// Decompiled with JetBrains decompiler
// Type: one_sti_student_portal.App
// Assembly: one_sti_student_portal, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 39E34984-485E-45CE-9895-F7524E3024D6
// Assembly location: \\wsl.localhost\kali-linux\root\One STI Student Portal_1.3.8_apkcombo.com (1)\unknown\assemblies\one_sti_student_portal.dll

using Microsoft.Identity.Client;
using one_sti_student_portal.Views;
using System.CodeDom.Compiler;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace one_sti_student_portal
{
  [XamlFilePath("App.xaml")]
  public class App : Application
  {
    public static PublicClientApplication IdentityClientApp = (PublicClientApplication) null;
    public static string ClientID = "d5f255fa-5c24-4dcc-9249-4327f0f48122";
    public static string[] Scopes = new string[3]
    {
      "User.Read",
      "User.ReadWrite",
      "User.ReadBasic.All"
    };
    public static UIParent UiParent = (UIParent) null;

    public App()
    {
      this.InitializeComponent();
      App.IdentityClientApp = new PublicClientApplication(App.ClientID);
      this.MainPage = (Page) new NavigationPage((Page) new LoginPage());
    }

    protected override void OnStart()
    {
    }

    protected override void OnSleep()
    {
    }

    protected override void OnResume()
    {
    }

    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private void InitializeComponent() => this.LoadFromXaml<App>(typeof (App));
  }
}
