// Decompiled with JetBrains decompiler
// Type: one_sti_student_portal.Models.FeedbackWithReply
// Assembly: one_sti_student_portal, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 39E34984-485E-45CE-9895-F7524E3024D6
// Assembly location: \\wsl.localhost\kali-linux\root\One STI Student Portal_1.3.8_apkcombo.com (1)\unknown\assemblies\one_sti_student_portal.dll

using SQLite;
using System;

namespace one_sti_student_portal.Models
{
  public class FeedbackWithReply
  {
    [AutoIncrement]
    [PrimaryKey]
    public int id { get; set; }

    public int conversation_id { get; set; }

    public int feedback_id { get; set; }

    public string username { get; set; }

    public string display_name { get; set; }

    public string subject { get; set; }

    public string feedback { get; set; }

    public DateTime created_on { get; set; }

    public string created_on_formatted { get; set; }

    public string reply { get; set; }

    public DateTime replied_on { get; set; }

    public bool unread { get; set; }

    public string helpful { get; set; }
  }
}
