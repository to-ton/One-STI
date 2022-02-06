// Decompiled with JetBrains decompiler
// Type: one_sti_student_portal.Views.MasterDetailPageMenuItem
// Assembly: one_sti_student_portal, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 39E34984-485E-45CE-9895-F7524E3024D6
// Assembly location: \\wsl.localhost\kali-linux\root\One STI Student Portal_1.3.8_apkcombo.com (1)\unknown\assemblies\one_sti_student_portal.dll

using System;

namespace one_sti_student_portal.Views
{
  public class MasterDetailPageMenuItem
  {
    public MasterDetailPageMenuItem() => this.TargetType = typeof (MasterDetailPageDetail);

    public bool Header { get; set; }

    public string RowColor { get; set; }

    public string Title { get; set; }

    public string IconSource { get; set; }

    public Type TargetType { get; set; }

    public bool GoTo { get; set; }

    public bool Enable { get; set; }

    public bool ComingSoon { get; set; }

    public bool NewFeature { get; set; }
  }
}
