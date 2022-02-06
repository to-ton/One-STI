// Decompiled with JetBrains decompiler
// Type: one_sti_student_portal.Views.LoginPage
// Assembly: one_sti_student_portal, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 39E34984-485E-45CE-9895-F7524E3024D6
// Assembly location: \\wsl.localhost\kali-linux\root\One STI Student Portal_1.3.8_apkcombo.com (1)\unknown\assemblies\one_sti_student_portal.dll

using Acr.UserDialogs;
using Microsoft.Graph;
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
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Xml;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.Xaml.Internals;
using XLabs.Forms.Controls;

namespace one_sti_student_portal.Views
{
  [XamlCompilation(XamlCompilationOptions.Compile)]
  [XamlFilePath("Views\\LoginPage.xaml")]
  public class LoginPage : ContentPage
  {
    private StudentData _studentData;
    private DWTableData _tableData;
    private string _serverStatusOK;
    private static GraphServiceClient graphClient;
    private string _userDisplayName;
    private string _userEmail;
    private string _userPSCSId;
    private string _userProfilePhoto;
    private bool _isConnected;
    private bool _isUpdateRequired;
    private string serverStatus;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private StackLayout stackBody;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private Label lblWelcome;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private Label lblIndicator;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private ActivityIndicator activityIndicator;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private Xamarin.Forms.Image btnLogin;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private ExtendedLabel lblEmailRecovery;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private StackLayout stackServerDown;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private StackLayout stackServerDownMessage;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private Label lblServerDown;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private StackLayout stackRefresh;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private ExtendedLabel lblRefresh;

    public LoginPage()
    {
      this.InitializeComponent();
      this._studentData = new StudentData();
      this._tableData = new DWTableData();
      Xamarin.Forms.Device.StartTimer(TimeSpan.FromSeconds(2.0), (Func<bool>) (() =>
      {
        this.stackBody.FadeTo(1.0, 1000U);
        this.Initialize();
        return false;
      }));
      this._isConnected = ConnectionHelper.IsConnected();
      Connectivity.ConnectivityChanged += new EventHandler<ConnectivityChangedEventArgs>(this.Connectivity_ConnectivityChanged);
    }

    private void Connectivity_ConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
    {
      this._isConnected = ConnectionHelper.IsConnected();
      Task.Run((Func<Task>) (async () => this._serverStatusOK = await this.ServerStatusAsync()));
    }

    protected override void OnAppearing() => base.OnAppearing();

    private void Initialize()
    {
      Xamarin.Forms.Device.BeginInvokeOnMainThread((Action) (() => this.activityIndicator.IsRunning = true));
      Task.Run((Func<Task>) (async () => this._serverStatusOK = await this.ServerStatusAsync())).ContinueWith((Action<Task>) (result => Xamarin.Forms.Device.BeginInvokeOnMainThread((Action) (() =>
      {
        bool flag = this._studentData.HasUser();
        if (this._serverStatusOK == "true")
        {
          this.lblWelcome.IsVisible = true;
          this.btnLogin.IsVisible = true;
          this.lblEmailRecovery.IsVisible = true;
          this.stackServerDown.IsVisible = false;
          this.stackRefresh.IsVisible = false;
          this.CheckAppVersion();
          if (flag)
          {
            int num1;
            Task.Run((Func<Task>) (async () => num1 = await this.DownloadStudentInformationAsync(this._studentData.GetStudentInformation().Result.FirstOrDefault<StudentInformation>().Email) ? 1 : 0)).ContinueWith((Action<Task>) (response => Xamarin.Forms.Device.BeginInvokeOnMainThread((Action) (() =>
            {
              WidgetsData widgetsData = new WidgetsData();
              if (!widgetsData.GetWidgets().Result.Any<WidgetsAvailable>((Func<WidgetsAvailable, bool>) (o => o.Widget.ToLower().Contains("payment"))))
              {
                this._isUpdateRequired = true;
                WidgetsAvailable widgetsModel3 = new WidgetsAvailable()
                {
                  Widget = "Payment Schedule",
                  CreatedOn = DateTime.Now,
                  IsActive = 1
                };
                widgetsData.SaveWidget(widgetsModel3);
                WidgetSettings widgetSetting3 = new WidgetSettings()
                {
                  Widget = "Payment Schedule",
                  AddedOn = DateTime.Now
                };
                widgetsData.RemoveWidget(widgetSetting3.Widget);
                widgetsData.UpdateWidgetSettings(widgetSetting3);
                WidgetsAvailable widgetsModel4 = new WidgetsAvailable()
                {
                  Widget = "Latest Grade",
                  CreatedOn = DateTime.Now,
                  IsActive = 1
                };
                widgetsData.SaveWidget(widgetsModel4);
                WidgetSettings widgetSetting4 = new WidgetSettings()
                {
                  Widget = "Latest Grade",
                  AddedOn = DateTime.Now
                };
                widgetsData.RemoveWidget(widgetSetting4.Widget);
                widgetsData.UpdateWidgetSettings(widgetSetting4);
              }
              if (this._isUpdateRequired)
              {
                Xamarin.Forms.Device.BeginInvokeOnMainThread((Action) (() =>
                {
                  this.lblIndicator.IsVisible = true;
                  this.lblIndicator.Text = Environment.NewLine + Environment.NewLine + "Applying updates...";
                }));
                int num2;
                Task.Run((Func<Task>) (async () => num2 = await this.DownloadUserDataAsync(this._studentData.GetStudentInformation().Result.FirstOrDefault<StudentInformation>().Email) ? 1 : 0)).ContinueWith((Action<Task>) (continueWith => Xamarin.Forms.Device.BeginInvokeOnMainThread((Action) (() =>
                {
                  Application.Current.MainPage = (Page) new MasterDetail()
                  {
                    Detail = (Page) new NavigationPage((Page) new WidgetHomePage())
                  };
                }))));
              }
              else if (this._studentData.GetLatestSemester().Result.Count != 0)
                Application.Current.MainPage = (Page) new MasterDetail()
                {
                  Detail = (Page) new NavigationPage((Page) new WidgetHomePage())
                };
              else
                Application.Current.MainPage = (Page) new LogoutPage();
            }))));
          }
          else
          {
            new ApplicationData().DeleteConstants();
            AuthenticationHelper.TokenForUser = (string) null;
            this.activityIndicator.IsRunning = false;
          }
        }
        else if (this._serverStatusOK == "down")
        {
          this.activityIndicator.IsRunning = false;
          this.lblWelcome.IsVisible = false;
          this.btnLogin.IsVisible = false;
          this.lblEmailRecovery.IsVisible = false;
          this.stackServerDown.IsVisible = true;
          this.stackRefresh.IsVisible = true;
          Xamarin.Forms.Device.StartTimer(TimeSpan.FromSeconds(2.0), (Func<bool>) (() =>
          {
            this.stackServerDown.FadeTo(1.0, 1000U);
            return false;
          }));
        }
        else if (this._serverStatusOK == "not connected")
        {
          this.activityIndicator.IsRunning = false;
          this.lblWelcome.IsVisible = false;
          this.btnLogin.IsVisible = false;
          this.lblEmailRecovery.IsVisible = false;
          Acr.UserDialogs.UserDialogs.Instance.Toast("Please check your network connection and try again.", new TimeSpan?(new TimeSpan(0, 0, 5)));
        }
        else
        {
          this.activityIndicator.IsRunning = false;
          Acr.UserDialogs.UserDialogs.Instance.Toast("An error occured while establishing a connection to the server", new TimeSpan?(new TimeSpan(0, 0, 5)));
          this.stackRefresh.IsVisible = true;
        }
      }))));
    }

