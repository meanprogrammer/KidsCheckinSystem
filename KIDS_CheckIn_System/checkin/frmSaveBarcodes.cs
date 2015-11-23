using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KIDS_CheckIn_System.checkin
{
    public partial class frmSaveBarcodes : Form
    {
        public frmSaveBarcodes()
        {
            InitializeComponent();
        }

        private void frmSaveBarcodes_Load(object sender, EventArgs e)
        {
            using (System.IO.StringReader rd = new System.IO.StringReader(""))
            {
                
                richTextBox1.Text = rd.ReadLine();

                rd.Close();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            using (System.IO.StreamWriter wr = new System.IO.StreamWriter(Application.StartupPath + "\\barcodes." + DateTime.Now.ToString("MMdd")))
            {

               for(int i=0;i<(richTextBox1.Lines.Length-1);i++)
               {
                   if (richTextBox1.Lines[i] == null)
                   {
                       return;
                   }
                   wr.WriteLine(richTextBox1.Lines[i]);
                 
                  
               }

               wr.Close();
            }
        }
    }
}
