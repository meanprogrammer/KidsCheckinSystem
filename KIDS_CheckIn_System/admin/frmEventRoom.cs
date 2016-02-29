using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KIDS_CheckIn_System.admin
{
    public partial class frmEventRoom : Form
    {
        Database db;
        Connector js = new Connector();
        public frmEventRoom()
        {
            InitializeComponent();
            db = DatabaseFactory.CreateDatabase();
        }


        private void frmEventRoom_Load(object sender, EventArgs e)
        {
            LoadEventRooms();
            LoadRooms();

        }

        private void LoadRooms()
        {
            string q = "SELECT * FROM tblRoom";

            DbCommand cmd = db.GetSqlStringCommand(q);
            IDataReader reader = db.ExecuteReader(cmd);

            while(reader.Read())
            {
                cboRoom.Items.Add(reader.GetString(reader.GetOrdinal("fldRoom")));
            }
        }

        private void LoadEventRooms()
        {
            string q = "SELECT * FROM tblCustomizedEventRooms WHERE fldCEventID='" + this.Tag + "'";

            js.ExecuteQuery(q);

            //DbCommand cmd = db.GetSqlStringCommand(q);
            //IDataReader reader = db.ExecuteReader(cmd);

            dataGridView1.Rows.Clear();
            while (js.RiD.Read())
            {
                string room = js.Lookup("fldRoom", "tblRoom", "fldID='" + js.RiD["fldRoomID"] + "'");

                dataGridView1.Rows.Add(js.RiD["fldID"],room, js.RiD["fldAgeFrom"], js.RiD["fldAgeTo"],js.RiD["fldMaxCapacity"]);
            }
        }

        private void frmEventRoom_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string id = dataGridView1.CurrentRow.Cells["fldID"].Value.ToString();

            string q = "DELETE FROM tblCustomizedEventRooms WHERE fldID='" + id + "'";

            js.ExecuteNonQuery(q);

            LoadEventRooms();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string q = "";

            if(cboRoom.Text=="")
            {
                js.showExclamation("Please select a room");
                return;
            }

            string room = js.Lookup("fldID", "tblRoom", "fldRoom='" + cboRoom.Text + "'");

            q = "INSERT INTO tblCustomizedEventRooms(fldRoomID,fldAgeFrom,fldAgeTo,fldCEventID,fldMaxCapacity) VALUES('" + 
                room + "','" + txtAgeFrom.Text + "','" + txtAgeTo.Text + "','" + this.Tag + "','" + txtMaxCap.Text + "')";

            js.ExecuteNonQuery(q);


            LoadEventRooms();

            cboRoom.Text = "";
            txtAgeTo.Text = "";
            txtAgeFrom.Text = "";


        }

        private void txtAgeFrom_TextChanged(object sender, EventArgs e)
        {
            if(txtAgeFrom.Text=="")
            {
                txtAgeFrom.Text = "0";
            }
        }

        private void txtAgeFrom_Click(object sender, EventArgs e)
        {
            if(txtAgeFrom.Text =="0")
            {
                txtAgeFrom.Text = "0";
            }
        }

        private void txtAgeTo_TextChanged(object sender, EventArgs e)
        {
            if(txtAgeTo.Text=="")
            {
                txtAgeTo.Text = "0";
            }
        }

        private void txtAgeTo_Click(object sender, EventArgs e)
        {
            if(txtAgeTo.Text =="0")
            {
                txtAgeTo.Text = "";
            }
        }

        private void txtMaxCap_TextChanged(object sender, EventArgs e)
        {
            if(txtMaxCap.Text=="")
            {
                txtMaxCap.Text = "0";
            }
        }

        private void txtMaxCap_Click(object sender, EventArgs e)
        {
            if(txtMaxCap.Text=="0")
            {
                txtMaxCap.Text = "";
            }
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
