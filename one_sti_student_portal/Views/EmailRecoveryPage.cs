// Decompiled with JetBrains decompiler
// Type: one_sti_student_portal.Views.EmailRecoveryPage
// Assembly: one_sti_student_portal, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 39E34984-485E-45CE-9895-F7524E3024D6
// Assembly location: \\wsl.localhost\kali-linux\root\One STI Student Portal_1.3.8_apkcombo.com (1)\unknown\assemblies\one_sti_student_portal.dll

using Newtonsoft.Json.Linq;
using one_sti_student_portal.Helpers;
using one_sti_student_portal.Models;
using one_sti_student_portal.Services;
using System;
using System.CodeDom.Compiler;
using System.Reflection;
using System.Threading.Tasks;
using System.Xml;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.Xaml.Internals;

namespace one_sti_student_portal.Views
{
  [XamlFilePath("Views\\EmailRecoveryPage.xaml")]
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public class EmailRecoveryPage : ContentPage
  {
    private bool _isConnected;
    private string _serverStatusOK;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private StackLayout stackEmailRecovery;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private Xamarin.Forms.Entry entStudentID;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private Xamarin.Forms.Entry entBirthday;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private DatePicker dtBirthday;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private Xamarin.Forms.Entry entMiddleName;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private Button btnNext;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private ActivityIndicator activityIndicator;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private StackLayout stackCredentials;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private Label lblFrameTitle;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private Label lblNote;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private StackLayout stackEmailPassword;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private Label lblEmail;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private Label lblPassword;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private Label lblAlready;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private Button btnDone;

    public EmailRecoveryPage()
    {
      this.InitializeComponent();
      this._isConnected = ConnectionHelper.IsConnected();
      Connectivity.ConnectivityChanged += new EventHandler<ConnectivityChangedEventArgs>(this.Connectivity_ConnectivityChanged);
    }

    private async Task<string> ServerStatusAsync()
    {
      try
      {
        return ConnectionHelper.IsConnected() ? (!(await new StudentService().CheckServerStatus()).ToLower().Contains("online") ? "false" : "true") : "false";
      }
      catch
      {
        return "error";
      }
    }

    private void Connectivity_ConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
    {
      this._isConnected = ConnectionHelper.IsConnected();
      Task.Run((Func<Task>) (async () => this._serverStatusOK = await this.ServerStatusAsync()));
    }

    protected override void OnAppearing()
    {
      base.OnAppearing();
      Device.StartTimer(TimeSpan.FromSeconds(1.0), (Func<bool>) (() =>
      {
        this.entStudentID.Focus();
        return false;
      }));
      Device.StartTimer(TimeSpan.FromSeconds(1.0), (Func<bool>) (() =>
      {
        if (!string.IsNullOrEmpty(this.entStudentID.Text) && !string.IsNullOrEmpty(this.entBirthday.Text))
        {
          if (this.entStudentID.Text.Length == 11)
            this.btnNext.IsEnabled = true;
          else
            this.btnNext.IsEnabled = false;
        }
        else
          this.btnNext.IsEnabled = false;
        return true;
      }));
      int _limit = 11;
      this.entStudentID.TextChanged += (EventHandler<TextChangedEventArgs>) ((sender, args) =>
      {
        string text = this.entStudentID.Text;
        if (text.Length <= _limit)
          return;
        this.entStudentID.Text = text.Remove(text.Length - 1);
      });
    }

    private void Birthday_Focused(object sender, FocusEventArgs e)
    {
      this.dtBirthday.Focus();
      this.entBirthday.Unfocus();
    }

    private void dtBirthday_DateSelected(object sender, DateChangedEventArgs e) => this.entBirthday.Text = this.dtBirthday.Date.ToString("MMM, dd yyyy");

    private void btnNext_Clicked(object sender, EventArgs e)
    {
      if (ConnectionHelper.IsConnected())
        Task.Run((Func<Task>) (async () => this._serverStatusOK = await this.ServerStatusAsync())).ContinueWith((Action<Task>) (result => Device.BeginInvokeOnMainThread((Action) (() =>
        {
          if (this._serverStatusOK == "true")
          {
            StudentCredentials studentCredentials = new StudentCredentials()
            {
              PSCSId = this.entStudentID.Text,
              Birthday = this.dtBirthday.Date,
              MiddleName = this.entMiddleName.Text
            };
            studentCredentials.MiddleName = studentCredentials.MiddleName == null ? "" : studentCredentials.MiddleName.Trim();
            Device.BeginInvokeOnMainThread((Action) (() =>
            {
              this.activityIndicator.IsVisible = true;
              this.btnNext.IsVisible = false;
            }));
            string content = "";
            StudentService studentService = new StudentService();
            Task.Run((Func<Task>) (async () => content = await studentService.validate_credentials(studentCredentials))).ContinueWith((Action<Task>) (result1 => Device.BeginInvokeOnMainThread((Action) (() =>
            {
              content = content.Replace('"', ' ');
              if (content.Trim() == "found")
              {
                    // ISSUE: variable of a compiler-generated type
                    EmailRecoveryPage.\u003C\u003Ec__DisplayClass8_0 cDisplayClass80 = this;
                JObject obj = new JObject();
                // ISSUE: reference to a compiler-generated field
                // ISSUE: reference to a compiler-generated field
                Task.Run((Func<Task>) (async () => obj = await cDisplayClass80.studentService.get_email_credentials(cDisplayClass80.\u003C\u003E4__this.entStudentID.Text))).ContinueWith((Action<Task>) (response => Device.BeginInvokeOnMainThread((Action) (() =>
                {
                  if ((string) obj["Email"] == "already retrieved")
                  {
                    // ISSUE: reference to a compiler-generated field
                    cDisplayClass80.\u003C\u003E4__this.stackEmailRecovery.IsVisible = false;
                    // ISSUE: reference to a compiler-generated field
                    cDisplayClass80.\u003C\u003E4__this.stackCredentials.IsVisible = true;
                    // ISSUE: reference to a compiler-generated field
                    cDisplayClass80.\u003C\u003E4__this.stackEmailPassword.IsVisible = false;
                    // ISSUE: reference to a compiler-generated field
                    cDisplayClass80.\u003C\u003E4__this.lblAlready.Text = "You've already retrieved your STI Microsoft Office 365 email and password. Please login to access the One STI Student Portal.";
                    // ISSUE: reference to a compiler-generated field
                    cDisplayClass80.\u003C\u003E4__this.lblFrameTitle.Text = "Retrieval Unsuccessful!";
                    // ISSUE: reference to a compiler-generated field
                    cDisplayClass80.\u003C\u003E4__this.lblAlready.IsVisible = true;
                    // ISSUE: reference to a compiler-generated field
                    cDisplayClass80.\u003C\u003E4__this.lblNote.IsVisible = false;
                  }
                  else if ((string) obj["Email"] == "credential not found")
                  {
                    // ISSUE: reference to a compiler-generated field
                    cDisplayClass80.\u003C\u003E4__this.btnNext.IsVisible = true;
                    // ISSUE: reference to a compiler-generated field
                    cDisplayClass80.\u003C\u003E4__this.activityIndicator.IsVisible = false;
                    // ISSUE: reference to a compiler-generated field
                    // ISSUE: reference to a compiler-generated method
                    Device.BeginInvokeOnMainThread(new Action(cDisplayClass80.\u003C\u003E4__this.\u003CbtnNext_Clicked\u003Eb__8_11));
                  }
                  else if (string.IsNullOrWhiteSpace((string) obj["Email"]))
                  {
                    // ISSUE: reference to a compiler-generated field
                    // ISSUE: reference to a compiler-generated method
                    Device.BeginInvokeOnMainThread(new Action(cDisplayClass80.\u003C\u003E4__this.\u003CbtnNext_Clicked\u003Eb__8_12));
                  }
                  else
                  {
                    // ISSUE: reference to a compiler-generated field
                    cDisplayClass80.\u003C\u003E4__this.stackEmailRecovery.IsVisible = false;
                    // ISSUE: reference to a compiler-generated field
                    cDisplayClass80.\u003C\u003E4__this.stackCredentials.IsVisible = true;
                    // ISSUE: reference to a compiler-generated field
                    cDisplayClass80.\u003C\u003E4__this.stackEmailPassword.IsVisible = true;
                    // ISSUE: reference to a compiler-generated field
                    cDisplayClass80.\u003C\u003E4__this.lblAlready.IsVisible = false;
                    // ISSUE: reference to a compiler-generated field
                    cDisplayClass80.\u003C\u003E4__this.lblNote.IsVisible = true;
                    // ISSUE: reference to a compiler-generated field
                    cDisplayClass80.\u003C\u003E4__this.lblFrameTitle.Text = "Successfully Retrieved!";
                    // ISSUE: reference to a compiler-generated field
                    cDisplayClass80.\u003C\u003E4__this.lblEmail.Text = (string) obj["Email"];
                    // ISSUE: reference to a compiler-generated field
                    cDisplayClass80.\u003C\u003E4__this.lblPassword.Text = (string) obj["Password"];
                  }
                }))));
              }
              else
              {
                this.btnNext.IsVisible = true;
                this.activityIndicator.IsVisible = false;
                Device.BeginInvokeOnMainThread((Action) (async () =>
                {
                  EmailRecoveryPage emailRecoveryPage = this;
                  if (!await emailRecoveryPage.DisplayAlert("", "You may have entered an incorrect data. Please try again or email us your student ID number for us to assist you in your login.", "EMAIL NOW", "CANCEL"))
                    return;
                  emailRecoveryPage.OpenEmail("Unable to retrieve my Microsoft O365 account");
                }));
              }
            }))));
          }
          else
            this.DisplayAlert("Temporarily Unavailable", "We're currently experiencing technical problem on our server.  We’re working on to fix the issues and we are estimating that by the end of the day today we should have fixed the issues. We apologize for the inconvenience and appreciate your patience. Thank you!", "OK");
        }))));
      else
        Acr.UserDialogs.UserDialogs.Instance.Toast("Network error. Please check your connection.");
    }

    private void btnDone_Clicked(object sender, EventArgs e) => Application.Current.MainPage = (Page) new NavigationPage((Page) new LoginPage());

    private void CopyPassword(object sender, EventArgs e)
    {
      DependencyService.Get<IClipboardService>()?.CopyToClipboard(this.lblPassword.Text);
      Acr.UserDialogs.UserDialogs.Instance.Toast("Copied to clipboard");
    }

    private void OpenEmail(string subject) => Device.OpenUri(new Uri("mailto:oneapp@sti.edu?subject=" + subject + "&body=Student ID: " + this.entStudentID.Text + Environment.NewLine + "Birthday: " + this.entBirthday.Text + Environment.NewLine + "Middle Name: " + this.entMiddleName.Text));

    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private void InitializeComponent()
    {
      if (ResourceLoader.ResourceProvider != null && ResourceLoader.ResourceProvider(typeof (EmailRecoveryPage).GetTypeInfo().Assembly.GetName(), "Views/EmailRecoveryPage.xaml") != null)
        this.__InitComponentRuntime();
      else if (Xamarin.Forms.Xaml.Internals.XamlLoader.XamlFileProvider != null && Xamarin.Forms.Xaml.Internals.XamlLoader.XamlFileProvider(this.GetType()) != null)
      {
        this.__InitComponentRuntime();
      }
      else
      {
        RowDefinition bindable1 = new RowDefinition();
        RowDefinition bindable2 = new RowDefinition();
        ColumnDefinition bindable3 = new ColumnDefinition();
        Image bindable4 = new Image();
        StaticResourceExtension resourceExtension1 = new StaticResourceExtension();
        Label bindable5 = new Label();
        Xamarin.Forms.Entry entry1 = new Xamarin.Forms.Entry();
        Xamarin.Forms.Entry entry2 = new Xamarin.Forms.Entry();
        DatePicker datePicker = new DatePicker();
        Xamarin.Forms.Entry entry3 = new Xamarin.Forms.Entry();
        Button button1 = new Button();
        ActivityIndicator activityIndicator = new ActivityIndicator();
        StackLayout bindable6 = new StackLayout();
        Frame bindable7 = new Frame();
        StackLayout stackLayout1 = new StackLayout();
        StaticResourceExtension resourceExtension2 = new StaticResourceExtension();
        Label label1 = new Label();
        BoxView bindable8 = new BoxView();
        StackLayout bindable9 = new StackLayout();
        StaticResourceExtension resourceExtension3 = new StaticResourceExtension();
        Label label2 = new Label();
        StaticResourceExtension resourceExtension4 = new StaticResourceExtension();
        Label bindable10 = new Label();
        StaticResourceExtension resourceExtension5 = new StaticResourceExtension();
        Label label3 = new Label();
        StackLayout bindable11 = new StackLayout();
        StaticResourceExtension resourceExtension6 = new StaticResourceExtension();
        Label bindable12 = new Label();
        StaticResourceExtension resourceExtension7 = new StaticResourceExtension();
        Label label4 = new Label();
        TapGestureRecognizer bindable13 = new TapGestureRecognizer();
        Image bindable14 = new Image();
        StackLayout bindable15 = new StackLayout();
        StackLayout bindable16 = new StackLayout();
        StackLayout stackLayout2 = new StackLayout();
        StaticResourceExtension resourceExtension8 = new StaticResourceExtension();
        Label label5 = new Label();
        Button button2 = new Button();
        StackLayout bindable17 = new StackLayout();
        Frame bindable18 = new Frame();
        StackLayout stackLayout3 = new StackLayout();
        Grid bindable19 = new Grid();
        StackLayout bindable20 = new StackLayout();
        ScrollView bindable21 = new ScrollView();
        EmailRecoveryPage bindable22 = this;
        NameScope nameScope = new NameScope();
        NameScope.SetNameScope((BindableObject) bindable22, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable21, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable20, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable19, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable1, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable2, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable3, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable4, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) stackLayout1, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("stackEmailRecovery", (object) stackLayout1);
        if (stackLayout1.StyleId == null)
          stackLayout1.StyleId = "stackEmailRecovery";
        NameScope.SetNameScope((BindableObject) bindable5, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable7, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable6, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) entry1, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("entStudentID", (object) entry1);
        if (entry1.StyleId == null)
          entry1.StyleId = "entStudentID";
        NameScope.SetNameScope((BindableObject) entry2, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("entBirthday", (object) entry2);
        if (entry2.StyleId == null)
          entry2.StyleId = "entBirthday";
        NameScope.SetNameScope((BindableObject) datePicker, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("dtBirthday", (object) datePicker);
        if (datePicker.StyleId == null)
          datePicker.StyleId = "dtBirthday";
        NameScope.SetNameScope((BindableObject) entry3, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("entMiddleName", (object) entry3);
        if (entry3.StyleId == null)
          entry3.StyleId = "entMiddleName";
        NameScope.SetNameScope((BindableObject) button1, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("btnNext", (object) button1);
        if (button1.StyleId == null)
          button1.StyleId = "btnNext";
        NameScope.SetNameScope((BindableObject) activityIndicator, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("activityIndicator", (object) activityIndicator);
        if (activityIndicator.StyleId == null)
          activityIndicator.StyleId = "activityIndicator";
        NameScope.SetNameScope((BindableObject) stackLayout3, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("stackCredentials", (object) stackLayout3);
        if (stackLayout3.StyleId == null)
          stackLayout3.StyleId = "stackCredentials";
        NameScope.SetNameScope((BindableObject) bindable18, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable17, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable9, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) label1, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("lblFrameTitle", (object) label1);
        if (label1.StyleId == null)
          label1.StyleId = "lblFrameTitle";
        NameScope.SetNameScope((BindableObject) bindable8, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) label2, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("lblNote", (object) label2);
        if (label2.StyleId == null)
          label2.StyleId = "lblNote";
        NameScope.SetNameScope((BindableObject) stackLayout2, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("stackEmailPassword", (object) stackLayout2);
        if (stackLayout2.StyleId == null)
          stackLayout2.StyleId = "stackEmailPassword";
        NameScope.SetNameScope((BindableObject) bindable11, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable10, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) label3, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("lblEmail", (object) label3);
        if (label3.StyleId == null)
          label3.StyleId = "lblEmail";
        NameScope.SetNameScope((BindableObject) bindable16, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable12, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable15, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) label4, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("lblPassword", (object) label4);
        if (label4.StyleId == null)
          label4.StyleId = "lblPassword";
        NameScope.SetNameScope((BindableObject) bindable14, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable13, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) label5, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("lblAlready", (object) label5);
        if (label5.StyleId == null)
          label5.StyleId = "lblAlready";
        NameScope.SetNameScope((BindableObject) button2, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("btnDone", (object) button2);
        if (button2.StyleId == null)
          button2.StyleId = "btnDone";
        this.stackEmailRecovery = stackLayout1;
        this.entStudentID = entry1;
        this.entBirthday = entry2;
        this.dtBirthday = datePicker;
        this.entMiddleName = entry3;
        this.btnNext = button1;
        this.activityIndicator = activityIndicator;
        this.stackCredentials = stackLayout3;
        this.lblFrameTitle = label1;
        this.lblNote = label2;
        this.stackEmailPassword = stackLayout2;
        this.lblEmail = label3;
        this.lblPassword = label4;
        this.lblAlready = label5;
        this.btnDone = button2;
        bindable22.SetValue(VisualElement.BackgroundColorProperty, (object) new Color(1.0, 1.0, 1.0, 1.0));
        bindable22.SetValue(Page.TitleProperty, (object) "Retrieve your account");
        bindable20.SetValue(View.VerticalOptionsProperty, (object) LayoutOptions.FillAndExpand);
        bindable19.SetValue(View.VerticalOptionsProperty, (object) LayoutOptions.FillAndExpand);
        bindable1.SetValue(RowDefinition.HeightProperty, new GridLengthTypeConverter().ConvertFromInvariantString("Auto"));
        ((DefinitionCollection<RowDefinition>) bindable19.GetValue(Grid.RowDefinitionsProperty)).Add(bindable1);
        bindable2.SetValue(RowDefinition.HeightProperty, new GridLengthTypeConverter().ConvertFromInvariantString("*"));
        ((DefinitionCollection<RowDefinition>) bindable19.GetValue(Grid.RowDefinitionsProperty)).Add(bindable2);
        bindable3.SetValue(ColumnDefinition.WidthProperty, new GridLengthTypeConverter().ConvertFromInvariantString("*"));
        ((DefinitionCollection<ColumnDefinition>) bindable19.GetValue(Grid.ColumnDefinitionsProperty)).Add(bindable3);
        bindable4.SetValue(View.MarginProperty, (object) new Thickness(10.0, 55.0, 10.0, 30.0));
        bindable4.SetValue(Image.SourceProperty, new ImageSourceConverter().ConvertFromInvariantString("launcher_icon"));
        bindable4.SetValue(VisualElement.HeightRequestProperty, (object) 55.0);
        bindable4.SetValue(Grid.RowProperty, (object) 0);
        bindable4.SetValue(Grid.ColumnProperty, (object) 0);
        bindable19.Children.Add((View) bindable4);
        stackLayout1.SetValue(Grid.RowProperty, (object) 1);
        stackLayout1.SetValue(Grid.ColumnProperty, (object) 0);
        stackLayout1.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.CenterAndExpand);
        stackLayout1.SetValue(View.MarginProperty, (object) new Thickness(20.0, 0.0, 20.0, 0.0));
        bindable5.SetValue(Label.TextProperty, (object) "Fill-in the form below to recover your account details.");
        resourceExtension1.Key = "smallHeader";
        StaticResourceExtension resourceExtension9 = resourceExtension1;
        XamlServiceProvider xamlServiceProvider1 = new XamlServiceProvider();
        Type type1 = typeof (IProvideValueTarget);
        object[] objectAndParents1 = new object[0 + 6];
        objectAndParents1[0] = (object) bindable5;
        objectAndParents1[1] = (object) stackLayout1;
        objectAndParents1[2] = (object) bindable19;
        objectAndParents1[3] = (object) bindable20;
        objectAndParents1[4] = (object) bindable21;
        objectAndParents1[5] = (object) bindable22;
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
        XamlTypeResolver service2 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver1, typeof (EmailRecoveryPage).GetTypeInfo().Assembly);
        xamlServiceProvider1.Add(type2, (object) service2);
        xamlServiceProvider1.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(28, 95)));
        object obj1 = resourceExtension9.ProvideValue((IServiceProvider) xamlServiceProvider1);
        bindable5.Style = (Style) obj1;
        bindable5.SetValue(Label.TextColorProperty, (object) new Color(0.250980406999588, 0.250980406999588, 0.250980406999588, 1.0));
        stackLayout1.Children.Add((View) bindable5);
        bindable7.SetValue(Frame.HasShadowProperty, (object) true);
        bindable7.SetValue(Layout.PaddingProperty, (object) new Thickness(15.0));
        bindable7.SetValue(View.MarginProperty, (object) new Thickness(0.0, 10.0, 0.0, 0.0));
        entry1.SetValue(Xamarin.Forms.Entry.PlaceholderProperty, (object) "11-digit Student ID");
        entry1.SetValue(Xamarin.Forms.Entry.FontFamilyProperty, (object) "Roboto-Regular.ttf#Roboto");
        Xamarin.Forms.Entry entry4 = entry1;
        BindableProperty fontSizeProperty1 = Xamarin.Forms.Entry.FontSizeProperty;
        FontSizeConverter fontSizeConverter1 = new FontSizeConverter();
        XamlServiceProvider xamlServiceProvider2 = new XamlServiceProvider();
        Type type3 = typeof (IProvideValueTarget);
        object[] objectAndParents2 = new object[0 + 8];
        objectAndParents2[0] = (object) entry1;
        objectAndParents2[1] = (object) bindable6;
        objectAndParents2[2] = (object) bindable7;
        objectAndParents2[3] = (object) stackLayout1;
        objectAndParents2[4] = (object) bindable19;
        objectAndParents2[5] = (object) bindable20;
        objectAndParents2[6] = (object) bindable21;
        objectAndParents2[7] = (object) bindable22;
        SimpleValueTargetProvider service3 = new SimpleValueTargetProvider(objectAndParents2, (object) Xamarin.Forms.Entry.FontSizeProperty);
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
        XamlTypeResolver service4 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver2, typeof (EmailRecoveryPage).GetTypeInfo().Assembly);
        xamlServiceProvider2.Add(type4, (object) service4);
        xamlServiceProvider2.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(35, 135)));
        object obj2 = ((IExtendedTypeConverter) fontSizeConverter1).ConvertFromInvariantString("Default", (IServiceProvider) xamlServiceProvider2);
        entry4.SetValue(fontSizeProperty1, obj2);
        entry1.SetValue(VisualElement.WidthRequestProperty, (object) 280.0);
        entry1.SetValue(InputView.KeyboardProperty, new KeyboardTypeConverter().ConvertFromInvariantString("Numeric"));
        bindable6.Children.Add((View) entry1);
        entry2.SetValue(Xamarin.Forms.Entry.PlaceholderProperty, (object) "Birthday");
        entry2.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.FillAndExpand);
        entry2.SetValue(Xamarin.Forms.Entry.FontFamilyProperty, (object) "Roboto-Regular.ttf#Roboto");
        Xamarin.Forms.Entry entry5 = entry2;
        BindableProperty fontSizeProperty2 = Xamarin.Forms.Entry.FontSizeProperty;
        FontSizeConverter fontSizeConverter2 = new FontSizeConverter();
        XamlServiceProvider xamlServiceProvider3 = new XamlServiceProvider();
        Type type5 = typeof (IProvideValueTarget);
        object[] objectAndParents3 = new object[0 + 8];
        objectAndParents3[0] = (object) entry2;
        objectAndParents3[1] = (object) bindable6;
        objectAndParents3[2] = (object) bindable7;
        objectAndParents3[3] = (object) stackLayout1;
        objectAndParents3[4] = (object) bindable19;
        objectAndParents3[5] = (object) bindable20;
        objectAndParents3[6] = (object) bindable21;
        objectAndParents3[7] = (object) bindable22;
        SimpleValueTargetProvider service5 = new SimpleValueTargetProvider(objectAndParents3, (object) Xamarin.Forms.Entry.FontSizeProperty);
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
        XamlTypeResolver service6 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver3, typeof (EmailRecoveryPage).GetTypeInfo().Assembly);
        xamlServiceProvider3.Add(type6, (object) service6);
        xamlServiceProvider3.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(37, 157)));
        object obj3 = ((IExtendedTypeConverter) fontSizeConverter2).ConvertFromInvariantString("Default", (IServiceProvider) xamlServiceProvider3);
        entry5.SetValue(fontSizeProperty2, obj3);
        entry2.Focused += new EventHandler<FocusEventArgs>(bindable22.Birthday_Focused);
        entry2.SetValue(VisualElement.WidthRequestProperty, (object) 280.0);
        bindable6.Children.Add((View) entry2);
        datePicker.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.FillAndExpand);
        datePicker.SetValue(DatePicker.FormatProperty, (object) "ddd MMM, dd yyyy");
        datePicker.SetValue(VisualElement.IsVisibleProperty, new VisualElement.VisibilityConverter().ConvertFromInvariantString("False"));
        datePicker.DateSelected += new EventHandler<DateChangedEventArgs>(bindable22.dtBirthday_DateSelected);
        bindable6.Children.Add((View) datePicker);
        entry3.SetValue(Xamarin.Forms.Entry.PlaceholderProperty, (object) "Middle Name (leave blank if none)");
        entry3.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.FillAndExpand);
        entry3.SetValue(Xamarin.Forms.Entry.FontFamilyProperty, (object) "Roboto-Regular.ttf#Roboto");
        Xamarin.Forms.Entry entry6 = entry3;
        BindableProperty fontSizeProperty3 = Xamarin.Forms.Entry.FontSizeProperty;
        FontSizeConverter fontSizeConverter3 = new FontSizeConverter();
        XamlServiceProvider xamlServiceProvider4 = new XamlServiceProvider();
        Type type7 = typeof (IProvideValueTarget);
        object[] objectAndParents4 = new object[0 + 8];
        objectAndParents4[0] = (object) entry3;
        objectAndParents4[1] = (object) bindable6;
        objectAndParents4[2] = (object) bindable7;
        objectAndParents4[3] = (object) stackLayout1;
        objectAndParents4[4] = (object) bindable19;
        objectAndParents4[5] = (object) bindable20;
        objectAndParents4[6] = (object) bindable21;
        objectAndParents4[7] = (object) bindable22;
        SimpleValueTargetProvider service7 = new SimpleValueTargetProvider(objectAndParents4, (object) Xamarin.Forms.Entry.FontSizeProperty);
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
        XamlTypeResolver service8 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver4, typeof (EmailRecoveryPage).GetTypeInfo().Assembly);
        xamlServiceProvider4.Add(type8, (object) service8);
        xamlServiceProvider4.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(39, 184)));
        object obj4 = ((IExtendedTypeConverter) fontSizeConverter3).ConvertFromInvariantString("Default", (IServiceProvider) xamlServiceProvider4);
        entry6.SetValue(fontSizeProperty3, obj4);
        entry3.SetValue(VisualElement.WidthRequestProperty, (object) 280.0);
        bindable6.Children.Add((View) entry3);
        button1.SetValue(VisualElement.IsEnabledProperty, (object) false);
        button1.SetValue(Button.TextProperty, (object) "ENTER");
        button1.SetValue(View.MarginProperty, (object) new Thickness(0.0, 10.0, 0.0, 0.0));
        button1.SetValue(Button.TextColorProperty, (object) new Color(1.0, 1.0, 1.0, 1.0));
        button1.SetValue(VisualElement.BackgroundColorProperty, (object) new Color(0.0431372560560703, 0.341176480054855, 0.576470613479614, 1.0));
        button1.SetValue(Button.FontFamilyProperty, (object) "Roboto-Regular.ttf#Roboto");
        button1.SetValue(VisualElement.HeightRequestProperty, (object) 35.0);
        Button button3 = button1;
        BindableProperty fontSizeProperty4 = Button.FontSizeProperty;
        FontSizeConverter fontSizeConverter4 = new FontSizeConverter();
        XamlServiceProvider xamlServiceProvider5 = new XamlServiceProvider();
        Type type9 = typeof (IProvideValueTarget);
        object[] objectAndParents5 = new object[0 + 8];
        objectAndParents5[0] = (object) button1;
        objectAndParents5[1] = (object) bindable6;
        objectAndParents5[2] = (object) bindable7;
        objectAndParents5[3] = (object) stackLayout1;
        objectAndParents5[4] = (object) bindable19;
        objectAndParents5[5] = (object) bindable20;
        objectAndParents5[6] = (object) bindable21;
        objectAndParents5[7] = (object) bindable22;
        SimpleValueTargetProvider service9 = new SimpleValueTargetProvider(objectAndParents5, (object) Button.FontSizeProperty);
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
        XamlTypeResolver service10 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver5, typeof (EmailRecoveryPage).GetTypeInfo().Assembly);
        xamlServiceProvider5.Add(type10, (object) service10);
        xamlServiceProvider5.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(41, 208)));
        object obj5 = ((IExtendedTypeConverter) fontSizeConverter4).ConvertFromInvariantString("12", (IServiceProvider) xamlServiceProvider5);
        button3.SetValue(fontSizeProperty4, obj5);
        button1.Clicked += new EventHandler(bindable22.btnNext_Clicked);
        bindable6.Children.Add((View) button1);
        activityIndicator.SetValue(ActivityIndicator.IsRunningProperty, (object) true);
        activityIndicator.SetValue(VisualElement.IsVisibleProperty, new VisualElement.VisibilityConverter().ConvertFromInvariantString("False"));
        activityIndicator.SetValue(VisualElement.HeightRequestProperty, (object) 35.0);
        activityIndicator.SetValue(View.MarginProperty, (object) new Thickness(0.0, 10.0, 0.0, 0.0));
        activityIndicator.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.Center);
        activityIndicator.SetValue(ActivityIndicator.ColorProperty, (object) new Color(0.905882358551025, 0.752941191196442, 0.113725490868092, 1.0));
        bindable6.Children.Add((View) activityIndicator);
        bindable7.SetValue(ContentView.ContentProperty, (object) bindable6);
        stackLayout1.Children.Add((View) bindable7);
        bindable19.Children.Add((View) stackLayout1);
        stackLayout3.SetValue(Grid.RowProperty, (object) 1);
        stackLayout3.SetValue(Grid.ColumnProperty, (object) 0);
        stackLayout3.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.CenterAndExpand);
        stackLayout3.SetValue(VisualElement.IsVisibleProperty, new VisualElement.VisibilityConverter().ConvertFromInvariantString("False"));
        bindable18.SetValue(Layout.PaddingProperty, (object) new Thickness(20.0));
        bindable18.SetValue(View.MarginProperty, (object) new Thickness(15.0, 0.0, 15.0, 10.0));
        bindable18.SetValue(Frame.CornerRadiusProperty, (object) 5f);
        bindable18.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.FillAndExpand);
        bindable9.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.FillAndExpand);
        label1.SetValue(Label.TextProperty, (object) "O365 Email Credentials");
        resourceExtension2.Key = "mediumHeader";
        StaticResourceExtension resourceExtension10 = resourceExtension2;
        XamlServiceProvider xamlServiceProvider6 = new XamlServiceProvider();
        Type type11 = typeof (IProvideValueTarget);
        object[] objectAndParents6 = new object[0 + 9];
        objectAndParents6[0] = (object) label1;
        objectAndParents6[1] = (object) bindable9;
        objectAndParents6[2] = (object) bindable17;
        objectAndParents6[3] = (object) bindable18;
        objectAndParents6[4] = (object) stackLayout3;
        objectAndParents6[5] = (object) bindable19;
        objectAndParents6[6] = (object) bindable20;
        objectAndParents6[7] = (object) bindable21;
        objectAndParents6[8] = (object) bindable22;
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
        XamlTypeResolver service12 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver6, typeof (EmailRecoveryPage).GetTypeInfo().Assembly);
        xamlServiceProvider6.Add(type12, (object) service12);
        xamlServiceProvider6.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(58, 97)));
        object obj6 = resourceExtension10.ProvideValue((IServiceProvider) xamlServiceProvider6);
        label1.Style = (Style) obj6;
        label1.SetValue(Label.TextColorProperty, (object) new Color(0.250980406999588, 0.250980406999588, 0.250980406999588, 1.0));
        label1.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.FillAndExpand);
        bindable9.Children.Add((View) label1);
        bindable8.SetValue(BoxView.ColorProperty, (object) new Color(0.905882358551025, 0.752941191196442, 0.113725490868092, 1.0));
        bindable8.SetValue(VisualElement.HeightRequestProperty, (object) 1.5);
        bindable8.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.FillAndExpand);
        bindable9.Children.Add((View) bindable8);
        bindable17.Children.Add((View) bindable9);
        label2.SetValue(Label.TextProperty, (object) "You can only retrieve your STI O365 details once so please copy the password or take a screenshot of your account details for safekeeping.");
        resourceExtension3.Key = "smallHeader";
        StaticResourceExtension resourceExtension11 = resourceExtension3;
        XamlServiceProvider xamlServiceProvider7 = new XamlServiceProvider();
        Type type13 = typeof (IProvideValueTarget);
        object[] objectAndParents7 = new object[0 + 8];
        objectAndParents7[0] = (object) label2;
        objectAndParents7[1] = (object) bindable17;
        objectAndParents7[2] = (object) bindable18;
        objectAndParents7[3] = (object) stackLayout3;
        objectAndParents7[4] = (object) bindable19;
        objectAndParents7[5] = (object) bindable20;
        objectAndParents7[6] = (object) bindable21;
        objectAndParents7[7] = (object) bindable22;
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
        XamlTypeResolver service14 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver7, typeof (EmailRecoveryPage).GetTypeInfo().Assembly);
        xamlServiceProvider7.Add(type14, (object) service14);
        xamlServiceProvider7.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(64, 203)));
        object obj7 = resourceExtension11.ProvideValue((IServiceProvider) xamlServiceProvider7);
        label2.Style = (Style) obj7;
        label2.SetValue(Label.TextColorProperty, (object) new Color(0.250980406999588, 0.250980406999588, 0.250980406999588, 1.0));
        bindable17.Children.Add((View) label2);
        stackLayout2.SetValue(View.MarginProperty, (object) new Thickness(0.0, 10.0, 0.0, 0.0));
        bindable11.SetValue(StackLayout.SpacingProperty, (object) 0.0);
        bindable11.SetValue(View.MarginProperty, (object) new Thickness(0.0, 10.0, 0.0, 0.0));
        bindable10.SetValue(Label.TextProperty, (object) "Email");
        resourceExtension4.Key = "smallHeader";
        StaticResourceExtension resourceExtension12 = resourceExtension4;
        XamlServiceProvider xamlServiceProvider8 = new XamlServiceProvider();
        Type type15 = typeof (IProvideValueTarget);
        object[] objectAndParents8 = new object[0 + 10];
        objectAndParents8[0] = (object) bindable10;
        objectAndParents8[1] = (object) bindable11;
        objectAndParents8[2] = (object) stackLayout2;
        objectAndParents8[3] = (object) bindable17;
        objectAndParents8[4] = (object) bindable18;
        objectAndParents8[5] = (object) stackLayout3;
        objectAndParents8[6] = (object) bindable19;
        objectAndParents8[7] = (object) bindable20;
        objectAndParents8[8] = (object) bindable21;
        objectAndParents8[9] = (object) bindable22;
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
        XamlTypeResolver service16 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver8, typeof (EmailRecoveryPage).GetTypeInfo().Assembly);
        xamlServiceProvider8.Add(type16, (object) service16);
        xamlServiceProvider8.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(68, 61)));
        object obj8 = resourceExtension12.ProvideValue((IServiceProvider) xamlServiceProvider8);
        bindable10.Style = (Style) obj8;
        bindable10.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.FillAndExpand);
        bindable11.Children.Add((View) bindable10);
        resourceExtension5.Key = "smallLabel";
        StaticResourceExtension resourceExtension13 = resourceExtension5;
        XamlServiceProvider xamlServiceProvider9 = new XamlServiceProvider();
        Type type17 = typeof (IProvideValueTarget);
        object[] objectAndParents9 = new object[0 + 10];
        objectAndParents9[0] = (object) label3;
        objectAndParents9[1] = (object) bindable11;
        objectAndParents9[2] = (object) stackLayout2;
        objectAndParents9[3] = (object) bindable17;
        objectAndParents9[4] = (object) bindable18;
        objectAndParents9[5] = (object) stackLayout3;
        objectAndParents9[6] = (object) bindable19;
        objectAndParents9[7] = (object) bindable20;
        objectAndParents9[8] = (object) bindable21;
        objectAndParents9[9] = (object) bindable22;
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
        XamlTypeResolver service18 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver9, typeof (EmailRecoveryPage).GetTypeInfo().Assembly);
        xamlServiceProvider9.Add(type18, (object) service18);
        xamlServiceProvider9.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(69, 66)));
        object obj9 = resourceExtension13.ProvideValue((IServiceProvider) xamlServiceProvider9);
        label3.Style = (Style) obj9;
        bindable11.Children.Add((View) label3);
        stackLayout2.Children.Add((View) bindable11);
        bindable16.SetValue(StackLayout.SpacingProperty, (object) 0.0);
        bindable16.SetValue(View.MarginProperty, (object) new Thickness(0.0, 10.0, 0.0, 0.0));
        bindable12.SetValue(Label.TextProperty, (object) "Password");
        resourceExtension6.Key = "smallHeader";
        StaticResourceExtension resourceExtension14 = resourceExtension6;
        XamlServiceProvider xamlServiceProvider10 = new XamlServiceProvider();
        Type type19 = typeof (IProvideValueTarget);
        object[] objectAndParents10 = new object[0 + 10];
        objectAndParents10[0] = (object) bindable12;
        objectAndParents10[1] = (object) bindable16;
        objectAndParents10[2] = (object) stackLayout2;
        objectAndParents10[3] = (object) bindable17;
        objectAndParents10[4] = (object) bindable18;
        objectAndParents10[5] = (object) stackLayout3;
        objectAndParents10[6] = (object) bindable19;
        objectAndParents10[7] = (object) bindable20;
        objectAndParents10[8] = (object) bindable21;
        objectAndParents10[9] = (object) bindable22;
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
        XamlTypeResolver service20 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver10, typeof (EmailRecoveryPage).GetTypeInfo().Assembly);
        xamlServiceProvider10.Add(type20, (object) service20);
        xamlServiceProvider10.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(73, 64)));
        object obj10 = resourceExtension14.ProvideValue((IServiceProvider) xamlServiceProvider10);
        bindable12.Style = (Style) obj10;
        bindable12.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.FillAndExpand);
        bindable16.Children.Add((View) bindable12);
        bindable15.SetValue(StackLayout.OrientationProperty, (object) StackOrientation.Horizontal);
        resourceExtension7.Key = "smallLabel";
        StaticResourceExtension resourceExtension15 = resourceExtension7;
        XamlServiceProvider xamlServiceProvider11 = new XamlServiceProvider();
        Type type21 = typeof (IProvideValueTarget);
        object[] objectAndParents11 = new object[0 + 11];
        objectAndParents11[0] = (object) label4;
        objectAndParents11[1] = (object) bindable15;
        objectAndParents11[2] = (object) bindable16;
        objectAndParents11[3] = (object) stackLayout2;
        objectAndParents11[4] = (object) bindable17;
        objectAndParents11[5] = (object) bindable18;
        objectAndParents11[6] = (object) stackLayout3;
        objectAndParents11[7] = (object) bindable19;
        objectAndParents11[8] = (object) bindable20;
        objectAndParents11[9] = (object) bindable21;
        objectAndParents11[10] = (object) bindable22;
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
        XamlTypeResolver service22 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver11, typeof (EmailRecoveryPage).GetTypeInfo().Assembly);
        xamlServiceProvider11.Add(type22, (object) service22);
        xamlServiceProvider11.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(75, 73)));
        object obj11 = resourceExtension15.ProvideValue((IServiceProvider) xamlServiceProvider11);
        label4.Style = (Style) obj11;
        label4.SetValue(View.VerticalOptionsProperty, (object) LayoutOptions.Center);
        label4.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.StartAndExpand);
        bindable15.Children.Add((View) label4);
        bindable14.SetValue(Image.SourceProperty, new ImageSourceConverter().ConvertFromInvariantString("ic_copy"));
        bindable14.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.End);
        bindable13.Tapped += new EventHandler(bindable22.CopyPassword);
        bindable14.GestureRecognizers.Add((IGestureRecognizer) bindable13);
        bindable15.Children.Add((View) bindable14);
        bindable16.Children.Add((View) bindable15);
        stackLayout2.Children.Add((View) bindable16);
        bindable17.Children.Add((View) stackLayout2);
        label5.SetValue(View.MarginProperty, (object) new Thickness(0.0, 15.0, 0.0, 0.0));
        label5.SetValue(Label.TextProperty, (object) "You've already retrieved your STI Microsoft Office 365 email and password. Please login to access the One STI Student Portal.");
        label5.SetValue(VisualElement.IsVisibleProperty, new VisualElement.VisibilityConverter().ConvertFromInvariantString("False"));
        resourceExtension8.Key = "smallLabel";
        StaticResourceExtension resourceExtension16 = resourceExtension8;
        XamlServiceProvider xamlServiceProvider12 = new XamlServiceProvider();
        Type type23 = typeof (IProvideValueTarget);
        object[] objectAndParents12 = new object[0 + 8];
        objectAndParents12[0] = (object) label5;
        objectAndParents12[1] = (object) bindable17;
        objectAndParents12[2] = (object) bindable18;
        objectAndParents12[3] = (object) stackLayout3;
        objectAndParents12[4] = (object) bindable19;
        objectAndParents12[5] = (object) bindable20;
        objectAndParents12[6] = (object) bindable21;
        objectAndParents12[7] = (object) bindable22;
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
        namespaceResolver12.Add("xlabs", "clr-namespace:XLabs.Forms.Controls;assembly=XLabs.Forms");
        XamlTypeResolver service24 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver12, typeof (EmailRecoveryPage).GetTypeInfo().Assembly);
        xamlServiceProvider12.Add(type24, (object) service24);
        xamlServiceProvider12.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(85, 229)));
        object obj12 = resourceExtension16.ProvideValue((IServiceProvider) xamlServiceProvider12);
        label5.Style = (Style) obj12;
        bindable17.Children.Add((View) label5);
        button2.SetValue(Button.TextProperty, (object) "DONE");
        button2.SetValue(View.MarginProperty, (object) new Thickness(0.0, 15.0, 0.0, 15.0));
        button2.SetValue(Button.TextColorProperty, (object) new Color(1.0, 1.0, 1.0, 1.0));
        button2.SetValue(VisualElement.BackgroundColorProperty, (object) new Color(0.0431372560560703, 0.341176480054855, 0.576470613479614, 1.0));
        button2.SetValue(Button.FontFamilyProperty, (object) "Roboto-Regular.ttf#Roboto");
        button2.SetValue(VisualElement.HeightRequestProperty, (object) 35.0);
        Button button4 = button2;
        BindableProperty fontSizeProperty5 = Button.FontSizeProperty;
        FontSizeConverter fontSizeConverter5 = new FontSizeConverter();
        XamlServiceProvider xamlServiceProvider13 = new XamlServiceProvider();
        Type type25 = typeof (IProvideValueTarget);
        object[] objectAndParents13 = new object[0 + 8];
        objectAndParents13[0] = (object) button2;
        objectAndParents13[1] = (object) bindable17;
        objectAndParents13[2] = (object) bindable18;
        objectAndParents13[3] = (object) stackLayout3;
        objectAndParents13[4] = (object) bindable19;
        objectAndParents13[5] = (object) bindable20;
        objectAndParents13[6] = (object) bindable21;
        objectAndParents13[7] = (object) bindable22;
        SimpleValueTargetProvider service25 = new SimpleValueTargetProvider(objectAndParents13, (object) Button.FontSizeProperty);
        xamlServiceProvider13.Add(type25, (object) service25);
        xamlServiceProvider13.Add(typeof (INameScopeProvider), (object) new NameScopeProvider()
        {
          NameScope = (INameScope) nameScope
        });
        Type type26 = typeof (IXamlTypeResolver);
        XmlNamespaceResolver namespaceResolver13 = new XmlNamespaceResolver();
        namespaceResolver13.Add("", "http://xamarin.com/schemas/2014/forms");
        namespaceResolver13.Add("x", "http://schemas.microsoft.com/winfx/2009/xaml");
        namespaceResolver13.Add("xlabs", "clr-namespace:XLabs.Forms.Controls;assembly=XLabs.Forms");
        XamlTypeResolver service26 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver13, typeof (EmailRecoveryPage).GetTypeInfo().Assembly);
        xamlServiceProvider13.Add(type26, (object) service26);
        xamlServiceProvider13.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(87, 190)));
        object obj13 = ((IExtendedTypeConverter) fontSizeConverter5).ConvertFromInvariantString("12", (IServiceProvider) xamlServiceProvider13);
        button4.SetValue(fontSizeProperty5, obj13);
        button2.Clicked += new EventHandler(bindable22.btnDone_Clicked);
        bindable17.Children.Add((View) button2);
        bindable18.SetValue(ContentView.ContentProperty, (object) bindable17);
        stackLayout3.Children.Add((View) bindable18);
        bindable19.Children.Add((View) stackLayout3);
        bindable20.Children.Add((View) bindable19);
        bindable21.Content = (View) bindable20;
        bindable22.SetValue(ContentPage.ContentProperty, (object) bindable21);
      }
    }

    private void __InitComponentRuntime()
    {
      this.LoadFromXaml<EmailRecoveryPage>(typeof (EmailRecoveryPage));
      this.stackEmailRecovery = NameScopeExtensions.FindByName<StackLayout>(this, "stackEmailRecovery");
      this.entStudentID = NameScopeExtensions.FindByName<Xamarin.Forms.Entry>(this, "entStudentID");
      this.entBirthday = NameScopeExtensions.FindByName<Xamarin.Forms.Entry>(this, "entBirthday");
      this.dtBirthday = NameScopeExtensions.FindByName<DatePicker>(this, "dtBirthday");
      this.entMiddleName = NameScopeExtensions.FindByName<Xamarin.Forms.Entry>(this, "entMiddleName");
      this.btnNext = NameScopeExtensions.FindByName<Button>(this, "btnNext");
      this.activityIndicator = NameScopeExtensions.FindByName<ActivityIndicator>(this, "activityIndicator");
      this.stackCredentials = NameScopeExtensions.FindByName<StackLayout>(this, "stackCredentials");
      this.lblFrameTitle = NameScopeExtensions.FindByName<Label>(this, "lblFrameTitle");
      this.lblNote = NameScopeExtensions.FindByName<Label>(this, "lblNote");
      this.stackEmailPassword = NameScopeExtensions.FindByName<StackLayout>(this, "stackEmailPassword");
      this.lblEmail = NameScopeExtensions.FindByName<Label>(this, "lblEmail");
      this.lblPassword = NameScopeExtensions.FindByName<Label>(this, "lblPassword");
      this.lblAlready = NameScopeExtensions.FindByName<Label>(this, "lblAlready");
      this.btnDone = NameScopeExtensions.FindByName<Button>(this, "btnDone");
    }
  }
}
