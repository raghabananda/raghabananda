using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;




public class DbLayer 
{
    public string connectionString = "Data Source=RAGHAB-PC;Initial Catalog=AttendanceSystem;Integrated Security=True";
    string AttendanceGridSql = "SELECT StudentProfile.ID, StudentProfile.Name, StudentProfile.RegistrationNo FROM Semistar INNER JOIN StudentProfile ON Semistar.StudentID = StudentProfile.ID WHERE Semistar.Semistar=@Semistar AND StudentProfile.Branch=@Branch";

    protected string DeleteCommandAttendanceStatus = "DELETE FROM [AttendanceStatus] WHERE [AttenStatusId] = @AttenStatusId";
    protected string InsertCommandAttendanceStatus = "INSERT INTO [AttendanceStatus] ([StudentID], [SubjectID], [Status], [Date]) VALUES (@StudentID, @SubjectID, @Status, @Date)";
    protected string SelectCommandAttendanceStatus = "SELECT [AttenStatusId], [StudentID], [SubjectID], [Status], [Date] FROM [AttendanceStatus]";
    protected string UpdateCommandAttendanceStatus = "UPDATE [AttendanceStatus] SET [StudentID] = @StudentID, [SubjectID] = @SubjectID, [Status] = @Status, [Date] = @Date WHERE [AttenStatusId] = @AttenStatusId";

    protected string DeleteCommandStudentProfile = "DELETE FROM [StudentProfile] WHERE [ID] = @ID";
    protected string InsertCommandStudentProfile = "INSERT INTO [StudentProfile] ([Name], [RegistrationNo], [Email], [Branch], [password], [PhoneNo], [Adress], [Photo]) VALUES (@Name, @RegistrationNo, @Email, @Branch, @password, @PhoneNo, @Adress, @Photo)";
    protected string SelectCommandStudentProfile = "SELECT [ID], [Name], [RegistrationNo], [Email], [Branch], [password], [PhoneNo], [Adress], [Photo] FROM [StudentProfile]";
    protected string UpdateCommandStudentProfile = "UPDATE [StudentProfile] SET [Name] = @Name, [RegistrationNo] = @RegistrationNo, [Email] = @Email, [Branch] = @Branch, [password] = @password, [PhoneNo] = @PhoneNo, [Adress] = @Adress, [Photo] = @Photo WHERE [ID] = @ID";

    protected string DeleteCommandSubject = "DELETE FROM [Subject] WHERE [Subject_Id] = @Subject_Id";
    protected string InsertCommandSubject = "INSERT INTO [Subject] ([SubjectName], [Branch], [Semistar]) VALUES (@SubjectName, @Branch, @Semistar)";
    protected string SelectCommandSubject = "SELECT [Subject_Id], [SubjectName], [Branch], [Semistar] FROM [Subject]";
    protected string UpdateCommandSubject = "UPDATE [Subject] SET [SubjectName] = @SubjectName, [Branch] = @Branch, [Semistar] = @Semistar WHERE [Subject_Id] = @Subject_Id";

    string DeleteCommandComplainTable = "DELETE FROM [ComplainTable] WHERE [ComplianID] = @ComplianID";
    string InsertCommandComplainTable = "INSERT INTO [ComplainTable] ([StudentID], [complain], [Date], [Semistar]) VALUES (@StudentID, @complain, @Date, @Semistar)";
    string SelectCommandComplainTable = "SELECT [ComplianID], [StudentID], [complain], [Date], [Semistar] FROM [ComplainTable]";
    string UpdateCommandComplainTable = "UPDATE [ComplainTable] SET [StudentID] = @StudentID, [complain] = @complain, [Date] = @Date, [Semistar] = @Semistar WHERE [ComplianID] = @ComplianID";

