// Decompiled with JetBrains decompiler
// Type: one_sti_student_portal.Views.MissionVisionPage
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
  [XamlFilePath("Views\\MissionVisionPage.xaml")]
  public class MissionVisionPage : ContentPage
  {
    private bool blnShouldStay;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private StackLayout stackBody;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private StackLayout stackAboutMore;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private Label lblReadMore;

    public MissionVisionPage() => this.InitializeComponent();

    private void ReadMore_Tapped(object sender, EventArgs e)
    {
      this.stackAboutMore.IsVisible = !this.stackAboutMore.IsVisible;
      this.lblReadMore.Text = this.stackAboutMore.IsVisible ? "READ LESS" : "READ MORE";
    }

    protected override void OnAppearing()
    {
      base.OnAppearing();
      Device.StartTimer(TimeSpan.FromSeconds(1.0), (Func<bool>) (() =>
      {
        this.stackBody.FadeTo(1.0, 750U);
        return false;
      }));
    }

    private void DownloadAudio_Tapped(object sender, EventArgs e) => Device.OpenUri(new Uri("https://www.sti.edu/media/alma_mater_hymn.mp3"));

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
      if (ResourceLoader.ResourceProvider != null && ResourceLoader.ResourceProvider(typeof (MissionVisionPage).GetTypeInfo().Assembly.GetName(), "Views/MissionVisionPage.xaml") != null)
        this.__InitComponentRuntime();
      else if (Xamarin.Forms.Xaml.Internals.XamlLoader.XamlFileProvider != null && Xamarin.Forms.Xaml.Internals.XamlLoader.XamlFileProvider(this.GetType()) != null)
      {
        this.__InitComponentRuntime();
      }
      else
      {
        StaticResourceExtension resourceExtension1 = new StaticResourceExtension();
        Label bindable1 = new Label();
        BoxView bindable2 = new BoxView();
        StaticResourceExtension resourceExtension2 = new StaticResourceExtension();
        Label bindable3 = new Label();
        StaticResourceExtension resourceExtension3 = new StaticResourceExtension();
        Label bindable4 = new Label();
        Span bindable5 = new Span();
        Span bindable6 = new Span();
        Span bindable7 = new Span();
        FormattedString bindable8 = new FormattedString();
        Label bindable9 = new Label();
        StaticResourceExtension resourceExtension4 = new StaticResourceExtension();
        Label bindable10 = new Label();
        StaticResourceExtension resourceExtension5 = new StaticResourceExtension();
        Label bindable11 = new Label();
        StaticResourceExtension resourceExtension6 = new StaticResourceExtension();
        Label bindable12 = new Label();
        StaticResourceExtension resourceExtension7 = new StaticResourceExtension();
        Label bindable13 = new Label();
        StaticResourceExtension resourceExtension8 = new StaticResourceExtension();
        Label bindable14 = new Label();
        StaticResourceExtension resourceExtension9 = new StaticResourceExtension();
        Label bindable15 = new Label();
        StackLayout stackLayout1 = new StackLayout();
        BoxView bindable16 = new BoxView();
        StaticResourceExtension resourceExtension10 = new StaticResourceExtension();
        TapGestureRecognizer bindable17 = new TapGestureRecognizer();
        Label label1 = new Label();
        StackLayout bindable18 = new StackLayout();
        StackLayout bindable19 = new StackLayout();
        StackLayout bindable20 = new StackLayout();
        Frame bindable21 = new Frame();
        StaticResourceExtension resourceExtension11 = new StaticResourceExtension();
        Label bindable22 = new Label();
        BoxView bindable23 = new BoxView();
        BoxView bindable24 = new BoxView();
        StaticResourceExtension resourceExtension12 = new StaticResourceExtension();
        Label bindable25 = new Label();
        StaticResourceExtension resourceExtension13 = new StaticResourceExtension();
        Label bindable26 = new Label();
        StaticResourceExtension resourceExtension14 = new StaticResourceExtension();
        Label bindable27 = new Label();
        StackLayout bindable28 = new StackLayout();
        StackLayout bindable29 = new StackLayout();
        StackLayout bindable30 = new StackLayout();
        Frame bindable31 = new Frame();
        StaticResourceExtension resourceExtension15 = new StaticResourceExtension();
        Label bindable32 = new Label();
        BoxView bindable33 = new BoxView();
        BoxView bindable34 = new BoxView();
        StaticResourceExtension resourceExtension16 = new StaticResourceExtension();
        Label bindable35 = new Label();
        StackLayout bindable36 = new StackLayout();
        StackLayout bindable37 = new StackLayout();
        Frame bindable38 = new Frame();
        StaticResourceExtension resourceExtension17 = new StaticResourceExtension();
        Label bindable39 = new Label();
        StaticResourceExtension resourceExtension18 = new StaticResourceExtension();
        TapGestureRecognizer bindable40 = new TapGestureRecognizer();
        Label bindable41 = new Label();
        StackLayout bindable42 = new StackLayout();
        BoxView bindable43 = new BoxView();
        StaticResourceExtension resourceExtension19 = new StaticResourceExtension();
        Label bindable44 = new Label();
        StackLayout bindable45 = new StackLayout();
        Frame bindable46 = new Frame();
        StackLayout stackLayout2 = new StackLayout();
        ScrollView bindable47 = new ScrollView();
        MissionVisionPage bindable48 = this;
        NameScope nameScope = new NameScope();
        NameScope.SetNameScope((BindableObject) bindable48, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable47, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) stackLayout2, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("stackBody", (object) stackLayout2);
        if (stackLayout2.StyleId == null)
          stackLayout2.StyleId = "stackBody";
        NameScope.SetNameScope((BindableObject) bindable21, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable20, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable1, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable2, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable19, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable3, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable18, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable4, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable9, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable8, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable5, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable6, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable7, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable10, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) stackLayout1, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("stackAboutMore", (object) stackLayout1);
        if (stackLayout1.StyleId == null)
          stackLayout1.StyleId = "stackAboutMore";
        NameScope.SetNameScope((BindableObject) bindable11, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable12, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable13, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable14, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable15, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable16, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) label1, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("lblReadMore", (object) label1);
        if (label1.StyleId == null)
          label1.StyleId = "lblReadMore";
        NameScope.SetNameScope((BindableObject) bindable17, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable31, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable30, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable22, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable23, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable29, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable24, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable28, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable25, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable26, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable27, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable38, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable37, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable32, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable33, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable36, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable34, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable35, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable46, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable45, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable42, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable39, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable41, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable40, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable43, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable44, (INameScope) nameScope);
        this.stackBody = stackLayout2;
        this.stackAboutMore = stackLayout1;
        this.lblReadMore = label1;
        bindable48.SetValue(Page.TitleProperty, (object) "History, Mission and Vision");
        bindable47.SetValue(View.VerticalOptionsProperty, (object) LayoutOptions.FillAndExpand);
        stackLayout2.SetValue(View.MarginProperty, (object) new Thickness(5.0));
        stackLayout2.SetValue(VisualElement.OpacityProperty, (object) 0.0);
        stackLayout2.SetValue(View.VerticalOptionsProperty, (object) LayoutOptions.FillAndExpand);
        bindable21.SetValue(View.MarginProperty, (object) new Thickness(5.0));
        bindable21.SetValue(Frame.HasShadowProperty, (object) true);
        bindable21.SetValue(Layout.PaddingProperty, (object) new Thickness(20.0, 15.0, 20.0, 15.0));
        bindable20.SetValue(StackLayout.SpacingProperty, (object) 0.0);
        bindable1.SetValue(Label.TextProperty, (object) "STI History");
        resourceExtension1.Key = "normalHeader";
        StaticResourceExtension resourceExtension20 = resourceExtension1;
        XamlServiceProvider xamlServiceProvider1 = new XamlServiceProvider();
        Type type1 = typeof (IProvideValueTarget);
        object[] objectAndParents1 = new object[0 + 6];
        objectAndParents1[0] = (object) bindable1;
        objectAndParents1[1] = (object) bindable20;
        objectAndParents1[2] = (object) bindable21;
        objectAndParents1[3] = (object) stackLayout2;
        objectAndParents1[4] = (object) bindable47;
        objectAndParents1[5] = (object) bindable48;
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
        XamlTypeResolver service2 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver1, typeof (MissionVisionPage).GetTypeInfo().Assembly);
        xamlServiceProvider1.Add(type2, (object) service2);
        xamlServiceProvider1.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(14, 51)));
        object obj1 = resourceExtension20.ProvideValue((IServiceProvider) xamlServiceProvider1);
        bindable1.Style = (Style) obj1;
        bindable1.SetValue(Label.TextColorProperty, (object) new Color(0.250980406999588, 0.250980406999588, 0.250980406999588, 1.0));
        bindable1.SetValue(View.VerticalOptionsProperty, (object) LayoutOptions.Start);
        bindable1.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.FillAndExpand);
        bindable20.Children.Add((View) bindable1);
        bindable2.SetValue(BoxView.ColorProperty, (object) new Color(0.905882358551025, 0.752941191196442, 0.113725490868092, 1.0));
        bindable2.SetValue(VisualElement.HeightRequestProperty, (object) 1.5);
        bindable2.SetValue(View.MarginProperty, (object) new Thickness(0.0, 5.0, 0.0, 15.0));
        bindable2.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.FillAndExpand);
        bindable20.Children.Add((View) bindable2);
        bindable3.SetValue(Label.TextProperty, (object) "From its humble beginnings on August 21, 1983 as a computer training center with only two campuses, STI now has campuses all over the Philippines and has diversified into ICT-enhanced programs in Information Technology, Business and Management, Tourism and Hospitality Management, Engineering, and Arts and Sciences.");
        resourceExtension2.Key = "smallLabel";
        StaticResourceExtension resourceExtension21 = resourceExtension2;
        XamlServiceProvider xamlServiceProvider2 = new XamlServiceProvider();
        Type type3 = typeof (IProvideValueTarget);
        object[] objectAndParents2 = new object[0 + 7];
        objectAndParents2[0] = (object) bindable3;
        objectAndParents2[1] = (object) bindable19;
        objectAndParents2[2] = (object) bindable20;
        objectAndParents2[3] = (object) bindable21;
        objectAndParents2[4] = (object) stackLayout2;
        objectAndParents2[5] = (object) bindable47;
        objectAndParents2[6] = (object) bindable48;
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
        XamlTypeResolver service4 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver2, typeof (MissionVisionPage).GetTypeInfo().Assembly);
        xamlServiceProvider2.Add(type4, (object) service4);
        xamlServiceProvider2.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(22, 360)));
        object obj2 = resourceExtension21.ProvideValue((IServiceProvider) xamlServiceProvider2);
        bindable3.Style = (Style) obj2;
        Label label2 = bindable3;
        BindableProperty fontSizeProperty1 = Label.FontSizeProperty;
        FontSizeConverter fontSizeConverter1 = new FontSizeConverter();
        XamlServiceProvider xamlServiceProvider3 = new XamlServiceProvider();
        Type type5 = typeof (IProvideValueTarget);
        object[] objectAndParents3 = new object[0 + 7];
        objectAndParents3[0] = (object) bindable3;
        objectAndParents3[1] = (object) bindable19;
        objectAndParents3[2] = (object) bindable20;
        objectAndParents3[3] = (object) bindable21;
        objectAndParents3[4] = (object) stackLayout2;
        objectAndParents3[5] = (object) bindable47;
        objectAndParents3[6] = (object) bindable48;
        SimpleValueTargetProvider service5 = new SimpleValueTargetProvider(objectAndParents3, (object) Label.FontSizeProperty);
        xamlServiceProvider3.Add(type5, (object) service5);
        xamlServiceProvider3.Add(typeof (INameScopeProvider), (object) new NameScopeProvider()
        {
          NameScope = (INameScope) nameScope
        });
        Type type6 = typeof (IXamlTypeResolver);
        XmlNamespaceResolver namespaceResolver3 = new XmlNamespaceResolver();
        namespaceResolver3.Add("", "http://xamarin.com/schemas/2014/forms");
        namespaceResolver3.Add("x", "http://schemas.microsoft.com/winfx/2009/xaml");
        XamlTypeResolver service6 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver3, typeof (MissionVisionPage).GetTypeInfo().Assembly);
        xamlServiceProvider3.Add(type6, (object) service6);
        xamlServiceProvider3.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(22, 398)));
        object obj3 = ((IExtendedTypeConverter) fontSizeConverter1).ConvertFromInvariantString("15", (IServiceProvider) xamlServiceProvider3);
        label2.SetValue(fontSizeProperty1, obj3);
        bindable3.SetValue(Label.TextColorProperty, (object) new Color(0.0431372560560703, 0.341176480054855, 0.576470613479614, 1.0));
        bindable3.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.FillAndExpand);
        bindable19.Children.Add((View) bindable3);
        bindable18.SetValue(StackLayout.SpacingProperty, (object) 10.0);
        bindable18.SetValue(View.MarginProperty, (object) new Thickness(0.0, 10.0, 0.0, 0.0));
        bindable4.SetValue(Label.TextProperty, (object) "It all started when four visionaries conceptualized setting up a training center to fill very specific manpower needs.");
        resourceExtension3.Key = "smallLabel";
        StaticResourceExtension resourceExtension22 = resourceExtension3;
        XamlServiceProvider xamlServiceProvider4 = new XamlServiceProvider();
        Type type7 = typeof (IProvideValueTarget);
        object[] objectAndParents4 = new object[0 + 8];
        objectAndParents4[0] = (object) bindable4;
        objectAndParents4[1] = (object) bindable18;
        objectAndParents4[2] = (object) bindable19;
        objectAndParents4[3] = (object) bindable20;
        objectAndParents4[4] = (object) bindable21;
        objectAndParents4[5] = (object) stackLayout2;
        objectAndParents4[6] = (object) bindable47;
        objectAndParents4[7] = (object) bindable48;
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
        XamlTypeResolver service8 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver4, typeof (MissionVisionPage).GetTypeInfo().Assembly);
        xamlServiceProvider4.Add(type8, (object) service8);
        xamlServiceProvider4.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(25, 166)));
        object obj4 = resourceExtension22.ProvideValue((IServiceProvider) xamlServiceProvider4);
        bindable4.Style = (Style) obj4;
        Label label3 = bindable4;
        BindableProperty fontSizeProperty2 = Label.FontSizeProperty;
        FontSizeConverter fontSizeConverter2 = new FontSizeConverter();
        XamlServiceProvider xamlServiceProvider5 = new XamlServiceProvider();
        Type type9 = typeof (IProvideValueTarget);
        object[] objectAndParents5 = new object[0 + 8];
        objectAndParents5[0] = (object) bindable4;
        objectAndParents5[1] = (object) bindable18;
        objectAndParents5[2] = (object) bindable19;
        objectAndParents5[3] = (object) bindable20;
        objectAndParents5[4] = (object) bindable21;
        objectAndParents5[5] = (object) stackLayout2;
        objectAndParents5[6] = (object) bindable47;
        objectAndParents5[7] = (object) bindable48;
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
        XamlTypeResolver service10 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver5, typeof (MissionVisionPage).GetTypeInfo().Assembly);
        xamlServiceProvider5.Add(type10, (object) service10);
        xamlServiceProvider5.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(25, 203)));
        object obj5 = ((IExtendedTypeConverter) fontSizeConverter2).ConvertFromInvariantString("15", (IServiceProvider) xamlServiceProvider5);
        label3.SetValue(fontSizeProperty2, obj5);
        bindable4.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.FillAndExpand);
        bindable18.Children.Add((View) bindable4);
        bindable5.SetValue(Span.TextProperty, (object) "It was in the early '80s when ");
        Span span1 = bindable5;
        BindableProperty fontSizeProperty3 = Span.FontSizeProperty;
        FontSizeConverter fontSizeConverter3 = new FontSizeConverter();
        XamlServiceProvider xamlServiceProvider6 = new XamlServiceProvider();
        Type type11 = typeof (IProvideValueTarget);
        object[] objectAndParents6 = new object[0 + 10];
        objectAndParents6[0] = (object) bindable5;
        objectAndParents6[1] = (object) bindable8;
        objectAndParents6[2] = (object) bindable9;
        objectAndParents6[3] = (object) bindable18;
        objectAndParents6[4] = (object) bindable19;
        objectAndParents6[5] = (object) bindable20;
        objectAndParents6[6] = (object) bindable21;
        objectAndParents6[7] = (object) stackLayout2;
        objectAndParents6[8] = (object) bindable47;
        objectAndParents6[9] = (object) bindable48;
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
        XamlTypeResolver service12 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver6, typeof (MissionVisionPage).GetTypeInfo().Assembly);
        xamlServiceProvider6.Add(type12, (object) service12);
        xamlServiceProvider6.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(31, 89)));
        object obj6 = ((IExtendedTypeConverter) fontSizeConverter3).ConvertFromInvariantString("15", (IServiceProvider) xamlServiceProvider6);
        span1.SetValue(fontSizeProperty3, obj6);
        bindable5.SetValue(Span.FontFamilyProperty, (object) "Roboto-Regular.ttf#Roboto");
        bindable5.SetValue(Span.TextColorProperty, (object) new Color(0.250980406999588, 0.250980406999588, 0.250980406999588, 1.0));
        bindable8.Spans.Add(bindable5);
        bindable6.SetValue(Span.TextProperty, (object) "Augusto C. Lagman, Herman T. Gamboa, Benjamin A. Santos, and Edgar H. Sarte — ");
        Span span2 = bindable6;
        BindableProperty fontSizeProperty4 = Span.FontSizeProperty;
        FontSizeConverter fontSizeConverter4 = new FontSizeConverter();
        XamlServiceProvider xamlServiceProvider7 = new XamlServiceProvider();
        Type type13 = typeof (IProvideValueTarget);
        object[] objectAndParents7 = new object[0 + 10];
        objectAndParents7[0] = (object) bindable6;
        objectAndParents7[1] = (object) bindable8;
        objectAndParents7[2] = (object) bindable9;
        objectAndParents7[3] = (object) bindable18;
        objectAndParents7[4] = (object) bindable19;
        objectAndParents7[5] = (object) bindable20;
        objectAndParents7[6] = (object) bindable21;
        objectAndParents7[7] = (object) stackLayout2;
        objectAndParents7[8] = (object) bindable47;
        objectAndParents7[9] = (object) bindable48;
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
        XamlTypeResolver service14 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver7, typeof (MissionVisionPage).GetTypeInfo().Assembly);
        xamlServiceProvider7.Add(type14, (object) service14);
        xamlServiceProvider7.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(33, 137)));
        object obj7 = ((IExtendedTypeConverter) fontSizeConverter4).ConvertFromInvariantString("15", (IServiceProvider) xamlServiceProvider7);
        span2.SetValue(fontSizeProperty4, obj7);
        bindable6.SetValue(Span.FontFamilyProperty, (object) "Roboto-Medium.ttf#Roboto");
        bindable6.SetValue(Span.TextColorProperty, (object) new Color(0.250980406999588, 0.250980406999588, 0.250980406999588, 1.0));
        bindable8.Spans.Add(bindable6);
        bindable7.SetValue(Span.TextProperty, (object) "four entrepreneurs came together to set up Systems Technology Institute (STI), a training center that delivers basic programming education to professionals and students who want to learn this new skill.");
        Span span3 = bindable7;
        BindableProperty fontSizeProperty5 = Span.FontSizeProperty;
        FontSizeConverter fontSizeConverter5 = new FontSizeConverter();
        XamlServiceProvider xamlServiceProvider8 = new XamlServiceProvider();
        Type type15 = typeof (IProvideValueTarget);
        object[] objectAndParents8 = new object[0 + 10];
        objectAndParents8[0] = (object) bindable7;
        objectAndParents8[1] = (object) bindable8;
        objectAndParents8[2] = (object) bindable9;
        objectAndParents8[3] = (object) bindable18;
        objectAndParents8[4] = (object) bindable19;
        objectAndParents8[5] = (object) bindable20;
        objectAndParents8[6] = (object) bindable21;
        objectAndParents8[7] = (object) stackLayout2;
        objectAndParents8[8] = (object) bindable47;
        objectAndParents8[9] = (object) bindable48;
        SimpleValueTargetProvider service15 = new SimpleValueTargetProvider(objectAndParents8, (object) Span.FontSizeProperty);
        xamlServiceProvider8.Add(type15, (object) service15);
        xamlServiceProvider8.Add(typeof (INameScopeProvider), (object) new NameScopeProvider()
        {
          NameScope = (INameScope) nameScope
        });
        Type type16 = typeof (IXamlTypeResolver);
        XmlNamespaceResolver namespaceResolver8 = new XmlNamespaceResolver();
        namespaceResolver8.Add("", "http://xamarin.com/schemas/2014/forms");
        namespaceResolver8.Add("x", "http://schemas.microsoft.com/winfx/2009/xaml");
        XamlTypeResolver service16 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver8, typeof (MissionVisionPage).GetTypeInfo().Assembly);
        xamlServiceProvider8.Add(type16, (object) service16);
        xamlServiceProvider8.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(35, 261)));
        object obj8 = ((IExtendedTypeConverter) fontSizeConverter5).ConvertFromInvariantString("15", (IServiceProvider) xamlServiceProvider8);
        span3.SetValue(fontSizeProperty5, obj8);
        bindable7.SetValue(Span.FontFamilyProperty, (object) "Roboto-Regular.ttf#Roboto");
        bindable7.SetValue(Span.TextColorProperty, (object) new Color(0.250980406999588, 0.250980406999588, 0.250980406999588, 1.0));
        bindable8.Spans.Add(bindable7);
        bindable9.SetValue(Label.FormattedTextProperty, (object) bindable8);
        bindable18.Children.Add((View) bindable9);
        bindable10.SetValue(Label.TextProperty, (object) "Systems Technology Institute's name came from countless brainstorming sessions among the founders, perhaps from Sarte's penchant for three-letter acronyms from the companies he managed at the time.");
        resourceExtension4.Key = "smallLabel";
        StaticResourceExtension resourceExtension23 = resourceExtension4;
        XamlServiceProvider xamlServiceProvider9 = new XamlServiceProvider();
        Type type17 = typeof (IProvideValueTarget);
        object[] objectAndParents9 = new object[0 + 8];
        objectAndParents9[0] = (object) bindable10;
        objectAndParents9[1] = (object) bindable18;
        objectAndParents9[2] = (object) bindable19;
        objectAndParents9[3] = (object) bindable20;
        objectAndParents9[4] = (object) bindable21;
        objectAndParents9[5] = (object) stackLayout2;
        objectAndParents9[6] = (object) bindable47;
        objectAndParents9[7] = (object) bindable48;
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
        XamlTypeResolver service18 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver9, typeof (MissionVisionPage).GetTypeInfo().Assembly);
        xamlServiceProvider9.Add(type18, (object) service18);
        xamlServiceProvider9.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(41, 245)));
        object obj9 = resourceExtension23.ProvideValue((IServiceProvider) xamlServiceProvider9);
        bindable10.Style = (Style) obj9;
        Label label4 = bindable10;
        BindableProperty fontSizeProperty6 = Label.FontSizeProperty;
        FontSizeConverter fontSizeConverter6 = new FontSizeConverter();
        XamlServiceProvider xamlServiceProvider10 = new XamlServiceProvider();
        Type type19 = typeof (IProvideValueTarget);
        object[] objectAndParents10 = new object[0 + 8];
        objectAndParents10[0] = (object) bindable10;
        objectAndParents10[1] = (object) bindable18;
        objectAndParents10[2] = (object) bindable19;
        objectAndParents10[3] = (object) bindable20;
        objectAndParents10[4] = (object) bindable21;
        objectAndParents10[5] = (object) stackLayout2;
        objectAndParents10[6] = (object) bindable47;
        objectAndParents10[7] = (object) bindable48;
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
        XamlTypeResolver service20 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver10, typeof (MissionVisionPage).GetTypeInfo().Assembly);
        xamlServiceProvider10.Add(type20, (object) service20);
        xamlServiceProvider10.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(41, 283)));
        object obj10 = ((IExtendedTypeConverter) fontSizeConverter6).ConvertFromInvariantString("15", (IServiceProvider) xamlServiceProvider10);
        label4.SetValue(fontSizeProperty6, obj10);
        bindable10.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.FillAndExpand);
        bindable18.Children.Add((View) bindable10);
        stackLayout1.SetValue(VisualElement.IsVisibleProperty, new VisualElement.VisibilityConverter().ConvertFromInvariantString("False"));
        bindable11.SetValue(Label.TextProperty, (object) "The first two schools were inaugurated in August 21, 1983 in Buendia, Makati and in España, Manila, and offered basic computer programming courses. With a unique and superior product on their hands, it was not difficult to expand the franchise through the founders' business contacts. A year after the first two schools opened, the franchise grew to include STI Binondo, Cubao, and Taft.");
        resourceExtension5.Key = "smallLabel";
        StaticResourceExtension resourceExtension24 = resourceExtension5;
        XamlServiceProvider xamlServiceProvider11 = new XamlServiceProvider();
        Type type21 = typeof (IProvideValueTarget);
        object[] objectAndParents11 = new object[0 + 9];
        objectAndParents11[0] = (object) bindable11;
        objectAndParents11[1] = (object) stackLayout1;
        objectAndParents11[2] = (object) bindable18;
        objectAndParents11[3] = (object) bindable19;
        objectAndParents11[4] = (object) bindable20;
        objectAndParents11[5] = (object) bindable21;
        objectAndParents11[6] = (object) stackLayout2;
        objectAndParents11[7] = (object) bindable47;
        objectAndParents11[8] = (object) bindable48;
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
        XamlTypeResolver service22 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver11, typeof (MissionVisionPage).GetTypeInfo().Assembly);
        xamlServiceProvider11.Add(type22, (object) service22);
        xamlServiceProvider11.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(45, 439)));
        object obj11 = resourceExtension24.ProvideValue((IServiceProvider) xamlServiceProvider11);
        bindable11.Style = (Style) obj11;
        Label label5 = bindable11;
        BindableProperty fontSizeProperty7 = Label.FontSizeProperty;
        FontSizeConverter fontSizeConverter7 = new FontSizeConverter();
        XamlServiceProvider xamlServiceProvider12 = new XamlServiceProvider();
        Type type23 = typeof (IProvideValueTarget);
        object[] objectAndParents12 = new object[0 + 9];
        objectAndParents12[0] = (object) bindable11;
        objectAndParents12[1] = (object) stackLayout1;
        objectAndParents12[2] = (object) bindable18;
        objectAndParents12[3] = (object) bindable19;
        objectAndParents12[4] = (object) bindable20;
        objectAndParents12[5] = (object) bindable21;
        objectAndParents12[6] = (object) stackLayout2;
        objectAndParents12[7] = (object) bindable47;
        objectAndParents12[8] = (object) bindable48;
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
        XamlTypeResolver service24 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver12, typeof (MissionVisionPage).GetTypeInfo().Assembly);
        xamlServiceProvider12.Add(type24, (object) service24);
        xamlServiceProvider12.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(45, 477)));
        object obj12 = ((IExtendedTypeConverter) fontSizeConverter7).ConvertFromInvariantString("15", (IServiceProvider) xamlServiceProvider12);
        label5.SetValue(fontSizeProperty7, obj12);
        bindable11.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.FillAndExpand);
        stackLayout1.Children.Add((View) bindable11);
        bindable12.SetValue(Label.TextProperty, (object) "A unique value proposition spelled the difference for the STI brand then: \"First We'll Teach You, Then We'll Hire You.\" Through its unique Guaranteed Hire Program (GHP), all qualified graduates were offered jobs by one of the founders' companies, or through their contacts in the industry.");
        resourceExtension6.Key = "smallLabel";
        StaticResourceExtension resourceExtension25 = resourceExtension6;
        XamlServiceProvider xamlServiceProvider13 = new XamlServiceProvider();
        Type type25 = typeof (IProvideValueTarget);
        object[] objectAndParents13 = new object[0 + 9];
        objectAndParents13[0] = (object) bindable12;
        objectAndParents13[1] = (object) stackLayout1;
        objectAndParents13[2] = (object) bindable18;
        objectAndParents13[3] = (object) bindable19;
        objectAndParents13[4] = (object) bindable20;
        objectAndParents13[5] = (object) bindable21;
        objectAndParents13[6] = (object) stackLayout2;
        objectAndParents13[7] = (object) bindable47;
        objectAndParents13[8] = (object) bindable48;
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
        XamlTypeResolver service26 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver13, typeof (MissionVisionPage).GetTypeInfo().Assembly);
        xamlServiceProvider13.Add(type26, (object) service26);
        xamlServiceProvider13.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(47, 351)));
        object obj13 = resourceExtension25.ProvideValue((IServiceProvider) xamlServiceProvider13);
        bindable12.Style = (Style) obj13;
        Label label6 = bindable12;
        BindableProperty fontSizeProperty8 = Label.FontSizeProperty;
        FontSizeConverter fontSizeConverter8 = new FontSizeConverter();
        XamlServiceProvider xamlServiceProvider14 = new XamlServiceProvider();
        Type type27 = typeof (IProvideValueTarget);
        object[] objectAndParents14 = new object[0 + 9];
        objectAndParents14[0] = (object) bindable12;
        objectAndParents14[1] = (object) stackLayout1;
        objectAndParents14[2] = (object) bindable18;
        objectAndParents14[3] = (object) bindable19;
        objectAndParents14[4] = (object) bindable20;
        objectAndParents14[5] = (object) bindable21;
        objectAndParents14[6] = (object) stackLayout2;
        objectAndParents14[7] = (object) bindable47;
        objectAndParents14[8] = (object) bindable48;
        SimpleValueTargetProvider service27 = new SimpleValueTargetProvider(objectAndParents14, (object) Label.FontSizeProperty);
        xamlServiceProvider14.Add(type27, (object) service27);
        xamlServiceProvider14.Add(typeof (INameScopeProvider), (object) new NameScopeProvider()
        {
          NameScope = (INameScope) nameScope
        });
        Type type28 = typeof (IXamlTypeResolver);
        XmlNamespaceResolver namespaceResolver14 = new XmlNamespaceResolver();
        namespaceResolver14.Add("", "http://xamarin.com/schemas/2014/forms");
        namespaceResolver14.Add("x", "http://schemas.microsoft.com/winfx/2009/xaml");
        XamlTypeResolver service28 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver14, typeof (MissionVisionPage).GetTypeInfo().Assembly);
        xamlServiceProvider14.Add(type28, (object) service28);
        xamlServiceProvider14.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(47, 389)));
        object obj14 = ((IExtendedTypeConverter) fontSizeConverter8).ConvertFromInvariantString("15", (IServiceProvider) xamlServiceProvider14);
        label6.SetValue(fontSizeProperty8, obj14);
        bindable12.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.FillAndExpand);
        stackLayout1.Children.Add((View) bindable12);
        bindable13.SetValue(Label.TextProperty, (object) "The schools' 1st batch of graduates, all 11 of them, were hired by Systems Resources Incorporated. And through GHP, more qualified STI graduates found themselves working in their field of interest straight out of school.");
        resourceExtension7.Key = "smallLabel";
        StaticResourceExtension resourceExtension26 = resourceExtension7;
        XamlServiceProvider xamlServiceProvider15 = new XamlServiceProvider();
        Type type29 = typeof (IProvideValueTarget);
        object[] objectAndParents15 = new object[0 + 9];
        objectAndParents15[0] = (object) bindable13;
        objectAndParents15[1] = (object) stackLayout1;
        objectAndParents15[2] = (object) bindable18;
        objectAndParents15[3] = (object) bindable19;
        objectAndParents15[4] = (object) bindable20;
        objectAndParents15[5] = (object) bindable21;
        objectAndParents15[6] = (object) stackLayout2;
        objectAndParents15[7] = (object) bindable47;
        objectAndParents15[8] = (object) bindable48;
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
        XamlTypeResolver service30 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver15, typeof (MissionVisionPage).GetTypeInfo().Assembly);
        xamlServiceProvider15.Add(type30, (object) service30);
        xamlServiceProvider15.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(49, 272)));
        object obj15 = resourceExtension26.ProvideValue((IServiceProvider) xamlServiceProvider15);
        bindable13.Style = (Style) obj15;
        Label label7 = bindable13;
        BindableProperty fontSizeProperty9 = Label.FontSizeProperty;
        FontSizeConverter fontSizeConverter9 = new FontSizeConverter();
        XamlServiceProvider xamlServiceProvider16 = new XamlServiceProvider();
        Type type31 = typeof (IProvideValueTarget);
        object[] objectAndParents16 = new object[0 + 9];
        objectAndParents16[0] = (object) bindable13;
        objectAndParents16[1] = (object) stackLayout1;
        objectAndParents16[2] = (object) bindable18;
        objectAndParents16[3] = (object) bindable19;
        objectAndParents16[4] = (object) bindable20;
        objectAndParents16[5] = (object) bindable21;
        objectAndParents16[6] = (object) stackLayout2;
        objectAndParents16[7] = (object) bindable47;
        objectAndParents16[8] = (object) bindable48;
        SimpleValueTargetProvider service31 = new SimpleValueTargetProvider(objectAndParents16, (object) Label.FontSizeProperty);
        xamlServiceProvider16.Add(type31, (object) service31);
        xamlServiceProvider16.Add(typeof (INameScopeProvider), (object) new NameScopeProvider()
        {
          NameScope = (INameScope) nameScope
        });
        Type type32 = typeof (IXamlTypeResolver);
        XmlNamespaceResolver namespaceResolver16 = new XmlNamespaceResolver();
        namespaceResolver16.Add("", "http://xamarin.com/schemas/2014/forms");
        namespaceResolver16.Add("x", "http://schemas.microsoft.com/winfx/2009/xaml");
        XamlTypeResolver service32 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver16, typeof (MissionVisionPage).GetTypeInfo().Assembly);
        xamlServiceProvider16.Add(type32, (object) service32);
        xamlServiceProvider16.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(49, 310)));
        object obj16 = ((IExtendedTypeConverter) fontSizeConverter9).ConvertFromInvariantString("15", (IServiceProvider) xamlServiceProvider16);
        label7.SetValue(fontSizeProperty9, obj16);
        bindable13.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.FillAndExpand);
        stackLayout1.Children.Add((View) bindable13);
        bindable14.SetValue(Label.TextProperty, (object) "No one among the four founders imagined that the Systems Technology Institute would become a college, or would grow to have over 100 schools across the country. But it did, all because of its unique value proposition, the synergy between the founders and their personnel, and the management's faithfulness to quality.");
        resourceExtension8.Key = "smallLabel";
        StaticResourceExtension resourceExtension27 = resourceExtension8;
        XamlServiceProvider xamlServiceProvider17 = new XamlServiceProvider();
        Type type33 = typeof (IProvideValueTarget);
        object[] objectAndParents17 = new object[0 + 9];
        objectAndParents17[0] = (object) bindable14;
        objectAndParents17[1] = (object) stackLayout1;
        objectAndParents17[2] = (object) bindable18;
        objectAndParents17[3] = (object) bindable19;
        objectAndParents17[4] = (object) bindable20;
        objectAndParents17[5] = (object) bindable21;
        objectAndParents17[6] = (object) stackLayout2;
        objectAndParents17[7] = (object) bindable47;
        objectAndParents17[8] = (object) bindable48;
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
        XamlTypeResolver service34 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver17, typeof (MissionVisionPage).GetTypeInfo().Assembly);
        xamlServiceProvider17.Add(type34, (object) service34);
        xamlServiceProvider17.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(51, 369)));
        object obj17 = resourceExtension27.ProvideValue((IServiceProvider) xamlServiceProvider17);
        bindable14.Style = (Style) obj17;
        Label label8 = bindable14;
        BindableProperty fontSizeProperty10 = Label.FontSizeProperty;
        FontSizeConverter fontSizeConverter10 = new FontSizeConverter();
        XamlServiceProvider xamlServiceProvider18 = new XamlServiceProvider();
        Type type35 = typeof (IProvideValueTarget);
        object[] objectAndParents18 = new object[0 + 9];
        objectAndParents18[0] = (object) bindable14;
        objectAndParents18[1] = (object) stackLayout1;
        objectAndParents18[2] = (object) bindable18;
        objectAndParents18[3] = (object) bindable19;
        objectAndParents18[4] = (object) bindable20;
        objectAndParents18[5] = (object) bindable21;
        objectAndParents18[6] = (object) stackLayout2;
        objectAndParents18[7] = (object) bindable47;
        objectAndParents18[8] = (object) bindable48;
        SimpleValueTargetProvider service35 = new SimpleValueTargetProvider(objectAndParents18, (object) Label.FontSizeProperty);
        xamlServiceProvider18.Add(type35, (object) service35);
        xamlServiceProvider18.Add(typeof (INameScopeProvider), (object) new NameScopeProvider()
        {
          NameScope = (INameScope) nameScope
        });
        Type type36 = typeof (IXamlTypeResolver);
        XmlNamespaceResolver namespaceResolver18 = new XmlNamespaceResolver();
        namespaceResolver18.Add("", "http://xamarin.com/schemas/2014/forms");
        namespaceResolver18.Add("x", "http://schemas.microsoft.com/winfx/2009/xaml");
        XamlTypeResolver service36 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver18, typeof (MissionVisionPage).GetTypeInfo().Assembly);
        xamlServiceProvider18.Add(type36, (object) service36);
        xamlServiceProvider18.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(51, 407)));
        object obj18 = ((IExtendedTypeConverter) fontSizeConverter10).ConvertFromInvariantString("15", (IServiceProvider) xamlServiceProvider18);
        label8.SetValue(fontSizeProperty10, obj18);
        bindable14.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.FillAndExpand);
        stackLayout1.Children.Add((View) bindable14);
        bindable15.SetValue(Label.TextProperty, (object) "A long way since its birth, STI's thrust has permeated right into the core of the globally competitive market — it has transcended beyond ICT and beyond education, addressing the need for job-ready graduates.");
        resourceExtension9.Key = "smallLabel";
        StaticResourceExtension resourceExtension28 = resourceExtension9;
        XamlServiceProvider xamlServiceProvider19 = new XamlServiceProvider();
        Type type37 = typeof (IProvideValueTarget);
        object[] objectAndParents19 = new object[0 + 9];
        objectAndParents19[0] = (object) bindable15;
        objectAndParents19[1] = (object) stackLayout1;
        objectAndParents19[2] = (object) bindable18;
        objectAndParents19[3] = (object) bindable19;
        objectAndParents19[4] = (object) bindable20;
        objectAndParents19[5] = (object) bindable21;
        objectAndParents19[6] = (object) stackLayout2;
        objectAndParents19[7] = (object) bindable47;
        objectAndParents19[8] = (object) bindable48;
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
        XamlTypeResolver service38 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver19, typeof (MissionVisionPage).GetTypeInfo().Assembly);
        xamlServiceProvider19.Add(type38, (object) service38);
        xamlServiceProvider19.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(53, 260)));
        object obj19 = resourceExtension28.ProvideValue((IServiceProvider) xamlServiceProvider19);
        bindable15.Style = (Style) obj19;
        Label label9 = bindable15;
        BindableProperty fontSizeProperty11 = Label.FontSizeProperty;
        FontSizeConverter fontSizeConverter11 = new FontSizeConverter();
        XamlServiceProvider xamlServiceProvider20 = new XamlServiceProvider();
        Type type39 = typeof (IProvideValueTarget);
        object[] objectAndParents20 = new object[0 + 9];
        objectAndParents20[0] = (object) bindable15;
        objectAndParents20[1] = (object) stackLayout1;
        objectAndParents20[2] = (object) bindable18;
        objectAndParents20[3] = (object) bindable19;
        objectAndParents20[4] = (object) bindable20;
        objectAndParents20[5] = (object) bindable21;
        objectAndParents20[6] = (object) stackLayout2;
        objectAndParents20[7] = (object) bindable47;
        objectAndParents20[8] = (object) bindable48;
        SimpleValueTargetProvider service39 = new SimpleValueTargetProvider(objectAndParents20, (object) Label.FontSizeProperty);
        xamlServiceProvider20.Add(type39, (object) service39);
        xamlServiceProvider20.Add(typeof (INameScopeProvider), (object) new NameScopeProvider()
        {
          NameScope = (INameScope) nameScope
        });
        Type type40 = typeof (IXamlTypeResolver);
        XmlNamespaceResolver namespaceResolver20 = new XmlNamespaceResolver();
        namespaceResolver20.Add("", "http://xamarin.com/schemas/2014/forms");
        namespaceResolver20.Add("x", "http://schemas.microsoft.com/winfx/2009/xaml");
        XamlTypeResolver service40 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver20, typeof (MissionVisionPage).GetTypeInfo().Assembly);
        xamlServiceProvider20.Add(type40, (object) service40);
        xamlServiceProvider20.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(53, 298)));
        object obj20 = ((IExtendedTypeConverter) fontSizeConverter11).ConvertFromInvariantString("15", (IServiceProvider) xamlServiceProvider20);
        label9.SetValue(fontSizeProperty11, obj20);
        bindable15.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.FillAndExpand);
        stackLayout1.Children.Add((View) bindable15);
        bindable18.Children.Add((View) stackLayout1);
        bindable16.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.FillAndExpand);
        bindable16.SetValue(VisualElement.HeightRequestProperty, (object) 1.5);
        bindable16.SetValue(BoxView.ColorProperty, (object) new Color(0.894117653369904, 0.91372549533844, 0.929411768913269, 1.0));
        bindable18.Children.Add((View) bindable16);
        label1.SetValue(Label.TextProperty, (object) "READ MORE");
        label1.SetValue(View.MarginProperty, (object) new Thickness(0.0, 5.0, 0.0, 0.0));
        resourceExtension10.Key = "microHeader";
        StaticResourceExtension resourceExtension29 = resourceExtension10;
        XamlServiceProvider xamlServiceProvider21 = new XamlServiceProvider();
        Type type41 = typeof (IProvideValueTarget);
        object[] objectAndParents21 = new object[0 + 8];
        objectAndParents21[0] = (object) label1;
        objectAndParents21[1] = (object) bindable18;
        objectAndParents21[2] = (object) bindable19;
        objectAndParents21[3] = (object) bindable20;
        objectAndParents21[4] = (object) bindable21;
        objectAndParents21[5] = (object) stackLayout2;
        objectAndParents21[6] = (object) bindable47;
        objectAndParents21[7] = (object) bindable48;
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
        XamlTypeResolver service42 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver21, typeof (MissionVisionPage).GetTypeInfo().Assembly);
        xamlServiceProvider21.Add(type42, (object) service42);
        xamlServiceProvider21.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(58, 95)));
        object obj21 = resourceExtension29.ProvideValue((IServiceProvider) xamlServiceProvider21);
        label1.Style = (Style) obj21;
        label1.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.CenterAndExpand);
        bindable17.Tapped += new EventHandler(bindable48.ReadMore_Tapped);
        label1.GestureRecognizers.Add((IGestureRecognizer) bindable17);
        bindable18.Children.Add((View) label1);
        bindable19.Children.Add((View) bindable18);
        bindable20.Children.Add((View) bindable19);
        bindable21.SetValue(ContentView.ContentProperty, (object) bindable20);
        stackLayout2.Children.Add((View) bindable21);
        bindable31.SetValue(View.MarginProperty, (object) new Thickness(5.0));
        bindable31.SetValue(Frame.HasShadowProperty, (object) true);
        bindable31.SetValue(Layout.PaddingProperty, (object) new Thickness(20.0, 15.0, 20.0, 15.0));
        bindable30.SetValue(StackLayout.SpacingProperty, (object) 0.0);
        bindable22.SetValue(Label.TextProperty, (object) "Mission");
        resourceExtension11.Key = "normalHeader";
        StaticResourceExtension resourceExtension30 = resourceExtension11;
        XamlServiceProvider xamlServiceProvider22 = new XamlServiceProvider();
        Type type43 = typeof (IProvideValueTarget);
        object[] objectAndParents22 = new object[0 + 6];
        objectAndParents22[0] = (object) bindable22;
        objectAndParents22[1] = (object) bindable30;
        objectAndParents22[2] = (object) bindable31;
        objectAndParents22[3] = (object) stackLayout2;
        objectAndParents22[4] = (object) bindable47;
        objectAndParents22[5] = (object) bindable48;
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
        XamlTypeResolver service44 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver22, typeof (MissionVisionPage).GetTypeInfo().Assembly);
        xamlServiceProvider22.Add(type44, (object) service44);
        xamlServiceProvider22.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(76, 47)));
        object obj22 = resourceExtension30.ProvideValue((IServiceProvider) xamlServiceProvider22);
        bindable22.Style = (Style) obj22;
        bindable22.SetValue(Label.TextColorProperty, (object) new Color(0.250980406999588, 0.250980406999588, 0.250980406999588, 1.0));
        bindable22.SetValue(View.VerticalOptionsProperty, (object) LayoutOptions.Start);
        bindable22.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.FillAndExpand);
        bindable30.Children.Add((View) bindable22);
        bindable23.SetValue(BoxView.ColorProperty, (object) new Color(0.905882358551025, 0.752941191196442, 0.113725490868092, 1.0));
        bindable23.SetValue(VisualElement.HeightRequestProperty, (object) 1.5);
        bindable23.SetValue(View.MarginProperty, (object) new Thickness(0.0, 5.0, 0.0, 15.0));
        bindable23.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.FillAndExpand);
        bindable30.Children.Add((View) bindable23);
        bindable29.SetValue(StackLayout.OrientationProperty, (object) StackOrientation.Horizontal);
        bindable24.SetValue(View.VerticalOptionsProperty, (object) LayoutOptions.FillAndExpand);
        bindable24.SetValue(VisualElement.WidthRequestProperty, (object) 5.0);
        bindable24.SetValue(BoxView.ColorProperty, (object) new Color(0.894117653369904, 0.91372549533844, 0.929411768913269, 1.0));
        bindable29.Children.Add((View) bindable24);
        bindable28.SetValue(StackLayout.SpacingProperty, (object) 10.0);
        bindable28.SetValue(View.MarginProperty, (object) new Thickness(8.0, 0.0, 0.0, 0.0));
        bindable25.SetValue(Label.TextProperty, (object) "We are an institution committed to provide knowledge through the development and delivery of superior learning systems.");
        resourceExtension12.Key = "smallLabel";
        StaticResourceExtension resourceExtension31 = resourceExtension12;
        XamlServiceProvider xamlServiceProvider23 = new XamlServiceProvider();
        Type type45 = typeof (IProvideValueTarget);
        object[] objectAndParents23 = new object[0 + 8];
        objectAndParents23[0] = (object) bindable25;
        objectAndParents23[1] = (object) bindable28;
        objectAndParents23[2] = (object) bindable29;
        objectAndParents23[3] = (object) bindable30;
        objectAndParents23[4] = (object) bindable31;
        objectAndParents23[5] = (object) stackLayout2;
        objectAndParents23[6] = (object) bindable47;
        objectAndParents23[7] = (object) bindable48;
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
        XamlTypeResolver service46 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver23, typeof (MissionVisionPage).GetTypeInfo().Assembly);
        xamlServiceProvider23.Add(type46, (object) service46);
        xamlServiceProvider23.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(86, 167)));
        object obj23 = resourceExtension31.ProvideValue((IServiceProvider) xamlServiceProvider23);
        bindable25.Style = (Style) obj23;
        Label label10 = bindable25;
        BindableProperty fontSizeProperty12 = Label.FontSizeProperty;
        FontSizeConverter fontSizeConverter12 = new FontSizeConverter();
        XamlServiceProvider xamlServiceProvider24 = new XamlServiceProvider();
        Type type47 = typeof (IProvideValueTarget);
        object[] objectAndParents24 = new object[0 + 8];
        objectAndParents24[0] = (object) bindable25;
        objectAndParents24[1] = (object) bindable28;
        objectAndParents24[2] = (object) bindable29;
        objectAndParents24[3] = (object) bindable30;
        objectAndParents24[4] = (object) bindable31;
        objectAndParents24[5] = (object) stackLayout2;
        objectAndParents24[6] = (object) bindable47;
        objectAndParents24[7] = (object) bindable48;
        SimpleValueTargetProvider service47 = new SimpleValueTargetProvider(objectAndParents24, (object) Label.FontSizeProperty);
        xamlServiceProvider24.Add(type47, (object) service47);
        xamlServiceProvider24.Add(typeof (INameScopeProvider), (object) new NameScopeProvider()
        {
          NameScope = (INameScope) nameScope
        });
        Type type48 = typeof (IXamlTypeResolver);
        XmlNamespaceResolver namespaceResolver24 = new XmlNamespaceResolver();
        namespaceResolver24.Add("", "http://xamarin.com/schemas/2014/forms");
        namespaceResolver24.Add("x", "http://schemas.microsoft.com/winfx/2009/xaml");
        XamlTypeResolver service48 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver24, typeof (MissionVisionPage).GetTypeInfo().Assembly);
        xamlServiceProvider24.Add(type48, (object) service48);
        xamlServiceProvider24.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(86, 204)));
        object obj24 = ((IExtendedTypeConverter) fontSizeConverter12).ConvertFromInvariantString("15", (IServiceProvider) xamlServiceProvider24);
        label10.SetValue(fontSizeProperty12, obj24);
        bindable25.SetValue(Label.TextColorProperty, (object) new Color(0.400000005960464, 0.400000005960464, 0.400000005960464, 1.0));
        bindable25.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.FillAndExpand);
        bindable25.SetValue(Label.FontFamilyProperty, (object) "Roboto-Italic.ttf#Roboto");
        bindable28.Children.Add((View) bindable25);
        bindable26.SetValue(Label.TextProperty, (object) "We strive to provide optimum value to all our stakeholders – our students, our faculty members, our employees, our partners, our shareholders, and our community.");
        resourceExtension13.Key = "smallLabel";
        StaticResourceExtension resourceExtension32 = resourceExtension13;
        XamlServiceProvider xamlServiceProvider25 = new XamlServiceProvider();
        Type type49 = typeof (IProvideValueTarget);
        object[] objectAndParents25 = new object[0 + 8];
        objectAndParents25[0] = (object) bindable26;
        objectAndParents25[1] = (object) bindable28;
        objectAndParents25[2] = (object) bindable29;
        objectAndParents25[3] = (object) bindable30;
        objectAndParents25[4] = (object) bindable31;
        objectAndParents25[5] = (object) stackLayout2;
        objectAndParents25[6] = (object) bindable47;
        objectAndParents25[7] = (object) bindable48;
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
        XamlTypeResolver service50 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver25, typeof (MissionVisionPage).GetTypeInfo().Assembly);
        xamlServiceProvider25.Add(type50, (object) service50);
        xamlServiceProvider25.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(88, 209)));
        object obj25 = resourceExtension32.ProvideValue((IServiceProvider) xamlServiceProvider25);
        bindable26.Style = (Style) obj25;
        Label label11 = bindable26;
        BindableProperty fontSizeProperty13 = Label.FontSizeProperty;
        FontSizeConverter fontSizeConverter13 = new FontSizeConverter();
        XamlServiceProvider xamlServiceProvider26 = new XamlServiceProvider();
        Type type51 = typeof (IProvideValueTarget);
        object[] objectAndParents26 = new object[0 + 8];
        objectAndParents26[0] = (object) bindable26;
        objectAndParents26[1] = (object) bindable28;
        objectAndParents26[2] = (object) bindable29;
        objectAndParents26[3] = (object) bindable30;
        objectAndParents26[4] = (object) bindable31;
        objectAndParents26[5] = (object) stackLayout2;
        objectAndParents26[6] = (object) bindable47;
        objectAndParents26[7] = (object) bindable48;
        SimpleValueTargetProvider service51 = new SimpleValueTargetProvider(objectAndParents26, (object) Label.FontSizeProperty);
        xamlServiceProvider26.Add(type51, (object) service51);
        xamlServiceProvider26.Add(typeof (INameScopeProvider), (object) new NameScopeProvider()
        {
          NameScope = (INameScope) nameScope
        });
        Type type52 = typeof (IXamlTypeResolver);
        XmlNamespaceResolver namespaceResolver26 = new XmlNamespaceResolver();
        namespaceResolver26.Add("", "http://xamarin.com/schemas/2014/forms");
        namespaceResolver26.Add("x", "http://schemas.microsoft.com/winfx/2009/xaml");
        XamlTypeResolver service52 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver26, typeof (MissionVisionPage).GetTypeInfo().Assembly);
        xamlServiceProvider26.Add(type52, (object) service52);
        xamlServiceProvider26.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(88, 247)));
        object obj26 = ((IExtendedTypeConverter) fontSizeConverter13).ConvertFromInvariantString("15", (IServiceProvider) xamlServiceProvider26);
        label11.SetValue(fontSizeProperty13, obj26);
        bindable26.SetValue(Label.TextColorProperty, (object) new Color(0.400000005960464, 0.400000005960464, 0.400000005960464, 1.0));
        bindable26.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.FillAndExpand);
        bindable26.SetValue(Label.FontFamilyProperty, (object) "Roboto-Italic.ttf#Roboto");
        bindable28.Children.Add((View) bindable26);
        bindable27.SetValue(Label.TextProperty, (object) "We will pursue this mission with utmost integrity, dedication, transparency, and creativity.");
        resourceExtension14.Key = "smallLabel";
        StaticResourceExtension resourceExtension33 = resourceExtension14;
        XamlServiceProvider xamlServiceProvider27 = new XamlServiceProvider();
        Type type53 = typeof (IProvideValueTarget);
        object[] objectAndParents27 = new object[0 + 8];
        objectAndParents27[0] = (object) bindable27;
        objectAndParents27[1] = (object) bindable28;
        objectAndParents27[2] = (object) bindable29;
        objectAndParents27[3] = (object) bindable30;
        objectAndParents27[4] = (object) bindable31;
        objectAndParents27[5] = (object) stackLayout2;
        objectAndParents27[6] = (object) bindable47;
        objectAndParents27[7] = (object) bindable48;
        SimpleValueTargetProvider service53 = new SimpleValueTargetProvider(objectAndParents27, (object) VisualElement.StyleProperty);
        xamlServiceProvider27.Add(type53, (object) service53);
        xamlServiceProvider27.Add(typeof (INameScopeProvider), (object) new NameScopeProvider()
        {
          NameScope = (INameScope) nameScope
        });
        Type type54 = typeof (IXamlTypeResolver);
        XmlNamespaceResolver namespaceResolver27 = new XmlNamespaceResolver();
        namespaceResolver27.Add("", "http://xamarin.com/schemas/2014/forms");
        namespaceResolver27.Add("x", "http://schemas.microsoft.com/winfx/2009/xaml");
        XamlTypeResolver service54 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver27, typeof (MissionVisionPage).GetTypeInfo().Assembly);
        xamlServiceProvider27.Add(type54, (object) service54);
        xamlServiceProvider27.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(90, 140)));
        object obj27 = resourceExtension33.ProvideValue((IServiceProvider) xamlServiceProvider27);
        bindable27.Style = (Style) obj27;
        Label label12 = bindable27;
        BindableProperty fontSizeProperty14 = Label.FontSizeProperty;
        FontSizeConverter fontSizeConverter14 = new FontSizeConverter();
        XamlServiceProvider xamlServiceProvider28 = new XamlServiceProvider();
        Type type55 = typeof (IProvideValueTarget);
        object[] objectAndParents28 = new object[0 + 8];
        objectAndParents28[0] = (object) bindable27;
        objectAndParents28[1] = (object) bindable28;
        objectAndParents28[2] = (object) bindable29;
        objectAndParents28[3] = (object) bindable30;
        objectAndParents28[4] = (object) bindable31;
        objectAndParents28[5] = (object) stackLayout2;
        objectAndParents28[6] = (object) bindable47;
        objectAndParents28[7] = (object) bindable48;
        SimpleValueTargetProvider service55 = new SimpleValueTargetProvider(objectAndParents28, (object) Label.FontSizeProperty);
        xamlServiceProvider28.Add(type55, (object) service55);
        xamlServiceProvider28.Add(typeof (INameScopeProvider), (object) new NameScopeProvider()
        {
          NameScope = (INameScope) nameScope
        });
        Type type56 = typeof (IXamlTypeResolver);
        XmlNamespaceResolver namespaceResolver28 = new XmlNamespaceResolver();
        namespaceResolver28.Add("", "http://xamarin.com/schemas/2014/forms");
        namespaceResolver28.Add("x", "http://schemas.microsoft.com/winfx/2009/xaml");
        XamlTypeResolver service56 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver28, typeof (MissionVisionPage).GetTypeInfo().Assembly);
        xamlServiceProvider28.Add(type56, (object) service56);
        xamlServiceProvider28.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(90, 178)));
        object obj28 = ((IExtendedTypeConverter) fontSizeConverter14).ConvertFromInvariantString("15", (IServiceProvider) xamlServiceProvider28);
        label12.SetValue(fontSizeProperty14, obj28);
        bindable27.SetValue(Label.TextColorProperty, (object) new Color(0.400000005960464, 0.400000005960464, 0.400000005960464, 1.0));
        bindable27.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.FillAndExpand);
        bindable27.SetValue(Label.FontFamilyProperty, (object) "Roboto-Italic.ttf#Roboto");
        bindable28.Children.Add((View) bindable27);
        bindable29.Children.Add((View) bindable28);
        bindable30.Children.Add((View) bindable29);
        bindable31.SetValue(ContentView.ContentProperty, (object) bindable30);
        stackLayout2.Children.Add((View) bindable31);
        bindable38.SetValue(View.MarginProperty, (object) new Thickness(5.0));
        bindable38.SetValue(Frame.HasShadowProperty, (object) true);
        bindable38.SetValue(Layout.PaddingProperty, (object) new Thickness(20.0, 15.0, 20.0, 15.0));
        bindable37.SetValue(StackLayout.SpacingProperty, (object) 0.0);
        bindable32.SetValue(Label.TextProperty, (object) "Vision");
        resourceExtension15.Key = "normalHeader";
        StaticResourceExtension resourceExtension34 = resourceExtension15;
        XamlServiceProvider xamlServiceProvider29 = new XamlServiceProvider();
        Type type57 = typeof (IProvideValueTarget);
        object[] objectAndParents29 = new object[0 + 6];
        objectAndParents29[0] = (object) bindable32;
        objectAndParents29[1] = (object) bindable37;
        objectAndParents29[2] = (object) bindable38;
        objectAndParents29[3] = (object) stackLayout2;
        objectAndParents29[4] = (object) bindable47;
        objectAndParents29[5] = (object) bindable48;
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
        XamlTypeResolver service58 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver29, typeof (MissionVisionPage).GetTypeInfo().Assembly);
        xamlServiceProvider29.Add(type58, (object) service58);
        xamlServiceProvider29.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(103, 46)));
        object obj29 = resourceExtension34.ProvideValue((IServiceProvider) xamlServiceProvider29);
        bindable32.Style = (Style) obj29;
        bindable32.SetValue(Label.TextColorProperty, (object) new Color(0.250980406999588, 0.250980406999588, 0.250980406999588, 1.0));
        bindable32.SetValue(View.VerticalOptionsProperty, (object) LayoutOptions.Start);
        bindable32.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.FillAndExpand);
        bindable37.Children.Add((View) bindable32);
        bindable33.SetValue(BoxView.ColorProperty, (object) new Color(0.905882358551025, 0.752941191196442, 0.113725490868092, 1.0));
        bindable33.SetValue(VisualElement.HeightRequestProperty, (object) 1.5);
        bindable33.SetValue(View.MarginProperty, (object) new Thickness(0.0, 5.0, 0.0, 15.0));
        bindable33.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.FillAndExpand);
        bindable37.Children.Add((View) bindable33);
        bindable36.SetValue(StackLayout.OrientationProperty, (object) StackOrientation.Horizontal);
        bindable34.SetValue(View.VerticalOptionsProperty, (object) LayoutOptions.FillAndExpand);
        bindable34.SetValue(VisualElement.WidthRequestProperty, (object) 5.0);
        bindable34.SetValue(BoxView.ColorProperty, (object) new Color(0.894117653369904, 0.91372549533844, 0.929411768913269, 1.0));
        bindable36.Children.Add((View) bindable34);
        bindable35.SetValue(View.MarginProperty, (object) new Thickness(8.0, 0.0, 0.0, 0.0));
        bindable35.SetValue(Label.TextProperty, (object) "To be the leader in innovative and relevant education that nurtures individuals to become competent and responsible members of society.");
        resourceExtension16.Key = "smallLabel";
        StaticResourceExtension resourceExtension35 = resourceExtension16;
        XamlServiceProvider xamlServiceProvider30 = new XamlServiceProvider();
        Type type59 = typeof (IProvideValueTarget);
        object[] objectAndParents30 = new object[0 + 7];
        objectAndParents30[0] = (object) bindable35;
        objectAndParents30[1] = (object) bindable36;
        objectAndParents30[2] = (object) bindable37;
        objectAndParents30[3] = (object) bindable38;
        objectAndParents30[4] = (object) stackLayout2;
        objectAndParents30[5] = (object) bindable47;
        objectAndParents30[6] = (object) bindable48;
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
        XamlTypeResolver service60 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver30, typeof (MissionVisionPage).GetTypeInfo().Assembly);
        xamlServiceProvider30.Add(type60, (object) service60);
        xamlServiceProvider30.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(111, 196)));
        object obj30 = resourceExtension35.ProvideValue((IServiceProvider) xamlServiceProvider30);
        bindable35.Style = (Style) obj30;
        Label label13 = bindable35;
        BindableProperty fontSizeProperty15 = Label.FontSizeProperty;
        FontSizeConverter fontSizeConverter15 = new FontSizeConverter();
        XamlServiceProvider xamlServiceProvider31 = new XamlServiceProvider();
        Type type61 = typeof (IProvideValueTarget);
        object[] objectAndParents31 = new object[0 + 7];
        objectAndParents31[0] = (object) bindable35;
        objectAndParents31[1] = (object) bindable36;
        objectAndParents31[2] = (object) bindable37;
        objectAndParents31[3] = (object) bindable38;
        objectAndParents31[4] = (object) stackLayout2;
        objectAndParents31[5] = (object) bindable47;
        objectAndParents31[6] = (object) bindable48;
        SimpleValueTargetProvider service61 = new SimpleValueTargetProvider(objectAndParents31, (object) Label.FontSizeProperty);
        xamlServiceProvider31.Add(type61, (object) service61);
        xamlServiceProvider31.Add(typeof (INameScopeProvider), (object) new NameScopeProvider()
        {
          NameScope = (INameScope) nameScope
        });
        Type type62 = typeof (IXamlTypeResolver);
        XmlNamespaceResolver namespaceResolver31 = new XmlNamespaceResolver();
        namespaceResolver31.Add("", "http://xamarin.com/schemas/2014/forms");
        namespaceResolver31.Add("x", "http://schemas.microsoft.com/winfx/2009/xaml");
        XamlTypeResolver service62 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver31, typeof (MissionVisionPage).GetTypeInfo().Assembly);
        xamlServiceProvider31.Add(type62, (object) service62);
        xamlServiceProvider31.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(111, 234)));
        object obj31 = ((IExtendedTypeConverter) fontSizeConverter15).ConvertFromInvariantString("15", (IServiceProvider) xamlServiceProvider31);
        label13.SetValue(fontSizeProperty15, obj31);
        bindable35.SetValue(Label.TextColorProperty, (object) new Color(0.400000005960464, 0.400000005960464, 0.400000005960464, 1.0));
        bindable35.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.FillAndExpand);
        bindable35.SetValue(Label.FontFamilyProperty, (object) "Roboto-Italic.ttf#Roboto");
        bindable36.Children.Add((View) bindable35);
        bindable37.Children.Add((View) bindable36);
        bindable38.SetValue(ContentView.ContentProperty, (object) bindable37);
        stackLayout2.Children.Add((View) bindable38);
        bindable46.SetValue(View.MarginProperty, (object) new Thickness(5.0, 5.0, 5.0, 10.0));
        bindable46.SetValue(Frame.HasShadowProperty, (object) true);
        bindable46.SetValue(Layout.PaddingProperty, (object) new Thickness(20.0, 15.0, 20.0, 15.0));
        bindable45.SetValue(StackLayout.SpacingProperty, (object) 0.0);
        bindable42.SetValue(StackLayout.OrientationProperty, (object) StackOrientation.Horizontal);
        bindable39.SetValue(Label.TextProperty, (object) "STI Hymn");
        resourceExtension17.Key = "normalHeader";
        StaticResourceExtension resourceExtension36 = resourceExtension17;
        XamlServiceProvider xamlServiceProvider32 = new XamlServiceProvider();
        Type type63 = typeof (IProvideValueTarget);
        object[] objectAndParents32 = new object[0 + 7];
        objectAndParents32[0] = (object) bindable39;
        objectAndParents32[1] = (object) bindable42;
        objectAndParents32[2] = (object) bindable45;
        objectAndParents32[3] = (object) bindable46;
        objectAndParents32[4] = (object) stackLayout2;
        objectAndParents32[5] = (object) bindable47;
        objectAndParents32[6] = (object) bindable48;
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
        XamlTypeResolver service64 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver32, typeof (MissionVisionPage).GetTypeInfo().Assembly);
        xamlServiceProvider32.Add(type64, (object) service64);
        xamlServiceProvider32.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(123, 52)));
        object obj32 = resourceExtension36.ProvideValue((IServiceProvider) xamlServiceProvider32);
        bindable39.Style = (Style) obj32;
        bindable39.SetValue(Label.TextColorProperty, (object) new Color(0.250980406999588, 0.250980406999588, 0.250980406999588, 1.0));
        bindable39.SetValue(View.VerticalOptionsProperty, (object) LayoutOptions.Start);
        bindable39.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.FillAndExpand);
        bindable42.Children.Add((View) bindable39);
        bindable41.SetValue(Label.TextProperty, (object) "DOWNLOAD AUDIO");
        resourceExtension18.Key = "microHeader";
        StaticResourceExtension resourceExtension37 = resourceExtension18;
        XamlServiceProvider xamlServiceProvider33 = new XamlServiceProvider();
        Type type65 = typeof (IProvideValueTarget);
        object[] objectAndParents33 = new object[0 + 7];
        objectAndParents33[0] = (object) bindable41;
        objectAndParents33[1] = (object) bindable42;
        objectAndParents33[2] = (object) bindable45;
        objectAndParents33[3] = (object) bindable46;
        objectAndParents33[4] = (object) stackLayout2;
        objectAndParents33[5] = (object) bindable47;
        objectAndParents33[6] = (object) bindable48;
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
        XamlTypeResolver service66 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver33, typeof (MissionVisionPage).GetTypeInfo().Assembly);
        xamlServiceProvider33.Add(type66, (object) service66);
        xamlServiceProvider33.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(124, 58)));
        object obj33 = resourceExtension37.ProvideValue((IServiceProvider) xamlServiceProvider33);
        bindable41.Style = (Style) obj33;
        bindable41.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.End);
        bindable41.SetValue(View.VerticalOptionsProperty, (object) LayoutOptions.Center);
        bindable40.Tapped += new EventHandler(bindable48.DownloadAudio_Tapped);
        bindable41.GestureRecognizers.Add((IGestureRecognizer) bindable40);
        bindable42.Children.Add((View) bindable41);
        bindable45.Children.Add((View) bindable42);
        bindable43.SetValue(BoxView.ColorProperty, (object) new Color(0.905882358551025, 0.752941191196442, 0.113725490868092, 1.0));
        bindable43.SetValue(VisualElement.HeightRequestProperty, (object) 1.5);
        bindable43.SetValue(View.MarginProperty, (object) new Thickness(0.0, 5.0, 0.0, 15.0));
        bindable43.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.FillAndExpand);
        bindable45.Children.Add((View) bindable43);
        bindable44.SetValue(View.MarginProperty, (object) new Thickness(8.0, 0.0, 0.0, 0.0));
        bindable44.SetValue(Label.TextProperty, (object) "Aim high with STI\nThe future is here today\nFly high with STI\nBe the best that you can be\nOnward to tomorrow\nWith dignity and pride\nA vision of excellence\nOur resounding battle cry\nAim high with STI\nThe future is here today\nFly high with STI\nBe the best that you can be");
        resourceExtension19.Key = "smallLabel";
        StaticResourceExtension resourceExtension38 = resourceExtension19;
        XamlServiceProvider xamlServiceProvider34 = new XamlServiceProvider();
        Type type67 = typeof (IProvideValueTarget);
        object[] objectAndParents34 = new object[0 + 6];
        objectAndParents34[0] = (object) bindable44;
        objectAndParents34[1] = (object) bindable45;
        objectAndParents34[2] = (object) bindable46;
        objectAndParents34[3] = (object) stackLayout2;
        objectAndParents34[4] = (object) bindable47;
        objectAndParents34[5] = (object) bindable48;
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
        XamlTypeResolver service68 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver34, typeof (MissionVisionPage).GetTypeInfo().Assembly);
        xamlServiceProvider34.Add(type68, (object) service68);
        xamlServiceProvider34.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(136, 36)));
        object obj34 = resourceExtension38.ProvideValue((IServiceProvider) xamlServiceProvider34);
        bindable44.Style = (Style) obj34;
        Label label14 = bindable44;
        BindableProperty fontSizeProperty16 = Label.FontSizeProperty;
        FontSizeConverter fontSizeConverter16 = new FontSizeConverter();
        XamlServiceProvider xamlServiceProvider35 = new XamlServiceProvider();
        Type type69 = typeof (IProvideValueTarget);
        object[] objectAndParents35 = new object[0 + 6];
        objectAndParents35[0] = (object) bindable44;
        objectAndParents35[1] = (object) bindable45;
        objectAndParents35[2] = (object) bindable46;
        objectAndParents35[3] = (object) stackLayout2;
        objectAndParents35[4] = (object) bindable47;
        objectAndParents35[5] = (object) bindable48;
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
        XamlTypeResolver service70 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver35, typeof (MissionVisionPage).GetTypeInfo().Assembly);
        xamlServiceProvider35.Add(type70, (object) service70);
        xamlServiceProvider35.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(136, 74)));
        object obj35 = ((IExtendedTypeConverter) fontSizeConverter16).ConvertFromInvariantString("15", (IServiceProvider) xamlServiceProvider35);
        label14.SetValue(fontSizeProperty16, obj35);
        bindable44.SetValue(Label.TextColorProperty, (object) new Color(0.250980406999588, 0.250980406999588, 0.250980406999588, 1.0));
        bindable44.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.FillAndExpand);
        bindable45.Children.Add((View) bindable44);
        bindable46.SetValue(ContentView.ContentProperty, (object) bindable45);
        stackLayout2.Children.Add((View) bindable46);
        bindable47.Content = (View) stackLayout2;
        bindable48.SetValue(ContentPage.ContentProperty, (object) bindable47);
      }
    }

    private void __InitComponentRuntime()
    {
      this.LoadFromXaml<MissionVisionPage>(typeof (MissionVisionPage));
      this.stackBody = NameScopeExtensions.FindByName<StackLayout>(this, "stackBody");
      this.stackAboutMore = NameScopeExtensions.FindByName<StackLayout>(this, "stackAboutMore");
      this.lblReadMore = NameScopeExtensions.FindByName<Label>(this, "lblReadMore");
    }
  }
}
