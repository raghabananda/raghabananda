using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class StudentHomePage : System.Web.UI.Page
{
    Student _student = new Student();
    public int Subject_ID
    {
        get 
        {
            return DropDownListSubject.SelectedIndex;
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
           
                FillDdlSemistar();
                FillDdlSubject();
                DropDownListSubject.Items.Insert(0, "Select Subject");
                /*-------------------Load AttendanceGrid & Studen Details-------------------*/
               // StudentLogInpage previousPage = (StudentLogInpage)Page.PreviousPage;
                _student.ID =Request.QueryString["id"].ToString();
                _student.SelectStudentData();
                GetDetails();
               // LoadAttendanceStatus();
                /*-------------------Load AttendanceGrid-------------------*/
                GridView1.Visible = false;
           
        }
        //LoadAttendanceStatus();
    }
    void GetDetails()
    {
        Image1.ImageUrl = _student.Photo;
        LabelName.Text = _student.Name;
        LabeEmail.Text = _student.Email;
        LabelPhone.Text = _student.PhoneNo;
        LabelAdress.Text = _student.Adress;
        LabelRegistrationNo.Text = _student.RegistrationNo;
    }
    protected void LinkBtnEditProfile_Click(object sender, EventArgs e)
    {
        Panel1.Visible = false;
        Panel3.Visible = false;
        Panel2.Visible = true;
    }
    void LoadAttendanceStatus()
    {
        Subject _subject = new Subject()
        {
            SubjectName = DropDownListSubject.SelectedItem.Text
        };
        string _subjectid = _subject.SelectSubJectIDByData();
        if(!DropDownListSubject.SelectedIndex.Equals(0))
        {
            Attendance _Attendance = new Attendance()
            {
                ID = Request.QueryString["id"].ToString(),
                SubjectID = Convert.ToInt32(_subjectid)
            };
           GridView1.DataSource= _Attendance.SelectAttendanceDataByID();
           GridView1.DataBind();
        }
       
        
    }

    protected void DropDownListSemistar_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDownListSemistar.SelectedIndex.Equals(0))
        {
            DropDownListSubject.Items.Clear();
            DropDownListSubject.Items.Insert(0, "Select Subject");
        }
        else
        {
            Subject _subject = new Subject()
            {
                Semistar = DropDownListSemistar.SelectedIndex,
                Branch = DropDownListBranch.SelectedItem.Text
            };
            List<string> SubjectList = _subject.SelectSubJectDataBySemistar();
            foreach (var item in SubjectList)
            {
                DropDownListSubject.Items.Add(item);
            }
        }

    }
    protected void DropDownListBranch_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownListSubject.Items.Clear();
        DropDownListSubject.Items.Insert(0, "Select Subject");
        if (DropDownListBranch.SelectedIndex == 0)
        {
            DropDownListSemistar.Items.Clear();
            DropDownListSemistar.Items.Insert(0, "Select Semistar");
        }
        else
        {
            DropDownListSemistar.Items.Clear();
            FillDdlSemistar();
        }
    }
    protected void ButtonSubmit_Click(object sender, EventArgs e)
    {
        GridView1.Visible = true;
        LoadAttendanceStatus();
    }
    void FillDdlSemistar()
    {
        string[] Semistar = { "Select Semistar", "1st Sem", "2nd Sem", "3rd Sem", "4th Sem", "5th Sem", "6th Sem", "7th Sem", "8th Sem" };
        for (int i = 0; i < Semistar.Length; i++)
        {
            DropDownListSemistar.Items.Insert(i, Semistar[i]);
        }


    }
    void FillDdlSubject()
    {
        string[] Branch = { "Select Branch", "ETC", "MECH", "CS", "IT", "CIVIL", "ELCTRICAL", "AUTOMOBILE" };
        foreach (var item in Branch)
        {
            //Branch Added
            DropDownListBranch.Items.Add(item);
        }
    }
}