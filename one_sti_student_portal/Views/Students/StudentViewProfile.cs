// Decompiled with JetBrains decompiler
// Type: one_sti_student_portal.Views.Students.StudentViewProfile
// Assembly: one_sti_student_portal, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 39E34984-485E-45CE-9895-F7524E3024D6
// Assembly location: \\wsl.localhost\kali-linux\root\One STI Student Portal_1.3.8_apkcombo.com (1)\unknown\assemblies\one_sti_student_portal.dll

using ImageCircle.Forms.Plugin.Abstractions;
using Microsoft.Graph;
using one_sti_student_portal.Data;
using one_sti_student_portal.Helpers;
using one_sti_student_portal.Models;
using one_sti_student_portal.Services;
using one_sti_student_portal.Views.Widgets;
using Refractored.XamForms.PullToRefresh;
using System;
using System.CodeDom.Compiler;
using System.IO;
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
  [XamlFilePath("Views\\Students\\StudentViewProfile.xaml")]
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public class StudentViewProfile : ContentPage
  {
    private StudentData _studentData;
    private bool _isConnected;
    private bool _isBusy;
    private string _delveID;
    private string serverStatus;
    private bool blnShouldStay;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private PullToRefreshLayout refreshProfile;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private CircleImage imgAvatar;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private Label lblStudentId;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private Label lblStudentName;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private Label lblCrse;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private Label lblCampus;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private Label lblEmail;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private Label lblAddress;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private Label lblContact;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private Label lblBirthday;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private StackLayout stackStatus;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private Label lblStatus;

    public StudentViewProfile()
    {
      this.InitializeComponent();
      this._studentData = new StudentData();
      this._isConnected = ConnectionHelper.IsConnected();
      Connectivity.ConnectivityChanged += (EventHandler<ConnectivityChangedEventArgs>) ((sender, args) =>
      {
        this._isConnected = ConnectionHelper.IsConnected();
        this.CheckStatus();
      });
      this.refreshProfile.RefreshCommand = (ICommand) new Command((Action) (() => this.RefreshContent()));
      this.LoadProfile();
      this._delveID = new ApplicationData().GetConstantValue("delveid");
      if (!string.IsNullOrWhiteSpace(this._delveID))
        return;
      this.RefreshContent();
    }

    private void RefreshContent()
    {
      Xamarin.Forms.Device.BeginInvokeOnMainThread((Action) (() =>
      {
        this.refreshProfile.IsRefreshing = true;
        this.LoadProfile();
      }));
      Task.Run((Func<Task>) (async () =>
      {
        StudentViewProfile studentViewProfile = this;
        if (!studentViewProfile._isConnected || studentViewProfile._isBusy)
          return;
        studentViewProfile._isBusy = true;
        if (string.IsNullOrWhiteSpace(studentViewProfile._delveID))
        {
          AuthenticationHelper authenticationHelper = new AuthenticationHelper();
          User async = await AuthenticationHelper.GetAuthenticatedClient().Me.Request().GetAsync();
          int num = await new ApplicationData().SaveConstant(new AppConstants()
          {
            Constant = "delveid",
            Value = async.Id
          });
        }
        string str = "";
        try
        {
          Stream photoStreamAsync = await new MailHelper().GetCurrentUserPhotoStreamAsync();
          MemoryStream memoryStream = new MemoryStream();
          MemoryStream destination = memoryStream;
          photoStreamAsync.CopyTo((Stream) destination);
          string base64String = Convert.ToBase64String(memoryStream.ToArray());
          int num = await new ApplicationData().SaveConstant(new AppConstants()
          {
            Constant = "profilephoto",
            Value = base64String
          });
        }
        catch
        {
          str = (string) null;
        }
        StudentService studentService = new StudentService();
        StudentInformation studentInfo = studentViewProfile._studentData.GetStudentInformation().Result.FirstOrDefault<StudentInformation>();
        string email = studentInfo.Email;
        await studentViewProfile._studentData.DownloadStudentInformation(email);
        AppLogModel appLogModel = new AppLogModel()
        {
          PSCSId = studentInfo.PSCSId,
          IPAddress = "null",
          Medium = "Mobile",
          AppVersion = one_sti_student_portal.Constants.VersionName,
          NumOfRequests = 4,
          DateAccessed = DateTime.Now.ToString("MM/dd/yyyy hh:mm tt"),
          ViewName = studentViewProfile.GetType().Name + " RefreshContent()",
          Campus = studentInfo.Campus
        };
        studentInfo = (StudentInformation) null;
      })).ContinueWith((Action<Task>) (result => Xamarin.Forms.Device.BeginInvokeOnMainThread((Action) (() =>
      {
        this.LoadProfile();
        this.refreshProfile.IsRefreshing = false;
        this._isBusy = false;
        if (ConnectionHelper.IsConnected())
          return;
        Acr.UserDialogs.UserDialogs.Instance.Toast("Could not refresh. Check your network connection.");
      }))));
    }

    private void LoadProfile()
    {
      foreach (StudentInformation studentInformation in this._studentData.GetStudentInformation().Result)
      {
        if (string.IsNullOrEmpty(studentInformation.ProfilePhoto))
        {
          this.imgAvatar.Source = (ImageSource) "default_avatar";
        }
        else
        {
          byte[] bytes = Convert.FromBase64String(studentInformation.ProfilePhoto);
          Xamarin.Forms.Device.BeginInvokeOnMainThread((Action) (() => this.imgAvatar.Source = ImageSource.FromStream((Func<Stream>) (() => (Stream) new MemoryStream(bytes)))));
        }
        this.lblStudentName.Text = studentInformation.FirstName + " " + studentInformation.MiddleName + " " + studentInformation.LastName;
        this.lblStudentId.Text = studentInformation.PSCSId;
        this.lblCampus.Text = studentInformation.CampusDesc;
        this.lblCrse.Text = studentInformation.Program;
        this.lblEmail.Text = studentInformation.Email;
        this.lblContact.Text = studentInformation.Phone;
        this.lblAddress.Text = "";
        string lower = studentInformation.Address.ToLower();
        char[] chArray = new char[1]{ ' ' };
        foreach (string s in lower.Split(chArray))
          this.lblAddress.Text = this.lblAddress.Text + StudentViewProfile.UppercaseFirst(s) + " ";
        this.lblBirthday.Text = studentInformation.BirthDate.ToString("dd MMM, yyyy");
      }
    }

    private void CheckStatus()
    {
      if (this._isConnected)
      {
        this.stackStatus.IsVisible = true;
        this.stackStatus.BackgroundColor = Color.FromHex("#03a678");
        this.lblStatus.Text = "Back online";
        Xamarin.Forms.Device.StartTimer(TimeSpan.FromSeconds(5.0), (Func<bool>) (() =>
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

    public static string UppercaseFirst(string s)
    {
      if (string.IsNullOrEmpty(s))
        return string.Empty;
      char[] charArray = s.ToCharArray();
      charArray[0] = char.ToUpper(charArray[0]);
      return new string(charArray);
    }

    protected override bool OnBackButtonPressed()
    {
      if (this.blnShouldStay)
        return true;
      MasterDetail masterDetail = new MasterDetail();
      masterDetail.Detail = (Page) new NavigationPage((Page) new WidgetHomePage());
      Application.Current.MainPage = (Page) masterDetail;
      return true;
    }

    protected override void OnAppearing()
    {
      base.OnAppearing();
      if (this._isConnected)
        return;
      this.stackStatus.BackgroundColor = Color.FromHex("#2e3131");
      this.stackStatus.IsVisible = true;
      this.lblStatus.Text = "No connection";
    }

    private void ViewProfilePhoto(object sender, EventArgs e)
    {
      if (!ConnectionHelper.IsConnected())
        return;
      Xamarin.Forms.Device.BeginInvokeOnMainThread((Action) (() =>
      {
        if (!string.IsNullOrWhiteSpace(this._delveID))
          Xamarin.Forms.Device.OpenUri(new Uri("https://apc.delve.office.com/?u=" + this._delveID + "&v=work"));
        else
          this.RefreshContent();
      }));
    }

    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private void InitializeComponent()
    {
      if (ResourceLoader.ResourceProvider != null && ResourceLoader.ResourceProvider(typeof (StudentViewProfile).GetTypeInfo().Assembly.GetName(), "Views/Students/StudentViewProfile.xaml") != null)
        this.__InitComponentRuntime();
      else if (Xamarin.Forms.Xaml.Internals.XamlLoader.XamlFileProvider != null && Xamarin.Forms.Xaml.Internals.XamlLoader.XamlFileProvider(this.GetType()) != null)
      {
        this.__InitComponentRuntime();
      }
      else
      {
        RowDefinition bindable1 = new RowDefinition();
        RowDefinition bindable2 = new RowDefinition();
        RowDefinition bindable3 = new RowDefinition();
        RowDefinition bindable4 = new RowDefinition();
        RowDefinition bindable5 = new RowDefinition();
        Xamarin.Forms.Image bindable6 = new Xamarin.Forms.Image();
        Xamarin.Forms.Image bindable7 = new Xamarin.Forms.Image();
        TapGestureRecognizer bindable8 = new TapGestureRecognizer();
        CircleImage circleImage = new CircleImage();
        Xamarin.Forms.Image bindable9 = new Xamarin.Forms.Image();
        StaticResourceExtension resourceExtension1 = new StaticResourceExtension();
        TapGestureRecognizer bindable10 = new TapGestureRecognizer();
        Label bindable11 = new Label();
        StackLayout bindable12 = new StackLayout();
        StaticResourceExtension resourceExtension2 = new StaticResourceExtension();
        Label label1 = new Label();
        StaticResourceExtension resourceExtension3 = new StaticResourceExtension();
        Label label2 = new Label();
        StaticResourceExtension resourceExtension4 = new StaticResourceExtension();
        Label label3 = new Label();
        StaticResourceExtension resourceExtension5 = new StaticResourceExtension();
        Label label4 = new Label();
        StackLayout bindable13 = new StackLayout();
        BoxView bindable14 = new BoxView();
        StaticResourceExtension resourceExtension6 = new StaticResourceExtension();
        Label bindable15 = new Label();
        Xamarin.Forms.Image bindable16 = new Xamarin.Forms.Image();
        StaticResourceExtension resourceExtension7 = new StaticResourceExtension();
        Label label5 = new Label();
        StackLayout bindable17 = new StackLayout();
        Xamarin.Forms.Image bindable18 = new Xamarin.Forms.Image();
        StaticResourceExtension resourceExtension8 = new StaticResourceExtension();
        Label label6 = new Label();
        StackLayout bindable19 = new StackLayout();
        Xamarin.Forms.Image bindable20 = new Xamarin.Forms.Image();
        StaticResourceExtension resourceExtension9 = new StaticResourceExtension();
        Label label7 = new Label();
        StackLayout bindable21 = new StackLayout();
        Xamarin.Forms.Image bindable22 = new Xamarin.Forms.Image();
        StaticResourceExtension resourceExtension10 = new StaticResourceExtension();
        Label label8 = new Label();
        StackLayout bindable23 = new StackLayout();
        StackLayout bindable24 = new StackLayout();
        StackLayout bindable25 = new StackLayout();
        Grid bindable26 = new Grid();
        ScrollView bindable27 = new ScrollView();
        PullToRefreshLayout pullToRefreshLayout = new PullToRefreshLayout();
        StaticResourceExtension resourceExtension11 = new StaticResourceExtension();
        Label label9 = new Label();
        StackLayout stackLayout = new StackLayout();
        StackLayout bindable28 = new StackLayout();
        StudentViewProfile bindable29 = this;
        NameScope nameScope = new NameScope();
        NameScope.SetNameScope((BindableObject) bindable29, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable28, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) pullToRefreshLayout, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("refreshProfile", (object) pullToRefreshLayout);
        if (pullToRefreshLayout.StyleId == null)
          pullToRefreshLayout.StyleId = "refreshProfile";
        NameScope.SetNameScope((BindableObject) bindable27, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable26, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable1, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable2, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable3, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable4, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable5, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable6, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable7, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) circleImage, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("imgAvatar", (object) circleImage);
        if (circleImage.StyleId == null)
          circleImage.StyleId = "imgAvatar";
        NameScope.SetNameScope((BindableObject) bindable8, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable13, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable12, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable9, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable11, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable10, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) label1, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("lblStudentId", (object) label1);
        if (label1.StyleId == null)
          label1.StyleId = "lblStudentId";
        NameScope.SetNameScope((BindableObject) label2, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("lblStudentName", (object) label2);
        if (label2.StyleId == null)
          label2.StyleId = "lblStudentName";
        NameScope.SetNameScope((BindableObject) label3, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("lblCrse", (object) label3);
        if (label3.StyleId == null)
          label3.StyleId = "lblCrse";
        NameScope.SetNameScope((BindableObject) label4, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("lblCampus", (object) label4);
        if (label4.StyleId == null)
          label4.StyleId = "lblCampus";
        NameScope.SetNameScope((BindableObject) bindable14, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable25, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable15, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable24, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable17, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable16, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) label5, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("lblEmail", (object) label5);
        if (label5.StyleId == null)
          label5.StyleId = "lblEmail";
        NameScope.SetNameScope((BindableObject) bindable19, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable18, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) label6, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("lblAddress", (object) label6);
        if (label6.StyleId == null)
          label6.StyleId = "lblAddress";
        NameScope.SetNameScope((BindableObject) bindable21, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable20, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) label7, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("lblContact", (object) label7);
        if (label7.StyleId == null)
          label7.StyleId = "lblContact";
        NameScope.SetNameScope((BindableObject) bindable23, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable22, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) label8, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("lblBirthday", (object) label8);
        if (label8.StyleId == null)
          label8.StyleId = "lblBirthday";
        NameScope.SetNameScope((BindableObject) stackLayout, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("stackStatus", (object) stackLayout);
        if (stackLayout.StyleId == null)
          stackLayout.StyleId = "stackStatus";
        NameScope.SetNameScope((BindableObject) label9, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("lblStatus", (object) label9);
        if (label9.StyleId == null)
          label9.StyleId = "lblStatus";
        this.refreshProfile = pullToRefreshLayout;
        this.imgAvatar = circleImage;
        this.lblStudentId = label1;
        this.lblStudentName = label2;
        this.lblCrse = label3;
        this.lblCampus = label4;
        this.lblEmail = label5;
        this.lblAddress = label6;
        this.lblContact = label7;
        this.lblBirthday = label8;
        this.stackStatus = stackLayout;
        this.lblStatus = label9;
        bindable29.SetValue(VisualElement.BackgroundColorProperty, (object) Color.White);
        bindable29.SetValue(Page.TitleProperty, (object) "My Profile");
        pullToRefreshLayout.SetValue(PullToRefreshLayout.IsPullToRefreshEnabledProperty, (object) true);
        bindable27.SetValue(View.VerticalOptionsProperty, (object) LayoutOptions.FillAndExpand);
        bindable26.SetValue(Grid.ColumnSpacingProperty, (object) 0.0);
        bindable26.SetValue(Grid.RowSpacingProperty, (object) 0.0);
        bindable1.SetValue(RowDefinition.HeightProperty, new GridLengthTypeConverter().ConvertFromInvariantString("AUTO"));
        ((DefinitionCollection<RowDefinition>) bindable26.GetValue(Grid.RowDefinitionsProperty)).Add(bindable1);
        bindable2.SetValue(RowDefinition.HeightProperty, new GridLengthTypeConverter().ConvertFromInvariantString("AUTO"));
        ((DefinitionCollection<RowDefinition>) bindable26.GetValue(Grid.RowDefinitionsProperty)).Add(bindable2);
        bindable3.SetValue(RowDefinition.HeightProperty, new GridLengthTypeConverter().ConvertFromInvariantString("AUTO"));
        ((DefinitionCollection<RowDefinition>) bindable26.GetValue(Grid.RowDefinitionsProperty)).Add(bindable3);
        bindable4.SetValue(RowDefinition.HeightProperty, new GridLengthTypeConverter().ConvertFromInvariantString("*"));
        ((DefinitionCollection<RowDefinition>) bindable26.GetValue(Grid.RowDefinitionsProperty)).Add(bindable4);
        bindable5.SetValue(RowDefinition.HeightProperty, new GridLengthTypeConverter().ConvertFromInvariantString("AUTO"));
        ((DefinitionCollection<RowDefinition>) bindable26.GetValue(Grid.RowDefinitionsProperty)).Add(bindable5);
        bindable6.SetValue(Xamarin.Forms.Image.SourceProperty, new ImageSourceConverter().ConvertFromInvariantString("HeaderBackground.png"));
        bindable6.SetValue(Xamarin.Forms.Image.AspectProperty, (object) Aspect.AspectFill);
        bindable26.Children.Add((View) bindable6);
        bindable7.SetValue(Xamarin.Forms.Image.SourceProperty, new ImageSourceConverter().ConvertFromInvariantString("CurvedMask.png"));
        bindable7.SetValue(View.VerticalOptionsProperty, (object) LayoutOptions.End);
        bindable7.SetValue(Xamarin.Forms.Image.AspectProperty, (object) Aspect.AspectFill);
        bindable7.SetValue(View.MarginProperty, (object) new Thickness(0.0, 0.0, 0.0, -1.0));
        bindable26.Children.Add((View) bindable7);
        circleImage.SetValue(Xamarin.Forms.Image.SourceProperty, new ImageSourceConverter().ConvertFromInvariantString("default_avatar"));
        circleImage.SetValue(View.MarginProperty, (object) new Thickness(0.0, 0.0, 0.0, -50.0));
        circleImage.SetValue(VisualElement.HeightRequestProperty, (object) 100.0);
        circleImage.SetValue(VisualElement.WidthRequestProperty, (object) 100.0);
        circleImage.SetValue(CircleImage.BorderThicknessProperty, (object) 2f);
        circleImage.SetValue(CircleImage.BorderColorProperty, (object) new Color(1.0, 1.0, 1.0, 1.0));
        circleImage.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.Center);
        circleImage.SetValue(View.VerticalOptionsProperty, (object) LayoutOptions.End);
        bindable8.Tapped += new EventHandler(bindable29.ViewProfilePhoto);
        circleImage.GestureRecognizers.Add((IGestureRecognizer) bindable8);
        bindable26.Children.Add((View) circleImage);
        bindable13.SetValue(Grid.RowProperty, (object) 1);
        bindable13.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.Center);
        bindable13.SetValue(Layout.PaddingProperty, (object) new Thickness(0.0, 50.0, 0.0, 0.0));
        bindable12.SetValue(StackLayout.OrientationProperty, (object) StackOrientation.Horizontal);
        bindable12.SetValue(StackLayout.SpacingProperty, (object) 0.0);
        bindable12.SetValue(View.MarginProperty, (object) new Thickness(0.0, 5.0, 0.0, 0.0));
        bindable12.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.Center);
        bindable9.SetValue(Xamarin.Forms.Image.SourceProperty, new ImageSourceConverter().ConvertFromInvariantString("ic_photo_camera"));
        bindable9.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.Center);
        bindable12.Children.Add((View) bindable9);
        bindable11.SetValue(Label.HorizontalTextAlignmentProperty, new TextAlignmentConverter().ConvertFromInvariantString("Center"));
        bindable11.SetValue(View.VerticalOptionsProperty, (object) LayoutOptions.Center);
        bindable11.SetValue(Label.TextProperty, (object) " CHANGE PHOTO");
        resourceExtension1.Key = "microHeader";
        StaticResourceExtension resourceExtension12 = resourceExtension1;
        XamlServiceProvider xamlServiceProvider1 = new XamlServiceProvider();
        Type type1 = typeof (IProvideValueTarget);
        object[] objectAndParents1 = new object[0 + 8];
        objectAndParents1[0] = (object) bindable11;
        objectAndParents1[1] = (object) bindable12;
        objectAndParents1[2] = (object) bindable13;
        objectAndParents1[3] = (object) bindable26;
        objectAndParents1[4] = (object) bindable27;
        objectAndParents1[5] = (object) pullToRefreshLayout;
        objectAndParents1[6] = (object) bindable28;
        objectAndParents1[7] = (object) bindable29;
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
        namespaceResolver1.Add("ctrImage", "clr-namespace:ImageCircle.Forms.Plugin.Abstractions;assembly=ImageCircle.Forms.Plugin.Abstractions");
        namespaceResolver1.Add("controls", "clr-namespace:Refractored.XamForms.PullToRefresh;assembly=Refractored.XamForms.PullToRefresh");
        XamlTypeResolver service2 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver1, typeof (StudentViewProfile).GetTypeInfo().Assembly);
        xamlServiceProvider1.Add(type2, (object) service2);
        xamlServiceProvider1.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(44, 119)));
        object obj1 = resourceExtension12.ProvideValue((IServiceProvider) xamlServiceProvider1);
        bindable11.Style = (Style) obj1;
        bindable10.Tapped += new EventHandler(bindable29.ViewProfilePhoto);
        bindable11.GestureRecognizers.Add((IGestureRecognizer) bindable10);
        bindable12.Children.Add((View) bindable11);
        bindable13.Children.Add((View) bindable12);
        label1.SetValue(Label.HorizontalTextAlignmentProperty, new TextAlignmentConverter().ConvertFromInvariantString("Center"));
        label1.SetValue(View.MarginProperty, (object) new Thickness(0.0, 10.0, 0.0, 0.0));
        resourceExtension2.Key = "smallLabel";
        StaticResourceExtension resourceExtension13 = resourceExtension2;
        XamlServiceProvider xamlServiceProvider2 = new XamlServiceProvider();
        Type type3 = typeof (IProvideValueTarget);
        object[] objectAndParents2 = new object[0 + 7];
        objectAndParents2[0] = (object) label1;
        objectAndParents2[1] = (object) bindable13;
        objectAndParents2[2] = (object) bindable26;
        objectAndParents2[3] = (object) bindable27;
        objectAndParents2[4] = (object) pullToRefreshLayout;
        objectAndParents2[5] = (object) bindable28;
        objectAndParents2[6] = (object) bindable29;
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
        namespaceResolver2.Add("ctrImage", "clr-namespace:ImageCircle.Forms.Plugin.Abstractions;assembly=ImageCircle.Forms.Plugin.Abstractions");
        namespaceResolver2.Add("controls", "clr-namespace:Refractored.XamForms.PullToRefresh;assembly=Refractored.XamForms.PullToRefresh");
        XamlTypeResolver service4 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver2, typeof (StudentViewProfile).GetTypeInfo().Assembly);
        xamlServiceProvider2.Add(type4, (object) service4);
        xamlServiceProvider2.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(51, 109)));
        object obj2 = resourceExtension13.ProvideValue((IServiceProvider) xamlServiceProvider2);
        label1.Style = (Style) obj2;
        label1.SetValue(Label.TextColorProperty, (object) new Color(0.400000005960464, 0.400000005960464, 0.400000005960464, 1.0));
        bindable13.Children.Add((View) label1);
        label2.SetValue(Label.HorizontalTextAlignmentProperty, new TextAlignmentConverter().ConvertFromInvariantString("Center"));
        label2.SetValue(View.MarginProperty, (object) new Thickness(0.0, -5.0));
        resourceExtension3.Key = "normalHeader";
        StaticResourceExtension resourceExtension14 = resourceExtension3;
        XamlServiceProvider xamlServiceProvider3 = new XamlServiceProvider();
        Type type5 = typeof (IProvideValueTarget);
        object[] objectAndParents3 = new object[0 + 7];
        objectAndParents3[0] = (object) label2;
        objectAndParents3[1] = (object) bindable13;
        objectAndParents3[2] = (object) bindable26;
        objectAndParents3[3] = (object) bindable27;
        objectAndParents3[4] = (object) pullToRefreshLayout;
        objectAndParents3[5] = (object) bindable28;
        objectAndParents3[6] = (object) bindable29;
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
        namespaceResolver3.Add("ctrImage", "clr-namespace:ImageCircle.Forms.Plugin.Abstractions;assembly=ImageCircle.Forms.Plugin.Abstractions");
        namespaceResolver3.Add("controls", "clr-namespace:Refractored.XamForms.PullToRefresh;assembly=Refractored.XamForms.PullToRefresh");
        XamlTypeResolver service6 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver3, typeof (StudentViewProfile).GetTypeInfo().Assembly);
        xamlServiceProvider3.Add(type6, (object) service6);
        xamlServiceProvider3.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(52, 108)));
        object obj3 = resourceExtension14.ProvideValue((IServiceProvider) xamlServiceProvider3);
        label2.Style = (Style) obj3;
        label2.SetValue(Label.TextColorProperty, (object) new Color(0.250980406999588, 0.250980406999588, 0.250980406999588, 1.0));
        bindable13.Children.Add((View) label2);
        label3.SetValue(Label.HorizontalTextAlignmentProperty, new TextAlignmentConverter().ConvertFromInvariantString("Center"));
        label3.SetValue(View.MarginProperty, (object) new Thickness(0.0, 5.0));
        resourceExtension4.Key = "smallLabel";
        StaticResourceExtension resourceExtension15 = resourceExtension4;
        XamlServiceProvider xamlServiceProvider4 = new XamlServiceProvider();
        Type type7 = typeof (IProvideValueTarget);
        object[] objectAndParents4 = new object[0 + 7];
        objectAndParents4[0] = (object) label3;
        objectAndParents4[1] = (object) bindable13;
        objectAndParents4[2] = (object) bindable26;
        objectAndParents4[3] = (object) bindable27;
        objectAndParents4[4] = (object) pullToRefreshLayout;
        objectAndParents4[5] = (object) bindable28;
        objectAndParents4[6] = (object) bindable29;
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
        namespaceResolver4.Add("ctrImage", "clr-namespace:ImageCircle.Forms.Plugin.Abstractions;assembly=ImageCircle.Forms.Plugin.Abstractions");
        namespaceResolver4.Add("controls", "clr-namespace:Refractored.XamForms.PullToRefresh;assembly=Refractored.XamForms.PullToRefresh");
        XamlTypeResolver service8 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver4, typeof (StudentViewProfile).GetTypeInfo().Assembly);
        xamlServiceProvider4.Add(type8, (object) service8);
        xamlServiceProvider4.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(53, 100)));
        object obj4 = resourceExtension15.ProvideValue((IServiceProvider) xamlServiceProvider4);
        label3.Style = (Style) obj4;
        label3.SetValue(Label.TextColorProperty, (object) new Color(0.400000005960464, 0.400000005960464, 0.400000005960464, 1.0));
        bindable13.Children.Add((View) label3);
        label4.SetValue(Label.HorizontalTextAlignmentProperty, new TextAlignmentConverter().ConvertFromInvariantString("Center"));
        label4.SetValue(View.MarginProperty, (object) new Thickness(0.0, -10.0));
        resourceExtension5.Key = "smallLabel";
        StaticResourceExtension resourceExtension16 = resourceExtension5;
        XamlServiceProvider xamlServiceProvider5 = new XamlServiceProvider();
        Type type9 = typeof (IProvideValueTarget);
        object[] objectAndParents5 = new object[0 + 7];
        objectAndParents5[0] = (object) label4;
        objectAndParents5[1] = (object) bindable13;
        objectAndParents5[2] = (object) bindable26;
        objectAndParents5[3] = (object) bindable27;
        objectAndParents5[4] = (object) pullToRefreshLayout;
        objectAndParents5[5] = (object) bindable28;
        objectAndParents5[6] = (object) bindable29;
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
        namespaceResolver5.Add("ctrImage", "clr-namespace:ImageCircle.Forms.Plugin.Abstractions;assembly=ImageCircle.Forms.Plugin.Abstractions");
        namespaceResolver5.Add("controls", "clr-namespace:Refractored.XamForms.PullToRefresh;assembly=Refractored.XamForms.PullToRefresh");
        XamlTypeResolver service10 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver5, typeof (StudentViewProfile).GetTypeInfo().Assembly);
        xamlServiceProvider5.Add(type10, (object) service10);
        xamlServiceProvider5.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(54, 103)));
        object obj5 = resourceExtension16.ProvideValue((IServiceProvider) xamlServiceProvider5);
        label4.Style = (Style) obj5;
        label4.SetValue(Label.TextColorProperty, (object) new Color(0.400000005960464, 0.400000005960464, 0.400000005960464, 1.0));
        bindable13.Children.Add((View) label4);
        bindable26.Children.Add((View) bindable13);
        bindable14.SetValue(BoxView.ColorProperty, (object) new Color(0.905882358551025, 0.752941191196442, 0.113725490868092, 1.0));
        bindable14.SetValue(Grid.RowProperty, (object) 2);
        bindable14.SetValue(VisualElement.HeightRequestProperty, (object) 1.5);
        bindable14.SetValue(View.MarginProperty, (object) new Thickness(20.0, 20.0, 20.0, 10.0));
        bindable14.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.FillAndExpand);
        bindable26.Children.Add((View) bindable14);
        bindable25.SetValue(Grid.RowProperty, (object) 3);
        bindable25.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.Start);
        bindable25.SetValue(Layout.PaddingProperty, (object) new Thickness(20.0, 10.0, 20.0, 0.0));
        bindable15.SetValue(Label.TextProperty, (object) "Other Information");
        bindable15.SetValue(Label.HorizontalTextAlignmentProperty, new TextAlignmentConverter().ConvertFromInvariantString("Start"));
        resourceExtension6.Key = "smallHeader";
        StaticResourceExtension resourceExtension17 = resourceExtension6;
        XamlServiceProvider xamlServiceProvider6 = new XamlServiceProvider();
        Type type11 = typeof (IProvideValueTarget);
        object[] objectAndParents6 = new object[0 + 7];
        objectAndParents6[0] = (object) bindable15;
        objectAndParents6[1] = (object) bindable25;
        objectAndParents6[2] = (object) bindable26;
        objectAndParents6[3] = (object) bindable27;
        objectAndParents6[4] = (object) pullToRefreshLayout;
        objectAndParents6[5] = (object) bindable28;
        objectAndParents6[6] = (object) bindable29;
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
        namespaceResolver6.Add("xlabs", "clr-namespace:XLabs.Forms.Controls;assembly=XLabs.Forms");
        namespaceResolver6.Add("ctrImage", "clr-namespace:ImageCircle.Forms.Plugin.Abstractions;assembly=ImageCircle.Forms.Plugin.Abstractions");
        namespaceResolver6.Add("controls", "clr-namespace:Refractored.XamForms.PullToRefresh;assembly=Refractored.XamForms.PullToRefresh");
        XamlTypeResolver service12 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver6, typeof (StudentViewProfile).GetTypeInfo().Assembly);
        xamlServiceProvider6.Add(type12, (object) service12);
        xamlServiceProvider6.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(63, 93)));
        object obj6 = resourceExtension17.ProvideValue((IServiceProvider) xamlServiceProvider6);
        bindable15.Style = (Style) obj6;
        bindable25.Children.Add((View) bindable15);
        bindable24.SetValue(StackLayout.SpacingProperty, (object) 0.0);
        bindable17.SetValue(StackLayout.OrientationProperty, (object) StackOrientation.Horizontal);
        bindable17.SetValue(View.MarginProperty, (object) new Thickness(0.0, 0.0, 0.0, 3.0));
        bindable16.SetValue(Xamarin.Forms.Image.SourceProperty, new ImageSourceConverter().ConvertFromInvariantString("ic_email"));
        bindable17.Children.Add((View) bindable16);
        label5.SetValue(Label.HorizontalTextAlignmentProperty, new TextAlignmentConverter().ConvertFromInvariantString("Start"));
        label5.SetValue(View.VerticalOptionsProperty, (object) LayoutOptions.Center);
        resourceExtension7.Key = "smallLabel";
        StaticResourceExtension resourceExtension18 = resourceExtension7;
        XamlServiceProvider xamlServiceProvider7 = new XamlServiceProvider();
        Type type13 = typeof (IProvideValueTarget);
        object[] objectAndParents7 = new object[0 + 9];
        objectAndParents7[0] = (object) label5;
        objectAndParents7[1] = (object) bindable17;
        objectAndParents7[2] = (object) bindable24;
        objectAndParents7[3] = (object) bindable25;
        objectAndParents7[4] = (object) bindable26;
        objectAndParents7[5] = (object) bindable27;
        objectAndParents7[6] = (object) pullToRefreshLayout;
        objectAndParents7[7] = (object) bindable28;
        objectAndParents7[8] = (object) bindable29;
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
        namespaceResolver7.Add("xlabs", "clr-namespace:XLabs.Forms.Controls;assembly=XLabs.Forms");
        namespaceResolver7.Add("ctrImage", "clr-namespace:ImageCircle.Forms.Plugin.Abstractions;assembly=ImageCircle.Forms.Plugin.Abstractions");
        namespaceResolver7.Add("controls", "clr-namespace:Refractored.XamForms.PullToRefresh;assembly=Refractored.XamForms.PullToRefresh");
        XamlTypeResolver service14 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver7, typeof (StudentViewProfile).GetTypeInfo().Assembly);
        xamlServiceProvider7.Add(type14, (object) service14);
        xamlServiceProvider7.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(69, 119)));
        object obj7 = resourceExtension18.ProvideValue((IServiceProvider) xamlServiceProvider7);
        label5.Style = (Style) obj7;
        label5.SetValue(Label.TextColorProperty, (object) new Color(0.250980406999588, 0.250980406999588, 0.250980406999588, 1.0));
        bindable17.Children.Add((View) label5);
        bindable24.Children.Add((View) bindable17);
        bindable19.SetValue(StackLayout.OrientationProperty, (object) StackOrientation.Horizontal);
        bindable19.SetValue(View.MarginProperty, (object) new Thickness(0.0, 0.0, 0.0, 3.0));
        bindable18.SetValue(Xamarin.Forms.Image.SourceProperty, new ImageSourceConverter().ConvertFromInvariantString("ic_location"));
        bindable19.Children.Add((View) bindable18);
        label6.SetValue(Label.HorizontalTextAlignmentProperty, new TextAlignmentConverter().ConvertFromInvariantString("Start"));
        label6.SetValue(View.VerticalOptionsProperty, (object) LayoutOptions.Center);
        resourceExtension8.Key = "smallLabel";
        StaticResourceExtension resourceExtension19 = resourceExtension8;
        XamlServiceProvider xamlServiceProvider8 = new XamlServiceProvider();
        Type type15 = typeof (IProvideValueTarget);
        object[] objectAndParents8 = new object[0 + 9];
        objectAndParents8[0] = (object) label6;
        objectAndParents8[1] = (object) bindable19;
        objectAndParents8[2] = (object) bindable24;
        objectAndParents8[3] = (object) bindable25;
        objectAndParents8[4] = (object) bindable26;
        objectAndParents8[5] = (object) bindable27;
        objectAndParents8[6] = (object) pullToRefreshLayout;
        objectAndParents8[7] = (object) bindable28;
        objectAndParents8[8] = (object) bindable29;
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
        namespaceResolver8.Add("xlabs", "clr-namespace:XLabs.Forms.Controls;assembly=XLabs.Forms");
        namespaceResolver8.Add("ctrImage", "clr-namespace:ImageCircle.Forms.Plugin.Abstractions;assembly=ImageCircle.Forms.Plugin.Abstractions");
        namespaceResolver8.Add("controls", "clr-namespace:Refractored.XamForms.PullToRefresh;assembly=Refractored.XamForms.PullToRefresh");
        XamlTypeResolver service16 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver8, typeof (StudentViewProfile).GetTypeInfo().Assembly);
        xamlServiceProvider8.Add(type16, (object) service16);
        xamlServiceProvider8.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(74, 121)));
        object obj8 = resourceExtension19.ProvideValue((IServiceProvider) xamlServiceProvider8);
        label6.Style = (Style) obj8;
        label6.SetValue(Label.TextColorProperty, (object) new Color(0.250980406999588, 0.250980406999588, 0.250980406999588, 1.0));
        bindable19.Children.Add((View) label6);
        bindable24.Children.Add((View) bindable19);
        bindable21.SetValue(StackLayout.OrientationProperty, (object) StackOrientation.Horizontal);
        bindable21.SetValue(View.MarginProperty, (object) new Thickness(0.0, 0.0, 0.0, 3.0));
        bindable20.SetValue(Xamarin.Forms.Image.SourceProperty, new ImageSourceConverter().ConvertFromInvariantString("ic_contact_phone"));
        bindable21.Children.Add((View) bindable20);
        label7.SetValue(Label.HorizontalTextAlignmentProperty, new TextAlignmentConverter().ConvertFromInvariantString("Start"));
        label7.SetValue(View.VerticalOptionsProperty, (object) LayoutOptions.Center);
        resourceExtension9.Key = "smallLabel";
        StaticResourceExtension resourceExtension20 = resourceExtension9;
        XamlServiceProvider xamlServiceProvider9 = new XamlServiceProvider();
        Type type17 = typeof (IProvideValueTarget);
        object[] objectAndParents9 = new object[0 + 9];
        objectAndParents9[0] = (object) label7;
        objectAndParents9[1] = (object) bindable21;
        objectAndParents9[2] = (object) bindable24;
        objectAndParents9[3] = (object) bindable25;
        objectAndParents9[4] = (object) bindable26;
        objectAndParents9[5] = (object) bindable27;
        objectAndParents9[6] = (object) pullToRefreshLayout;
        objectAndParents9[7] = (object) bindable28;
        objectAndParents9[8] = (object) bindable29;
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
        namespaceResolver9.Add("xlabs", "clr-namespace:XLabs.Forms.Controls;assembly=XLabs.Forms");
        namespaceResolver9.Add("ctrImage", "clr-namespace:ImageCircle.Forms.Plugin.Abstractions;assembly=ImageCircle.Forms.Plugin.Abstractions");
        namespaceResolver9.Add("controls", "clr-namespace:Refractored.XamForms.PullToRefresh;assembly=Refractored.XamForms.PullToRefresh");
        XamlTypeResolver service18 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver9, typeof (StudentViewProfile).GetTypeInfo().Assembly);
        xamlServiceProvider9.Add(type18, (object) service18);
        xamlServiceProvider9.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(79, 121)));
        object obj9 = resourceExtension20.ProvideValue((IServiceProvider) xamlServiceProvider9);
        label7.Style = (Style) obj9;
        label7.SetValue(Label.TextColorProperty, (object) new Color(0.250980406999588, 0.250980406999588, 0.250980406999588, 1.0));
        bindable21.Children.Add((View) label7);
        bindable24.Children.Add((View) bindable21);
        bindable23.SetValue(StackLayout.OrientationProperty, (object) StackOrientation.Horizontal);
        bindable23.SetValue(View.MarginProperty, (object) new Thickness(0.0, 0.0, 0.0, 3.0));
        bindable22.SetValue(Xamarin.Forms.Image.SourceProperty, new ImageSourceConverter().ConvertFromInvariantString("ic_cake"));
        bindable23.Children.Add((View) bindable22);
        label8.SetValue(View.MarginProperty, (object) new Thickness(0.0, 0.0, 0.0, 5.0));
        label8.SetValue(Label.HorizontalTextAlignmentProperty, new TextAlignmentConverter().ConvertFromInvariantString("Start"));
        label8.SetValue(View.VerticalOptionsProperty, (object) LayoutOptions.End);
        resourceExtension10.Key = "smallLabel";
        StaticResourceExtension resourceExtension21 = resourceExtension10;
        XamlServiceProvider xamlServiceProvider10 = new XamlServiceProvider();
        Type type19 = typeof (IProvideValueTarget);
        object[] objectAndParents10 = new object[0 + 9];
        objectAndParents10[0] = (object) label8;
        objectAndParents10[1] = (object) bindable23;
        objectAndParents10[2] = (object) bindable24;
        objectAndParents10[3] = (object) bindable25;
        objectAndParents10[4] = (object) bindable26;
        objectAndParents10[5] = (object) bindable27;
        objectAndParents10[6] = (object) pullToRefreshLayout;
        objectAndParents10[7] = (object) bindable28;
        objectAndParents10[8] = (object) bindable29;
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
        namespaceResolver10.Add("xlabs", "clr-namespace:XLabs.Forms.Controls;assembly=XLabs.Forms");
        namespaceResolver10.Add("ctrImage", "clr-namespace:ImageCircle.Forms.Plugin.Abstractions;assembly=ImageCircle.Forms.Plugin.Abstractions");
        namespaceResolver10.Add("controls", "clr-namespace:Refractored.XamForms.PullToRefresh;assembly=Refractored.XamForms.PullToRefresh");
        XamlTypeResolver service20 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver10, typeof (StudentViewProfile).GetTypeInfo().Assembly);
        xamlServiceProvider10.Add(type20, (object) service20);
        xamlServiceProvider10.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(84, 136)));
        object obj10 = resourceExtension21.ProvideValue((IServiceProvider) xamlServiceProvider10);
        label8.Style = (Style) obj10;
        label8.SetValue(Label.TextColorProperty, (object) new Color(0.250980406999588, 0.250980406999588, 0.250980406999588, 1.0));
        bindable23.Children.Add((View) label8);
        bindable24.Children.Add((View) bindable23);
        bindable25.Children.Add((View) bindable24);
        bindable26.Children.Add((View) bindable25);
        bindable27.Content = (View) bindable26;
        pullToRefreshLayout.SetValue(ContentView.ContentProperty, (object) bindable27);
        bindable28.Children.Add((View) pullToRefreshLayout);
        stackLayout.SetValue(VisualElement.BackgroundColorProperty, (object) new Color(0.180392161011696, 0.192156866192818, 0.192156866192818, 1.0));
        stackLayout.SetValue(VisualElement.IsVisibleProperty, new VisualElement.VisibilityConverter().ConvertFromInvariantString("False"));
        stackLayout.SetValue(View.VerticalOptionsProperty, (object) LayoutOptions.End);
        stackLayout.SetValue(Layout.PaddingProperty, (object) new Thickness(3.0));
        stackLayout.SetValue(View.MarginProperty, (object) new Thickness(0.0));
        label9.SetValue(Label.TextProperty, (object) "No connection");
        resourceExtension11.Key = "microLabel";
        StaticResourceExtension resourceExtension22 = resourceExtension11;
        XamlServiceProvider xamlServiceProvider11 = new XamlServiceProvider();
        Type type21 = typeof (IProvideValueTarget);
        object[] objectAndParents11 = new object[0 + 4];
        objectAndParents11[0] = (object) label9;
        objectAndParents11[1] = (object) stackLayout;
        objectAndParents11[2] = (object) bindable28;
        objectAndParents11[3] = (object) bindable29;
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
        namespaceResolver11.Add("xlabs", "clr-namespace:XLabs.Forms.Controls;assembly=XLabs.Forms");
        namespaceResolver11.Add("ctrImage", "clr-namespace:ImageCircle.Forms.Plugin.Abstractions;assembly=ImageCircle.Forms.Plugin.Abstractions");
        namespaceResolver11.Add("controls", "clr-namespace:Refractored.XamForms.PullToRefresh;assembly=Refractored.XamForms.PullToRefresh");
        XamlTypeResolver service22 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver11, typeof (StudentViewProfile).GetTypeInfo().Assembly);
        xamlServiceProvider11.Add(type22, (object) service22);
        xamlServiceProvider11.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(96, 64)));
        object obj11 = resourceExtension22.ProvideValue((IServiceProvider) xamlServiceProvider11);
        label9.Style = (Style) obj11;
        Label label10 = label9;
        BindableProperty fontSizeProperty = Label.FontSizeProperty;
        FontSizeConverter fontSizeConverter = new FontSizeConverter();
        XamlServiceProvider xamlServiceProvider12 = new XamlServiceProvider();
        Type type23 = typeof (IProvideValueTarget);
        object[] objectAndParents12 = new object[0 + 4];
        objectAndParents12[0] = (object) label9;
        objectAndParents12[1] = (object) stackLayout;
        objectAndParents12[2] = (object) bindable28;
        objectAndParents12[3] = (object) bindable29;
        SimpleValueTargetProvider service23 = new SimpleValueTargetProvider(objectAndParents12, (object) Label.FontSizeProperty);
        xamlServiceProvider12.Add(type23, (object) service23);
        xamlServiceProvider12.Add(typeof (INameScopeProvider), (object) new NameScopeProvider()
        {
          NameScope = (INameScope) nameScope
        });
        Type type24 = typeof (IXamlTypeResolver);
        XmlNamespaceResolver namespaceResolver12 = new XmlNamespaceResolver();
        namespaceResolver12.Add("", "http://xamarin.com/schemas/2014/forms");
        namespaceResolver12.Add("x", "http://schemas.microsoft.com/winfx/2009/xaml");
        namespaceResolver12.Add("xlabs", "clr-namespace:XLabs.Forms.Controls;assembly=XLabs.Forms");
        namespaceResolver12.Add("ctrImage", "clr-namespace:ImageCircle.Forms.Plugin.Abstractions;assembly=ImageCircle.Forms.Plugin.Abstractions");
        namespaceResolver12.Add("controls", "clr-namespace:Refractored.XamForms.PullToRefresh;assembly=Refractored.XamForms.PullToRefresh");
        XamlTypeResolver service24 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver12, typeof (StudentViewProfile).GetTypeInfo().Assembly);
        xamlServiceProvider12.Add(type24, (object) service24);
        xamlServiceProvider12.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(96, 100)));
        object obj12 = ((IExtendedTypeConverter) fontSizeConverter).ConvertFromInvariantString("12", (IServiceProvider) xamlServiceProvider12);
        label10.SetValue(fontSizeProperty, obj12);
        label9.SetValue(Label.TextColorProperty, (object) new Color(1.0, 1.0, 1.0, 1.0));
        label9.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.Center);
        stackLayout.Children.Add((View) label9);
        bindable28.Children.Add((View) stackLayout);
        bindable29.SetValue(ContentPage.ContentProperty, (object) bindable28);
      }
    }

    private void __InitComponentRuntime()
    {
      this.LoadFromXaml<StudentViewProfile>(typeof (StudentViewProfile));
      this.refreshProfile = NameScopeExtensions.FindByName<PullToRefreshLayout>(this, "refreshProfile");
      this.imgAvatar = NameScopeExtensions.FindByName<CircleImage>(this, "imgAvatar");
      this.lblStudentId = NameScopeExtensions.FindByName<Label>(this, "lblStudentId");
      this.lblStudentName = NameScopeExtensions.FindByName<Label>(this, "lblStudentName");
      this.lblCrse = NameScopeExtensions.FindByName<Label>(this, "lblCrse");
      this.lblCampus = NameScopeExtensions.FindByName<Label>(this, "lblCampus");
      this.lblEmail = NameScopeExtensions.FindByName<Label>(this, "lblEmail");
      this.lblAddress = NameScopeExtensions.FindByName<Label>(this, "lblAddress");
      this.lblContact = NameScopeExtensions.FindByName<Label>(this, "lblContact");
      this.lblBirthday = NameScopeExtensions.FindByName<Label>(this, "lblBirthday");
      this.stackStatus = NameScopeExtensions.FindByName<StackLayout>(this, "stackStatus");
      this.lblStatus = NameScopeExtensions.FindByName<Label>(this, "lblStatus");
    }
  }
}
