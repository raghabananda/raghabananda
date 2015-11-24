using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class StudentLogInpage : System.Web.UI.Page
{
    Student _student = new Student();
   
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void BtnSubmit_Click(object sender, EventArgs e)
    {
       
     
            _student.Email = TextBoxEmail.Text;
            
       

        string str=_student.LogIn(TextBoxPassWord.Text.Trim());
       
        if (str.Equals("Password matches"))
        {
            Response.Redirect("~/StudentHomePage.aspx?id="+_student.ID);
        }
        else
            Label1.Text = str;
    }
}