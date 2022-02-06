// Decompiled with JetBrains decompiler
// Type: one_sti_student_portal.Views.CreateFeedback
// Assembly: one_sti_student_portal, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 39E34984-485E-45CE-9895-F7524E3024D6
// Assembly location: \\wsl.localhost\kali-linux\root\One STI Student Portal_1.3.8_apkcombo.com (1)\unknown\assemblies\one_sti_student_portal.dll

using one_sti_student_portal.Data;
using one_sti_student_portal.Helpers;
using one_sti_student_portal.Models;
using one_sti_student_portal.Renderers;
using one_sti_student_portal.Services;
using System;
using System.CodeDom.Compiler;
using System.Linq;
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
  [XamlCompilation(XamlCompilationOptions.Compile)]
  [XamlFilePath("Views\\CreateFeedback.xaml")]
  public class CreateFeedback : ContentPage
  {
    private ToolbarItem toolbarItem;
    private bool _isConnected;
    private int _star;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private Image imgStar1;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private Image imgStar2;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private Image imgStar3;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private Image imgStar4;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private Image imgStar5;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private Picker pckrIssue;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private EditorXF editorMessage;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private StackLayout stackStatus;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private Label lblStatus;

    public CreateFeedback()
    {
      this.InitializeComponent();
      this._isConnected = ConnectionHelper.IsConnected();
      Connectivity.ConnectivityChanged += (EventHandler<ConnectivityChangedEventArgs>) ((sender, args) =>
      {
        this._isConnected = ConnectionHelper.IsConnected();
        this.CheckStatus();
      });
      switch (Device.RuntimePlatform)
      {
        case "Android":
          this.BackgroundColor = Color.Transparent;
          this.toolbarItem = new ToolbarItem("SEND", "ic_action_send.png", (Action) (() =>
          {
            this.WidthRequest = 5.0;
            this.HeightRequest = 5.0;
            this.SendFeedback();
          }));
          this.ToolbarItems.Add(this.toolbarItem);
          break;
        case "iOS":
          this.BackgroundColor = Color.Transparent;
          this.toolbarItem = new ToolbarItem("SEND", (string) null, (Action) (() =>
          {
            this.WidthRequest = 5.0;
            this.HeightRequest = 5.0;
            this.SendFeedback();
          }));
          this.ToolbarItems.Add(this.toolbarItem);
          break;
        default:
          throw new ArgumentOutOfRangeException();
      }
      this.pckrIssue.Items.Add("On how I look");
      this.pckrIssue.Items.Add("My speed and performance");
      this.pckrIssue.Items.Add("Your experience on my usability");
      this.pckrIssue.Items.Add("Reporting an error/crash");
      this.pckrIssue.Items.Add("Availability of information");
      this.pckrIssue.Items.Add("Additional features");
      this.pckrIssue.Items.Add("Others");
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

    private void SendFeedback()
    {
      if (this._star == 0 && this.pckrIssue.SelectedIndex == -1)
        this.DisplayAlert("", "Enter your feedback.", "OK");
      else if (this._isConnected)
      {
        string email = new StudentData().GetStudentInformation().Result.FirstOrDefault<StudentInformation>().Email;
        FeedbackModel feedback = new FeedbackModel()
        {
          App = "One STI Student Portal",
          Email = email,
          Subject = this.pckrIssue.SelectedIndex == -1 ? "Rating" : this.pckrIssue.SelectedItem.ToString(),
          Message = string.IsNullOrWhiteSpace(this.editorMessage.Text) ? "" : this.editorMessage.Text,
          Rating = this._star
        };
        StudentService studentService = new StudentService();
        Device.BeginInvokeOnMainThread((Action) (() => Acr.UserDialogs.UserDialogs.Instance.ShowLoading("Sending your feedback...")));
        string str;
        Task.Run((Func<Task>) (async () => str = await studentService.SendFeedback(feedback))).ContinueWith((Action<Task>) (result => Device.BeginInvokeOnMainThread((Action) (() =>
        {
          Acr.UserDialogs.UserDialogs.Instance.HideLoading();
          this.DisplayAlert("", "Thanks for your feedback!", "CLOSE");
          this.Navigation.PopAsync();
        }))));
      }
      else
        Acr.UserDialogs.UserDialogs.Instance.Toast("Feedback could not be sent. Check your network connection.");
    }

    private void btnSubmit_Clicked(object sender, EventArgs e) => this.SendFeedback();

    private void OneStar_Tapped(object sender, EventArgs e)
    {
      this._star = 1;
      this.FillRating();
    }

    private void TwoStar_Tapped(object sender, EventArgs e)
    {
      this._star = 2;
      this.FillRating();
    }

    private void ThreeStar_Tapped(object sender, EventArgs e)
    {
      this._star = 3;
      this.FillRating();
    }

    private void FourStar_Tapped(object sender, EventArgs e)
    {
      this._star = 4;
      this.FillRating();
    }

    private void FiveStar_Tapped(object sender, EventArgs e)
    {
      this._star = 5;
      this.FillRating();
    }

    private void FillRating() => Device.BeginInvokeOnMainThread((Action) (() =>
    {
      switch (this._star)
      {
        case 0:
          this.imgStar1.Source = (ImageSource) "ic_star_border";
          this.imgStar2.Source = (ImageSource) "ic_star_border";
          this.imgStar3.Source = (ImageSource) "ic_star_border";
          this.imgStar4.Source = (ImageSource) "ic_star_border";
          this.imgStar5.Source = (ImageSource) "ic_star_border";
          break;
        case 1:
          this.imgStar1.Source = (ImageSource) "ic_star_colored";
          this.imgStar2.Source = (ImageSource) "ic_star_border";
          this.imgStar3.Source = (ImageSource) "ic_star_border";
          this.imgStar4.Source = (ImageSource) "ic_star_border";
          this.imgStar5.Source = (ImageSource) "ic_star_border";
          break;
        case 2:
          this.imgStar1.Source = (ImageSource) "ic_star_colored";
          this.imgStar2.Source = (ImageSource) "ic_star_colored";
          this.imgStar3.Source = (ImageSource) "ic_star_border";
          this.imgStar4.Source = (ImageSource) "ic_star_border";
          this.imgStar5.Source = (ImageSource) "ic_star_border";
          break;
        case 3:
          this.imgStar1.Source = (ImageSource) "ic_star_colored";
          this.imgStar2.Source = (ImageSource) "ic_star_colored";
          this.imgStar3.Source = (ImageSource) "ic_star_colored";
          this.imgStar4.Source = (ImageSource) "ic_star_border";
          this.imgStar5.Source = (ImageSource) "ic_star_border";
          break;
        case 4:
          this.imgStar1.Source = (ImageSource) "ic_star_colored";
          this.imgStar2.Source = (ImageSource) "ic_star_colored";
          this.imgStar3.Source = (ImageSource) "ic_star_colored";
          this.imgStar4.Source = (ImageSource) "ic_star_colored";
          this.imgStar5.Source = (ImageSource) "ic_star_border";
          break;
        case 5:
          this.imgStar1.Source = (ImageSource) "ic_star_colored";
          this.imgStar2.Source = (ImageSource) "ic_star_colored";
          this.imgStar3.Source = (ImageSource) "ic_star_colored";
          this.imgStar4.Source = (ImageSource) "ic_star_colored";
          this.imgStar5.Source = (ImageSource) "ic_star_colored";
          break;
      }
    }));

    private void TapGestureRecognizer_Tapped(object sender, EventArgs e) => Device.OpenUri(new Uri("mailto:" + "oneapp@sti.edu"));

    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private void InitializeComponent()
    {
      if (ResourceLoader.ResourceProvider != null && ResourceLoader.ResourceProvider(typeof (CreateFeedback).GetTypeInfo().Assembly.GetName(), "Views/CreateFeedback.xaml") != null)
        this.__InitComponentRuntime();
      else if (Xamarin.Forms.Xaml.Internals.XamlLoader.XamlFileProvider != null && Xamarin.Forms.Xaml.Internals.XamlLoader.XamlFileProvider(this.GetType()) != null)
      {
        this.__InitComponentRuntime();
      }
      else
      {
        StaticResourceExtension resourceExtension1 = new StaticResourceExtension();
        Label bindable1 = new Label();
        TapGestureRecognizer bindable2 = new TapGestureRecognizer();
        Image image1 = new Image();
        TapGestureRecognizer bindable3 = new TapGestureRecognizer();
        Image image2 = new Image();
        TapGestureRecognizer bindable4 = new TapGestureRecognizer();
        Image image3 = new Image();
        TapGestureRecognizer bindable5 = new TapGestureRecognizer();
        Image image4 = new Image();
        TapGestureRecognizer bindable6 = new TapGestureRecognizer();
        Image image5 = new Image();
        StackLayout bindable7 = new StackLayout();
        StackLayout bindable8 = new StackLayout();
        StaticResourceExtension resourceExtension2 = new StaticResourceExtension();
        Label bindable9 = new Label();
        Picker picker = new Picker();
        StackLayout bindable10 = new StackLayout();
        StaticResourceExtension resourceExtension3 = new StaticResourceExtension();
        Label bindable11 = new Label();
        EditorXF editorXf1 = new EditorXF();
        StackLayout bindable12 = new StackLayout();
        Span bindable13 = new Span();
        Span bindable14 = new Span();
        FormattedString bindable15 = new FormattedString();
        TapGestureRecognizer bindable16 = new TapGestureRecognizer();
        Label bindable17 = new Label();
        StackLayout bindable18 = new StackLayout();
        StaticResourceExtension resourceExtension4 = new StaticResourceExtension();
        Label label1 = new Label();
        StackLayout stackLayout = new StackLayout();
        StackLayout bindable19 = new StackLayout();
        ScrollView bindable20 = new ScrollView();
        CreateFeedback bindable21 = this;
        NameScope nameScope = new NameScope();
        NameScope.SetNameScope((BindableObject) bindable21, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable20, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable19, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable8, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable1, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable7, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) image1, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("imgStar1", (object) image1);
        if (image1.StyleId == null)
          image1.StyleId = "imgStar1";
        NameScope.SetNameScope((BindableObject) bindable2, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) image2, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("imgStar2", (object) image2);
        if (image2.StyleId == null)
          image2.StyleId = "imgStar2";
        NameScope.SetNameScope((BindableObject) bindable3, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) image3, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("imgStar3", (object) image3);
        if (image3.StyleId == null)
          image3.StyleId = "imgStar3";
        NameScope.SetNameScope((BindableObject) bindable4, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) image4, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("imgStar4", (object) image4);
        if (image4.StyleId == null)
          image4.StyleId = "imgStar4";
        NameScope.SetNameScope((BindableObject) bindable5, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) image5, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("imgStar5", (object) image5);
        if (image5.StyleId == null)
          image5.StyleId = "imgStar5";
        NameScope.SetNameScope((BindableObject) bindable6, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable10, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable9, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) picker, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("pckrIssue", (object) picker);
        if (picker.StyleId == null)
          picker.StyleId = "pckrIssue";
        NameScope.SetNameScope((BindableObject) bindable12, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable11, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) editorXf1, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("editorMessage", (object) editorXf1);
        if (editorXf1.StyleId == null)
          editorXf1.StyleId = "editorMessage";
        NameScope.SetNameScope((BindableObject) bindable18, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable17, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable15, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable13, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable14, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable16, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) stackLayout, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("stackStatus", (object) stackLayout);
        if (stackLayout.StyleId == null)
          stackLayout.StyleId = "stackStatus";
        NameScope.SetNameScope((BindableObject) label1, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("lblStatus", (object) label1);
        if (label1.StyleId == null)
          label1.StyleId = "lblStatus";
        this.imgStar1 = image1;
        this.imgStar2 = image2;
        this.imgStar3 = image3;
        this.imgStar4 = image4;
        this.imgStar5 = image5;
        this.pckrIssue = picker;
        this.editorMessage = editorXf1;
        this.stackStatus = stackLayout;
        this.lblStatus = label1;
        bindable21.SetValue(Page.TitleProperty, (object) "Give us feedback");
        bindable19.SetValue(StackLayout.OrientationProperty, (object) StackOrientation.Vertical);
        bindable19.SetValue(View.VerticalOptionsProperty, (object) LayoutOptions.FillAndExpand);
        bindable8.SetValue(View.MarginProperty, (object) new Thickness(20.0));
        bindable8.SetValue(VisualElement.IsVisibleProperty, new VisualElement.VisibilityConverter().ConvertFromInvariantString("False"));
        bindable1.SetValue(Label.TextProperty, (object) "Rate us!");
        resourceExtension1.Key = "smallLabel";
        StaticResourceExtension resourceExtension5 = resourceExtension1;
        XamlServiceProvider xamlServiceProvider1 = new XamlServiceProvider();
        Type type1 = typeof (IProvideValueTarget);
        object[] objectAndParents1 = new object[0 + 5];
        objectAndParents1[0] = (object) bindable1;
        objectAndParents1[1] = (object) bindable8;
        objectAndParents1[2] = (object) bindable19;
        objectAndParents1[3] = (object) bindable20;
        objectAndParents1[4] = (object) bindable21;
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
        namespaceResolver1.Add("renderer", "clr-namespace:one_sti_student_portal.Renderers");
        XamlTypeResolver service2 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver1, typeof (CreateFeedback).GetTypeInfo().Assembly);
        xamlServiceProvider1.Add(type2, (object) service2);
        xamlServiceProvider1.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(15, 44)));
        object obj1 = resourceExtension5.ProvideValue((IServiceProvider) xamlServiceProvider1);
        bindable1.Style = (Style) obj1;
        bindable1.SetValue(Label.HorizontalTextAlignmentProperty, new TextAlignmentConverter().ConvertFromInvariantString("Center"));
        bindable1.SetValue(Label.FontFamilyProperty, (object) "Roboto-Regular.ttf#Roboto");
        bindable8.Children.Add((View) bindable1);
        bindable7.SetValue(StackLayout.OrientationProperty, (object) StackOrientation.Horizontal);
        bindable7.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.CenterAndExpand);
        image1.SetValue(Image.SourceProperty, new ImageSourceConverter().ConvertFromInvariantString("ic_star_border"));
        bindable2.Tapped += new EventHandler(bindable21.OneStar_Tapped);
        image1.GestureRecognizers.Add((IGestureRecognizer) bindable2);
        bindable7.Children.Add((View) image1);
        image2.SetValue(Image.SourceProperty, new ImageSourceConverter().ConvertFromInvariantString("ic_star_border"));
        bindable3.Tapped += new EventHandler(bindable21.TwoStar_Tapped);
        image2.GestureRecognizers.Add((IGestureRecognizer) bindable3);
        bindable7.Children.Add((View) image2);
        image3.SetValue(Image.SourceProperty, new ImageSourceConverter().ConvertFromInvariantString("ic_star_border"));
        bindable4.Tapped += new EventHandler(bindable21.ThreeStar_Tapped);
        image3.GestureRecognizers.Add((IGestureRecognizer) bindable4);
        bindable7.Children.Add((View) image3);
        image4.SetValue(Image.SourceProperty, new ImageSourceConverter().ConvertFromInvariantString("ic_star_border"));
        bindable5.Tapped += new EventHandler(bindable21.FourStar_Tapped);
        image4.GestureRecognizers.Add((IGestureRecognizer) bindable5);
        bindable7.Children.Add((View) image4);
        image5.SetValue(Image.SourceProperty, new ImageSourceConverter().ConvertFromInvariantString("ic_star_border"));
        bindable6.Tapped += new EventHandler(bindable21.FiveStar_Tapped);
        image5.GestureRecognizers.Add((IGestureRecognizer) bindable6);
        bindable7.Children.Add((View) image5);
        bindable8.Children.Add((View) bindable7);
        bindable19.Children.Add((View) bindable8);
        bindable10.SetValue(View.MarginProperty, (object) new Thickness(20.0, 20.0, 20.0, 0.0));
        bindable9.SetValue(Label.TextProperty, (object) "Select feedback type");
        resourceExtension2.Key = "smallLabel";
        StaticResourceExtension resourceExtension6 = resourceExtension2;
        XamlServiceProvider xamlServiceProvider2 = new XamlServiceProvider();
        Type type3 = typeof (IProvideValueTarget);
        object[] objectAndParents2 = new object[0 + 5];
        objectAndParents2[0] = (object) bindable9;
        objectAndParents2[1] = (object) bindable10;
        objectAndParents2[2] = (object) bindable19;
        objectAndParents2[3] = (object) bindable20;
        objectAndParents2[4] = (object) bindable21;
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
        namespaceResolver2.Add("renderer", "clr-namespace:one_sti_student_portal.Renderers");
        XamlTypeResolver service4 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver2, typeof (CreateFeedback).GetTypeInfo().Assembly);
        xamlServiceProvider2.Add(type4, (object) service4);
        xamlServiceProvider2.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(52, 56)));
        object obj2 = resourceExtension6.ProvideValue((IServiceProvider) xamlServiceProvider2);
        bindable9.Style = (Style) obj2;
        bindable9.SetValue(Label.FontFamilyProperty, (object) "Roboto-Regular.ttf#Roboto");
        bindable10.Children.Add((View) bindable9);
        picker.SetValue(Picker.TitleProperty, (object) "Select one");
        picker.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.FillAndExpand);
        bindable10.Children.Add((View) picker);
        bindable19.Children.Add((View) bindable10);
        bindable12.SetValue(View.MarginProperty, (object) new Thickness(20.0, 20.0, 20.0, 0.0));
        bindable12.SetValue(View.VerticalOptionsProperty, (object) LayoutOptions.FillAndExpand);
        bindable11.SetValue(Label.TextProperty, (object) "Feedback");
        resourceExtension3.Key = "smallLabel";
        StaticResourceExtension resourceExtension7 = resourceExtension3;
        XamlServiceProvider xamlServiceProvider3 = new XamlServiceProvider();
        Type type5 = typeof (IProvideValueTarget);
        object[] objectAndParents3 = new object[0 + 5];
        objectAndParents3[0] = (object) bindable11;
        objectAndParents3[1] = (object) bindable12;
        objectAndParents3[2] = (object) bindable19;
        objectAndParents3[3] = (object) bindable20;
        objectAndParents3[4] = (object) bindable21;
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
        namespaceResolver3.Add("renderer", "clr-namespace:one_sti_student_portal.Renderers");
        XamlTypeResolver service6 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver3, typeof (CreateFeedback).GetTypeInfo().Assembly);
        xamlServiceProvider3.Add(type6, (object) service6);
        xamlServiceProvider3.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(58, 44)));
        object obj3 = resourceExtension7.ProvideValue((IServiceProvider) xamlServiceProvider3);
        bindable11.Style = (Style) obj3;
        bindable11.SetValue(Label.FontFamilyProperty, (object) "Roboto-Regular.ttf#Roboto");
        bindable12.Children.Add((View) bindable11);
        EditorXF editorXf2 = editorXf1;
        BindableProperty fontSizeProperty1 = Editor.FontSizeProperty;
        FontSizeConverter fontSizeConverter1 = new FontSizeConverter();
        XamlServiceProvider xamlServiceProvider4 = new XamlServiceProvider();
        Type type7 = typeof (IProvideValueTarget);
        object[] objectAndParents4 = new object[0 + 5];
        objectAndParents4[0] = (object) editorXf1;
        objectAndParents4[1] = (object) bindable12;
        objectAndParents4[2] = (object) bindable19;
        objectAndParents4[3] = (object) bindable20;
        objectAndParents4[4] = (object) bindable21;
        SimpleValueTargetProvider service7 = new SimpleValueTargetProvider(objectAndParents4, (object) Editor.FontSizeProperty);
        xamlServiceProvider4.Add(type7, (object) service7);
        xamlServiceProvider4.Add(typeof (INameScopeProvider), (object) new NameScopeProvider()
        {
          NameScope = (INameScope) nameScope
        });
        Type type8 = typeof (IXamlTypeResolver);
        XmlNamespaceResolver namespaceResolver4 = new XmlNamespaceResolver();
        namespaceResolver4.Add("", "http://xamarin.com/schemas/2014/forms");
        namespaceResolver4.Add("x", "http://schemas.microsoft.com/winfx/2009/xaml");
        namespaceResolver4.Add("renderer", "clr-namespace:one_sti_student_portal.Renderers");
        XamlTypeResolver service8 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver4, typeof (CreateFeedback).GetTypeInfo().Assembly);
        xamlServiceProvider4.Add(type8, (object) service8);
        xamlServiceProvider4.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(59, 63)));
        object obj4 = ((IExtendedTypeConverter) fontSizeConverter1).ConvertFromInvariantString("Default", (IServiceProvider) xamlServiceProvider4);
        editorXf2.SetValue(fontSizeProperty1, obj4);
        editorXf1.SetValue(EditorXF.PlaceholderProperty, (object) "Type here...");
        editorXf1.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.FillAndExpand);
        bindable12.Children.Add((View) editorXf1);
        bindable19.Children.Add((View) bindable12);
        bindable18.SetValue(StackLayout.SpacingProperty, (object) 0.0);
        bindable18.SetValue(View.MarginProperty, (object) new Thickness(20.0));
        bindable17.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.Start);
        bindable13.SetValue(Span.TextProperty, (object) "You can also reach out us directly at ");
        Span span1 = bindable13;
        BindableProperty fontSizeProperty2 = Span.FontSizeProperty;
        FontSizeConverter fontSizeConverter2 = new FontSizeConverter();
        XamlServiceProvider xamlServiceProvider5 = new XamlServiceProvider();
        Type type9 = typeof (IProvideValueTarget);
        object[] objectAndParents5 = new object[0 + 7];
        objectAndParents5[0] = (object) bindable13;
        objectAndParents5[1] = (object) bindable15;
        objectAndParents5[2] = (object) bindable17;
        objectAndParents5[3] = (object) bindable18;
        objectAndParents5[4] = (object) bindable19;
        objectAndParents5[5] = (object) bindable20;
        objectAndParents5[6] = (object) bindable21;
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
        namespaceResolver5.Add("renderer", "clr-namespace:one_sti_student_portal.Renderers");
        XamlTypeResolver service10 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver5, typeof (CreateFeedback).GetTypeInfo().Assembly);
        xamlServiceProvider5.Add(type10, (object) service10);
        xamlServiceProvider5.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(68, 85)));
        object obj5 = ((IExtendedTypeConverter) fontSizeConverter2).ConvertFromInvariantString("Small", (IServiceProvider) xamlServiceProvider5);
        span1.SetValue(fontSizeProperty2, obj5);
        bindable13.SetValue(Span.FontFamilyProperty, (object) "Roboto-Regular.ttf#Roboto");
        bindable15.Spans.Add(bindable13);
        bindable14.SetValue(Span.TextProperty, (object) "oneapp@sti.edu");
        Span span2 = bindable14;
        BindableProperty fontSizeProperty3 = Span.FontSizeProperty;
        FontSizeConverter fontSizeConverter3 = new FontSizeConverter();
        XamlServiceProvider xamlServiceProvider6 = new XamlServiceProvider();
        Type type11 = typeof (IProvideValueTarget);
        object[] objectAndParents6 = new object[0 + 7];
        objectAndParents6[0] = (object) bindable14;
        objectAndParents6[1] = (object) bindable15;
        objectAndParents6[2] = (object) bindable17;
        objectAndParents6[3] = (object) bindable18;
        objectAndParents6[4] = (object) bindable19;
        objectAndParents6[5] = (object) bindable20;
        objectAndParents6[6] = (object) bindable21;
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
        namespaceResolver6.Add("renderer", "clr-namespace:one_sti_student_portal.Renderers");
        XamlTypeResolver service12 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver6, typeof (CreateFeedback).GetTypeInfo().Assembly);
        xamlServiceProvider6.Add(type12, (object) service12);
        xamlServiceProvider6.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(69, 61)));
        object obj6 = ((IExtendedTypeConverter) fontSizeConverter3).ConvertFromInvariantString("Small", (IServiceProvider) xamlServiceProvider6);
        span2.SetValue(fontSizeProperty3, obj6);
        bindable14.SetValue(Span.ForegroundColorProperty, (object) new Color(0.0431372560560703, 0.341176480054855, 0.576470613479614, 1.0));
        bindable14.SetValue(Span.FontFamilyProperty, (object) "Roboto-Regular.ttf#Roboto");
        bindable15.Spans.Add(bindable14);
        bindable17.SetValue(Label.FormattedTextProperty, (object) bindable15);
        bindable16.Tapped += new EventHandler(bindable21.TapGestureRecognizer_Tapped);
        bindable17.GestureRecognizers.Add((IGestureRecognizer) bindable16);
        bindable18.Children.Add((View) bindable17);
        bindable19.Children.Add((View) bindable18);
        stackLayout.SetValue(VisualElement.BackgroundColorProperty, (object) new Color(0.180392161011696, 0.192156866192818, 0.192156866192818, 1.0));
        stackLayout.SetValue(VisualElement.IsVisibleProperty, new VisualElement.VisibilityConverter().ConvertFromInvariantString("False"));
        stackLayout.SetValue(View.VerticalOptionsProperty, (object) LayoutOptions.End);
        stackLayout.SetValue(Layout.PaddingProperty, (object) new Thickness(3.0));
        stackLayout.SetValue(View.MarginProperty, (object) new Thickness(0.0));
        label1.SetValue(Label.TextProperty, (object) "No connection");
        resourceExtension4.Key = "microLabel";
        StaticResourceExtension resourceExtension8 = resourceExtension4;
        XamlServiceProvider xamlServiceProvider7 = new XamlServiceProvider();
        Type type13 = typeof (IProvideValueTarget);
        object[] objectAndParents7 = new object[0 + 5];
        objectAndParents7[0] = (object) label1;
        objectAndParents7[1] = (object) stackLayout;
        objectAndParents7[2] = (object) bindable19;
        objectAndParents7[3] = (object) bindable20;
        objectAndParents7[4] = (object) bindable21;
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
        namespaceResolver7.Add("renderer", "clr-namespace:one_sti_student_portal.Renderers");
        XamlTypeResolver service14 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver7, typeof (CreateFeedback).GetTypeInfo().Assembly);
        xamlServiceProvider7.Add(type14, (object) service14);
        xamlServiceProvider7.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(84, 68)));
        object obj7 = resourceExtension8.ProvideValue((IServiceProvider) xamlServiceProvider7);
        label1.Style = (Style) obj7;
        Label label2 = label1;
        BindableProperty fontSizeProperty4 = Label.FontSizeProperty;
        FontSizeConverter fontSizeConverter4 = new FontSizeConverter();
        XamlServiceProvider xamlServiceProvider8 = new XamlServiceProvider();
        Type type15 = typeof (IProvideValueTarget);
        object[] objectAndParents8 = new object[0 + 5];
        objectAndParents8[0] = (object) label1;
        objectAndParents8[1] = (object) stackLayout;
        objectAndParents8[2] = (object) bindable19;
        objectAndParents8[3] = (object) bindable20;
        objectAndParents8[4] = (object) bindable21;
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
        namespaceResolver8.Add("renderer", "clr-namespace:one_sti_student_portal.Renderers");
        XamlTypeResolver service16 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver8, typeof (CreateFeedback).GetTypeInfo().Assembly);
        xamlServiceProvider8.Add(type16, (object) service16);
        xamlServiceProvider8.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(84, 104)));
        object obj8 = ((IExtendedTypeConverter) fontSizeConverter4).ConvertFromInvariantString("12", (IServiceProvider) xamlServiceProvider8);
        label2.SetValue(fontSizeProperty4, obj8);
        label1.SetValue(Label.TextColorProperty, (object) new Color(1.0, 1.0, 1.0, 1.0));
        label1.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.Center);
        stackLayout.Children.Add((View) label1);
        bindable19.Children.Add((View) stackLayout);
        bindable20.Content = (View) bindable19;
        bindable21.SetValue(ContentPage.ContentProperty, (object) bindable20);
      }
    }

    private void __InitComponentRuntime()
    {
      this.LoadFromXaml<CreateFeedback>(typeof (CreateFeedback));
      this.imgStar1 = NameScopeExtensions.FindByName<Image>(this, "imgStar1");
      this.imgStar2 = NameScopeExtensions.FindByName<Image>(this, "imgStar2");
      this.imgStar3 = NameScopeExtensions.FindByName<Image>(this, "imgStar3");
      this.imgStar4 = NameScopeExtensions.FindByName<Image>(this, "imgStar4");
      this.imgStar5 = NameScopeExtensions.FindByName<Image>(this, "imgStar5");
      this.pckrIssue = NameScopeExtensions.FindByName<Picker>(this, "pckrIssue");
      this.editorMessage = NameScopeExtensions.FindByName<EditorXF>(this, "editorMessage");
      this.stackStatus = NameScopeExtensions.FindByName<StackLayout>(this, "stackStatus");
      this.lblStatus = NameScopeExtensions.FindByName<Label>(this, "lblStatus");
    }
  }
}
