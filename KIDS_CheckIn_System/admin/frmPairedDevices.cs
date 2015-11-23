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
    public partial class frmPairedDevices : Form
    {
        public frmPairedDevices()
        {
            InitializeComponent();
        }

        private void frmPairedDevices_FormClosing(object sender, FormClosingEventArgs e)
        {
           
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string devices = "";
            for (int i = 0; i <= (dataGridView1.Rows.Count - 2); i++)
            {
                string PCName = dataGridView1.Rows[i].Cells["ComputerName"].Value.ToString();
                string ip = dataGridView1.Rows[i].Cells["IP"].Value.ToString();
                devices += PCName + "|" + ip;
                if (dataGridView1.Rows[i + 1].Cells["ComputerName"].Value == null && dataGridView1.Rows[i + 1].Cells["IP"].Value == null)
                {

                }
                else
                {
                    devices += ",";
                }


                
            }

            this.Tag = devices;
        }

        private void frmPairedDevices_Load(object sender, EventArgs e)
        {
            string paireddevices = this.Tag.ToString();

            string[] devices = paireddevices.Split(char.Parse(","));


            if (devices[0] == "")
            {
                string device = paireddevices;

                string[] properties = device.Split(char.Parse("|"));

                dataGridView1.Rows.Add(properties[0], properties[1]);
                return;
            }


            for(int i =0; i<=(devices.Length-1);i++)
            {
                string device = devices[i];

                string[] properties = device.Split(char.Parse("|"));

                dataGridView1.Rows.Add(properties[0],properties[1]);
            }

            

        }
    }
}
