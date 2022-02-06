// Decompiled with JetBrains decompiler
// Type: one_sti_student_portal.Models.NewsArticles
// Assembly: one_sti_student_portal, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 39E34984-485E-45CE-9895-F7524E3024D6
// Assembly location: \\wsl.localhost\kali-linux\root\One STI Student Portal_1.3.8_apkcombo.com (1)\unknown\assemblies\one_sti_student_portal.dll

using SQLite;

namespace one_sti_student_portal.Models
{
  public class NewsArticles
  {
    [AutoIncrement]
    [PrimaryKey]
    public int id { get; set; }

    public int newsno { get; set; }

    public string title { get; set; }

    public string content_text { get; set; }

    public string pic_large { get; set; }

    public string imagepathlink { get; set; }

    public string published { get; set; }

    public string category { get; set; }

    public string datepub { get; set; }
  }
}
