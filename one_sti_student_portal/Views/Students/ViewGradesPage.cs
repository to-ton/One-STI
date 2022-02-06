// Decompiled with JetBrains decompiler
// Type: one_sti_student_portal.Views.Students.ViewGradesPage
// Assembly: one_sti_student_portal, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 39E34984-485E-45CE-9895-F7524E3024D6
// Assembly location: \\wsl.localhost\kali-linux\root\One STI Student Portal_1.3.8_apkcombo.com (1)\unknown\assemblies\one_sti_student_portal.dll

using one_sti_student_portal.Data;
using one_sti_student_portal.Helpers;
using one_sti_student_portal.Models;
using one_sti_student_portal.Services;
using Refractored.XamForms.PullToRefresh;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.Xaml.Internals;

namespace one_sti_student_portal.Views.Students
{
  [XamlCompilation(XamlCompilationOptions.Compile)]
  [XamlFilePath("Views\\Students\\ViewGradesPage.xaml")]
  public class ViewGradesPage : ContentPage
  {
    private bool _isBusy;
    private bool _isConnected;
    private bool _isActive;
    private bool _refreshContent;
    private string _currentSemester;
    private string serverStatus;
    private List<string> _listSemester;
    private StudentData _studentData;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private StackLayout stackSYTerm;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private Label lblSYTerm;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private Image imgPullDownTerms;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private Picker pckrSchoolTerm;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private PullToRefreshLayout refreshGrades;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private StackLayout stackMain;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private Label lblAsOf;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private Frame frmGWA;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private Label lblCurGWA;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private Label lblCumGWA;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private StackLayout stackGrades;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private Label lblLastSync;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private Frame frameServerDown;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private Label lblServerDown;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private StackLayout stackStatus;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private Label lblStatus;

