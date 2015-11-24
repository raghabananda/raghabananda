using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Subject
/// </summary>
public partial class Subject:IBranch,ISubject
{
    public int SubjectID { get; set; }
    public string SubjectName { get; set; }
    public int Semistar { get; set; }
    public string Branch { get; set; }
    
   
}