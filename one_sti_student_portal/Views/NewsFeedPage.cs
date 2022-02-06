// Decompiled with JetBrains decompiler
// Type: one_sti_student_portal.Views.NewsFeedPage
// Assembly: one_sti_student_portal, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 39E34984-485E-45CE-9895-F7524E3024D6
// Assembly location: \\wsl.localhost\kali-linux\root\One STI Student Portal_1.3.8_apkcombo.com (1)\unknown\assemblies\one_sti_student_portal.dll

using Newtonsoft.Json;
using one_sti_student_portal.Data;
using one_sti_student_portal.Helpers;
using one_sti_student_portal.Models;
using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
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
  [XamlFilePath("Views\\NewsFeedPage.xaml")]
  public class NewsFeedPage : ContentPage
  {
    private int page = 1;
    private bool _isConnected;
    private bool _updateNews;
    private string NewsFeedUri = Constants.NewsFeedUri;
    private ObservableCollection<NewsArticles> _newsArticleModel;
    private ObservableCollection<NewsArticles> _localNewsArticles;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private StackLayout refreshIndicator;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private ListView NewsArticlesListView;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private StackLayout stackMore;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private Button btnViewMore;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private StackLayout activityIndicator;

    public NewsFeedPage()
    {
      this.InitializeComponent();
      this.BindingContext = (object) this;
      this._newsArticleModel = new ObservableCollection<NewsArticles>();
      this._localNewsArticles = new ObservableCollection<NewsArticles>();
      this.LoadNewsFeed();
      this._isConnected = ConnectionHelper.IsConnected();
      Connectivity.ConnectivityChanged += (EventHandler<ConnectivityChangedEventArgs>) ((sender, args) => this._isConnected = ConnectionHelper.IsConnected());
    }

    protected override void OnAppearing()
    {
      base.OnAppearing();
      this.RefreshNewsFeed();
    }

    protected override void OnDisappearing() => base.OnDisappearing();

    private void AddItemsToList()
    {
      for (int index = 0; index < this._localNewsArticles.Count; ++index)
      {
        if (this._localNewsArticles[index].content_text.Length > 140)
          this._localNewsArticles[index].content_text = this._localNewsArticles[index].content_text.Substring(0, 140);
        this._localNewsArticles[index].content_text += "...";
        this._newsArticleModel.Add(this._localNewsArticles[index]);
      }
    }

    private void LoadNewsFeed()
    {
      this._localNewsArticles.Clear();
      this._newsArticleModel.Clear();
      foreach (NewsArticles newsArticles in new NewsData().GetNewsArticleAsync().Result)
      {
        NewsArticles items = newsArticles;
        if (!this._localNewsArticles.Any<NewsArticles>((Func<NewsArticles, bool>) (o => o.newsno == items.newsno)))
          this._localNewsArticles.Add(new NewsArticles()
          {
            id = items.id,
            newsno = items.newsno,
            content_text = items.content_text,
            title = items.title,
            pic_large = items.pic_large
          });
      }
      this.AddItemsToList();
      if (this._localNewsArticles.Count == 0)
        return;
      string s = Math.Round(Convert.ToDouble(this._newsArticleModel.Count) / 15.0).ToString();
      this.page = this._newsArticleModel.Count >= 15 ? int.Parse(s) : 1;
      this.NewsArticlesListView.ItemsSource = (IEnumerable) this._newsArticleModel;
      this.NewsArticlesListView.IsVisible = true;
      this.NewsArticlesListView.FadeTo(1.0, 750U);
    }

    private void NewsArticlesListView_ItemTapped(object sender, ItemTappedEventArgs e)
    {
      if (this._isConnected)
      {
        if (!(e.Item is NewsArticles newsarticle))
          return;
        this.Navigation.PushAsync((Page) new NewsFeedDetailsPage(newsarticle), true);
      }
      else
        Acr.UserDialogs.UserDialogs.Instance.Toast("Network Error. Please check your internet connection.");
    }

    private void Refresh_Tapped(object sender, EventArgs e)
    {
      if (!this._isConnected)
        return;
      Device.BeginInvokeOnMainThread((Action) (() => this.refreshIndicator.IsVisible = true));
      this.RefreshNewsFeed();
    }

    private void btnViewMore_Clicked(object sender, EventArgs e)
    {
      if (this._isConnected)
      {
        ++this.page;
        NewsData newsData = new NewsData();
        Device.BeginInvokeOnMainThread((Action) (() =>
        {
          this.activityIndicator.IsVisible = true;
          this.btnViewMore.IsVisible = false;
        }));
        Task.Run((Func<Task>) (async () => await newsData.DownloadNewsArticles(this.page))).ContinueWith((Action<Task>) (result => Device.BeginInvokeOnMainThread((Action) (() =>
        {
          this.LoadNewsFeed();
          this.activityIndicator.IsVisible = false;
          this.btnViewMore.IsVisible = true;
        }))));
      }
      else
        Acr.UserDialogs.UserDialogs.Instance.Toast("Network Error. Please check your internet connection.");
    }

    private void RefreshNewsFeed()
    {
      NewsData newsData = new NewsData();
      Task.Run((Func<Task>) (async () =>
      {
        if (!await this.CheckUpdate())
          return;
        await newsData.DownloadNewsArticles(1);
      })).ContinueWith((Action<Task>) (result => Device.BeginInvokeOnMainThread((Action) (() =>
      {
        this.refreshIndicator.IsVisible = false;
        if (!this._updateNews)
          return;
        this.LoadNewsFeed();
      }))));
    }

    private async Task<bool> CheckUpdate()
    {
      NewsData newsData = new NewsData();
      List<NewsArticles> source = JsonConvert.DeserializeObject<List<NewsArticles>>(await new HttpClient().GetStringAsync(this.NewsFeedUri + "?sort=-id"));
      List<NewsArticles> result = newsData.GetNewsArticleAsync().Result;
      if (result.Count == 0)
        return true;
      if (result.FirstOrDefault<NewsArticles>().newsno != source.FirstOrDefault<NewsArticles>().newsno)
      {
        this._updateNews = true;
        return true;
      }
      this._updateNews = false;
      return false;
    }

    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private void InitializeComponent()
    {
      if (ResourceLoader.ResourceProvider != null && ResourceLoader.ResourceProvider(typeof (NewsFeedPage).GetTypeInfo().Assembly.GetName(), "Views/NewsFeedPage.xaml") != null)
        this.__InitComponentRuntime();
      else if (Xamarin.Forms.Xaml.Internals.XamlLoader.XamlFileProvider != null && Xamarin.Forms.Xaml.Internals.XamlLoader.XamlFileProvider(this.GetType()) != null)
      {
        this.__InitComponentRuntime();
      }
      else
      {
        StaticResourceExtension resourceExtension1 = new StaticResourceExtension();
        ActivityIndicator bindable1 = new ActivityIndicator();
        StackLayout stackLayout1 = new StackLayout();
        DataTemplate dataTemplate1 = new DataTemplate();
        StaticResourceExtension resourceExtension2 = new StaticResourceExtension();
        Button button1 = new Button();
        ActivityIndicator bindable2 = new ActivityIndicator();
        StackLayout stackLayout2 = new StackLayout();
        StackLayout stackLayout3 = new StackLayout();
        ListView listView = new ListView();
        StackLayout bindable3 = new StackLayout();
        NewsFeedPage bindable4 = this;
        NameScope nameScope = new NameScope();
        NameScope.SetNameScope((BindableObject) bindable4, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable3, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) stackLayout1, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("refreshIndicator", (object) stackLayout1);
        if (stackLayout1.StyleId == null)
          stackLayout1.StyleId = "refreshIndicator";
        NameScope.SetNameScope((BindableObject) bindable1, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) listView, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("NewsArticlesListView", (object) listView);
        if (listView.StyleId == null)
          listView.StyleId = "NewsArticlesListView";
        NameScope.SetNameScope((BindableObject) stackLayout3, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("stackMore", (object) stackLayout3);
        if (stackLayout3.StyleId == null)
          stackLayout3.StyleId = "stackMore";
        NameScope.SetNameScope((BindableObject) button1, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("btnViewMore", (object) button1);
        if (button1.StyleId == null)
          button1.StyleId = "btnViewMore";
        NameScope.SetNameScope((BindableObject) stackLayout2, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("activityIndicator", (object) stackLayout2);
        if (stackLayout2.StyleId == null)
          stackLayout2.StyleId = "activityIndicator";
        NameScope.SetNameScope((BindableObject) bindable2, (INameScope) nameScope);
        this.refreshIndicator = stackLayout1;
        this.NewsArticlesListView = listView;
        this.stackMore = stackLayout3;
        this.btnViewMore = button1;
        this.activityIndicator = stackLayout2;
        bindable4.SetValue(Page.TitleProperty, (object) "News Feed");
        resourceExtension1.Key = "PageBackgroundColor";
        StaticResourceExtension resourceExtension3 = resourceExtension1;
        XamlServiceProvider xamlServiceProvider1 = new XamlServiceProvider();
        Type type1 = typeof (IProvideValueTarget);
        object[] objectAndParents1 = new object[0 + 1];
        objectAndParents1[0] = (object) bindable4;
        SimpleValueTargetProvider service1 = new SimpleValueTargetProvider(objectAndParents1, (object) VisualElement.BackgroundColorProperty);
        xamlServiceProvider1.Add(type1, (object) service1);
        xamlServiceProvider1.Add(typeof (INameScopeProvider), (object) new NameScopeProvider()
        {
          NameScope = (INameScope) nameScope
        });
        Type type2 = typeof (IXamlTypeResolver);
        XmlNamespaceResolver namespaceResolver1 = new XmlNamespaceResolver();
        namespaceResolver1.Add("", "http://xamarin.com/schemas/2014/forms");
        namespaceResolver1.Add("x", "http://schemas.microsoft.com/winfx/2009/xaml");
        namespaceResolver1.Add("forms", "clr-namespace:FFImageLoading.Forms;assembly=FFImageLoading.Forms");
        XamlTypeResolver service2 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver1, typeof (NewsFeedPage).GetTypeInfo().Assembly);
        xamlServiceProvider1.Add(type2, (object) service2);
        xamlServiceProvider1.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(7, 14)));
        object obj1 = resourceExtension3.ProvideValue((IServiceProvider) xamlServiceProvider1);
        bindable4.BackgroundColor = (Color) obj1;
        bindable3.SetValue(StackLayout.OrientationProperty, (object) StackOrientation.Vertical);
        bindable3.SetValue(View.VerticalOptionsProperty, (object) LayoutOptions.FillAndExpand);
        bindable3.SetValue(StackLayout.SpacingProperty, (object) 0.0);
        stackLayout1.SetValue(View.MarginProperty, (object) new Thickness(5.0));
        stackLayout1.SetValue(VisualElement.IsVisibleProperty, new VisualElement.VisibilityConverter().ConvertFromInvariantString("False"));
        stackLayout1.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.CenterAndExpand);
        bindable1.SetValue(VisualElement.HeightRequestProperty, (object) 25.0);
        bindable1.SetValue(ActivityIndicator.IsRunningProperty, (object) true);
        stackLayout1.Children.Add((View) bindable1);
        bindable3.Children.Add((View) stackLayout1);
        listView.SetValue(ListView.RowHeightProperty, (object) 130);
        listView.SetValue(VisualElement.IsVisibleProperty, new VisualElement.VisibilityConverter().ConvertFromInvariantString("False"));
        listView.SetValue(View.VerticalOptionsProperty, (object) LayoutOptions.FillAndExpand);
        listView.ItemTapped += new EventHandler<ItemTappedEventArgs>(bindable4.NewsArticlesListView_ItemTapped);
        DataTemplate dataTemplate2 = dataTemplate1;
        // ISSUE: object of a compiler-generated type is created
        // ISSUE: variable of a compiler-generated type
        NewsFeedPage.\u003CInitializeComponent\u003E_anonXamlCDataTemplate_1 xamlCdataTemplate1 = new NewsFeedPage.\u003CInitializeComponent\u003E_anonXamlCDataTemplate_1();
        object[] objArray = new object[0 + 4];
        objArray[0] = (object) dataTemplate1;
        objArray[1] = (object) listView;
        objArray[2] = (object) bindable3;
        objArray[3] = (object) bindable4;
        // ISSUE: reference to a compiler-generated field
        xamlCdataTemplate1.parentValues = objArray;
        // ISSUE: reference to a compiler-generated field
        xamlCdataTemplate1.root = bindable4;
        // ISSUE: reference to a compiler-generated method
        Func<object> func = new Func<object>(xamlCdataTemplate1.LoadDataTemplate);
        ((IDataTemplate) dataTemplate2).LoadTemplate = func;
        listView.SetValue(ItemsView<Cell>.ItemTemplateProperty, (object) dataTemplate1);
        stackLayout3.SetValue(StackLayout.OrientationProperty, (object) StackOrientation.Horizontal);
        stackLayout3.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.FillAndExpand);
        stackLayout3.SetValue(Layout.PaddingProperty, (object) new Thickness(5.0, 10.0, 5.0, 10.0));
        button1.Clicked += new EventHandler(bindable4.btnViewMore_Clicked);
        button1.SetValue(Button.TextProperty, (object) "Show more");
        Button button2 = button1;
        BindableProperty fontSizeProperty = Button.FontSizeProperty;
        FontSizeConverter fontSizeConverter = new FontSizeConverter();
        XamlServiceProvider xamlServiceProvider2 = new XamlServiceProvider();
        Type type3 = typeof (IProvideValueTarget);
        object[] objectAndParents2 = new object[0 + 5];
        objectAndParents2[0] = (object) button1;
        objectAndParents2[1] = (object) stackLayout3;
        objectAndParents2[2] = (object) listView;
        objectAndParents2[3] = (object) bindable3;
        objectAndParents2[4] = (object) bindable4;
        SimpleValueTargetProvider service3 = new SimpleValueTargetProvider(objectAndParents2, (object) Button.FontSizeProperty);
        xamlServiceProvider2.Add(type3, (object) service3);
        xamlServiceProvider2.Add(typeof (INameScopeProvider), (object) new NameScopeProvider()
        {
          NameScope = (INameScope) nameScope
        });
        Type type4 = typeof (IXamlTypeResolver);
        XmlNamespaceResolver namespaceResolver2 = new XmlNamespaceResolver();
        namespaceResolver2.Add("", "http://xamarin.com/schemas/2014/forms");
        namespaceResolver2.Add("x", "http://schemas.microsoft.com/winfx/2009/xaml");
        namespaceResolver2.Add("forms", "clr-namespace:FFImageLoading.Forms;assembly=FFImageLoading.Forms");
        XamlTypeResolver service4 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver2, typeof (NewsFeedPage).GetTypeInfo().Assembly);
        xamlServiceProvider2.Add(type4, (object) service4);
        xamlServiceProvider2.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(56, 101)));
        object obj2 = ((IExtendedTypeConverter) fontSizeConverter).ConvertFromInvariantString("Small", (IServiceProvider) xamlServiceProvider2);
        button2.SetValue(fontSizeProperty, obj2);
        resourceExtension2.Key = "PrimaryColor";
        StaticResourceExtension resourceExtension4 = resourceExtension2;
        XamlServiceProvider xamlServiceProvider3 = new XamlServiceProvider();
        Type type5 = typeof (IProvideValueTarget);
        object[] objectAndParents3 = new object[0 + 5];
        objectAndParents3[0] = (object) button1;
        objectAndParents3[1] = (object) stackLayout3;
        objectAndParents3[2] = (object) listView;
        objectAndParents3[3] = (object) bindable3;
        objectAndParents3[4] = (object) bindable4;
        SimpleValueTargetProvider service5 = new SimpleValueTargetProvider(objectAndParents3, (object) Button.TextColorProperty);
        xamlServiceProvider3.Add(type5, (object) service5);
        xamlServiceProvider3.Add(typeof (INameScopeProvider), (object) new NameScopeProvider()
        {
          NameScope = (INameScope) nameScope
        });
        Type type6 = typeof (IXamlTypeResolver);
        XmlNamespaceResolver namespaceResolver3 = new XmlNamespaceResolver();
        namespaceResolver3.Add("", "http://xamarin.com/schemas/2014/forms");
        namespaceResolver3.Add("x", "http://schemas.microsoft.com/winfx/2009/xaml");
        namespaceResolver3.Add("forms", "clr-namespace:FFImageLoading.Forms;assembly=FFImageLoading.Forms");
        XamlTypeResolver service6 = new XamlTypeResolver((IXmlNamespaceResolver) namespaceResolver3, typeof (NewsFeedPage).GetTypeInfo().Assembly);
        xamlServiceProvider3.Add(type6, (object) service6);
        xamlServiceProvider3.Add(typeof (IXmlLineInfoProvider), (object) new XmlLineInfoProvider((IXmlLineInfo) new XmlLineInfo(56, 118)));
        object obj3 = resourceExtension4.ProvideValue((IServiceProvider) xamlServiceProvider3);
        button1.TextColor = (Color) obj3;
        button1.SetValue(VisualElement.BackgroundColorProperty, (object) Color.White);
        button1.SetValue(Button.FontAttributesProperty, (object) FontAttributes.Bold);
        button1.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.FillAndExpand);
        stackLayout3.Children.Add((View) button1);
        stackLayout2.SetValue(View.MarginProperty, (object) new Thickness(5.0));
        stackLayout2.SetValue(VisualElement.IsVisibleProperty, new VisualElement.VisibilityConverter().ConvertFromInvariantString("False"));
        stackLayout2.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.CenterAndExpand);
        bindable2.SetValue(VisualElement.HeightRequestProperty, (object) 25.0);
        bindable2.SetValue(ActivityIndicator.IsRunningProperty, (object) true);
        stackLayout2.Children.Add((View) bindable2);
        stackLayout3.Children.Add((View) stackLayout2);
        listView.SetValue(ListView.FooterProperty, (object) stackLayout3);
        bindable3.Children.Add((View) listView);
        bindable4.SetValue(ContentPage.ContentProperty, (object) bindable3);
      }
    }

    private void __InitComponentRuntime()
    {
      this.LoadFromXaml<NewsFeedPage>(typeof (NewsFeedPage));
      this.refreshIndicator = NameScopeExtensions.FindByName<StackLayout>(this, "refreshIndicator");
      this.NewsArticlesListView = NameScopeExtensions.FindByName<ListView>(this, "NewsArticlesListView");
      this.stackMore = NameScopeExtensions.FindByName<StackLayout>(this, "stackMore");
      this.btnViewMore = NameScopeExtensions.FindByName<Button>(this, "btnViewMore");
      this.activityIndicator = NameScopeExtensions.FindByName<StackLayout>(this, "activityIndicator");
    }
  }
}
