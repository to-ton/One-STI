// Decompiled with JetBrains decompiler
// Type: one_sti_student_portal.Renderers.EditorXF
// Assembly: one_sti_student_portal, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 39E34984-485E-45CE-9895-F7524E3024D6
// Assembly location: \\wsl.localhost\kali-linux\root\One STI Student Portal_1.3.8_apkcombo.com (1)\unknown\assemblies\one_sti_student_portal.dll

using System;
using Xamarin.Forms;

namespace one_sti_student_portal.Renderers
{
  public class EditorXF : Editor
  {
    public static BindableProperty PlaceholderProperty = BindableProperty.Create(nameof (Placeholder), typeof (string), typeof (EditorXF));
    public static BindableProperty PlaceholderColorProperty = BindableProperty.Create(nameof (PlaceholderColor), typeof (Color), typeof (EditorXF), (object) Color.Gray);

    public EditorXF() => this.TextChanged += (EventHandler<TextChangedEventArgs>) ((sender, e) => this.InvalidateMeasure());

    public string Placeholder
    {
      get => (string) this.GetValue(EditorXF.PlaceholderProperty);
      set => this.SetValue(EditorXF.PlaceholderProperty, (object) value);
    }

    public Color PlaceholderColor
    {
      get => (Color) this.GetValue(EditorXF.PlaceholderColorProperty);
      set => this.SetValue(EditorXF.PlaceholderColorProperty, (object) value);
    }
  }
}