   public DataSet LoadAttendanceGrid(int Semistar,string Branch)
    {       
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            SqlCommand cmd = new SqlCommand(AttendanceGridSql, con);
            cmd.Parameters.AddWithValue("@Semistar", Semistar);
            cmd.Parameters.AddWithValue("@Branch",Branch);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            con.Open();
            da.Fill(ds);
            return ds;
        }
    }
}
public partial class Student : DbLayer
{
    bool CheckIdByEmail()
    {
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT [ID] FROM [StudentProfile] WHERE [Email] = @Email";
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@Email", this.Email);

            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count>0)
            {
               
                this.ID = (ds.Tables[0].Rows[0]["ID"]).ToString();
                return true;
            }
            else
            {
                this.ID = string.Empty;
                return false;
            }
        }
    }

    public bool InsertProfileData()
    {
        
        if (!CheckIdByEmail())
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(InsertCommandStudentProfile + "SELECT SCOPE_IDENTITY() AS I", con);

                cmd.Parameters.AddWithValue("@Name", this.Name);
                cmd.Parameters.AddWithValue("@RegistrationNo", this.RegistrationNo);
                cmd.Parameters.AddWithValue("@Email", this.Email);
                cmd.Parameters.AddWithValue("@Branch", this.Branch);
                cmd.Parameters.AddWithValue("password", this.password);
                cmd.Parameters.AddWithValue("@PhoneNo", this.PhoneNo);
                cmd.Parameters.AddWithValue("@Adress", this.Adress);
                cmd.Parameters.AddWithValue("@Photo", this.Photo);

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    this.ID = dr["I"].ToString();
                }
                return true;
            }
        }
        else
            return false;
    }

    public string LogIn(string PassWord)
    {
        // throw new System.NotImplementedException();
        if (CheckIdByEmail())
        {
            this.SelectStudentData();
            if (PassWord.Equals(this.password))
                return "Password matches";
            else
                return "Incorrect PassWord";
        }
        return "EmailID does not exist.";
    }

    public void UpdateStudentProfile()
    {

        // throw new System.NotImplementedException();
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            SqlCommand cmd = new SqlCommand(UpdateCommandStudentProfile, con);


            cmd.Parameters.AddWithValue("@@ID", this.ID);
            cmd.Parameters.AddWithValue("@Name", this.Name);
            cmd.Parameters.AddWithValue("@RegistrationNo", this.RegistrationNo);
            cmd.Parameters.AddWithValue("@Email", this.Email);
            cmd.Parameters.AddWithValue("@Branch", this.Branch);
            cmd.Parameters.AddWithValue("password", this.password);
            cmd.Parameters.AddWithValue("@PhoneNo", this.PhoneNo);
            cmd.Parameters.AddWithValue("@Adress", this.Adress);
            cmd.Parameters.AddWithValue("@Photo", this.Photo);

            con.Open();
            cmd.ExecuteNonQuery();
        }
    }

    public void SelectStudentData()
    {
        //throw new System.NotImplementedException();
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            SqlCommand cmd = new SqlCommand(SelectCommandStudentProfile+" WHERE [ID] = @ID",con);
            cmd.Parameters.AddWithValue("@ID",this.ID);
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                this.ID = rdr["ID"].ToString();
                this.Name = rdr["Name"].ToString();
                this.RegistrationNo = rdr["RegistrationNo"].ToString();
                this.Email = rdr["Email"].ToString();
                this.Branch = rdr["Branch"].ToString();
                this.password = rdr["password"].ToString();
                this.PhoneNo = rdr["PhoneNo"].ToString();
                this.Adress = rdr["Adress"].ToString();
                this.Photo = rdr["Photo"].ToString();
                this.Name = rdr["Name"].ToString();
            }
           
        }
    }
}
public partial class Subject : DbLayer
{
    public void InsertSubjectData()
    {
        //([SubjectName], [Branch], [Semistar]) VALUES (@SubjectName, @Branch, @Semistar)"
       // throw new System.NotImplementedException();
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            SqlCommand cmd = new SqlCommand(InsertCommandSubject,con);

            cmd.Parameters.AddWithValue("@SubjectNam",this.SubjectName);
            cmd.Parameters.AddWithValue("@Branch",this.Branch);
            cmd.Parameters.AddWithValue("@Semistar",this.Semistar);

            con.Open();
            cmd.ExecuteNonQuery();
        }
    }

    public void UpdateSubjectData()
    {
        throw new System.NotImplementedException();
    }

    public void DelteSubjectData()
    {
        throw new System.NotImplementedException();
    }

    public string SelectSubJectIDByData()
    {
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            SqlCommand cmd = new SqlCommand(SelectCommandSubject + " WHERE [SubjectName] = @SubjectName", con);
            cmd.Parameters.AddWithValue("@SubjectName", this.SubjectName);
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds.Tables[0].Rows[0]["Subject_Id"].ToString();
        }
    }
    public List<string> SelectSubJectDataBySemistar()
    {
        List<string> subjectList = new List<string>();
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            SqlCommand cmd = new SqlCommand(SelectCommandSubject + " WHERE [Semistar] = @Semistar AND  [Branch] = @Branch", con);
            cmd.Parameters.AddWithValue("@Semistar", this.Semistar);
            cmd.Parameters.AddWithValue("@Branch",this.Branch);
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            if(rdr!=null)
            while (rdr.Read())
            {
                subjectList.Add(rdr["SubjectName"].ToString());
            }
            return subjectList;
        }
    }
}
public partial class Complain 
{
   // string  DeleteCommand="DELETE FROM [ComplainTable] WHERE [ComplianID] = @ComplianID";
    string InsertCommand="INSERT INTO [ComplainTable] ([StudentID], [complain], [Date], [Semistar]) VALUES (@StudentID, @complain, @Date, @Semistar)";
    string SelectCommand="SELECT [ComplianID], [StudentID], [complain], [Date], [Semistar] FROM [ComplainTable]";
   // string UpdateCommand="UPDATE [ComplainTable] SET [StudentID] = @StudentID, [complain] = @complain, [Date] = @Date, [Semistar] = @Semistar WHERE [ComplianID] = @ComplianID";
   
