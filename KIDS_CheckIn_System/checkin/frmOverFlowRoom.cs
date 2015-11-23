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
    public partial class frmOverFlowRoom : Form
    {
        public frmOverFlowRoom()
        {
            InitializeComponent();
        }

        Connector js = new Connector();

        private void frmOverFlowRoom_Load(object sender, EventArgs e)
        {
            string q = this.Tag.ToString();

            js.ExecuteQuery(q);


            while(js.RiD.Read())
            {
                dataGridView1.Rows.Add(js.RiD["fldRoomID"],js.RiD["fldRoom"],js.RiD["fldAgeFrom"],js.RiD["fldAgeTo"]);
            }
            
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            this.Tag = dataGridView1.CurrentRow.Cells["fldID"].Value + "|" + dataGridView1.CurrentRow.Cells["fldRoom"].Value;
        }
    }
}
