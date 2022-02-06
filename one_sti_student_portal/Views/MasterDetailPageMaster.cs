// Decompiled with JetBrains decompiler
// Type: one_sti_student_portal.Views.MasterDetailPageMaster
// Assembly: one_sti_student_portal, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 39E34984-485E-45CE-9895-F7524E3024D6
// Assembly location: \\wsl.localhost\kali-linux\root\One STI Student Portal_1.3.8_apkcombo.com (1)\unknown\assemblies\one_sti_student_portal.dll

using ImageCircle.Forms.Plugin.Abstractions;
using one_sti_student_portal.Data;
using one_sti_student_portal.Helpers;
using one_sti_student_portal.Models;
using one_sti_student_portal.Views.Students;
using one_sti_student_portal.Views.Widgets;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Xml;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.Xaml.Internals;

namespace one_sti_student_portal.Views
{
  [XamlFilePath("Views\\MasterDetailPageMaster.xaml")]
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public class MasterDetailPageMaster : ContentPage
  {
    public ListView ListView;
    private StudentData _studentData;
    private bool _isConnected;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private CircleImage imgAvatar;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private Label lblMyProfile;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private Label lblStudentName;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private Label lblStudentID;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private Label lblCrse;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private Label lblCampus;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private ListView MenuItemsListView;

    public MasterDetailPageMaster()
    {
      this.InitializeComponent();
      MasterDetailPageMaster.MasterDetailPageMasterViewModel pageMasterViewModel = new MasterDetailPageMaster.MasterDetailPageMasterViewModel();
      this.BindingContext = (object) pageMasterViewModel;
      this.ListView = this.MenuItemsListView;
      this.ListView.SelectedItem = (object) pageMasterViewModel.MenuItems[0];
      this._isConnected = ConnectionHelper.IsConnected();
      Connectivity.ConnectivityChanged += (EventHandler<ConnectivityChangedEventArgs>) ((sender, args) => this._isConnected = ConnectionHelper.IsConnected());
      this._studentData = new StudentData();
      if (this._studentData.HasUser())
      {
        foreach (StudentInformation studentInformation in this._studentData.GetStudentInformation().Result)
        {
          this.lblStudentName.Text = studentInformation.FirstName + " " + studentInformation.MiddleName + " " + studentInformation.LastName;
          this.lblStudentID.Text = studentInformation.PSCSId;
          this.lblCampus.Text = studentInformation.CampusDesc.ToUpper();
          if (string.IsNullOrEmpty(studentInformation.ProfilePhoto))
          {
            this.imgAvatar.Source = (ImageSource) "default_avatar";
          }
          else
          {
            byte[] bytes = Convert.FromBase64String(studentInformation.ProfilePhoto);
            Device.BeginInvokeOnMainThread((Action) (() => this.imgAvatar.Source = ImageSource.FromStream((Func<Stream>) (() => (Stream) new MemoryStream(bytes)))));
          }
          this.lblCrse.Text = studentInformation.ProgramShort.ToUpper();
        }
      }
      NavigationPage.SetTitleIcon((BindableObject) this, (FileImageSource) "hamburger.png");
    }

    protected override void OnAppearing() => base.OnAppearing();

    public static string UppercaseFirst(string s)
    {
      if (string.IsNullOrEmpty(s))
        return string.Empty;
      char[] charArray = s.ToCharArray();
      charArray[0] = char.ToUpper(charArray[0]);
      return new string(charArray);
    }

    private void Logout_Tapped(object sender, EventArgs e) => Device.BeginInvokeOnMainThread((Action) (async () =>
    {
      MasterDetailPageMaster detailPageMaster = this;
      (Application.Current.MainPage as MasterDetailPage).IsPresented = false;
      if (!await detailPageMaster.DisplayAlert("Confirm", "Logout now?", "YES", "NO"))
        return;
      Application.Current.MainPage = (Page) new LogoutPage();
    }));

    private void SwitchAccount(object sender, EventArgs e) => Application.Current.MainPage = (Page) new one_sti_student_portal.Views.SwitchAccount();

    private void ViewProfile_Tapped(object sender, EventArgs e)
    {
      MasterDetail masterDetail = new MasterDetail();
      masterDetail.Detail = (Page) new NavigationPage((Page) new StudentViewProfile());
      Application.Current.MainPage = (Page) masterDetail;
    }

    private void MyProfile(object sender, EventArgs e)
    {
      MasterDetail masterDetail = new MasterDetail();
      masterDetail.Detail = (Page) new NavigationPage((Page) new StudentViewProfile());
      Application.Current.MainPage = (Page) masterDetail;
    }

    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private void InitializeComponent()
    {
      if (ResourceLoader.ResourceProvider != null && ResourceLoader.ResourceProvider(typeof (MasterDetailPageMaster).GetTypeInfo().Assembly.GetName(), "Views/MasterDetailPageMaster.xaml") != null)
        this.__InitComponentRuntime();
      else if (Xamarin.Forms.Xaml.Internals.XamlLoader.XamlFileProvider != null && Xamarin.Forms.Xaml.Internals.XamlLoader.XamlFileProvider(this.GetType()) != null)
      {
        this.__InitComponentRuntime();
      }
      else
      {
        StringToColorConverter toColorConverter = new StringToColorConverter();
        ResourceDictionary resourceDictionary = new ResourceDictionary();
        TapGestureRecognizer bindable1 = new TapGestureRecognizer();
        CircleImage circleImage = new CircleImage();
        StaticResourceExtension resourceExtension1 = new StaticResourceExtension();
        TapGestureRecognizer bindable2 = new TapGestureRecognizer();
        Label label1 = new Label();
        StaticResourceExtension resourceExtension2 = new StaticResourceExtension();
        Label label2 = new Label();
        StaticResourceExtension resourceExtension3 = new StaticResourceExtension();
        Label label3 = new Label();
        StaticResourceExtension resourceExtension4 = new StaticResourceExtension();
        Label label4 = new Label();
        StaticResourceExtension resourceExtension5 = new StaticResourceExtension();
        Label bindable3 = new Label();
        StaticResourceExtension resourceExtension6 = new StaticResourceExtension();
        Label label5 = new Label();
        StackLayout bindable4 = new StackLayout();
        StackLayout bindable5 = new StackLayout();
        BoxView bindable6 = new BoxView();
        StackLayout bindable7 = new StackLayout();
        StackLayout bindable8 = new StackLayout();
        BindingExtension bindingExtension = new BindingExtension();
        DataTemplate dataTemplate1 = new DataTemplate();
        TapGestureRecognizer bindable9 = new TapGestureRecognizer();
        Image bindable10 = new Image();
        StaticResourceExtension resourceExtension7 = new StaticResourceExtension();
        Label bindable11 = new Label();
        StackLayout bindable12 = new StackLayout();
        ListView listView = new ListView();
        StackLayout bindable13 = new StackLayout();
        MasterDetailPageMaster bindable14 = this;
        NameScope nameScope = new NameScope();
        NameScope.SetNameScope((BindableObject) bindable14, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable13, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable8, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable7, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) circleImage, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("imgAvatar", (object) circleImage);
        if (circleImage.StyleId == null)
          circleImage.StyleId = "imgAvatar";
        NameScope.SetNameScope((BindableObject) bindable1, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable5, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) label1, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("lblMyProfile", (object) label1);
        if (label1.StyleId == null)
          label1.StyleId = "lblMyProfile";
        NameScope.SetNameScope((BindableObject) bindable2, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) label2, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("lblStudentName", (object) label2);
        if (label2.StyleId == null)
          label2.StyleId = "lblStudentName";
        NameScope.SetNameScope((BindableObject) label3, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("lblStudentID", (object) label3);
        if (label3.StyleId == null)
          label3.StyleId = "lblStudentID";
        NameScope.SetNameScope((BindableObject) bindable4, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) label4, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("lblCrse", (object) label4);
        if (label4.StyleId == null)
          label4.StyleId = "lblCrse";
        NameScope.SetNameScope((BindableObject) bindable3, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) label5, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("lblCampus", (object) label5);
        if (label5.StyleId == null)
          label5.StyleId = "lblCampus";
        NameScope.SetNameScope((BindableObject) bindable6, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) listView, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("MenuItemsListView", (object) listView);
        if (listView.StyleId == null)
          listView.StyleId = "MenuItemsListView";
        NameScope.SetNameScope((BindableObject) bindable12, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable9, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable10, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable11, (INameScope) nameScope);
        this.imgAvatar = circleImage;
        this.lblMyProfile = label1;
        this.lblStudentName = label2;
        this.lblStudentID = label3;
        this.lblCrse = label4;
        this.lblCampus = label5;
        this.MenuItemsListView = listView;
        bindable14.Resources = resourceDictionary;
        resourceDictionary.Add("StringToColorConverter", (object) toColorConverter);
        bindable14.SetValue(Page.TitleProperty, (object) "Master");
        bindable14.SetValue(Page.IconProperty, new FileImageSourceConverter().ConvertFromInvariantString("hamburger.png"));
        bindable14.SetValue(VisualElement.BackgroundColorProperty, (object) new Color(1.0, 1.0, 1.0, 1.0));
        bindable14.SetValue(NavigationPage.HasNavigationBarProperty, (object) false);
        bindable14.Resources = resourceDictionary;
        bindable8.SetValue(View.VerticalOptionsProperty, (object) LayoutOptions.Start);
        bindable8.SetValue(VisualElement.BackgroundColorProperty, (object) new Color(1.0, 1.0, 1.0, 1.0));
        bindable8.SetValue(StackLayout.SpacingProperty, (object) 0.0);
        bindable7.SetValue(View.MarginProperty, (object) new Thickness(15.0, 30.0, 15.0, 0.0));
        circleImage.SetValue(VisualElement.WidthRequestProperty, (object) 80.0);
        circleImage.SetValue(Image.SourceProperty, new ImageSourceConverter().ConvertFromInvariantString("default_avatar"));
        circleImage.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.Center);
        circleImage.SetValue(CircleImage.BorderThicknessProperty, (object) 2f);
        circleImage.SetValue(CircleImage.BorderColorProperty, (object) new Color(1.0, 1.0, 1.0, 1.0));
        circleImage.SetValue(Image.AspectProperty, (object) Aspect.AspectFit);
        bindable1.Tapped += new EventHandler(bindable14.ViewProfile_Tapped);
        circleImage.GestureRecognizers.Add((IGestureRecognizer) bindable1);
        bindable7.Children.Add((View) circleImage);
        bindable5.SetValue(View.VerticalOptionsProperty, (object) LayoutOptions.Center);
        bindable5.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.Center);
        bindable5.SetValue(View.MarginProperty, (object) new Thickness(0.0, 5.0, 0.0, 0.0));
        bindable5.SetValue(StackLayout.SpacingProperty, (object) 0.0);
        label1.SetValue(Label.TextProperty, (object) "MY PROFILE");
        resourceExtension1.Key = "microHeader";
        StaticResourceExtension resourceExtension8 = resourceExtension1;
        XamlServiceProvider xamlServiceProvider1 = new XamlServiceProvider();
        Type type1 = typeof (IProvideValueTarget);
        object[] objectAndParents1 = new object[0 + 6];
        objectAndParents1[0] = (object) label1;
        objectAndParents1[1] = (object) bindable5;
        objectAndParents1[2] = (object) bindable7;
        objectAndParents1[3] = (object) bindable8;
        objectAndParents1[4] = (object) bindable13;
        objectAndParents1[5] = (object) bindable14;
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
        namespaceResolver1.Add("stringToHex", "clr-namespace:one_sti_student_portal;assembly=one_sti_student_portal");
        namespaceResolver1.Add("ctrImage", "clr-namespace:ImageCircle.Forms.Plugin.Abstractions;assembly=ImageCircle.Forms.Plugin.Abstractions");
        XamlTypeResolver service2 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver1, typeof (MasterDetailPageMaster).GetTypeInfo().Assembly);
        xamlServiceProvider1.Add(type2, (object) service2);
        xamlServiceProvider1.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(34, 72)));
        object obj1 = resourceExtension8.ProvideValue((IServiceProvider) xamlServiceProvider1);
        label1.Style = (Style) obj1;
        label1.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.Center);
        Label label6 = label1;
        BindableProperty fontSizeProperty1 = Label.FontSizeProperty;
        FontSizeConverter fontSizeConverter1 = new FontSizeConverter();
        XamlServiceProvider xamlServiceProvider2 = new XamlServiceProvider();
        Type type3 = typeof (IProvideValueTarget);
        object[] objectAndParents2 = new object[0 + 6];
        objectAndParents2[0] = (object) label1;
        objectAndParents2[1] = (object) bindable5;
        objectAndParents2[2] = (object) bindable7;
        objectAndParents2[3] = (object) bindable8;
        objectAndParents2[4] = (object) bindable13;
        objectAndParents2[5] = (object) bindable14;
        SimpleValueTargetProvider service3 = new SimpleValueTargetProvider(objectAndParents2, (object) Label.FontSizeProperty);
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
        namespaceResolver2.Add("stringToHex", "clr-namespace:one_sti_student_portal;assembly=one_sti_student_portal");
        namespaceResolver2.Add("ctrImage", "clr-namespace:ImageCircle.Forms.Plugin.Abstractions;assembly=ImageCircle.Forms.Plugin.Abstractions");
        XamlTypeResolver service4 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver2, typeof (MasterDetailPageMaster).GetTypeInfo().Assembly);
        xamlServiceProvider2.Add(type4, (object) service4);
        xamlServiceProvider2.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(34, 136)));
        object obj2 = ((IExtendedTypeConverter) fontSizeConverter1).ConvertFromInvariantString("12", (IServiceProvider) xamlServiceProvider2);
        label6.SetValue(fontSizeProperty1, obj2);
        label1.SetValue(View.MarginProperty, (object) new Thickness(0.0, 0.0, 0.0, 5.0));
        bindable2.Tapped += new EventHandler(bindable14.MyProfile);
        label1.GestureRecognizers.Add((IGestureRecognizer) bindable2);
        bindable5.Children.Add((View) label1);
        resourceExtension2.Key = "smallHeader";
        StaticResourceExtension resourceExtension9 = resourceExtension2;
        XamlServiceProvider xamlServiceProvider3 = new XamlServiceProvider();
        Type type5 = typeof (IProvideValueTarget);
        object[] objectAndParents3 = new object[0 + 6];
        objectAndParents3[0] = (object) label2;
        objectAndParents3[1] = (object) bindable5;
        objectAndParents3[2] = (object) bindable7;
        objectAndParents3[3] = (object) bindable8;
        objectAndParents3[4] = (object) bindable13;
        objectAndParents3[5] = (object) bindable14;
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
        namespaceResolver3.Add("stringToHex", "clr-namespace:one_sti_student_portal;assembly=one_sti_student_portal");
        namespaceResolver3.Add("ctrImage", "clr-namespace:ImageCircle.Forms.Plugin.Abstractions;assembly=ImageCircle.Forms.Plugin.Abstractions");
        XamlTypeResolver service6 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver3, typeof (MasterDetailPageMaster).GetTypeInfo().Assembly);
        xamlServiceProvider3.Add(type6, (object) service6);
        xamlServiceProvider3.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(41, 56)));
        object obj3 = resourceExtension9.ProvideValue((IServiceProvider) xamlServiceProvider3);
        label2.Style = (Style) obj3;
        label2.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.Center);
        label2.SetValue(Label.TextColorProperty, (object) new Color(0.250980406999588, 0.250980406999588, 0.250980406999588, 1.0));
        label2.SetValue(Label.HorizontalTextAlignmentProperty, new TextAlignmentConverter().ConvertFromInvariantString("Center"));
        bindable5.Children.Add((View) label2);
        resourceExtension3.Key = "smallLabel";
        StaticResourceExtension resourceExtension10 = resourceExtension3;
        XamlServiceProvider xamlServiceProvider4 = new XamlServiceProvider();
        Type type7 = typeof (IProvideValueTarget);
        object[] objectAndParents4 = new object[0 + 6];
        objectAndParents4[0] = (object) label3;
        objectAndParents4[1] = (object) bindable5;
        objectAndParents4[2] = (object) bindable7;
        objectAndParents4[3] = (object) bindable8;
        objectAndParents4[4] = (object) bindable13;
        objectAndParents4[5] = (object) bindable14;
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
        namespaceResolver4.Add("stringToHex", "clr-namespace:one_sti_student_portal;assembly=one_sti_student_portal");
        namespaceResolver4.Add("ctrImage", "clr-namespace:ImageCircle.Forms.Plugin.Abstractions;assembly=ImageCircle.Forms.Plugin.Abstractions");
        XamlTypeResolver service8 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver4, typeof (MasterDetailPageMaster).GetTypeInfo().Assembly);
        xamlServiceProvider4.Add(type8, (object) service8);
        xamlServiceProvider4.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(42, 54)));
        object obj4 = resourceExtension10.ProvideValue((IServiceProvider) xamlServiceProvider4);
        label3.Style = (Style) obj4;
        Label label7 = label3;
        BindableProperty fontSizeProperty2 = Label.FontSizeProperty;
        FontSizeConverter fontSizeConverter2 = new FontSizeConverter();
        XamlServiceProvider xamlServiceProvider5 = new XamlServiceProvider();
        Type type9 = typeof (IProvideValueTarget);
        object[] objectAndParents5 = new object[0 + 6];
        objectAndParents5[0] = (object) label3;
        objectAndParents5[1] = (object) bindable5;
        objectAndParents5[2] = (object) bindable7;
        objectAndParents5[3] = (object) bindable8;
        objectAndParents5[4] = (object) bindable13;
        objectAndParents5[5] = (object) bindable14;
        SimpleValueTargetProvider service9 = new SimpleValueTargetProvider(objectAndParents5, (object) Label.FontSizeProperty);
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
        namespaceResolver5.Add("stringToHex", "clr-namespace:one_sti_student_portal;assembly=one_sti_student_portal");
        namespaceResolver5.Add("ctrImage", "clr-namespace:ImageCircle.Forms.Plugin.Abstractions;assembly=ImageCircle.Forms.Plugin.Abstractions");
        XamlTypeResolver service10 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver5, typeof (MasterDetailPageMaster).GetTypeInfo().Assembly);
        xamlServiceProvider5.Add(type10, (object) service10);
        xamlServiceProvider5.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(42, 90)));
        object obj5 = ((IExtendedTypeConverter) fontSizeConverter2).ConvertFromInvariantString("13", (IServiceProvider) xamlServiceProvider5);
        label7.SetValue(fontSizeProperty2, obj5);
        label3.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.Center);
        label3.SetValue(Label.HorizontalTextAlignmentProperty, new TextAlignmentConverter().ConvertFromInvariantString("Center"));
        label3.SetValue(Label.TextColorProperty, (object) new Color(0.400000005960464, 0.400000005960464, 0.400000005960464, 1.0));
        bindable5.Children.Add((View) label3);
        bindable4.SetValue(StackLayout.OrientationProperty, (object) StackOrientation.Horizontal);
        bindable4.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.Center);
        bindable4.SetValue(StackLayout.SpacingProperty, (object) 0.0);
        bindable4.SetValue(View.MarginProperty, (object) new Thickness(0.0, 10.0, 0.0, 0.0));
        resourceExtension4.Key = "smallLabel";
        StaticResourceExtension resourceExtension11 = resourceExtension4;
        XamlServiceProvider xamlServiceProvider6 = new XamlServiceProvider();
        Type type11 = typeof (IProvideValueTarget);
        object[] objectAndParents6 = new object[0 + 7];
        objectAndParents6[0] = (object) label4;
        objectAndParents6[1] = (object) bindable4;
        objectAndParents6[2] = (object) bindable5;
        objectAndParents6[3] = (object) bindable7;
        objectAndParents6[4] = (object) bindable8;
        objectAndParents6[5] = (object) bindable13;
        objectAndParents6[6] = (object) bindable14;
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
        namespaceResolver6.Add("stringToHex", "clr-namespace:one_sti_student_portal;assembly=one_sti_student_portal");
        namespaceResolver6.Add("ctrImage", "clr-namespace:ImageCircle.Forms.Plugin.Abstractions;assembly=ImageCircle.Forms.Plugin.Abstractions");
        XamlTypeResolver service12 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver6, typeof (MasterDetailPageMaster).GetTypeInfo().Assembly);
        xamlServiceProvider6.Add(type12, (object) service12);
        xamlServiceProvider6.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(51, 53)));
        object obj6 = resourceExtension11.ProvideValue((IServiceProvider) xamlServiceProvider6);
        label4.Style = (Style) obj6;
        Label label8 = label4;
        BindableProperty fontSizeProperty3 = Label.FontSizeProperty;
        FontSizeConverter fontSizeConverter3 = new FontSizeConverter();
        XamlServiceProvider xamlServiceProvider7 = new XamlServiceProvider();
        Type type13 = typeof (IProvideValueTarget);
        object[] objectAndParents7 = new object[0 + 7];
        objectAndParents7[0] = (object) label4;
        objectAndParents7[1] = (object) bindable4;
        objectAndParents7[2] = (object) bindable5;
        objectAndParents7[3] = (object) bindable7;
        objectAndParents7[4] = (object) bindable8;
        objectAndParents7[5] = (object) bindable13;
        objectAndParents7[6] = (object) bindable14;
        SimpleValueTargetProvider service13 = new SimpleValueTargetProvider(objectAndParents7, (object) Label.FontSizeProperty);
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
        namespaceResolver7.Add("stringToHex", "clr-namespace:one_sti_student_portal;assembly=one_sti_student_portal");
        namespaceResolver7.Add("ctrImage", "clr-namespace:ImageCircle.Forms.Plugin.Abstractions;assembly=ImageCircle.Forms.Plugin.Abstractions");
        XamlTypeResolver service14 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver7, typeof (MasterDetailPageMaster).GetTypeInfo().Assembly);
        xamlServiceProvider7.Add(type14, (object) service14);
        xamlServiceProvider7.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(51, 89)));
        object obj7 = ((IExtendedTypeConverter) fontSizeConverter3).ConvertFromInvariantString("13", (IServiceProvider) xamlServiceProvider7);
        label8.SetValue(fontSizeProperty3, obj7);
        label4.SetValue(Label.TextColorProperty, (object) new Color(0.400000005960464, 0.400000005960464, 0.400000005960464, 1.0));
        bindable4.Children.Add((View) label4);
        bindable3.SetValue(Label.TextProperty, (object) " • ");
        resourceExtension5.Key = "smallLabel";
        StaticResourceExtension resourceExtension12 = resourceExtension5;
        XamlServiceProvider xamlServiceProvider8 = new XamlServiceProvider();
        Type type15 = typeof (IProvideValueTarget);
        object[] objectAndParents8 = new object[0 + 7];
        objectAndParents8[0] = (object) bindable3;
        objectAndParents8[1] = (object) bindable4;
        objectAndParents8[2] = (object) bindable5;
        objectAndParents8[3] = (object) bindable7;
        objectAndParents8[4] = (object) bindable8;
        objectAndParents8[5] = (object) bindable13;
        objectAndParents8[6] = (object) bindable14;
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
        namespaceResolver8.Add("stringToHex", "clr-namespace:one_sti_student_portal;assembly=one_sti_student_portal");
        namespaceResolver8.Add("ctrImage", "clr-namespace:ImageCircle.Forms.Plugin.Abstractions;assembly=ImageCircle.Forms.Plugin.Abstractions");
        XamlTypeResolver service16 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver8, typeof (MasterDetailPageMaster).GetTypeInfo().Assembly);
        xamlServiceProvider8.Add(type16, (object) service16);
        xamlServiceProvider8.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(52, 47)));
        object obj8 = resourceExtension12.ProvideValue((IServiceProvider) xamlServiceProvider8);
        bindable3.Style = (Style) obj8;
        bindable3.SetValue(Label.TextColorProperty, (object) new Color(0.400000005960464, 0.400000005960464, 0.400000005960464, 1.0));
        bindable4.Children.Add((View) bindable3);
        resourceExtension6.Key = "smallLabel";
        StaticResourceExtension resourceExtension13 = resourceExtension6;
        XamlServiceProvider xamlServiceProvider9 = new XamlServiceProvider();
        Type type17 = typeof (IProvideValueTarget);
        object[] objectAndParents9 = new object[0 + 7];
        objectAndParents9[0] = (object) label5;
        objectAndParents9[1] = (object) bindable4;
        objectAndParents9[2] = (object) bindable5;
        objectAndParents9[3] = (object) bindable7;
        objectAndParents9[4] = (object) bindable8;
        objectAndParents9[5] = (object) bindable13;
        objectAndParents9[6] = (object) bindable14;
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
        namespaceResolver9.Add("stringToHex", "clr-namespace:one_sti_student_portal;assembly=one_sti_student_portal");
        namespaceResolver9.Add("ctrImage", "clr-namespace:ImageCircle.Forms.Plugin.Abstractions;assembly=ImageCircle.Forms.Plugin.Abstractions");
        XamlTypeResolver service18 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver9, typeof (MasterDetailPageMaster).GetTypeInfo().Assembly);
        xamlServiceProvider9.Add(type18, (object) service18);
        xamlServiceProvider9.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(53, 55)));
        object obj9 = resourceExtension13.ProvideValue((IServiceProvider) xamlServiceProvider9);
        label5.Style = (Style) obj9;
        Label label9 = label5;
        BindableProperty fontSizeProperty4 = Label.FontSizeProperty;
        FontSizeConverter fontSizeConverter4 = new FontSizeConverter();
        XamlServiceProvider xamlServiceProvider10 = new XamlServiceProvider();
        Type type19 = typeof (IProvideValueTarget);
        object[] objectAndParents10 = new object[0 + 7];
        objectAndParents10[0] = (object) label5;
        objectAndParents10[1] = (object) bindable4;
        objectAndParents10[2] = (object) bindable5;
        objectAndParents10[3] = (object) bindable7;
        objectAndParents10[4] = (object) bindable8;
        objectAndParents10[5] = (object) bindable13;
        objectAndParents10[6] = (object) bindable14;
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
        namespaceResolver10.Add("xlabs", "clr-namespace:XLabs.Forms.Controls;assembly=XLabs.Forms");
        namespaceResolver10.Add("stringToHex", "clr-namespace:one_sti_student_portal;assembly=one_sti_student_portal");
        namespaceResolver10.Add("ctrImage", "clr-namespace:ImageCircle.Forms.Plugin.Abstractions;assembly=ImageCircle.Forms.Plugin.Abstractions");
        XamlTypeResolver service20 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver10, typeof (MasterDetailPageMaster).GetTypeInfo().Assembly);
        xamlServiceProvider10.Add(type20, (object) service20);
        xamlServiceProvider10.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(53, 91)));
        object obj10 = ((IExtendedTypeConverter) fontSizeConverter4).ConvertFromInvariantString("13", (IServiceProvider) xamlServiceProvider10);
        label9.SetValue(fontSizeProperty4, obj10);
        label5.SetValue(Label.TextColorProperty, (object) new Color(0.400000005960464, 0.400000005960464, 0.400000005960464, 1.0));
        bindable4.Children.Add((View) label5);
        bindable5.Children.Add((View) bindable4);
        bindable7.Children.Add((View) bindable5);
        bindable6.SetValue(BoxView.ColorProperty, (object) new Color(0.905882358551025, 0.752941191196442, 0.113725490868092, 1.0));
        bindable6.SetValue(VisualElement.HeightRequestProperty, (object) 1.5);
        bindable6.SetValue(View.MarginProperty, (object) new Thickness(0.0, 5.0, 0.0, 0.0));
        bindable6.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.FillAndExpand);
        bindable7.Children.Add((View) bindable6);
        bindable8.Children.Add((View) bindable7);
        bindable13.Children.Add((View) bindable8);
        listView.SetValue(View.MarginProperty, (object) new Thickness(5.0));
        listView.SetValue(ListView.HasUnevenRowsProperty, (object) true);
        listView.SetValue(ListView.SeparatorVisibilityProperty, (object) SeparatorVisibility.None);
        listView.SetValue(VisualElement.BackgroundColorProperty, (object) new Color(1.0, 1.0, 1.0, 1.0));
        bindingExtension.Path = "MenuItems";
        BindingBase binding = ((IMarkupExtension<BindingBase>) bindingExtension).ProvideValue((IServiceProvider) null);
        listView.SetBinding(ItemsView<Cell>.ItemsSourceProperty, binding);
        DataTemplate dataTemplate2 = dataTemplate1;
        // ISSUE: object of a compiler-generated type is created
        // ISSUE: variable of a compiler-generated type
        MasterDetailPageMaster.\u003CInitializeComponent\u003E_anonXamlCDataTemplate_0 xamlCdataTemplate0 = new MasterDetailPageMaster.\u003CInitializeComponent\u003E_anonXamlCDataTemplate_0();
        object[] objArray = new object[0 + 4];
        objArray[0] = (object) dataTemplate1;
        objArray[1] = (object) listView;
        objArray[2] = (object) bindable13;
        objArray[3] = (object) bindable14;
        // ISSUE: reference to a compiler-generated field
        xamlCdataTemplate0.parentValues = objArray;
        // ISSUE: reference to a compiler-generated field
        xamlCdataTemplate0.root = bindable14;
        // ISSUE: reference to a compiler-generated method
        Func<object> func = new Func<object>(xamlCdataTemplate0.LoadDataTemplate);
        ((IDataTemplate) dataTemplate2).LoadTemplate = func;
        listView.SetValue(ItemsView<Cell>.ItemTemplateProperty, (object) dataTemplate1);
        bindable12.SetValue(View.VerticalOptionsProperty, (object) LayoutOptions.FillAndExpand);
        bindable12.SetValue(StackLayout.OrientationProperty, (object) StackOrientation.Horizontal);
        bindable12.SetValue(View.MarginProperty, (object) new Thickness(5.0));
        bindable12.SetValue(StackLayout.SpacingProperty, (object) 0.0);
        bindable9.Tapped += new EventHandler(bindable14.Logout_Tapped);
        bindable12.GestureRecognizers.Add((IGestureRecognizer) bindable9);
        bindable10.SetValue(Image.SourceProperty, new ImageSourceConverter().ConvertFromInvariantString("ic_logout"));
        bindable10.SetValue(View.VerticalOptionsProperty, (object) LayoutOptions.Center);
        bindable12.Children.Add((View) bindable10);
        bindable11.SetValue(Label.TextProperty, (object) "   Logout");
        bindable11.SetValue(View.VerticalOptionsProperty, (object) LayoutOptions.Center);
        resourceExtension7.Key = "smallHeader";
        StaticResourceExtension resourceExtension14 = resourceExtension7;
        XamlServiceProvider xamlServiceProvider11 = new XamlServiceProvider();
        Type type21 = typeof (IProvideValueTarget);
        object[] objectAndParents11 = new object[0 + 5];
        objectAndParents11[0] = (object) bindable11;
        objectAndParents11[1] = (object) bindable12;
        objectAndParents11[2] = (object) listView;
        objectAndParents11[3] = (object) bindable13;
        objectAndParents11[4] = (object) bindable14;
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
        namespaceResolver11.Add("stringToHex", "clr-namespace:one_sti_student_portal;assembly=one_sti_student_portal");
        namespaceResolver11.Add("ctrImage", "clr-namespace:ImageCircle.Forms.Plugin.Abstractions;assembly=ImageCircle.Forms.Plugin.Abstractions");
        XamlTypeResolver service22 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver11, typeof (MasterDetailPageMaster).GetTypeInfo().Assembly);
        xamlServiceProvider11.Add(type22, (object) service22);
        xamlServiceProvider11.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(99, 74)));
        object obj11 = resourceExtension14.ProvideValue((IServiceProvider) xamlServiceProvider11);
        bindable11.Style = (Style) obj11;
        bindable11.SetValue(Label.TextColorProperty, (object) new Color(0.250980406999588, 0.250980406999588, 0.250980406999588, 1.0));
        bindable12.Children.Add((View) bindable11);
        listView.SetValue(ListView.FooterProperty, (object) bindable12);
        bindable13.Children.Add((View) listView);
        bindable14.SetValue(ContentPage.ContentProperty, (object) bindable13);
      }
    }

    private void __InitComponentRuntime()
    {
      this.LoadFromXaml<MasterDetailPageMaster>(typeof (MasterDetailPageMaster));
      this.imgAvatar = NameScopeExtensions.FindByName<CircleImage>(this, "imgAvatar");
      this.lblMyProfile = NameScopeExtensions.FindByName<Label>(this, "lblMyProfile");
      this.lblStudentName = NameScopeExtensions.FindByName<Label>(this, "lblStudentName");
      this.lblStudentID = NameScopeExtensions.FindByName<Label>(this, "lblStudentID");
      this.lblCrse = NameScopeExtensions.FindByName<Label>(this, "lblCrse");
      this.lblCampus = NameScopeExtensions.FindByName<Label>(this, "lblCampus");
      this.MenuItemsListView = NameScopeExtensions.FindByName<ListView>(this, "MenuItemsListView");
    }

    public class MasterDetailPageMasterViewModel : INotifyPropertyChanged
    {
      private StudentData _studentData = new StudentData();

      public ObservableCollection<MasterDetailPageMenuItem> MenuItems { get; set; }

      public MasterDetailPageMasterViewModel()
      {
        ObservableCollection<MasterDetailPageMenuItem> observableCollection = new ObservableCollection<MasterDetailPageMenuItem>();
        observableCollection.Add(new MasterDetailPageMenuItem()
        {
          Header = false,
          RowColor = "#404040",
          Title = "   Home",
          IconSource = "ic_home",
          Enable = true,
          GoTo = true,
          ComingSoon = false,
          NewFeature = false,
          TargetType = typeof (WidgetHomePage)
        });
        observableCollection.Add(new MasterDetailPageMenuItem()
        {
          Header = true,
          RowColor = "#0B5793",
          Title = "  Information",
          IconSource = "",
          Enable = false,
          GoTo = false,
          ComingSoon = false,
          NewFeature = false,
          TargetType = (Type) null
        });
        observableCollection.Add(new MasterDetailPageMenuItem()
        {
          Header = false,
          RowColor = "#404040",
          Title = "   View Grades",
          IconSource = "ic_star",
          Enable = true,
          GoTo = true,
          ComingSoon = false,
          NewFeature = false,
          TargetType = typeof (StudentViewTabbedPage)
        });
        observableCollection.Add(new MasterDetailPageMenuItem()
        {
          Header = false,
          RowColor = "#404040",
          Title = "   View Class Schedule",
          IconSource = "ic_access_time",
          Enable = true,
          GoTo = true,
          ComingSoon = false,
          NewFeature = false,
          TargetType = typeof (StudentViewTabbedPage)
        });
        this.MenuItems = observableCollection;
        List<StudentInformation> result = this._studentData.GetStudentInformation().Result;
        if (result.Count != 0 && !result.FirstOrDefault<StudentInformation>().AcadLevel.Contains("G"))
          this.MenuItems.Add(new MasterDetailPageMenuItem()
          {
            Header = false,
            RowColor = "#404040",
            Title = "   Program Curriculum",
            IconSource = "ic_checklist",
            Enable = true,
            GoTo = true,
            ComingSoon = false,
            NewFeature = false,
            TargetType = typeof (StudentViewTabbedPage)
          });
        this.MenuItems.Add(new MasterDetailPageMenuItem()
        {
          Header = false,
          RowColor = "#404040",
          Title = "   Student Balance",
          IconSource = "ic_peso",
          Enable = true,
          GoTo = true,
          ComingSoon = false,
          NewFeature = false,
          TargetType = typeof (StudentViewTabbedPage)
        });
        this.MenuItems.Add(new MasterDetailPageMenuItem()
        {
          Header = true,
          RowColor = "#0B5793",
          Title = "  Others",
          IconSource = "",
          Enable = false,
          GoTo = false,
          ComingSoon = false,
          NewFeature = false,
          TargetType = (Type) null
        });
        this.MenuItems.Add(new MasterDetailPageMenuItem()
        {
          Header = false,
          RowColor = "#404040",
          Title = "  Alternative Payment Service",
          IconSource = "ic_payment",
          Enable = false,
          GoTo = true,
          ComingSoon = true,
          NewFeature = false,
          TargetType = (Type) null
        });
        this.MenuItems.Add(new MasterDetailPageMenuItem()
        {
          Header = false,
          RowColor = "#404040",
          Title = "   History, Mission & Vision",
          IconSource = "ic_values",
          Enable = true,
          GoTo = true,
          ComingSoon = false,
          NewFeature = false,
          TargetType = typeof (MissionVisionPage)
        });
        if (result.FirstOrDefault<StudentInformation>().Email == "cedric.gabrang@sti.edu")
          this.MenuItems.Add(new MasterDetailPageMenuItem()
          {
            Header = false,
            RowColor = "#404040",
            Title = "   Feedback",
            IconSource = "ic_feedback",
            Enable = true,
            GoTo = true,
            ComingSoon = false,
            NewFeature = false,
            TargetType = typeof (FeedbackAdmin)
          });
        else
          this.MenuItems.Add(new MasterDetailPageMenuItem()
          {
            Header = false,
            RowColor = "#404040",
            Title = "   Feedback",
            IconSource = "ic_feedback",
            Enable = true,
            GoTo = true,
            ComingSoon = false,
            NewFeature = false,
            TargetType = typeof (FeedbackPage)
          });
        this.MenuItems.Add(new MasterDetailPageMenuItem()
        {
          Header = false,
          RowColor = "#404040",
          Title = "   Rate Us!",
          IconSource = "ic_star_rate",
          Enable = true,
          GoTo = true,
          ComingSoon = false,
          NewFeature = false,
          TargetType = (Type) null
        });
        this.MenuItems.Add(new MasterDetailPageMenuItem()
        {
          Header = false,
          RowColor = "#404040",
          Title = "   About",
          IconSource = "ic_info",
          Enable = true,
          GoTo = true,
          ComingSoon = false,
          NewFeature = false,
          TargetType = typeof (AboutPage)
        });
        this.MenuItems.Add(new MasterDetailPageMenuItem()
        {
          Header = false,
          RowColor = "#404040",
          Title = "   FAQs",
          IconSource = "ic_faqs",
          Enable = true,
          GoTo = true,
          ComingSoon = false,
          NewFeature = false,
          TargetType = typeof (FAQsPage)
        });
      }

      public event PropertyChangedEventHandler PropertyChanged;

      private void OnPropertyChanged([CallerMemberName] string propertyName = "")
      {
        if (this.PropertyChanged == null)
          return;
        this.PropertyChanged((object) this, new PropertyChangedEventArgs(propertyName));
      }
    }
  }
}
