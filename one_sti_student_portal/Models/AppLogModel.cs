// Decompiled with JetBrains decompiler
// Type: one_sti_student_portal.Models.AppLogModel
// Assembly: one_sti_student_portal, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 39E34984-485E-45CE-9895-F7524E3024D6
// Assembly location: \\wsl.localhost\kali-linux\root\One STI Student Portal_1.3.8_apkcombo.com (1)\unknown\assemblies\one_sti_student_portal.dll

namespace one_sti_student_portal.Models
{
  public class AppLogModel
  {
    public string PSCSId { get; set; }

    public string IPAddress { get; set; }

    public string Medium { get; set; }

    public string AppVersion { get; set; }

    public int NumOfRequests { get; set; }

    public string DateAccessed { get; set; }

    public string ViewName { get; set; }

    public string Campus { get; set; }
  }
}
