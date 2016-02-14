using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;

namespace KIDS_CheckIn_System.volunteers
{
    class Volunteers
    {


        //Connection Properties
        SqlConnection connection = null;
        SqlCommand command = new SqlCommand();
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

        Database db;
        public Volunteers()
        {
            db = DatabaseFactory.CreateDatabase();
            this.connection = db.CreateConnection() as SqlConnection;
        }

        public Volunteers(string fldID)
        {

            IDataReader reader;
            string sql = "SELECT * FROM tblVolunteers WHERE fldID='" + fldID + "'";


            using (reader = this.db.ExecuteReader(System.Data.CommandType.Text, sql))
            {
                while (reader.Read())
                {
                    this.FirstName = reader.GetString(reader.GetOrdinal("fldFirstName"));
                    this.LastName = reader.GetString(reader.GetOrdinal("fldLastName"));
                    this.NickName = reader.GetString(reader.GetOrdinal("fldNickName"));
                    this.NameOnID = reader.GetString(reader.GetOrdinal("fldNameOnID"));
                    this.Street = reader.GetString(reader.GetOrdinal("fldStreet"));
                    this.City = reader.GetString(reader.GetOrdinal("fldCity"));
                    this.Mobile = reader.GetString(reader.GetOrdinal("fldMobile"));
                    this.Email = reader.GetString(reader.GetOrdinal("fldEmail"));
                    //this.Service = int.Parse("" + reader["fldService"]);
                    ////this.Week = "" + reader["fldWeek"];
                    //this.Class = int.Parse("" + reader["fldClass"]);
                    this.VGL = reader.GetString(reader.GetOrdinal("fldVGL"));
                    this.VGLContact = reader.GetString(reader.GetOrdinal("fldVGLContact"));
                    this.Leading = reader.GetBoolean(reader.GetOrdinal("fldLeading"));
                    this.ID = fldID;
                    this.NFCCode = reader.GetString(reader.GetOrdinal("fldNFCCode"));
                    this.PicPath = reader.GetString(reader.GetOrdinal("fldPicture"));
                }
            }
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
            string sql = "INSERT INTO tblVolunteers(fldFirstName,fldLastName,fldNickName,fldNameOnID,fldService,fldWeek,fldClass,fldStreet,fldCity,fldEmail,fldMobile,fldVGL,fldVGLContact,fldLeading,fldPicture) VALUES('" + 
                         FirstName + "','" + LastName + "','" + NickName + "','" + NameOnID + "','" + Service + "','" + Week + "','" + Class + "','" + Street  + "','" + City + "','" + Email + "','" + Mobile + "','" + VGL + "','" + VGLContact + "','" + Leading + "','" + PicPath +  "')";

            DbCommand cmd = db.GetSqlStringCommand(sql);
            int result =  db.ExecuteNonQuery(cmd);
            cmd.Dispose();
            return result > 0;
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

            DbCommand cmd = db.GetSqlStringCommand(sql);
            int result = db.ExecuteNonQuery(cmd);
            cmd.Dispose();
            return result > 0;

        }


    }
}
