// Decompiled with JetBrains decompiler
// Type: one_sti_student_portal.Views.ListViewTemplate
// Assembly: one_sti_student_portal, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 39E34984-485E-45CE-9895-F7524E3024D6
// Assembly location: \\wsl.localhost\kali-linux\root\One STI Student Portal_1.3.8_apkcombo.com (1)\unknown\assemblies\one_sti_student_portal.dll

using Xamarin.Forms;

namespace one_sti_student_portal.Views
{
  public class ListViewTemplate
  {
    public int feedback_id { get; set; }

    public ImageSource display_image { get; set; }

    public string display_name { get; set; }

    public string subject { get; set; }

    public Color subject_color { get; set; }

    public string created_on { get; set; }

    public string feedback { get; set; }

    public string reply { get; set; }

    public Color row_color { get; set; }

    public Color feedback_color { get; set; }

    public Style feedback_style { get; set; }

    public bool is_unread { get; set; }
  }
}
