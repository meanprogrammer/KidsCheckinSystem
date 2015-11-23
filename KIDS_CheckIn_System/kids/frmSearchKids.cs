using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace KIDS_CheckIn_System
{
    public partial class frmSearchKids : Form
    {
        //WebCam webcam = new WebCam();

        string fetcherImage = "";
        Connector js = new Connector();
        //Connector2 js2 = new Connector2();
        string fldAddressDetails = "";
        string fldContactDetails = "";
        int fldFetcherID = 0;
        string fldNationality = "";
        string fldKidsID = "";

        bool boolFetcher = false;
        bool boolSave = false;

        string timestamp = "";

        string KidsPicture = "";
        
        string [] fetcherID = new string [3];


        public frmSearchKids()
        {
            InitializeComponent();
        }

        private void cboSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSearch.Text = "";

            if(cboSearch.Text=="Birth Day")
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

        private void btnBrowse_Click(object sender, EventArgs e)
        {

            if(txtFirstName.Text == "" && txtLastName.Text =="")
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

        private void btnBrowse2_Click(object sender, EventArgs e)
        {
            if (txtFetcherFN.Text == "" && txtFetcherLN.Text == "")
            {
                MessageBox.Show("Fetcher's First Name and Last Name Required", "Importing Picture", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            openFileDialog2.FilterIndex = 1;
            openFileDialog2.Filter = "JPEG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif|PNG Files (*.png)|*.png";

            if (openFileDialog2.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                var filename = openFileDialog2.FileName;
                //System.IO.File.Copy(filename, Application.StartupPath + "/Pictures/Fetchers/" + txtFetcherFN.Text + txtFetcherLN.Text + ".jpg", true);
                //pbFetcher.Image = System.Drawing.Image.FromFile(Application.StartupPath + "/Pictures/Fetchers/" + txtFetcherFN.Text + txtFetcherLN.Text + ".jpg");
                pbFetcher.Image = System.Drawing.Image.FromFile(filename);
                openFileDialog2.Dispose();

            }
        }

        private string EscString(string Str)
        {
            string str = Str.Replace("'", "''");

            return str;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int hasCompanion = 0;
            if(Convert.ToInt32(txtAge.Text)>12)
            {
                js.showExclamation("Cannot update kids more than 12 years Old", "Update Information");
                return;
            }


            if(fldKidsID=="")
            {
                MessageBox.Show("Cannot Save Empty Record","Check-In Update", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (Convert.ToInt32(txtAge.Text) >= 10)
            {
                if(js.showQuestion("By click YES, I understand fully that the Preteens class teachers and administrators will let my child out without my presence. They will not be held liable for any untoward incidences after my child has left the Preteens room. Should my child be found loitering during services, I am to be paged immediately.","Update")== System.Windows.Forms.DialogResult.Yes)
                {
                    chkTick.Checked = true;
                }
                else
                {
                    chkTick.Checked = false;
                }
            }

            if(chkCompanion.Checked)
            {
                hasCompanion = 1;
            }
            else
            {
                hasCompanion = 0;
            }

            string aID = "";//SaveUpdateAddressDetails(fldAddressDetails, txtAddress1.Text, txtAddress2.Text, txtCity.Text, txtZipCode.Text);
            string cID = "";// SaveUpdateContactDetails(fldContactDetails, txtContactNo.Text);

           int GenderID =Convert.ToInt32(js.Lookup("fldID", "tblGender", "fldGender='" + cboGender.Text + "'"));
           //string NationalityID = js.Lookup("fldID", "tblNationality", "fldNationality='" + cboNationality.Text + "'");


           string strPath = GetPath() + "/Kids/";

           timestamp = DateTime.Now.ToString("hhmmss");
           KidsPicture = txtFirstName.Text.Replace("'","''") + txtLastName.Text.Replace("'","''") + timestamp + ".jpg";

           string fullfilename = strPath + KidsPicture;

            if(System.IO.File.Exists(fullfilename))
            {
                System.IO.File.Delete(fullfilename);
            }

            pbImage.Image.Save(fullfilename);

            string update = js.Lookup("fldUpdateStatus", "tblKids", "fldID='" + fldKidsID + "'");
            if (update == "")
            {
                update = "0";
            }
            int fldUpdateStatus = Convert.ToInt32(update);

            string q = "";

            if(fldUpdateStatus >0)
            {


                q = "UPDATE tblKids SET fldFirstName='" + EscString(txtFirstName.Text) + "',fldLastName='" + EscString(txtLastName.Text) + "'," +
                      "fldMiddleName='" + EscString(txtMiddleName.Text) + "',fldNickName='" + EscString(txtNickName.Text) + "'," +
                      "fldBirthday='" + dtBirthdate.Value.ToShortDateString() + "',fldAddressDetails='" + aID + "'," +
                      "fldContactDetails='" + cID + "',fldPicture='" + KidsPicture + "',fldGender='" + GenderID + "'," +
                      "fldNationality='" + EscString(cboNationality.Text) + "',fldAllergies='" + EscString(txtAllergies.Text) + "',fldRemarks='" + EscString(txtRemarks.Text) + "',fldHasCompanion='" + hasCompanion + "'";

                //if(chkTick.Checked)
                //{
                //    q += ",fldClaimStub=0, fldDateTime='" + DateTime.Now.ToString() + "'";
                   
                //}
                //else
                //{
                //    q += ",fldClaimStub=1, fldDateTime='" + DateTime.Now.ToString() + "'";
                //}
                q += " WHERE fldID='" + fldKidsID + "'";

            }
            else
            {

                q = "UPDATE tblKids SET fldFirstName='" + EscString(txtFirstName.Text) + "',fldLastName='" + EscString(txtLastName.Text) + "'," +
                               "fldMiddleName='" + EscString(txtMiddleName.Text) + "',fldNickName='" + EscString(txtNickName.Text) + "'," + 
                               "fldBirthday='" + dtBirthdate.Value.ToShortDateString() + "',fldAddressDetails='" + aID + "'," + 
                               "fldContactDetails='" + cID + "',fldPicture='" + KidsPicture + "',fldGender='" + GenderID + "'," +
                               "fldNationality='" + EscString(cboNationality.Text) + "',fldUpdateStatus='1',fldAllergies='" + EscString(txtAllergies.Text) + "',fldRemarks='" + EscString(txtRemarks.Text) + "',fldHasCompanion='" + hasCompanion + "'";

                    if (chkTick.Checked)
                    {
                        q += ",fldClaimStub=0, fldDateTime='" + DateTime.Now.ToString() + "'";

                    }
                    else
                    {
                        q += ",fldClaimStub=1, fldDateTime='" + DateTime.Now.ToString() + "'";
                    }
                    q += " WHERE fldID='" + fldKidsID + "'";
            }
           


            

           js.ExecuteNonQuery(q);

           boolSave = true;

          if(boolFetcher==false)
          {
            GetFectchers();
           

            dgvFetchers.Rows.Clear();

            for (int i = 0; i <= (fetcherID.Length - 1); i++)
            {
                string qry = "SELECT f.*,a.*,r.fldRelationship as Relationship,c.fldContactNumber FROM tblFetcher f " +
                             " LEFT OUTER JOIN tblAddress a ON a.fldID=f.fldAddressDetails " +
                             " LEFT OUTER JOIN tblContactDetails c ON c.fldID = f.fldContactDetails " +
                             " LEFT OUTER JOIN tblRelationship r ON r.fldID = f.fldRelationship" +
                             " WHERE f.fldID = '" + fetcherID[i] + "'";
                 js.ExecuteQuery(qry);
                 js.RiD.Read();

                 if (js.RiD.HasRows)
                 {
                     dgvFetchers.Rows.Add(js.RiD["fldFirstName"], js.RiD["fldLastName"], js.RiD["fldMiddleName"], js.RiD["fldEmail"], js.RiD["Relationship"], js.RiD["fldContactNumber"], js.RiD["fldAddress1"], js.RiD["fldAddress2"], js.RiD["fldCity"], js.RiD["fldZipCode"], js.RiD["fldPicture"].ToString().Replace("'","''"));
                 }

            }
          }

          tabControl1.SelectTab(1);

               

            


            //MessageBox.Show("", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private string GetPath()
        {
            string strPath = "";

            strPath = AccessRegistryTool.ReadValue("PicPath");

            return strPath;
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {

            if (dgvFetchers.Rows.Count == 0)
            {
                MessageBox.Show("No record to save", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (!chkAgree.Checked)
            {
                MessageBox.Show("You have to check the I agree on the Terms and Condition", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(dgvFetchers.Rows.Count>3)
            {
                js.showExclamation("The fetchers are more than 3 cannot proceed to save");
                return;
            }

            

          string kidid = js.Lookup("fldID", "tblKids", "fldStudentID='" + lblStudentID.Text + "'");

          js.ExecuteNonQuery("DELETE FROM tblKidFetcher WHERE fldKidID='" + kidid + "'");

           for(int i=0;i<= (dgvFetchers.Rows.Count -1);i++)
           {
               string Addr1 = dgvFetchers.Rows[i].Cells["Address1"].Value.ToString();
               string Addr2 = dgvFetchers.Rows[i].Cells["Address2"].Value.ToString();
               string city = dgvFetchers.Rows[i].Cells["City"].Value.ToString();
               string ZipCode = dgvFetchers.Rows[i].Cells["ZipCode"].Value.ToString();

              // MessageBox.Show(dgvFetchers.Rows[i].Cells["ZipCode"].Value.ToString());

               //return;

               string addrID = js.Lookup("fldID", "tblAddress", "fldAddress1='" + Addr1 + "' AND fldAddress2='" + Addr2 + "' AND fldCity='" + city + "' AND fldZipCode='" + ZipCode + "'");

               addrID = SaveUpdateAddressDetails(addrID, Addr1, Addr2, city, ZipCode);

               string contactno = dgvFetchers.Rows[i].Cells["ContactNo"].Value.ToString();
               string cID = js.Lookup("fldID", "tblContactDetails", "fldContactNumber='" + contactno + "'");

               cID = SaveUpdateContactDetails(cID, contactno);

               string rID = js.Lookup("fldID", "tblRelationship", "fldRelationship='" + dgvFetchers.Rows[i].Cells["Relationship"].Value.ToString() + "'");

               string picture = dgvFetchers.Rows[i].Cells["Picture"].Value.ToString();


               string q = "";

               string FN = EscString(dgvFetchers.Rows[i].Cells["FirstName"].Value.ToString());
               string LN = EscString(dgvFetchers.Rows[i].Cells["LastName"].Value.ToString());
               string MN = EscString(dgvFetchers.Rows[i].Cells["MiddleName"].Value.ToString());
               string Email = EscString(dgvFetchers.Rows[i].Cells["Email"].Value.ToString());

               string fID = js.Lookup("fldID", "tblFetcher", "fldFirstName='" + FN + "' AND fldLastName='" + LN + "' AND fldMiddleName='" + MN + "'");

               //js.ExecuteNonQuery("DELETE FROM tblFetcher WHERE fldID='" + fID + "'");

               if (fID != "")
               {

                   q = "UPDATE tblFetcher SET fldFirstName='" + FN + "',fldLastName='" + LN  + "',fldMiddleName='" + MN + "',fldAddressDetails='" + addrID + "', fldContactDetails='" + cID  + "',fldEmail='" + Email  + "',fldRelationship='" + rID + "',fldPicture='" + picture + "' WHERE fldID='" + fID + "'";

                  
               }
               else
               {
                   q = "INSERT INTO tblFetcher(fldFirstName,fldLastName,fldMiddleName,fldAddressDetails,fldContactDetails,fldRelationship,fldPicture,fldEmail) VALUES('" + FN +
                        "','" + LN + "','" + MN + "','" + addrID + "','" + cID + "','" + rID + "','" + picture + "','" + Email + "')";
               }

               js.ExecuteNonQuery(q);
               //js2.ExecuteNonQuery(q);

               fID = js.Lookup("fldID", "tblFetcher", "fldFirstName='" + FN + "' AND fldLastName='" + LN + "' AND fldMiddleName='" + MN + "'");

               if(fID!="")
               {
                   string qry = "INSERT INTO tblKidFetcher(fldKidID,fldFetcherID) VALUES('" + kidid + "','" + fID + "')";
                   js.ExecuteNonQuery(qry);
                   //.ExecuteNonQuery(qry);
               }

               

           }

           MessageBox.Show("Kid & Fetchers Successfully Updated","", MessageBoxButtons.OK, MessageBoxIcon.Information);

            if(MessageBox.Show("Do you want to update another sibling?","", MessageBoxButtons.YesNo, MessageBoxIcon.Question)== System.Windows.Forms.DialogResult.Yes)
            {
                tabControl1.SelectTab(0);
                boolFetcher = true;
                btnSearch_Click(null, null);
                return;
            }
            else
            {
                boolFetcher = false;
            }

            boolSave = false;
           txtAddress1.Text = "";
           txtAddress2.Text = "";
           txtChurch.Text = "";
           txtCity.Text = "";
           txtContactNo.Text = "";
           txtEmail.Text = "";
           txtFirstName.Text = "";
           txtLastName.Text = "";
           txtMiddleName.Text = "";
           txtNickName.Text = "";
           txtPoints.Text = "";
           txtSearch.Text = "";
           txtZipCode.Text = "";
           txtEmail.Text = "";
           txtAge.Text = "";
           txtAllergies.Text = "";
           txtRemarks.Text = "";

           cboGender.Text = "";
           cboNationality.Text = "";
           cboRelationship.Text = "";
           lblStudentID.Text = "000000000000";
           dgvFetchers.Rows.Clear();
           

           chkAgree.Checked = false;
           chkCompanion.Checked = false;

           pbFetcher.Image.Dispose();
           pbFetcher.Image = Image.FromFile(Application.StartupPath + "/Pictures/download.jpg");
           pbImage.Image.Dispose();
           pbImage.Image = Image.FromFile(Application.StartupPath + "/Pictures/download.jpg");

           tabControl1.SelectTab(0);

           fetcherID = new string[3];

           string tempic = Application.StartupPath + "/Pictures/tmp/Kids/tmp1.jpg";
           try { File.Delete(tempic); }
           catch (Exception ex) { };
           

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(0);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            if (txtFetcherFN.Text == "")
            {
                MessageBox.Show("Fetcher First Name Required!","", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if(txtFetcherLN.Text =="")
            {
                MessageBox.Show("Fetcher Last Name Required!", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if(txtFetcherContact.Text =="")
            {
                MessageBox.Show("Fetcher Contact No Required!", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            string path = GetPath() + "/Fetchers/";
            timestamp = DateTime.Now.ToString("hhmmss");
            string filename = txtFetcherFN.Text.Replace("'","''") + txtFetcherLN.Text.Replace("'","''") + timestamp +  ".jpg";

            string fullpath = path + filename;

            if(btnEdit.Tag !=null)
            {
                int dgvIndex = Convert.ToInt32(btnEdit.Tag);

               

                pbFetcher.Image.Save(fullpath);
                //fetcherImage = Application.StartupPath + "/Pictures/Fetchers/" + txtFetcherFN.Text + txtFetcherLN.Text + ".jpg";

                dgvFetchers.Rows[dgvIndex].Cells["FirstName"].Value = txtFetcherFN.Text;
                dgvFetchers.Rows[dgvIndex].Cells["LastName"].Value = txtFetcherLN.Text;
                dgvFetchers.Rows[dgvIndex].Cells["MiddleName"].Value = txtFetcherMN.Text;
                dgvFetchers.Rows[dgvIndex].Cells["Relationship"].Value = cboRelationship.Text;
                dgvFetchers.Rows[dgvIndex].Cells["ContactNo"].Value = txtFetcherContact.Text;
                dgvFetchers.Rows[dgvIndex].Cells["Address1"].Value = txtFetcherAddr1.Text;
                dgvFetchers.Rows[dgvIndex].Cells["Address2"].Value = txtFetcherAddr2.Text;
                dgvFetchers.Rows[dgvIndex].Cells["City"].Value = txtFetcherCity.Text;
                dgvFetchers.Rows[dgvIndex].Cells["ZipCode"].Value = txtFetcherZip.Text;
                dgvFetchers.Rows[dgvIndex].Cells["Picture"].Value = filename;
                dgvFetchers.Rows[dgvIndex].Cells["Email"].Value = txtEmail.Text;

                btnEdit.Tag = null;
                btnAdd.Text = "Add";

            }
            else 
            { 

                pbFetcher.Image.Save(fullpath);
                //fetcherImage = Application.StartupPath + "/Pictures/Fetchers/" + txtFetcherFN.Text + txtFetcherLN.Text + ".jpg";

                dgvFetchers.Rows.Add(txtFetcherFN.Text,txtFetcherLN.Text,txtFetcherMN.Text,txtEmail.Text,cboRelationship.Text,txtFetcherContact.Text,txtFetcherAddr1.Text,txtFetcherAddr2.Text,txtFetcherCity.Text,txtFetcherZip.Text,filename);
            }

            txtFetcherFN.Text = "";
            txtFetcherLN.Text = "";
            txtFetcherMN.Text = "";
            cboRelationship.Text = "";
            txtFetcherContact.Text = "";
            txtFetcherAddr1.Text = "";
            txtFetcherAddr2.Text = "";
            txtFetcherCity.Text = "";
            txtFetcherZip.Text = "";
            txtEmail.Text = "";

            pbFetcher.Image.Dispose();
            pbFetcher.Image = System.Drawing.Image.FromFile(Application.StartupPath + "/Pictures/download.jpg");


        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string qry = "";

            if (txtSearch.Text == "")
            {
                js.showExclamation("Cannot generate result with an empty field");
                return;
            }


            if(cboSearch.Text == "First Name")
            {

                 qry = "SELECT k.*,g.fldGender as Gender FROM tblKids  k " + 
                            "LEFT OUTER JOIN tblGender g ON g.fldID=k.fldGender" + 
                            " WHERE fldFirstName='" + txtSearch.Text.Replace("'","''") + "' ORDER BY fldLastName";
            }

            if(cboSearch.Text == "Last Name")
            {

                qry = "SELECT k.*,g.fldGender as Gender FROM tblKids  k " +
                             "LEFT OUTER JOIN tblGender g ON g.fldID=k.fldGender" +
                             " WHERE fldLastName='" + txtSearch.Text.Replace("'", "''") + "' ORDER BY fldFirstName";
            }


            if (cboSearch.Text == "Nick Name")
            {

                qry = "SELECT k.*,g.fldGender as Gender FROM tblKids  k " +
                             "LEFT OUTER JOIN tblGender g ON g.fldID=k.fldGender" +
                             " WHERE fldNickName='" + txtSearch.Text.Replace("'", "''") + "' ORDER BY fldFirstName,fldLastName";
            }


            if (cboSearch.Text == "Birth Day")
            {

                qry = "SELECT k.*,g.fldGender as Gender FROM tblKids  k " +
                             "LEFT OUTER JOIN tblGender g ON g.fldID=k.fldGender" +
                             " WHERE fldBirthday='" + dtSearch.Value.ToShortDateString() + "' ORDER BY fldFirstName, fldLastName";
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
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error Connection", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                //js.ExecuteQuery(q);
                js.RiD.Read();
                fetcherID = new string[3];
                pbImage.Image = Image.FromFile(Application.StartupPath + "/Pictures/download.jpg");

                lblStudentID.Text = js.RiD["fldStudentID"].ToString();
                txtFirstName.Text = js.RiD["fldFirstName"].ToString().Replace("''", "'");
                txtLastName.Text = js.RiD["fldLastName"].ToString().Replace("''", "'");
                txtMiddleName.Text = js.RiD["fldMiddleName"].ToString();
                txtNickName.Text = js.RiD["fldNickName"].ToString();


                DateTime bdate;

                if (DateTime.TryParse(js.RiD["fldBirthday"].ToString(), out bdate))
                {
                    dtBirthdate.Value = bdate;
                }
                
                cboGender.Text = js.RiD["Gender"].ToString();
                txtChurch.Text = js.Lookup("fldChurch", "tblChurch", "fldID='" + js.RiD["fldChurch"].ToString() + "'");
                fldAddressDetails = js.RiD["fldAddressDetails"].ToString();
                fldContactDetails = js.RiD["fldContactDetails"].ToString();
                fldNationality = js.RiD["fldNationality"].ToString();
                cboNationality.Text = fldNationality;//js.Lookup("fldNationality", "tblNationality", "fldID='" + js.RiD["fldNationality"].ToString() + "'");
                txtPoints.Text = js.RiD["fldPoints"].ToString();
                fldKidsID = js.RiD["fldID"].ToString();

                int age = js.GetAge(dtBirthdate.Value);

                txtAge.Text = age.ToString();

                txtAllergies.Text = js.RiD["fldAllergies"].ToString();

                string status = js.RiD["fldUpdateStatus"].ToString();

                txtStatus.Text = js.Lookup("fldStatus","tblStatus","fldID='" + status + "'");

                txtRemarks.Text = js.RiD["fldRemarks"].ToString();

                string group = "";

                if(age>=10)
                {
                    chkTick.Enabled = false;
                }
                else
                {
                    chkTick.Enabled = false;
                }

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

                txtGroup.Text = group;

                //FOR LOADING PICTURE
                string picture = GetPath() + "/Kids/" +  js.RiD["fldPicture"].ToString();
                string temppic = Application.StartupPath + "/Pictures/tmp/Kids/tmp1.jpg";

                //try { System.IO.File.Delete(temppic); }
                //catch (Exception ex) { }

                if(System.IO.File.Exists(picture))
                {
                    pbImage.Image.Dispose();
                    ///System.IO.File.Copy(picture, temppic,true);
                    pbImage.Image = System.Drawing.Image.FromFile(picture);
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
                
                if(js.RiD.HasRows)
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
            if (frm.ShowDialog()== System.Windows.Forms.DialogResult.OK)
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
                fetcherID = new string[3]; //destroy string
                pbImage.Image = Image.FromFile(Application.StartupPath + "/Pictures/download.jpg");


                lblStudentID.Text = js.RiD["fldStudentID"].ToString();
                txtFirstName.Text = js.RiD["fldFirstName"].ToString().Replace("''", "'");
                txtLastName.Text = js.RiD["fldLastName"].ToString().Replace("''", "'");
                txtMiddleName.Text = js.RiD["fldMiddleName"].ToString();
                txtNickName.Text = js.RiD["fldNickName"].ToString();
                DateTime bdate;

                if (DateTime.TryParse(js.RiD["fldBirthday"].ToString(), out bdate))
                {
                    dtBirthdate.Value = bdate;
                }

                cboGender.Text = js.RiD["Gender"].ToString();
                txtChurch.Text = js.Lookup("fldChurch", "tblChurch", "fldID='" + js.RiD["fldChurch"].ToString() + "'");
                fldAddressDetails = js.RiD["fldAddressDetails"].ToString();
                fldContactDetails = js.RiD["fldContactDetails"].ToString();
                fldNationality = js.RiD["fldNationality"].ToString();
                cboNationality.Text = fldNationality;//js.Lookup("fldNationality", "tblNationality", "fldID='" + js.RiD["fldNationality"].ToString() + "'");
                txtPoints.Text = js.RiD["fldPoints"].ToString();
                fldKidsID = js.RiD["fldID"].ToString();

                int age = js.GetAge(dtBirthdate.Value);
                string group = "";

                txtAge.Text = age.ToString();

                txtAllergies.Text = js.RiD["fldAllergies"].ToString();

                string status = js.RiD["fldUpdateStatus"].ToString();

                txtStatus.Text = js.Lookup("fldStatus", "tblStatus", "fldID='" + status + "'");

                txtRemarks.Text = js.RiD["fldRemarks"].ToString();

                if (age >= 10)
                {
                    chkTick.Visible = false;
                }
                else
                {
                    chkTick.Visible = false;
                }

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

                txtGroup.Text = group;



                //FOR LOADING PICTURE
                string picture = GetPath() + "/Kids/" + js.RiD["fldPicture"].ToString().Replace("'","''");
                string temppic = Application.StartupPath + "/Pictures/tmp/Kids/tmp1.jpg";

                //try { System.IO.File.Delete(temppic); }
                //catch (Exception ex) { }

                if (System.IO.File.Exists(picture))
                {
                    //pbImage.Dispose();
                    pbImage.Image.Dispose();
                    //System.IO.File.Copy(picture, temppic, true);
                    pbImage.Image = System.Drawing.Image.FromFile(picture);
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
                
                if(js.RiD.HasRows)
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



        private void frmSearchKids_Load(object sender, EventArgs e)
        {
            timestamp = DateTime.Now.ToString("hhmmss");
            LoadGender();
            LoadRelationship();
            cboSearch.Text = "Last Name";
        }

        private void LoadGender()
        {
            string q = "SELECT * FROM tblGender";

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
            cboGender.Items.Clear();
            while(js.RiD.Read())
            {
                cboGender.Items.Add(js.RiD["fldGender"]);
            }
            js.CloseConnection();
        }

        

        private void LoadRelationship()
        {
            string q = "SELECT * FROM tblRelationship";

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

            cboRelationship.Items.Clear();

            while(js.RiD.Read())
            {
                cboRelationship.Items.Add(js.RiD["fldRelationship"]);
            }
        }

        private string SaveUpdateAddressDetails(string fldAddressID,string Address1,string Address2,string City,string ZipCode)
        {
            //Connector2 js2 = new Connector2();
            string qry = "";
            string aID = "";
            if(fldAddressID=="")
            {
                qry = "INSERT INTO tblAddress(fldAddress1,fldAddress2,fldCity,fldZipCode) VALUES('" + Address1 + "','" + Address2 + "','" + City + "','" + ZipCode +  "')";

                try
                {
                    js.ExecuteQuery(qry);
                    aID = js.Lookup("fldID", "tblAddress", "fldAddress1='" + Address1 + "' AND fldAddress2='" + Address2 + "' AND fldCity='" + City + "' AND fldZipCode='" + ZipCode + "'");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error Connection", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    
                }

                //js.ExecuteNonQuery(qry);
                //js2.ExecuteNonQuery(qry);
                


            }
            else
            {
                qry = "UPDATE tblAddress SET fldAddress1='" + Address1 + "',fldAddress2='" + Address2 + "',fldCity='" + City + "',fldZipCode='" + ZipCode + "' WHERE fldID='" + fldAddressID + "'";

                try
                {
                    js.ExecuteQuery(qry);
                    aID = fldAddressID;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error Connection", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

                //js.ExecuteNonQuery(qry);
                //js2.ExecuteNonQuery(qry);
                
            }

            return aID;

        }

        private string SaveUpdateContactDetails(string fldContactID,string ContactNo)
        {
            //Connector2 js2 = new Connector2();
            string qry = "";
            string cID = "";
            if(fldContactID=="")
            {
                qry = "INSERT INTO tblContactDetails(fldContactNumber) VALUES('" + ContactNo + "')";

                try
                {
                    js.ExecuteQuery(qry);
                    cID = js.Lookup("fldID", "tblContactDetails", "fldContactNumber='" + ContactNo + "'");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error Connection", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }


                //js.ExecuteNonQuery(qry);
                //js2.ExecuteNonQuery(qry);

                
            }
            else
            {
                qry = "UPDATE tblContactDetails SET fldContactNumber='" + ContactNo + "' WHERE fldID='" + fldContactID + "'";

                try
                {
                    js.ExecuteQuery(qry);
                    cID = fldContactID;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error Connection", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

                //js.ExecuteNonQuery(qry);
                //js.ExecuteNonQuery(qry);
                //cID = fldContactID;
            }

            return cID;
        }

        private void GetFectchers()
        {
            string q = "SELECT * FROM tblKidFetcher WHERE fldKidID='" + fldKidsID + "'";

            try
            {
                js.ExecuteQuery(q);
            }
            catch
            {

            }

           
            int i = 0;
            while(js.RiD.Read())
            {
                fetcherID[i] = js.RiD["fldFetcherID"].ToString();
                i += 1;
            }

            js.CloseConnection();
        }

        private void tabControl1_TabIndexChanged(object sender, EventArgs e)
        {
            if(tabControl1.SelectedIndex==1)
            {
                MessageBox.Show(Convert.ToString(fetcherID.Length));
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if(dgvFetchers.Rows.Count==0)
            {
                MessageBox.Show("No record to edit","", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            txtFetcherFN.Text = dgvFetchers.CurrentRow.Cells["FirstName"].Value.ToString();
            txtFetcherLN.Text = dgvFetchers.CurrentRow.Cells["LastName"].Value.ToString();
            txtFetcherMN.Text = dgvFetchers.CurrentRow.Cells["MiddleName"].Value.ToString();
            cboRelationship.Text = dgvFetchers.CurrentRow.Cells["Relationship"].Value.ToString();
            txtFetcherContact.Text = dgvFetchers.CurrentRow.Cells["ContactNo"].Value.ToString();
            txtFetcherAddr1.Text = dgvFetchers.CurrentRow.Cells["Address1"].Value.ToString();
            txtFetcherAddr2.Text = dgvFetchers.CurrentRow.Cells["Address2"].Value.ToString();
            txtFetcherCity.Text = dgvFetchers.CurrentRow.Cells["City"].Value.ToString();
            txtFetcherZip.Text = dgvFetchers.CurrentRow.Cells["ZipCode"].Value.ToString();
            txtEmail.Text = dgvFetchers.CurrentRow.Cells["Email"].Value.ToString();

            pbFetcher.Image.Dispose();

            string temppic2 = Application.StartupPath + "/Pictures/tmp/Fetchers/tmp1.jpg";

            if(System.IO.File.Exists(temppic2))
            {
                System.IO.File.Delete(temppic2);
            }
            string path = GetPath() + "/Fetchers/" + dgvFetchers.CurrentRow.Cells["Picture"].Value.ToString();

            if (System.IO.File.Exists(path))
            {
                System.IO.File.Copy(path, temppic2, true);
                pbFetcher.Image = System.Drawing.Image.FromFile(temppic2);
            }

            

           

            btnEdit.Tag = dgvFetchers.CurrentRow.Index;
            btnAdd.Text = "Save";

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvFetchers.Rows.Count == 0)
            {
                MessageBox.Show("No record to delete", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            dgvFetchers.Rows.Remove(dgvFetchers.CurrentRow);
        }

        private void btnPicture_Click(object sender, EventArgs e)
        {
            //taking picture
            frmTakePicture frm = new frmTakePicture();

            if(frm.ShowDialog()== System.Windows.Forms.DialogResult.OK)
            {
                pbImage.Image = (Image)frm.Tag;
            }

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void label33_Click(object sender, EventArgs e)
        {

        }

        private void chkAgree_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnñ_Click(object sender, EventArgs e)
        {

            txtSearch.Text += "ñ";
        }

        private void btnPicture2_Click(object sender, EventArgs e)
        {
            frmTakePicture frm = new frmTakePicture();
            
            if(frm.ShowDialog()== System.Windows.Forms.DialogResult.OK)
            {
                pbFetcher.Image = (Image)frm.Tag;
            }
            
        }

        private void tabPage2_Click_1(object sender, EventArgs e)
        {
            if(boolSave == false)
            {
                tabControl1.SelectTab(0);
                js.showExclamation("Cannot proceed here without saving the kids details","Kids Check-In System");
                return;
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(tabControl1.SelectedIndex == 1)
            {
                tabPage2_Click_1(null, null);
            }
        }

        private void txtFetcherContact_TextChanged(object sender, EventArgs e)
        {
            float n;
            if(!float.TryParse(txtFetcherContact.Text, out n))
            {
                txtFetcherContact.Text = "";
            }
        }

        private void frmSearchKids_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmSystemOptions frm = new frmSystemOptions();
            frm.Show();
            this.Hide();
        }

        private void txtFetcherZip_TextChanged(object sender, EventArgs e)
        {
            int n;
            if (!int.TryParse(txtFetcherZip.Text, out n))
            {
                txtFetcherZip.Text = "";

            }
        }

        private void dtBirthdate_ValueChanged(object sender, EventArgs e)
        {
            txtAge.Text = js.GetAge(dtBirthdate.Value).ToString();
        }

        

       
    }
}
