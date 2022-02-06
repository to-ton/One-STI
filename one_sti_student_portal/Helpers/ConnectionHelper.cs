// Decompiled with JetBrains decompiler
// Type: one_sti_student_portal.Helpers.ConnectionHelper
// Assembly: one_sti_student_portal, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 39E34984-485E-45CE-9895-F7524E3024D6
// Assembly location: \\wsl.localhost\kali-linux\root\One STI Student Portal_1.3.8_apkcombo.com (1)\unknown\assemblies\one_sti_student_portal.dll

using Xamarin.Essentials;

namespace one_sti_student_portal.Helpers
{
  public class ConnectionHelper
  {
    public static bool IsConnected()
    {
      switch (Connectivity.NetworkAccess)
      {
        case NetworkAccess.None:
          return false;
        case NetworkAccess.Local:
          return false;
        case NetworkAccess.ConstrainedInternet:
          return false;
        case NetworkAccess.Internet:
          return true;
        default:
          return false;
      }
    }
  }
}
