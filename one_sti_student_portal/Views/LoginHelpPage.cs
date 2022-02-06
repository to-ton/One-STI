// Decompiled with JetBrains decompiler
// Type: one_sti_student_portal.Views.LoginHelpPage
// Assembly: one_sti_student_portal, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 39E34984-485E-45CE-9895-F7524E3024D6
// Assembly location: \\wsl.localhost\kali-linux\root\One STI Student Portal_1.3.8_apkcombo.com (1)\unknown\assemblies\one_sti_student_portal.dll

using System;
using System.CodeDom.Compiler;
using System.Reflection;
using System.Xml;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.Xaml.Internals;
using XLabs.Forms.Controls;

namespace one_sti_student_portal.Views
{
  [XamlFilePath("Views\\LoginHelpPage.xaml")]
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public class LoginHelpPage : ContentPage
  {
    public LoginHelpPage() => this.InitializeComponent();

    private void OpenEmail(object sender, EventArgs e) => Device.OpenUri(new Uri("mailto:oneapp@sti.edu?subject=Unable to retrieve my Microsoft O365 account&body=Student ID: " + Environment.NewLine + "Complete Student Name: " + Environment.NewLine + "Campus: " + Environment.NewLine + "Birthday: "));

    private void TapGestureRecognizer_Tapped(object sender, EventArgs e) => Device.OpenUri(new Uri("mailto:oneapp@sti.edu?subject=One STI Students Link Up&body=Student ID: " + Environment.NewLine + "Complete Student Name: " + Environment.NewLine + "Microsoft O365 Email Address: "));

    private void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
    {
    }

    private void TapGestureRecognizer_Tapped_2(object sender, EventArgs e) => this.Navigation.PushAsync((Page) new EmailRecoveryPage(), true);

    private void TapGestureRecognizer_Tapped_3(object sender, EventArgs e) => Device.OpenUri(new Uri("mailto:oneapp@sti.edu"));

    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private void InitializeComponent()
    {
      if (ResourceLoader.ResourceProvider != null && ResourceLoader.ResourceProvider(typeof (LoginHelpPage).GetTypeInfo().Assembly.GetName(), "Views/LoginHelpPage.xaml") != null)
        this.__InitComponentRuntime();
      else if (Xamarin.Forms.Xaml.Internals.XamlLoader.XamlFileProvider != null && Xamarin.Forms.Xaml.Internals.XamlLoader.XamlFileProvider(this.GetType()) != null)
      {
        this.__InitComponentRuntime();
      }
      else
      {
        StaticResourceExtension resourceExtension1 = new StaticResourceExtension();
        Label bindable1 = new Label();
        StaticResourceExtension resourceExtension2 = new StaticResourceExtension();
        Label bindable2 = new Label();
        BoxView bindable3 = new BoxView();
        StaticResourceExtension resourceExtension3 = new StaticResourceExtension();
        Label bindable4 = new Label();
        StaticResourceExtension resourceExtension4 = new StaticResourceExtension();
        Span bindable5 = new Span();
        Span bindable6 = new Span();
        Span bindable7 = new Span();
        FormattedString bindable8 = new FormattedString();
        ExtendedLabel bindable9 = new ExtendedLabel();
        StackLayout bindable10 = new StackLayout();
        Image bindable11 = new Image();
        StaticResourceExtension resourceExtension5 = new StaticResourceExtension();
        Label bindable12 = new Label();
        BoxView bindable13 = new BoxView();
        StaticResourceExtension resourceExtension6 = new StaticResourceExtension();
        Label bindable14 = new Label();
        StaticResourceExtension resourceExtension7 = new StaticResourceExtension();
        Span bindable15 = new Span();
        Span bindable16 = new Span();
        Span bindable17 = new Span();
        Span bindable18 = new Span();
        FormattedString bindable19 = new FormattedString();
        ExtendedLabel bindable20 = new ExtendedLabel();
        StackLayout bindable21 = new StackLayout();
        StaticResourceExtension resourceExtension8 = new StaticResourceExtension();
        Label bindable22 = new Label();
        StaticResourceExtension resourceExtension9 = new StaticResourceExtension();
        Span bindable23 = new Span();
        Span bindable24 = new Span();
        Span bindable25 = new Span();
        FormattedString bindable26 = new FormattedString();
        ExtendedLabel bindable27 = new ExtendedLabel();
        StackLayout bindable28 = new StackLayout();
        StaticResourceExtension resourceExtension10 = new StaticResourceExtension();
        Label bindable29 = new Label();
        BoxView bindable30 = new BoxView();
        StaticResourceExtension resourceExtension11 = new StaticResourceExtension();
        Label bindable31 = new Label();
        StaticResourceExtension resourceExtension12 = new StaticResourceExtension();
        ExtendedLabel bindable32 = new ExtendedLabel();
        StackLayout bindable33 = new StackLayout();
        StaticResourceExtension resourceExtension13 = new StaticResourceExtension();
        Label bindable34 = new Label();
        StaticResourceExtension resourceExtension14 = new StaticResourceExtension();
        ExtendedLabel bindable35 = new ExtendedLabel();
        StackLayout bindable36 = new StackLayout();
        StackLayout bindable37 = new StackLayout();
        StaticResourceExtension resourceExtension15 = new StaticResourceExtension();
        Span bindable38 = new Span();
        Span bindable39 = new Span();
        Span bindable40 = new Span();
        FormattedString bindable41 = new FormattedString();
        TapGestureRecognizer bindable42 = new TapGestureRecognizer();
        ExtendedLabel bindable43 = new ExtendedLabel();
        StackLayout bindable44 = new StackLayout();
        ScrollView bindable45 = new ScrollView();
        StackLayout bindable46 = new StackLayout();
        LoginHelpPage bindable47 = this;
        NameScope nameScope = new NameScope();
        NameScope.SetNameScope((BindableObject) bindable47, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable46, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable45, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable44, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable37, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable1, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable2, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable3, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable10, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable4, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable9, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable8, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable5, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable6, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable7, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable11, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable12, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable13, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable21, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable14, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable20, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable19, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable15, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable16, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable17, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable18, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable28, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable22, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable27, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable26, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable23, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable24, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable25, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable29, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable30, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable33, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable31, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable32, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable36, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable34, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable35, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable43, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable41, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable38, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable39, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable40, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable42, (INameScope) nameScope);
        bindable47.SetValue(Page.TitleProperty, (object) "Login FAQs");
        bindable46.SetValue(View.VerticalOptionsProperty, (object) LayoutOptions.FillAndExpand);
        bindable45.SetValue(View.VerticalOptionsProperty, (object) LayoutOptions.FillAndExpand);
        bindable44.SetValue(View.MarginProperty, (object) new Thickness(5.0, 0.0, 5.0, 0.0));
        bindable44.SetValue(StackLayout.OrientationProperty, (object) StackOrientation.Vertical);
        bindable44.SetValue(View.VerticalOptionsProperty, (object) LayoutOptions.FillAndExpand);
        bindable37.SetValue(View.MarginProperty, (object) new Thickness(15.0));
        resourceExtension1.Key = "mediumHeader";
        StaticResourceExtension resourceExtension16 = resourceExtension1;
        XamlServiceProvider xamlServiceProvider1 = new XamlServiceProvider();
        Type type1 = typeof (IProvideValueTarget);
        object[] objectAndParents1 = new object[0 + 6];
        objectAndParents1[0] = (object) bindable1;
        objectAndParents1[1] = (object) bindable37;
        objectAndParents1[2] = (object) bindable44;
        objectAndParents1[3] = (object) bindable45;
        objectAndParents1[4] = (object) bindable46;
        objectAndParents1[5] = (object) bindable47;
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
        XamlTypeResolver service2 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver1, typeof (LoginHelpPage).GetTypeInfo().Assembly);
        xamlServiceProvider1.Add(type2, (object) service2);
        xamlServiceProvider1.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(15, 32)));
        object obj1 = resourceExtension16.ProvideValue((IServiceProvider) xamlServiceProvider1);
        bindable1.Style = (Style) obj1;
        bindable1.SetValue(Label.TextColorProperty, (object) new Color(0.250980406999588, 0.250980406999588, 0.250980406999588, 1.0));
        bindable1.SetValue(Label.TextProperty, (object) "Having trouble logging in? Explore the following options.");
        bindable37.Children.Add((View) bindable1);
        bindable2.SetValue(View.MarginProperty, (object) new Thickness(0.0, 20.0, 0.0, 5.0));
        resourceExtension2.Key = "normalHeader";
        StaticResourceExtension resourceExtension17 = resourceExtension2;
        XamlServiceProvider xamlServiceProvider2 = new XamlServiceProvider();
        Type type3 = typeof (IProvideValueTarget);
        object[] objectAndParents2 = new object[0 + 6];
        objectAndParents2[0] = (object) bindable2;
        objectAndParents2[1] = (object) bindable37;
        objectAndParents2[2] = (object) bindable44;
        objectAndParents2[3] = (object) bindable45;
        objectAndParents2[4] = (object) bindable46;
        objectAndParents2[5] = (object) bindable47;
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
        XamlTypeResolver service4 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver2, typeof (LoginHelpPage).GetTypeInfo().Assembly);
        xamlServiceProvider2.Add(type4, (object) service4);
        xamlServiceProvider2.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(17, 50)));
        object obj2 = resourceExtension17.ProvideValue((IServiceProvider) xamlServiceProvider2);
        bindable2.Style = (Style) obj2;
        bindable2.SetValue(Label.TextColorProperty, (object) new Color(0.250980406999588, 0.250980406999588, 0.250980406999588, 1.0));
        bindable2.SetValue(Label.TextProperty, (object) "How to log-in");
        bindable2.SetValue(Label.HorizontalTextAlignmentProperty, new TextAlignmentConverter().ConvertFromInvariantString("Start"));
        bindable37.Children.Add((View) bindable2);
        bindable3.SetValue(BoxView.ColorProperty, (object) new Color(0.905882358551025, 0.752941191196442, 0.113725490868092, 1.0));
        bindable3.SetValue(VisualElement.HeightRequestProperty, (object) 1.5);
        bindable3.SetValue(View.MarginProperty, (object) new Thickness(0.0, 0.0, 0.0, 3.0));
        bindable3.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.FillAndExpand);
        bindable37.Children.Add((View) bindable3);
        bindable10.SetValue(StackLayout.OrientationProperty, (object) StackOrientation.Horizontal);
        resourceExtension3.Key = "mediumHeader";
        StaticResourceExtension resourceExtension18 = resourceExtension3;
        XamlServiceProvider xamlServiceProvider3 = new XamlServiceProvider();
        Type type5 = typeof (IProvideValueTarget);
        object[] objectAndParents3 = new object[0 + 7];
        objectAndParents3[0] = (object) bindable4;
        objectAndParents3[1] = (object) bindable10;
        objectAndParents3[2] = (object) bindable37;
        objectAndParents3[3] = (object) bindable44;
        objectAndParents3[4] = (object) bindable45;
        objectAndParents3[5] = (object) bindable46;
        objectAndParents3[6] = (object) bindable47;
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
        XamlTypeResolver service6 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver3, typeof (LoginHelpPage).GetTypeInfo().Assembly);
        xamlServiceProvider3.Add(type6, (object) service6);
        xamlServiceProvider3.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(21, 36)));
        object obj3 = resourceExtension18.ProvideValue((IServiceProvider) xamlServiceProvider3);
        bindable4.Style = (Style) obj3;
        bindable4.SetValue(Label.TextColorProperty, (object) new Color(0.250980406999588, 0.250980406999588, 0.250980406999588, 1.0));
        bindable4.SetValue(Label.TextProperty, (object) "• ");
        bindable4.SetValue(Label.HorizontalTextAlignmentProperty, new TextAlignmentConverter().ConvertFromInvariantString("Start"));
        bindable10.Children.Add((View) bindable4);
        resourceExtension4.Key = "smallLabel";
        StaticResourceExtension resourceExtension19 = resourceExtension4;
        XamlServiceProvider xamlServiceProvider4 = new XamlServiceProvider();
        Type type7 = typeof (IProvideValueTarget);
        object[] objectAndParents4 = new object[0 + 7];
        objectAndParents4[0] = (object) bindable9;
        objectAndParents4[1] = (object) bindable10;
        objectAndParents4[2] = (object) bindable37;
        objectAndParents4[3] = (object) bindable44;
        objectAndParents4[4] = (object) bindable45;
        objectAndParents4[5] = (object) bindable46;
        objectAndParents4[6] = (object) bindable47;
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
        XamlTypeResolver service8 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver4, typeof (LoginHelpPage).GetTypeInfo().Assembly);
        xamlServiceProvider4.Add(type8, (object) service8);
        xamlServiceProvider4.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(22, 50)));
        object obj4 = resourceExtension19.ProvideValue((IServiceProvider) xamlServiceProvider4);
        bindable9.Style = (Style) obj4;
        bindable9.SetValue(Label.TextColorProperty, (object) new Color(0.250980406999588, 0.250980406999588, 0.250980406999588, 1.0));
        bindable9.SetValue(Label.HorizontalTextAlignmentProperty, new TextAlignmentConverter().ConvertFromInvariantString("Start"));
        bindable5.SetValue(Span.TextColorProperty, (object) new Color(0.250980406999588, 0.250980406999588, 0.250980406999588, 1.0));
        bindable5.SetValue(Span.FontFamilyProperty, (object) "Roboto-Regular.ttf#Roboto");
        Span span1 = bindable5;
        BindableProperty fontSizeProperty1 = Span.FontSizeProperty;
        FontSizeConverter fontSizeConverter1 = new FontSizeConverter();
        XamlServiceProvider xamlServiceProvider5 = new XamlServiceProvider();
        Type type9 = typeof (IProvideValueTarget);
        object[] objectAndParents5 = new object[0 + 9];
        objectAndParents5[0] = (object) bindable5;
        objectAndParents5[1] = (object) bindable8;
        objectAndParents5[2] = (object) bindable9;
        objectAndParents5[3] = (object) bindable10;
        objectAndParents5[4] = (object) bindable37;
        objectAndParents5[5] = (object) bindable44;
        objectAndParents5[6] = (object) bindable45;
        objectAndParents5[7] = (object) bindable46;
        objectAndParents5[8] = (object) bindable47;
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
        namespaceResolver5.Add("xlabs", "clr-namespace:XLabs.Forms.Controls;assembly=XLabs.Forms");
        XamlTypeResolver service10 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver5, typeof (LoginHelpPage).GetTypeInfo().Assembly);
        xamlServiceProvider5.Add(type10, (object) service10);
        xamlServiceProvider5.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(25, 106)));
        object obj5 = ((IExtendedTypeConverter) fontSizeConverter1).ConvertFromInvariantString("15", (IServiceProvider) xamlServiceProvider5);
        span1.SetValue(fontSizeProperty1, obj5);
        bindable5.SetValue(Span.TextProperty, (object) "Sign-in using your STI Microsoft Office 365 account. If you don't know your account yet, get your credentials from your School Laboratory Facilitator or refer to your  ");
        bindable8.Spans.Add(bindable5);
        bindable6.SetValue(Span.TextColorProperty, (object) new Color(0.250980406999588, 0.250980406999588, 0.250980406999588, 1.0));
        bindable6.SetValue(Span.FontFamilyProperty, (object) "Roboto-Medium.ttf#Roboto");
        Span span2 = bindable6;
        BindableProperty fontSizeProperty2 = Span.FontSizeProperty;
        FontSizeConverter fontSizeConverter2 = new FontSizeConverter();
        XamlServiceProvider xamlServiceProvider6 = new XamlServiceProvider();
        Type type11 = typeof (IProvideValueTarget);
        object[] objectAndParents6 = new object[0 + 9];
        objectAndParents6[0] = (object) bindable6;
        objectAndParents6[1] = (object) bindable8;
        objectAndParents6[2] = (object) bindable9;
        objectAndParents6[3] = (object) bindable10;
        objectAndParents6[4] = (object) bindable37;
        objectAndParents6[5] = (object) bindable44;
        objectAndParents6[6] = (object) bindable45;
        objectAndParents6[7] = (object) bindable46;
        objectAndParents6[8] = (object) bindable47;
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
        namespaceResolver6.Add("xlabs", "clr-namespace:XLabs.Forms.Controls;assembly=XLabs.Forms");
        XamlTypeResolver service12 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver6, typeof (LoginHelpPage).GetTypeInfo().Assembly);
        xamlServiceProvider6.Add(type12, (object) service12);
        xamlServiceProvider6.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(26, 105)));
        object obj6 = ((IExtendedTypeConverter) fontSizeConverter2).ConvertFromInvariantString("15", (IServiceProvider) xamlServiceProvider6);
        span2.SetValue(fontSizeProperty2, obj6);
        bindable6.SetValue(Span.TextProperty, (object) "Registration and Assessment Form");
        bindable8.Spans.Add(bindable6);
        bindable7.SetValue(Span.TextColorProperty, (object) new Color(0.250980406999588, 0.250980406999588, 0.250980406999588, 1.0));
        bindable7.SetValue(Span.FontFamilyProperty, (object) "Roboto-Regular.ttf#Roboto");
        Span span3 = bindable7;
        BindableProperty fontSizeProperty3 = Span.FontSizeProperty;
        FontSizeConverter fontSizeConverter3 = new FontSizeConverter();
        XamlServiceProvider xamlServiceProvider7 = new XamlServiceProvider();
        Type type13 = typeof (IProvideValueTarget);
        object[] objectAndParents7 = new object[0 + 9];
        objectAndParents7[0] = (object) bindable7;
        objectAndParents7[1] = (object) bindable8;
        objectAndParents7[2] = (object) bindable9;
        objectAndParents7[3] = (object) bindable10;
        objectAndParents7[4] = (object) bindable37;
        objectAndParents7[5] = (object) bindable44;
        objectAndParents7[6] = (object) bindable45;
        objectAndParents7[7] = (object) bindable46;
        objectAndParents7[8] = (object) bindable47;
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
        namespaceResolver7.Add("xlabs", "clr-namespace:XLabs.Forms.Controls;assembly=XLabs.Forms");
        XamlTypeResolver service14 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver7, typeof (LoginHelpPage).GetTypeInfo().Assembly);
        xamlServiceProvider7.Add(type14, (object) service14);
        xamlServiceProvider7.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(27, 106)));
        object obj7 = ((IExtendedTypeConverter) fontSizeConverter3).ConvertFromInvariantString("15", (IServiceProvider) xamlServiceProvider7);
        span3.SetValue(fontSizeProperty3, obj7);
        bindable7.SetValue(Span.TextProperty, (object) " to get your official school email address. You may locate it at the lower-left corner of the form. See the sample screenshot below:");
        bindable8.Spans.Add(bindable7);
        bindable9.SetValue(Label.FormattedTextProperty, (object) bindable8);
        bindable10.Children.Add((View) bindable9);
        bindable37.Children.Add((View) bindable10);
        bindable11.SetValue(View.MarginProperty, (object) new Thickness(0.0, 10.0, 0.0, 0.0));
        bindable11.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.Center);
        bindable11.SetValue(Image.SourceProperty, new Xamarin.Forms.ImageSourceConverter().ConvertFromInvariantString("raf_account"));
        bindable37.Children.Add((View) bindable11);
        bindable12.SetValue(View.MarginProperty, (object) new Thickness(0.0, 25.0, 0.0, 5.0));
        resourceExtension5.Key = "normalHeader";
        StaticResourceExtension resourceExtension20 = resourceExtension5;
        XamlServiceProvider xamlServiceProvider8 = new XamlServiceProvider();
        Type type15 = typeof (IProvideValueTarget);
        object[] objectAndParents8 = new object[0 + 6];
        objectAndParents8[0] = (object) bindable12;
        objectAndParents8[1] = (object) bindable37;
        objectAndParents8[2] = (object) bindable44;
        objectAndParents8[3] = (object) bindable45;
        objectAndParents8[4] = (object) bindable46;
        objectAndParents8[5] = (object) bindable47;
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
        XamlTypeResolver service16 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver8, typeof (LoginHelpPage).GetTypeInfo().Assembly);
        xamlServiceProvider8.Add(type16, (object) service16);
        xamlServiceProvider8.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(62, 50)));
        object obj8 = resourceExtension20.ProvideValue((IServiceProvider) xamlServiceProvider8);
        bindable12.Style = (Style) obj8;
        bindable12.SetValue(Label.TextColorProperty, (object) new Color(0.250980406999588, 0.250980406999588, 0.250980406999588, 1.0));
        bindable12.SetValue(Label.TextProperty, (object) "My email account is not working.");
        bindable12.SetValue(Label.HorizontalTextAlignmentProperty, new TextAlignmentConverter().ConvertFromInvariantString("Start"));
        bindable37.Children.Add((View) bindable12);
        bindable13.SetValue(BoxView.ColorProperty, (object) new Color(0.905882358551025, 0.752941191196442, 0.113725490868092, 1.0));
        bindable13.SetValue(VisualElement.HeightRequestProperty, (object) 1.5);
        bindable13.SetValue(View.MarginProperty, (object) new Thickness(0.0, 0.0, 0.0, 3.0));
        bindable13.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.FillAndExpand);
        bindable37.Children.Add((View) bindable13);
        bindable21.SetValue(StackLayout.OrientationProperty, (object) StackOrientation.Horizontal);
        resourceExtension6.Key = "mediumHeader";
        StaticResourceExtension resourceExtension21 = resourceExtension6;
        XamlServiceProvider xamlServiceProvider9 = new XamlServiceProvider();
        Type type17 = typeof (IProvideValueTarget);
        object[] objectAndParents9 = new object[0 + 7];
        objectAndParents9[0] = (object) bindable14;
        objectAndParents9[1] = (object) bindable21;
        objectAndParents9[2] = (object) bindable37;
        objectAndParents9[3] = (object) bindable44;
        objectAndParents9[4] = (object) bindable45;
        objectAndParents9[5] = (object) bindable46;
        objectAndParents9[6] = (object) bindable47;
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
        XamlTypeResolver service18 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver9, typeof (LoginHelpPage).GetTypeInfo().Assembly);
        xamlServiceProvider9.Add(type18, (object) service18);
        xamlServiceProvider9.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(67, 36)));
        object obj9 = resourceExtension21.ProvideValue((IServiceProvider) xamlServiceProvider9);
        bindable14.Style = (Style) obj9;
        bindable14.SetValue(Label.TextColorProperty, (object) new Color(0.250980406999588, 0.250980406999588, 0.250980406999588, 1.0));
        bindable14.SetValue(Label.TextProperty, (object) "• ");
        bindable14.SetValue(Label.HorizontalTextAlignmentProperty, new TextAlignmentConverter().ConvertFromInvariantString("Start"));
        bindable21.Children.Add((View) bindable14);
        resourceExtension7.Key = "smallLabel";
        StaticResourceExtension resourceExtension22 = resourceExtension7;
        XamlServiceProvider xamlServiceProvider10 = new XamlServiceProvider();
        Type type19 = typeof (IProvideValueTarget);
        object[] objectAndParents10 = new object[0 + 7];
        objectAndParents10[0] = (object) bindable20;
        objectAndParents10[1] = (object) bindable21;
        objectAndParents10[2] = (object) bindable37;
        objectAndParents10[3] = (object) bindable44;
        objectAndParents10[4] = (object) bindable45;
        objectAndParents10[5] = (object) bindable46;
        objectAndParents10[6] = (object) bindable47;
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
        XamlTypeResolver service20 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver10, typeof (LoginHelpPage).GetTypeInfo().Assembly);
        xamlServiceProvider10.Add(type20, (object) service20);
        xamlServiceProvider10.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(68, 50)));
        object obj10 = resourceExtension22.ProvideValue((IServiceProvider) xamlServiceProvider10);
        bindable20.Style = (Style) obj10;
        bindable20.SetValue(Label.TextColorProperty, (object) new Color(0.250980406999588, 0.250980406999588, 0.250980406999588, 1.0));
        bindable20.SetValue(Label.HorizontalTextAlignmentProperty, new TextAlignmentConverter().ConvertFromInvariantString("Start"));
        bindable15.SetValue(Span.TextColorProperty, (object) new Color(0.250980406999588, 0.250980406999588, 0.250980406999588, 1.0));
        bindable15.SetValue(Span.FontFamilyProperty, (object) "Roboto-Regular.ttf#Roboto");
        Span span4 = bindable15;
        BindableProperty fontSizeProperty4 = Span.FontSizeProperty;
        FontSizeConverter fontSizeConverter4 = new FontSizeConverter();
        XamlServiceProvider xamlServiceProvider11 = new XamlServiceProvider();
        Type type21 = typeof (IProvideValueTarget);
        object[] objectAndParents11 = new object[0 + 9];
        objectAndParents11[0] = (object) bindable15;
        objectAndParents11[1] = (object) bindable19;
        objectAndParents11[2] = (object) bindable20;
        objectAndParents11[3] = (object) bindable21;
        objectAndParents11[4] = (object) bindable37;
        objectAndParents11[5] = (object) bindable44;
        objectAndParents11[6] = (object) bindable45;
        objectAndParents11[7] = (object) bindable46;
        objectAndParents11[8] = (object) bindable47;
        SimpleValueTargetProvider service21 = new SimpleValueTargetProvider(objectAndParents11, (object) Span.FontSizeProperty);
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
        XamlTypeResolver service22 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver11, typeof (LoginHelpPage).GetTypeInfo().Assembly);
        xamlServiceProvider11.Add(type22, (object) service22);
        xamlServiceProvider11.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(71, 106)));
        object obj11 = ((IExtendedTypeConverter) fontSizeConverter4).ConvertFromInvariantString("15", (IServiceProvider) xamlServiceProvider11);
        span4.SetValue(fontSizeProperty4, obj11);
        bindable15.SetValue(Span.TextProperty, (object) "You might be using the old email address format ");
        bindable19.Spans.Add(bindable15);
        bindable16.SetValue(Span.TextColorProperty, (object) new Color(0.250980406999588, 0.250980406999588, 0.250980406999588, 1.0));
        bindable16.SetValue(Span.FontFamilyProperty, (object) "Roboto-Medium.ttf#Roboto");
        Span span5 = bindable16;
        BindableProperty fontSizeProperty5 = Span.FontSizeProperty;
        FontSizeConverter fontSizeConverter5 = new FontSizeConverter();
        XamlServiceProvider xamlServiceProvider12 = new XamlServiceProvider();
        Type type23 = typeof (IProvideValueTarget);
        object[] objectAndParents12 = new object[0 + 9];
        objectAndParents12[0] = (object) bindable16;
        objectAndParents12[1] = (object) bindable19;
        objectAndParents12[2] = (object) bindable20;
        objectAndParents12[3] = (object) bindable21;
        objectAndParents12[4] = (object) bindable37;
        objectAndParents12[5] = (object) bindable44;
        objectAndParents12[6] = (object) bindable45;
        objectAndParents12[7] = (object) bindable46;
        objectAndParents12[8] = (object) bindable47;
        SimpleValueTargetProvider service23 = new SimpleValueTargetProvider(objectAndParents12, (object) Span.FontSizeProperty);
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
        XamlTypeResolver service24 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver12, typeof (LoginHelpPage).GetTypeInfo().Assembly);
        xamlServiceProvider12.Add(type24, (object) service24);
        xamlServiceProvider12.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(72, 105)));
        object obj12 = ((IExtendedTypeConverter) fontSizeConverter5).ConvertFromInvariantString("15", (IServiceProvider) xamlServiceProvider12);
        span5.SetValue(fontSizeProperty5, obj12);
        bindable16.SetValue(Span.TextProperty, (object) "(sti.ph). ");
        bindable19.Spans.Add(bindable16);
        bindable17.SetValue(Span.TextColorProperty, (object) new Color(0.250980406999588, 0.250980406999588, 0.250980406999588, 1.0));
        bindable17.SetValue(Span.FontFamilyProperty, (object) "Roboto-Regular.ttf#Roboto");
        Span span6 = bindable17;
        BindableProperty fontSizeProperty6 = Span.FontSizeProperty;
        FontSizeConverter fontSizeConverter6 = new FontSizeConverter();
        XamlServiceProvider xamlServiceProvider13 = new XamlServiceProvider();
        Type type25 = typeof (IProvideValueTarget);
        object[] objectAndParents13 = new object[0 + 9];
        objectAndParents13[0] = (object) bindable17;
        objectAndParents13[1] = (object) bindable19;
        objectAndParents13[2] = (object) bindable20;
        objectAndParents13[3] = (object) bindable21;
        objectAndParents13[4] = (object) bindable37;
        objectAndParents13[5] = (object) bindable44;
        objectAndParents13[6] = (object) bindable45;
        objectAndParents13[7] = (object) bindable46;
        objectAndParents13[8] = (object) bindable47;
        SimpleValueTargetProvider service25 = new SimpleValueTargetProvider(objectAndParents13, (object) Span.FontSizeProperty);
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
        XamlTypeResolver service26 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver13, typeof (LoginHelpPage).GetTypeInfo().Assembly);
        xamlServiceProvider13.Add(type26, (object) service26);
        xamlServiceProvider13.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(73, 106)));
        object obj13 = ((IExtendedTypeConverter) fontSizeConverter6).ConvertFromInvariantString("15", (IServiceProvider) xamlServiceProvider13);
        span6.SetValue(fontSizeProperty6, obj13);
        bindable17.SetValue(Span.TextProperty, (object) "Please update it using the new format ");
        bindable19.Spans.Add(bindable17);
        bindable18.SetValue(Span.TextColorProperty, (object) new Color(0.250980406999588, 0.250980406999588, 0.250980406999588, 1.0));
        bindable18.SetValue(Span.FontFamilyProperty, (object) "Roboto-Medium.ttf#Roboto");
        Span span7 = bindable18;
        BindableProperty fontSizeProperty7 = Span.FontSizeProperty;
        FontSizeConverter fontSizeConverter7 = new FontSizeConverter();
        XamlServiceProvider xamlServiceProvider14 = new XamlServiceProvider();
        Type type27 = typeof (IProvideValueTarget);
        object[] objectAndParents14 = new object[0 + 9];
        objectAndParents14[0] = (object) bindable18;
        objectAndParents14[1] = (object) bindable19;
        objectAndParents14[2] = (object) bindable20;
        objectAndParents14[3] = (object) bindable21;
        objectAndParents14[4] = (object) bindable37;
        objectAndParents14[5] = (object) bindable44;
        objectAndParents14[6] = (object) bindable45;
        objectAndParents14[7] = (object) bindable46;
        objectAndParents14[8] = (object) bindable47;
        SimpleValueTargetProvider service27 = new SimpleValueTargetProvider(objectAndParents14, (object) Span.FontSizeProperty);
        xamlServiceProvider14.Add(type27, (object) service27);
        xamlServiceProvider14.Add(typeof (INameScopeProvider), (object) new NameScopeProvider()
        {
          NameScope = (INameScope) nameScope
        });
        Type type28 = typeof (IXamlTypeResolver);
        XmlNamespaceResolver namespaceResolver14 = new XmlNamespaceResolver();
        namespaceResolver14.Add("", "http://xamarin.com/schemas/2014/forms");
        namespaceResolver14.Add("x", "http://schemas.microsoft.com/winfx/2009/xaml");
        namespaceResolver14.Add("xlabs", "clr-namespace:XLabs.Forms.Controls;assembly=XLabs.Forms");
        XamlTypeResolver service28 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver14, typeof (LoginHelpPage).GetTypeInfo().Assembly);
        xamlServiceProvider14.Add(type28, (object) service28);
        xamlServiceProvider14.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(74, 105)));
        object obj14 = ((IExtendedTypeConverter) fontSizeConverter7).ConvertFromInvariantString("15", (IServiceProvider) xamlServiceProvider14);
        span7.SetValue(fontSizeProperty7, obj14);
        bindable18.SetValue(Span.TextProperty, (object) "(sti.edu.ph). ");
        bindable19.Spans.Add(bindable18);
        bindable20.SetValue(Label.FormattedTextProperty, (object) bindable19);
        bindable21.Children.Add((View) bindable20);
        bindable37.Children.Add((View) bindable21);
        bindable28.SetValue(StackLayout.OrientationProperty, (object) StackOrientation.Horizontal);
        resourceExtension8.Key = "mediumHeader";
        StaticResourceExtension resourceExtension23 = resourceExtension8;
        XamlServiceProvider xamlServiceProvider15 = new XamlServiceProvider();
        Type type29 = typeof (IProvideValueTarget);
        object[] objectAndParents15 = new object[0 + 7];
        objectAndParents15[0] = (object) bindable22;
        objectAndParents15[1] = (object) bindable28;
        objectAndParents15[2] = (object) bindable37;
        objectAndParents15[3] = (object) bindable44;
        objectAndParents15[4] = (object) bindable45;
        objectAndParents15[5] = (object) bindable46;
        objectAndParents15[6] = (object) bindable47;
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
        namespaceResolver15.Add("xlabs", "clr-namespace:XLabs.Forms.Controls;assembly=XLabs.Forms");
        XamlTypeResolver service30 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver15, typeof (LoginHelpPage).GetTypeInfo().Assembly);
        xamlServiceProvider15.Add(type30, (object) service30);
        xamlServiceProvider15.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(81, 36)));
        object obj15 = resourceExtension23.ProvideValue((IServiceProvider) xamlServiceProvider15);
        bindable22.Style = (Style) obj15;
        bindable22.SetValue(Label.TextColorProperty, (object) new Color(0.250980406999588, 0.250980406999588, 0.250980406999588, 1.0));
        bindable22.SetValue(Label.TextProperty, (object) "• ");
        bindable22.SetValue(Label.HorizontalTextAlignmentProperty, new TextAlignmentConverter().ConvertFromInvariantString("Start"));
        bindable28.Children.Add((View) bindable22);
        resourceExtension9.Key = "smallLabel";
        StaticResourceExtension resourceExtension24 = resourceExtension9;
        XamlServiceProvider xamlServiceProvider16 = new XamlServiceProvider();
        Type type31 = typeof (IProvideValueTarget);
        object[] objectAndParents16 = new object[0 + 7];
        objectAndParents16[0] = (object) bindable27;
        objectAndParents16[1] = (object) bindable28;
        objectAndParents16[2] = (object) bindable37;
        objectAndParents16[3] = (object) bindable44;
        objectAndParents16[4] = (object) bindable45;
        objectAndParents16[5] = (object) bindable46;
        objectAndParents16[6] = (object) bindable47;
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
        namespaceResolver16.Add("xlabs", "clr-namespace:XLabs.Forms.Controls;assembly=XLabs.Forms");
        XamlTypeResolver service32 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver16, typeof (LoginHelpPage).GetTypeInfo().Assembly);
        xamlServiceProvider16.Add(type32, (object) service32);
        xamlServiceProvider16.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(82, 50)));
        object obj16 = resourceExtension24.ProvideValue((IServiceProvider) xamlServiceProvider16);
        bindable27.Style = (Style) obj16;
        bindable27.SetValue(Label.TextColorProperty, (object) new Color(0.250980406999588, 0.250980406999588, 0.250980406999588, 1.0));
        bindable27.SetValue(Label.HorizontalTextAlignmentProperty, new TextAlignmentConverter().ConvertFromInvariantString("Start"));
        bindable23.SetValue(Span.TextColorProperty, (object) new Color(0.250980406999588, 0.250980406999588, 0.250980406999588, 1.0));
        bindable23.SetValue(Span.FontFamilyProperty, (object) "Roboto-Regular.ttf#Roboto");
        Span span8 = bindable23;
        BindableProperty fontSizeProperty8 = Span.FontSizeProperty;
        FontSizeConverter fontSizeConverter8 = new FontSizeConverter();
        XamlServiceProvider xamlServiceProvider17 = new XamlServiceProvider();
        Type type33 = typeof (IProvideValueTarget);
        object[] objectAndParents17 = new object[0 + 9];
        objectAndParents17[0] = (object) bindable23;
        objectAndParents17[1] = (object) bindable26;
        objectAndParents17[2] = (object) bindable27;
        objectAndParents17[3] = (object) bindable28;
        objectAndParents17[4] = (object) bindable37;
        objectAndParents17[5] = (object) bindable44;
        objectAndParents17[6] = (object) bindable45;
        objectAndParents17[7] = (object) bindable46;
        objectAndParents17[8] = (object) bindable47;
        SimpleValueTargetProvider service33 = new SimpleValueTargetProvider(objectAndParents17, (object) Span.FontSizeProperty);
        xamlServiceProvider17.Add(type33, (object) service33);
        xamlServiceProvider17.Add(typeof (INameScopeProvider), (object) new NameScopeProvider()
        {
          NameScope = (INameScope) nameScope
        });
        Type type34 = typeof (IXamlTypeResolver);
        XmlNamespaceResolver namespaceResolver17 = new XmlNamespaceResolver();
        namespaceResolver17.Add("", "http://xamarin.com/schemas/2014/forms");
        namespaceResolver17.Add("x", "http://schemas.microsoft.com/winfx/2009/xaml");
        namespaceResolver17.Add("xlabs", "clr-namespace:XLabs.Forms.Controls;assembly=XLabs.Forms");
        XamlTypeResolver service34 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver17, typeof (LoginHelpPage).GetTypeInfo().Assembly);
        xamlServiceProvider17.Add(type34, (object) service34);
        xamlServiceProvider17.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(85, 106)));
        object obj17 = ((IExtendedTypeConverter) fontSizeConverter8).ConvertFromInvariantString("15", (IServiceProvider) xamlServiceProvider17);
        span8.SetValue(fontSizeProperty8, obj17);
        bindable23.SetValue(Span.TextProperty, (object) "When a message appears that ");
        bindable26.Spans.Add(bindable23);
        bindable24.SetValue(Span.TextColorProperty, (object) new Color(0.250980406999588, 0.250980406999588, 0.250980406999588, 1.0));
        bindable24.SetValue(Span.FontFamilyProperty, (object) "Roboto-Medium.ttf#Roboto");
        Span span9 = bindable24;
        BindableProperty fontSizeProperty9 = Span.FontSizeProperty;
        FontSizeConverter fontSizeConverter9 = new FontSizeConverter();
        XamlServiceProvider xamlServiceProvider18 = new XamlServiceProvider();
        Type type35 = typeof (IProvideValueTarget);
        object[] objectAndParents18 = new object[0 + 9];
        objectAndParents18[0] = (object) bindable24;
        objectAndParents18[1] = (object) bindable26;
        objectAndParents18[2] = (object) bindable27;
        objectAndParents18[3] = (object) bindable28;
        objectAndParents18[4] = (object) bindable37;
        objectAndParents18[5] = (object) bindable44;
        objectAndParents18[6] = (object) bindable45;
        objectAndParents18[7] = (object) bindable46;
        objectAndParents18[8] = (object) bindable47;
        SimpleValueTargetProvider service35 = new SimpleValueTargetProvider(objectAndParents18, (object) Span.FontSizeProperty);
        xamlServiceProvider18.Add(type35, (object) service35);
        xamlServiceProvider18.Add(typeof (INameScopeProvider), (object) new NameScopeProvider()
        {
          NameScope = (INameScope) nameScope
        });
        Type type36 = typeof (IXamlTypeResolver);
        XmlNamespaceResolver namespaceResolver18 = new XmlNamespaceResolver();
        namespaceResolver18.Add("", "http://xamarin.com/schemas/2014/forms");
        namespaceResolver18.Add("x", "http://schemas.microsoft.com/winfx/2009/xaml");
        namespaceResolver18.Add("xlabs", "clr-namespace:XLabs.Forms.Controls;assembly=XLabs.Forms");
        XamlTypeResolver service36 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver18, typeof (LoginHelpPage).GetTypeInfo().Assembly);
        xamlServiceProvider18.Add(type36, (object) service36);
        xamlServiceProvider18.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(86, 105)));
        object obj18 = ((IExtendedTypeConverter) fontSizeConverter9).ConvertFromInvariantString("15", (IServiceProvider) xamlServiceProvider18);
        span9.SetValue(fontSizeProperty9, obj18);
        bindable24.SetValue(Span.TextProperty, (object) "\"Your email account needs to link up with your record\" ");
        bindable26.Spans.Add(bindable24);
        bindable25.SetValue(Span.TextColorProperty, (object) new Color(0.250980406999588, 0.250980406999588, 0.250980406999588, 1.0));
        bindable25.SetValue(Span.FontFamilyProperty, (object) "Roboto-Regular.ttf#Roboto");
        Span span10 = bindable25;
        BindableProperty fontSizeProperty10 = Span.FontSizeProperty;
        FontSizeConverter fontSizeConverter10 = new FontSizeConverter();
        XamlServiceProvider xamlServiceProvider19 = new XamlServiceProvider();
        Type type37 = typeof (IProvideValueTarget);
        object[] objectAndParents19 = new object[0 + 9];
        objectAndParents19[0] = (object) bindable25;
        objectAndParents19[1] = (object) bindable26;
        objectAndParents19[2] = (object) bindable27;
        objectAndParents19[3] = (object) bindable28;
        objectAndParents19[4] = (object) bindable37;
        objectAndParents19[5] = (object) bindable44;
        objectAndParents19[6] = (object) bindable45;
        objectAndParents19[7] = (object) bindable46;
        objectAndParents19[8] = (object) bindable47;
        SimpleValueTargetProvider service37 = new SimpleValueTargetProvider(objectAndParents19, (object) Span.FontSizeProperty);
        xamlServiceProvider19.Add(type37, (object) service37);
        xamlServiceProvider19.Add(typeof (INameScopeProvider), (object) new NameScopeProvider()
        {
          NameScope = (INameScope) nameScope
        });
        Type type38 = typeof (IXamlTypeResolver);
        XmlNamespaceResolver namespaceResolver19 = new XmlNamespaceResolver();
        namespaceResolver19.Add("", "http://xamarin.com/schemas/2014/forms");
        namespaceResolver19.Add("x", "http://schemas.microsoft.com/winfx/2009/xaml");
        namespaceResolver19.Add("xlabs", "clr-namespace:XLabs.Forms.Controls;assembly=XLabs.Forms");
        XamlTypeResolver service38 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver19, typeof (LoginHelpPage).GetTypeInfo().Assembly);
        xamlServiceProvider19.Add(type38, (object) service38);
        xamlServiceProvider19.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(87, 106)));
        object obj19 = ((IExtendedTypeConverter) fontSizeConverter10).ConvertFromInvariantString("15", (IServiceProvider) xamlServiceProvider19);
        span10.SetValue(fontSizeProperty10, obj19);
        bindable25.SetValue(Span.TextProperty, (object) "talk to your School Registrar and request for a record update.");
        bindable26.Spans.Add(bindable25);
        bindable27.SetValue(Label.FormattedTextProperty, (object) bindable26);
        bindable28.Children.Add((View) bindable27);
        bindable37.Children.Add((View) bindable28);
        bindable29.SetValue(View.MarginProperty, (object) new Thickness(0.0, 25.0, 0.0, 5.0));
        resourceExtension10.Key = "normalHeader";
        StaticResourceExtension resourceExtension25 = resourceExtension10;
        XamlServiceProvider xamlServiceProvider20 = new XamlServiceProvider();
        Type type39 = typeof (IProvideValueTarget);
        object[] objectAndParents20 = new object[0 + 6];
        objectAndParents20[0] = (object) bindable29;
        objectAndParents20[1] = (object) bindable37;
        objectAndParents20[2] = (object) bindable44;
        objectAndParents20[3] = (object) bindable45;
        objectAndParents20[4] = (object) bindable46;
        objectAndParents20[5] = (object) bindable47;
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
        namespaceResolver20.Add("xlabs", "clr-namespace:XLabs.Forms.Controls;assembly=XLabs.Forms");
        XamlTypeResolver service40 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver20, typeof (LoginHelpPage).GetTypeInfo().Assembly);
        xamlServiceProvider20.Add(type40, (object) service40);
        xamlServiceProvider20.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(117, 50)));
        object obj20 = resourceExtension25.ProvideValue((IServiceProvider) xamlServiceProvider20);
        bindable29.Style = (Style) obj20;
        bindable29.SetValue(Label.TextColorProperty, (object) new Color(0.250980406999588, 0.250980406999588, 0.250980406999588, 1.0));
        bindable29.SetValue(Label.TextProperty, (object) "My default password is incorrect.");
        bindable29.SetValue(Label.HorizontalTextAlignmentProperty, new TextAlignmentConverter().ConvertFromInvariantString("Start"));
        bindable37.Children.Add((View) bindable29);
        bindable30.SetValue(BoxView.ColorProperty, (object) new Color(0.905882358551025, 0.752941191196442, 0.113725490868092, 1.0));
        bindable30.SetValue(VisualElement.HeightRequestProperty, (object) 1.5);
        bindable30.SetValue(View.MarginProperty, (object) new Thickness(0.0, 0.0, 0.0, 3.0));
        bindable30.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.FillAndExpand);
        bindable37.Children.Add((View) bindable30);
        bindable33.SetValue(StackLayout.OrientationProperty, (object) StackOrientation.Horizontal);
        resourceExtension11.Key = "mediumHeader";
        StaticResourceExtension resourceExtension26 = resourceExtension11;
        XamlServiceProvider xamlServiceProvider21 = new XamlServiceProvider();
        Type type41 = typeof (IProvideValueTarget);
        object[] objectAndParents21 = new object[0 + 7];
        objectAndParents21[0] = (object) bindable31;
        objectAndParents21[1] = (object) bindable33;
        objectAndParents21[2] = (object) bindable37;
        objectAndParents21[3] = (object) bindable44;
        objectAndParents21[4] = (object) bindable45;
        objectAndParents21[5] = (object) bindable46;
        objectAndParents21[6] = (object) bindable47;
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
        namespaceResolver21.Add("xlabs", "clr-namespace:XLabs.Forms.Controls;assembly=XLabs.Forms");
        XamlTypeResolver service42 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver21, typeof (LoginHelpPage).GetTypeInfo().Assembly);
        xamlServiceProvider21.Add(type42, (object) service42);
        xamlServiceProvider21.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(121, 36)));
        object obj21 = resourceExtension26.ProvideValue((IServiceProvider) xamlServiceProvider21);
        bindable31.Style = (Style) obj21;
        bindable31.SetValue(Label.TextColorProperty, (object) new Color(0.250980406999588, 0.250980406999588, 0.250980406999588, 1.0));
        bindable31.SetValue(Label.TextProperty, (object) "• ");
        bindable31.SetValue(Label.HorizontalTextAlignmentProperty, new TextAlignmentConverter().ConvertFromInvariantString("Start"));
        bindable33.Children.Add((View) bindable31);
        resourceExtension12.Key = "smallLabel";
        StaticResourceExtension resourceExtension27 = resourceExtension12;
        XamlServiceProvider xamlServiceProvider22 = new XamlServiceProvider();
        Type type43 = typeof (IProvideValueTarget);
        object[] objectAndParents22 = new object[0 + 7];
        objectAndParents22[0] = (object) bindable32;
        objectAndParents22[1] = (object) bindable33;
        objectAndParents22[2] = (object) bindable37;
        objectAndParents22[3] = (object) bindable44;
        objectAndParents22[4] = (object) bindable45;
        objectAndParents22[5] = (object) bindable46;
        objectAndParents22[6] = (object) bindable47;
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
        namespaceResolver22.Add("xlabs", "clr-namespace:XLabs.Forms.Controls;assembly=XLabs.Forms");
        XamlTypeResolver service44 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver22, typeof (LoginHelpPage).GetTypeInfo().Assembly);
        xamlServiceProvider22.Add(type44, (object) service44);
        xamlServiceProvider22.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(122, 50)));
        object obj22 = resourceExtension27.ProvideValue((IServiceProvider) xamlServiceProvider22);
        bindable32.Style = (Style) obj22;
        bindable32.SetValue(Label.TextColorProperty, (object) new Color(0.250980406999588, 0.250980406999588, 0.250980406999588, 1.0));
        bindable32.SetValue(Label.HorizontalTextAlignmentProperty, new TextAlignmentConverter().ConvertFromInvariantString("Start"));
        bindable32.SetValue(Label.TextProperty, (object) "Verify the password from your School Laboratory Facilitator. ");
        bindable33.Children.Add((View) bindable32);
        bindable37.Children.Add((View) bindable33);
        bindable36.SetValue(StackLayout.OrientationProperty, (object) StackOrientation.Horizontal);
        resourceExtension13.Key = "mediumHeader";
        StaticResourceExtension resourceExtension28 = resourceExtension13;
        XamlServiceProvider xamlServiceProvider23 = new XamlServiceProvider();
        Type type45 = typeof (IProvideValueTarget);
        object[] objectAndParents23 = new object[0 + 7];
        objectAndParents23[0] = (object) bindable34;
        objectAndParents23[1] = (object) bindable36;
        objectAndParents23[2] = (object) bindable37;
        objectAndParents23[3] = (object) bindable44;
        objectAndParents23[4] = (object) bindable45;
        objectAndParents23[5] = (object) bindable46;
        objectAndParents23[6] = (object) bindable47;
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
        namespaceResolver23.Add("xlabs", "clr-namespace:XLabs.Forms.Controls;assembly=XLabs.Forms");
        XamlTypeResolver service46 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver23, typeof (LoginHelpPage).GetTypeInfo().Assembly);
        xamlServiceProvider23.Add(type46, (object) service46);
        xamlServiceProvider23.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(127, 36)));
        object obj23 = resourceExtension28.ProvideValue((IServiceProvider) xamlServiceProvider23);
        bindable34.Style = (Style) obj23;
        bindable34.SetValue(Label.TextColorProperty, (object) new Color(0.250980406999588, 0.250980406999588, 0.250980406999588, 1.0));
        bindable34.SetValue(Label.TextProperty, (object) "• ");
        bindable34.SetValue(Label.HorizontalTextAlignmentProperty, new TextAlignmentConverter().ConvertFromInvariantString("Start"));
        bindable36.Children.Add((View) bindable34);
        resourceExtension14.Key = "smallLabel";
        StaticResourceExtension resourceExtension29 = resourceExtension14;
        XamlServiceProvider xamlServiceProvider24 = new XamlServiceProvider();
        Type type47 = typeof (IProvideValueTarget);
        object[] objectAndParents24 = new object[0 + 7];
        objectAndParents24[0] = (object) bindable35;
        objectAndParents24[1] = (object) bindable36;
        objectAndParents24[2] = (object) bindable37;
        objectAndParents24[3] = (object) bindable44;
        objectAndParents24[4] = (object) bindable45;
        objectAndParents24[5] = (object) bindable46;
        objectAndParents24[6] = (object) bindable47;
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
        namespaceResolver24.Add("xlabs", "clr-namespace:XLabs.Forms.Controls;assembly=XLabs.Forms");
        XamlTypeResolver service48 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver24, typeof (LoginHelpPage).GetTypeInfo().Assembly);
        xamlServiceProvider24.Add(type48, (object) service48);
        xamlServiceProvider24.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(128, 50)));
        object obj24 = resourceExtension29.ProvideValue((IServiceProvider) xamlServiceProvider24);
        bindable35.Style = (Style) obj24;
        bindable35.SetValue(Label.TextColorProperty, (object) new Color(0.250980406999588, 0.250980406999588, 0.250980406999588, 1.0));
        bindable35.SetValue(Label.HorizontalTextAlignmentProperty, new TextAlignmentConverter().ConvertFromInvariantString("Start"));
        bindable35.SetValue(Label.TextProperty, (object) "You may also request for a new one by approaching the School Laboratory Facilitator then ask for a password reset. ");
        bindable36.Children.Add((View) bindable35);
        bindable37.Children.Add((View) bindable36);
        bindable44.Children.Add((View) bindable37);
        resourceExtension15.Key = "smallLabel";
        StaticResourceExtension resourceExtension30 = resourceExtension15;
        XamlServiceProvider xamlServiceProvider25 = new XamlServiceProvider();
        Type type49 = typeof (IProvideValueTarget);
        object[] objectAndParents25 = new object[0 + 5];
        objectAndParents25[0] = (object) bindable43;
        objectAndParents25[1] = (object) bindable44;
        objectAndParents25[2] = (object) bindable45;
        objectAndParents25[3] = (object) bindable46;
        objectAndParents25[4] = (object) bindable47;
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
        namespaceResolver25.Add("xlabs", "clr-namespace:XLabs.Forms.Controls;assembly=XLabs.Forms");
        XamlTypeResolver service50 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver25, typeof (LoginHelpPage).GetTypeInfo().Assembly);
        xamlServiceProvider25.Add(type50, (object) service50);
        xamlServiceProvider25.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(136, 42)));
        object obj25 = resourceExtension30.ProvideValue((IServiceProvider) xamlServiceProvider25);
        bindable43.Style = (Style) obj25;
        bindable43.SetValue(Label.TextColorProperty, (object) new Color(0.250980406999588, 0.250980406999588, 0.250980406999588, 1.0));
        bindable43.SetValue(View.MarginProperty, (object) new Thickness(15.0, 25.0, 15.0, 15.0));
        bindable43.SetValue(Label.HorizontalTextAlignmentProperty, new TextAlignmentConverter().ConvertFromInvariantString("Start"));
        bindable38.SetValue(Span.TextColorProperty, (object) new Color(0.400000005960464, 0.400000005960464, 0.400000005960464, 1.0));
        bindable38.SetValue(Span.FontFamilyProperty, (object) "Roboto-Regular.ttf#Roboto");
        Span span11 = bindable38;
        BindableProperty fontSizeProperty11 = Span.FontSizeProperty;
        FontSizeConverter fontSizeConverter11 = new FontSizeConverter();
        XamlServiceProvider xamlServiceProvider26 = new XamlServiceProvider();
        Type type51 = typeof (IProvideValueTarget);
        object[] objectAndParents26 = new object[0 + 7];
        objectAndParents26[0] = (object) bindable38;
        objectAndParents26[1] = (object) bindable41;
        objectAndParents26[2] = (object) bindable43;
        objectAndParents26[3] = (object) bindable44;
        objectAndParents26[4] = (object) bindable45;
        objectAndParents26[5] = (object) bindable46;
        objectAndParents26[6] = (object) bindable47;
        SimpleValueTargetProvider service51 = new SimpleValueTargetProvider(objectAndParents26, (object) Span.FontSizeProperty);
        xamlServiceProvider26.Add(type51, (object) service51);
        xamlServiceProvider26.Add(typeof (INameScopeProvider), (object) new NameScopeProvider()
        {
          NameScope = (INameScope) nameScope
        });
        Type type52 = typeof (IXamlTypeResolver);
        XmlNamespaceResolver namespaceResolver26 = new XmlNamespaceResolver();
        namespaceResolver26.Add("", "http://xamarin.com/schemas/2014/forms");
        namespaceResolver26.Add("x", "http://schemas.microsoft.com/winfx/2009/xaml");
        namespaceResolver26.Add("xlabs", "clr-namespace:XLabs.Forms.Controls;assembly=XLabs.Forms");
        XamlTypeResolver service52 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver26, typeof (LoginHelpPage).GetTypeInfo().Assembly);
        xamlServiceProvider26.Add(type52, (object) service52);
        xamlServiceProvider26.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(139, 98)));
        object obj26 = ((IExtendedTypeConverter) fontSizeConverter11).ConvertFromInvariantString("13", (IServiceProvider) xamlServiceProvider26);
        span11.SetValue(fontSizeProperty11, obj26);
        bindable38.SetValue(Span.TextProperty, (object) "Can't find what you're looking for? Send us an email at ");
        bindable41.Spans.Add(bindable38);
        bindable39.SetValue(Span.TextColorProperty, (object) new Color(0.0431372560560703, 0.341176480054855, 0.576470613479614, 1.0));
        bindable39.SetValue(Span.FontFamilyProperty, (object) "Roboto-Medium.ttf#Roboto");
        Span span12 = bindable39;
        BindableProperty fontSizeProperty12 = Span.FontSizeProperty;
        FontSizeConverter fontSizeConverter12 = new FontSizeConverter();
        XamlServiceProvider xamlServiceProvider27 = new XamlServiceProvider();
        Type type53 = typeof (IProvideValueTarget);
        object[] objectAndParents27 = new object[0 + 7];
        objectAndParents27[0] = (object) bindable39;
        objectAndParents27[1] = (object) bindable41;
        objectAndParents27[2] = (object) bindable43;
        objectAndParents27[3] = (object) bindable44;
        objectAndParents27[4] = (object) bindable45;
        objectAndParents27[5] = (object) bindable46;
        objectAndParents27[6] = (object) bindable47;
        SimpleValueTargetProvider service53 = new SimpleValueTargetProvider(objectAndParents27, (object) Span.FontSizeProperty);
        xamlServiceProvider27.Add(type53, (object) service53);
        xamlServiceProvider27.Add(typeof (INameScopeProvider), (object) new NameScopeProvider()
        {
          NameScope = (INameScope) nameScope
        });
        Type type54 = typeof (IXamlTypeResolver);
        XmlNamespaceResolver namespaceResolver27 = new XmlNamespaceResolver();
        namespaceResolver27.Add("", "http://xamarin.com/schemas/2014/forms");
        namespaceResolver27.Add("x", "http://schemas.microsoft.com/winfx/2009/xaml");
        namespaceResolver27.Add("xlabs", "clr-namespace:XLabs.Forms.Controls;assembly=XLabs.Forms");
        XamlTypeResolver service54 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver27, typeof (LoginHelpPage).GetTypeInfo().Assembly);
        xamlServiceProvider27.Add(type54, (object) service54);
        xamlServiceProvider27.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(140, 97)));
        object obj27 = ((IExtendedTypeConverter) fontSizeConverter12).ConvertFromInvariantString("13", (IServiceProvider) xamlServiceProvider27);
        span12.SetValue(fontSizeProperty12, obj27);
        bindable39.SetValue(Span.TextProperty, (object) "oneapp@sti.edu ");
        bindable41.Spans.Add(bindable39);
        bindable40.SetValue(Span.TextColorProperty, (object) new Color(0.400000005960464, 0.400000005960464, 0.400000005960464, 1.0));
        bindable40.SetValue(Span.FontFamilyProperty, (object) "Roboto-Regular.ttf#Roboto");
        Span span13 = bindable40;
        BindableProperty fontSizeProperty13 = Span.FontSizeProperty;
        FontSizeConverter fontSizeConverter13 = new FontSizeConverter();
        XamlServiceProvider xamlServiceProvider28 = new XamlServiceProvider();
        Type type55 = typeof (IProvideValueTarget);
        object[] objectAndParents28 = new object[0 + 7];
        objectAndParents28[0] = (object) bindable40;
        objectAndParents28[1] = (object) bindable41;
        objectAndParents28[2] = (object) bindable43;
        objectAndParents28[3] = (object) bindable44;
        objectAndParents28[4] = (object) bindable45;
        objectAndParents28[5] = (object) bindable46;
        objectAndParents28[6] = (object) bindable47;
        SimpleValueTargetProvider service55 = new SimpleValueTargetProvider(objectAndParents28, (object) Span.FontSizeProperty);
        xamlServiceProvider28.Add(type55, (object) service55);
        xamlServiceProvider28.Add(typeof (INameScopeProvider), (object) new NameScopeProvider()
        {
          NameScope = (INameScope) nameScope
        });
        Type type56 = typeof (IXamlTypeResolver);
        XmlNamespaceResolver namespaceResolver28 = new XmlNamespaceResolver();
        namespaceResolver28.Add("", "http://xamarin.com/schemas/2014/forms");
        namespaceResolver28.Add("x", "http://schemas.microsoft.com/winfx/2009/xaml");
        namespaceResolver28.Add("xlabs", "clr-namespace:XLabs.Forms.Controls;assembly=XLabs.Forms");
        XamlTypeResolver service56 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver28, typeof (LoginHelpPage).GetTypeInfo().Assembly);
        xamlServiceProvider28.Add(type56, (object) service56);
        xamlServiceProvider28.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(141, 98)));
        object obj28 = ((IExtendedTypeConverter) fontSizeConverter13).ConvertFromInvariantString("13", (IServiceProvider) xamlServiceProvider28);
        span13.SetValue(fontSizeProperty13, obj28);
        bindable40.SetValue(Span.TextProperty, (object) "and we'll be happy to assist you with your other concerns.");
        bindable41.Spans.Add(bindable40);
        bindable43.SetValue(Label.FormattedTextProperty, (object) bindable41);
        bindable42.Tapped += new EventHandler(bindable47.TapGestureRecognizer_Tapped_3);
        bindable43.GestureRecognizers.Add((IGestureRecognizer) bindable42);
        bindable44.Children.Add((View) bindable43);
        bindable45.Content = (View) bindable44;
        bindable46.Children.Add((View) bindable45);
        bindable47.SetValue(ContentPage.ContentProperty, (object) bindable46);
      }
    }

    private void __InitComponentRuntime() => this.LoadFromXaml<LoginHelpPage>(typeof (LoginHelpPage));
  }
}