    private async Task<string> ServerStatusAsync()
    {
      try
      {
        string isServerOK = "false";
        if (!ConnectionHelper.IsConnected())
          return "not connected";
        string str = await new StudentService().CheckServerStatus();
        if (str.ToLower().Contains("online"))
          isServerOK = "true";
        else if (str.ToLower().Contains("down"))
          isServerOK = "down";
        return isServerOK;
      }
      catch (Exception ex)
      {
        return "error";
      }
    }

    private async Task<bool> CreateGraphClientAsync()
    {
      try
      {
        AuthenticationHelper authenticationHelper = new AuthenticationHelper();
        LoginPage.graphClient = AuthenticationHelper.GetAuthenticatedClient();
        User async = await LoginPage.graphClient.Me.Request().GetAsync();
        this._userDisplayName = async.GivenName;
        this._userEmail = async.UserPrincipalName;
        int num = await new ApplicationData().SaveConstant(new AppConstants()
        {
          Constant = "delveid",
          Value = async.Id
        });
        try
        {
          Stream photoStreamAsync = await new MailHelper().GetCurrentUserPhotoStreamAsync();
          MemoryStream memoryStream = new MemoryStream();
          MemoryStream destination = memoryStream;
          photoStreamAsync.CopyTo((Stream) destination);
          this._userProfilePhoto = Convert.ToBase64String(memoryStream.ToArray());
        }
        catch
        {
          this._userProfilePhoto = (string) null;
        }
        return true;
      }
      catch (Exception ex)
      {
        return false;
      }
    }

