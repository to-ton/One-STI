// Decompiled with JetBrains decompiler
// Type: one_sti_student_portal.Views.FeedbackPage
// Assembly: one_sti_student_portal, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 39E34984-485E-45CE-9895-F7524E3024D6
// Assembly location: \\wsl.localhost\kali-linux\root\One STI Student Portal_1.3.8_apkcombo.com (1)\unknown\assemblies\one_sti_student_portal.dll

using one_sti_student_portal.Data;
using one_sti_student_portal.Helpers;
using one_sti_student_portal.Models;
using one_sti_student_portal.Views.Widgets;
using Refractored.XamForms.PullToRefresh;
using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
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

namespace one_sti_student_portal.Views
{
  [XamlFilePath("Views\\FeedbackPage.xaml")]
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public class FeedbackPage : ContentPage
  {
    private bool _isBusy;
    private bool _isConnected;
    private FeedbackData _feedbackData;
    private StudentData _studentData;
    private bool blnShouldStay;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private PullToRefreshLayout refreshFeedbacks;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private ListView lvFeedbacks;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private StackLayout stackEmpty;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private Image imgEmpty;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private StackLayout stackStatus;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private Label lblStatus;

    public FeedbackPage()
    {
      this.InitializeComponent();
      this._feedbackData = new FeedbackData();
      this._studentData = new StudentData();
      this._isConnected = ConnectionHelper.IsConnected();
      Connectivity.ConnectivityChanged += (EventHandler<ConnectivityChangedEventArgs>) ((sender, args) =>
      {
        this._isConnected = ConnectionHelper.IsConnected();
        this.CheckStatus();
      });
      switch (Device.RuntimePlatform)
      {
        case "Android":
          this.ToolbarItems.Add(new ToolbarItem("", "ic_action_add", (Action) (() => this.Navigation.PushAsync((Page) new CreateFeedback(), true))));
          break;
        case "iOS":
          this.ToolbarItems.Add(new ToolbarItem("+", (string) null, (Action) (() => this.Navigation.PushAsync((Page) new CreateFeedback(), true))));
          break;
        default:
          throw new ArgumentOutOfRangeException();
      }
      this.refreshFeedbacks.RefreshCommand = (ICommand) new Command((Action) (() => this.RefreshContent()));
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
      this.RefreshContent();
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
      Device.BeginInvokeOnMainThread((Action) (() => this.refreshFeedbacks.IsRefreshing = true));
      Task.Run((Func<Task>) (async () =>
      {
        if (!this._isConnected || this._isBusy)
          return;
        this._isBusy = true;
        await this._feedbackData.DownloadMyFeedbacks(this._studentData.GetStudentInformation().Result.FirstOrDefault<StudentInformation>().Email);
      })).ContinueWith((Action<Task>) (result => Device.BeginInvokeOnMainThread((Action) (() =>
      {
        this.LoadFeedbacks();
        this.refreshFeedbacks.IsRefreshing = false;
        this._isBusy = false;
        if (ConnectionHelper.IsConnected())
          return;
        Acr.UserDialogs.UserDialogs.Instance.Toast("Could not refresh. Check your network connection.");
      }))));
    }

    private void LvFeedbacks_ItemTapped(object sender, ItemTappedEventArgs e) => this.Navigation.PushAsync((Page) new ViewFeedback(((ListViewTemplate) e.Item).feedback_id));

    private void LoadFeedbacks()
    {
      List<FeedbackWithReply> result = this._feedbackData.GetMyFeedbacks(this._studentData.GetStudentInformation().Result.FirstOrDefault<StudentInformation>().Email).Result;
      foreach (FeedbackWithReply feedbackWithReply in result)
      {
        if (!string.IsNullOrWhiteSpace(feedbackWithReply.reply))
        {
          feedbackWithReply.feedback = feedbackWithReply.reply;
          feedbackWithReply.created_on_formatted = feedbackWithReply.replied_on.ToString("MMM dd, yyyy hh:mm tt").ToString().ToUpper();
        }
      }
      List<FeedbackWithReply> list = result.OrderByDescending<FeedbackWithReply, string>((Func<FeedbackWithReply, string>) (o => o.created_on_formatted)).ToList<FeedbackWithReply>();
      List<ListViewTemplate> listViewTemplateList = new List<ListViewTemplate>();
      foreach (FeedbackWithReply feedbackWithReply in list)
      {
        ImageSource displayImage = (ImageSource) null;
        if (string.IsNullOrWhiteSpace(feedbackWithReply.reply))
        {
          foreach (StudentInformation studentInformation in this._studentData.GetStudentInformation().Result)
          {
            if (string.IsNullOrEmpty(studentInformation.ProfilePhoto))
            {
              displayImage = (ImageSource) "default_avatar";
            }
            else
            {
              byte[] bytes = Convert.FromBase64String(studentInformation.ProfilePhoto);
              Device.BeginInvokeOnMainThread((Action) (() => displayImage = ImageSource.FromStream((Func<Stream>) (() => (Stream) new MemoryStream(bytes)))));
            }
          }
        }
        Color.FromHex("#404040");
        Color color = !(feedbackWithReply.subject.ToLower() == "on how i look") ? (!(feedbackWithReply.subject.ToLower() == "my speed and performance") ? (!(feedbackWithReply.subject.ToLower() == "your experience on my usability") ? (!(feedbackWithReply.subject.ToLower() == "reporting an error/crash") ? (!(feedbackWithReply.subject.ToLower() == "availability of information") ? (!(feedbackWithReply.subject.ToLower() == "additional features") ? Color.FromHex("#95a5a6") : Color.FromHex("#f2784b")) : Color.FromHex("#736598")) : Color.FromHex("#c0392b")) : Color.FromHex("#2c82c9")) : Color.FromHex("#f5e51b")) : Color.FromHex("#68c3a3");
        listViewTemplateList.Add(new ListViewTemplate()
        {
          feedback_id = feedbackWithReply.feedback_id,
          created_on = feedbackWithReply.created_on_formatted,
          feedback = feedbackWithReply.feedback,
          reply = feedbackWithReply.reply,
          row_color = feedbackWithReply.unread ? Color.FromHex("#e8ecf1") : Color.FromHex("#FFF"),
          feedback_color = feedbackWithReply.unread ? Color.FromHex("#404040") : Color.FromHex("#666666"),
          display_image = string.IsNullOrWhiteSpace(feedbackWithReply.reply) ? displayImage : (ImageSource) "launcher_icon",
          display_name = string.IsNullOrWhiteSpace(feedbackWithReply.reply) ? "Me" : "One STI",
          subject = feedbackWithReply.subject.ToUpper(),
          subject_color = color,
          is_unread = feedbackWithReply.unread
        });
      }
      this.lvFeedbacks.ItemsSource = (IEnumerable) listViewTemplateList;
      this.lvFeedbacks.IsVisible = true;
      if (list.Count == 0)
      {
        this.lvFeedbacks.IsVisible = false;
        this.stackEmpty.IsVisible = true;
      }
      else
      {
        this.lvFeedbacks.IsVisible = true;
        this.stackEmpty.IsVisible = false;
      }
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

    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private void InitializeComponent()
    {
      if (ResourceLoader.ResourceProvider != null && ResourceLoader.ResourceProvider(typeof (FeedbackPage).GetTypeInfo().Assembly.GetName(), "Views/FeedbackPage.xaml") != null)
        this.__InitComponentRuntime();
      else if (Xamarin.Forms.Xaml.Internals.XamlLoader.XamlFileProvider != null && Xamarin.Forms.Xaml.Internals.XamlLoader.XamlFileProvider(this.GetType()) != null)
      {
        this.__InitComponentRuntime();
      }
      else
      {
        DataTemplate dataTemplate1 = new DataTemplate();
        ListView listView = new ListView();
        Image image = new Image();
        StaticResourceExtension resourceExtension1 = new StaticResourceExtension();
        Label bindable1 = new Label();
        StaticResourceExtension resourceExtension2 = new StaticResourceExtension();
        Label bindable2 = new Label();
        StackLayout stackLayout1 = new StackLayout();
        StackLayout bindable3 = new StackLayout();
        PullToRefreshLayout pullToRefreshLayout = new PullToRefreshLayout();
        StackLayout bindable4 = new StackLayout();
        StaticResourceExtension resourceExtension3 = new StaticResourceExtension();
        Label label1 = new Label();
        StackLayout stackLayout2 = new StackLayout();
        StackLayout bindable5 = new StackLayout();
        FeedbackPage bindable6 = this;
        NameScope nameScope = new NameScope();
        NameScope.SetNameScope((BindableObject) bindable6, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable5, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable4, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) pullToRefreshLayout, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("refreshFeedbacks", (object) pullToRefreshLayout);
        if (pullToRefreshLayout.StyleId == null)
          pullToRefreshLayout.StyleId = "refreshFeedbacks";
        NameScope.SetNameScope((BindableObject) bindable3, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) listView, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("lvFeedbacks", (object) listView);
        if (listView.StyleId == null)
          listView.StyleId = "lvFeedbacks";
        NameScope.SetNameScope((BindableObject) stackLayout1, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("stackEmpty", (object) stackLayout1);
        if (stackLayout1.StyleId == null)
          stackLayout1.StyleId = "stackEmpty";
        NameScope.SetNameScope((BindableObject) image, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("imgEmpty", (object) image);
        if (image.StyleId == null)
          image.StyleId = "imgEmpty";
        NameScope.SetNameScope((BindableObject) bindable1, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable2, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) stackLayout2, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("stackStatus", (object) stackLayout2);
        if (stackLayout2.StyleId == null)
          stackLayout2.StyleId = "stackStatus";
        NameScope.SetNameScope((BindableObject) label1, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("lblStatus", (object) label1);
        if (label1.StyleId == null)
          label1.StyleId = "lblStatus";
        this.refreshFeedbacks = pullToRefreshLayout;
        this.lvFeedbacks = listView;
        this.stackEmpty = stackLayout1;
        this.imgEmpty = image;
        this.stackStatus = stackLayout2;
        this.lblStatus = label1;
        bindable6.SetValue(Page.TitleProperty, (object) "My Feedbacks");
        bindable4.SetValue(View.VerticalOptionsProperty, (object) LayoutOptions.FillAndExpand);
        pullToRefreshLayout.SetValue(PullToRefreshLayout.IsPullToRefreshEnabledProperty, (object) true);
        listView.SetValue(VisualElement.IsVisibleProperty, new VisualElement.VisibilityConverter().ConvertFromInvariantString("False"));
        listView.ItemTapped += new EventHandler<ItemTappedEventArgs>(bindable6.LvFeedbacks_ItemTapped);
        listView.SetValue(ListView.HasUnevenRowsProperty, (object) true);
        listView.SetValue(VisualElement.BackgroundColorProperty, (object) Color.White);
        listView.SetValue(ListView.SeparatorVisibilityProperty, (object) SeparatorVisibility.Default);
        DataTemplate dataTemplate2 = dataTemplate1;
        // ISSUE: object of a compiler-generated type is created
        // ISSUE: variable of a compiler-generated type
        FeedbackPage.\u003CInitializeComponent\u003E_anonXamlCDataTemplate_4 xamlCdataTemplate4 = new FeedbackPage.\u003CInitializeComponent\u003E_anonXamlCDataTemplate_4();
        object[] objArray = new object[0 + 7];
        objArray[0] = (object) dataTemplate1;
        objArray[1] = (object) listView;
        objArray[2] = (object) bindable3;
        objArray[3] = (object) pullToRefreshLayout;
        objArray[4] = (object) bindable4;
        objArray[5] = (object) bindable5;
        objArray[6] = (object) bindable6;
        // ISSUE: reference to a compiler-generated field
        xamlCdataTemplate4.parentValues = objArray;
        // ISSUE: reference to a compiler-generated field
        xamlCdataTemplate4.root = bindable6;
        // ISSUE: reference to a compiler-generated method
        Func<object> func = new Func<object>(xamlCdataTemplate4.LoadDataTemplate);
        ((IDataTemplate) dataTemplate2).LoadTemplate = func;
        listView.SetValue(ItemsView<Cell>.ItemTemplateProperty, (object) dataTemplate1);
        bindable3.Children.Add((View) listView);
        stackLayout1.SetValue(StackLayout.SpacingProperty, (object) 5.0);
        stackLayout1.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.CenterAndExpand);
        stackLayout1.SetValue(View.VerticalOptionsProperty, (object) LayoutOptions.CenterAndExpand);
        image.SetValue(Image.SourceProperty, new ImageSourceConverter().ConvertFromInvariantString("ic_inbox"));
        stackLayout1.Children.Add((View) image);
        resourceExtension1.Key = "smallLabel";
        StaticResourceExtension resourceExtension4 = resourceExtension1;
        XamlServiceProvider xamlServiceProvider1 = new XamlServiceProvider();
        Type type1 = typeof (IProvideValueTarget);
        object[] objectAndParents1 = new object[0 + 7];
        objectAndParents1[0] = (object) bindable1;
        objectAndParents1[1] = (object) stackLayout1;
        objectAndParents1[2] = (object) bindable3;
        objectAndParents1[3] = (object) pullToRefreshLayout;
        objectAndParents1[4] = (object) bindable4;
        objectAndParents1[5] = (object) bindable5;
        objectAndParents1[6] = (object) bindable6;
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
        namespaceResolver1.Add("ctrImage", "clr-namespace:ImageCircle.Forms.Plugin.Abstractions;assembly=ImageCircle.Forms.Plugin.Abstractions");
        XamlTypeResolver service2 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver1, typeof (FeedbackPage).GetTypeInfo().Assembly);
        xamlServiceProvider1.Add(type2, (object) service2);
        xamlServiceProvider1.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(65, 36)));
        object obj1 = resourceExtension4.ProvideValue((IServiceProvider) xamlServiceProvider1);
        bindable1.Style = (Style) obj1;
        bindable1.SetValue(View.MarginProperty, (object) new Thickness(0.0, 5.0, 0.0, 0.0));
        bindable1.SetValue(Label.TextProperty, (object) "You haven't sent any feedbacks yet.");
        bindable1.SetValue(Label.HorizontalTextAlignmentProperty, new TextAlignmentConverter().ConvertFromInvariantString("Center"));
        stackLayout1.Children.Add((View) bindable1);
        resourceExtension2.Key = "smallHeader";
        StaticResourceExtension resourceExtension5 = resourceExtension2;
        XamlServiceProvider xamlServiceProvider2 = new XamlServiceProvider();
        Type type3 = typeof (IProvideValueTarget);
        object[] objectAndParents2 = new object[0 + 7];
        objectAndParents2[0] = (object) bindable2;
        objectAndParents2[1] = (object) stackLayout1;
        objectAndParents2[2] = (object) bindable3;
        objectAndParents2[3] = (object) pullToRefreshLayout;
        objectAndParents2[4] = (object) bindable4;
        objectAndParents2[5] = (object) bindable5;
        objectAndParents2[6] = (object) bindable6;
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
        namespaceResolver2.Add("ctrImage", "clr-namespace:ImageCircle.Forms.Plugin.Abstractions;assembly=ImageCircle.Forms.Plugin.Abstractions");
        XamlTypeResolver service4 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver2, typeof (FeedbackPage).GetTypeInfo().Assembly);
        xamlServiceProvider2.Add(type4, (object) service4);
        xamlServiceProvider2.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(66, 36)));
        object obj2 = resourceExtension5.ProvideValue((IServiceProvider) xamlServiceProvider2);
        bindable2.Style = (Style) obj2;
        bindable2.SetValue(Label.TextProperty, (object) "Send your feedback now");
        bindable2.SetValue(View.MarginProperty, (object) new Thickness(0.0, 10.0, 0.0, 0.0));
        bindable2.SetValue(Label.HorizontalTextAlignmentProperty, new TextAlignmentConverter().ConvertFromInvariantString("Center"));
        stackLayout1.Children.Add((View) bindable2);
        bindable3.Children.Add((View) stackLayout1);
        pullToRefreshLayout.SetValue(ContentView.ContentProperty, (object) bindable3);
        bindable4.Children.Add((View) pullToRefreshLayout);
        bindable5.Children.Add((View) bindable4);
        stackLayout2.SetValue(VisualElement.BackgroundColorProperty, (object) new Color(0.180392161011696, 0.192156866192818, 0.192156866192818, 1.0));
        stackLayout2.SetValue(VisualElement.IsVisibleProperty, new VisualElement.VisibilityConverter().ConvertFromInvariantString("False"));
        stackLayout2.SetValue(View.VerticalOptionsProperty, (object) LayoutOptions.End);
        stackLayout2.SetValue(Layout.PaddingProperty, (object) new Thickness(3.0));
        stackLayout2.SetValue(View.MarginProperty, (object) new Thickness(0.0));
        label1.SetValue(Label.TextProperty, (object) "No connection");
        resourceExtension3.Key = "microLabel";
        StaticResourceExtension resourceExtension6 = resourceExtension3;
        XamlServiceProvider xamlServiceProvider3 = new XamlServiceProvider();
        Type type5 = typeof (IProvideValueTarget);
        object[] objectAndParents3 = new object[0 + 4];
        objectAndParents3[0] = (object) label1;
        objectAndParents3[1] = (object) stackLayout2;
        objectAndParents3[2] = (object) bindable5;
        objectAndParents3[3] = (object) bindable6;
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
        namespaceResolver3.Add("ctrImage", "clr-namespace:ImageCircle.Forms.Plugin.Abstractions;assembly=ImageCircle.Forms.Plugin.Abstractions");
        XamlTypeResolver service6 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver3, typeof (FeedbackPage).GetTypeInfo().Assembly);
        xamlServiceProvider3.Add(type6, (object) service6);
        xamlServiceProvider3.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(74, 64)));
        object obj3 = resourceExtension6.ProvideValue((IServiceProvider) xamlServiceProvider3);
        label1.Style = (Style) obj3;
        Label label2 = label1;
        BindableProperty fontSizeProperty = Label.FontSizeProperty;
        FontSizeConverter fontSizeConverter = new FontSizeConverter();
        XamlServiceProvider xamlServiceProvider4 = new XamlServiceProvider();
        Type type7 = typeof (IProvideValueTarget);
        object[] objectAndParents4 = new object[0 + 4];
        objectAndParents4[0] = (object) label1;
        objectAndParents4[1] = (object) stackLayout2;
        objectAndParents4[2] = (object) bindable5;
        objectAndParents4[3] = (object) bindable6;
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
        namespaceResolver4.Add("ctrImage", "clr-namespace:ImageCircle.Forms.Plugin.Abstractions;assembly=ImageCircle.Forms.Plugin.Abstractions");
        XamlTypeResolver service8 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver4, typeof (FeedbackPage).GetTypeInfo().Assembly);
        xamlServiceProvider4.Add(type8, (object) service8);
        xamlServiceProvider4.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(74, 100)));
        object obj4 = ((IExtendedTypeConverter) fontSizeConverter).ConvertFromInvariantString("12", (IServiceProvider) xamlServiceProvider4);
        label2.SetValue(fontSizeProperty, obj4);
        label1.SetValue(Label.TextColorProperty, (object) new Color(1.0, 1.0, 1.0, 1.0));
        label1.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.Center);
        stackLayout2.Children.Add((View) label1);
        bindable5.Children.Add((View) stackLayout2);
        bindable6.SetValue(ContentPage.ContentProperty, (object) bindable5);
      }
    }

    private void __InitComponentRuntime()
    {
      this.LoadFromXaml<FeedbackPage>(typeof (FeedbackPage));
      this.refreshFeedbacks = NameScopeExtensions.FindByName<PullToRefreshLayout>(this, "refreshFeedbacks");
      this.lvFeedbacks = NameScopeExtensions.FindByName<ListView>(this, "lvFeedbacks");
      this.stackEmpty = NameScopeExtensions.FindByName<StackLayout>(this, "stackEmpty");
      this.imgEmpty = NameScopeExtensions.FindByName<Image>(this, "imgEmpty");
      this.stackStatus = NameScopeExtensions.FindByName<StackLayout>(this, "stackStatus");
      this.lblStatus = NameScopeExtensions.FindByName<Label>(this, "lblStatus");
    }
  }
}
