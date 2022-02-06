// Decompiled with JetBrains decompiler
// Type: one_sti_student_portal.Views.Students.CurriculumDetailsPage
// Assembly: one_sti_student_portal, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 39E34984-485E-45CE-9895-F7524E3024D6
// Assembly location: \\wsl.localhost\kali-linux\root\One STI Student Portal_1.3.8_apkcombo.com (1)\unknown\assemblies\one_sti_student_portal.dll

using one_sti_student_portal.Data;
using one_sti_student_portal.Models;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Reflection;
using System.Xml;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.Xaml.Internals;

namespace one_sti_student_portal.Views.Students
{
  [XamlFilePath("Views\\Students\\CurriculumDetailsPage.xaml")]
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public class CurriculumDetailsPage : ContentPage
  {
    private StudentData _studentData;
    private string _requirementGroup;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private Label lblCurriculum;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private Span lblRequired;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private Span lblTaken;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private Span lblNeeded;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private Label lblDescription;

    public CurriculumDetailsPage(string requirementGroup)
    {
      this.InitializeComponent();
      this._studentData = new StudentData();
      this._requirementGroup = requirementGroup;
      this.LoadCurriculumDetails();
      StudentViewTabbedPage.selectedTabIndex = 2;
    }

    private void LoadCurriculumDetails()
    {
      using (List<StudentChecklist>.Enumerator enumerator = this._studentData.GetChecklist("*").Result.GetEnumerator())
      {
        if (!enumerator.MoveNext())
          return;
        StudentChecklist current = enumerator.Current;
        this.lblCurriculum.Text = current.RqrmntGroupDescr;
        this._requirementGroup = current.RqrmntGroup;
        foreach (CurriculumDetails curriculumDetails in this._studentData.GetCurriculum(current.RqrmntGroup).Result)
        {
          this.lblDescription.Text = curriculumDetails.RqrmntGroupLongDescr;
          curriculumDetails.MinUnitsRequired = string.IsNullOrWhiteSpace(curriculumDetails.MinUnitsRequired) ? "0.00" : curriculumDetails.MinUnitsRequired;
          curriculumDetails.UnitsTaken = string.IsNullOrWhiteSpace(curriculumDetails.UnitsTaken) ? "0.00" : curriculumDetails.UnitsTaken;
          this.lblRequired.Text = curriculumDetails.MinUnitsRequired;
          this.lblTaken.Text = string.Format("{0:0.00}", new object[1]
          {
            (object) curriculumDetails.UnitsTaken
          });
          double num = double.Parse(curriculumDetails.MinUnitsRequired) - double.Parse(curriculumDetails.UnitsTaken);
          this.lblNeeded.Text = string.Format("{0:0.00}", new object[1]
          {
            (object) (num <= 0.0 ? 0.0 : num)
          });
        }
      }
    }

    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private void InitializeComponent()
    {
      if (ResourceLoader.ResourceProvider != null && ResourceLoader.ResourceProvider(typeof (CurriculumDetailsPage).GetTypeInfo().Assembly.GetName(), "Views/Students/CurriculumDetailsPage.xaml") != null)
        this.__InitComponentRuntime();
      else if (Xamarin.Forms.Xaml.Internals.XamlLoader.XamlFileProvider != null && Xamarin.Forms.Xaml.Internals.XamlLoader.XamlFileProvider(this.GetType()) != null)
      {
        this.__InitComponentRuntime();
      }
      else
      {
        StaticResourceExtension resourceExtension1 = new StaticResourceExtension();
        Label label1 = new Label();
        BoxView bindable1 = new BoxView();
        Span bindable2 = new Span();
        Span span1 = new Span();
        Span bindable3 = new Span();
        Span span2 = new Span();
        Span bindable4 = new Span();
        Span span3 = new Span();
        Span bindable5 = new Span();
        FormattedString bindable6 = new FormattedString();
        Label bindable7 = new Label();
        StaticResourceExtension resourceExtension2 = new StaticResourceExtension();
        Label label2 = new Label();
        StackLayout bindable8 = new StackLayout();
        Frame bindable9 = new Frame();
        StackLayout bindable10 = new StackLayout();
        ScrollView bindable11 = new ScrollView();
        CurriculumDetailsPage bindable12 = this;
        NameScope nameScope = new NameScope();
        NameScope.SetNameScope((BindableObject) bindable12, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable11, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable10, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable9, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable8, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) label1, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("lblCurriculum", (object) label1);
        if (label1.StyleId == null)
          label1.StyleId = "lblCurriculum";
        NameScope.SetNameScope((BindableObject) bindable1, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable7, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable6, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable2, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) span1, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("lblRequired", (object) span1);
        if (span1.StyleId == null)
          span1.StyleId = "lblRequired";
        NameScope.SetNameScope((BindableObject) bindable3, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) span2, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("lblTaken", (object) span2);
        if (span2.StyleId == null)
          span2.StyleId = "lblTaken";
        NameScope.SetNameScope((BindableObject) bindable4, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) span3, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("lblNeeded", (object) span3);
        if (span3.StyleId == null)
          span3.StyleId = "lblNeeded";
        NameScope.SetNameScope((BindableObject) bindable5, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) label2, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("lblDescription", (object) label2);
        if (label2.StyleId == null)
          label2.StyleId = "lblDescription";
        this.lblCurriculum = label1;
        this.lblRequired = span1;
        this.lblTaken = span2;
        this.lblNeeded = span3;
        this.lblDescription = label2;
        bindable12.SetValue(Page.TitleProperty, (object) "Curriculum Details");
        bindable11.SetValue(View.VerticalOptionsProperty, (object) LayoutOptions.FillAndExpand);
        bindable10.SetValue(View.MarginProperty, (object) new Thickness(5.0));
        bindable10.SetValue(View.VerticalOptionsProperty, (object) LayoutOptions.FillAndExpand);
        bindable9.SetValue(View.MarginProperty, (object) new Thickness(5.0));
        bindable9.SetValue(Frame.HasShadowProperty, (object) true);
        resourceExtension1.Key = "normalHeader";
        StaticResourceExtension resourceExtension3 = resourceExtension1;
        XamlServiceProvider xamlServiceProvider1 = new XamlServiceProvider();
        Type type1 = typeof (IProvideValueTarget);
        object[] objectAndParents1 = new object[0 + 6];
        objectAndParents1[0] = (object) label1;
        objectAndParents1[1] = (object) bindable8;
        objectAndParents1[2] = (object) bindable9;
        objectAndParents1[3] = (object) bindable10;
        objectAndParents1[4] = (object) bindable11;
        objectAndParents1[5] = (object) bindable12;
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
        XamlTypeResolver service2 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver1, typeof (CurriculumDetailsPage).GetTypeInfo().Assembly);
        xamlServiceProvider1.Add(type2, (object) service2);
        xamlServiceProvider1.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(13, 55)));
        object obj1 = resourceExtension3.ProvideValue((IServiceProvider) xamlServiceProvider1);
        label1.Style = (Style) obj1;
        label1.SetValue(Label.TextColorProperty, (object) new Color(0.250980406999588, 0.250980406999588, 0.250980406999588, 1.0));
        label1.SetValue(View.VerticalOptionsProperty, (object) LayoutOptions.Center);
        label1.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.FillAndExpand);
        bindable8.Children.Add((View) label1);
        bindable1.SetValue(BoxView.ColorProperty, (object) new Color(0.905882358551025, 0.752941191196442, 0.113725490868092, 1.0));
        bindable1.SetValue(VisualElement.HeightRequestProperty, (object) 1.5);
        bindable1.SetValue(View.MarginProperty, (object) new Thickness(0.0, 0.0, 0.0, 5.0));
        bindable1.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.FillAndExpand);
        bindable8.Children.Add((View) bindable1);
        bindable7.SetValue(View.MarginProperty, (object) new Thickness(0.0, 5.0, 0.0, 10.0));
        bindable2.SetValue(Span.TextProperty, (object) "Units:");
        Span span4 = bindable2;
        BindableProperty fontSizeProperty1 = Span.FontSizeProperty;
        FontSizeConverter fontSizeConverter1 = new FontSizeConverter();
        XamlServiceProvider xamlServiceProvider2 = new XamlServiceProvider();
        Type type3 = typeof (IProvideValueTarget);
        object[] objectAndParents2 = new object[0 + 8];
        objectAndParents2[0] = (object) bindable2;
        objectAndParents2[1] = (object) bindable6;
        objectAndParents2[2] = (object) bindable7;
        objectAndParents2[3] = (object) bindable8;
        objectAndParents2[4] = (object) bindable9;
        objectAndParents2[5] = (object) bindable10;
        objectAndParents2[6] = (object) bindable11;
        objectAndParents2[7] = (object) bindable12;
        SimpleValueTargetProvider service3 = new SimpleValueTargetProvider(objectAndParents2, (object) Span.FontSizeProperty);
        xamlServiceProvider2.Add(type3, (object) service3);
        xamlServiceProvider2.Add(typeof (INameScopeProvider), (object) new NameScopeProvider()
        {
          NameScope = (INameScope) nameScope
        });
        Type type4 = typeof (IXamlTypeResolver);
        XmlNamespaceResolver namespaceResolver2 = new XmlNamespaceResolver();
        namespaceResolver2.Add("", "http://xamarin.com/schemas/2014/forms");
        namespaceResolver2.Add("x", "http://schemas.microsoft.com/winfx/2009/xaml");
        XamlTypeResolver service4 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver2, typeof (CurriculumDetailsPage).GetTypeInfo().Assembly);
        xamlServiceProvider2.Add(type4, (object) service4);
        xamlServiceProvider2.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(22, 57)));
        object obj2 = ((IExtendedTypeConverter) fontSizeConverter1).ConvertFromInvariantString("Small", (IServiceProvider) xamlServiceProvider2);
        span4.SetValue(fontSizeProperty1, obj2);
        bindable2.SetValue(Span.FontFamilyProperty, (object) "Roboto-Regular.ttf#Roboto");
        bindable2.SetValue(Span.TextColorProperty, (object) new Color(0.250980406999588, 0.250980406999588, 0.250980406999588, 1.0));
        bindable6.Spans.Add(bindable2);
        Span span5 = span1;
        BindableProperty fontSizeProperty2 = Span.FontSizeProperty;
        FontSizeConverter fontSizeConverter2 = new FontSizeConverter();
        XamlServiceProvider xamlServiceProvider3 = new XamlServiceProvider();
        Type type5 = typeof (IProvideValueTarget);
        object[] objectAndParents3 = new object[0 + 8];
        objectAndParents3[0] = (object) span1;
        objectAndParents3[1] = (object) bindable6;
        objectAndParents3[2] = (object) bindable7;
        objectAndParents3[3] = (object) bindable8;
        objectAndParents3[4] = (object) bindable9;
        objectAndParents3[5] = (object) bindable10;
        objectAndParents3[6] = (object) bindable11;
        objectAndParents3[7] = (object) bindable12;
        SimpleValueTargetProvider service5 = new SimpleValueTargetProvider(objectAndParents3, (object) Span.FontSizeProperty);
        xamlServiceProvider3.Add(type5, (object) service5);
        xamlServiceProvider3.Add(typeof (INameScopeProvider), (object) new NameScopeProvider()
        {
          NameScope = (INameScope) nameScope
        });
        Type type6 = typeof (IXamlTypeResolver);
        XmlNamespaceResolver namespaceResolver3 = new XmlNamespaceResolver();
        namespaceResolver3.Add("", "http://xamarin.com/schemas/2014/forms");
        namespaceResolver3.Add("x", "http://schemas.microsoft.com/winfx/2009/xaml");
        XamlTypeResolver service6 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver3, typeof (CurriculumDetailsPage).GetTypeInfo().Assembly);
        xamlServiceProvider3.Add(type6, (object) service6);
        xamlServiceProvider3.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(24, 64)));
        object obj3 = ((IExtendedTypeConverter) fontSizeConverter2).ConvertFromInvariantString("Small", (IServiceProvider) xamlServiceProvider3);
        span5.SetValue(fontSizeProperty2, obj3);
        span1.SetValue(Span.ForegroundColorProperty, (object) new Color(0.0431372560560703, 0.341176480054855, 0.576470613479614, 1.0));
        span1.SetValue(Span.FontFamilyProperty, (object) "Roboto-Medium.ttf#Roboto");
        span1.SetValue(Span.TextColorProperty, (object) new Color(0.250980406999588, 0.250980406999588, 0.250980406999588, 1.0));
        bindable6.Spans.Add(span1);
        bindable3.SetValue(Span.TextProperty, (object) " required, ");
        Span span6 = bindable3;
        BindableProperty fontSizeProperty3 = Span.FontSizeProperty;
        FontSizeConverter fontSizeConverter3 = new FontSizeConverter();
        XamlServiceProvider xamlServiceProvider4 = new XamlServiceProvider();
        Type type7 = typeof (IProvideValueTarget);
        object[] objectAndParents4 = new object[0 + 8];
        objectAndParents4[0] = (object) bindable3;
        objectAndParents4[1] = (object) bindable6;
        objectAndParents4[2] = (object) bindable7;
        objectAndParents4[3] = (object) bindable8;
        objectAndParents4[4] = (object) bindable9;
        objectAndParents4[5] = (object) bindable10;
        objectAndParents4[6] = (object) bindable11;
        objectAndParents4[7] = (object) bindable12;
        SimpleValueTargetProvider service7 = new SimpleValueTargetProvider(objectAndParents4, (object) Span.FontSizeProperty);
        xamlServiceProvider4.Add(type7, (object) service7);
        xamlServiceProvider4.Add(typeof (INameScopeProvider), (object) new NameScopeProvider()
        {
          NameScope = (INameScope) nameScope
        });
        Type type8 = typeof (IXamlTypeResolver);
        XmlNamespaceResolver namespaceResolver4 = new XmlNamespaceResolver();
        namespaceResolver4.Add("", "http://xamarin.com/schemas/2014/forms");
        namespaceResolver4.Add("x", "http://schemas.microsoft.com/winfx/2009/xaml");
        XamlTypeResolver service8 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver4, typeof (CurriculumDetailsPage).GetTypeInfo().Assembly);
        xamlServiceProvider4.Add(type8, (object) service8);
        xamlServiceProvider4.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(25, 62)));
        object obj4 = ((IExtendedTypeConverter) fontSizeConverter3).ConvertFromInvariantString("Small", (IServiceProvider) xamlServiceProvider4);
        span6.SetValue(fontSizeProperty3, obj4);
        bindable3.SetValue(Span.FontFamilyProperty, (object) "Roboto-Regular.ttf#Roboto");
        bindable3.SetValue(Span.TextColorProperty, (object) new Color(0.250980406999588, 0.250980406999588, 0.250980406999588, 1.0));
        bindable6.Spans.Add(bindable3);
        Span span7 = span2;
        BindableProperty fontSizeProperty4 = Span.FontSizeProperty;
        FontSizeConverter fontSizeConverter4 = new FontSizeConverter();
        XamlServiceProvider xamlServiceProvider5 = new XamlServiceProvider();
        Type type9 = typeof (IProvideValueTarget);
        object[] objectAndParents5 = new object[0 + 8];
        objectAndParents5[0] = (object) span2;
        objectAndParents5[1] = (object) bindable6;
        objectAndParents5[2] = (object) bindable7;
        objectAndParents5[3] = (object) bindable8;
        objectAndParents5[4] = (object) bindable9;
        objectAndParents5[5] = (object) bindable10;
        objectAndParents5[6] = (object) bindable11;
        objectAndParents5[7] = (object) bindable12;
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
        XamlTypeResolver service10 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver5, typeof (CurriculumDetailsPage).GetTypeInfo().Assembly);
        xamlServiceProvider5.Add(type10, (object) service10);
        xamlServiceProvider5.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(27, 61)));
        object obj5 = ((IExtendedTypeConverter) fontSizeConverter4).ConvertFromInvariantString("Small", (IServiceProvider) xamlServiceProvider5);
        span7.SetValue(fontSizeProperty4, obj5);
        span2.SetValue(Span.ForegroundColorProperty, (object) new Color(0.0431372560560703, 0.341176480054855, 0.576470613479614, 1.0));
        span2.SetValue(Span.FontFamilyProperty, (object) "Roboto-Medium.ttf#Roboto");
        span2.SetValue(Span.TextColorProperty, (object) new Color(0.250980406999588, 0.250980406999588, 0.250980406999588, 1.0));
        bindable6.Spans.Add(span2);
        bindable4.SetValue(Span.TextProperty, (object) " taken, ");
        Span span8 = bindable4;
        BindableProperty fontSizeProperty5 = Span.FontSizeProperty;
        FontSizeConverter fontSizeConverter5 = new FontSizeConverter();
        XamlServiceProvider xamlServiceProvider6 = new XamlServiceProvider();
        Type type11 = typeof (IProvideValueTarget);
        object[] objectAndParents6 = new object[0 + 8];
        objectAndParents6[0] = (object) bindable4;
        objectAndParents6[1] = (object) bindable6;
        objectAndParents6[2] = (object) bindable7;
        objectAndParents6[3] = (object) bindable8;
        objectAndParents6[4] = (object) bindable9;
        objectAndParents6[5] = (object) bindable10;
        objectAndParents6[6] = (object) bindable11;
        objectAndParents6[7] = (object) bindable12;
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
        XamlTypeResolver service12 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver6, typeof (CurriculumDetailsPage).GetTypeInfo().Assembly);
        xamlServiceProvider6.Add(type12, (object) service12);
        xamlServiceProvider6.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(28, 59)));
        object obj6 = ((IExtendedTypeConverter) fontSizeConverter5).ConvertFromInvariantString("Small", (IServiceProvider) xamlServiceProvider6);
        span8.SetValue(fontSizeProperty5, obj6);
        bindable4.SetValue(Span.FontFamilyProperty, (object) "Roboto-Regular.ttf#Roboto");
        bindable4.SetValue(Span.TextColorProperty, (object) new Color(0.250980406999588, 0.250980406999588, 0.250980406999588, 1.0));
        bindable6.Spans.Add(bindable4);
        Span span9 = span3;
        BindableProperty fontSizeProperty6 = Span.FontSizeProperty;
        FontSizeConverter fontSizeConverter6 = new FontSizeConverter();
        XamlServiceProvider xamlServiceProvider7 = new XamlServiceProvider();
        Type type13 = typeof (IProvideValueTarget);
        object[] objectAndParents7 = new object[0 + 8];
        objectAndParents7[0] = (object) span3;
        objectAndParents7[1] = (object) bindable6;
        objectAndParents7[2] = (object) bindable7;
        objectAndParents7[3] = (object) bindable8;
        objectAndParents7[4] = (object) bindable9;
        objectAndParents7[5] = (object) bindable10;
        objectAndParents7[6] = (object) bindable11;
        objectAndParents7[7] = (object) bindable12;
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
        XamlTypeResolver service14 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver7, typeof (CurriculumDetailsPage).GetTypeInfo().Assembly);
        xamlServiceProvider7.Add(type14, (object) service14);
        xamlServiceProvider7.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(30, 62)));
        object obj7 = ((IExtendedTypeConverter) fontSizeConverter6).ConvertFromInvariantString("Small", (IServiceProvider) xamlServiceProvider7);
        span9.SetValue(fontSizeProperty6, obj7);
        span3.SetValue(Span.ForegroundColorProperty, (object) new Color(0.0431372560560703, 0.341176480054855, 0.576470613479614, 1.0));
        span3.SetValue(Span.FontFamilyProperty, (object) "Roboto-Medium.ttf#Roboto");
        span3.SetValue(Span.TextColorProperty, (object) new Color(0.250980406999588, 0.250980406999588, 0.250980406999588, 1.0));
        bindable6.Spans.Add(span3);
        bindable5.SetValue(Span.TextProperty, (object) " needed ");
        Span span10 = bindable5;
        BindableProperty fontSizeProperty7 = Span.FontSizeProperty;
        FontSizeConverter fontSizeConverter7 = new FontSizeConverter();
        XamlServiceProvider xamlServiceProvider8 = new XamlServiceProvider();
        Type type15 = typeof (IProvideValueTarget);
        object[] objectAndParents8 = new object[0 + 8];
        objectAndParents8[0] = (object) bindable5;
        objectAndParents8[1] = (object) bindable6;
        objectAndParents8[2] = (object) bindable7;
        objectAndParents8[3] = (object) bindable8;
        objectAndParents8[4] = (object) bindable9;
        objectAndParents8[5] = (object) bindable10;
        objectAndParents8[6] = (object) bindable11;
        objectAndParents8[7] = (object) bindable12;
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
        XamlTypeResolver service16 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver8, typeof (CurriculumDetailsPage).GetTypeInfo().Assembly);
        xamlServiceProvider8.Add(type16, (object) service16);
        xamlServiceProvider8.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(31, 59)));
        object obj8 = ((IExtendedTypeConverter) fontSizeConverter7).ConvertFromInvariantString("Small", (IServiceProvider) xamlServiceProvider8);
        span10.SetValue(fontSizeProperty7, obj8);
        bindable5.SetValue(Span.FontFamilyProperty, (object) "Roboto-Regular.ttf#Roboto");
        bindable5.SetValue(Span.TextColorProperty, (object) new Color(0.250980406999588, 0.250980406999588, 0.250980406999588, 1.0));
        bindable6.Spans.Add(bindable5);
        bindable7.SetValue(Label.FormattedTextProperty, (object) bindable6);
        bindable8.Children.Add((View) bindable7);
        resourceExtension2.Key = "smallLabel";
        StaticResourceExtension resourceExtension4 = resourceExtension2;
        XamlServiceProvider xamlServiceProvider9 = new XamlServiceProvider();
        Type type17 = typeof (IProvideValueTarget);
        object[] objectAndParents9 = new object[0 + 6];
        objectAndParents9[0] = (object) label2;
        objectAndParents9[1] = (object) bindable8;
        objectAndParents9[2] = (object) bindable9;
        objectAndParents9[3] = (object) bindable10;
        objectAndParents9[4] = (object) bindable11;
        objectAndParents9[5] = (object) bindable12;
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
        XamlTypeResolver service18 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver9, typeof (CurriculumDetailsPage).GetTypeInfo().Assembly);
        xamlServiceProvider9.Add(type18, (object) service18);
        xamlServiceProvider9.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(37, 56)));
        object obj9 = resourceExtension4.ProvideValue((IServiceProvider) xamlServiceProvider9);
        label2.Style = (Style) obj9;
        label2.SetValue(Label.TextColorProperty, (object) new Color(0.250980406999588, 0.250980406999588, 0.250980406999588, 1.0));
        label2.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.FillAndExpand);
        bindable8.Children.Add((View) label2);
        bindable9.SetValue(ContentView.ContentProperty, (object) bindable8);
        bindable10.Children.Add((View) bindable9);
        bindable11.Content = (View) bindable10;
        bindable12.SetValue(ContentPage.ContentProperty, (object) bindable11);
      }
    }

    private void __InitComponentRuntime()
    {
      this.LoadFromXaml<CurriculumDetailsPage>(typeof (CurriculumDetailsPage));
      this.lblCurriculum = NameScopeExtensions.FindByName<Label>(this, "lblCurriculum");
      this.lblRequired = NameScopeExtensions.FindByName<Span>(this, "lblRequired");
      this.lblTaken = NameScopeExtensions.FindByName<Span>(this, "lblTaken");
      this.lblNeeded = NameScopeExtensions.FindByName<Span>(this, "lblNeeded");
      this.lblDescription = NameScopeExtensions.FindByName<Label>(this, "lblDescription");
    }
  }
}
