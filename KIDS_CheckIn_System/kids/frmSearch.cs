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
    public partial class frmSearch : Form
    {
        public frmSearch()
        {
            InitializeComponent();
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cboSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            if(cboSearch.Text=="Birth Day")
            {
                txtSearch.Visible = false;
                dtSearch.Visible = true;
                dtSearch.Tag = cboSearch.Text;
                txtSearch.Tag = "";
            }
            else
            {
                txtSearch.Tag = cboSearch.Text;
                dtSearch.Visible = false;
                txtSearch.Visible = true;
                dtSearch.Tag = "";
            }
        }

        private void frmSearch_Load(object sender, EventArgs e)
        {
            txtSearch.Focus();
            txtSearch.Tag = cboSearch.Text;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
           

        }

        private void btnBrowse2_Click(object sender, EventArgs e)
        {
            if(openFileDialog2.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                var filename = openFileDialog2.FileName;
                System.IO.File.Copy(filename, Application.StartupPath + "/Pictures/Fetchers/" + txtFetcherFN.Text  +  txtFetcherLN.Text + ".jpg", true);
                pbFetcher.Image = System.Drawing.Image.FromFile(Application.StartupPath + "/Pictures/Fetchers/" + txtFetcherFN.Text + txtFetcherLN.Text + ".jpg");
                openFileDialog2.Dispose();

            }
            

        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
             if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                var filename = openFileDialog1.FileName;
                System.IO.File.Copy(filename, Application.StartupPath + "/Pictures/Kids/" + txtFirstName.Text + txtLastName.Text + ".jpg", true);
                pbImage.Image = System.Drawing.Image.FromFile(Application.StartupPath + "/Pictures/Kids/" + txtFirstName.Text + txtLastName.Text + ".jpg");
                openFileDialog1.Dispose();

            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }
    }
}
