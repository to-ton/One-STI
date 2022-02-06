// Decompiled with JetBrains decompiler
// Type: one_sti_student_portal.Views.Students.StudentCheckList
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
using System.Net;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.Xaml.Internals;
using XLabs.Forms.Controls;

namespace one_sti_student_portal.Views.Students
{
  [XamlFilePath("Views\\Students\\StudentCheckList.xaml")]
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public class StudentCheckList : ContentPage
  {
    private StudentData _studentData;
    private bool _isBusy;
    private bool _isConnected;
    private bool _isActive;
    private bool _refreshContent;
    private string _requirementGroup;
    private string serverStatus;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private PullToRefreshLayout refreshChecklist;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private StackLayout stackBody;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private Label lblProcessed;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private Label lblCurriculum;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private Span lblRequired;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private Span lblTaken;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private Span lblNeeded;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private StackLayout stackSchoolTerm;
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

    public StudentCheckList(bool refreshContent)
    {
      this.InitializeComponent();
      this._refreshContent = refreshContent;
      this._studentData = new StudentData();
      this._isConnected = ConnectionHelper.IsConnected();
      Connectivity.ConnectivityChanged += (EventHandler<ConnectivityChangedEventArgs>) ((sender, args) =>
      {
        this._isConnected = ConnectionHelper.IsConnected();
        this.CheckStatus();
      });
      this.refreshChecklist.RefreshCommand = (ICommand) new Command((Action) (() => this.RefreshContent()));
      switch (Device.RuntimePlatform)
      {
        case "Android":
          this.ToolbarItems.Add(new ToolbarItem("", "ic_action_info", (Action) (() => this.DisplayAlert("Program Curriculum", "For issues regarding the status of your subject list and units taken, proceed to the Registrar’s Office to verify your information or you may report it using our in-app feedback page.", "OK"))));
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

    private void LoadCurriculumDetails()
    {
      List<StudentChecklist> result = this._studentData.GetChecklist("*").Result;
      using (List<StudentChecklist>.Enumerator enumerator = result.GetEnumerator())
      {
        if (!enumerator.MoveNext())
          return;
        StudentChecklist current = enumerator.Current;
        this.lblProcessed.Text = "AS OF " + result.OrderByDescending<StudentChecklist, DateTime>((Func<StudentChecklist, DateTime>) (o => o.GradeDate)).ToList<StudentChecklist>().FirstOrDefault<StudentChecklist>().GradeDate.ToString("dd MMM, yyyy").ToUpper();
        this.lblCurriculum.Text = current.RqrmntGroupDescr;
        this._requirementGroup = current.RqrmntGroup;
        foreach (CurriculumDetails curriculumDetails in this._studentData.GetCurriculum(current.RqrmntGroup).Result)
        {
          curriculumDetails.MinUnitsRequired = string.IsNullOrWhiteSpace(curriculumDetails.MinUnitsRequired) ? "0.00" : curriculumDetails.MinUnitsRequired;
          curriculumDetails.UnitsTaken = string.IsNullOrWhiteSpace(curriculumDetails.UnitsTaken) ? "0.00" : curriculumDetails.UnitsTaken;
          this.lblRequired.Text = curriculumDetails.MinUnitsRequired;
          this.lblTaken.Text = string.Format("{0:0.00}", new object[1]
          {
            (object) curriculumDetails.UnitsTaken
          });
          double num = double.Parse(curriculumDetails.MinUnitsRequired) - double.Parse(curriculumDetails.UnitsTaken);
          this.lblNeeded.Text = string.Format("{0:0.00}", new object[1]
          {
            (object) (num <= 0.0 ? 0.0 : num)
          });
        }
      }
    }

    private void LoadRequirementDescriptions()
    {
      List<StudentChecklist> requirementDescriptions = this._studentData.GetRequirementDescriptions(false);
      List<StudentChecklist> studentChecklistList = new List<StudentChecklist>();
      Frame frame1 = new Frame();
      Image image1 = new Image();
      this.stackSchoolTerm.Children.Clear();
      List<StudentChecklist> source = new List<StudentChecklist>();
      foreach (StudentChecklist studentChecklist in requirementDescriptions)
      {
        this.lblLastSync.Text = "LAST SYNC ON " + studentChecklist.UpdatedOn.ToString("dd MMM, yyyy hh:mm tt").ToUpper();
        string rqrmntDescr = studentChecklist.RqrmntDescr;
        if (rqrmntDescr.Length != 0 && rqrmntDescr.Contains(","))
        {
          rqrmntDescr = rqrmntDescr.Substring(0, rqrmntDescr.IndexOf(",") + 1);
          rqrmntDescr = rqrmntDescr.Trim().Replace(",", "");
        }
        if (!source.Any<StudentChecklist>((Func<StudentChecklist, bool>) (o => o.RqrmntDescr == rqrmntDescr)))
          source.Add(new StudentChecklist()
          {
            RqrmntDescr = rqrmntDescr,
            CourseList = studentChecklist.CourseList,
            Status = studentChecklist.Status
          });
      }
      foreach (StudentChecklist studentChecklist1 in source)
      {
        StudentChecklist level = studentChecklist1;
        StackLayout stackLayout1 = new StackLayout()
        {
          Spacing = 0.0
        };
        StackLayout stackLayout2 = new StackLayout();
        StackLayout stackLayout3 = new StackLayout();
        stackLayout3.Margin = new Thickness(10.0, 0.0, 10.0, 0.0);
        stackLayout3.Orientation = StackOrientation.Horizontal;
        StackLayout stackLayout4 = stackLayout3;
        this._studentData.GetChecklist("*").Result.Where<StudentChecklist>((Func<StudentChecklist, bool>) (o => o.RqrmntDescr.Contains(level.RqrmntDescr))).ToList<StudentChecklist>();
        stackLayout2.Children.Add((View) stackLayout4);
        IList<View> children1 = stackLayout4.Children;
        Label label1 = new Label();
        label1.Text = level.RqrmntDescr;
        label1.Style = (Style) Application.Current.Resources["normalHeader"];
        label1.TextColor = Color.FromHex("#404040");
        label1.HorizontalOptions = LayoutOptions.StartAndExpand;
        children1.Add((View) label1);
        Image image2 = new Image();
        List<StudentChecklist> checklistPerLevel = this._studentData.GetChecklistPerLevel(level.RqrmntDescr).Result;
        Image image3;
        if (checklistPerLevel.Any<StudentChecklist>((Func<StudentChecklist, bool>) (o => o.IsExpand == 1)))
        {
          Image image4 = new Image();
          image4.Source = (ImageSource) "ic_expand_less";
          image4.HorizontalOptions = LayoutOptions.End;
          image3 = image4;
        }
        else
        {
          Image image5 = new Image();
          image5.Source = (ImageSource) "ic_expand_more";
          image5.HorizontalOptions = LayoutOptions.End;
          image3 = image5;
        }
        TapGestureRecognizer gestureRecognizer1 = new TapGestureRecognizer();
        gestureRecognizer1.Tapped += (EventHandler) ((s, e) =>
        {
          if (checklistPerLevel.Any<StudentChecklist>((Func<StudentChecklist, bool>) (o => o.IsExpand == 1)))
          {
            Acr.UserDialogs.UserDialogs.Instance.ShowLoading("Wait a moment");
            this._studentData.ExpandCollapsePerLevel(level.RqrmntDescr, 0);
          }
          else
          {
            Acr.UserDialogs.UserDialogs.Instance.ShowLoading();
            this._studentData.ExpandCollapsePerLevel(level.RqrmntDescr, 1);
          }
          Device.StartTimer(TimeSpan.FromSeconds(0.5), (Func<bool>) (() =>
          {
            this.LoadRequirementDescriptions();
            Acr.UserDialogs.UserDialogs.Instance.HideLoading();
            return false;
          }));
        });
        image3.GestureRecognizers.Add((IGestureRecognizer) gestureRecognizer1);
        stackLayout4.Children.Add((View) image3);
        IList<View> children2 = stackLayout2.Children;
        BoxView boxView1 = new BoxView();
        boxView1.Color = Color.FromHex("#E7C01D");
        boxView1.HeightRequest = 1.5;
        boxView1.Margin = new Thickness(10.0, 5.0, 10.0, 5.0);
        boxView1.HorizontalOptions = LayoutOptions.FillAndExpand;
        children2.Add((View) boxView1);
        stackLayout1.Children.Add((View) stackLayout2);
        foreach (StudentChecklist studentChecklist2 in requirementDescriptions)
        {
          StudentChecklist items = studentChecklist2;
          if (items.RqrmntDescr.Contains(level.RqrmntDescr))
          {
            StackLayout stackLayout5 = new StackLayout();
            stackLayout5.Orientation = StackOrientation.Horizontal;
            stackLayout5.Margin = new Thickness(8.0, 0.0, 10.0, 0.0);
            StackLayout stackLayout6 = stackLayout5;
            string str1 = items.RqrmntDescr;
            if (str1.Length != 0 && str1.Contains(","))
              str1 = str1.Substring(str1.IndexOf(",")).Trim().Replace(",", "");
            Image image6 = new Image()
            {
              Source = (ImageSource) (items.IsExpand == 0 ? "ic_expand_more" : "ic_expand_less")
            };
            stackLayout6.Children.Add((View) image6);
            IList<View> children3 = stackLayout6.Children;
            ExtendedLabel extendedLabel = new ExtendedLabel();
            extendedLabel.Text = str1;
            extendedLabel.Style = (Style) Application.Current.Resources["smallHeader"];
            extendedLabel.FontSize = 16.0;
            extendedLabel.IsUnderline = true;
            extendedLabel.VerticalOptions = LayoutOptions.Center;
            extendedLabel.HorizontalOptions = LayoutOptions.StartAndExpand;
            extendedLabel.Margin = new Thickness(0.0, 5.0, 0.0, 5.0);
            children3.Add((View) extendedLabel);
            TapGestureRecognizer gestureRecognizer2 = new TapGestureRecognizer();
            gestureRecognizer2.Tapped += (EventHandler) ((s, e) =>
            {
              if (items.IsExpand == 0)
              {
                Acr.UserDialogs.UserDialogs.Instance.ShowLoading();
                this._studentData.ExpandCollapse(items.CourseList, 1);
              }
              else
              {
                Acr.UserDialogs.UserDialogs.Instance.ShowLoading("Wait a moment...");
                this._studentData.ExpandCollapse(items.CourseList, 0);
              }
              Device.StartTimer(TimeSpan.FromSeconds(0.5), (Func<bool>) (() =>
              {
                this.LoadRequirementDescriptions();
                Acr.UserDialogs.UserDialogs.Instance.HideLoading();
                return false;
              }));
            });
            stackLayout6.GestureRecognizers.Add((IGestureRecognizer) gestureRecognizer2);
            stackLayout1.Children.Add((View) stackLayout6);
            bool flag = false;
            if (items.IsExpand == 1)
            {
              List<StudentChecklist> result = this._studentData.GetChecklist(items.CourseList).Result;
              int num1 = 0;
              foreach (StudentChecklist studentChecklist3 in result)
              {
                ++num1;
                StackLayout stackLayout7 = new StackLayout();
                stackLayout7.Padding = new Thickness(5.0);
                stackLayout7.Margin = new Thickness(5.0, 0.0, 5.0, 0.0);
                stackLayout7.Spacing = 0.0;
                stackLayout7.Opacity = 0.0;
                StackLayout view = stackLayout7;
                if (!flag && !str1.ToLower().Contains("elective"))
                {
                  double num2 = result.Select<StudentChecklist, double>((Func<StudentChecklist, double>) (i => double.Parse(i.EarnedUnits))).Sum();
                  double num3 = result.Select<StudentChecklist, double>((Func<StudentChecklist, double>) (i => double.Parse(i.ReqUnits))).Sum();
                  double num4 = num3 - num2;
                  FormattedString formattedString = new FormattedString();
                  formattedString.Spans.Add(new Span()
                  {
                    Text = "Units: ",
                    ForegroundColor = Color.FromHex("#404040"),
                    FontFamily = "Roboto-Regular.ttf#Roboto",
                    FontSize = Device.GetNamedSize(NamedSize.Small, typeof (Label))
                  });
                  formattedString.Spans.Add(new Span()
                  {
                    Text = string.Format("{0:0.00}", new object[1]
                    {
                      (object) num3
                    }),
                    ForegroundColor = Color.FromHex("#404040"),
                    FontFamily = "Roboto-Medium.ttf#Roboto",
                    FontSize = Device.GetNamedSize(NamedSize.Small, typeof (Label))
                  });
                  formattedString.Spans.Add(new Span()
                  {
                    Text = " required, ",
                    ForegroundColor = Color.FromHex("#404040"),
                    FontFamily = "Roboto-Regular.ttf#Roboto",
                    FontSize = Device.GetNamedSize(NamedSize.Small, typeof (Label))
                  });
                  formattedString.Spans.Add(new Span()
                  {
                    Text = string.Format("{0:0.00}", new object[1]
                    {
                      (object) num2
                    }),
                    ForegroundColor = Color.FromHex("#404040"),
                    FontFamily = "Roboto-Medium.ttf#Roboto",
                    FontSize = Device.GetNamedSize(NamedSize.Small, typeof (Label))
                  });
                  formattedString.Spans.Add(new Span()
                  {
                    Text = " taken, ",
                    ForegroundColor = Color.FromHex("#404040"),
                    FontFamily = "Roboto-Regular.ttf#Roboto",
                    FontSize = Device.GetNamedSize(NamedSize.Small, typeof (Label))
                  });
                  formattedString.Spans.Add(new Span()
                  {
                    Text = string.Format("{0:0.00}", new object[1]
                    {
                      (object) num4
                    }),
                    ForegroundColor = Color.FromHex("#404040"),
                    FontFamily = "Roboto-Medium.ttf#Roboto",
                    FontSize = Device.GetNamedSize(NamedSize.Small, typeof (Label))
                  });
                  formattedString.Spans.Add(new Span()
                  {
                    Text = " needed",
                    ForegroundColor = Color.FromHex("#404040"),
                    FontFamily = "Roboto-Regular.ttf#Roboto",
                    FontSize = Device.GetNamedSize(NamedSize.Small, typeof (Label))
                  });
                  flag = true;
                }
                StackLayout stackLayout8 = new StackLayout()
                {
                  Orientation = StackOrientation.Horizontal,
                  Spacing = 0.0
                };
                if (!string.IsNullOrWhiteSpace(studentChecklist3.CourseCode))
                {
                  string str2 = studentChecklist3.CourseCode + " - ";
                }
                Label label2 = new Label();
                label2.Text = WebUtility.HtmlDecode(studentChecklist3.CourseDesc);
                label2.Style = (Style) Application.Current.Resources["smallHeader"];
                label2.FontSize = 15.0;
                label2.TextColor = Color.FromHex("#404040");
                label2.HorizontalOptions = LayoutOptions.StartAndExpand;
                label2.VerticalOptions = LayoutOptions.Center;
                Label label3 = label2;
                string str3 = "ic_in_progress";
                int left1 = 22;
                switch (studentChecklist3.Status)
                {
                  case "TKN":
                    str3 = "ic_check";
                    break;
                  case "PRG":
                    str3 = "ic_in_progress";
                    break;
                  case "NYT":
                    str3 = "ic_not_started";
                    break;
                }
                Image image7 = new Image();
                image7.Source = (ImageSource) str3;
                image7.HeightRequest = 15.0;
                image7.Margin = new Thickness(0.0, 0.0, 7.0, 0.0);
                image7.HorizontalOptions = LayoutOptions.Start;
                Image image8 = image7;
                if (!string.IsNullOrWhiteSpace(str3))
                  stackLayout8.Children.Add((View) image8);
                stackLayout8.Children.Add((View) label3);
                view.Children.Add((View) stackLayout8);
                StackLayout stackLayout9 = new StackLayout();
                stackLayout9.HorizontalOptions = LayoutOptions.Start;
                stackLayout9.VerticalOptions = LayoutOptions.End;
                stackLayout9.Margin = new Thickness((double) left1, 5.0, 0.0, 0.0);
                stackLayout9.Spacing = 0.0;
                StackLayout stackLayout10 = stackLayout9;
                string str4 = string.IsNullOrWhiteSpace(studentChecklist3.ReqUnits) ? "0.00" : studentChecklist3.ReqUnits;
                string str5 = string.IsNullOrWhiteSpace(studentChecklist3.EarnedUnits) ? "0.00" : studentChecklist3.EarnedUnits;
                FormattedString formattedString1 = new FormattedString();
                formattedString1.Spans.Add(new Span()
                {
                  Text = "Units: ",
                  ForegroundColor = Color.FromHex("#404040"),
                  FontFamily = "Roboto-Regular.ttf#Roboto",
                  FontSize = Device.GetNamedSize(NamedSize.Small, typeof (Label))
                });
                formattedString1.Spans.Add(new Span()
                {
                  Text = str4,
                  ForegroundColor = Color.FromHex("#404040"),
                  FontFamily = "Roboto-Medium.ttf#Roboto",
                  FontSize = Device.GetNamedSize(NamedSize.Small, typeof (Label))
                });
                formattedString1.Spans.Add(new Span()
                {
                  Text = " required",
                  ForegroundColor = Color.FromHex("#404040"),
                  FontFamily = "Roboto-Regular.ttf#Roboto",
                  FontSize = Device.GetNamedSize(NamedSize.Small, typeof (Label))
                });
                if (str5 != "0.00")
                {
                  formattedString1.Spans.Add(new Span()
                  {
                    Text = ", " + str5,
                    ForegroundColor = Color.FromHex("#404040"),
                    FontFamily = "Roboto-Medium.ttf#Roboto",
                    FontSize = Device.GetNamedSize(NamedSize.Small, typeof (Label))
                  });
                  formattedString1.Spans.Add(new Span()
                  {
                    Text = " taken",
                    ForegroundColor = Color.FromHex("#404040"),
                    FontFamily = "Roboto-Regular.ttf#Roboto",
                    FontSize = Device.GetNamedSize(NamedSize.Small, typeof (Label))
                  });
                }
                stackLayout10.Children.Add((View) new Label()
                {
                  FormattedText = formattedString1
                });
                string str6 = string.IsNullOrWhiteSpace(studentChecklist3.Grade) ? "0.00" : studentChecklist3.Grade;
                if (str6 != "0.00")
                {
                  FormattedString formattedString2 = new FormattedString();
                  formattedString2.Spans.Add(new Span()
                  {
                    Text = "Grade: ",
                    ForegroundColor = Color.FromHex("#404040"),
                    FontFamily = "Roboto-Regular.ttf#Roboto",
                    FontSize = Device.GetNamedSize(NamedSize.Small, typeof (Label))
                  });
                  formattedString2.Spans.Add(new Span()
                  {
                    Text = str6,
                    ForegroundColor = Color.FromHex("#404040"),
                    FontFamily = "Roboto-Medium.ttf#Roboto",
                    FontSize = Device.GetNamedSize(NamedSize.Small, typeof (Label))
                  });
                  stackLayout10.Children.Add((View) new Label()
                  {
                    FormattedText = formattedString2
                  });
                }
                if (studentChecklist3.Term != "N/A")
                {
                  FormattedString formattedString3 = new FormattedString();
                  formattedString3.Spans.Add(new Span()
                  {
                    Text = "Term Taken: ",
                    ForegroundColor = Color.FromHex("#404040"),
                    FontFamily = "Roboto-Regular.ttf#Roboto",
                    FontSize = Device.GetNamedSize(NamedSize.Small, typeof (Label))
                  });
                  formattedString3.Spans.Add(new Span()
                  {
                    Text = studentChecklist3.Term,
                    ForegroundColor = Color.FromHex("#404040"),
                    FontFamily = "Roboto-Medium.ttf#Roboto",
                    FontSize = Device.GetNamedSize(NamedSize.Small, typeof (Label))
                  });
                  stackLayout10.Children.Add((View) new Label()
                  {
                    FormattedText = formattedString3
                  });
                }
                view.Children.Add((View) stackLayout10);
                if (!string.IsNullOrWhiteSpace(studentChecklist3.PreRequisite))
                {
                  FormattedString formattedString4 = new FormattedString();
                  formattedString4.Spans.Add(new Span()
                  {
                    Text = "Pre - Requisite / Co - Requisite: ",
                    ForegroundColor = Color.FromHex("#404040"),
                    FontFamily = "Roboto-Regular.ttf#Roboto",
                    FontSize = Device.GetNamedSize(NamedSize.Small, typeof (Label))
                  });
                  formattedString4.Spans.Add(new Span()
                  {
                    Text = WebUtility.HtmlDecode(studentChecklist3.PreRequisite),
                    ForegroundColor = Color.FromHex("#404040"),
                    FontFamily = "Roboto-Medium.ttf#Roboto",
                    FontSize = Device.GetNamedSize(NamedSize.Small, typeof (Label))
                  });
                  IList<View> children4 = view.Children;
                  Label label4 = new Label();
                  label4.FormattedText = formattedString4;
                  label4.Margin = new Thickness((double) left1, 10.0, 20.0, 20.0);
                  children4.Add((View) label4);
                }
                if (num1 != result.Count)
                {
                  BoxView boxView2 = new BoxView();
                  boxView2.Color = Color.FromHex("#e4e9ed");
                  boxView2.HeightRequest = 1.0;
                  boxView2.Margin = new Thickness(5.0, 0.0, 5.0, 0.0);
                  boxView2.HorizontalOptions = LayoutOptions.FillAndExpand;
                  BoxView boxView3 = boxView2;
                  if (string.IsNullOrWhiteSpace(studentChecklist3.PreRequisite))
                    boxView3.Margin = new Thickness(5.0, 10.0, 5.0, 10.0);
                  view.Children.Add((View) boxView3);
                }
                else if (string.IsNullOrWhiteSpace(studentChecklist3.PreRequisite))
                {
                  StackLayout stackLayout11 = view;
                  Thickness margin = view.Margin;
                  double left2 = margin.Left;
                  margin = view.Margin;
                  double top = margin.Top;
                  margin = view.Margin;
                  double right = margin.Right;
                  margin = view.Margin;
                  double bottom = margin.Bottom + 10.0;
                  Thickness thickness = new Thickness(left2, top, right, bottom);
                  stackLayout11.Margin = thickness;
                }
                stackLayout1.Children.Add((View) view);
                view.FadeTo(1.0, 1000U);
              }
            }
          }
        }
        Frame frame2 = new Frame();
        frame2.Content = (View) stackLayout1;
        frame2.HasShadow = true;
        frame2.Padding = new Thickness(10.0);
        this.stackSchoolTerm.Children.Add((View) frame2);
        this.stackBody.IsVisible = true;
      }
    }

    private void Curriculum_Tapped(object sender, EventArgs e) => this.Navigation.PushAsync((Page) new CurriculumDetailsPage(this.lblCurriculum.Text), true);

    private void RefreshContent()
    {
      this._refreshContent = false;
      Device.BeginInvokeOnMainThread((Action) (() => this.refreshChecklist.IsRefreshing = true));
      Task.Run((Func<Task>) (async () =>
      {
        StudentCheckList studentCheckList = this;
        string str1 = await studentCheckList.ServerStatusAsync();
        studentCheckList.serverStatus = str1;
        if (!(studentCheckList.serverStatus == "true") || !studentCheckList._isConnected || studentCheckList._isBusy)
          return;
        studentCheckList._isBusy = true;
        StudentService studentService = new StudentService();
        StudentInformation studentInfo = studentCheckList._studentData.GetStudentInformation().Result.FirstOrDefault<StudentInformation>();
        await studentCheckList._studentData.DeleteChecklist();
        await studentCheckList._studentData.DeleteCurriculum();
        await studentCheckList._studentData.DownloadChecklist(studentInfo.PSCSId, studentInfo.ProgramShort);
        string str2 = await new StudentService().SendLog(new AppLogModel()
        {
          PSCSId = studentInfo.PSCSId,
          IPAddress = "null",
          Medium = "Mobile",
          AppVersion = Constants.VersionName,
          NumOfRequests = 1,
          DateAccessed = DateTime.Now.ToString("MM/dd/yyyy hh:mm tt"),
          ViewName = studentCheckList.GetType().Name + " RefreshContent()",
          Campus = studentInfo.Campus
        });
        studentInfo = (StudentInformation) null;
      })).ContinueWith((Action<Task>) (result => Device.BeginInvokeOnMainThread((Action) (() =>
      {
        if (this.serverStatus == "true")
        {
          this.LoadCurriculumDetails();
          this.LoadRequirementDescriptions();
          this.refreshChecklist.IsRefreshing = false;
          this._isBusy = false;
          if (ConnectionHelper.IsConnected())
            return;
          Acr.UserDialogs.UserDialogs.Instance.Toast("Could not refresh. Check your network connection.");
        }
        else
        {
          this.refreshChecklist.IsRefreshing = false;
          this._isBusy = false;
          if (ConnectionHelper.IsConnected())
            return;
          Acr.UserDialogs.UserDialogs.Instance.Toast("Could not refresh. Check your network connection.");
        }
      }))));
    }

    protected override void OnAppearing()
    {
      base.OnAppearing();
      MessagingCenter.Send<MessageSender>(new MessageSender(), "Curriculum");
      Application.Current.Properties["IsCurriculumOpened"] = (object) "1";
      this._isConnected = ConnectionHelper.IsConnected();
      this._isActive = true;
      if (!this._isConnected)
      {
        this.stackStatus.BackgroundColor = Color.FromHex("#2e3131");
        this.stackStatus.IsVisible = true;
        this.lblStatus.Text = "No connection";
      }
      if (!this._refreshContent || !this._isActive)
        return;
      this.refreshChecklist.IsRefreshing = true;
      Device.StartTimer(TimeSpan.FromSeconds(2.0), (Func<bool>) (() =>
      {
        if (this._studentData.GetChecklist("*").Result.Count == 0)
        {
          this.RefreshContent();
        }
        else
        {
          this._studentData.ExpandCollapse("*", 0);
          this.LoadCurriculumDetails();
          this.LoadRequirementDescriptions();
        }
        this.refreshChecklist.IsRefreshing = false;
        this._refreshContent = false;
        return false;
      }));
    }

    protected override void OnDisappearing()
    {
      base.OnDisappearing();
      this._isActive = false;
    }

    private async Task<string> ServerStatusAsync()
    {
      try
      {
        return ConnectionHelper.IsConnected() ? (!(await new StudentService().CheckServerStatus()).ToLower().Contains("online") ? "false" : "true") : "false";
      }
      catch
      {
        return "false";
      }
    }

    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private void InitializeComponent()
    {
      if (ResourceLoader.ResourceProvider != null && ResourceLoader.ResourceProvider(typeof (StudentCheckList).GetTypeInfo().Assembly.GetName(), "Views/Students/StudentCheckList.xaml") != null)
        this.__InitComponentRuntime();
      else if (Xamarin.Forms.Xaml.Internals.XamlLoader.XamlFileProvider != null && Xamarin.Forms.Xaml.Internals.XamlLoader.XamlFileProvider(this.GetType()) != null)
      {
        this.__InitComponentRuntime();
      }
      else
      {
        TapGestureRecognizer bindable1 = new TapGestureRecognizer();
        StaticResourceExtension resourceExtension1 = new StaticResourceExtension();
        Label label1 = new Label();
        StaticResourceExtension resourceExtension2 = new StaticResourceExtension();
        Label label2 = new Label();
        Image bindable2 = new Image();
        StackLayout bindable3 = new StackLayout();
        BoxView bindable4 = new BoxView();
        Span bindable5 = new Span();
        Span span1 = new Span();
        Span bindable6 = new Span();
        Span span2 = new Span();
        Span bindable7 = new Span();
        Span span3 = new Span();
        Span bindable8 = new Span();
        FormattedString bindable9 = new FormattedString();
        Label bindable10 = new Label();
        StackLayout bindable11 = new StackLayout();
        Frame bindable12 = new Frame();
        Image bindable13 = new Image();
        StaticResourceExtension resourceExtension3 = new StaticResourceExtension();
        Label bindable14 = new Label();
        Image bindable15 = new Image();
        StaticResourceExtension resourceExtension4 = new StaticResourceExtension();
        Label bindable16 = new Label();
        Image bindable17 = new Image();
        StaticResourceExtension resourceExtension5 = new StaticResourceExtension();
        Label bindable18 = new Label();
        StackLayout bindable19 = new StackLayout();
        StackLayout stackLayout1 = new StackLayout();
        StaticResourceExtension resourceExtension6 = new StaticResourceExtension();
        Label label3 = new Label();
        StaticResourceExtension resourceExtension7 = new StaticResourceExtension();
        Label label4 = new Label();
        StackLayout bindable20 = new StackLayout();
        Frame frame = new Frame();
        StackLayout stackLayout2 = new StackLayout();
        ScrollView bindable21 = new ScrollView();
        PullToRefreshLayout pullToRefreshLayout = new PullToRefreshLayout();
        StackLayout bindable22 = new StackLayout();
        StaticResourceExtension resourceExtension8 = new StaticResourceExtension();
        Label label5 = new Label();
        StackLayout stackLayout3 = new StackLayout();
        StackLayout bindable23 = new StackLayout();
        StudentCheckList bindable24 = this;
        NameScope nameScope = new NameScope();
        NameScope.SetNameScope((BindableObject) bindable24, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable23, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable22, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) pullToRefreshLayout, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("refreshChecklist", (object) pullToRefreshLayout);
        if (pullToRefreshLayout.StyleId == null)
          pullToRefreshLayout.StyleId = "refreshChecklist";
        NameScope.SetNameScope((BindableObject) bindable21, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) stackLayout2, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("stackBody", (object) stackLayout2);
        if (stackLayout2.StyleId == null)
          stackLayout2.StyleId = "stackBody";
        NameScope.SetNameScope((BindableObject) bindable12, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable1, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable11, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) label1, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("lblProcessed", (object) label1);
        if (label1.StyleId == null)
          label1.StyleId = "lblProcessed";
        NameScope.SetNameScope((BindableObject) bindable3, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) label2, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("lblCurriculum", (object) label2);
        if (label2.StyleId == null)
          label2.StyleId = "lblCurriculum";
        NameScope.SetNameScope((BindableObject) bindable2, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable4, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable10, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable9, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable5, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) span1, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("lblRequired", (object) span1);
        if (span1.StyleId == null)
          span1.StyleId = "lblRequired";
        NameScope.SetNameScope((BindableObject) bindable6, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) span2, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("lblTaken", (object) span2);
        if (span2.StyleId == null)
          span2.StyleId = "lblTaken";
        NameScope.SetNameScope((BindableObject) bindable7, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) span3, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("lblNeeded", (object) span3);
        if (span3.StyleId == null)
          span3.StyleId = "lblNeeded";
        NameScope.SetNameScope((BindableObject) bindable8, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable19, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable13, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable14, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable15, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable16, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable17, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable18, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) stackLayout1, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("stackSchoolTerm", (object) stackLayout1);
        if (stackLayout1.StyleId == null)
          stackLayout1.StyleId = "stackSchoolTerm";
        NameScope.SetNameScope((BindableObject) label3, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("lblLastSync", (object) label3);
        if (label3.StyleId == null)
          label3.StyleId = "lblLastSync";
        NameScope.SetNameScope((BindableObject) frame, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("frameServerDown", (object) frame);
        if (frame.StyleId == null)
          frame.StyleId = "frameServerDown";
        NameScope.SetNameScope((BindableObject) bindable20, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) label4, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("lblServerDown", (object) label4);
        if (label4.StyleId == null)
          label4.StyleId = "lblServerDown";
        NameScope.SetNameScope((BindableObject) stackLayout3, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("stackStatus", (object) stackLayout3);
        if (stackLayout3.StyleId == null)
          stackLayout3.StyleId = "stackStatus";
        NameScope.SetNameScope((BindableObject) label5, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("lblStatus", (object) label5);
        if (label5.StyleId == null)
          label5.StyleId = "lblStatus";
        this.refreshChecklist = pullToRefreshLayout;
        this.stackBody = stackLayout2;
        this.lblProcessed = label1;
        this.lblCurriculum = label2;
        this.lblRequired = span1;
        this.lblTaken = span2;
        this.lblNeeded = span3;
        this.stackSchoolTerm = stackLayout1;
        this.lblLastSync = label3;
        this.frameServerDown = frame;
        this.lblServerDown = label4;
        this.stackStatus = stackLayout3;
        this.lblStatus = label5;
        bindable24.SetValue(Page.IconProperty, new FileImageSourceConverter().ConvertFromInvariantString("ic_action_checklist"));
        bindable22.SetValue(View.MarginProperty, (object) new Thickness(5.0));
        bindable22.SetValue(View.VerticalOptionsProperty, (object) LayoutOptions.FillAndExpand);
        pullToRefreshLayout.SetValue(PullToRefreshLayout.IsPullToRefreshEnabledProperty, (object) true);
        bindable21.SetValue(View.VerticalOptionsProperty, (object) LayoutOptions.FillAndExpand);
        stackLayout2.SetValue(VisualElement.IsVisibleProperty, new VisualElement.VisibilityConverter().ConvertFromInvariantString("False"));
        bindable12.SetValue(View.MarginProperty, (object) new Thickness(10.0));
        bindable12.SetValue(Frame.HasShadowProperty, (object) true);
        bindable1.Tapped += new EventHandler(bindable24.Curriculum_Tapped);
        bindable12.GestureRecognizers.Add((IGestureRecognizer) bindable1);
        bindable11.SetValue(StackLayout.SpacingProperty, (object) 0.0);
        resourceExtension1.Key = "microLabel";
        StaticResourceExtension resourceExtension9 = resourceExtension1;
        XamlServiceProvider xamlServiceProvider1 = new XamlServiceProvider();
        Type type1 = typeof (IProvideValueTarget);
        object[] objectAndParents1 = new object[0 + 9];
        objectAndParents1[0] = (object) label1;
        objectAndParents1[1] = (object) bindable11;
        objectAndParents1[2] = (object) bindable12;
        objectAndParents1[3] = (object) stackLayout2;
        objectAndParents1[4] = (object) bindable21;
        objectAndParents1[5] = (object) pullToRefreshLayout;
        objectAndParents1[6] = (object) bindable22;
        objectAndParents1[7] = (object) bindable23;
        objectAndParents1[8] = (object) bindable24;
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
        XamlTypeResolver service2 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver1, typeof (StudentCheckList).GetTypeInfo().Assembly);
        xamlServiceProvider1.Add(type2, (object) service2);
        xamlServiceProvider1.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(28, 66)));
        object obj1 = resourceExtension9.ProvideValue((IServiceProvider) xamlServiceProvider1);
        label1.Style = (Style) obj1;
        label1.SetValue(Label.FontFamilyProperty, (object) "Roboto-Regular.ttf#Roboto");
        bindable11.Children.Add((View) label1);
        bindable3.SetValue(StackLayout.OrientationProperty, (object) StackOrientation.Horizontal);
        resourceExtension2.Key = "normalHeader";
        StaticResourceExtension resourceExtension10 = resourceExtension2;
        XamlServiceProvider xamlServiceProvider2 = new XamlServiceProvider();
        Type type3 = typeof (IProvideValueTarget);
        object[] objectAndParents2 = new object[0 + 10];
        objectAndParents2[0] = (object) label2;
        objectAndParents2[1] = (object) bindable3;
        objectAndParents2[2] = (object) bindable11;
        objectAndParents2[3] = (object) bindable12;
        objectAndParents2[4] = (object) stackLayout2;
        objectAndParents2[5] = (object) bindable21;
        objectAndParents2[6] = (object) pullToRefreshLayout;
        objectAndParents2[7] = (object) bindable22;
        objectAndParents2[8] = (object) bindable23;
        objectAndParents2[9] = (object) bindable24;
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
        XamlTypeResolver service4 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver2, typeof (StudentCheckList).GetTypeInfo().Assembly);
        xamlServiceProvider2.Add(type4, (object) service4);
        xamlServiceProvider2.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(31, 71)));
        object obj2 = resourceExtension10.ProvideValue((IServiceProvider) xamlServiceProvider2);
        label2.Style = (Style) obj2;
        label2.SetValue(Label.TextColorProperty, (object) new Color(0.250980406999588, 0.250980406999588, 0.250980406999588, 1.0));
        label2.SetValue(View.VerticalOptionsProperty, (object) LayoutOptions.Center);
        label2.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.FillAndExpand);
        bindable3.Children.Add((View) label2);
        bindable2.SetValue(Image.SourceProperty, new Xamarin.Forms.ImageSourceConverter().ConvertFromInvariantString("ic_info_outline"));
        bindable2.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.End);
        bindable3.Children.Add((View) bindable2);
        bindable11.Children.Add((View) bindable3);
        bindable4.SetValue(BoxView.ColorProperty, (object) new Color(0.905882358551025, 0.752941191196442, 0.113725490868092, 1.0));
        bindable4.SetValue(VisualElement.HeightRequestProperty, (object) 1.5);
        bindable4.SetValue(View.MarginProperty, (object) new Thickness(0.0, 5.0, 0.0, 5.0));
        bindable4.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.FillAndExpand);
        bindable11.Children.Add((View) bindable4);
        bindable5.SetValue(Span.TextProperty, (object) "Total Units:");
        Span span4 = bindable5;
        BindableProperty fontSizeProperty1 = Span.FontSizeProperty;
        FontSizeConverter fontSizeConverter1 = new FontSizeConverter();
        XamlServiceProvider xamlServiceProvider3 = new XamlServiceProvider();
        Type type5 = typeof (IProvideValueTarget);
        object[] objectAndParents3 = new object[0 + 11];
        objectAndParents3[0] = (object) bindable5;
        objectAndParents3[1] = (object) bindable9;
        objectAndParents3[2] = (object) bindable10;
        objectAndParents3[3] = (object) bindable11;
        objectAndParents3[4] = (object) bindable12;
        objectAndParents3[5] = (object) stackLayout2;
        objectAndParents3[6] = (object) bindable21;
        objectAndParents3[7] = (object) pullToRefreshLayout;
        objectAndParents3[8] = (object) bindable22;
        objectAndParents3[9] = (object) bindable23;
        objectAndParents3[10] = (object) bindable24;
        SimpleValueTargetProvider service5 = new SimpleValueTargetProvider(objectAndParents3, (object) Span.FontSizeProperty);
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
        XamlTypeResolver service6 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver3, typeof (StudentCheckList).GetTypeInfo().Assembly);
        xamlServiceProvider3.Add(type6, (object) service6);
        xamlServiceProvider3.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(42, 75)));
        object obj3 = ((IExtendedTypeConverter) fontSizeConverter1).ConvertFromInvariantString("Small", (IServiceProvider) xamlServiceProvider3);
        span4.SetValue(fontSizeProperty1, obj3);
        bindable5.SetValue(Span.FontFamilyProperty, (object) "Roboto-Regular.ttf#Roboto");
        bindable5.SetValue(Span.TextColorProperty, (object) new Color(0.250980406999588, 0.250980406999588, 0.250980406999588, 1.0));
        bindable9.Spans.Add(bindable5);
        Span span5 = span1;
        BindableProperty fontSizeProperty2 = Span.FontSizeProperty;
        FontSizeConverter fontSizeConverter2 = new FontSizeConverter();
        XamlServiceProvider xamlServiceProvider4 = new XamlServiceProvider();
        Type type7 = typeof (IProvideValueTarget);
        object[] objectAndParents4 = new object[0 + 11];
        objectAndParents4[0] = (object) span1;
        objectAndParents4[1] = (object) bindable9;
        objectAndParents4[2] = (object) bindable10;
        objectAndParents4[3] = (object) bindable11;
        objectAndParents4[4] = (object) bindable12;
        objectAndParents4[5] = (object) stackLayout2;
        objectAndParents4[6] = (object) bindable21;
        objectAndParents4[7] = (object) pullToRefreshLayout;
        objectAndParents4[8] = (object) bindable22;
        objectAndParents4[9] = (object) bindable23;
        objectAndParents4[10] = (object) bindable24;
        SimpleValueTargetProvider service7 = new SimpleValueTargetProvider(objectAndParents4, (object) Span.FontSizeProperty);
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
        XamlTypeResolver service8 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver4, typeof (StudentCheckList).GetTypeInfo().Assembly);
        xamlServiceProvider4.Add(type8, (object) service8);
        xamlServiceProvider4.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(44, 76)));
        object obj4 = ((IExtendedTypeConverter) fontSizeConverter2).ConvertFromInvariantString("Small", (IServiceProvider) xamlServiceProvider4);
        span5.SetValue(fontSizeProperty2, obj4);
        span1.SetValue(Span.ForegroundColorProperty, (object) new Color(0.0431372560560703, 0.341176480054855, 0.576470613479614, 1.0));
        span1.SetValue(Span.FontFamilyProperty, (object) "Roboto-Medium.ttf#Roboto");
        span1.SetValue(Span.TextColorProperty, (object) new Color(0.250980406999588, 0.250980406999588, 0.250980406999588, 1.0));
        bindable9.Spans.Add(span1);
        bindable6.SetValue(Span.TextProperty, (object) " required, ");
        Span span6 = bindable6;
        BindableProperty fontSizeProperty3 = Span.FontSizeProperty;
        FontSizeConverter fontSizeConverter3 = new FontSizeConverter();
        XamlServiceProvider xamlServiceProvider5 = new XamlServiceProvider();
        Type type9 = typeof (IProvideValueTarget);
        object[] objectAndParents5 = new object[0 + 11];
        objectAndParents5[0] = (object) bindable6;
        objectAndParents5[1] = (object) bindable9;
        objectAndParents5[2] = (object) bindable10;
        objectAndParents5[3] = (object) bindable11;
        objectAndParents5[4] = (object) bindable12;
        objectAndParents5[5] = (object) stackLayout2;
        objectAndParents5[6] = (object) bindable21;
        objectAndParents5[7] = (object) pullToRefreshLayout;
        objectAndParents5[8] = (object) bindable22;
        objectAndParents5[9] = (object) bindable23;
        objectAndParents5[10] = (object) bindable24;
        SimpleValueTargetProvider service9 = new SimpleValueTargetProvider(objectAndParents5, (object) Span.FontSizeProperty);
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
        XamlTypeResolver service10 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver5, typeof (StudentCheckList).GetTypeInfo().Assembly);
        xamlServiceProvider5.Add(type10, (object) service10);
        xamlServiceProvider5.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(45, 74)));
        object obj5 = ((IExtendedTypeConverter) fontSizeConverter3).ConvertFromInvariantString("Small", (IServiceProvider) xamlServiceProvider5);
        span6.SetValue(fontSizeProperty3, obj5);
        bindable6.SetValue(Span.FontFamilyProperty, (object) "Roboto-Regular.ttf#Roboto");
        bindable6.SetValue(Span.TextColorProperty, (object) new Color(0.250980406999588, 0.250980406999588, 0.250980406999588, 1.0));
        bindable9.Spans.Add(bindable6);
        Span span7 = span2;
        BindableProperty fontSizeProperty4 = Span.FontSizeProperty;
        FontSizeConverter fontSizeConverter4 = new FontSizeConverter();
        XamlServiceProvider xamlServiceProvider6 = new XamlServiceProvider();
        Type type11 = typeof (IProvideValueTarget);
        object[] objectAndParents6 = new object[0 + 11];
        objectAndParents6[0] = (object) span2;
        objectAndParents6[1] = (object) bindable9;
        objectAndParents6[2] = (object) bindable10;
        objectAndParents6[3] = (object) bindable11;
        objectAndParents6[4] = (object) bindable12;
        objectAndParents6[5] = (object) stackLayout2;
        objectAndParents6[6] = (object) bindable21;
        objectAndParents6[7] = (object) pullToRefreshLayout;
        objectAndParents6[8] = (object) bindable22;
        objectAndParents6[9] = (object) bindable23;
        objectAndParents6[10] = (object) bindable24;
        SimpleValueTargetProvider service11 = new SimpleValueTargetProvider(objectAndParents6, (object) Span.FontSizeProperty);
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
        XamlTypeResolver service12 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver6, typeof (StudentCheckList).GetTypeInfo().Assembly);
        xamlServiceProvider6.Add(type12, (object) service12);
        xamlServiceProvider6.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(47, 73)));
        object obj6 = ((IExtendedTypeConverter) fontSizeConverter4).ConvertFromInvariantString("Small", (IServiceProvider) xamlServiceProvider6);
        span7.SetValue(fontSizeProperty4, obj6);
        span2.SetValue(Span.ForegroundColorProperty, (object) new Color(0.0431372560560703, 0.341176480054855, 0.576470613479614, 1.0));
        span2.SetValue(Span.FontFamilyProperty, (object) "Roboto-Medium.ttf#Roboto");
        span2.SetValue(Span.TextColorProperty, (object) new Color(0.250980406999588, 0.250980406999588, 0.250980406999588, 1.0));
        bindable9.Spans.Add(span2);
        bindable7.SetValue(Span.TextProperty, (object) " taken, ");
        Span span8 = bindable7;
        BindableProperty fontSizeProperty5 = Span.FontSizeProperty;
        FontSizeConverter fontSizeConverter5 = new FontSizeConverter();
        XamlServiceProvider xamlServiceProvider7 = new XamlServiceProvider();
        Type type13 = typeof (IProvideValueTarget);
        object[] objectAndParents7 = new object[0 + 11];
        objectAndParents7[0] = (object) bindable7;
        objectAndParents7[1] = (object) bindable9;
        objectAndParents7[2] = (object) bindable10;
        objectAndParents7[3] = (object) bindable11;
        objectAndParents7[4] = (object) bindable12;
        objectAndParents7[5] = (object) stackLayout2;
        objectAndParents7[6] = (object) bindable21;
        objectAndParents7[7] = (object) pullToRefreshLayout;
        objectAndParents7[8] = (object) bindable22;
        objectAndParents7[9] = (object) bindable23;
        objectAndParents7[10] = (object) bindable24;
        SimpleValueTargetProvider service13 = new SimpleValueTargetProvider(objectAndParents7, (object) Span.FontSizeProperty);
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
        XamlTypeResolver service14 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver7, typeof (StudentCheckList).GetTypeInfo().Assembly);
        xamlServiceProvider7.Add(type14, (object) service14);
        xamlServiceProvider7.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(48, 71)));
        object obj7 = ((IExtendedTypeConverter) fontSizeConverter5).ConvertFromInvariantString("Small", (IServiceProvider) xamlServiceProvider7);
        span8.SetValue(fontSizeProperty5, obj7);
        bindable7.SetValue(Span.FontFamilyProperty, (object) "Roboto-Regular.ttf#Roboto");
        bindable7.SetValue(Span.TextColorProperty, (object) new Color(0.250980406999588, 0.250980406999588, 0.250980406999588, 1.0));
        bindable9.Spans.Add(bindable7);
        Span span9 = span3;
        BindableProperty fontSizeProperty6 = Span.FontSizeProperty;
        FontSizeConverter fontSizeConverter6 = new FontSizeConverter();
        XamlServiceProvider xamlServiceProvider8 = new XamlServiceProvider();
        Type type15 = typeof (IProvideValueTarget);
        object[] objectAndParents8 = new object[0 + 11];
        objectAndParents8[0] = (object) span3;
        objectAndParents8[1] = (object) bindable9;
        objectAndParents8[2] = (object) bindable10;
        objectAndParents8[3] = (object) bindable11;
        objectAndParents8[4] = (object) bindable12;
        objectAndParents8[5] = (object) stackLayout2;
        objectAndParents8[6] = (object) bindable21;
        objectAndParents8[7] = (object) pullToRefreshLayout;
        objectAndParents8[8] = (object) bindable22;
        objectAndParents8[9] = (object) bindable23;
        objectAndParents8[10] = (object) bindable24;
        SimpleValueTargetProvider service15 = new SimpleValueTargetProvider(objectAndParents8, (object) Span.FontSizeProperty);
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
        XamlTypeResolver service16 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver8, typeof (StudentCheckList).GetTypeInfo().Assembly);
        xamlServiceProvider8.Add(type16, (object) service16);
        xamlServiceProvider8.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(50, 74)));
        object obj8 = ((IExtendedTypeConverter) fontSizeConverter6).ConvertFromInvariantString("Small", (IServiceProvider) xamlServiceProvider8);
        span9.SetValue(fontSizeProperty6, obj8);
        span3.SetValue(Span.ForegroundColorProperty, (object) new Color(0.0431372560560703, 0.341176480054855, 0.576470613479614, 1.0));
        span3.SetValue(Span.FontFamilyProperty, (object) "Roboto-Medium.ttf#Roboto");
        span3.SetValue(Span.TextColorProperty, (object) new Color(0.250980406999588, 0.250980406999588, 0.250980406999588, 1.0));
        bindable9.Spans.Add(span3);
        bindable8.SetValue(Span.TextProperty, (object) " needed ");
        Span span10 = bindable8;
        BindableProperty fontSizeProperty7 = Span.FontSizeProperty;
        FontSizeConverter fontSizeConverter7 = new FontSizeConverter();
        XamlServiceProvider xamlServiceProvider9 = new XamlServiceProvider();
        Type type17 = typeof (IProvideValueTarget);
        object[] objectAndParents9 = new object[0 + 11];
        objectAndParents9[0] = (object) bindable8;
        objectAndParents9[1] = (object) bindable9;
        objectAndParents9[2] = (object) bindable10;
        objectAndParents9[3] = (object) bindable11;
        objectAndParents9[4] = (object) bindable12;
        objectAndParents9[5] = (object) stackLayout2;
        objectAndParents9[6] = (object) bindable21;
        objectAndParents9[7] = (object) pullToRefreshLayout;
        objectAndParents9[8] = (object) bindable22;
        objectAndParents9[9] = (object) bindable23;
        objectAndParents9[10] = (object) bindable24;
        SimpleValueTargetProvider service17 = new SimpleValueTargetProvider(objectAndParents9, (object) Span.FontSizeProperty);
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
        XamlTypeResolver service18 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver9, typeof (StudentCheckList).GetTypeInfo().Assembly);
        xamlServiceProvider9.Add(type18, (object) service18);
        xamlServiceProvider9.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(51, 71)));
        object obj9 = ((IExtendedTypeConverter) fontSizeConverter7).ConvertFromInvariantString("Small", (IServiceProvider) xamlServiceProvider9);
        span10.SetValue(fontSizeProperty7, obj9);
        bindable8.SetValue(Span.FontFamilyProperty, (object) "Roboto-Regular.ttf#Roboto");
        bindable8.SetValue(Span.TextColorProperty, (object) new Color(0.250980406999588, 0.250980406999588, 0.250980406999588, 1.0));
        bindable9.Spans.Add(bindable8);
        bindable10.SetValue(Label.FormattedTextProperty, (object) bindable9);
        bindable11.Children.Add((View) bindable10);
        bindable12.SetValue(ContentView.ContentProperty, (object) bindable11);
        stackLayout2.Children.Add((View) bindable12);
        bindable19.SetValue(StackLayout.OrientationProperty, (object) StackOrientation.Horizontal);
        bindable19.SetValue(View.MarginProperty, (object) new Thickness(10.0, 0.0, 10.0, 5.0));
        bindable19.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.EndAndExpand);
        bindable13.SetValue(Image.SourceProperty, new Xamarin.Forms.ImageSourceConverter().ConvertFromInvariantString("ic_check"));
        bindable13.SetValue(VisualElement.HeightRequestProperty, (object) 15.0);
        bindable19.Children.Add((View) bindable13);
        bindable14.SetValue(Label.TextProperty, (object) "Taken");
        resourceExtension3.Key = "smallHeader";
        StaticResourceExtension resourceExtension11 = resourceExtension3;
        XamlServiceProvider xamlServiceProvider10 = new XamlServiceProvider();
        Type type19 = typeof (IProvideValueTarget);
        object[] objectAndParents10 = new object[0 + 8];
        objectAndParents10[0] = (object) bindable14;
        objectAndParents10[1] = (object) bindable19;
        objectAndParents10[2] = (object) stackLayout2;
        objectAndParents10[3] = (object) bindable21;
        objectAndParents10[4] = (object) pullToRefreshLayout;
        objectAndParents10[5] = (object) bindable22;
        objectAndParents10[6] = (object) bindable23;
        objectAndParents10[7] = (object) bindable24;
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
        namespaceResolver10.Add("controls", "clr-namespace:Refractored.XamForms.PullToRefresh;assembly=Refractored.XamForms.PullToRefresh");
        XamlTypeResolver service20 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver10, typeof (StudentCheckList).GetTypeInfo().Assembly);
        xamlServiceProvider10.Add(type20, (object) service20);
        xamlServiceProvider10.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(63, 53)));
        object obj10 = resourceExtension11.ProvideValue((IServiceProvider) xamlServiceProvider10);
        bindable14.Style = (Style) obj10;
        bindable14.SetValue(Label.TextColorProperty, (object) new Color(0.250980406999588, 0.250980406999588, 0.250980406999588, 1.0));
        bindable14.SetValue(View.VerticalOptionsProperty, (object) LayoutOptions.Center);
        bindable19.Children.Add((View) bindable14);
        bindable15.SetValue(Image.SourceProperty, new Xamarin.Forms.ImageSourceConverter().ConvertFromInvariantString("ic_in_progress"));
        bindable15.SetValue(VisualElement.HeightRequestProperty, (object) 15.0);
        bindable19.Children.Add((View) bindable15);
        bindable16.SetValue(Label.TextProperty, (object) "In-progress");
        resourceExtension4.Key = "smallHeader";
        StaticResourceExtension resourceExtension12 = resourceExtension4;
        XamlServiceProvider xamlServiceProvider11 = new XamlServiceProvider();
        Type type21 = typeof (IProvideValueTarget);
        object[] objectAndParents11 = new object[0 + 8];
        objectAndParents11[0] = (object) bindable16;
        objectAndParents11[1] = (object) bindable19;
        objectAndParents11[2] = (object) stackLayout2;
        objectAndParents11[3] = (object) bindable21;
        objectAndParents11[4] = (object) pullToRefreshLayout;
        objectAndParents11[5] = (object) bindable22;
        objectAndParents11[6] = (object) bindable23;
        objectAndParents11[7] = (object) bindable24;
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
        XamlTypeResolver service22 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver11, typeof (StudentCheckList).GetTypeInfo().Assembly);
        xamlServiceProvider11.Add(type22, (object) service22);
        xamlServiceProvider11.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(66, 59)));
        object obj11 = resourceExtension12.ProvideValue((IServiceProvider) xamlServiceProvider11);
        bindable16.Style = (Style) obj11;
        bindable16.SetValue(Label.TextColorProperty, (object) new Color(0.250980406999588, 0.250980406999588, 0.250980406999588, 1.0));
        bindable16.SetValue(View.VerticalOptionsProperty, (object) LayoutOptions.Center);
        bindable19.Children.Add((View) bindable16);
        bindable17.SetValue(Image.SourceProperty, new Xamarin.Forms.ImageSourceConverter().ConvertFromInvariantString("ic_not_started"));
        bindable17.SetValue(VisualElement.HeightRequestProperty, (object) 15.0);
        bindable19.Children.Add((View) bindable17);
        bindable18.SetValue(Label.TextProperty, (object) "Not Yet Taken");
        resourceExtension5.Key = "smallHeader";
        StaticResourceExtension resourceExtension13 = resourceExtension5;
        XamlServiceProvider xamlServiceProvider12 = new XamlServiceProvider();
        Type type23 = typeof (IProvideValueTarget);
        object[] objectAndParents12 = new object[0 + 8];
        objectAndParents12[0] = (object) bindable18;
        objectAndParents12[1] = (object) bindable19;
        objectAndParents12[2] = (object) stackLayout2;
        objectAndParents12[3] = (object) bindable21;
        objectAndParents12[4] = (object) pullToRefreshLayout;
        objectAndParents12[5] = (object) bindable22;
        objectAndParents12[6] = (object) bindable23;
        objectAndParents12[7] = (object) bindable24;
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
        XamlTypeResolver service24 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver12, typeof (StudentCheckList).GetTypeInfo().Assembly);
        xamlServiceProvider12.Add(type24, (object) service24);
        xamlServiceProvider12.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(69, 61)));
        object obj12 = resourceExtension13.ProvideValue((IServiceProvider) xamlServiceProvider12);
        bindable18.Style = (Style) obj12;
        bindable18.SetValue(Label.TextColorProperty, (object) new Color(0.250980406999588, 0.250980406999588, 0.250980406999588, 1.0));
        bindable18.SetValue(View.VerticalOptionsProperty, (object) LayoutOptions.Center);
        bindable19.Children.Add((View) bindable18);
        stackLayout2.Children.Add((View) bindable19);
        stackLayout1.SetValue(View.MarginProperty, (object) new Thickness(10.0, 0.0, 10.0, 10.0));
        stackLayout2.Children.Add((View) stackLayout1);
        label3.SetValue(View.MarginProperty, (object) new Thickness(15.0));
        label3.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.Center);
        label3.SetValue(View.VerticalOptionsProperty, (object) LayoutOptions.EndAndExpand);
        resourceExtension6.Key = "microLabel";
        StaticResourceExtension resourceExtension14 = resourceExtension6;
        XamlServiceProvider xamlServiceProvider13 = new XamlServiceProvider();
        Type type25 = typeof (IProvideValueTarget);
        object[] objectAndParents13 = new object[0 + 7];
        objectAndParents13[0] = (object) label3;
        objectAndParents13[1] = (object) stackLayout2;
        objectAndParents13[2] = (object) bindable21;
        objectAndParents13[3] = (object) pullToRefreshLayout;
        objectAndParents13[4] = (object) bindable22;
        objectAndParents13[5] = (object) bindable23;
        objectAndParents13[6] = (object) bindable24;
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
        XamlTypeResolver service26 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver13, typeof (StudentCheckList).GetTypeInfo().Assembly);
        xamlServiceProvider13.Add(type26, (object) service26);
        xamlServiceProvider13.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(74, 127)));
        object obj13 = resourceExtension14.ProvideValue((IServiceProvider) xamlServiceProvider13);
        label3.Style = (Style) obj13;
        label3.SetValue(Label.FontFamilyProperty, (object) "Roboto-Regular.ttf#Roboto");
        stackLayout2.Children.Add((View) label3);
        frame.SetValue(View.MarginProperty, (object) new Thickness(15.0));
        frame.SetValue(Layout.PaddingProperty, (object) new Thickness(15.0));
        frame.SetValue(Frame.CornerRadiusProperty, (object) 5f);
        frame.SetValue(Frame.HasShadowProperty, (object) true);
        label4.SetValue(Label.TextProperty, (object) "Apologies, the server is undergoing maintenance.");
        resourceExtension7.Key = "smallLabel";
        StaticResourceExtension resourceExtension15 = resourceExtension7;
        XamlServiceProvider xamlServiceProvider14 = new XamlServiceProvider();
        Type type27 = typeof (IProvideValueTarget);
        object[] objectAndParents14 = new object[0 + 9];
        objectAndParents14[0] = (object) label4;
        objectAndParents14[1] = (object) bindable20;
        objectAndParents14[2] = (object) frame;
        objectAndParents14[3] = (object) stackLayout2;
        objectAndParents14[4] = (object) bindable21;
        objectAndParents14[5] = (object) pullToRefreshLayout;
        objectAndParents14[6] = (object) bindable22;
        objectAndParents14[7] = (object) bindable23;
        objectAndParents14[8] = (object) bindable24;
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
        namespaceResolver14.Add("controls", "clr-namespace:Refractored.XamForms.PullToRefresh;assembly=Refractored.XamForms.PullToRefresh");
        XamlTypeResolver service28 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver14, typeof (StudentCheckList).GetTypeInfo().Assembly);
        xamlServiceProvider14.Add(type28, (object) service28);
        xamlServiceProvider14.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(79, 124)));
        object obj14 = resourceExtension15.ProvideValue((IServiceProvider) xamlServiceProvider14);
        label4.Style = (Style) obj14;
        label4.SetValue(Label.TextColorProperty, (object) new Color(0.250980406999588, 0.250980406999588, 0.250980406999588, 1.0));
        label4.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.FillAndExpand);
        bindable20.Children.Add((View) label4);
        frame.SetValue(ContentView.ContentProperty, (object) bindable20);
        stackLayout2.Children.Add((View) frame);
        bindable21.Content = (View) stackLayout2;
        pullToRefreshLayout.SetValue(ContentView.ContentProperty, (object) bindable21);
        bindable22.Children.Add((View) pullToRefreshLayout);
        bindable23.Children.Add((View) bindable22);
        stackLayout3.SetValue(VisualElement.BackgroundColorProperty, (object) new Color(0.180392161011696, 0.192156866192818, 0.192156866192818, 1.0));
        stackLayout3.SetValue(VisualElement.IsVisibleProperty, new VisualElement.VisibilityConverter().ConvertFromInvariantString("False"));
        stackLayout3.SetValue(View.VerticalOptionsProperty, (object) LayoutOptions.End);
        stackLayout3.SetValue(Layout.PaddingProperty, (object) new Thickness(3.0));
        stackLayout3.SetValue(View.MarginProperty, (object) new Thickness(0.0));
        label5.SetValue(Label.TextProperty, (object) "No connection");
        resourceExtension8.Key = "microLabel";
        StaticResourceExtension resourceExtension16 = resourceExtension8;
        XamlServiceProvider xamlServiceProvider15 = new XamlServiceProvider();
        Type type29 = typeof (IProvideValueTarget);
        object[] objectAndParents15 = new object[0 + 4];
        objectAndParents15[0] = (object) label5;
        objectAndParents15[1] = (object) stackLayout3;
        objectAndParents15[2] = (object) bindable23;
        objectAndParents15[3] = (object) bindable24;
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
        namespaceResolver15.Add("controls", "clr-namespace:Refractored.XamForms.PullToRefresh;assembly=Refractored.XamForms.PullToRefresh");
        XamlTypeResolver service30 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver15, typeof (StudentCheckList).GetTypeInfo().Assembly);
        xamlServiceProvider15.Add(type30, (object) service30);
        xamlServiceProvider15.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(93, 64)));
        object obj15 = resourceExtension16.ProvideValue((IServiceProvider) xamlServiceProvider15);
        label5.Style = (Style) obj15;
        Label label6 = label5;
        BindableProperty fontSizeProperty8 = Label.FontSizeProperty;
        FontSizeConverter fontSizeConverter8 = new FontSizeConverter();
        XamlServiceProvider xamlServiceProvider16 = new XamlServiceProvider();
        Type type31 = typeof (IProvideValueTarget);
        object[] objectAndParents16 = new object[0 + 4];
        objectAndParents16[0] = (object) label5;
        objectAndParents16[1] = (object) stackLayout3;
        objectAndParents16[2] = (object) bindable23;
        objectAndParents16[3] = (object) bindable24;
        SimpleValueTargetProvider service31 = new SimpleValueTargetProvider(objectAndParents16, (object) Label.FontSizeProperty);
        xamlServiceProvider16.Add(type31, (object) service31);
        xamlServiceProvider16.Add(typeof (INameScopeProvider), (object) new NameScopeProvider()
        {
          NameScope = (INameScope) nameScope
        });
        Type type32 = typeof (IXamlTypeResolver);
        XmlNamespaceResolver namespaceResolver16 = new XmlNamespaceResolver();
        namespaceResolver16.Add("", "http://xamarin.com/schemas/2014/forms");
        namespaceResolver16.Add("x", "http://schemas.microsoft.com/winfx/2009/xaml");
        namespaceResolver16.Add("controls", "clr-namespace:Refractored.XamForms.PullToRefresh;assembly=Refractored.XamForms.PullToRefresh");
        XamlTypeResolver service32 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver16, typeof (StudentCheckList).GetTypeInfo().Assembly);
        xamlServiceProvider16.Add(type32, (object) service32);
        xamlServiceProvider16.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(93, 100)));
        object obj16 = ((IExtendedTypeConverter) fontSizeConverter8).ConvertFromInvariantString("12", (IServiceProvider) xamlServiceProvider16);
        label6.SetValue(fontSizeProperty8, obj16);
        label5.SetValue(Label.TextColorProperty, (object) new Color(1.0, 1.0, 1.0, 1.0));
        label5.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.Center);
        stackLayout3.Children.Add((View) label5);
        bindable23.Children.Add((View) stackLayout3);
        bindable24.SetValue(ContentPage.ContentProperty, (object) bindable23);
      }
    }

    private void __InitComponentRuntime()
    {
      this.LoadFromXaml<StudentCheckList>(typeof (StudentCheckList));
      this.refreshChecklist = NameScopeExtensions.FindByName<PullToRefreshLayout>(this, "refreshChecklist");
      this.stackBody = NameScopeExtensions.FindByName<StackLayout>(this, "stackBody");
      this.lblProcessed = NameScopeExtensions.FindByName<Label>(this, "lblProcessed");
      this.lblCurriculum = NameScopeExtensions.FindByName<Label>(this, "lblCurriculum");
      this.lblRequired = NameScopeExtensions.FindByName<Span>(this, "lblRequired");
      this.lblTaken = NameScopeExtensions.FindByName<Span>(this, "lblTaken");
      this.lblNeeded = NameScopeExtensions.FindByName<Span>(this, "lblNeeded");
      this.stackSchoolTerm = NameScopeExtensions.FindByName<StackLayout>(this, "stackSchoolTerm");
      this.lblLastSync = NameScopeExtensions.FindByName<Label>(this, "lblLastSync");
      this.frameServerDown = NameScopeExtensions.FindByName<Frame>(this, "frameServerDown");
      this.lblServerDown = NameScopeExtensions.FindByName<Label>(this, "lblServerDown");
      this.stackStatus = NameScopeExtensions.FindByName<StackLayout>(this, "stackStatus");
      this.lblStatus = NameScopeExtensions.FindByName<Label>(this, "lblStatus");
    }
  }
}
