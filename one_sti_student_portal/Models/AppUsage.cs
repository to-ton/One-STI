// Decompiled with JetBrains decompiler
// Type: one_sti_student_portal.Models.AppUsage
// Assembly: one_sti_student_portal, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 39E34984-485E-45CE-9895-F7524E3024D6
// Assembly location: \\wsl.localhost\kali-linux\root\One STI Student Portal_1.3.8_apkcombo.com (1)\unknown\assemblies\one_sti_student_portal.dll

using System;

namespace one_sti_student_portal.Models
{
  public class AppUsage
  {
    public string PSCSId { get; set; }

    public string Email { get; set; }

    public string Campus { get; set; }

    public DateTime LastAccess { get; set; }

    public string Device { get; set; }

    public string VersionCode { get; set; }

    public string VersionName { get; set; }
  }
}
