using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillDdlBranch();
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (DropDownListBranch.SelectedIndex.Equals(0))
            return;
        if (!FileUploadPhoto.HasFile)
            return;
        FileUploadPhoto.SaveAs(Server.MapPath("~/Image/" + FileUploadPhoto.FileName));
        Student _student = new Student()
        {
            Adress = TextAdress.Text,
            Branch = DropDownListBranch.SelectedItem.Text,
            Email = TextEmail.Text,
            Name = TextBoxFirstName.Text + " " + TextBoxLastName.Text,
            password = TextPassword.Text,
            RegistrationNo = TextRegistrationNo.Text,
            PhoneNo = TextPhoneNo.Text,
            Photo = "~/Image/" + FileUploadPhoto.FileName
        };
        if (_student.InsertProfileData())
        {
           Response.Redirect("StudentHomePage.aspx?id="+_student.ID);
        }
        else
        {
            LabelErrorMsg.Text = "This Email ID already exists.";
        }
    }
    void FillDdlBranch()
    {
        string[] Branch = { "Select Branch", "ETC", "MECH", "CS", "IT", "CIVIL", "ELCTRICAL", "AUTOMOBILE" };
        foreach (var item in Branch)
        {
            //Branch Added
            DropDownListBranch.Items.Add(item);
        }
    }
}