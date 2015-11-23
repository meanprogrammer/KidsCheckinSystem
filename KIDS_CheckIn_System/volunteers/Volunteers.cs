using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace KIDS_CheckIn_System.volunteers
{
    class Volunteers
    {
        //Connection Properties
        SqlConnection connection = new SqlConnection();
        SqlCommand command = new SqlCommand();
        string connectionstring = "Server=" + AccessRegistryTool.ReadValue("DBServer") + ";Database=Kids_Checkin;User ID=kidschurch;Password=1nt3gr1ty@ENLI;";


        //Volunteer Info
        private string FirstName = "";
        private string LastName = "";
        private string NickName = "";
        private string NameOnID = "";

        //Volunteer Commitment
        private int Service = 0;
        private string Week = "";
        private int Class = 0;

        //Address
        private string Street = "";
        private string City = "";
        
        //Contact Details
        private string Email = "";
        private string Mobile = "";

        //Victory Group Details
        private string VGL = "";
        private string VGLContact = "";
        private bool Leading = false;


        private string ID = "";
        private string NFCCode = "";
        private string PicPath = "";

        public Volunteers()
        {

        }

        public Volunteers(string fldID)
        {
            SqlDataReader reader;
            string sql = "SELECT * FROM tblVolunteers WHERE fldID='" + fldID + "'";

            connection = new SqlConnection(connectionstring);
            connection.Open();
            command.Connection = connection;
            command.CommandText = sql;

            reader = command.ExecuteReader();

            reader.Read();
            if(reader.HasRows)
            {
                this.FirstName = "" + reader["fldFirstName"];
                this.LastName = "" + reader["fldLastName"];
                this.NickName = "" + reader["fldNickName"];
                this.NameOnID = "" + reader["fldNameOnID"];
                this.Street = "" + reader["fldStreet"];
                this.City = "" + reader["fldCity"];
                this.Mobile = "" + reader["fldMobile"];
                this.Email = "" + reader["fldEmail"];
                //this.Service = int.Parse("" + reader["fldService"]);
                ////this.Week = "" + reader["fldWeek"];
                //this.Class = int.Parse("" + reader["fldClass"]);
                this.VGL = "" + reader["fldVGL"];
                this.VGLContact = "" + reader["fldVGLContact"];
                this.Leading = bool.Parse("" + reader["fldLeading"]);
                this.ID = fldID;
                this.NFCCode = "" + reader["fldNFCCode"];
                this.PicPath = "" + reader["fldPicture"];
            }

            command.Dispose();
            connection.Close();
        }



        public void setName(string FirstName, string LastName, string NickName, string NameOnID)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.NickName = NickName;
            this.NameOnID = NameOnID;
        }

        public void setAddress(string Street, string City)
        {
            this.Street = Street;
            this.City = City;
        }

        public void setContact(string Email, string Mobile) 
        {
            this.Email = Email;
            this.Mobile = Mobile;
        }

        public void setVGDetails(string VGL, string VGLContact, bool Leading)
        {
            this.VGL = VGL;
            this.VGLContact = VGLContact;
            this.Leading = Leading;
        }

        public void setNFCCode(string NFCCode)
        {
            this.NFCCode = NFCCode;
        }

        public void setServiceDetails(int Service,string Week,int Class)
        {
            this.Service = Service;
            this.Week = Week;
            this.Class = Class;
        }

        public void setPicPath(string PicPath)
        {
            this.PicPath = PicPath;
        }


        public bool Save()
        {
            connection = new SqlConnection(connectionstring);
            connection.Open();

            command.Connection = connection;

            string sql = "INSERT INTO tblVolunteers(fldFirstName,fldLastName,fldNickName,fldNameOnID,fldService,fldWeek,fldClass,fldStreet,fldCity,fldEmail,fldMobile,fldVGL,fldVGLContact,fldLeading,fldPicture) VALUES('" + 
                         FirstName + "','" + LastName + "','" + NickName + "','" + NameOnID + "','" + Service + "','" + Week + "','" + Class + "','" + Street  + "','" + City + "','" + Email + "','" + Mobile + "','" + VGL + "','" + VGLContact + "','" + Leading + "','" + PicPath +  "')";

            command.CommandText = sql;

            if(command.ExecuteNonQuery()==0)
            {
                command.Dispose();
                connection.Close();
                return false;
            }
            else
            {
                command.Dispose();
                connection.Close();
                return true;
            }

           

        }

        public string getFirstName() { return this.FirstName; }
        public string getLastName() { return this.LastName; }
        public string getNickName() { return this.NickName; }
        public string getNameOnID() { return this.NameOnID; }
        public string getStreet() { return this.Street; }
        public string getCity() { return this.City; }
        public string getMobile() { return this.Mobile; }
        public string getEmail() { return this.Email; }
        public int getService() { return this.Service; }
        public string getWeek() { return this.Week; }
        public int getClass() { return this.Class; }
        public string getVGL() { return this.VGL; }
        public string getVGLContact() { return this.VGLContact; }
        public bool getLeading() { return this.Leading; }
        public string getNFCCode() { return this.NFCCode; }
        public string getPicPath() { return this.PicPath; }

        public bool Update()
        {
            string sql = "UPDATE tblVolunteers SET fldFirstName='" + FirstName + "',fldLastName='" + LastName + "',fldNickName='" + NickName + "',fldNameOnID='" + NameOnID +
                        "',fldStreet='" + Street + "',fldCity='" + City + "',fldService='" + Service + "',fldWeek='" + Week + "',fldClass='" + Class + "',fldVGL='" + VGL + "',fldVGLContact='" +
                        VGLContact + "',fldLeading='" + Leading + "',fldNFCCode='" + NFCCode + "',fldActive=1,fldPicture='" + PicPath + "' WHERE fldID='" + ID  + "'";

            connection = new SqlConnection(connectionstring);
            connection.Open();

            command.CommandText = sql;
            command.Connection = connection;

            if (command.ExecuteNonQuery() == 0)
            {
                command.Dispose();
                connection.Close();
                return false;
            }
            else
            {
                command.Dispose();
                connection.Close();
                return true;
            }

           
        }


    }
}