    private void Login(object sender, EventArgs e)
    {
      if (this._isConnected)
      {
        bool loginStatus = false;
        Task.Run((Func<Task>) (async () => this._serverStatusOK = await this.ServerStatusAsync()));
        if (this._serverStatusOK == "true")
        {
          Xamarin.Forms.Device.BeginInvokeOnMainThread((Action) (() =>
          {
            this.lblWelcome.IsVisible = true;
            this.lblIndicator.IsVisible = true;
            this.lblIndicator.Text = "Wait a moment...";
            this.stackRefresh.IsVisible = false;
            this.activityIndicator.IsRunning = true;
          }));
          Task.Run((Func<Task>) (async () => loginStatus = await this.CreateGraphClientAsync())).ContinueWith((Action<Task>) (result => Xamarin.Forms.Device.BeginInvokeOnMainThread((Action) (() =>
          {
            if (loginStatus)
            {
              new ApplicationData().SaveConstant(new AppConstants()
              {
                Constant = "profilephoto",
                Value = this._userProfilePhoto
              });
              Task.Run((Func<Task>) (async () =>
              {
                LoginPage loginPage = this;
                JObject studentInfoComplete = await new StudentService().get_student_info_complete(loginPage._userEmail);
                loginPage._userPSCSId = studentInfoComplete["pscs_id"].ToString();
                if (loginPage._userPSCSId == "")
                {
                  Acr.UserDialogs.UserDialogs.Instance.Toast("Your email account needs to link up with your record. Please contact your School Registrar.", new TimeSpan?(new TimeSpan(0, 0, 5)));
                  // ISSUE: reference to a compiler-generated method
                  Xamarin.Forms.Device.BeginInvokeOnMainThread(new Action(loginPage.\u003CLogin\u003Eb__17_8));
                }
                else
                {
                  // ISSUE: reference to a compiler-generated method
                  Xamarin.Forms.Device.BeginInvokeOnMainThread(new Action(loginPage.\u003CLogin\u003Eb__17_9));
                  if (!await loginPage.DownloadUserDataAsync(loginPage._userEmail))
                    return;
                  MasterDetail masterDetail = new MasterDetail()
                  {
                    Detail = (Page) new NavigationPage((Page) new WidgetHomePage())
                  };
                  Xamarin.Forms.Device.BeginInvokeOnMainThread((Action) (() => Application.Current.MainPage = (Page) masterDetail));
                }
              }));
            }
            else
              Xamarin.Forms.Device.BeginInvokeOnMainThread((Action) (() =>
              {
                this.lblWelcome.IsVisible = false;
                this.lblIndicator.IsVisible = false;
                this.activityIndicator.IsRunning = false;
                AuthenticationHelper.TokenForUser = (string) null;
              }));
          }))));
        }
        else if (this._serverStatusOK == "down")
        {
          this.activityIndicator.IsRunning = false;
          this.lblWelcome.IsVisible = false;
          this.btnLogin.IsVisible = false;
          this.lblEmailRecovery.IsVisible = false;
          this.stackServerDown.IsVisible = true;
          this.stackRefresh.IsVisible = true;
          Xamarin.Forms.Device.StartTimer(TimeSpan.FromSeconds(2.0), (Func<bool>) (() =>
          {
            this.stackServerDown.FadeTo(1.0, 1000U);
            return false;
          }));
        }
        else if (this._serverStatusOK == "not connected")
        {
          this.activityIndicator.IsRunning = false;
          this.lblWelcome.IsVisible = false;
          this.btnLogin.IsVisible = false;
          this.lblEmailRecovery.IsVisible = false;
          Acr.UserDialogs.UserDialogs.Instance.Toast("Please check your network connection and try again.", new TimeSpan?(new TimeSpan(0, 0, 5)));
        }
        else
        {
          this.activityIndicator.IsRunning = false;
          Acr.UserDialogs.UserDialogs.Instance.Toast("An error occured while establishing a connection to the server", new TimeSpan?(new TimeSpan(0, 0, 5)));
          this.stackRefresh.IsVisible = true;
        }
      }
      else
        Acr.UserDialogs.UserDialogs.Instance.Toast("Network error. Please check your connection.");
    }

    private void CheckAppVersion()
    {
      bool isUpdated = true;
      Task.Run((Func<Task>) (async () =>
      {
        try
        {
          isUpdated = (await new StudentService().CheckAppVersion(one_sti_student_portal.Constants.VersionCode)).Contains("true");
        }
        catch
        {
          isUpdated = true;
        }
      })).ContinueWith((Action<Task>) (result => Xamarin.Forms.Device.BeginInvokeOnMainThread((Action) (() =>
      {
        if (this._serverStatusOK == "true")
        {
          AlertConfig config = new AlertConfig()
          {
            Message = "You are using an old version of the app. Please update to the latest version.",
            Title = "Update Available",
            OkText = "Update",
            OnAction = (Action) (() => this.GotoPlayStore())
          };
          if (isUpdated)
            return;
          Acr.UserDialogs.UserDialogs.Instance.Alert(config);
        }
        else
        {
          int num = this._serverStatusOK != "true" ? 1 : 0;
        }
      }))));
    }

    private void GotoPlayStore() => Xamarin.Forms.Device.BeginInvokeOnMainThread((Action) (() => Xamarin.Forms.Device.OpenUri(new Uri("https://play.google.com/store/apps/details?id=com.onesti.student.portal"))));

    public async Task<bool> DownloadStudentInformationAsync(string email)
    {
      string pscsId = (await new StudentService().get_student_info_complete(email))["pscs_id"].ToString();
      try
      {
        await this._studentData.DeleteStudentHistory();
        await this._studentData.DeleteSemester();
        await this._studentData.DeleteSettings();
        await this._studentData.DownloadAllSemesters(pscsId);
        await this._studentData.DownloadStudentInformation(email);
        string semester = this._studentData.GetLatestSemester().Result.FirstOrDefault<StudentSemester>().Semester;
        await this._studentData.DownloadStudentHistory(pscsId, semester);
        List<StudentInformation> result = this._studentData.GetStudentInformation().Result;
        return true;
      }
      catch
      {
        return false;
      }
    }

