// Decompiled with JetBrains decompiler
// Type: one_sti_student_portal.Views.NewsFeedDetailsPage
// Assembly: one_sti_student_portal, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 39E34984-485E-45CE-9895-F7524E3024D6
// Assembly location: \\wsl.localhost\kali-linux\root\One STI Student Portal_1.3.8_apkcombo.com (1)\unknown\assemblies\one_sti_student_portal.dll

using Acr.UserDialogs;
using one_sti_student_portal.Models;
using System;
using System.CodeDom.Compiler;
using System.Reflection;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace one_sti_student_portal.Views
{
  [XamlCompilation(XamlCompilationOptions.Compile)]
  [XamlFilePath("Views\\NewsFeedDetailsPage.xaml")]
  public class NewsFeedDetailsPage : ContentPage
  {
    private int newsarticleId;
    private int newsarticleNewsno;
    private string newsarticleCategory;
    private string newsarticleURL;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private WebView webview;

    public NewsFeedDetailsPage(NewsArticles newsarticle)
    {
      this.InitializeComponent();
      this.Title = "News Feed";
      this.newsarticleId = newsarticle.id;
      this.newsarticleNewsno = newsarticle.newsno;
      this.newsarticleCategory = newsarticle.category;
      Device.BeginInvokeOnMainThread((Action) (() => Acr.UserDialogs.UserDialogs.Instance.ShowLoading("Loading...", new MaskType?(MaskType.Black))));
      Task.Run((Action) (() =>
      {
        if (this.newsarticleCategory == "Local")
          this.newsarticleURL = "https://www.sti.edu";
        else
          this.newsarticleURL = "https://www.sti.edu/onestiappnews2.asp?id=" + this.newsarticleNewsno.ToString();
      })).ContinueWith((Action<Task>) (result => Device.BeginInvokeOnMainThread((Action) (() =>
      {
        this.webview.Source = (WebViewSource) this.newsarticleURL;
        Acr.UserDialogs.UserDialogs.Instance.HideLoading();
      }))));
    }

    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private void InitializeComponent()
    {
      if (ResourceLoader.ResourceProvider != null && ResourceLoader.ResourceProvider(typeof (NewsFeedDetailsPage).GetTypeInfo().Assembly.GetName(), "Views/NewsFeedDetailsPage.xaml") != null)
        this.__InitComponentRuntime();
      else if (Xamarin.Forms.Xaml.Internals.XamlLoader.XamlFileProvider != null && Xamarin.Forms.Xaml.Internals.XamlLoader.XamlFileProvider(this.GetType()) != null)
      {
        this.__InitComponentRuntime();
      }
      else
      {
        WebView webView = new WebView();
        StackLayout bindable1 = new StackLayout();
        NewsFeedDetailsPage bindable2 = this;
        NameScope nameScope = new NameScope();
        NameScope.SetNameScope((BindableObject) bindable2, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable1, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) webView, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("webview", (object) webView);
        if (webView.StyleId == null)
          webView.StyleId = "webview";
        this.webview = webView;
        bindable2.SetValue(Page.TitleProperty, (object) "Feed Details");
        bindable1.SetValue(StackLayout.OrientationProperty, (object) StackOrientation.Vertical);
        bindable1.SetValue(View.VerticalOptionsProperty, (object) LayoutOptions.FillAndExpand);
        bindable1.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.FillAndExpand);
        webView.SetValue(View.VerticalOptionsProperty, (object) LayoutOptions.FillAndExpand);
        webView.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.FillAndExpand);
        bindable1.Children.Add((View) webView);
        bindable2.SetValue(ContentPage.ContentProperty, (object) bindable1);
      }
    }

    private void __InitComponentRuntime()
    {
      this.LoadFromXaml<NewsFeedDetailsPage>(typeof (NewsFeedDetailsPage));
      this.webview = NameScopeExtensions.FindByName<WebView>(this, "webview");
    }
  }
}
