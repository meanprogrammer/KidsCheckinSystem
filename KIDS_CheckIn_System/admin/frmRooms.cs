using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KIDS_CheckIn_System.admin
{
    public partial class frmRooms : Form
    {
        public frmRooms()
        {
            InitializeComponent();
        }

        Connector js = new Connector();
        string fldID = "";
        

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            
        }

        private void frmRooms_Load(object sender, EventArgs e)
        {
            LoadGroups();
            LoadRooms();
        }

        private void LoadGroups()
        {
            string q = "SELECT * FROM tblGroup";

            js.ExecuteQuery(q);

            cboGroup.Items.Clear();
            while(js.RiD.Read())
            {
                cboGroup.Items.Add(js.RiD["fldGroup"]);
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (txtRoom.Text == "")
            {
                js.showExclamation("Room Name required");
                return;
            }

            string q = "";
            string groupid = js.Lookup("fldID", "tblGroup", "fldGroup='" + cboGroup.Text + "'");
            if(lblID.Text=="")
            {
                int enable = 0;
                if(chkAll.Checked)
                {
                    enable = 1;
                }
                q = "INSERT INTO tblRoom (fldRoom,fldAgeFrom,fldAgeTo,fldGroupID,fldMaxCapacity,fldGroup,fldEnableAll) VALUES('" + txtRoom.Text + "','" + txtAge1.Text + "','" + txtAge2.Text + "','" + groupid + "','" + txtMaxCap.Text + "','" + cboGroup.Text + "'," + enable +  ")";
            }
            else
            {
                int enable = 0;
                if (chkAll.Checked)
                {
                    enable = 1;
                }
                q = "UPDATE tblRoom SET fldRoom='" + txtRoom.Text + "',fldAgeFrom='" + txtAge1.Text + "',fldAgeTo='" + txtAge2.Text + "',fldGroupID='" + groupid + "',fldMaxCapacity='" + txtMaxCap.Text + "',fldGroup='" + cboGroup.Text + "',fldEnableAll=" + enable + " WHERE fldID='" + lblID.Text + "'";
            }

           

            js.ExecuteNonQuery(q);

            txtRoom.Text = "";
            txtAge1.Text = "";
            txtAge2.Text = "";
            txtMaxCap.Text = "";
            cboGroup.Text = "";
            lblID.Text = "";
            chkAll.Checked = false;

            LoadRooms();

        }

        private void LoadRooms()
        {
            string q = "SELECT * FROM tblRoom";

            js.ExecuteQuery(q);

            dgvEvents.Rows.Clear();
            
            while(js.RiD.Read())
            {
                bool game = false;
                if(js.RiD["fldEnableAll"].ToString()=="True")
                {
                    game = true;
                }
                dgvEvents.Rows.Add(js.RiD["fldID"],js.RiD["fldRoom"], js.RiD["fldAgeFrom"], js.RiD["fldAgeTo"], js.RiD["fldMaxCapacity"], js.RiD["fldGroup"],game);
            }

        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            lblID.Text = dgvEvents.CurrentRow.Cells["ID"].Value.ToString();
            txtRoom.Text = dgvEvents.CurrentRow.Cells["fldRoom"].Value.ToString();
            txtAge1.Text = dgvEvents.CurrentRow.Cells["fldAge1"].Value.ToString();
            txtAge2.Text = dgvEvents.CurrentRow.Cells["fldAge2"].Value.ToString();
            txtMaxCap.Text = dgvEvents.CurrentRow.Cells["fldMaxCap"].Value.ToString();
            cboGroup.Text = dgvEvents.CurrentRow.Cells["fldGroup"].Value.ToString();
            
            if(dgvEvents.CurrentRow.Cells["fldEnableAll"].Value.ToString()=="True")
            {
                chkAll.Checked = true;
            }
            else
            {
                chkAll.Checked = false;
            }


        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            string q = "";
            if(js.showQuestion("Are you sure you want to delete " + dgvEvents.CurrentRow.Cells["fldRoom"].Value.ToString()  + "?")== System.Windows.Forms.DialogResult.Yes)
            {
                q = "DELETE FROM tblRoom WHERE fldID='" + dgvEvents.CurrentRow.Cells["ID"].Value.ToString() + "'";
            }
            else
            {
                return;
            }

            js.ExecuteNonQuery(q);
            LoadRooms();
        }
    }
}