    public async Task<bool> DownloadUserDataAsync(string email)
    {
      LoginPage loginPage = this;
      try
      {
        JObject pscsData = await new StudentService().get_student_info_complete(email);
        string pscsId = pscsData["pscs_id"].ToString();
        await loginPage._studentData.DeleteSemester();
        await loginPage._studentData.DeleteSubjects();
        await loginPage._studentData.DeleteChargesDueDate();
        await loginPage._studentData.DeleteGrades();
        await loginPage._studentData.DeleteGWA("all");
        await loginPage._studentData.DeletePaymentCharges();
        await loginPage._studentData.DeleteNetAssessment();
        await loginPage._studentData.DeleteSchedule();
        await loginPage._studentData.DeleteSettings();
        await loginPage._studentData.DeleteStudentInfo();
        await loginPage._studentData.DeleteChecklist();
        await loginPage._studentData.DeleteCurriculum();
        await loginPage._studentData.DeleteOSFDetails();
        await loginPage._studentData.DeleteTuitionMiscDetails();
        await loginPage._studentData.DownloadAllSemesters(pscsId);
        string currentTerm = loginPage._studentData.GetLatestSemester().Result.FirstOrDefault<StudentSemester>().Semester;
        string currentAcadCareer = pscsData["acad_career"].ToString();
        await loginPage._studentData.DownloadStudentHistory(pscsId, currentTerm);
        await loginPage._studentData.DownloadSubjectsPerSemester(pscsId, currentTerm);
        await loginPage._studentData.DownloadSemesterGrades(pscsId, currentTerm);
        await loginPage._studentData.DownloadSemesterGWA(pscsId, currentTerm);
        await loginPage._studentData.DownloadSchedulePerSem(pscsId, currentTerm);
        await loginPage._studentData.DownloadStudentInformation(email);
        await loginPage._studentData.DeleteDueDetails();
        await loginPage._studentData.DownloadDueDetails(pscsId, currentTerm, currentAcadCareer);
        List<StudentInformation> studentInfo = loginPage._studentData.GetStudentInformation().Result;
        if (studentInfo.Count != 0)
        {
          if (studentInfo.FirstOrDefault<StudentInformation>().AcadLevel.Contains("G"))
          {
            currentTerm = currentTerm.Remove(currentTerm.Length - 2);
            await loginPage._studentData.DownloadOSFDetails(pscsId, currentTerm + "01");
            await loginPage._studentData.DownloadTuitionMiscDetails(pscsId, currentTerm + "01");
          }
          else
          {
            try
            {
              await loginPage._studentData.DownloadChecklist(studentInfo.FirstOrDefault<StudentInformation>().PSCSId, studentInfo.FirstOrDefault<StudentInformation>().ProgramShort);
            }
            catch (Exception ex)
            {
            }
          }
        }
        await loginPage._studentData.DownloadSemPaymentCharges(pscsId, currentTerm);
        await loginPage._studentData.DownloadSemChargesDueDate(pscsId, currentTerm);
        await loginPage._studentData.DownloadNetAssessment(pscsId);
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
        int num2 = await widgetData.SaveWidget(new WidgetsAvailable()
        {
          Widget = "Payment Schedule",
          CreatedOn = DateTime.Now,
          IsActive = 1
        });
        widgetSettings = new WidgetSettings()
        {
          Widget = "Payment Schedule",
          AddedOn = DateTime.Now
        };
        await widgetData.RemoveWidget(widgetSettings.Widget);
        int num3 = await widgetData.UpdateWidgetSettings(widgetSettings);
        int num4 = await widgetData.SaveWidget(new WidgetsAvailable()
        {
          Widget = "Latest Grade",
          CreatedOn = DateTime.Now,
          IsActive = 1
        });
        widgetSettings = new WidgetSettings()
        {
          Widget = "Latest Grade",
          AddedOn = DateTime.Now
        };
        await widgetData.RemoveWidget(widgetSettings.Widget);
        int num5 = await widgetData.UpdateWidgetSettings(widgetSettings);
        string str = await new StudentService().SendLog(new AppLogModel()
        {
          PSCSId = studentInfo.FirstOrDefault<StudentInformation>().PSCSId,
          IPAddress = "null",
          Medium = "Mobile",
          AppVersion = one_sti_student_portal.Constants.VersionName,
          NumOfRequests = 16,
          DateAccessed = DateTime.Now.ToString("MM/dd/yyyy hh:mm tt"),
          ViewName = loginPage.GetType().Name + " DownloadUserDataAsync",
          Campus = studentInfo.FirstOrDefault<StudentInformation>().Campus
        });
        return true;
      }
      catch (Exception ex)
      {
        return false;
      }
    }

    private bool HasChromeInstalled() => DependencyService.Get<IAppChecker>().IsChromeInstalled();

    private bool IsAppEnabled() => DependencyService.Get<IAppChecker>().IsAppEnabled();

    private void HavingTrouble_Tapped(object sender, EventArgs e) => this.Navigation.PushAsync((Page) new LoginHelpPage(), true);

    private void EmailRecovery(object sender, EventArgs e)
    {
      if (this._serverStatusOK == "true")
      {
        this.Navigation.PushAsync((Page) new EmailRecoveryPage(), true);
      }
      else
      {
        if (!(this._serverStatusOK == "error"))
          return;
        this.DisplayAlert("Temporarily Unavailable", "We're currently experiencing technical problem on our server.  We’re working on to fix the issues and we are estimating that by the end of the day today we should have fixed the issues. We apologize for the inconvenience and appreciate your patience. Thank you!", "OK");
      }
    }

