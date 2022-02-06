// Decompiled with JetBrains decompiler
// Type: one_sti_student_portal.Data.WidgetsData
// Assembly: one_sti_student_portal, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 39E34984-485E-45CE-9895-F7524E3024D6
// Assembly location: \\wsl.localhost\kali-linux\root\One STI Student Portal_1.3.8_apkcombo.com (1)\unknown\assemblies\one_sti_student_portal.dll

using one_sti_student_portal.DependencyServices;
using one_sti_student_portal.Models.Widget;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace one_sti_student_portal.Data
{
  public class WidgetsData
  {
    private SQLiteAsyncConnection _connection;

    public WidgetsData()
    {
      this._connection = DependencyService.Get<ISQLite>().SQLiteConnection();
      this._connection.CreateTableAsync<WidgetsAvailable>().Wait();
      this._connection.CreateTableAsync<WidgetSettings>().Wait();
    }

    public void DownloadWidgets()
    {
      this.SaveWidget(new WidgetsAvailable()
      {
        Widget = "Latest News",
        CreatedOn = DateTime.Now,
        IsActive = 1
      });
      this.SaveWidget(new WidgetsAvailable()
      {
        Widget = "Classes for Today",
        CreatedOn = DateTime.Now,
        IsActive = 1
      });
      this.SaveWidget(new WidgetsAvailable()
      {
        Widget = "Latest Grade",
        CreatedOn = DateTime.Now,
        IsActive = 1
      });
    }

    public Task<int> SaveWidget(WidgetsAvailable widgetsModel)
    {
      List<WidgetsAvailable> result = this._connection.QueryAsync<WidgetsAvailable>("SELECT * FROM WidgetsAvailable WHERE Widget=?", (object) widgetsModel.Widget).Result;
      if (result.Count == 0)
        return this._connection.InsertAsync((object) widgetsModel);
      widgetsModel.Id = result.FirstOrDefault<WidgetsAvailable>().Id;
      return this._connection.UpdateAsync((object) widgetsModel);
    }

    public Task<List<WidgetsAvailable>> GetWidgetsAvailable() => this._connection.QueryAsync<WidgetsAvailable>("SELECT * FROM WidgetsAvailable WHERE IsActive=1");

    public Task<List<WidgetsAvailable>> GetWidgets() => this._connection.QueryAsync<WidgetsAvailable>("SELECT * FROM WidgetsAvailable");

    public Task<List<WidgetSettings>> GetSelectedWidgets() => this._connection.QueryAsync<WidgetSettings>("SELECT * FROM WidgetSettings ORDER BY AddedOn");

    public Task RemoveWidget(string widget) => (Task) this._connection.QueryAsync<WidgetSettings>("DELETE FROM WidgetSettings WHERE Widget=?", (object) widget);

    public Task<int> UpdateWidgetSettings(WidgetSettings widgetSetting)
    {
      List<WidgetSettings> result = this._connection.QueryAsync<WidgetSettings>("SELECT * FROM WidgetSettings WHERE Widget=?", (object) widgetSetting.Widget).Result;
      if (result.Count == 0)
        return this._connection.InsertAsync((object) widgetSetting);
      widgetSetting.Id = result.FirstOrDefault<WidgetSettings>().Id;
      return this._connection.UpdateAsync((object) widgetSetting);
    }
  }
}
