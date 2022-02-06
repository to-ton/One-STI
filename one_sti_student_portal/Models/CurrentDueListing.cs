// Decompiled with JetBrains decompiler
// Type: one_sti_student_portal.Models.CurrentDueListing
// Assembly: one_sti_student_portal, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 39E34984-485E-45CE-9895-F7524E3024D6
// Assembly location: \\wsl.localhost\kali-linux\root\One STI Student Portal_1.3.8_apkcombo.com (1)\unknown\assemblies\one_sti_student_portal.dll

using System;

namespace one_sti_student_portal.Models
{
  public class CurrentDueListing
  {
    public DateTime dueDate { get; set; }

    public float dueAmount { get; set; }

    public float appliedAmount { get; set; }

    public DateTime termStartDate { get; set; }

    public DateTime termEndDate { get; set; }

    public string schoolTerm { get; set; }

    public string studTerm { get; set; }

    public float currentDue { get; set; }
  }
}
