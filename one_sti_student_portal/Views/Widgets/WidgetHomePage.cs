// Decompiled with JetBrains decompiler
// Type: one_sti_student_portal.Views.Widgets.WidgetHomePage
// Assembly: one_sti_student_portal, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 39E34984-485E-45CE-9895-F7524E3024D6
// Assembly location: \\wsl.localhost\kali-linux\root\One STI Student Portal_1.3.8_apkcombo.com (1)\unknown\assemblies\one_sti_student_portal.dll

using FFImageLoading.Forms;
using Newtonsoft.Json;
using one_sti_student_portal.Data;
using one_sti_student_portal.Helpers;
using one_sti_student_portal.Models;
using one_sti_student_portal.Models.Widget;
using one_sti_student_portal.Renderers;
using one_sti_student_portal.Services;
using one_sti_student_portal.Views.Students;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using System.Xml;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.Xaml.Internals;
using XLabs.Forms.Controls;

namespace one_sti_student_portal.Views.Widgets
{
  [XamlFilePath("Views\\Widgets\\WidgetHomePage.xaml")]
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public class WidgetHomePage : ContentPage
  {
    private NewsData _newsData;
    private WidgetsData _widgetData;
    private StudentData _studentData;
    private int _currentNewsId;
    private string NewsFeedUri = "https://www.sti.edu/stinews/api/Newsarticles";
    private bool _isConnected;
    private bool _updateNews;
    public static bool _isRefresh = true;
    private string serverStatus;
    private List<Color> _listColors;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private StackLayout versionOutOfDate;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private ScrollView scrollMain;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private Frame frameServerDown;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private Label lblServerDown;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private ExtendedLabel lblRefresh;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private Grid gridWidgets;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private Frame frmScheduleToday;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private StackLayout stackScheduleHeader;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private Label lblToday;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private Label lblLastScheduleSync;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private ActivityIndicator loadingTodayClass;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private StackLayout stackTodaySchedule;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private Frame frmNextPayment;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private Label lblPaymentSync;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private ActivityIndicator loadingPaymentSched;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private Label lblPaymentRemarks;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private StackLayout stackPaymentSchedule;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private Label lblNexyPaymentAmount;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private Label lblPaymentDue;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private Frame frmLatestNews;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private StackLayout stackNews;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private Label lblNewsTitle;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private CachedImage imgNewsHeader;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private Label lblNewsContent;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private Frame frmLatestGrades;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private Label lblViewAllGrades;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private Label lblGradeAsOf;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private ActivityIndicator loadingGrade;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private Label lblGradeRemarks;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private StackLayout stackLatestGrade;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private Label lblProfessor;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private Label lblSubjectInfo;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private Label lblGradePeriod;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private Label lblLatestGrade;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private StackLayout stackGradesVisibility;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private Label lblMessage;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private StackLayout stackStatus;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private Label lblStatus;

    public WidgetHomePage()
    {
      this.InitializeComponent();
      WidgetHomePage._isRefresh = true;
      switch (Device.RuntimePlatform)
      {
        case "Android":
          this.ToolbarItems.Add(new ToolbarItem("", "ic_action_add_widget", (Action) (() => this.Navigation.PushAsync((Page) new WidgetSettingsPage(), true))));
          this.ToolbarItems.Add(new ToolbarItem("", "ic_action_notifications", (Action) (() => this.Navigation.PushAsync((Page) new NotificationPage(), true))));
          break;
        case "iOS":
          this.ToolbarItems.Add(new ToolbarItem("+", (string) null, (Action) (() => this.Navigation.PushAsync((Page) new WidgetSettingsPage(), true))));
          break;
        default:
          throw new ArgumentOutOfRangeException();
      }
      this._newsData = new NewsData();
      this._widgetData = new WidgetsData();
      this._studentData = new StudentData();
      this._isConnected = ConnectionHelper.IsConnected();
      Connectivity.ConnectivityChanged += (EventHandler<ConnectivityChangedEventArgs>) ((sender, args) =>
      {
        this._isConnected = ConnectionHelper.IsConnected();
        this.CheckStatus();
      });
      Task.Run((Func<Task>) (async () => this.serverStatus = await this.ServerStatusAsync())).ContinueWith((Action<Task>) (result => Device.BeginInvokeOnMainThread((Action) (() =>
      {
        if (this.serverStatus == "true")
        {
          this.gridWidgets.IsVisible = true;
          this.frameServerDown.IsVisible = false;
          this.CreateWidgets();
        }
        else if (this.serverStatus == "down")
        {
          this.gridWidgets.IsVisible = false;
          this.frameServerDown.IsVisible = true;
          this.versionOutOfDate.IsVisible = false;
          Acr.UserDialogs.UserDialogs.Instance.Toast("Unable to retrieve data.", new TimeSpan?(new TimeSpan(0, 0, 5)));
        }
        else if (this.serverStatus == "not connected")
        {
          this.gridWidgets.IsVisible = true;
          this.frameServerDown.IsVisible = false;
          Acr.UserDialogs.UserDialogs.Instance.Toast("Please check your network connection and try again.", new TimeSpan?(new TimeSpan(0, 0, 5)));
        }
        else
        {
          this.gridWidgets.IsVisible = true;
          this.frameServerDown.IsVisible = false;
          Acr.UserDialogs.UserDialogs.Instance.Toast("An error occured while establishing a connection to the server.", new TimeSpan?(new TimeSpan(0, 0, 5)));
        }
      }))));
    }

    private void CheckStatus()
    {
      if (this._isConnected)
      {
        this.stackStatus.IsVisible = true;
        this.stackStatus.BackgroundColor = Color.FromHex("#03a678");
        this.lblStatus.Text = "Back online";
        Device.StartTimer(TimeSpan.FromSeconds(5.0), (Func<bool>) (() =>
        {
          this.stackStatus.FadeTo(0.0, 1000U);
          this.stackStatus.IsVisible = false;
          return false;
        }));
      }
      else
      {
        this.stackStatus.FadeTo(1.0, 1000U);
        this.stackStatus.IsVisible = true;
        this.stackStatus.BackgroundColor = Color.FromHex("#2e3131");
        this.lblStatus.Text = "No connection";
      }
    }

    protected override void OnAppearing()
    {
      base.OnAppearing();
      this._isConnected = ConnectionHelper.IsConnected();
      if (!this._isConnected)
      {
        this.stackStatus.BackgroundColor = Color.FromHex("#2e3131");
        this.stackStatus.IsVisible = true;
        this.lblStatus.Text = "No connection";
      }
      else
        this.CheckAppVersion();
      if (!WidgetHomePage._isRefresh)
        return;
      this.CreateWidgets();
      Device.StartTimer(TimeSpan.FromSeconds(2.0), (Func<bool>) (() =>
      {
        this.RefreshSchedule();
        this.RefreshLatestGrade();
        this.RefreshPaymentSchedule();
        this.RefreshFeedbacks();
        return false;
      }));
      WidgetHomePage._isRefresh = false;
    }

    private void CreateWidgets()
    {
      this.gridWidgets.IsVisible = true;
      this.frameServerDown.IsVisible = false;
      try
      {
        Device.BeginInvokeOnMainThread((Action) (() =>
        {
          List<WidgetSettings> result = this._widgetData.GetSelectedWidgets().Result;
          int num = 0;
          foreach (WidgetSettings widgetSettings in result)
          {
            if (widgetSettings.Widget.ToLower().Contains("news"))
            {
              this.LoadLatestNews();
              this.RefreshNewsFeed();
            }
            if (widgetSettings.Widget.ToLower().Contains("classes"))
              this.CreateScheduleWidget();
            if (widgetSettings.Widget.ToLower().Contains("payment"))
              this.CreatePaymentSchedWidget();
            if (widgetSettings.Widget.ToLower().Contains("grade"))
              this.CreateLatestGradeWidget();
          }
          this.gridWidgets.Children.Clear();
          foreach (WidgetSettings widgetSettings in result)
          {
            widgetSettings.WidgetRow = num;
            ++num;
          }
          foreach (WidgetSettings widgetSettings in result)
          {
            if (widgetSettings.Widget.ToLower().Contains("news"))
            {
              this.frmLatestNews.IsVisible = true;
              this.gridWidgets.Children.Add((View) this.frmLatestNews, 0, widgetSettings.WidgetRow);
            }
            if (widgetSettings.Widget.ToLower().Contains("classes"))
            {
              this.frmScheduleToday.IsVisible = true;
              this.gridWidgets.Children.Add((View) this.frmScheduleToday, 0, widgetSettings.WidgetRow);
            }
            if (widgetSettings.Widget.ToLower().Contains("payment"))
            {
              this.frmNextPayment.IsVisible = true;
              this.gridWidgets.Children.Add((View) this.frmNextPayment, 0, widgetSettings.WidgetRow);
            }
            if (widgetSettings.Widget.ToLower().Contains("grade"))
            {
              this.frmLatestGrades.IsVisible = true;
              this.gridWidgets.Children.Add((View) this.frmLatestGrades, 0, widgetSettings.WidgetRow);
            }
          }
        }));
      }
      catch
      {
        this.DisplayAlert("One STI", "Trouble loading widgets.", "OK");
      }
    }

    protected override void OnDisappearing()
    {
      base.OnDisappearing();
      WidgetHomePage._isRefresh = false;
    }

    private void CheckAppVersion()
    {
      bool isUpdated = true;
      Task.Run((Func<Task>) (async () =>
      {
        try
        {
          isUpdated = (await new StudentService().CheckAppVersion(Constants.VersionCode)).Contains("true");
        }
        catch
        {
          isUpdated = true;
        }
      })).ContinueWith((Action<Task>) (result => Device.BeginInvokeOnMainThread((Action) (() =>
      {
        if (this.serverStatus == "true")
        {
          this.versionOutOfDate.IsVisible = !isUpdated;
        }
        else
        {
          if (!(this.serverStatus != "true"))
            return;
          this.versionOutOfDate.IsVisible = false;
        }
      }))));
    }

    private void LoadLatestNews() => this.CreateNewsWidget(this._newsData.GetNewsArticleAsync().Result);

    private void CreateNewsWidget(List<NewsArticles> lastestNews)
    {
      using (List<NewsArticles>.Enumerator enumerator = lastestNews.GetEnumerator())
      {
        if (!enumerator.MoveNext())
          return;
        NewsArticles current = enumerator.Current;
        this.imgNewsHeader.Source = (ImageSource) current.pic_large;
        this.lblNewsTitle.Text = current.title;
        this.lblNewsContent.Text = current.content_text;
        this._currentNewsId = current.newsno;
        this.frmLatestNews.FadeTo(1.0, 750U);
      }
    }

    private void RefreshNewsFeed() => Task.Run((Func<Task>) (async () =>
    {
      if (!await this.CheckUpdate())
        return;
      await this._newsData.DownloadNewsArticles(1);
    })).ContinueWith((Action<Task>) (result => Device.BeginInvokeOnMainThread((Action) (() =>
    {
      if (!this._updateNews)
        return;
      this.LoadLatestNews();
    }))));

    private void MoreNews_Tapped(object sender, EventArgs e) => this.Navigation.PushAsync((Page) new NewsFeedPage(), true);

    private void Learn_More_Tapped(object sender, EventArgs e)
    {
      if (this._isConnected)
        this.Navigation.PushAsync((Page) new NewsFeedDetailsPage(new NewsArticles()
        {
          newsno = this._currentNewsId
        }), true);
      else
        Acr.UserDialogs.UserDialogs.Instance.Toast("Network Error. Please check your internet connection.");
    }

    private async Task<bool> CheckUpdate()
    {
      List<NewsArticles> source = JsonConvert.DeserializeObject<List<NewsArticles>>(await new HttpClient().GetStringAsync(this.NewsFeedUri));
      List<NewsArticles> result = this._newsData.GetNewsArticleAsync().Result;
      if (result.Count == 0)
        return true;
      if (result.FirstOrDefault<NewsArticles>().newsno != source.FirstOrDefault<NewsArticles>().newsno)
      {
        this._updateNews = true;
        return true;
      }
      this._updateNews = false;
      return false;
    }

    private void RefreshSchedule()
    {
      try
      {
        Device.BeginInvokeOnMainThread((Action) (() => this.loadingTodayClass.IsVisible = true));
        Task.Run((Func<Task>) (async () =>
        {
          if (!ConnectionHelper.IsConnected())
            return;
          StudentService studentService = new StudentService();
          StudentInformation studentInfo = this._studentData.GetStudentInformation().Result.FirstOrDefault<StudentInformation>();
          StudentSemester latestSemester = this._studentData.GetLatestSemester().Result.FirstOrDefault<StudentSemester>();
          await this._studentData.DeleteSubjects();
          await this._studentData.DeleteSchedule(latestSemester.Semester);
          await this._studentData.DownloadSubjectsPerSemester(studentInfo.PSCSId, latestSemester.Semester);
          await this._studentData.DownloadSchedulePerSem(studentInfo.PSCSId, latestSemester.Semester);
          studentInfo = (StudentInformation) null;
          latestSemester = (StudentSemester) null;
        })).ContinueWith((Action<Task>) (result => Device.BeginInvokeOnMainThread((Action) (() =>
        {
          this.loadingTodayClass.IsVisible = false;
          if (!ConnectionHelper.IsConnected())
            Acr.UserDialogs.UserDialogs.Instance.Toast("Could not refresh. Check your network connection.");
          else
            this.CreateScheduleWidget();
        }))));
      }
      catch
      {
      }
    }

    private void CreateScheduleWidget()
    {
      List<StudentSemester> result = this._studentData.GetLatestSemester().Result;
      string strm = result.Count != 0 ? result.FirstOrDefault<StudentSemester>().Semester : "";
      DayOfWeek dayOfWeek = DateTime.Now.DayOfWeek;
      List<StudentSchedule> schedule1 = this._studentData.GetSchedule(strm, dayOfWeek.ToString());
      List<StudentSchedule> schedule2 = this._studentData.GetSchedule(strm, "0");
      this.lblToday.Text = "Classes for Today | " + DateTime.Now.DayOfWeek.ToString();
      this.FillColors();
      int num = 0;
      StackLayout stackLayout1 = new StackLayout()
      {
        Spacing = 0.0
      };
      if (schedule1.Count == 0 && schedule2.Count == 0)
      {
        this.stackScheduleHeader.VerticalOptions = LayoutOptions.Center;
        Label label1 = new Label();
        label1.Text = "No schedule available. Tap to refresh.";
        label1.Style = (Style) Application.Current.Resources["smallLabel"];
        label1.TextColor = Color.FromHex("#666666");
        Label label2 = label1;
        TapGestureRecognizer gestureRecognizer = new TapGestureRecognizer();
        gestureRecognizer.Tapped += (EventHandler) ((s, e) => this.RefreshSchedule());
        label2.GestureRecognizers.Add((IGestureRecognizer) gestureRecognizer);
        stackLayout1.Children.Add((View) label2);
      }
      else if (schedule1.Count == 0)
      {
        this.lblLastScheduleSync.IsVisible = true;
        this.lblLastScheduleSync.Text = "AS OF " + schedule2.OrderByDescending<StudentSchedule, DateTime>((Func<StudentSchedule, DateTime>) (o => o.AddDate)).ToList<StudentSchedule>().FirstOrDefault<StudentSchedule>().AddDate.ToString("dd MMM, yyyy").ToUpper();
        IList<View> children = stackLayout1.Children;
        Label label = new Label();
        label.Text = "Your schedule is free today.";
        label.Style = (Style) Application.Current.Resources["smallLabel"];
        label.TextColor = Color.FromHex("#666666");
        children.Add((View) label);
      }
      else
      {
        foreach (StudentSchedule studentSchedule in schedule1)
        {
          this.lblLastScheduleSync.IsVisible = true;
          this.lblLastScheduleSync.Text = "AS OF " + schedule2.OrderByDescending<StudentSchedule, DateTime>((Func<StudentSchedule, DateTime>) (o => o.AddDate)).ToList<StudentSchedule>().FirstOrDefault<StudentSchedule>().AddDate.ToString("dd MMM, yyyy").ToUpper();
          int index = num == 7 ? 0 : num;
          StackLayout stackLayout2 = new StackLayout()
          {
            Orientation = StackOrientation.Horizontal
          };
          StackLayout stackLayout3 = new StackLayout();
          stackLayout3.Spacing = 0.0;
          stackLayout3.BackgroundColor = this._listColors[index];
          stackLayout3.Padding = new Thickness(10.0);
          stackLayout3.HorizontalOptions = LayoutOptions.FillAndExpand;
          StackLayout stackLayout4 = stackLayout3;
          StackLayout stackLayout5 = new StackLayout();
          stackLayout5.Spacing = 2.0;
          stackLayout5.Margin = new Thickness(5.0, 0.0, 0.0, 0.0);
          stackLayout5.VerticalOptions = LayoutOptions.Center;
          stackLayout5.WidthRequest = 235.0;
          StackLayout stackLayout6 = stackLayout5;
          Label label3 = new Label();
          label3.Text = Convert.ToDateTime(studentSchedule.MeetingTimeStart).ToString("hh:mm tt");
          label3.Style = (Style) Application.Current.Resources["smallHeader"];
          label3.TextColor = Color.FromHex("#FFF");
          label3.HorizontalOptions = LayoutOptions.Center;
          label3.LineBreakMode = LineBreakMode.NoWrap;
          label3.Margin = new Thickness(2.0, 0.0, 2.0, 0.0);
          Label label4 = label3;
          Label label5 = new Label();
          label5.Text = "to " + Convert.ToDateTime(studentSchedule.MeetingTimeEnd).ToString("hh:mm tt");
          label5.Style = (Style) Application.Current.Resources["microLabel"];
          label5.FontSize = 11.0;
          label5.TextColor = Color.FromHex("#FFF");
          label5.HorizontalOptions = LayoutOptions.Center;
          label5.LineBreakMode = LineBreakMode.NoWrap;
          label5.Margin = new Thickness(2.0, 0.0, 2.0, 0.0);
          Label label6 = label5;
          stackLayout4.Children.Add((View) label4);
          stackLayout4.Children.Add((View) label6);
          Label label7 = new Label();
          label7.Text = studentSchedule.SubjectDesc;
          label7.Style = (Style) Application.Current.Resources["smallHeader"];
          label7.TextColor = Color.FromHex("#404040");
          Label label8 = label7;
          stackLayout6.Children.Add((View) label8);
          foreach (StudentSubjects studentSubjects in this._studentData.GetClassSubjectDetails(studentSchedule.ClassNumber).Result)
          {
            string str = string.IsNullOrWhiteSpace(studentSchedule.RoomCode) ? "TBA" : studentSchedule.RoomCode;
            studentSubjects.Professor = string.IsNullOrWhiteSpace(studentSubjects.Professor) ? "TBA" : studentSubjects.Professor;
            Label label9 = new Label();
            label9.Text = str + " | " + studentSubjects.Professor.ToUpper();
            label9.Style = (Style) Application.Current.Resources["microLabel"];
            label9.FontFamily = "Roboto-Medium.ttf#Roboto";
            label9.TextColor = Color.FromHex("#666666");
            label9.FontSize = 11.0;
            Label label10 = label9;
            stackLayout6.Children.Add((View) label10);
          }
          stackLayout2.Children.Add((View) stackLayout4);
          stackLayout2.Children.Add((View) stackLayout6);
          stackLayout1.Children.Add((View) stackLayout2);
          num = index + 1;
        }
      }
      try
      {
        this.stackTodaySchedule.Children.Clear();
      }
      catch
      {
      }
      this.stackTodaySchedule.Children.Add((View) stackLayout1);
      this.frmScheduleToday.FadeTo(1.0, 750U);
    }

    private void Schedule_Tapped(object sender, EventArgs e)
    {
      MasterDetail masterDetail1 = new MasterDetail();
      masterDetail1.Detail = (Page) new NavigationPage((Page) new StudentViewTabbedPage());
      MasterDetail masterDetail2 = masterDetail1;
      StudentViewTabbedPage.selectedTabIndex = 1;
      Application.Current.MainPage = (Page) masterDetail2;
    }

    public void FillColors() => this._listColors = new List<Color>()
    {
      Color.FromHex("#2c82c9"),
      Color.FromHex("#f2784b"),
      Color.FromHex("#d64541"),
      Color.FromHex("#fdcb6e"),
      Color.FromHex("#9b59b6"),
      Color.FromHex("#2c3e50"),
      Color.FromHex("#019875")
    };

    private void DownloadUpdatedVersion(object sender, EventArgs e) => Device.BeginInvokeOnMainThread((Action) (() => Device.OpenUri(new Uri("https://play.google.com/store/apps/details?id=com.onesti.student.portal"))));

    private void CreatePaymentSchedWidget()
    {
      List<StudentNetAssessment> result = this._studentData.GetNetAssessment().Result;
      using (List<StudentNetAssessment>.Enumerator enumerator = result.GetEnumerator())
      {
        if (enumerator.MoveNext())
        {
          StudentNetAssessment current = enumerator.Current;
          this.lblNexyPaymentAmount.Text = "PhP " + current.DueAmount.ToString("N");
          this.lblPaymentDue.Text = current.DueDate.ToString("dd MMM, yyyy").ToString();
        }
      }
      DateTime recentTransactionDate = this._studentData.GetRecentTransactionDate(this._studentData.GetStudentInformation().Result.FirstOrDefault<StudentInformation>().SchoolTerm);
      this.lblPaymentSync.IsVisible = !(recentTransactionDate == DateTime.MinValue);
      this.lblPaymentSync.Text = "AS OF " + recentTransactionDate.ToString("dd MMM, yyyy").ToUpper();
      if (result.Count == 0)
      {
        this.stackPaymentSchedule.IsVisible = false;
        this.lblPaymentRemarks.IsVisible = true;
      }
      else
      {
        this.stackPaymentSchedule.IsVisible = true;
        this.lblPaymentRemarks.IsVisible = false;
      }
      this.frmNextPayment.FadeTo(1.0, 750U);
    }

    private void RefreshPayment_Tapped(object sender, EventArgs e) => this.RefreshPaymentSchedule();

    private void ViewAllPayment_Tapped(object sender, EventArgs e)
    {
      MasterDetail masterDetail1 = new MasterDetail();
      masterDetail1.Detail = (Page) new NavigationPage((Page) new StudentViewTabbedPage());
      MasterDetail masterDetail2 = masterDetail1;
      List<StudentInformation> result = this._studentData.GetStudentInformation().Result;
      if (result.Count != 0)
        StudentViewTabbedPage.selectedTabIndex = !result.FirstOrDefault<StudentInformation>().AcadLevel.Contains("G") ? 3 : 2;
      Application.Current.MainPage = (Page) masterDetail2;
    }

    private void RefreshPaymentSchedule()
    {
      Device.BeginInvokeOnMainThread((Action) (() => this.loadingPaymentSched.IsVisible = true));
      Task.Run((Func<Task>) (async () =>
      {
        if (!ConnectionHelper.IsConnected())
          return;
        StudentService studentService = new StudentService();
        StudentInformation studentInfo = this._studentData.GetStudentInformation().Result.FirstOrDefault<StudentInformation>();
        await this._studentData.DeleteOSFDetails(studentInfo.SchoolTerm);
        await this._studentData.DeleteTuitionMiscDetails(studentInfo.SchoolTerm);
        await this._studentData.DeleteNetAssessment();
        await this._studentData.DownloadNetAssessment(studentInfo.PSCSId);
        studentInfo = (StudentInformation) null;
      })).ContinueWith((Action<Task>) (result => Device.BeginInvokeOnMainThread((Action) (() =>
      {
        this.loadingPaymentSched.IsVisible = false;
        this.CreatePaymentSchedWidget();
      }))));
    }

    private void CreateLatestGradeWidget()
    {
      string schoolTerm = this._studentData.GetStudentInformation().Result.FirstOrDefault<StudentInformation>().SchoolTerm;
      List<StudentSubjects> result1 = this._studentData.GetSubjectInfo(schoolTerm).Result;
      List<GradeListing> source = new List<GradeListing>();
      DateTime minValue = DateTime.MinValue;
      string str1 = "";
      foreach (StudentSubjects studentSubjects in result1)
      {
        List<StudentGrades> result2 = this._studentData.GetSubjectGradeDetail(schoolTerm, studentSubjects.ClassNumber).Result;
        DateTime dateTime = result2.Count == 0 ? DateTime.MinValue : result2.OrderByDescending<StudentGrades, DateTime>((Func<StudentGrades, DateTime>) (o => o.SubmittedOn)).ToList<StudentGrades>().FirstOrDefault<StudentGrades>().SubmittedOn;
        string str2 = result2.Count == 0 ? "" : result2.OrderByDescending<StudentGrades, DateTime>((Func<StudentGrades, DateTime>) (o => o.SubmittedOn)).ToList<StudentGrades>().FirstOrDefault<StudentGrades>().PeriodGrade;
        str1 = result2.Count == 0 ? "" : result2.OrderByDescending<StudentGrades, DateTime>((Func<StudentGrades, DateTime>) (o => o.SubmittedOn)).ToList<StudentGrades>().FirstOrDefault<StudentGrades>().GradingPeriod;
        source.Add(new GradeListing()
        {
          ClassNumber = studentSubjects.ClassNumber,
          CourseCareer = studentSubjects.CourseCareer,
          DatePosted = studentSubjects.DatePosted,
          FinalGrade = studentSubjects.FinalGrade,
          PeriodicGrade = str2,
          Professor = studentSubjects.Professor,
          SubjectDesc = studentSubjects.SubjectDesc,
          SubmittedOn = !(studentSubjects.FinalGrade != "-") || !(studentSubjects.DatePosted != DateTime.MinValue) ? dateTime : studentSubjects.DatePosted
        });
      }
      if (source.Count != 0)
      {
        using (List<GradeListing>.Enumerator enumerator = source.OrderByDescending<GradeListing, DateTime>((Func<GradeListing, DateTime>) (o => o.SubmittedOn)).ToList<GradeListing>().GetEnumerator())
        {
          if (enumerator.MoveNext())
          {
            GradeListing current = enumerator.Current;
            if ((current.PeriodicGrade == "-" || string.IsNullOrEmpty(current.PeriodicGrade)) && current.SubmittedOn == DateTime.MinValue)
            {
              this.lblGradeRemarks.IsVisible = true;
              this.stackLatestGrade.IsVisible = false;
              this.lblGradeAsOf.IsVisible = false;
              this.lblViewAllGrades.IsVisible = false;
            }
            else
            {
              this.lblViewAllGrades.IsVisible = true;
              this.lblGradeRemarks.IsVisible = false;
              this.stackLatestGrade.IsVisible = true;
              this.lblGradeAsOf.IsVisible = true;
              this.lblGradeAsOf.Text = "AS OF " + current.SubmittedOn.ToString("dd MMM, yyyy").ToUpper();
              this.lblSubjectInfo.Text = current.SubjectDesc;
              this.lblGradePeriod.Text = str1.ToUpper();
              this.lblLatestGrade.Text = current.PeriodicGrade;
              this.lblProfessor.Text = current.Professor.ToUpper();
              if (current.CourseCareer == "SHS" && schoolTerm.EndsWith("01"))
              {
                switch (str1.ToLower())
                {
                  case "first quarter":
                    if (this.ShowQ1Grade())
                    {
                      this.lblLatestGrade.Text = current.PeriodicGrade;
                      this.stackGradesVisibility.IsVisible = false;
                      break;
                    }
                    this.lblLatestGrade.Text = "\uF070";
                    this.lblLatestGrade.TextColor = Color.FromHex("#dc3545");
                    this.lblLatestGrade.FontFamily = "FontAwesome5-Regular.otf#Regular";
                    this.stackGradesVisibility.IsVisible = true;
                    break;
                  case "second quarter":
                    if (this.ShowQ2Grade())
                    {
                      this.lblLatestGrade.Text = current.PeriodicGrade;
                      this.stackGradesVisibility.IsVisible = false;
                      break;
                    }
                    this.lblLatestGrade.Text = "\uF070";
                    this.lblLatestGrade.TextColor = Color.FromHex("#dc3545");
                    this.lblLatestGrade.FontFamily = "FontAwesome5-Regular.otf#Regular";
                    this.stackGradesVisibility.IsVisible = true;
                    break;
                  default:
                    if (this.ShowQ2Grade())
                    {
                      this.lblLatestGrade.Text = current.PeriodicGrade;
                      this.stackGradesVisibility.IsVisible = false;
                      break;
                    }
                    this.lblLatestGrade.Text = "\uF070";
                    this.lblLatestGrade.TextColor = Color.FromHex("#dc3545");
                    this.lblLatestGrade.FontFamily = "FontAwesome5-Regular.otf#Regular";
                    this.stackGradesVisibility.IsVisible = true;
                    break;
                }
              }
              else if (current.CourseCareer == "SHS" && schoolTerm.EndsWith("02"))
              {
                switch (str1.ToLower())
                {
                  case "first quarter":
                    if (this.ShowQ3Grade())
                    {
                      this.lblLatestGrade.Text = current.PeriodicGrade;
                      this.stackGradesVisibility.IsVisible = false;
                      break;
                    }
                    this.lblLatestGrade.Text = "\uF070";
                    this.lblLatestGrade.TextColor = Color.FromHex("#dc3545");
                    this.lblLatestGrade.FontFamily = "FontAwesome5-Regular.otf#Regular";
                    this.stackGradesVisibility.IsVisible = true;
                    break;
                  case "second quarter":
                    if (this.ShowQ4Grade())
                    {
                      this.lblLatestGrade.Text = current.PeriodicGrade;
                      this.stackGradesVisibility.IsVisible = false;
                      break;
                    }
                    this.lblLatestGrade.Text = "\uF070";
                    this.lblLatestGrade.TextColor = Color.FromHex("#dc3545");
                    this.lblLatestGrade.FontFamily = "FontAwesome5-Regular.otf#Regular";
                    this.stackGradesVisibility.IsVisible = true;
                    break;
                  default:
                    if (this.ShowQ4Grade())
                    {
                      this.lblLatestGrade.Text = current.PeriodicGrade;
                      this.stackGradesVisibility.IsVisible = false;
                      break;
                    }
                    this.lblLatestGrade.Text = "\uF070";
                    this.lblLatestGrade.TextColor = Color.FromHex("#dc3545");
                    this.lblLatestGrade.FontFamily = "FontAwesome5-Regular.otf#Regular";
                    this.stackGradesVisibility.IsVisible = true;
                    break;
                }
              }
              else if (current.CourseCareer == "SHS" && schoolTerm.EndsWith("03"))
              {
                switch (str1.ToLower())
                {
                  case "first quarter":
                    if (this.ShowQ1SummerGrade())
                    {
                      this.lblLatestGrade.Text = current.PeriodicGrade;
                      this.stackGradesVisibility.IsVisible = false;
                      break;
                    }
                    this.lblLatestGrade.Text = "\uF070";
                    this.lblLatestGrade.TextColor = Color.FromHex("#dc3545");
                    this.lblLatestGrade.FontFamily = "FontAwesome5-Regular.otf#Regular";
                    this.stackGradesVisibility.IsVisible = true;
                    break;
                  case "second quarter":
                    if (this.ShowQ2SummerGrade())
                    {
                      this.lblLatestGrade.Text = current.PeriodicGrade;
                      this.stackGradesVisibility.IsVisible = false;
                      break;
                    }
                    this.lblLatestGrade.Text = "\uF070";
                    this.lblLatestGrade.TextColor = Color.FromHex("#dc3545");
                    this.lblLatestGrade.FontFamily = "FontAwesome5-Regular.otf#Regular";
                    this.stackGradesVisibility.IsVisible = true;
                    break;
                  default:
                    if (this.ShowQ2SummerGrade())
                    {
                      this.lblLatestGrade.Text = current.PeriodicGrade;
                      this.stackGradesVisibility.IsVisible = false;
                      break;
                    }
                    this.lblLatestGrade.Text = "\uF070";
                    this.lblLatestGrade.TextColor = Color.FromHex("#dc3545");
                    this.lblLatestGrade.FontFamily = "FontAwesome5-Regular.otf#Regular";
                    this.stackGradesVisibility.IsVisible = true;
                    break;
                }
              }
              else
              {
                switch (str1.ToLower())
                {
                  case "prelim":
                    if (this.ShowPrelimGrade())
                    {
                      this.lblLatestGrade.Text = current.PeriodicGrade;
                      this.stackGradesVisibility.IsVisible = false;
                      break;
                    }
                    this.lblLatestGrade.Text = "\uF070";
                    this.lblLatestGrade.TextColor = Color.FromHex("#dc3545");
                    this.lblLatestGrade.FontFamily = "FontAwesome5-Regular.otf#Regular";
                    this.stackGradesVisibility.IsVisible = true;
                    break;
                  case "midterm":
                    if (this.ShowMidtermGrade())
                    {
                      this.lblLatestGrade.Text = current.PeriodicGrade;
                      this.stackGradesVisibility.IsVisible = false;
                      break;
                    }
                    this.lblLatestGrade.Text = "\uF070";
                    this.lblLatestGrade.TextColor = Color.FromHex("#dc3545");
                    this.lblLatestGrade.FontFamily = "FontAwesome5-Regular.otf#Regular";
                    this.stackGradesVisibility.IsVisible = true;
                    break;
                  case "pre finals":
                    if (this.ShowPreFinGrade())
                    {
                      this.lblLatestGrade.Text = current.PeriodicGrade;
                      this.stackGradesVisibility.IsVisible = false;
                      break;
                    }
                    this.lblLatestGrade.Text = "\uF070";
                    this.lblLatestGrade.TextColor = Color.FromHex("#dc3545");
                    this.lblLatestGrade.FontFamily = "FontAwesome5-Regular.otf#Regular";
                    this.stackGradesVisibility.IsVisible = true;
                    break;
                  case "finals":
                    if (this.ShowFinalsGrade())
                    {
                      this.lblLatestGrade.Text = current.PeriodicGrade;
                      this.stackGradesVisibility.IsVisible = false;
                      break;
                    }
                    this.lblLatestGrade.Text = "\uF070";
                    this.lblLatestGrade.TextColor = Color.FromHex("#dc3545");
                    this.lblLatestGrade.FontFamily = "FontAwesome5-Regular.otf#Regular";
                    this.lblLatestGrade.Margin = new Thickness(0.0, 0.0, 5.0, 0.0);
                    this.stackGradesVisibility.IsVisible = true;
                    break;
                  default:
                    if (this.ShowFinalsGrade())
                    {
                      this.lblLatestGrade.Text = current.PeriodicGrade;
                      this.stackGradesVisibility.IsVisible = false;
                      break;
                    }
                    this.lblLatestGrade.Text = "\uF070";
                    this.lblLatestGrade.TextColor = Color.FromHex("#dc3545");
                    this.lblLatestGrade.FontFamily = "FontAwesome5-Regular.otf#Regular";
                    this.stackGradesVisibility.IsVisible = true;
                    break;
                }
              }
            }
          }
        }
      }
      else
      {
        this.lblGradeRemarks.IsVisible = true;
        this.stackLatestGrade.IsVisible = false;
        this.lblGradeAsOf.IsVisible = false;
        this.lblViewAllGrades.IsVisible = false;
      }
      this.frmLatestGrades.FadeTo(1.0, 750U);
    }

    private void ViewAllGrades_Tapped(object sender, EventArgs e)
    {
      StudentViewTabbedPage.selectedTabIndex = 0;
      MasterDetail masterDetail = new MasterDetail();
      masterDetail.Detail = (Page) new NavigationPage((Page) new StudentViewTabbedPage());
      Application.Current.MainPage = (Page) masterDetail;
    }

    private void RefreshLatestGrade()
    {
      Device.BeginInvokeOnMainThread((Action) (() => this.loadingGrade.IsVisible = true));
      Task.Run((Func<Task>) (async () =>
      {
        if (!ConnectionHelper.IsConnected())
          return;
        StudentService studentService = new StudentService();
        StudentInformation studentInfo = this._studentData.GetStudentInformation().Result.FirstOrDefault<StudentInformation>();
        await this._studentData.DeleteGrades(studentInfo.SchoolTerm);
        await this._studentData.DownloadSemesterGrades(studentInfo.PSCSId, studentInfo.SchoolTerm);
        studentInfo = (StudentInformation) null;
      })).ContinueWith((Action<Task>) (result => Device.BeginInvokeOnMainThread((Action) (() =>
      {
        this.loadingGrade.IsVisible = false;
        this.CreateLatestGradeWidget();
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

    private void lblRefresh_Tapped(object sender, EventArgs e) => this.CreateWidgets();

    private void RefreshFeedbacks()
    {
      string email = this._studentData.GetStudentInformation().Result.FirstOrDefault<StudentInformation>().Email;
      FeedbackData feedbackData = new FeedbackData();
      Task.Run((Func<Task>) (async () =>
      {
        if (!this._isConnected)
          return;
        await feedbackData.DownloadMyFeedbacks(email);
      })).ContinueWith((Action<Task>) (result => Device.BeginInvokeOnMainThread((Action) (() =>
      {
        List<FeedbackWithReply> list = feedbackData.GetMyFeedbacks(email).Result.Where<FeedbackWithReply>((Func<FeedbackWithReply, bool>) (o => o.unread)).ToList<FeedbackWithReply>();
        if (list.Count == 0)
          DependencyService.Get<IToolbarItemBadgeService>().SetBadge((Page) this, this.ToolbarItems[1], string.Empty, Color.Red, Color.White);
        else
          DependencyService.Get<IToolbarItemBadgeService>().SetBadge((Page) this, this.ToolbarItems[1], list.Count.ToString(), Color.Red, Color.White);
      }))));
    }

    private bool ShowPrelimGrade()
    {
      List<StudentDueDetails> result = this._studentData.GetDueDetails().Result;
      int count = result.Count;
      int num1 = 0;
      switch (count)
      {
        case 1:
          num1 = count;
          break;
        case 4:
          num1 = 1;
          break;
        case 5:
          num1 = 2;
          break;
      }
      float num2 = 0.0f;
      float num3 = 0.0f;
      int num4 = 1;
      foreach (StudentDueDetails studentDueDetails in result)
      {
        if (num4 <= num1)
        {
          num2 += studentDueDetails.DueAmount;
          num3 += studentDueDetails.AppliedAmount;
          ++num4;
        }
        else
          break;
      }
      return (double) num2 <= (double) num3;
    }

    private bool ShowMidtermGrade()
    {
      List<StudentDueDetails> result = this._studentData.GetDueDetails().Result;
      int count = result.Count;
      int num1 = 0;
      switch (count)
      {
        case 1:
          num1 = count;
          break;
        case 4:
          num1 = 2;
          break;
        case 5:
          num1 = 3;
          break;
      }
      float num2 = 0.0f;
      float num3 = 0.0f;
      int num4 = 1;
      foreach (StudentDueDetails studentDueDetails in result)
      {
        if (num4 <= num1)
        {
          num2 += studentDueDetails.DueAmount;
          num3 += studentDueDetails.AppliedAmount;
          ++num4;
        }
        else
          break;
      }
      return (double) num2 <= (double) num3;
    }

    private bool ShowPreFinGrade()
    {
      List<StudentDueDetails> result = this._studentData.GetDueDetails().Result;
      int count = result.Count;
      int num1 = 0;
      switch (count)
      {
        case 1:
          num1 = count;
          break;
        case 4:
          num1 = 3;
          break;
        case 5:
          num1 = 4;
          break;
      }
      float num2 = 0.0f;
      float num3 = 0.0f;
      int num4 = 1;
      foreach (StudentDueDetails studentDueDetails in result)
      {
        if (num4 <= num1)
        {
          num2 += studentDueDetails.DueAmount;
          num3 += studentDueDetails.AppliedAmount;
          ++num4;
        }
        else
          break;
      }
      return (double) num2 <= (double) num3;
    }

    private bool ShowFinalsGrade()
    {
      List<StudentDueDetails> result = this._studentData.GetDueDetails().Result;
      int count = result.Count;
      int num1 = 0;
      switch (count)
      {
        case 1:
          num1 = count;
          break;
        case 4:
          num1 = 4;
          break;
        case 5:
          num1 = 5;
          break;
      }
      float num2 = 0.0f;
      float num3 = 0.0f;
      int num4 = 1;
      foreach (StudentDueDetails studentDueDetails in result)
      {
        if (num4 <= num1)
        {
          num2 += studentDueDetails.DueAmount;
          num3 += studentDueDetails.AppliedAmount;
          ++num4;
        }
        else
          break;
      }
      return (double) num2 <= (double) num3;
    }

    private bool ShowQ1Grade()
    {
      List<StudentDueDetails> result = this._studentData.GetDueDetails().Result;
      int count = result.Count;
      int num1 = 0;
      switch (count)
      {
        case 1:
          num1 = count;
          break;
        case 2:
          num1 = 1;
          break;
        case 4:
          num1 = 1;
          break;
        case 10:
          num1 = 3;
          break;
      }
      float num2 = 0.0f;
      float num3 = 0.0f;
      int num4 = 1;
      foreach (StudentDueDetails studentDueDetails in result)
      {
        if (num4 <= num1)
        {
          num2 += studentDueDetails.DueAmount;
          num3 += studentDueDetails.AppliedAmount;
          ++num4;
        }
        else
          break;
      }
      return (double) num2 <= (double) num3;
    }

    private bool ShowQ2Grade()
    {
      List<StudentDueDetails> result = this._studentData.GetDueDetails().Result;
      int count = result.Count;
      int num1 = 0;
      switch (count)
      {
        case 1:
          num1 = count;
          break;
        case 2:
          num1 = 1;
          break;
        case 4:
          num1 = 2;
          break;
        case 10:
          num1 = 5;
          break;
      }
      float num2 = 0.0f;
      float num3 = 0.0f;
      int num4 = 1;
      foreach (StudentDueDetails studentDueDetails in result)
      {
        if (num4 <= num1)
        {
          num2 += studentDueDetails.DueAmount;
          num3 += studentDueDetails.AppliedAmount;
          ++num4;
        }
        else
          break;
      }
      return (double) num2 <= (double) num3;
    }

    private bool ShowQ3Grade()
    {
      List<StudentDueDetails> result = this._studentData.GetDueDetails().Result;
      int count = result.Count;
      int num1 = 0;
      switch (count)
      {
        case 1:
          num1 = count;
          break;
        case 2:
          num1 = 2;
          break;
        case 4:
          num1 = 3;
          break;
        case 10:
          num1 = 8;
          break;
      }
      float num2 = 0.0f;
      float num3 = 0.0f;
      int num4 = 1;
      foreach (StudentDueDetails studentDueDetails in result)
      {
        if (num4 <= num1)
        {
          num2 += studentDueDetails.DueAmount;
          num3 += studentDueDetails.AppliedAmount;
          ++num4;
        }
        else
          break;
      }
      return (double) num2 <= (double) num3;
    }

    private bool ShowQ4Grade()
    {
      List<StudentDueDetails> result = this._studentData.GetDueDetails().Result;
      int count = result.Count;
      int num1 = 0;
      switch (count)
      {
        case 1:
          num1 = count;
          break;
        case 2:
          num1 = 2;
          break;
        case 4:
          num1 = 4;
          break;
        case 10:
          num1 = 10;
          break;
      }
      float num2 = 0.0f;
      float num3 = 0.0f;
      int num4 = 1;
      foreach (StudentDueDetails studentDueDetails in result)
      {
        if (num4 <= num1)
        {
          num2 += studentDueDetails.DueAmount;
          num3 += studentDueDetails.AppliedAmount;
          ++num4;
        }
        else
          break;
      }
      return (double) num2 <= (double) num3;
    }

    private bool ShowQ1SummerGrade()
    {
      List<StudentDueDetails> result = this._studentData.GetDueDetails().Result;
      int count = result.Count;
      int num1 = 0;
      switch (count)
      {
        case 1:
          num1 = count;
          break;
        case 2:
          num1 = 1;
          break;
        case 3:
          num1 = 1;
          break;
        case 4:
          num1 = 1;
          break;
      }
      float num2 = 0.0f;
      float num3 = 0.0f;
      int num4 = 1;
      foreach (StudentDueDetails studentDueDetails in result)
      {
        if (num4 <= num1)
        {
          num2 += studentDueDetails.DueAmount;
          num3 += studentDueDetails.AppliedAmount;
          ++num4;
        }
        else
          break;
      }
      return (double) num2 <= (double) num3;
    }

    private bool ShowQ2SummerGrade()
    {
      List<StudentDueDetails> result = this._studentData.GetDueDetails().Result;
      int count = result.Count;
      int num1 = 0;
      switch (count)
      {
        case 1:
          num1 = count;
          break;
        case 2:
          num1 = 2;
          break;
        case 3:
          num1 = 3;
          break;
        case 4:
          num1 = 4;
          break;
      }
      float num2 = 0.0f;
      float num3 = 0.0f;
      int num4 = 1;
      foreach (StudentDueDetails studentDueDetails in result)
      {
        if (num4 <= num1)
        {
          num2 += studentDueDetails.DueAmount;
          num3 += studentDueDetails.AppliedAmount;
          ++num4;
        }
        else
          break;
      }
      return (double) num2 <= (double) num3;
    }

    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private void InitializeComponent()
    {
      if (ResourceLoader.ResourceProvider != null && ResourceLoader.ResourceProvider(typeof (WidgetHomePage).GetTypeInfo().Assembly.GetName(), "Views/Widgets/WidgetHomePage.xaml") != null)
        this.__InitComponentRuntime();
      else if (Xamarin.Forms.Xaml.Internals.XamlLoader.XamlFileProvider != null && Xamarin.Forms.Xaml.Internals.XamlLoader.XamlFileProvider(this.GetType()) != null)
      {
        this.__InitComponentRuntime();
      }
      else
      {
        StaticResourceExtension resourceExtension1 = new StaticResourceExtension();
        StaticResourceExtension resourceExtension2 = new StaticResourceExtension();
        TapGestureRecognizer bindable1 = new TapGestureRecognizer();
        Label bindable2 = new Label();
        StackLayout stackLayout1 = new StackLayout();
        StaticResourceExtension resourceExtension3 = new StaticResourceExtension();
        Label label1 = new Label();
        StaticResourceExtension resourceExtension4 = new StaticResourceExtension();
        TapGestureRecognizer bindable3 = new TapGestureRecognizer();
        ExtendedLabel extendedLabel = new ExtendedLabel();
        StackLayout bindable4 = new StackLayout();
        Frame frame1 = new Frame();
        RowDefinition bindable5 = new RowDefinition();
        RowDefinition bindable6 = new RowDefinition();
        RowDefinition bindable7 = new RowDefinition();
        RowDefinition bindable8 = new RowDefinition();
        ColumnDefinition bindable9 = new ColumnDefinition();
        TapGestureRecognizer bindable10 = new TapGestureRecognizer();
        StaticResourceExtension resourceExtension5 = new StaticResourceExtension();
        Label label2 = new Label();
        StaticResourceExtension resourceExtension6 = new StaticResourceExtension();
        Label label3 = new Label();
        BoxView bindable11 = new BoxView();
        StackLayout stackLayout2 = new StackLayout();
        ActivityIndicator activityIndicator1 = new ActivityIndicator();
        StackLayout stackLayout3 = new StackLayout();
        StackLayout bindable12 = new StackLayout();
        Frame frame2 = new Frame();
        StaticResourceExtension resourceExtension7 = new StaticResourceExtension();
        Label bindable13 = new Label();
        StaticResourceExtension resourceExtension8 = new StaticResourceExtension();
        TapGestureRecognizer bindable14 = new TapGestureRecognizer();
        Label bindable15 = new Label();
        StackLayout bindable16 = new StackLayout();
        StaticResourceExtension resourceExtension9 = new StaticResourceExtension();
        Label label4 = new Label();
        BoxView bindable17 = new BoxView();
        ActivityIndicator activityIndicator2 = new ActivityIndicator();
        StaticResourceExtension resourceExtension10 = new StaticResourceExtension();
        TapGestureRecognizer bindable18 = new TapGestureRecognizer();
        Label label5 = new Label();
        StaticResourceExtension resourceExtension11 = new StaticResourceExtension();
        Label bindable19 = new Label();
        StaticResourceExtension resourceExtension12 = new StaticResourceExtension();
        Label label6 = new Label();
        StackLayout bindable20 = new StackLayout();
        StaticResourceExtension resourceExtension13 = new StaticResourceExtension();
        Label bindable21 = new Label();
        StaticResourceExtension resourceExtension14 = new StaticResourceExtension();
        Label label7 = new Label();
        StackLayout bindable22 = new StackLayout();
        StackLayout stackLayout4 = new StackLayout();
        StaticResourceExtension resourceExtension15 = new StaticResourceExtension();
        Label bindable23 = new Label();
        StackLayout bindable24 = new StackLayout();
        StackLayout bindable25 = new StackLayout();
        Frame frame3 = new Frame();
        StaticResourceExtension resourceExtension16 = new StaticResourceExtension();
        Label bindable26 = new Label();
        StaticResourceExtension resourceExtension17 = new StaticResourceExtension();
        TapGestureRecognizer bindable27 = new TapGestureRecognizer();
        Label bindable28 = new Label();
        StackLayout bindable29 = new StackLayout();
        BoxView bindable30 = new BoxView();
        StackLayout bindable31 = new StackLayout();
        TapGestureRecognizer bindable32 = new TapGestureRecognizer();
        StaticResourceExtension resourceExtension18 = new StaticResourceExtension();
        Label label8 = new Label();
        CachedImage cachedImage = new CachedImage();
        StaticResourceExtension resourceExtension19 = new StaticResourceExtension();
        Label label9 = new Label();
        StackLayout bindable33 = new StackLayout();
        StackLayout stackLayout5 = new StackLayout();
        StackLayout bindable34 = new StackLayout();
        Frame frame4 = new Frame();
        StaticResourceExtension resourceExtension20 = new StaticResourceExtension();
        TapGestureRecognizer bindable35 = new TapGestureRecognizer();
        Label bindable36 = new Label();
        StaticResourceExtension resourceExtension21 = new StaticResourceExtension();
        TapGestureRecognizer bindable37 = new TapGestureRecognizer();
        Label label10 = new Label();
        StackLayout bindable38 = new StackLayout();
        StaticResourceExtension resourceExtension22 = new StaticResourceExtension();
        Label label11 = new Label();
        BoxView bindable39 = new BoxView();
        ActivityIndicator activityIndicator3 = new ActivityIndicator();
        StaticResourceExtension resourceExtension23 = new StaticResourceExtension();
        Label label12 = new Label();
        StaticResourceExtension resourceExtension24 = new StaticResourceExtension();
        Label label13 = new Label();
        StaticResourceExtension resourceExtension25 = new StaticResourceExtension();
        Label label14 = new Label();
        StackLayout bindable40 = new StackLayout();
        StaticResourceExtension resourceExtension26 = new StaticResourceExtension();
        Label label15 = new Label();
        StaticResourceExtension resourceExtension27 = new StaticResourceExtension();
        Label label16 = new Label();
        StackLayout bindable41 = new StackLayout();
        StackLayout bindable42 = new StackLayout();
        StaticResourceExtension resourceExtension28 = new StaticResourceExtension();
        Label label17 = new Label();
        StackLayout stackLayout6 = new StackLayout();
        StackLayout stackLayout7 = new StackLayout();
        StackLayout bindable43 = new StackLayout();
        StackLayout bindable44 = new StackLayout();
        Frame frame5 = new Frame();
        Grid grid = new Grid();
        StackLayout bindable45 = new StackLayout();
        ScrollView scrollView = new ScrollView();
        StaticResourceExtension resourceExtension29 = new StaticResourceExtension();
        Label label18 = new Label();
        StackLayout stackLayout8 = new StackLayout();
        StackLayout bindable46 = new StackLayout();
        WidgetHomePage bindable47 = this;
        NameScope nameScope = new NameScope();
        NameScope.SetNameScope((BindableObject) bindable47, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable46, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) stackLayout1, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("versionOutOfDate", (object) stackLayout1);
        if (stackLayout1.StyleId == null)
          stackLayout1.StyleId = "versionOutOfDate";
        NameScope.SetNameScope((BindableObject) bindable2, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable1, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) scrollView, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("scrollMain", (object) scrollView);
        if (scrollView.StyleId == null)
          scrollView.StyleId = "scrollMain";
        NameScope.SetNameScope((BindableObject) bindable45, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) frame1, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("frameServerDown", (object) frame1);
        if (frame1.StyleId == null)
          frame1.StyleId = "frameServerDown";
        NameScope.SetNameScope((BindableObject) bindable4, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) label1, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("lblServerDown", (object) label1);
        if (label1.StyleId == null)
          label1.StyleId = "lblServerDown";
        NameScope.SetNameScope((BindableObject) extendedLabel, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("lblRefresh", (object) extendedLabel);
        if (extendedLabel.StyleId == null)
          extendedLabel.StyleId = "lblRefresh";
        NameScope.SetNameScope((BindableObject) bindable3, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) grid, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("gridWidgets", (object) grid);
        if (grid.StyleId == null)
          grid.StyleId = "gridWidgets";
        NameScope.SetNameScope((BindableObject) bindable5, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable6, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable7, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable8, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable9, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) frame2, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("frmScheduleToday", (object) frame2);
        if (frame2.StyleId == null)
          frame2.StyleId = "frmScheduleToday";
        NameScope.SetNameScope((BindableObject) bindable10, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable12, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) stackLayout2, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("stackScheduleHeader", (object) stackLayout2);
        if (stackLayout2.StyleId == null)
          stackLayout2.StyleId = "stackScheduleHeader";
        NameScope.SetNameScope((BindableObject) label2, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("lblToday", (object) label2);
        if (label2.StyleId == null)
          label2.StyleId = "lblToday";
        NameScope.SetNameScope((BindableObject) label3, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("lblLastScheduleSync", (object) label3);
        if (label3.StyleId == null)
          label3.StyleId = "lblLastScheduleSync";
        NameScope.SetNameScope((BindableObject) bindable11, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) activityIndicator1, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("loadingTodayClass", (object) activityIndicator1);
        if (activityIndicator1.StyleId == null)
          activityIndicator1.StyleId = "loadingTodayClass";
        NameScope.SetNameScope((BindableObject) stackLayout3, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("stackTodaySchedule", (object) stackLayout3);
        if (stackLayout3.StyleId == null)
          stackLayout3.StyleId = "stackTodaySchedule";
        NameScope.SetNameScope((BindableObject) frame3, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("frmNextPayment", (object) frame3);
        if (frame3.StyleId == null)
          frame3.StyleId = "frmNextPayment";
        NameScope.SetNameScope((BindableObject) bindable25, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable24, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable16, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable13, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable15, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable14, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) label4, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("lblPaymentSync", (object) label4);
        if (label4.StyleId == null)
          label4.StyleId = "lblPaymentSync";
        NameScope.SetNameScope((BindableObject) bindable17, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) activityIndicator2, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("loadingPaymentSched", (object) activityIndicator2);
        if (activityIndicator2.StyleId == null)
          activityIndicator2.StyleId = "loadingPaymentSched";
        NameScope.SetNameScope((BindableObject) label5, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("lblPaymentRemarks", (object) label5);
        if (label5.StyleId == null)
          label5.StyleId = "lblPaymentRemarks";
        NameScope.SetNameScope((BindableObject) bindable18, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) stackLayout4, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("stackPaymentSchedule", (object) stackLayout4);
        if (stackLayout4.StyleId == null)
          stackLayout4.StyleId = "stackPaymentSchedule";
        NameScope.SetNameScope((BindableObject) bindable20, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable19, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) label6, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("lblNexyPaymentAmount", (object) label6);
        if (label6.StyleId == null)
          label6.StyleId = "lblNexyPaymentAmount";
        NameScope.SetNameScope((BindableObject) bindable22, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable21, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) label7, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("lblPaymentDue", (object) label7);
        if (label7.StyleId == null)
          label7.StyleId = "lblPaymentDue";
        NameScope.SetNameScope((BindableObject) bindable23, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) frame4, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("frmLatestNews", (object) frame4);
        if (frame4.StyleId == null)
          frame4.StyleId = "frmLatestNews";
        NameScope.SetNameScope((BindableObject) bindable34, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable31, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable29, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable26, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable28, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable27, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable30, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) stackLayout5, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("stackNews", (object) stackLayout5);
        if (stackLayout5.StyleId == null)
          stackLayout5.StyleId = "stackNews";
        NameScope.SetNameScope((BindableObject) bindable32, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) label8, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("lblNewsTitle", (object) label8);
        if (label8.StyleId == null)
          label8.StyleId = "lblNewsTitle";
        NameScope.SetNameScope((BindableObject) bindable33, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) cachedImage, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("imgNewsHeader", (object) cachedImage);
        if (cachedImage.StyleId == null)
          cachedImage.StyleId = "imgNewsHeader";
        NameScope.SetNameScope((BindableObject) label9, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("lblNewsContent", (object) label9);
        if (label9.StyleId == null)
          label9.StyleId = "lblNewsContent";
        NameScope.SetNameScope((BindableObject) frame5, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("frmLatestGrades", (object) frame5);
        if (frame5.StyleId == null)
          frame5.StyleId = "frmLatestGrades";
        NameScope.SetNameScope((BindableObject) bindable44, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable43, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable38, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable36, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable35, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) label10, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("lblViewAllGrades", (object) label10);
        if (label10.StyleId == null)
          label10.StyleId = "lblViewAllGrades";
        NameScope.SetNameScope((BindableObject) bindable37, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) label11, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("lblGradeAsOf", (object) label11);
        if (label11.StyleId == null)
          label11.StyleId = "lblGradeAsOf";
        NameScope.SetNameScope((BindableObject) bindable39, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) activityIndicator3, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("loadingGrade", (object) activityIndicator3);
        if (activityIndicator3.StyleId == null)
          activityIndicator3.StyleId = "loadingGrade";
        NameScope.SetNameScope((BindableObject) label12, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("lblGradeRemarks", (object) label12);
        if (label12.StyleId == null)
          label12.StyleId = "lblGradeRemarks";
        NameScope.SetNameScope((BindableObject) stackLayout7, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("stackLatestGrade", (object) stackLayout7);
        if (stackLayout7.StyleId == null)
          stackLayout7.StyleId = "stackLatestGrade";
        NameScope.SetNameScope((BindableObject) bindable42, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable40, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) label13, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("lblProfessor", (object) label13);
        if (label13.StyleId == null)
          label13.StyleId = "lblProfessor";
        NameScope.SetNameScope((BindableObject) label14, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("lblSubjectInfo", (object) label14);
        if (label14.StyleId == null)
          label14.StyleId = "lblSubjectInfo";
        NameScope.SetNameScope((BindableObject) bindable41, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) label15, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("lblGradePeriod", (object) label15);
        if (label15.StyleId == null)
          label15.StyleId = "lblGradePeriod";
        NameScope.SetNameScope((BindableObject) label16, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("lblLatestGrade", (object) label16);
        if (label16.StyleId == null)
          label16.StyleId = "lblLatestGrade";
        NameScope.SetNameScope((BindableObject) stackLayout6, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("stackGradesVisibility", (object) stackLayout6);
        if (stackLayout6.StyleId == null)
          stackLayout6.StyleId = "stackGradesVisibility";
        NameScope.SetNameScope((BindableObject) label17, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("lblMessage", (object) label17);
        if (label17.StyleId == null)
          label17.StyleId = "lblMessage";
        NameScope.SetNameScope((BindableObject) stackLayout8, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("stackStatus", (object) stackLayout8);
        if (stackLayout8.StyleId == null)
          stackLayout8.StyleId = "stackStatus";
        NameScope.SetNameScope((BindableObject) label18, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("lblStatus", (object) label18);
        if (label18.StyleId == null)
          label18.StyleId = "lblStatus";
        this.versionOutOfDate = stackLayout1;
        this.scrollMain = scrollView;
        this.frameServerDown = frame1;
        this.lblServerDown = label1;
        this.lblRefresh = extendedLabel;
        this.gridWidgets = grid;
        this.frmScheduleToday = frame2;
        this.stackScheduleHeader = stackLayout2;
        this.lblToday = label2;
        this.lblLastScheduleSync = label3;
        this.loadingTodayClass = activityIndicator1;
        this.stackTodaySchedule = stackLayout3;
        this.frmNextPayment = frame3;
        this.lblPaymentSync = label4;
        this.loadingPaymentSched = activityIndicator2;
        this.lblPaymentRemarks = label5;
        this.stackPaymentSchedule = stackLayout4;
        this.lblNexyPaymentAmount = label6;
        this.lblPaymentDue = label7;
        this.frmLatestNews = frame4;
        this.stackNews = stackLayout5;
        this.lblNewsTitle = label8;
        this.imgNewsHeader = cachedImage;
        this.lblNewsContent = label9;
        this.frmLatestGrades = frame5;
        this.lblViewAllGrades = label10;
        this.lblGradeAsOf = label11;
        this.loadingGrade = activityIndicator3;
        this.lblGradeRemarks = label12;
        this.stackLatestGrade = stackLayout7;
        this.lblProfessor = label13;
        this.lblSubjectInfo = label14;
        this.lblGradePeriod = label15;
        this.lblLatestGrade = label16;
        this.stackGradesVisibility = stackLayout6;
        this.lblMessage = label17;
        this.stackStatus = stackLayout8;
        this.lblStatus = label18;
        resourceExtension1.Key = "PageBackgroundColor";
        StaticResourceExtension resourceExtension30 = resourceExtension1;
        XamlServiceProvider xamlServiceProvider1 = new XamlServiceProvider();
        Type type1 = typeof (IProvideValueTarget);
        object[] objectAndParents1 = new object[0 + 1];
        objectAndParents1[0] = (object) bindable47;
        SimpleValueTargetProvider service1 = new SimpleValueTargetProvider(objectAndParents1, (object) VisualElement.BackgroundColorProperty);
        xamlServiceProvider1.Add(type1, (object) service1);
        xamlServiceProvider1.Add(typeof (INameScopeProvider), (object) new NameScopeProvider()
        {
          NameScope = (INameScope) nameScope
        });
        Type type2 = typeof (IXamlTypeResolver);
        XmlNamespaceResolver namespaceResolver1 = new XmlNamespaceResolver();
        namespaceResolver1.Add("", "http://xamarin.com/schemas/2014/forms");
        namespaceResolver1.Add("x", "http://schemas.microsoft.com/winfx/2009/xaml");
        namespaceResolver1.Add("forms", "clr-namespace:FFImageLoading.Forms;assembly=FFImageLoading.Forms");
        namespaceResolver1.Add("xlabs", "clr-namespace:XLabs.Forms.Controls;assembly=XLabs.Forms");
        XamlTypeResolver service2 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver1, typeof (WidgetHomePage).GetTypeInfo().Assembly);
        xamlServiceProvider1.Add(type2, (object) service2);
        xamlServiceProvider1.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(7, 14)));
        object obj1 = resourceExtension30.ProvideValue((IServiceProvider) xamlServiceProvider1);
        bindable47.BackgroundColor = (Color) obj1;
        bindable47.SetValue(Page.TitleProperty, (object) "Home");
        bindable47.SetValue(NavigationPage.HasNavigationBarProperty, (object) true);
        bindable46.SetValue(StackLayout.SpacingProperty, (object) 0.0);
        bindable46.SetValue(View.MarginProperty, (object) new Thickness(0.0));
        bindable46.SetValue(Layout.PaddingProperty, (object) new Thickness(0.0));
        stackLayout1.SetValue(VisualElement.BackgroundColorProperty, (object) new Color(0.921568632125854, 0.584313750267029, 0.196078434586525, 1.0));
        stackLayout1.SetValue(VisualElement.IsVisibleProperty, new VisualElement.VisibilityConverter().ConvertFromInvariantString("false"));
        stackLayout1.SetValue(Layout.PaddingProperty, (object) new Thickness(3.0));
        bindable2.SetValue(View.MarginProperty, (object) new Thickness(3.0));
        bindable2.SetValue(Label.TextProperty, (object) "Your app version is out of date. Check out the updated version here.");
        resourceExtension2.Key = "smallLabel";
        StaticResourceExtension resourceExtension31 = resourceExtension2;
        XamlServiceProvider xamlServiceProvider2 = new XamlServiceProvider();
        Type type3 = typeof (IProvideValueTarget);
        object[] objectAndParents2 = new object[0 + 4];
        objectAndParents2[0] = (object) bindable2;
        objectAndParents2[1] = (object) stackLayout1;
        objectAndParents2[2] = (object) bindable46;
        objectAndParents2[3] = (object) bindable47;
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
        namespaceResolver2.Add("forms", "clr-namespace:FFImageLoading.Forms;assembly=FFImageLoading.Forms");
        namespaceResolver2.Add("xlabs", "clr-namespace:XLabs.Forms.Controls;assembly=XLabs.Forms");
        XamlTypeResolver service4 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver2, typeof (WidgetHomePage).GetTypeInfo().Assembly);
        xamlServiceProvider2.Add(type4, (object) service4);
        xamlServiceProvider2.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(16, 111)));
        object obj2 = resourceExtension31.ProvideValue((IServiceProvider) xamlServiceProvider2);
        bindable2.Style = (Style) obj2;
        bindable2.SetValue(Label.HorizontalTextAlignmentProperty, new TextAlignmentConverter().ConvertFromInvariantString("Center"));
        Label label19 = bindable2;
        BindableProperty fontSizeProperty1 = Label.FontSizeProperty;
        FontSizeConverter fontSizeConverter1 = new FontSizeConverter();
        XamlServiceProvider xamlServiceProvider3 = new XamlServiceProvider();
        Type type5 = typeof (IProvideValueTarget);
        object[] objectAndParents3 = new object[0 + 4];
        objectAndParents3[0] = (object) bindable2;
        objectAndParents3[1] = (object) stackLayout1;
        objectAndParents3[2] = (object) bindable46;
        objectAndParents3[3] = (object) bindable47;
        SimpleValueTargetProvider service5 = new SimpleValueTargetProvider(objectAndParents3, (object) Label.FontSizeProperty);
        xamlServiceProvider3.Add(type5, (object) service5);
        xamlServiceProvider3.Add(typeof (INameScopeProvider), (object) new NameScopeProvider()
        {
          NameScope = (INameScope) nameScope
        });
        Type type6 = typeof (IXamlTypeResolver);
        XmlNamespaceResolver namespaceResolver3 = new XmlNamespaceResolver();
        namespaceResolver3.Add("", "http://xamarin.com/schemas/2014/forms");
        namespaceResolver3.Add("x", "http://schemas.microsoft.com/winfx/2009/xaml");
        namespaceResolver3.Add("forms", "clr-namespace:FFImageLoading.Forms;assembly=FFImageLoading.Forms");
        namespaceResolver3.Add("xlabs", "clr-namespace:XLabs.Forms.Controls;assembly=XLabs.Forms");
        XamlTypeResolver service6 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver3, typeof (WidgetHomePage).GetTypeInfo().Assembly);
        xamlServiceProvider3.Add(type6, (object) service6);
        xamlServiceProvider3.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(16, 180)));
        object obj3 = ((IExtendedTypeConverter) fontSizeConverter1).ConvertFromInvariantString("13", (IServiceProvider) xamlServiceProvider3);
        label19.SetValue(fontSizeProperty1, obj3);
        bindable2.SetValue(Label.TextColorProperty, (object) Color.White);
        bindable1.Tapped += new EventHandler(bindable47.DownloadUpdatedVersion);
        bindable2.GestureRecognizers.Add((IGestureRecognizer) bindable1);
        stackLayout1.Children.Add((View) bindable2);
        bindable46.Children.Add((View) stackLayout1);
        scrollView.SetValue(View.VerticalOptionsProperty, (object) LayoutOptions.FillAndExpand);
        scrollView.SetValue(View.MarginProperty, (object) new Thickness(0.0, 0.0, 0.0, 10.0));
        bindable45.SetValue(View.MarginProperty, (object) new Thickness(10.0));
        frame1.SetValue(View.MarginProperty, (object) new Thickness(0.0, 0.0, 0.0, 5.0));
        frame1.SetValue(Layout.PaddingProperty, (object) new Thickness(15.0));
        frame1.SetValue(Frame.CornerRadiusProperty, (object) 5f);
        frame1.SetValue(VisualElement.IsVisibleProperty, new VisualElement.VisibilityConverter().ConvertFromInvariantString("false"));
        label1.SetValue(Label.TextProperty, (object) "Apologies, the server is undergoing maintenance.");
        resourceExtension3.Key = "smallLabel";
        StaticResourceExtension resourceExtension32 = resourceExtension3;
        XamlServiceProvider xamlServiceProvider4 = new XamlServiceProvider();
        Type type7 = typeof (IProvideValueTarget);
        object[] objectAndParents4 = new object[0 + 7];
        objectAndParents4[0] = (object) label1;
        objectAndParents4[1] = (object) bindable4;
        objectAndParents4[2] = (object) frame1;
        objectAndParents4[3] = (object) bindable45;
        objectAndParents4[4] = (object) scrollView;
        objectAndParents4[5] = (object) bindable46;
        objectAndParents4[6] = (object) bindable47;
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
        namespaceResolver4.Add("forms", "clr-namespace:FFImageLoading.Forms;assembly=FFImageLoading.Forms");
        namespaceResolver4.Add("xlabs", "clr-namespace:XLabs.Forms.Controls;assembly=XLabs.Forms");
        XamlTypeResolver service8 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver4, typeof (WidgetHomePage).GetTypeInfo().Assembly);
        xamlServiceProvider4.Add(type8, (object) service8);
        xamlServiceProvider4.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(30, 116)));
        object obj4 = resourceExtension32.ProvideValue((IServiceProvider) xamlServiceProvider4);
        label1.Style = (Style) obj4;
        label1.SetValue(Label.TextColorProperty, (object) new Color(0.250980406999588, 0.250980406999588, 0.250980406999588, 1.0));
        label1.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.FillAndExpand);
        bindable4.Children.Add((View) label1);
        extendedLabel.SetValue(VisualElement.IsVisibleProperty, new VisualElement.VisibilityConverter().ConvertFromInvariantString("True"));
        extendedLabel.SetValue(Label.TextProperty, (object) "Refresh");
        extendedLabel.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.Center);
        resourceExtension4.Key = "smallLabel";
        StaticResourceExtension resourceExtension33 = resourceExtension4;
        XamlServiceProvider xamlServiceProvider5 = new XamlServiceProvider();
        Type type9 = typeof (IProvideValueTarget);
        object[] objectAndParents5 = new object[0 + 7];
        objectAndParents5[0] = (object) extendedLabel;
        objectAndParents5[1] = (object) bindable4;
        objectAndParents5[2] = (object) frame1;
        objectAndParents5[3] = (object) bindable45;
        objectAndParents5[4] = (object) scrollView;
        objectAndParents5[5] = (object) bindable46;
        objectAndParents5[6] = (object) bindable47;
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
        namespaceResolver5.Add("forms", "clr-namespace:FFImageLoading.Forms;assembly=FFImageLoading.Forms");
        namespaceResolver5.Add("xlabs", "clr-namespace:XLabs.Forms.Controls;assembly=XLabs.Forms");
        XamlTypeResolver service10 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver5, typeof (WidgetHomePage).GetTypeInfo().Assembly);
        xamlServiceProvider5.Add(type10, (object) service10);
        xamlServiceProvider5.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(31, 129)));
        object obj5 = resourceExtension33.ProvideValue((IServiceProvider) xamlServiceProvider5);
        extendedLabel.Style = (Style) obj5;
        extendedLabel.SetValue(Label.TextColorProperty, (object) new Color(0.20392157137394, 0.227450981736183, 0.250980406999588, 1.0));
        extendedLabel.SetValue(ExtendedLabel.IsUnderlineProperty, (object) true);
        bindable3.Tapped += new EventHandler(bindable47.lblRefresh_Tapped);
        extendedLabel.GestureRecognizers.Add((IGestureRecognizer) bindable3);
        bindable4.Children.Add((View) extendedLabel);
        frame1.SetValue(ContentView.ContentProperty, (object) bindable4);
        bindable45.Children.Add((View) frame1);
        grid.SetValue(View.MarginProperty, (object) new Thickness(0.0));
        grid.SetValue(Layout.PaddingProperty, (object) new Thickness(0.0));
        bindable5.SetValue(RowDefinition.HeightProperty, new GridLengthTypeConverter().ConvertFromInvariantString("Auto"));
        ((DefinitionCollection<RowDefinition>) grid.GetValue(Grid.RowDefinitionsProperty)).Add(bindable5);
        bindable6.SetValue(RowDefinition.HeightProperty, new GridLengthTypeConverter().ConvertFromInvariantString("Auto"));
        ((DefinitionCollection<RowDefinition>) grid.GetValue(Grid.RowDefinitionsProperty)).Add(bindable6);
        bindable7.SetValue(RowDefinition.HeightProperty, new GridLengthTypeConverter().ConvertFromInvariantString("Auto"));
        ((DefinitionCollection<RowDefinition>) grid.GetValue(Grid.RowDefinitionsProperty)).Add(bindable7);
        bindable8.SetValue(RowDefinition.HeightProperty, new GridLengthTypeConverter().ConvertFromInvariantString("Auto"));
        ((DefinitionCollection<RowDefinition>) grid.GetValue(Grid.RowDefinitionsProperty)).Add(bindable8);
        bindable9.SetValue(ColumnDefinition.WidthProperty, new GridLengthTypeConverter().ConvertFromInvariantString("*"));
        ((DefinitionCollection<ColumnDefinition>) grid.GetValue(Grid.ColumnDefinitionsProperty)).Add(bindable9);
        frame2.SetValue(Grid.ColumnProperty, (object) 0);
        frame2.SetValue(Grid.RowProperty, (object) 0);
        frame2.SetValue(VisualElement.OpacityProperty, (object) 0.0);
        frame2.SetValue(Frame.CornerRadiusProperty, (object) 5f);
        frame2.SetValue(Frame.HasShadowProperty, (object) true);
        frame2.SetValue(View.MarginProperty, (object) new Thickness(0.0, 0.0, 0.0, 5.0));
        frame2.SetValue(Layout.PaddingProperty, (object) new Thickness(0.0, 0.0, 0.0, 15.0));
        bindable10.Tapped += new EventHandler(bindable47.Schedule_Tapped);
        frame2.GestureRecognizers.Add((IGestureRecognizer) bindable10);
        bindable12.SetValue(StackLayout.SpacingProperty, (object) 0.0);
        stackLayout2.SetValue(StackLayout.SpacingProperty, (object) 1.0);
        stackLayout2.SetValue(View.MarginProperty, (object) new Thickness(0.0, 0.0, 0.0, 5.0));
        stackLayout2.SetValue(Layout.PaddingProperty, (object) new Thickness(15.0, 10.0, 15.0, 10.0));
        resourceExtension5.Key = "normalHeader";
        StaticResourceExtension resourceExtension34 = resourceExtension5;
        XamlServiceProvider xamlServiceProvider6 = new XamlServiceProvider();
        Type type11 = typeof (IProvideValueTarget);
        object[] objectAndParents6 = new object[0 + 9];
        objectAndParents6[0] = (object) label2;
        objectAndParents6[1] = (object) stackLayout2;
        objectAndParents6[2] = (object) bindable12;
        objectAndParents6[3] = (object) frame2;
        objectAndParents6[4] = (object) grid;
        objectAndParents6[5] = (object) bindable45;
        objectAndParents6[6] = (object) scrollView;
        objectAndParents6[7] = (object) bindable46;
        objectAndParents6[8] = (object) bindable47;
        SimpleValueTargetProvider service11 = new SimpleValueTargetProvider(objectAndParents6, (object) VisualElement.StyleProperty);
        xamlServiceProvider6.Add(type11, (object) service11);
        xamlServiceProvider6.Add(typeof (INameScopeProvider), (object) new NameScopeProvider()
        {
          NameScope = (INameScope) nameScope
        });
        Type type12 = typeof (IXamlTypeResolver);
        XmlNamespaceResolver namespaceResolver6 = new XmlNamespaceResolver();
        namespaceResolver6.Add("", "http://xamarin.com/schemas/2014/forms");
        namespaceResolver6.Add("x", "http://schemas.microsoft.com/winfx/2009/xaml");
        namespaceResolver6.Add("forms", "clr-namespace:FFImageLoading.Forms;assembly=FFImageLoading.Forms");
        namespaceResolver6.Add("xlabs", "clr-namespace:XLabs.Forms.Controls;assembly=XLabs.Forms");
        XamlTypeResolver service12 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver6, typeof (WidgetHomePage).GetTypeInfo().Assembly);
        xamlServiceProvider6.Add(type12, (object) service12);
        xamlServiceProvider6.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(61, 62)));
        object obj6 = resourceExtension34.ProvideValue((IServiceProvider) xamlServiceProvider6);
        label2.Style = (Style) obj6;
        label2.SetValue(Label.TextProperty, (object) "Classes for Today");
        label2.SetValue(Label.TextColorProperty, (object) new Color(0.250980406999588, 0.250980406999588, 0.250980406999588, 1.0));
        stackLayout2.Children.Add((View) label2);
        label3.SetValue(View.MarginProperty, (object) new Thickness(0.0, 2.0, 0.0, 0.0));
        resourceExtension6.Key = "microHeader";
        StaticResourceExtension resourceExtension35 = resourceExtension6;
        XamlServiceProvider xamlServiceProvider7 = new XamlServiceProvider();
        Type type13 = typeof (IProvideValueTarget);
        object[] objectAndParents7 = new object[0 + 9];
        objectAndParents7[0] = (object) label3;
        objectAndParents7[1] = (object) stackLayout2;
        objectAndParents7[2] = (object) bindable12;
        objectAndParents7[3] = (object) frame2;
        objectAndParents7[4] = (object) grid;
        objectAndParents7[5] = (object) bindable45;
        objectAndParents7[6] = (object) scrollView;
        objectAndParents7[7] = (object) bindable46;
        objectAndParents7[8] = (object) bindable47;
        SimpleValueTargetProvider service13 = new SimpleValueTargetProvider(objectAndParents7, (object) VisualElement.StyleProperty);
        xamlServiceProvider7.Add(type13, (object) service13);
        xamlServiceProvider7.Add(typeof (INameScopeProvider), (object) new NameScopeProvider()
        {
          NameScope = (INameScope) nameScope
        });
        Type type14 = typeof (IXamlTypeResolver);
        XmlNamespaceResolver namespaceResolver7 = new XmlNamespaceResolver();
        namespaceResolver7.Add("", "http://xamarin.com/schemas/2014/forms");
        namespaceResolver7.Add("x", "http://schemas.microsoft.com/winfx/2009/xaml");
        namespaceResolver7.Add("forms", "clr-namespace:FFImageLoading.Forms;assembly=FFImageLoading.Forms");
        namespaceResolver7.Add("xlabs", "clr-namespace:XLabs.Forms.Controls;assembly=XLabs.Forms");
        XamlTypeResolver service14 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver7, typeof (WidgetHomePage).GetTypeInfo().Assembly);
        xamlServiceProvider7.Add(type14, (object) service14);
        xamlServiceProvider7.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(62, 90)));
        object obj7 = resourceExtension35.ProvideValue((IServiceProvider) xamlServiceProvider7);
        label3.Style = (Style) obj7;
        label3.SetValue(Label.TextColorProperty, (object) new Color(0.400000005960464, 0.400000005960464, 0.400000005960464, 1.0));
        stackLayout2.Children.Add((View) label3);
        bindable11.SetValue(BoxView.ColorProperty, (object) new Color(0.905882358551025, 0.752941191196442, 0.113725490868092, 1.0));
        bindable11.SetValue(VisualElement.HeightRequestProperty, (object) 1.5);
        bindable11.SetValue(View.MarginProperty, (object) new Thickness(0.0, 5.0, 0.0, 0.0));
        bindable11.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.FillAndExpand);
        stackLayout2.Children.Add((View) bindable11);
        bindable12.Children.Add((View) stackLayout2);
        activityIndicator1.SetValue(View.MarginProperty, (object) new Thickness(0.0, 0.0, 0.0, 5.0));
        activityIndicator1.SetValue(VisualElement.IsVisibleProperty, new VisualElement.VisibilityConverter().ConvertFromInvariantString("False"));
        activityIndicator1.SetValue(ActivityIndicator.ColorProperty, (object) Color.LightGray);
        activityIndicator1.SetValue(ActivityIndicator.IsRunningProperty, (object) true);
        activityIndicator1.SetValue(VisualElement.HeightRequestProperty, (object) 25.0);
        activityIndicator1.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.Center);
        activityIndicator1.SetValue(View.VerticalOptionsProperty, (object) LayoutOptions.Center);
        bindable12.Children.Add((View) activityIndicator1);
        stackLayout3.SetValue(Layout.PaddingProperty, (object) new Thickness(15.0, 0.0, 15.0, 0.0));
        bindable12.Children.Add((View) stackLayout3);
        frame2.SetValue(ContentView.ContentProperty, (object) bindable12);
        grid.Children.Add((View) frame2);
        frame3.SetValue(Grid.ColumnProperty, (object) 0);
        frame3.SetValue(Grid.RowProperty, (object) 1);
        frame3.SetValue(VisualElement.OpacityProperty, (object) 0.0);
        frame3.SetValue(Frame.CornerRadiusProperty, (object) 5f);
        frame3.SetValue(Frame.HasShadowProperty, (object) true);
        frame3.SetValue(View.MarginProperty, (object) new Thickness(0.0, 0.0, 0.0, 5.0));
        frame3.SetValue(Layout.PaddingProperty, (object) new Thickness(0.0));
        bindable25.SetValue(StackLayout.SpacingProperty, (object) 0.0);
        bindable24.SetValue(StackLayout.SpacingProperty, (object) 1.0);
        bindable24.SetValue(View.MarginProperty, (object) new Thickness(0.0, 0.0, 0.0, 5.0));
        bindable24.SetValue(Layout.PaddingProperty, (object) new Thickness(15.0, 10.0, 15.0, 10.0));
        bindable16.SetValue(StackLayout.OrientationProperty, (object) StackOrientation.Horizontal);
        bindable13.SetValue(Label.TextProperty, (object) "Payment Schedule");
        resourceExtension7.Key = "normalHeader";
        StaticResourceExtension resourceExtension36 = resourceExtension7;
        XamlServiceProvider xamlServiceProvider8 = new XamlServiceProvider();
        Type type15 = typeof (IProvideValueTarget);
        object[] objectAndParents8 = new object[0 + 10];
        objectAndParents8[0] = (object) bindable13;
        objectAndParents8[1] = (object) bindable16;
        objectAndParents8[2] = (object) bindable24;
        objectAndParents8[3] = (object) bindable25;
        objectAndParents8[4] = (object) frame3;
        objectAndParents8[5] = (object) grid;
        objectAndParents8[6] = (object) bindable45;
        objectAndParents8[7] = (object) scrollView;
        objectAndParents8[8] = (object) bindable46;
        objectAndParents8[9] = (object) bindable47;
        SimpleValueTargetProvider service15 = new SimpleValueTargetProvider(objectAndParents8, (object) VisualElement.StyleProperty);
        xamlServiceProvider8.Add(type15, (object) service15);
        xamlServiceProvider8.Add(typeof (INameScopeProvider), (object) new NameScopeProvider()
        {
          NameScope = (INameScope) nameScope
        });
        Type type16 = typeof (IXamlTypeResolver);
        XmlNamespaceResolver namespaceResolver8 = new XmlNamespaceResolver();
        namespaceResolver8.Add("", "http://xamarin.com/schemas/2014/forms");
        namespaceResolver8.Add("x", "http://schemas.microsoft.com/winfx/2009/xaml");
        namespaceResolver8.Add("forms", "clr-namespace:FFImageLoading.Forms;assembly=FFImageLoading.Forms");
        namespaceResolver8.Add("xlabs", "clr-namespace:XLabs.Forms.Controls;assembly=XLabs.Forms");
        XamlTypeResolver service16 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver8, typeof (WidgetHomePage).GetTypeInfo().Assembly);
        xamlServiceProvider8.Add(type16, (object) service16);
        xamlServiceProvider8.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(83, 72)));
        object obj8 = resourceExtension36.ProvideValue((IServiceProvider) xamlServiceProvider8);
        bindable13.Style = (Style) obj8;
        bindable13.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.FillAndExpand);
        bindable13.SetValue(Label.TextColorProperty, (object) new Color(0.250980406999588, 0.250980406999588, 0.250980406999588, 1.0));
        bindable16.Children.Add((View) bindable13);
        bindable15.SetValue(Label.TextProperty, (object) "VIEW ALL");
        resourceExtension8.Key = "microHeader";
        StaticResourceExtension resourceExtension37 = resourceExtension8;
        XamlServiceProvider xamlServiceProvider9 = new XamlServiceProvider();
        Type type17 = typeof (IProvideValueTarget);
        object[] objectAndParents9 = new object[0 + 10];
        objectAndParents9[0] = (object) bindable15;
        objectAndParents9[1] = (object) bindable16;
        objectAndParents9[2] = (object) bindable24;
        objectAndParents9[3] = (object) bindable25;
        objectAndParents9[4] = (object) frame3;
        objectAndParents9[5] = (object) grid;
        objectAndParents9[6] = (object) bindable45;
        objectAndParents9[7] = (object) scrollView;
        objectAndParents9[8] = (object) bindable46;
        objectAndParents9[9] = (object) bindable47;
        SimpleValueTargetProvider service17 = new SimpleValueTargetProvider(objectAndParents9, (object) VisualElement.StyleProperty);
        xamlServiceProvider9.Add(type17, (object) service17);
        xamlServiceProvider9.Add(typeof (INameScopeProvider), (object) new NameScopeProvider()
        {
          NameScope = (INameScope) nameScope
        });
        Type type18 = typeof (IXamlTypeResolver);
        XmlNamespaceResolver namespaceResolver9 = new XmlNamespaceResolver();
        namespaceResolver9.Add("", "http://xamarin.com/schemas/2014/forms");
        namespaceResolver9.Add("x", "http://schemas.microsoft.com/winfx/2009/xaml");
        namespaceResolver9.Add("forms", "clr-namespace:FFImageLoading.Forms;assembly=FFImageLoading.Forms");
        namespaceResolver9.Add("xlabs", "clr-namespace:XLabs.Forms.Controls;assembly=XLabs.Forms");
        XamlTypeResolver service18 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver9, typeof (WidgetHomePage).GetTypeInfo().Assembly);
        xamlServiceProvider9.Add(type18, (object) service18);
        xamlServiceProvider9.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(85, 64)));
        object obj9 = resourceExtension37.ProvideValue((IServiceProvider) xamlServiceProvider9);
        bindable15.Style = (Style) obj9;
        bindable15.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.End);
        bindable15.SetValue(View.VerticalOptionsProperty, (object) LayoutOptions.Center);
        bindable14.Tapped += new EventHandler(bindable47.ViewAllPayment_Tapped);
        bindable15.GestureRecognizers.Add((IGestureRecognizer) bindable14);
        bindable16.Children.Add((View) bindable15);
        bindable24.Children.Add((View) bindable16);
        label4.SetValue(View.MarginProperty, (object) new Thickness(0.0, 2.0, 0.0, 0.0));
        resourceExtension9.Key = "microHeader";
        StaticResourceExtension resourceExtension38 = resourceExtension9;
        XamlServiceProvider xamlServiceProvider10 = new XamlServiceProvider();
        Type type19 = typeof (IProvideValueTarget);
        object[] objectAndParents10 = new object[0 + 9];
        objectAndParents10[0] = (object) label4;
        objectAndParents10[1] = (object) bindable24;
        objectAndParents10[2] = (object) bindable25;
        objectAndParents10[3] = (object) frame3;
        objectAndParents10[4] = (object) grid;
        objectAndParents10[5] = (object) bindable45;
        objectAndParents10[6] = (object) scrollView;
        objectAndParents10[7] = (object) bindable46;
        objectAndParents10[8] = (object) bindable47;
        SimpleValueTargetProvider service19 = new SimpleValueTargetProvider(objectAndParents10, (object) VisualElement.StyleProperty);
        xamlServiceProvider10.Add(type19, (object) service19);
        xamlServiceProvider10.Add(typeof (INameScopeProvider), (object) new NameScopeProvider()
        {
          NameScope = (INameScope) nameScope
        });
        Type type20 = typeof (IXamlTypeResolver);
        XmlNamespaceResolver namespaceResolver10 = new XmlNamespaceResolver();
        namespaceResolver10.Add("", "http://xamarin.com/schemas/2014/forms");
        namespaceResolver10.Add("x", "http://schemas.microsoft.com/winfx/2009/xaml");
        namespaceResolver10.Add("forms", "clr-namespace:FFImageLoading.Forms;assembly=FFImageLoading.Forms");
        namespaceResolver10.Add("xlabs", "clr-namespace:XLabs.Forms.Controls;assembly=XLabs.Forms");
        XamlTypeResolver service20 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver10, typeof (WidgetHomePage).GetTypeInfo().Assembly);
        xamlServiceProvider10.Add(type20, (object) service20);
        xamlServiceProvider10.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(95, 85)));
        object obj10 = resourceExtension38.ProvideValue((IServiceProvider) xamlServiceProvider10);
        label4.Style = (Style) obj10;
        label4.SetValue(Label.TextColorProperty, (object) new Color(0.400000005960464, 0.400000005960464, 0.400000005960464, 1.0));
        bindable24.Children.Add((View) label4);
        bindable17.SetValue(BoxView.ColorProperty, (object) new Color(0.905882358551025, 0.752941191196442, 0.113725490868092, 1.0));
        bindable17.SetValue(VisualElement.HeightRequestProperty, (object) 1.5);
        bindable17.SetValue(View.MarginProperty, (object) new Thickness(0.0, 5.0, 0.0, 0.0));
        bindable17.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.FillAndExpand);
        bindable24.Children.Add((View) bindable17);
        activityIndicator2.SetValue(View.MarginProperty, (object) new Thickness(0.0, 5.0, 0.0, 5.0));
        activityIndicator2.SetValue(VisualElement.IsVisibleProperty, new VisualElement.VisibilityConverter().ConvertFromInvariantString("False"));
        activityIndicator2.SetValue(ActivityIndicator.ColorProperty, (object) Color.LightGray);
        activityIndicator2.SetValue(ActivityIndicator.IsRunningProperty, (object) true);
        activityIndicator2.SetValue(VisualElement.HeightRequestProperty, (object) 25.0);
        activityIndicator2.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.Center);
        activityIndicator2.SetValue(View.VerticalOptionsProperty, (object) LayoutOptions.Center);
        bindable24.Children.Add((View) activityIndicator2);
        label5.SetValue(VisualElement.IsVisibleProperty, new VisualElement.VisibilityConverter().ConvertFromInvariantString("False"));
        label5.SetValue(View.MarginProperty, (object) new Thickness(0.0, 5.0, 0.0, 0.0));
        resourceExtension10.Key = "smallLabel";
        StaticResourceExtension resourceExtension39 = resourceExtension10;
        XamlServiceProvider xamlServiceProvider11 = new XamlServiceProvider();
        Type type21 = typeof (IProvideValueTarget);
        object[] objectAndParents11 = new object[0 + 9];
        objectAndParents11[0] = (object) label5;
        objectAndParents11[1] = (object) bindable24;
        objectAndParents11[2] = (object) bindable25;
        objectAndParents11[3] = (object) frame3;
        objectAndParents11[4] = (object) grid;
        objectAndParents11[5] = (object) bindable45;
        objectAndParents11[6] = (object) scrollView;
        objectAndParents11[7] = (object) bindable46;
        objectAndParents11[8] = (object) bindable47;
        SimpleValueTargetProvider service21 = new SimpleValueTargetProvider(objectAndParents11, (object) VisualElement.StyleProperty);
        xamlServiceProvider11.Add(type21, (object) service21);
        xamlServiceProvider11.Add(typeof (INameScopeProvider), (object) new NameScopeProvider()
        {
          NameScope = (INameScope) nameScope
        });
        Type type22 = typeof (IXamlTypeResolver);
        XmlNamespaceResolver namespaceResolver11 = new XmlNamespaceResolver();
        namespaceResolver11.Add("", "http://xamarin.com/schemas/2014/forms");
        namespaceResolver11.Add("x", "http://schemas.microsoft.com/winfx/2009/xaml");
        namespaceResolver11.Add("forms", "clr-namespace:FFImageLoading.Forms;assembly=FFImageLoading.Forms");
        namespaceResolver11.Add("xlabs", "clr-namespace:XLabs.Forms.Controls;assembly=XLabs.Forms");
        XamlTypeResolver service22 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver11, typeof (WidgetHomePage).GetTypeInfo().Assembly);
        xamlServiceProvider11.Add(type22, (object) service22);
        xamlServiceProvider11.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(103, 106)));
        object obj11 = resourceExtension39.ProvideValue((IServiceProvider) xamlServiceProvider11);
        label5.Style = (Style) obj11;
        label5.SetValue(Label.TextColorProperty, (object) new Color(0.400000005960464, 0.400000005960464, 0.400000005960464, 1.0));
        label5.SetValue(Label.TextProperty, (object) "No payment schedule available. Tap to refresh.");
        label5.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.FillAndExpand);
        bindable18.Tapped += new EventHandler(bindable47.RefreshPayment_Tapped);
        label5.GestureRecognizers.Add((IGestureRecognizer) bindable18);
        bindable24.Children.Add((View) label5);
        stackLayout4.SetValue(StackLayout.OrientationProperty, (object) StackOrientation.Horizontal);
        stackLayout4.SetValue(Layout.PaddingProperty, (object) new Thickness(0.0, 10.0, 0.0, 0.0));
        bindable20.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.FillAndExpand);
        bindable20.SetValue(StackLayout.SpacingProperty, (object) 0.0);
        resourceExtension11.Key = "smallLabel";
        StaticResourceExtension resourceExtension40 = resourceExtension11;
        XamlServiceProvider xamlServiceProvider12 = new XamlServiceProvider();
        Type type23 = typeof (IProvideValueTarget);
        object[] objectAndParents12 = new object[0 + 11];
        objectAndParents12[0] = (object) bindable19;
        objectAndParents12[1] = (object) bindable20;
        objectAndParents12[2] = (object) stackLayout4;
        objectAndParents12[3] = (object) bindable24;
        objectAndParents12[4] = (object) bindable25;
        objectAndParents12[5] = (object) frame3;
        objectAndParents12[6] = (object) grid;
        objectAndParents12[7] = (object) bindable45;
        objectAndParents12[8] = (object) scrollView;
        objectAndParents12[9] = (object) bindable46;
        objectAndParents12[10] = (object) bindable47;
        SimpleValueTargetProvider service23 = new SimpleValueTargetProvider(objectAndParents12, (object) VisualElement.StyleProperty);
        xamlServiceProvider12.Add(type23, (object) service23);
        xamlServiceProvider12.Add(typeof (INameScopeProvider), (object) new NameScopeProvider()
        {
          NameScope = (INameScope) nameScope
        });
        Type type24 = typeof (IXamlTypeResolver);
        XmlNamespaceResolver namespaceResolver12 = new XmlNamespaceResolver();
        namespaceResolver12.Add("", "http://xamarin.com/schemas/2014/forms");
        namespaceResolver12.Add("x", "http://schemas.microsoft.com/winfx/2009/xaml");
        namespaceResolver12.Add("forms", "clr-namespace:FFImageLoading.Forms;assembly=FFImageLoading.Forms");
        namespaceResolver12.Add("xlabs", "clr-namespace:XLabs.Forms.Controls;assembly=XLabs.Forms");
        XamlTypeResolver service24 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver12, typeof (WidgetHomePage).GetTypeInfo().Assembly);
        xamlServiceProvider12.Add(type24, (object) service24);
        xamlServiceProvider12.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(112, 53)));
        object obj12 = resourceExtension40.ProvideValue((IServiceProvider) xamlServiceProvider12);
        bindable19.Style = (Style) obj12;
        bindable19.SetValue(Label.TextColorProperty, (object) new Color(0.250980406999588, 0.250980406999588, 0.250980406999588, 1.0));
        bindable19.SetValue(Label.TextProperty, (object) "Next Payment Amount");
        bindable20.Children.Add((View) bindable19);
        resourceExtension12.Key = "normalHeader";
        StaticResourceExtension resourceExtension41 = resourceExtension12;
        XamlServiceProvider xamlServiceProvider13 = new XamlServiceProvider();
        Type type25 = typeof (IProvideValueTarget);
        object[] objectAndParents13 = new object[0 + 11];
        objectAndParents13[0] = (object) label6;
        objectAndParents13[1] = (object) bindable20;
        objectAndParents13[2] = (object) stackLayout4;
        objectAndParents13[3] = (object) bindable24;
        objectAndParents13[4] = (object) bindable25;
        objectAndParents13[5] = (object) frame3;
        objectAndParents13[6] = (object) grid;
        objectAndParents13[7] = (object) bindable45;
        objectAndParents13[8] = (object) scrollView;
        objectAndParents13[9] = (object) bindable46;
        objectAndParents13[10] = (object) bindable47;
        SimpleValueTargetProvider service25 = new SimpleValueTargetProvider(objectAndParents13, (object) VisualElement.StyleProperty);
        xamlServiceProvider13.Add(type25, (object) service25);
        xamlServiceProvider13.Add(typeof (INameScopeProvider), (object) new NameScopeProvider()
        {
          NameScope = (INameScope) nameScope
        });
        Type type26 = typeof (IXamlTypeResolver);
        XmlNamespaceResolver namespaceResolver13 = new XmlNamespaceResolver();
        namespaceResolver13.Add("", "http://xamarin.com/schemas/2014/forms");
        namespaceResolver13.Add("x", "http://schemas.microsoft.com/winfx/2009/xaml");
        namespaceResolver13.Add("forms", "clr-namespace:FFImageLoading.Forms;assembly=FFImageLoading.Forms");
        namespaceResolver13.Add("xlabs", "clr-namespace:XLabs.Forms.Controls;assembly=XLabs.Forms");
        XamlTypeResolver service26 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver13, typeof (WidgetHomePage).GetTypeInfo().Assembly);
        xamlServiceProvider13.Add(type26, (object) service26);
        xamlServiceProvider13.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(113, 83)));
        object obj13 = resourceExtension41.ProvideValue((IServiceProvider) xamlServiceProvider13);
        label6.Style = (Style) obj13;
        label6.SetValue(Label.TextColorProperty, (object) new Color(0.250980406999588, 0.250980406999588, 0.250980406999588, 1.0));
        bindable20.Children.Add((View) label6);
        stackLayout4.Children.Add((View) bindable20);
        bindable22.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.FillAndExpand);
        bindable22.SetValue(StackLayout.SpacingProperty, (object) 0.0);
        resourceExtension13.Key = "smallLabel";
        StaticResourceExtension resourceExtension42 = resourceExtension13;
        XamlServiceProvider xamlServiceProvider14 = new XamlServiceProvider();
        Type type27 = typeof (IProvideValueTarget);
        object[] objectAndParents14 = new object[0 + 11];
        objectAndParents14[0] = (object) bindable21;
        objectAndParents14[1] = (object) bindable22;
        objectAndParents14[2] = (object) stackLayout4;
        objectAndParents14[3] = (object) bindable24;
        objectAndParents14[4] = (object) bindable25;
        objectAndParents14[5] = (object) frame3;
        objectAndParents14[6] = (object) grid;
        objectAndParents14[7] = (object) bindable45;
        objectAndParents14[8] = (object) scrollView;
        objectAndParents14[9] = (object) bindable46;
        objectAndParents14[10] = (object) bindable47;
        SimpleValueTargetProvider service27 = new SimpleValueTargetProvider(objectAndParents14, (object) VisualElement.StyleProperty);
        xamlServiceProvider14.Add(type27, (object) service27);
        xamlServiceProvider14.Add(typeof (INameScopeProvider), (object) new NameScopeProvider()
        {
          NameScope = (INameScope) nameScope
        });
        Type type28 = typeof (IXamlTypeResolver);
        XmlNamespaceResolver namespaceResolver14 = new XmlNamespaceResolver();
        namespaceResolver14.Add("", "http://xamarin.com/schemas/2014/forms");
        namespaceResolver14.Add("x", "http://schemas.microsoft.com/winfx/2009/xaml");
        namespaceResolver14.Add("forms", "clr-namespace:FFImageLoading.Forms;assembly=FFImageLoading.Forms");
        namespaceResolver14.Add("xlabs", "clr-namespace:XLabs.Forms.Controls;assembly=XLabs.Forms");
        XamlTypeResolver service28 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver14, typeof (WidgetHomePage).GetTypeInfo().Assembly);
        xamlServiceProvider14.Add(type28, (object) service28);
        xamlServiceProvider14.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(117, 53)));
        object obj14 = resourceExtension42.ProvideValue((IServiceProvider) xamlServiceProvider14);
        bindable21.Style = (Style) obj14;
        bindable21.SetValue(Label.TextColorProperty, (object) new Color(0.250980406999588, 0.250980406999588, 0.250980406999588, 1.0));
        bindable21.SetValue(Label.TextProperty, (object) "Due Date");
        bindable22.Children.Add((View) bindable21);
        resourceExtension14.Key = "normalHeader";
        StaticResourceExtension resourceExtension43 = resourceExtension14;
        XamlServiceProvider xamlServiceProvider15 = new XamlServiceProvider();
        Type type29 = typeof (IProvideValueTarget);
        object[] objectAndParents15 = new object[0 + 11];
        objectAndParents15[0] = (object) label7;
        objectAndParents15[1] = (object) bindable22;
        objectAndParents15[2] = (object) stackLayout4;
        objectAndParents15[3] = (object) bindable24;
        objectAndParents15[4] = (object) bindable25;
        objectAndParents15[5] = (object) frame3;
        objectAndParents15[6] = (object) grid;
        objectAndParents15[7] = (object) bindable45;
        objectAndParents15[8] = (object) scrollView;
        objectAndParents15[9] = (object) bindable46;
        objectAndParents15[10] = (object) bindable47;
        SimpleValueTargetProvider service29 = new SimpleValueTargetProvider(objectAndParents15, (object) VisualElement.StyleProperty);
        xamlServiceProvider15.Add(type29, (object) service29);
        xamlServiceProvider15.Add(typeof (INameScopeProvider), (object) new NameScopeProvider()
        {
          NameScope = (INameScope) nameScope
        });
        Type type30 = typeof (IXamlTypeResolver);
        XmlNamespaceResolver namespaceResolver15 = new XmlNamespaceResolver();
        namespaceResolver15.Add("", "http://xamarin.com/schemas/2014/forms");
        namespaceResolver15.Add("x", "http://schemas.microsoft.com/winfx/2009/xaml");
        namespaceResolver15.Add("forms", "clr-namespace:FFImageLoading.Forms;assembly=FFImageLoading.Forms");
        namespaceResolver15.Add("xlabs", "clr-namespace:XLabs.Forms.Controls;assembly=XLabs.Forms");
        XamlTypeResolver service30 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver15, typeof (WidgetHomePage).GetTypeInfo().Assembly);
        xamlServiceProvider15.Add(type30, (object) service30);
        xamlServiceProvider15.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(118, 75)));
        object obj15 = resourceExtension43.ProvideValue((IServiceProvider) xamlServiceProvider15);
        label7.Style = (Style) obj15;
        label7.SetValue(Label.TextColorProperty, (object) new Color(0.250980406999588, 0.250980406999588, 0.250980406999588, 1.0));
        bindable22.Children.Add((View) label7);
        stackLayout4.Children.Add((View) bindable22);
        bindable24.Children.Add((View) stackLayout4);
        bindable23.SetValue(VisualElement.IsVisibleProperty, new VisualElement.VisibilityConverter().ConvertFromInvariantString("False"));
        resourceExtension15.Key = "microLabel";
        StaticResourceExtension resourceExtension44 = resourceExtension15;
        XamlServiceProvider xamlServiceProvider16 = new XamlServiceProvider();
        Type type31 = typeof (IProvideValueTarget);
        object[] objectAndParents16 = new object[0 + 9];
        objectAndParents16[0] = (object) bindable23;
        objectAndParents16[1] = (object) bindable24;
        objectAndParents16[2] = (object) bindable25;
        objectAndParents16[3] = (object) frame3;
        objectAndParents16[4] = (object) grid;
        objectAndParents16[5] = (object) bindable45;
        objectAndParents16[6] = (object) scrollView;
        objectAndParents16[7] = (object) bindable46;
        objectAndParents16[8] = (object) bindable47;
        SimpleValueTargetProvider service31 = new SimpleValueTargetProvider(objectAndParents16, (object) VisualElement.StyleProperty);
        xamlServiceProvider16.Add(type31, (object) service31);
        xamlServiceProvider16.Add(typeof (INameScopeProvider), (object) new NameScopeProvider()
        {
          NameScope = (INameScope) nameScope
        });
        Type type32 = typeof (IXamlTypeResolver);
        XmlNamespaceResolver namespaceResolver16 = new XmlNamespaceResolver();
        namespaceResolver16.Add("", "http://xamarin.com/schemas/2014/forms");
        namespaceResolver16.Add("x", "http://schemas.microsoft.com/winfx/2009/xaml");
        namespaceResolver16.Add("forms", "clr-namespace:FFImageLoading.Forms;assembly=FFImageLoading.Forms");
        namespaceResolver16.Add("xlabs", "clr-namespace:XLabs.Forms.Controls;assembly=XLabs.Forms");
        XamlTypeResolver service32 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver16, typeof (WidgetHomePage).GetTypeInfo().Assembly);
        xamlServiceProvider16.Add(type32, (object) service32);
        xamlServiceProvider16.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(123, 63)));
        object obj16 = resourceExtension44.ProvideValue((IServiceProvider) xamlServiceProvider16);
        bindable23.Style = (Style) obj16;
        bindable23.SetValue(Label.TextColorProperty, (object) new Color(0.400000005960464, 0.400000005960464, 0.400000005960464, 1.0));
        bindable23.SetValue(Label.TextProperty, (object) "Your latest transaction/s will reflect within 24 hours.");
        bindable23.SetValue(View.MarginProperty, (object) new Thickness(0.0, 10.0, 0.0, 0.0));
        bindable23.SetValue(View.VerticalOptionsProperty, (object) LayoutOptions.End);
        bindable24.Children.Add((View) bindable23);
        bindable25.Children.Add((View) bindable24);
        frame3.SetValue(ContentView.ContentProperty, (object) bindable25);
        grid.Children.Add((View) frame3);
        frame4.SetValue(Grid.ColumnProperty, (object) 0);
        frame4.SetValue(Grid.RowProperty, (object) 2);
        frame4.SetValue(VisualElement.OpacityProperty, (object) 0.0);
        frame4.SetValue(Frame.CornerRadiusProperty, (object) 5f);
        frame4.SetValue(Frame.HasShadowProperty, (object) true);
        frame4.SetValue(View.MarginProperty, (object) new Thickness(0.0, 0.0, 0.0, 5.0));
        frame4.SetValue(Layout.PaddingProperty, (object) new Thickness(0.0));
        bindable34.SetValue(StackLayout.SpacingProperty, (object) 0.0);
        bindable31.SetValue(StackLayout.SpacingProperty, (object) 0.0);
        bindable31.SetValue(Layout.PaddingProperty, (object) new Thickness(15.0, 10.0, 15.0, 10.0));
        bindable29.SetValue(StackLayout.OrientationProperty, (object) StackOrientation.Horizontal);
        resourceExtension16.Key = "normalHeader";
        StaticResourceExtension resourceExtension45 = resourceExtension16;
        XamlServiceProvider xamlServiceProvider17 = new XamlServiceProvider();
        Type type33 = typeof (IProvideValueTarget);
        object[] objectAndParents17 = new object[0 + 10];
        objectAndParents17[0] = (object) bindable26;
        objectAndParents17[1] = (object) bindable29;
        objectAndParents17[2] = (object) bindable31;
        objectAndParents17[3] = (object) bindable34;
        objectAndParents17[4] = (object) frame4;
        objectAndParents17[5] = (object) grid;
        objectAndParents17[6] = (object) bindable45;
        objectAndParents17[7] = (object) scrollView;
        objectAndParents17[8] = (object) bindable46;
        objectAndParents17[9] = (object) bindable47;
        SimpleValueTargetProvider service33 = new SimpleValueTargetProvider(objectAndParents17, (object) VisualElement.StyleProperty);
        xamlServiceProvider17.Add(type33, (object) service33);
        xamlServiceProvider17.Add(typeof (INameScopeProvider), (object) new NameScopeProvider()
        {
          NameScope = (INameScope) nameScope
        });
        Type type34 = typeof (IXamlTypeResolver);
        XmlNamespaceResolver namespaceResolver17 = new XmlNamespaceResolver();
        namespaceResolver17.Add("", "http://xamarin.com/schemas/2014/forms");
        namespaceResolver17.Add("x", "http://schemas.microsoft.com/winfx/2009/xaml");
        namespaceResolver17.Add("forms", "clr-namespace:FFImageLoading.Forms;assembly=FFImageLoading.Forms");
        namespaceResolver17.Add("xlabs", "clr-namespace:XLabs.Forms.Controls;assembly=XLabs.Forms");
        XamlTypeResolver service34 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver17, typeof (WidgetHomePage).GetTypeInfo().Assembly);
        xamlServiceProvider17.Add(type34, (object) service34);
        xamlServiceProvider17.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(136, 48)));
        object obj17 = resourceExtension45.ProvideValue((IServiceProvider) xamlServiceProvider17);
        bindable26.Style = (Style) obj17;
        bindable26.SetValue(Label.TextProperty, (object) "Latest News");
        bindable26.SetValue(Label.TextColorProperty, (object) new Color(0.250980406999588, 0.250980406999588, 0.250980406999588, 1.0));
        bindable26.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.FillAndExpand);
        bindable29.Children.Add((View) bindable26);
        bindable28.SetValue(Label.TextProperty, (object) "MORE NEWS");
        resourceExtension17.Key = "microHeader";
        StaticResourceExtension resourceExtension46 = resourceExtension17;
        XamlServiceProvider xamlServiceProvider18 = new XamlServiceProvider();
        Type type35 = typeof (IProvideValueTarget);
        object[] objectAndParents18 = new object[0 + 10];
        objectAndParents18[0] = (object) bindable28;
        objectAndParents18[1] = (object) bindable29;
        objectAndParents18[2] = (object) bindable31;
        objectAndParents18[3] = (object) bindable34;
        objectAndParents18[4] = (object) frame4;
        objectAndParents18[5] = (object) grid;
        objectAndParents18[6] = (object) bindable45;
        objectAndParents18[7] = (object) scrollView;
        objectAndParents18[8] = (object) bindable46;
        objectAndParents18[9] = (object) bindable47;
        SimpleValueTargetProvider service35 = new SimpleValueTargetProvider(objectAndParents18, (object) VisualElement.StyleProperty);
        xamlServiceProvider18.Add(type35, (object) service35);
        xamlServiceProvider18.Add(typeof (INameScopeProvider), (object) new NameScopeProvider()
        {
          NameScope = (INameScope) nameScope
        });
        Type type36 = typeof (IXamlTypeResolver);
        XmlNamespaceResolver namespaceResolver18 = new XmlNamespaceResolver();
        namespaceResolver18.Add("", "http://xamarin.com/schemas/2014/forms");
        namespaceResolver18.Add("x", "http://schemas.microsoft.com/winfx/2009/xaml");
        namespaceResolver18.Add("forms", "clr-namespace:FFImageLoading.Forms;assembly=FFImageLoading.Forms");
        namespaceResolver18.Add("xlabs", "clr-namespace:XLabs.Forms.Controls;assembly=XLabs.Forms");
        XamlTypeResolver service36 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver18, typeof (WidgetHomePage).GetTypeInfo().Assembly);
        xamlServiceProvider18.Add(type36, (object) service36);
        xamlServiceProvider18.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(138, 65)));
        object obj18 = resourceExtension46.ProvideValue((IServiceProvider) xamlServiceProvider18);
        bindable28.Style = (Style) obj18;
        bindable28.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.End);
        bindable28.SetValue(View.VerticalOptionsProperty, (object) LayoutOptions.Center);
        bindable27.Tapped += new EventHandler(bindable47.MoreNews_Tapped);
        bindable28.GestureRecognizers.Add((IGestureRecognizer) bindable27);
        bindable29.Children.Add((View) bindable28);
        bindable31.Children.Add((View) bindable29);
        bindable30.SetValue(BoxView.ColorProperty, (object) new Color(0.905882358551025, 0.752941191196442, 0.113725490868092, 1.0));
        bindable30.SetValue(VisualElement.HeightRequestProperty, (object) 1.5);
        bindable30.SetValue(View.MarginProperty, (object) new Thickness(0.0, 5.0, 0.0, 3.0));
        bindable30.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.FillAndExpand);
        bindable31.Children.Add((View) bindable30);
        bindable34.Children.Add((View) bindable31);
        bindable32.Tapped += new EventHandler(bindable47.Learn_More_Tapped);
        stackLayout5.GestureRecognizers.Add((IGestureRecognizer) bindable32);
        label8.SetValue(View.MarginProperty, (object) new Thickness(15.0, 0.0, 15.0, 5.0));
        label8.SetValue(View.VerticalOptionsProperty, (object) LayoutOptions.Start);
        label8.SetValue(Label.LineBreakModeProperty, (object) LineBreakMode.WordWrap);
        resourceExtension18.Key = "smallHeader";
        StaticResourceExtension resourceExtension47 = resourceExtension18;
        XamlServiceProvider xamlServiceProvider19 = new XamlServiceProvider();
        Type type37 = typeof (IProvideValueTarget);
        object[] objectAndParents19 = new object[0 + 9];
        objectAndParents19[0] = (object) label8;
        objectAndParents19[1] = (object) stackLayout5;
        objectAndParents19[2] = (object) bindable34;
        objectAndParents19[3] = (object) frame4;
        objectAndParents19[4] = (object) grid;
        objectAndParents19[5] = (object) bindable45;
        objectAndParents19[6] = (object) scrollView;
        objectAndParents19[7] = (object) bindable46;
        objectAndParents19[8] = (object) bindable47;
        SimpleValueTargetProvider service37 = new SimpleValueTargetProvider(objectAndParents19, (object) VisualElement.StyleProperty);
        xamlServiceProvider19.Add(type37, (object) service37);
        xamlServiceProvider19.Add(typeof (INameScopeProvider), (object) new NameScopeProvider()
        {
          NameScope = (INameScope) nameScope
        });
        Type type38 = typeof (IXamlTypeResolver);
        XmlNamespaceResolver namespaceResolver19 = new XmlNamespaceResolver();
        namespaceResolver19.Add("", "http://xamarin.com/schemas/2014/forms");
        namespaceResolver19.Add("x", "http://schemas.microsoft.com/winfx/2009/xaml");
        namespaceResolver19.Add("forms", "clr-namespace:FFImageLoading.Forms;assembly=FFImageLoading.Forms");
        namespaceResolver19.Add("xlabs", "clr-namespace:XLabs.Forms.Controls;assembly=XLabs.Forms");
        XamlTypeResolver service38 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver19, typeof (WidgetHomePage).GetTypeInfo().Assembly);
        xamlServiceProvider19.Add(type38, (object) service38);
        xamlServiceProvider19.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(159, 135)));
        object obj19 = resourceExtension47.ProvideValue((IServiceProvider) xamlServiceProvider19);
        label8.Style = (Style) obj19;
        label8.SetValue(Label.TextColorProperty, (object) new Color(0.250980406999588, 0.250980406999588, 0.250980406999588, 1.0));
        stackLayout5.Children.Add((View) label8);
        bindable33.SetValue(StackLayout.SpacingProperty, (object) 0.0);
        bindable33.SetValue(StackLayout.OrientationProperty, (object) StackOrientation.Horizontal);
        cachedImage.SetValue(CachedImage.LoadingPlaceholderProperty, new FFImageLoading.Forms.ImageSourceConverter().ConvertFromInvariantString("default_thumbnail"));
        cachedImage.SetValue(CachedImage.AspectProperty, (object) Aspect.AspectFill);
        cachedImage.SetValue(VisualElement.MinimumHeightRequestProperty, (object) 110.0);
        cachedImage.SetValue(View.VerticalOptionsProperty, (object) LayoutOptions.Start);
        cachedImage.SetValue(VisualElement.HeightRequestProperty, (object) 110.0);
        cachedImage.SetValue(View.MarginProperty, (object) new Thickness(15.0, 0.0, 0.0, 15.0));
        bindable33.Children.Add((View) cachedImage);
        label9.SetValue(View.MarginProperty, (object) new Thickness(10.0, 0.0, 10.0, 15.0));
        label9.SetValue(View.VerticalOptionsProperty, (object) LayoutOptions.Start);
        resourceExtension19.Key = "microLabel";
        StaticResourceExtension resourceExtension48 = resourceExtension19;
        XamlServiceProvider xamlServiceProvider20 = new XamlServiceProvider();
        Type type39 = typeof (IProvideValueTarget);
        object[] objectAndParents20 = new object[0 + 10];
        objectAndParents20[0] = (object) label9;
        objectAndParents20[1] = (object) bindable33;
        objectAndParents20[2] = (object) stackLayout5;
        objectAndParents20[3] = (object) bindable34;
        objectAndParents20[4] = (object) frame4;
        objectAndParents20[5] = (object) grid;
        objectAndParents20[6] = (object) bindable45;
        objectAndParents20[7] = (object) scrollView;
        objectAndParents20[8] = (object) bindable46;
        objectAndParents20[9] = (object) bindable47;
        SimpleValueTargetProvider service39 = new SimpleValueTargetProvider(objectAndParents20, (object) VisualElement.StyleProperty);
        xamlServiceProvider20.Add(type39, (object) service39);
        xamlServiceProvider20.Add(typeof (INameScopeProvider), (object) new NameScopeProvider()
        {
          NameScope = (INameScope) nameScope
        });
        Type type40 = typeof (IXamlTypeResolver);
        XmlNamespaceResolver namespaceResolver20 = new XmlNamespaceResolver();
        namespaceResolver20.Add("", "http://xamarin.com/schemas/2014/forms");
        namespaceResolver20.Add("x", "http://schemas.microsoft.com/winfx/2009/xaml");
        namespaceResolver20.Add("forms", "clr-namespace:FFImageLoading.Forms;assembly=FFImageLoading.Forms");
        namespaceResolver20.Add("xlabs", "clr-namespace:XLabs.Forms.Controls;assembly=XLabs.Forms");
        XamlTypeResolver service40 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver20, typeof (WidgetHomePage).GetTypeInfo().Assembly);
        xamlServiceProvider20.Add(type40, (object) service40);
        xamlServiceProvider20.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(163, 116)));
        object obj20 = resourceExtension48.ProvideValue((IServiceProvider) xamlServiceProvider20);
        label9.Style = (Style) obj20;
        Label label20 = label9;
        BindableProperty fontSizeProperty2 = Label.FontSizeProperty;
        FontSizeConverter fontSizeConverter2 = new FontSizeConverter();
        XamlServiceProvider xamlServiceProvider21 = new XamlServiceProvider();
        Type type41 = typeof (IProvideValueTarget);
        object[] objectAndParents21 = new object[0 + 10];
        objectAndParents21[0] = (object) label9;
        objectAndParents21[1] = (object) bindable33;
        objectAndParents21[2] = (object) stackLayout5;
        objectAndParents21[3] = (object) bindable34;
        objectAndParents21[4] = (object) frame4;
        objectAndParents21[5] = (object) grid;
        objectAndParents21[6] = (object) bindable45;
        objectAndParents21[7] = (object) scrollView;
        objectAndParents21[8] = (object) bindable46;
        objectAndParents21[9] = (object) bindable47;
        SimpleValueTargetProvider service41 = new SimpleValueTargetProvider(objectAndParents21, (object) Label.FontSizeProperty);
        xamlServiceProvider21.Add(type41, (object) service41);
        xamlServiceProvider21.Add(typeof (INameScopeProvider), (object) new NameScopeProvider()
        {
          NameScope = (INameScope) nameScope
        });
        Type type42 = typeof (IXamlTypeResolver);
        XmlNamespaceResolver namespaceResolver21 = new XmlNamespaceResolver();
        namespaceResolver21.Add("", "http://xamarin.com/schemas/2014/forms");
        namespaceResolver21.Add("x", "http://schemas.microsoft.com/winfx/2009/xaml");
        namespaceResolver21.Add("forms", "clr-namespace:FFImageLoading.Forms;assembly=FFImageLoading.Forms");
        namespaceResolver21.Add("xlabs", "clr-namespace:XLabs.Forms.Controls;assembly=XLabs.Forms");
        XamlTypeResolver service42 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver21, typeof (WidgetHomePage).GetTypeInfo().Assembly);
        xamlServiceProvider21.Add(type42, (object) service42);
        xamlServiceProvider21.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(163, 152)));
        object obj21 = ((IExtendedTypeConverter) fontSizeConverter2).ConvertFromInvariantString("11", (IServiceProvider) xamlServiceProvider21);
        label20.SetValue(fontSizeProperty2, obj21);
        label9.SetValue(Label.TextColorProperty, (object) new Color(0.400000005960464, 0.400000005960464, 0.400000005960464, 1.0));
        bindable33.Children.Add((View) label9);
        stackLayout5.Children.Add((View) bindable33);
        bindable34.Children.Add((View) stackLayout5);
        frame4.SetValue(ContentView.ContentProperty, (object) bindable34);
        grid.Children.Add((View) frame4);
        frame5.SetValue(Grid.ColumnProperty, (object) 0);
        frame5.SetValue(Grid.RowProperty, (object) 3);
        frame5.SetValue(Frame.CornerRadiusProperty, (object) 5f);
        frame5.SetValue(VisualElement.OpacityProperty, (object) 0.0);
        frame5.SetValue(Frame.HasShadowProperty, (object) true);
        frame5.SetValue(View.MarginProperty, (object) new Thickness(0.0, 0.0, 0.0, 5.0));
        frame5.SetValue(Layout.PaddingProperty, (object) new Thickness(0.0));
        bindable44.SetValue(StackLayout.SpacingProperty, (object) 0.0);
        bindable43.SetValue(StackLayout.SpacingProperty, (object) 1.0);
        bindable43.SetValue(View.MarginProperty, (object) new Thickness(0.0, 0.0, 0.0, 5.0));
        bindable43.SetValue(Layout.PaddingProperty, (object) new Thickness(15.0, 10.0, 15.0, 10.0));
        bindable38.SetValue(StackLayout.OrientationProperty, (object) StackOrientation.Horizontal);
        bindable36.SetValue(Label.TextProperty, (object) "Latest Grade");
        resourceExtension20.Key = "normalHeader";
        StaticResourceExtension resourceExtension49 = resourceExtension20;
        XamlServiceProvider xamlServiceProvider22 = new XamlServiceProvider();
        Type type43 = typeof (IProvideValueTarget);
        object[] objectAndParents22 = new object[0 + 10];
        objectAndParents22[0] = (object) bindable36;
        objectAndParents22[1] = (object) bindable38;
        objectAndParents22[2] = (object) bindable43;
        objectAndParents22[3] = (object) bindable44;
        objectAndParents22[4] = (object) frame5;
        objectAndParents22[5] = (object) grid;
        objectAndParents22[6] = (object) bindable45;
        objectAndParents22[7] = (object) scrollView;
        objectAndParents22[8] = (object) bindable46;
        objectAndParents22[9] = (object) bindable47;
        SimpleValueTargetProvider service43 = new SimpleValueTargetProvider(objectAndParents22, (object) VisualElement.StyleProperty);
        xamlServiceProvider22.Add(type43, (object) service43);
        xamlServiceProvider22.Add(typeof (INameScopeProvider), (object) new NameScopeProvider()
        {
          NameScope = (INameScope) nameScope
        });
        Type type44 = typeof (IXamlTypeResolver);
        XmlNamespaceResolver namespaceResolver22 = new XmlNamespaceResolver();
        namespaceResolver22.Add("", "http://xamarin.com/schemas/2014/forms");
        namespaceResolver22.Add("x", "http://schemas.microsoft.com/winfx/2009/xaml");
        namespaceResolver22.Add("forms", "clr-namespace:FFImageLoading.Forms;assembly=FFImageLoading.Forms");
        namespaceResolver22.Add("xlabs", "clr-namespace:XLabs.Forms.Controls;assembly=XLabs.Forms");
        XamlTypeResolver service44 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver22, typeof (WidgetHomePage).GetTypeInfo().Assembly);
        xamlServiceProvider22.Add(type44, (object) service44);
        xamlServiceProvider22.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(178, 68)));
        object obj22 = resourceExtension49.ProvideValue((IServiceProvider) xamlServiceProvider22);
        bindable36.Style = (Style) obj22;
        bindable36.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.FillAndExpand);
        bindable36.SetValue(Label.TextColorProperty, (object) new Color(0.250980406999588, 0.250980406999588, 0.250980406999588, 1.0));
        bindable35.Tapped += new EventHandler(bindable47.ViewAllGrades_Tapped);
        bindable36.GestureRecognizers.Add((IGestureRecognizer) bindable35);
        bindable38.Children.Add((View) bindable36);
        label10.SetValue(Label.TextProperty, (object) "VIEW ALL");
        resourceExtension21.Key = "microHeader";
        StaticResourceExtension resourceExtension50 = resourceExtension21;
        XamlServiceProvider xamlServiceProvider23 = new XamlServiceProvider();
        Type type45 = typeof (IProvideValueTarget);
        object[] objectAndParents23 = new object[0 + 10];
        objectAndParents23[0] = (object) label10;
        objectAndParents23[1] = (object) bindable38;
        objectAndParents23[2] = (object) bindable43;
        objectAndParents23[3] = (object) bindable44;
        objectAndParents23[4] = (object) frame5;
        objectAndParents23[5] = (object) grid;
        objectAndParents23[6] = (object) bindable45;
        objectAndParents23[7] = (object) scrollView;
        objectAndParents23[8] = (object) bindable46;
        objectAndParents23[9] = (object) bindable47;
        SimpleValueTargetProvider service45 = new SimpleValueTargetProvider(objectAndParents23, (object) VisualElement.StyleProperty);
        xamlServiceProvider23.Add(type45, (object) service45);
        xamlServiceProvider23.Add(typeof (INameScopeProvider), (object) new NameScopeProvider()
        {
          NameScope = (INameScope) nameScope
        });
        Type type46 = typeof (IXamlTypeResolver);
        XmlNamespaceResolver namespaceResolver23 = new XmlNamespaceResolver();
        namespaceResolver23.Add("", "http://xamarin.com/schemas/2014/forms");
        namespaceResolver23.Add("x", "http://schemas.microsoft.com/winfx/2009/xaml");
        namespaceResolver23.Add("forms", "clr-namespace:FFImageLoading.Forms;assembly=FFImageLoading.Forms");
        namespaceResolver23.Add("xlabs", "clr-namespace:XLabs.Forms.Controls;assembly=XLabs.Forms");
        XamlTypeResolver service46 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver23, typeof (WidgetHomePage).GetTypeInfo().Assembly);
        xamlServiceProvider23.Add(type46, (object) service46);
        xamlServiceProvider23.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(184, 90)));
        object obj23 = resourceExtension50.ProvideValue((IServiceProvider) xamlServiceProvider23);
        label10.Style = (Style) obj23;
        label10.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.End);
        label10.SetValue(View.VerticalOptionsProperty, (object) LayoutOptions.Center);
        bindable37.Tapped += new EventHandler(bindable47.ViewAllGrades_Tapped);
        label10.GestureRecognizers.Add((IGestureRecognizer) bindable37);
        bindable38.Children.Add((View) label10);
        bindable43.Children.Add((View) bindable38);
        label11.SetValue(View.MarginProperty, (object) new Thickness(0.0, 2.0, 0.0, 0.0));
        resourceExtension22.Key = "microHeader";
        StaticResourceExtension resourceExtension51 = resourceExtension22;
        XamlServiceProvider xamlServiceProvider24 = new XamlServiceProvider();
        Type type47 = typeof (IProvideValueTarget);
        object[] objectAndParents24 = new object[0 + 9];
        objectAndParents24[0] = (object) label11;
        objectAndParents24[1] = (object) bindable43;
        objectAndParents24[2] = (object) bindable44;
        objectAndParents24[3] = (object) frame5;
        objectAndParents24[4] = (object) grid;
        objectAndParents24[5] = (object) bindable45;
        objectAndParents24[6] = (object) scrollView;
        objectAndParents24[7] = (object) bindable46;
        objectAndParents24[8] = (object) bindable47;
        SimpleValueTargetProvider service47 = new SimpleValueTargetProvider(objectAndParents24, (object) VisualElement.StyleProperty);
        xamlServiceProvider24.Add(type47, (object) service47);
        xamlServiceProvider24.Add(typeof (INameScopeProvider), (object) new NameScopeProvider()
        {
          NameScope = (INameScope) nameScope
        });
        Type type48 = typeof (IXamlTypeResolver);
        XmlNamespaceResolver namespaceResolver24 = new XmlNamespaceResolver();
        namespaceResolver24.Add("", "http://xamarin.com/schemas/2014/forms");
        namespaceResolver24.Add("x", "http://schemas.microsoft.com/winfx/2009/xaml");
        namespaceResolver24.Add("forms", "clr-namespace:FFImageLoading.Forms;assembly=FFImageLoading.Forms");
        namespaceResolver24.Add("xlabs", "clr-namespace:XLabs.Forms.Controls;assembly=XLabs.Forms");
        XamlTypeResolver service48 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver24, typeof (WidgetHomePage).GetTypeInfo().Assembly);
        xamlServiceProvider24.Add(type48, (object) service48);
        xamlServiceProvider24.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(194, 83)));
        object obj24 = resourceExtension51.ProvideValue((IServiceProvider) xamlServiceProvider24);
        label11.Style = (Style) obj24;
        label11.SetValue(Label.TextColorProperty, (object) new Color(0.400000005960464, 0.400000005960464, 0.400000005960464, 1.0));
        bindable43.Children.Add((View) label11);
        bindable39.SetValue(BoxView.ColorProperty, (object) new Color(0.905882358551025, 0.752941191196442, 0.113725490868092, 1.0));
        bindable39.SetValue(VisualElement.HeightRequestProperty, (object) 1.5);
        bindable39.SetValue(View.MarginProperty, (object) new Thickness(0.0, 5.0, 0.0, 0.0));
        bindable39.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.FillAndExpand);
        bindable43.Children.Add((View) bindable39);
        activityIndicator3.SetValue(View.MarginProperty, (object) new Thickness(0.0, 5.0, 0.0, 5.0));
        activityIndicator3.SetValue(VisualElement.IsVisibleProperty, new VisualElement.VisibilityConverter().ConvertFromInvariantString("False"));
        activityIndicator3.SetValue(ActivityIndicator.ColorProperty, (object) Color.LightGray);
        activityIndicator3.SetValue(ActivityIndicator.IsRunningProperty, (object) true);
        activityIndicator3.SetValue(VisualElement.HeightRequestProperty, (object) 25.0);
        activityIndicator3.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.Center);
        activityIndicator3.SetValue(View.VerticalOptionsProperty, (object) LayoutOptions.Center);
        bindable43.Children.Add((View) activityIndicator3);
        label12.SetValue(VisualElement.IsVisibleProperty, new VisualElement.VisibilityConverter().ConvertFromInvariantString("False"));
        label12.SetValue(View.MarginProperty, (object) new Thickness(0.0, 5.0, 0.0, 0.0));
        resourceExtension23.Key = "smallLabel";
        StaticResourceExtension resourceExtension52 = resourceExtension23;
        XamlServiceProvider xamlServiceProvider25 = new XamlServiceProvider();
        Type type49 = typeof (IProvideValueTarget);
        object[] objectAndParents25 = new object[0 + 9];
        objectAndParents25[0] = (object) label12;
        objectAndParents25[1] = (object) bindable43;
        objectAndParents25[2] = (object) bindable44;
        objectAndParents25[3] = (object) frame5;
        objectAndParents25[4] = (object) grid;
        objectAndParents25[5] = (object) bindable45;
        objectAndParents25[6] = (object) scrollView;
        objectAndParents25[7] = (object) bindable46;
        objectAndParents25[8] = (object) bindable47;
        SimpleValueTargetProvider service49 = new SimpleValueTargetProvider(objectAndParents25, (object) VisualElement.StyleProperty);
        xamlServiceProvider25.Add(type49, (object) service49);
        xamlServiceProvider25.Add(typeof (INameScopeProvider), (object) new NameScopeProvider()
        {
          NameScope = (INameScope) nameScope
        });
        Type type50 = typeof (IXamlTypeResolver);
        XmlNamespaceResolver namespaceResolver25 = new XmlNamespaceResolver();
        namespaceResolver25.Add("", "http://xamarin.com/schemas/2014/forms");
        namespaceResolver25.Add("x", "http://schemas.microsoft.com/winfx/2009/xaml");
        namespaceResolver25.Add("forms", "clr-namespace:FFImageLoading.Forms;assembly=FFImageLoading.Forms");
        namespaceResolver25.Add("xlabs", "clr-namespace:XLabs.Forms.Controls;assembly=XLabs.Forms");
        XamlTypeResolver service50 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver25, typeof (WidgetHomePage).GetTypeInfo().Assembly);
        xamlServiceProvider25.Add(type50, (object) service50);
        xamlServiceProvider25.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(202, 104)));
        object obj25 = resourceExtension52.ProvideValue((IServiceProvider) xamlServiceProvider25);
        label12.Style = (Style) obj25;
        label12.SetValue(Label.TextColorProperty, (object) new Color(0.400000005960464, 0.400000005960464, 0.400000005960464, 1.0));
        label12.SetValue(Label.TextProperty, (object) "No grades available.");
        label12.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.FillAndExpand);
        bindable43.Children.Add((View) label12);
        stackLayout7.SetValue(StackLayout.OrientationProperty, (object) StackOrientation.Vertical);
        stackLayout7.SetValue(Layout.PaddingProperty, (object) new Thickness(0.0, 10.0, 0.0, 0.0));
        bindable42.SetValue(StackLayout.OrientationProperty, (object) StackOrientation.Horizontal);
        bindable42.SetValue(Layout.PaddingProperty, (object) new Thickness(0.0));
        bindable40.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.FillAndExpand);
        bindable40.SetValue(StackLayout.SpacingProperty, (object) 0.0);
        bindable40.SetValue(View.VerticalOptionsProperty, (object) LayoutOptions.End);
        resourceExtension24.Key = "microHeader";
        StaticResourceExtension resourceExtension53 = resourceExtension24;
        XamlServiceProvider xamlServiceProvider26 = new XamlServiceProvider();
        Type type51 = typeof (IProvideValueTarget);
        object[] objectAndParents26 = new object[0 + 12];
        objectAndParents26[0] = (object) label13;
        objectAndParents26[1] = (object) bindable40;
        objectAndParents26[2] = (object) bindable42;
        objectAndParents26[3] = (object) stackLayout7;
        objectAndParents26[4] = (object) bindable43;
        objectAndParents26[5] = (object) bindable44;
        objectAndParents26[6] = (object) frame5;
        objectAndParents26[7] = (object) grid;
        objectAndParents26[8] = (object) bindable45;
        objectAndParents26[9] = (object) scrollView;
        objectAndParents26[10] = (object) bindable46;
        objectAndParents26[11] = (object) bindable47;
        SimpleValueTargetProvider service51 = new SimpleValueTargetProvider(objectAndParents26, (object) VisualElement.StyleProperty);
        xamlServiceProvider26.Add(type51, (object) service51);
        xamlServiceProvider26.Add(typeof (INameScopeProvider), (object) new NameScopeProvider()
        {
          NameScope = (INameScope) nameScope
        });
        Type type52 = typeof (IXamlTypeResolver);
        XmlNamespaceResolver namespaceResolver26 = new XmlNamespaceResolver();
        namespaceResolver26.Add("", "http://xamarin.com/schemas/2014/forms");
        namespaceResolver26.Add("x", "http://schemas.microsoft.com/winfx/2009/xaml");
        namespaceResolver26.Add("forms", "clr-namespace:FFImageLoading.Forms;assembly=FFImageLoading.Forms");
        namespaceResolver26.Add("xlabs", "clr-namespace:XLabs.Forms.Controls;assembly=XLabs.Forms");
        XamlTypeResolver service52 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver26, typeof (WidgetHomePage).GetTypeInfo().Assembly);
        xamlServiceProvider26.Add(type52, (object) service52);
        xamlServiceProvider26.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(212, 78)));
        object obj26 = resourceExtension53.ProvideValue((IServiceProvider) xamlServiceProvider26);
        label13.Style = (Style) obj26;
        label13.SetValue(Label.TextColorProperty, (object) new Color(0.400000005960464, 0.400000005960464, 0.400000005960464, 1.0));
        bindable40.Children.Add((View) label13);
        resourceExtension25.Key = "normalHeader";
        StaticResourceExtension resourceExtension54 = resourceExtension25;
        XamlServiceProvider xamlServiceProvider27 = new XamlServiceProvider();
        Type type53 = typeof (IProvideValueTarget);
        object[] objectAndParents27 = new object[0 + 12];
        objectAndParents27[0] = (object) label14;
        objectAndParents27[1] = (object) bindable40;
        objectAndParents27[2] = (object) bindable42;
        objectAndParents27[3] = (object) stackLayout7;
        objectAndParents27[4] = (object) bindable43;
        objectAndParents27[5] = (object) bindable44;
        objectAndParents27[6] = (object) frame5;
        objectAndParents27[7] = (object) grid;
        objectAndParents27[8] = (object) bindable45;
        objectAndParents27[9] = (object) scrollView;
        objectAndParents27[10] = (object) bindable46;
        objectAndParents27[11] = (object) bindable47;
        SimpleValueTargetProvider service53 = new SimpleValueTargetProvider(objectAndParents27, (object) VisualElement.StyleProperty);
        xamlServiceProvider27.Add(type53, (object) service53);
        xamlServiceProvider27.Add(typeof (INameScopeProvider), (object) new NameScopeProvider()
        {
          NameScope = (INameScope) nameScope
        });
        Type type54 = typeof (IXamlTypeResolver);
        XmlNamespaceResolver namespaceResolver27 = new XmlNamespaceResolver();
        namespaceResolver27.Add("", "http://xamarin.com/schemas/2014/forms");
        namespaceResolver27.Add("x", "http://schemas.microsoft.com/winfx/2009/xaml");
        namespaceResolver27.Add("forms", "clr-namespace:FFImageLoading.Forms;assembly=FFImageLoading.Forms");
        namespaceResolver27.Add("xlabs", "clr-namespace:XLabs.Forms.Controls;assembly=XLabs.Forms");
        XamlTypeResolver service54 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver27, typeof (WidgetHomePage).GetTypeInfo().Assembly);
        xamlServiceProvider27.Add(type54, (object) service54);
        xamlServiceProvider27.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(213, 80)));
        object obj27 = resourceExtension54.ProvideValue((IServiceProvider) xamlServiceProvider27);
        label14.Style = (Style) obj27;
        label14.SetValue(Label.TextColorProperty, (object) new Color(0.250980406999588, 0.250980406999588, 0.250980406999588, 1.0));
        bindable40.Children.Add((View) label14);
        bindable42.Children.Add((View) bindable40);
        bindable41.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.End);
        bindable41.SetValue(StackLayout.SpacingProperty, (object) 0.0);
        bindable41.SetValue(View.VerticalOptionsProperty, (object) LayoutOptions.End);
        bindable41.SetValue(View.MarginProperty, (object) new Thickness(0.0));
        resourceExtension26.Key = "microHeader";
        StaticResourceExtension resourceExtension55 = resourceExtension26;
        XamlServiceProvider xamlServiceProvider28 = new XamlServiceProvider();
        Type type55 = typeof (IProvideValueTarget);
        object[] objectAndParents28 = new object[0 + 12];
        objectAndParents28[0] = (object) label15;
        objectAndParents28[1] = (object) bindable41;
        objectAndParents28[2] = (object) bindable42;
        objectAndParents28[3] = (object) stackLayout7;
        objectAndParents28[4] = (object) bindable43;
        objectAndParents28[5] = (object) bindable44;
        objectAndParents28[6] = (object) frame5;
        objectAndParents28[7] = (object) grid;
        objectAndParents28[8] = (object) bindable45;
        objectAndParents28[9] = (object) scrollView;
        objectAndParents28[10] = (object) bindable46;
        objectAndParents28[11] = (object) bindable47;
        SimpleValueTargetProvider service55 = new SimpleValueTargetProvider(objectAndParents28, (object) VisualElement.StyleProperty);
        xamlServiceProvider28.Add(type55, (object) service55);
        xamlServiceProvider28.Add(typeof (INameScopeProvider), (object) new NameScopeProvider()
        {
          NameScope = (INameScope) nameScope
        });
        Type type56 = typeof (IXamlTypeResolver);
        XmlNamespaceResolver namespaceResolver28 = new XmlNamespaceResolver();
        namespaceResolver28.Add("", "http://xamarin.com/schemas/2014/forms");
        namespaceResolver28.Add("x", "http://schemas.microsoft.com/winfx/2009/xaml");
        namespaceResolver28.Add("forms", "clr-namespace:FFImageLoading.Forms;assembly=FFImageLoading.Forms");
        namespaceResolver28.Add("xlabs", "clr-namespace:XLabs.Forms.Controls;assembly=XLabs.Forms");
        XamlTypeResolver service56 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver28, typeof (WidgetHomePage).GetTypeInfo().Assembly);
        xamlServiceProvider28.Add(type56, (object) service56);
        xamlServiceProvider28.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(217, 81)));
        object obj28 = resourceExtension55.ProvideValue((IServiceProvider) xamlServiceProvider28);
        label15.Style = (Style) obj28;
        label15.SetValue(Label.HorizontalTextAlignmentProperty, new TextAlignmentConverter().ConvertFromInvariantString("End"));
        label15.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.EndAndExpand);
        bindable41.Children.Add((View) label15);
        resourceExtension27.Key = "mediumHeader";
        StaticResourceExtension resourceExtension56 = resourceExtension27;
        XamlServiceProvider xamlServiceProvider29 = new XamlServiceProvider();
        Type type57 = typeof (IProvideValueTarget);
        object[] objectAndParents29 = new object[0 + 12];
        objectAndParents29[0] = (object) label16;
        objectAndParents29[1] = (object) bindable41;
        objectAndParents29[2] = (object) bindable42;
        objectAndParents29[3] = (object) stackLayout7;
        objectAndParents29[4] = (object) bindable43;
        objectAndParents29[5] = (object) bindable44;
        objectAndParents29[6] = (object) frame5;
        objectAndParents29[7] = (object) grid;
        objectAndParents29[8] = (object) bindable45;
        objectAndParents29[9] = (object) scrollView;
        objectAndParents29[10] = (object) bindable46;
        objectAndParents29[11] = (object) bindable47;
        SimpleValueTargetProvider service57 = new SimpleValueTargetProvider(objectAndParents29, (object) VisualElement.StyleProperty);
        xamlServiceProvider29.Add(type57, (object) service57);
        xamlServiceProvider29.Add(typeof (INameScopeProvider), (object) new NameScopeProvider()
        {
          NameScope = (INameScope) nameScope
        });
        Type type58 = typeof (IXamlTypeResolver);
        XmlNamespaceResolver namespaceResolver29 = new XmlNamespaceResolver();
        namespaceResolver29.Add("", "http://xamarin.com/schemas/2014/forms");
        namespaceResolver29.Add("x", "http://schemas.microsoft.com/winfx/2009/xaml");
        namespaceResolver29.Add("forms", "clr-namespace:FFImageLoading.Forms;assembly=FFImageLoading.Forms");
        namespaceResolver29.Add("xlabs", "clr-namespace:XLabs.Forms.Controls;assembly=XLabs.Forms");
        XamlTypeResolver service58 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver29, typeof (WidgetHomePage).GetTypeInfo().Assembly);
        xamlServiceProvider29.Add(type58, (object) service58);
        xamlServiceProvider29.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(218, 80)));
        object obj29 = resourceExtension56.ProvideValue((IServiceProvider) xamlServiceProvider29);
        label16.Style = (Style) obj29;
        label16.SetValue(Label.TextColorProperty, (object) new Color(0.250980406999588, 0.250980406999588, 0.250980406999588, 1.0));
        label16.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.EndAndExpand);
        bindable41.Children.Add((View) label16);
        bindable42.Children.Add((View) bindable41);
        stackLayout7.Children.Add((View) bindable42);
        stackLayout6.SetValue(VisualElement.BackgroundColorProperty, (object) new Color(1.0, 0.921568632125854, 0.933333337306976, 1.0));
        stackLayout6.SetValue(VisualElement.IsVisibleProperty, new VisualElement.VisibilityConverter().ConvertFromInvariantString("false"));
        stackLayout6.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.FillAndExpand);
        stackLayout6.SetValue(Layout.PaddingProperty, (object) new Thickness(5.0));
        stackLayout6.SetValue(View.MarginProperty, (object) new Thickness(0.0, 5.0, 0.0, 5.0));
        resourceExtension28.Key = "microLabel";
        StaticResourceExtension resourceExtension57 = resourceExtension28;
        XamlServiceProvider xamlServiceProvider30 = new XamlServiceProvider();
        Type type59 = typeof (IProvideValueTarget);
        object[] objectAndParents30 = new object[0 + 11];
        objectAndParents30[0] = (object) label17;
        objectAndParents30[1] = (object) stackLayout6;
        objectAndParents30[2] = (object) stackLayout7;
        objectAndParents30[3] = (object) bindable43;
        objectAndParents30[4] = (object) bindable44;
        objectAndParents30[5] = (object) frame5;
        objectAndParents30[6] = (object) grid;
        objectAndParents30[7] = (object) bindable45;
        objectAndParents30[8] = (object) scrollView;
        objectAndParents30[9] = (object) bindable46;
        objectAndParents30[10] = (object) bindable47;
        SimpleValueTargetProvider service59 = new SimpleValueTargetProvider(objectAndParents30, (object) VisualElement.StyleProperty);
        xamlServiceProvider30.Add(type59, (object) service59);
        xamlServiceProvider30.Add(typeof (INameScopeProvider), (object) new NameScopeProvider()
        {
          NameScope = (INameScope) nameScope
        });
        Type type60 = typeof (IXamlTypeResolver);
        XmlNamespaceResolver namespaceResolver30 = new XmlNamespaceResolver();
        namespaceResolver30.Add("", "http://xamarin.com/schemas/2014/forms");
        namespaceResolver30.Add("x", "http://schemas.microsoft.com/winfx/2009/xaml");
        namespaceResolver30.Add("forms", "clr-namespace:FFImageLoading.Forms;assembly=FFImageLoading.Forms");
        namespaceResolver30.Add("xlabs", "clr-namespace:XLabs.Forms.Controls;assembly=XLabs.Forms");
        XamlTypeResolver service60 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver30, typeof (WidgetHomePage).GetTypeInfo().Assembly);
        xamlServiceProvider30.Add(type60, (object) service60);
        xamlServiceProvider30.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(223, 72)));
        object obj30 = resourceExtension57.ProvideValue((IServiceProvider) xamlServiceProvider30);
        label17.Style = (Style) obj30;
        label17.SetValue(Label.FontFamilyProperty, (object) "FontAwesome5-Regular.otf#Regular");
        Label label21 = label17;
        BindableProperty fontSizeProperty3 = Label.FontSizeProperty;
        FontSizeConverter fontSizeConverter3 = new FontSizeConverter();
        XamlServiceProvider xamlServiceProvider31 = new XamlServiceProvider();
        Type type61 = typeof (IProvideValueTarget);
        object[] objectAndParents31 = new object[0 + 11];
        objectAndParents31[0] = (object) label17;
        objectAndParents31[1] = (object) stackLayout6;
        objectAndParents31[2] = (object) stackLayout7;
        objectAndParents31[3] = (object) bindable43;
        objectAndParents31[4] = (object) bindable44;
        objectAndParents31[5] = (object) frame5;
        objectAndParents31[6] = (object) grid;
        objectAndParents31[7] = (object) bindable45;
        objectAndParents31[8] = (object) scrollView;
        objectAndParents31[9] = (object) bindable46;
        objectAndParents31[10] = (object) bindable47;
        SimpleValueTargetProvider service61 = new SimpleValueTargetProvider(objectAndParents31, (object) Label.FontSizeProperty);
        xamlServiceProvider31.Add(type61, (object) service61);
        xamlServiceProvider31.Add(typeof (INameScopeProvider), (object) new NameScopeProvider()
        {
          NameScope = (INameScope) nameScope
        });
        Type type62 = typeof (IXamlTypeResolver);
        XmlNamespaceResolver namespaceResolver31 = new XmlNamespaceResolver();
        namespaceResolver31.Add("", "http://xamarin.com/schemas/2014/forms");
        namespaceResolver31.Add("x", "http://schemas.microsoft.com/winfx/2009/xaml");
        namespaceResolver31.Add("forms", "clr-namespace:FFImageLoading.Forms;assembly=FFImageLoading.Forms");
        namespaceResolver31.Add("xlabs", "clr-namespace:XLabs.Forms.Controls;assembly=XLabs.Forms");
        XamlTypeResolver service62 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver31, typeof (WidgetHomePage).GetTypeInfo().Assembly);
        xamlServiceProvider31.Add(type62, (object) service62);
        xamlServiceProvider31.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(223, 154)));
        object obj31 = ((IExtendedTypeConverter) fontSizeConverter3).ConvertFromInvariantString("12", (IServiceProvider) xamlServiceProvider31);
        label21.SetValue(fontSizeProperty3, obj31);
        label17.SetValue(Label.TextColorProperty, (object) new Color(0.862745106220245, 0.207843139767647, 0.270588248968124, 1.0));
        label17.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.StartAndExpand);
        label17.SetValue(Label.HorizontalTextAlignmentProperty, new TextAlignmentConverter().ConvertFromInvariantString("Start"));
        label17.SetValue(View.VerticalOptionsProperty, (object) LayoutOptions.Start);
        label17.SetValue(Label.TextProperty, (object) "\uF070 Unable to view current grade. Please see the registrar.");
        stackLayout6.Children.Add((View) label17);
        stackLayout7.Children.Add((View) stackLayout6);
        bindable43.Children.Add((View) stackLayout7);
        bindable44.Children.Add((View) bindable43);
        frame5.SetValue(ContentView.ContentProperty, (object) bindable44);
        grid.Children.Add((View) frame5);
        bindable45.Children.Add((View) grid);
        scrollView.Content = (View) bindable45;
        bindable46.Children.Add((View) scrollView);
        stackLayout8.SetValue(VisualElement.BackgroundColorProperty, (object) new Color(0.180392161011696, 0.192156866192818, 0.192156866192818, 1.0));
        stackLayout8.SetValue(VisualElement.IsVisibleProperty, new VisualElement.VisibilityConverter().ConvertFromInvariantString("False"));
        stackLayout8.SetValue(View.VerticalOptionsProperty, (object) LayoutOptions.End);
        stackLayout8.SetValue(Layout.PaddingProperty, (object) new Thickness(3.0));
        stackLayout8.SetValue(View.MarginProperty, (object) new Thickness(0.0));
        label18.SetValue(Label.TextProperty, (object) "No connection");
        resourceExtension29.Key = "microLabel";
        StaticResourceExtension resourceExtension58 = resourceExtension29;
        XamlServiceProvider xamlServiceProvider32 = new XamlServiceProvider();
        Type type63 = typeof (IProvideValueTarget);
        object[] objectAndParents32 = new object[0 + 4];
        objectAndParents32[0] = (object) label18;
        objectAndParents32[1] = (object) stackLayout8;
        objectAndParents32[2] = (object) bindable46;
        objectAndParents32[3] = (object) bindable47;
        SimpleValueTargetProvider service63 = new SimpleValueTargetProvider(objectAndParents32, (object) VisualElement.StyleProperty);
        xamlServiceProvider32.Add(type63, (object) service63);
        xamlServiceProvider32.Add(typeof (INameScopeProvider), (object) new NameScopeProvider()
        {
          NameScope = (INameScope) nameScope
        });
        Type type64 = typeof (IXamlTypeResolver);
        XmlNamespaceResolver namespaceResolver32 = new XmlNamespaceResolver();
        namespaceResolver32.Add("", "http://xamarin.com/schemas/2014/forms");
        namespaceResolver32.Add("x", "http://schemas.microsoft.com/winfx/2009/xaml");
        namespaceResolver32.Add("forms", "clr-namespace:FFImageLoading.Forms;assembly=FFImageLoading.Forms");
        namespaceResolver32.Add("xlabs", "clr-namespace:XLabs.Forms.Controls;assembly=XLabs.Forms");
        XamlTypeResolver service64 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver32, typeof (WidgetHomePage).GetTypeInfo().Assembly);
        xamlServiceProvider32.Add(type64, (object) service64);
        xamlServiceProvider32.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(240, 64)));
        object obj32 = resourceExtension58.ProvideValue((IServiceProvider) xamlServiceProvider32);
        label18.Style = (Style) obj32;
        Label label22 = label18;
        BindableProperty fontSizeProperty4 = Label.FontSizeProperty;
        FontSizeConverter fontSizeConverter4 = new FontSizeConverter();
        XamlServiceProvider xamlServiceProvider33 = new XamlServiceProvider();
        Type type65 = typeof (IProvideValueTarget);
        object[] objectAndParents33 = new object[0 + 4];
        objectAndParents33[0] = (object) label18;
        objectAndParents33[1] = (object) stackLayout8;
        objectAndParents33[2] = (object) bindable46;
        objectAndParents33[3] = (object) bindable47;
        SimpleValueTargetProvider service65 = new SimpleValueTargetProvider(objectAndParents33, (object) Label.FontSizeProperty);
        xamlServiceProvider33.Add(type65, (object) service65);
        xamlServiceProvider33.Add(typeof (INameScopeProvider), (object) new NameScopeProvider()
        {
          NameScope = (INameScope) nameScope
        });
        Type type66 = typeof (IXamlTypeResolver);
        XmlNamespaceResolver namespaceResolver33 = new XmlNamespaceResolver();
        namespaceResolver33.Add("", "http://xamarin.com/schemas/2014/forms");
        namespaceResolver33.Add("x", "http://schemas.microsoft.com/winfx/2009/xaml");
        namespaceResolver33.Add("forms", "clr-namespace:FFImageLoading.Forms;assembly=FFImageLoading.Forms");
        namespaceResolver33.Add("xlabs", "clr-namespace:XLabs.Forms.Controls;assembly=XLabs.Forms");
        XamlTypeResolver service66 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver33, typeof (WidgetHomePage).GetTypeInfo().Assembly);
        xamlServiceProvider33.Add(type66, (object) service66);
        xamlServiceProvider33.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(240, 100)));
        object obj33 = ((IExtendedTypeConverter) fontSizeConverter4).ConvertFromInvariantString("12", (IServiceProvider) xamlServiceProvider33);
        label22.SetValue(fontSizeProperty4, obj33);
        label18.SetValue(Label.TextColorProperty, (object) new Color(1.0, 1.0, 1.0, 1.0));
        label18.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.Center);
        stackLayout8.Children.Add((View) label18);
        bindable46.Children.Add((View) stackLayout8);
        bindable47.SetValue(ContentPage.ContentProperty, (object) bindable46);
      }
    }

    private void __InitComponentRuntime()
    {
      this.LoadFromXaml<WidgetHomePage>(typeof (WidgetHomePage));
      this.versionOutOfDate = NameScopeExtensions.FindByName<StackLayout>(this, "versionOutOfDate");
      this.scrollMain = NameScopeExtensions.FindByName<ScrollView>(this, "scrollMain");
      this.frameServerDown = NameScopeExtensions.FindByName<Frame>(this, "frameServerDown");
      this.lblServerDown = NameScopeExtensions.FindByName<Label>(this, "lblServerDown");
      this.lblRefresh = NameScopeExtensions.FindByName<ExtendedLabel>(this, "lblRefresh");
      this.gridWidgets = NameScopeExtensions.FindByName<Grid>(this, "gridWidgets");
      this.frmScheduleToday = NameScopeExtensions.FindByName<Frame>(this, "frmScheduleToday");
      this.stackScheduleHeader = NameScopeExtensions.FindByName<StackLayout>(this, "stackScheduleHeader");
      this.lblToday = NameScopeExtensions.FindByName<Label>(this, "lblToday");
      this.lblLastScheduleSync = NameScopeExtensions.FindByName<Label>(this, "lblLastScheduleSync");
      this.loadingTodayClass = NameScopeExtensions.FindByName<ActivityIndicator>(this, "loadingTodayClass");
      this.stackTodaySchedule = NameScopeExtensions.FindByName<StackLayout>(this, "stackTodaySchedule");
      this.frmNextPayment = NameScopeExtensions.FindByName<Frame>(this, "frmNextPayment");
      this.lblPaymentSync = NameScopeExtensions.FindByName<Label>(this, "lblPaymentSync");
      this.loadingPaymentSched = NameScopeExtensions.FindByName<ActivityIndicator>(this, "loadingPaymentSched");
      this.lblPaymentRemarks = NameScopeExtensions.FindByName<Label>(this, "lblPaymentRemarks");
      this.stackPaymentSchedule = NameScopeExtensions.FindByName<StackLayout>(this, "stackPaymentSchedule");
      this.lblNexyPaymentAmount = NameScopeExtensions.FindByName<Label>(this, "lblNexyPaymentAmount");
      this.lblPaymentDue = NameScopeExtensions.FindByName<Label>(this, "lblPaymentDue");
      this.frmLatestNews = NameScopeExtensions.FindByName<Frame>(this, "frmLatestNews");
      this.stackNews = NameScopeExtensions.FindByName<StackLayout>(this, "stackNews");
      this.lblNewsTitle = NameScopeExtensions.FindByName<Label>(this, "lblNewsTitle");
      this.imgNewsHeader = NameScopeExtensions.FindByName<CachedImage>(this, "imgNewsHeader");
      this.lblNewsContent = NameScopeExtensions.FindByName<Label>(this, "lblNewsContent");
      this.frmLatestGrades = NameScopeExtensions.FindByName<Frame>(this, "frmLatestGrades");
      this.lblViewAllGrades = NameScopeExtensions.FindByName<Label>(this, "lblViewAllGrades");
      this.lblGradeAsOf = NameScopeExtensions.FindByName<Label>(this, "lblGradeAsOf");
      this.loadingGrade = NameScopeExtensions.FindByName<ActivityIndicator>(this, "loadingGrade");
      this.lblGradeRemarks = NameScopeExtensions.FindByName<Label>(this, "lblGradeRemarks");
      this.stackLatestGrade = NameScopeExtensions.FindByName<StackLayout>(this, "stackLatestGrade");
      this.lblProfessor = NameScopeExtensions.FindByName<Label>(this, "lblProfessor");
      this.lblSubjectInfo = NameScopeExtensions.FindByName<Label>(this, "lblSubjectInfo");
      this.lblGradePeriod = NameScopeExtensions.FindByName<Label>(this, "lblGradePeriod");
      this.lblLatestGrade = NameScopeExtensions.FindByName<Label>(this, "lblLatestGrade");
      this.stackGradesVisibility = NameScopeExtensions.FindByName<StackLayout>(this, "stackGradesVisibility");
      this.lblMessage = NameScopeExtensions.FindByName<Label>(this, "lblMessage");
      this.stackStatus = NameScopeExtensions.FindByName<StackLayout>(this, "stackStatus");
      this.lblStatus = NameScopeExtensions.FindByName<Label>(this, "lblStatus");
    }
  }
}
