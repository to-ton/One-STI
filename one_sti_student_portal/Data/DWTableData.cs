// Decompiled with JetBrains decompiler
// Type: one_sti_student_portal.Data.DWTableData
// Assembly: one_sti_student_portal, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 39E34984-485E-45CE-9895-F7524E3024D6
// Assembly location: \\wsl.localhost\kali-linux\root\One STI Student Portal_1.3.8_apkcombo.com (1)\unknown\assemblies\one_sti_student_portal.dll

using Newtonsoft.Json.Linq;
using one_sti_student_portal.DependencyServices;
using one_sti_student_portal.Models;
using one_sti_student_portal.Services;
using SQLite;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace one_sti_student_portal.Data
{
  public class DWTableData
  {
    private SQLiteAsyncConnection _connection;

    public DWTableData()
    {
      this._connection = DependencyService.Get<ISQLite>().SQLiteConnection();
      this._connection.CreateTableAsync<DWTablesProperty>().Wait();
    }

    public Task<List<DWTablesProperty>> GetTableProperty(string table_name) => this._connection.QueryAsync<DWTablesProperty>("SELECT * FROM DWTablesProperty WHERE TableName=?", (object) table_name);

    public async Task DownloadTableProperty(string table_name)
    {
      JObject tableProperty1 = await new StudentService().get_table_property(table_name);
      DWTablesProperty tableProperty = new DWTablesProperty()
      {
        TableName = (string) tableProperty1[nameof (table_name)],
        CreateDate = (DateTime) tableProperty1["create_date"],
        ModifyDate = (DateTime) tableProperty1["modify_date"]
      };
      await this.DeleteTableProperty(tableProperty.TableName);
      int num = await this.SaveTableProperty(tableProperty);
      tableProperty = (DWTablesProperty) null;
    }

    public Task<int> SaveTableProperty(DWTablesProperty tableProperty) => this._connection.InsertAsync((object) tableProperty);

    public Task DeleteTableProperty(string table_name) => (Task) this._connection.QueryAsync<DWTablesProperty>("DELETE FROM DWTablesProperty WHERE TableName=?", (object) table_name);
  }
}
