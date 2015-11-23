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
    public partial class frmMain2 : Form
    {
        public frmMain2()
        {
            InitializeComponent();
        }

        private void frmMain2_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmSystemOptions frm = new frmSystemOptions();
            frm.Show();
            this.Hide();
            
            //Application.Exit();
        }

        private void tsbSearch_Click(object sender, EventArgs e)
        {
            frmAdminUpdate frm = new frmAdminUpdate();
            frm.MdiParent = this;
            frm.Show();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            frmReport frm = new frmReport();
            frm.MdiParent = this;
            frm.Show();
        }

        private void tsbSetting_Click(object sender, EventArgs e)
        {
            frmSettings frm = new frmSettings();
            frm.MdiParent = this;
            frm.Show();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            frmClaimStubs frm = new frmClaimStubs();
            frm.MdiParent = this;
            frm.Show();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            frmEvents frm = new frmEvents();
            frm.MdiParent =this;
            frm.Show();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            frmRooms frm = new frmRooms();
            frm.ShowDialog();

        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            checkin.frmEvents frm = new checkin.frmEvents();
            frm.ShowDialog();
            
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            volunteers.frmVolunteerManagement frm = new volunteers.frmVolunteerManagement();
            frm.ShowDialog();
        }

        private void frmMain2_Load(object sender, EventArgs e)
        {

        }
    }
}