    private void lblRefresh_Tapped(object sender, EventArgs e)
    {
      this.stackServerDown.IsVisible = false;
      this.stackRefresh.IsVisible = false;
      Xamarin.Forms.Device.BeginInvokeOnMainThread((Action) (() => this.activityIndicator.IsRunning = true));
      Xamarin.Forms.Device.StartTimer(TimeSpan.FromSeconds(2.0), (Func<bool>) (() =>
      {
        this.Initialize();
        this.activityIndicator.IsRunning = false;
        return false;
      }));
    }

    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private void InitializeComponent()
    {
      if (ResourceLoader.ResourceProvider != null && ResourceLoader.ResourceProvider(typeof (LoginPage).GetTypeInfo().Assembly.GetName(), "Views/LoginPage.xaml") != null)
        this.__InitComponentRuntime();
      else if (Xamarin.Forms.Xaml.Internals.XamlLoader.XamlFileProvider != null && Xamarin.Forms.Xaml.Internals.XamlLoader.XamlFileProvider(this.GetType()) != null)
      {
        this.__InitComponentRuntime();
      }
      else
      {
        Xamarin.Forms.Image bindable1 = new Xamarin.Forms.Image();
        Xamarin.Forms.Image bindable2 = new Xamarin.Forms.Image();
        StaticResourceExtension resourceExtension1 = new StaticResourceExtension();
        Label label1 = new Label();
        StaticResourceExtension resourceExtension2 = new StaticResourceExtension();
        Label label2 = new Label();
        ActivityIndicator activityIndicator = new ActivityIndicator();
        TapGestureRecognizer bindable3 = new TapGestureRecognizer();
        Xamarin.Forms.Image image = new Xamarin.Forms.Image();
        StaticResourceExtension resourceExtension3 = new StaticResourceExtension();
        TapGestureRecognizer bindable4 = new TapGestureRecognizer();
        ExtendedLabel extendedLabel1 = new ExtendedLabel();
        StaticResourceExtension resourceExtension4 = new StaticResourceExtension();
        Label label3 = new Label();
        StackLayout stackLayout1 = new StackLayout();
        StackLayout stackLayout2 = new StackLayout();
        StaticResourceExtension resourceExtension5 = new StaticResourceExtension();
        TapGestureRecognizer bindable5 = new TapGestureRecognizer();
        ExtendedLabel extendedLabel2 = new ExtendedLabel();
        StackLayout stackLayout3 = new StackLayout();
        StackLayout bindable6 = new StackLayout();
        StackLayout stackLayout4 = new StackLayout();
        LoginPage bindable7 = this;
        NameScope nameScope = new NameScope();
        NameScope.SetNameScope((BindableObject) bindable7, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) stackLayout4, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("stackBody", (object) stackLayout4);
        if (stackLayout4.StyleId == null)
          stackLayout4.StyleId = "stackBody";
        NameScope.SetNameScope((BindableObject) bindable1, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable2, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable6, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) label1, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("lblWelcome", (object) label1);
        if (label1.StyleId == null)
          label1.StyleId = "lblWelcome";
        NameScope.SetNameScope((BindableObject) label2, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("lblIndicator", (object) label2);
        if (label2.StyleId == null)
          label2.StyleId = "lblIndicator";
        NameScope.SetNameScope((BindableObject) activityIndicator, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("activityIndicator", (object) activityIndicator);
        if (activityIndicator.StyleId == null)
          activityIndicator.StyleId = "activityIndicator";
        NameScope.SetNameScope((BindableObject) image, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("btnLogin", (object) image);
        if (image.StyleId == null)
          image.StyleId = "btnLogin";
        NameScope.SetNameScope((BindableObject) bindable3, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) extendedLabel1, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("lblEmailRecovery", (object) extendedLabel1);
        if (extendedLabel1.StyleId == null)
          extendedLabel1.StyleId = "lblEmailRecovery";
        NameScope.SetNameScope((BindableObject) bindable4, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) stackLayout2, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("stackServerDown", (object) stackLayout2);
        if (stackLayout2.StyleId == null)
          stackLayout2.StyleId = "stackServerDown";
        NameScope.SetNameScope((BindableObject) stackLayout1, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("stackServerDownMessage", (object) stackLayout1);
        if (stackLayout1.StyleId == null)
          stackLayout1.StyleId = "stackServerDownMessage";
        NameScope.SetNameScope((BindableObject) label3, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("lblServerDown", (object) label3);
        if (label3.StyleId == null)
          label3.StyleId = "lblServerDown";
        NameScope.SetNameScope((BindableObject) stackLayout3, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("stackRefresh", (object) stackLayout3);
        if (stackLayout3.StyleId == null)
          stackLayout3.StyleId = "stackRefresh";
        NameScope.SetNameScope((BindableObject) extendedLabel2, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("lblRefresh", (object) extendedLabel2);
        if (extendedLabel2.StyleId == null)
          extendedLabel2.StyleId = "lblRefresh";
        NameScope.SetNameScope((BindableObject) bindable5, (INameScope) nameScope);
        this.stackBody = stackLayout4;
        this.lblWelcome = label1;
        this.lblIndicator = label2;
        this.activityIndicator = activityIndicator;
        this.btnLogin = image;
        this.lblEmailRecovery = extendedLabel1;
        this.stackServerDown = stackLayout2;
        this.stackServerDownMessage = stackLayout1;
        this.lblServerDown = label3;
        this.stackRefresh = stackLayout3;
        this.lblRefresh = extendedLabel2;
        bindable7.SetValue(NavigationPage.HasNavigationBarProperty, (object) false);
        bindable7.SetValue(Page.BackgroundImageProperty, (object) "onesti_bg");
        bindable7.SetValue(VisualElement.BackgroundColorProperty, (object) new Color(0.0431372560560703, 0.341176480054855, 0.576470613479614, 1.0));
        stackLayout4.SetValue(VisualElement.OpacityProperty, (object) 0.0);
        stackLayout4.SetValue(View.VerticalOptionsProperty, (object) LayoutOptions.FillAndExpand);
        bindable1.SetValue(View.MarginProperty, (object) new Thickness(0.0, 0.0, 35.0, 0.0));
        bindable1.SetValue(Xamarin.Forms.Image.SourceProperty, new Xamarin.Forms.ImageSourceConverter().ConvertFromInvariantString("sti_logo.png"));
        bindable1.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.End);
        bindable1.SetValue(VisualElement.MinimumHeightRequestProperty, (object) 60.0);
        bindable1.SetValue(VisualElement.HeightRequestProperty, (object) 60.0);
        stackLayout4.Children.Add((View) bindable1);
        bindable2.SetValue(View.MarginProperty, (object) new Thickness(10.0, 80.0, 10.0, 0.0));
        bindable2.SetValue(Xamarin.Forms.Image.SourceProperty, new Xamarin.Forms.ImageSourceConverter().ConvertFromInvariantString("onestiapp_logo.png"));
        stackLayout4.Children.Add((View) bindable2);
        bindable6.SetValue(View.MarginProperty, (object) new Thickness(0.0, 35.0, 0.0, 0.0));
        label1.SetValue(VisualElement.IsVisibleProperty, new VisualElement.VisibilityConverter().ConvertFromInvariantString("False"));
        label1.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.CenterAndExpand);
        resourceExtension1.Key = "normalLabel";
        StaticResourceExtension resourceExtension6 = resourceExtension1;
        XamlServiceProvider xamlServiceProvider1 = new XamlServiceProvider();
        Type type1 = typeof (IProvideValueTarget);
        object[] objectAndParents1 = new object[0 + 4];
        objectAndParents1[0] = (object) label1;
        objectAndParents1[1] = (object) bindable6;
        objectAndParents1[2] = (object) stackLayout4;
        objectAndParents1[3] = (object) bindable7;
        SimpleValueTargetProvider service1 = new SimpleValueTargetProvider(objectAndParents1, (object) VisualElement.StyleProperty);
        xamlServiceProvider1.Add(type1, (object) service1);
        xamlServiceProvider1.Add(typeof (INameScopeProvider), (object) new NameScopeProvider()
        {
          NameScope = (INameScope) nameScope
        });
        Type type2 = typeof (IXamlTypeResolver);
        XmlNamespaceResolver namespaceResolver1 = new XmlNamespaceResolver();
        namespaceResolver1.Add("", "http://xamarin.com/schemas/2014/forms");
        namespaceResolver1.Add("x", "http://schemas.microsoft.com/winfx/2009/xaml");
        namespaceResolver1.Add("xlabs", "clr-namespace:XLabs.Forms.Controls;assembly=XLabs.Forms");
        XamlTypeResolver service2 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver1, typeof (LoginPage).GetTypeInfo().Assembly);
        xamlServiceProvider1.Add(type2, (object) service2);
        xamlServiceProvider1.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(21, 98)));
        object obj1 = resourceExtension6.ProvideValue((IServiceProvider) xamlServiceProvider1);
        label1.Style = (Style) obj1;
        label1.SetValue(Label.FontFamilyProperty, (object) "Roboto-Regular.ttf#Roboto");
        label1.SetValue(Label.TextColorProperty, (object) Color.White);
        bindable6.Children.Add((View) label1);
        label2.SetValue(VisualElement.IsVisibleProperty, new VisualElement.VisibilityConverter().ConvertFromInvariantString("False"));
        label2.SetValue(Label.TextProperty, (object) "Wait a moment...");
        label2.SetValue(View.MarginProperty, (object) new Thickness(35.0, 0.0, 35.0, 0.0));
        label2.SetValue(View.VerticalOptionsProperty, (object) LayoutOptions.Center);
        label2.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.CenterAndExpand);
        label2.SetValue(Label.HorizontalTextAlignmentProperty, new TextAlignmentConverter().ConvertFromInvariantString("Center"));
        resourceExtension2.Key = "smallLabel";
        StaticResourceExtension resourceExtension7 = resourceExtension2;
        XamlServiceProvider xamlServiceProvider2 = new XamlServiceProvider();
        Type type3 = typeof (IProvideValueTarget);
        object[] objectAndParents2 = new object[0 + 4];
        objectAndParents2[0] = (object) label2;
        objectAndParents2[1] = (object) bindable6;
        objectAndParents2[2] = (object) stackLayout4;
        objectAndParents2[3] = (object) bindable7;
        SimpleValueTargetProvider service3 = new SimpleValueTargetProvider(objectAndParents2, (object) VisualElement.StyleProperty);
        xamlServiceProvider2.Add(type3, (object) service3);
        xamlServiceProvider2.Add(typeof (INameScopeProvider), (object) new NameScopeProvider()
        {
          NameScope = (INameScope) nameScope
        });
        Type type4 = typeof (IXamlTypeResolver);
        XmlNamespaceResolver namespaceResolver2 = new XmlNamespaceResolver();
        namespaceResolver2.Add("", "http://xamarin.com/schemas/2014/forms");
        namespaceResolver2.Add("x", "http://schemas.microsoft.com/winfx/2009/xaml");
        namespaceResolver2.Add("xlabs", "clr-namespace:XLabs.Forms.Controls;assembly=XLabs.Forms");
        XamlTypeResolver service4 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver2, typeof (LoginPage).GetTypeInfo().Assembly);
        xamlServiceProvider2.Add(type4, (object) service4);
        xamlServiceProvider2.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(23, 201)));
        object obj2 = resourceExtension7.ProvideValue((IServiceProvider) xamlServiceProvider2);
        label2.Style = (Style) obj2;
        label2.SetValue(Label.FontFamilyProperty, (object) "Roboto-Regular.ttf#Roboto");
        label2.SetValue(Label.TextColorProperty, (object) Color.White);
        bindable6.Children.Add((View) label2);
        activityIndicator.SetValue(VisualElement.HeightRequestProperty, (object) 30.0);
        activityIndicator.SetValue(View.MarginProperty, (object) new Thickness(5.0));
        activityIndicator.SetValue(ActivityIndicator.ColorProperty, (object) new Color(1.0, 1.0, 1.0, 1.0));
        activityIndicator.SetValue(ActivityIndicator.IsRunningProperty, (object) false);
        bindable6.Children.Add((View) activityIndicator);
        image.SetValue(Xamarin.Forms.Image.SourceProperty, new Xamarin.Forms.ImageSourceConverter().ConvertFromInvariantString("login_button"));
        image.SetValue(VisualElement.IsVisibleProperty, new VisualElement.VisibilityConverter().ConvertFromInvariantString("True"));
        image.SetValue(View.MarginProperty, (object) new Thickness(30.0, 0.0, 30.0, 0.0));
        bindable3.Tapped += new EventHandler(bindable7.Login);
        image.GestureRecognizers.Add((IGestureRecognizer) bindable3);
        bindable6.Children.Add((View) image);
        extendedLabel1.SetValue(VisualElement.IsVisibleProperty, new VisualElement.VisibilityConverter().ConvertFromInvariantString("True"));
        extendedLabel1.SetValue(Label.TextProperty, (object) "Having trouble logging in?");
        extendedLabel1.SetValue(View.MarginProperty, (object) new Thickness(0.0, 20.0, 0.0, 0.0));
        extendedLabel1.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.Center);
        resourceExtension3.Key = "smallLabel";
        StaticResourceExtension resourceExtension8 = resourceExtension3;
        XamlServiceProvider xamlServiceProvider3 = new XamlServiceProvider();
        Type type5 = typeof (IProvideValueTarget);
        object[] objectAndParents3 = new object[0 + 4];
        objectAndParents3[0] = (object) extendedLabel1;
        objectAndParents3[1] = (object) bindable6;
        objectAndParents3[2] = (object) stackLayout4;
        objectAndParents3[3] = (object) bindable7;
        SimpleValueTargetProvider service5 = new SimpleValueTargetProvider(objectAndParents3, (object) VisualElement.StyleProperty);
        xamlServiceProvider3.Add(type5, (object) service5);
        xamlServiceProvider3.Add(typeof (INameScopeProvider), (object) new NameScopeProvider()
        {
          NameScope = (INameScope) nameScope
        });
        Type type6 = typeof (IXamlTypeResolver);
        XmlNamespaceResolver namespaceResolver3 = new XmlNamespaceResolver();
        namespaceResolver3.Add("", "http://xamarin.com/schemas/2014/forms");
        namespaceResolver3.Add("x", "http://schemas.microsoft.com/winfx/2009/xaml");
        namespaceResolver3.Add("xlabs", "clr-namespace:XLabs.Forms.Controls;assembly=XLabs.Forms");
        XamlTypeResolver service6 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver3, typeof (LoginPage).GetTypeInfo().Assembly);
        xamlServiceProvider3.Add(type6, (object) service6);
        xamlServiceProvider3.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(33, 160)));
        object obj3 = resourceExtension8.ProvideValue((IServiceProvider) xamlServiceProvider3);
        extendedLabel1.Style = (Style) obj3;
        extendedLabel1.SetValue(Label.TextColorProperty, (object) new Color(1.0, 1.0, 1.0, 1.0));
        extendedLabel1.SetValue(ExtendedLabel.IsUnderlineProperty, (object) true);
        bindable4.Tapped += new EventHandler(bindable7.HavingTrouble_Tapped);
        extendedLabel1.GestureRecognizers.Add((IGestureRecognizer) bindable4);
        bindable6.Children.Add((View) extendedLabel1);
        stackLayout2.SetValue(VisualElement.IsVisibleProperty, new VisualElement.VisibilityConverter().ConvertFromInvariantString("false"));
        stackLayout1.SetValue(VisualElement.BackgroundColorProperty, (object) new Color(0.20392157137394, 0.227450981736183, 0.250980406999588, 1.0));
        stackLayout1.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.FillAndExpand);
        stackLayout1.SetValue(View.VerticalOptionsProperty, (object) LayoutOptions.End);
        stackLayout1.SetValue(Layout.PaddingProperty, (object) new Thickness(5.0));
        stackLayout1.SetValue(View.MarginProperty, (object) new Thickness(0.0, 5.0, 0.0, 5.0));
        label3.SetValue(Label.TextProperty, (object) "Apologies, the server is undergoing maintenance.");
        label3.SetValue(View.MarginProperty, (object) new Thickness(35.0, 0.0, 35.0, 0.0));
        label3.SetValue(View.VerticalOptionsProperty, (object) LayoutOptions.Center);
        label3.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.CenterAndExpand);
        label3.SetValue(Label.HorizontalTextAlignmentProperty, new TextAlignmentConverter().ConvertFromInvariantString("Center"));
        resourceExtension4.Key = "smallLabel";
        StaticResourceExtension resourceExtension9 = resourceExtension4;
        XamlServiceProvider xamlServiceProvider4 = new XamlServiceProvider();
        Type type7 = typeof (IProvideValueTarget);
        object[] objectAndParents4 = new object[0 + 6];
        objectAndParents4[0] = (object) label3;
        objectAndParents4[1] = (object) stackLayout1;
        objectAndParents4[2] = (object) stackLayout2;
        objectAndParents4[3] = (object) bindable6;
        objectAndParents4[4] = (object) stackLayout4;
        objectAndParents4[5] = (object) bindable7;
        SimpleValueTargetProvider service7 = new SimpleValueTargetProvider(objectAndParents4, (object) VisualElement.StyleProperty);
        xamlServiceProvider4.Add(type7, (object) service7);
        xamlServiceProvider4.Add(typeof (INameScopeProvider), (object) new NameScopeProvider()
        {
          NameScope = (INameScope) nameScope
        });
        Type type8 = typeof (IXamlTypeResolver);
        XmlNamespaceResolver namespaceResolver4 = new XmlNamespaceResolver();
        namespaceResolver4.Add("", "http://xamarin.com/schemas/2014/forms");
        namespaceResolver4.Add("x", "http://schemas.microsoft.com/winfx/2009/xaml");
        namespaceResolver4.Add("xlabs", "clr-namespace:XLabs.Forms.Controls;assembly=XLabs.Forms");
        XamlTypeResolver service8 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver4, typeof (LoginPage).GetTypeInfo().Assembly);
        xamlServiceProvider4.Add(type8, (object) service8);
        xamlServiceProvider4.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(42, 224)));
        object obj4 = resourceExtension9.ProvideValue((IServiceProvider) xamlServiceProvider4);
        label3.Style = (Style) obj4;
        label3.SetValue(Label.FontFamilyProperty, (object) "Roboto-Regular.ttf#Roboto");
        label3.SetValue(Label.TextColorProperty, (object) Color.White);
        stackLayout1.Children.Add((View) label3);
        stackLayout2.Children.Add((View) stackLayout1);
        bindable6.Children.Add((View) stackLayout2);
        stackLayout3.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.FillAndExpand);
        stackLayout3.SetValue(Layout.PaddingProperty, (object) new Thickness(5.0));
        stackLayout3.SetValue(View.MarginProperty, (object) new Thickness(0.0, 5.0, 0.0, 5.0));
        extendedLabel2.SetValue(VisualElement.IsVisibleProperty, new VisualElement.VisibilityConverter().ConvertFromInvariantString("True"));
        extendedLabel2.SetValue(Label.TextProperty, (object) "Refresh");
        extendedLabel2.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.Center);
        resourceExtension5.Key = "smallLabel";
        StaticResourceExtension resourceExtension10 = resourceExtension5;
        XamlServiceProvider xamlServiceProvider5 = new XamlServiceProvider();
        Type type9 = typeof (IProvideValueTarget);
        object[] objectAndParents5 = new object[0 + 5];
        objectAndParents5[0] = (object) extendedLabel2;
        objectAndParents5[1] = (object) stackLayout3;
        objectAndParents5[2] = (object) bindable6;
        objectAndParents5[3] = (object) stackLayout4;
        objectAndParents5[4] = (object) bindable7;
        SimpleValueTargetProvider service9 = new SimpleValueTargetProvider(objectAndParents5, (object) VisualElement.StyleProperty);
        xamlServiceProvider5.Add(type9, (object) service9);
        xamlServiceProvider5.Add(typeof (INameScopeProvider), (object) new NameScopeProvider()
        {
          NameScope = (INameScope) nameScope
        });
        Type type10 = typeof (IXamlTypeResolver);
        XmlNamespaceResolver namespaceResolver5 = new XmlNamespaceResolver();
        namespaceResolver5.Add("", "http://xamarin.com/schemas/2014/forms");
        namespaceResolver5.Add("x", "http://schemas.microsoft.com/winfx/2009/xaml");
        namespaceResolver5.Add("xlabs", "clr-namespace:XLabs.Forms.Controls;assembly=XLabs.Forms");
        XamlTypeResolver service10 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver5, typeof (LoginPage).GetTypeInfo().Assembly);
        xamlServiceProvider5.Add(type10, (object) service10);
        xamlServiceProvider5.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(47, 121)));
        object obj5 = resourceExtension10.ProvideValue((IServiceProvider) xamlServiceProvider5);
        extendedLabel2.Style = (Style) obj5;
        extendedLabel2.SetValue(Label.TextColorProperty, (object) new Color(1.0, 1.0, 1.0, 1.0));
        extendedLabel2.SetValue(ExtendedLabel.IsUnderlineProperty, (object) true);
        bindable5.Tapped += new EventHandler(bindable7.lblRefresh_Tapped);
        extendedLabel2.GestureRecognizers.Add((IGestureRecognizer) bindable5);
        stackLayout3.Children.Add((View) extendedLabel2);
        bindable6.Children.Add((View) stackLayout3);
        stackLayout4.Children.Add((View) bindable6);
        bindable7.SetValue(ContentPage.ContentProperty, (object) stackLayout4);
      }
    }

    private void __InitComponentRuntime()
    {
      this.LoadFromXaml<LoginPage>(typeof (LoginPage));
      this.stackBody = NameScopeExtensions.FindByName<StackLayout>(this, "stackBody");
      this.lblWelcome = NameScopeExtensions.FindByName<Label>(this, "lblWelcome");
      this.lblIndicator = NameScopeExtensions.FindByName<Label>(this, "lblIndicator");
      this.activityIndicator = NameScopeExtensions.FindByName<ActivityIndicator>(this, "activityIndicator");
      this.btnLogin = NameScopeExtensions.FindByName<Xamarin.Forms.Image>(this, "btnLogin");
      this.lblEmailRecovery = NameScopeExtensions.FindByName<ExtendedLabel>(this, "lblEmailRecovery");
      this.stackServerDown = NameScopeExtensions.FindByName<StackLayout>(this, "stackServerDown");
      this.stackServerDownMessage = NameScopeExtensions.FindByName<StackLayout>(this, "stackServerDownMessage");
      this.lblServerDown = NameScopeExtensions.FindByName<Label>(this, "lblServerDown");
      this.stackRefresh = NameScopeExtensions.FindByName<StackLayout>(this, "stackRefresh");
      this.lblRefresh = NameScopeExtensions.FindByName<ExtendedLabel>(this, "lblRefresh");
    }
  }
}
