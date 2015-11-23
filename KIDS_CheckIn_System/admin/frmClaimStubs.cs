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
    public partial class frmClaimStubs : Form
    {
        Connector con = new Connector();
        public frmClaimStubs()
        {
            InitializeComponent();
        }

        private void frmClaimStubs_Load(object sender, EventArgs e)
        {

            timer1.Enabled = true;
            string qry = "";

            qry = "select fldID, fldFirstName, fldLastName, fldNickName, fldStudentID, fldBirthday, fldDateTime from tblKids where fldUpdateStatus = 2 AND fldClaimStub=1 order by fldDateTime DESC";

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

                gvReport.Rows.Add(con.RiD["fldFirstName"], con.RiD["fldLastName"], con.RiD["fldNickName"], "*" + con.RiD["fldStudentID"] + "*", age, group, birthday, false);


            }

            con.CloseConnection();

           
        }

        private void gvReport_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(gvReport.CurrentCell.ColumnIndex==7)
            {
                if(gvReport.CurrentCell.Value.ToString()==false.ToString())
                {
                    gvReport.CurrentCell.Value = true;

                    string qry = "";
                    string studentID = gvReport.CurrentRow.Cells["StudentID"].Value.ToString();
                    studentID = studentID.Replace("*", "");

                    qry = "Update tblKids SET fldClaimStub =0 where fldStudentID = '" + studentID + "'";

                    string q = qry;

                    con.ExecuteNonQuery(q);
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            frmClaimStubs_Load(null, null);
        }

        private void frmClaimStubs_FormClosed(object sender, FormClosedEventArgs e)
        {
            timer1.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string strPath = System.Windows.Forms.Application.StartupPath + "\\Exported File\\ClaimStub.xlsx";

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
            string filename = path + "\\" + "ClaimStubs - " + DateTime.Now.ToString("(MM.dd.yyyy.hh_mm_ss)") + ".xlsx";
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
    }
}
