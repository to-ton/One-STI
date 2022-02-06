// Decompiled with JetBrains decompiler
// Type: one_sti_student_portal.Views.ReplyFeedback
// Assembly: one_sti_student_portal, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 39E34984-485E-45CE-9895-F7524E3024D6
// Assembly location: \\wsl.localhost\kali-linux\root\One STI Student Portal_1.3.8_apkcombo.com (1)\unknown\assemblies\one_sti_student_portal.dll

using ImageCircle.Forms.Plugin.Abstractions;
using one_sti_student_portal.Data;
using one_sti_student_portal.Helpers;
using one_sti_student_portal.Models;
using one_sti_student_portal.Renderers;
using one_sti_student_portal.Services;
using Refractored.XamForms.PullToRefresh;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
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
  [XamlFilePath("Views\\ReplyFeedback.xaml")]
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public class ReplyFeedback : ContentPage
  {
    private StudentData _studentData;
    private FeedbackData _feedbackData;
    private bool _isBusy;
    private bool _isConnected;
    private int _feedbackId;
    private string _subject;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private PullToRefreshLayout refreshFeedback;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private StackLayout stackBody;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private CircleImage imgAvatar;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private Label lblUser;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private BoxView bxView;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private Label lblSubject;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private Label lblCreatedOn;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private Label lblFeedback;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private StackLayout stackReply;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private Label lblRepliedOn;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private Label lblReply;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private StackLayout stackEnterReply;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private EditorXF editorMessage;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private Button btnSendReply;

    public ReplyFeedback(int feedbackid)
    {
      this.InitializeComponent();
      this._studentData = new StudentData();
      this._feedbackData = new FeedbackData();
      this._isConnected = ConnectionHelper.IsConnected();
      this._feedbackId = feedbackid;
      Connectivity.ConnectivityChanged += (EventHandler<ConnectivityChangedEventArgs>) ((sender, args) => this._isConnected = ConnectionHelper.IsConnected());
      this.refreshFeedback.RefreshCommand = (ICommand) new Command((Action) (() => this.RefreshContent()));
      this.RefreshContent();
    }

    private void RefreshContent() => this.LoadFeedback();

    private void TapGestureRecognizer_Tapped(object sender, EventArgs e) => Device.OpenUri(new Uri("mailto:oneapp@sti.edu"));

    private void BtnSendReply_Clicked(object sender, EventArgs e) => Task.Run((Func<Task>) (async () =>
    {
      if (!this._isConnected || this._isBusy)
        return;
      this._isBusy = true;
      string str = await new StudentService().SendFeedbackReply(new FeedbackWithReply()
      {
        feedback_id = this._feedbackId,
        reply = this.editorMessage.Text
      });
    })).ContinueWith((Action<Task>) (result => Device.BeginInvokeOnMainThread((Action) (() =>
    {
      Device.BeginInvokeOnMainThread((Action) (() =>
      {
        this.stackEnterReply.FadeTo(0.0, 1000U);
        this.stackReply.IsVisible = false;
      }));
      Device.BeginInvokeOnMainThread((Action) (() =>
      {
        this.stackReply.IsVisible = true;
        this.stackReply.FadeTo(1.0, 1000U);
        this.lblRepliedOn.Text = "REPLIED ON " + DateTime.Now.ToString("MMM dd, yyyy hh:mm tt").ToUpper();
        this.lblReply.Text = this.editorMessage.Text;
      }));
    }))));

    private void LoadFeedback()
    {
      using (List<FeedbackWithReply>.Enumerator enumerator = this._feedbackData.GetFeedbackDetail(this._feedbackId).Result.GetEnumerator())
      {
        if (enumerator.MoveNext())
        {
          FeedbackWithReply current = enumerator.Current;
          this._subject = current.subject;
          this.lblUser.Text = current.display_name;
          this.lblSubject.Text = current.subject.ToUpper();
          this.lblCreatedOn.Text = current.created_on.ToString("MMM dd, yyyy hh:mm tt").ToString().ToUpper();
          this.lblFeedback.Text = current.feedback;
          Color.FromHex("#404040");
          this.bxView.Color = !(current.subject.ToLower() == "on how i look") ? (!(current.subject.ToLower() == "my speed and performance") ? (!(current.subject.ToLower() == "your experience on my usability") ? (!(current.subject.ToLower() == "reporting an error/crash") ? (!(current.subject.ToLower() == "availability of information") ? (!(current.subject.ToLower() == "additional features") ? Color.FromHex("#95a5a6") : Color.FromHex("#f2784b")) : Color.FromHex("#736598")) : Color.FromHex("#c0392b")) : Color.FromHex("#2c82c9")) : Color.FromHex("#f5e51b")) : Color.FromHex("#68c3a3");
          this.stackReply.IsVisible = !string.IsNullOrWhiteSpace(current.reply);
          this.stackEnterReply.IsVisible = string.IsNullOrWhiteSpace(current.reply);
          this.lblRepliedOn.Text = "REPLIED ON " + current.replied_on.ToString("MMM dd, yyyy hh:mm tt").ToString().ToUpper();
          this.lblReply.Text = current.reply;
        }
      }
      this.imgAvatar.Source = (ImageSource) "default_avatar";
      this.stackBody.IsVisible = true;
    }

    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private void InitializeComponent()
    {
      if (ResourceLoader.ResourceProvider != null && ResourceLoader.ResourceProvider(typeof (ReplyFeedback).GetTypeInfo().Assembly.GetName(), "Views/ReplyFeedback.xaml") != null)
        this.__InitComponentRuntime();
      else if (Xamarin.Forms.Xaml.Internals.XamlLoader.XamlFileProvider != null && Xamarin.Forms.Xaml.Internals.XamlLoader.XamlFileProvider(this.GetType()) != null)
      {
        this.__InitComponentRuntime();
      }
      else
      {
        CircleImage circleImage = new CircleImage();
        StaticResourceExtension resourceExtension1 = new StaticResourceExtension();
        Label label1 = new Label();
        BoxView boxView = new BoxView();
        StaticResourceExtension resourceExtension2 = new StaticResourceExtension();
        Label label2 = new Label();
        StackLayout bindable1 = new StackLayout();
        StackLayout bindable2 = new StackLayout();
        StaticResourceExtension resourceExtension3 = new StaticResourceExtension();
        Label label3 = new Label();
        StackLayout bindable3 = new StackLayout();
        StaticResourceExtension resourceExtension4 = new StaticResourceExtension();
        Label label4 = new Label();
        BoxView bindable4 = new BoxView();
        StaticResourceExtension resourceExtension5 = new StaticResourceExtension();
        Label label5 = new Label();
        StaticResourceExtension resourceExtension6 = new StaticResourceExtension();
        Label label6 = new Label();
        StackLayout stackLayout1 = new StackLayout();
        StaticResourceExtension resourceExtension7 = new StaticResourceExtension();
        Label bindable5 = new Label();
        EditorXF editorXf1 = new EditorXF();
        Button button1 = new Button();
        StackLayout stackLayout2 = new StackLayout();
        StackLayout stackLayout3 = new StackLayout();
        ScrollView bindable6 = new ScrollView();
        PullToRefreshLayout pullToRefreshLayout = new PullToRefreshLayout();
        ReplyFeedback bindable7 = this;
        NameScope nameScope = new NameScope();
        NameScope.SetNameScope((BindableObject) bindable7, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) pullToRefreshLayout, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("refreshFeedback", (object) pullToRefreshLayout);
        if (pullToRefreshLayout.StyleId == null)
          pullToRefreshLayout.StyleId = "refreshFeedback";
        NameScope.SetNameScope((BindableObject) bindable6, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) stackLayout3, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("stackBody", (object) stackLayout3);
        if (stackLayout3.StyleId == null)
          stackLayout3.StyleId = "stackBody";
        NameScope.SetNameScope((BindableObject) bindable3, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) circleImage, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("imgAvatar", (object) circleImage);
        if (circleImage.StyleId == null)
          circleImage.StyleId = "imgAvatar";
        NameScope.SetNameScope((BindableObject) bindable2, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) label1, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("lblUser", (object) label1);
        if (label1.StyleId == null)
          label1.StyleId = "lblUser";
        NameScope.SetNameScope((BindableObject) bindable1, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) boxView, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("bxView", (object) boxView);
        if (boxView.StyleId == null)
          boxView.StyleId = "bxView";
        NameScope.SetNameScope((BindableObject) label2, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("lblSubject", (object) label2);
        if (label2.StyleId == null)
          label2.StyleId = "lblSubject";
        NameScope.SetNameScope((BindableObject) label3, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("lblCreatedOn", (object) label3);
        if (label3.StyleId == null)
          label3.StyleId = "lblCreatedOn";
        NameScope.SetNameScope((BindableObject) label4, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("lblFeedback", (object) label4);
        if (label4.StyleId == null)
          label4.StyleId = "lblFeedback";
        NameScope.SetNameScope((BindableObject) bindable4, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) stackLayout1, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("stackReply", (object) stackLayout1);
        if (stackLayout1.StyleId == null)
          stackLayout1.StyleId = "stackReply";
        NameScope.SetNameScope((BindableObject) label5, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("lblRepliedOn", (object) label5);
        if (label5.StyleId == null)
          label5.StyleId = "lblRepliedOn";
        NameScope.SetNameScope((BindableObject) label6, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("lblReply", (object) label6);
        if (label6.StyleId == null)
          label6.StyleId = "lblReply";
        NameScope.SetNameScope((BindableObject) stackLayout2, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("stackEnterReply", (object) stackLayout2);
        if (stackLayout2.StyleId == null)
          stackLayout2.StyleId = "stackEnterReply";
        NameScope.SetNameScope((BindableObject) bindable5, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) editorXf1, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("editorMessage", (object) editorXf1);
        if (editorXf1.StyleId == null)
          editorXf1.StyleId = "editorMessage";
        NameScope.SetNameScope((BindableObject) button1, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("btnSendReply", (object) button1);
        if (button1.StyleId == null)
          button1.StyleId = "btnSendReply";
        this.refreshFeedback = pullToRefreshLayout;
        this.stackBody = stackLayout3;
        this.imgAvatar = circleImage;
        this.lblUser = label1;
        this.bxView = boxView;
        this.lblSubject = label2;
        this.lblCreatedOn = label3;
        this.lblFeedback = label4;
        this.stackReply = stackLayout1;
        this.lblRepliedOn = label5;
        this.lblReply = label6;
        this.stackEnterReply = stackLayout2;
        this.editorMessage = editorXf1;
        this.btnSendReply = button1;
        bindable7.SetValue(Page.TitleProperty, (object) "My Feedback Details");
        pullToRefreshLayout.SetValue(PullToRefreshLayout.IsPullToRefreshEnabledProperty, (object) true);
        stackLayout3.SetValue(Layout.PaddingProperty, (object) new Thickness(15.0));
        stackLayout3.SetValue(VisualElement.IsVisibleProperty, new VisualElement.VisibilityConverter().ConvertFromInvariantString("False"));
        bindable3.SetValue(StackLayout.OrientationProperty, (object) StackOrientation.Horizontal);
        circleImage.SetValue(VisualElement.WidthRequestProperty, (object) 40.0);
        circleImage.SetValue(Image.SourceProperty, new ImageSourceConverter().ConvertFromInvariantString("default_avatar"));
        circleImage.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.Center);
        circleImage.SetValue(Image.AspectProperty, (object) Aspect.AspectFit);
        bindable3.Children.Add((View) circleImage);
        bindable2.SetValue(View.VerticalOptionsProperty, (object) LayoutOptions.Center);
        bindable2.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.FillAndExpand);
        bindable2.SetValue(StackLayout.SpacingProperty, (object) 0.0);
        label1.SetValue(Label.TextProperty, (object) "Me");
        resourceExtension1.Key = "smallLabel";
        StaticResourceExtension resourceExtension8 = resourceExtension1;
        XamlServiceProvider xamlServiceProvider1 = new XamlServiceProvider();
        Type type1 = typeof (IProvideValueTarget);
        object[] objectAndParents1 = new object[0 + 7];
        objectAndParents1[0] = (object) label1;
        objectAndParents1[1] = (object) bindable2;
        objectAndParents1[2] = (object) bindable3;
        objectAndParents1[3] = (object) stackLayout3;
        objectAndParents1[4] = (object) bindable6;
        objectAndParents1[5] = (object) pullToRefreshLayout;
        objectAndParents1[6] = (object) bindable7;
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
        namespaceResolver1.Add("ctrImage", "clr-namespace:ImageCircle.Forms.Plugin.Abstractions;assembly=ImageCircle.Forms.Plugin.Abstractions");
        namespaceResolver1.Add("controls", "clr-namespace:Refractored.XamForms.PullToRefresh;assembly=Refractored.XamForms.PullToRefresh");
        namespaceResolver1.Add("renderer", "clr-namespace:one_sti_student_portal.Renderers");
        XamlTypeResolver service2 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver1, typeof (ReplyFeedback).GetTypeInfo().Assembly);
        xamlServiceProvider1.Add(type2, (object) service2);
        xamlServiceProvider1.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(27, 63)));
        object obj1 = resourceExtension8.ProvideValue((IServiceProvider) xamlServiceProvider1);
        label1.Style = (Style) obj1;
        label1.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.FillAndExpand);
        label1.SetValue(View.VerticalOptionsProperty, (object) LayoutOptions.Center);
        bindable2.Children.Add((View) label1);
        bindable1.SetValue(StackLayout.OrientationProperty, (object) StackOrientation.Horizontal);
        boxView.SetValue(VisualElement.WidthRequestProperty, (object) 10.0);
        boxView.SetValue(VisualElement.HeightRequestProperty, (object) 10.0);
        boxView.SetValue(View.VerticalOptionsProperty, (object) LayoutOptions.Center);
        boxView.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.Center);
        bindable1.Children.Add((View) boxView);
        resourceExtension2.Key = "microHeader";
        StaticResourceExtension resourceExtension9 = resourceExtension2;
        XamlServiceProvider xamlServiceProvider2 = new XamlServiceProvider();
        Type type3 = typeof (IProvideValueTarget);
        object[] objectAndParents2 = new object[0 + 8];
        objectAndParents2[0] = (object) label2;
        objectAndParents2[1] = (object) bindable1;
        objectAndParents2[2] = (object) bindable2;
        objectAndParents2[3] = (object) bindable3;
        objectAndParents2[4] = (object) stackLayout3;
        objectAndParents2[5] = (object) bindable6;
        objectAndParents2[6] = (object) pullToRefreshLayout;
        objectAndParents2[7] = (object) bindable7;
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
        namespaceResolver2.Add("ctrImage", "clr-namespace:ImageCircle.Forms.Plugin.Abstractions;assembly=ImageCircle.Forms.Plugin.Abstractions");
        namespaceResolver2.Add("controls", "clr-namespace:Refractored.XamForms.PullToRefresh;assembly=Refractored.XamForms.PullToRefresh");
        namespaceResolver2.Add("renderer", "clr-namespace:one_sti_student_portal.Renderers");
        XamlTypeResolver service4 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver2, typeof (ReplyFeedback).GetTypeInfo().Assembly);
        xamlServiceProvider2.Add(type4, (object) service4);
        xamlServiceProvider2.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(36, 60)));
        object obj2 = resourceExtension9.ProvideValue((IServiceProvider) xamlServiceProvider2);
        label2.Style = (Style) obj2;
        label2.SetValue(Label.TextColorProperty, (object) new Color(0.250980406999588, 0.250980406999588, 0.250980406999588, 1.0));
        bindable1.Children.Add((View) label2);
        bindable2.Children.Add((View) bindable1);
        bindable3.Children.Add((View) bindable2);
        resourceExtension3.Key = "microLabel";
        StaticResourceExtension resourceExtension10 = resourceExtension3;
        XamlServiceProvider xamlServiceProvider3 = new XamlServiceProvider();
        Type type5 = typeof (IProvideValueTarget);
        object[] objectAndParents3 = new object[0 + 6];
        objectAndParents3[0] = (object) label3;
        objectAndParents3[1] = (object) bindable3;
        objectAndParents3[2] = (object) stackLayout3;
        objectAndParents3[3] = (object) bindable6;
        objectAndParents3[4] = (object) pullToRefreshLayout;
        objectAndParents3[5] = (object) bindable7;
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
        namespaceResolver3.Add("ctrImage", "clr-namespace:ImageCircle.Forms.Plugin.Abstractions;assembly=ImageCircle.Forms.Plugin.Abstractions");
        namespaceResolver3.Add("controls", "clr-namespace:Refractored.XamForms.PullToRefresh;assembly=Refractored.XamForms.PullToRefresh");
        namespaceResolver3.Add("renderer", "clr-namespace:one_sti_student_portal.Renderers");
        XamlTypeResolver service6 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver3, typeof (ReplyFeedback).GetTypeInfo().Assembly);
        xamlServiceProvider3.Add(type6, (object) service6);
        xamlServiceProvider3.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(42, 54)));
        object obj3 = resourceExtension10.ProvideValue((IServiceProvider) xamlServiceProvider3);
        label3.Style = (Style) obj3;
        label3.SetValue(View.VerticalOptionsProperty, (object) LayoutOptions.Center);
        bindable3.Children.Add((View) label3);
        stackLayout3.Children.Add((View) bindable3);
        resourceExtension4.Key = "smallLabel";
        StaticResourceExtension resourceExtension11 = resourceExtension4;
        XamlServiceProvider xamlServiceProvider4 = new XamlServiceProvider();
        Type type7 = typeof (IProvideValueTarget);
        object[] objectAndParents4 = new object[0 + 5];
        objectAndParents4[0] = (object) label4;
        objectAndParents4[1] = (object) stackLayout3;
        objectAndParents4[2] = (object) bindable6;
        objectAndParents4[3] = (object) pullToRefreshLayout;
        objectAndParents4[4] = (object) bindable7;
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
        namespaceResolver4.Add("ctrImage", "clr-namespace:ImageCircle.Forms.Plugin.Abstractions;assembly=ImageCircle.Forms.Plugin.Abstractions");
        namespaceResolver4.Add("controls", "clr-namespace:Refractored.XamForms.PullToRefresh;assembly=Refractored.XamForms.PullToRefresh");
        namespaceResolver4.Add("renderer", "clr-namespace:one_sti_student_portal.Renderers");
        XamlTypeResolver service8 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver4, typeof (ReplyFeedback).GetTypeInfo().Assembly);
        xamlServiceProvider4.Add(type8, (object) service8);
        xamlServiceProvider4.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(47, 49)));
        object obj4 = resourceExtension11.ProvideValue((IServiceProvider) xamlServiceProvider4);
        label4.Style = (Style) obj4;
        label4.SetValue(View.MarginProperty, (object) new Thickness(0.0, 5.0, 0.0, 0.0));
        label4.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.FillAndExpand);
        stackLayout3.Children.Add((View) label4);
        bindable4.SetValue(VisualElement.HeightRequestProperty, (object) 0.5);
        bindable4.SetValue(View.MarginProperty, (object) new Thickness(0.0, 10.0, 0.0, 10.0));
        bindable4.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.FillAndExpand);
        bindable4.SetValue(BoxView.ColorProperty, (object) new Color(0.400000005960464, 0.400000005960464, 0.400000005960464, 1.0));
        stackLayout3.Children.Add((View) bindable4);
        stackLayout1.SetValue(VisualElement.BackgroundColorProperty, (object) new Color(0.909803926944733, 0.925490200519562, 0.945098042488098, 1.0));
        stackLayout1.SetValue(Layout.PaddingProperty, (object) new Thickness(10.0, 15.0, 10.0, 15.0));
        resourceExtension5.Key = "microLabel";
        StaticResourceExtension resourceExtension12 = resourceExtension5;
        XamlServiceProvider xamlServiceProvider5 = new XamlServiceProvider();
        Type type9 = typeof (IProvideValueTarget);
        object[] objectAndParents5 = new object[0 + 6];
        objectAndParents5[0] = (object) label5;
        objectAndParents5[1] = (object) stackLayout1;
        objectAndParents5[2] = (object) stackLayout3;
        objectAndParents5[3] = (object) bindable6;
        objectAndParents5[4] = (object) pullToRefreshLayout;
        objectAndParents5[5] = (object) bindable7;
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
        namespaceResolver5.Add("ctrImage", "clr-namespace:ImageCircle.Forms.Plugin.Abstractions;assembly=ImageCircle.Forms.Plugin.Abstractions");
        namespaceResolver5.Add("controls", "clr-namespace:Refractored.XamForms.PullToRefresh;assembly=Refractored.XamForms.PullToRefresh");
        namespaceResolver5.Add("renderer", "clr-namespace:one_sti_student_portal.Renderers");
        XamlTypeResolver service10 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver5, typeof (ReplyFeedback).GetTypeInfo().Assembly);
        xamlServiceProvider5.Add(type10, (object) service10);
        xamlServiceProvider5.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(52, 54)));
        object obj5 = resourceExtension12.ProvideValue((IServiceProvider) xamlServiceProvider5);
        label5.Style = (Style) obj5;
        label5.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.FillAndExpand);
        stackLayout1.Children.Add((View) label5);
        resourceExtension6.Key = "smallLabel";
        StaticResourceExtension resourceExtension13 = resourceExtension6;
        XamlServiceProvider xamlServiceProvider6 = new XamlServiceProvider();
        Type type11 = typeof (IProvideValueTarget);
        object[] objectAndParents6 = new object[0 + 6];
        objectAndParents6[0] = (object) label6;
        objectAndParents6[1] = (object) stackLayout1;
        objectAndParents6[2] = (object) stackLayout3;
        objectAndParents6[3] = (object) bindable6;
        objectAndParents6[4] = (object) pullToRefreshLayout;
        objectAndParents6[5] = (object) bindable7;
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
        namespaceResolver6.Add("ctrImage", "clr-namespace:ImageCircle.Forms.Plugin.Abstractions;assembly=ImageCircle.Forms.Plugin.Abstractions");
        namespaceResolver6.Add("controls", "clr-namespace:Refractored.XamForms.PullToRefresh;assembly=Refractored.XamForms.PullToRefresh");
        namespaceResolver6.Add("renderer", "clr-namespace:one_sti_student_portal.Renderers");
        XamlTypeResolver service12 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver6, typeof (ReplyFeedback).GetTypeInfo().Assembly);
        xamlServiceProvider6.Add(type12, (object) service12);
        xamlServiceProvider6.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(53, 50)));
        object obj6 = resourceExtension13.ProvideValue((IServiceProvider) xamlServiceProvider6);
        label6.Style = (Style) obj6;
        stackLayout1.Children.Add((View) label6);
        stackLayout3.Children.Add((View) stackLayout1);
        bindable5.SetValue(Label.TextProperty, (object) "Reply");
        resourceExtension7.Key = "smallHeader";
        StaticResourceExtension resourceExtension14 = resourceExtension7;
        XamlServiceProvider xamlServiceProvider7 = new XamlServiceProvider();
        Type type13 = typeof (IProvideValueTarget);
        object[] objectAndParents7 = new object[0 + 6];
        objectAndParents7[0] = (object) bindable5;
        objectAndParents7[1] = (object) stackLayout2;
        objectAndParents7[2] = (object) stackLayout3;
        objectAndParents7[3] = (object) bindable6;
        objectAndParents7[4] = (object) pullToRefreshLayout;
        objectAndParents7[5] = (object) bindable7;
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
        namespaceResolver7.Add("ctrImage", "clr-namespace:ImageCircle.Forms.Plugin.Abstractions;assembly=ImageCircle.Forms.Plugin.Abstractions");
        namespaceResolver7.Add("controls", "clr-namespace:Refractored.XamForms.PullToRefresh;assembly=Refractored.XamForms.PullToRefresh");
        namespaceResolver7.Add("renderer", "clr-namespace:one_sti_student_portal.Renderers");
        XamlTypeResolver service14 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver7, typeof (ReplyFeedback).GetTypeInfo().Assembly);
        xamlServiceProvider7.Add(type14, (object) service14);
        xamlServiceProvider7.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(57, 45)));
        object obj7 = resourceExtension14.ProvideValue((IServiceProvider) xamlServiceProvider7);
        bindable5.Style = (Style) obj7;
        bindable5.SetValue(Label.TextColorProperty, (object) new Color(0.250980406999588, 0.250980406999588, 0.250980406999588, 1.0));
        stackLayout2.Children.Add((View) bindable5);
        EditorXF editorXf2 = editorXf1;
        BindableProperty fontSizeProperty1 = Editor.FontSizeProperty;
        FontSizeConverter fontSizeConverter1 = new FontSizeConverter();
        XamlServiceProvider xamlServiceProvider8 = new XamlServiceProvider();
        Type type15 = typeof (IProvideValueTarget);
        object[] objectAndParents8 = new object[0 + 6];
        objectAndParents8[0] = (object) editorXf1;
        objectAndParents8[1] = (object) stackLayout2;
        objectAndParents8[2] = (object) stackLayout3;
        objectAndParents8[3] = (object) bindable6;
        objectAndParents8[4] = (object) pullToRefreshLayout;
        objectAndParents8[5] = (object) bindable7;
        SimpleValueTargetProvider service15 = new SimpleValueTargetProvider(objectAndParents8, (object) Editor.FontSizeProperty);
        xamlServiceProvider8.Add(type15, (object) service15);
        xamlServiceProvider8.Add(typeof (INameScopeProvider), (object) new NameScopeProvider()
        {
          NameScope = (INameScope) nameScope
        });
        Type type16 = typeof (IXamlTypeResolver);
        XmlNamespaceResolver namespaceResolver8 = new XmlNamespaceResolver();
        namespaceResolver8.Add("", "http://xamarin.com/schemas/2014/forms");
        namespaceResolver8.Add("x", "http://schemas.microsoft.com/winfx/2009/xaml");
        namespaceResolver8.Add("ctrImage", "clr-namespace:ImageCircle.Forms.Plugin.Abstractions;assembly=ImageCircle.Forms.Plugin.Abstractions");
        namespaceResolver8.Add("controls", "clr-namespace:Refractored.XamForms.PullToRefresh;assembly=Refractored.XamForms.PullToRefresh");
        namespaceResolver8.Add("renderer", "clr-namespace:one_sti_student_portal.Renderers");
        XamlTypeResolver service16 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver8, typeof (ReplyFeedback).GetTypeInfo().Assembly);
        xamlServiceProvider8.Add(type16, (object) service16);
        xamlServiceProvider8.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(58, 67)));
        object obj8 = ((IExtendedTypeConverter) fontSizeConverter1).ConvertFromInvariantString("Default", (IServiceProvider) xamlServiceProvider8);
        editorXf2.SetValue(fontSizeProperty1, obj8);
        editorXf1.SetValue(EditorXF.PlaceholderProperty, (object) "Type here...");
        editorXf1.SetValue(Editor.FontFamilyProperty, (object) "Roboto-Regular.ttf#Roboto");
        editorXf1.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.FillAndExpand);
        stackLayout2.Children.Add((View) editorXf1);
        button1.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.End);
        button1.SetValue(Button.TextColorProperty, (object) Color.White);
        button1.SetValue(VisualElement.HeightRequestProperty, (object) 32.0);
        button1.SetValue(VisualElement.BackgroundColorProperty, (object) new Color(0.133333340287209, 0.65490198135376, 0.941176474094391, 1.0));
        Button button2 = button1;
        BindableProperty fontSizeProperty2 = Button.FontSizeProperty;
        FontSizeConverter fontSizeConverter2 = new FontSizeConverter();
        XamlServiceProvider xamlServiceProvider9 = new XamlServiceProvider();
        Type type17 = typeof (IProvideValueTarget);
        object[] objectAndParents9 = new object[0 + 6];
        objectAndParents9[0] = (object) button1;
        objectAndParents9[1] = (object) stackLayout2;
        objectAndParents9[2] = (object) stackLayout3;
        objectAndParents9[3] = (object) bindable6;
        objectAndParents9[4] = (object) pullToRefreshLayout;
        objectAndParents9[5] = (object) bindable7;
        SimpleValueTargetProvider service17 = new SimpleValueTargetProvider(objectAndParents9, (object) Button.FontSizeProperty);
        xamlServiceProvider9.Add(type17, (object) service17);
        xamlServiceProvider9.Add(typeof (INameScopeProvider), (object) new NameScopeProvider()
        {
          NameScope = (INameScope) nameScope
        });
        Type type18 = typeof (IXamlTypeResolver);
        XmlNamespaceResolver namespaceResolver9 = new XmlNamespaceResolver();
        namespaceResolver9.Add("", "http://xamarin.com/schemas/2014/forms");
        namespaceResolver9.Add("x", "http://schemas.microsoft.com/winfx/2009/xaml");
        namespaceResolver9.Add("ctrImage", "clr-namespace:ImageCircle.Forms.Plugin.Abstractions;assembly=ImageCircle.Forms.Plugin.Abstractions");
        namespaceResolver9.Add("controls", "clr-namespace:Refractored.XamForms.PullToRefresh;assembly=Refractored.XamForms.PullToRefresh");
        namespaceResolver9.Add("renderer", "clr-namespace:one_sti_student_portal.Renderers");
        XamlTypeResolver service18 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver9, typeof (ReplyFeedback).GetTypeInfo().Assembly);
        xamlServiceProvider9.Add(type18, (object) service18);
        xamlServiceProvider9.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(60, 142)));
        object obj9 = ((IExtendedTypeConverter) fontSizeConverter2).ConvertFromInvariantString("Micro", (IServiceProvider) xamlServiceProvider9);
        button2.SetValue(fontSizeProperty2, obj9);
        button1.SetValue(Button.TextProperty, (object) "SEND");
        button1.SetValue(Button.FontFamilyProperty, (object) "Roboto-Regular.ttf#Roboto");
        button1.SetValue(Button.BorderRadiusProperty, (object) 0);
        button1.SetValue(Button.BorderWidthProperty, (object) 0.0);
        button1.Clicked += new EventHandler(bindable7.BtnSendReply_Clicked);
        stackLayout2.Children.Add((View) button1);
        stackLayout3.Children.Add((View) stackLayout2);
        bindable6.Content = (View) stackLayout3;
        pullToRefreshLayout.SetValue(ContentView.ContentProperty, (object) bindable6);
        bindable7.SetValue(ContentPage.ContentProperty, (object) pullToRefreshLayout);
      }
    }

    private void __InitComponentRuntime()
    {
      this.LoadFromXaml<ReplyFeedback>(typeof (ReplyFeedback));
      this.refreshFeedback = NameScopeExtensions.FindByName<PullToRefreshLayout>(this, "refreshFeedback");
      this.stackBody = NameScopeExtensions.FindByName<StackLayout>(this, "stackBody");
      this.imgAvatar = NameScopeExtensions.FindByName<CircleImage>(this, "imgAvatar");
      this.lblUser = NameScopeExtensions.FindByName<Label>(this, "lblUser");
      this.bxView = NameScopeExtensions.FindByName<BoxView>(this, "bxView");
      this.lblSubject = NameScopeExtensions.FindByName<Label>(this, "lblSubject");
      this.lblCreatedOn = NameScopeExtensions.FindByName<Label>(this, "lblCreatedOn");
      this.lblFeedback = NameScopeExtensions.FindByName<Label>(this, "lblFeedback");
      this.stackReply = NameScopeExtensions.FindByName<StackLayout>(this, "stackReply");
      this.lblRepliedOn = NameScopeExtensions.FindByName<Label>(this, "lblRepliedOn");
      this.lblReply = NameScopeExtensions.FindByName<Label>(this, "lblReply");
      this.stackEnterReply = NameScopeExtensions.FindByName<StackLayout>(this, "stackEnterReply");
      this.editorMessage = NameScopeExtensions.FindByName<EditorXF>(this, "editorMessage");
      this.btnSendReply = NameScopeExtensions.FindByName<Button>(this, "btnSendReply");
    }
  }
}
