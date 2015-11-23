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
    public partial class frmSystemOptions : Form
    {
        public frmSystemOptions()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Under Construction", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmMain1 frm = new frmMain1();
            this.Hide();
            frm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmMain2 frm = new frmMain2();
            this.Hide();
            frm.Show();
        }
    }
}
