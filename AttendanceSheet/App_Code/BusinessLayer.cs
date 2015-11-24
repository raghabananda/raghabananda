using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public partial class Complain : Student
{
    public int complain { get; set; }

    public DateTime Date { get; set; }


    public int Semistar { get; set; }



}
public class Admin
{
    public string Admin_Email
    {
        get
        {
            return "Admin@mycollege.com";
        }
    }
    public string Admin_Password
    {
        get
        {
            return "adminpass";
        }
    }
    public string Email { get; set; }
    public string Password { get; set; }
    public Boolean AdminAuthentication
    {
        get
        {
            return (this.Admin_Email.Equals(this.Email)) && (this.Admin_Password.Equals(this.Password));
        }
    }
}
  
        
    
   
   




   

