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
    public partial class frmVerifier : Form
    {
        Connector js = new Connector();
        string StudentID = "";
        public frmVerifier()
        {
            InitializeComponent();
        }
        
        private void frmVerifier_Load(object sender, EventArgs e)
        {
            StudentID = this.Tag.ToString();

            string q = "SELECT * FROM tblKids WHERE fldStudentID='" + StudentID + "'";

            string fullname = "";

            js.ExecuteQuery(q);
            js.RiD.Read();

            fullname = js.RiD["fldLastName"] + ", " + js.RiD["fldFirstName"];

            txtFullname.Text = fullname;

            string picture = js.GetPath() + "/Kids/" + js.RiD["fldPicture"];

            pbKidsImage.Image = Image.FromFile(picture);

            txtBarcode.Text = StudentID;

            dtBDay.Value = Convert.ToDateTime(js.RiD["fldBirthday"]);

            js.CloseConnection();
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Yes;
            pbKidsImage.Image.Dispose();
            this.Close();
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.No;
            this.Close();
        }
    }
}
