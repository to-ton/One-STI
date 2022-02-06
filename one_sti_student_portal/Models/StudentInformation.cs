// Decompiled with JetBrains decompiler
// Type: one_sti_student_portal.Models.StudentInformation
// Assembly: one_sti_student_portal, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 39E34984-485E-45CE-9895-F7524E3024D6
// Assembly location: \\wsl.localhost\kali-linux\root\One STI Student Portal_1.3.8_apkcombo.com (1)\unknown\assemblies\one_sti_student_portal.dll

using SQLite;
using System;

namespace one_sti_student_portal.Models
{
  public class StudentInformation
  {
    [PrimaryKey]
    [AutoIncrement]
    public int Id { get; set; }

    public string ProfilePhoto { get; set; }

    public string PSCSId { get; set; }

    public string Email { get; set; }

    public string Sex { get; set; }

    public string Address { get; set; }

    public string Phone { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string MiddleName { get; set; }

    public DateTime BirthDate { get; set; }

    public string Age { get; set; }

    public string Campus { get; set; }

    public string CampusDesc { get; set; }

    public string Program { get; set; }

    public string ProgramShort { get; set; }

    public string AcadLevel { get; set; }

    public string AcadCareerCurrent { get; set; }

    public string SchoolTerm { get; set; }

    public string SchoolYear { get; set; }

    public string Hash { get; set; }
  }
}
