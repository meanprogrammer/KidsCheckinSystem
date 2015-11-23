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
    public partial class frmNewKid : Form
    {
        Connector js = new Connector();
        public frmNewKid()
        {
            InitializeComponent();
        }

        private void btnTaKe_Click(object sender, EventArgs e)
        {
            frmTakePicture frm = new frmTakePicture();

            if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                pbKid.Image = (Image)frm.Tag;
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.Filter = "JPEG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif|PNG Files (*.png)|*.png";

            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                var filename = openFileDialog1.FileName;

                //System.IO.File.Copy(filename, Application.StartupPath + "/Pictures/Kids/" + txtFirstName.Text + txtLastName.Text + ".jpg", true);
                //pbImage.Image = System.Drawing.Image.FromFile(Application.StartupPath + "/Pictures/Kids/" + txtFirstName.Text + txtLastName.Text + ".jpg");
                pbKid.Image = System.Drawing.Image.FromFile(filename);
                openFileDialog1.Dispose();

            }
        }

        private void btnBrowse2_Click(object sender, EventArgs e)
        {
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.Filter = "JPEG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif|PNG Files (*.png)|*.png";

            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                var filename = openFileDialog1.FileName;

                //System.IO.File.Copy(filename, Application.StartupPath + "/Pictures/Kids/" + txtFirstName.Text + txtLastName.Text + ".jpg", true);
                //pbImage.Image = System.Drawing.Image.FromFile(Application.StartupPath + "/Pictures/Kids/" + txtFirstName.Text + txtLastName.Text + ".jpg");
                pbFetcher.Image = System.Drawing.Image.FromFile(filename);
                openFileDialog1.Dispose();

            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void btnTake2_Click(object sender, EventArgs e)
        {
            frmTakePicture frm = new frmTakePicture();

            if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                pbFetcher.Image = (Image)frm.Tag;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string rel = "";
            string cID = "";
            string contactno = "";
            int gen = 0;

            if(txtFirstName.Text=="")
            {
                js.showExclamation("Kid's FirstName is required");
                txtFirstName.Focus();
                return;
            }

            if(txtLastName.Text =="")
            {
                js.showExclamation("Kid's LastName is required");
                txtLastName.Focus();
                return;
            }

            if(txtNickName.Text =="")
            {
                js.showExclamation("Kid's NickName is required. It will appear on temporay ID");
                txtNickName.Focus();
                return;
            }

            if (Convert.ToInt32(lblAge.Text) > 12)
            {
                js.showExclamation("Cannot Save age above 12");
                return;
            }

            if(!chkNG.Checked)
            {
                if (txtFirstName2.Text == "")
                {
                    js.showExclamation("Fetcher's FirstName is required");
                    txtFirstName2.Focus();
                    return;
                }

                if (txtLastName2.Text == "")
                {
                    js.showExclamation("Fetcher's LastName is required");
                    txtLastName2.Focus();
                    return;
                }

                if (cboRelationship.Text == "")
                {
                    js.showExclamation("Relationship required");
                    cboRelationship.Focus();
                    return;
                }
                else
                {
                    rel = js.Lookup("fldID", "tblRelationship", "fldRelationship='" + cboRelationship.Text + "'");
                }

                if (txtContactNo.Text == "")
                {
                    js.showExclamation("Contact No. Required");
                    txtContactNo.Focus();
                    return;
                }
                else
                {
                    contactno = txtContactNo.Text;
                    cID = js.Lookup("fldID", "tblContactDetails", "fldContactNumber='" + contactno + "'");
                    cID = SaveUpdateContactDetails(cID, contactno);
                }

                if(!chkNA.Checked)
                {
                    if(txtEmail.Text=="")
                    {
                        js.showExclamation("Email Address Required");
                        txtEmail.Focus();
                        return;
                    }
                }
            }

            

            

           if(cboGender.Text =="")
           {
               js.showExclamation("Gender Required");
               cboGender.Focus();
               return;
           }
           else
           {
               gen = Convert.ToInt32(js.Lookup("fldID","tblGender","fldGender='" + cboGender.Text + "'"));
           }

           string query = "SELECT * FROM tblKids WHERE fldLastName='" + txtLastName.Text.Replace("'","''") + "' AND fldBirthday='" + dtBDay.Value.ToShortDateString() + "'";

           js.ExecuteQuery(query);

            if(js.RiD.HasRows)
            {
                js.RiD.Read();
                frmVerifier frm = new frmVerifier();

                frm.Tag = js.RiD["fldStudentID"];
                string id = "" + js.RiD["fldID"];

                if(frm.ShowDialog() == System.Windows.Forms.DialogResult.Yes)
                {
                    this.Tag = id;
                    DialogResult = System.Windows.Forms.DialogResult.Yes;
                    this.Close();
                    return;
                }
            }

            js.CloseConnection();



            Kids kid = new Kids();

            kid.setFirstName(txtFirstName.Text);
            kid.setLastName(txtLastName.Text);
            kid.setNickName(txtNickName.Text);
            kid.setBirthday(dtBDay.Value);
            kid.GetChurchID();
            kid.GenerateStudentID();
            kid.setImage(pbKid.Image);
            kid.setGender(gen);
            kid.setAllergies(txtAllergies.Text);
            

            string sID = kid.SaveInfo();

            string sql = "UPDATE tblKids SET fldHasVictoryGroup='" + chkVG.Checked + "', fldVGL='" + txtVGL.Text  + "',fldOne2One='" + chkOne2One.Checked + "', fldVW='" + chkVW.Checked + "' WHERE fldID='" + sID + "'";
            js.ExecuteNonQuery(sql);

            sID = kid.SaveInfo(Properties.Settings.Default.Server);
            sql = "UPDATE tblKids SET fldHasVictoryGroup='" + chkVG.Checked + "', fldVGL='" + txtVGL.Text + "',fldOne2One='" + chkOne2One.Checked + "', fldVW='" + chkVW.Checked + "' WHERE fldID='" + sID + "'";
            js.ExecuteNonQuery(sql);


            //string fldPicture = txtFirstName2.Text + txtLastName2.Text + ".jpg";

            //pbFetcher.Image.Save(js.GetPath() + "/Fetchers/" + fldPicture);

            //string q = "INSERT INTO tblFetcher(fldFirstName,fldLastName,fldContactDetails,fldRelationship,fldPicture)" + 
            //           " VALUES('" + txtFirstName2.Text + "','" + txtLastName2.Text + "','" + cID + "','" + rel + "','" + fldPicture + "')";

            //js.ExecuteNonQuery(q);
            

            //Saving Fetcher

            string qq = "UPDATE tblKids SET fldRemarks='" + txtRemarks.Text + "' WHERE fldID='" + sID + "'";
            js.ExecuteNonQuery(qq);


            if(!chkNG.Checked)
            {
                InitialFetcher fetcher = new InitialFetcher();
                fetcher.setFirstName(txtFirstName2.Text);
                fetcher.setLastName(txtLastName2.Text);
                fetcher.setRelationship(Convert.ToInt32(rel));
                fetcher.setContactID(Convert.ToInt32(cID));
                fetcher.setImage(pbFetcher.Image);
                fetcher.setEmail(txtEmail.Text);

                string fID = fetcher.SaveInfo();//js.Lookup("fldID", "tblFetcher", "fldFirstName='" + txtFirstName2.Text + "' AND fldLastName='" + txtLastName2.Text + "'");

                string q = "INSERT INTO tblKidFetcher(fldKidID,fldFetcherID) VALUES('" + sID + "','" + fID + "')";

                js.ExecuteNonQuery(q);
            }
            

            this.Tag = sID;

            DialogResult = System.Windows.Forms.DialogResult.OK;

            this.Close();




        }

        private void frmNewKid_Load(object sender, EventArgs e)
        {
            LoadRelationship();
            LoadGender();
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

            while (js.RiD.Read())
            {
                cboRelationship.Items.Add(js.RiD["fldRelationship"]);
            }
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
            while (js.RiD.Read())
            {
                cboGender.Items.Add(js.RiD["fldGender"]);
            }
            js.CloseConnection();
        }

        private string SaveUpdateContactDetails(string fldContactID, string ContactNo)
        {
            //Connector2 js2 = new Connector2();
            string qry = "";
            string cID = "";
            if (fldContactID == "")
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

        private void chkNA_CheckedChanged(object sender, EventArgs e)
        {
            if (chkNA.Checked)
            {
                txtEmail.Enabled = false;
            }
            else
            {
                txtEmail.Enabled = true;
            }
        }

        private void chkNG_CheckedChanged(object sender, EventArgs e)
        {
            if(chkNG.Checked)
            {
                txtFirstName2.Enabled = false;
                txtLastName2.Enabled = false;
                cboRelationship.Enabled = false;
                txtContactNo.Enabled = false;
                txtEmail.Enabled = false;
                chkNA.Enabled = false;
                btnBrowse2.Enabled = false;
                btnTake2.Enabled = false;
            }
            else
            {
                txtFirstName2.Enabled = true;
                txtLastName2.Enabled = true;
                cboRelationship.Enabled = true;
                txtContactNo.Enabled = true;
                txtEmail.Enabled = true;
                chkNA.Enabled = true;
                btnBrowse2.Enabled = true;
                btnTake2.Enabled = true;
            }
        }

        private void dtBDay_ValueChanged(object sender, EventArgs e)
        {
            lblAge.Text = js.GetAge(dtBDay.Value).ToString();

        }

        private void lblAge_TextChanged(object sender, EventArgs e)
        {
            string age = lblAge.Text;

            if (Convert.ToDecimal(age) < 2)
            {
                txtGroup.Text = "Nursery";
            }

            else if ((Convert.ToDecimal(age) >= 2) && (Convert.ToDecimal(age) < 3))
            {
                txtGroup.Text = "Toddlers";
            }

            else if ((Convert.ToDecimal(age) >= 3) && (Convert.ToDecimal(age) <= 4))
            {
                txtGroup.Text = "Preschool";
            }

            else if ((Convert.ToDecimal(age) >= 5) && (Convert.ToDecimal(age) <= 6))
            {
                txtGroup.Text = "Kinder";
            }

            else if ((Convert.ToDecimal(age) >= 7) && (Convert.ToDecimal(age) <= 9))
            {
                txtGroup.Text = "Primary";
            }

            else if ((Convert.ToDecimal(age) >= 10) && (Convert.ToDecimal(age) <= 12))
            {
                txtGroup.Text = "Preteens";
            }

            else
            {
                txtGroup.Text = "Adult";
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void chkVG_CheckedChanged(object sender, EventArgs e)
        {
            if(chkVG.Checked)
            {
                txtVGL.Enabled = true;
                chkOne2One.Enabled = true;
                chkVW.Enabled = true;
                txtVGL.Text = "";
            }
            else
            {
                txtVGL.Enabled = false;
                chkOne2One.Enabled = false;
                chkVW.Enabled = false;
                txtVGL.Text = "Victory Group Leader";
            }
        }

        private void txtVGL_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
