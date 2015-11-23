using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace KIDS_CheckIn_System.volunteers
{
    public partial class frmVolunteerManagement : Form
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

        string Picture = "";

        public frmVolunteerManagement()
        {
            InitializeComponent();
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
                lblStatus.ForeColor = System.Drawing.Color.Red;
                lblStatus.Text = "Card Reader not connected";

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
                lblStatus.ForeColor = System.Drawing.Color.Green;
                lblStatus.Text = "Please Scan Card";
                //timer1.Enabled = true;
            }  //displayOut(1, retCode, "");
            else
            {
                //displayOut(0, 0, "Successful connection to " + cbReader.Text);
                //MessageBox.Show("Reader Connected", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //lblNotification.ForeColor = System.Drawing.Color.Green;
                //lblNotification.Text = "Reader Connected";

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

        private void frmVolunteerManagement_Load(object sender, EventArgs e)
        {
            LoadVolunteers();
            LoadService();
            LoadClass();
        }

        private void LoadService()
        {
            string sql = "SELECT * FROM tblEvent";

            js.ExecuteQuery(sql);
            cboService.Items.Clear();
            while(js.RiD.Read())
            {
                cboService.Items.Add(js.RiD["fldEventTitle"]);
            }
        }

        private void LoadClass()
        {
            string sql = "SELECT * FROM tblGroup";

            js.ExecuteQuery(sql);
            cboClass.Items.Clear();
            while (js.RiD.Read())
            {
                cboClass.Items.Add(js.RiD["fldGroup"]);
            }
        }

        private void LoadWeek()
        {
            cboWeek.Items.Clear();
            cboWeek.Items.Add("1st Week");
            cboWeek.Items.Add("2nd Week");
            cboWeek.Items.Add("3rd Week");
            cboWeek.Items.Add("4th Week");
        }

        private void LoadVolunteers(string Week = "")
        {
            string sql = "SELECT * FROM tblVolunteers WHERE fldActive='1'";

            if(Week!="")
            {
                sql += " AND fldWeek='" + Week + "'";
            }

            js.ExecuteQuery(sql);
            dgvVolunteers.Rows.Clear();
            while(js.RiD.Read())
            {
                string service = js.Lookup("fldEventTitle", "tblEvent", "fldID='" + js.RiD["fldService"] + "'");
                string cls = js.Lookup("fldGroup", "tblGroup", "fldID='" + js.RiD["fldClass"] + "'");
                dgvVolunteers.Rows.Add(String.Format("{0:00000}", js.RiD["fldID"]), js.RiD["fldFirstName"], js.RiD["fldLastName"], js.RiD["fldNickName"], js.RiD["fldNameOnID"], service, js.RiD["fldWeek"], cls, js.RiD["fldMobile"], js.RiD["fldEmail"], js.RiD["fldVGL"]);
            }

            counter.Text = "Count: " + dgvVolunteers.Rows.Count;
        }

        private void allToolStripMenuItem_Click(object sender, EventArgs e)
        {
            drpWeek.Text = allToolStripMenuItem.Text;
            LoadVolunteers();
        }

        private void stWeekToolStripMenuItem_Click(object sender, EventArgs e)
        {
            drpWeek.Text = Week1.Text;
            LoadVolunteers(Week1.Text);
        }

        private void drpWeek_Click(object sender, EventArgs e)
        {
            drpStatus.Text = "Status: Active";
        }

        private void Week2_Click(object sender, EventArgs e)
        {
            drpWeek.Text = Week2.Text;
            LoadVolunteers(Week2.Text);
        }

        private void Week3_Click(object sender, EventArgs e)
        {
            drpWeek.Text = Week3.Text;
            LoadVolunteers(Week3.Text);
        }

        private void Week4_Click(object sender, EventArgs e)
        {
            drpWeek.Text = Week4.Text;
            LoadVolunteers(Week4.Text);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
           
            if(txtFirstName.Text=="")
            {
                ErrorProvider errFN = new ErrorProvider();
                errFN.SetError(txtFirstName,"Required Field");
                return;
            }

            if (txtLastName.Text == "")
            {
                ErrorProvider errLN = new ErrorProvider();
                errLN.SetError(txtLastName, "Required Field");
                return;
            }

            if (txtNickName.Text == "")
            {
                ErrorProvider errNN = new ErrorProvider();
                errNN.SetError(txtNickName, "Required Field");
                return;
            }

            if (txtNameOnId.Text == "")
            {
                ErrorProvider errNID = new ErrorProvider();
                errNID.SetError(txtNameOnId, "Required Field");
                return;
            }

            if (txtMobile.Text == "")
            {
                ErrorProvider errMobile = new ErrorProvider();
                errMobile.SetError(txtMobile, "Required Field");
                return;
            }

            if (txtEmail.Text == "")
            {
                ErrorProvider errEmail = new ErrorProvider();
                errEmail.SetError(txtEmail, "Required Field");
                return;
            }


            Picture = txtFirstName.Text+txtLastName.Text + "_" + DateTime.Now.ToString("mm.ss") +  ".jpg";
           

            if(this.Tag=="edit")
            {
                Volunteers vol = (Volunteers) btnSave.Tag;


                vol.setName(txtFirstName.Text, txtLastName.Text, txtNickName.Text, txtNameOnId.Text);
                vol.setAddress(txtStreet.Text, txtCity.Text);
                vol.setContact(txtEmail.Text, txtMobile.Text);
                vol.setVGDetails(txtVGL.Text, txtContactNo.Text, chkLeading.Checked);
                //int s = int.Parse(js.Lookup("fldID","tblEvent","fldEventTitle='" + cboService.Text + "'"));
                //int c = int.Parse(js.Lookup("fldID","tblGroup","fldGroup='" + cboClass.Text + "'"));
                //vol.setServiceDetails(s, cboWeek.Text, c);
                vol.setNFCCode(txtNFCCode.Text);
                vol.setPicPath(Picture);
                //System.IO.File.Delete(AccessRegistryTool.ReadValue("PicPath") + @"\volunteer\" + Picture);

                if (vol.Update())
                {
                    pictureBox1.Image.Save(AccessRegistryTool.ReadValue("PicPath") + @"\volunteer\" + Picture);
                    LoadVolunteers();
                    txtFirstName.Text = "";
                    txtLastName.Text = "";
                    txtNickName.Text = "";
                    txtNameOnId.Text = "";
                    txtMobile.Text = "";
                    txtEmail.Text = "";
                    txtStreet.Text = "";
                    txtCity.Text = "";
                    txtVGL.Text = "";
                    txtContactNo.Text = "";
                    LoadService();
                    LoadWeek();
                    LoadClass();
                    chkLeading.Checked = false;
                    txtNFCCode.Text = "";
                    pictureBox1.Image.Dispose();
                    pictureBox1.Image = Image.FromFile(AccessRegistryTool.ReadValue("PicPath") + "\\download.jpg");
                }
                else
                {
                    js.showExclamation("Failed Updating Volunteer Details");
                }

                this.Tag = null;


            }
            else
            {
                Volunteers vol = new Volunteers();
                vol.setName(txtFirstName.Text, txtLastName.Text, txtNickName.Text, txtNameOnId.Text);
                vol.setAddress(txtStreet.Text, txtCity.Text);
                vol.setContact(txtEmail.Text, txtMobile.Text);
                vol.setVGDetails(txtVGL.Text, txtContactNo.Text, chkLeading.Checked);
                //int s = int.Parse(js.Lookup("fldID", "tblEvent", "fldEventTitle='" + cboService.Text + "'"));
                //int c = int.Parse(js.Lookup("fldID", "tblGroup", "fldGroup='" + cboClass.Text + "'"));
               // vol.setServiceDetails(s, cboWeek.Text, c);
                vol.setPicPath(Picture);

                if(vol.Save())
                {
                    pictureBox1.Image.Save(AccessRegistryTool.ReadValue("PicPath") + @"\volunteer\" + Picture);
                    LoadVolunteers();
                    txtFirstName.Text = "";
                    txtLastName.Text = "";
                    txtNickName.Text = "";
                    txtNameOnId.Text = "";
                    txtMobile.Text = "";
                    txtEmail.Text = "";
                    txtStreet.Text = "";
                    txtCity.Text = "";
                    txtVGL.Text = "";
                    txtContactNo.Text = "";
                    LoadService();
                    LoadWeek();
                    LoadClass();
                    chkLeading.Checked = false;
                    txtNFCCode.Text = "";
                    Picture = "";
                    pictureBox1.Image.Dispose();
                    pictureBox1.Image = Image.FromFile(AccessRegistryTool.ReadValue("PicPath") + "\\download.jpg");
                }
            }

            tmrLogin.Enabled = false;

            //pictureBox1.Image.Save(AccessRegistryTool.ReadValue("PicPath") + @"\volunteer\" + Picture);


        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM tblVolunteers WHERE (fldFirstName LIKE'%" + txtSearch.Text + "%' OR fldLastName LIKE '%" + txtSearch.Text + "%')";
            js.ExecuteQuery(sql);
            dgvVolunteers.Rows.Clear();
            while (js.RiD.Read())
            {
                string service = js.Lookup("fldEventTitle", "tblEvent", "fldID='" + js.RiD["fldService"] + "'");
                string cls = js.Lookup("fldGroup", "tblGroup", "fldID='" + js.RiD["fldClass"] + "'");
                dgvVolunteers.Rows.Add(String.Format("{0:00000}", js.RiD["fldID"]), js.RiD["fldFirstName"], js.RiD["fldLastName"], js.RiD["fldNickName"], js.RiD["fldNameOnID"], service, js.RiD["fldWeek"], cls, js.RiD["fldMobile"], js.RiD["fldEmail"], js.RiD["fldVGL"]);
            }

            counter.Text = "Count: " + dgvVolunteers.Rows.Count;
        }

        private void dgvVolunteers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string id = dgvVolunteers.CurrentRow.Cells["fldID"].Value.ToString();
            this.Tag = "edit";
            Volunteers volunteer = new Volunteers(id);
            btnSave.Tag = volunteer;
            txtFirstName.Text = volunteer.getFirstName();
            txtLastName.Text = volunteer.getLastName();
            txtNickName.Text = volunteer.getNickName();
            txtNameOnId.Text = volunteer.getNameOnID();
            txtMobile.Text = volunteer.getMobile();
            txtEmail.Text = volunteer.getEmail();
            txtStreet.Text = volunteer.getStreet();
            txtCity.Text = volunteer.getCity();
            txtVGL.Text = volunteer.getVGL();
            txtContactNo.Text = volunteer.getVGLContact();
            //cboService.Text = js.Lookup("fldEventTitle", "tblEvent", "fldID='" + volunteer.getService() + "'");
            //cboWeek.Text = volunteer.getWeek();
            //cboClass.Text = js.Lookup("fldGroup", "tblGroup", "fldID='" + volunteer.getClass() + "'");
            chkLeading.Checked = volunteer.getLeading();
            txtNFCCode.Text = volunteer.getNFCCode();
            Picture = volunteer.getPicPath();

            if (System.IO.File.Exists(AccessRegistryTool.ReadValue("PicPath") + @"\volunteer\" + Picture))
            {
                pictureBox1.Image = Image.FromFile(AccessRegistryTool.ReadValue("PicPath") + @"\volunteer\" + Picture);
            }
            else
            {
                pictureBox1.Image = Image.FromFile(AccessRegistryTool.ReadValue("PicPath") + "\\download.jpg");
            }

        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            ToolTip tip = new ToolTip();
            tip.SetToolTip(pictureBox1, "Click to Take Picture");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            frmTakePicture frm = new frmTakePicture();

            if(frm.ShowDialog()== System.Windows.Forms.DialogResult.OK)
            {
                pictureBox1.Image = (Image)(frm.Tag);
            }
        }

        private void activeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM tblVolunteers WHERE fldActive='1'";

            js.ExecuteQuery(sql);
            dgvVolunteers.Rows.Clear();
            while (js.RiD.Read())
            {
                string service = js.Lookup("fldEventTitle", "tblEvent", "fldID='" + js.RiD["fldService"] + "'");
                string cls = js.Lookup("fldGroup", "tblGroup", "fldID='" + js.RiD["fldClass"] + "'");
                dgvVolunteers.Rows.Add(String.Format("{0:00000}", js.RiD["fldID"]), js.RiD["fldFirstName"], js.RiD["fldLastName"], js.RiD["fldNickName"], js.RiD["fldNameOnID"], service, js.RiD["fldWeek"], cls, js.RiD["fldMobile"], js.RiD["fldEmail"], js.RiD["fldVGL"]);
            }

            counter.Text = "Count: " + dgvVolunteers.Rows.Count;

            drpStatus.Text = "Status: Active";
        }

        private void notActiveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM tblVolunteers WHERE fldActive='0'";

            js.ExecuteQuery(sql);
            dgvVolunteers.Rows.Clear();
            while (js.RiD.Read())
            {
                string service = js.Lookup("fldEventTitle", "tblEvent", "fldID='" + js.RiD["fldService"] + "'");
                string cls = js.Lookup("fldGroup", "tblGroup", "fldID='" + js.RiD["fldClass"] + "'");
                dgvVolunteers.Rows.Add(String.Format("{0:00000}", js.RiD["fldID"]), js.RiD["fldFirstName"], js.RiD["fldLastName"], js.RiD["fldNickName"], js.RiD["fldNameOnID"], service, js.RiD["fldWeek"], cls, js.RiD["fldMobile"], js.RiD["fldEmail"], js.RiD["fldVGL"]);
            }

            counter.Text = "Count: " + dgvVolunteers.Rows.Count;
            drpStatus.Text = "Status: Not Active";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string id = dgvVolunteers.CurrentRow.Cells["fldID"].Value.ToString();
            js.ExecuteNonQuery("UPDATE tblVolunteers SET fldActive=0 WHERE fldID='" + id + "'");
            LoadVolunteers();
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtNickName.Text = "";
            txtNameOnId.Text = "";
            txtMobile.Text = "";
            txtEmail.Text = "";
            txtStreet.Text = "";
            txtCity.Text = "";
            txtVGL.Text = "";
            txtContactNo.Text = "";
            LoadService();
            LoadWeek();
            LoadClass();
            chkLeading.Checked = false;
            txtNFCCode.Text = "";
        }

        private void tmrLogin_Tick(object sender, EventArgs e)
        {
            retCode = CardConnect(1);

            if (retCode != ModWinsCard.SCARD_S_SUCCESS)
            {

                //displayOut(5, 0, "No card within range.");
                //tsMsg2.Text = "";
                return;

            }


            if (CheckCard())
            {

                getParam();

                string tmpStr = "";
                int indx;

                for (indx = 0; indx <= RecvLen - 3; indx++)
                {

                    tmpStr = tmpStr + string.Format("{0:X2}", RecvBuff[indx]);

                }

                txtNFCCode.Text = tmpStr;

                
            }

            else
            {



            }
            //timer1.Enabled = true;
        }

        private void btnScan_Click(object sender, EventArgs e)
        {
            StartReader();
            tmrLogin.Enabled = true;
        }

        private void drpStatus_Click(object sender, EventArgs e)
        {
            drpWeek.Text = "All";
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void btnbrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();

            open.FilterIndex = 1;
            open.Filter = "JPEG: .jpg|*.jpg";
            open.InitialDirectory = Environment.SpecialFolder.MyPictures.ToString();
            open.Title = "Browse Picture";


            if(open.ShowDialog()== System.Windows.Forms.DialogResult.OK)
            {
                pictureBox1.Image = System.Drawing.Image.FromFile(open.FileName);
                Picture = System.IO.Path.GetFileName(open.FileName);
            }

        }


    }
}
