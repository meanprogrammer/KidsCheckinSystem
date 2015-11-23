using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DYMO.Common;
using DYMO;



namespace KIDS_CheckIn_System
{
    public partial class frmHelpDesk : Form
    {
        string fetcherImage = "";
        Connector js = new Connector();
        //Connector2 js2 = new Connector2();
        string fldAddressDetails = "";
        string fldContactDetails = "";
        int fldFetcherID = 0;
        string fldNationality = "";
        string fldKidsID = "";

        string timestamp = "";

        string KidsPicture = "";




        string[] fetcherID = new string[3];
        public frmHelpDesk()
        {
            InitializeComponent();
        }

        private void frmHelpDesk_Load(object sender, EventArgs e)
        {
            tabControl1.TabPages.Remove(tabControl1.TabPages[1]);
            cboSearch.Text = "Last Name";
        }

        private void frmHelpDesk_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmSystemOptions frm = new frmSystemOptions();
            frm.Show();
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string qry = "";

            if (cboSearch.Text == "First Name")
            {

                qry = "SELECT k.*,g.fldGender as Gender FROM tblKids  k " +
                           "LEFT OUTER JOIN tblGender g ON g.fldID=k.fldGender" +
                           " WHERE fldFirstName='" + txtSearch.Text.Replace("'","''") + "' ORDER BY fldLastName";
            }

            if (cboSearch.Text == "Last Name")
            {

                qry = "SELECT k.*,g.fldGender as Gender FROM tblKids  k " +
                             "LEFT OUTER JOIN tblGender g ON g.fldID=k.fldGender" +
                             " WHERE fldLastName LIKE'%" + txtSearch.Text.Replace("'", "''") + "%' ORDER BY fldFirstName";
            }


            if (cboSearch.Text == "Nick Name")
            {

                qry = "SELECT k.*,g.fldGender as Gender FROM tblKids  k " +
                             "LEFT OUTER JOIN tblGender g ON g.fldID=k.fldGender" +
                             " WHERE fldNickName LIKE '%" + txtSearch.Text.Replace("'", "''") + "%' ORDER BY fldFirstName,fldLastName";
            }


            if (cboSearch.Text == "Birth Day")
            {

                qry = "SELECT k.*,g.fldGender as Gender FROM tblKids  k " +
                             "LEFT OUTER JOIN tblGender g ON g.fldID=k.fldGender" +
                             " WHERE fldBirthday LIKE '%" + dtSearch.Value.ToShortDateString() + "%' ORDER BY fldFirstName, fldLastName";
            }


