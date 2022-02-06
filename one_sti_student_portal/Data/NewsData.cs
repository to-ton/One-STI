// Decompiled with JetBrains decompiler
// Type: one_sti_student_portal.Data.NewsData
// Assembly: one_sti_student_portal, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 39E34984-485E-45CE-9895-F7524E3024D6
// Assembly location: \\wsl.localhost\kali-linux\root\One STI Student Portal_1.3.8_apkcombo.com (1)\unknown\assemblies\one_sti_student_portal.dll

using Newtonsoft.Json;
using one_sti_student_portal.DependencyServices;
using one_sti_student_portal.Models;
using SQLite;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace one_sti_student_portal.Data
{
  public class NewsData
  {
    private SQLiteAsyncConnection _connection;
    private int _pagesize = 15;

    public NewsData()
    {
      this._connection = DependencyService.Get<ISQLite>().SQLiteConnection();
      this._connection.CreateTableAsync<NewsArticles>().Wait();
    }

    public async Task DownloadNewsArticles(int page)
    {
      List<NewsArticles> source = JsonConvert.DeserializeObject<List<NewsArticles>>(await new HttpClient().GetStringAsync(Constants.NewsFeedUri));
      this.GetNewsArticleAsync();
      int pagesize = this._pagesize;
      int num1 = (page - 1) * pagesize + 1;
      foreach (NewsArticles newsArticles in source.Count != 0 ? source.Skip<NewsArticles>(num1 - 1).Take<NewsArticles>(pagesize).ToList<NewsArticles>() : source)
      {
        if (newsArticles.published == "True")
        {
          int num2 = await this.SaveNews(new NewsArticles()
          {
            category = newsArticles.category,
            content_text = newsArticles.content_text,
            datepub = newsArticles.datepub,
            newsno = newsArticles.newsno,
            pic_large = newsArticles.imagepathlink,
            title = newsArticles.title
          });
        }
      }
    }

    public Task<List<NewsArticles>> GetNewsArticleAsync(string newsNo = null)
    {
      if (newsNo == null)
        return this._connection.QueryAsync<NewsArticles>("SELECT * FROM NewsArticles ORDER BY newsno DESC");
      return this._connection.QueryAsync<NewsArticles>("SELECT * FROM NewsArticles WHERE newsno=?", (object) newsNo);
    }

    public Task<int> SaveNews(NewsArticles newsArticle)
    {
      NewsArticles newsArticles = this.GetNewsArticleAsync(newsArticle.newsno.ToString()).Result.FirstOrDefault<NewsArticles>();
      if (newsArticles == null)
        return this._connection.InsertAsync((object) newsArticle);
      newsArticle.id = newsArticles.id;
      return this._connection.UpdateAsync((object) newsArticle);
    }
  }
}
