// Decompiled with JetBrains decompiler
// Type: one_sti_student_portal.Views.Widgets.WidgetSettingsPage
// Assembly: one_sti_student_portal, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 39E34984-485E-45CE-9895-F7524E3024D6
// Assembly location: \\wsl.localhost\kali-linux\root\One STI Student Portal_1.3.8_apkcombo.com (1)\unknown\assemblies\one_sti_student_portal.dll

using one_sti_student_portal.Data;
using one_sti_student_portal.Models.Widget;
using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Xml;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.Xaml.Internals;

namespace one_sti_student_portal.Views.Widgets
{
  [XamlFilePath("Views\\Widgets\\WidgetSettingsPage.xaml")]
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public class WidgetSettingsPage : ContentPage
  {
    private WidgetsData _widgetData;
    private List<WidgetsAvailable> _widgetsList;
    private List<WidgetSettings> _widgetSettingsList;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private StackLayout refreshIndicator;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private ListView WidgetListView;

    public WidgetSettingsPage()
    {
      this.InitializeComponent();
      this._widgetData = new WidgetsData();
      this._widgetsList = new List<WidgetsAvailable>();
      this._widgetSettingsList = new List<WidgetSettings>();
      this.LoadWidgets();
      this.DownloadWidgets();
    }

    private void DownloadWidgets()
    {
      Device.BeginInvokeOnMainThread((Action) (() => this.refreshIndicator.IsVisible = true));
      Task.Run((Action) (() => { })).ContinueWith((Action<Task>) (result => Device.BeginInvokeOnMainThread((Action) (() =>
      {
        this._widgetData.DownloadWidgets();
        this.LoadWidgets();
        this.refreshIndicator.IsVisible = false;
      }))));
    }

    private void LoadWidgets()
    {
      this._widgetsList = this._widgetData.GetWidgetsAvailable().Result;
      List<WidgetSettings> result = this._widgetData.GetSelectedWidgets().Result;
      foreach (WidgetsAvailable widgets in this._widgetsList)
      {
        WidgetsAvailable items = widgets;
        items.Selector = !result.Any<WidgetSettings>((Func<WidgetSettings, bool>) (o => o.Widget == items.Widget)) ? "" : "ic_item_check";
      }
      this.WidgetListView.ItemsSource = (IEnumerable) this._widgetsList;
    }

    private void WidgetListView_ItemTapped(object sender, ItemTappedEventArgs e)
    {
      WidgetsAvailable widgetsAvailable = (WidgetsAvailable) e.Item;
      List<WidgetSettings> result = this._widgetData.GetSelectedWidgets().Result;
      if (widgetsAvailable.Selector == "")
        this._widgetData.UpdateWidgetSettings(new WidgetSettings()
        {
          Widget = widgetsAvailable.Widget,
          AddedOn = DateTime.Now
        });
      else if (result.Count == 1)
        Acr.UserDialogs.UserDialogs.Instance.Toast("You should have atleast 1 widget selected.");
      else
        this._widgetData.RemoveWidget(widgetsAvailable.Widget);
      this.LoadWidgets();
      WidgetHomePage._isRefresh = true;
    }

    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private void InitializeComponent()
    {
      if (ResourceLoader.ResourceProvider != null && ResourceLoader.ResourceProvider(typeof (WidgetSettingsPage).GetTypeInfo().Assembly.GetName(), "Views/Widgets/WidgetSettingsPage.xaml") != null)
        this.__InitComponentRuntime();
      else if (Xamarin.Forms.Xaml.Internals.XamlLoader.XamlFileProvider != null && Xamarin.Forms.Xaml.Internals.XamlLoader.XamlFileProvider(this.GetType()) != null)
      {
        this.__InitComponentRuntime();
      }
      else
      {
        StaticResourceExtension resourceExtension1 = new StaticResourceExtension();
        ActivityIndicator bindable1 = new ActivityIndicator();
        StackLayout stackLayout = new StackLayout();
        DataTemplate dataTemplate1 = new DataTemplate();
        ListView listView = new ListView();
        StackLayout bindable2 = new StackLayout();
        WidgetSettingsPage bindable3 = this;
        NameScope nameScope = new NameScope();
        NameScope.SetNameScope((BindableObject) bindable3, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable2, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) stackLayout, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("refreshIndicator", (object) stackLayout);
        if (stackLayout.StyleId == null)
          stackLayout.StyleId = "refreshIndicator";
        NameScope.SetNameScope((BindableObject) bindable1, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) listView, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("WidgetListView", (object) listView);
        if (listView.StyleId == null)
          listView.StyleId = "WidgetListView";
        this.refreshIndicator = stackLayout;
        this.WidgetListView = listView;
        resourceExtension1.Key = "PageBackgroundColor";
        StaticResourceExtension resourceExtension2 = resourceExtension1;
        XamlServiceProvider xamlServiceProvider = new XamlServiceProvider();
        Type type1 = typeof (IProvideValueTarget);
        object[] objectAndParents = new object[0 + 1];
        objectAndParents[0] = (object) bindable3;
        SimpleValueTargetProvider service1 = new SimpleValueTargetProvider(objectAndParents, (object) VisualElement.BackgroundColorProperty);
        xamlServiceProvider.Add(type1, (object) service1);
        xamlServiceProvider.Add(typeof (INameScopeProvider), (object) new NameScopeProvider()
        {
          NameScope = (INameScope) nameScope
        });
        Type type2 = typeof (IXamlTypeResolver);
        XmlNamespaceResolver namespaceResolver = new XmlNamespaceResolver();
        namespaceResolver.Add("", "http://xamarin.com/schemas/2014/forms");
        namespaceResolver.Add("x", "http://schemas.microsoft.com/winfx/2009/xaml");
        XamlTypeResolver service2 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver, typeof (WidgetSettingsPage).GetTypeInfo().Assembly);
        xamlServiceProvider.Add(type2, (object) service2);
        xamlServiceProvider.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(5, 14)));
        object obj = resourceExtension2.ProvideValue((IServiceProvider) xamlServiceProvider);
        bindable3.BackgroundColor = (Color) obj;
        bindable3.SetValue(Page.TitleProperty, (object) "Manage Widgets");
        stackLayout.SetValue(View.MarginProperty, (object) new Thickness(5.0));
        stackLayout.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.CenterAndExpand);
        bindable1.SetValue(VisualElement.HeightRequestProperty, (object) 25.0);
        bindable1.SetValue(ActivityIndicator.IsRunningProperty, (object) true);
        stackLayout.Children.Add((View) bindable1);
        bindable2.Children.Add((View) stackLayout);
        listView.SetValue(ListView.HasUnevenRowsProperty, (object) true);
        listView.SetValue(View.VerticalOptionsProperty, (object) LayoutOptions.FillAndExpand);
        listView.SetValue(View.MarginProperty, (object) new Thickness(0.0, 5.0, 0.0, 0.0));
        listView.SetValue(ListView.SeparatorVisibilityProperty, (object) SeparatorVisibility.None);
        listView.ItemTapped += new EventHandler<ItemTappedEventArgs>(bindable3.WidgetListView_ItemTapped);
        DataTemplate dataTemplate2 = dataTemplate1;
        // ISSUE: object of a compiler-generated type is created
        // ISSUE: variable of a compiler-generated type
        WidgetSettingsPage.\u003CInitializeComponent\u003E_anonXamlCDataTemplate_3 xamlCdataTemplate3 = new WidgetSettingsPage.\u003CInitializeComponent\u003E_anonXamlCDataTemplate_3();
        object[] objArray = new object[0 + 4];
        objArray[0] = (object) dataTemplate1;
        objArray[1] = (object) listView;
        objArray[2] = (object) bindable2;
        objArray[3] = (object) bindable3;
        // ISSUE: reference to a compiler-generated field
        xamlCdataTemplate3.parentValues = objArray;
        // ISSUE: reference to a compiler-generated field
        xamlCdataTemplate3.root = bindable3;
        // ISSUE: reference to a compiler-generated method
        Func<object> func = new Func<object>(xamlCdataTemplate3.LoadDataTemplate);
        ((IDataTemplate) dataTemplate2).LoadTemplate = func;
        listView.SetValue(ItemsView<Cell>.ItemTemplateProperty, (object) dataTemplate1);
        bindable2.Children.Add((View) listView);
        bindable3.SetValue(ContentPage.ContentProperty, (object) bindable2);
      }
    }

    private void __InitComponentRuntime()
    {
      this.LoadFromXaml<WidgetSettingsPage>(typeof (WidgetSettingsPage));
      this.refreshIndicator = NameScopeExtensions.FindByName<StackLayout>(this, "refreshIndicator");
      this.WidgetListView = NameScopeExtensions.FindByName<ListView>(this, "WidgetListView");
    }
  }
}
