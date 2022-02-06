// Decompiled with JetBrains decompiler
// Type: one_sti_student_portal.Views.Students.ViewSOAPage
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
  [XamlFilePath("Views\\Students\\ViewSOAPage.xaml")]
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public class ViewSOAPage : ContentPage
  {
    private StudentData _studentData;
    private DWTableData _tableData;
    private List<string> _listSemester;
    private string _currentTerm;
    private string _userId;
    private string _acad_career;
    private string _campus;
    private string serverStatus;
    private bool _isBusy;
    private bool _isConnected;
    private bool _isActive;
    private bool _refreshContent;
    private double _totalBalance;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private StackLayout stackSYTerm;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private Label lblSYTerm;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private Image imgPullDownTerms;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private Picker pckrSchoolTerm;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private PullToRefreshLayout refreshAssessment;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private StackLayout stackMain;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private Label lblNetAsOf;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private Label lblTotalBalance;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private StackLayout stackAssessment;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private Label lblAssessment;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private Label lblAssessmentAmt;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private StackLayout stackRegFee;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private Label lblRegFeeAmt;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private StackLayout stackTutFees;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private Label lblTutHeader;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private Label lblTuitionAmt;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private StackLayout stackTutMiscDetails;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private StackLayout stackOSF;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private Label lblOSFAmt;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private StackLayout stackOSFDetails;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private StackLayout stackMiscellaneous;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private Label lblMiscAmt;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private StackLayout stackMiscDetails;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private StackLayout stackPaymentData;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private Label lblTuitionGrand;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private Label lbl_balance;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private Frame frmNonTuition;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private Label lblOtherChrgstAmt;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private StackLayout stackNonTuition;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private StackLayout stackNonTuitionPayment;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private StackLayout stackNonTuitionTotals;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private Label lblNonTuitionGrand;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private Label lblNonTuitionBalance;
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

    public ViewSOAPage(bool isRefresh)
    {
      this.InitializeComponent();
      this._refreshContent = isRefresh;
      switch (Device.RuntimePlatform)
      {
        case "Android":
          this.ToolbarItems.Add(new ToolbarItem("", "ic_action_info", (Action) (() => this.DisplayAlert("Student Balance", "To validate your balances, check with the Registrar’s Office for clarification.", "OK"))));
          this._studentData = new StudentData();
          this._tableData = new DWTableData();
          this._isConnected = ConnectionHelper.IsConnected();
          Connectivity.ConnectivityChanged += (EventHandler<ConnectivityChangedEventArgs>) ((sender, args) =>
          {
            this._isConnected = ConnectionHelper.IsConnected();
            this.CheckStatus();
          });
          this.refreshAssessment.RefreshCommand = (ICommand) new Command((Action) (() => this.RefreshContent()));
          Task.Run((Func<Task>) (async () => await this.LoadStudentInformation())).ContinueWith((Action<Task>) (result => Device.BeginInvokeOnMainThread((Action) (() =>
          {
            this.LoadSemester();
            this.LoadPage();
          }))));
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
      Device.BeginInvokeOnMainThread((Action) (() => this.refreshAssessment.IsRefreshing = true));
      Task.Run((Func<Task>) (async () =>
      {
        ViewSOAPage viewSoaPage = this;
        string str = await viewSoaPage.ServerStatusAsync();
        viewSoaPage.serverStatus = str;
        if (!(viewSoaPage.serverStatus == "true") || !ConnectionHelper.IsConnected() || viewSoaPage._isBusy)
          return;
        viewSoaPage._isBusy = true;
        StudentService studentService = new StudentService();
        await viewSoaPage.LoadStudentInformation();
        await viewSoaPage._studentData.DeletePaymentCharges(viewSoaPage._currentTerm);
        await viewSoaPage._studentData.DeleteChargesDueDate(viewSoaPage._currentTerm);
        await viewSoaPage._studentData.DeleteOSFDetails(viewSoaPage._currentTerm);
        await viewSoaPage._studentData.DeleteTuitionMiscDetails(viewSoaPage._currentTerm);
        await viewSoaPage._studentData.DownloadSemPaymentCharges(viewSoaPage._userId, viewSoaPage._currentTerm);
        await viewSoaPage._studentData.DownloadSemChargesDueDate(viewSoaPage._userId, viewSoaPage._currentTerm);
        if (viewSoaPage._acad_career == "SHS")
        {
          await viewSoaPage._studentData.DownloadTuitionMiscDetails(viewSoaPage._userId, viewSoaPage._currentTerm + "01");
          await viewSoaPage._studentData.DownloadOSFDetails(viewSoaPage._userId, viewSoaPage._currentTerm + "01");
        }
        await viewSoaPage._studentData.DownloadStudentHistory(viewSoaPage._userId, viewSoaPage._currentTerm);
        AppLogModel appLogModel = new AppLogModel()
        {
          PSCSId = viewSoaPage._userId,
          IPAddress = "null",
          Medium = "Mobile",
          AppVersion = Constants.VersionName,
          NumOfRequests = 4,
          DateAccessed = DateTime.Now.ToString("MM/dd/yyyy hh:mm tt"),
          ViewName = viewSoaPage.GetType().Name + " RefreshContent()",
          Campus = viewSoaPage._campus
        };
      })).ContinueWith((Action<Task>) (result => Device.BeginInvokeOnMainThread((Action) (() =>
      {
        if (this.serverStatus == "true")
        {
          this.stackMain.IsVisible = true;
          this.frameServerDown.IsVisible = false;
          this.LoadPage();
          this.refreshAssessment.IsRefreshing = false;
          this._isBusy = false;
          if (ConnectionHelper.IsConnected())
            return;
          Acr.UserDialogs.UserDialogs.Instance.Toast("Could not refresh. Check your network connection.");
        }
        else if (this.serverStatus == "down")
        {
          this.stackMain.IsVisible = false;
          this.frameServerDown.IsVisible = true;
          this.refreshAssessment.IsRefreshing = false;
          this._isBusy = false;
        }
        else if (this.serverStatus == "not connected")
        {
          this.stackMain.IsVisible = true;
          this.frameServerDown.IsVisible = false;
          this._isBusy = false;
          Acr.UserDialogs.UserDialogs.Instance.Toast("Please check your network connection and try again.", new TimeSpan?(new TimeSpan(0, 0, 5)));
        }
        else
        {
          this.stackMain.IsVisible = true;
          this.frameServerDown.IsVisible = false;
          this._isBusy = false;
          Acr.UserDialogs.UserDialogs.Instance.Toast("An error occured while connecting to the server", new TimeSpan?(new TimeSpan(0, 0, 5)));
        }
      }))));
    }

    private void LoadPage()
    {
      this.lbl_balance.Text = "PhP " + this._studentData.GetTermBalance(this._currentTerm).ToString("N2");
      this._totalBalance = 0.0;
      this._totalBalance += this._studentData.GetTermBalance(this._currentTerm);
      this.LoadGrossAssessment();
      this.LoadTuitionRelatedPayments();
      this.LoadNonAssessmentCharges();
      this.LoadNonTuitionRelatedPayment();
      if (this._acad_career == "BCT")
      {
        this.LoadMiscDetails();
        this.stackMiscellaneous.IsVisible = true;
        this.stackRegFee.IsVisible = false;
      }
      else if (this._acad_career == "SHS")
      {
        this.LoadRegistrationFee();
        this.stackMiscDetails.Children.Clear();
        this.stackMiscDetails.IsVisible = false;
        this.stackMiscellaneous.IsVisible = false;
        this.stackRegFee.IsVisible = true;
      }
      this.LoadOSFDetails();
      this.LoadTuitionFees();
      DateTime recentTransactionDate = this._studentData.GetRecentTransactionDate(this._currentTerm);
      this.lblNetAsOf.IsVisible = !(recentTransactionDate == DateTime.MinValue);
      this.lblNetAsOf.Text = "AS OF " + recentTransactionDate.ToString("dd MMM, yyyy").ToUpper();
      if (!this.stackNonTuitionPayment.IsVisible && !this.stackNonTuition.IsVisible)
      {
        this.frmNonTuition.IsVisible = false;
        this.stackNonTuitionTotals.IsVisible = false;
      }
      else
      {
        this.frmNonTuition.IsVisible = true;
        this.stackNonTuitionTotals.IsVisible = true;
      }
    }

    protected override void OnAppearing()
    {
      base.OnAppearing();
      MessagingCenter.Send<MessageSender>(new MessageSender(), "MyAssessment");
      this._isConnected = ConnectionHelper.IsConnected();
      if (!this._isConnected)
      {
        this.stackStatus.BackgroundColor = Color.FromHex("#2e3131");
        this.stackStatus.IsVisible = true;
        this.lblStatus.Text = "No connection";
      }
      this._isActive = true;
    }

    protected override void OnDisappearing()
    {
      base.OnDisappearing();
      this._isActive = false;
    }

    private async Task LoadStudentInformation()
    {
      using (List<StudentInformation>.Enumerator enumerator = (await this._studentData.GetStudentInformation()).GetEnumerator())
      {
        if (enumerator.MoveNext())
        {
          StudentInformation current = enumerator.Current;
          this._userId = current.PSCSId;
          this._campus = current.Campus;
        }
      }
      using (List<StudentHistory>.Enumerator enumerator = (await this._studentData.GetStudentHistory(this._currentTerm)).GetEnumerator())
      {
        if (!enumerator.MoveNext())
          return;
        this._acad_career = enumerator.Current.acad_career;
      }
    }

    private void LoadMiscDetails()
    {
      List<StudentChargesPayment> list = this._studentData.GetSemPaymentCharges(this._userId, this._currentTerm).Result.Where<StudentChargesPayment>((Func<StudentChargesPayment, bool>) (o => o.ItemTypeCD == "C" && o.AccountNumber.Contains("MIS") && o.ItemAmount != 0.0)).ToList<StudentChargesPayment>();
      double num1 = list.Sum<StudentChargesPayment>((Func<StudentChargesPayment, double>) (o => o.ItemAmount));
      this.lblMiscAmt.Text = "PhP " + num1.ToString("N2");
      this.stackMiscDetails.Children.Clear();
      this.stackMiscDetails.IsVisible = num1 != 0.0;
      string str = "";
      int num2 = 1;
      foreach (StudentChargesPayment studentChargesPayment in list)
      {
        str = list.Count != 1 ? (num2 != list.Count<StudentChargesPayment>() ? (num2 >= list.Count<StudentChargesPayment>() || num2 != 1 ? str + studentChargesPayment.Description + ", " : "(" + studentChargesPayment.Description + ", ") : str + studentChargesPayment.Description + ")") : "(" + studentChargesPayment.Description + ")";
        ++num2;
      }
      StackLayout stackLayout = new StackLayout()
      {
        Orientation = StackOrientation.Horizontal
      };
      Label label1 = new Label();
      label1.HorizontalOptions = LayoutOptions.StartAndExpand;
      label1.Text = str;
      label1.Style = (Style) Application.Current.Resources["microLabel"];
      label1.FontSize = 13.0;
      label1.FontAttributes = FontAttributes.Italic;
      label1.FontFamily = "Roboto-Regular.ttf#Roboto";
      Label label2 = label1;
      stackLayout.Children.Add((View) label2);
      this.stackMiscDetails.Children.Add((View) stackLayout);
    }

    private void LoadOSFDetails()
    {
      if (this._acad_career == "SHS")
      {
        Task.Run((Func<Task>) (async () =>
        {
          ViewSOAPage viewSoaPage = this;
          if (!ConnectionHelper.IsConnected())
            return;
          await viewSoaPage._studentData.DeleteOSFDetails(viewSoaPage._currentTerm + "01");
          await viewSoaPage._studentData.DownloadOSFDetails(viewSoaPage._userId, viewSoaPage._currentTerm + "01");
          string str = await new StudentService().SendLog(new AppLogModel()
          {
            PSCSId = viewSoaPage._userId,
            IPAddress = "null",
            Medium = "Mobile",
            AppVersion = Constants.VersionName,
            NumOfRequests = 1,
            DateAccessed = DateTime.Now.ToString("MM/dd/yyyy hh:mm tt"),
            ViewName = viewSoaPage.GetType().Name + " LoadOSFDetails()",
            Campus = viewSoaPage._campus
          });
        })).ContinueWith((Action<Task>) (result => Device.BeginInvokeOnMainThread((Action) (() =>
        {
          List<OSFDetails> result = this._studentData.GetOSFDetails(this._currentTerm).Result;
          double num1 = result.Sum<OSFDetails>((Func<OSFDetails, double>) (o => double.Parse(o.item_amount)));
          this.lblOSFAmt.Text = "PhP " + num1.ToString("N2");
          this.stackOSFDetails.Children.Clear();
          this.stackOSFDetails.IsVisible = num1 != 0.0;
          string str = "";
          int num2 = 1;
          foreach (OSFDetails osfDetails in result)
          {
            str = result.Count != 1 ? (num2 != result.Count<OSFDetails>() ? (num2 >= result.Count<OSFDetails>() || num2 != 1 ? str + osfDetails.fee_code + ", " : "(" + osfDetails.fee_code + ", ") : str + osfDetails.fee_code + ")") : "(" + osfDetails.fee_code + ")";
            ++num2;
          }
          StackLayout stackLayout = new StackLayout()
          {
            Orientation = StackOrientation.Horizontal
          };
          Label label = new Label()
          {
            HorizontalOptions = LayoutOptions.StartAndExpand,
            Text = str,
            Style = (Style) Application.Current.Resources["microLabel"],
            FontSize = 13.0,
            FontAttributes = FontAttributes.Italic,
            FontFamily = "Roboto-Regular.ttf#Roboto"
          };
          stackLayout.Children.Add((View) label);
          this.stackOSFDetails.Children.Add((View) stackLayout);
        }))));
      }
      else
      {
        List<StudentChargesPayment> list = this._studentData.GetSemPaymentCharges(this._userId, this._currentTerm).Result.Where<StudentChargesPayment>((Func<StudentChargesPayment, bool>) (o => o.ItemTypeCD == "C" && o.AccountNumber.Contains("OSF") && o.ItemAmount != 0.0)).ToList<StudentChargesPayment>();
        double num3 = list.Sum<StudentChargesPayment>((Func<StudentChargesPayment, double>) (o => o.ItemAmount));
        this.lblOSFAmt.Text = "PhP " + num3.ToString("N2");
        this.stackOSFDetails.Children.Clear();
        this.stackOSFDetails.IsVisible = num3 != 0.0;
        string str = "";
        int num4 = 1;
        foreach (StudentChargesPayment studentChargesPayment in list)
        {
          str = list.Count != 1 ? (num4 != list.Count<StudentChargesPayment>() ? (num4 >= list.Count<StudentChargesPayment>() || num4 != 1 ? str + studentChargesPayment.Description + ", " : "(" + studentChargesPayment.Description + ", ") : str + studentChargesPayment.Description + ")") : "(" + studentChargesPayment.Description + ")";
          ++num4;
        }
        StackLayout stackLayout = new StackLayout()
        {
          Orientation = StackOrientation.Horizontal
        };
        Label label1 = new Label();
        label1.HorizontalOptions = LayoutOptions.StartAndExpand;
        label1.Text = str;
        label1.Style = (Style) Application.Current.Resources["microLabel"];
        label1.FontSize = 13.0;
        label1.FontAttributes = FontAttributes.Italic;
        label1.FontFamily = "Roboto-Regular.ttf#Roboto";
        Label label2 = label1;
        stackLayout.Children.Add((View) label2);
        this.stackOSFDetails.Children.Add((View) stackLayout);
      }
    }

    private void LoadTuitionFees()
    {
      if (this._acad_career == "BCT")
      {
        this.stackTutMiscDetails.Children.Clear();
        this.stackTutMiscDetails.IsVisible = false;
        this.lblTutHeader.Text = "Tuition Fee";
        this.lblTuitionAmt.Text = "PhP " + this._studentData.GetSemPaymentCharges(this._userId, this._currentTerm).Result.Where<StudentChargesPayment>((Func<StudentChargesPayment, bool>) (o => o.ItemTypeCD == "C" && o.AccountNumber.Contains("TUTFEES") && o.ItemAmount != 0.0)).ToList<StudentChargesPayment>().Sum<StudentChargesPayment>((Func<StudentChargesPayment, double>) (o => o.ItemAmount)).ToString("N2");
      }
      else
      {
        this.lblTutHeader.Text = "Tuition and Misc. Fee";
        List<MiscDetails> content = new List<MiscDetails>();
        Task.Run((Func<Task>) (async () =>
        {
          ViewSOAPage viewSoaPage = this;
          if (!ConnectionHelper.IsConnected())
            return;
          await viewSoaPage._studentData.DeleteTuitionMiscDetails();
          await viewSoaPage._studentData.DownloadTuitionMiscDetails(viewSoaPage._userId, viewSoaPage._currentTerm + "01");
          string str = await new StudentService().SendLog(new AppLogModel()
          {
            PSCSId = viewSoaPage._userId,
            IPAddress = "null",
            Medium = "Mobile",
            AppVersion = Constants.VersionName,
            NumOfRequests = 1,
            DateAccessed = DateTime.Now.ToString("MM/dd/yyyy hh:mm tt"),
            ViewName = viewSoaPage.GetType().Name + " LoadTuitionFees()",
            Campus = viewSoaPage._campus
          });
        })).ContinueWith((Action<Task>) (result => Device.BeginInvokeOnMainThread((Action) (() =>
        {
          content = this._studentData.GetTuitionMiscDetails(this._currentTerm).Result;
          this.lblTuitionAmt.Text = "PhP " + content.Sum<MiscDetails>((Func<MiscDetails, double>) (o => double.Parse(o.item_amount))).ToString("N2");
          this.stackTutMiscDetails.Children.Clear();
          this.stackTutMiscDetails.IsVisible = content.Count != 0;
          string str = "";
          int num = 1;
          foreach (MiscDetails miscDetails in content)
          {
            str = content.Count != 1 ? (num != content.Count<MiscDetails>() ? (num >= content.Count<MiscDetails>() || num != 1 ? str + miscDetails.fee_code + ", " : "(" + miscDetails.fee_code + ", ") : str + miscDetails.fee_code + ")") : "(" + miscDetails.fee_code + ")";
            ++num;
          }
          StackLayout stackLayout = new StackLayout()
          {
            Orientation = StackOrientation.Horizontal
          };
          Label label = new Label()
          {
            HorizontalOptions = LayoutOptions.StartAndExpand,
            Text = str,
            Style = (Style) Application.Current.Resources["microLabel"],
            FontSize = 13.0,
            FontAttributes = FontAttributes.Italic,
            FontFamily = "Roboto-Regular.ttf#Roboto"
          };
          stackLayout.Children.Add((View) label);
          this.stackTutMiscDetails.Children.Add((View) stackLayout);
        }))));
      }
    }

    private void LoadGrossAssessment()
    {
      this.lblAssessment.Text = "Gross Assessment";
      this.lblAssessmentAmt.Text = "PhP " + this._studentData.GetNetTuitionAmount(this._currentTerm).ToString("N2");
      this.stackAssessment.Children.Clear();
      List<StudentNetAssessment> result1 = this._studentData.GetNetAssessment().Result;
      List<StudentInformation> result2 = this._studentData.GetStudentInformation().Result;
      if (result1.Count == 0)
      {
        this.stackAssessment.Margin = new Thickness(10.0, 5.0, 0.0, 5.0);
        IList<View> children = this.stackAssessment.Children;
        Label label = new Label();
        label.HorizontalOptions = LayoutOptions.StartAndExpand;
        label.Text = "No schedule available.";
        label.Style = (Style) Application.Current.Resources["smallLabel"];
        label.FontFamily = "Roboto-Regular.ttf#Roboto";
        children.Add((View) label);
      }
      else if (result2.FirstOrDefault<StudentInformation>().SchoolTerm != this._listSemester[this.pckrSchoolTerm.SelectedIndex])
      {
        this.lblLastSync.Text = "LAST SYNC ON " + result1.OrderByDescending<StudentNetAssessment, DateTime>((Func<StudentNetAssessment, DateTime>) (o => o.UpdatedOn)).FirstOrDefault<StudentNetAssessment>().UpdatedOn.ToString("dd MMM, yyyy hh:mm tt").ToUpper();
        this.stackAssessment.Margin = new Thickness(10.0, 5.0, 0.0, 5.0);
        IList<View> children = this.stackAssessment.Children;
        Label label = new Label();
        label.HorizontalOptions = LayoutOptions.StartAndExpand;
        label.Text = "No schedule available.";
        label.Style = (Style) Application.Current.Resources["smallLabel"];
        label.FontFamily = "Roboto-Regular.ttf#Roboto";
        children.Add((View) label);
      }
      else
      {
        foreach (StudentNetAssessment studentNetAssessment in result1)
        {
          this.lblLastSync.Text = "LAST SYNC ON " + studentNetAssessment.UpdatedOn.ToString("dd MMM, yyyy hh:mm tt").ToUpper();
          StackLayout stackLayout = new StackLayout()
          {
            Orientation = StackOrientation.Horizontal
          };
          Label label1 = new Label();
          label1.HorizontalOptions = LayoutOptions.StartAndExpand;
          label1.Text = studentNetAssessment.DueDate.ToString("dd MMM, yyyy");
          label1.Style = (Style) Application.Current.Resources["smallLabel"];
          label1.FontFamily = "Roboto-Regular.ttf#Roboto";
          Label label2 = label1;
          Label label3 = new Label();
          label3.HorizontalOptions = LayoutOptions.End;
          label3.HorizontalTextAlignment = TextAlignment.End;
          label3.Text = "PhP " + studentNetAssessment.DueAmount.ToString("N2");
          label3.Style = (Style) Application.Current.Resources["smallLabel"];
          label3.FontFamily = "Roboto-Regular.ttf#Roboto";
          Label label4 = label3;
          stackLayout.Children.Add((View) label2);
          stackLayout.Children.Add((View) label4);
          this.stackAssessment.Children.Add((View) stackLayout);
        }
      }
    }

    public void LoadTuitionRelatedPayments()
    {
      this.stackPaymentData.Children.Clear();
      List<StudentChargesPayment> list1 = this._studentData.GetTuitionPaymentData(this._currentTerm).Result.OrderByDescending<StudentChargesPayment, DateTime>((Func<StudentChargesPayment, DateTime>) (o => o.ItemEffectiveDate)).ToList<StudentChargesPayment>();
      List<string> list2 = list1.Select<StudentChargesPayment, string>((Func<StudentChargesPayment, string>) (x => x.ReceiptNumber)).Distinct<string>().ToList<string>();
      double num1 = 0.0;
      List<StudentChargesPayment> list3 = this._studentData.GetTotalWaivedAmount(this._currentTerm).Result.OrderByDescending<StudentChargesPayment, DateTime>((Func<StudentChargesPayment, DateTime>) (o => o.ItemEffectiveDate)).ToList<StudentChargesPayment>();
      List<DateTime> list4 = list3.Select<StudentChargesPayment, DateTime>((Func<StudentChargesPayment, DateTime>) (x => x.ItemEffectiveDate)).Distinct<DateTime>().ToList<DateTime>();
      if (list1.Count == 0 && list3.Count == 0)
      {
        IList<View> children = this.stackPaymentData.Children;
        Label label = new Label();
        label.Text = "No data available.";
        label.Style = (Style) Application.Current.Resources["smallLabel"];
        label.VerticalOptions = LayoutOptions.Start;
        label.Margin = new Thickness(0.0, 0.0, 0.0, 10.0);
        children.Add((View) label);
      }
      else
      {
        foreach (DateTime dateTime in list4)
        {
          DateTime items = dateTime;
          StackLayout stackLayout1 = new StackLayout();
          stackLayout1.Orientation = StackOrientation.Horizontal;
          stackLayout1.Margin = new Thickness(0.0, 0.0, 0.0, 5.0);
          StackLayout stackLayout2 = stackLayout1;
          stackLayout2.Children.Add((View) new Image()
          {
            Source = (ImageSource) "ic_pin"
          });
          IList<View> children1 = stackLayout2.Children;
          Label label1 = new Label();
          label1.Text = "Scholarship/Discount";
          label1.Style = (Style) Application.Current.Resources["smallHeader"];
          label1.TextColor = Color.FromHex("#404040");
          label1.VerticalOptions = LayoutOptions.Start;
          children1.Add((View) label1);
          this.stackPaymentData.Children.Add((View) stackLayout2);
          foreach (StudentChargesPayment studentChargesPayment in list3.Where<StudentChargesPayment>((Func<StudentChargesPayment, bool>) (o => o.ItemEffectiveDate == items)).ToList<StudentChargesPayment>())
          {
            IList<View> children2 = this.stackPaymentData.Children;
            StackLayout stackLayout3 = new StackLayout();
            stackLayout3.Orientation = StackOrientation.Horizontal;
            stackLayout3.BackgroundColor = Color.White;
            IList<View> children3 = stackLayout3.Children;
            Label label2 = new Label();
            label2.HorizontalOptions = LayoutOptions.StartAndExpand;
            label2.Margin = new Thickness(23.0, 0.0, 10.0, 0.0);
            label2.Style = (Style) Application.Current.Resources["smallLabel"];
            label2.Text = studentChargesPayment.Description;
            label2.FontFamily = "Roboto-Regular.ttf#Roboto";
            children3.Add((View) label2);
            IList<View> children4 = stackLayout3.Children;
            Label label3 = new Label();
            label3.HorizontalOptions = LayoutOptions.End;
            label3.HorizontalTextAlignment = TextAlignment.End;
            label3.Text = "PhP " + studentChargesPayment.ItemAmount.ToString("n2");
            label3.Style = (Style) Application.Current.Resources["smallLabel"];
            label3.FontFamily = "Roboto-Regular.ttf#Roboto";
            children4.Add((View) label3);
            children2.Add((View) stackLayout3);
          }
          IList<View> children5 = this.stackPaymentData.Children;
          BoxView boxView = new BoxView();
          boxView.Color = Color.FromHex("#dadfe1");
          boxView.HeightRequest = 1.5;
          boxView.Margin = new Thickness(23.0, 5.0, 0.0, 5.0);
          boxView.HorizontalOptions = LayoutOptions.FillAndExpand;
          children5.Add((View) boxView);
          StackLayout stackLayout4 = new StackLayout();
          stackLayout4.Orientation = StackOrientation.Horizontal;
          stackLayout4.Margin = new Thickness(0.0, 0.0, 0.0, 27.0);
          StackLayout stackLayout5 = stackLayout4;
          IList<View> children6 = stackLayout5.Children;
          Label label4 = new Label();
          label4.Text = "Total";
          label4.Style = (Style) Application.Current.Resources["smallLabel"];
          label4.HorizontalOptions = LayoutOptions.FillAndExpand;
          label4.FontFamily = "Roboto-Medium.ttf#Roboto";
          label4.Margin = new Thickness(23.0, 0.0, 0.0, 0.0);
          children6.Add((View) label4);
          IList<View> children7 = stackLayout5.Children;
          Label label5 = new Label();
          label5.Text = "PhP " + list3.Sum<StudentChargesPayment>((Func<StudentChargesPayment, double>) (item => item.ItemAmount)).ToString("N2");
          label5.Style = (Style) Application.Current.Resources["smallLabel"];
          label5.HorizontalOptions = LayoutOptions.End;
          label5.HorizontalTextAlignment = TextAlignment.End;
          label5.FontFamily = "Roboto-Medium.ttf#Roboto";
          children7.Add((View) label5);
          this.stackPaymentData.Children.Add((View) stackLayout5);
        }
        StackLayout stackLayout6 = new StackLayout()
        {
          Spacing = 0.0
        };
        foreach (string str1 in list2)
        {
          string items = str1;
          StackLayout stackLayout7 = new StackLayout()
          {
            Orientation = StackOrientation.Horizontal,
            Spacing = 0.0
          };
          StackLayout stackLayout8 = new StackLayout()
          {
            Spacing = 3.0
          };
          List<StudentChargesPayment> list5 = list1.Where<StudentChargesPayment>((Func<StudentChargesPayment, bool>) (o => o.ReceiptNumber == items)).ToList<StudentChargesPayment>();
          DateTime itemEffectiveDate = list5.Where<StudentChargesPayment>((Func<StudentChargesPayment, bool>) (x => x.ReceiptNumber == items)).ToList<StudentChargesPayment>().FirstOrDefault<StudentChargesPayment>().ItemEffectiveDate;
          Image image1 = new Image();
          image1.Source = (ImageSource) "ic_pin";
          image1.VerticalOptions = LayoutOptions.Start;
          image1.Margin = new Thickness(0.0, 3.0, 0.0, 0.0);
          Image image2 = image1;
          string str2 = "OR # " + items;
          if (items == "0" && list5.FirstOrDefault<StudentChargesPayment>().ItemAmount > 0.0)
            str2 = list5.FirstOrDefault<StudentChargesPayment>().AccountNumber + " - Credit Memo ";
          Label label6 = new Label();
          label6.Text = itemEffectiveDate.ToString("dd MMM, yyyy") + " | " + str2;
          label6.Style = (Style) Application.Current.Resources["smallHeader"];
          label6.TextColor = Color.FromHex("#404040");
          label6.VerticalOptions = LayoutOptions.Start;
          label6.Margin = new Thickness(8.0, 0.0, 0.0, 10.0);
          Label label7 = label6;
          stackLayout7.Children.Add((View) image2);
          stackLayout7.Children.Add((View) label7);
          stackLayout6.Children.Add((View) stackLayout7);
          double num2 = 0.0;
          foreach (StudentChargesPayment studentChargesPayment in list5)
          {
            StackLayout stackLayout9 = new StackLayout()
            {
              Orientation = StackOrientation.Horizontal
            };
            Label label8 = new Label();
            label8.Text = this.AccountTitle(studentChargesPayment.AccountNumber.Remove(studentChargesPayment.AccountNumber.Length - 3));
            label8.Style = (Style) Application.Current.Resources["smallLabel"];
            label8.Margin = new Thickness(23.0, 0.0, 0.0, 0.0);
            label8.HorizontalOptions = LayoutOptions.FillAndExpand;
            label8.FontFamily = "Roboto-Regular.ttf#Roboto";
            Label label9 = label8;
            Label label10 = new Label();
            label10.Text = "PhP " + studentChargesPayment.ItemAmount.ToString("N2");
            label10.Style = (Style) Application.Current.Resources["smallLabel"];
            label10.HorizontalOptions = LayoutOptions.End;
            label10.HorizontalTextAlignment = TextAlignment.End;
            label10.FontFamily = "Roboto-Regular.ttf#Roboto";
            Label label11 = label10;
            num2 += studentChargesPayment.ItemAmount;
            num1 += studentChargesPayment.ItemAmount;
            if (studentChargesPayment.ItemAmount != 0.0)
            {
              stackLayout9.Children.Add((View) label9);
              stackLayout9.Children.Add((View) label11);
              stackLayout8.Children.Add((View) stackLayout9);
            }
          }
          stackLayout6.Children.Add((View) stackLayout8);
          IList<View> children8 = stackLayout6.Children;
          BoxView boxView = new BoxView();
          boxView.Color = Color.FromHex("#dadfe1");
          boxView.HeightRequest = 1.5;
          boxView.Margin = new Thickness(23.0, 5.0, 0.0, 5.0);
          boxView.HorizontalOptions = LayoutOptions.FillAndExpand;
          children8.Add((View) boxView);
          StackLayout stackLayout10 = new StackLayout();
          stackLayout10.Orientation = StackOrientation.Horizontal;
          stackLayout10.Margin = new Thickness(0.0, 0.0, 0.0, 27.0);
          StackLayout stackLayout11 = stackLayout10;
          Label label12 = new Label();
          label12.Text = "PhP " + num2.ToString("N2");
          label12.Style = (Style) Application.Current.Resources["smallHeader"];
          label12.HorizontalOptions = LayoutOptions.End;
          label12.HorizontalTextAlignment = TextAlignment.End;
          label12.TextColor = Color.FromHex("#404040");
          Label label13 = label12;
          IList<View> children9 = stackLayout11.Children;
          Label label14 = new Label();
          label14.Text = "Total";
          label14.Style = (Style) Application.Current.Resources["smallLabel"];
          label14.HorizontalOptions = LayoutOptions.FillAndExpand;
          label14.FontFamily = "Roboto-Medium.ttf#Roboto";
          label14.Margin = new Thickness(23.0, 0.0, 0.0, 0.0);
          children9.Add((View) label14);
          stackLayout11.Children.Add((View) label13);
          stackLayout6.Children.Add((View) stackLayout11);
        }
        this.stackPaymentData.Children.Add((View) stackLayout6);
      }
      this.lblTuitionGrand.Text = "PhP " + (num1 + list3.Sum<StudentChargesPayment>((Func<StudentChargesPayment, double>) (item => item.ItemAmount))).ToString("N2");
    }

    private void LoadRegistrationFee()
    {
      double num = this._studentData.GetSemPaymentCharges(this._userId, this._currentTerm).Result.Where<StudentChargesPayment>((Func<StudentChargesPayment, bool>) (o => o.ItemTypeCD == "C" && o.AccountNumber.Contains("REG") && o.ItemAmount != 0.0)).ToList<StudentChargesPayment>().Sum<StudentChargesPayment>((Func<StudentChargesPayment, double>) (o => o.ItemAmount));
      this.stackRegFee.IsVisible = true;
      this.lblRegFeeAmt.Text = "PhP " + num.ToString("N2");
    }

    private string AccountTitle(string account)
    {
      switch (account)
      {
        case "BFS":
          return "SHS - Basic Fee";
        case "CM":
          return "Credit Memo";
        case "DM":
          return "Debit Memo";
        case "INSTAL":
          return "Installment";
        case "MFS":
        case "MFSP":
        case "MISCL":
          return "Miscellaneous Fee";
        case "OFS":
        case "OSF":
          return "Other School Fees";
        case "OPTNL":
          return "Optional Fee";
        case "PYMNT":
          return "Payments";
        case "REG":
          return "Registration Fee";
        case "SPF":
          return "Special Fees";
        case "TFS":
          return "Tuition Fee";
        case "TFSP":
        case "TUTFEES":
          return "Tuition Fees";
        case "TPCONTR":
          return "Third Party Contract";
        case "WAIVR":
          return "Waivers / Scholarships";
        default:
          return account;
      }
    }

    public void LoadNonAssessmentCharges()
    {
      this.stackNonTuition.Children.Clear();
      List<StudentChargesPayment> result = this._studentData.GetNonTuitionChargesData(this._currentTerm).Result;
      this.lblOtherChrgstAmt.Text = "PhP " + this._studentData.GetNonTuitionTotalCharges(this._currentTerm).ToString("N2");
      if (result.Count<StudentChargesPayment>() == 0)
      {
        IList<View> children = this.stackNonTuition.Children;
        Label label = new Label();
        label.HorizontalOptions = LayoutOptions.StartAndExpand;
        label.Margin = new Thickness(23.0, 0.0, 0.0, 0.0);
        label.Style = (Style) Application.Current.Resources["smallLabel"];
        label.Text = "No schedule available.";
        children.Add((View) label);
      }
      else
      {
        this.stackNonTuition.IsVisible = true;
        foreach (StudentChargesPayment studentChargesPayment in result)
        {
          StackLayout stackLayout1 = new StackLayout();
          stackLayout1.Orientation = StackOrientation.Horizontal;
          stackLayout1.BackgroundColor = Color.White;
          stackLayout1.Margin = new Thickness(23.0, 0.0, 0.0, 10.0);
          StackLayout stackLayout2 = stackLayout1;
          IList<View> children1 = stackLayout2.Children;
          Label label1 = new Label();
          label1.Text = studentChargesPayment.Description.ToString();
          label1.HorizontalOptions = LayoutOptions.StartAndExpand;
          label1.VerticalOptions = LayoutOptions.End;
          label1.Style = (Style) Application.Current.Resources["smallLabel"];
          label1.FontFamily = "Roboto-Regular.ttf#Roboto";
          children1.Add((View) label1);
          IList<View> children2 = stackLayout2.Children;
          Label label2 = new Label();
          label2.HorizontalOptions = LayoutOptions.End;
          label2.HorizontalTextAlignment = TextAlignment.End;
          label2.VerticalOptions = LayoutOptions.End;
          label2.Text = "PhP " + studentChargesPayment.ItemAmount.ToString("N2");
          label2.Style = (Style) Application.Current.Resources["smallLabel"];
          label2.FontFamily = "Roboto-Regular.ttf#Roboto";
          children2.Add((View) label2);
          IList<View> children3 = this.stackNonTuition.Children;
          Label label3 = new Label();
          label3.HorizontalOptions = LayoutOptions.StartAndExpand;
          label3.Margin = new Thickness(23.0, 0.0, 0.0, 0.0);
          label3.Style = (Style) Application.Current.Resources["smallLabel"];
          label3.Text = studentChargesPayment.ItemEffectiveDate.ToString("dd MMM, yyyy");
          children3.Add((View) label3);
          this.stackNonTuition.Children.Add((View) stackLayout2);
        }
      }
    }

    public void LoadNonTuitionRelatedPayment()
    {
      this.stackNonTuitionPayment.Children.Clear();
      List<StudentChargesPayment> result = this._studentData.GetNonTuitionPaymentData(this._currentTerm).Result;
      List<string> list1 = result.Select<StudentChargesPayment, string>((Func<StudentChargesPayment, string>) (x => x.ReceiptNumber)).Distinct<string>().ToList<string>();
      double num1 = 0.0;
      if (result.Count<StudentChargesPayment>() == 0)
      {
        IList<View> children = this.stackNonTuitionPayment.Children;
        Label label = new Label();
        label.Text = "No data available.";
        label.Style = (Style) Application.Current.Resources["smallLabel"];
        label.VerticalOptions = LayoutOptions.Start;
        label.Margin = new Thickness(0.0, 0.0, 0.0, 10.0);
        children.Add((View) label);
      }
      else
        this.stackNonTuitionPayment.IsVisible = true;
      StackLayout stackLayout1 = new StackLayout()
      {
        Spacing = 0.0
      };
      foreach (string str in list1)
      {
        string items = str;
        StackLayout stackLayout2 = new StackLayout()
        {
          Orientation = StackOrientation.Horizontal,
          Spacing = 0.0
        };
        StackLayout stackLayout3 = new StackLayout()
        {
          Spacing = 3.0
        };
        List<StudentChargesPayment> list2 = result.Where<StudentChargesPayment>((Func<StudentChargesPayment, bool>) (o => o.ReceiptNumber == items)).ToList<StudentChargesPayment>();
        DateTime itemEffectiveDate = list2.Where<StudentChargesPayment>((Func<StudentChargesPayment, bool>) (x => x.ReceiptNumber == items)).ToList<StudentChargesPayment>().FirstOrDefault<StudentChargesPayment>().ItemEffectiveDate;
        Image image1 = new Image();
        image1.Source = (ImageSource) "ic_pin";
        image1.VerticalOptions = LayoutOptions.Start;
        image1.Margin = new Thickness(0.0, 3.0, 0.0, 0.0);
        Image image2 = image1;
        Label label1 = new Label();
        label1.Text = itemEffectiveDate.ToString("dd MMM, yyyy") + " | OR # " + items;
        label1.Style = (Style) Application.Current.Resources["smallHeader"];
        label1.TextColor = Color.FromHex("#404040");
        label1.VerticalOptions = LayoutOptions.Start;
        label1.Margin = new Thickness(8.0, 0.0, 0.0, 10.0);
        Label label2 = label1;
        stackLayout2.Children.Add((View) image2);
        stackLayout2.Children.Add((View) label2);
        stackLayout1.Children.Add((View) stackLayout2);
        double num2 = 0.0;
        foreach (StudentChargesPayment studentChargesPayment in list2)
        {
          StackLayout stackLayout4 = new StackLayout()
          {
            Orientation = StackOrientation.Horizontal
          };
          Label label3 = new Label();
          label3.Text = this.AccountTitle(studentChargesPayment.AccountNumber.Remove(studentChargesPayment.AccountNumber.Length - 3));
          label3.Style = (Style) Application.Current.Resources["smallLabel"];
          label3.Margin = new Thickness(23.0, 0.0, 0.0, 0.0);
          label3.HorizontalOptions = LayoutOptions.FillAndExpand;
          label3.FontFamily = "Roboto-Regular.ttf#Roboto";
          Label label4 = label3;
          Label label5 = new Label();
          label5.Text = "PhP " + studentChargesPayment.ItemAmount.ToString("N2");
          label5.Style = (Style) Application.Current.Resources["smallLabel"];
          label5.HorizontalOptions = LayoutOptions.End;
          label5.HorizontalTextAlignment = TextAlignment.End;
          label5.FontFamily = "Roboto-Regular.ttf#Roboto";
          Label label6 = label5;
          num2 += studentChargesPayment.ItemAmount;
          num1 += studentChargesPayment.ItemAmount;
          if (studentChargesPayment.ItemAmount != 0.0)
          {
            stackLayout4.Children.Add((View) label4);
            stackLayout4.Children.Add((View) label6);
            stackLayout3.Children.Add((View) stackLayout4);
          }
        }
        stackLayout1.Children.Add((View) stackLayout3);
        IList<View> children1 = stackLayout1.Children;
        BoxView boxView = new BoxView();
        boxView.Color = Color.FromHex("#dadfe1");
        boxView.HeightRequest = 1.5;
        boxView.Margin = new Thickness(23.0, 5.0, 0.0, 5.0);
        boxView.HorizontalOptions = LayoutOptions.FillAndExpand;
        children1.Add((View) boxView);
        StackLayout stackLayout5 = new StackLayout();
        stackLayout5.Orientation = StackOrientation.Horizontal;
        stackLayout5.Margin = new Thickness(0.0, 0.0, 0.0, 27.0);
        StackLayout stackLayout6 = stackLayout5;
        Label label7 = new Label();
        label7.Text = "PhP " + num2.ToString("N2");
        label7.Style = (Style) Application.Current.Resources["smallLabel"];
        label7.HorizontalOptions = LayoutOptions.End;
        label7.HorizontalTextAlignment = TextAlignment.End;
        label7.FontFamily = "Roboto-Medium.ttf#Roboto";
        Label label8 = label7;
        IList<View> children2 = stackLayout6.Children;
        Label label9 = new Label();
        label9.Text = "Total";
        label9.Style = (Style) Application.Current.Resources["smallLabel"];
        label9.HorizontalOptions = LayoutOptions.FillAndExpand;
        label9.FontFamily = "Roboto-Medium.ttf#Roboto";
        label9.Margin = new Thickness(23.0, 0.0, 0.0, 0.0);
        children2.Add((View) label9);
        stackLayout6.Children.Add((View) label8);
        stackLayout1.Children.Add((View) stackLayout6);
      }
      this.stackNonTuitionPayment.Children.Add((View) stackLayout1);
      this.lblNonTuitionGrand.Text = "PhP " + num1.ToString("N2");
      double num3 = this._studentData.GetNonTuitionTotalCharges(this._currentTerm) - num1;
      this.lblNonTuitionBalance.Text = "PhP " + num3.ToString("N2");
      this._totalBalance += num3;
      this.lblTotalBalance.Text = "PhP " + this._totalBalance.ToString("N2");
    }

    public void LoadSemester()
    {
      List<StudentSemester> result = this._studentData.GetSemesters().Result;
      this._listSemester = new List<string>();
      foreach (StudentSemester studentSemester in result)
      {
        this._listSemester.Add(studentSemester.Semester);
        this.pckrSchoolTerm.Items.Add(studentSemester.SemesterDesc);
      }
      if (this._listSemester.Count == 0)
        return;
      this.pckrSchoolTerm.SelectedIndex = 0;
      this._currentTerm = this._listSemester[this.pckrSchoolTerm.SelectedIndex];
      foreach (StudentInformation studentInformation in this._studentData.GetStudentInformation().Result)
      {
        if (studentInformation.AcadLevel.Contains("G"))
          this._currentTerm = this._currentTerm.Remove(this._currentTerm.Length - 2);
      }
      this.lblSYTerm.Text = this.pckrSchoolTerm.SelectedItem.ToString();
    }

    private void pckrSchoolTerm_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (!this._isActive || this.pckrSchoolTerm.SelectedIndex == -1)
        return;
      this._currentTerm = this._listSemester[this.pckrSchoolTerm.SelectedIndex];
      Task.Run((Func<Task>) (async () =>
      {
        ViewSOAPage viewSoaPage = this;
        await viewSoaPage._studentData.DownloadStudentHistory(viewSoaPage._userId, viewSoaPage._currentTerm);
        string str = await new StudentService().SendLog(new AppLogModel()
        {
          PSCSId = viewSoaPage._userId,
          IPAddress = "null",
          Medium = "Mobile",
          AppVersion = Constants.VersionName,
          NumOfRequests = 1,
          DateAccessed = DateTime.Now.ToString("MM/dd/yyyy hh:mm tt"),
          ViewName = viewSoaPage.GetType().Name + " pckrSchoolTerm_SelectedIndexChanged",
          Campus = viewSoaPage._campus
        });
      })).ContinueWith((Action<Task>) (result => Device.BeginInvokeOnMainThread((Action) (() =>
      {
        foreach (StudentHistory studentHistory in this._studentData.GetStudentHistory(this._currentTerm).Result)
        {
          if (studentHistory.acad_career == "SHS")
            this._currentTerm = this._currentTerm.Remove(this._currentTerm.Length - 2);
        }
        this.lblSYTerm.Text = this.pckrSchoolTerm.SelectedItem.ToString();
        this.RefreshContent();
      }))));
    }

    private void SYTerms_Tapped(object sender, EventArgs e) => this.pckrSchoolTerm.Focus();

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
      if (ResourceLoader.ResourceProvider != null && ResourceLoader.ResourceProvider(typeof (ViewSOAPage).GetTypeInfo().Assembly.GetName(), "Views/Students/ViewSOAPage.xaml") != null)
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
        Label bindable5 = new Label();
        StackLayout bindable6 = new StackLayout();
        StaticResourceExtension resourceExtension3 = new StaticResourceExtension();
        Label label2 = new Label();
        StaticResourceExtension resourceExtension4 = new StaticResourceExtension();
        Label bindable7 = new Label();
        StaticResourceExtension resourceExtension5 = new StaticResourceExtension();
        Label label3 = new Label();
        StackLayout bindable8 = new StackLayout();
        StaticResourceExtension resourceExtension6 = new StaticResourceExtension();
        Label bindable9 = new Label();
        BoxView bindable10 = new BoxView();
        StackLayout stackLayout2 = new StackLayout();
        StackLayout bindable11 = new StackLayout();
        Frame bindable12 = new Frame();
        StaticResourceExtension resourceExtension7 = new StaticResourceExtension();
        Label label4 = new Label();
        StaticResourceExtension resourceExtension8 = new StaticResourceExtension();
        Label label5 = new Label();
        StackLayout bindable13 = new StackLayout();
        BoxView bindable14 = new BoxView();
        StackLayout bindable15 = new StackLayout();
        Image bindable16 = new Image();
        StaticResourceExtension resourceExtension9 = new StaticResourceExtension();
        Label bindable17 = new Label();
        StaticResourceExtension resourceExtension10 = new StaticResourceExtension();
        Label label6 = new Label();
        StackLayout stackLayout3 = new StackLayout();
        Image bindable18 = new Image();
        StaticResourceExtension resourceExtension11 = new StaticResourceExtension();
        Label label7 = new Label();
        StaticResourceExtension resourceExtension12 = new StaticResourceExtension();
        Label label8 = new Label();
        StackLayout stackLayout4 = new StackLayout();
        StackLayout stackLayout5 = new StackLayout();
        Image bindable19 = new Image();
        StaticResourceExtension resourceExtension13 = new StaticResourceExtension();
        Label bindable20 = new Label();
        StaticResourceExtension resourceExtension14 = new StaticResourceExtension();
        Label label9 = new Label();
        StackLayout stackLayout6 = new StackLayout();
        StackLayout stackLayout7 = new StackLayout();
        Image bindable21 = new Image();
        StaticResourceExtension resourceExtension15 = new StaticResourceExtension();
        Label bindable22 = new Label();
        StaticResourceExtension resourceExtension16 = new StaticResourceExtension();
        Label label10 = new Label();
        StackLayout stackLayout8 = new StackLayout();
        StackLayout stackLayout9 = new StackLayout();
        StaticResourceExtension resourceExtension17 = new StaticResourceExtension();
        Label bindable23 = new Label();
        BoxView bindable24 = new BoxView();
        StackLayout bindable25 = new StackLayout();
        StackLayout stackLayout10 = new StackLayout();
        StackLayout bindable26 = new StackLayout();
        Frame bindable27 = new Frame();
        StaticResourceExtension resourceExtension18 = new StaticResourceExtension();
        StaticResourceExtension resourceExtension19 = new StaticResourceExtension();
        Label bindable28 = new Label();
        StaticResourceExtension resourceExtension20 = new StaticResourceExtension();
        Label label11 = new Label();
        StackLayout bindable29 = new StackLayout();
        StaticResourceExtension resourceExtension21 = new StaticResourceExtension();
        Label bindable30 = new Label();
        StaticResourceExtension resourceExtension22 = new StaticResourceExtension();
        Label label12 = new Label();
        StackLayout bindable31 = new StackLayout();
        StaticResourceExtension resourceExtension23 = new StaticResourceExtension();
        Label bindable32 = new Label();
        StaticResourceExtension resourceExtension24 = new StaticResourceExtension();
        Label label13 = new Label();
        StackLayout bindable33 = new StackLayout();
        BoxView bindable34 = new BoxView();
        StackLayout bindable35 = new StackLayout();
        Image bindable36 = new Image();
        StaticResourceExtension resourceExtension25 = new StaticResourceExtension();
        Label bindable37 = new Label();
        StackLayout bindable38 = new StackLayout();
        StackLayout stackLayout11 = new StackLayout();
        StaticResourceExtension resourceExtension26 = new StaticResourceExtension();
        Label bindable39 = new Label();
        BoxView bindable40 = new BoxView();
        StackLayout bindable41 = new StackLayout();
        StackLayout stackLayout12 = new StackLayout();
        StackLayout bindable42 = new StackLayout();
        Frame frame1 = new Frame();
        StaticResourceExtension resourceExtension27 = new StaticResourceExtension();
        StaticResourceExtension resourceExtension28 = new StaticResourceExtension();
        Label bindable43 = new Label();
        StaticResourceExtension resourceExtension29 = new StaticResourceExtension();
        Label label14 = new Label();
        StackLayout bindable44 = new StackLayout();
        StaticResourceExtension resourceExtension30 = new StaticResourceExtension();
        Label bindable45 = new Label();
        StaticResourceExtension resourceExtension31 = new StaticResourceExtension();
        Label label15 = new Label();
        StackLayout bindable46 = new StackLayout();
        StackLayout stackLayout13 = new StackLayout();
        StaticResourceExtension resourceExtension32 = new StaticResourceExtension();
        Label label16 = new Label();
        StackLayout stackLayout14 = new StackLayout();
        StaticResourceExtension resourceExtension33 = new StaticResourceExtension();
        Label label17 = new Label();
        StackLayout bindable47 = new StackLayout();
        Frame frame2 = new Frame();
        StackLayout bindable48 = new StackLayout();
        ScrollView bindable49 = new ScrollView();
        PullToRefreshLayout pullToRefreshLayout = new PullToRefreshLayout();
        StaticResourceExtension resourceExtension34 = new StaticResourceExtension();
        Label label18 = new Label();
        StackLayout stackLayout15 = new StackLayout();
        StackLayout bindable50 = new StackLayout();
        ViewSOAPage bindable51 = this;
        NameScope nameScope = new NameScope();
        NameScope.SetNameScope((BindableObject) bindable51, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable50, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable4, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) stackLayout1, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("stackSYTerm", (object) stackLayout1);
        if (stackLayout1.StyleId == null)
          stackLayout1.StyleId = "stackSYTerm";
        NameScope.SetNameScope((BindableObject) bindable1, (INameScope) nameScope);
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
        ((INameScope) nameScope).RegisterName("refreshAssessment", (object) pullToRefreshLayout);
        if (pullToRefreshLayout.StyleId == null)
          pullToRefreshLayout.StyleId = "refreshAssessment";
        NameScope.SetNameScope((BindableObject) bindable49, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable48, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable6, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable5, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) stackLayout14, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("stackMain", (object) stackLayout14);
        if (stackLayout14.StyleId == null)
          stackLayout14.StyleId = "stackMain";
        NameScope.SetNameScope((BindableObject) label2, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("lblNetAsOf", (object) label2);
        if (label2.StyleId == null)
          label2.StyleId = "lblNetAsOf";
        NameScope.SetNameScope((BindableObject) bindable8, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable7, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) label3, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("lblTotalBalance", (object) label3);
        if (label3.StyleId == null)
          label3.StyleId = "lblTotalBalance";
        NameScope.SetNameScope((BindableObject) bindable12, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable11, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable9, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable10, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) stackLayout2, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("stackAssessment", (object) stackLayout2);
        if (stackLayout2.StyleId == null)
          stackLayout2.StyleId = "stackAssessment";
        NameScope.SetNameScope((BindableObject) bindable27, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable26, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable15, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable13, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) label4, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("lblAssessment", (object) label4);
        if (label4.StyleId == null)
          label4.StyleId = "lblAssessment";
        NameScope.SetNameScope((BindableObject) label5, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("lblAssessmentAmt", (object) label5);
        if (label5.StyleId == null)
          label5.StyleId = "lblAssessmentAmt";
        NameScope.SetNameScope((BindableObject) bindable14, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) stackLayout3, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("stackRegFee", (object) stackLayout3);
        if (stackLayout3.StyleId == null)
          stackLayout3.StyleId = "stackRegFee";
        NameScope.SetNameScope((BindableObject) bindable16, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable17, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) label6, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("lblRegFeeAmt", (object) label6);
        if (label6.StyleId == null)
          label6.StyleId = "lblRegFeeAmt";
        NameScope.SetNameScope((BindableObject) stackLayout4, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("stackTutFees", (object) stackLayout4);
        if (stackLayout4.StyleId == null)
          stackLayout4.StyleId = "stackTutFees";
        NameScope.SetNameScope((BindableObject) bindable18, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) label7, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("lblTutHeader", (object) label7);
        if (label7.StyleId == null)
          label7.StyleId = "lblTutHeader";
        NameScope.SetNameScope((BindableObject) label8, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("lblTuitionAmt", (object) label8);
        if (label8.StyleId == null)
          label8.StyleId = "lblTuitionAmt";
        NameScope.SetNameScope((BindableObject) stackLayout5, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("stackTutMiscDetails", (object) stackLayout5);
        if (stackLayout5.StyleId == null)
          stackLayout5.StyleId = "stackTutMiscDetails";
        NameScope.SetNameScope((BindableObject) stackLayout6, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("stackOSF", (object) stackLayout6);
        if (stackLayout6.StyleId == null)
          stackLayout6.StyleId = "stackOSF";
        NameScope.SetNameScope((BindableObject) bindable19, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable20, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) label9, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("lblOSFAmt", (object) label9);
        if (label9.StyleId == null)
          label9.StyleId = "lblOSFAmt";
        NameScope.SetNameScope((BindableObject) stackLayout7, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("stackOSFDetails", (object) stackLayout7);
        if (stackLayout7.StyleId == null)
          stackLayout7.StyleId = "stackOSFDetails";
        NameScope.SetNameScope((BindableObject) stackLayout8, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("stackMiscellaneous", (object) stackLayout8);
        if (stackLayout8.StyleId == null)
          stackLayout8.StyleId = "stackMiscellaneous";
        NameScope.SetNameScope((BindableObject) bindable21, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable22, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) label10, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("lblMiscAmt", (object) label10);
        if (label10.StyleId == null)
          label10.StyleId = "lblMiscAmt";
        NameScope.SetNameScope((BindableObject) stackLayout9, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("stackMiscDetails", (object) stackLayout9);
        if (stackLayout9.StyleId == null)
          stackLayout9.StyleId = "stackMiscDetails";
        NameScope.SetNameScope((BindableObject) bindable25, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable23, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable24, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) stackLayout10, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("stackPaymentData", (object) stackLayout10);
        if (stackLayout10.StyleId == null)
          stackLayout10.StyleId = "stackPaymentData";
        NameScope.SetNameScope((BindableObject) bindable29, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable28, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) label11, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("lblTuitionGrand", (object) label11);
        if (label11.StyleId == null)
          label11.StyleId = "lblTuitionGrand";
        NameScope.SetNameScope((BindableObject) bindable31, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable30, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) label12, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("lbl_balance", (object) label12);
        if (label12.StyleId == null)
          label12.StyleId = "lbl_balance";
        NameScope.SetNameScope((BindableObject) frame1, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("frmNonTuition", (object) frame1);
        if (frame1.StyleId == null)
          frame1.StyleId = "frmNonTuition";
        NameScope.SetNameScope((BindableObject) bindable42, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable35, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable33, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable32, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) label13, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("lblOtherChrgstAmt", (object) label13);
        if (label13.StyleId == null)
          label13.StyleId = "lblOtherChrgstAmt";
        NameScope.SetNameScope((BindableObject) bindable34, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable38, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable36, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable37, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) stackLayout11, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("stackNonTuition", (object) stackLayout11);
        if (stackLayout11.StyleId == null)
          stackLayout11.StyleId = "stackNonTuition";
        NameScope.SetNameScope((BindableObject) bindable41, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable39, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable40, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) stackLayout12, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("stackNonTuitionPayment", (object) stackLayout12);
        if (stackLayout12.StyleId == null)
          stackLayout12.StyleId = "stackNonTuitionPayment";
        NameScope.SetNameScope((BindableObject) stackLayout13, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("stackNonTuitionTotals", (object) stackLayout13);
        if (stackLayout13.StyleId == null)
          stackLayout13.StyleId = "stackNonTuitionTotals";
        NameScope.SetNameScope((BindableObject) bindable44, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable43, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) label14, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("lblNonTuitionGrand", (object) label14);
        if (label14.StyleId == null)
          label14.StyleId = "lblNonTuitionGrand";
        NameScope.SetNameScope((BindableObject) bindable46, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable45, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) label15, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("lblNonTuitionBalance", (object) label15);
        if (label15.StyleId == null)
          label15.StyleId = "lblNonTuitionBalance";
        NameScope.SetNameScope((BindableObject) label16, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("lblLastSync", (object) label16);
        if (label16.StyleId == null)
          label16.StyleId = "lblLastSync";
        NameScope.SetNameScope((BindableObject) frame2, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("frameServerDown", (object) frame2);
        if (frame2.StyleId == null)
          frame2.StyleId = "frameServerDown";
        NameScope.SetNameScope((BindableObject) bindable47, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) label17, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("lblServerDown", (object) label17);
        if (label17.StyleId == null)
          label17.StyleId = "lblServerDown";
        NameScope.SetNameScope((BindableObject) stackLayout15, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("stackStatus", (object) stackLayout15);
        if (stackLayout15.StyleId == null)
          stackLayout15.StyleId = "stackStatus";
        NameScope.SetNameScope((BindableObject) label18, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("lblStatus", (object) label18);
        if (label18.StyleId == null)
          label18.StyleId = "lblStatus";
        this.stackSYTerm = stackLayout1;
        this.lblSYTerm = label1;
        this.imgPullDownTerms = image;
        this.pckrSchoolTerm = picker;
        this.refreshAssessment = pullToRefreshLayout;
        this.stackMain = stackLayout14;
        this.lblNetAsOf = label2;
        this.lblTotalBalance = label3;
        this.stackAssessment = stackLayout2;
        this.lblAssessment = label4;
        this.lblAssessmentAmt = label5;
        this.stackRegFee = stackLayout3;
        this.lblRegFeeAmt = label6;
        this.stackTutFees = stackLayout4;
        this.lblTutHeader = label7;
        this.lblTuitionAmt = label8;
        this.stackTutMiscDetails = stackLayout5;
        this.stackOSF = stackLayout6;
        this.lblOSFAmt = label9;
        this.stackOSFDetails = stackLayout7;
        this.stackMiscellaneous = stackLayout8;
        this.lblMiscAmt = label10;
        this.stackMiscDetails = stackLayout9;
        this.stackPaymentData = stackLayout10;
        this.lblTuitionGrand = label11;
        this.lbl_balance = label12;
        this.frmNonTuition = frame1;
        this.lblOtherChrgstAmt = label13;
        this.stackNonTuition = stackLayout11;
        this.stackNonTuitionPayment = stackLayout12;
        this.stackNonTuitionTotals = stackLayout13;
        this.lblNonTuitionGrand = label14;
        this.lblNonTuitionBalance = label15;
        this.lblLastSync = label16;
        this.frameServerDown = frame2;
        this.lblServerDown = label17;
        this.stackStatus = stackLayout15;
        this.lblStatus = label18;
        bindable51.SetValue(Page.IconProperty, new FileImageSourceConverter().ConvertFromInvariantString("ic_action_peso"));
        bindable50.SetValue(View.MarginProperty, (object) new Thickness(0.0));
        bindable50.SetValue(Layout.PaddingProperty, (object) new Thickness(0.0));
        bindable4.SetValue(Frame.HasShadowProperty, (object) true);
        bindable4.SetValue(Layout.PaddingProperty, (object) new Thickness(0.0, 5.0, 0.0, 5.0));
        bindable4.SetValue(View.MarginProperty, (object) new Thickness(10.0, 10.0, 10.0, 0.0));
        bindable4.SetValue(Frame.CornerRadiusProperty, (object) 15f);
        stackLayout1.SetValue(StackLayout.OrientationProperty, (object) StackOrientation.Vertical);
        stackLayout1.SetValue(StackLayout.SpacingProperty, (object) 0.0);
        stackLayout1.SetValue(View.MarginProperty, (object) new Thickness(20.0, 0.0, 20.0, 0.0));
        stackLayout1.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.CenterAndExpand);
        bindable1.Tapped += new EventHandler(bindable51.SYTerms_Tapped);
        stackLayout1.GestureRecognizers.Add((IGestureRecognizer) bindable1);
        bindable3.SetValue(StackLayout.OrientationProperty, (object) StackOrientation.Horizontal);
        bindable3.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.FillAndExpand);
        bindable2.SetValue(Image.SourceProperty, new ImageSourceConverter().ConvertFromInvariantString("ic_calendar_today"));
        bindable3.Children.Add((View) bindable2);
        label1.SetValue(Label.TextProperty, (object) "Loading School Year/Term...");
        resourceExtension1.Key = "smallHeader";
        StaticResourceExtension resourceExtension35 = resourceExtension1;
        XamlServiceProvider xamlServiceProvider1 = new XamlServiceProvider();
        Type type1 = typeof (IProvideValueTarget);
        object[] objectAndParents1 = new object[0 + 6];
        objectAndParents1[0] = (object) label1;
        objectAndParents1[1] = (object) bindable3;
        objectAndParents1[2] = (object) stackLayout1;
        objectAndParents1[3] = (object) bindable4;
        objectAndParents1[4] = (object) bindable50;
        objectAndParents1[5] = (object) bindable51;
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
        XamlTypeResolver service2 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver1, typeof (ViewSOAPage).GetTypeInfo().Assembly);
        xamlServiceProvider1.Add(type2, (object) service2);
        xamlServiceProvider1.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(19, 86)));
        object obj1 = resourceExtension35.ProvideValue((IServiceProvider) xamlServiceProvider1);
        label1.Style = (Style) obj1;
        label1.SetValue(View.VerticalOptionsProperty, (object) LayoutOptions.Center);
        bindable3.Children.Add((View) label1);
        image.SetValue(Image.SourceProperty, new ImageSourceConverter().ConvertFromInvariantString("ic_arrow_drop_down"));
        bindable3.Children.Add((View) image);
        stackLayout1.Children.Add((View) bindable3);
        bindable4.SetValue(ContentView.ContentProperty, (object) stackLayout1);
        bindable50.Children.Add((View) bindable4);
        picker.SetValue(Picker.TitleProperty, (object) "School Year/Term");
        picker.SetValue(VisualElement.IsVisibleProperty, new VisualElement.VisibilityConverter().ConvertFromInvariantString("False"));
        picker.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.FillAndExpand);
        picker.SelectedIndexChanged += new EventHandler(bindable51.pckrSchoolTerm_SelectedIndexChanged);
        bindable50.Children.Add((View) picker);
        pullToRefreshLayout.SetValue(PullToRefreshLayout.IsPullToRefreshEnabledProperty, (object) true);
        pullToRefreshLayout.SetValue(View.VerticalOptionsProperty, (object) LayoutOptions.FillAndExpand);
        bindable49.SetValue(View.VerticalOptionsProperty, (object) LayoutOptions.FillAndExpand);
        bindable48.SetValue(StackLayout.SpacingProperty, (object) 0.0);
        bindable6.SetValue(StackLayout.OrientationProperty, (object) StackOrientation.Horizontal);
        bindable6.SetValue(View.MarginProperty, (object) new Thickness(10.0));
        bindable6.SetValue(Layout.PaddingProperty, (object) new Thickness(10.0));
        bindable6.SetValue(VisualElement.BackgroundColorProperty, (object) new Color(0.854901969432831, 0.874509811401367, 0.882352948188782, 1.0));
        bindable6.SetValue(VisualElement.IsVisibleProperty, new VisualElement.VisibilityConverter().ConvertFromInvariantString("False"));
        bindable5.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.CenterAndExpand);
        bindable5.SetValue(Label.HorizontalTextAlignmentProperty, new TextAlignmentConverter().ConvertFromInvariantString("Center"));
        bindable5.SetValue(Label.TextProperty, (object) "Your latest transaction/s will reflect within 24 hours.");
        resourceExtension2.Key = "smallHeader";
        StaticResourceExtension resourceExtension36 = resourceExtension2;
        XamlServiceProvider xamlServiceProvider2 = new XamlServiceProvider();
        Type type3 = typeof (IProvideValueTarget);
        object[] objectAndParents2 = new object[0 + 7];
        objectAndParents2[0] = (object) bindable5;
        objectAndParents2[1] = (object) bindable6;
        objectAndParents2[2] = (object) bindable48;
        objectAndParents2[3] = (object) bindable49;
        objectAndParents2[4] = (object) pullToRefreshLayout;
        objectAndParents2[5] = (object) bindable50;
        objectAndParents2[6] = (object) bindable51;
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
        XamlTypeResolver service4 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver2, typeof (ViewSOAPage).GetTypeInfo().Assembly);
        xamlServiceProvider2.Add(type4, (object) service4);
        xamlServiceProvider2.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(37, 168)));
        object obj2 = resourceExtension36.ProvideValue((IServiceProvider) xamlServiceProvider2);
        bindable5.Style = (Style) obj2;
        bindable5.SetValue(Label.TextColorProperty, (object) new Color(0.250980406999588, 0.250980406999588, 0.250980406999588, 1.0));
        bindable6.Children.Add((View) bindable5);
        bindable48.Children.Add((View) bindable6);
        label2.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.Center);
        label2.SetValue(View.MarginProperty, (object) new Thickness(0.0, 10.0, 0.0, 0.0));
        label2.SetValue(VisualElement.IsVisibleProperty, new VisualElement.VisibilityConverter().ConvertFromInvariantString("False"));
        resourceExtension3.Key = "microLabel";
        StaticResourceExtension resourceExtension37 = resourceExtension3;
        XamlServiceProvider xamlServiceProvider3 = new XamlServiceProvider();
        Type type5 = typeof (IProvideValueTarget);
        object[] objectAndParents3 = new object[0 + 7];
        objectAndParents3[0] = (object) label2;
        objectAndParents3[1] = (object) stackLayout14;
        objectAndParents3[2] = (object) bindable48;
        objectAndParents3[3] = (object) bindable49;
        objectAndParents3[4] = (object) pullToRefreshLayout;
        objectAndParents3[5] = (object) bindable50;
        objectAndParents3[6] = (object) bindable51;
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
        XamlTypeResolver service6 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver3, typeof (ViewSOAPage).GetTypeInfo().Assembly);
        xamlServiceProvider3.Add(type6, (object) service6);
        xamlServiceProvider3.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(42, 119)));
        object obj3 = resourceExtension37.ProvideValue((IServiceProvider) xamlServiceProvider3);
        label2.Style = (Style) obj3;
        label2.SetValue(Label.FontFamilyProperty, (object) "Roboto-Regular.ttf#Roboto");
        stackLayout14.Children.Add((View) label2);
        bindable8.SetValue(StackLayout.OrientationProperty, (object) StackOrientation.Horizontal);
        bindable8.SetValue(View.MarginProperty, (object) new Thickness(10.0));
        bindable8.SetValue(Layout.PaddingProperty, (object) new Thickness(20.0, 10.0, 20.0, 10.0));
        bindable8.SetValue(VisualElement.BackgroundColorProperty, (object) new Color(0.905882358551025, 0.752941191196442, 0.113725490868092, 1.0));
        bindable7.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.StartAndExpand);
        bindable7.SetValue(Label.TextProperty, (object) "Total Balance");
        resourceExtension4.Key = "normalHeader";
        StaticResourceExtension resourceExtension38 = resourceExtension4;
        XamlServiceProvider xamlServiceProvider4 = new XamlServiceProvider();
        Type type7 = typeof (IProvideValueTarget);
        object[] objectAndParents4 = new object[0 + 8];
        objectAndParents4[0] = (object) bindable7;
        objectAndParents4[1] = (object) bindable8;
        objectAndParents4[2] = (object) stackLayout14;
        objectAndParents4[3] = (object) bindable48;
        objectAndParents4[4] = (object) bindable49;
        objectAndParents4[5] = (object) pullToRefreshLayout;
        objectAndParents4[6] = (object) bindable50;
        objectAndParents4[7] = (object) bindable51;
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
        XamlTypeResolver service8 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver4, typeof (ViewSOAPage).GetTypeInfo().Assembly);
        xamlServiceProvider4.Add(type8, (object) service8);
        xamlServiceProvider4.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(44, 96)));
        object obj4 = resourceExtension38.ProvideValue((IServiceProvider) xamlServiceProvider4);
        bindable7.Style = (Style) obj4;
        bindable7.SetValue(Label.TextColorProperty, (object) new Color(0.250980406999588, 0.250980406999588, 0.250980406999588, 1.0));
        bindable8.Children.Add((View) bindable7);
        label3.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.End);
        label3.SetValue(Label.HorizontalTextAlignmentProperty, new TextAlignmentConverter().ConvertFromInvariantString("End"));
        label3.SetValue(Label.TextProperty, (object) "PhP 0.00");
        resourceExtension5.Key = "normalHeader";
        StaticResourceExtension resourceExtension39 = resourceExtension5;
        XamlServiceProvider xamlServiceProvider5 = new XamlServiceProvider();
        Type type9 = typeof (IProvideValueTarget);
        object[] objectAndParents5 = new object[0 + 8];
        objectAndParents5[0] = (object) label3;
        objectAndParents5[1] = (object) bindable8;
        objectAndParents5[2] = (object) stackLayout14;
        objectAndParents5[3] = (object) bindable48;
        objectAndParents5[4] = (object) bindable49;
        objectAndParents5[5] = (object) pullToRefreshLayout;
        objectAndParents5[6] = (object) bindable50;
        objectAndParents5[7] = (object) bindable51;
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
        XamlTypeResolver service10 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver5, typeof (ViewSOAPage).GetTypeInfo().Assembly);
        xamlServiceProvider5.Add(type10, (object) service10);
        xamlServiceProvider5.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(45, 135)));
        object obj5 = resourceExtension39.ProvideValue((IServiceProvider) xamlServiceProvider5);
        label3.Style = (Style) obj5;
        label3.SetValue(Label.TextColorProperty, (object) new Color(0.250980406999588, 0.250980406999588, 0.250980406999588, 1.0));
        bindable8.Children.Add((View) label3);
        stackLayout14.Children.Add((View) bindable8);
        bindable12.SetValue(View.MarginProperty, (object) new Thickness(10.0));
        bindable12.SetValue(Layout.PaddingProperty, (object) new Thickness(20.0, 20.0, 20.0, 10.0));
        bindable12.SetValue(Frame.CornerRadiusProperty, (object) 5f);
        bindable9.SetValue(Label.TextProperty, (object) "Payment Schedule");
        resourceExtension6.Key = "mediumHeader";
        StaticResourceExtension resourceExtension40 = resourceExtension6;
        XamlServiceProvider xamlServiceProvider6 = new XamlServiceProvider();
        Type type11 = typeof (IProvideValueTarget);
        object[] objectAndParents6 = new object[0 + 9];
        objectAndParents6[0] = (object) bindable9;
        objectAndParents6[1] = (object) bindable11;
        objectAndParents6[2] = (object) bindable12;
        objectAndParents6[3] = (object) stackLayout14;
        objectAndParents6[4] = (object) bindable48;
        objectAndParents6[5] = (object) bindable49;
        objectAndParents6[6] = (object) pullToRefreshLayout;
        objectAndParents6[7] = (object) bindable50;
        objectAndParents6[8] = (object) bindable51;
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
        namespaceResolver6.Add("controls", "clr-namespace:Refractored.XamForms.PullToRefresh;assembly=Refractored.XamForms.PullToRefresh");
        XamlTypeResolver service12 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver6, typeof (ViewSOAPage).GetTypeInfo().Assembly);
        xamlServiceProvider6.Add(type12, (object) service12);
        xamlServiceProvider6.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(50, 68)));
        object obj6 = resourceExtension40.ProvideValue((IServiceProvider) xamlServiceProvider6);
        bindable9.Style = (Style) obj6;
        bindable9.SetValue(Label.TextColorProperty, (object) new Color(0.250980406999588, 0.250980406999588, 0.250980406999588, 1.0));
        bindable9.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.FillAndExpand);
        bindable11.Children.Add((View) bindable9);
        bindable10.SetValue(BoxView.ColorProperty, (object) new Color(0.905882358551025, 0.752941191196442, 0.113725490868092, 1.0));
        bindable10.SetValue(VisualElement.HeightRequestProperty, (object) 1.5);
        bindable10.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.FillAndExpand);
        bindable11.Children.Add((View) bindable10);
        stackLayout2.SetValue(View.MarginProperty, (object) new Thickness(23.0, 5.0, 10.0, 5.0));
        stackLayout2.SetValue(StackLayout.SpacingProperty, (object) 5.0);
        bindable11.Children.Add((View) stackLayout2);
        bindable12.SetValue(ContentView.ContentProperty, (object) bindable11);
        stackLayout14.Children.Add((View) bindable12);
        bindable27.SetValue(View.MarginProperty, (object) new Thickness(10.0));
        bindable27.SetValue(Layout.PaddingProperty, (object) new Thickness(20.0, 20.0, 20.0, 10.0));
        bindable27.SetValue(Frame.CornerRadiusProperty, (object) 5f);
        bindable13.SetValue(StackLayout.OrientationProperty, (object) StackOrientation.Horizontal);
        label4.SetValue(Label.TextProperty, (object) "Gross Assessment");
        resourceExtension7.Key = "mediumHeader";
        StaticResourceExtension resourceExtension41 = resourceExtension7;
        XamlServiceProvider xamlServiceProvider7 = new XamlServiceProvider();
        Type type13 = typeof (IProvideValueTarget);
        object[] objectAndParents7 = new object[0 + 11];
        objectAndParents7[0] = (object) label4;
        objectAndParents7[1] = (object) bindable13;
        objectAndParents7[2] = (object) bindable15;
        objectAndParents7[3] = (object) bindable26;
        objectAndParents7[4] = (object) bindable27;
        objectAndParents7[5] = (object) stackLayout14;
        objectAndParents7[6] = (object) bindable48;
        objectAndParents7[7] = (object) bindable49;
        objectAndParents7[8] = (object) pullToRefreshLayout;
        objectAndParents7[9] = (object) bindable50;
        objectAndParents7[10] = (object) bindable51;
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
        XamlTypeResolver service14 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver7, typeof (ViewSOAPage).GetTypeInfo().Assembly);
        xamlServiceProvider7.Add(type14, (object) service14);
        xamlServiceProvider7.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(63, 99)));
        object obj7 = resourceExtension41.ProvideValue((IServiceProvider) xamlServiceProvider7);
        label4.Style = (Style) obj7;
        label4.SetValue(Label.TextColorProperty, (object) new Color(0.250980406999588, 0.250980406999588, 0.250980406999588, 1.0));
        label4.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.FillAndExpand);
        bindable13.Children.Add((View) label4);
        resourceExtension8.Key = "normalHeader";
        StaticResourceExtension resourceExtension42 = resourceExtension8;
        XamlServiceProvider xamlServiceProvider8 = new XamlServiceProvider();
        Type type15 = typeof (IProvideValueTarget);
        object[] objectAndParents8 = new object[0 + 11];
        objectAndParents8[0] = (object) label5;
        objectAndParents8[1] = (object) bindable13;
        objectAndParents8[2] = (object) bindable15;
        objectAndParents8[3] = (object) bindable26;
        objectAndParents8[4] = (object) bindable27;
        objectAndParents8[5] = (object) stackLayout14;
        objectAndParents8[6] = (object) bindable48;
        objectAndParents8[7] = (object) bindable49;
        objectAndParents8[8] = (object) pullToRefreshLayout;
        objectAndParents8[9] = (object) bindable50;
        objectAndParents8[10] = (object) bindable51;
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
        namespaceResolver8.Add("controls", "clr-namespace:Refractored.XamForms.PullToRefresh;assembly=Refractored.XamForms.PullToRefresh");
        XamlTypeResolver service16 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver8, typeof (ViewSOAPage).GetTypeInfo().Assembly);
        xamlServiceProvider8.Add(type16, (object) service16);
        xamlServiceProvider8.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(64, 79)));
        object obj8 = resourceExtension42.ProvideValue((IServiceProvider) xamlServiceProvider8);
        label5.Style = (Style) obj8;
        label5.SetValue(Label.TextColorProperty, (object) new Color(0.250980406999588, 0.250980406999588, 0.250980406999588, 1.0));
        label5.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.End);
        label5.SetValue(Label.HorizontalTextAlignmentProperty, new TextAlignmentConverter().ConvertFromInvariantString("End"));
        bindable13.Children.Add((View) label5);
        bindable15.Children.Add((View) bindable13);
        bindable14.SetValue(BoxView.ColorProperty, (object) new Color(0.905882358551025, 0.752941191196442, 0.113725490868092, 1.0));
        bindable14.SetValue(VisualElement.HeightRequestProperty, (object) 1.5);
        bindable14.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.FillAndExpand);
        bindable15.Children.Add((View) bindable14);
        bindable26.Children.Add((View) bindable15);
        stackLayout3.SetValue(VisualElement.BackgroundColorProperty, (object) new Color(0.854901969432831, 0.874509811401367, 0.882352948188782, 1.0));
        stackLayout3.SetValue(StackLayout.OrientationProperty, (object) StackOrientation.Horizontal);
        stackLayout3.SetValue(Layout.PaddingProperty, (object) new Thickness(10.0));
        stackLayout3.SetValue(View.MarginProperty, (object) new Thickness(0.0, 10.0, 0.0, 5.0));
        stackLayout3.SetValue(StackLayout.SpacingProperty, (object) 0.0);
        stackLayout3.SetValue(VisualElement.IsVisibleProperty, new VisualElement.VisibilityConverter().ConvertFromInvariantString("False"));
        bindable16.SetValue(Image.SourceProperty, new ImageSourceConverter().ConvertFromInvariantString("ic_pin"));
        bindable16.SetValue(View.VerticalOptionsProperty, (object) LayoutOptions.Start);
        bindable16.SetValue(View.MarginProperty, (object) new Thickness(0.0, 3.0, 0.0, 0.0));
        stackLayout3.Children.Add((View) bindable16);
        bindable17.SetValue(Label.TextProperty, (object) "Registration Fee");
        resourceExtension9.Key = "smallHeader";
        StaticResourceExtension resourceExtension43 = resourceExtension9;
        XamlServiceProvider xamlServiceProvider9 = new XamlServiceProvider();
        Type type17 = typeof (IProvideValueTarget);
        object[] objectAndParents9 = new object[0 + 10];
        objectAndParents9[0] = (object) bindable17;
        objectAndParents9[1] = (object) stackLayout3;
        objectAndParents9[2] = (object) bindable26;
        objectAndParents9[3] = (object) bindable27;
        objectAndParents9[4] = (object) stackLayout14;
        objectAndParents9[5] = (object) bindable48;
        objectAndParents9[6] = (object) bindable49;
        objectAndParents9[7] = (object) pullToRefreshLayout;
        objectAndParents9[8] = (object) bindable50;
        objectAndParents9[9] = (object) bindable51;
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
        XamlTypeResolver service18 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver9, typeof (ViewSOAPage).GetTypeInfo().Assembly);
        xamlServiceProvider9.Add(type18, (object) service18);
        xamlServiceProvider9.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(73, 72)));
        object obj9 = resourceExtension43.ProvideValue((IServiceProvider) xamlServiceProvider9);
        bindable17.Style = (Style) obj9;
        bindable17.SetValue(View.MarginProperty, (object) new Thickness(7.0, 0.0, 0.0, 0.0));
        bindable17.SetValue(Label.TextColorProperty, (object) new Color(0.180392161011696, 0.192156866192818, 0.192156866192818, 1.0));
        bindable17.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.FillAndExpand);
        stackLayout3.Children.Add((View) bindable17);
        label6.SetValue(Label.TextProperty, (object) "PhP 0.00");
        resourceExtension10.Key = "smallHeader";
        StaticResourceExtension resourceExtension44 = resourceExtension10;
        XamlServiceProvider xamlServiceProvider10 = new XamlServiceProvider();
        Type type19 = typeof (IProvideValueTarget);
        object[] objectAndParents10 = new object[0 + 10];
        objectAndParents10[0] = (object) label6;
        objectAndParents10[1] = (object) stackLayout3;
        objectAndParents10[2] = (object) bindable26;
        objectAndParents10[3] = (object) bindable27;
        objectAndParents10[4] = (object) stackLayout14;
        objectAndParents10[5] = (object) bindable48;
        objectAndParents10[6] = (object) bindable49;
        objectAndParents10[7] = (object) pullToRefreshLayout;
        objectAndParents10[8] = (object) bindable50;
        objectAndParents10[9] = (object) bindable51;
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
        XamlTypeResolver service20 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver10, typeof (ViewSOAPage).GetTypeInfo().Assembly);
        xamlServiceProvider10.Add(type20, (object) service20);
        xamlServiceProvider10.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(74, 86)));
        object obj10 = resourceExtension44.ProvideValue((IServiceProvider) xamlServiceProvider10);
        label6.Style = (Style) obj10;
        label6.SetValue(Label.TextColorProperty, (object) new Color(0.180392161011696, 0.192156866192818, 0.192156866192818, 1.0));
        label6.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.End);
        stackLayout3.Children.Add((View) label6);
        bindable26.Children.Add((View) stackLayout3);
        stackLayout4.SetValue(VisualElement.BackgroundColorProperty, (object) new Color(0.854901969432831, 0.874509811401367, 0.882352948188782, 1.0));
        stackLayout4.SetValue(StackLayout.OrientationProperty, (object) StackOrientation.Horizontal);
        stackLayout4.SetValue(Layout.PaddingProperty, (object) new Thickness(10.0));
        stackLayout4.SetValue(View.MarginProperty, (object) new Thickness(0.0, 10.0, 0.0, 5.0));
        stackLayout4.SetValue(StackLayout.SpacingProperty, (object) 0.0);
        bindable18.SetValue(Image.SourceProperty, new ImageSourceConverter().ConvertFromInvariantString("ic_pin"));
        bindable18.SetValue(View.VerticalOptionsProperty, (object) LayoutOptions.Start);
        bindable18.SetValue(View.MarginProperty, (object) new Thickness(0.0, 3.0, 0.0, 0.0));
        stackLayout4.Children.Add((View) bindable18);
        label7.SetValue(Label.TextProperty, (object) "Tuition Fees");
        resourceExtension11.Key = "smallHeader";
        StaticResourceExtension resourceExtension45 = resourceExtension11;
        XamlServiceProvider xamlServiceProvider11 = new XamlServiceProvider();
        Type type21 = typeof (IProvideValueTarget);
        object[] objectAndParents11 = new object[0 + 10];
        objectAndParents11[0] = (object) label7;
        objectAndParents11[1] = (object) stackLayout4;
        objectAndParents11[2] = (object) bindable26;
        objectAndParents11[3] = (object) bindable27;
        objectAndParents11[4] = (object) stackLayout14;
        objectAndParents11[5] = (object) bindable48;
        objectAndParents11[6] = (object) bindable49;
        objectAndParents11[7] = (object) pullToRefreshLayout;
        objectAndParents11[8] = (object) bindable50;
        objectAndParents11[9] = (object) bindable51;
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
        XamlTypeResolver service22 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver11, typeof (ViewSOAPage).GetTypeInfo().Assembly);
        xamlServiceProvider11.Add(type22, (object) service22);
        xamlServiceProvider11.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(79, 90)));
        object obj11 = resourceExtension45.ProvideValue((IServiceProvider) xamlServiceProvider11);
        label7.Style = (Style) obj11;
        label7.SetValue(View.MarginProperty, (object) new Thickness(7.0, 0.0, 0.0, 0.0));
        label7.SetValue(Label.TextColorProperty, (object) new Color(0.180392161011696, 0.192156866192818, 0.192156866192818, 1.0));
        label7.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.FillAndExpand);
        stackLayout4.Children.Add((View) label7);
        label8.SetValue(Label.TextProperty, (object) "PhP 0.00");
        resourceExtension12.Key = "smallHeader";
        StaticResourceExtension resourceExtension46 = resourceExtension12;
        XamlServiceProvider xamlServiceProvider12 = new XamlServiceProvider();
        Type type23 = typeof (IProvideValueTarget);
        object[] objectAndParents12 = new object[0 + 10];
        objectAndParents12[0] = (object) label8;
        objectAndParents12[1] = (object) stackLayout4;
        objectAndParents12[2] = (object) bindable26;
        objectAndParents12[3] = (object) bindable27;
        objectAndParents12[4] = (object) stackLayout14;
        objectAndParents12[5] = (object) bindable48;
        objectAndParents12[6] = (object) bindable49;
        objectAndParents12[7] = (object) pullToRefreshLayout;
        objectAndParents12[8] = (object) bindable50;
        objectAndParents12[9] = (object) bindable51;
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
        XamlTypeResolver service24 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver12, typeof (ViewSOAPage).GetTypeInfo().Assembly);
        xamlServiceProvider12.Add(type24, (object) service24);
        xamlServiceProvider12.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(80, 87)));
        object obj12 = resourceExtension46.ProvideValue((IServiceProvider) xamlServiceProvider12);
        label8.Style = (Style) obj12;
        label8.SetValue(Label.TextColorProperty, (object) new Color(0.180392161011696, 0.192156866192818, 0.192156866192818, 1.0));
        label8.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.End);
        stackLayout4.Children.Add((View) label8);
        bindable26.Children.Add((View) stackLayout4);
        stackLayout5.SetValue(View.MarginProperty, (object) new Thickness(30.0, 0.0, 10.0, 0.0));
        stackLayout5.SetValue(StackLayout.SpacingProperty, (object) 8.0);
        stackLayout5.SetValue(VisualElement.IsVisibleProperty, new VisualElement.VisibilityConverter().ConvertFromInvariantString("False"));
        bindable26.Children.Add((View) stackLayout5);
        stackLayout6.SetValue(VisualElement.BackgroundColorProperty, (object) new Color(0.854901969432831, 0.874509811401367, 0.882352948188782, 1.0));
        stackLayout6.SetValue(StackLayout.OrientationProperty, (object) StackOrientation.Horizontal);
        stackLayout6.SetValue(Layout.PaddingProperty, (object) new Thickness(10.0));
        stackLayout6.SetValue(View.MarginProperty, (object) new Thickness(0.0, 5.0, 0.0, 5.0));
        stackLayout6.SetValue(StackLayout.SpacingProperty, (object) 0.0);
        bindable19.SetValue(Image.SourceProperty, new ImageSourceConverter().ConvertFromInvariantString("ic_pin"));
        bindable19.SetValue(View.VerticalOptionsProperty, (object) LayoutOptions.Start);
        bindable19.SetValue(View.MarginProperty, (object) new Thickness(0.0, 3.0, 0.0, 0.0));
        stackLayout6.Children.Add((View) bindable19);
        bindable20.SetValue(Label.TextProperty, (object) "Other School Fees");
        bindable20.SetValue(View.MarginProperty, (object) new Thickness(7.0, 0.0, 0.0, 0.0));
        resourceExtension13.Key = "smallHeader";
        StaticResourceExtension resourceExtension47 = resourceExtension13;
        XamlServiceProvider xamlServiceProvider13 = new XamlServiceProvider();
        Type type25 = typeof (IProvideValueTarget);
        object[] objectAndParents13 = new object[0 + 10];
        objectAndParents13[0] = (object) bindable20;
        objectAndParents13[1] = (object) stackLayout6;
        objectAndParents13[2] = (object) bindable26;
        objectAndParents13[3] = (object) bindable27;
        objectAndParents13[4] = (object) stackLayout14;
        objectAndParents13[5] = (object) bindable48;
        objectAndParents13[6] = (object) bindable49;
        objectAndParents13[7] = (object) pullToRefreshLayout;
        objectAndParents13[8] = (object) bindable50;
        objectAndParents13[9] = (object) bindable51;
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
        XamlTypeResolver service26 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver13, typeof (ViewSOAPage).GetTypeInfo().Assembly);
        xamlServiceProvider13.Add(type26, (object) service26);
        xamlServiceProvider13.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(87, 90)));
        object obj13 = resourceExtension47.ProvideValue((IServiceProvider) xamlServiceProvider13);
        bindable20.Style = (Style) obj13;
        bindable20.SetValue(Label.TextColorProperty, (object) new Color(0.180392161011696, 0.192156866192818, 0.192156866192818, 1.0));
        bindable20.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.FillAndExpand);
        stackLayout6.Children.Add((View) bindable20);
        label9.SetValue(Label.TextProperty, (object) "PhP 0.00");
        resourceExtension14.Key = "smallHeader";
        StaticResourceExtension resourceExtension48 = resourceExtension14;
        XamlServiceProvider xamlServiceProvider14 = new XamlServiceProvider();
        Type type27 = typeof (IProvideValueTarget);
        object[] objectAndParents14 = new object[0 + 10];
        objectAndParents14[0] = (object) label9;
        objectAndParents14[1] = (object) stackLayout6;
        objectAndParents14[2] = (object) bindable26;
        objectAndParents14[3] = (object) bindable27;
        objectAndParents14[4] = (object) stackLayout14;
        objectAndParents14[5] = (object) bindable48;
        objectAndParents14[6] = (object) bindable49;
        objectAndParents14[7] = (object) pullToRefreshLayout;
        objectAndParents14[8] = (object) bindable50;
        objectAndParents14[9] = (object) bindable51;
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
        XamlTypeResolver service28 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver14, typeof (ViewSOAPage).GetTypeInfo().Assembly);
        xamlServiceProvider14.Add(type28, (object) service28);
        xamlServiceProvider14.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(88, 83)));
        object obj14 = resourceExtension48.ProvideValue((IServiceProvider) xamlServiceProvider14);
        label9.Style = (Style) obj14;
        label9.SetValue(Label.TextColorProperty, (object) new Color(0.180392161011696, 0.192156866192818, 0.192156866192818, 1.0));
        label9.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.End);
        stackLayout6.Children.Add((View) label9);
        bindable26.Children.Add((View) stackLayout6);
        stackLayout7.SetValue(View.MarginProperty, (object) new Thickness(30.0, 0.0, 10.0, 0.0));
        stackLayout7.SetValue(StackLayout.SpacingProperty, (object) 8.0);
        bindable26.Children.Add((View) stackLayout7);
        stackLayout8.SetValue(VisualElement.BackgroundColorProperty, (object) new Color(0.854901969432831, 0.874509811401367, 0.882352948188782, 1.0));
        stackLayout8.SetValue(StackLayout.OrientationProperty, (object) StackOrientation.Horizontal);
        stackLayout8.SetValue(Layout.PaddingProperty, (object) new Thickness(10.0));
        stackLayout8.SetValue(View.MarginProperty, (object) new Thickness(0.0, 10.0, 0.0, 5.0));
        stackLayout8.SetValue(StackLayout.SpacingProperty, (object) 0.0);
        bindable21.SetValue(Image.SourceProperty, new ImageSourceConverter().ConvertFromInvariantString("ic_pin"));
        bindable21.SetValue(View.VerticalOptionsProperty, (object) LayoutOptions.Start);
        bindable21.SetValue(View.MarginProperty, (object) new Thickness(0.0, 3.0, 0.0, 0.0));
        stackLayout8.Children.Add((View) bindable21);
        bindable22.SetValue(Label.TextProperty, (object) "Miscellaneous Fees");
        bindable22.SetValue(View.MarginProperty, (object) new Thickness(7.0, 0.0, 0.0, 0.0));
        resourceExtension15.Key = "smallHeader";
        StaticResourceExtension resourceExtension49 = resourceExtension15;
        XamlServiceProvider xamlServiceProvider15 = new XamlServiceProvider();
        Type type29 = typeof (IProvideValueTarget);
        object[] objectAndParents15 = new object[0 + 10];
        objectAndParents15[0] = (object) bindable22;
        objectAndParents15[1] = (object) stackLayout8;
        objectAndParents15[2] = (object) bindable26;
        objectAndParents15[3] = (object) bindable27;
        objectAndParents15[4] = (object) stackLayout14;
        objectAndParents15[5] = (object) bindable48;
        objectAndParents15[6] = (object) bindable49;
        objectAndParents15[7] = (object) pullToRefreshLayout;
        objectAndParents15[8] = (object) bindable50;
        objectAndParents15[9] = (object) bindable51;
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
        XamlTypeResolver service30 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver15, typeof (ViewSOAPage).GetTypeInfo().Assembly);
        xamlServiceProvider15.Add(type30, (object) service30);
        xamlServiceProvider15.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(95, 91)));
        object obj15 = resourceExtension49.ProvideValue((IServiceProvider) xamlServiceProvider15);
        bindable22.Style = (Style) obj15;
        bindable22.SetValue(Label.TextColorProperty, (object) new Color(0.180392161011696, 0.192156866192818, 0.192156866192818, 1.0));
        bindable22.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.FillAndExpand);
        stackLayout8.Children.Add((View) bindable22);
        label10.SetValue(Label.TextProperty, (object) "PhP 0.00");
        resourceExtension16.Key = "smallHeader";
        StaticResourceExtension resourceExtension50 = resourceExtension16;
        XamlServiceProvider xamlServiceProvider16 = new XamlServiceProvider();
        Type type31 = typeof (IProvideValueTarget);
        object[] objectAndParents16 = new object[0 + 10];
        objectAndParents16[0] = (object) label10;
        objectAndParents16[1] = (object) stackLayout8;
        objectAndParents16[2] = (object) bindable26;
        objectAndParents16[3] = (object) bindable27;
        objectAndParents16[4] = (object) stackLayout14;
        objectAndParents16[5] = (object) bindable48;
        objectAndParents16[6] = (object) bindable49;
        objectAndParents16[7] = (object) pullToRefreshLayout;
        objectAndParents16[8] = (object) bindable50;
        objectAndParents16[9] = (object) bindable51;
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
        namespaceResolver16.Add("controls", "clr-namespace:Refractored.XamForms.PullToRefresh;assembly=Refractored.XamForms.PullToRefresh");
        XamlTypeResolver service32 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver16, typeof (ViewSOAPage).GetTypeInfo().Assembly);
        xamlServiceProvider16.Add(type32, (object) service32);
        xamlServiceProvider16.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(96, 84)));
        object obj16 = resourceExtension50.ProvideValue((IServiceProvider) xamlServiceProvider16);
        label10.Style = (Style) obj16;
        label10.SetValue(Label.TextColorProperty, (object) new Color(0.180392161011696, 0.192156866192818, 0.192156866192818, 1.0));
        label10.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.End);
        stackLayout8.Children.Add((View) label10);
        bindable26.Children.Add((View) stackLayout8);
        stackLayout9.SetValue(View.MarginProperty, (object) new Thickness(30.0, 0.0, 10.0, 0.0));
        stackLayout9.SetValue(StackLayout.SpacingProperty, (object) 8.0);
        bindable26.Children.Add((View) stackLayout9);
        bindable25.SetValue(View.MarginProperty, (object) new Thickness(0.0, 30.0, 0.0, 10.0));
        bindable23.SetValue(Label.TextProperty, (object) "Payments and Adjustments");
        resourceExtension17.Key = "mediumHeader";
        StaticResourceExtension resourceExtension51 = resourceExtension17;
        XamlServiceProvider xamlServiceProvider17 = new XamlServiceProvider();
        Type type33 = typeof (IProvideValueTarget);
        object[] objectAndParents17 = new object[0 + 10];
        objectAndParents17[0] = (object) bindable23;
        objectAndParents17[1] = (object) bindable25;
        objectAndParents17[2] = (object) bindable26;
        objectAndParents17[3] = (object) bindable27;
        objectAndParents17[4] = (object) stackLayout14;
        objectAndParents17[5] = (object) bindable48;
        objectAndParents17[6] = (object) bindable49;
        objectAndParents17[7] = (object) pullToRefreshLayout;
        objectAndParents17[8] = (object) bindable50;
        objectAndParents17[9] = (object) bindable51;
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
        namespaceResolver17.Add("controls", "clr-namespace:Refractored.XamForms.PullToRefresh;assembly=Refractored.XamForms.PullToRefresh");
        XamlTypeResolver service34 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver17, typeof (ViewSOAPage).GetTypeInfo().Assembly);
        xamlServiceProvider17.Add(type34, (object) service34);
        xamlServiceProvider17.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(128, 80)));
        object obj17 = resourceExtension51.ProvideValue((IServiceProvider) xamlServiceProvider17);
        bindable23.Style = (Style) obj17;
        bindable23.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.FillAndExpand);
        bindable23.SetValue(Label.TextColorProperty, (object) new Color(0.250980406999588, 0.250980406999588, 0.250980406999588, 1.0));
        bindable25.Children.Add((View) bindable23);
        bindable24.SetValue(BoxView.ColorProperty, (object) new Color(0.905882358551025, 0.752941191196442, 0.113725490868092, 1.0));
        bindable24.SetValue(VisualElement.HeightRequestProperty, (object) 1.5);
        bindable24.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.FillAndExpand);
        bindable25.Children.Add((View) bindable24);
        bindable26.Children.Add((View) bindable25);
        stackLayout10.SetValue(View.MarginProperty, (object) new Thickness(0.0, 5.0, 0.0, 0.0));
        stackLayout10.SetValue(StackLayout.SpacingProperty, (object) 5.0);
        bindable26.Children.Add((View) stackLayout10);
        bindable27.SetValue(ContentView.ContentProperty, (object) bindable26);
        stackLayout14.Children.Add((View) bindable27);
        bindable29.SetValue(StackLayout.OrientationProperty, (object) StackOrientation.Horizontal);
        resourceExtension18.Key = "PrimaryColor";
        StaticResourceExtension resourceExtension52 = resourceExtension18;
        XamlServiceProvider xamlServiceProvider18 = new XamlServiceProvider();
        Type type35 = typeof (IProvideValueTarget);
        object[] objectAndParents18 = new object[0 + 7];
        objectAndParents18[0] = (object) bindable29;
        objectAndParents18[1] = (object) stackLayout14;
        objectAndParents18[2] = (object) bindable48;
        objectAndParents18[3] = (object) bindable49;
        objectAndParents18[4] = (object) pullToRefreshLayout;
        objectAndParents18[5] = (object) bindable50;
        objectAndParents18[6] = (object) bindable51;
        SimpleValueTargetProvider service35 = new SimpleValueTargetProvider(objectAndParents18, (object) VisualElement.BackgroundColorProperty);
        xamlServiceProvider18.Add(type35, (object) service35);
        xamlServiceProvider18.Add(typeof (INameScopeProvider), (object) new NameScopeProvider()
        {
          NameScope = (INameScope) nameScope
        });
        Type type36 = typeof (IXamlTypeResolver);
        XmlNamespaceResolver namespaceResolver18 = new XmlNamespaceResolver();
        namespaceResolver18.Add("", "http://xamarin.com/schemas/2014/forms");
        namespaceResolver18.Add("x", "http://schemas.microsoft.com/winfx/2009/xaml");
        namespaceResolver18.Add("controls", "clr-namespace:Refractored.XamForms.PullToRefresh;assembly=Refractored.XamForms.PullToRefresh");
        XamlTypeResolver service36 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver18, typeof (ViewSOAPage).GetTypeInfo().Assembly);
        xamlServiceProvider18.Add(type36, (object) service36);
        xamlServiceProvider18.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(147, 68)));
        object obj18 = resourceExtension52.ProvideValue((IServiceProvider) xamlServiceProvider18);
        bindable29.BackgroundColor = (Color) obj18;
        bindable29.SetValue(Layout.PaddingProperty, (object) new Thickness(10.0));
        bindable29.SetValue(View.MarginProperty, (object) new Thickness(10.0, 0.0, 10.0, 3.0));
        bindable28.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.StartAndExpand);
        bindable28.SetValue(Label.TextProperty, (object) "Total Payments and Adjustments");
        resourceExtension19.Key = "smallHeader";
        StaticResourceExtension resourceExtension53 = resourceExtension19;
        XamlServiceProvider xamlServiceProvider19 = new XamlServiceProvider();
        Type type37 = typeof (IProvideValueTarget);
        object[] objectAndParents19 = new object[0 + 8];
        objectAndParents19[0] = (object) bindable28;
        objectAndParents19[1] = (object) bindable29;
        objectAndParents19[2] = (object) stackLayout14;
        objectAndParents19[3] = (object) bindable48;
        objectAndParents19[4] = (object) bindable49;
        objectAndParents19[5] = (object) pullToRefreshLayout;
        objectAndParents19[6] = (object) bindable50;
        objectAndParents19[7] = (object) bindable51;
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
        namespaceResolver19.Add("controls", "clr-namespace:Refractored.XamForms.PullToRefresh;assembly=Refractored.XamForms.PullToRefresh");
        XamlTypeResolver service38 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver19, typeof (ViewSOAPage).GetTypeInfo().Assembly);
        xamlServiceProvider19.Add(type38, (object) service38);
        xamlServiceProvider19.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(148, 113)));
        object obj19 = resourceExtension53.ProvideValue((IServiceProvider) xamlServiceProvider19);
        bindable28.Style = (Style) obj19;
        bindable28.SetValue(Label.TextColorProperty, (object) new Color(1.0, 1.0, 1.0, 1.0));
        bindable29.Children.Add((View) bindable28);
        label11.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.End);
        label11.SetValue(Label.TextProperty, (object) "0.00");
        label11.SetValue(Label.HorizontalTextAlignmentProperty, new TextAlignmentConverter().ConvertFromInvariantString("End"));
        resourceExtension20.Key = "smallHeader";
        StaticResourceExtension resourceExtension54 = resourceExtension20;
        XamlServiceProvider xamlServiceProvider20 = new XamlServiceProvider();
        Type type39 = typeof (IProvideValueTarget);
        object[] objectAndParents20 = new object[0 + 8];
        objectAndParents20[0] = (object) label11;
        objectAndParents20[1] = (object) bindable29;
        objectAndParents20[2] = (object) stackLayout14;
        objectAndParents20[3] = (object) bindable48;
        objectAndParents20[4] = (object) bindable49;
        objectAndParents20[5] = (object) pullToRefreshLayout;
        objectAndParents20[6] = (object) bindable50;
        objectAndParents20[7] = (object) bindable51;
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
        namespaceResolver20.Add("controls", "clr-namespace:Refractored.XamForms.PullToRefresh;assembly=Refractored.XamForms.PullToRefresh");
        XamlTypeResolver service40 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver20, typeof (ViewSOAPage).GetTypeInfo().Assembly);
        xamlServiceProvider20.Add(type40, (object) service40);
        xamlServiceProvider20.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(149, 131)));
        object obj20 = resourceExtension54.ProvideValue((IServiceProvider) xamlServiceProvider20);
        label11.Style = (Style) obj20;
        label11.SetValue(Label.TextColorProperty, (object) new Color(1.0, 1.0, 1.0, 1.0));
        bindable29.Children.Add((View) label11);
        stackLayout14.Children.Add((View) bindable29);
        bindable31.SetValue(StackLayout.OrientationProperty, (object) StackOrientation.Horizontal);
        bindable31.SetValue(VisualElement.BackgroundColorProperty, (object) new Color(0.905882358551025, 0.752941191196442, 0.113725490868092, 1.0));
        bindable31.SetValue(Layout.PaddingProperty, (object) new Thickness(10.0));
        bindable31.SetValue(View.MarginProperty, (object) new Thickness(10.0, 0.0, 10.0, 10.0));
        bindable30.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.StartAndExpand);
        bindable30.SetValue(Label.TextProperty, (object) "Assessment Balance");
        resourceExtension21.Key = "smallHeader";
        StaticResourceExtension resourceExtension55 = resourceExtension21;
        XamlServiceProvider xamlServiceProvider21 = new XamlServiceProvider();
        Type type41 = typeof (IProvideValueTarget);
        object[] objectAndParents21 = new object[0 + 8];
        objectAndParents21[0] = (object) bindable30;
        objectAndParents21[1] = (object) bindable31;
        objectAndParents21[2] = (object) stackLayout14;
        objectAndParents21[3] = (object) bindable48;
        objectAndParents21[4] = (object) bindable49;
        objectAndParents21[5] = (object) pullToRefreshLayout;
        objectAndParents21[6] = (object) bindable50;
        objectAndParents21[7] = (object) bindable51;
        SimpleValueTargetProvider service41 = new SimpleValueTargetProvider(objectAndParents21, (object) VisualElement.StyleProperty);
        xamlServiceProvider21.Add(type41, (object) service41);
        xamlServiceProvider21.Add(typeof (INameScopeProvider), (object) new NameScopeProvider()
        {
          NameScope = (INameScope) nameScope
        });
        Type type42 = typeof (IXamlTypeResolver);
        XmlNamespaceResolver namespaceResolver21 = new XmlNamespaceResolver();
        namespaceResolver21.Add("", "http://xamarin.com/schemas/2014/forms");
        namespaceResolver21.Add("x", "http://schemas.microsoft.com/winfx/2009/xaml");
        namespaceResolver21.Add("controls", "clr-namespace:Refractored.XamForms.PullToRefresh;assembly=Refractored.XamForms.PullToRefresh");
        XamlTypeResolver service42 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver21, typeof (ViewSOAPage).GetTypeInfo().Assembly);
        xamlServiceProvider21.Add(type42, (object) service42);
        xamlServiceProvider21.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(153, 101)));
        object obj21 = resourceExtension55.ProvideValue((IServiceProvider) xamlServiceProvider21);
        bindable30.Style = (Style) obj21;
        bindable30.SetValue(Label.TextColorProperty, (object) new Color(0.250980406999588, 0.250980406999588, 0.250980406999588, 1.0));
        bindable31.Children.Add((View) bindable30);
        label12.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.End);
        label12.SetValue(Label.HorizontalTextAlignmentProperty, new TextAlignmentConverter().ConvertFromInvariantString("End"));
        label12.SetValue(Label.TextProperty, (object) "0.00");
        resourceExtension22.Key = "smallHeader";
        StaticResourceExtension resourceExtension56 = resourceExtension22;
        XamlServiceProvider xamlServiceProvider22 = new XamlServiceProvider();
        Type type43 = typeof (IProvideValueTarget);
        object[] objectAndParents22 = new object[0 + 8];
        objectAndParents22[0] = (object) label12;
        objectAndParents22[1] = (object) bindable31;
        objectAndParents22[2] = (object) stackLayout14;
        objectAndParents22[3] = (object) bindable48;
        objectAndParents22[4] = (object) bindable49;
        objectAndParents22[5] = (object) pullToRefreshLayout;
        objectAndParents22[6] = (object) bindable50;
        objectAndParents22[7] = (object) bindable51;
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
        namespaceResolver22.Add("controls", "clr-namespace:Refractored.XamForms.PullToRefresh;assembly=Refractored.XamForms.PullToRefresh");
        XamlTypeResolver service44 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver22, typeof (ViewSOAPage).GetTypeInfo().Assembly);
        xamlServiceProvider22.Add(type44, (object) service44);
        xamlServiceProvider22.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(154, 127)));
        object obj22 = resourceExtension56.ProvideValue((IServiceProvider) xamlServiceProvider22);
        label12.Style = (Style) obj22;
        label12.SetValue(Label.TextColorProperty, (object) new Color(0.250980406999588, 0.250980406999588, 0.250980406999588, 1.0));
        bindable31.Children.Add((View) label12);
        stackLayout14.Children.Add((View) bindable31);
        frame1.SetValue(View.MarginProperty, (object) new Thickness(10.0));
        frame1.SetValue(Layout.PaddingProperty, (object) new Thickness(20.0, 20.0, 20.0, 15.0));
        frame1.SetValue(Frame.CornerRadiusProperty, (object) 5f);
        bindable35.SetValue(View.MarginProperty, (object) new Thickness(0.0, 0.0, 0.0, 5.0));
        bindable33.SetValue(StackLayout.OrientationProperty, (object) StackOrientation.Horizontal);
        bindable32.SetValue(Label.TextProperty, (object) "Other Charges");
        resourceExtension23.Key = "mediumHeader";
        StaticResourceExtension resourceExtension57 = resourceExtension23;
        XamlServiceProvider xamlServiceProvider23 = new XamlServiceProvider();
        Type type45 = typeof (IProvideValueTarget);
        object[] objectAndParents23 = new object[0 + 11];
        objectAndParents23[0] = (object) bindable32;
        objectAndParents23[1] = (object) bindable33;
        objectAndParents23[2] = (object) bindable35;
        objectAndParents23[3] = (object) bindable42;
        objectAndParents23[4] = (object) frame1;
        objectAndParents23[5] = (object) stackLayout14;
        objectAndParents23[6] = (object) bindable48;
        objectAndParents23[7] = (object) bindable49;
        objectAndParents23[8] = (object) pullToRefreshLayout;
        objectAndParents23[9] = (object) bindable50;
        objectAndParents23[10] = (object) bindable51;
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
        namespaceResolver23.Add("controls", "clr-namespace:Refractored.XamForms.PullToRefresh;assembly=Refractored.XamForms.PullToRefresh");
        XamlTypeResolver service46 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver23, typeof (ViewSOAPage).GetTypeInfo().Assembly);
        xamlServiceProvider23.Add(type46, (object) service46);
        xamlServiceProvider23.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(165, 73)));
        object obj23 = resourceExtension57.ProvideValue((IServiceProvider) xamlServiceProvider23);
        bindable32.Style = (Style) obj23;
        bindable32.SetValue(Label.TextColorProperty, (object) new Color(0.250980406999588, 0.250980406999588, 0.250980406999588, 1.0));
        bindable32.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.FillAndExpand);
        bindable33.Children.Add((View) bindable32);
        resourceExtension24.Key = "normalHeader";
        StaticResourceExtension resourceExtension58 = resourceExtension24;
        XamlServiceProvider xamlServiceProvider24 = new XamlServiceProvider();
        Type type47 = typeof (IProvideValueTarget);
        object[] objectAndParents24 = new object[0 + 11];
        objectAndParents24[0] = (object) label13;
        objectAndParents24[1] = (object) bindable33;
        objectAndParents24[2] = (object) bindable35;
        objectAndParents24[3] = (object) bindable42;
        objectAndParents24[4] = (object) frame1;
        objectAndParents24[5] = (object) stackLayout14;
        objectAndParents24[6] = (object) bindable48;
        objectAndParents24[7] = (object) bindable49;
        objectAndParents24[8] = (object) pullToRefreshLayout;
        objectAndParents24[9] = (object) bindable50;
        objectAndParents24[10] = (object) bindable51;
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
        namespaceResolver24.Add("controls", "clr-namespace:Refractored.XamForms.PullToRefresh;assembly=Refractored.XamForms.PullToRefresh");
        XamlTypeResolver service48 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver24, typeof (ViewSOAPage).GetTypeInfo().Assembly);
        xamlServiceProvider24.Add(type48, (object) service48);
        xamlServiceProvider24.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(166, 80)));
        object obj24 = resourceExtension58.ProvideValue((IServiceProvider) xamlServiceProvider24);
        label13.Style = (Style) obj24;
        label13.SetValue(Label.TextColorProperty, (object) new Color(0.250980406999588, 0.250980406999588, 0.250980406999588, 1.0));
        label13.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.End);
        label13.SetValue(Label.HorizontalTextAlignmentProperty, new TextAlignmentConverter().ConvertFromInvariantString("End"));
        bindable33.Children.Add((View) label13);
        bindable35.Children.Add((View) bindable33);
        bindable34.SetValue(BoxView.ColorProperty, (object) new Color(0.905882358551025, 0.752941191196442, 0.113725490868092, 1.0));
        bindable34.SetValue(VisualElement.HeightRequestProperty, (object) 1.5);
        bindable34.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.FillAndExpand);
        bindable35.Children.Add((View) bindable34);
        bindable42.Children.Add((View) bindable35);
        bindable38.SetValue(StackLayout.OrientationProperty, (object) StackOrientation.Horizontal);
        bindable38.SetValue(View.MarginProperty, (object) new Thickness(0.0, 5.0, 0.0, 0.0));
        bindable38.SetValue(StackLayout.SpacingProperty, (object) 0.0);
        bindable36.SetValue(Image.SourceProperty, new ImageSourceConverter().ConvertFromInvariantString("ic_pin"));
        bindable36.SetValue(View.VerticalOptionsProperty, (object) LayoutOptions.Start);
        bindable36.SetValue(View.MarginProperty, (object) new Thickness(0.0, 3.0, 0.0, 0.0));
        bindable38.Children.Add((View) bindable36);
        bindable37.SetValue(Label.TextProperty, (object) "Payment Schedule");
        bindable37.SetValue(View.MarginProperty, (object) new Thickness(8.0, 0.0, 0.0, 0.0));
        resourceExtension25.Key = "smallHeader";
        StaticResourceExtension resourceExtension59 = resourceExtension25;
        XamlServiceProvider xamlServiceProvider25 = new XamlServiceProvider();
        Type type49 = typeof (IProvideValueTarget);
        object[] objectAndParents25 = new object[0 + 10];
        objectAndParents25[0] = (object) bindable37;
        objectAndParents25[1] = (object) bindable38;
        objectAndParents25[2] = (object) bindable42;
        objectAndParents25[3] = (object) frame1;
        objectAndParents25[4] = (object) stackLayout14;
        objectAndParents25[5] = (object) bindable48;
        objectAndParents25[6] = (object) bindable49;
        objectAndParents25[7] = (object) pullToRefreshLayout;
        objectAndParents25[8] = (object) bindable50;
        objectAndParents25[9] = (object) bindable51;
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
        namespaceResolver25.Add("controls", "clr-namespace:Refractored.XamForms.PullToRefresh;assembly=Refractored.XamForms.PullToRefresh");
        XamlTypeResolver service50 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver25, typeof (ViewSOAPage).GetTypeInfo().Assembly);
        xamlServiceProvider25.Add(type50, (object) service50);
        xamlServiceProvider25.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(176, 89)));
        object obj25 = resourceExtension59.ProvideValue((IServiceProvider) xamlServiceProvider25);
        bindable37.Style = (Style) obj25;
        bindable37.SetValue(Label.TextColorProperty, (object) new Color(0.250980406999588, 0.250980406999588, 0.250980406999588, 1.0));
        bindable37.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.FillAndExpand);
        bindable38.Children.Add((View) bindable37);
        bindable42.Children.Add((View) bindable38);
        stackLayout11.SetValue(View.MarginProperty, (object) new Thickness(0.0, 5.0, 0.0, 0.0));
        stackLayout11.SetValue(StackLayout.SpacingProperty, (object) 0.0);
        bindable42.Children.Add((View) stackLayout11);
        bindable41.SetValue(View.MarginProperty, (object) new Thickness(0.0, 30.0, 0.0, 5.0));
        bindable39.SetValue(Label.TextProperty, (object) "Payments and Adjustments");
        resourceExtension26.Key = "mediumHeader";
        StaticResourceExtension resourceExtension60 = resourceExtension26;
        XamlServiceProvider xamlServiceProvider26 = new XamlServiceProvider();
        Type type51 = typeof (IProvideValueTarget);
        object[] objectAndParents26 = new object[0 + 10];
        objectAndParents26[0] = (object) bindable39;
        objectAndParents26[1] = (object) bindable41;
        objectAndParents26[2] = (object) bindable42;
        objectAndParents26[3] = (object) frame1;
        objectAndParents26[4] = (object) stackLayout14;
        objectAndParents26[5] = (object) bindable48;
        objectAndParents26[6] = (object) bindable49;
        objectAndParents26[7] = (object) pullToRefreshLayout;
        objectAndParents26[8] = (object) bindable50;
        objectAndParents26[9] = (object) bindable51;
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
        namespaceResolver26.Add("controls", "clr-namespace:Refractored.XamForms.PullToRefresh;assembly=Refractored.XamForms.PullToRefresh");
        XamlTypeResolver service52 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver26, typeof (ViewSOAPage).GetTypeInfo().Assembly);
        xamlServiceProvider26.Add(type52, (object) service52);
        xamlServiceProvider26.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(197, 80)));
        object obj26 = resourceExtension60.ProvideValue((IServiceProvider) xamlServiceProvider26);
        bindable39.Style = (Style) obj26;
        bindable39.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.FillAndExpand);
        bindable39.SetValue(Label.TextColorProperty, (object) new Color(0.250980406999588, 0.250980406999588, 0.250980406999588, 1.0));
        bindable41.Children.Add((View) bindable39);
        bindable40.SetValue(BoxView.ColorProperty, (object) new Color(0.905882358551025, 0.752941191196442, 0.113725490868092, 1.0));
        bindable40.SetValue(VisualElement.HeightRequestProperty, (object) 1.5);
        bindable40.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.FillAndExpand);
        bindable41.Children.Add((View) bindable40);
        bindable42.Children.Add((View) bindable41);
        stackLayout12.SetValue(View.MarginProperty, (object) new Thickness(0.0, 5.0, 0.0, 0.0));
        stackLayout12.SetValue(StackLayout.SpacingProperty, (object) 5.0);
        bindable42.Children.Add((View) stackLayout12);
        frame1.SetValue(ContentView.ContentProperty, (object) bindable42);
        stackLayout14.Children.Add((View) frame1);
        stackLayout13.SetValue(StackLayout.SpacingProperty, (object) 0.0);
        bindable44.SetValue(StackLayout.OrientationProperty, (object) StackOrientation.Horizontal);
        resourceExtension27.Key = "PrimaryColor";
        StaticResourceExtension resourceExtension61 = resourceExtension27;
        XamlServiceProvider xamlServiceProvider27 = new XamlServiceProvider();
        Type type53 = typeof (IProvideValueTarget);
        object[] objectAndParents27 = new object[0 + 8];
        objectAndParents27[0] = (object) bindable44;
        objectAndParents27[1] = (object) stackLayout13;
        objectAndParents27[2] = (object) stackLayout14;
        objectAndParents27[3] = (object) bindable48;
        objectAndParents27[4] = (object) bindable49;
        objectAndParents27[5] = (object) pullToRefreshLayout;
        objectAndParents27[6] = (object) bindable50;
        objectAndParents27[7] = (object) bindable51;
        SimpleValueTargetProvider service53 = new SimpleValueTargetProvider(objectAndParents27, (object) VisualElement.BackgroundColorProperty);
        xamlServiceProvider27.Add(type53, (object) service53);
        xamlServiceProvider27.Add(typeof (INameScopeProvider), (object) new NameScopeProvider()
        {
          NameScope = (INameScope) nameScope
        });
        Type type54 = typeof (IXamlTypeResolver);
        XmlNamespaceResolver namespaceResolver27 = new XmlNamespaceResolver();
        namespaceResolver27.Add("", "http://xamarin.com/schemas/2014/forms");
        namespaceResolver27.Add("x", "http://schemas.microsoft.com/winfx/2009/xaml");
        namespaceResolver27.Add("controls", "clr-namespace:Refractored.XamForms.PullToRefresh;assembly=Refractored.XamForms.PullToRefresh");
        XamlTypeResolver service54 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver27, typeof (ViewSOAPage).GetTypeInfo().Assembly);
        xamlServiceProvider27.Add(type54, (object) service54);
        xamlServiceProvider27.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(209, 72)));
        object obj27 = resourceExtension61.ProvideValue((IServiceProvider) xamlServiceProvider27);
        bindable44.BackgroundColor = (Color) obj27;
        bindable44.SetValue(Layout.PaddingProperty, (object) new Thickness(10.0));
        bindable44.SetValue(View.MarginProperty, (object) new Thickness(10.0, 0.0, 10.0, 3.0));
        bindable43.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.StartAndExpand);
        bindable43.SetValue(Label.TextProperty, (object) "Total Payments and Adjustments");
        resourceExtension28.Key = "smallHeader";
        StaticResourceExtension resourceExtension62 = resourceExtension28;
        XamlServiceProvider xamlServiceProvider28 = new XamlServiceProvider();
        Type type55 = typeof (IProvideValueTarget);
        object[] objectAndParents28 = new object[0 + 9];
        objectAndParents28[0] = (object) bindable43;
        objectAndParents28[1] = (object) bindable44;
        objectAndParents28[2] = (object) stackLayout13;
        objectAndParents28[3] = (object) stackLayout14;
        objectAndParents28[4] = (object) bindable48;
        objectAndParents28[5] = (object) bindable49;
        objectAndParents28[6] = (object) pullToRefreshLayout;
        objectAndParents28[7] = (object) bindable50;
        objectAndParents28[8] = (object) bindable51;
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
        namespaceResolver28.Add("controls", "clr-namespace:Refractored.XamForms.PullToRefresh;assembly=Refractored.XamForms.PullToRefresh");
        XamlTypeResolver service56 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver28, typeof (ViewSOAPage).GetTypeInfo().Assembly);
        xamlServiceProvider28.Add(type56, (object) service56);
        xamlServiceProvider28.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(210, 117)));
        object obj28 = resourceExtension62.ProvideValue((IServiceProvider) xamlServiceProvider28);
        bindable43.Style = (Style) obj28;
        bindable43.SetValue(Label.TextColorProperty, (object) new Color(1.0, 1.0, 1.0, 1.0));
        bindable44.Children.Add((View) bindable43);
        label14.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.End);
        label14.SetValue(Label.HorizontalTextAlignmentProperty, new TextAlignmentConverter().ConvertFromInvariantString("End"));
        label14.SetValue(Label.TextProperty, (object) "0.00");
        resourceExtension29.Key = "smallHeader";
        StaticResourceExtension resourceExtension63 = resourceExtension29;
        XamlServiceProvider xamlServiceProvider29 = new XamlServiceProvider();
        Type type57 = typeof (IProvideValueTarget);
        object[] objectAndParents29 = new object[0 + 9];
        objectAndParents29[0] = (object) label14;
        objectAndParents29[1] = (object) bindable44;
        objectAndParents29[2] = (object) stackLayout13;
        objectAndParents29[3] = (object) stackLayout14;
        objectAndParents29[4] = (object) bindable48;
        objectAndParents29[5] = (object) bindable49;
        objectAndParents29[6] = (object) pullToRefreshLayout;
        objectAndParents29[7] = (object) bindable50;
        objectAndParents29[8] = (object) bindable51;
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
        namespaceResolver29.Add("controls", "clr-namespace:Refractored.XamForms.PullToRefresh;assembly=Refractored.XamForms.PullToRefresh");
        XamlTypeResolver service58 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver29, typeof (ViewSOAPage).GetTypeInfo().Assembly);
        xamlServiceProvider29.Add(type58, (object) service58);
        xamlServiceProvider29.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(211, 138)));
        object obj29 = resourceExtension63.ProvideValue((IServiceProvider) xamlServiceProvider29);
        label14.Style = (Style) obj29;
        label14.SetValue(Label.TextColorProperty, (object) new Color(1.0, 1.0, 1.0, 1.0));
        bindable44.Children.Add((View) label14);
        stackLayout13.Children.Add((View) bindable44);
        bindable46.SetValue(StackLayout.OrientationProperty, (object) StackOrientation.Horizontal);
        bindable46.SetValue(VisualElement.BackgroundColorProperty, (object) new Color(0.905882358551025, 0.752941191196442, 0.113725490868092, 1.0));
        bindable46.SetValue(Layout.PaddingProperty, (object) new Thickness(10.0));
        bindable46.SetValue(View.MarginProperty, (object) new Thickness(10.0, 0.0, 10.0, 10.0));
        bindable45.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.StartAndExpand);
        bindable45.SetValue(Label.TextProperty, (object) "Other Charges Balance");
        resourceExtension30.Key = "smallHeader";
        StaticResourceExtension resourceExtension64 = resourceExtension30;
        XamlServiceProvider xamlServiceProvider30 = new XamlServiceProvider();
        Type type59 = typeof (IProvideValueTarget);
        object[] objectAndParents30 = new object[0 + 9];
        objectAndParents30[0] = (object) bindable45;
        objectAndParents30[1] = (object) bindable46;
        objectAndParents30[2] = (object) stackLayout13;
        objectAndParents30[3] = (object) stackLayout14;
        objectAndParents30[4] = (object) bindable48;
        objectAndParents30[5] = (object) bindable49;
        objectAndParents30[6] = (object) pullToRefreshLayout;
        objectAndParents30[7] = (object) bindable50;
        objectAndParents30[8] = (object) bindable51;
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
        namespaceResolver30.Add("controls", "clr-namespace:Refractored.XamForms.PullToRefresh;assembly=Refractored.XamForms.PullToRefresh");
        XamlTypeResolver service60 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver30, typeof (ViewSOAPage).GetTypeInfo().Assembly);
        xamlServiceProvider30.Add(type60, (object) service60);
        xamlServiceProvider30.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(215, 108)));
        object obj30 = resourceExtension64.ProvideValue((IServiceProvider) xamlServiceProvider30);
        bindable45.Style = (Style) obj30;
        bindable45.SetValue(Label.TextColorProperty, (object) new Color(0.250980406999588, 0.250980406999588, 0.250980406999588, 1.0));
        bindable46.Children.Add((View) bindable45);
        label15.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.End);
        label15.SetValue(Label.TextProperty, (object) "0.00");
        label15.SetValue(Label.HorizontalTextAlignmentProperty, new TextAlignmentConverter().ConvertFromInvariantString("End"));
        resourceExtension31.Key = "smallHeader";
        StaticResourceExtension resourceExtension65 = resourceExtension31;
        XamlServiceProvider xamlServiceProvider31 = new XamlServiceProvider();
        Type type61 = typeof (IProvideValueTarget);
        object[] objectAndParents31 = new object[0 + 9];
        objectAndParents31[0] = (object) label15;
        objectAndParents31[1] = (object) bindable46;
        objectAndParents31[2] = (object) stackLayout13;
        objectAndParents31[3] = (object) stackLayout14;
        objectAndParents31[4] = (object) bindable48;
        objectAndParents31[5] = (object) bindable49;
        objectAndParents31[6] = (object) pullToRefreshLayout;
        objectAndParents31[7] = (object) bindable50;
        objectAndParents31[8] = (object) bindable51;
        SimpleValueTargetProvider service61 = new SimpleValueTargetProvider(objectAndParents31, (object) VisualElement.StyleProperty);
        xamlServiceProvider31.Add(type61, (object) service61);
        xamlServiceProvider31.Add(typeof (INameScopeProvider), (object) new NameScopeProvider()
        {
          NameScope = (INameScope) nameScope
        });
        Type type62 = typeof (IXamlTypeResolver);
        XmlNamespaceResolver namespaceResolver31 = new XmlNamespaceResolver();
        namespaceResolver31.Add("", "http://xamarin.com/schemas/2014/forms");
        namespaceResolver31.Add("x", "http://schemas.microsoft.com/winfx/2009/xaml");
        namespaceResolver31.Add("controls", "clr-namespace:Refractored.XamForms.PullToRefresh;assembly=Refractored.XamForms.PullToRefresh");
        XamlTypeResolver service62 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver31, typeof (ViewSOAPage).GetTypeInfo().Assembly);
        xamlServiceProvider31.Add(type62, (object) service62);
        xamlServiceProvider31.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(216, 140)));
        object obj31 = resourceExtension65.ProvideValue((IServiceProvider) xamlServiceProvider31);
        label15.Style = (Style) obj31;
        label15.SetValue(Label.TextColorProperty, (object) new Color(0.250980406999588, 0.250980406999588, 0.250980406999588, 1.0));
        bindable46.Children.Add((View) label15);
        stackLayout13.Children.Add((View) bindable46);
        stackLayout14.Children.Add((View) stackLayout13);
        label16.SetValue(View.MarginProperty, (object) new Thickness(15.0));
        resourceExtension32.Key = "microLabel";
        StaticResourceExtension resourceExtension66 = resourceExtension32;
        XamlServiceProvider xamlServiceProvider32 = new XamlServiceProvider();
        Type type63 = typeof (IProvideValueTarget);
        object[] objectAndParents32 = new object[0 + 7];
        objectAndParents32[0] = (object) label16;
        objectAndParents32[1] = (object) stackLayout14;
        objectAndParents32[2] = (object) bindable48;
        objectAndParents32[3] = (object) bindable49;
        objectAndParents32[4] = (object) pullToRefreshLayout;
        objectAndParents32[5] = (object) bindable50;
        objectAndParents32[6] = (object) bindable51;
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
        namespaceResolver32.Add("controls", "clr-namespace:Refractored.XamForms.PullToRefresh;assembly=Refractored.XamForms.PullToRefresh");
        XamlTypeResolver service64 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver32, typeof (ViewSOAPage).GetTypeInfo().Assembly);
        xamlServiceProvider32.Add(type64, (object) service64);
        xamlServiceProvider32.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(221, 69)));
        object obj32 = resourceExtension66.ProvideValue((IServiceProvider) xamlServiceProvider32);
        label16.Style = (Style) obj32;
        label16.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.Center);
        label16.SetValue(Label.FontFamilyProperty, (object) "Roboto-Regular.ttf#Roboto");
        stackLayout14.Children.Add((View) label16);
        bindable48.Children.Add((View) stackLayout14);
        frame2.SetValue(View.MarginProperty, (object) new Thickness(15.0));
        frame2.SetValue(Layout.PaddingProperty, (object) new Thickness(15.0));
        frame2.SetValue(Frame.CornerRadiusProperty, (object) 5f);
        frame2.SetValue(VisualElement.IsVisibleProperty, new VisualElement.VisibilityConverter().ConvertFromInvariantString("false"));
        label17.SetValue(Label.TextProperty, (object) "Apologies, the server is undergoing maintenance.");
        resourceExtension33.Key = "smallLabel";
        StaticResourceExtension resourceExtension67 = resourceExtension33;
        XamlServiceProvider xamlServiceProvider33 = new XamlServiceProvider();
        Type type65 = typeof (IProvideValueTarget);
        object[] objectAndParents33 = new object[0 + 8];
        objectAndParents33[0] = (object) label17;
        objectAndParents33[1] = (object) bindable47;
        objectAndParents33[2] = (object) frame2;
        objectAndParents33[3] = (object) bindable48;
        objectAndParents33[4] = (object) bindable49;
        objectAndParents33[5] = (object) pullToRefreshLayout;
        objectAndParents33[6] = (object) bindable50;
        objectAndParents33[7] = (object) bindable51;
        SimpleValueTargetProvider service65 = new SimpleValueTargetProvider(objectAndParents33, (object) VisualElement.StyleProperty);
        xamlServiceProvider33.Add(type65, (object) service65);
        xamlServiceProvider33.Add(typeof (INameScopeProvider), (object) new NameScopeProvider()
        {
          NameScope = (INameScope) nameScope
        });
        Type type66 = typeof (IXamlTypeResolver);
        XmlNamespaceResolver namespaceResolver33 = new XmlNamespaceResolver();
        namespaceResolver33.Add("", "http://xamarin.com/schemas/2014/forms");
        namespaceResolver33.Add("x", "http://schemas.microsoft.com/winfx/2009/xaml");
        namespaceResolver33.Add("controls", "clr-namespace:Refractored.XamForms.PullToRefresh;assembly=Refractored.XamForms.PullToRefresh");
        XamlTypeResolver service66 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver33, typeof (ViewSOAPage).GetTypeInfo().Assembly);
        xamlServiceProvider33.Add(type66, (object) service66);
        xamlServiceProvider33.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(229, 120)));
        object obj33 = resourceExtension67.ProvideValue((IServiceProvider) xamlServiceProvider33);
        label17.Style = (Style) obj33;
        label17.SetValue(Label.TextColorProperty, (object) new Color(0.250980406999588, 0.250980406999588, 0.250980406999588, 1.0));
        label17.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.FillAndExpand);
        bindable47.Children.Add((View) label17);
        frame2.SetValue(ContentView.ContentProperty, (object) bindable47);
        bindable48.Children.Add((View) frame2);
        bindable49.Content = (View) bindable48;
        pullToRefreshLayout.SetValue(ContentView.ContentProperty, (object) bindable49);
        bindable50.Children.Add((View) pullToRefreshLayout);
        stackLayout15.SetValue(VisualElement.BackgroundColorProperty, (object) new Color(0.180392161011696, 0.192156866192818, 0.192156866192818, 1.0));
        stackLayout15.SetValue(VisualElement.IsVisibleProperty, new VisualElement.VisibilityConverter().ConvertFromInvariantString("False"));
        stackLayout15.SetValue(View.VerticalOptionsProperty, (object) LayoutOptions.End);
        stackLayout15.SetValue(Layout.PaddingProperty, (object) new Thickness(3.0));
        stackLayout15.SetValue(View.MarginProperty, (object) new Thickness(0.0));
        label18.SetValue(Label.TextProperty, (object) "No connection");
        resourceExtension34.Key = "microLabel";
        StaticResourceExtension resourceExtension68 = resourceExtension34;
        XamlServiceProvider xamlServiceProvider34 = new XamlServiceProvider();
        Type type67 = typeof (IProvideValueTarget);
        object[] objectAndParents34 = new object[0 + 4];
        objectAndParents34[0] = (object) label18;
        objectAndParents34[1] = (object) stackLayout15;
        objectAndParents34[2] = (object) bindable50;
        objectAndParents34[3] = (object) bindable51;
        SimpleValueTargetProvider service67 = new SimpleValueTargetProvider(objectAndParents34, (object) VisualElement.StyleProperty);
        xamlServiceProvider34.Add(type67, (object) service67);
        xamlServiceProvider34.Add(typeof (INameScopeProvider), (object) new NameScopeProvider()
        {
          NameScope = (INameScope) nameScope
        });
        Type type68 = typeof (IXamlTypeResolver);
        XmlNamespaceResolver namespaceResolver34 = new XmlNamespaceResolver();
        namespaceResolver34.Add("", "http://xamarin.com/schemas/2014/forms");
        namespaceResolver34.Add("x", "http://schemas.microsoft.com/winfx/2009/xaml");
        namespaceResolver34.Add("controls", "clr-namespace:Refractored.XamForms.PullToRefresh;assembly=Refractored.XamForms.PullToRefresh");
        XamlTypeResolver service68 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver34, typeof (ViewSOAPage).GetTypeInfo().Assembly);
        xamlServiceProvider34.Add(type68, (object) service68);
        xamlServiceProvider34.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(239, 64)));
        object obj34 = resourceExtension68.ProvideValue((IServiceProvider) xamlServiceProvider34);
        label18.Style = (Style) obj34;
        Label label19 = label18;
        BindableProperty fontSizeProperty = Label.FontSizeProperty;
        FontSizeConverter fontSizeConverter = new FontSizeConverter();
        XamlServiceProvider xamlServiceProvider35 = new XamlServiceProvider();
        Type type69 = typeof (IProvideValueTarget);
        object[] objectAndParents35 = new object[0 + 4];
        objectAndParents35[0] = (object) label18;
        objectAndParents35[1] = (object) stackLayout15;
        objectAndParents35[2] = (object) bindable50;
        objectAndParents35[3] = (object) bindable51;
        SimpleValueTargetProvider service69 = new SimpleValueTargetProvider(objectAndParents35, (object) Label.FontSizeProperty);
        xamlServiceProvider35.Add(type69, (object) service69);
        xamlServiceProvider35.Add(typeof (INameScopeProvider), (object) new NameScopeProvider()
        {
          NameScope = (INameScope) nameScope
        });
        Type type70 = typeof (IXamlTypeResolver);
        XmlNamespaceResolver namespaceResolver35 = new XmlNamespaceResolver();
        namespaceResolver35.Add("", "http://xamarin.com/schemas/2014/forms");
        namespaceResolver35.Add("x", "http://schemas.microsoft.com/winfx/2009/xaml");
        namespaceResolver35.Add("controls", "clr-namespace:Refractored.XamForms.PullToRefresh;assembly=Refractored.XamForms.PullToRefresh");
        XamlTypeResolver service70 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver35, typeof (ViewSOAPage).GetTypeInfo().Assembly);
        xamlServiceProvider35.Add(type70, (object) service70);
        xamlServiceProvider35.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(239, 100)));
        object obj35 = ((IExtendedTypeConverter) fontSizeConverter).ConvertFromInvariantString("12", (IServiceProvider) xamlServiceProvider35);
        label19.SetValue(fontSizeProperty, obj35);
        label18.SetValue(Label.TextColorProperty, (object) new Color(1.0, 1.0, 1.0, 1.0));
        label18.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.Center);
        stackLayout15.Children.Add((View) label18);
        bindable50.Children.Add((View) stackLayout15);
        bindable51.SetValue(ContentPage.ContentProperty, (object) bindable50);
      }
    }

    private void __InitComponentRuntime()
    {
      this.LoadFromXaml<ViewSOAPage>(typeof (ViewSOAPage));
      this.stackSYTerm = NameScopeExtensions.FindByName<StackLayout>(this, "stackSYTerm");
      this.lblSYTerm = NameScopeExtensions.FindByName<Label>(this, "lblSYTerm");
      this.imgPullDownTerms = NameScopeExtensions.FindByName<Image>(this, "imgPullDownTerms");
      this.pckrSchoolTerm = NameScopeExtensions.FindByName<Picker>(this, "pckrSchoolTerm");
      this.refreshAssessment = NameScopeExtensions.FindByName<PullToRefreshLayout>(this, "refreshAssessment");
      this.stackMain = NameScopeExtensions.FindByName<StackLayout>(this, "stackMain");
      this.lblNetAsOf = NameScopeExtensions.FindByName<Label>(this, "lblNetAsOf");
      this.lblTotalBalance = NameScopeExtensions.FindByName<Label>(this, "lblTotalBalance");
      this.stackAssessment = NameScopeExtensions.FindByName<StackLayout>(this, "stackAssessment");
      this.lblAssessment = NameScopeExtensions.FindByName<Label>(this, "lblAssessment");
      this.lblAssessmentAmt = NameScopeExtensions.FindByName<Label>(this, "lblAssessmentAmt");
      this.stackRegFee = NameScopeExtensions.FindByName<StackLayout>(this, "stackRegFee");
      this.lblRegFeeAmt = NameScopeExtensions.FindByName<Label>(this, "lblRegFeeAmt");
      this.stackTutFees = NameScopeExtensions.FindByName<StackLayout>(this, "stackTutFees");
      this.lblTutHeader = NameScopeExtensions.FindByName<Label>(this, "lblTutHeader");
      this.lblTuitionAmt = NameScopeExtensions.FindByName<Label>(this, "lblTuitionAmt");
      this.stackTutMiscDetails = NameScopeExtensions.FindByName<StackLayout>(this, "stackTutMiscDetails");
      this.stackOSF = NameScopeExtensions.FindByName<StackLayout>(this, "stackOSF");
      this.lblOSFAmt = NameScopeExtensions.FindByName<Label>(this, "lblOSFAmt");
      this.stackOSFDetails = NameScopeExtensions.FindByName<StackLayout>(this, "stackOSFDetails");
      this.stackMiscellaneous = NameScopeExtensions.FindByName<StackLayout>(this, "stackMiscellaneous");
      this.lblMiscAmt = NameScopeExtensions.FindByName<Label>(this, "lblMiscAmt");
      this.stackMiscDetails = NameScopeExtensions.FindByName<StackLayout>(this, "stackMiscDetails");
      this.stackPaymentData = NameScopeExtensions.FindByName<StackLayout>(this, "stackPaymentData");
      this.lblTuitionGrand = NameScopeExtensions.FindByName<Label>(this, "lblTuitionGrand");
      this.lbl_balance = NameScopeExtensions.FindByName<Label>(this, "lbl_balance");
      this.frmNonTuition = NameScopeExtensions.FindByName<Frame>(this, "frmNonTuition");
      this.lblOtherChrgstAmt = NameScopeExtensions.FindByName<Label>(this, "lblOtherChrgstAmt");
      this.stackNonTuition = NameScopeExtensions.FindByName<StackLayout>(this, "stackNonTuition");
      this.stackNonTuitionPayment = NameScopeExtensions.FindByName<StackLayout>(this, "stackNonTuitionPayment");
      this.stackNonTuitionTotals = NameScopeExtensions.FindByName<StackLayout>(this, "stackNonTuitionTotals");
      this.lblNonTuitionGrand = NameScopeExtensions.FindByName<Label>(this, "lblNonTuitionGrand");
      this.lblNonTuitionBalance = NameScopeExtensions.FindByName<Label>(this, "lblNonTuitionBalance");
      this.lblLastSync = NameScopeExtensions.FindByName<Label>(this, "lblLastSync");
      this.frameServerDown = NameScopeExtensions.FindByName<Frame>(this, "frameServerDown");
      this.lblServerDown = NameScopeExtensions.FindByName<Label>(this, "lblServerDown");
      this.stackStatus = NameScopeExtensions.FindByName<StackLayout>(this, "stackStatus");
      this.lblStatus = NameScopeExtensions.FindByName<Label>(this, "lblStatus");
    }
  }
}
