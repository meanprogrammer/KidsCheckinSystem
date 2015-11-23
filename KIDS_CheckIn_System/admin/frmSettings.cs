using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace KIDS_CheckIn_System
{
    public partial class frmSettings : Form
    {
        //static AccessRegistryTool reg = new AccessRegistryTool();
        Connector js = new Connector();
        public frmSettings()
        {
            InitializeComponent();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            string path = AccessRegistryTool.ReadValue("PicPath");//File.ReadAllText(Application.StartupPath + "/path.dat");

            fbd1.SelectedPath = path;

            fbd1.ShowNewFolderButton = true;
            if (fbd1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtPath.Text = fbd1.SelectedPath;
            }
        }

        private void frmSettings_Load(object sender, EventArgs e)
        {
            string path = AccessRegistryTool.ReadValue("PicPath");   //File.ReadAllText(Application.StartupPath + "/path.dat");
            string server = AccessRegistryTool.ReadValue("DBServer"); //File.ReadAllText(Application.StartupPath + "/server.dat"); 

            txtPath.Text = path;
            txtServerName.Text = server;
            txtServer2.Text = KIDS_CheckIn_System.Properties.Settings.Default.Server;

            txtPairedDevices.Text = KIDS_CheckIn_System.Properties.Settings.Default.PairedDevices;

            lblMachineName.Text = System.Environment.MachineName;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        //Summary:
        // Saves the setting to the registry
        private void btnSave_Click(object sender, EventArgs e)
        {

           
            if(AccessRegistryTool.WriteValue("DBServer", txtServerName.Text))
            {
                if (AccessRegistryTool.WriteValue("PicPath", txtPath.Text))
                {
                    MessageBox.Show("Setting Successfully Saved\n\n Please Restart the Program", "Settings", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            KIDS_CheckIn_System.Properties.Settings.Default.Server = txtServer2.Text;
            KIDS_CheckIn_System.Properties.Settings.Default.PairedDevices = txtPairedDevices.Text;
            KIDS_CheckIn_System.Properties.Settings.Default.Save();
          
         
            Application.Exit();

        }

        private void fbd1_HelpRequest(object sender, EventArgs e)
        {

        }

        private void btnPaired_Click(object sender, EventArgs e)
        {
            admin.frmPairedDevices frm = new admin.frmPairedDevices();
            frm.Tag = txtPairedDevices.Text;
            if(frm.ShowDialog()== System.Windows.Forms.DialogResult.OK)
            {
                txtPairedDevices.Text = frm.Tag.ToString();
            }

        }
    }
}
