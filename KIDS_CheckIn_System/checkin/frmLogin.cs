using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KIDS_CheckIn_System
{
    public partial class frmLogin : Form
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

        string fldGroupID = "";

        NotifyIcon icon = new NotifyIcon();

        string AttendanceID = "";

        string fldEventID = "";
        string fldRoomID = "";

        public frmLogin()
        {
            InitializeComponent();
        }

        

        
        private void btnClose_Click(object sender, EventArgs e)
        {
            if(js.showQuestion("Are you sure you want to close this form?","Kids Check-In")== System.Windows.Forms.DialogResult.Yes)
            {
                tmrReader.Enabled = false;
                frmSystemOptions frm = new frmSystemOptions();
                frm.Show();
                icon.Visible = false;
                this.Close();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string datefrom = DateTime.Now.ToString("MM/dd/yyyy 00:00:00");
            string dateto = DateTime.Now.ToString("MM/dd/yyyy 23:59:59");

            string studentid = js.Lookup("fldID", "tblKids", "fldStudentID='" + txtBarcode.Text + "'");

            string q = "UPDATE tblAttendance SET fldRemarks='" + txtNote.Text + "' WHERE fldKidsID='" + studentid + "' AND fldLoginDateTime BETWEEN '" + datefrom + "' AND '" + dateto + "'";

            js.ExecuteNonQuery(q);

            js.showInformation("Note Added!", "Check-IN | Add Note");
            linkLabel1_LinkClicked(null, null);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (txtNote.Enabled == false)
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblDateTime.Text = DateTime.Now.ToString("MMMM dd ,yyyy hh:mm:ss tt");
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

            js = new Connector(AccessRegistryTool.ReadValue("DBServer"),"Kids_Checkin","kidschurch","1nt3gr1ty@ENLI");

            icon.Icon = new Icon(Application.StartupPath + @"\kids-icon.ico");
            icon.Visible = true;

            txtRoom.Text = this.Tag.ToString();

            lblConnected.Text = "Connected To: " + AccessRegistryTool.ReadValue("DBServer");

            fldRoomID = js.Lookup("fldID", "tblRoom", "fldRoom='" + txtRoom.Text + "'");

            string eID = js.Lookup("fldID", "tblCustomizedEvent", "fldEventCode='" + this.Text + "'");

            lblTotal.Text = js.Lookup("fldMaxCapacity", "tblCustomizedEventRooms", "fldRoomID='" + fldRoomID + "' AND fldCEventID='" + eID + "'");

            txtAge1.Text = js.Lookup("fldAgeFrom", "tblCustomizedEventRooms", "fldRoomID='" + fldRoomID + "' AND fldCEventID='" + eID + "'");
            txtAge2.Text = js.Lookup("fldAgeTo", "tblCustomizedEventRooms", "fldRoomID='" + fldRoomID + "' AND fldCEventID='" + eID + "'");

            fldGroupID = js.Lookup("fldID","tblGroup","fldAgeFrom='" + txtAge1.Text + "' AND fldAgeTo='" + txtAge2.Text + "'");



            if(Convert.ToInt32(txtAge1.Text)< 7)
            {
                btnAddPoints.Enabled = false;
            }

            string timetoday = DateTime.Now.ToString("hh:mm tt");

            string q = "SELECT * FROM tblEvent WHERE fldRegistrationTime <= convert(time,'" + timetoday + "') AND fldEndTime >=convert(time,'" + timetoday + "')";

            js.ExecuteQuery(q);

            js.RiD.Read();

            lblNotification.Text = "";

            if (js.RiD.HasRows)
            {
                fldEventID = "" + js.RiD["fldID"].ToString();

                txtService.Text = js.RiD["fldEventTitle"].ToString();

                LoadAttendance();
                LoadBirthdays();
                LoadNewComer();
                LoadVolunteer();
                dgvAttendance_CellContentClick(null,null);
            }
            else
            {
                js.showExclamation("Cannot open an event yet!, Please try again later");
                frmSystemOptions frm = new frmSystemOptions();
                frm.Show();
                Close();
                return;
            }

            js.CloseConnection();

            StartReader();

            string mode = AccessRegistryTool.ReadValue("RegMode");

            if(mode=="Barcode")
            {
                tmrReader.Enabled = false;
                //rbBarcode_CheckedChanged(null, null);
                
            }
            else
            {
                tmrReader.Enabled = true;
            }


            //this.BackgroundImage = Image.FromFile(Application.StartupPath + "/Pictures/kids back.jpg");
        }

        private void LoadAttendance()
        {
            try
            {
                string q = "SELECT * FROM tblAttendance WHERE fldLoginDateTime BETWEEN '" + DateTime.Now.ToShortDateString() + " 00:00:00' AND '" + DateTime.Now.ToShortDateString() + " 23:59:59' AND fldEventID='" + fldEventID + "' AND fldRoomID='" + fldRoomID + "' AND fldLogoutDateTime IS NULL ORDER BY fldID DESC";

                js.ExecuteQuery(q);

                //string bc = js.getBarcode();
                dgvAttendance.Rows.Clear();
                while (js.RiD.Read())
                {


                    string DBServer = AccessRegistryTool.ReadValue("DBServer");
                    string DBase = "Kids_Checkin";
                    string DBUser = "kidschurch";
                    string DBPass = "1nt3gr1ty@ENLI";

                    string connectionstring = "Server=" + DBServer + ";Database=" + DBase + ";User Id=" + DBUser + ";Password=" + DBPass + ";";

                    Connector kid = new Connector(DBServer, DBase, DBUser, DBPass);

                    string kidID = js.RiD["fldKidsID"].ToString();

                    string id = "";

                    string qry = "SELECT * FROM tblKids WHERE fldStudentID='" + kidID + "'";


                    kid.ExecuteQuery(qry);

                    kid.RiD.Read();

                    DataGridViewImageColumn img = new DataGridViewImageColumn();

                    string pic = kid.RiD["fldPicture"].ToString();
                    id = kid.RiD["fldID"].ToString();

                    string picture = js.GetPath() + "/Kids/" + pic;

                    if (System.IO.File.Exists(picture))
                    {
                        img.Image = Image.FromFile(picture);
                        img.Image = (Image)(new Bitmap(img.Image, new Size(150, 150)));
                    }
                    else
                    {
                        img.Image = Image.FromFile(Application.StartupPath + "/Pictures/download.jpg");
                        img.Image = (Image)(new Bitmap(img.Image, new Size(150, 150)));
                    }

                    dgvAttendance.Rows.Add(id, img.Image);

                    kid.CloseConnection();


                }

                js.CloseConnection();
            }
            catch(Exception ex)
            {

            }
        }

        private void LoadBirthdays()
        {
            try
            {
                string q = "SELECT * FROM tblAttendance WHERE fldLoginDateTime BETWEEN '" + DateTime.Now.ToShortDateString() + " 00:00:00' AND '" + DateTime.Now.ToShortDateString() + " 23:59:59' AND fldEventID='" + fldEventID + "' AND fldRoomID='" + fldRoomID + "' AND fldLogoutDateTime IS NULL ORDER BY fldID DESC";

                js.ExecuteQuery(q);

                //string bc = js.getBarcode();
                dgvBirthdays.Rows.Clear();
                while (js.RiD.Read())
                {


                    string DBServer = AccessRegistryTool.ReadValue("DBServer");
                    string DBase = "Kids_Checkin";
                    string DBUser = "kidschurch";
                    string DBPass = "1nt3gr1ty@ENLI";

                    string connectionstring = "Server=" + DBServer + ";Database=" + DBase + ";User Id=" + DBUser + ";Password=" + DBPass + ";";

                    Connector kid = new Connector(DBServer, DBase, DBUser, DBPass);

                    string kidID = js.RiD["fldKidsID"].ToString();
                    string id = "";

                    string qry = "SELECT * FROM tblKids WHERE fldStudentID='" + kidID + "'";


                    kid.ExecuteQuery(qry);

                    kid.RiD.Read();

                    DataGridViewImageColumn img = new DataGridViewImageColumn();

                    string pic = kid.RiD["fldPicture"].ToString();
                    id = kid.RiD["fldID"].ToString();

                    string picture = js.GetPath() + "/Kids/" + pic;

                    if (System.IO.File.Exists(picture))
                    {
                        img.Image = Image.FromFile(picture);
                        img.Image = (Image)(new Bitmap(img.Image, new Size(150, 150)));
                    }
                    else
                    {
                        img.Image = Image.FromFile(Application.StartupPath + "/Pictures/download.jpg");
                        img.Image = (Image)(new Bitmap(img.Image, new Size(150, 150)));
                    }

                    DateTime sdate = Convert.ToDateTime(DateTime.Now.ToString("MM/dd"));
                    DateTime edate = sdate.AddDays(6);
                    DateTime bd = Convert.ToDateTime(Convert.ToDateTime(kid.RiD["fldBirthday"]).ToString("MM/dd"));

                    if (bd >= sdate && bd <= edate)
                    {
                        dgvBirthdays.Rows.Add(id, img.Image);

                    }

                    kid.CloseConnection();


                }
            }
            catch(Exception ex)
            {

            }
        }

        private void LoadNewComer()
        {
            try
            {
                string q = "SELECT * FROM tblAttendance WHERE fldLoginDateTime BETWEEN '" + DateTime.Now.ToShortDateString() + " 00:00:00' AND '" + DateTime.Now.ToShortDateString() + " 23:59:59' AND fldEventID='" + fldEventID + "' AND fldRoomID='" + fldRoomID + "' AND fldLogoutDateTime IS NULL ORDER BY fldID DESC";

                js.ExecuteQuery(q);

                //string bc = js.getBarcode();
                dgvNew.Rows.Clear();
                while (js.RiD.Read())
                {


                    string DBServer = AccessRegistryTool.ReadValue("DBServer");
                    string DBase = "Kids_Checkin";
                    string DBUser = "kidschurch";
                    string DBPass = "1nt3gr1ty@ENLI";

                    string connectionstring = "Server=" + DBServer + ";Database=" + DBase + ";User Id=" + DBUser + ";Password=" + DBPass + ";";

                    Connector kid = new Connector(DBServer, DBase, DBUser, DBPass);

                    string kidID = js.RiD["fldKidsID"].ToString();
                    string id = "";

                    string qry = "SELECT * FROM tblKids WHERE fldStudentID='" + kidID + "'";


                    kid.ExecuteQuery(qry);

                    kid.RiD.Read();

                    DataGridViewImageColumn img = new DataGridViewImageColumn();

                    string pic = kid.RiD["fldPicture"].ToString();
                    id = kid.RiD["fldID"].ToString();

                    string picture = js.GetPath() + "/Kids/" + pic;

                    if (System.IO.File.Exists(picture))
                    {
                        img.Image = Image.FromFile(picture);
                        img.Image = (Image)(new Bitmap(img.Image, new Size(150, 150)));
                    }
                    else
                    {
                        img.Image = Image.FromFile(Application.StartupPath + "/Pictures/download.jpg");
                        img.Image = (Image)(new Bitmap(img.Image, new Size(150, 150)));
                    }

                    string creationdate = js.Lookup("fldDateCreated", "tblKids", "fldStudentID='" + kidID + "'");

                    DateTime cdate = new DateTime();
                    if (creationdate != "")
                    {
                        cdate = Convert.ToDateTime(creationdate);

                        if (cdate.ToShortDateString() == DateTime.Now.ToShortDateString())
                        {
                            dgvNew.Rows.Add(id, img.Image);
                        }
                    }

                    kid.CloseConnection();


                }
            }
            catch(Exception ex)
            {

            }
        }

        private void LoadVolunteer()
        {

            js = new Connector(AccessRegistryTool.ReadValue("DBServer"), "Kids_Checkin", "kidschurch", "1nt3gr1ty@ENLI");
            string sql = "SELECT * FROM tblVolunteerAttendance WHERE fldLoginDateTime BETWEEN '" + DateTime.Now.ToString("MM/dd/yyyy 00:00:00") + "' AND '" + DateTime.Now.ToString("MM/dd/yyyy 23:59:59") + "' AND fldLogoutDateTime IS NULL";

            js.ExecuteQuery(sql);


            dgvVolunteers.Rows.Clear();
            while(js.RiD.Read())
            {
                string id = js.RiD["fldVolunteerID"].ToString();
                Image img;
                string picture = js.Lookup("fldPicture", "tblVolunteers", "fldID='" + id + "'");

                if(System.IO.File.Exists(AccessRegistryTool.ReadValue("PicPath") + "\\volunteer\\" + picture))
                {
                    img = Image.FromFile(AccessRegistryTool.ReadValue("PicPath") + "\\volunteer\\" + picture);
                }
                else
                {
                    img = Image.FromFile(AccessRegistryTool.ReadValue("PicPath") + "\\download.jpg");
                }
               

                img = new Bitmap(img,new Size(150,150));

                dgvVolunteers.Rows.Add(id, (Image)img);


            }
            
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

                //MessageBox.Show("Card Reader not connected", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblNotification.ForeColor = System.Drawing.Color.Red;
                lblNotification.Text = "Card Reader not connected";

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
                //MessageBox.Show("Please Scan Card", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                lblNotification.ForeColor = System.Drawing.Color.Green;
                lblNotification.Text = "Please Scan Card";
                //timer1.Enabled = true;
            }  //displayOut(1, retCode, "");
            else
            {
                //displayOut(0, 0, "Successful connection to " + cbReader.Text);
                //MessageBox.Show("Reader Connected", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lblNotification.ForeColor = System.Drawing.Color.Green;
                lblNotification.Text = "Reader Connected";

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

        private bool isVolunteer(string NFC = "")
        {
            js = new Connector(AccessRegistryTool.ReadValue("DBServer"),"Kids_Checkin", "kidschurch", "1nt3gr1ty@ENLI");

            string sql = "SELECT * FROM tblVolunteers WHERE fldNFCCode='" + NFC + "'";

            js.ExecuteQuery(sql);

            js.RiD.Read();

            if(js.RiD.HasRows)
            {
                js.CloseConnection();
                return true;
            }
            else
            {
                js.CloseConnection();
                return false;
            }


            
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
                string value;

                if (rbCheckin.Checked)
                {

                    string str = tmpStr.Substring(0, 8);


                    if(str=="00000000")
                    {
                        lblNotification.Text = "Please Try Again";
                        return;
                    }

                    ////if (tmpStr == "0000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000")
                    ////{
                    ////    lblNotification.Text = "Please try again";
                    ////    return;
                    ////}


                    if(isVolunteer(tmpStr))
                    {

                        //Display Info of Volunteer
                        
                        js = new Connector(Properties.Settings.Default.Server,"Kids_Checkin","kidschurch","1nt3gr1ty@ENLI");

                        string id = js.Lookup("fldID","tblVolunteers","fldNFCCode='" + tmpStr + "'");

                        string sql = "SELECT * FROM tblSchedule WHERE fldDate='" + DateTime.Now.ToShortDateString() + "' AND fldVolunteerID='" + id + "' AND (fldServiceID='" + fldEventID + "') AND fldClass='" + fldGroupID + "'" ;

                        js.ExecuteQuery(sql);

                        js.RiD.Read();

                        if(js.RiD.HasRows)
                        {
                            string q = "SELECT * FROM tblVolunteerAttendance WHERE fldVolunteerID='" + id + "' AND convert(time,fldLoginDateTime)<=convert(time,'" + DateTime.Now.ToString("HH:mm:ss") + "')  AND fldLogoutDateTime IS NULL";

                            js.ExecuteQuery(q);

                            if(js.RiD.HasRows)
                            {
                                lblNotification.Text = "Already logged in";
                                return;
                            }

                            txtName.Text = js.Lookup("fldFirstName + ' ' + fldLastName", "tblVolunteers", "fldID ='" + id + "'");


                            if (System.IO.File.Exists(AccessRegistryTool.ReadValue("PicPath") + @"\volunteer\" + js.Lookup("fldPicture", "tblVolunteers", "fldID ='" + id + "'")))
                            {
                                pbImageKid.Image = Image.FromFile(AccessRegistryTool.ReadValue("PicPath") + @"\volunteer\" + js.Lookup("fldPicture", "tblVolunteers", "fldID ='" + id + "'"));
                            }
                            else
                            {
                                pbImageKid.Image = Image.FromFile(AccessRegistryTool.ReadValue("PicPath") + "\\download.jpg");
                            }

                            txtNFC.Text = tmpStr;

                            txtBarcode.Text = "N/A";
                            txtBirthday.Text = "N/A";
                            txtAge.Text = "N/A";
                            txtAllergies.Text = "N/A";

                            lblNotification.Text = "Welcome " + txtName.Text;

                            sql = "INSERT INTO tblVolunteerAttendance(fldVolunteerID,fldLoginDateTime) VALUES('" + id + "','" + DateTime.Now.ToString() + "')";

                            js = new Connector(AccessRegistryTool.ReadValue("DBServer"), "Kids_Checkin", "kidschurch", "1nt3gr1ty@ENLI");

                            js.ExecuteNonQuery(sql);

                            js = new Connector(Properties.Settings.Default.Server, "Kids_Checkin", "kidschurch", "1nt3gr1ty@ENLI");

                            js.ExecuteNonQuery(sql);
                        }
                        else
                        {
                            lblNotification.Text = "Not Assigned to this SERVICE";
                        }


                        LoadVolunteer();
                        return;
                    }
                    else
                    {
                        if (ValidateCheckin(tmpStr, out kidid, out value))
                        {
                            if (kidid == "")
                            {
                                lblNotification.ForeColor = System.Drawing.Color.Red;
                                lblNotification.Text = "No Record Found";
                                return;
                            }

                            if (lblCount.Text == lblTotal.Text)
                            {

                                string id = js.Lookup("fldID", "tblCustomizedEvent", "fldEventCode='" + this.Text + "'");

                                string qry = "SELECT er.fldRoomID,r.fldRoom FROM tblCustomizedEventRooms er " +
                                  "  LEFT OUTER JOIN tblRoom r on r.fldID=er.fldRoomID" +
                                   " WHERE er.fldMaxCapacity>(SELECT Count(*) FROM tblAttendance WHERE fldRoomID=er.fldRoomID AND fldLoginDateTime BETWEEN '" + DateTime.Now.ToShortDateString() + " 00:00:00' AND '" + DateTime.Now.ToShortDateString() + " 23:59:59' AND fldEventID='" + fldEventID + "')" +
                                   " AND fldCEventID='" + id + "'";

                                js.ExecuteQuery(qry);

                                js.RiD.Read();

                                string room = "";
                                string roomid = "";

                                if (js.RiD.HasRows)
                                {
                                    room = "" + js.RiD["fldRoom"].ToString();
                                    roomid = js.RiD["fldRoomID"].ToString();
                                }

                                if (room != "")
                                {
                                    js.showExclamation("Room: " + room + " is already maxed out System will assign a room to the child");
                                }
                                else
                                {
                                    room = txtRoom.Text;
                                    roomid = js.Lookup("fldID", "tblRoom", "fldRoom='" + txtRoom.Text + "'");
                                    js.showExclamation("Room: " + room + " is already maxed out, System will assign room to the child");
                                }

                                try
                                {
                                    SaveCheckin(kidid, roomid);

                                }
                                catch (Exception ex)
                                {
                                    errBallontoolTip("Kids Checkin System", ex.Message);
                                }

                            }
                            else
                            {
                                try
                                {
                                    SaveCheckin(kidid);
                                }
                                catch (Exception ex)
                                {
                                    errBallontoolTip("Kids Checkin System", ex.Message);
                                }
                            }



                        }
                        else
                        {
                            lblNotification.ForeColor = System.Drawing.Color.Red;
                            string datetimeattended = js.Lookup("TOP 1 fldLoginDateTime", "tblAttendance", "fldKidsID='" + value + "' ORDER BY fldLoginDateTime DESC");
                            lblNotification.Text = "the child attended: " + datetimeattended;

                            string logout = js.Lookup("TOP 1 fldLogoutDateTime", "tblAttendance", "fldKidsID='" + value + "' ORDER BY fldLogoutDateTime DESC");

                            DateTime lOut;
                            if (DateTime.TryParse(logout, out lOut))
                            {
                                if (lOut.ToShortDateString() == DateTime.Now.ToShortDateString() || lOut.ToShortDateString() == DateTime.Now.AddDays(-1).ToShortDateString())
                                {
                                    pbOverride.Tag = kidid;
                                    pbOverride.Visible = true;
                                }
                            }



                            //js.showInformation("The Kids Already Checked-IN", "Check-IN");
                        }
                    }
                    
                    
                }

                if (rbCheckout.Checked)
                {
                    string id = "";
                    if (ValidateCheckOut(tmpStr, out id))
                    {

                        //CheckOut(id);

                        string kID = js.Lookup("fldKidsID", "tblAttendance", "fldID='" + id + "'");

                    }
                    else
                    {
                        //js.showInformation("The Kids Already Checked-OUT", "Check-IN");
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

                //js.showExclamation("No Card Within Range", "Check-IN");

            }
            //timer1.Enabled = true;
         
        }

        void errBallontoolTip(string title, string text)
        {
            icon.ShowBalloonTip(10000, title, text, ToolTipIcon.Error);
        }

        private bool ValidateCheckin(string NFC, out string kidid,out string bcode)
        {
            

            string kid = js.Lookup("fldKidID", "tblKidsNFC", "fldNFCCode='" + NFC + "'");
            string barcode = js.Lookup("fldStudentID", "tblKids", "fldID='" + kid + "'");
            string id = "";

            Connector con = new Connector(Properties.Settings.Default.Server, "Kids_Checkin", "kidschurch", "1nt3gr1ty@ENLI");

            if(kid=="" && barcode=="")
            {
                kid = con.Lookup("fldKidID", "tblKidsNFC", "fldNFCCode='" + NFC + "'");
                barcode = con.Lookup("fldStudentID", "tblKids", "fldID='" + kid + "'");
                
                //Update Local Database

                js = new Connector(AccessRegistryTool.ReadValue("DBServer"), "Kids_Checkin", "kidschurch", "1nt3gr1ty@ENLI");

                string kcID = js.Lookup("fldID", "tblKids", "fldStudentID='" + barcode + "'");

                if(kcID!="")
                {
                    string qry = "INSERT INTO tblKidsNFC(fldNFCCode,fldKidID) VALUES('" + NFC + "','" + kcID + "')";

                    js.ExecuteQuery(qry);
                }

                kid = kcID;

                pbLoading.Visible = true;

                if (Properties.Settings.Default.PairedDevices != "")
                {
                    string[] devices = Properties.Settings.Default.PairedDevices.Split(char.Parse(","));

                    if (devices[0] == null)
                    {
                        string device = Properties.Settings.Default.PairedDevices;

                        string[] properties = device.Split(char.Parse("|"));

                        

                        try
                        {


                            Application.DoEvents();

                            Connector paired = new Connector(properties[1], "Kids_Checkin", "kidschurch", "1nt3gr1ty@ENLI");
                            kcID = paired.Lookup("fldID", "tblKids", "fldStudentID='" + barcode + "'");

                            string qry = "INSERT INTO tblKidsNFC(fldNFCCode,fldKidID) VALUES('" + NFC + "','" + kcID + "')";
                            paired.ExecuteNonQuery(qry);
                            //paired.CloseConnection();
                        }
                        catch (Exception ex)
                        {
                            errBallontoolTip("Kids Checkin System", ex.Message);
                            //paired.CloseConnection();
                        }

                    }

                    for (int i = 0; i <= (devices.Length - 1); i++)
                    {
                        string device = devices[i];

                        string[] properties = device.Split(char.Parse("|"));


                        try
                        {
                            Application.DoEvents();

                            Connector paired = new Connector(properties[1], "Kids_Checkin", "kidschurch", "1nt3gr1ty@ENLI");
                            kcID = paired.Lookup("fldID", "tblKids", "fldStudentID='" + barcode + "'");

                            string qry = "INSERT INTO tblKidsNFC(fldNFCCode,fldKidID) VALUES('" + NFC + "','" + kcID + "')";
                            paired.ExecuteNonQuery(qry);
                            //paired.CloseConnection();
                        }
                        catch (Exception ex)
                        {
                            errBallontoolTip("Kids Checkin System", ex.Message);
                            //paired.CloseConnection();
                            pbLoading.Visible = false;
                        }

                    }

                }


                





            }

            js = new Connector(AccessRegistryTool.ReadValue("DBServer"), "Kids_Checkin", "kidschurch", "1nt3gr1ty@ENLI");

            id = js.Lookup("fldID", "tblAttendance", "fldKidsID='" + barcode + "' AND fldLoginDateTime BETWEEN '" + DateTime.Now.AddDays(-1).ToShortDateString() + " 00:00:00' AND '" + DateTime.Now.ToShortDateString() + " 23:59:59'");
            

            if (id == "")
            {
                kidid = kid;
                bcode = barcode;
                return true;

            }
            else
            {
                kidid = kid;
                bcode = barcode;
                return false;
            }
        }

         private bool ValidateCheckin2(string BarCode, out string kidid)
        {
            
            string kid = js.Lookup("fldID", "tblKids", "fldStudentID='" + BarCode + "'");
            string id = "";
             if (kid=="")
             {
                 Connector con  =  new Connector(KIDS_CheckIn_System.Properties.Settings.Default.Server,"Kids_Checkin","kidschurch","1nt3gr1ty@ENLI");
                 kid = con.Lookup("fldID", "tblKids", "fldStudentID='" + BarCode + "'");

                 //UPDATE Local Database;

                 string qry = "SELECT * FROM tblKids WHERE fldID='" + kid + "'";

                 con.ExecuteQuery(qry);

                 con.RiD.Read();

                 string studentID = "";
                 string firstname = "";
                 string lastname = "";
                 string middle = "";
                 string nickname = "";
                 string birthday = "";
                 string church = "";
                 string picture = "";
                 string nationality = "";
                 string gender = "";
                 string allergies = "";
                 string fldFirstName = "";
                 string fldLastName = "";
                 string fldRelationship = "";
                 string fldPicture = "";
                 string fldEmail = "";

                 if(con.RiD.HasRows)
                 {
                     studentID = "" + con.RiD["fldStudentID"];
                     firstname = "" + con.RiD["fldFirstName"];
                     lastname = "" + con.RiD["fldLastName"];
                     middle = "" + con.RiD["fldMiddleName"];
                     nickname = "" + con.RiD["fldNickName"];
                     birthday = "" + con.RiD["fldBirthday"];
                     church = "" + con.RiD["fldChurch"];
                     picture = "" + con.RiD["fldPicture"];
                     nationality = "" + con.RiD["fldNationality"];
                     gender = "" + con.RiD["fldGender"];
                     allergies = "" + con.RiD["fldAllergies"];

                 }

                 string fID = con.Lookup("fldFetcherID", "tblKidFetcher", "fldKidID='" + kid + "'");

                 qry = "SELECT * FROM tblFetcher WHERE fldID='" + fID + "'";

                 con.ExecuteQuery(qry);

                 con.RiD.Read();

                 if(con.RiD.HasRows)
                 {
                      fldFirstName = "" + con.RiD["fldFirstName"];
                      fldLastName = "" + con.RiD["fldLastName"];
                      fldRelationship = "" + con.RiD["fldRelationship"];
                      fldPicture = "" + con.RiD["fldPicture"];
                      fldEmail = "" + con.RiD["fldEmail"];
                 }


                 js = new Connector(AccessRegistryTool.ReadValue("DBServer"), "Kids_Checkin", "kidschurch", "1nt3gr1ty@ENLI");

                 string qry1 = "INSERT INTO tblKids(fldStudentID,fldFirstName,fldLastName,fldNickName,fldBirthday,fldChurch,fldPicture,fldNationality,fldGender,fldAllergies) VALUES('" +
                        studentID + "','" + firstname + "','" + lastname + "','" + nickname + "','" + birthday + "','" + church + "','" + picture + "','" + nationality + "','" + gender + "','" + allergies + "')" ;

                 js.ExecuteNonQuery(qry1);

                 string kcID = js.Lookup("fldID", "tblKids", "fldStudentID='" + studentID + "'");

                 string qry2 = "INSERT INTO tblFetcher(fldFirstName,fldLastName,fldRelationship,fldPicture,fldEmail) VALUES('" + 
                        fldFirstName + "','" + fldLastName + "','" + fldRelationship + "','" + fldPicture + "','" + fldEmail + "')";

                 js.ExecuteNonQuery(qry2);

                 string fetcher = js.Lookup("fldID", "tblFetcher", "fldPicture='" + fldPicture + "' AND fldLastName='" + fldLastName + "'");

                 string qry3 = "INSERT INTO tblKidFetcher(fldKidID,fldFetcherID) VALUES('" + kcID + "','" + fetcher + "')";

                 js.ExecuteNonQuery(qry3);

                 kid = kcID;

                 pbLoading.Visible = true;
                 if (Properties.Settings.Default.PairedDevices != "")
                 {
                     string[] devices = Properties.Settings.Default.PairedDevices.Split(char.Parse(","));

                     if (devices[0] == "")
                     {
                         string device = Properties.Settings.Default.PairedDevices;

                         string[] properties = device.Split(char.Parse("|"));

                         

                         try
                         {
                             Application.DoEvents();
                             Connector paired = new Connector(properties[1], "Kids_Checkin", "kidschurch", "1nt3gr1ty@ENLI");
                             paired.ExecuteNonQuery(qry1);
                             kcID = paired.Lookup("fldID", "tblKids", "fldStudentID='" + studentID + "'");
                             paired.ExecuteNonQuery(qry2);
                             fetcher = paired.Lookup("fldID", "tblFetcher", "fldPicture='" + fldPicture + "' AND fldLastName='" + fldLastName + "'");

                             qry3 = "INSERT INTO tblKidFetcher(fldKidID,fldFetcherID) VALUES('" + kcID + "','" + fetcher + "')";
                             paired.ExecuteNonQuery(qry3);
                             //paired.CloseConnection();
                         }
                         catch (Exception ex)
                         {
                             errBallontoolTip("Kids Checkin System", ex.Message);
                             //paired.CloseConnection();
                         }

                     }

                     for (int i = 0; i <= (devices.Length - 1); i++)
                     {
                         string device = devices[i];

                         string[] properties = device.Split(char.Parse("|"));

                         

                         try
                         {
                             Application.DoEvents();

                             Connector paired = new Connector(properties[1], "Kids_Checkin", "kidschurch", "1nt3gr1ty@ENLI");

                             paired.ExecuteNonQuery(qry1);
                             kcID = paired.Lookup("fldID", "tblKids", "fldStudentID='" + studentID + "'");
                             paired.ExecuteNonQuery(qry2);
                             fetcher = paired.Lookup("fldID", "tblFetcher", "fldPicture='" + fldPicture + "' AND fldLastName='" + fldLastName + "'");

                             qry3 = "INSERT INTO tblKidFetcher(fldKidID,fldFetcherID) VALUES('" + kcID + "','" + fetcher + "')";
                             paired.ExecuteNonQuery(qry3);
                             //paired.CloseConnection();
                         }
                         catch (Exception ex)
                         {
                             errBallontoolTip("Kids Checkin System", ex.Message);
                             //paired.CloseConnection();
                             pbLoading.Visible = false;
                         }

                     }

                 }

                 pbLoading.Visible = false;

                 js = new Connector(AccessRegistryTool.ReadValue("DBServer"), "Kids_Checkin", "kidschurch", "1nt3gr1ty@ENLI");

                 id = js.Lookup("fldID", "tblAttendance", "fldKidsID='" + BarCode + "' AND fldLoginDateTime BETWEEN '" + DateTime.Now.ToShortDateString() + " 00:00:00' AND '" + DateTime.Now.ToShortDateString() + " 23:59:59'");

                 



             }
             else
             {
                 js = new Connector(AccessRegistryTool.ReadValue("DBServer"), "Kids_Checkin", "kidschurch", "1nt3gr1ty@ENLI");

                 id = js.Lookup("fldID", "tblAttendance", "fldKidsID='" + BarCode + "' AND fldLoginDateTime BETWEEN '" + DateTime.Now.ToShortDateString() + " 00:00:00' AND '" + DateTime.Now.ToShortDateString() + " 23:59:59'");
             }


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

        private bool ValidateCheckOut2(string Barcode, out string id)
        {
            string kid = js.Lookup("fldID", "tblKids", "fldStudentID='" + Barcode + "'");
            string id2 = js.Lookup("fldID", "tblAttendance", "fldKidsID='" + Barcode + "' AND fldLogoutDateTime BETWEEN '" + DateTime.Now.ToShortDateString() + " 00:00:00' AND '" + DateTime.Now.ToShortDateString() + " 23:59:59'");

            if (id2 == "")
            {
                id = kid;
                return true;

            }
            else
            {
                id = kid;
                return false;
            }
        }

        private void SaveCheckin(string kidid,string fldRoomID = "")
        {
            js = new Connector(AccessRegistryTool.ReadValue("DBServer"),"Kids_Checkin","kidschurch","1nt3gr1ty@ENLI");

            if (kidid == "")
            {
                return;
            }

            DataGridViewImageColumn img = new DataGridViewImageColumn();
            int age = 0;
            int group = 0;
            bool passed = false;

            string pathfile = js.GetPath() + "/Kids/" + js.Lookup("fldPicture", "tblKids", "fldID='" + kidid + "'");

            string roomid;
            string room = "";

            string firstname = js.Lookup("fldNickName", "tblKids", "fldID='" + kidid + "'");
            string Lastname = js.Lookup("fldLastName", "tblKids", "fldID='" + kidid + "'");

            age = js.GetAge(Convert.ToDateTime(js.Lookup("fldBirthday", "tblKids", "fldID='" + kidid + "'")));

            if (fldRoomID == "")
            {
                roomid = js.Lookup("fldID", "tblRoom", "fldRoom='" + txtRoom.Text + "'");
                room = js.Lookup("fldRoom", "tblRoom", "fldID=" + roomid);
            }
            else
            {
                roomid = fldRoomID;
                room = js.Lookup("fldRoom", "tblRoom", "fldID=" + roomid);
                passed = true;
            }

            if (age <= Convert.ToInt32(txtAge1.Text) && age >= Convert.ToInt32(txtAge2.Text))
            {
                int rooms = 0;
                string id = js.Lookup("fldID", "tblCustomizedEvent", "fldEventCode='" + this.Text + "'");

                rooms = int.Parse(js.Lookup("Count(*)","tblCustomizedEventRooms","fldCEventID='" + id + "'"));


                if(rooms>1)
                {
                    string qry = "SELECT er.fldRoomID,r.fldRoom FROM tblCustomizedEventRooms er " +
                              "  LEFT OUTER JOIN tblRoom r on r.fldID=er.fldRoomID" +
                               " WHERE er.fldMaxCapacity>(SELECT Count(*) FROM tblAttendance WHERE fldRoomID=er.fldRoomID AND fldLoginDateTime BETWEEN '" + DateTime.Now.ToShortDateString() + " 00:00:00' AND '" + DateTime.Now.ToShortDateString() + " 23:59:59' AND fldEventID='" + fldEventID + "')" +
                               " AND fldCEventID='" + id + "' AND er.fldAgeFrom<=" + age + " AND er.fldAgeTo>=" + age;
                    
                    js.RiD.Read();

                    
                    //string roomid = "";

                    if (js.RiD.HasRows)
                    {
                        room = "" + js.RiD["fldRoom"].ToString();
                        roomid = js.RiD["fldRoomID"].ToString();
                        passed = true;
                    }
                    else
                    {
                            roomid = js.Lookup("fldID", "tblCustomizedEventRooms", "fldAgeFrom<=" + age + " AND fldAgeTo>=" + age + " AND fldCEventID='" + id + "'");
                            room = js.Lookup("fldRoom", "tblRoom", "fldID='" +roomid + "'");
                    }
                    
                }
                else
                {
                    lblNotification.ForeColor = System.Drawing.Color.Red;
                    lblNotification.Text = firstname + " " + Lastname + " does not belong to this Group";
                    pbOverride.Tag = null;
                    pbOverride.Visible = false;
                    return;
                }

                
            }
            else if(age > Convert.ToInt32(txtAge2.Text))
            {
                int rooms = 0;
                string id = js.Lookup("fldID", "tblCustomizedEvent", "fldEventCode='" + this.Text + "'");

                rooms = int.Parse(js.Lookup("Count(*)", "tblCustomizedEventRooms", "fldCEventID='" + id + "'"));


                if (rooms>1)
                {



                    string qry = "SELECT er.fldRoomID,r.fldRoom FROM tblCustomizedEventRooms er " +
                              "  LEFT OUTER JOIN tblRoom r on r.fldID=er.fldRoomID" +
                               " WHERE er.fldMaxCapacity>(SELECT Count(*) FROM tblAttendance WHERE fldRoomID=er.fldRoomID AND fldLoginDateTime BETWEEN '" + DateTime.Now.ToShortDateString() + " 00:00:00' AND '" + DateTime.Now.ToShortDateString() + " 23:59:59' AND fldEventID='" + fldEventID + "')" +
                               " AND fldCEventID='" + id + "' AND er.fldAgeFrom<=" + age + " AND er.fldAgeTo>=" + age;

                    js.ExecuteQuery(qry);

                    js.RiD.Read();


                    //string roomid = "";

                    if (js.RiD.HasRows)
                    {
                        room = "" + js.RiD["fldRoom"].ToString();
                        roomid = js.RiD["fldRoomID"].ToString();
                        passed = true;
                    }
                    else
                    {
                        roomid = js.Lookup("fldID", "tblCustomizedEventRooms", "fldAgeFrom<=" + age + " AND fldAgeTo>=" + age + " AND fldCEventID='" + id + "'");
                        room = js.Lookup("fldRoom", "tblRoom", "fldID='" + roomid + "'");

                        if(room=="")
                        {
                            lblNotification.Text = firstname + " " + Lastname + " does not belong to this group";
                            pbOverride.Tag = kidid;
                            pbOverride.Visible = true;
                            return;
                        }
                        else if (room != txtRoom.Text)
                        {
                            passed = true;
                        }
                    }


                    //js.showInformation("The child logged in to room " + room);


                }
                else
                {
                    lblNotification.Text = firstname + " " + Lastname + " does not belong to this group";
                    pbOverride.Tag = kidid;
                    pbOverride.Visible = true;
                    return;
                }
                
               

            }
            else
            {
                pbOverride.Visible = false;

                //if(lblCount.Text==lblTotal.Text)
                //{
                int rooms = 0;
                string id = js.Lookup("fldID", "tblCustomizedEvent", "fldEventCode='" + this.Text + "'");

                rooms = int.Parse(js.Lookup("Count(*)", "tblCustomizedEventRooms", "fldCEventID='" + id + "'"));

                    if (rooms>=1)
                    {
                        string qry = "SELECT er.fldRoomID,r.fldRoom FROM tblCustomizedEventRooms er " +
                               "  LEFT OUTER JOIN tblRoom r on r.fldID=er.fldRoomID" +
                                " WHERE er.fldMaxCapacity>(SELECT Count(*) FROM tblAttendance WHERE fldRoomID=er.fldRoomID AND fldLoginDateTime BETWEEN '" + DateTime.Now.ToShortDateString() + " 00:00:00' AND '" + DateTime.Now.ToShortDateString() + " 23:59:59' AND fldEventID='" + fldEventID + "')" +
                                " AND fldCEventID='" + id + "' AND er.fldAgeFrom<=" + age + " AND er.fldAgeTo>=" + age;


                        js.ExecuteQuery(qry);

                        js.RiD.Read();


                        //string roomid = "";

                        if (js.RiD.HasRows)
                        {
                            room = "" + js.RiD["fldRoom"].ToString();
                            roomid = js.RiD["fldRoomID"].ToString();
                            passed = true;
                        }
                        else
                        {
                            roomid = js.Lookup("fldID", "tblCustomizedEventRooms", "fldAgeFrom<=" + age + " AND fldAgeTo>=" + age + " AND fldCEventID='" + id + "'");
                            room = js.Lookup("fldRoom", "tblRoom", "fldID='" + roomid + "'");

                            if (room == "")
                            {
                                lblNotification.Text = firstname + " " + Lastname + " does not belong to this group";
                                pbOverride.Tag = kidid;
                                pbOverride.Visible = false;
                                return;
                            }
                            else if (room != txtRoom.Text)
                            {
                                passed = true;
                            }

                        }


                        //js.showInformation("The child logged in to room " + room);


                    }
                //}
            }

           

            if (System.IO.File.Exists(pathfile))
            {
                img.Image = Image.FromFile(pathfile);

                img.Image = (Image)(new Bitmap(img.Image, new Size(150, 150)));
            }
            else
            {
                img.Image = Image.FromFile(Application.StartupPath + "/Pictures/download.jpg");
                img.Image = (Image)(new Bitmap(img.Image, new Size(150, 150)));
            }
           

           
            pbImageKid.Image = img.Image;

            txtName.Text = firstname + " " + Lastname;

            txtBirthday.Text = Convert.ToDateTime(js.Lookup("fldBirthday", "tblKids", "fldID='" + kidid + "'")).ToShortDateString();

            DateTime sdate = Convert.ToDateTime(DateTime.Now.ToString("MM/dd"));
            DateTime edate = sdate.AddDays(6);
            DateTime bd = Convert.ToDateTime(Convert.ToDateTime(txtBirthday.Text).ToString("MM/dd"));

           

            if (bd >= sdate && bd <= edate)
            {
                pbBirthday.Visible = true;
                pbPopper.Visible = true;

            }
            else
            {
                pbBirthday.Visible = false;
                pbPopper.Visible = false;
            }

            txtAllergies.Text = js.Lookup("fldAllergies", "tblKids", "fldID='" + kidid + "'");

            txtAge.Text = js.GetAge(Convert.ToDateTime(txtBirthday.Text)).ToString();

            txtBarcode.Text = js.Lookup("fldStudentID", "tblKids", "fldID='" + kidid + "'");

            txtNFC.Text = js.Lookup("fldNFCCode", "tblKidsNFC", "fldKidID='" + kidid + "'");

            

            if (Convert.ToDecimal(age) < 2)
            {
                group = 1;
            }

            else if ((Convert.ToDecimal(age) >= 2) && (Convert.ToDecimal(age) < 3))
            {
                group = 2;
            }

            else if ((Convert.ToDecimal(age) >= 3) && (Convert.ToDecimal(age) <= 4))
            {
                group =3;
            }

            else if ((Convert.ToDecimal(age) >= 5) && (Convert.ToDecimal(age) <= 6))
            {
                group = 4;
            }

            else if ((Convert.ToDecimal(age) >= 7) && (Convert.ToDecimal(age) <= 9))
            {
                group = 5;
            }

            else if ((Convert.ToDecimal(age) >= 10) && (Convert.ToDecimal(age) <= 12))
            {
                group =6;
            }

            else
            {
                group = 0;
            }


            string q = "INSERT INTO tblAttendance(fldRoomID,fldChurch,fldLoginDateTime,fldKidsID,fldEventID,fldGroupID,fldAge) VALUES('" + roomid + "','" + 1 + "','" + DateTime.Now.ToString() + "','" + txtBarcode.Text + "','" + fldEventID + "','" + group + "','" + age + "')";

            //string q = "INSERT INTO tblAttendance(fldRoomID,fldChurch,fldLoginDateTime,fldKidsID,fldEventID) VALUES('" + roomid + "','" + 1 + "','" + DateTime.Now.ToString() + "','" + kidid + "','" + fldEventID + "')";

            js.ExecuteNonQuery(q);

            dgvAttendance.Rows.Add(kidid, img.Image);

            pbLoading.Visible = true;

            if (Properties.Settings.Default.PairedDevices != "")
            {
                string[] devices = Properties.Settings.Default.PairedDevices.Split(char.Parse(","));

                if (devices[0] == "")
                {
                    string device = Properties.Settings.Default.PairedDevices;

                    string[] properties = device.Split(char.Parse("|"));

                    Connector con = new Connector(properties[1], "Kids_Checkin", "kidschurch", "1nt3gr1ty@ENLI");

                    try
                    {
                        Application.DoEvents();
                        con.ExecuteNonQuery(q);
                        //con.CloseConnection();
                    }
                    catch(Exception ex)
                    {
                        errBallontoolTip("Kids Checkin System", ex.Message);
                        //con.CloseConnection();
                    }

                    txtRoom.Text = room;
                    this.Tag = room;
                    frmLogin_Load(null, null);
                    lblNotification.ForeColor = System.Drawing.Color.Green;
                    lblNotification.Text = "Successfully Logged In";
                    pbLoading.Visible = false;
                    return;
                }

                for (int i = 0; i <= (devices.Length - 1); i++)
                {
                    string device = devices[i];

                    string[] properties = device.Split(char.Parse("|"));

                   

                    try
                    {

                        Application.DoEvents();
                        Connector con = new Connector(properties[1], "Kids_Checkin", "kidschurch", "1nt3gr1ty@ENLI");
                        con.ExecuteNonQuery(q);
                        //con.CloseConnection();
                    }
                    catch(Exception ex)
                    {
                        errBallontoolTip("Kids Checkin System", ex.Message);
                        //con.CloseConnection();
                    }

                }

            }

            pbLoading.Visible = false;
            

         
            txtRoom.Text = room;
            this.Tag = room;
            frmLogin_Load(null, null);
            lblNotification.ForeColor = System.Drawing.Color.Green;
            lblNotification.Text = "Successfully Logged In";


        }

        private void rbCheckout_CheckedChanged(object sender, EventArgs e)
        {
            if(rbCheckout.Checked)
            {
                tmrReader.Enabled = false;
                frmCheckOut frm = new frmCheckOut();
                if(frm.ShowDialog()== System.Windows.Forms.DialogResult.Cancel)
                {
                    rbCheckin.Checked = true;
                    dgvAttendance.Rows.Clear();
                    dgvBirthdays.Rows.Clear();
                    dgvNew.Rows.Clear();
                    LoadAttendance();
                    LoadBirthdays();
                    LoadNewComer();
                    LoadVolunteer();
                }
                tmrReader.Enabled = true;
            }
        }

        private void dgvAttendance_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvAttendance.Rows.Count==0)
            {
                return;
            }

            try
            {
                string id = dgvAttendance.CurrentRow.Cells["KidID"].Value.ToString();

                string datefrom = DateTime.Now.ToString("MM/dd/yyyy 00:00:00");
                string dateto = DateTime.Now.ToString("MM/dd/yyyy 23:59:59");

                pbImageKid.Image = (Image)dgvAttendance.CurrentCell.Value;

                txtNote.Text = js.Lookup("fldRemarks", "tblAttendance", "fldKidsID='" + id + "' AND fldLoginDateTime BETWEEN '" + datefrom + "' AND '" + dateto + "'");

                AttendanceID = js.Lookup("fldID", "tblAttendance", "fldKidsID='" + id + "' AND fldLoginDateTime BETWEEN '" + datefrom + "' AND '" + dateto + "'");

                //txtName.Text = js.Lookup("")

                string firstname = js.Lookup("fldNickName", "tblKids", "fldID='" + id + "'");
                string Lastname = js.Lookup("fldLastName", "tblKids", "fldID='" + id + "'");

                txtName.Text = firstname + " " + Lastname;

                txtBirthday.Text = Convert.ToDateTime(js.Lookup("fldBirthday", "tblKids", "fldID='" + id + "'")).ToShortDateString();

                txtAge.Text = js.GetAge(Convert.ToDateTime(txtBirthday.Text)).ToString();

                string creationdate = js.Lookup("fldDateCreated", "tblKids", "fldID='" + id + "'");

                DateTime cdate = new DateTime();
                if (creationdate != "")
                {
                    cdate = Convert.ToDateTime(creationdate);

                    if (cdate.ToShortDateString() == DateTime.Now.ToShortDateString())
                    {
                        pbBirthday.Visible = false;
                        pbWelcome.Visible = true;
                    }
                    else
                    {
                        pbWelcome.Visible = false;
                        pbBirthday.Visible = false;
                    }
                }

                DateTime sdate = Convert.ToDateTime(DateTime.Now.ToString("MM/dd"));
                DateTime edate = sdate.AddDays(6);
                DateTime bd = Convert.ToDateTime(Convert.ToDateTime(txtBirthday.Text).ToString("MM/dd"));

                if (bd >= sdate && bd <= edate)
                {
                    pbBirthday.Visible = true;
                    pbPopper.Visible = true;

                }
                else
                {
                    pbBirthday.Visible = false;
                    pbPopper.Visible = false;
                }



                txtAllergies.Text = js.Lookup("fldAllergies", "tblKids", "fldID='" + id + "'");

                txtBarcode.Text = js.Lookup("fldStudentID", "tblKids", "fldID='" + id + "'");

                txtNFC.Text = js.Lookup("fldNFCCode", "tblKidsNFC", "fldKidID='" + id + "'");
            }
            catch(Exception ex)
            {

            }
        }

        private void dgvBirthdays_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvBirthdays.Rows.Count==0)
            {
                return;
            }
            try
            {
                string id = dgvBirthdays.CurrentRow.Cells["KidIDb"].Value.ToString();

                string datefrom = DateTime.Now.ToString("MM/dd/yyyy 00:00:00");
                string dateto = DateTime.Now.ToString("MM/dd/yyyy 23:59:59");

                pbImageKid.Image = (Image)dgvBirthdays.CurrentCell.Value;

                txtNote.Text = js.Lookup("fldRemarks", "tblAttendance", "fldKidsID='" + id + "' AND fldLoginDateTime BETWEEN '" + datefrom + "' AND '" + dateto + "'");

                //txtName.Text = js.Lookup("")

                string firstname = js.Lookup("fldNickName", "tblKids", "fldID='" + id + "'");
                string Lastname = js.Lookup("fldLastName", "tblKids", "fldID='" + id + "'");

                txtName.Text = firstname + " " + Lastname;

                txtBirthday.Text = Convert.ToDateTime(js.Lookup("fldBirthday", "tblKids", "fldID='" + id + "'")).ToShortDateString();

                txtAge.Text = js.GetAge(Convert.ToDateTime(txtBirthday.Text)).ToString();

                string creationdate = js.Lookup("fldDateCreated", "tblKids", "fldID='" + id + "'");


                DateTime sdate = Convert.ToDateTime(DateTime.Now.ToString("MM/dd"));
                DateTime edate = sdate.AddDays(6);
                DateTime bd = Convert.ToDateTime(Convert.ToDateTime(txtBirthday.Text).ToString("MM/dd"));



                if (bd >= sdate && bd <= edate)
                {
                    pbWelcome.Visible = false;
                    pbBirthday.Visible = true;
                    pbPopper.Visible = true;

                }



                txtAllergies.Text = js.Lookup("fldAllergies", "tblKids", "fldID='" + id + "'");

                txtBarcode.Text = js.Lookup("fldStudentID", "tblKids", "fldID='" + id + "'");

                txtNFC.Text = js.Lookup("fldNFCCode", "tblKidsNFC", "fldKidID='" + id + "'");
            }
            catch(Exception ex)
            {

            }
        }

        private void dgvNew_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvNew.Rows.Count == 0)
            {
                return;
            }

            try
            {
                string id = dgvNew.CurrentRow.Cells["KidIDn"].Value.ToString();

                string datefrom = DateTime.Now.ToString("MM/dd/yyyy 00:00:00");
                string dateto = DateTime.Now.ToString("MM/dd/yyyy 23:59:59");

                pbImageKid.Image = (Image)dgvNew.CurrentCell.Value;

                txtNote.Text = js.Lookup("fldRemarks", "tblAttendance", "fldKidsID='" + id + "' AND fldLoginDateTime BETWEEN '" + datefrom + "' AND '" + dateto + "'");

                //txtName.Text = js.Lookup("")

                string firstname = js.Lookup("fldNickName", "tblKids", "fldID='" + id + "'");
                string Lastname = js.Lookup("fldLastName", "tblKids", "fldID='" + id + "'");

                txtName.Text = firstname + " " + Lastname;

                txtBirthday.Text = Convert.ToDateTime(js.Lookup("fldBirthday", "tblKids", "fldID='" + id + "'")).ToShortDateString();

                txtAge.Text = js.GetAge(Convert.ToDateTime(txtBirthday.Text)).ToString();

                string creationdate = js.Lookup("fldDateCreated", "tblKids", "fldID='" + id + "'");

                DateTime cdate = new DateTime();
                if (creationdate != "")
                {
                    cdate = Convert.ToDateTime(creationdate);

                    if (cdate.ToShortDateString() == DateTime.Now.ToShortDateString())
                    {
                        pbBirthday.Visible = false;
                        pbWelcome.Visible = true;
                    }
                    else
                    {
                        pbWelcome.Visible = false;
                        pbBirthday.Visible = false;
                    }
                }

                txtAllergies.Text = js.Lookup("fldAllergies", "tblKids", "fldID='" + id + "'");

                txtBarcode.Text = js.Lookup("fldStudentID", "tblKids", "fldID='" + id + "'");

                txtNFC.Text = js.Lookup("fldNFCCode", "tblKidsNFC", "fldKidID='" + id + "'");
            }
            catch(Exception ex)
            {

            }
           
        }

        private void rbBarcode_CheckedChanged(object sender, EventArgs e)
        {
            if (rbBarcode.Checked)
            {
                if (rbBarcode.Checked)
                {
                    if (!AccessRegistryTool.WriteValue("RegMode", "Barcode"))
                    {
                        js.showExclamation("The System is not configure to write on the registry, Please run the system as administrator!");
                        return;
                    }
                }

                tmrReader.Enabled = false;
                string value = "";
                string mode = AccessRegistryTool.ReadValue("RegMode");
                while(mode=="Barcode")
                {
                    if (js.InputBox("Check-In", "Please Scan Barcode", ref value) == System.Windows.Forms.DialogResult.OK)
                    {
                        string kidid;
                        string id;

                        if (rbCheckin.Checked)
                        {

                            try
                            {
                                if (ValidateCheckin2(value, out kidid))
                                {
                                    if (lblCount.Text == lblTotal.Text)
                                    {
                                        int age = js.GetAge(DateTime.Parse(js.Lookup("fldBirthday", "tblKids", "fldID='" + kidid + "'")));
                                        id = js.Lookup("fldID", "tblCustomizedEvent", "fldEventCode='" + this.Text + "'");

                                        string qry = "SELECT er.fldRoomID,r.fldRoom FROM tblCustomizedEventRooms er " +
                                                   "  LEFT OUTER JOIN tblRoom r on r.fldID=er.fldRoomID" +
                                                    " WHERE er.fldMaxCapacity>(SELECT Count(*) FROM tblAttendance WHERE fldRoomID=er.fldRoomID AND fldLoginDateTime BETWEEN '" + DateTime.Now.ToShortDateString() + " 00:00:00' AND '" + DateTime.Now.ToShortDateString() + " 23:59:59' AND fldEventID='" + fldEventID + "')" +
                                                    " AND fldCEventID='" + id + "' AND er.fldAgeFrom<=" + age + " AND er.fldAgeTo>=" + age;

                                        js.ExecuteQuery(qry);

                                        js.RiD.Read();

                                        string room = "";
                                        string roomid = "";

                                        if (js.RiD.HasRows)
                                        {
                                            room = "" + js.RiD["fldRoom"].ToString();
                                            roomid = js.RiD["fldID"].ToString();
                                        }

                                        if (room != "")
                                        {
                                            js.showExclamation("Room: " + room + " is already maxed out the kid will be transferred to Room: " + room);
                                        }
                                        else
                                        {
                                            room = txtRoom.Text;
                                            roomid = js.Lookup("fldID", "tblRoom", "fldRoom='" + txtRoom.Text + "'");
                                            js.showExclamation("Room: " + txtRoom.Text + " is already maxed out, system will assign room to the child");
                                        }

                                        try
                                        {
                                            SaveCheckin(kidid, roomid);
                                        }
                                        catch (Exception ex)
                                        {
                                            errBallontoolTip("Kids Checkin System", ex.Message);
                                        }

                                    }
                                    else
                                    {
                                        try
                                        {
                                            SaveCheckin(kidid);
                                        }
                                        catch (Exception ex)
                                        {
                                            errBallontoolTip("Kids Checkin System", ex.Message);
                                        }

                                    }
                                }
                                else
                                {
                                    lblNotification.ForeColor = System.Drawing.Color.Red;
                                    string datetimeattended = js.Lookup("TOP 1 fldLoginDateTime", "tblAttendance", "fldKidsID='" + value + "' ORDER BY fldLoginDateTime DESC");
                                    lblNotification.Text = "the child attended: " + datetimeattended;

                                    string logout = js.Lookup("TOP 1 fldLogoutDateTime", "tblAttendance", "fldKidsID='" + value + "' ORDER BY fldLogoutDateTime DESC");

                                    DateTime lOut;
                                    if (DateTime.TryParse(logout, out lOut))
                                    {
                                        if (lOut.ToShortDateString() == DateTime.Now.ToShortDateString() || lOut.ToShortDateString() == DateTime.Now.AddDays(-1).ToShortDateString())
                                        {
                                            pbOverride.Tag = kidid;
                                            pbOverride.Visible = true;
                                        }
                                    }



                                    //js.showInformation("The Kids Already Checked-IN", "Check-IN");
                                }

                            }
                            catch(Exception ex)
                            {
                                errBallontoolTip("Kids Checkin System", ex.Message);
                            }
                        }

                        tmrReader.Enabled = true;
                        rbNFC.Checked = true;

                    }
                    else
                    {
                        tmrReader.Enabled = true;
                        rbNFC.Checked = true;
                        rbNFC_CheckedChanged(null, null);
                        mode = AccessRegistryTool.ReadValue("RegMode");
                    }
                }
                }
                
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                dgvAttendance_CellContentClick(null, null);
            }
            else if (tabControl1.SelectedIndex == 1)
            {
                dgvBirthdays_CellContentClick(null, null);
            }
            else if(tabControl1.SelectedIndex==2)
            {
                dgvNew_CellContentClick(null, null);
            }
            else
            {
                dgvVolunteers_CellContentClick(null, null);
            }
        }

        private void rbNFC_CheckedChanged(object sender, EventArgs e)
        {
            if(rbNFC.Checked)
            {
                if (!AccessRegistryTool.WriteValue("RegMode", "NFC"))
                {
                    js.showExclamation("The System is not configure to write on the registry, Please run the system as administrator!");
                    return;
                }
            }
        }

        private void btnAddPoints_Click(object sender, EventArgs e)
        {
            frmPoints frm = new frmPoints();
            tmrReader.Enabled = false;
            frm.ShowDialog();
            tmrReader.Enabled = true;
        }

        private void pbOverride_Click(object sender, EventArgs e)
        {
            js = new Connector(AccessRegistryTool.ReadValue("DBServer"), "Kids_Checkin", "kidschurch", "1nt3gr1ty@ENLI");
            tmrReader.Enabled = false;
            DataGridViewImageColumn img = new DataGridViewImageColumn();
            int age = 0;
            int group = 0;

            string pathfile = js.GetPath() + "/Kids/" + js.Lookup("fldPicture", "tblKids", "fldID='" + pbOverride.Tag + "'");

            string roomid = js.Lookup("fldID", "tblRoom", "fldRoom='" + txtRoom.Text + "'");

            string firstname = js.Lookup("fldNickName", "tblKids", "fldID='" + pbOverride.Tag + "'");
            string Lastname = js.Lookup("fldLastName", "tblKids", "fldID='" + pbOverride.Tag + "'");
            bool correct = false;
            string room = "";
            string thistext = "";
            string id = js.Lookup("fldID", "tblCustomizedEvent", "fldEventCode='" + this.Text + "'");

            if(lblCount.Text==lblTotal.Text)
            {

                string qry = "SELECT er.fldRoomID,r.fldRoom FROM tblCustomizedEventRooms er " +
                              "  LEFT OUTER JOIN tblRoom r on r.fldID=er.fldRoomID" +
                               " WHERE er.fldMaxCapacity>(SELECT Count(*) FROM tblAttendance WHERE fldRoomID=er.fldRoomID AND fldLoginDateTime BETWEEN '" + DateTime.Now.ToShortDateString() + " 00:00:00' AND '" + DateTime.Now.ToShortDateString() + " 23:59:59' AND fldEventID='" + fldEventID + "')" +
                               " AND fldCEventID='" + id + "'";
                js.ExecuteQuery(qry);

                js.RiD.Read();

                

                if (js.RiD.HasRows)
                {
                    room = "" + js.RiD["fldRoom"].ToString();
                    roomid = js.RiD["fldRoomID"].ToString();
                }

                if(room!="")
                {
                    js.showExclamation("Room: " + txtRoom.Text + " is already maxed out the kid will be transferred to Room: " + room);
                }
                else
                {
                    room = txtRoom.Text;
                    roomid =  js.Lookup("fldID", "tblRoom", "fldRoom='" + txtRoom.Text + "'");
                    js.showExclamation("Room: " + txtRoom.Text + " is already maxed out, the kid will be added to Room: " + room);
                }

                
            }
           id = js.Lookup("fldID", "tblCustomizedEvent", "fldEventCode='" + this.Text + "'");

            string qq = "SELECT er.fldRoomID,r.fldRoom,er.fldAgeFrom,er.fldAgeTo FROM tblCustomizedEventRooms er " +
                              "  LEFT OUTER JOIN tblRoom r on r.fldID=er.fldRoomID" +
                               " WHERE er.fldMaxCapacity>(SELECT Count(*) FROM tblAttendance WHERE fldRoomID=er.fldRoomID AND fldLoginDateTime BETWEEN '" + DateTime.Now.ToShortDateString() + " 00:00:00' AND '" + DateTime.Now.ToShortDateString() + " 23:59:59' AND fldEventID='" + fldEventID + "')" +
                               " AND fldCEventID='" + id + "'";

            

            while (correct == false)
            {
                //string value = "";
                frmOverride frm = new frmOverride();
                if (frm.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
                {

                    
                
                }
                else
                {

                    checkin.frmOverFlowRoom form = new checkin.frmOverFlowRoom();
                    form.Tag = qq;
                    if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        string[] tag = form.Tag.ToString().Split(char.Parse("|"));

                        room = tag[1];
                        roomid = tag[0];
                    }
                    correct = true;
                    //return;
                }

            }


            if (System.IO.File.Exists(pathfile))
            {
                img.Image = Image.FromFile(pathfile);

                img.Image = (Image)(new Bitmap(img.Image, new Size(150, 150)));
            }
            else
            {
                img.Image = Image.FromFile(Application.StartupPath + "/Pictures/download.jpg");
                img.Image = (Image)(new Bitmap(img.Image, new Size(150, 150)));
            }



            pbImageKid.Image = img.Image;

            txtName.Text = firstname + " " + Lastname;

            txtBirthday.Text = Convert.ToDateTime(js.Lookup("fldBirthday", "tblKids", "fldID='" + pbOverride.Tag + "'")).ToShortDateString();

            DateTime sdate = Convert.ToDateTime(DateTime.Now.ToString("MM/dd"));
            DateTime edate = sdate.AddDays(6);
            DateTime bd = Convert.ToDateTime(Convert.ToDateTime(txtBirthday.Text).ToString("MM/dd"));



            if (bd >= sdate && bd <= edate)
            {
                pbBirthday.Visible = true;
                pbPopper.Visible = true;

            }
            else
            {
                pbBirthday.Visible = false;
                pbPopper.Visible = false;
            }

            txtAllergies.Text = js.Lookup("fldAllergies", "tblKids", "fldID='" + pbOverride.Tag + "'");

            txtAge.Text = js.GetAge(Convert.ToDateTime(txtBirthday.Text)).ToString();

            txtBarcode.Text = js.Lookup("fldStudentID", "tblKids", "fldID='" + pbOverride.Tag + "'");

            txtNFC.Text = js.Lookup("fldNFCCode", "tblKidsNFC", "fldKidID='" + pbOverride.Tag + "'");



            if (Convert.ToDecimal(age) < 2)
            {
                group = 1;
            }

            else if ((Convert.ToDecimal(age) >= 2) && (Convert.ToDecimal(age) < 3))
            {
                group = 2;
            }

            else if ((Convert.ToDecimal(age) >= 3) && (Convert.ToDecimal(age) <= 4))
            {
                group = 3;
            }

            else if ((Convert.ToDecimal(age) >= 5) && (Convert.ToDecimal(age) <= 6))
            {
                group = 4;
            }

            else if ((Convert.ToDecimal(age) >= 7) && (Convert.ToDecimal(age) <= 9))
            {
                group = 5;
            }

            else if ((Convert.ToDecimal(age) >= 10) && (Convert.ToDecimal(age) <= 12))
            {
                group = 6;
            }

            else
            {
                group = 0;
            }


            string q = "INSERT INTO tblAttendance(fldRoomID,fldChurch,fldLoginDateTime,fldKidsID,fldEventID,fldGroupID,fldAge) VALUES('" + roomid + "','" + 1 + "','" + DateTime.Now.ToString() + "','" + txtBarcode.Text + "','" + fldEventID + "','" + group + "','" + age + "')";



            //string q = "INSERT INTO tblAttendance(fldRoomID,fldChurch,fldLoginDateTime,fldKidsID,fldEventID) VALUES('" + roomid + "','" + 1 + "','" + DateTime.Now.ToString() + "','" + kidid + "','" + fldEventID + "')";

            js.ExecuteNonQuery(q);

            pbLoading.Visible = true;

            if(Properties.Settings.Default.PairedDevices!="")
            {
                string[] devices = Properties.Settings.Default.PairedDevices.Split(char.Parse(","));

                if (devices[0] == "")
                {
                    string device = Properties.Settings.Default.PairedDevices;

                    string[] properties = device.Split(char.Parse("|"));

                    Connector con = new Connector(properties[1],"Kids_Checkin","kidschurch","1nt3gr1ty@ENLI");

                    try
                    {
                        Application.DoEvents();
                        con.ExecuteNonQuery(q);
                    }
                    catch(Exception ex)
                    {

                    }

                    return;
                }

                for(int i=0;i<=(devices.Length - 1);i++)
                {
                    string device = devices[i];

                    string[] properties = device.Split(char.Parse("|"));

                    Connector con = new Connector(properties[1], "Kids_Checkin", "kidschurch", "1nt3gr1ty@ENLI");

                    try
                    {
                        Application.DoEvents();
                        con.ExecuteNonQuery(q);
                    }
                    catch(Exception ex)
                    {

                    }

                }

            }

            pbLoading.Visible = false;

            thistext = this.Text;
            txtRoom.Text = room;
            this.Tag = room;
            frmLogin_Load(null, null);
            lblNotification.ForeColor = System.Drawing.Color.Green;
            lblNotification.Text = "Successfully Logged In";

            tmrReader.Enabled = true;
            pbOverride.Tag = null;
            pbOverride.Visible = false;

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            //js = new Connector(AccessRegistryTool.ReadValue("DBServer"),"Kids_Checkin","kidschurch","1nt3gr1ty@ENLI");
            try
            {
                string qry = "SELECT Count(*) as AttendanceCount FROM tblAttendance WHERE fldRoomID='" + fldRoomID + "' AND fldLoginDateTime BETWEEN '" + DateTime.Now.ToShortDateString() + " 00:00:00' AND '" + DateTime.Now.ToShortDateString() + " 23:59:59' AND fldEventID='" + fldEventID + "' AND fldLogoutDateTime IS NULL";
                js.ExecuteQuery(qry);
                js.RiD.Read();
                lblCount.Text = js.RiD["AttendanceCount"].ToString();
            }
            catch(Exception ex)
            {
            }

        }

        private void txtRoom_Click(object sender, EventArgs e)
        {
            KIDS_CheckIn_System.checkin.frmRoomList frm = new checkin.frmRoomList();

            frm.Tag = this.Text;
            if(frm.ShowDialog()== System.Windows.Forms.DialogResult.OK)
            {
                this.Tag = frm.Tag;
                frmLogin_Load(null, null);

            }

        }

        private void txtRoom_TextChanged(object sender, EventArgs e)
        {

        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            js = new Connector(AccessRegistryTool.ReadValue("DBServer"), "Kids_Checkin", "kidschurch", "1nt3gr1ty@ENLI");

            //Automatic Changing of Service Time
            string timetoday = DateTime.Now.ToString("hh:mm tt");
            object thistag = this.Tag;

            string q = "SELECT * FROM tblEvent WHERE fldRegistrationTime <= convert(time,'" + timetoday + "') AND fldEndTime >=convert(time,'" + timetoday + "')";

            js.ExecuteQuery(q);

            js.RiD.Read();

            
            if(js.RiD.HasRows)
            {
                if(fldEventID!=js.RiD["fldID"].ToString())
                {
                    this.Tag = thistag;
                    frmLogin_Load(null, null);
                }
                
            }
        }

        private void splitContainer3_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnTransfer_Click(object sender, EventArgs e)
        {
            if(dgvAttendance.Rows.Count ==0)
            {
                return;
            }

            checkin.frmContactNo frm = new checkin.frmContactNo();

            frm.Tag = dgvAttendance.CurrentRow.Cells["KidID"].Value.ToString();

            frm.ShowDialog();



        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string kidID = dgvAttendance.CurrentRow.Cells["KidID"].Value.ToString();
            if(js.showQuestion("Are you sure you want to Transfer " + txtName.Text + " to other room?")== System.Windows.Forms.DialogResult.Yes)
            {
                tmrReader.Enabled = false;
                frmOverride overrider = new frmOverride();
                
                if(overrider.ShowDialog()== System.Windows.Forms.DialogResult.OK)
                {
                    checkin.frmRoomList frm = new checkin.frmRoomList();
                    frm.Tag = this.Text;

                    if(frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        string id = js.Lookup("fldID","tblRoom","fldRoom='" + frm.Tag + "'");

                        string q = "UPDATE tblAttendance SET fldRoomID='" + id + "' WHERE fldID='" + AttendanceID + "'";

                        js.ExecuteNonQuery(q);

                        this.Tag = frm.Tag;
                        frmLogin_Load(null, null);

                    }
                }
            }
            tmrReader.Enabled = true;
        }

        private void btnNotePad_Click(object sender, EventArgs e)
        {
            checkin.frmSaveBarcodes frm = new checkin.frmSaveBarcodes();

            frm.ShowDialog();
        }

        private void dgvVolunteers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dgvVolunteers.Rows.Count==0)
            {
                return;
            }


            pbImageKid.Image = (Image)dgvVolunteers.CurrentCell.Value;

            txtName.Text = js.Lookup("fldFirstName + ' ' + fldLastName", "tblVolunteers", "fldID='" + dgvVolunteers.CurrentRow.Cells["vID"].Value + "'");

            txtNFC.Text = js.Lookup("fldNFCCode", "tblVolunteers", "fldID='" + dgvVolunteers.CurrentRow.Cells["vID"].Value + "'");

            txtBarcode.Text = "N/A";
            txtBirthday.Text = "N/A";
            txtAge.Text = "N/A";
            txtAllergies.Text = "N/A";

        }



        
    }
}