    //Writing Complain
    public void ComplainWrite()
    {
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            SqlCommand cmd = new SqlCommand(InsertCommand, con);
            cmd.Parameters.AddWithValue("@StudentID",this.ID);
            cmd.Parameters.AddWithValue("@complain",this.complain);
            cmd.Parameters.AddWithValue("@Date", this.Date);
            cmd.Parameters.AddWithValue("@Semistar", this.Semistar);
            con.Open();
            cmd.ExecuteNonQuery();
        }
    }
    public void SelectComplainByStudentID()
    {
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            SqlCommand cmd = new SqlCommand(SelectCommand + "WHERE [StudentID] = @StudentID", con);
            cmd.Parameters.AddWithValue("@StudentID", this.ID);
           
            con.Open();
            cmd.ExecuteNonQuery();
        }
    }
}
public partial class Attendance
{
    public void InsertAttendance()
    {
        //([StudentID], [SubjectID], [Status], [Date])
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            SqlCommand cmd = new SqlCommand(InsertCommandAttendanceStatus, con);
            cmd.Parameters.AddWithValue("@StudentID", this.ID);
            cmd.Parameters.AddWithValue("@SubjectID", this.SubjectID);
            cmd.Parameters.AddWithValue("@Date", this.Date);
            cmd.Parameters.AddWithValue("@Status", this.Status);
            con.Open();
            cmd.ExecuteNonQuery();
        }
    }
    public DataSet SelectAttendanceDataByID()
    {
        //([StudentID], [SubjectID], [Status], [Date])
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            SqlCommand cmd = new SqlCommand(SelectCommandAttendanceStatus + " WHERE [StudentID]=@StudentID AND [SubjectID]=@SubjectID", con);
            cmd.Parameters.AddWithValue("@StudentID", this.ID);
            cmd.Parameters.AddWithValue("@SubjectID", this.SubjectID);
            
            con.Open();
            SqlDataAdapter DA = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            DA.Fill(ds);
            return ds;
        }
    }
}
