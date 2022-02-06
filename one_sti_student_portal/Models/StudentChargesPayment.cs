// Decompiled with JetBrains decompiler
// Type: one_sti_student_portal.Models.StudentChargesPayment
// Assembly: one_sti_student_portal, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 39E34984-485E-45CE-9895-F7524E3024D6
// Assembly location: \\wsl.localhost\kali-linux\root\One STI Student Portal_1.3.8_apkcombo.com (1)\unknown\assemblies\one_sti_student_portal.dll

using SQLite;
using System;

namespace one_sti_student_portal.Models
{
  public class StudentChargesPayment
  {
    [AutoIncrement]
    [PrimaryKey]
    public int Id { get; set; }

    public string PSCSId { get; set; }

    public string BusinessUnit { set; get; }

    public string Term { get; set; }

    public string AccountNumber { get; set; }

    public string Description { set; get; }

    public double ItemAmount { set; get; }

    public string ItemTypeCD { set; get; }

    public string ReceiptNumber { set; get; }

    public DateTime ItemEffectiveDate { set; get; }

    public Decimal OrignlItemAmount { set; get; }

    public string ReferenceDesc { set; get; }

    public DateTime UpdatedOn { get; set; }
  }
}
