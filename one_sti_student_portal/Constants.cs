// Decompiled with JetBrains decompiler
// Type: one_sti_student_portal.Constants
// Assembly: one_sti_student_portal, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 39E34984-485E-45CE-9895-F7524E3024D6
// Assembly location: \\wsl.localhost\kali-linux\root\One STI Student Portal_1.3.8_apkcombo.com (1)\unknown\assemblies\one_sti_student_portal.dll

using Xamarin.Forms;

namespace one_sti_student_portal
{
  public class Constants
  {
    public static string StudentAPIUri = "https://api-studentportal.sti.edu";
    public static string NewsFeedUri = "https://www.sti.edu/eduapi/api/Newsarticle";
    public static string VersionCode = "38";
    public static string VersionName = "1.3.8";
    public static string DateUpdated = "Oct. 28, 2021";

    public static string IsCurriculumOpened()
    {
      try
      {
        return Application.Current.Properties.ContainsKey(nameof (IsCurriculumOpened)) ? Application.Current.Properties[nameof (IsCurriculumOpened)] as string : "0";
      }
      catch
      {
        return (string) null;
      }
    }
  }
}
