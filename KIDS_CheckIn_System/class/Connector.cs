using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.IO;
using System.Drawing;

 public class Connector
{
     
     static private string DBServer = AccessRegistryTool.ReadValue("DBServer");
     static private string DBase = "Kids_Checkin";
     static private string DBUser = "kidschurch";
     static private string DBPass = "1nt3gr1ty@ENLI";

     static private string connectionstring = "Server=" + DBServer + ";Database=" + DBase + ";User Id=" + DBUser + ";Password=" + DBPass + ";";

     static private SqlConnection connection = new SqlConnection(connectionstring);
     static private SqlCommand command = new SqlCommand();
     public SqlDataReader RiD;

     public Connector()
     {

     }

     public Connector(string Server,string Database,string User,string Password)
     {
         connectionstring = "Server=" + Server + ";Database=" + Database + ";User Id=" + User + ";Password=" + Password + ";";
         connection = new SqlConnection(connectionstring);
     }



     public void ExecuteQuery(string Query)
     {

         if (connection.State == System.Data.ConnectionState.Open)
         {
             connection.Close();
             connection.ConnectionString = connectionstring;
             
         }
         else
         {
             connection.ConnectionString = connectionstring;
         }

         try
         {
             connection.Open();
         }
         catch(Exception ex)
         {

         }
       
         
         command.Connection = connection;
         command.CommandText = Query;

         RiD = command.ExecuteReader();

     }

     public void ExecuteNonQuery(string Query)
     {
         if (connection.State == System.Data.ConnectionState.Open)
         {
             connection.Close();
             connection.ConnectionString = connectionstring;

         }
         else
         {
             connection.ConnectionString = connectionstring;
         }

         connection.Open();
         command.Connection = connection;
         command.CommandText = Query;

         command.ExecuteNonQuery();
     }

     public void CloseConnection()
     {
         RiD.Close();
         command.Dispose();
         connection.Close();
     }


     public string Lookup(string Field,string Table,string Criteria = "")
     {
         string query = "";
         string cnstr = connectionstring;
         SqlConnection conn = new SqlConnection(connectionstring);
         SqlCommand comm = new SqlCommand();
         SqlDataReader reader;

         if (Criteria=="")
         {
             query = "SELECT " + Field + " as lookup FROM " + Table;
         }
         else
         {
             query = "SELECT " + Field + " as lookup FROM " + Table + " WHERE " + Criteria;
         }

         if(conn.State == System.Data.ConnectionState.Open)
         {
             conn.Close();
         }
         conn.Open();

         comm.Connection = conn;
         comm.CommandText = query;

         reader = comm.ExecuteReader();
         reader.Read();

         string lookup = "";

         if (reader.HasRows)
         {
             lookup = reader["lookup"].ToString();
         }
         else
         {
             lookup = "";
         }

         reader.Close();
         comm.Dispose();
         conn.Close();

         return lookup;
     }


 
     public string GetServerName(){
         string server = "";

         server = AccessRegistryTool.ReadValue("DBServer");

        return server;
     }

     public Int32 GetAge(DateTime dateOfBirth)
     {
         var today = DateTime.Today;

         var tYear = today.Year;
         var bYear = dateOfBirth.Year;

         var age = tYear - bYear;

         if(dateOfBirth<=today)
         {
             if (Convert.ToDateTime(dateOfBirth.ToString("MM/dd")) <= Convert.ToDateTime(today.ToString("MM/dd")))
             {
                 return age;
             }
             else
             {
                 return age - 1;
             }
             
         }
         else
         {
             return age - 1;
         }
     }


     public string GetPath()
     {
         string strPath = "";

         strPath = AccessRegistryTool.ReadValue("PicPath");

         return strPath;
     }

     public void showExclamation(string msg = "", string title = "Kids Check-In System")
     {
         MessageBox.Show(msg,title, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
     }

     public void showInformation(string msg = "", string title = "Kids Check-In System")
     {
         MessageBox.Show(msg, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
     }

     public DialogResult showQuestion(string msg="",string title ="Kids Check-In System")
     {
         return MessageBox.Show(msg, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
     }


     

     public DialogResult InputBox(string title, string promptText, ref string value)
     {
         Form form = new Form();
         Label label = new Label();
         TextBox textBox = new TextBox();
         Button buttonOk = new Button();
         Button buttonCancel = new Button();

         form.Text = title;
         label.Text = promptText;
         textBox.Text = value;

         buttonOk.Text = "OK";
         buttonCancel.Text = "Cancel";
         buttonOk.DialogResult = DialogResult.OK;
         buttonCancel.DialogResult = DialogResult.Cancel;

         label.SetBounds(9, 20, 372, 13);
         textBox.SetBounds(12, 36, 372, 20);
         buttonOk.SetBounds(228, 72, 75, 23);
         buttonCancel.SetBounds(309, 72, 75, 23);

         label.AutoSize = true;
         textBox.Anchor = textBox.Anchor | AnchorStyles.Right;
         buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
         buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

         form.ClientSize = new Size(396, 107);
         form.Controls.AddRange(new Control[] { label, textBox, buttonOk, buttonCancel });
         form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
         form.FormBorderStyle = FormBorderStyle.FixedDialog;
         form.StartPosition = FormStartPosition.CenterScreen;
         form.MinimizeBox = false;
         form.MaximizeBox = false;
         form.AcceptButton = buttonOk;
         form.CancelButton = buttonCancel;

         DialogResult dialogResult = form.ShowDialog();
         value = textBox.Text;
         return dialogResult;
     }

}

