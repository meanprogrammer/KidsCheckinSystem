using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.Diagnostics;

namespace KIDS_CheckIn_System
{
    public partial class frmReport : Form
    {
        Connector con = new Connector();
        private DataGridView gvReport;
        private DataGridViewTextBoxColumn FirstName;
        private DataGridViewTextBoxColumn LastName;
        private DataGridViewTextBoxColumn NickName;
        private DataGridViewTextBoxColumn StudentID;
        private DataGridViewTextBoxColumn Age;
        private DataGridViewTextBoxColumn Group;
        private DataGridViewTextBoxColumn Birthday;
        private DataGridViewCheckBoxColumn ID;
        private Panel panel1;
        private Button Export;
        private Timer timer1;
        private IContainer components;
        //Connector con1 = new Connector();
        string barcode = "";

        public frmReport()
        {
            InitializeComponent();
        }


        private void frmReport_Load(object sender, EventArgs e)
        {

           // MessageBox.Show(Environment.GetFolderPath(Environment.SpecialFolder.Desktop));
            timer1.Enabled = true;
            string qry = "";

            qry = "select fldID, fldFirstName, fldLastName, fldNickName, fldStudentID, fldBirthday, fldDateTime from tblKids where fldUpdateStatus = 1 order by fldDateTime DESC";

            string q = qry;

            con.ExecuteQuery(q);
            //con.RiD.Read();
            gvReport.Rows.Clear();

            while (con.RiD.Read())
            {

                string firstname = con.RiD["fldFirstName"].ToString();
                string lastname = con.RiD["fldLastName"].ToString();
                string barcode = con.RiD["fldStudentID"].ToString();
                string nickname = con.RiD["fldNickName"].ToString();
                string birthday = "";
                birthday = Convert.ToDateTime(con.RiD["fldBirthday"].ToString()).ToShortDateString();
                string age = "";
                string group = "";
                
                //age = con.Lookup("DATEDIFF(year, fldBirthday, GETDATE())", "tblKids", "fldStudentID = '" + barcode + "'");

                age = con.GetAge(Convert.ToDateTime(birthday)).ToString();

                if (Convert.ToDecimal(age) < 2)
                {
                    group = "Nursery";
                }

                else if ((Convert.ToDecimal(age) >= 2) && (Convert.ToDecimal(age) < 3))
                {
                    group = "Toddlers";
                }

                else if ((Convert.ToDecimal(age) >= 3) && (Convert.ToDecimal(age) <= 4))
                {
                    group = "Pre-School";
                }

                else if ((Convert.ToDecimal(age) >= 5) && (Convert.ToDecimal(age) <= 6))
                {
                    group = "Kinder";
                }

                else if ((Convert.ToDecimal(age) >= 7) && (Convert.ToDecimal(age) <= 9))
                {
                    group = "Primary";
                }

                else if ((Convert.ToDecimal(age) >= 10) && (Convert.ToDecimal(age) <= 12))
                {
                    group = "Pre-Teens";
                }

                else
                {
                    group = "Adult";
                }

                gvReport.Rows.Add(con.RiD["fldFirstName"], con.RiD["fldLastName"], con.RiD["fldNickName"],"*" +  con.RiD["fldStudentID"] + "*", age, group, birthday, false);

               
            }

            con.CloseConnection();

           
            
        }

