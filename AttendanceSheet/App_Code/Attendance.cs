using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Attendance
/// </summary>
public partial class Attendance:Student,ISubject
{   
    public bool Status { get; set; }
    public int SubjectID { get; set; }
    public string Date { get; set; } 
}