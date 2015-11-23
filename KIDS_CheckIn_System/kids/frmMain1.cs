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
    public partial class frmMain1 : Form
    {
        Connector js = new Connector();
        public frmMain1()
        {
            InitializeComponent();
        }

        private void frmMain1_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Application.Exit();
            

        }

        private void tsbSearch_Click(object sender, EventArgs e)
        {
            frmSearchKids frm = new frmSearchKids();
            frm.MdiParent = this;
            frm.Tag = "";
            frm.Show();
        }

        private void frmMain1_FormClosing(object sender, FormClosingEventArgs e)
        {
            
                frmSystemOptions frm = new frmSystemOptions();
                frm.ShowDialog();
                this.Close();
            

        }

        private void frmMain1_Load(object sender, EventArgs e)
        {

        }
    }
}
