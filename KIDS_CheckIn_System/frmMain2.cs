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
    public partial class frmMain2 : Form
    {
        public frmMain2()
        {
            InitializeComponent();
        }

        private void frmMain2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void tsbSearch_Click(object sender, EventArgs e)
        {
            frmAdminUpdate frm = new frmAdminUpdate();
            frm.MdiParent = this;
            frm.Show();
        }
    }
}
