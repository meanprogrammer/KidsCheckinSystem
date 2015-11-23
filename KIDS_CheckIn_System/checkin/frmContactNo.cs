using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KIDS_CheckIn_System.checkin
{
    public partial class frmContactNo : Form
    {
        public frmContactNo()
        {
            InitializeComponent();
        }

        Connector js = new Connector();

        private void frmContactNo_Load(object sender, EventArgs e)
        {
            string KidID = this.Tag.ToString();

            string q = "SELECT * FROM tblKidFetcher WHERE fldKidID='" + KidID + "'";
            
            js.ExecuteQuery(q);
            dgvContacts.Rows.Clear();
            while(js.RiD.Read())
            {
                string fname = js.Lookup("fldFirstName", "tblFetcher", "fldID='" + js.RiD["fldFetcherID"].ToString() + "'");
                string lname = js.Lookup("fldLastName", "tblFetcher", "fldID='" + js.RiD["fldFetcherID"].ToString() + "'");

                string rel = js.Lookup("fldRelationship", "tblFetcher", "fldID='" + js.RiD["fldFetcherID"].ToString() + "'");

                string relationship = js.Lookup("fldRelationship", "tblRelationship", "fldID='" + rel + "'");

                string cid = js.Lookup("fldContactDetails", "tblFetcher", "fldID='" + js.RiD["fldFetcherID"].ToString() + "'");

                string contact = js.Lookup("fldContactNumber", "tblContactDetails", "fldID='" + cid + "'");

                dgvContacts.Rows.Add(fname + " " + lname, relationship, contact);
                
            }
        }
    }
}
