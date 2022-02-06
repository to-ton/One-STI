// Decompiled with JetBrains decompiler
// Type: one_sti_student_portal.Views.SwitchAccount
// Assembly: one_sti_student_portal, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 39E34984-485E-45CE-9895-F7524E3024D6
// Assembly location: \\wsl.localhost\kali-linux\root\One STI Student Portal_1.3.8_apkcombo.com (1)\unknown\assemblies\one_sti_student_portal.dll

using Newtonsoft.Json.Linq;
using one_sti_student_portal.Data;
using one_sti_student_portal.DependencyServices;
using one_sti_student_portal.Helpers;
using one_sti_student_portal.Models;
using one_sti_student_portal.Models.Widget;
using one_sti_student_portal.Services;
using one_sti_student_portal.Views.Widgets;
using System;
using System.CodeDom.Compiler;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace one_sti_student_portal.Views
{
  [XamlCompilation(XamlCompilationOptions.Compile)]
  [XamlFilePath("Views\\SwitchAccount.xaml")]
  public class SwitchAccount : ContentPage
  {
    private StudentData _studentData;
    private string userEmail;
    private string userPSCSId;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private Entry entEmail;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private Button btnLogin;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private ActivityIndicator activityIndicator;

    public SwitchAccount()
    {
      this.InitializeComponent();
      this._studentData = new StudentData();
    }

    private void Login(object sender, EventArgs e)
    {
      this.userPSCSId = this.entEmail.Text.Trim();
      if (ConnectionHelper.IsConnected())
      {
        if (this.HasChromeInstalled())
        {
          Device.BeginInvokeOnMainThread((Action) (() =>
          {
            this.btnLogin.IsVisible = false;
            this.activityIndicator.IsRunning = true;
          }));
          if (true)
            Task.Run((Func<Task>) (async () =>
            {
              SwitchAccount switchAccount = this;
              JObject studentInfoById = await new StudentService().get_student_info_by_id(switchAccount.userPSCSId);
              if (switchAccount.userPSCSId == "")
              {
                Acr.UserDialogs.UserDialogs.Instance.Toast("Your email is not linked to our record. Please contact your registrar.", new TimeSpan?(new TimeSpan(0, 0, 5)));
                // ISSUE: reference to a compiler-generated method
                Device.BeginInvokeOnMainThread(new Action(switchAccount.\u003CLogin\u003Eb__4_3));
              }
              else
              {
                // ISSUE: reference to a compiler-generated method
                Device.BeginInvokeOnMainThread(new Action(switchAccount.\u003CLogin\u003Eb__4_4));
                if (!await switchAccount.DownloadUserDataAsync(switchAccount.userPSCSId))
                  return;
                MasterDetail masterDetail = new MasterDetail()
                {
                  Detail = (Page) new NavigationPage((Page) new WidgetHomePage())
                };
                Device.BeginInvokeOnMainThread((Action) (() => Application.Current.MainPage = (Page) masterDetail));
              }
            }));
          else
            Device.BeginInvokeOnMainThread((Action) (() =>
            {
              this.btnLogin.IsVisible = true;
              this.activityIndicator.IsRunning = false;
            }));
        }
        else
          Acr.UserDialogs.UserDialogs.Instance.Toast("Unsupported browser. Please use Google Chrome browser");
      }
      else
        Acr.UserDialogs.UserDialogs.Instance.Toast("Network error. Please check your connection.");
    }

    public async Task<bool> DownloadStudentInformationAsync(string email)
    {
      string pscsId = (await new StudentService().get_student_info_complete(email))["pscs_id"].ToString();
      try
      {
        await this._studentData.DeleteSemester();
        await this._studentData.DeleteStudentInfo();
        await this._studentData.DeleteSettings();
        await this._studentData.DownloadAllSemesters(pscsId);
        await this._studentData.DownloadStudentInformation(email);
        await this._studentData.DownloadStudentSettings(pscsId);
        return true;
      }
      catch
      {
        return false;
      }
    }

    public async Task<bool> DownloadUserDataAsync(string id)
    {
      try
      {
        StudentService studentService = new StudentService();
        string pscsId = id;
        await this._studentData.DeleteSemester();
        await this._studentData.DeleteSubjects();
        await this._studentData.DeleteChargesDueDate();
        await this._studentData.DeleteGrades();
        await this._studentData.DeleteGWA("all");
        await this._studentData.DeletePaymentCharges();
        await this._studentData.DeleteSchedule();
        await this._studentData.DeleteSettings();
        await this._studentData.DeleteStudentInfo();
        await this._studentData.DeleteDueDetails();
        await this._studentData.DownloadAllSemesters(pscsId);
        StudentSemester semester = this._studentData.GetLatestSemester().Result.FirstOrDefault<StudentSemester>();
        await this._studentData.DownloadSubjectsPerSemester(pscsId, semester.Semester);
        await this._studentData.DownloadSemesterGrades(pscsId, semester.Semester);
        await this._studentData.DownloadSemesterGWA(pscsId, semester.Semester);
        await this._studentData.DownloadSchedulePerSem(pscsId, semester.Semester);
        await this._studentData.DownloadSemPaymentCharges(pscsId, semester.Semester);
        await this._studentData.DownloadSemChargesDueDate(pscsId, semester.Semester);
        await this._studentData.DownloadStudentSettings(pscsId);
        await this._studentData.DownloadStudentInformationById(pscsId);
        string class_number = "";
        string level = "";
        foreach (StudentSubjects studentSubjects in this._studentData.GetSubjectInfo(semester.Semester).Result)
          class_number = studentSubjects.ClassNumber;
        foreach (StudentGrades studentGrades in this._studentData.GetSubjectGradeDetail(semester.Semester, class_number).Result)
          level = studentGrades.CourseCareer;
        await this._studentData.DownloadDueDetails(pscsId, semester.Semester, level);
        WidgetsData widgetData = new WidgetsData();
        WidgetSettings widgetSettings = new WidgetSettings();
        try
        {
          await new NewsData().DownloadNewsArticles(1);
          widgetData = new WidgetsData();
          widgetSettings = new WidgetSettings()
          {
            Widget = "Latest News",
            AddedOn = DateTime.Now
          };
          await widgetData.RemoveWidget(widgetSettings.Widget);
          int num = await widgetData.UpdateWidgetSettings(widgetSettings);
        }
        catch
        {
        }
        widgetSettings = new WidgetSettings()
        {
          Widget = "Classes for Today",
          AddedOn = DateTime.Now
        };
        await widgetData.RemoveWidget(widgetSettings.Widget);
        int num1 = await widgetData.UpdateWidgetSettings(widgetSettings);
        widgetSettings = new WidgetSettings()
        {
          Widget = "Payment Schedule",
          AddedOn = DateTime.Now
        };
        await widgetData.RemoveWidget(widgetSettings.Widget);
        int num2 = await widgetData.UpdateWidgetSettings(widgetSettings);
        return true;
      }
      catch
      {
        return false;
      }
    }

    private bool HasChromeInstalled() => DependencyService.Get<IAppChecker>().IsChromeInstalled();

    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private void InitializeComponent()
    {
      if (ResourceLoader.ResourceProvider != null && ResourceLoader.ResourceProvider(typeof (SwitchAccount).GetTypeInfo().Assembly.GetName(), "Views/SwitchAccount.xaml") != null)
        this.__InitComponentRuntime();
      else if (Xamarin.Forms.Xaml.Internals.XamlLoader.XamlFileProvider != null && Xamarin.Forms.Xaml.Internals.XamlLoader.XamlFileProvider(this.GetType()) != null)
      {
        this.__InitComponentRuntime();
      }
      else
      {
        Entry entry = new Entry();
        Button button = new Button();
        ActivityIndicator activityIndicator = new ActivityIndicator();
        StackLayout bindable1 = new StackLayout();
        SwitchAccount bindable2 = this;
        NameScope nameScope = new NameScope();
        NameScope.SetNameScope((BindableObject) bindable2, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable1, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) entry, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("entEmail", (object) entry);
        if (entry.StyleId == null)
          entry.StyleId = "entEmail";
        NameScope.SetNameScope((BindableObject) button, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("btnLogin", (object) button);
        if (button.StyleId == null)
          button.StyleId = "btnLogin";
        NameScope.SetNameScope((BindableObject) activityIndicator, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("activityIndicator", (object) activityIndicator);
        if (activityIndicator.StyleId == null)
          activityIndicator.StyleId = "activityIndicator";
        this.entEmail = entry;
        this.btnLogin = button;
        this.activityIndicator = activityIndicator;
        bindable1.SetValue(View.MarginProperty, (object) new Thickness(10.0));
        entry.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.FillAndExpand);
        bindable1.Children.Add((View) entry);
        button.SetValue(Button.TextProperty, (object) "LOGIN");
        button.Clicked += new EventHandler(bindable2.Login);
        bindable1.Children.Add((View) button);
        activityIndicator.SetValue(VisualElement.HeightRequestProperty, (object) 35.0);
        activityIndicator.SetValue(ActivityIndicator.IsRunningProperty, (object) false);
        bindable1.Children.Add((View) activityIndicator);
        bindable2.SetValue(ContentPage.ContentProperty, (object) bindable1);
      }
    }

    private void __InitComponentRuntime()
    {
      this.LoadFromXaml<SwitchAccount>(typeof (SwitchAccount));
      this.entEmail = NameScopeExtensions.FindByName<Entry>(this, "entEmail");
      this.btnLogin = NameScopeExtensions.FindByName<Button>(this, "btnLogin");
      this.activityIndicator = NameScopeExtensions.FindByName<ActivityIndicator>(this, "activityIndicator");
    }
  }
}