            if (cboSearch.Text == "Barcode")
            {

                qry = "SELECT k.*,g.fldGender as Gender FROM tblKids  k " +
                             "LEFT OUTER JOIN tblGender g ON g.fldID=k.fldGender" +
                             " WHERE fldStudentID='" + txtSearch.Text.Replace("'", "''") + "'";

                string q = qry;

                try
                {
                    js.ExecuteQuery(q);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error Connection", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                //js.ExecuteQuery(q);
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
                cboNationality.Text = js.RiD["fldNationality"].ToString();
                txtPoints.Text = js.RiD["fldPoints"].ToString();
                fldKidsID = js.RiD["fldID"].ToString();

                int age = js.GetAge(dtBirthdate.Value);

                txtAge.Text = age.ToString();

                txtAllergies.Text = js.RiD["fldAllergies"].ToString();

                string status = js.RiD["fldUpdateStatus"].ToString();

                txtStatus.Text = js.Lookup("fldStatus", "tblStatus", "fldID='" + status + "'");

                txtRemarks.Text = js.RiD["fldRemarks"].ToString();

                if (age >= 10)
                {
                    //chkTick.Enabled = true;
                }
                else
                {
                    //chkTick.Enabled = false;
                }
                //FOR LOADING PICTURE
                string picture = js.GetPath() + "/Kids/" + js.RiD["fldPicture"].ToString();
                string temppic = Application.StartupPath + "/Pictures/tmp/Kids/tmp1.jpg";
                if (System.IO.File.Exists(picture))
                {
                    pbImage.Image.Dispose();
                    System.IO.File.Copy(picture, temppic, true);
                    pbImage.Image = System.Drawing.Image.FromFile(temppic);
                }


                js.CloseConnection();



                //For the Address Details
                q = "SELECT * FROM tblAddress WHERE fldID='" + fldAddressDetails + "'";

                try
                {
                    js.ExecuteQuery(q);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error Connection", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                //js.ExecuteQuery(q);
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

                try
                {
                    js.ExecuteQuery(q);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error Connection", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                //js.ExecuteQuery(q);
                js.RiD.Read();

                if (js.RiD.HasRows)
                {
                    txtContactNo.Text = js.RiD["fldContactNumber"].ToString();
                }

                js.CloseConnection();


                return;


            }

            //js.searchquery = qry;

            frmResults frm = new frmResults();
            frm.Tag = qry;
            if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string q = frm.Tag.ToString();


                try
                {
                    js.ExecuteQuery(q);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error Connection", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                //js.ExecuteQuery(q);
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
                cboNationality.Text = js.RiD["fldNationality"].ToString();
                txtPoints.Text = js.RiD["fldPoints"].ToString();
                fldKidsID = js.RiD["fldID"].ToString();

                int age = js.GetAge(dtBirthdate.Value);

                txtAge.Text = age.ToString();

                txtAllergies.Text = js.RiD["fldAllergies"].ToString();

                string status = js.RiD["fldUpdateStatus"].ToString();

                txtStatus.Text = js.Lookup("fldStatus", "tblStatus", "fldID='" + status + "'");
                txtRemarks.Text = js.RiD["fldRemarks"].ToString();


                if (age >= 10)
                {
                    //chkTick.Enabled = true;
                }
                else
                {
                    //chkTick.Enabled = false;
                }

                //FOR LOADING PICTURE
                string picture = js.GetPath() + "/Kids/" + js.RiD["fldPicture"].ToString();
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

                try
                {
                    js.ExecuteQuery(q);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error Connection", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                //js.ExecuteQuery(q);
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


                try
                {
                    js.ExecuteQuery(q);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error Connection", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                js.ExecuteQuery(q);
                js.RiD.Read();

                if (js.RiD.HasRows)
                {
                    txtContactNo.Text = js.RiD["fldContactNumber"].ToString();
                }

                js.CloseConnection();

            }


        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            if (txtLastName.Text == "" && txtLastName.Text == "")
            {
                MessageBox.Show("Kids First Name and Last Name Required", "Importing Picture", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            openFileDialog1.FilterIndex = 1;
            openFileDialog1.Filter = "JPEG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif|PNG Files (*.png)|*.png";

            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                var filename = openFileDialog1.FileName;

                //System.IO.File.Copy(filename, Application.StartupPath + "/Pictures/Kids/" + txtFirstName.Text + txtLastName.Text + ".jpg", true);
                //pbImage.Image = System.Drawing.Image.FromFile(Application.StartupPath + "/Pictures/Kids/" + txtFirstName.Text + txtLastName.Text + ".jpg");
                pbImage.Image = System.Drawing.Image.FromFile(filename);
                openFileDialog1.Dispose();

            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if(txtNickName.Text =="")
            {
                js.showExclamation("Cannot Print Empty Fields");
                return;
            }

            Dymo.DymoAddIn addin = new Dymo.DymoAddIn();
            Dymo.DymoLabels labels = new Dymo.DymoLabels();

            if(addin.Open(Application.StartupPath + "/include/tempID.label"))
            {
                labels.SetField("Barcode","*" +  lblStudentID.Text + "*");
                labels.SetField("NickName", txtNickName.Text);
                labels.SetField("LastName", txtLastName.Text);
                if (rbLost.Checked)
                {
                    labels.SetField("Status", "Lost/Forgotten");
                }
                else
                {
                    labels.SetField("Status", "New");
                }

                string group;
                string age = txtAge.Text;

                if (Convert.ToDecimal(age) < 2)
                {
                    group = "Nursery";
                }

                else if ((Convert.ToDecimal(age) >= 2) && (Convert.ToDecimal(age) < 3))
                {
                    group = "Toddlers";
                }

                else if ((Convert.ToDecimal(age) >= 3) && (Convert.ToDecimal(age) <= 4))
                {
                    group = "Preschool";
                }

                else if ((Convert.ToDecimal(age) >= 5) && (Convert.ToDecimal(age) <= 6))
                {
                    group = "Kinder";
                }

                else if ((Convert.ToDecimal(age) >= 7) && (Convert.ToDecimal(age) <= 9))
                {
                    group = "Primary";
                }

                else if ((Convert.ToDecimal(age) >= 10) && (Convert.ToDecimal(age) <= 12))
                {
                    group = "Preteens";
                }

                else
                {
                    group = "Adult";
                }

                labels.SetField("Group", group);

                string printername = addin.GetCurrentPrinterName();

                if(addin.IsPrinterOnline(printername))
                {
                    object mydymo;

                    mydymo = addin.Print(Convert.ToInt32(1), false);

                    addin.StartPrintJob();
                    addin.EndPrintJob();
                    addin.Quit();
                }
                else
                {
                    js.showExclamation("Printer is offline", "Help Desk");
                }
                
            }
        }

        private void rbNew_CheckedChanged(object sender, EventArgs e)
        {
            if(rbNew.Checked)
            {
                frmNewKid frm = new frmNewKid();

                if(frm.ShowDialog()== System.Windows.Forms.DialogResult.OK)
                {
                    string qry = "SELECT k.*,g.fldGender as Gender FROM tblKids  k " +
                            "LEFT OUTER JOIN tblGender g ON g.fldID=k.fldGender" +
                            " WHERE k.fldID='" + frm.Tag.ToString() + "'";

                    string q = qry;

                    try
                    {
                        js.ExecuteQuery(q);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error Connection", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    //js.ExecuteQuery(q);
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

                    int age = js.GetAge(dtBirthdate.Value);

                    txtAge.Text = age.ToString();

                    txtAllergies.Text = js.RiD["fldAllergies"].ToString();

                    string status = js.RiD["fldUpdateStatus"].ToString();

                    txtStatus.Text = js.Lookup("fldStatus", "tblStatus", "fldID='" + status + "'");


                    if (age >= 10)
                    {
                        //chkTick.Enabled = true;
                    }
                    else
                    {
                        //chkTick.Enabled = false;
                    }
                    //FOR LOADING PICTURE
                    string picture = js.GetPath() + "/Kids/" + js.RiD["fldPicture"].ToString();
                    string temppic = Application.StartupPath + "/Pictures/tmp/Kids/tmp1.jpg";
                    if (System.IO.File.Exists(picture))
                    {
                        pbImage.Image.Dispose();
                        System.IO.File.Copy(picture, temppic, true);
                        pbImage.Image = System.Drawing.Image.FromFile(temppic);
                    }


                    js.CloseConnection();



                    //For the Address Details
                    q = "SELECT * FROM tblAddress WHERE fldID='" + fldAddressDetails + "'";

                    try
                    {
                        js.ExecuteQuery(q);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error Connection", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    //js.ExecuteQuery(q);
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

                    try
                    {
                        js.ExecuteQuery(q);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error Connection", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    //js.ExecuteQuery(q);
                    js.RiD.Read();

                    if (js.RiD.HasRows)
                    {
                        txtContactNo.Text = js.RiD["fldContactNumber"].ToString();
                    }

                    js.CloseConnection();

                }
                else
                {
                    rbLost.Checked = true;
                }

            }
        }

        private void cboSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSearch.Text = "";
        }

        private void btnñ_Click(object sender, EventArgs e)
        {
            txtSearch.Text += btnñ.Text;
        }

    }
}
