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
    public partial class frmEvents : Form
    {
        Connector js = new Connector();
        public frmEvents()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(txtTitle.Text=="")
            {
                js.showExclamation("Please Enter Event Title");
                return;
            }

            if(txtCode.Text == "")
            {
                js.showExclamation("Please Enter Event Code");
            }

            int active = 0;
            if(chkActive.Checked)
            {
                active = 1;
            }

            string q = "";
            
            if(btnAdd.Tag==null)
            {
                q = "INSERT INTO tblCustomizedEvent(fldEventTitle,fldEventCode,fldStatus) VALUES('" + txtTitle.Text + "','" + txtCode.Text + "','" + active + "')";
            }
            else
            {
                q = "UPDATE tblCustomizedEvent SET fldEventTitle='" + txtTitle.Text + "',fldEventCode='" + txtCode.Text + "',fldStatus='" + active + "' WHERE fldID='" + btnAdd.Tag + "'";
            }


            js.ExecuteNonQuery(q);


            LoadEvents();

            txtTitle.Text = "";
            txtCode.Text = "";
            chkActive.Checked = false;
            btnAdd.Tag = null;
            btnAdd.Text = "Add";


        }

        private void LoadEvents()
        {
            string q = "SELECT * FROM tblCustomizedEvent";

            js.ExecuteQuery(q);

            dataGridView1.Rows.Clear();

            while(js.RiD.Read())
            {
                dataGridView1.Rows.Add(js.RiD["fldID"], js.RiD["fldEventTitle"], js.RiD["fldEventCode"], js.RiD["fldStatus"]);
            }
        }

        private void frmEvents_Load(object sender, EventArgs e)
        {
            LoadEvents();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            btnAdd.Tag = dataGridView1.CurrentRow.Cells["fldID"].Value;

            txtTitle.Text = dataGridView1.CurrentRow.Cells["fldEventTitle"].Value.ToString();
            txtCode.Text = dataGridView1.CurrentRow.Cells["fldEventCode"].Value.ToString();

            chkActive.Checked = bool.Parse(dataGridView1.CurrentRow.Cells["fldActive"].Value.ToString());

            btnAdd.Text = "Save";
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            admin.frmEventRoom frm = new admin.frmEventRoom();

            frm.Tag = dataGridView1.CurrentRow.Cells["fldID"].Value;

            frm.ShowDialog();

        }
    }
}
