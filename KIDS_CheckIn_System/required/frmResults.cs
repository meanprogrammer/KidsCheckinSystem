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
    public partial class frmResults : Form
    {
        Connector js = new Connector();
        public frmResults()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(this.Tag.ToString());
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Tag = null;
            this.Close();

            //js.searchquery = "";
        }

        private void frmResults_Load(object sender, EventArgs e)
        {
            string q = this.Tag.ToString();

            try
            {
                js.ExecuteQuery(q);
                dgvResults.Rows.Clear();
                while (js.RiD.Read())
                {
                    DateTime bdate;
                    string bd;
                    
                    if(DateTime.TryParse(js.RiD["fldBirthday"].ToString(),out bdate))
                    {
                        bd = bdate.ToShortDateString();
                    }
                    else
                    {
                        bd = "";
                    }

                    dgvResults.Rows.Add(js.RiD["fldStudentID"], js.RiD["fldFirstName"], js.RiD["fldLastName"], js.RiD["fldMiddleName"], js.RiD["fldNickName"], bd);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //js.ExecuteQuery(q);

           

            

            js.CloseConnection();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            string qry = "";

            qry = "SELECT k.*,g.fldGender as Gender FROM tblKids  k " +
                             "LEFT OUTER JOIN tblGender g ON g.fldID=k.fldGender" +
                             " WHERE fldStudentID='" + dgvResults.CurrentRow.Cells["StudentID"].Value + "' ORDER BY fldFirstName,fldLastName";

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Tag = qry;
            this.Close();
        }

        private void dgvResults_DoubleClick(object sender, EventArgs e)
        {
            string qry = "";

            qry = "SELECT isnull(kf.fldFetcherID,0) as fldFetcherID,k.*,g.fldGender as Gender FROM tblKids  k " +
                          "LEFT OUTER JOIN tblKidFetcher kf ON kf.fldKidID=k.fldID " +
                          "LEFT OUTER JOIN tblGender g ON g.fldID=k.fldGender" +
                          " WHERE fldStudentID='" + dgvResults.CurrentRow.Cells["StudentID"].Value + "' ORDER BY fldFirstName,fldLastName";

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Tag = qry;
            this.Close();
        }
    }
}
