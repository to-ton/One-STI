// Decompiled with JetBrains decompiler
// Type: one_sti_student_portal.Views.MasterDetailPageDetail
// Assembly: one_sti_student_portal, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 39E34984-485E-45CE-9895-F7524E3024D6
// Assembly location: \\wsl.localhost\kali-linux\root\One STI Student Portal_1.3.8_apkcombo.com (1)\unknown\assemblies\one_sti_student_portal.dll

using System.CodeDom.Compiler;
using System.Reflection;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace one_sti_student_portal.Views
{
  [XamlCompilation(XamlCompilationOptions.Compile)]
  [XamlFilePath("Views\\MasterDetailPageDetail.xaml")]
  public class MasterDetailPageDetail : ContentPage
  {
    public MasterDetailPageDetail() => this.InitializeComponent();

    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private void InitializeComponent()
    {
      if (ResourceLoader.ResourceProvider != null && ResourceLoader.ResourceProvider(typeof (MasterDetailPageDetail).GetTypeInfo().Assembly.GetName(), "Views/MasterDetailPageDetail.xaml") != null)
        this.__InitComponentRuntime();
      else if (Xamarin.Forms.Xaml.Internals.XamlLoader.XamlFileProvider != null && Xamarin.Forms.Xaml.Internals.XamlLoader.XamlFileProvider(this.GetType()) != null)
      {
        this.__InitComponentRuntime();
      }
      else
      {
        Label bindable1 = new Label();
        StackLayout bindable2 = new StackLayout();
        MasterDetailPageDetail bindable3 = this;
        NameScope nameScope = new NameScope();
        NameScope.SetNameScope((BindableObject) bindable3, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable2, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable1, (INameScope) nameScope);
        bindable3.SetValue(Page.TitleProperty, (object) "Detail");
        bindable2.SetValue(Layout.PaddingProperty, (object) new Thickness(10.0));
        bindable1.SetValue(Label.TextProperty, (object) "This is a detail page. To get the 'triple' line icon on each platform add a icon to each platform and update the 'Master' page with an Icon that references it.");
        bindable2.Children.Add((View) bindable1);
        bindable3.SetValue(ContentPage.ContentProperty, (object) bindable2);
      }
    }

    private void __InitComponentRuntime() => this.LoadFromXaml<MasterDetailPageDetail>(typeof (MasterDetailPageDetail));
  }
}