    public ViewGradesPage(bool refreshContent)
    {
      this.InitializeComponent();
      this._refreshContent = refreshContent;
      this._studentData = new StudentData();
      this.LoadSemester();
      this.LoadGrades();
      this._isConnected = ConnectionHelper.IsConnected();
      Connectivity.ConnectivityChanged += (EventHandler<ConnectivityChangedEventArgs>) ((sender, args) =>
      {
        this._isConnected = ConnectionHelper.IsConnected();
        this.CheckStatus();
      });
      this.refreshGrades.RefreshCommand = (ICommand) new Command((Action) (() => this.RefreshContent()));
      switch (Device.RuntimePlatform)
      {
        case "Android":
          this.ToolbarItems.Add(new ToolbarItem("", "ic_action_info", (Action) (() => this.DisplayAlert("My Grades", "All the grades indicated on this section are encoded only by the corresponding teacher or instructor of every subject." + Environment.NewLine + Environment.NewLine + "For grade-related concerns, you may discuss it with your teacher.", "OK"))));
          break;
        default:
          throw new ArgumentOutOfRangeException();
      }
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

    private void RefreshContent()
    {
      this._refreshContent = false;
      Device.BeginInvokeOnMainThread((Action) (() => this.refreshGrades.IsRefreshing = true));
      Task.Run((Func<Task>) (async () =>
      {
        ViewGradesPage viewGradesPage = this;
        string str1 = await viewGradesPage.ServerStatusAsync();
        viewGradesPage.serverStatus = str1;
        if (!(viewGradesPage.serverStatus == "true") || !viewGradesPage._isConnected || viewGradesPage._isBusy)
          return;
        viewGradesPage._isBusy = true;
        StudentService studentService = new StudentService();
        StudentInformation studentInfo = viewGradesPage._studentData.GetStudentInformation().Result.FirstOrDefault<StudentInformation>();
        await viewGradesPage._studentData.DeleteGrades(viewGradesPage._listSemester[viewGradesPage.pckrSchoolTerm.SelectedIndex]);
        await viewGradesPage._studentData.DownloadSemesterGrades(studentInfo.PSCSId, viewGradesPage._listSemester[viewGradesPage.pckrSchoolTerm.SelectedIndex]);
        await viewGradesPage._studentData.DeleteGWA(viewGradesPage._listSemester[viewGradesPage.pckrSchoolTerm.SelectedIndex]);
        await viewGradesPage._studentData.DownloadSemesterGWA(studentInfo.PSCSId, viewGradesPage._listSemester[viewGradesPage.pckrSchoolTerm.SelectedIndex]);
        await viewGradesPage._studentData.DeleteSubjects(viewGradesPage._listSemester[viewGradesPage.pckrSchoolTerm.SelectedIndex]);
        await viewGradesPage._studentData.DownloadSubjectsPerSemester(studentInfo.PSCSId, viewGradesPage._listSemester[viewGradesPage.pckrSchoolTerm.SelectedIndex]);
        string class_number = "";
        string acadCareer = "";
        foreach (StudentSubjects studentSubjects in viewGradesPage._studentData.GetSubjectInfo(viewGradesPage._listSemester[viewGradesPage.pckrSchoolTerm.SelectedIndex]).Result)
          class_number = studentSubjects.ClassNumber;
        foreach (StudentGrades studentGrades in viewGradesPage._studentData.GetSubjectGradeDetail(viewGradesPage._listSemester[viewGradesPage.pckrSchoolTerm.SelectedIndex], class_number).Result)
          acadCareer = studentGrades.CourseCareer;
        await viewGradesPage._studentData.DeleteDueDetails();
        await viewGradesPage._studentData.DownloadDueDetails(studentInfo.PSCSId, viewGradesPage._listSemester[viewGradesPage.pckrSchoolTerm.SelectedIndex], acadCareer);
        string str2 = await new StudentService().SendLog(new AppLogModel()
        {
          PSCSId = studentInfo.PSCSId,
          IPAddress = "null",
          Medium = "Mobile",
          AppVersion = Constants.VersionName,
          NumOfRequests = 4,
          DateAccessed = DateTime.Now.ToString("MM/dd/yyyy hh:mm tt"),
          ViewName = viewGradesPage.GetType().Name + " RefreshContent()",
          Campus = studentInfo.Campus
        });
        studentInfo = (StudentInformation) null;
        acadCareer = (string) null;
      })).ContinueWith((Action<Task>) (result => Device.BeginInvokeOnMainThread((Action) (() =>
      {
        if (this.serverStatus == "true")
        {
          this.stackMain.IsVisible = true;
          this.frameServerDown.IsVisible = false;
          this.LoadGrades();
          this.refreshGrades.IsRefreshing = false;
          this._isBusy = false;
          if (ConnectionHelper.IsConnected())
            return;
          Acr.UserDialogs.UserDialogs.Instance.Toast("Could not refresh. Check your network connection.");
        }
        else if (this.serverStatus == "down")
        {
          this.refreshGrades.IsRefreshing = false;
          this._isBusy = false;
          this.stackMain.IsVisible = false;
          this.frameServerDown.IsVisible = true;
        }
        else if (this.serverStatus == "not connected")
        {
          this.refreshGrades.IsRefreshing = false;
          this._isBusy = false;
          this.stackMain.IsVisible = true;
          this.frameServerDown.IsVisible = false;
          Acr.UserDialogs.UserDialogs.Instance.Toast("Please check your network connection and try again.", new TimeSpan?(new TimeSpan(0, 0, 5)));
        }
        else
        {
          this.refreshGrades.IsRefreshing = false;
          this._isBusy = false;
          this.stackMain.IsVisible = true;
          this.frameServerDown.IsVisible = false;
          Acr.UserDialogs.UserDialogs.Instance.Toast("An error occured while connecting to the server", new TimeSpan?(new TimeSpan(0, 0, 5)));
        }
      }))));
    }

    protected override void OnAppearing()
    {
      base.OnAppearing();
      MessagingCenter.Send<MessageSender>(new MessageSender(), "MyGrades");
      this._isConnected = ConnectionHelper.IsConnected();
      this._isActive = true;
      if (this._isConnected)
        return;
      this.stackStatus.BackgroundColor = Color.FromHex("#2e3131");
      this.stackStatus.IsVisible = true;
      this.lblStatus.Text = "No connection";
    }

    protected override void OnDisappearing()
    {
      base.OnDisappearing();
      this._isActive = false;
    }

    private void LoadGWA()
    {
      foreach (StudentGWA studentGwa in this._studentData.GetGWA(this._listSemester[this.pckrSchoolTerm.SelectedIndex]).Result)
      {
        Decimal num1 = Convert.ToDecimal(studentGwa.CurGPA);
        Decimal num2 = Convert.ToDecimal(studentGwa.CumGPA);
        if (this.ShowFinalsGrade())
        {
          this.lblCurGWA.Text = string.Format("{0:.##}", new object[1]
          {
            (object) num1
          });
          this.lblCurGWA.TextColor = Color.FromHex("#404040");
          this.lblCurGWA.FontFamily = "Roboto-Medium.ttf#Roboto";
          this.lblCurGWA.Margin = new Thickness(0.0, 0.0, 0.0, 0.0);
          this.lblCumGWA.Text = string.Format("{0:.##}", new object[1]
          {
            (object) num2
          });
          this.lblCumGWA.TextColor = Color.FromHex("#404040");
          this.lblCumGWA.FontFamily = "Roboto-Medium.ttf#Roboto";
          this.lblCumGWA.Margin = new Thickness(0.0, 0.0, 0.0, 0.0);
        }
        else
        {
          this.lblCurGWA.Text = "\uF070";
          this.lblCurGWA.TextColor = Color.FromHex("#dc3545");
          this.lblCurGWA.FontFamily = "FontAwesome5-Regular.otf#Regular";
          this.lblCurGWA.Margin = new Thickness(0.0, 5.0, 0.0, 0.0);
          this.lblCumGWA.Text = "\uF070";
          this.lblCumGWA.TextColor = Color.FromHex("#dc3545");
          this.lblCumGWA.FontFamily = "FontAwesome5-Regular.otf#Regular";
          this.lblCumGWA.Margin = new Thickness(0.0, 5.0, 0.0, 0.0);
        }
      }
    }

    public void LoadGrades()
    {
      this._currentSemester = this._studentData.GetStudentInformation().Result.FirstOrDefault<StudentInformation>().SchoolTerm;
      List<StudentSubjects> result1 = this._studentData.GetSubjectInfo(this._listSemester[this.pckrSchoolTerm.SelectedIndex]).Result;
      List<GradeListing> source = new List<GradeListing>();
      foreach (StudentSubjects studentSubjects in result1)
      {
        List<StudentGrades> result2 = this._studentData.GetSubjectGradeDetail(this._listSemester[this.pckrSchoolTerm.SelectedIndex], studentSubjects.ClassNumber).Result;
        DateTime dateTime = result2.Count == 0 ? DateTime.MinValue : result2.OrderByDescending<StudentGrades, DateTime>((Func<StudentGrades, DateTime>) (o => o.SubmittedOn)).ToList<StudentGrades>().FirstOrDefault<StudentGrades>().SubmittedOn;
        source.Add(new GradeListing()
        {
          ClassNumber = studentSubjects.ClassNumber,
          CourseCareer = studentSubjects.CourseCareer,
          DatePosted = studentSubjects.DatePosted,
          FinalGrade = studentSubjects.FinalGrade,
          Professor = studentSubjects.Professor,
          SubjectDesc = studentSubjects.SubjectDesc,
          SubmittedOn = !(studentSubjects.FinalGrade != "-") || !(studentSubjects.DatePosted != DateTime.MinValue) ? dateTime : studentSubjects.DatePosted
        });
      }
      List<GradeListing> list = source.OrderByDescending<GradeListing, DateTime>((Func<GradeListing, DateTime>) (o => o.SubmittedOn)).ToList<GradeListing>();
      this.stackGrades.Children.Clear();
      Frame frame1 = new Frame();
      foreach (GradeListing gradeListing in list)
      {
        if (gradeListing.CourseCareer != "SHS")
        {
          if (result1.Any<StudentSubjects>((Func<StudentSubjects, bool>) (o => o.FinalGrade != "-")))
          {
            this.frmGWA.IsVisible = true;
            this.LoadGWA();
          }
          else
            this.frmGWA.IsVisible = false;
        }
        StackLayout stackLayout1 = new StackLayout();
        stackLayout1.Padding = new Thickness(5.0);
        stackLayout1.Spacing = 0.0;
        StackLayout stackLayout2 = stackLayout1;
        StackLayout stackLayout3 = new StackLayout()
        {
          Orientation = StackOrientation.Horizontal
        };
        StackLayout stackLayout4 = new StackLayout();
        stackLayout4.Orientation = StackOrientation.Horizontal;
        stackLayout4.Spacing = 0.0;
        stackLayout4.Margin = new Thickness(0.0, 0.0, 5.0, 0.0);
        StackLayout stackLayout5 = stackLayout4;
        new StackLayout() { Spacing = 0.0 }.HorizontalOptions = LayoutOptions.FillAndExpand;
        new StackLayout() { Spacing = 0.0 }.HorizontalOptions = LayoutOptions.EndAndExpand;
        StackLayout stackLayout6 = new StackLayout();
        stackLayout6.Spacing = 0.0;
        stackLayout6.HorizontalOptions = LayoutOptions.FillAndExpand;
        stackLayout6.BackgroundColor = Color.FromHex("#ffebee");
        stackLayout6.Margin = new Thickness(0.0, 5.0, 0.0, 5.0);
        stackLayout6.Padding = new Thickness(5.0);
        StackLayout stackLayout7 = stackLayout6;
        Label label1 = new Label();
        label1.Text = gradeListing.SubjectDesc;
        label1.Style = (Style) Application.Current.Resources["normalHeader"];
        label1.TextColor = Color.FromHex("#404040");
        label1.WidthRequest = gradeListing.FinalGrade != "-" ? 250.0 : 350.0;
        label1.HorizontalOptions = LayoutOptions.Start;
        label1.VerticalOptions = LayoutOptions.Center;
        label1.Margin = new Thickness(0.0, 0.0, 0.0, 5.0);
        Label label2 = label1;
        stackLayout3.Children.Add((View) label2);
        if (gradeListing.FinalGrade != "-")
        {
          Label label3 = new Label();
          label3.Style = (Style) Application.Current.Resources["mediumHeader"];
          label3.TextColor = Color.FromHex("#404040");
          label3.Margin = new Thickness(0.0, 0.0, 10.0, 0.0);
          label3.VerticalOptions = LayoutOptions.Center;
          label3.HorizontalOptions = LayoutOptions.EndAndExpand;
          label3.LineBreakMode = LineBreakMode.NoWrap;
          Label label4 = label3;
          if (gradeListing.CourseCareer == "SHS" && this._listSemester[this.pckrSchoolTerm.SelectedIndex].EndsWith("01"))
          {
            if (this.ShowQ2Grade())
            {
              label4.Text = gradeListing.FinalGrade;
              stackLayout7.IsVisible = false;
            }
            else
            {
              label4.Text = "\uF070";
              label4.TextColor = Color.FromHex("#dc3545");
              label4.FontFamily = "FontAwesome5-Regular.otf#Regular";
              stackLayout7.IsVisible = true;
            }
          }
          else if (gradeListing.CourseCareer == "SHS" && this._listSemester[this.pckrSchoolTerm.SelectedIndex].EndsWith("02"))
          {
            if (this.ShowQ4Grade())
            {
              label4.Text = gradeListing.FinalGrade;
              stackLayout7.IsVisible = false;
            }
            else
            {
              label4.Text = "\uF070";
              label4.TextColor = Color.FromHex("#dc3545");
              label4.FontFamily = "FontAwesome5-Regular.otf#Regular";
              stackLayout7.IsVisible = true;
            }
          }
          else if (gradeListing.CourseCareer == "SHS" && this._listSemester[this.pckrSchoolTerm.SelectedIndex].EndsWith("03"))
          {
            if (this.ShowQ2SummerGrade())
            {
              label4.Text = gradeListing.FinalGrade;
              stackLayout7.IsVisible = false;
            }
            else
            {
              label4.Text = "\uF070";
              label4.TextColor = Color.FromHex("#dc3545");
              label4.FontFamily = "FontAwesome5-Regular.otf#Regular";
              stackLayout7.IsVisible = true;
            }
          }
          else if (this.ShowFinalsGrade())
          {
            label4.Text = gradeListing.FinalGrade;
            stackLayout7.IsVisible = false;
          }
          else
          {
            label4.Text = "\uF070";
            label4.TextColor = Color.FromHex("#dc3545");
            label4.FontFamily = "FontAwesome5-Regular.otf#Regular";
            stackLayout7.IsVisible = true;
          }
          stackLayout3.Children.Add((View) label4);
        }
        BoxView boxView1 = new BoxView();
        boxView1.Color = Color.FromHex("#E7C01D");
        boxView1.HeightRequest = 1.5;
        boxView1.Margin = new Thickness(0.0, 5.0, 0.0, 5.0);
        boxView1.HorizontalOptions = LayoutOptions.FillAndExpand;
        BoxView boxView2 = boxView1;
        stackLayout2.Children.Add((View) stackLayout3);
        stackLayout2.Children.Add((View) boxView2);
        List<StudentGrades> result3 = this._studentData.GetSubjectGradeDetail(this._listSemester[this.pckrSchoolTerm.SelectedIndex], gradeListing.ClassNumber).Result;
        bool flag = false;
        DateTime dateTime = DateTime.MinValue;
        foreach (StudentGrades studentGrades in result3)
        {
          this.lblLastSync.IsVisible = true;
          this.lblLastSync.Text = "LAST SYNC ON " + studentGrades.SyncedOn.ToString("dd MMM, yyyy hh:mm tt").ToUpper();
          StackLayout stackLayout8 = new StackLayout()
          {
            Spacing = 0.0,
            Orientation = StackOrientation.Horizontal
          };
          Label label5 = new Label();
          label5.Text = studentGrades.GradingPeriod;
          label5.Style = (Style) Application.Current.Resources["smallLabel"];
          label5.FontFamily = "Roboto-Regular.ttf#Roboto";
          label5.HorizontalOptions = LayoutOptions.FillAndExpand;
          label5.Margin = new Thickness(10.0, 3.0, 0.0, 0.0);
          Label label6 = label5;
          Label label7 = new Label();
          label7.Style = (Style) Application.Current.Resources["smallHeader"];
          label7.HorizontalOptions = LayoutOptions.End;
          label7.Margin = new Thickness(0.0, 3.0, 10.0, 0.0);
          Label label8 = label7;
          if (studentGrades.PeriodGrade != "-")
          {
            flag = true;
            stackLayout8.Children.Add((View) label6);
            stackLayout8.Children.Add((View) label8);
            stackLayout2.Children.Add((View) stackLayout8);
            if (studentGrades.CourseCareer == "SHS" && this._listSemester[this.pckrSchoolTerm.SelectedIndex].EndsWith("01"))
            {
              switch (studentGrades.SequenceNumber)
              {
                case "1":
                  if (this.ShowQ1Grade())
                  {
                    label8.Text = studentGrades.PeriodGrade;
                    stackLayout7.IsVisible = false;
                    break;
                  }
                  label8.Text = "\uF070";
                  label8.TextColor = Color.FromHex("#dc3545");
                  label8.FontFamily = "FontAwesome5-Regular.otf#Regular";
                  stackLayout7.IsVisible = true;
                  break;
                case "2":
                  if (this.ShowQ2Grade())
                  {
                    label8.Text = studentGrades.PeriodGrade;
                    stackLayout7.IsVisible = false;
                    break;
                  }
                  label8.Text = "\uF070";
                  label8.TextColor = Color.FromHex("#dc3545");
                  label8.FontFamily = "FontAwesome5-Regular.otf#Regular";
                  stackLayout7.IsVisible = true;
                  break;
                default:
                  if (this.ShowQ2Grade())
                  {
                    label8.Text = studentGrades.PeriodGrade;
                    stackLayout7.IsVisible = false;
                    break;
                  }
                  label8.Text = "\uF070";
                  label8.TextColor = Color.FromHex("#dc3545");
                  label8.FontFamily = "FontAwesome5-Regular.otf#Regular";
                  stackLayout7.IsVisible = true;
                  break;
              }
            }
            else if (studentGrades.CourseCareer == "SHS" && this._listSemester[this.pckrSchoolTerm.SelectedIndex].EndsWith("02"))
            {
              switch (studentGrades.SequenceNumber)
              {
                case "1":
                  if (this.ShowQ3Grade())
                  {
                    label8.Text = studentGrades.PeriodGrade;
                    stackLayout7.IsVisible = false;
                    break;
                  }
                  label8.Text = "\uF070";
                  label8.TextColor = Color.FromHex("#dc3545");
                  label8.FontFamily = "FontAwesome5-Regular.otf#Regular";
                  stackLayout7.IsVisible = true;
                  break;
                case "2":
                  if (this.ShowQ4Grade())
                  {
                    label8.Text = studentGrades.PeriodGrade;
                    stackLayout7.IsVisible = false;
                    break;
                  }
                  label8.Text = "\uF070";
                  label8.TextColor = Color.FromHex("#dc3545");
                  label8.FontFamily = "FontAwesome5-Regular.otf#Regular";
                  stackLayout7.IsVisible = true;
                  break;
                default:
                  if (this.ShowQ4Grade())
                  {
                    label8.Text = studentGrades.PeriodGrade;
                    stackLayout7.IsVisible = false;
                    break;
                  }
                  label8.Text = "\uF070";
                  label8.TextColor = Color.FromHex("#dc3545");
                  label8.FontFamily = "FontAwesome5-Regular.otf#Regular";
                  stackLayout7.IsVisible = true;
                  break;
              }
            }
            else if (studentGrades.CourseCareer == "SHS" && this._listSemester[this.pckrSchoolTerm.SelectedIndex].EndsWith("03"))
            {
              switch (studentGrades.SequenceNumber)
              {
                case "1":
                  if (this.ShowQ1SummerGrade())
                  {
                    label8.Text = studentGrades.PeriodGrade;
                    stackLayout7.IsVisible = false;
                    break;
                  }
                  label8.Text = "\uF070";
                  label8.TextColor = Color.FromHex("#dc3545");
                  label8.FontFamily = "FontAwesome5-Regular.otf#Regular";
                  stackLayout7.IsVisible = true;
                  break;
                case "2":
                  if (this.ShowQ2SummerGrade())
                  {
                    label8.Text = studentGrades.PeriodGrade;
                    stackLayout7.IsVisible = false;
                    break;
                  }
                  label8.Text = "\uF070";
                  label8.TextColor = Color.FromHex("#dc3545");
                  label8.FontFamily = "FontAwesome5-Regular.otf#Regular";
                  stackLayout7.IsVisible = true;
                  break;
                default:
                  if (this.ShowQ4Grade())
                  {
                    label8.Text = studentGrades.PeriodGrade;
                    stackLayout7.IsVisible = false;
                    break;
                  }
                  label8.Text = "\uF070";
                  label8.TextColor = Color.FromHex("#dc3545");
                  label8.FontFamily = "FontAwesome5-Regular.otf#Regular";
                  stackLayout7.IsVisible = true;
                  break;
              }
            }
            else
            {
              switch (studentGrades.SequenceNumber)
              {
                case "1":
                  if (this.ShowPrelimGrade())
                  {
                    label8.Text = studentGrades.PeriodGrade;
                    stackLayout7.IsVisible = false;
                    break;
                  }
                    label8.Text = studentGrades.PeriodGrade;
                    stackLayout7.IsVisible = false;
                    break;
                case "2":
                  if (this.ShowMidtermGrade())
                  {
                    label8.Text = studentGrades.PeriodGrade;
                    stackLayout7.IsVisible = false;
                    break;
                  }
                  label8.Text = "\uF070";
                  label8.TextColor = Color.FromHex("#dc3545");
                  label8.FontFamily = "FontAwesome5-Regular.otf#Regular";
                  stackLayout7.IsVisible = true;
                  break;
                case "3":
                  if (this.ShowPreFinGrade())
                  {
                    label8.Text = studentGrades.PeriodGrade;
                    stackLayout7.IsVisible = false;
                    break;
                  }
                  label8.Text = "\uF070";
                  label8.TextColor = Color.FromHex("#dc3545");
                  label8.FontFamily = "FontAwesome5-Regular.otf#Regular";
                  stackLayout7.IsVisible = true;
                  break;
                case "4":
                  if (this.ShowFinalsGrade())
                  {
                    label8.Text = studentGrades.PeriodGrade;
                    stackLayout7.IsVisible = false;
                    break;
                  }
                  label8.Text = "\uF070";
                  label8.TextColor = Color.FromHex("#dc3545");
                  label8.FontFamily = "FontAwesome5-Regular.otf#Regular";
                  stackLayout7.IsVisible = true;
                  break;
                default:
                  if (this.ShowFinalsGrade())
                  {
                    label8.Text = studentGrades.PeriodGrade;
                    stackLayout7.IsVisible = false;
                    break;
                  }
                  label8.Text = "\uF070";
                  label8.TextColor = Color.FromHex("#dc3545");
                  label8.FontFamily = "FontAwesome5-Regular.otf#Regular";
                  stackLayout7.IsVisible = true;
                  break;
              }
            }
          }
          dateTime = result3.OrderByDescending<StudentGrades, DateTime>((Func<StudentGrades, DateTime>) (o => o.SubmittedOn)).ToList<StudentGrades>().FirstOrDefault<StudentGrades>().SubmittedOn;
        }
        if (!flag)
        {
          Label label9 = new Label();
          label9.Text = "No grades available.";
          label9.Style = (Style) Application.Current.Resources["smallLabel"];
          label9.FontFamily = "Roboto-Regular.ttf#Roboto";
          label9.HorizontalOptions = LayoutOptions.FillAndExpand;
          label9.Margin = new Thickness(5.0, 3.0, 0.0, 0.0);
          Label label10 = label9;
          stackLayout2.Children.Add((View) label10);
          stackLayout7.IsVisible = false;
        }
        BoxView boxView3 = new BoxView();
        boxView3.Color = Color.FromHex("#e4e9ed");
        boxView3.HeightRequest = 1.5;
        boxView3.Margin = new Thickness(0.0, 10.0, 0.0, 5.0);
        boxView3.HorizontalOptions = LayoutOptions.FillAndExpand;
        BoxView boxView4 = boxView3;
        IList<View> children = stackLayout5.Children;
        Image image = new Image();
        image.Source = (ImageSource) "ic_person";
        image.HeightRequest = 25.0;
        image.Margin = new Thickness(0.0, 0.0, 5.0, 0.0);
        children.Add((View) image);
        Label label11 = new Label();
        label11.Text = string.IsNullOrWhiteSpace(gradeListing.Professor.ToUpper()) ? "TBA" : gradeListing.Professor.ToUpper();
        label11.Style = (Style) Application.Current.Resources["microLabel"];
        label11.FontSize = 11.0;
        label11.TextColor = Color.FromHex("#666666");
        label11.FontFamily = "Roboto-Medium.ttf#Roboto";
        label11.HorizontalOptions = LayoutOptions.StartAndExpand;
        label11.VerticalOptions = LayoutOptions.Center;
        label11.WidthRequest = dateTime == DateTime.MinValue ? 200.0 : 150.0;
        label11.Margin = new Thickness(0.0, 3.0, 0.0, 0.0);
        Label label12 = label11;
        dateTime = !(gradeListing.FinalGrade != "-") || !(gradeListing.DatePosted != DateTime.MinValue) ? dateTime : gradeListing.DatePosted;
        Label label13 = new Label();
        label13.Text = this._currentSemester == this._listSemester[this.pckrSchoolTerm.SelectedIndex] ? dateTime.ToString("dd MMM, yyyy hh:mm tt").ToUpper() : dateTime.ToString("dd MMM, yyyy").ToUpper();
        label13.Style = (Style) Application.Current.Resources["microLabel"];
        label13.TextColor = Color.FromHex("#666666");
        label13.FontFamily = "Roboto-Regular.ttf#Roboto";
        label13.HorizontalOptions = LayoutOptions.End;
        label13.HorizontalTextAlignment = TextAlignment.End;
        label13.VerticalOptions = LayoutOptions.Center;
        Label label14 = label13;
        stackLayout5.Children.Add((View) label12);
        Label label15 = new Label();
        label15.Text = "\uF070 Unable to view current grade. Please see the registrar.";
        label15.Style = (Style) Application.Current.Resources["microLabel"];
        label15.TextColor = Color.FromHex("#dc3545");
        label15.FontFamily = "FontAwesome5-Regular.otf#Regular";
        label15.FontSize = 12.0;
        label15.Margin = new Thickness(3.0, 5.0, 0.0, 5.0);
        label15.HorizontalOptions = LayoutOptions.StartAndExpand;
        label15.HorizontalTextAlignment = TextAlignment.Start;
        label15.VerticalOptions = LayoutOptions.Center;
        Label label16 = label15;
        stackLayout7.Children.Add((View) label16);
        if (!string.IsNullOrWhiteSpace(dateTime.ToString()) && dateTime != DateTime.MinValue)
          stackLayout5.Children.Add((View) label14);
        stackLayout2.Children.Add((View) boxView4);
        stackLayout2.Children.Add((View) stackLayout5);
        stackLayout2.Children.Add((View) stackLayout7);
        Frame frame2 = new Frame();
        frame2.Content = (View) stackLayout2;
        frame2.HasShadow = true;
        frame2.Padding = new Thickness(10.0, 10.0, 10.0, 5.0);
        frame2.Margin = new Thickness(0.0, 0.0, 0.0, 3.0);
        frame2.CornerRadius = 5f;
        this.stackGrades.Children.Add((View) frame2);
        if (gradeListing.CourseCareer != "SHS")
        {
          if (result1.Any<StudentSubjects>((Func<StudentSubjects, bool>) (o => o.FinalGrade != "-")))
          {
            this.frmGWA.IsVisible = true;
            this.LoadGWA();
          }
          else
            this.frmGWA.IsVisible = false;
        }
      }
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

    public void LoadSemester()
    {
      Task<List<StudentSemester>> semesters = this._studentData.GetSemesters();
      this._listSemester = new List<string>();
      foreach (StudentSemester studentSemester in semesters.Result)
      {
        this._listSemester.Add(studentSemester.Semester);
        this.pckrSchoolTerm.Items.Add(studentSemester.SemesterDesc);
      }
      if (this._listSemester.Count == 0)
        return;
      this.pckrSchoolTerm.SelectedIndex = 0;
      this.lblSYTerm.Text = this.pckrSchoolTerm.SelectedItem.ToString();
    }

    private void SYTerms_Tapped(object sender, EventArgs e) => this.pckrSchoolTerm.Focus();

    private void pckrSchoolTerm_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (!this._isActive || this.pckrSchoolTerm.SelectedIndex == -1)
        return;
      this.lblSYTerm.Text = this.pckrSchoolTerm.SelectedItem.ToString();
      this.lblLastSync.IsVisible = false;
      this.RefreshContent();
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

    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private void InitializeComponent()
    {
      if (ResourceLoader.ResourceProvider != null && ResourceLoader.ResourceProvider(typeof (ViewGradesPage).GetTypeInfo().Assembly.GetName(), "Views/Students/ViewGradesPage.xaml") != null)
        this.__InitComponentRuntime();
      else if (Xamarin.Forms.Xaml.Internals.XamlLoader.XamlFileProvider != null && Xamarin.Forms.Xaml.Internals.XamlLoader.XamlFileProvider(this.GetType()) != null)
      {
        this.__InitComponentRuntime();
      }
      else
      {
        TapGestureRecognizer bindable1 = new TapGestureRecognizer();
        Image bindable2 = new Image();
        StaticResourceExtension resourceExtension1 = new StaticResourceExtension();
        Label label1 = new Label();
        Image image = new Image();
        StackLayout bindable3 = new StackLayout();
        StackLayout stackLayout1 = new StackLayout();
        Frame bindable4 = new Frame();
        Picker picker = new Picker();
        StaticResourceExtension resourceExtension2 = new StaticResourceExtension();
        Label label2 = new Label();
        Image bindable5 = new Image();
        StaticResourceExtension resourceExtension3 = new StaticResourceExtension();
        Label bindable6 = new Label();
        StaticResourceExtension resourceExtension4 = new StaticResourceExtension();
        Label label3 = new Label();
        StackLayout bindable7 = new StackLayout();
        StaticResourceExtension resourceExtension5 = new StaticResourceExtension();
        Label bindable8 = new Label();
        StaticResourceExtension resourceExtension6 = new StaticResourceExtension();
        Label label4 = new Label();
        StackLayout bindable9 = new StackLayout();
        StackLayout bindable10 = new StackLayout();
        StackLayout bindable11 = new StackLayout();
        Frame frame1 = new Frame();
        StackLayout stackLayout2 = new StackLayout();
        StaticResourceExtension resourceExtension7 = new StaticResourceExtension();
        Label label5 = new Label();
        StackLayout stackLayout3 = new StackLayout();
        StaticResourceExtension resourceExtension8 = new StaticResourceExtension();
        Label label6 = new Label();
        StackLayout bindable12 = new StackLayout();
        Frame frame2 = new Frame();
        StackLayout bindable13 = new StackLayout();
        ScrollView bindable14 = new ScrollView();
        PullToRefreshLayout pullToRefreshLayout = new PullToRefreshLayout();
        StackLayout bindable15 = new StackLayout();
        StaticResourceExtension resourceExtension9 = new StaticResourceExtension();
        Label label7 = new Label();
        StackLayout stackLayout4 = new StackLayout();
        StackLayout bindable16 = new StackLayout();
        ViewGradesPage bindable17 = this;
        NameScope nameScope = new NameScope();
        NameScope.SetNameScope((BindableObject) bindable17, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable16, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable15, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable4, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable1, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) stackLayout1, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("stackSYTerm", (object) stackLayout1);
        if (stackLayout1.StyleId == null)
          stackLayout1.StyleId = "stackSYTerm";
        NameScope.SetNameScope((BindableObject) bindable3, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable2, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) label1, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("lblSYTerm", (object) label1);
        if (label1.StyleId == null)
          label1.StyleId = "lblSYTerm";
        NameScope.SetNameScope((BindableObject) image, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("imgPullDownTerms", (object) image);
        if (image.StyleId == null)
          image.StyleId = "imgPullDownTerms";
        NameScope.SetNameScope((BindableObject) picker, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("pckrSchoolTerm", (object) picker);
        if (picker.StyleId == null)
          picker.StyleId = "pckrSchoolTerm";
        NameScope.SetNameScope((BindableObject) pullToRefreshLayout, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("refreshGrades", (object) pullToRefreshLayout);
        if (pullToRefreshLayout.StyleId == null)
          pullToRefreshLayout.StyleId = "refreshGrades";
        NameScope.SetNameScope((BindableObject) bindable14, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable13, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) stackLayout3, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("stackMain", (object) stackLayout3);
        if (stackLayout3.StyleId == null)
          stackLayout3.StyleId = "stackMain";
        NameScope.SetNameScope((BindableObject) label2, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("lblAsOf", (object) label2);
        if (label2.StyleId == null)
          label2.StyleId = "lblAsOf";
        NameScope.SetNameScope((BindableObject) frame1, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("frmGWA", (object) frame1);
        if (frame1.StyleId == null)
          frame1.StyleId = "frmGWA";
        NameScope.SetNameScope((BindableObject) bindable11, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable5, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable10, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable7, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable6, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) label3, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("lblCurGWA", (object) label3);
        if (label3.StyleId == null)
          label3.StyleId = "lblCurGWA";
        NameScope.SetNameScope((BindableObject) bindable9, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable8, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) label4, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("lblCumGWA", (object) label4);
        if (label4.StyleId == null)
          label4.StyleId = "lblCumGWA";
        NameScope.SetNameScope((BindableObject) stackLayout2, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("stackGrades", (object) stackLayout2);
        if (stackLayout2.StyleId == null)
          stackLayout2.StyleId = "stackGrades";
        NameScope.SetNameScope((BindableObject) label5, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("lblLastSync", (object) label5);
        if (label5.StyleId == null)
          label5.StyleId = "lblLastSync";
        NameScope.SetNameScope((BindableObject) frame2, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("frameServerDown", (object) frame2);
        if (frame2.StyleId == null)
          frame2.StyleId = "frameServerDown";
        NameScope.SetNameScope((BindableObject) bindable12, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) label6, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("lblServerDown", (object) label6);
        if (label6.StyleId == null)
          label6.StyleId = "lblServerDown";
        NameScope.SetNameScope((BindableObject) stackLayout4, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("stackStatus", (object) stackLayout4);
        if (stackLayout4.StyleId == null)
          stackLayout4.StyleId = "stackStatus";
        NameScope.SetNameScope((BindableObject) label7, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("lblStatus", (object) label7);
        if (label7.StyleId == null)
          label7.StyleId = "lblStatus";
        this.stackSYTerm = stackLayout1;
        this.lblSYTerm = label1;
        this.imgPullDownTerms = image;
        this.pckrSchoolTerm = picker;
        this.refreshGrades = pullToRefreshLayout;
        this.stackMain = stackLayout3;
        this.lblAsOf = label2;
        this.frmGWA = frame1;
        this.lblCurGWA = label3;
        this.lblCumGWA = label4;
        this.stackGrades = stackLayout2;
        this.lblLastSync = label5;
        this.frameServerDown = frame2;
        this.lblServerDown = label6;
        this.stackStatus = stackLayout4;
        this.lblStatus = label7;
        bindable17.SetValue(Page.IconProperty, new FileImageSourceConverter().ConvertFromInvariantString("ic_action_star"));
        bindable15.SetValue(View.MarginProperty, (object) new Thickness(5.0));
        bindable15.SetValue(View.VerticalOptionsProperty, (object) LayoutOptions.FillAndExpand);
        bindable4.SetValue(Frame.HasShadowProperty, (object) true);
        bindable4.SetValue(Layout.PaddingProperty, (object) new Thickness(0.0, 5.0, 0.0, 5.0));
        bindable4.SetValue(View.MarginProperty, (object) new Thickness(10.0, 10.0, 10.0, 0.0));
        bindable4.SetValue(Frame.CornerRadiusProperty, (object) 15f);
        bindable1.Tapped += new EventHandler(bindable17.SYTerms_Tapped);
        bindable4.GestureRecognizers.Add((IGestureRecognizer) bindable1);
        stackLayout1.SetValue(StackLayout.OrientationProperty, (object) StackOrientation.Vertical);
        stackLayout1.SetValue(StackLayout.SpacingProperty, (object) 0.0);
        stackLayout1.SetValue(View.MarginProperty, (object) new Thickness(20.0, 0.0, 20.0, 0.0));
        stackLayout1.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.CenterAndExpand);
        bindable3.SetValue(StackLayout.OrientationProperty, (object) StackOrientation.Horizontal);
        bindable3.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.FillAndExpand);
        bindable2.SetValue(Image.SourceProperty, new ImageSourceConverter().ConvertFromInvariantString("ic_calendar_today"));
        bindable3.Children.Add((View) bindable2);
        label1.SetValue(Label.TextProperty, (object) "Loading School Year/Term...");
        resourceExtension1.Key = "smallHeader";
        StaticResourceExtension resourceExtension10 = resourceExtension1;
        XamlServiceProvider xamlServiceProvider1 = new XamlServiceProvider();
        Type type1 = typeof (IProvideValueTarget);
        object[] objectAndParents1 = new object[0 + 7];
        objectAndParents1[0] = (object) label1;
        objectAndParents1[1] = (object) bindable3;
        objectAndParents1[2] = (object) stackLayout1;
        objectAndParents1[3] = (object) bindable4;
        objectAndParents1[4] = (object) bindable15;
        objectAndParents1[5] = (object) bindable16;
        objectAndParents1[6] = (object) bindable17;
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
        namespaceResolver1.Add("controls", "clr-namespace:Refractored.XamForms.PullToRefresh;assembly=Refractored.XamForms.PullToRefresh");
        XamlTypeResolver service2 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver1, typeof (ViewGradesPage).GetTypeInfo().Assembly);
        xamlServiceProvider1.Add(type2, (object) service2);
        xamlServiceProvider1.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(23, 90)));
        object obj1 = resourceExtension10.ProvideValue((IServiceProvider) xamlServiceProvider1);
        label1.Style = (Style) obj1;
        label1.SetValue(View.VerticalOptionsProperty, (object) LayoutOptions.Center);
        bindable3.Children.Add((View) label1);
        image.SetValue(Image.SourceProperty, new ImageSourceConverter().ConvertFromInvariantString("ic_arrow_drop_down"));
        bindable3.Children.Add((View) image);
        stackLayout1.Children.Add((View) bindable3);
        bindable4.SetValue(ContentView.ContentProperty, (object) stackLayout1);
        bindable15.Children.Add((View) bindable4);
        picker.SetValue(Picker.TitleProperty, (object) "School Year/Term");
        picker.SetValue(VisualElement.IsVisibleProperty, new VisualElement.VisibilityConverter().ConvertFromInvariantString("False"));
        picker.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.FillAndExpand);
        picker.SelectedIndexChanged += new EventHandler(bindable17.pckrSchoolTerm_SelectedIndexChanged);
        bindable15.Children.Add((View) picker);
        pullToRefreshLayout.SetValue(PullToRefreshLayout.IsPullToRefreshEnabledProperty, (object) true);
        bindable14.SetValue(View.VerticalOptionsProperty, (object) LayoutOptions.FillAndExpand);
        label2.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.Center);
        label2.SetValue(View.MarginProperty, (object) new Thickness(0.0, 10.0, 0.0, 0.0));
        label2.SetValue(VisualElement.IsVisibleProperty, new VisualElement.VisibilityConverter().ConvertFromInvariantString("False"));
        resourceExtension2.Key = "microLabel";
        StaticResourceExtension resourceExtension11 = resourceExtension2;
        XamlServiceProvider xamlServiceProvider2 = new XamlServiceProvider();
        Type type3 = typeof (IProvideValueTarget);
        object[] objectAndParents2 = new object[0 + 8];
        objectAndParents2[0] = (object) label2;
        objectAndParents2[1] = (object) stackLayout3;
        objectAndParents2[2] = (object) bindable13;
        objectAndParents2[3] = (object) bindable14;
        objectAndParents2[4] = (object) pullToRefreshLayout;
        objectAndParents2[5] = (object) bindable15;
        objectAndParents2[6] = (object) bindable16;
        objectAndParents2[7] = (object) bindable17;
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
        namespaceResolver2.Add("controls", "clr-namespace:Refractored.XamForms.PullToRefresh;assembly=Refractored.XamForms.PullToRefresh");
        XamlTypeResolver service4 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver2, typeof (ViewGradesPage).GetTypeInfo().Assembly);
        xamlServiceProvider2.Add(type4, (object) service4);
        xamlServiceProvider2.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(44, 120)));
        object obj2 = resourceExtension11.ProvideValue((IServiceProvider) xamlServiceProvider2);
        label2.Style = (Style) obj2;
        label2.SetValue(Label.FontFamilyProperty, (object) "Roboto-Regular.ttf#Roboto");
        stackLayout3.Children.Add((View) label2);
        frame1.SetValue(View.MarginProperty, (object) new Thickness(10.0, 10.0, 10.0, 0.0));
        frame1.SetValue(Layout.PaddingProperty, (object) new Thickness(10.0));
        frame1.SetValue(VisualElement.IsVisibleProperty, new VisualElement.VisibilityConverter().ConvertFromInvariantString("False"));
        bindable11.SetValue(StackLayout.OrientationProperty, (object) StackOrientation.Horizontal);
        bindable5.SetValue(View.MarginProperty, (object) new Thickness(5.0, 0.0, 0.0, 0.0));
        bindable5.SetValue(Image.SourceProperty, new ImageSourceConverter().ConvertFromInvariantString("ic_progress"));
        bindable5.SetValue(VisualElement.HeightRequestProperty, (object) 60.0);
        bindable11.Children.Add((View) bindable5);
        bindable10.SetValue(View.MarginProperty, (object) new Thickness(5.0, 0.0, 0.0, 0.0));
        bindable10.SetValue(View.VerticalOptionsProperty, (object) LayoutOptions.Center);
        bindable10.SetValue(StackLayout.SpacingProperty, (object) 0.0);
        bindable7.SetValue(StackLayout.SpacingProperty, (object) 0.0);
        bindable7.SetValue(StackLayout.OrientationProperty, (object) StackOrientation.Horizontal);
        bindable6.SetValue(Label.TextProperty, (object) "GWA: ");
        resourceExtension3.Key = "normalLabel";
        StaticResourceExtension resourceExtension12 = resourceExtension3;
        XamlServiceProvider xamlServiceProvider3 = new XamlServiceProvider();
        Type type5 = typeof (IProvideValueTarget);
        object[] objectAndParents3 = new object[0 + 12];
        objectAndParents3[0] = (object) bindable6;
        objectAndParents3[1] = (object) bindable7;
        objectAndParents3[2] = (object) bindable10;
        objectAndParents3[3] = (object) bindable11;
        objectAndParents3[4] = (object) frame1;
        objectAndParents3[5] = (object) stackLayout3;
        objectAndParents3[6] = (object) bindable13;
        objectAndParents3[7] = (object) bindable14;
        objectAndParents3[8] = (object) pullToRefreshLayout;
        objectAndParents3[9] = (object) bindable15;
        objectAndParents3[10] = (object) bindable16;
        objectAndParents3[11] = (object) bindable17;
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
        namespaceResolver3.Add("controls", "clr-namespace:Refractored.XamForms.PullToRefresh;assembly=Refractored.XamForms.PullToRefresh");
        XamlTypeResolver service6 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver3, typeof (ViewGradesPage).GetTypeInfo().Assembly);
        xamlServiceProvider3.Add(type6, (object) service6);
        xamlServiceProvider3.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(52, 69)));
        object obj3 = resourceExtension12.ProvideValue((IServiceProvider) xamlServiceProvider3);
        bindable6.Style = (Style) obj3;
        Label label8 = bindable6;
        BindableProperty fontSizeProperty1 = Label.FontSizeProperty;
        FontSizeConverter fontSizeConverter1 = new FontSizeConverter();
        XamlServiceProvider xamlServiceProvider4 = new XamlServiceProvider();
        Type type7 = typeof (IProvideValueTarget);
        object[] objectAndParents4 = new object[0 + 12];
        objectAndParents4[0] = (object) bindable6;
        objectAndParents4[1] = (object) bindable7;
        objectAndParents4[2] = (object) bindable10;
        objectAndParents4[3] = (object) bindable11;
        objectAndParents4[4] = (object) frame1;
        objectAndParents4[5] = (object) stackLayout3;
        objectAndParents4[6] = (object) bindable13;
        objectAndParents4[7] = (object) bindable14;
        objectAndParents4[8] = (object) pullToRefreshLayout;
        objectAndParents4[9] = (object) bindable15;
        objectAndParents4[10] = (object) bindable16;
        objectAndParents4[11] = (object) bindable17;
        SimpleValueTargetProvider service7 = new SimpleValueTargetProvider(objectAndParents4, (object) Label.FontSizeProperty);
        xamlServiceProvider4.Add(type7, (object) service7);
        xamlServiceProvider4.Add(typeof (INameScopeProvider), (object) new NameScopeProvider()
        {
          NameScope = (INameScope) nameScope
        });
        Type type8 = typeof (IXamlTypeResolver);
        XmlNamespaceResolver namespaceResolver4 = new XmlNamespaceResolver();
        namespaceResolver4.Add("", "http://xamarin.com/schemas/2014/forms");
        namespaceResolver4.Add("x", "http://schemas.microsoft.com/winfx/2009/xaml");
        namespaceResolver4.Add("controls", "clr-namespace:Refractored.XamForms.PullToRefresh;assembly=Refractored.XamForms.PullToRefresh");
        XamlTypeResolver service8 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver4, typeof (ViewGradesPage).GetTypeInfo().Assembly);
        xamlServiceProvider4.Add(type8, (object) service8);
        xamlServiceProvider4.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(52, 106)));
        object obj4 = ((IExtendedTypeConverter) fontSizeConverter1).ConvertFromInvariantString("19", (IServiceProvider) xamlServiceProvider4);
        label8.SetValue(fontSizeProperty1, obj4);
        bindable6.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.Center);
        bindable7.Children.Add((View) bindable6);
        resourceExtension4.Key = "normalLabel";
        StaticResourceExtension resourceExtension13 = resourceExtension4;
        XamlServiceProvider xamlServiceProvider5 = new XamlServiceProvider();
        Type type9 = typeof (IProvideValueTarget);
        object[] objectAndParents5 = new object[0 + 12];
        objectAndParents5[0] = (object) label3;
        objectAndParents5[1] = (object) bindable7;
        objectAndParents5[2] = (object) bindable10;
        objectAndParents5[3] = (object) bindable11;
        objectAndParents5[4] = (object) frame1;
        objectAndParents5[5] = (object) stackLayout3;
        objectAndParents5[6] = (object) bindable13;
        objectAndParents5[7] = (object) bindable14;
        objectAndParents5[8] = (object) pullToRefreshLayout;
        objectAndParents5[9] = (object) bindable15;
        objectAndParents5[10] = (object) bindable16;
        objectAndParents5[11] = (object) bindable17;
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
        namespaceResolver5.Add("controls", "clr-namespace:Refractored.XamForms.PullToRefresh;assembly=Refractored.XamForms.PullToRefresh");
        XamlTypeResolver service10 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver5, typeof (ViewGradesPage).GetTypeInfo().Assembly);
        xamlServiceProvider5.Add(type10, (object) service10);
        xamlServiceProvider5.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(53, 75)));
        object obj5 = resourceExtension13.ProvideValue((IServiceProvider) xamlServiceProvider5);
        label3.Style = (Style) obj5;
        Label label9 = label3;
        BindableProperty fontSizeProperty2 = Label.FontSizeProperty;
        FontSizeConverter fontSizeConverter2 = new FontSizeConverter();
        XamlServiceProvider xamlServiceProvider6 = new XamlServiceProvider();
        Type type11 = typeof (IProvideValueTarget);
        object[] objectAndParents6 = new object[0 + 12];
        objectAndParents6[0] = (object) label3;
        objectAndParents6[1] = (object) bindable7;
        objectAndParents6[2] = (object) bindable10;
        objectAndParents6[3] = (object) bindable11;
        objectAndParents6[4] = (object) frame1;
        objectAndParents6[5] = (object) stackLayout3;
        objectAndParents6[6] = (object) bindable13;
        objectAndParents6[7] = (object) bindable14;
        objectAndParents6[8] = (object) pullToRefreshLayout;
        objectAndParents6[9] = (object) bindable15;
        objectAndParents6[10] = (object) bindable16;
        objectAndParents6[11] = (object) bindable17;
        SimpleValueTargetProvider service11 = new SimpleValueTargetProvider(objectAndParents6, (object) Label.FontSizeProperty);
        xamlServiceProvider6.Add(type11, (object) service11);
        xamlServiceProvider6.Add(typeof (INameScopeProvider), (object) new NameScopeProvider()
        {
          NameScope = (INameScope) nameScope
        });
        Type type12 = typeof (IXamlTypeResolver);
        XmlNamespaceResolver namespaceResolver6 = new XmlNamespaceResolver();
        namespaceResolver6.Add("", "http://xamarin.com/schemas/2014/forms");
        namespaceResolver6.Add("x", "http://schemas.microsoft.com/winfx/2009/xaml");
        namespaceResolver6.Add("controls", "clr-namespace:Refractored.XamForms.PullToRefresh;assembly=Refractored.XamForms.PullToRefresh");
        XamlTypeResolver service12 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver6, typeof (ViewGradesPage).GetTypeInfo().Assembly);
        xamlServiceProvider6.Add(type12, (object) service12);
        xamlServiceProvider6.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(53, 112)));
        object obj6 = ((IExtendedTypeConverter) fontSizeConverter2).ConvertFromInvariantString("19", (IServiceProvider) xamlServiceProvider6);
        label9.SetValue(fontSizeProperty2, obj6);
        label3.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.Center);
        bindable7.Children.Add((View) label3);
        bindable10.Children.Add((View) bindable7);
        bindable9.SetValue(StackLayout.SpacingProperty, (object) 0.0);
        bindable9.SetValue(StackLayout.OrientationProperty, (object) StackOrientation.Horizontal);
        bindable8.SetValue(Label.TextProperty, (object) "Cumulative GWA: ");
        resourceExtension5.Key = "normalLabel";
        StaticResourceExtension resourceExtension14 = resourceExtension5;
        XamlServiceProvider xamlServiceProvider7 = new XamlServiceProvider();
        Type type13 = typeof (IProvideValueTarget);
        object[] objectAndParents7 = new object[0 + 12];
        objectAndParents7[0] = (object) bindable8;
        objectAndParents7[1] = (object) bindable9;
        objectAndParents7[2] = (object) bindable10;
        objectAndParents7[3] = (object) bindable11;
        objectAndParents7[4] = (object) frame1;
        objectAndParents7[5] = (object) stackLayout3;
        objectAndParents7[6] = (object) bindable13;
        objectAndParents7[7] = (object) bindable14;
        objectAndParents7[8] = (object) pullToRefreshLayout;
        objectAndParents7[9] = (object) bindable15;
        objectAndParents7[10] = (object) bindable16;
        objectAndParents7[11] = (object) bindable17;
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
        namespaceResolver7.Add("controls", "clr-namespace:Refractored.XamForms.PullToRefresh;assembly=Refractored.XamForms.PullToRefresh");
        XamlTypeResolver service14 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver7, typeof (ViewGradesPage).GetTypeInfo().Assembly);
        xamlServiceProvider7.Add(type14, (object) service14);
        xamlServiceProvider7.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(57, 80)));
        object obj7 = resourceExtension14.ProvideValue((IServiceProvider) xamlServiceProvider7);
        bindable8.Style = (Style) obj7;
        Label label10 = bindable8;
        BindableProperty fontSizeProperty3 = Label.FontSizeProperty;
        FontSizeConverter fontSizeConverter3 = new FontSizeConverter();
        XamlServiceProvider xamlServiceProvider8 = new XamlServiceProvider();
        Type type15 = typeof (IProvideValueTarget);
        object[] objectAndParents8 = new object[0 + 12];
        objectAndParents8[0] = (object) bindable8;
        objectAndParents8[1] = (object) bindable9;
        objectAndParents8[2] = (object) bindable10;
        objectAndParents8[3] = (object) bindable11;
        objectAndParents8[4] = (object) frame1;
        objectAndParents8[5] = (object) stackLayout3;
        objectAndParents8[6] = (object) bindable13;
        objectAndParents8[7] = (object) bindable14;
        objectAndParents8[8] = (object) pullToRefreshLayout;
        objectAndParents8[9] = (object) bindable15;
        objectAndParents8[10] = (object) bindable16;
        objectAndParents8[11] = (object) bindable17;
        SimpleValueTargetProvider service15 = new SimpleValueTargetProvider(objectAndParents8, (object) Label.FontSizeProperty);
        xamlServiceProvider8.Add(type15, (object) service15);
        xamlServiceProvider8.Add(typeof (INameScopeProvider), (object) new NameScopeProvider()
        {
          NameScope = (INameScope) nameScope
        });
        Type type16 = typeof (IXamlTypeResolver);
        XmlNamespaceResolver namespaceResolver8 = new XmlNamespaceResolver();
        namespaceResolver8.Add("", "http://xamarin.com/schemas/2014/forms");
        namespaceResolver8.Add("x", "http://schemas.microsoft.com/winfx/2009/xaml");
        namespaceResolver8.Add("controls", "clr-namespace:Refractored.XamForms.PullToRefresh;assembly=Refractored.XamForms.PullToRefresh");
        XamlTypeResolver service16 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver8, typeof (ViewGradesPage).GetTypeInfo().Assembly);
        xamlServiceProvider8.Add(type16, (object) service16);
        xamlServiceProvider8.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(57, 117)));
        object obj8 = ((IExtendedTypeConverter) fontSizeConverter3).ConvertFromInvariantString("19", (IServiceProvider) xamlServiceProvider8);
        label10.SetValue(fontSizeProperty3, obj8);
        bindable8.SetValue(Label.FontFamilyProperty, (object) "Roboto-Medium.ttf#Roboto");
        bindable8.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.Center);
        bindable9.Children.Add((View) bindable8);
        resourceExtension6.Key = "normalLabel";
        StaticResourceExtension resourceExtension15 = resourceExtension6;
        XamlServiceProvider xamlServiceProvider9 = new XamlServiceProvider();
        Type type17 = typeof (IProvideValueTarget);
        object[] objectAndParents9 = new object[0 + 12];
        objectAndParents9[0] = (object) label4;
        objectAndParents9[1] = (object) bindable9;
        objectAndParents9[2] = (object) bindable10;
        objectAndParents9[3] = (object) bindable11;
        objectAndParents9[4] = (object) frame1;
        objectAndParents9[5] = (object) stackLayout3;
        objectAndParents9[6] = (object) bindable13;
        objectAndParents9[7] = (object) bindable14;
        objectAndParents9[8] = (object) pullToRefreshLayout;
        objectAndParents9[9] = (object) bindable15;
        objectAndParents9[10] = (object) bindable16;
        objectAndParents9[11] = (object) bindable17;
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
        namespaceResolver9.Add("controls", "clr-namespace:Refractored.XamForms.PullToRefresh;assembly=Refractored.XamForms.PullToRefresh");
        XamlTypeResolver service18 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver9, typeof (ViewGradesPage).GetTypeInfo().Assembly);
        xamlServiceProvider9.Add(type18, (object) service18);
        xamlServiceProvider9.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(58, 75)));
        object obj9 = resourceExtension15.ProvideValue((IServiceProvider) xamlServiceProvider9);
        label4.Style = (Style) obj9;
        Label label11 = label4;
        BindableProperty fontSizeProperty4 = Label.FontSizeProperty;
        FontSizeConverter fontSizeConverter4 = new FontSizeConverter();
        XamlServiceProvider xamlServiceProvider10 = new XamlServiceProvider();
        Type type19 = typeof (IProvideValueTarget);
        object[] objectAndParents10 = new object[0 + 12];
        objectAndParents10[0] = (object) label4;
        objectAndParents10[1] = (object) bindable9;
        objectAndParents10[2] = (object) bindable10;
        objectAndParents10[3] = (object) bindable11;
        objectAndParents10[4] = (object) frame1;
        objectAndParents10[5] = (object) stackLayout3;
        objectAndParents10[6] = (object) bindable13;
        objectAndParents10[7] = (object) bindable14;
        objectAndParents10[8] = (object) pullToRefreshLayout;
        objectAndParents10[9] = (object) bindable15;
        objectAndParents10[10] = (object) bindable16;
        objectAndParents10[11] = (object) bindable17;
        SimpleValueTargetProvider service19 = new SimpleValueTargetProvider(objectAndParents10, (object) Label.FontSizeProperty);
        xamlServiceProvider10.Add(type19, (object) service19);
        xamlServiceProvider10.Add(typeof (INameScopeProvider), (object) new NameScopeProvider()
        {
          NameScope = (INameScope) nameScope
        });
        Type type20 = typeof (IXamlTypeResolver);
        XmlNamespaceResolver namespaceResolver10 = new XmlNamespaceResolver();
        namespaceResolver10.Add("", "http://xamarin.com/schemas/2014/forms");
        namespaceResolver10.Add("x", "http://schemas.microsoft.com/winfx/2009/xaml");
        namespaceResolver10.Add("controls", "clr-namespace:Refractored.XamForms.PullToRefresh;assembly=Refractored.XamForms.PullToRefresh");
        XamlTypeResolver service20 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver10, typeof (ViewGradesPage).GetTypeInfo().Assembly);
        xamlServiceProvider10.Add(type20, (object) service20);
        xamlServiceProvider10.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(58, 112)));
        object obj10 = ((IExtendedTypeConverter) fontSizeConverter4).ConvertFromInvariantString("19", (IServiceProvider) xamlServiceProvider10);
        label11.SetValue(fontSizeProperty4, obj10);
        label4.SetValue(Label.FontFamilyProperty, (object) "Roboto-Medium.ttf#Roboto");
        label4.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.Center);
        bindable9.Children.Add((View) label4);
        bindable10.Children.Add((View) bindable9);
        bindable11.Children.Add((View) bindable10);
        frame1.SetValue(ContentView.ContentProperty, (object) bindable11);
        stackLayout3.Children.Add((View) frame1);
        stackLayout2.SetValue(View.MarginProperty, (object) new Thickness(10.0));
        stackLayout3.Children.Add((View) stackLayout2);
        label5.SetValue(View.MarginProperty, (object) new Thickness(15.0));
        label5.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.Center);
        resourceExtension7.Key = "microLabel";
        StaticResourceExtension resourceExtension16 = resourceExtension7;
        XamlServiceProvider xamlServiceProvider11 = new XamlServiceProvider();
        Type type21 = typeof (IProvideValueTarget);
        object[] objectAndParents11 = new object[0 + 8];
        objectAndParents11[0] = (object) label5;
        objectAndParents11[1] = (object) stackLayout3;
        objectAndParents11[2] = (object) bindable13;
        objectAndParents11[3] = (object) bindable14;
        objectAndParents11[4] = (object) pullToRefreshLayout;
        objectAndParents11[5] = (object) bindable15;
        objectAndParents11[6] = (object) bindable16;
        objectAndParents11[7] = (object) bindable17;
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
        namespaceResolver11.Add("controls", "clr-namespace:Refractored.XamForms.PullToRefresh;assembly=Refractored.XamForms.PullToRefresh");
        XamlTypeResolver service22 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver11, typeof (ViewGradesPage).GetTypeInfo().Assembly);
        xamlServiceProvider11.Add(type22, (object) service22);
        xamlServiceProvider11.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(69, 100)));
        object obj11 = resourceExtension16.ProvideValue((IServiceProvider) xamlServiceProvider11);
        label5.Style = (Style) obj11;
        label5.SetValue(Label.FontFamilyProperty, (object) "Roboto-Regular.ttf#Roboto");
        stackLayout3.Children.Add((View) label5);
        bindable13.Children.Add((View) stackLayout3);
        frame2.SetValue(View.MarginProperty, (object) new Thickness(15.0));
        frame2.SetValue(Layout.PaddingProperty, (object) new Thickness(15.0));
        frame2.SetValue(Frame.CornerRadiusProperty, (object) 5f);
        frame2.SetValue(VisualElement.IsVisibleProperty, new VisualElement.VisibilityConverter().ConvertFromInvariantString("false"));
        label6.SetValue(Label.TextProperty, (object) "Apologies, the server is undergoing maintenance.");
        resourceExtension8.Key = "smallLabel";
        StaticResourceExtension resourceExtension17 = resourceExtension8;
        XamlServiceProvider xamlServiceProvider12 = new XamlServiceProvider();
        Type type23 = typeof (IProvideValueTarget);
        object[] objectAndParents12 = new object[0 + 9];
        objectAndParents12[0] = (object) label6;
        objectAndParents12[1] = (object) bindable12;
        objectAndParents12[2] = (object) frame2;
        objectAndParents12[3] = (object) bindable13;
        objectAndParents12[4] = (object) bindable14;
        objectAndParents12[5] = (object) pullToRefreshLayout;
        objectAndParents12[6] = (object) bindable15;
        objectAndParents12[7] = (object) bindable16;
        objectAndParents12[8] = (object) bindable17;
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
        namespaceResolver12.Add("controls", "clr-namespace:Refractored.XamForms.PullToRefresh;assembly=Refractored.XamForms.PullToRefresh");
        XamlTypeResolver service24 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver12, typeof (ViewGradesPage).GetTypeInfo().Assembly);
        xamlServiceProvider12.Add(type24, (object) service24);
        xamlServiceProvider12.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(75, 124)));
        object obj12 = resourceExtension17.ProvideValue((IServiceProvider) xamlServiceProvider12);
        label6.Style = (Style) obj12;
        label6.SetValue(Label.TextColorProperty, (object) new Color(0.250980406999588, 0.250980406999588, 0.250980406999588, 1.0));
        label6.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.FillAndExpand);
        bindable12.Children.Add((View) label6);
        frame2.SetValue(ContentView.ContentProperty, (object) bindable12);
        bindable13.Children.Add((View) frame2);
        bindable14.Content = (View) bindable13;
        pullToRefreshLayout.SetValue(ContentView.ContentProperty, (object) bindable14);
        bindable15.Children.Add((View) pullToRefreshLayout);
        bindable16.Children.Add((View) bindable15);
        stackLayout4.SetValue(VisualElement.BackgroundColorProperty, (object) new Color(0.180392161011696, 0.192156866192818, 0.192156866192818, 1.0));
        stackLayout4.SetValue(VisualElement.IsVisibleProperty, new VisualElement.VisibilityConverter().ConvertFromInvariantString("False"));
        stackLayout4.SetValue(View.VerticalOptionsProperty, (object) LayoutOptions.End);
        stackLayout4.SetValue(Layout.PaddingProperty, (object) new Thickness(3.0));
        stackLayout4.SetValue(View.MarginProperty, (object) new Thickness(0.0));
        label7.SetValue(Label.TextProperty, (object) "No connection");
        resourceExtension9.Key = "microLabel";
        StaticResourceExtension resourceExtension18 = resourceExtension9;
        XamlServiceProvider xamlServiceProvider13 = new XamlServiceProvider();
        Type type25 = typeof (IProvideValueTarget);
        object[] objectAndParents13 = new object[0 + 4];
        objectAndParents13[0] = (object) label7;
        objectAndParents13[1] = (object) stackLayout4;
        objectAndParents13[2] = (object) bindable16;
        objectAndParents13[3] = (object) bindable17;
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
        namespaceResolver13.Add("controls", "clr-namespace:Refractored.XamForms.PullToRefresh;assembly=Refractored.XamForms.PullToRefresh");
        XamlTypeResolver service26 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver13, typeof (ViewGradesPage).GetTypeInfo().Assembly);
        xamlServiceProvider13.Add(type26, (object) service26);
        xamlServiceProvider13.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(90, 64)));
        object obj13 = resourceExtension18.ProvideValue((IServiceProvider) xamlServiceProvider13);
        label7.Style = (Style) obj13;
        Label label12 = label7;
        BindableProperty fontSizeProperty5 = Label.FontSizeProperty;
        FontSizeConverter fontSizeConverter5 = new FontSizeConverter();
        XamlServiceProvider xamlServiceProvider14 = new XamlServiceProvider();
        Type type27 = typeof (IProvideValueTarget);
        object[] objectAndParents14 = new object[0 + 4];
        objectAndParents14[0] = (object) label7;
        objectAndParents14[1] = (object) stackLayout4;
        objectAndParents14[2] = (object) bindable16;
        objectAndParents14[3] = (object) bindable17;
        SimpleValueTargetProvider service27 = new SimpleValueTargetProvider(objectAndParents14, (object) Label.FontSizeProperty);
        xamlServiceProvider14.Add(type27, (object) service27);
        xamlServiceProvider14.Add(typeof (INameScopeProvider), (object) new NameScopeProvider()
        {
          NameScope = (INameScope) nameScope
        });
        Type type28 = typeof (IXamlTypeResolver);
        XmlNamespaceResolver namespaceResolver14 = new XmlNamespaceResolver();
        namespaceResolver14.Add("", "http://xamarin.com/schemas/2014/forms");
        namespaceResolver14.Add("x", "http://schemas.microsoft.com/winfx/2009/xaml");
        namespaceResolver14.Add("controls", "clr-namespace:Refractored.XamForms.PullToRefresh;assembly=Refractored.XamForms.PullToRefresh");
        XamlTypeResolver service28 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver14, typeof (ViewGradesPage).GetTypeInfo().Assembly);
        xamlServiceProvider14.Add(type28, (object) service28);
        xamlServiceProvider14.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(90, 100)));
        object obj14 = ((IExtendedTypeConverter) fontSizeConverter5).ConvertFromInvariantString("12", (IServiceProvider) xamlServiceProvider14);
        label12.SetValue(fontSizeProperty5, obj14);
        label7.SetValue(Label.TextColorProperty, (object) new Color(1.0, 1.0, 1.0, 1.0));
        label7.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.Center);
        stackLayout4.Children.Add((View) label7);
        bindable16.Children.Add((View) stackLayout4);
        bindable17.SetValue(ContentPage.ContentProperty, (object) bindable16);
      }
    }

    private void __InitComponentRuntime()
    {
      this.LoadFromXaml<ViewGradesPage>(typeof (ViewGradesPage));
      this.stackSYTerm = NameScopeExtensions.FindByName<StackLayout>(this, "stackSYTerm");
      this.lblSYTerm = NameScopeExtensions.FindByName<Label>(this, "lblSYTerm");
      this.imgPullDownTerms = NameScopeExtensions.FindByName<Image>(this, "imgPullDownTerms");
      this.pckrSchoolTerm = NameScopeExtensions.FindByName<Picker>(this, "pckrSchoolTerm");
      this.refreshGrades = NameScopeExtensions.FindByName<PullToRefreshLayout>(this, "refreshGrades");
      this.stackMain = NameScopeExtensions.FindByName<StackLayout>(this, "stackMain");
      this.lblAsOf = NameScopeExtensions.FindByName<Label>(this, "lblAsOf");
      this.frmGWA = NameScopeExtensions.FindByName<Frame>(this, "frmGWA");
      this.lblCurGWA = NameScopeExtensions.FindByName<Label>(this, "lblCurGWA");
      this.lblCumGWA = NameScopeExtensions.FindByName<Label>(this, "lblCumGWA");
      this.stackGrades = NameScopeExtensions.FindByName<StackLayout>(this, "stackGrades");
      this.lblLastSync = NameScopeExtensions.FindByName<Label>(this, "lblLastSync");
      this.frameServerDown = NameScopeExtensions.FindByName<Frame>(this, "frameServerDown");
      this.lblServerDown = NameScopeExtensions.FindByName<Label>(this, "lblServerDown");
      this.stackStatus = NameScopeExtensions.FindByName<StackLayout>(this, "stackStatus");
      this.lblStatus = NameScopeExtensions.FindByName<Label>(this, "lblStatus");
    }
  }
}
