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
    public partial class frmEvents : Form
    {
        Connector js = new Connector();
        string fldID = "";
        public frmEvents()
        {
            InitializeComponent();
        }

        private void frmEvents_Load(object sender, EventArgs e)
        {
            LoadEvents();
            dtStartTime.ShowUpDown = true;
            dtStartTime.CustomFormat = "hh:mm tt";
            dtStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;

            dtEndTime.ShowUpDown = true;
            dtEndTime.CustomFormat = "hh:mm tt";
            dtEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;

            dtRegis.ShowUpDown = true;
            dtRegis.CustomFormat = "hh:mm tt";
            dtRegis.Format = System.Windows.Forms.DateTimePickerFormat.Custom;


        }

        private void LoadEvents()
        {
            string q = "SELECT * FROM tblEvent";

            js.ExecuteQuery(q);

            dgvEvents.Rows.Clear();
            while(js.RiD.Read())
            {
                dgvEvents.Rows.Add(js.RiD["fldID"], js.RiD["fldEventTitle"], js.RiD["fldStartTime"], js.RiD["fldEndTime"], js.RiD["fldRegistrationTime"]);
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            txtEventTitle.Enabled = true;
            dtEndTime.Enabled = true;
            dtStartTime.Enabled = true;
            dtRegis.Enabled = true;
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            fldID = dgvEvents.CurrentRow.Cells["ID"].Value.ToString();
            lblID.Text = fldID;

            txtEventTitle.Text = dgvEvents.CurrentRow.Cells["fldEventTitle"].Value.ToString();

            dtStartTime.Value = Convert.ToDateTime(dgvEvents.CurrentRow.Cells["fldStartTime"].Value);
            dtEndTime.Value = Convert.ToDateTime(dgvEvents.CurrentRow.Cells["fldEndTime"].Value);
            dtRegis.Value = Convert.ToDateTime(dgvEvents.CurrentRow.Cells["fldRegistrationTime"].Value);


            toolStripButton1_Click(null, null);
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            string q = "";
            if(js.showQuestion("Are you sure you want to delete " + dgvEvents.CurrentRow.Cells["fldEventTitle"].Value + "?")== System.Windows.Forms.DialogResult.Yes)
            {
                q = "DELETE FROM tblEvent WHERE fldID='" + dgvEvents.CurrentRow.Cells["ID"].Value + "'";
            }
            js.ExecuteNonQuery(q);

            LoadEvents();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if(txtEventTitle.Text =="")
            {
                js.showExclamation("Event Title Required");
                return;
            }
            string q = "";

            if(lblID.Text=="")
            {
                q = "INSERT INTO tblEvent(fldEventTitle,fldStartTime,fldEndTime,fldRegistrationTime) VALUES('" + txtEventTitle.Text + "','" + dtStartTime.Value.ToString("hh:mm tt") + 
                    "','" + dtEndTime.Value.ToString("hh:mm tt") + "','" + dtRegis.Value.ToString("hh:mm tt") +  "')";
            }
            else
            {
                q = "UPDATE tblEvent SET fldEventTitle='" + txtEventTitle.Text + "',fldStartTime='" + dtStartTime.Value.ToString("hh:mm tt") + "',fldEndTime='" + dtEndTime.Value.ToString("hh:mm tt") +
                    "',fldRegistrationTime='" + dtRegis.Value.ToString("hh:mm tt") + "' WHERE fldID='" + lblID.Text + "'";
            }

            js.ExecuteNonQuery(q);

            txtEventTitle.Text = "";
            dtRegis.Value = DateTime.Now;
            dtEndTime.Value = DateTime.Now;
            dtStartTime.Value = DateTime.Now;
            lblID.Text = "";
            LoadEvents();

        }
    }
}
