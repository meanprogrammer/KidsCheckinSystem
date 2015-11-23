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
        Connector js = new Connector();
        AccessRegistryTool reg = new AccessRegistryTool();

        public frmSystemOptions()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //js.showExclamation("Under Contruction","Check-IN");
            frmRoom d  =  new frmRoom();
            if (d.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                
                frmLogin frm = new frmLogin();

                string[] tag = d.Tag.ToString().Split(char.Parse("-"));

                frm.Tag = tag[0];
                frm.Text = tag[1];
                frm.Show();
                this.Hide();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            admin.frmStaffLogin d = new admin.frmStaffLogin();
        
            if(d.ShowDialog()== System.Windows.Forms.DialogResult.OK)
            {
                frmSearchKids frm = new frmSearchKids();
                this.Hide();
                frm.Show();
            }
    
            

           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            admin.frmStaffLogin d = new admin.frmStaffLogin();

            if(d.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                admin.frmMain2 frm = new admin.frmMain2();
                this.Hide();
                frm.Show();
            }
                

        }

        private void btnHelpDesk_Click(object sender, EventArgs e)
        {
            frmHelpDesk frm = new frmHelpDesk();
            //frm.MdiParent = this;
            frm.Show();
            this.Hide();
        }

        private void frmSystemOptions_FormClosed(object sender, FormClosedEventArgs e)
        {
            

            Application.Exit();
        }

        private void frmSystemOptions_Load(object sender, EventArgs e)
        {
            try
            {
                string val = AccessRegistryTool.ReadValue("DBServer");
                if (val == "")
                {
                    frmSettings frm = new frmSettings();

                    frm.ShowDialog();

                }
            }
            catch (Exception ex)
            {

                return;
            }
            

        }

        private void button4_Click(object sender, EventArgs e)
        {
            frmVolunteers frm = new frmVolunteers();
            this.Hide();
            frm.ShowDialog();
            
        }
    }
}
