// Decompiled with JetBrains decompiler
// Type: one_sti_student_portal.Views.NotificationPage
// Assembly: one_sti_student_portal, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 39E34984-485E-45CE-9895-F7524E3024D6
// Assembly location: \\wsl.localhost\kali-linux\root\One STI Student Portal_1.3.8_apkcombo.com (1)\unknown\assemblies\one_sti_student_portal.dll

using one_sti_student_portal.Data;
using one_sti_student_portal.Helpers;
using one_sti_student_portal.Models;
using Refractored.XamForms.PullToRefresh;
using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
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
  [XamlFilePath("Views\\NotificationPage.xaml")]
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public class NotificationPage : ContentPage
  {
    private bool _isBusy;
    private bool _isConnected;
    private FeedbackData _feedbackData;
    private StudentData _studentData;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private PullToRefreshLayout refreshNotifications;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private ListView NotificationListView;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private StackLayout stackNothing;

    public NotificationPage()
    {
      this.InitializeComponent();
      this._feedbackData = new FeedbackData();
      this._studentData = new StudentData();
      this._isConnected = ConnectionHelper.IsConnected();
      Connectivity.ConnectivityChanged += (EventHandler<ConnectivityChangedEventArgs>) ((sender, args) => this._isConnected = ConnectionHelper.IsConnected());
      this.refreshNotifications.RefreshCommand = (ICommand) new Command((Action) (() => this.RefreshContent()));
    }

    protected override void OnAppearing()
    {
      base.OnAppearing();
      this.RefreshContent();
    }

    private void RefreshContent()
    {
      Device.BeginInvokeOnMainThread((Action) (() => this.refreshNotifications.IsRefreshing = true));
      Task.Run((Func<Task>) (async () =>
      {
        if (!this._isConnected || this._isBusy)
          return;
        this._isBusy = true;
        await this._feedbackData.DownloadMyFeedbacks(this._studentData.GetStudentInformation().Result.FirstOrDefault<StudentInformation>().Email);
      })).ContinueWith((Action<Task>) (result => Device.BeginInvokeOnMainThread((Action) (() =>
      {
        this.LoadFeedbacks();
        this.refreshNotifications.IsRefreshing = false;
        this._isBusy = false;
        if (ConnectionHelper.IsConnected())
          return;
        Acr.UserDialogs.UserDialogs.Instance.Toast("Could not refresh. Check your network connection.");
      }))));
    }

    private void LoadFeedbacks()
    {
      List<FeedbackWithReply> list = this._feedbackData.GetMyFeedbacks(this._studentData.GetStudentInformation().Result.FirstOrDefault<StudentInformation>().Email).Result.Where<FeedbackWithReply>((Func<FeedbackWithReply, bool>) (o => o.unread)).ToList<FeedbackWithReply>().OrderByDescending<FeedbackWithReply, DateTime>((Func<FeedbackWithReply, DateTime>) (o => o.replied_on)).ToList<FeedbackWithReply>();
      List<NotificationTemplate> notificationTemplateList = new List<NotificationTemplate>();
      foreach (FeedbackWithReply feedbackWithReply in list)
        notificationTemplateList.Add(new NotificationTemplate()
        {
          feedback_id = feedbackWithReply.feedback_id,
          title = "One STI",
          created_on = feedbackWithReply.replied_on.ToString("MMM dd, yyyy hh:mm tt").ToUpper(),
          subject = "has replied to your feedback \"" + feedbackWithReply.feedback + "\""
        });
      this.NotificationListView.ItemsSource = (IEnumerable) notificationTemplateList;
      this.NotificationListView.IsVisible = true;
      if (list.Count == 0)
      {
        this.NotificationListView.IsVisible = false;
        this.stackNothing.IsVisible = true;
      }
      else
      {
        this.NotificationListView.IsVisible = true;
        this.stackNothing.IsVisible = false;
      }
    }

    private void NotificationListView_ItemTapped(object sender, ItemTappedEventArgs e) => this.Navigation.PushAsync((Page) new ViewFeedback(((NotificationTemplate) e.Item).feedback_id), true);

    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private void InitializeComponent()
    {
      if (ResourceLoader.ResourceProvider != null && ResourceLoader.ResourceProvider(typeof (NotificationPage).GetTypeInfo().Assembly.GetName(), "Views/NotificationPage.xaml") != null)
        this.__InitComponentRuntime();
      else if (Xamarin.Forms.Xaml.Internals.XamlLoader.XamlFileProvider != null && Xamarin.Forms.Xaml.Internals.XamlLoader.XamlFileProvider(this.GetType()) != null)
      {
        this.__InitComponentRuntime();
      }
      else
      {
        DataTemplate dataTemplate1 = new DataTemplate();
        ListView listView = new ListView(ListViewCachingStrategy.RecycleElement);
        Image bindable1 = new Image();
        StaticResourceExtension resourceExtension1 = new StaticResourceExtension();
        Label bindable2 = new Label();
        StackLayout stackLayout = new StackLayout();
        StackLayout bindable3 = new StackLayout();
        PullToRefreshLayout pullToRefreshLayout = new PullToRefreshLayout();
        StackLayout bindable4 = new StackLayout();
        NotificationPage bindable5 = this;
        NameScope nameScope = new NameScope();
        NameScope.SetNameScope((BindableObject) bindable5, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable4, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) pullToRefreshLayout, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("refreshNotifications", (object) pullToRefreshLayout);
        if (pullToRefreshLayout.StyleId == null)
          pullToRefreshLayout.StyleId = "refreshNotifications";
        NameScope.SetNameScope((BindableObject) bindable3, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) listView, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("NotificationListView", (object) listView);
        if (listView.StyleId == null)
          listView.StyleId = "NotificationListView";
        NameScope.SetNameScope((BindableObject) stackLayout, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("stackNothing", (object) stackLayout);
        if (stackLayout.StyleId == null)
          stackLayout.StyleId = "stackNothing";
        NameScope.SetNameScope((BindableObject) bindable1, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable2, (INameScope) nameScope);
        this.refreshNotifications = pullToRefreshLayout;
        this.NotificationListView = listView;
        this.stackNothing = stackLayout;
        bindable5.SetValue(Page.TitleProperty, (object) "Notifications");
        bindable4.SetValue(StackLayout.OrientationProperty, (object) StackOrientation.Vertical);
        bindable4.SetValue(Layout.PaddingProperty, (object) new Thickness(0.0, 0.0, 0.0, 0.0));
        bindable4.SetValue(VisualElement.BackgroundColorProperty, (object) new Color(1.0, 1.0, 1.0, 1.0));
        pullToRefreshLayout.SetValue(PullToRefreshLayout.IsPullToRefreshEnabledProperty, (object) true);
        listView.SetValue(ListView.HasUnevenRowsProperty, (object) true);
        listView.SetValue(ListView.SeparatorVisibilityProperty, (object) SeparatorVisibility.Default);
        listView.ItemTapped += new EventHandler<ItemTappedEventArgs>(bindable5.NotificationListView_ItemTapped);
        DataTemplate dataTemplate2 = dataTemplate1;
        // ISSUE: object of a compiler-generated type is created
        // ISSUE: variable of a compiler-generated type
        NotificationPage.\u003CInitializeComponent\u003E_anonXamlCDataTemplate_5 xamlCdataTemplate5 = new NotificationPage.\u003CInitializeComponent\u003E_anonXamlCDataTemplate_5();
        object[] objArray = new object[0 + 6];
        objArray[0] = (object) dataTemplate1;
        objArray[1] = (object) listView;
        objArray[2] = (object) bindable3;
        objArray[3] = (object) pullToRefreshLayout;
        objArray[4] = (object) bindable4;
        objArray[5] = (object) bindable5;
        // ISSUE: reference to a compiler-generated field
        xamlCdataTemplate5.parentValues = objArray;
        // ISSUE: reference to a compiler-generated field
        xamlCdataTemplate5.root = bindable5;
        // ISSUE: reference to a compiler-generated method
        Func<object> func = new Func<object>(xamlCdataTemplate5.LoadDataTemplate);
        ((IDataTemplate) dataTemplate2).LoadTemplate = func;
        listView.SetValue(ItemsView<Cell>.ItemTemplateProperty, (object) dataTemplate1);
        bindable3.Children.Add((View) listView);
        stackLayout.SetValue(VisualElement.IsVisibleProperty, new VisualElement.VisibilityConverter().ConvertFromInvariantString("False"));
        stackLayout.SetValue(StackLayout.OrientationProperty, (object) StackOrientation.Vertical);
        stackLayout.SetValue(View.VerticalOptionsProperty, (object) LayoutOptions.CenterAndExpand);
        stackLayout.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.CenterAndExpand);
        stackLayout.SetValue(VisualElement.BackgroundColorProperty, (object) Color.White);
        bindable1.SetValue(Image.SourceProperty, new ImageSourceConverter().ConvertFromInvariantString("ic_empty_notification"));
        bindable1.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.CenterAndExpand);
        bindable1.SetValue(Image.AspectProperty, (object) Aspect.AspectFit);
        bindable1.SetValue(VisualElement.HeightRequestProperty, (object) 65.0);
        stackLayout.Children.Add((View) bindable1);
        bindable2.SetValue(Label.TextProperty, (object) "No new notifications");
        bindable2.SetValue(View.MarginProperty, (object) new Thickness(0.0, 10.0, 0.0, 0.0));
        resourceExtension1.Key = "smallLabel";
        StaticResourceExtension resourceExtension2 = resourceExtension1;
        XamlServiceProvider xamlServiceProvider = new XamlServiceProvider();
        Type type1 = typeof (IProvideValueTarget);
        object[] objectAndParents = new object[0 + 6];
        objectAndParents[0] = (object) bindable2;
        objectAndParents[1] = (object) stackLayout;
        objectAndParents[2] = (object) bindable3;
        objectAndParents[3] = (object) pullToRefreshLayout;
        objectAndParents[4] = (object) bindable4;
        objectAndParents[5] = (object) bindable5;
        SimpleValueTargetProvider service1 = new SimpleValueTargetProvider(objectAndParents, (object) VisualElement.StyleProperty);
        xamlServiceProvider.Add(type1, (object) service1);
        xamlServiceProvider.Add(typeof (INameScopeProvider), (object) new NameScopeProvider()
        {
          NameScope = (INameScope) nameScope
        });
        Type type2 = typeof (IXamlTypeResolver);
        XmlNamespaceResolver namespaceResolver = new XmlNamespaceResolver();
        namespaceResolver.Add("", "http://xamarin.com/schemas/2014/forms");
        namespaceResolver.Add("x", "http://schemas.microsoft.com/winfx/2009/xaml");
        namespaceResolver.Add("ctrImage", "clr-namespace:ImageCircle.Forms.Plugin.Abstractions;assembly=ImageCircle.Forms.Plugin.Abstractions");
        namespaceResolver.Add("controls", "clr-namespace:Refractored.XamForms.PullToRefresh;assembly=Refractored.XamForms.PullToRefresh");
        XamlTypeResolver service2 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver, typeof (NotificationPage).GetTypeInfo().Assembly);
        xamlServiceProvider.Add(type2, (object) service2);
        xamlServiceProvider.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(43, 78)));
        object obj = resourceExtension2.ProvideValue((IServiceProvider) xamlServiceProvider);
        bindable2.Style = (Style) obj;
        bindable2.SetValue(Label.HorizontalTextAlignmentProperty, new TextAlignmentConverter().ConvertFromInvariantString("Center"));
        bindable2.SetValue(Label.TextColorProperty, (object) new Color(0.250980406999588, 0.250980406999588, 0.250980406999588, 1.0));
        stackLayout.Children.Add((View) bindable2);
        bindable3.Children.Add((View) stackLayout);
        pullToRefreshLayout.SetValue(ContentView.ContentProperty, (object) bindable3);
        bindable4.Children.Add((View) pullToRefreshLayout);
        bindable5.SetValue(ContentPage.ContentProperty, (object) bindable4);
      }
    }

    private void __InitComponentRuntime()
    {
      this.LoadFromXaml<NotificationPage>(typeof (NotificationPage));
      this.refreshNotifications = NameScopeExtensions.FindByName<PullToRefreshLayout>(this, "refreshNotifications");
      this.NotificationListView = NameScopeExtensions.FindByName<ListView>(this, "NotificationListView");
      this.stackNothing = NameScopeExtensions.FindByName<StackLayout>(this, "stackNothing");
    }
  }
}
