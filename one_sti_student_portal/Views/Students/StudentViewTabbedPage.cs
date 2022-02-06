// Decompiled with JetBrains decompiler
// Type: one_sti_student_portal.Views.Students.StudentViewTabbedPage
// Assembly: one_sti_student_portal, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 39E34984-485E-45CE-9895-F7524E3024D6
// Assembly location: \\wsl.localhost\kali-linux\root\One STI Student Portal_1.3.8_apkcombo.com (1)\unknown\assemblies\one_sti_student_portal.dll

using one_sti_student_portal.Data;
using one_sti_student_portal.Models;
using one_sti_student_portal.Views.Widgets;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace one_sti_student_portal.Views.Students
{
  [XamlCompilation(XamlCompilationOptions.Compile)]
  [XamlFilePath("Views\\Students\\StudentViewTabbedPage.xaml")]
  public class StudentViewTabbedPage : TabbedPage
  {
    public static int selectedTabIndex = 0;
    public static string selectedTabTitle = "My Grades";
    private bool blnShouldStay;

    public StudentViewTabbedPage()
    {
      this.InitializeComponent();
      this.Title = StudentViewTabbedPage.selectedTabTitle;
      this.BarBackgroundColor = Color.FromHex("#0B5793");
      this.BarTextColor = Color.FromHex("#FFF");
      this.Children.Add((Page) new ViewGradesPage(true));
      this.Children.Add((Page) new ViewSchedulesPage(true));
      List<StudentInformation> result = new StudentData().GetStudentInformation().Result;
      if (result.Count != 0 && !result.FirstOrDefault<StudentInformation>().AcadLevel.Contains("G"))
        this.Children.Add((Page) new StudentCheckList(true));
      this.Children.Add((Page) new ViewSOAPage(true));
      MessagingCenter.Subscribe<MessageSender>((object) this, "MyGrades", (Action<MessageSender>) (message => this.Title = "My Grades"), (MessageSender) null);
      MessagingCenter.Subscribe<MessageSender>((object) this, "MySchedule", (Action<MessageSender>) (message => this.Title = "My Class Schedule"), (MessageSender) null);
      MessagingCenter.Subscribe<MessageSender>((object) this, "MyAssessment", (Action<MessageSender>) (message => this.Title = "Student Balance"), (MessageSender) null);
      MessagingCenter.Subscribe<MessageSender>((object) this, "Curriculum", (Action<MessageSender>) (message => this.Title = "Program Curriculum"), (MessageSender) null);
    }

    protected override void OnAppearing()
    {
      base.OnAppearing();
      Device.BeginInvokeOnMainThread((Action) (() => this.CurrentPage = this.Children[StudentViewTabbedPage.selectedTabIndex]));
    }

    protected override bool OnBackButtonPressed()
    {
      if (this.CurrentPage != this.Children[0])
      {
        this.CurrentPage = this.Children[0];
        this.blnShouldStay = true;
      }
      else
        this.blnShouldStay = false;
      if (this.blnShouldStay)
        return true;
      MasterDetail masterDetail = new MasterDetail();
      masterDetail.Detail = (Page) new NavigationPage((Page) new WidgetHomePage());
      Application.Current.MainPage = (Page) masterDetail;
      return true;
    }

    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private void InitializeComponent()
    {
      if (ResourceLoader.ResourceProvider != null && ResourceLoader.ResourceProvider(typeof (StudentViewTabbedPage).GetTypeInfo().Assembly.GetName(), "Views/Students/StudentViewTabbedPage.xaml") != null)
        this.__InitComponentRuntime();
      else if (Xamarin.Forms.Xaml.Internals.XamlLoader.XamlFileProvider != null && Xamarin.Forms.Xaml.Internals.XamlLoader.XamlFileProvider(this.GetType()) != null)
      {
        this.__InitComponentRuntime();
      }
      else
      {
        StudentViewTabbedPage bindable = this;
        NameScope nameScope = new NameScope();
        NameScope.SetNameScope((BindableObject) bindable, (INameScope) nameScope);
        bindable.SetValue(Page.TitleProperty, (object) "");
      }
    }

    private void __InitComponentRuntime() => this.LoadFromXaml<StudentViewTabbedPage>(typeof (StudentViewTabbedPage));
  }
}
