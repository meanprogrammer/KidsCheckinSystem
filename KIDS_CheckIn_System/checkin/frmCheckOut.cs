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
    public partial class frmCheckOut : Form
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
        bool fromNFC = false;
        string[] kID = new string[10];
        string[] fetcher = new string[4];

        public frmCheckOut()
        {
            InitializeComponent();
        }

        private void frmCheckOut_FormClosed(object sender, FormClosedEventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            tmrReader.Enabled = false;
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
                lblNotification.Text = "Card Reader not Connected";
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
                //timer1.Enabled = true;

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

               

                try
                {
                    string str = tmpStr.Substring(0, 8);


                    if (str == "00000000")
                    {
                        lblNotification.Text = "Please Try Again";
                        return;
                    }

                    string fID = js.Lookup("fldFetcherID", "tblFetcherNFC", "fldNFCCode='" + tmpStr + "'");

                    for (int i = 0; i <= (fetcher.Length - 1); i++)
                    {
                        if (fetcher[i] == fID)
                        {
                            btnConfirm_Click(null, null);
                            break;

                        }
                        else
                        {
                            lblNotification.Text = "Not valid Fetcher";
                            return;
                        }
                    }

                    tmrReader.Enabled = false;
                    timer2.Enabled = true;
                }
                catch
                {
                    lblNotification.Text = "Please Try Again";
                }
                


            }

            else
            {

                //displayOut(5, 0, "No card within range.");
                //tsMsg2.Text = "";

                lblNotification.ForeColor = System.Drawing.Color.Red;
                lblNotification.Text = "No Card Within Range";

            }
            //timer1.Enabled = true;

        }

        private bool isVolunteer(string NFC = "")
        {
            js = new Connector(AccessRegistryTool.ReadValue("DBServer"), "Kids_Checkin", "kidschurch", "1nt3gr1ty@ENLI");

            string sql = "SELECT * FROM tblVolunteers WHERE fldNFCCode='" + NFC + "'";

            js.ExecuteQuery(sql);

            js.RiD.Read();

            if (js.RiD.HasRows)
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

        private void frmCheckOut_Load(object sender, EventArgs e)
        {
            StartReader();
        }

        private bool ValidateCheckOut(string NFC, out string kid)
        {
            string kid2 = js.Lookup("fldFetcherID", "tblFetcherNFC", "fldNFCCode='" + NFC + "'");

            string[] fetcherID = new string[5];
            //string id2 = js.Lookup("fldID", "tblAttendance", "fldKidsID='" + kid + "' AND fldLogoutDateTime BETWEEN '" + DateTime.Now.ToShortDateString() + " 00:00:00' AND '" + DateTime.Now.ToShortDateString() + " 23:59:59'");

            if(kid2=="")
            {
                Connector server = new Connector(Properties.Settings.Default.Server, "Kids_Checkin", "kidschurch", "1nt3gr1ty@ENLI");

                //kid2 = server.Lookup("fldFetcherID", "tblFetcherNFC", "fldNFCCode='" + NFC + "'");

                string query = "SELECT * FROM tblFetcherNFC WHERE fldNFCCode='" + NFC + "'";

                server.ExecuteQuery(query);
                int i =0;
                while(server.RiD.Read())
                {
                   
                    fetcherID[i] = server.RiD["fldFetcherID"].ToString();
                    i++;
                }

            }

            for (int i = 0; i <= (fetcherID.Length - 1);i++)
            {
                if(fetcherID[i]==null)
                {
                    break;
                }

                string qry = "SELECT * FROM tblFetcher WHERE fldID='" + fetcherID[i] + "'";

                Connector server = new Connector(Properties.Settings.Default.Server, "Kids_Checkin", "kidschurch", "1nt3gr1ty@ENLI");

                server.ExecuteQuery(qry);
                server.RiD.Read();

                string fldLastName = "" + server.RiD["fldLastName"];
                string fldFirstName = "" + server.RiD["fldFirstName"];
                string fldPicture = "" + server.RiD["fldPicture"];

                Connector local = new Connector(AccessRegistryTool.ReadValue("DBServer"), "Kids_Checkin", "kidschurch", "1nt3gr1ty@ENLI");

                string q = "SELECT fldID FROM tblFetcher WHERE fldLastName='" + fldLastName + "' AND fldFirstName='" + fldFirstName + "' AND fldPicture='" + fldPicture + "'";

                local.ExecuteQuery(q);

                local.RiD.Read();

                if (local.RiD.HasRows)
                {
                    string exist = local.Lookup("fldNFCCode", "tblFetcherNFC", "fldFetcherID='" + local.RiD["fldID"] + "'");

                    if(exist=="")
                    {
                        string insert = "INSERT INTO tblFetcherNFC (fldFetcherID,fldNFCCode) VALUES('" + local.RiD["fldID"] + "','" + NFC + "')";
                        js.ExecuteNonQuery(insert);
                    }

                    else
                    {
                        string update = "UPDATE tblFetcherNFC SET fldNFCCode='" + NFC + "' WHERE fldID='" + local.RiD["fldID"] + "'";

                        js.ExecuteNonQuery(update);
                    }

                    kid2 = local.RiD["fldID"].ToString();
                }
            }

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

            if(kid=="")
            {
                Connector conn = new Connector(KIDS_CheckIn_System.Properties.Settings.Default.Server,"Kids_Checkin","kidschurch","1nt3gr1ty@ENLI");
                kid = conn.Lookup("fldID", "tblKids", "fldStudentID='" + Barcode + "'");
            }
            string id2 = js.Lookup("fldID", "tblAttendance", "fldKidsID='" + Barcode + "' AND fldLogoutDateTime BETWEEN '" + DateTime.Now.ToShortDateString() + " 00:00:00' AND '" + DateTime.Now.ToShortDateString() + " 23:59:59'");

            if (id2 == "")
            {
                id = kid;
                btnConfirm.Tag = id2;
                return true;

            }
            else
            {
                id = kid;
                btnConfirm.Tag = id2;
                return false;
            }
        }

        private void LoadFetcher(string kidid)
        {
            string[] fID = new string[3];

            string q = "SELECT * FROM tblKidFetcher WHERE fldKidID='" + kidid + "'";

            js.ExecuteQuery(q);
            int i = 0;
            int j = 0;
            while (js.RiD.Read())
            {
                fID[i] = js.RiD["fldFetcherID"].ToString();
                string qry = "SELECT * FROM tblKidFetcher WHERE fldFetcherID='" + fID[i] + "'";
                Connector js2 = new Connector(AccessRegistryTool.ReadValue("DBServer"),"Kids_Checkin","kidschurch","1nt3gr1ty@ENLI");
                js2.ExecuteQuery(qry);
               
                while(js2.RiD.Read())
                {
                    kID[j] = js2.RiD["fldKidID"].ToString();
                    j++;
                }
                i++;
            }

            if(!js.RiD.HasRows)
            {
                string id = js.Lookup("fldStudentID","tblKids","fldID='" + kidid + "'");
                string aID = js.Lookup("fldID", "tblAttendance", "fldKidsID='" + id + "' AND fldLoginDateTime BETWEEN '" + DateTime.Now.ToShortDateString() + " 00:00:00' AND '" + DateTime.Now.ToShortDateString() + " 23:59:59'");

                lblNotification.Text = "No Fetcher details yet!";

                string pic = js.GetPath() + "/Kids/" + js.Lookup("fldPicture", "tblKids", "fldID='" + kidid + "'");

                if (System.IO.File.Exists(pic))
                {
                    pbK1.Image = Image.FromFile(pic);

                }
                lblKName.Text = "" + js.Lookup("fldNickName", "tblKids", "fldID='" + kidid + "'") + " " + js.Lookup("fldLastName", "tblKids", "fldID='" + kidid + "'");
                lblBarcode.Text = "" + id;
                lblBirthday.Text = Convert.ToDateTime(js.Lookup("fldBirthday","tblKids","fldID='" + kidid + "'")).ToShortDateString();
                btnConfirm.Tag = aID;
                btnConfirm.Enabled = true;

                return;
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


        } //BARCODE

        private void LoadFetcher2(string kidid)
        {
            js = new Connector(AccessRegistryTool.ReadValue("DBServer"),"Kids_Checkin","kidschurch","1nt3gr1ty@ENLI");
            string[] fID = new string[4];
            

            string q = "SELECT * FROM tblFetcherNFC WHERE fldNFCCode='" + kidid + "'";
            js.ExecuteQuery(q);
           
            if (!js.RiD.HasRows)
            {
                js = new Connector(Properties.Settings.Default.Server, "Kids_Checkin", "kidschurch", "1nt3gr1ty@ENLI");
                js.ExecuteQuery(q);
            }

            int i = 0;
            int j = 0;
            while (js.RiD.Read())
            {
                fID[i] = js.RiD["fldFetcherID"].ToString();
                string qry = "SELECT * FROM tblKidFetcher WHERE fldFetcherID='" + fID[i] + "'";
                Connector js2 = new Connector(AccessRegistryTool.ReadValue("DBServer"), "Kids_Checkin", "kidschurch", "1nt3gr1ty@ENLI");
                js2.ExecuteQuery(qry);
                
                while (js2.RiD.Read())
                {
                    kID[j] = js2.RiD["fldKidID"].ToString();
                    j++;
                }

                i++;
            }

            if (!js.RiD.HasRows)
            {
                lblNotification.Text = "No Fetcher details yet!";
                return;
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


        } //NFC

        private void rbBarcode_CheckedChanged(object sender, EventArgs e)
        {
            if (rbBarcode.Checked)
            {
                timer2.Enabled = false;
                txtBarcode.Enabled = true;
                txtBarcode.Focus();

            }
        }

        private void btnScan_Click(object sender, EventArgs e)
        {
            js = new Connector(AccessRegistryTool.ReadValue("DBServer"), "Kids_Checkin", "kidschurch", "1nt3gr1ty@ENLI");

            string value = "";
            bool passed  = false;
            if (js.InputBox("Check Out", "Please Scan Barcode", ref value) == System.Windows.Forms.DialogResult.OK)
            {
                string q = "SELECT * FROM tblKids WHERE fldStudentID = '" + value + "'";
                js.ExecuteQuery(q);
                js.RiD.Read();

                if(!js.RiD.HasRows)
                {
                    return;
                }

                string kidsid = js.RiD["fldID"].ToString();
                for (int i=0;i<kID.Length;i++)
                {
                    if(kidsid==kID[i])
                    {
                        passed = true;
                        break;
                    }
                }

                if(passed==true)
                { 
                    string p = js.GetPath() + "/Kids/" + js.RiD["fldPicture"];

                    string aID = js.Lookup("fldID", "tblAttendance", "fldKidsID='" + value  + "' AND fldLoginDateTime BETWEEN '" + DateTime.Now.ToShortDateString() + " 00:00:00' AND '" + DateTime.Now.ToShortDateString() + " 23:59:59' AND (fldLogoutDateTime IS NULL)");

                    if (System.IO.File.Exists(p))
                    {
                        pbK1.Image = Image.FromFile(p);
                    }
                    lblKName.Text = "" + js.RiD["fldNickName"] + " " + js.RiD["fldLastName"];
                    lblBarcode.Text = value;
                    lblBirthday.Text = Convert.ToDateTime(js.RiD["fldBirthday"].ToString()).ToString("MM/dd/yyyy");
                    btnConfirm.Tag = aID;
                    btnConfirm.Enabled = true;
                    fromNFC = false;
                }
                else
                {
                    lblNotification.ForeColor = Color.Red;
                    lblNotification.Text = "Fetcher and Kid Do Not Match";
                }
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            CheckOut(btnConfirm.Tag.ToString());

            if (rbBarcode.Checked)
            {
                rbBarcode_CheckedChanged(null, null);
            }

            tmrReader.Enabled = true;
            pb1.Image = Image.FromFile(Application.StartupPath + "/Pictures/download.jpg");
            pb2.Image = Image.FromFile(Application.StartupPath + "/Pictures/download.jpg");
            pb3.Image = Image.FromFile(Application.StartupPath + "/Pictures/download.jpg");
            pbK1.Image = Image.FromFile(Application.StartupPath + "/Pictures/download.jpg");

            lblBarcode.Text = "Barcode";
            lblBirthday.Text = "Birthday";
            lblKName.Text = "Name";
            lblName1.Text = "";
            lblName2.Text = "";
            lblName3.Text = "";

            //string id = js.Lookup("fldKidID","tblAttendance","fldID='" + btnConfirm.Tag + "'");

            this.Tag = btnConfirm.Tag;
            btnConfirm.Enabled = false;
            //this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            //this.Close();
        }

        private void CheckOut(string attendanceID)
        {
            js = new Connector(AccessRegistryTool.ReadValue("DBServer"), "Kids_Checkin", "kidschurch", "1nt3gr1ty@ENLI");

            string remarks = js.Lookup("fldRemarks", "tblAttendance", "fldID='" + attendanceID + "'");

            string fldKidID = js.Lookup("fldKidsID", "tblAttendance", "fldID='" + attendanceID + "'");

            int p = 0;
            int fldPoints = 0;
            if(int.TryParse(js.Lookup("fldPoints","tblKids"," fldStudentID='" + fldKidID + "'"),out p))
            {
                fldPoints = p + 50;
            }
            else
            {
                fldPoints = 50;
            }

            if(fromNFC==true)
            { 
                string qq = "UPDATE tblKids SET fldPoints='" + fldPoints + "' WHERE fldStudentID='" + fldKidID + "'";
                js.ExecuteNonQuery(qq);
            }

            remarks += ";Logged out: " + DateTime.Now.ToString();
            string q = "Update tblAttendance SET fldLogoutDateTime='" + DateTime.Now.ToString() + "',fldRemarks='" + remarks + "' WHERE fldLoginDateTime BETWEEN '" + DateTime.Now.ToString("MM/dd/yyyy") + " 00:00:00' AND '" +  DateTime.Now.ToString("MM/dd/yyyy") + " 23:59:59' AND fldKidsID='" +fldKidID + "'";

            js.ExecuteNonQuery(q);

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
                    }
                    catch(Exception ex)
                    {

                    }

                    return;
                }

                for (int i = 0; i <= (devices.Length - 1); i++)
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

            //PASS TO SERVER

            js = new Connector(AccessRegistryTool.ReadValue("DBServer"), "Kids_Checkin", "kidschurch", "1nt3gr1ty@ENLI");
            string query = "SELECT * FROM tblAttendance WHERE fldLoginDateTime BETWEEN '" + DateTime.Now.ToString("MM/dd/yyyy") + " 00:00:00' AND '" + DateTime.Now.ToString("MM/dd/yyyy") + " 23:59:59'" +
                              " AND fldKidsID='" + fldKidID + "'";

            js.ExecuteQuery(query);

              

              
                js.RiD.Read();

                if(js.RiD.HasRows)
                {
                    string fldRoomID = "" + js.RiD["fldRoomID"];
                    string fldLoginDateTime = "" + js.RiD["fldLoginDateTime"];
                    string fldLogoutDateTime = "" + js.RiD["fldLogoutDateTime"];
                    string fldChurch ="" + js.RiD["fldChurch"];
                    string fldKidsID = "" + js.RiD["fldKidsID"];
                    string fldRemarks = "" + js.RiD["fldRemarks"];
                    string fldEventID = js.Lookup("fldEventTitle", "tblEvent", "fldID='" + js.RiD["fldEventID"] + "'");
                    string fldGroupID ="" + js.RiD["fldGroupID"];
                    string fldAge = "" + js.RiD["fldAge"];

                    
                    string qq = "INSERT INTO tblAttendance(fldRoomID,fldLoginDateTime,fldLogoutDateTime,fldChurch,fldKidsID,fldRemarks,fldEventID,fldGroupID,fldAge) VALUES('" + 
                                fldRoomID + "','" + fldLoginDateTime + "','" + fldLogoutDateTime + "','" + fldChurch + "','" + fldKidsID + "','" + fldRemarks + "','" + fldEventID + "','" + fldGroupID + "','" + fldAge + "')";

                    try
                    {
                        Connector cc = new Connector(Properties.Settings.Default.Server, "Kids_Checkin", "kidschurch", "1nt3gr1ty@ENLI");

                        cc.ExecuteNonQuery(qq);
                    }
                    catch(Exception ex)
                    {

                    }

                }

                pbLoading.Visible = false;

            //js.showInformation("Kid Successfully Checked OUT", "Check-OUT");
            lblNotification.ForeColor = System.Drawing.Color.Green;
            lblNotification.Text = "Successfully Logged Out";
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

                string str = tmpStr.Substring(0, 8);


                if (str == "00000000")
                {
                    lblNotification.Text = "Please Try Again";
                    return;
                }

                if (isVolunteer(tmpStr))
                {
                    js = new Connector(Properties.Settings.Default.Server, "Kids_Checkin", "kidschurch", "1nt3gr1ty@ENLI");

                    string vid = js.Lookup("fldID", "tblVolunteers", "fldNFCCode='" + tmpStr + "'");

                    string sql = "SELECT * FROM tblVolunteerAttendance WHERE fldVolunteerID='" + vid + "' AND fldLoginDateTime BETWEEN '" + DateTime.Now.ToString("MM/dd/yyyy 00:00:00") + "' AND '" + DateTime.Now.ToString("MM/dd/yyyy 23:59:59") + "' AND fldLogoutDateTime IS NULL";

                    js.ExecuteQuery(sql);

                    if (js.RiD.Read())
                    {
                        string attendanceID = js.RiD["fldID"].ToString();

                        string picture = js.Lookup("fldPicture", "tblVolunteers", "fldID='" + vid + "'");

                        lblKName.Text = js.Lookup("fldFirstName + ' ' + fldLastName", "tblVolunteers", "fldID='" + vid + "'");

                        if (System.IO.File.Exists(AccessRegistryTool.ReadValue("PicPath") + "\\volunteer\\" + picture))
                        {
                            pbK1.Image = Image.FromFile(AccessRegistryTool.ReadValue("PicPath") + "\\volunteer\\" + picture);
                        }
                        else
                        {
                            pbK1.Image = Image.FromFile(AccessRegistryTool.ReadValue("PicPath") + "\\download.jpg");
                        }

                        js = new Connector(AccessRegistryTool.ReadValue("DBServer"), "Kids_Checkin", "kidschurch", "1nt3gr1ty@ENLI");

                        sql = "UPDATE tblVolunteerAttendance SET fldLogoutDateTime='" + DateTime.Now.ToString() + "' WHERE fldID='" + attendanceID + "'";

                        js.ExecuteNonQuery(sql);

                        js = new Connector(Properties.Settings.Default.Server, "Kids_Checkin", "kidschurch", "1nt3gr1ty@ENLI");

                        attendanceID = js.Lookup("fldID", "tblVolunteerAttendance", "fldVolunteerID='" + vid + "' AND fldLoginDateTime BETWEEN '" + DateTime.Now.ToString("MM/dd/yyyy 00:00:00") + "' AND '" + DateTime.Now.ToString("MM/dd/yyyy 23:59:59") + "' AND fldLogoutDateTime IS NULL");

                        sql = "UPDATE tblVolunteerAttendance SET fldLogoutDateTime='" + DateTime.Now.ToString() + "' WHERE fldID='" + attendanceID + "'";

                        js.ExecuteNonQuery(sql);

                        lblNotification.Text = "Volunteer Logged out";

                    }

                    return;

                }

                //tmrReader.Enabled = false;

                string id = js.Lookup("fldKidID", "tblKidsNFC", "fldNFCCode='" + tmpStr + "'");
                string bc = js.Lookup("fldStudentID", "tblKids", "fldID='" + id + "'");
                string q = "SELECT  * FROM tblKids WHERE fldID='" + id + "'";

                string aID = js.Lookup("fldID", "tblAttendance", "fldKidsID='" + bc + "' AND fldLoginDateTime BETWEEN '" + DateTime.Now.ToShortDateString() + " 00:00:00' AND '" + DateTime.Now.ToShortDateString() + " 23:59:59' AND fldLogoutDateTime IS NULL");

                js.ExecuteQuery(q);

                js.RiD.Read();
                bool passed = false;
                //string q = "SELECT * FROM tblKids WHERE fldStudentID = '" + value + "'";
                js.ExecuteQuery(q);
                js.RiD.Read();


                string pic = js.GetPath() + "/Kids/" + js.RiD["fldPicture"];

                if (System.IO.File.Exists(pic))
                {
                    pbK1.Image = Image.FromFile(pic);

                }
                lblKName.Text = "" + js.RiD["fldNickName"] + " " + js.RiD["fldLastName"];
                lblBarcode.Text = "" + js.RiD["fldStudentID"];
                lblBirthday.Text = Convert.ToDateTime(js.RiD["fldBirthday"]).ToShortDateString();
                btnConfirm.Tag = aID;
                btnConfirm.Enabled = true;


                try
                {
                    string[] fetcher = getFetchers(id);
                    this.fetcher = fetcher;

                    string pic1 = "";
                    string pic2 = "";
                    string pic3 = "";
                    string name1 = "";
                    string name2 = "";
                    string name3 = "";



                    pic1 = js.GetPath() + "/Fetchers/" + js.Lookup("fldPicture", "tblFetcher", "fldID='" + fetcher[0] + "'");
                    pic2 = js.GetPath() + "/Fetchers/" + js.Lookup("fldPicture", "tblFetcher", "fldID='" + fetcher[1] + "'");
                    pic3 = js.GetPath() + "/Fetchers/" + js.Lookup("fldPicture", "tblFetcher", "fldID='" + fetcher[2] + "'");

                    name1 = js.Lookup("fldFirstName", "tblFetcher", "fldID='" + fetcher[0] + "'") + " " + js.Lookup("fldLastName", "tblFetcher", "fldID='" + fetcher[0] + "'");
                    name2 = js.Lookup("fldFirstName", "tblFetcher", "fldID='" + fetcher[1] + "'") + " " + js.Lookup("fldLastName", "tblFetcher", "fldID='" + fetcher[1] + "'");
                    name3 = js.Lookup("fldFirstName", "tblFetcher", "fldID='" + fetcher[2] + "'") + " " + js.Lookup("fldLastName", "tblFetcher", "fldID='" + fetcher[2] + "'");



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

                    timer2.Enabled = false;
                    tmrReader.Enabled = true;
                }

                catch
                {
                    lblNotification.Text = "Please Try Again";
                }
                




            }

            else
            {

                //displayOut(5, 0, "No card within range.");
                //tsMsg2.Text = "";
                lblNotification.ForeColor = System.Drawing.Color.Red;
                lblNotification.Text = "No Card Within Range";
                //js.showExclamation("No Card Within Range", "Check-IN");

            }
            //timer1.Enabled = true;
        }

        private void rbNFC_CheckedChanged(object sender, EventArgs e)
        {
            if(rbNFC.Checked)
            {
                txtBarcode.Text = "";
                txtBarcode.Enabled = false;
                timer2.Enabled = true;
            }
        }

        private string[] getFetchers(string fldKidID)
        {
            string[] fetchers = new string[3];

            string sql = "SELECT * FROM tblKidFetcher WHERE fldKidID='" + fldKidID + "'";

            int i = 0;
            js.ExecuteQuery(sql);

            while(js.RiD.Read())
            {
                fetchers[i] = js.RiD["fldFetcherID"].ToString();
                i++;
            }


            return fetchers;

        }

        private void btnBarcode_Click(object sender, EventArgs e)
        {
            string q = "SELECT * FROM tblKids WHERE fldStudentID = '" + txtBarcode.Text + "'";
            js.ExecuteQuery(q);
            js.RiD.Read();

            if (!js.RiD.HasRows)
            {
                return;
            }
            else
            {
                string p = js.GetPath() + "/Kids/" + js.RiD["fldPicture"];

                string aID = js.Lookup("fldID", "tblAttendance", "fldKidsID='" + txtBarcode.Text + "' AND fldLoginDateTime BETWEEN '" + DateTime.Now.ToShortDateString() + " 00:00:00' AND '" + DateTime.Now.ToShortDateString() + " 23:59:59' AND (fldLogoutDateTime IS NULL)");

                if (System.IO.File.Exists(p))
                {
                    pbK1.Image = Image.FromFile(p);
                }
                lblKName.Text = "" + js.RiD["fldNickName"] + " " + js.RiD["fldLastName"];
                lblBarcode.Text = txtBarcode.Text;
                lblBirthday.Text = Convert.ToDateTime(js.RiD["fldBirthday"].ToString()).ToString("MM/dd/yyyy");
                btnConfirm.Tag = aID;
                btnConfirm.Enabled = true;

                string id = js.Lookup("fldID", "tblKids", "fldStudentID='" + txtBarcode.Text + "'");

                string[] fetcher = getFetchers(id);
                this.fetcher = fetcher;

                string pic1 = "";
                string pic2 = "";
                string pic3 = "";
                string name1 = "";
                string name2 = "";
                string name3 = "";



                pic1 = js.GetPath() + "/Fetchers/" + js.Lookup("fldPicture", "tblFetcher", "fldID='" + fetcher[0] + "'");
                pic2 = js.GetPath() + "/Fetchers/" + js.Lookup("fldPicture", "tblFetcher", "fldID='" + fetcher[1] + "'");
                pic3 = js.GetPath() + "/Fetchers/" + js.Lookup("fldPicture", "tblFetcher", "fldID='" + fetcher[2] + "'");

                name1 = js.Lookup("fldFirstName", "tblFetcher", "fldID='" + fetcher[0] + "'") + " " + js.Lookup("fldLastName", "tblFetcher", "fldID='" + fetcher[0] + "'");
                name2 = js.Lookup("fldFirstName", "tblFetcher", "fldID='" + fetcher[1] + "'") + " " + js.Lookup("fldLastName", "tblFetcher", "fldID='" + fetcher[1] + "'");
                name3 = js.Lookup("fldFirstName", "tblFetcher", "fldID='" + fetcher[2] + "'") + " " + js.Lookup("fldLastName", "tblFetcher", "fldID='" + fetcher[2] + "'");



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
                tmrReader.Enabled = true;
            }

            btnConfirm.Focus();
            txtBarcode.Text = "";

        }
    }
}
