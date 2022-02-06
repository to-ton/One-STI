// Decompiled with JetBrains decompiler
// Type: one_sti_student_portal.Models.StudentChecklist
// Assembly: one_sti_student_portal, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 39E34984-485E-45CE-9895-F7524E3024D6
// Assembly location: \\wsl.localhost\kali-linux\root\One STI Student Portal_1.3.8_apkcombo.com (1)\unknown\assemblies\one_sti_student_portal.dll

using SQLite;
using System;

namespace one_sti_student_portal.Models
{
  public class StudentChecklist
  {
    [PrimaryKey]
    [AutoIncrement]
    public int Id { get; set; }

    public string RqrmntGroup { get; set; }

    public string RqrmntGroupDescr { get; set; }

    public string RqrmntDescr { get; set; }

    public string CourseList { get; set; }

    public string CourseListDescr { get; set; }

    public string CourseCode { get; set; }

    public string CourseDesc { get; set; }

    public string ReqUnits { get; set; }

    public string Grade { get; set; }

    public DateTime GradeDate { get; set; }

    public string EarnedUnits { get; set; }

    public string PreRequisite { get; set; }

    public string Term { get; set; }

    public string Status { get; set; }

    public double Amount { get; set; }

    public DateTime DateProcessed { get; set; }

    public DateTime UpdatedOn { get; set; }

    public int IsExpand { get; set; }
  }
}
