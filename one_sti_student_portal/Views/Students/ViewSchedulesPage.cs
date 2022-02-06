// Decompiled with JetBrains decompiler
// Type: one_sti_student_portal.Views.Students.ViewSchedulesPage
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
using System.Collections;
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
  [XamlFilePath("Views\\Students\\ViewSchedulesPage.xaml")]
  public class ViewSchedulesPage : ContentPage
  {
    private ViewSchedulesPage.ListProperty _listPropertyClass;
    private List<Color> _listColors;
    private List<string> _listDays;
    private string _currentSemester;
    private string serverStatus;
    private bool _isConnected;
    private bool _refreshContent;
    private bool _isBusy;
    private StudentData _studentData;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private StackLayout stackScheduleDay;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private Label lblDay;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private Image imgPullDownTerms;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private Picker pckrDays;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private PullToRefreshLayout refresNoClass;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private StackLayout stackNoClass;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private Label lblNoClass;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private PullToRefreshLayout refreshSchedule;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private ListView ScheduleList;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private Label lblAsOf;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private Label lblLastSync;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private StackLayout stackStatus;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private Label lblStatus;

    public ViewSchedulesPage(bool refrehContent)
    {
      this.InitializeComponent();
      this._studentData = new StudentData();
      this._listPropertyClass = new ViewSchedulesPage.ListProperty();
      this._refreshContent = refrehContent;
      this.LoadSemester();
      this.LoadDays();
      this.LoadSchedule();
      this._isConnected = ConnectionHelper.IsConnected();
      Connectivity.ConnectivityChanged += (EventHandler<ConnectivityChangedEventArgs>) ((sender, args) =>
      {
        this._isConnected = ConnectionHelper.IsConnected();
        this.CheckStatus();
      });
      this.refreshSchedule.RefreshCommand = (ICommand) new Command((Action) (() => this.RefreshContent()));
      this.refresNoClass.RefreshCommand = (ICommand) new Command((Action) (() => this.RefreshContent()));
      switch (Device.RuntimePlatform)
      {
        case "Android":
          this.ToolbarItems.Add(new ToolbarItem("", "ic_action_info", (Action) (() => this.DisplayAlert("Class schedule ", "Missing time, room number, or questionable subject periods?" + Environment.NewLine + Environment.NewLine + "Confirm your class schedules through the Registrar’s Office.", "OK"))));
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
      Device.BeginInvokeOnMainThread((Action) (() => this.refreshSchedule.IsRefreshing = true));
      Task.Run((Func<Task>) (async () =>
      {
        ViewSchedulesPage viewSchedulesPage = this;
        string str1 = await viewSchedulesPage.ServerStatusAsync();
        viewSchedulesPage.serverStatus = str1;
        if (!(viewSchedulesPage.serverStatus == "true") || !ConnectionHelper.IsConnected() || viewSchedulesPage._isBusy)
          return;
        viewSchedulesPage._isBusy = true;
        StudentService studentService = new StudentService();
        StudentInformation studentInfo = viewSchedulesPage._studentData.GetStudentInformation().Result.FirstOrDefault<StudentInformation>();
        StudentSemester latestSemester = viewSchedulesPage._studentData.GetLatestSemester().Result.FirstOrDefault<StudentSemester>();
        await viewSchedulesPage._studentData.DeleteSchedule(latestSemester.Semester);
        await viewSchedulesPage._studentData.DownloadSchedulePerSem(studentInfo.PSCSId, latestSemester.Semester);
        string str2 = await new StudentService().SendLog(new AppLogModel()
        {
          PSCSId = studentInfo.PSCSId,
          IPAddress = "null",
          Medium = "Mobile",
          AppVersion = Constants.VersionName,
          NumOfRequests = 1,
          DateAccessed = DateTime.Now.ToString("MM/dd/yyyy hh:mm tt"),
          ViewName = viewSchedulesPage.GetType().Name + " RefreshContent()",
          Campus = studentInfo.Campus
        });
        studentInfo = (StudentInformation) null;
        latestSemester = (StudentSemester) null;
      })).ContinueWith((Action<Task>) (result => Device.BeginInvokeOnMainThread((Action) (() =>
      {
        if (this.serverStatus == "true")
        {
          this.refreshSchedule.IsRefreshing = false;
          this.refresNoClass.IsRefreshing = false;
          if (!ConnectionHelper.IsConnected())
            Acr.UserDialogs.UserDialogs.Instance.Toast("Could not refresh. Check your network connection.");
          else if (this.pckrDays.SelectedItem.ToString() == "Entire Week")
            this.LoadAllSchedule();
          else
            this.LoadSchedule();
          this._isBusy = false;
        }
        else
        {
          this.refreshSchedule.IsRefreshing = false;
          this.refresNoClass.IsRefreshing = false;
          if (!ConnectionHelper.IsConnected())
            Acr.UserDialogs.UserDialogs.Instance.Toast("Could not refresh. Check your network connection.");
          this._isBusy = false;
        }
      }))));
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

    public void LoadSemester()
    {
      List<StudentSemester> result = this._studentData.GetLatestSemester().Result;
      this._currentSemester = result.Count != 0 ? result.FirstOrDefault<StudentSemester>().Semester : "";
    }

    public void LoadDays()
    {
      this._listDays = new List<string>()
      {
        "Monday",
        "Tuesday",
        "Wednesday",
        "Thursday",
        "Friday",
        "Saturday",
        "Sunday",
        "Entire Week"
      };
      this.pckrDays.Items.Clear();
      foreach (string listDay in this._listDays)
        this.pckrDays.Items.Add(listDay);
      if (this.pckrDays.Items.Count == 0)
        return;
      this.pckrDays.SelectedItem = (object) DateTime.Now.DayOfWeek.ToString();
      this.lblDay.Text = "Today | " + this.pckrDays.SelectedItem?.ToString();
    }

    public void LoadSchedule()
    {
      List<StudentSchedule> schedule = this._studentData.GetSchedule(this._currentSemester, this._listDays[this.pckrDays.SelectedIndex]);
      List<ViewSchedulesPage.ListProperty> listPropertyList1 = new List<ViewSchedulesPage.ListProperty>();
      listPropertyList1.Clear();
      int index = 0;
      this.FillColors();
      this.ScheduleList.Opacity = 0.0;
      foreach (StudentSchedule studentSchedule in schedule)
      {
        this.lblAsOf.IsVisible = true;
        this.lblAsOf.Text = "AS OF " + schedule.OrderByDescending<StudentSchedule, DateTime>((Func<StudentSchedule, DateTime>) (o => o.AddDate)).ToList<StudentSchedule>().FirstOrDefault<StudentSchedule>().AddDate.ToString("dd MMM, yyyy").ToUpper();
        Label lblLastSync = this.lblLastSync;
        DateTime dateTime = studentSchedule.UpdatedOn;
        string str1 = "LAST SYNC ON " + dateTime.ToString("dd MMM, yyyy hh:mm tt").ToUpper();
        lblLastSync.Text = str1;
        foreach (StudentSubjects studentSubjects in this._studentData.GetClassSubjectDetails(studentSchedule.ClassNumber).Result)
        {
          index = index == 7 ? 0 : index;
          string str2 = string.IsNullOrWhiteSpace(studentSchedule.RoomCode) ? "TBA" : studentSchedule.RoomCode;
          string upper = studentSubjects.Professor.ToUpper();
          string str3 = string.IsNullOrWhiteSpace(studentSubjects.Professor.ToUpper()) ? "TBA" : upper;
          List<ViewSchedulesPage.ListProperty> listPropertyList2 = listPropertyList1;
          ViewSchedulesPage.ListProperty listProperty = new ViewSchedulesPage.ListProperty();
          listProperty.tile_color = this._listColors[index];
          listProperty.dayVisible = false;
          dateTime = Convert.ToDateTime(studentSchedule.MeetingTimeStart);
          listProperty.time_start = dateTime.ToString("hh:mm tt");
          dateTime = Convert.ToDateTime(studentSchedule.MeetingTimeEnd);
          listProperty.time_end = "to " + dateTime.ToString("hh:mm tt");
          listProperty.subj_code = studentSubjects.SubjectCode.ToUpper() + " - " + str2;
          listProperty.instructor = str2 + " | " + str3;
          listProperty.subj_desc = studentSubjects.SubjectDesc;
          listPropertyList2.Add(listProperty);
          ++index;
        }
      }
      if (listPropertyList1.Count == 0)
      {
        this.refreshSchedule.IsVisible = false;
        this.ScheduleList.IsVisible = false;
        this.refresNoClass.IsVisible = true;
        this.lblNoClass.Text = "Your schedule is free today.";
      }
      else
      {
        this.refresNoClass.IsVisible = false;
        this.refreshSchedule.IsVisible = true;
        this.ScheduleList.IsVisible = true;
        this.ScheduleList.FadeTo(1.0, 500U);
        this.ScheduleList.ItemsSource = (IEnumerable) listPropertyList1;
      }
    }

    private void LoadAllSchedule()
    {
      int index1 = 0;
      int index2 = 0;
      List<ViewSchedulesPage.ListProperty> listPropertyList1 = new List<ViewSchedulesPage.ListProperty>();
      listPropertyList1.Clear();
      this.FillColors();
      this.ScheduleList.Opacity = 0.0;
      for (; index1 != 7; ++index1)
      {
        List<StudentSchedule> schedule = this._studentData.GetSchedule(this._currentSemester, this._listDays[index1]);
        foreach (StudentSchedule studentSchedule in schedule)
        {
          this.lblAsOf.IsVisible = true;
          Label lblAsOf = this.lblAsOf;
          DateTime dateTime = schedule.OrderByDescending<StudentSchedule, DateTime>((Func<StudentSchedule, DateTime>) (o => o.AddDate)).ToList<StudentSchedule>().FirstOrDefault<StudentSchedule>().AddDate;
          string str1 = "AS OF " + dateTime.ToString("dd MMM, yyyy").ToUpper();
          lblAsOf.Text = str1;
          Label lblLastSync = this.lblLastSync;
          dateTime = studentSchedule.UpdatedOn;
          string str2 = "LAST SYNC ON " + dateTime.ToString("dd MMM, yyyy hh:mm tt").ToUpper();
          lblLastSync.Text = str2;
          List<StudentSubjects> result = this._studentData.GetClassSubjectDetails(studentSchedule.ClassNumber).Result;
          index2 = index2 == 7 ? 0 : index2;
          string str3 = string.IsNullOrWhiteSpace(studentSchedule.RoomCode) ? "TBA" : studentSchedule.RoomCode;
          foreach (StudentSubjects studentSubjects in result)
          {
            string upper = studentSubjects.Professor.ToUpper();
            string str4 = string.IsNullOrWhiteSpace(studentSubjects.Professor.ToUpper()) ? "TBA" : upper;
            List<ViewSchedulesPage.ListProperty> listPropertyList2 = listPropertyList1;
            ViewSchedulesPage.ListProperty listProperty = new ViewSchedulesPage.ListProperty();
            listProperty.tile_color = this._listColors[index2];
            listProperty.day = this._listDays[index1].ToUpper();
            listProperty.dayVisible = true;
            dateTime = Convert.ToDateTime(studentSchedule.MeetingTimeStart);
            listProperty.time_start = dateTime.ToString("hh:mm tt");
            dateTime = Convert.ToDateTime(studentSchedule.MeetingTimeEnd);
            listProperty.time_end = "to " + dateTime.ToString("hh:mm tt");
            listProperty.subj_code = studentSubjects.SubjectCode.ToUpper() + " - " + str3;
            listProperty.instructor = str3 + " | " + str4;
            listProperty.subj_desc = studentSubjects.SubjectDesc;
            listPropertyList2.Add(listProperty);
            ++index2;
          }
        }
      }
      if (listPropertyList1.Count == 0)
      {
        this.refreshSchedule.IsVisible = false;
        this.ScheduleList.IsVisible = false;
        this.refresNoClass.IsVisible = true;
        this.lblNoClass.Text = "Your schedule is free today.";
      }
      else
      {
        this.refresNoClass.IsVisible = false;
        this.refreshSchedule.IsVisible = true;
        this.ScheduleList.IsVisible = true;
        this.ScheduleList.FadeTo(1.0, 500U);
        this.ScheduleList.ItemsSource = (IEnumerable) listPropertyList1;
      }
    }

    private void Schedules_Tapped(object sender, EventArgs e) => this.pckrDays.Focus();

    private void pckrDays_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.pckrDays.SelectedIndex == -1)
        return;
      this.lblDay.Text = !(this.pckrDays.SelectedItem.ToString() == DateTime.Now.DayOfWeek.ToString()) ? this.pckrDays.SelectedItem.ToString() : "Today | " + this.pckrDays.SelectedItem?.ToString();
      if (this.pckrDays.SelectedItem.ToString() != "Entire Week")
        this.LoadSchedule();
      else
        this.LoadAllSchedule();
    }

    protected override void OnAppearing()
    {
      base.OnAppearing();
      MessagingCenter.Send<MessageSender>(new MessageSender(), "MySchedule");
      this._isConnected = ConnectionHelper.IsConnected();
      if (this._isConnected)
        return;
      this.stackStatus.BackgroundColor = Color.FromHex("#2e3131");
      this.stackStatus.IsVisible = true;
      this.lblStatus.Text = "No connection";
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
      if (ResourceLoader.ResourceProvider != null && ResourceLoader.ResourceProvider(typeof (ViewSchedulesPage).GetTypeInfo().Assembly.GetName(), "Views/Students/ViewSchedulesPage.xaml") != null)
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
        Image bindable5 = new Image();
        StaticResourceExtension resourceExtension2 = new StaticResourceExtension();
        Label label2 = new Label();
        StackLayout bindable6 = new StackLayout();
        StackLayout stackLayout2 = new StackLayout();
        PullToRefreshLayout pullToRefreshLayout1 = new PullToRefreshLayout();
        StaticResourceExtension resourceExtension3 = new StaticResourceExtension();
        Label label3 = new Label();
        DataTemplate dataTemplate1 = new DataTemplate();
        StaticResourceExtension resourceExtension4 = new StaticResourceExtension();
        Label label4 = new Label();
        ListView listView = new ListView();
        PullToRefreshLayout pullToRefreshLayout2 = new PullToRefreshLayout();
        StackLayout bindable7 = new StackLayout();
        StaticResourceExtension resourceExtension5 = new StaticResourceExtension();
        Label label5 = new Label();
        StackLayout stackLayout3 = new StackLayout();
        StackLayout bindable8 = new StackLayout();
        ViewSchedulesPage bindable9 = this;
        NameScope nameScope = new NameScope();
        NameScope.SetNameScope((BindableObject) bindable9, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable8, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable7, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable4, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable1, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) stackLayout1, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("stackScheduleDay", (object) stackLayout1);
        if (stackLayout1.StyleId == null)
          stackLayout1.StyleId = "stackScheduleDay";
        NameScope.SetNameScope((BindableObject) bindable3, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable2, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) label1, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("lblDay", (object) label1);
        if (label1.StyleId == null)
          label1.StyleId = "lblDay";
        NameScope.SetNameScope((BindableObject) image, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("imgPullDownTerms", (object) image);
        if (image.StyleId == null)
          image.StyleId = "imgPullDownTerms";
        NameScope.SetNameScope((BindableObject) picker, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("pckrDays", (object) picker);
        if (picker.StyleId == null)
          picker.StyleId = "pckrDays";
        NameScope.SetNameScope((BindableObject) pullToRefreshLayout1, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("refresNoClass", (object) pullToRefreshLayout1);
        if (pullToRefreshLayout1.StyleId == null)
          pullToRefreshLayout1.StyleId = "refresNoClass";
        NameScope.SetNameScope((BindableObject) stackLayout2, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("stackNoClass", (object) stackLayout2);
        if (stackLayout2.StyleId == null)
          stackLayout2.StyleId = "stackNoClass";
        NameScope.SetNameScope((BindableObject) bindable6, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable5, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) label2, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("lblNoClass", (object) label2);
        if (label2.StyleId == null)
          label2.StyleId = "lblNoClass";
        NameScope.SetNameScope((BindableObject) pullToRefreshLayout2, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("refreshSchedule", (object) pullToRefreshLayout2);
        if (pullToRefreshLayout2.StyleId == null)
          pullToRefreshLayout2.StyleId = "refreshSchedule";
        NameScope.SetNameScope((BindableObject) listView, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("ScheduleList", (object) listView);
        if (listView.StyleId == null)
          listView.StyleId = "ScheduleList";
        NameScope.SetNameScope((BindableObject) label3, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("lblAsOf", (object) label3);
        if (label3.StyleId == null)
          label3.StyleId = "lblAsOf";
        NameScope.SetNameScope((BindableObject) label4, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("lblLastSync", (object) label4);
        if (label4.StyleId == null)
          label4.StyleId = "lblLastSync";
        NameScope.SetNameScope((BindableObject) stackLayout3, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("stackStatus", (object) stackLayout3);
        if (stackLayout3.StyleId == null)
          stackLayout3.StyleId = "stackStatus";
        NameScope.SetNameScope((BindableObject) label5, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("lblStatus", (object) label5);
        if (label5.StyleId == null)
          label5.StyleId = "lblStatus";
        this.stackScheduleDay = stackLayout1;
        this.lblDay = label1;
        this.imgPullDownTerms = image;
        this.pckrDays = picker;
        this.refresNoClass = pullToRefreshLayout1;
        this.stackNoClass = stackLayout2;
        this.lblNoClass = label2;
        this.refreshSchedule = pullToRefreshLayout2;
        this.ScheduleList = listView;
        this.lblAsOf = label3;
        this.lblLastSync = label4;
        this.stackStatus = stackLayout3;
        this.lblStatus = label5;
        bindable9.SetValue(Page.IconProperty, new FileImageSourceConverter().ConvertFromInvariantString("ic_action_schedule"));
        bindable9.SetValue(VisualElement.BackgroundColorProperty, (object) Color.White);
        bindable7.SetValue(View.MarginProperty, (object) new Thickness(5.0));
        bindable7.SetValue(View.VerticalOptionsProperty, (object) LayoutOptions.FillAndExpand);
        bindable4.SetValue(Frame.HasShadowProperty, (object) true);
        bindable4.SetValue(Layout.PaddingProperty, (object) new Thickness(0.0, 5.0, 0.0, 5.0));
        bindable4.SetValue(View.MarginProperty, (object) new Thickness(10.0, 10.0, 10.0, 0.0));
        bindable4.SetValue(Frame.CornerRadiusProperty, (object) 15f);
        bindable1.Tapped += new EventHandler(bindable9.Schedules_Tapped);
        bindable4.GestureRecognizers.Add((IGestureRecognizer) bindable1);
        stackLayout1.SetValue(StackLayout.OrientationProperty, (object) StackOrientation.Vertical);
        stackLayout1.SetValue(StackLayout.SpacingProperty, (object) 0.0);
        stackLayout1.SetValue(View.MarginProperty, (object) new Thickness(20.0, 0.0, 20.0, 0.0));
        stackLayout1.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.CenterAndExpand);
        bindable3.SetValue(StackLayout.OrientationProperty, (object) StackOrientation.Horizontal);
        bindable3.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.FillAndExpand);
        bindable2.SetValue(Image.SourceProperty, new ImageSourceConverter().ConvertFromInvariantString("ic_calendar_today"));
        bindable3.Children.Add((View) bindable2);
        resourceExtension1.Key = "smallHeader";
        StaticResourceExtension resourceExtension6 = resourceExtension1;
        XamlServiceProvider xamlServiceProvider1 = new XamlServiceProvider();
        Type type1 = typeof (IProvideValueTarget);
        object[] objectAndParents1 = new object[0 + 7];
        objectAndParents1[0] = (object) label1;
        objectAndParents1[1] = (object) bindable3;
        objectAndParents1[2] = (object) stackLayout1;
        objectAndParents1[3] = (object) bindable4;
        objectAndParents1[4] = (object) bindable7;
        objectAndParents1[5] = (object) bindable8;
        objectAndParents1[6] = (object) bindable9;
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
        XamlTypeResolver service2 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver1, typeof (ViewSchedulesPage).GetTypeInfo().Assembly);
        xamlServiceProvider1.Add(type2, (object) service2);
        xamlServiceProvider1.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(23, 52)));
        object obj1 = resourceExtension6.ProvideValue((IServiceProvider) xamlServiceProvider1);
        label1.Style = (Style) obj1;
        label1.SetValue(View.VerticalOptionsProperty, (object) LayoutOptions.Center);
        bindable3.Children.Add((View) label1);
        image.SetValue(Image.SourceProperty, new ImageSourceConverter().ConvertFromInvariantString("ic_arrow_drop_down"));
        bindable3.Children.Add((View) image);
        stackLayout1.Children.Add((View) bindable3);
        bindable4.SetValue(ContentView.ContentProperty, (object) stackLayout1);
        bindable7.Children.Add((View) bindable4);
        picker.SetValue(Picker.TitleProperty, (object) "Class Days");
        picker.SetValue(VisualElement.IsVisibleProperty, new VisualElement.VisibilityConverter().ConvertFromInvariantString("False"));
        picker.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.FillAndExpand);
        picker.SelectedIndexChanged += new EventHandler(bindable9.pckrDays_SelectedIndexChanged);
        bindable7.Children.Add((View) picker);
        pullToRefreshLayout1.SetValue(VisualElement.IsVisibleProperty, new VisualElement.VisibilityConverter().ConvertFromInvariantString("False"));
        pullToRefreshLayout1.SetValue(PullToRefreshLayout.IsPullToRefreshEnabledProperty, (object) true);
        pullToRefreshLayout1.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.FillAndExpand);
        pullToRefreshLayout1.SetValue(View.VerticalOptionsProperty, (object) LayoutOptions.FillAndExpand);
        stackLayout2.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.FillAndExpand);
        stackLayout2.SetValue(View.VerticalOptionsProperty, (object) LayoutOptions.FillAndExpand);
        bindable6.SetValue(View.VerticalOptionsProperty, (object) LayoutOptions.CenterAndExpand);
        bindable5.SetValue(Image.SourceProperty, new ImageSourceConverter().ConvertFromInvariantString("image_calendar"));
        bindable5.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.Center);
        bindable5.SetValue(View.VerticalOptionsProperty, (object) LayoutOptions.Center);
        bindable5.SetValue(Image.AspectProperty, (object) Aspect.AspectFit);
        bindable5.SetValue(VisualElement.HeightRequestProperty, (object) 90.0);
        bindable6.Children.Add((View) bindable5);
        resourceExtension2.Key = "mediumLabel";
        StaticResourceExtension resourceExtension7 = resourceExtension2;
        XamlServiceProvider xamlServiceProvider2 = new XamlServiceProvider();
        Type type3 = typeof (IProvideValueTarget);
        object[] objectAndParents2 = new object[0 + 7];
        objectAndParents2[0] = (object) label2;
        objectAndParents2[1] = (object) bindable6;
        objectAndParents2[2] = (object) stackLayout2;
        objectAndParents2[3] = (object) pullToRefreshLayout1;
        objectAndParents2[4] = (object) bindable7;
        objectAndParents2[5] = (object) bindable8;
        objectAndParents2[6] = (object) bindable9;
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
        XamlTypeResolver service4 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver2, typeof (ViewSchedulesPage).GetTypeInfo().Assembly);
        xamlServiceProvider2.Add(type4, (object) service4);
        xamlServiceProvider2.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(36, 58)));
        object obj2 = resourceExtension7.ProvideValue((IServiceProvider) xamlServiceProvider2);
        label2.Style = (Style) obj2;
        label2.SetValue(Label.HorizontalTextAlignmentProperty, new TextAlignmentConverter().ConvertFromInvariantString("Center"));
        label2.SetValue(View.VerticalOptionsProperty, (object) LayoutOptions.Center);
        bindable6.Children.Add((View) label2);
        stackLayout2.Children.Add((View) bindable6);
        pullToRefreshLayout1.SetValue(ContentView.ContentProperty, (object) stackLayout2);
        bindable7.Children.Add((View) pullToRefreshLayout1);
        pullToRefreshLayout2.SetValue(PullToRefreshLayout.IsPullToRefreshEnabledProperty, (object) true);
        listView.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.CenterAndExpand);
        listView.SetValue(View.VerticalOptionsProperty, (object) LayoutOptions.FillAndExpand);
        listView.SetValue(View.MarginProperty, (object) new Thickness(0.0, 5.0, 5.0, 5.0));
        listView.SetValue(ListView.HasUnevenRowsProperty, (object) true);
        listView.SetValue(ListView.SeparatorVisibilityProperty, (object) SeparatorVisibility.None);
        listView.SetValue(VisualElement.BackgroundColorProperty, (object) new Color(1.0, 1.0, 1.0, 1.0));
        label3.SetValue(View.MarginProperty, (object) new Thickness(10.0));
        label3.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.Center);
        label3.SetValue(VisualElement.IsVisibleProperty, new VisualElement.VisibilityConverter().ConvertFromInvariantString("False"));
        label3.SetValue(View.VerticalOptionsProperty, (object) LayoutOptions.EndAndExpand);
        resourceExtension3.Key = "microLabel";
        StaticResourceExtension resourceExtension8 = resourceExtension3;
        XamlServiceProvider xamlServiceProvider3 = new XamlServiceProvider();
        Type type5 = typeof (IProvideValueTarget);
        object[] objectAndParents3 = new object[0 + 6];
        objectAndParents3[0] = (object) label3;
        objectAndParents3[1] = (object) listView;
        objectAndParents3[2] = (object) pullToRefreshLayout2;
        objectAndParents3[3] = (object) bindable7;
        objectAndParents3[4] = (object) bindable8;
        objectAndParents3[5] = (object) bindable9;
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
        XamlTypeResolver service6 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver3, typeof (ViewSchedulesPage).GetTypeInfo().Assembly);
        xamlServiceProvider3.Add(type6, (object) service6);
        xamlServiceProvider3.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(49, 141)));
        object obj3 = resourceExtension8.ProvideValue((IServiceProvider) xamlServiceProvider3);
        label3.Style = (Style) obj3;
        label3.SetValue(Label.FontFamilyProperty, (object) "Roboto-Regular.ttf#Roboto");
        listView.SetValue(ListView.HeaderProperty, (object) label3);
        DataTemplate dataTemplate2 = dataTemplate1;
        // ISSUE: object of a compiler-generated type is created
        // ISSUE: variable of a compiler-generated type
        ViewSchedulesPage.\u003CInitializeComponent\u003E_anonXamlCDataTemplate_2 xamlCdataTemplate2 = new ViewSchedulesPage.\u003CInitializeComponent\u003E_anonXamlCDataTemplate_2();
        object[] objArray = new object[0 + 6];
        objArray[0] = (object) dataTemplate1;
        objArray[1] = (object) listView;
        objArray[2] = (object) pullToRefreshLayout2;
        objArray[3] = (object) bindable7;
        objArray[4] = (object) bindable8;
        objArray[5] = (object) bindable9;
        // ISSUE: reference to a compiler-generated field
        xamlCdataTemplate2.parentValues = objArray;
        // ISSUE: reference to a compiler-generated field
        xamlCdataTemplate2.root = bindable9;
        // ISSUE: reference to a compiler-generated method
        Func<object> func = new Func<object>(xamlCdataTemplate2.LoadDataTemplate);
        ((IDataTemplate) dataTemplate2).LoadTemplate = func;
        listView.SetValue(ItemsView<Cell>.ItemTemplateProperty, (object) dataTemplate1);
        label4.SetValue(View.MarginProperty, (object) new Thickness(15.0));
        label4.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.Center);
        label4.SetValue(View.VerticalOptionsProperty, (object) LayoutOptions.EndAndExpand);
        resourceExtension4.Key = "microLabel";
        StaticResourceExtension resourceExtension9 = resourceExtension4;
        XamlServiceProvider xamlServiceProvider4 = new XamlServiceProvider();
        Type type7 = typeof (IProvideValueTarget);
        object[] objectAndParents4 = new object[0 + 6];
        objectAndParents4[0] = (object) label4;
        objectAndParents4[1] = (object) listView;
        objectAndParents4[2] = (object) pullToRefreshLayout2;
        objectAndParents4[3] = (object) bindable7;
        objectAndParents4[4] = (object) bindable8;
        objectAndParents4[5] = (object) bindable9;
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
        namespaceResolver4.Add("controls", "clr-namespace:Refractored.XamForms.PullToRefresh;assembly=Refractored.XamForms.PullToRefresh");
        XamlTypeResolver service8 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver4, typeof (ViewSchedulesPage).GetTypeInfo().Assembly);
        xamlServiceProvider4.Add(type8, (object) service8);
        xamlServiceProvider4.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(95, 127)));
        object obj4 = resourceExtension9.ProvideValue((IServiceProvider) xamlServiceProvider4);
        label4.Style = (Style) obj4;
        label4.SetValue(Label.FontFamilyProperty, (object) "Roboto-Regular.ttf#Roboto");
        listView.SetValue(ListView.FooterProperty, (object) label4);
        pullToRefreshLayout2.SetValue(ContentView.ContentProperty, (object) listView);
        bindable7.Children.Add((View) pullToRefreshLayout2);
        bindable8.Children.Add((View) bindable7);
        stackLayout3.SetValue(VisualElement.BackgroundColorProperty, (object) new Color(0.180392161011696, 0.192156866192818, 0.192156866192818, 1.0));
        stackLayout3.SetValue(VisualElement.IsVisibleProperty, new VisualElement.VisibilityConverter().ConvertFromInvariantString("False"));
        stackLayout3.SetValue(View.VerticalOptionsProperty, (object) LayoutOptions.End);
        stackLayout3.SetValue(Layout.PaddingProperty, (object) new Thickness(3.0));
        stackLayout3.SetValue(View.MarginProperty, (object) new Thickness(0.0));
        label5.SetValue(Label.TextProperty, (object) "No connection");
        resourceExtension5.Key = "microLabel";
        StaticResourceExtension resourceExtension10 = resourceExtension5;
        XamlServiceProvider xamlServiceProvider5 = new XamlServiceProvider();
        Type type9 = typeof (IProvideValueTarget);
        object[] objectAndParents5 = new object[0 + 4];
        objectAndParents5[0] = (object) label5;
        objectAndParents5[1] = (object) stackLayout3;
        objectAndParents5[2] = (object) bindable8;
        objectAndParents5[3] = (object) bindable9;
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
        XamlTypeResolver service10 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver5, typeof (ViewSchedulesPage).GetTypeInfo().Assembly);
        xamlServiceProvider5.Add(type10, (object) service10);
        xamlServiceProvider5.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(103, 64)));
        object obj5 = resourceExtension10.ProvideValue((IServiceProvider) xamlServiceProvider5);
        label5.Style = (Style) obj5;
        Label label6 = label5;
        BindableProperty fontSizeProperty = Label.FontSizeProperty;
        FontSizeConverter fontSizeConverter = new FontSizeConverter();
        XamlServiceProvider xamlServiceProvider6 = new XamlServiceProvider();
        Type type11 = typeof (IProvideValueTarget);
        object[] objectAndParents6 = new object[0 + 4];
        objectAndParents6[0] = (object) label5;
        objectAndParents6[1] = (object) stackLayout3;
        objectAndParents6[2] = (object) bindable8;
        objectAndParents6[3] = (object) bindable9;
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
        XamlTypeResolver service12 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver6, typeof (ViewSchedulesPage).GetTypeInfo().Assembly);
        xamlServiceProvider6.Add(type12, (object) service12);
        xamlServiceProvider6.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(103, 100)));
        object obj6 = ((IExtendedTypeConverter) fontSizeConverter).ConvertFromInvariantString("12", (IServiceProvider) xamlServiceProvider6);
        label6.SetValue(fontSizeProperty, obj6);
        label5.SetValue(Label.TextColorProperty, (object) new Color(1.0, 1.0, 1.0, 1.0));
        label5.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.Center);
        stackLayout3.Children.Add((View) label5);
        bindable8.Children.Add((View) stackLayout3);
        bindable9.SetValue(ContentPage.ContentProperty, (object) bindable8);
      }
    }

    private void __InitComponentRuntime()
    {
      this.LoadFromXaml<ViewSchedulesPage>(typeof (ViewSchedulesPage));
      this.stackScheduleDay = NameScopeExtensions.FindByName<StackLayout>(this, "stackScheduleDay");
      this.lblDay = NameScopeExtensions.FindByName<Label>(this, "lblDay");
      this.imgPullDownTerms = NameScopeExtensions.FindByName<Image>(this, "imgPullDownTerms");
      this.pckrDays = NameScopeExtensions.FindByName<Picker>(this, "pckrDays");
      this.refresNoClass = NameScopeExtensions.FindByName<PullToRefreshLayout>(this, "refresNoClass");
      this.stackNoClass = NameScopeExtensions.FindByName<StackLayout>(this, "stackNoClass");
      this.lblNoClass = NameScopeExtensions.FindByName<Label>(this, "lblNoClass");
      this.refreshSchedule = NameScopeExtensions.FindByName<PullToRefreshLayout>(this, "refreshSchedule");
      this.ScheduleList = NameScopeExtensions.FindByName<ListView>(this, "ScheduleList");
      this.lblAsOf = NameScopeExtensions.FindByName<Label>(this, "lblAsOf");
      this.lblLastSync = NameScopeExtensions.FindByName<Label>(this, "lblLastSync");
      this.stackStatus = NameScopeExtensions.FindByName<StackLayout>(this, "stackStatus");
      this.lblStatus = NameScopeExtensions.FindByName<Label>(this, "lblStatus");
    }

    public class ListProperty
    {
      public Color tile_color { get; set; }

      public string day { get; set; }

      public bool dayVisible { get; set; }

      public string time_start { get; set; }

      public string time_end { get; set; }

      public string subj_code { get; set; }

      public string subj_desc { get; set; }

      public string instructor { get; set; }

      public string room { get; set; }
    }
  }
}
