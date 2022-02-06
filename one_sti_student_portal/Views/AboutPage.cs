// Decompiled with JetBrains decompiler
// Type: one_sti_student_portal.Views.AboutPage
// Assembly: one_sti_student_portal, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 39E34984-485E-45CE-9895-F7524E3024D6
// Assembly location: \\wsl.localhost\kali-linux\root\One STI Student Portal_1.3.8_apkcombo.com (1)\unknown\assemblies\one_sti_student_portal.dll

using one_sti_student_portal.Views.Widgets;
using System;
using System.CodeDom.Compiler;
using System.Reflection;
using System.Xml;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.Xaml.Internals;

namespace one_sti_student_portal.Views
{
  [XamlCompilation(XamlCompilationOptions.Compile)]
  [XamlFilePath("Views\\AboutPage.xaml")]
  public class AboutPage : ContentPage
  {
    private bool blnShouldStay;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private Label lblVersionName;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private Label lblDateUpdated;

    public AboutPage()
    {
      this.InitializeComponent();
      this.lblVersionName.Text = Constants.VersionName;
      this.lblDateUpdated.Text = Constants.DateUpdated;
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
      if (ResourceLoader.ResourceProvider != null && ResourceLoader.ResourceProvider(typeof (AboutPage).GetTypeInfo().Assembly.GetName(), "Views/AboutPage.xaml") != null)
        this.__InitComponentRuntime();
      else if (Xamarin.Forms.Xaml.Internals.XamlLoader.XamlFileProvider != null && Xamarin.Forms.Xaml.Internals.XamlLoader.XamlFileProvider(this.GetType()) != null)
      {
        this.__InitComponentRuntime();
      }
      else
      {
        StaticResourceExtension resourceExtension1 = new StaticResourceExtension();
        Label bindable1 = new Label();
        Image bindable2 = new Image();
        StackLayout bindable3 = new StackLayout();
        StaticResourceExtension resourceExtension2 = new StaticResourceExtension();
        Label bindable4 = new Label();
        StackLayout bindable5 = new StackLayout();
        BoxView bindable6 = new BoxView();
        StaticResourceExtension resourceExtension3 = new StaticResourceExtension();
        Label bindable7 = new Label();
        StaticResourceExtension resourceExtension4 = new StaticResourceExtension();
        Label bindable8 = new Label();
        StaticResourceExtension resourceExtension5 = new StaticResourceExtension();
        Label bindable9 = new Label();
        StaticResourceExtension resourceExtension6 = new StaticResourceExtension();
        Label bindable10 = new Label();
        StaticResourceExtension resourceExtension7 = new StaticResourceExtension();
        Label bindable11 = new Label();
        StackLayout bindable12 = new StackLayout();
        StaticResourceExtension resourceExtension8 = new StaticResourceExtension();
        Label bindable13 = new Label();
        StaticResourceExtension resourceExtension9 = new StaticResourceExtension();
        Label bindable14 = new Label();
        StackLayout bindable15 = new StackLayout();
        StaticResourceExtension resourceExtension10 = new StaticResourceExtension();
        Label bindable16 = new Label();
        StaticResourceExtension resourceExtension11 = new StaticResourceExtension();
        Label bindable17 = new Label();
        StackLayout bindable18 = new StackLayout();
        StaticResourceExtension resourceExtension12 = new StaticResourceExtension();
        Label bindable19 = new Label();
        StaticResourceExtension resourceExtension13 = new StaticResourceExtension();
        Label bindable20 = new Label();
        StackLayout bindable21 = new StackLayout();
        StackLayout bindable22 = new StackLayout();
        BoxView bindable23 = new BoxView();
        StaticResourceExtension resourceExtension14 = new StaticResourceExtension();
        Label bindable24 = new Label();
        StaticResourceExtension resourceExtension15 = new StaticResourceExtension();
        Label bindable25 = new Label();
        StaticResourceExtension resourceExtension16 = new StaticResourceExtension();
        Label label1 = new Label();
        StackLayout bindable26 = new StackLayout();
        StaticResourceExtension resourceExtension17 = new StaticResourceExtension();
        Label bindable27 = new Label();
        StaticResourceExtension resourceExtension18 = new StaticResourceExtension();
        Label label2 = new Label();
        StackLayout bindable28 = new StackLayout();
        StaticResourceExtension resourceExtension19 = new StaticResourceExtension();
        Label bindable29 = new Label();
        StaticResourceExtension resourceExtension20 = new StaticResourceExtension();
        Label bindable30 = new Label();
        StackLayout bindable31 = new StackLayout();
        StaticResourceExtension resourceExtension21 = new StaticResourceExtension();
        Label bindable32 = new Label();
        StaticResourceExtension resourceExtension22 = new StaticResourceExtension();
        Label bindable33 = new Label();
        StackLayout bindable34 = new StackLayout();
        StackLayout bindable35 = new StackLayout();
        BoxView bindable36 = new BoxView();
        StaticResourceExtension resourceExtension23 = new StaticResourceExtension();
        Label bindable37 = new Label();
        StaticResourceExtension resourceExtension24 = new StaticResourceExtension();
        Label bindable38 = new Label();
        StaticResourceExtension resourceExtension25 = new StaticResourceExtension();
        Label bindable39 = new Label();
        StackLayout bindable40 = new StackLayout();
        StackLayout bindable41 = new StackLayout();
        ScrollView bindable42 = new ScrollView();
        StackLayout bindable43 = new StackLayout();
        AboutPage bindable44 = this;
        NameScope nameScope = new NameScope();
        NameScope.SetNameScope((BindableObject) bindable44, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable43, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable42, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable41, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable5, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable3, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable1, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable2, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable4, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable6, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable22, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable7, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable8, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable9, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable12, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable10, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable11, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable15, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable13, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable14, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable18, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable16, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable17, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable21, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable19, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable20, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable23, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable35, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable24, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable26, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable25, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) label1, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("lblVersionName", (object) label1);
        if (label1.StyleId == null)
          label1.StyleId = "lblVersionName";
        NameScope.SetNameScope((BindableObject) bindable28, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable27, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) label2, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("lblDateUpdated", (object) label2);
        if (label2.StyleId == null)
          label2.StyleId = "lblDateUpdated";
        NameScope.SetNameScope((BindableObject) bindable31, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable29, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable30, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable34, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable32, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable33, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable36, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable40, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable37, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable38, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable39, (INameScope) nameScope);
        this.lblVersionName = label1;
        this.lblDateUpdated = label2;
        bindable44.SetValue(Page.TitleProperty, (object) "About");
        bindable43.SetValue(View.VerticalOptionsProperty, (object) LayoutOptions.FillAndExpand);
        bindable42.SetValue(View.VerticalOptionsProperty, (object) LayoutOptions.FillAndExpand);
        bindable41.SetValue(View.MarginProperty, (object) new Thickness(5.0, 0.0, 5.0, 0.0));
        bindable41.SetValue(StackLayout.OrientationProperty, (object) StackOrientation.Vertical);
        bindable41.SetValue(View.VerticalOptionsProperty, (object) LayoutOptions.FillAndExpand);
        bindable5.SetValue(View.MarginProperty, (object) new Thickness(15.0));
        bindable3.SetValue(StackLayout.OrientationProperty, (object) StackOrientation.Horizontal);
        resourceExtension1.Key = "normalHeader";
        StaticResourceExtension resourceExtension26 = resourceExtension1;
        XamlServiceProvider xamlServiceProvider1 = new XamlServiceProvider();
        Type type1 = typeof (IProvideValueTarget);
        object[] objectAndParents1 = new object[0 + 7];
        objectAndParents1[0] = (object) bindable1;
        objectAndParents1[1] = (object) bindable3;
        objectAndParents1[2] = (object) bindable5;
        objectAndParents1[3] = (object) bindable41;
        objectAndParents1[4] = (object) bindable42;
        objectAndParents1[5] = (object) bindable43;
        objectAndParents1[6] = (object) bindable44;
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
        XamlTypeResolver service2 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver1, typeof (AboutPage).GetTypeInfo().Assembly);
        xamlServiceProvider1.Add(type2, (object) service2);
        xamlServiceProvider1.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(15, 36)));
        object obj1 = resourceExtension26.ProvideValue((IServiceProvider) xamlServiceProvider1);
        bindable1.Style = (Style) obj1;
        bindable1.SetValue(Label.TextColorProperty, (object) new Color(0.250980406999588, 0.250980406999588, 0.250980406999588, 1.0));
        bindable1.SetValue(Label.TextProperty, (object) "What's new");
        bindable1.SetValue(Label.HorizontalTextAlignmentProperty, new TextAlignmentConverter().ConvertFromInvariantString("Start"));
        bindable3.Children.Add((View) bindable1);
        bindable2.SetValue(Image.SourceProperty, new ImageSourceConverter().ConvertFromInvariantString("ic_new_releases"));
        bindable3.Children.Add((View) bindable2);
        bindable5.Children.Add((View) bindable3);
        bindable4.SetValue(Label.TextProperty, (object) "✓  Fixed bugs");
        resourceExtension2.Key = "smallLabel";
        StaticResourceExtension resourceExtension27 = resourceExtension2;
        XamlServiceProvider xamlServiceProvider2 = new XamlServiceProvider();
        Type type3 = typeof (IProvideValueTarget);
        object[] objectAndParents2 = new object[0 + 6];
        objectAndParents2[0] = (object) bindable4;
        objectAndParents2[1] = (object) bindable5;
        objectAndParents2[2] = (object) bindable41;
        objectAndParents2[3] = (object) bindable42;
        objectAndParents2[4] = (object) bindable43;
        objectAndParents2[5] = (object) bindable44;
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
        XamlTypeResolver service4 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver2, typeof (AboutPage).GetTypeInfo().Assembly);
        xamlServiceProvider2.Add(type4, (object) service4);
        xamlServiceProvider2.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(19, 53)));
        object obj2 = resourceExtension27.ProvideValue((IServiceProvider) xamlServiceProvider2);
        bindable4.Style = (Style) obj2;
        bindable4.SetValue(Label.TextColorProperty, (object) new Color(0.400000005960464, 0.400000005960464, 0.400000005960464, 1.0));
        bindable5.Children.Add((View) bindable4);
        bindable41.Children.Add((View) bindable5);
        bindable6.SetValue(BoxView.ColorProperty, (object) new Color(0.400000005960464, 0.400000005960464, 0.400000005960464, 1.0));
        bindable6.SetValue(VisualElement.HeightRequestProperty, (object) 0.5);
        bindable6.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.FillAndExpand);
        bindable41.Children.Add((View) bindable6);
        bindable22.SetValue(View.MarginProperty, (object) new Thickness(15.0));
        resourceExtension3.Key = "normalHeader";
        StaticResourceExtension resourceExtension28 = resourceExtension3;
        XamlServiceProvider xamlServiceProvider3 = new XamlServiceProvider();
        Type type5 = typeof (IProvideValueTarget);
        object[] objectAndParents3 = new object[0 + 6];
        objectAndParents3[0] = (object) bindable7;
        objectAndParents3[1] = (object) bindable22;
        objectAndParents3[2] = (object) bindable41;
        objectAndParents3[3] = (object) bindable42;
        objectAndParents3[4] = (object) bindable43;
        objectAndParents3[5] = (object) bindable44;
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
        XamlTypeResolver service6 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver3, typeof (AboutPage).GetTypeInfo().Assembly);
        xamlServiceProvider3.Add(type6, (object) service6);
        xamlServiceProvider3.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(27, 32)));
        object obj3 = resourceExtension28.ProvideValue((IServiceProvider) xamlServiceProvider3);
        bindable7.Style = (Style) obj3;
        bindable7.SetValue(Label.TextColorProperty, (object) new Color(0.250980406999588, 0.250980406999588, 0.250980406999588, 1.0));
        bindable7.SetValue(Label.TextProperty, (object) "Description");
        bindable22.Children.Add((View) bindable7);
        resourceExtension4.Key = "smallLabel";
        StaticResourceExtension resourceExtension29 = resourceExtension4;
        XamlServiceProvider xamlServiceProvider4 = new XamlServiceProvider();
        Type type7 = typeof (IProvideValueTarget);
        object[] objectAndParents4 = new object[0 + 6];
        objectAndParents4[0] = (object) bindable8;
        objectAndParents4[1] = (object) bindable22;
        objectAndParents4[2] = (object) bindable41;
        objectAndParents4[3] = (object) bindable42;
        objectAndParents4[4] = (object) bindable43;
        objectAndParents4[5] = (object) bindable44;
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
        XamlTypeResolver service8 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver4, typeof (AboutPage).GetTypeInfo().Assembly);
        xamlServiceProvider4.Add(type8, (object) service8);
        xamlServiceProvider4.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(29, 32)));
        object obj4 = resourceExtension29.ProvideValue((IServiceProvider) xamlServiceProvider4);
        bindable8.Style = (Style) obj4;
        bindable8.SetValue(Label.TextColorProperty, (object) new Color(0.400000005960464, 0.400000005960464, 0.400000005960464, 1.0));
        bindable8.SetValue(Label.TextProperty, (object) "Check your grades, tuition balance, and more in this app made for STI students.");
        bindable8.SetValue(Label.HorizontalTextAlignmentProperty, new TextAlignmentConverter().ConvertFromInvariantString("Start"));
        bindable22.Children.Add((View) bindable8);
        bindable9.SetValue(View.MarginProperty, (object) new Thickness(0.0, 20.0, 0.0, 20.0));
        resourceExtension5.Key = "smallLabel";
        StaticResourceExtension resourceExtension30 = resourceExtension5;
        XamlServiceProvider xamlServiceProvider5 = new XamlServiceProvider();
        Type type9 = typeof (IProvideValueTarget);
        object[] objectAndParents5 = new object[0 + 6];
        objectAndParents5[0] = (object) bindable9;
        objectAndParents5[1] = (object) bindable22;
        objectAndParents5[2] = (object) bindable41;
        objectAndParents5[3] = (object) bindable42;
        objectAndParents5[4] = (object) bindable43;
        objectAndParents5[5] = (object) bindable44;
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
        XamlTypeResolver service10 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver5, typeof (AboutPage).GetTypeInfo().Assembly);
        xamlServiceProvider5.Add(type10, (object) service10);
        xamlServiceProvider5.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(31, 51)));
        object obj5 = resourceExtension30.ProvideValue((IServiceProvider) xamlServiceProvider5);
        bindable9.Style = (Style) obj5;
        bindable9.SetValue(Label.TextColorProperty, (object) new Color(0.400000005960464, 0.400000005960464, 0.400000005960464, 1.0));
        bindable9.SetValue(Label.TextProperty, (object) "The One STI Student Portal keeps your necessary student information in this free and easy-to-use app. With the One STI Student Portal, you can now:");
        bindable9.SetValue(Label.HorizontalTextAlignmentProperty, new TextAlignmentConverter().ConvertFromInvariantString("Start"));
        bindable22.Children.Add((View) bindable9);
        bindable12.SetValue(StackLayout.OrientationProperty, (object) StackOrientation.Horizontal);
        resourceExtension6.Key = "smallLabel";
        StaticResourceExtension resourceExtension31 = resourceExtension6;
        XamlServiceProvider xamlServiceProvider6 = new XamlServiceProvider();
        Type type11 = typeof (IProvideValueTarget);
        object[] objectAndParents6 = new object[0 + 7];
        objectAndParents6[0] = (object) bindable10;
        objectAndParents6[1] = (object) bindable12;
        objectAndParents6[2] = (object) bindable22;
        objectAndParents6[3] = (object) bindable41;
        objectAndParents6[4] = (object) bindable42;
        objectAndParents6[5] = (object) bindable43;
        objectAndParents6[6] = (object) bindable44;
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
        XamlTypeResolver service12 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver6, typeof (AboutPage).GetTypeInfo().Assembly);
        xamlServiceProvider6.Add(type12, (object) service12);
        xamlServiceProvider6.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(34, 36)));
        object obj6 = resourceExtension31.ProvideValue((IServiceProvider) xamlServiceProvider6);
        bindable10.Style = (Style) obj6;
        bindable10.SetValue(Label.TextColorProperty, (object) new Color(0.400000005960464, 0.400000005960464, 0.400000005960464, 1.0));
        bindable10.SetValue(Label.TextProperty, (object) "✓ ");
        bindable10.SetValue(Label.HorizontalTextAlignmentProperty, new TextAlignmentConverter().ConvertFromInvariantString("Start"));
        bindable12.Children.Add((View) bindable10);
        resourceExtension7.Key = "smallLabel";
        StaticResourceExtension resourceExtension32 = resourceExtension7;
        XamlServiceProvider xamlServiceProvider7 = new XamlServiceProvider();
        Type type13 = typeof (IProvideValueTarget);
        object[] objectAndParents7 = new object[0 + 7];
        objectAndParents7[0] = (object) bindable11;
        objectAndParents7[1] = (object) bindable12;
        objectAndParents7[2] = (object) bindable22;
        objectAndParents7[3] = (object) bindable41;
        objectAndParents7[4] = (object) bindable42;
        objectAndParents7[5] = (object) bindable43;
        objectAndParents7[6] = (object) bindable44;
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
        XamlTypeResolver service14 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver7, typeof (AboutPage).GetTypeInfo().Assembly);
        xamlServiceProvider7.Add(type14, (object) service14);
        xamlServiceProvider7.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(35, 36)));
        object obj7 = resourceExtension32.ProvideValue((IServiceProvider) xamlServiceProvider7);
        bindable11.Style = (Style) obj7;
        bindable11.SetValue(Label.TextColorProperty, (object) new Color(0.400000005960464, 0.400000005960464, 0.400000005960464, 1.0));
        bindable11.SetValue(Label.TextProperty, (object) "View your grades with just a quick tap of a button");
        bindable11.SetValue(Label.HorizontalTextAlignmentProperty, new TextAlignmentConverter().ConvertFromInvariantString("Start"));
        bindable12.Children.Add((View) bindable11);
        bindable22.Children.Add((View) bindable12);
        bindable15.SetValue(StackLayout.OrientationProperty, (object) StackOrientation.Horizontal);
        resourceExtension8.Key = "smallLabel";
        StaticResourceExtension resourceExtension33 = resourceExtension8;
        XamlServiceProvider xamlServiceProvider8 = new XamlServiceProvider();
        Type type15 = typeof (IProvideValueTarget);
        object[] objectAndParents8 = new object[0 + 7];
        objectAndParents8[0] = (object) bindable13;
        objectAndParents8[1] = (object) bindable15;
        objectAndParents8[2] = (object) bindable22;
        objectAndParents8[3] = (object) bindable41;
        objectAndParents8[4] = (object) bindable42;
        objectAndParents8[5] = (object) bindable43;
        objectAndParents8[6] = (object) bindable44;
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
        XamlTypeResolver service16 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver8, typeof (AboutPage).GetTypeInfo().Assembly);
        xamlServiceProvider8.Add(type16, (object) service16);
        xamlServiceProvider8.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(39, 36)));
        object obj8 = resourceExtension33.ProvideValue((IServiceProvider) xamlServiceProvider8);
        bindable13.Style = (Style) obj8;
        bindable13.SetValue(Label.TextColorProperty, (object) new Color(0.400000005960464, 0.400000005960464, 0.400000005960464, 1.0));
        bindable13.SetValue(Label.TextProperty, (object) "✓ ");
        bindable13.SetValue(Label.HorizontalTextAlignmentProperty, new TextAlignmentConverter().ConvertFromInvariantString("Start"));
        bindable15.Children.Add((View) bindable13);
        resourceExtension9.Key = "smallLabel";
        StaticResourceExtension resourceExtension34 = resourceExtension9;
        XamlServiceProvider xamlServiceProvider9 = new XamlServiceProvider();
        Type type17 = typeof (IProvideValueTarget);
        object[] objectAndParents9 = new object[0 + 7];
        objectAndParents9[0] = (object) bindable14;
        objectAndParents9[1] = (object) bindable15;
        objectAndParents9[2] = (object) bindable22;
        objectAndParents9[3] = (object) bindable41;
        objectAndParents9[4] = (object) bindable42;
        objectAndParents9[5] = (object) bindable43;
        objectAndParents9[6] = (object) bindable44;
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
        XamlTypeResolver service18 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver9, typeof (AboutPage).GetTypeInfo().Assembly);
        xamlServiceProvider9.Add(type18, (object) service18);
        xamlServiceProvider9.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(40, 36)));
        object obj9 = resourceExtension34.ProvideValue((IServiceProvider) xamlServiceProvider9);
        bindable14.Style = (Style) obj9;
        bindable14.SetValue(Label.TextColorProperty, (object) new Color(0.400000005960464, 0.400000005960464, 0.400000005960464, 1.0));
        bindable14.SetValue(Label.TextProperty, (object) "Know your day-to-day class schedule complete with the classroom details and professors");
        bindable14.SetValue(Label.HorizontalTextAlignmentProperty, new TextAlignmentConverter().ConvertFromInvariantString("Start"));
        bindable15.Children.Add((View) bindable14);
        bindable22.Children.Add((View) bindable15);
        bindable18.SetValue(StackLayout.OrientationProperty, (object) StackOrientation.Horizontal);
        resourceExtension10.Key = "smallLabel";
        StaticResourceExtension resourceExtension35 = resourceExtension10;
        XamlServiceProvider xamlServiceProvider10 = new XamlServiceProvider();
        Type type19 = typeof (IProvideValueTarget);
        object[] objectAndParents10 = new object[0 + 7];
        objectAndParents10[0] = (object) bindable16;
        objectAndParents10[1] = (object) bindable18;
        objectAndParents10[2] = (object) bindable22;
        objectAndParents10[3] = (object) bindable41;
        objectAndParents10[4] = (object) bindable42;
        objectAndParents10[5] = (object) bindable43;
        objectAndParents10[6] = (object) bindable44;
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
        XamlTypeResolver service20 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver10, typeof (AboutPage).GetTypeInfo().Assembly);
        xamlServiceProvider10.Add(type20, (object) service20);
        xamlServiceProvider10.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(44, 36)));
        object obj10 = resourceExtension35.ProvideValue((IServiceProvider) xamlServiceProvider10);
        bindable16.Style = (Style) obj10;
        bindable16.SetValue(Label.TextColorProperty, (object) new Color(0.400000005960464, 0.400000005960464, 0.400000005960464, 1.0));
        bindable16.SetValue(Label.TextProperty, (object) "✓ ");
        bindable16.SetValue(Label.HorizontalTextAlignmentProperty, new TextAlignmentConverter().ConvertFromInvariantString("Start"));
        bindable18.Children.Add((View) bindable16);
        resourceExtension11.Key = "smallLabel";
        StaticResourceExtension resourceExtension36 = resourceExtension11;
        XamlServiceProvider xamlServiceProvider11 = new XamlServiceProvider();
        Type type21 = typeof (IProvideValueTarget);
        object[] objectAndParents11 = new object[0 + 7];
        objectAndParents11[0] = (object) bindable17;
        objectAndParents11[1] = (object) bindable18;
        objectAndParents11[2] = (object) bindable22;
        objectAndParents11[3] = (object) bindable41;
        objectAndParents11[4] = (object) bindable42;
        objectAndParents11[5] = (object) bindable43;
        objectAndParents11[6] = (object) bindable44;
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
        XamlTypeResolver service22 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver11, typeof (AboutPage).GetTypeInfo().Assembly);
        xamlServiceProvider11.Add(type22, (object) service22);
        xamlServiceProvider11.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(45, 36)));
        object obj11 = resourceExtension36.ProvideValue((IServiceProvider) xamlServiceProvider11);
        bindable17.Style = (Style) obj11;
        bindable17.SetValue(Label.TextColorProperty, (object) new Color(0.400000005960464, 0.400000005960464, 0.400000005960464, 1.0));
        bindable17.SetValue(Label.TextProperty, (object) "Keep track of your tuition balances");
        bindable17.SetValue(Label.HorizontalTextAlignmentProperty, new TextAlignmentConverter().ConvertFromInvariantString("Start"));
        bindable18.Children.Add((View) bindable17);
        bindable22.Children.Add((View) bindable18);
        bindable21.SetValue(StackLayout.OrientationProperty, (object) StackOrientation.Horizontal);
        resourceExtension12.Key = "smallLabel";
        StaticResourceExtension resourceExtension37 = resourceExtension12;
        XamlServiceProvider xamlServiceProvider12 = new XamlServiceProvider();
        Type type23 = typeof (IProvideValueTarget);
        object[] objectAndParents12 = new object[0 + 7];
        objectAndParents12[0] = (object) bindable19;
        objectAndParents12[1] = (object) bindable21;
        objectAndParents12[2] = (object) bindable22;
        objectAndParents12[3] = (object) bindable41;
        objectAndParents12[4] = (object) bindable42;
        objectAndParents12[5] = (object) bindable43;
        objectAndParents12[6] = (object) bindable44;
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
        XamlTypeResolver service24 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver12, typeof (AboutPage).GetTypeInfo().Assembly);
        xamlServiceProvider12.Add(type24, (object) service24);
        xamlServiceProvider12.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(49, 36)));
        object obj12 = resourceExtension37.ProvideValue((IServiceProvider) xamlServiceProvider12);
        bindable19.Style = (Style) obj12;
        bindable19.SetValue(Label.TextColorProperty, (object) new Color(0.400000005960464, 0.400000005960464, 0.400000005960464, 1.0));
        bindable19.SetValue(Label.TextProperty, (object) "✓ ");
        bindable19.SetValue(Label.HorizontalTextAlignmentProperty, new TextAlignmentConverter().ConvertFromInvariantString("Start"));
        bindable21.Children.Add((View) bindable19);
        resourceExtension13.Key = "smallLabel";
        StaticResourceExtension resourceExtension38 = resourceExtension13;
        XamlServiceProvider xamlServiceProvider13 = new XamlServiceProvider();
        Type type25 = typeof (IProvideValueTarget);
        object[] objectAndParents13 = new object[0 + 7];
        objectAndParents13[0] = (object) bindable20;
        objectAndParents13[1] = (object) bindable21;
        objectAndParents13[2] = (object) bindable22;
        objectAndParents13[3] = (object) bindable41;
        objectAndParents13[4] = (object) bindable42;
        objectAndParents13[5] = (object) bindable43;
        objectAndParents13[6] = (object) bindable44;
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
        XamlTypeResolver service26 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver13, typeof (AboutPage).GetTypeInfo().Assembly);
        xamlServiceProvider13.Add(type26, (object) service26);
        xamlServiceProvider13.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(50, 36)));
        object obj13 = resourceExtension38.ProvideValue((IServiceProvider) xamlServiceProvider13);
        bindable20.Style = (Style) obj13;
        bindable20.SetValue(Label.TextColorProperty, (object) new Color(0.400000005960464, 0.400000005960464, 0.400000005960464, 1.0));
        bindable20.SetValue(Label.TextProperty, (object) "Get the latest STI news from all over the STI network");
        bindable20.SetValue(Label.HorizontalTextAlignmentProperty, new TextAlignmentConverter().ConvertFromInvariantString("Start"));
        bindable21.Children.Add((View) bindable20);
        bindable22.Children.Add((View) bindable21);
        bindable41.Children.Add((View) bindable22);
        bindable23.SetValue(BoxView.ColorProperty, (object) new Color(0.400000005960464, 0.400000005960464, 0.400000005960464, 1.0));
        bindable23.SetValue(VisualElement.HeightRequestProperty, (object) 0.5);
        bindable23.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.FillAndExpand);
        bindable41.Children.Add((View) bindable23);
        bindable35.SetValue(View.MarginProperty, (object) new Thickness(15.0));
        resourceExtension14.Key = "normalHeader";
        StaticResourceExtension resourceExtension39 = resourceExtension14;
        XamlServiceProvider xamlServiceProvider14 = new XamlServiceProvider();
        Type type27 = typeof (IProvideValueTarget);
        object[] objectAndParents14 = new object[0 + 6];
        objectAndParents14[0] = (object) bindable24;
        objectAndParents14[1] = (object) bindable35;
        objectAndParents14[2] = (object) bindable41;
        objectAndParents14[3] = (object) bindable42;
        objectAndParents14[4] = (object) bindable43;
        objectAndParents14[5] = (object) bindable44;
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
        XamlTypeResolver service28 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver14, typeof (AboutPage).GetTypeInfo().Assembly);
        xamlServiceProvider14.Add(type28, (object) service28);
        xamlServiceProvider14.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(60, 32)));
        object obj14 = resourceExtension39.ProvideValue((IServiceProvider) xamlServiceProvider14);
        bindable24.Style = (Style) obj14;
        bindable24.SetValue(Label.TextColorProperty, (object) new Color(0.250980406999588, 0.250980406999588, 0.250980406999588, 1.0));
        bindable24.SetValue(Label.TextProperty, (object) "App info");
        bindable35.Children.Add((View) bindable24);
        bindable26.SetValue(StackLayout.OrientationProperty, (object) StackOrientation.Horizontal);
        bindable26.SetValue(View.MarginProperty, (object) new Thickness(0.0, 15.0, 0.0, 15.0));
        resourceExtension15.Key = "smallLabel";
        StaticResourceExtension resourceExtension40 = resourceExtension15;
        XamlServiceProvider xamlServiceProvider15 = new XamlServiceProvider();
        Type type29 = typeof (IProvideValueTarget);
        object[] objectAndParents15 = new object[0 + 7];
        objectAndParents15[0] = (object) bindable25;
        objectAndParents15[1] = (object) bindable26;
        objectAndParents15[2] = (object) bindable35;
        objectAndParents15[3] = (object) bindable41;
        objectAndParents15[4] = (object) bindable42;
        objectAndParents15[5] = (object) bindable43;
        objectAndParents15[6] = (object) bindable44;
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
        XamlTypeResolver service30 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver15, typeof (AboutPage).GetTypeInfo().Assembly);
        xamlServiceProvider15.Add(type30, (object) service30);
        xamlServiceProvider15.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(63, 36)));
        object obj15 = resourceExtension40.ProvideValue((IServiceProvider) xamlServiceProvider15);
        bindable25.Style = (Style) obj15;
        bindable25.SetValue(Label.TextColorProperty, (object) new Color(0.400000005960464, 0.400000005960464, 0.400000005960464, 1.0));
        bindable25.SetValue(Label.TextProperty, (object) "Version");
        bindable25.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.StartAndExpand);
        bindable26.Children.Add((View) bindable25);
        resourceExtension16.Key = "smallLabel";
        StaticResourceExtension resourceExtension41 = resourceExtension16;
        XamlServiceProvider xamlServiceProvider16 = new XamlServiceProvider();
        Type type31 = typeof (IProvideValueTarget);
        object[] objectAndParents16 = new object[0 + 7];
        objectAndParents16[0] = (object) label1;
        objectAndParents16[1] = (object) bindable26;
        objectAndParents16[2] = (object) bindable35;
        objectAndParents16[3] = (object) bindable41;
        objectAndParents16[4] = (object) bindable42;
        objectAndParents16[5] = (object) bindable43;
        objectAndParents16[6] = (object) bindable44;
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
        XamlTypeResolver service32 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver16, typeof (AboutPage).GetTypeInfo().Assembly);
        xamlServiceProvider16.Add(type32, (object) service32);
        xamlServiceProvider16.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(64, 60)));
        object obj16 = resourceExtension41.ProvideValue((IServiceProvider) xamlServiceProvider16);
        label1.Style = (Style) obj16;
        label1.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.End);
        bindable26.Children.Add((View) label1);
        bindable35.Children.Add((View) bindable26);
        bindable28.SetValue(StackLayout.OrientationProperty, (object) StackOrientation.Horizontal);
        bindable28.SetValue(View.MarginProperty, (object) new Thickness(0.0, 15.0, 0.0, 15.0));
        resourceExtension17.Key = "smallLabel";
        StaticResourceExtension resourceExtension42 = resourceExtension17;
        XamlServiceProvider xamlServiceProvider17 = new XamlServiceProvider();
        Type type33 = typeof (IProvideValueTarget);
        object[] objectAndParents17 = new object[0 + 7];
        objectAndParents17[0] = (object) bindable27;
        objectAndParents17[1] = (object) bindable28;
        objectAndParents17[2] = (object) bindable35;
        objectAndParents17[3] = (object) bindable41;
        objectAndParents17[4] = (object) bindable42;
        objectAndParents17[5] = (object) bindable43;
        objectAndParents17[6] = (object) bindable44;
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
        XamlTypeResolver service34 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver17, typeof (AboutPage).GetTypeInfo().Assembly);
        xamlServiceProvider17.Add(type34, (object) service34);
        xamlServiceProvider17.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(68, 36)));
        object obj17 = resourceExtension42.ProvideValue((IServiceProvider) xamlServiceProvider17);
        bindable27.Style = (Style) obj17;
        bindable27.SetValue(Label.TextColorProperty, (object) new Color(0.400000005960464, 0.400000005960464, 0.400000005960464, 1.0));
        bindable27.SetValue(Label.TextProperty, (object) "Updated on");
        bindable27.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.StartAndExpand);
        bindable28.Children.Add((View) bindable27);
        resourceExtension18.Key = "smallLabel";
        StaticResourceExtension resourceExtension43 = resourceExtension18;
        XamlServiceProvider xamlServiceProvider18 = new XamlServiceProvider();
        Type type35 = typeof (IProvideValueTarget);
        object[] objectAndParents18 = new object[0 + 7];
        objectAndParents18[0] = (object) label2;
        objectAndParents18[1] = (object) bindable28;
        objectAndParents18[2] = (object) bindable35;
        objectAndParents18[3] = (object) bindable41;
        objectAndParents18[4] = (object) bindable42;
        objectAndParents18[5] = (object) bindable43;
        objectAndParents18[6] = (object) bindable44;
        SimpleValueTargetProvider service35 = new SimpleValueTargetProvider(objectAndParents18, (object) VisualElement.StyleProperty);
        xamlServiceProvider18.Add(type35, (object) service35);
        xamlServiceProvider18.Add(typeof (INameScopeProvider), (object) new NameScopeProvider()
        {
          NameScope = (INameScope) nameScope
        });
        Type type36 = typeof (IXamlTypeResolver);
        XmlNamespaceResolver namespaceResolver18 = new XmlNamespaceResolver();
        namespaceResolver18.Add("", "http://xamarin.com/schemas/2014/forms");
        namespaceResolver18.Add("x", "http://schemas.microsoft.com/winfx/2009/xaml");
        XamlTypeResolver service36 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver18, typeof (AboutPage).GetTypeInfo().Assembly);
        xamlServiceProvider18.Add(type36, (object) service36);
        xamlServiceProvider18.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(69, 60)));
        object obj18 = resourceExtension43.ProvideValue((IServiceProvider) xamlServiceProvider18);
        label2.Style = (Style) obj18;
        label2.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.End);
        bindable28.Children.Add((View) label2);
        bindable35.Children.Add((View) bindable28);
        bindable31.SetValue(StackLayout.OrientationProperty, (object) StackOrientation.Horizontal);
        bindable31.SetValue(View.MarginProperty, (object) new Thickness(0.0, 15.0, 0.0, 15.0));
        resourceExtension19.Key = "smallLabel";
        StaticResourceExtension resourceExtension44 = resourceExtension19;
        XamlServiceProvider xamlServiceProvider19 = new XamlServiceProvider();
        Type type37 = typeof (IProvideValueTarget);
        object[] objectAndParents19 = new object[0 + 7];
        objectAndParents19[0] = (object) bindable29;
        objectAndParents19[1] = (object) bindable31;
        objectAndParents19[2] = (object) bindable35;
        objectAndParents19[3] = (object) bindable41;
        objectAndParents19[4] = (object) bindable42;
        objectAndParents19[5] = (object) bindable43;
        objectAndParents19[6] = (object) bindable44;
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
        XamlTypeResolver service38 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver19, typeof (AboutPage).GetTypeInfo().Assembly);
        xamlServiceProvider19.Add(type38, (object) service38);
        xamlServiceProvider19.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(73, 36)));
        object obj19 = resourceExtension44.ProvideValue((IServiceProvider) xamlServiceProvider19);
        bindable29.Style = (Style) obj19;
        bindable29.SetValue(Label.TextColorProperty, (object) new Color(0.400000005960464, 0.400000005960464, 0.400000005960464, 1.0));
        bindable29.SetValue(Label.TextProperty, (object) "Offered by");
        bindable29.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.StartAndExpand);
        bindable31.Children.Add((View) bindable29);
        resourceExtension20.Key = "smallLabel";
        StaticResourceExtension resourceExtension45 = resourceExtension20;
        XamlServiceProvider xamlServiceProvider20 = new XamlServiceProvider();
        Type type39 = typeof (IProvideValueTarget);
        object[] objectAndParents20 = new object[0 + 7];
        objectAndParents20[0] = (object) bindable30;
        objectAndParents20[1] = (object) bindable31;
        objectAndParents20[2] = (object) bindable35;
        objectAndParents20[3] = (object) bindable41;
        objectAndParents20[4] = (object) bindable42;
        objectAndParents20[5] = (object) bindable43;
        objectAndParents20[6] = (object) bindable44;
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
        XamlTypeResolver service40 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver20, typeof (AboutPage).GetTypeInfo().Assembly);
        xamlServiceProvider20.Add(type40, (object) service40);
        xamlServiceProvider20.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(74, 36)));
        object obj20 = resourceExtension45.ProvideValue((IServiceProvider) xamlServiceProvider20);
        bindable30.Style = (Style) obj20;
        bindable30.SetValue(Label.TextProperty, (object) "STI College");
        bindable30.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.End);
        bindable31.Children.Add((View) bindable30);
        bindable35.Children.Add((View) bindable31);
        bindable34.SetValue(StackLayout.OrientationProperty, (object) StackOrientation.Horizontal);
        bindable34.SetValue(View.MarginProperty, (object) new Thickness(0.0, 15.0, 0.0, 15.0));
        resourceExtension21.Key = "smallLabel";
        StaticResourceExtension resourceExtension46 = resourceExtension21;
        XamlServiceProvider xamlServiceProvider21 = new XamlServiceProvider();
        Type type41 = typeof (IProvideValueTarget);
        object[] objectAndParents21 = new object[0 + 7];
        objectAndParents21[0] = (object) bindable32;
        objectAndParents21[1] = (object) bindable34;
        objectAndParents21[2] = (object) bindable35;
        objectAndParents21[3] = (object) bindable41;
        objectAndParents21[4] = (object) bindable42;
        objectAndParents21[5] = (object) bindable43;
        objectAndParents21[6] = (object) bindable44;
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
        XamlTypeResolver service42 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver21, typeof (AboutPage).GetTypeInfo().Assembly);
        xamlServiceProvider21.Add(type42, (object) service42);
        xamlServiceProvider21.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(78, 36)));
        object obj21 = resourceExtension46.ProvideValue((IServiceProvider) xamlServiceProvider21);
        bindable32.Style = (Style) obj21;
        bindable32.SetValue(Label.TextColorProperty, (object) new Color(0.400000005960464, 0.400000005960464, 0.400000005960464, 1.0));
        bindable32.SetValue(Label.TextProperty, (object) "Developed by");
        bindable32.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.StartAndExpand);
        bindable34.Children.Add((View) bindable32);
        resourceExtension22.Key = "smallLabel";
        StaticResourceExtension resourceExtension47 = resourceExtension22;
        XamlServiceProvider xamlServiceProvider22 = new XamlServiceProvider();
        Type type43 = typeof (IProvideValueTarget);
        object[] objectAndParents22 = new object[0 + 7];
        objectAndParents22[0] = (object) bindable33;
        objectAndParents22[1] = (object) bindable34;
        objectAndParents22[2] = (object) bindable35;
        objectAndParents22[3] = (object) bindable41;
        objectAndParents22[4] = (object) bindable42;
        objectAndParents22[5] = (object) bindable43;
        objectAndParents22[6] = (object) bindable44;
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
        XamlTypeResolver service44 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver22, typeof (AboutPage).GetTypeInfo().Assembly);
        xamlServiceProvider22.Add(type44, (object) service44);
        xamlServiceProvider22.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(79, 36)));
        object obj22 = resourceExtension47.ProvideValue((IServiceProvider) xamlServiceProvider22);
        bindable33.Style = (Style) obj22;
        bindable33.SetValue(Label.TextProperty, (object) "Cedric Gabrang");
        bindable33.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.End);
        bindable34.Children.Add((View) bindable33);
        bindable35.Children.Add((View) bindable34);
        bindable41.Children.Add((View) bindable35);
        bindable36.SetValue(BoxView.ColorProperty, (object) new Color(0.400000005960464, 0.400000005960464, 0.400000005960464, 1.0));
        bindable36.SetValue(VisualElement.HeightRequestProperty, (object) 0.5);
        bindable36.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.FillAndExpand);
        bindable41.Children.Add((View) bindable36);
        bindable40.SetValue(View.MarginProperty, (object) new Thickness(15.0));
        resourceExtension23.Key = "normalHeader";
        StaticResourceExtension resourceExtension48 = resourceExtension23;
        XamlServiceProvider xamlServiceProvider23 = new XamlServiceProvider();
        Type type45 = typeof (IProvideValueTarget);
        object[] objectAndParents23 = new object[0 + 6];
        objectAndParents23[0] = (object) bindable37;
        objectAndParents23[1] = (object) bindable40;
        objectAndParents23[2] = (object) bindable41;
        objectAndParents23[3] = (object) bindable42;
        objectAndParents23[4] = (object) bindable43;
        objectAndParents23[5] = (object) bindable44;
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
        XamlTypeResolver service46 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver23, typeof (AboutPage).GetTypeInfo().Assembly);
        xamlServiceProvider23.Add(type46, (object) service46);
        xamlServiceProvider23.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(89, 32)));
        object obj23 = resourceExtension48.ProvideValue((IServiceProvider) xamlServiceProvider23);
        bindable37.Style = (Style) obj23;
        bindable37.SetValue(Label.TextColorProperty, (object) new Color(0.250980406999588, 0.250980406999588, 0.250980406999588, 1.0));
        bindable37.SetValue(Label.TextProperty, (object) "Disclaimer");
        bindable40.Children.Add((View) bindable37);
        resourceExtension24.Key = "microLabel";
        StaticResourceExtension resourceExtension49 = resourceExtension24;
        XamlServiceProvider xamlServiceProvider24 = new XamlServiceProvider();
        Type type47 = typeof (IProvideValueTarget);
        object[] objectAndParents24 = new object[0 + 6];
        objectAndParents24[0] = (object) bindable38;
        objectAndParents24[1] = (object) bindable40;
        objectAndParents24[2] = (object) bindable41;
        objectAndParents24[3] = (object) bindable42;
        objectAndParents24[4] = (object) bindable43;
        objectAndParents24[5] = (object) bindable44;
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
        XamlTypeResolver service48 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver24, typeof (AboutPage).GetTypeInfo().Assembly);
        xamlServiceProvider24.Add(type48, (object) service48);
        xamlServiceProvider24.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(91, 32)));
        object obj24 = resourceExtension49.ProvideValue((IServiceProvider) xamlServiceProvider24);
        bindable38.Style = (Style) obj24;
        bindable38.SetValue(Label.TextColorProperty, (object) new Color(0.400000005960464, 0.400000005960464, 0.400000005960464, 1.0));
        Label label3 = bindable38;
        BindableProperty fontSizeProperty1 = Label.FontSizeProperty;
        FontSizeConverter fontSizeConverter1 = new FontSizeConverter();
        XamlServiceProvider xamlServiceProvider25 = new XamlServiceProvider();
        Type type49 = typeof (IProvideValueTarget);
        object[] objectAndParents25 = new object[0 + 6];
        objectAndParents25[0] = (object) bindable38;
        objectAndParents25[1] = (object) bindable40;
        objectAndParents25[2] = (object) bindable41;
        objectAndParents25[3] = (object) bindable42;
        objectAndParents25[4] = (object) bindable43;
        objectAndParents25[5] = (object) bindable44;
        SimpleValueTargetProvider service49 = new SimpleValueTargetProvider(objectAndParents25, (object) Label.FontSizeProperty);
        xamlServiceProvider25.Add(type49, (object) service49);
        xamlServiceProvider25.Add(typeof (INameScopeProvider), (object) new NameScopeProvider()
        {
          NameScope = (INameScope) nameScope
        });
        Type type50 = typeof (IXamlTypeResolver);
        XmlNamespaceResolver namespaceResolver25 = new XmlNamespaceResolver();
        namespaceResolver25.Add("", "http://xamarin.com/schemas/2014/forms");
        namespaceResolver25.Add("x", "http://schemas.microsoft.com/winfx/2009/xaml");
        XamlTypeResolver service50 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver25, typeof (AboutPage).GetTypeInfo().Assembly);
        xamlServiceProvider25.Add(type50, (object) service50);
        xamlServiceProvider25.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(91, 88)));
        object obj25 = ((IExtendedTypeConverter) fontSizeConverter1).ConvertFromInvariantString("11", (IServiceProvider) xamlServiceProvider25);
        label3.SetValue(fontSizeProperty1, obj25);
        bindable38.SetValue(Label.TextProperty, (object) "The information contained herein is not on real-time and for information purposes only. The information may not be up to date and requires further validation from the School Registrar.");
        bindable40.Children.Add((View) bindable38);
        bindable39.SetValue(View.MarginProperty, (object) new Thickness(0.0, 10.0, 0.0, 0.0));
        resourceExtension25.Key = "microLabel";
        StaticResourceExtension resourceExtension50 = resourceExtension25;
        XamlServiceProvider xamlServiceProvider26 = new XamlServiceProvider();
        Type type51 = typeof (IProvideValueTarget);
        object[] objectAndParents26 = new object[0 + 6];
        objectAndParents26[0] = (object) bindable39;
        objectAndParents26[1] = (object) bindable40;
        objectAndParents26[2] = (object) bindable41;
        objectAndParents26[3] = (object) bindable42;
        objectAndParents26[4] = (object) bindable43;
        objectAndParents26[5] = (object) bindable44;
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
        XamlTypeResolver service52 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver26, typeof (AboutPage).GetTypeInfo().Assembly);
        xamlServiceProvider26.Add(type52, (object) service52);
        xamlServiceProvider26.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(93, 50)));
        object obj26 = resourceExtension50.ProvideValue((IServiceProvider) xamlServiceProvider26);
        bindable39.Style = (Style) obj26;
        Label label4 = bindable39;
        BindableProperty fontSizeProperty2 = Label.FontSizeProperty;
        FontSizeConverter fontSizeConverter2 = new FontSizeConverter();
        XamlServiceProvider xamlServiceProvider27 = new XamlServiceProvider();
        Type type53 = typeof (IProvideValueTarget);
        object[] objectAndParents27 = new object[0 + 6];
        objectAndParents27[0] = (object) bindable39;
        objectAndParents27[1] = (object) bindable40;
        objectAndParents27[2] = (object) bindable41;
        objectAndParents27[3] = (object) bindable42;
        objectAndParents27[4] = (object) bindable43;
        objectAndParents27[5] = (object) bindable44;
        SimpleValueTargetProvider service53 = new SimpleValueTargetProvider(objectAndParents27, (object) Label.FontSizeProperty);
        xamlServiceProvider27.Add(type53, (object) service53);
        xamlServiceProvider27.Add(typeof (INameScopeProvider), (object) new NameScopeProvider()
        {
          NameScope = (INameScope) nameScope
        });
        Type type54 = typeof (IXamlTypeResolver);
        XmlNamespaceResolver namespaceResolver27 = new XmlNamespaceResolver();
        namespaceResolver27.Add("", "http://xamarin.com/schemas/2014/forms");
        namespaceResolver27.Add("x", "http://schemas.microsoft.com/winfx/2009/xaml");
        XamlTypeResolver service54 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver27, typeof (AboutPage).GetTypeInfo().Assembly);
        xamlServiceProvider27.Add(type54, (object) service54);
        xamlServiceProvider27.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(93, 86)));
        object obj27 = ((IExtendedTypeConverter) fontSizeConverter2).ConvertFromInvariantString("11", (IServiceProvider) xamlServiceProvider27);
        label4.SetValue(fontSizeProperty2, obj27);
        bindable39.SetValue(Label.TextColorProperty, (object) new Color(0.400000005960464, 0.400000005960464, 0.400000005960464, 1.0));
        bindable39.SetValue(Label.TextProperty, (object) "If you have further questions, please do not hesitate to get in touch with the School Registrar.");
        bindable40.Children.Add((View) bindable39);
        bindable41.Children.Add((View) bindable40);
        bindable42.Content = (View) bindable41;
        bindable43.Children.Add((View) bindable42);
        bindable44.SetValue(ContentPage.ContentProperty, (object) bindable43);
      }
    }

    private void __InitComponentRuntime()
    {
      this.LoadFromXaml<AboutPage>(typeof (AboutPage));
      this.lblVersionName = NameScopeExtensions.FindByName<Label>(this, "lblVersionName");
      this.lblDateUpdated = NameScopeExtensions.FindByName<Label>(this, "lblDateUpdated");
    }
  }
}
