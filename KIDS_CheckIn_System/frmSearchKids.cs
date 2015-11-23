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
    public partial class frmSearchKids : Form
    {

        string fetcherImage = "";
        Connector js = new Connector();
        //Connector2 js2 = new Connector2();
        string fldAddressDetails = "";
        string fldContactDetails = "";
        int fldFetcherID = 0;
        string fldNationality = "";
        string fldKidsID = "";

        string KidsPicture = "";
        
        string [] fetcherID = new string [3];


        public frmSearchKids()
        {
            InitializeComponent();
        }

        private void cboSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
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

            if(txtLastName.Text == "" && txtLastName.Text =="")
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

        private void btnSave_Click(object sender, EventArgs e)
        {

            if(fldKidsID=="")
            {
                MessageBox.Show("Cannot Save Empty Record","Check-In Update", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

           string aID =  SaveUpdateAddressDetails(fldAddressDetails, txtAddress1.Text, txtAddress2.Text, txtCity.Text, txtZipCode.Text);
           string cID = SaveUpdateContactDetails(fldContactDetails, txtContactNo.Text);

           int GenderID =Convert.ToInt32(js.Lookup("fldID", "tblGender", "fldGender='" + cboGender.Text + "'"));
           string NationalityID = js.Lookup("fldID", "tblNationality", "fldNationality='" + cboNationality.Text + "'");

           KidsPicture = Application.StartupPath + "/Pictures/Kids/" + txtFirstName.Text + txtLastName.Text + ".jpg";

            if(System.IO.File.Exists(KidsPicture))
            {
                System.IO.File.Delete(KidsPicture);
            }

            pbImage.Image.Save(Application.StartupPath + "/Pictures/Kids/" + txtFirstName.Text + txtLastName.Text + ".jpg");

            
           

           string q = "UPDATE tblKids SET fldFirstName='" + txtFirstName.Text + "',fldLastName='" + txtLastName.Text + "'," + 
                       "fldMiddleName='" + txtMiddleName.Text + "',fldNickName='" + txtNickName.Text + "'," + 
                       "fldBirthday='" + dtBirthdate.Value.ToShortDateString() + "',fldAddressDetails='" + aID + "'," + 
                       "fldContactDetails='" + cID + "',fldPicture='" + KidsPicture + "',fldGender='" + GenderID + "'," + 
                       "fldNationality='" + NationalityID + "',fldUpdateStatus='1' WHERE fldID='" + fldKidsID + "'";

           js.ExecuteNonQuery(q);


           GetFectchers();
           tabControl1.SelectTab(1);



           for (int i = 0; i <= (fetcherID.Length - 1);i++ )
           {
               string qry = "SELECT f.*,a.*,r.fldRelationship as Relationship,c.fldContactNumber FROM tblFetcher f " + 
                            " LEFT OUTER JOIN tblAddress a ON a.fldID=f.fldAddressDetails " +
                            " LEFT OUTER JOIN tblContactDetails c ON c.fldID = f.fldContactDetails " + 
                            " LEFT OUTER JOIN tblRelationship r ON r.fldID = f.fldRelationship" + 
                            " WHERE f.fldID = '" + fetcherID[i]  + "'";
               js.ExecuteQuery(qry);
               js.RiD.Read();

               if(js.RiD.HasRows)
               {
                 dgvFetchers.Rows.Add(js.RiD["fldFirstName"], js.RiD["fldLastName"], js.RiD["fldMiddleName"],js.RiD["fldEmail"], js.RiD["Relationship"], js.RiD["fldContactNumber"], js.RiD["fldAddress1"], js.RiD["fldAddress2"], js.RiD["fldCity"], js.RiD["fldZipCode"], js.RiD["fldPicture"]);
               }

           }

           fldKidsID = "";

           //MessageBox.Show(fetcherID.Length.ToString());

            //MessageBox.Show("", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

               string FN = dgvFetchers.Rows[i].Cells["FirstName"].Value.ToString();
               string LN = dgvFetchers.Rows[i].Cells["LastName"].Value.ToString();
               string MN = dgvFetchers.Rows[i].Cells["MiddleName"].Value.ToString();
               string Email = dgvFetchers.Rows[i].Cells["Email"].Value.ToString();

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

           cboGender.Text = "";
           cboNationality.Text = "";
           cboRelationship.Text = "";
           lblStudentID.Text = "000000000000";
           dgvFetchers.Rows.Clear();

           pbFetcher.Image.Dispose();
           pbFetcher.Image = Image.FromFile(Application.StartupPath + "/Pictures/download.jpg");
           pbImage.Image.Dispose();
           pbImage.Image = Image.FromFile(Application.StartupPath + "/Pictures/download.jpg");

           tabControl1.SelectTab(0);


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


            if(btnEdit.Tag !=null)
            {
                int dgvIndex = Convert.ToInt32(btnEdit.Tag);

                pbFetcher.Image.Save(Application.StartupPath + "/Pictures/Fetchers/" + txtFetcherFN.Text + txtFetcherLN.Text + ".jpg");
                fetcherImage = Application.StartupPath + "/Pictures/Fetchers/" + txtFetcherFN.Text + txtFetcherLN.Text + ".jpg";

                dgvFetchers.Rows[dgvIndex].Cells["FirstName"].Value = txtFetcherFN.Text;
                dgvFetchers.Rows[dgvIndex].Cells["LastName"].Value = txtFetcherLN.Text;
                dgvFetchers.Rows[dgvIndex].Cells["MiddleName"].Value = txtFetcherMN.Text;
                dgvFetchers.Rows[dgvIndex].Cells["Relationship"].Value = cboRelationship.Text;
                dgvFetchers.Rows[dgvIndex].Cells["ContactNo"].Value = txtFetcherContact.Text;
                dgvFetchers.Rows[dgvIndex].Cells["Address1"].Value = txtFetcherAddr1.Text;
                dgvFetchers.Rows[dgvIndex].Cells["Address2"].Value = txtFetcherAddr2.Text;
                dgvFetchers.Rows[dgvIndex].Cells["City"].Value = txtFetcherCity.Text;
                dgvFetchers.Rows[dgvIndex].Cells["ZipCode"].Value = txtFetcherZip.Text;
                dgvFetchers.Rows[dgvIndex].Cells["Picture"].Value = fetcherImage;
                dgvFetchers.Rows[dgvIndex].Cells["Email"].Value = txtEmail.Text;

                btnEdit.Tag = null;

            }
            else 
            { 

                pbFetcher.Image.Save(Application.StartupPath + "/Pictures/Fetchers/" + txtFetcherFN.Text + txtFetcherLN.Text + ".jpg");
                fetcherImage = Application.StartupPath + "/Pictures/Fetchers/" + txtFetcherFN.Text + txtFetcherLN.Text + ".jpg";

                dgvFetchers.Rows.Add(txtFetcherFN.Text,txtFetcherLN.Text,txtFetcherMN.Text,txtEmail.Text,cboRelationship.Text,txtFetcherContact.Text,txtFetcherAddr1.Text,txtFetcherAddr2.Text,txtFetcherCity.Text,txtFetcherZip.Text,fetcherImage);
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

            pbFetcher.Image.Dispose();
            pbFetcher.Image = System.Drawing.Image.FromFile(Application.StartupPath + "/Pictures/download.jpg");


        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string qry = "";

            if(cboSearch.Text == "First Name")
            {

                 qry = "SELECT k.*,g.fldGender as Gender FROM tblKids  k " + 
                            "LEFT OUTER JOIN tblGender g ON g.fldID=k.fldGender" + 
                            " WHERE fldFirstName='" + txtSearch.Text + "'";
            }

            if(cboSearch.Text == "Last Name")
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
                if(System.IO.File.Exists(picture))
                {
                    pbImage.Image.Dispose();
                    System.IO.File.Copy(picture, temppic,true);
                    pbImage.Image = System.Drawing.Image.FromFile(temppic);
                }


                js.CloseConnection();



                //For the Address Details
                q = "SELECT * FROM tblAddress WHERE fldID='" + fldAddressDetails + "'";
                js.ExecuteQuery(q);
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
                js.ExecuteQuery(q);
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
            LoadGender();
            LoadNationality();
            LoadRelationship();
        }

        private void LoadGender()
        {
            string q = "SELECT * FROM tblGender";

            js.ExecuteQuery(q);
            cboGender.Items.Clear();
            while(js.RiD.Read())
            {
                cboGender.Items.Add(js.RiD["fldGender"]);
            }
            js.CloseConnection();
        }

        private void LoadNationality()
        {
            string q = "SELECT * FROM tblNationality";

            js.ExecuteQuery(q);

            cboNationality.Items.Clear();
            while(js.RiD.Read())
            {
                cboNationality.Items.Add(js.RiD["fldNationality"]);
            }
        }

        private void LoadRelationship()
        {
            string q = "SELECT * FROM tblRelationship";
            js.ExecuteQuery(q);

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
                js.ExecuteNonQuery(qry);
                //js2.ExecuteNonQuery(qry);
                aID = js.Lookup("fldID", "tblAddress", "fldAddress1='" + Address1 + "' AND fldAddress2='" + Address2 + "' AND fldCity='" + City + "' AND fldZipCode='" + ZipCode + "'");


            }
            else
            {
                qry = "UPDATE tblAddress SET fldAddress1='" + Address1 + "',fldAddress2='" + Address2 + "',fldCity='" + City + "',fldZipCode='" + ZipCode + "' WHERE fldID='" + fldAddressID + "'";
                js.ExecuteNonQuery(qry);
                //js2.ExecuteNonQuery(qry);
                aID = fldAddressID;
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
                js.ExecuteNonQuery(qry);
                //js2.ExecuteNonQuery(qry);

                cID = js.Lookup("fldID", "tblContactDetails", "fldContactNumber='" + ContactNo + "'");
            }
            else
            {
                qry = "UPDATE tblContactDetails SET fldContactNumber='" + ContactNo + "' WHERE fldID='" + fldContactID + "'";
                js.ExecuteNonQuery(qry);
                //js.ExecuteNonQuery(qry);
                cID = fldContactID;
            }

            return cID;
        }

        private void GetFectchers()
        {
            string q = "SELECT * FROM tblKidFetcher WHERE fldKidID='" + fldKidsID + "'";
            js.ExecuteQuery(q);
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

            System.IO.File.Copy(dgvFetchers.CurrentRow.Cells["Picture"].Value.ToString(), temppic2, true);

            pbFetcher.Image = System.Drawing.Image.FromFile(temppic2);

            btnEdit.Tag = dgvFetchers.CurrentRow.Index;

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

        

       
    }
}
