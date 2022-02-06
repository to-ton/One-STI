// Decompiled with JetBrains decompiler
// Type: one_sti_student_portal.StringToColorConverter
// Assembly: one_sti_student_portal, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 39E34984-485E-45CE-9895-F7524E3024D6
// Assembly location: \\wsl.localhost\kali-linux\root\One STI Student Portal_1.3.8_apkcombo.com (1)\unknown\assemblies\one_sti_student_portal.dll

using System;
using System.Globalization;
using Xamarin.Forms;

namespace one_sti_student_portal
{
  public class StringToColorConverter : IValueConverter
  {
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
      switch (value.ToString())
      {
        case "":
          return (object) Color.Default;
        case "Accent":
          return (object) Color.Accent;
        default:
          return (object) Color.FromHex(value.ToString());
      }
    }

    public object ConvertBack(
      object value,
      Type targetType,
      object parameter,
      CultureInfo culture)
    {
      return (object) null;
    }
  }
}
