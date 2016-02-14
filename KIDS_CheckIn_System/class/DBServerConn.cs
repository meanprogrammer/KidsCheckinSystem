using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

 public class Connector2
{
     static private string DBServer = "ENPRDDB3";
     static private string DBase = "Kids_Checkin";
     static private string DBUser = "kidschurch";
     static private string DBPass = "1nt3gr1ty@ENLI";

    static private string connectionstring = "Server=" + DBServer + ";Database=" + DBase + "Integrated Security=true;";

     static private SqlConnection connection = new SqlConnection(connectionstring);
     static private SqlCommand command = new SqlCommand();
     public SqlDataReader RiD;



     public void ExecuteQuery(string Query)
     {

         if (connection.State == System.Data.ConnectionState.Open)
         {
             connection.Close();
         }
         
         connection.Open();
         command.Connection = connection;
         command.CommandText = Query;

         RiD = command.ExecuteReader();

     }

     public void ExecuteNonQuery(string Query)
     {
         if (connection.State == System.Data.ConnectionState.Open)
         {
             connection.Close();
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


        


}

