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
    public partial class frmPoints : Form
    {
        Connector js = new Connector();
        int points = 0;
        string KidID = "";
        string cp;
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

        public frmPoints()
        {
            InitializeComponent();
        }

        private void rb20_CheckedChanged(object sender, EventArgs e)
        {
            points = 20;
            lblAddPoints.Text = "Additional Pts. " + cp + " + " + points;
            lbltotalpoints.Text = "Total Pts. " +  (Convert.ToInt32(cp) + points).ToString();
        }

        private void rb50_CheckedChanged(object sender, EventArgs e)
        {
            points = 50;
            lblAddPoints.Text = "Additional Pts. " + cp + " + " + points;
            lbltotalpoints.Text = "Total Pts. " + (Convert.ToInt32(cp) + points).ToString();
        }

        private void rb100_CheckedChanged(object sender, EventArgs e)
        {
            points = 100;
            lblAddPoints.Text = "Additional Pts. " + cp + " + " + points;
            lbltotalpoints.Text = "Total Pts. " + (Convert.ToInt32(cp) + points).ToString();
        }

        private void rb200_CheckedChanged(object sender, EventArgs e)
        {
            points = 200;
            lblAddPoints.Text = "Additional Pts. " + cp + " + " + points;
            lbltotalpoints.Text = "Total Pts. " + (Convert.ToInt32(cp) + points).ToString();
        }

        private void rb500_CheckedChanged(object sender, EventArgs e)
        {
            points = 500;
            lblAddPoints.Text = "Additional Pts. " + cp + " + " + points;
            lbltotalpoints.Text = "Total Pts. " + (Convert.ToInt32(cp) + points).ToString();
        }

        private void rb1000_CheckedChanged(object sender, EventArgs e)
        {
            points = 1000;
            lblAddPoints.Text = "Additional Pts. " + cp + " + " + points;
            lbltotalpoints.Text = "Total Pts. " + (Convert.ToInt32(cp) + points).ToString();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int totalpoint = int.Parse(cp) + points;

            string q = "UPDATE tblKids SET fldPoints='" + totalpoint + "' WHERE fldID='" + KidID + "'";
            js.ExecuteNonQuery(q);

            js.showInformation( points + " Points Added to " + lblName.Text );

            Close();

        }

        private void frmPoints_Load(object sender, EventArgs e)
        {
            StartReader();
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
                lblReader.Text = "Card Reader not Connected";

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
                lblReader.Text = "Please Scan Card";
                //timer1.Enabled = true;
            }  //displayOut(1, retCode, "");
            else
            {
                //displayOut(0, 0, "Successful connection to " + cbReader.Text);
                //MessageBox.Show("Reader Connected", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lblReader.Text = "Reader Connected";


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


                string fldKidID = js.Lookup("fldKidID","tblKidsNFC","fldNFCCode='" + tmpStr + "'");

                string q = "SELECT * FROM tblKids WHERE fldID='" + fldKidID + "'";
                js.ExecuteQuery(q);
                js.RiD.Read();

                if (!js.RiD.HasRows) { lblReader.Text = "No Record Found" ; return; }
                string fldPicture = AccessRegistryTool.ReadValue("PicPath") + "/Kids/" + js.RiD["fldPicture"];

                if(System.IO.File.Exists(fldPicture))
                {
                    pictureBox1.Image = Image.FromFile(fldPicture);
                }
                else
                {
                    pictureBox1.Image = Image.FromFile(Application.StartupPath + "/Pictures/download.jpg");
                }

                lblName.Text = js.RiD["fldFirstName"] + " " + js.RiD["fldLastName"];
                cp = "" + js.RiD["fldPoints"].ToString();

                if (cp == "") { cp = "0"; }

                lblPoints.Text = "Current Pts. " + Convert.ToInt32(cp).ToString();


                lblAddPoints.Text = "Additional Pts. " +  cp + " + " + points;
                lbltotalpoints.Text = "Total Pts. " +  (Convert.ToInt32(cp) + points).ToString();

                KidID = fldKidID;
        
            }

            else
            {

                //displayOut(5, 0, "No card within range.");
                //tsMsg2.Text = "";

                lblReader.Text = "No Card Within Range";

            }
            //timer1.Enabled = true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }

        private void rb300_CheckedChanged(object sender, EventArgs e)
        {
            points = 300;
            lblAddPoints.Text = "Additional Pts. " + cp + " + " + points;
            lbltotalpoints.Text = "Total Pts. " + (Convert.ToInt32(cp) + points).ToString();
        }

        private void frmPoints_FormClosed(object sender, FormClosedEventArgs e)
        {
            tmrReader.Enabled = false;
        }

    }
}
