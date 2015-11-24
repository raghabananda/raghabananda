using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminLogIn : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillDdlSemistar();
            FillDdlSubject();
            DropDownListSubject.Items.Insert(0, "Select Subject");
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
    protected void LinkBtnLogout_Click(object sender, EventArgs e)
    {
        Label1.Text = string.Empty;
        PanelLogIn.Visible = true;
        PanelAttendanceSheet.Visible = false;
        LinkBtnHome.Visible = false;
        LinkBtnLogout.Visible = false;
        ResetDropDownist();
    }
    protected void BtnLogIn_Click(object sender, EventArgs e)
    {
        Admin _admin = new Admin()
        {
            Email=TextBoxAdminId.Text,
            Password=TextBoxPassWord.Text
        };
        if (_admin.AdminAuthentication)
        {
            PanelLogIn.Visible = false;
            PanelAttendanceSheet.Visible = true;
            PanelAttendanceSheet1.Visible = true;
            LinkBtnLogout.Visible = true;
            PanelAttendanceSheet2.Visible = false;
        }
        else
        {
            Label1.Text = "Incorrect Email ID or Password ";
        }
    }
    void FillDdlSemistar()
    {
        string[] Semistar = {"Select Semistar", "1st Sem", "2nd Sem", "3rd Sem", "4th Sem", "5th Sem", "6th Sem", "7th Sem", "8th Sem" };
        for (int i = 0; i < Semistar.Length; i++)
        {
            DropDownListSemistar.Items.Insert(i,Semistar[i]);
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
   
    protected void LinkBtnHome_Click(object sender, EventArgs e)
    {
        PanelAttendanceSheet1.Visible = true;
        PanelAttendanceSheet2.Visible = false;
        LinkBtnHome.Visible = false;
    }
    protected void BtnSubmit1_Click(object sender, EventArgs e)
    {
        PanelAttendanceSheet1.Visible = false;
        LinkBtnHome.Visible = PanelAttendanceSheet2.Visible=true;
        DbLayer _Db=new DbLayer();
        GridViewAttendanceSheet.DataSource = _Db.LoadAttendanceGrid(DropDownListSemistar.SelectedIndex,DropDownListBranch.SelectedItem.Text);
        GridViewAttendanceSheet.DataBind();
    }
    void ResetDropDownist()
    {
        DropDownListBranch.SelectedIndex = 0;
        DropDownListSemistar.Items.Clear();
        DropDownListSemistar.Items.Insert(0, "Select Semistar");
        DropDownListSubject.Items.Clear();
        DropDownListSubject.Items.Insert(0, "Select Subject");

    }
    protected void ButtonSubmitAttendance_Click(object sender, EventArgs e)
    {
        Subject _subject = new Subject()
        {
             SubjectName=DropDownListSubject.SelectedItem.Text
        };
        string _subjectid=_subject.SelectSubJectIDByData();
        foreach (GridViewRow row in GridViewAttendanceSheet.Rows)
        {
            CheckBox ChkBox = (CheckBox)row.FindControl("CheckBoxStatus");
            Label lbl = (Label)row.FindControl("LabelID");
            Attendance _Attendance = new Attendance()
                {
                    ID = lbl.Text,
                    Status = ChkBox.Checked,
                    SubjectID = Convert.ToInt32(_subjectid),
                    Date=DateTime.Now.ToShortDateString()
                };
            _Attendance.InsertAttendance();
        }
        PanelAttendanceSheet2.Visible = false;
        PanelAttendanceSheet1.Visible = true;
        ResetDropDownist();
    }
}