using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

 class InitialFetcher
{
     public InitialFetcher()
     {
         
     }
     public InitialFetcher(string FirstName,string LastName, int Relationship,int ContactID,Image Image)
     {
         this.FirstName = FirstName;
         this.LastName = LastName;
         this.Relationship = Relationship;
         this.ContactID = ContactID;
         this.Image = Image;
     }
     

     private string FirstName;
     private string LastName;
     private int Relationship;
     private int ContactID;
     private Image Image;
     private string Email;

     public void setFirstName(string FirstName)
     {
         this.FirstName = EscString(FirstName);
     }

     public void setLastName(string LastName)
     {
         this.LastName = EscString(LastName);
     }


     public void setRelationship(int Relationship)
     {
         this.Relationship = Relationship;
     }

     public void setContactID(int ContactID)
     {
         this.ContactID = ContactID;
     }

     public void setImage(Image Image)
     {
         this.Image = Image;
     }

     public void setEmail(string Email)
     {
         this.Email = EscString(Email);
     }

     private string EscString(string Str)
     {
         string str = Str.Replace("'", "''");

         return str;
     }

     public string SaveInfo(string Server = "") //saves the information of the Fetcher and return the ID from the database
     {
         Connector js;
         if (Server == "")
         {
             js = new Connector();
         }
         else
         {
             js = new Connector(Server, "Kids_Checkin", "kidchurch", "1nt3gr1ty@ENLI");
         }


         string fldPicture = this.FirstName + this.LastName + ".jpg";

         this.Image.Save(js.GetPath() + "/Fetchers/" + fldPicture);

         string q = "INSERT INTO tblFetcher(fldFirstName,fldLastName,fldContactDetails,fldRelationship,fldPicture,fldEmail)" +
                               " VALUES('" + this.FirstName + "','" + this.LastName + "','" + this.ContactID + "','" + this.Relationship + "','" + fldPicture + "','" + this.Email + "')";

         js.ExecuteNonQuery(q);

         q = "SELECT fldID FROM tblFetcher WHERE fldLastName='" + this.LastName + "' AND fldFirstName ='" + this.FirstName + "' AND fldPicture='" + fldPicture + "'";

         js.ExecuteQuery(q);

         js.RiD.Read();

         return js.RiD["fldID"].ToString();

     }



}
