// Decompiled with JetBrains decompiler
// Type: one_sti_student_portal.Data.ApplicationData
// Assembly: one_sti_student_portal, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 39E34984-485E-45CE-9895-F7524E3024D6
// Assembly location: \\wsl.localhost\kali-linux\root\One STI Student Portal_1.3.8_apkcombo.com (1)\unknown\assemblies\one_sti_student_portal.dll

using one_sti_student_portal.DependencyServices;
using one_sti_student_portal.Models;
using SQLite;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace one_sti_student_portal.Data
{
  public class ApplicationData
  {
    private SQLiteAsyncConnection _connection;

    public ApplicationData()
    {
      this._connection = DependencyService.Get<ISQLite>().SQLiteConnection();
      this._connection.CreateTableAsync<AppConstants>().Wait();
    }

    public Task DeleteConstants() => (Task) this._connection.QueryAsync<AppConstants>("DELETE FROM AppConstants");

    public Task<int> SaveConstant(AppConstants appConstants)
    {
      List<AppConstants> result = this._connection.QueryAsync<AppConstants>("SELECT * FROM AppConstants WHERE Constant=?", (object) appConstants.Constant).Result;
      if (result.Count == 0)
        return this._connection.InsertAsync((object) appConstants);
      appConstants.Id = result.FirstOrDefault<AppConstants>().Id;
      return this._connection.UpdateAsync((object) appConstants);
    }

    public string GetConstantValue(string constantName)
    {
      string constantValue = "";
      using (List<AppConstants>.Enumerator enumerator = this._connection.QueryAsync<AppConstants>("SELECT * FROM AppConstants WHERE Constant=?", (object) constantName).Result.GetEnumerator())
      {
        if (enumerator.MoveNext())
          constantValue = enumerator.Current.Value;
      }
      return constantValue;
    }
  }
}
