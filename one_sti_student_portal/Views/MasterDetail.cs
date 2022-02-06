// Decompiled with JetBrains decompiler
// Type: one_sti_student_portal.Views.MasterDetail
// Assembly: one_sti_student_portal, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 39E34984-485E-45CE-9895-F7524E3024D6
// Assembly location: \\wsl.localhost\kali-linux\root\One STI Student Portal_1.3.8_apkcombo.com (1)\unknown\assemblies\one_sti_student_portal.dll

using one_sti_student_portal.Data;
using one_sti_student_portal.Models;
using one_sti_student_portal.Views.Students;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace one_sti_student_portal.Views
{
  [XamlCompilation(XamlCompilationOptions.Compile)]
  [XamlFilePath("Views\\MasterDetail.xaml")]
  public class MasterDetail : MasterDetailPage
  {
    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private MasterDetailPageMaster MasterPage;

    public MasterDetail()
    {
      this.InitializeComponent();
      this.MasterPage.ListView.ItemSelected += new EventHandler<SelectedItemChangedEventArgs>(this.ListView_ItemSelected);
    }

    private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
      MasterDetailPageMenuItem selectedItem = e.SelectedItem as MasterDetailPageMenuItem;
      try
      {
        if (selectedItem.Title.Trim() == "Rate Us!")
        {
          Device.OpenUri(new Uri("https://play.google.com/store/apps/details?id=com.onesti.student.portal"));
        }
        else
        {
          if (selectedItem == null || (object) selectedItem.TargetType == null)
            return;
          Page instance = (Page) Activator.CreateInstance(selectedItem.TargetType);
          MessageSender sender1 = new MessageSender();
          if (selectedItem.Title.Trim() == "View Grades")
            StudentViewTabbedPage.selectedTabIndex = 0;
          else if (selectedItem.Title.Trim() == "View Class Schedule")
            StudentViewTabbedPage.selectedTabIndex = 1;
          else if (selectedItem.Title.Trim() == "Program Curriculum")
            StudentViewTabbedPage.selectedTabIndex = 2;
          else if (selectedItem.Title.Trim() == "Student Balance")
          {
            MessagingCenter.Send<MessageSender>(sender1, "MyAssessment");
            List<StudentInformation> result = new StudentData().GetStudentInformation().Result;
            if (result.Count != 0)
              StudentViewTabbedPage.selectedTabIndex = !result.FirstOrDefault<StudentInformation>().AcadLevel.Contains("G") ? 3 : 2;
          }
          this.Detail = (Page) new NavigationPage(instance);
          this.IsPresented = false;
        }
      }
      catch (Exception ex)
      {
      }
    }

    [GeneratedCode("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
    private void InitializeComponent()
    {
      if (ResourceLoader.ResourceProvider != null && ResourceLoader.ResourceProvider(typeof (MasterDetail).GetTypeInfo().Assembly.GetName(), "Views/MasterDetail.xaml") != null)
        this.__InitComponentRuntime();
      else if (Xamarin.Forms.Xaml.Internals.XamlLoader.XamlFileProvider != null && Xamarin.Forms.Xaml.Internals.XamlLoader.XamlFileProvider(this.GetType()) != null)
      {
        this.__InitComponentRuntime();
      }
      else
      {
        MasterDetailPageMaster detailPageMaster = new MasterDetailPageMaster();
        MasterDetailPageDetail bindable1;
        NavigationPage bindable2 = new NavigationPage((Page) (bindable1 = new MasterDetailPageDetail()));
        MasterDetail bindable3 = this;
        NameScope nameScope = new NameScope();
        NameScope.SetNameScope((BindableObject) bindable3, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) detailPageMaster, (INameScope) nameScope);
        ((INameScope) nameScope).RegisterName("MasterPage", (object) detailPageMaster);
        if (detailPageMaster.StyleId == null)
          detailPageMaster.StyleId = "MasterPage";
        NameScope.SetNameScope((BindableObject) bindable2, (INameScope) nameScope);
        NameScope.SetNameScope((BindableObject) bindable1, (INameScope) nameScope);
        this.MasterPage = detailPageMaster;
        bindable3.Master = (Page) detailPageMaster;
        bindable3.Detail = (Page) bindable2;
      }
    }

    private void __InitComponentRuntime()
    {
      this.LoadFromXaml<MasterDetail>(typeof (MasterDetail));
      this.MasterPage = NameScopeExtensions.FindByName<MasterDetailPageMaster>(this, "MasterPage");
    }
  }
}
