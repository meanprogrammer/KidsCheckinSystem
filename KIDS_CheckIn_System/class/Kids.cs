using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Kids
{
    public Kids()
    {

    }

    public Kids(string FirstName, string LastName,string NickName, DateTime Birthday,int Gender)
    {

        this.FirstName = FirstName;
        this.LastName = LastName;
        this.NickName = NickName;
        this.BirthDay = Birthday;
        this.Gender = Gender;


    }


    private string FirstName;
    private string LastName;
    private string NickName;
    private DateTime BirthDay;
    private string StudentID;
    private string ChurchID;
    private int Gender;
    private System.Drawing.Image img;
    private string Allergies;

    public void setFirstName(string FirstName)
    {
        this.FirstName = EscString(FirstName);
    }
    public void setLastName(string LastName)
    {
        this.LastName = EscString(LastName);
    }

    public void setNickName(string NickName)
    {
        this.NickName = EscString(NickName);
    }

    public void setBirthday(DateTime BirthDay)
    {
        this.BirthDay = BirthDay;
    }

    public void GenerateStudentID()
    {
        this.StudentID = getStudentID();
    }

    public void setImage(System.Drawing.Image img)
    {
        this.img = img;
    }

    public void setGender(int Gender)
    {
        this.Gender = Gender;
    }
    public void setAllergies(string Allergies)
    {
        this.Allergies = EscString(Allergies);
    }

    private string EscString(string Str)
    {
        string str = Str.Replace("'","''");

        return str;
    }

    public string SaveInfo(string Server="") //saves the information of the Kid and return the ID from the database
    {
        Connector js;
        if(Server=="")
        {
            js = new Connector();
        }
        else
        {
            js = new Connector(Server, "Kids_Checkin", "kidschurch", "1nt3gr1ty@ENLI"); 
        }
        

        string fldPicture = this.FirstName + this.LastName + ".jpg";

        this.img.Save(js.GetPath() + "/Kids/" + fldPicture);

        
        string q = "INSERT INTO tblKids(fldStudentID,fldFirstName,fldLastName,fldNickName,fldBirthday,fldChurch,fldDateCreated,fldPicture,fldGender,fldAllergies)" +
                    " VALUES('" + this.StudentID + "','" + this.FirstName + "','" + this.LastName + "','" +  this.NickName + "','" + this.BirthDay + "','" + this.ChurchID + "','" + DateTime.Now.ToShortDateString() + "','" +  fldPicture + "','" + this.Gender + "','" + this.Allergies + "')";

        js.ExecuteNonQuery(q);

        q = "SELECT fldID FROM tblKids WHERE fldStudentID='" + this.StudentID + "'";

        js.ExecuteQuery(q);

        js.RiD.Read();

        return js.RiD["fldID"].ToString();

    }

    public void GetChurchID()
    {
        Connector js = new Connector();

        this.ChurchID = js.Lookup("fldID", "tblChurch", "fldActive=1");
    }

    public string getStudentID()
     {
         string barcode = "";
         Connector conn = new Connector();

         string churchcode = String.Format("{0:00}",Convert.ToInt32(conn.Lookup("fldID", "tblChurch", "fldActive='1'")));
         string dt = DateTime.Now.ToString("yyMMddmmss");

         barcode = churchcode + dt;


         return barcode;
     }
}