        private void gvReport_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //check if check box is checked
            if (gvReport.CurrentCell.ColumnIndex == 7)
            {
                //MessageBox.Show(gvReport.CurrentCell.Value.ToString());

                if (gvReport.CurrentCell.Value.ToString() == false.ToString())
                {
                    gvReport.CurrentCell.Value = true;

                    string qry = "";
                    string studentID = gvReport.CurrentRow.Cells["StudentID"].Value.ToString();
                    studentID = studentID.Replace("*", "");

                    qry = "Update tblKids SET fldUpdateStatus = '2' where fldStudentID = '" + studentID + "'";

                    string q = qry;

                    con.ExecuteNonQuery(q);
                }

            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            frmReport_Load(null, null);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string strPath = System.Windows.Forms.Application.StartupPath + "\\Exported File\\List of ID.xlsx";

            Excel._Application xl = new Microsoft.Office.Interop.Excel.Application();
            Excel._Workbook xb = xl.Workbooks.Open(strPath);
            Excel._Worksheet xs;

            xs = xb.Worksheets["Sheet1"];

            int irows = 3;

            for (int r = 0; r <= (gvReport.Rows.Count - 1); r++)
            {
                System.Windows.Forms.Application.DoEvents();
                if (irows > 3)
                {
                    //xlApp.Rows.get_Range("2:2").Select();
                    xl.Rows["3:3"].Select();
                    xl.Application.CutCopyMode = Excel.XlCutCopyMode.xlCopy;
                    xl.Selection.Copy();
                    xl.Rows[irows + ":" + irows].Select();
                    xl.Selection.Insert(Shift: -4121);

                }

                xl.Cells[irows, 1] = gvReport.Rows[r].Cells["Nickname"].Value;
                xl.Cells[irows, 2] = gvReport.Rows[r].Cells["LastName"].Value;
                xl.Cells[irows, 3] = gvReport.Rows[r].Cells["FirstName"].Value;
                xl.Cells[irows, 4] = gvReport.Rows[r].Cells["StudentID"].Value;
                xl.Cells[irows, 5] = gvReport.Rows[r].Cells["Birthday"].Value;
                xl.Cells[irows, 6] = gvReport.Rows[r].Cells["Age"].Value;
                xl.Cells[irows, 7] = gvReport.Rows[r].Cells["Group"].Value;

                irows += 1;



                //while (pbExport.Value != pbExport.Maximum)
                //{
                //    pbExport.Value += 1;
                //}

            }

            //xl.Visible = true;
            //xl.ActiveWindow.SelectedSheets.PrintPreview();

            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string filename = path + "\\" + "ID - " + DateTime.Now.ToString("(MM.dd.yyyy.hh_mm_ss)") + ".xlsx";
            xl.ActiveWorkbook.SaveAs(filename);
            xl.DisplayAlerts = false;
            xb.Close();
            xl.Quit();



            foreach (Process proc in Process.GetProcessesByName("EXCEL"))
            {
                proc.Kill();
            }

            MessageBox.Show("The File Has Been Saved : \n" + filename, "File Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //pbExport.Value = 0;
            //gbExport.Visible = false;   

        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gvReport = new System.Windows.Forms.DataGridView();
            this.FirstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NickName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StudentID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Age = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Group = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Birthday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Export = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.gvReport)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gvReport
            // 
            this.gvReport.AllowUserToAddRows = false;
            this.gvReport.AllowUserToDeleteRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.LightSteelBlue;
            this.gvReport.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.gvReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvReport.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FirstName,
            this.LastName,
            this.NickName,
            this.StudentID,
            this.Age,
            this.Group,
            this.Birthday,
            this.ID});
            this.gvReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvReport.Location = new System.Drawing.Point(0, 0);
            this.gvReport.Name = "gvReport";
            this.gvReport.RowHeadersVisible = false;
            this.gvReport.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.gvReport.Size = new System.Drawing.Size(1231, 698);
            this.gvReport.TabIndex = 3;
            this.gvReport.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvReport_CellContentClick);
            // 
            // FirstName
            // 
            this.FirstName.HeaderText = "First Name";
            this.FirstName.Name = "FirstName";
            this.FirstName.ReadOnly = true;
            this.FirstName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.FirstName.Width = 200;
            // 
            // LastName
            // 
            this.LastName.HeaderText = "Last Name";
            this.LastName.Name = "LastName";
            this.LastName.ReadOnly = true;
            this.LastName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.LastName.Width = 200;
            // 
            // NickName
            // 
            this.NickName.HeaderText = "Nick Name";
            this.NickName.Name = "NickName";
            this.NickName.ReadOnly = true;
            this.NickName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.NickName.Width = 150;
            // 
            // StudentID
            // 
            this.StudentID.HeaderText = "Barcode";
            this.StudentID.Name = "StudentID";
            this.StudentID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.StudentID.Width = 150;
            // 
            // Age
            // 
            this.Age.HeaderText = "Age";
            this.Age.Name = "Age";
            this.Age.ReadOnly = true;
            this.Age.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Age.Width = 80;
            // 
            // Group
            // 
            this.Group.HeaderText = "Group";
            this.Group.Name = "Group";
            this.Group.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Birthday
            // 
            this.Birthday.HeaderText = "Birthday";
            this.Birthday.Name = "Birthday";
            this.Birthday.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Birthday.Width = 250;
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.Export);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 698);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1231, 51);
            this.panel1.TabIndex = 4;
            // 
            // Export
            // 
            this.Export.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Export.Location = new System.Drawing.Point(1144, 6);
            this.Export.Name = "Export";
            this.Export.Size = new System.Drawing.Size(75, 33);
            this.Export.TabIndex = 0;
            this.Export.Text = "Export";
            this.Export.UseVisualStyleBackColor = true;
            this.Export.Click += new System.EventHandler(this.button1_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 30000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // frmReport
            // 
            this.ClientSize = new System.Drawing.Size(1231, 749);
            this.Controls.Add(this.gvReport);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmReport";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmReport_FormClosed);
            this.Load += new System.EventHandler(this.frmReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvReport)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private void frmReport_Load_1(object sender, EventArgs e)
        {

        }

        private void frmReport_FormClosed(object sender, FormClosedEventArgs e)
        {
            timer1.Enabled = false;
        }
    }
}
