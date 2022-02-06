// Decompiled with JetBrains decompiler
// Type: one_sti_student_portal.Data.FeedbackData
// Assembly: one_sti_student_portal, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 39E34984-485E-45CE-9895-F7524E3024D6
// Assembly location: \\wsl.localhost\kali-linux\root\One STI Student Portal_1.3.8_apkcombo.com (1)\unknown\assemblies\one_sti_student_portal.dll

using Newtonsoft.Json;
using one_sti_student_portal.DependencyServices;
using one_sti_student_portal.Models;
using SQLite;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace one_sti_student_portal.Data
{
  public class FeedbackData
  {
    private SQLiteAsyncConnection _connection;

    public FeedbackData()
    {
      this._connection = DependencyService.Get<ISQLite>().SQLiteConnection();
      this._connection.CreateTableAsync<FeedbackWithReply>().Wait();
    }

    public async Task DownloadMyFeedbacks(string email)
    {
      foreach (FeedbackWithReply feedbackWithReply in JsonConvert.DeserializeObject<List<FeedbackWithReply>>(await new HttpClient().GetStringAsync(Constants.StudentAPIUri + "/get_my_feedback/" + email + "/")))
      {
        int num = await this.SaveMyFeedback(new FeedbackWithReply()
        {
          conversation_id = feedbackWithReply.conversation_id,
          created_on = feedbackWithReply.created_on,
          created_on_formatted = feedbackWithReply.created_on.ToString("MMM dd, yyyy hh:mm tt").ToString().ToUpper(),
          feedback = feedbackWithReply.feedback,
          feedback_id = feedbackWithReply.feedback_id,
          display_name = feedbackWithReply.display_name,
          replied_on = feedbackWithReply.replied_on,
          unread = feedbackWithReply.unread,
          reply = feedbackWithReply.reply,
          subject = feedbackWithReply.subject,
          username = feedbackWithReply.username,
          helpful = feedbackWithReply.helpful
        });
      }
    }

    public async Task MarkAsRead(string feedback_id)
    {
      string stringAsync = await new HttpClient().GetStringAsync(Constants.StudentAPIUri + "/mark_as_read/" + feedback_id + "/");
    }

    public async Task MarkAsHelpful(string feedback_id, string helpful)
    {
      string stringAsync = await new HttpClient().GetStringAsync(Constants.StudentAPIUri + "/mark_as_helpful/" + feedback_id + "/" + helpful + "/");
    }

    private Task<int> SaveMyFeedback(FeedbackWithReply feedback)
    {
      List<FeedbackWithReply> result = this.GetFeedbackWithReply(feedback.feedback_id).Result;
      if (result.Count == 0)
        return this._connection.InsertAsync((object) feedback);
      feedback.id = result[0].id;
      return this._connection.UpdateAsync((object) feedback);
    }

    public Task<List<FeedbackWithReply>> GetFeedbackWithReply(
      int feedback_id)
    {
      return this._connection.QueryAsync<FeedbackWithReply>("SELECT * FROM FeedbackWithReply WHERE feedback_id=?", (object) feedback_id);
    }

    public Task<List<FeedbackWithReply>> GetMyFeedbacks(string email) => email != "cedric.gabrang@sti.edu" ? this._connection.QueryAsync<FeedbackWithReply>("SELECT * FROM FeedbackWithReply WHERE username=? ORDER BY created_on DESC", (object) email) : this._connection.QueryAsync<FeedbackWithReply>("SELECT * FROM FeedbackWithReply ORDER BY created_on DESC", (object) email);

    public Task<List<FeedbackWithReply>> GetFeedbackDetail(int feedback_id) => this._connection.QueryAsync<FeedbackWithReply>("SELECT * FROM FeedbackWithReply WHERE feedback_id=?", (object) feedback_id);

    public void MarkAsRead(int feedback_id) => this._connection.QueryAsync<FeedbackWithReply>("UPDATE FeedbackWithReply SET unread='false' WHERE feedback_id=?", (object) feedback_id);

    public void MarkAsHelpful(int feedback_id, string helpful) => this._connection.QueryAsync<FeedbackWithReply>("UPDATE FeedbackWithReply SET helpful='" + helpful + "' WHERE feedback_id=?", (object) feedback_id);

    public Task DeleteFeedbacks() => (Task) this._connection.QueryAsync<FeedbackWithReply>("DELETE FROM FeedbackWithReply");
  }
}
