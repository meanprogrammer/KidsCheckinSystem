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
    public partial class frmRoom : Form
    {
        Connector js = new Connector();
        string fldEventID;
        public frmRoom()
        {
            InitializeComponent();
        }

        private void frmRoom_Load(object sender, EventArgs e)
        {
            LoadRooms();
        }

        private void LoadRooms()
        {

            string q = "SELECT * FROM tblCustomizedEvent WHERE fldStatus=1";

            js.ExecuteQuery(q);

            cboRooms.Items.Clear();

            while(js.RiD.Read())
            {
                cboRooms.Items.Add(js.RiD["fldEventTitle"]);
            }

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            string timetoday = DateTime.Now.ToString("hh:mm tt");

            string q = "SELECT * FROM tblEvent WHERE fldRegistrationTime <= convert(time,'" + timetoday + "') AND fldEndTime >=convert(time,'" + timetoday + "')";

            js.ExecuteQuery(q);

            js.RiD.Read();

            //lblNotification.Text = "";

            if (js.RiD.HasRows)
            {
                fldEventID = "" + js.RiD["fldID"].ToString();

                string fldCEventID = js.Lookup("fldID", "tblCustomizedEvent", "fldEventTitle='" + cboRooms.Text + "'");
                string fldEventCode = js.Lookup("fldEventCode", "tblCustomizedEvent", "fldEventTitle='" + cboRooms.Text + "'");

                string qry = "SELECT er.fldRoomID,r.fldRoom FROM tblCustomizedEventRooms er " + 
                              "  LEFT OUTER JOIN tblRoom r on r.fldID=er.fldRoomID" + 
                               " WHERE er.fldMaxCapacity>(SELECT Count(*) FROM tblAttendance WHERE fldRoomID=er.fldRoomID AND fldLoginDateTime BETWEEN '" + DateTime.Now.ToShortDateString() +  " 00:00:00' AND '" + DateTime.Now.ToShortDateString() + " 23:59:59' AND fldEventID='" + fldEventID + "')" + 
                               " AND fldCEventID='" + fldCEventID + "'";
                

                js.ExecuteQuery(qry);

                js.RiD.Read();

                string room = "";

                if(js.RiD.HasRows)
                {
                    room = "" + js.RiD["fldRoom"].ToString();
                }

                if(room=="")
                {
                    js.showExclamation("There are no available Rooms for " + cboRooms.Text + " system will show last used room");

                    
                    room =  js.Lookup("TOP 1 fldRoom", "tblCustomizedEventRooms", "fldEventTitle='" + cboRooms.Text + "' ORDER BY fldID DESC");
                  
                    if(room=="")
                    {
                        js.showExclamation("Error Loading CheckIn System will exit");
                        Application.Exit();
                        return;
                    }

                    DialogResult = System.Windows.Forms.DialogResult.OK;
                    //return;
                }


                this.Tag = room + "-" + fldEventCode;
            }
            else
            {
                js.showExclamation("Cannot open an event yet!, Please try again later");
                this.DialogResult = DialogResult.Cancel;
                return;
            }

            js.CloseConnection();

            //
            


            
            this.DialogResult = DialogResult.OK;
            //this.Close();
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Tag = null;
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            //this.Close();
        }
    }
}
