// Decompiled with JetBrains decompiler
// Type: one_sti_student_portal.Views.LogoutPage
// Assembly: one_sti_student_portal, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 39E34984-485E-45CE-9895-F7524E3024D6
// Assembly location: \\wsl.localhost\kali-linux\root\One STI Student Portal_1.3.8_apkcombo.com (1)\unknown\assemblies\one_sti_student_portal.dll

using one_sti_student_portal.Data;
using System;
using System.CodeDom.Compiler;
using System.Reflection;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace one_sti_student_portal.Views
{
  [XamlCompilation(XamlCompilationOptions.Compile)]
  [XamlFilePath("Views\\LogoutPage.xaml")]
  public class LogoutPage : ContentPage
  {
    private StudentData _studentData;
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private Label lblLoggingIn;

    public LogoutPage()
    {
      this.InitializeComponent();
      NavigationPage.SetHasNavigationBar((BindableObject) this, false);
      this._studentData = new StudentData();
    }

    protected override void OnAppearing()
    {
      base.OnAppearing();
      Device.StartTimer(TimeSpan.FromSeconds(2.0), (Func<bool>) (() =>
      {
        Device.BeginInvokeOnMainThread((Action) (() =>
        {
          if (!this._studentData.ClearData())
            return;
          Application.Current.MainPage = (Page) new NavigationPage((Page) new LoginPage());
        }));
        return false;
      }));
    }

    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private void InitializeComponent()
    {
      if (ResourceLoader.ResourceProvider != null && ResourceLoader.ResourceProvider(typeof (LogoutPage).GetTypeInfo().Assembly.GetName(), "Views/LogoutPage.xaml") != null)
        this.__InitComponentRuntime();
      else if (Xamarin.Forms.Xaml.Internals.XamlLoader.XamlFileProvider != null && Xamarin.Forms.Xaml.Internals.XamlLoader.XamlFileProvider(this.GetType()) != null)
      {
        this.__InitComponentRuntime();
      }
      else
      {
        Image bindable1 = new Image();
        RowDefinition bindable2 = new RowDefinition();
        RowDefinition bindable3 = new RowDefinition();
        ColumnDefinition bindable4 = new ColumnDefinition();
        Image bindable5 = new Image();
        ActivityIndicator bindable6 = new ActivityIndicator();
        Label label = new Label();
        StackLayout bindable7 = new StackLayout();
        Grid bindable8 = new Grid();
        StackLayout bindable9 = new StackLayout();
        LogoutPage bindable10 = this;
        NameScope nameScope = new NameScope();
        NameScope.SetNameScope((BindableObject) bindable10, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable9, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable1, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable8, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable2, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable3, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable4, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable5, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable7, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable6, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) label, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("lblLoggingIn", (object) label);
        if (label.StyleId == null)
          label.StyleId = "lblLoggingIn";
        this.lblLoggingIn = label;
        bindable10.SetValue(Page.BackgroundImageProperty, (object) "onesti_bg");
        bindable10.SetValue(VisualElement.BackgroundColorProperty, (object) new Color(0.0431372560560703, 0.341176480054855, 0.576470613479614, 1.0));
        bindable9.SetValue(View.VerticalOptionsProperty, (object) LayoutOptions.FillAndExpand);
        bindable1.SetValue(View.MarginProperty, (object) new Thickness(0.0, 0.0, 35.0, 0.0));
        bindable1.SetValue(Image.SourceProperty, new ImageSourceConverter().ConvertFromInvariantString("sti_logo.png"));
        bindable1.SetValue(View.HorizontalOptionsProperty, (object) LayoutOptions.End);
        bindable1.SetValue(VisualElement.MinimumHeightRequestProperty, (object) 60.0);
        bindable1.SetValue(VisualElement.HeightRequestProperty, (object) 60.0);
        bindable9.Children.Add((View) bindable1);
        bindable8.SetValue(View.VerticalOptionsProperty, (object) LayoutOptions.FillAndExpand);
        bindable2.SetValue(RowDefinition.HeightProperty, new GridLengthTypeConverter().ConvertFromInvariantString("*"));
        ((DefinitionCollection<RowDefinition>) bindable8.GetValue(Grid.RowDefinitionsProperty)).Add(bindable2);
        bindable3.SetValue(RowDefinition.HeightProperty, new GridLengthTypeConverter().ConvertFromInvariantString("*"));
        ((DefinitionCollection<RowDefinition>) bindable8.GetValue(Grid.RowDefinitionsProperty)).Add(bindable3);
        bindable4.SetValue(ColumnDefinition.WidthProperty, new GridLengthTypeConverter().ConvertFromInvariantString("*"));
        ((DefinitionCollection<ColumnDefinition>) bindable8.GetValue(Grid.ColumnDefinitionsProperty)).Add(bindable4);
        bindable5.SetValue(View.MarginProperty, (object) new Thickness(15.0, 0.0, 15.0, 0.0));
        bindable5.SetValue(Image.SourceProperty, new ImageSourceConverter().ConvertFromInvariantString("onestiapp_logo.png"));
        bindable5.SetValue(Grid.RowProperty, (object) 0);
        bindable5.SetValue(Grid.ColumnProperty, (object) 0);
        bindable5.SetValue(View.VerticalOptionsProperty, (object) LayoutOptions.FillAndExpand);
        bindable8.Children.Add((View) bindable5);
        bindable7.SetValue(Grid.RowProperty, (object) 1);
        bindable7.SetValue(Grid.ColumnProperty, (object) 0);
        bindable6.SetValue(ActivityIndicator.IsRunningProperty, (object) true);
        bindable6.SetValue(VisualElement.HeightRequestProperty, (object) 30.0);
        bindable6.SetValue(ActivityIndicator.ColorProperty, (object) Color.White);
        bindable7.Children.Add((View) bindable6);
        label.SetValue(Label.TextProperty, (object) "Logging out...");
        label.SetValue(Label.TextColorProperty, (object) Color.White);
        label.SetValue(Label.HorizontalTextAlignmentProperty, new TextAlignmentConverter().ConvertFromInvariantString("Center"));
        bindable7.Children.Add((View) label);
        bindable8.Children.Add((View) bindable7);
        bindable9.Children.Add((View) bindable8);
        bindable10.SetValue(ContentPage.ContentProperty, (object) bindable9);
      }
    }

    private void __InitComponentRuntime()
    {
      this.LoadFromXaml<LogoutPage>(typeof (LogoutPage));
      this.lblLoggingIn = NameScopeExtensions.FindByName<Label>(this, "lblLoggingIn");
    }
  }
}
