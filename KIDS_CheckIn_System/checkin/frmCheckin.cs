using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace KIDS_CheckIn_System
{
    public partial class frmCheckin : Form
    {
        Connector js = new Connector();

        public long pollCase;
        public bool connActive = false;
        public bool autoDet;
        public bool dualPoll;
        public bool detect;
        public byte[] SendBuff = new byte[263];
        public byte[] RecvBuff = new byte[263];
        public int SendLen;
        public int RecvLen;
        public int nBytesRet;
        public int ATRLen;
        byte[] ATRVal = new byte[257];
        public ModWinsCard.SCARD_READERSTATE RdrState;
        public ModWinsCard.SCARD_IO_REQUEST ioRequest;
        public int dwState, dwActProtocol;
        public int retCode, hContext, hCard, Protocol, ReaderCount;
        string[] strReaderName = new string[10];

        string fldEventID = "";
        string fldRoomID = "";

        public frmCheckin()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            
            frmSystemOptions frm = new frmSystemOptions();
            frm.Show();
            this.Close();

            
        }

        private void frmCheckin_Load(object sender, EventArgs e)
        {
            txtRoom.Text = this.Tag.ToString();

            fldRoomID = js.Lookup("fldID", "tblRoom", "fldRoom='" + txtRoom.Text + "'");

            txtAge1.Text = js.Lookup("fldAgeFrom", "tblRoom", "fldRoom='" + txtRoom.Text + "'");
            txtAge2.Text = js.Lookup("fldAgeTo", "tblRoom", "fldRoom='" + txtRoom.Text + "'");

            string timetoday = DateTime.Now.ToString("hh:mm");

            string q = "SELECT * FROM tblEvent WHERE fldStartTime <= convert(time,'" + timetoday  + "') AND fldEndTime >=convert(time,'" + timetoday + "')";

            js.ExecuteQuery(q);

            js.RiD.Read();

            if(js.RiD.HasRows)
            { 
                fldEventID = "" +  js.RiD["fldID"].ToString();

                txtService.Text = js.RiD["fldEventTitle"].ToString();

                LoadAttendance();
            }

            js.CloseConnection();




            
           

            StartReader();


            this.BackgroundImage = Image.FromFile(Application.StartupPath + "/Pictures/kids back.jpg");

            

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblDateTime.Text = DateTime.Now.ToString("MMMM dd ,yyyy hh:mm:ss tt");
        }

        private void tmrReader_Tick(object sender, EventArgs e)
        {
            retCode = CardConnect(1);

            if (retCode != ModWinsCard.SCARD_S_SUCCESS)
            {

                //displayOut(5, 0, "No card within range.");
                //tsMsg2.Text = "";
                return;


            }

            //CheckCard();

            if (CheckCard())
            {

                //displayOut(5, 0, "Card is detected.");

                getParam();

                string tmpStr = "";
                int indx;

                for (indx = 0; indx <= RecvLen - 3; indx++)
                {

                    tmpStr = tmpStr + string.Format("{0:X2}", RecvBuff[indx]);

                }

                //tmrReader.Enabled = false;

                string kidid;

                if(rbCheckin.Checked)
                { 
                    if (ValidateCheckin(tmpStr,out kidid))
                    {
                        SaveCheckin(kidid);
                    }
                    else
                    {
                        js.showInformation("The Kids Already Checked-IN","Check-IN");
                    }
                }

                if (rbCheckout.Checked)
                {
                    string id = "";
                    if (ValidateCheckOut(tmpStr, out id))
                    {

                        //CheckOut(id);

                        string kID = js.Lookup("fldKidsID", "tblAttendance", "fldID='" + id + "'");


                        
                        btnConfirm.Tag = id;
                        LoadFetcher2(tmpStr);
                        btnScan.Enabled = false;
                        pFetchers.Visible = true;
                        pkids.Visible = true;

                        timer2.Enabled = true;
                        js.showInformation("Please Scan Card");
                        tmrReader.Enabled = false;
                        


                    }
                    else
                    {
                        js.showInformation("The Kids Already Checked-OUT", "Check-IN");
                    }
                }

                //txtKNFC.Text = tmpStr;
                //timer1.Enabled = false;
                //bStartPoll_Click(null, null);
            }

            else
            {

                //displayOut(5, 0, "No card within range.");
                //tsMsg2.Text = "";

                js.showExclamation("No Card Within Range", "Check-IN");

            }
            //timer1.Enabled = true;
            
        }

        private int CardConnect(int connType)
        {
            //bool functionReturnValue = false;

            if (connActive)
            {

                retCode = ModWinsCard.SCardDisconnect(hCard, ModWinsCard.SCARD_UNPOWER_CARD);

            }

            //Connect
            retCode = ModWinsCard.SCardConnect(hContext, strReaderName[0], ModWinsCard.SCARD_SHARE_SHARED, ModWinsCard.SCARD_PROTOCOL_T0 | ModWinsCard.SCARD_PROTOCOL_T1, ref hCard, ref Protocol);

            if (retCode != ModWinsCard.SCARD_S_SUCCESS)
            {

                if (connType != 1)
                {
                    //displayOut(1, retCode, "");
                }
                connActive = false;
                return retCode;
            }

            else
            {

                if (connType != 1)
                {

                    //displayOut(0, 0, "Successful connection to " + cbReader.Text);

                }

                //functionReturnValue = retCode;

            }
            return retCode;

        }

        private bool CheckCard()
        {
            bool functionReturnValue = false;

            //Variable declaration
            int ReaderLen = 0;
            long tmpWord;

            tmpWord = 32;
            ATRLen = Convert.ToInt32(tmpWord);

            retCode = ModWinsCard.SCardStatus(hCard, strReaderName[0], ref ReaderLen, ref dwState, ref dwActProtocol, ref ATRVal[0], ref ATRLen);

            if (retCode != ModWinsCard.SCARD_S_SUCCESS)
            {

                //Call DisplayOut(1, retCode, "")
                functionReturnValue = false;
                return functionReturnValue;
            }

            else
            {

                InterpretATR();
                functionReturnValue = true;

            }
            return functionReturnValue;

        }

        private void InterpretATR()
        {

            string RIDVal, cardName, sATRStr, lATRStr, tmpVal;
            int indx, indx2;

            //4. Interpret ATR and guess card
            // 4.1. Mifare cards using ISO 14443 Part 3 Supplemental Document
            if ((int)(ATRLen) > 14)
            {

                RIDVal = "";
                sATRStr = "";
                lATRStr = "";

                for (indx = 7; indx <= 11; indx++)
                {

                    RIDVal = RIDVal + " " + string.Format("{0:X2}", ATRVal[indx]);

                }


                for (indx = 0; indx <= 4; indx++)
                {

                    //shift bit to right
                    tmpVal = ATRVal[indx].ToString();

                    for (indx2 = 1; indx2 <= 4; indx2++)
                    {

                        tmpVal = Convert.ToString(Convert.ToInt32(tmpVal) / 2);

                    }

                    if (((indx == '1') & (tmpVal == "8")))
                    {

                        lATRStr = lATRStr + "8X";
                        sATRStr = sATRStr + "8X";
                    }

                    else
                    {

                        if (indx == 4)
                        {

                            lATRStr = lATRStr + " " + string.Format("{0:X2}", ATRVal[indx]);
                        }

                        else
                        {

                            lATRStr = lATRStr + " " + string.Format("{0:X2}", ATRVal[indx]);
                            sATRStr = sATRStr + " " + string.Format("{0:X2}", ATRVal[indx]);

                        }

                    }

                }

                cardName = "";

                // Felica and Topaz Cards
                if (ATRVal[12] == 0x03)
                {
                    if (ATRVal[13] == 0xF0)
                    {
                        switch (ATRVal[14])
                        {
                            case 0x11:
                                cardName = " FeliCa 212K";
                                break;
                            case 0x12:
                                cardName = " Felica 424K";
                                break;
                            case 0x04:
                                cardName = " Topaz";
                                break;

                        }

                    }
                }


                if (ATRVal[12] == 0x03)
                {

                    if (ATRVal[13] == 0x00)
                    {

                        switch (ATRVal[14])
                        {

                            case 0x01:
                                cardName = cardName + " Mifare Standard 1K";
                                break;
                            case 0x02:
                                cardName = cardName + " Mifare Standard 4K";
                                break;
                            case 0x03:
                                cardName = cardName + " Mifare Ultra light";
                                break;
                            case 0x04:
                                cardName = cardName + " SLE55R_XXXX";
                                break;
                            case 0x06:
                                cardName = cardName + " SR176";
                                break;
                            case 0x07:
                                cardName = cardName + " SRI X4K";
                                break;
                            case 0x08:
                                cardName = cardName + " AT88RF020";
                                break;
                            case 0x09:
                                cardName = cardName + " AT88SC0204CRF";
                                break;
                            case 0x0A:
                                cardName = cardName + " AT88SC0808CRF";
                                break;
                            case 0x0B:
                                cardName = cardName + " AT88SC1616CRF";
                                break;
                            case 0x0C:
                                cardName = cardName + " AT88SC3216CRF";
                                break;
                            case 0x0D:
                                cardName = cardName + " AT88SC6416CRF";
                                break;
                            case 0x0E:
                                cardName = cardName + " SRF55V10P";
                                break;
                            case 0xF:
                                cardName = cardName + " SRF55V02P";
                                break;
                            case 0x10:
                                cardName = cardName + " SRF55V10S";
                                break;
                            case 0x11:
                                cardName = cardName + " SRF55V02S";
                                break;
                            case 0x12:
                                cardName = cardName + " TAG IT";
                                break;
                            case 0x13:
                                cardName = cardName + " LRI512";
                                break;
                            case 0x14:
                                cardName = cardName + " ICODESLI";
                                break;
                            case 0x15:
                                cardName = cardName + " TEMPSENS";
                                break;
                            case 0x16:
                                cardName = cardName + " I.CODE1";
                                break;
                            case 0x17:
                                cardName = cardName + " PicoPass 2K";
                                break;
                            case 0x18:
                                cardName = cardName + " PicoPass 2KS";
                                break;
                            case 0x19:
                                cardName = cardName + " PicoPass 16K";
                                break;
                            case 0x1A:
                                cardName = cardName + " PicoPass 16KS";
                                break;
                            case 0x1B:
                                cardName = cardName + " PicoPass 16K(8x2)";
                                break;
                            case 0x1C:
                                cardName = cardName + " PicoPass 16KS(8x2)";
                                break;

                            case 0x1D:
                                cardName = cardName + " PicoPass 32KS(16+16)";
                                break;
                            case 0x1E:
                                cardName = cardName + " PicoPass 32KS(16+8x2)";
                                break;
                            case 0x1F:
                                cardName = cardName + " PicoPass 32KS(8x2+16)";
                                break;
                            case 0x20:
                                cardName = cardName + " PicoPass 32KS(8x2+8x2)";
                                break;
                            case 0x21:
                                cardName = cardName + " LRI64";
                                break;
                            case 0x22:
                                cardName = cardName + " I.CODE UID";
                                break;
                            case 0x23:
                                cardName = cardName + " I.CODE EPC";
                                break;
                            case 0x24:
                                cardName = cardName + " LRI12";
                                break;
                            case 0x25:
                                cardName = cardName + " LRI128";
                                break;
                            case 0x26:
                                cardName = cardName + " Mifare Mini";
                                break;

                        }
                    }

                    else
                    {

                        if (ATRVal[13] == 0xFF)
                        {

                            switch (ATRVal[14])
                            {

                                case 0x09:
                                    cardName = cardName + " Mifare Mini";
                                    break;

                            }

                        }

                    }

                    //displayOut(6, 0, cardName);

                }

            }

            //4.2. Mifare DESFire card using ISO 14443 Part 4
            if ((int)ATRLen == 11)
            {

                RIDVal = "";

                for (indx = 4; indx <= 9; indx++)
                {

                    RIDVal = RIDVal + " " + string.Format("{0:X2}", ATRVal[indx]);

                }

                if (RIDVal == " 06 75 77 81 02 80")
                {

                    //displayOut(6, 0, "Mifare DESFire");

                }

            }

            //4.3. Other cards using ISO 14443 Part 4
            if ((int)ATRLen == 17)
            {

                RIDVal = "";

                for (indx = 4; indx <= 15; indx++)
                {

                    RIDVal = RIDVal + " " + string.Format("{0:X2}", RecvBuff[indx]);

                }

                if (RIDVal == "50122345561253544E3381C3")
                {

                    //displayOut(6, 0, "ST19XRC8E");

                }

            }

            //4.4. other cards using ISO 14443 Type A or B
            lATRStr = "";
            sATRStr = "";

            if (lATRStr == "3B8X800150")
            {

                //displayOut(6, 0, "ISO 14443B ");
            }

            else
            {

                if (sATRStr == "3B8X8001")
                {

                    //displayOut(6, 0, "ISO 14443A");

                }

            }


        }

        private void StartReader()
        {
            //for Initializing the reader

            string ReaderList = "" + Convert.ToChar(0);
            int indx;
            int pcchReaders = 0;
            string rName = "";

            // Establish Context
            retCode = ModWinsCard.SCardEstablishContext(ModWinsCard.SCARD_SCOPE_USER, 0, 0, ref hContext);

            if (retCode != ModWinsCard.SCARD_S_SUCCESS)
            {

                //displayOut(1, retCode, "");

                return;

            }

            // 2. List PC/SC card readers installed in the system

            retCode = ModWinsCard.SCardListReaders(this.hContext, null, null, ref pcchReaders);

            if (retCode != ModWinsCard.SCARD_S_SUCCESS)
            {

                MessageBox.Show("Card Reader not connected", "", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            //EnableButtons();

            byte[] ReadersList = new byte[pcchReaders];

            // Fill reader list
            retCode = ModWinsCard.SCardListReaders(this.hContext, null, ReadersList, ref pcchReaders);

            if (retCode != ModWinsCard.SCARD_S_SUCCESS)
            {
                MessageBox.Show("SCardListReaders Error: " + ModWinsCard.GetScardErrMsg(retCode));

                return;
            }
            else
            {
                //displayOut(0, 0, " ");
            }

            rName = "";
            indx = 0;
            int index = 0;

            // Convert reader buffer to string
            while (ReadersList[indx] != 0)
            {


                while (ReadersList[indx] != 0)
                {
                    rName = rName + (char)ReadersList[indx];
                    indx = indx + 1;
                }

                //Add reader name to list
                //cbReader.Items.Add(rName);
                strReaderName[index] = rName;
                rName = "";
                indx = indx + 1;
                index++;

            }


            //CONNECTING TO THE READER
            retCode = ModWinsCard.SCardConnect(hContext, strReaderName[0], ModWinsCard.SCARD_SHARE_SHARED,
                                          ModWinsCard.SCARD_PROTOCOL_T0 | ModWinsCard.SCARD_PROTOCOL_T1, ref hCard, ref Protocol);

            if (retCode != ModWinsCard.SCARD_S_SUCCESS)
            {
                MessageBox.Show("Please Scan Card", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                timer1.Enabled = true;
            }  //displayOut(1, retCode, "");
            else
            {
                //displayOut(0, 0, "Successful connection to " + cbReader.Text);
                MessageBox.Show("Reader Connected", "", MessageBoxButtons.OK, MessageBoxIcon.Information);


                timer1.Enabled = true;

            }
            connActive = true;
        }

        private void ClearBuffers()
        {

            long indx;

            for (indx = 0; indx <= 262; indx++)
            {

                RecvBuff[indx] = 0;
                SendBuff[indx] = 0;

            }

        }

        private void getParam()
        {

            // get the PICC Operating Parameter of the reader.
            ClearBuffers();
            SendBuff[0] = 0xFF;
            SendBuff[1] = 0xCA;
            SendBuff[2] = 0x00;
            SendBuff[3] = 0x00;
            SendBuff[4] = 0x04;
            SendLen = 5;
            RecvLen = 2;

            retCode = Transmit();

            if (retCode != ModWinsCard.SCARD_S_SUCCESS)
            {
                return;
            }

        }

        private int Transmit()
        {

            ioRequest.dwProtocol = Protocol;
            ioRequest.cbPciLength = 8;


            RecvLen = 262;

            // Issue SCardTransmit
            retCode = ModWinsCard.SCardTransmit(hCard, ref ioRequest, ref SendBuff[0], SendLen, ref ioRequest, ref RecvBuff[0], ref RecvLen);

            if (retCode != ModWinsCard.SCARD_S_SUCCESS)
            {

                //displayOut(1, retCode, "");


            }
            return retCode;


        }



        //FOR NFC
        private bool ValidateCheckin(string NFC, out string kidid)
        {
            string kid = js.Lookup("fldKidID", "tblKidsNFC", "fldNFCCode='" + NFC + "'");
            string id = js.Lookup("fldID", "tblAttendance", "fldKidsID='" + kid + "' AND fldLoginDateTime BETWEEN '" + DateTime.Now.ToShortDateString() + " 00:00:00' AND '" + DateTime.Now.ToShortDateString() + " 23:59:59'");

            if (id == "")
            {
                kidid = kid;
                return true;
                
            }
            else
            {
                kidid = kid;
                return false;
            }
        }

        //FOR NFC
        private bool ValidateCheckOut(string NFC, out string kid)
        {
            string kid2 = js.Lookup("fldFetcherID", "tblFetcherNFC", "fldNFCCode='" + NFC + "'");
            //string id2 = js.Lookup("fldID", "tblAttendance", "fldKidsID='" + kid + "' AND fldLogoutDateTime BETWEEN '" + DateTime.Now.ToShortDateString() + " 00:00:00' AND '" + DateTime.Now.ToShortDateString() + " 23:59:59'");

            if (kid2 == "")
            {
                kid = kid2;
                return false;

            }
            else
            {
                kid = kid2;
                return true;
            }
        }

        //FOR BARCODE
        private bool ValidateCheckOut2(string Barcode, out string id)
        {
            string kid = js.Lookup("fldID", "tblKids", "fldStudentID='" + Barcode + "'");
            string id2 = js.Lookup("fldID", "tblAttendance", "fldKidsID='" + kid + "' AND fldLogoutDateTime BETWEEN '" + DateTime.Now.ToShortDateString() + " 00:00:00' AND '" + DateTime.Now.ToShortDateString() + " 23:59:59'");

            if (id2 == "")
            {
                id = id2;
                return true;

            }
            else
            {
                id = id2;
                return false;
            }
        }
        //FOR BARCODE
        private bool ValidateCheckin2(string BarCode, out string kidid)
        {
            string kid = js.Lookup("fldID", "tblKids", "fldStudentID='" + BarCode + "'");
            string id = js.Lookup("fldID", "tblAttendance", "fldKidsID='" + kid + "' AND fldLoginDateTime BETWEEN '" + DateTime.Now.ToShortDateString() + " 00:00:00' AND '" + DateTime.Now.ToShortDateString() + " 23:59:59'");

            if (id == "")
            {
                kidid = kid;
                return true;

            }
            else
            {
                kidid = kid;
                return false;
            }
        }

        private void SaveCheckin(string kidid)
        {
            if(kidid=="")
            {
                return;
            }

            DataGridViewImageColumn img = new DataGridViewImageColumn();

            string pathfile = js.GetPath() + "/Kids/" + js.Lookup("fldPicture","tblKids","fldID='" + kidid + "'");

            string roomid = js.Lookup("fldID", "tblRoom", "fldRoom='" + txtRoom.Text + "'");

            string firstname = js.Lookup("fldFirstName", "tblKids", "fldID='" + kidid + "'");
            string Lastname = js.Lookup("fldLastName", "tblKids", "fldID='" + kidid + "'");
            
            
            if(System.IO.File.Exists(pathfile))
            {
                img.Image = Image.FromFile(pathfile);

                img.Image = (Image)(new Bitmap(img.Image, new Size(150, 150)));
            }

            pbImageKid.Image = img.Image;

            txtName.Text = firstname + " " + Lastname;

            txtBirthday.Text = Convert.ToDateTime(js.Lookup("fldBirthday", "tblKids", "fldID='" + kidid + "'")).ToShortDateString();

            txtAllergies.Text = js.Lookup("fldAllergies", "tblKids", "fldID='" + kidid + "'");

            txtBarcode.Text = js.Lookup("fldStudentID", "tblKids", "fldID='" + kidid + "'");

            txtNFC.Text = js.Lookup("fldNFCCode", "tblKidsNFC", "fldKidID='" + kidid + "'");

            string q = "INSERT INTO tblAttendance(fldRoomID,fldChurch,fldLoginDateTime,fldKidsID,fldEventID) VALUES('" + roomid + "','" + 1 + "','" + DateTime.Now.ToString() + "','" + kidid + "','" + fldEventID  + "')";

            js.ExecuteNonQuery(q);

            dataGridView1.Rows.Add(kidid,img.Image);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if(txtNote.Enabled == false)
            {
                btnAdd.Enabled = true;
                txtNote.Enabled = true;
            }
            else
            {
                btnAdd.Enabled = false;
                txtNote.Enabled = false;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string datefrom = DateTime.Now.ToString("MM/dd/yyyy 00:00:00");
            string dateto = DateTime.Now.ToString("MM/dd/yyyy 23:59:59");

            string id = dataGridView1.CurrentRow.Cells["KidID"].Value.ToString();

            string q = "UPDATE tblAttendance SET fldRemarks='" + txtNote.Text + "' WHERE fldKidsID='" + id + "' AND fldLoginDateTime BETWEEN '" + datefrom + "' AND '" + dateto + "'";

            js.ExecuteNonQuery(q);

            js.showInformation("Note Added!", "Check-IN | Add Note");

            linkLabel1_LinkClicked(null, null);
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string id = dataGridView1.CurrentRow.Cells["KidID"].Value.ToString();

            string datefrom = DateTime.Now.ToString("MM/dd/yyyy 00:00:00");
            string dateto = DateTime.Now.ToString("MM/dd/yyyy 23:59:59");

            pbImageKid.Image =(Image) dataGridView1.CurrentCell.Value;

            txtNote.Text = js.Lookup("fldRemarks","tblAttendance","fldKidsID='" + id + "' AND fldLoginDateTime BETWEEN '" + datefrom + "' AND '" + dateto + "'");

            //txtName.Text = js.Lookup("")

            string firstname = js.Lookup("fldFirstName", "tblKids", "fldID='" + id + "'");
            string Lastname = js.Lookup("fldLastName", "tblKids", "fldID='" + id + "'");

            txtName.Text = firstname + " " + Lastname;

            txtBirthday.Text = Convert.ToDateTime(js.Lookup("fldBirthday", "tblKids", "fldID='" + id + "'")).ToShortDateString();

            txtAllergies.Text = js.Lookup("fldAllergies", "tblKids", "fldID='" + id + "'");

            txtBarcode.Text = js.Lookup("fldStudentID", "tblKids", "fldID='" + id + "'");

            txtNFC.Text = js.Lookup("fldNFCCode", "tblKidsNFC", "fldKidID='" + id + "'");

        }

        private void LoadAttendance()
        {
            string q = "SELECT * FROM tblAttendance WHERE fldLoginDateTime BETWEEN '" + DateTime.Now.ToShortDateString() + " 00:00:00' AND '" + DateTime.Now.ToShortDateString()  + " 23:59:59' AND fldEventID='" + fldEventID + "' AND fldRoomID='" + fldRoomID + "'";

            js.ExecuteQuery(q);

            //string bc = js.getBarcode();

            while(js.RiD.Read())
            {


                 string DBServer = System.IO.File.ReadAllText(Application.StartupPath + "/server.dat");
                 string DBase = "Kids_Checkin";
                 string DBUser = "kidschurch";
                 string DBPass = "1nt3gr1ty@ENLI";

                 string connectionstring = "Server=" + DBServer + ";Database=" + DBase + ";User Id=" + DBUser + ";Password=" + DBPass + ";";

                 SqlConnection connection = new SqlConnection(connectionstring);
                 SqlCommand command = new SqlCommand();
                 SqlDataReader RiD;

                string kidID = js.RiD["fldKidsID"].ToString();

                string qry = "SELECT * FROM tblKids WHERE fldID='" + kidID + "'";


                connection.Open();
                command.CommandText = qry;
                command.Connection = connection;

                RiD = command.ExecuteReader();

                RiD.Read();

                DataGridViewImageColumn img = new DataGridViewImageColumn();

                string pic = RiD["fldPicture"].ToString();

                string picture = js.GetPath() + "/Kids/" + pic;

                if(System.IO.File.Exists(picture))
                {
                    img.Image = Image.FromFile(picture);
                    img.Image = (Image)(new Bitmap(img.Image, new Size(150, 150)));
                }
                else
                {
                    img.Image = Image.FromFile(Application.StartupPath + "/Pictures/download.jpg");
                    img.Image = (Image)(new Bitmap(img.Image, new Size(150, 150)));
                }

                dataGridView1.Rows.Add(kidID, img.Image);

                connection.Close();
                command.Dispose();
                RiD.Close();


            }
        }



        private void rbNFC_CheckedChanged(object sender, EventArgs e)
        {
            if (rbNFC.Checked)
            {
                StartReader();
                tmrReader.Enabled = true;
            }
        }

        private void rbBarcode_CheckedChanged(object sender, EventArgs e)
        {
            if(rbBarcode.Checked)
            { 
                tmrReader.Enabled = false;
                string value = "";
                    if (js.InputBox("Check-In", "Please Scan Barcode", ref value) == System.Windows.Forms.DialogResult.OK)
                    {
                        string kidid;
                        string id;

                        if (rbCheckin.Checked)
                        {
                            if (ValidateCheckin2(value, out kidid))
                            {
                                SaveCheckin(kidid);
                            }
                            else
                            {
                                js.showInformation("The Kids Already Checked-IN", "Check-IN");
                            }
                        }

                        if (rbCheckout.Checked)
                        {
                            if (ValidateCheckOut2(value, out id))
                            {

                                //CheckOut(id);

                                string kID = js.Lookup("fldKidsID", "tblAttendance", "fldID='" + id + "'");
                                btnConfirm.Tag = id;
                                btnScan.Enabled = true;
                                LoadFetcher(kID);
                                pFetchers.Visible = true;
                                pkids.Visible = true;
                                
                                
                            }
                            else
                            {
                                js.showInformation("The Kids Already Checked-OUT", "Check-IN");
                            }
                        }

                    }
    
               
            }
        }


        private void LoadFetcher(string kidid)
        {
            string [] fID = new string [3];

            string q = "SELECT * FROM tblKidFetcher WHERE fldKidID='" + kidid + "'";

            js.ExecuteQuery(q);
            int i = 0;
            while(js.RiD.Read())
            {
                fID[i] = js.RiD["fldFetcherID"].ToString();

                i++;
            }

            js.CloseConnection();

            string pic1 = "";
            string pic2 = "";
            string pic3 = "";
            string name1 = "";
            string name2 = "";
            string name3 = "";



            pic1 = js.GetPath() + "/Fetchers/" + js.Lookup("fldPicture", "tblFetcher", "fldID='" + fID[0] + "'");
            pic2 = js.GetPath() + "/Fetchers/" + js.Lookup("fldPicture", "tblFetcher", "fldID='" + fID[1] + "'");
            pic3 = js.GetPath() + "/Fetchers/" + js.Lookup("fldPicture", "tblFetcher", "fldID='" + fID[2] + "'");

            name1 = js.Lookup("fldFirstName", "tblFetcher", "fldID='" + fID[0] + "'") + " " + js.Lookup("fldLastName", "tblFetcher", "fldID='" + fID[0] + "'");
            name2 = js.Lookup("fldFirstName", "tblFetcher", "fldID='" + fID[1] + "'") + " " + js.Lookup("fldLastName", "tblFetcher", "fldID='" + fID[1] + "'");
            name3 = js.Lookup("fldFirstName", "tblFetcher", "fldID='" + fID[2] + "'") + " " + js.Lookup("fldLastName", "tblFetcher", "fldID='" + fID[2] + "'");

            

            if(System.IO.File.Exists(pic1))
            {
                pb1.Image = Image.FromFile(pic1);
                
            }
            else
            {
                pb1.Image = Image.FromFile(Application.StartupPath + "/Pictures/download.jpg");
            }

            if (System.IO.File.Exists(pic2))
            {
                pb2.Image = Image.FromFile(pic2);
            }
            else
            {
                pb2.Image = Image.FromFile(Application.StartupPath + "/Pictures/download.jpg");
            }

            if (System.IO.File.Exists(pic3))
            {
                pb3.Image = Image.FromFile(pic3);
            }
            else
            {
                pb3.Image = Image.FromFile(Application.StartupPath + "/Pictures/download.jpg");
            }

            lblName1.Text = name1;
            lblName2.Text = name2;
            lblName3.Text = name3;


        }

        private void LoadFetcher2(string kidid)
        {
            string[] fID = new string[4];

            string q = "SELECT * FROM tblFetcherNFC WHERE fldNFCCode='" + kidid + "'";

            js.ExecuteQuery(q);
            int i = 0;
            while (js.RiD.Read())
            {
                fID[i] = js.RiD["fldFetcherID"].ToString();

                i++;
            }

            js.CloseConnection();

            string pic1 = "";
            string pic2 = "";
            string pic3 = "";
            string name1 = "";
            string name2 = "";
            string name3 = "";



            pic1 = js.GetPath() + "/Fetchers/" + js.Lookup("fldPicture", "tblFetcher", "fldID='" + fID[0] + "'");
            pic2 = js.GetPath() + "/Fetchers/" + js.Lookup("fldPicture", "tblFetcher", "fldID='" + fID[1] + "'");
            pic3 = js.GetPath() + "/Fetchers/" + js.Lookup("fldPicture", "tblFetcher", "fldID='" + fID[2] + "'");

            name1 = js.Lookup("fldFirstName", "tblFetcher", "fldID='" + fID[0] + "'") + " " + js.Lookup("fldLastName", "tblFetcher", "fldID='" + fID[0] + "'");
            name2 = js.Lookup("fldFirstName", "tblFetcher", "fldID='" + fID[1] + "'") + " " + js.Lookup("fldLastName", "tblFetcher", "fldID='" + fID[1] + "'");
            name3 = js.Lookup("fldFirstName", "tblFetcher", "fldID='" + fID[2] + "'") + " " + js.Lookup("fldLastName", "tblFetcher", "fldID='" + fID[2] + "'");



            if (System.IO.File.Exists(pic1))
            {
                pb1.Image = Image.FromFile(pic1);

            }
            else
            {
                pb1.Image = Image.FromFile(Application.StartupPath + "/Pictures/download.jpg");
            }

            if (System.IO.File.Exists(pic2))
            {
                pb2.Image = Image.FromFile(pic2);
            }
            else
            {
                pb2.Image = Image.FromFile(Application.StartupPath + "/Pictures/download.jpg");
            }

            if (System.IO.File.Exists(pic3))
            {
                pb3.Image = Image.FromFile(pic3);
            }
            else
            {
                pb3.Image = Image.FromFile(Application.StartupPath + "/Pictures/download.jpg");
            }

            lblName1.Text = name1;
            lblName2.Text = name2;
            lblName3.Text = name3;


        }

        private void CheckOut(string attendanceID)
        {
            string remarks = js.Lookup("fldRemarks", "tblAttendance", "fldID='" + attendanceID + "'");

            remarks += ";Logged out: " + DateTime.Now.ToString();
            string q = "Update tblAttendance SET fldLogoutDateTime='" + DateTime.Now.ToString() + "',fldRemarks='" + remarks +  "' WHERE fldID='" + attendanceID + "'";
            js.ExecuteNonQuery(q);

            js.showInformation("Kid Successfully Checked OUT", "Check-OUT");
        }

        private void btnScan_Click(object sender, EventArgs e)
        {
            string value = "";
            if(js.InputBox("Check Out","Please Scan Barcode",ref value)== System.Windows.Forms.DialogResult.OK)
            {
                string q = "SELECT * FROM tblKids WHERE fldStudentID = '" + value + "'";
                js.ExecuteQuery(q);

                js.RiD.Read();

                string p = js.GetPath() + "/Kids/" + js.RiD["fldPicture"];

                if(System.IO.File.Exists(p))
                { 
                    pbK1.Image = Image.FromFile(p);
                    lblKName.Text = "" + js.RiD["fldFirstName"] + " " + js.RiD["fldLastName"];
                    lblBarcode.Text = value;
                    lblBirthday.Text = Convert.ToDateTime(js.RiD["fldBirthday"].ToString()).ToString("MM/dd/yyyy");
                    btnConfirm.Enabled = true;
                }
                
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            CheckOut(btnConfirm.Tag.ToString());
            
            if(rbBarcode.Checked)
            {
                rbBarcode_CheckedChanged(null, null);
            }

            tmrReader.Enabled = true;

            //dataGridView1.Rows.Clear();
           
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            retCode = CardConnect(1);

            if (retCode != ModWinsCard.SCARD_S_SUCCESS)
            {

                //displayOut(5, 0, "No card within range.");
                //tsMsg2.Text = "";
                return;


            }

            //CheckCard();

            if (CheckCard())
            {

                //displayOut(5, 0, "Card is detected.");

                getParam();

                string tmpStr = "";
                int indx;

                for (indx = 0; indx <= RecvLen - 3; indx++)
                {

                    tmpStr = tmpStr + string.Format("{0:X2}", RecvBuff[indx]);

                }

                //tmrReader.Enabled = false;

                string id = js.Lookup("fldKidID","tblKidsNFC","fldNFCCode='" + tmpStr + "'");
                string q = "SELECT  * FROM tblKids WHERE fldID='" + id + "'";

                js.ExecuteQuery(q);

                js.RiD.Read();

                string pic = js.GetPath() + "/Kids/" + js.RiD["fldPicture"];

                if(System.IO.File.Exists(pic))
                {
                    pbK1.Image = Image.FromFile(pic);

                }
                lblKName.Text = "" + js.RiD["fldFirstName"] + " " + js.RiD["fldLastName"];
                lblBarcode.Text = "" + js.RiD["fldStudentID"];
                lblBirthday.Text = Convert.ToDateTime(js.RiD["fldBirthday"]).ToShortDateString();
                btnConfirm.Enabled = true;
                timer2.Enabled = false;
               

                //txtKNFC.Text = tmpStr;
                //timer1.Enabled = false;
                //bStartPoll_Click(null, null);
            }

            else
            {

                //displayOut(5, 0, "No card within range.");
                //tsMsg2.Text = "";

                js.showExclamation("No Card Within Range", "Check-IN");

            }
            //timer1.Enabled = true;
        }

        private void rbCheckin_CheckedChanged(object sender, EventArgs e)
        {
            if(rbCheckin.Checked)
            {
                pFetchers.Visible = false;
                pkids.Visible = false;
            }
        }

       

    }

}
