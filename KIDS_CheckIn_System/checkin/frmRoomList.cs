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
    public partial class frmRoomList : Form
    {
        Connector js = new Connector();
        public frmRoomList()
        {
            InitializeComponent();
        }

        string fldEventCode;

        private void frmRoomList_Load(object sender, EventArgs e)
        {

            fldEventCode = this.Tag.ToString();

            string id = js.Lookup("fldID","tblCustomizedEvent","fldEventCode='" + fldEventCode + "'");


            string q = "SELECT fldRoom FROM tblRoom r LEFT OUTER JOIN tblCustomizedEventRooms c ON c.fldRoomID=r.fldID WHERE c.fldCEventID='" + id + "'";
           

            js.ExecuteQuery(q);

            while(js.RiD.Read())
            {
               
                cboRooms.Items.Add(js.RiD["fldRoom"].ToString());
               
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {

            if(cboRooms.Text=="")
            {
                js.showExclamation("Please Select a room");
                return;
            }
            this.Tag = cboRooms.Text;
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }
    }
}
