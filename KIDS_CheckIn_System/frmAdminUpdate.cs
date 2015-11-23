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
    public partial class frmAdminUpdate : Form
    {

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
        string strReaderName = "";



        string fetcherImage = "";
        Connector js = new Connector();
        //Connector2 js = new Connector2();
        string fldAddressDetails = "";
        string fldContactDetails = "";
        int fldFetcherID = 0;
        string fldNationality = "";
        string fldKidsID = "";

        string KidsPicture = "";

        string[] fetcherID = new string[3];

        public frmAdminUpdate()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string qry = "";

            if (cboSearch.Text == "First Name")
            {

                qry = "SELECT k.*,g.fldGender as Gender FROM tblKids  k " +
                           "LEFT OUTER JOIN tblGender g ON g.fldID=k.fldGender" +
                           " WHERE fldFirstName='" + txtSearch.Text + "'";
            }

            if (cboSearch.Text == "Last Name")
            {

                qry = "SELECT k.*,g.fldGender as Gender FROM tblKids  k " +
                             "LEFT OUTER JOIN tblGender g ON g.fldID=k.fldGender" +
                             " WHERE fldLastName='" + txtSearch.Text + "'";
            }


            if (cboSearch.Text == "Nick Name")
            {

                qry = "SELECT k.*,g.fldGender as Gender FROM tblKids  k " +
                             "LEFT OUTER JOIN tblGender g ON g.fldID=k.fldGender" +
                             " WHERE fldNickName='" + txtSearch.Text + "'";
            }


            if (cboSearch.Text == "Birth Day")
            {

                qry = "SELECT k.*,g.fldGender as Gender FROM tblKids  k " +
                             "LEFT OUTER JOIN tblGender g ON g.fldID=k.fldGender" +
                             " WHERE fldBirthday='" + dtSearch.Value.ToShortDateString() + "'";
            }


            if (cboSearch.Text == "Barcode")
            {

                qry = "SELECT k.*,g.fldGender as Gender FROM tblKids  k " +
                             "LEFT OUTER JOIN tblGender g ON g.fldID=k.fldGender" +
                             " WHERE fldStudentID='" + txtSearch.Text + "'";

                string q = qry;

                js.ExecuteQuery(q);
                js.RiD.Read();

                lblStudentID.Text = js.RiD["fldStudentID"].ToString();
                txtFirstName.Text = js.RiD["fldFirstName"].ToString();
                txtLastName.Text = js.RiD["fldLastName"].ToString();
                txtMiddleName.Text = js.RiD["fldMiddleName"].ToString();
                txtNickName.Text = js.RiD["fldNickName"].ToString();
                dtBirthdate.Value = Convert.ToDateTime(js.RiD["fldBirthday"].ToString());
                cboGender.Text = js.RiD["Gender"].ToString();
                txtChurch.Text = js.Lookup("fldChurch", "tblChurch", "fldID='" + js.RiD["fldChurch"].ToString() + "'");
                fldAddressDetails = js.RiD["fldAddressDetails"].ToString();
                fldContactDetails = js.RiD["fldContactDetails"].ToString();
                fldNationality = js.RiD["fldNationality"].ToString();
                cboNationality.Text = js.Lookup("fldNationality", "tblNationality", "fldID='" + js.RiD["fldNationality"].ToString() + "'");
                txtPoints.Text = js.RiD["fldPoints"].ToString();
                fldKidsID = js.RiD["fldID"].ToString();

                //FOR LOADING PICTURE
                string picture = js.RiD["fldPicture"].ToString();
                string temppic = Application.StartupPath + "/Pictures/tmp/Kids/tmp1.jpg";
                if (System.IO.File.Exists(picture))
                {
                    //pbImage.Dispose();
                    pbImage.Image.Dispose();
                    System.IO.File.Copy(picture, temppic, true);
                    pbImage.Image = System.Drawing.Image.FromFile(temppic);
                }


                js.CloseConnection();



                //For the Address Details
                q = "SELECT * FROM tblAddress WHERE fldID='" + fldAddressDetails + "'";
                js.ExecuteQuery(q);
                js.RiD.Read();

                if (js.RiD.HasRows)
                {
                    txtAddress1.Text = js.RiD["fldAddress1"].ToString();
                    txtAddress2.Text = js.RiD["fldAddress2"].ToString();
                    txtCity.Text = js.RiD["fldCity"].ToString();
                    txtZipCode.Text = js.RiD["fldZipCode"].ToString();
                }

                js.CloseConnection();


                //For Contact Details
                q = "SELECT * FROM tblContactDetails WHERE fldID='" + fldContactDetails + "'";
                js.ExecuteQuery(q);
                js.RiD.Read();

                if (js.RiD.HasRows)
                {
                    txtContactNo.Text = js.RiD["fldContactNumber"].ToString();
                }

                js.CloseConnection();

                GetFectchers();

                for (int i = 0; i <= (fetcherID.Length - 1); i++)
                {
                    string qq = "SELECT f.*,a.*,r.fldRelationship as Relationship,c.fldContactNumber FROM tblFetcher f " +
                                 " LEFT OUTER JOIN tblAddress a ON a.fldID=f.fldAddressDetails " +
                                 " LEFT OUTER JOIN tblContactDetails c ON c.fldID = f.fldContactDetails " +
                                 " LEFT OUTER JOIN tblRelationship r ON r.fldID = f.fldRelationship" +
                                 " WHERE f.fldID = '" + fetcherID[i] + "'";
                    js.ExecuteQuery(qq);
                    js.RiD.Read();

                    if (js.RiD.HasRows)
                    {
                        dgvFetchers.Rows.Add(js.RiD["fldID"], js.RiD["fldFirstName"], js.RiD["fldLastName"], js.RiD["fldMiddleName"], js.RiD["Relationship"], js.RiD["fldContactNumber"], js.RiD["fldAddress1"], js.RiD["fldAddress2"], js.RiD["fldCity"], js.RiD["fldZipCode"], js.RiD["fldPicture"]);
                    }




                }

                

                if (dgvFetchers.Rows.Count != 0)
                {
                    if (dgvFetchers.Rows.Count == 1)
                    {
                        if (System.IO.File.Exists(dgvFetchers.Rows[0].Cells["Picture"].Value.ToString()))
                        { 
                            pbFetcher1.Image = Image.FromFile(dgvFetchers.Rows[0].Cells["Picture"].Value.ToString());
                        }
                    }
                    else if (dgvFetchers.Rows.Count == 2)
                    {
                        if (System.IO.File.Exists(dgvFetchers.Rows[0].Cells["Picture"].Value.ToString()))
                        { 
                            pbFetcher1.Image = Image.FromFile(dgvFetchers.Rows[0].Cells["Picture"].Value.ToString());
                        }



                        if (System.IO.File.Exists(dgvFetchers.Rows[1].Cells["Picture"].Value.ToString()))
                        {
                            pbFetcher2.Image = Image.FromFile(dgvFetchers.Rows[1].Cells["Picture"].Value.ToString());
                        }
                    }
                    else
                    {
                        if (System.IO.File.Exists(dgvFetchers.Rows[0].Cells["Picture"].Value.ToString()))
                        {
                            pbFetcher1.Image = Image.FromFile(dgvFetchers.Rows[0].Cells["Picture"].Value.ToString());
                        }



                        if (System.IO.File.Exists(dgvFetchers.Rows[1].Cells["Picture"].Value.ToString()))
                        {
                            pbFetcher2.Image = Image.FromFile(dgvFetchers.Rows[1].Cells["Picture"].Value.ToString());
                        }

                        if (System.IO.File.Exists(dgvFetchers.Rows[2].Cells["Picture"].Value.ToString()))
                        {
                            pbFetcher2.Image = Image.FromFile(dgvFetchers.Rows[2].Cells["Picture"].Value.ToString());
                        }
                    }
                }

                StartReader();

                return;


            }

            //js.searchquery = qry;

            frmResults frm = new frmResults();
            frm.Tag = qry;
            if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string q = frm.Tag.ToString();

                js.ExecuteQuery(q);
                js.RiD.Read();

                lblStudentID.Text = js.RiD["fldStudentID"].ToString();
                txtFirstName.Text = js.RiD["fldFirstName"].ToString();
                txtLastName.Text = js.RiD["fldLastName"].ToString();
                txtMiddleName.Text = js.RiD["fldMiddleName"].ToString();
                txtNickName.Text = js.RiD["fldNickName"].ToString();
                dtBirthdate.Value = Convert.ToDateTime(js.RiD["fldBirthday"].ToString());
                cboGender.Text = js.RiD["Gender"].ToString();
                txtChurch.Text = js.Lookup("fldChurch", "tblChurch", "fldID='" + js.RiD["fldChurch"].ToString() + "'");
                fldAddressDetails = js.RiD["fldAddressDetails"].ToString();
                fldContactDetails = js.RiD["fldContactDetails"].ToString();
                fldNationality = js.RiD["fldNationality"].ToString();
                cboNationality.Text = js.Lookup("fldNationality", "tblNationality", "fldID='" + js.RiD["fldNationality"].ToString() + "'");
                txtPoints.Text = js.RiD["fldPoints"].ToString();
                fldKidsID = js.RiD["fldID"].ToString();

                //FOR LOADING PICTURE
                string picture =  js.RiD["fldPicture"].ToString() + "";
                string temppic = Application.StartupPath + "/Pictures/tmp/Kids/tmp1.jpg";
                if (System.IO.File.Exists(picture))
                {
                    //pbImage.Dispose();
                    pbImage.Image.Dispose();
                    System.IO.File.Copy(picture, temppic, true);
                    pbImage.Image = System.Drawing.Image.FromFile(temppic);
                }


                js.CloseConnection();



                //For the Address Details
                q = "SELECT * FROM tblAddress WHERE fldID='" + fldAddressDetails + "'";
                js.ExecuteQuery(q);
                js.RiD.Read();

                if (js.RiD.HasRows)
                {
                    txtAddress1.Text = js.RiD["fldAddress1"].ToString();
                    txtAddress2.Text = js.RiD["fldAddress2"].ToString();
                    txtCity.Text = js.RiD["fldCity"].ToString();
                    txtZipCode.Text = js.RiD["fldZipCode"].ToString();
                }

                js.CloseConnection();


                //For Contact Details
                q = "SELECT * FROM tblContactDetails WHERE fldID='" + fldContactDetails + "'";
                js.ExecuteQuery(q);
                js.RiD.Read();

                if (js.RiD.HasRows)
                {
                    txtContactNo.Text = js.RiD["fldContactNumber"].ToString();
                }

                js.CloseConnection();

                GetFectchers();

                for (int i = 0; i <= (fetcherID.Length - 1); i++)
                {
                    string qq = "SELECT f.*,a.*,r.fldRelationship as Relationship,c.fldContactNumber FROM tblFetcher f " +
                                 " LEFT OUTER JOIN tblAddress a ON a.fldID=f.fldAddressDetails " +
                                 " LEFT OUTER JOIN tblContactDetails c ON c.fldID = f.fldContactDetails " +
                                 " LEFT OUTER JOIN tblRelationship r ON r.fldID = f.fldRelationship" +
                                 " WHERE f.fldID = '" + fetcherID[i] + "'";
                    js.ExecuteQuery(qq);
                    js.RiD.Read();

                    if (js.RiD.HasRows)
                    {
                        dgvFetchers.Rows.Add(js.RiD["fldID"], js.RiD["fldFirstName"], js.RiD["fldLastName"], js.RiD["fldMiddleName"], js.RiD["Relationship"], js.RiD["fldContactNumber"], js.RiD["fldAddress1"], js.RiD["fldAddress2"], js.RiD["fldCity"], js.RiD["fldZipCode"], js.RiD["fldPicture"]);
                    }

                   


                }

                if (dgvFetchers.Rows.Count != 0)
                {
                    if (dgvFetchers.Rows.Count == 1)
                    {
                        if (System.IO.File.Exists(dgvFetchers.Rows[0].Cells["Picture"].Value.ToString()))
                        {
                            pbFetcher1.Image = Image.FromFile(dgvFetchers.Rows[0].Cells["Picture"].Value.ToString());
                        }
                    }
                    else if (dgvFetchers.Rows.Count == 2)
                    {
                        if (System.IO.File.Exists(dgvFetchers.Rows[0].Cells["Picture"].Value.ToString()))
                        {
                            pbFetcher1.Image = Image.FromFile(dgvFetchers.Rows[0].Cells["Picture"].Value.ToString());
                        }



                        if (System.IO.File.Exists(dgvFetchers.Rows[1].Cells["Picture"].Value.ToString()))
                        {
                            pbFetcher2.Image = Image.FromFile(dgvFetchers.Rows[1].Cells["Picture"].Value.ToString());
                        }
                    }
                    else
                    {
                        if (System.IO.File.Exists(dgvFetchers.Rows[0].Cells["Picture"].Value.ToString()))
                        {
                            pbFetcher1.Image = Image.FromFile(dgvFetchers.Rows[0].Cells["Picture"].Value.ToString());
                        }



                        if (System.IO.File.Exists(dgvFetchers.Rows[1].Cells["Picture"].Value.ToString()))
                        {
                            pbFetcher2.Image = Image.FromFile(dgvFetchers.Rows[1].Cells["Picture"].Value.ToString());
                        }

                        if (System.IO.File.Exists(dgvFetchers.Rows[2].Cells["Picture"].Value.ToString()))
                        {
                            pbFetcher2.Image = Image.FromFile(dgvFetchers.Rows[2].Cells["Picture"].Value.ToString());
                        }
                    }
                }


                StartReader();



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

                //displayOut(1, retCode, "");

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
                strReaderName = rName;
                rName = "";
                indx = indx + 1;

            }


            //CONNECTING TO THE READER
            retCode = ModWinsCard.SCardConnect(hContext, strReaderName, ModWinsCard.SCARD_SHARE_SHARED,
                                          ModWinsCard.SCARD_PROTOCOL_T0 | ModWinsCard.SCARD_PROTOCOL_T1, ref hCard, ref Protocol);

            if (retCode != ModWinsCard.SCARD_S_SUCCESS)
            {
                MessageBox.Show("Please Connect the card","", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

        private void cboSearch_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cboSearch.Text == "Birth Day")
            {
                txtSearch.Visible = false;
                dtSearch.Visible = true;
                txtSearch.Tag = "";
                dtSearch.Tag = cboSearch.Text;
            }
            else
            {
                txtSearch.Visible = true;
                dtSearch.Visible = false;
                txtSearch.Tag = cboSearch.Text;
                dtSearch.Tag = "";
            }
        }

        private void GetFectchers()
        {
            string q = "SELECT * FROM tblKidFetcher WHERE fldKidID='" + fldKidsID + "'";
            js.ExecuteQuery(q);
            int i = 0;
            while (js.RiD.Read())
            {
                fetcherID[i] = js.RiD["fldFetcherID"].ToString();
                i += 1;
            }

            js.CloseConnection();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void frmAdminUpdate_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
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

                txtKNFC.Text = tmpStr;
                timer1.Enabled = false;
                //bStartPoll_Click(null, null);
            }

            else
            {

                //displayOut(5, 0, "No card within range.");
                //tsMsg2.Text = "";

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
            retCode = ModWinsCard.SCardConnect(hContext, strReaderName, ModWinsCard.SCARD_SHARE_SHARED, ModWinsCard.SCARD_PROTOCOL_T0 | ModWinsCard.SCARD_PROTOCOL_T1, ref hCard, ref Protocol);

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

            retCode = ModWinsCard.SCardStatus(hCard, strReaderName, ref ReaderLen, ref dwState, ref dwActProtocol, ref ATRVal[0], ref ATRLen);

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

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if(txtKNFC.Text=="")
            {
                MessageBox.Show("");
            }

            fldKidsID = js.Lookup("fldID", "tblKids", "fldStudentID='" + lblStudentID.Text + "'");

            string q = "SELECT * FROM tblKidsNFC WHERE fldKidID='" + fldKidsID + "'";

            js.ExecuteQuery(q);

            js.RiD.Read();
            
           if(js.RiD.HasRows)
           {
               js.CloseConnection();

               q = "UPDATE tblKidsNFC SET fldNFCCode='" + txtKNFC.Text + "' WHERE fldKidID='" + fldKidsID + "'";

               js.ExecuteNonQuery(q);
               //js.ExecuteNonQuery(q);
           }
           else
           {
               q = "INSERT INTO tblKidsNFC(fldNFCCode,fldKidID) VALUES('" + txtKNFC.Text + "','" + fldKidsID + "')";

               js.ExecuteNonQuery(q);
               //js.ExecuteNonQuery(q);
           }

           tabControl1.SelectTab(1);
           timer2.Enabled = true;

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

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

                txtFNFC.Text = tmpStr;
                timer2.Enabled = false;
                //bStartPoll_Click(null, null);
            }

            else
            {

                //displayOut(5, 0, "No card within range.");
                //tsMsg2.Text = "";

            }
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            if(txtFNFC.Text.Trim()=="")
            {
                MessageBox.Show("Cannot proceed without NFC","", MessageBoxButtons.OK,  MessageBoxIcon.Exclamation);
                return;
            }

            for (int i = 0; i<=(dgvFetchers.Rows.Count-1);i++)
            {
                string fID = dgvFetchers.Rows[i].Cells["fID"].Value.ToString();

                string q = "SELECT * FROM tblFetcherNFC WHERE fldFetcherID='" + fID + "'";

                js.ExecuteQuery(q);

                js.RiD.Read();

                if (js.RiD.HasRows)
                {
                    js.CloseConnection();

                    q = "UPDATE tblFetcherNFC SET fldNFCCode='" + txtFNFC.Text + "' WHERE fldKidID='" + fID + "'";

                    js.ExecuteNonQuery(q);
                    //js.ExecuteNonQuery(q);
                }
                else
                {
                    q = "INSERT INTO tblKidsNFC(fldNFCCode,fldKidID) VALUES('" + txtFNFC.Text + "','" + fID + "')";

                    js.ExecuteNonQuery(q);
                    //js.ExecuteNonQuery(q);
                }

                //tabControl1.SelectTab(1);
                //timer2.Enabled = true;

                MessageBox.Show("Kids and Fetcher NFC Successfully Updated", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtAddress1.Text = "";
                txtAddress2.Text = "";
                txtChurch.Text = "";
                txtCity.Text = "";
                txtContactNo.Text = "";
                txtFirstName.Text = "";
                txtFNFC.Text = "";
                txtKNFC.Text = "";
                txtLastName.Text = "";
                txtMiddleName.Text = "";
                txtNickName.Text = "";
                txtPoints.Text = "";
                txtSearch.Text = "";
                txtZipCode.Text = "";
                dgvFetchers.Rows.Clear();
                pbFetcher1.Image.Dispose();
                pbFetcher2.Image.Dispose();
                pbFetcher3.Image.Dispose();
                pbImage.Image.Dispose();

                cboGender.Text = "";
                cboNationality.Text = "";
                lblStudentID.Text = "000000000000";

                pbFetcher1.Image = Image.FromFile(Application.StartupPath + "/Pictures/download.jpg");
                pbFetcher2.Image = Image.FromFile(Application.StartupPath + "/Pictures/download.jpg");
                pbFetcher3.Image = Image.FromFile(Application.StartupPath + "/Pictures/download.jpg");
                pbImage.Image = Image.FromFile(Application.StartupPath + "/Pictures/download.jpg");

                tabControl1.SelectTab(0);
            }


        }

        private void btnReScan_Click(object sender, EventArgs e)
        {
            StartReader();
            timer1.Enabled = true;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StartReader();
            timer2.Enabled = true;
        }

        private void label24_Click(object sender, EventArgs e)
        {

        }
    }
}
