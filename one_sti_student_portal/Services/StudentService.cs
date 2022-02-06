// Decompiled with JetBrains decompiler
// Type: one_sti_student_portal.Services.StudentService
// Assembly: one_sti_student_portal, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 39E34984-485E-45CE-9895-F7524E3024D6
// Assembly location: \\wsl.localhost\kali-linux\root\One STI Student Portal_1.3.8_apkcombo.com (1)\unknown\assemblies\one_sti_student_portal.dll

using Newtonsoft.Json.Linq;
using one_sti_student_portal.Models;
using System.Net.Http;
using System.Threading.Tasks;

namespace one_sti_student_portal.Services
{
  public class StudentService
  {
    public async Task<JArray> get_due_details(string pscsId, string term, string level)
    {
      JArray jarray = new JArray();
      return JArray.Parse(await WebMethods.MakeGetRequest(Constants.StudentAPIUri + "/get_due_details/" + pscsId + "/" + term + "/" + level));
    }

    public async Task<JArray> get_student_current_due(string pscsId)
    {
      JArray jarray = new JArray();
      return JArray.Parse(await WebMethods.MakeGetRequest(Constants.StudentAPIUri + "/get_student_current_due/" + pscsId));
    }

    public async Task<JObject> get_table_property(string table_name)
    {
      JObject jobject = new JObject();
      return JObject.Parse(await WebMethods.MakeGetRequest(Constants.StudentAPIUri + "/table_property/" + table_name + "/"));
    }

    public async Task<JObject> get_student_info_complete(string email)
    {
      JObject jobject = new JObject();
      return JObject.Parse(await WebMethods.MakeGetRequest(Constants.StudentAPIUri + "/student_info_complete/" + email + "/"));
    }

    public async Task<JObject> get_student_info_by_id(string id)
    {
      JObject jobject = new JObject();
      return JObject.Parse(await WebMethods.MakeGetRequest(Constants.StudentAPIUri + "/student_info_by_id/" + id + "/"));
    }

    public async Task<JObject> get_student_history(string pscsId, string strm) => JObject.Parse(await new HttpClient().GetStringAsync(Constants.StudentAPIUri + "/get_student_history/" + pscsId + "/" + strm));

    public async Task<JArray> get_student_checklist(string pscs_id)
    {
      JArray jarray = new JArray();
      return JArray.Parse(await WebMethods.MakeGetRequest(Constants.StudentAPIUri + "/get_student_checklist/" + pscs_id));
    }

    public async Task<JArray> get_curriculum_checklist(string pscs_id, string acad_prog)
    {
      JArray jarray = new JArray();
      return JArray.Parse(await WebMethods.MakeGetRequest(Constants.StudentAPIUri + "/get_curriculum_checklist/" + pscs_id + "/" + acad_prog));
    }

    public async Task<JArray> get_student_checklist_only(string pscs_id)
    {
      JArray jarray = new JArray();
      return JArray.Parse(await WebMethods.MakeGetRequest(Constants.StudentAPIUri + "/get_student_checklist_only/" + pscs_id));
    }

    public async Task<JArray> get_curriculum_details(
      string pscs_id,
      string requirement_group,
      string requirement_group_date)
    {
      JArray jarray = new JArray();
      return JArray.Parse(await WebMethods.MakeGetRequest(Constants.StudentAPIUri + "/get_curriculum_details/" + pscs_id + "/" + requirement_group + "/" + requirement_group_date));
    }

    public async Task<JArray> get_student_semester(string pscs_id)
    {
      JArray jarray = new JArray();
      return JArray.Parse(await WebMethods.MakeGetRequest(Constants.StudentAPIUri + "/get_semester/" + pscs_id));
    }

    public async Task<JArray> get_subjects_per_semester(string pscs_id, string strm)
    {
      JArray jarray = new JArray();
      return JArray.Parse(await WebMethods.MakeGetRequest(Constants.StudentAPIUri + "/get_subjects_per_semester_new/" + pscs_id + "/" + strm));
    }

    public async Task<JArray> get_all_student_subject(string pscs_id)
    {
      JArray jarray = new JArray();
      return JArray.Parse(await WebMethods.MakeGetRequest(Constants.StudentAPIUri + "/get_all_subjects/" + pscs_id));
    }

    public async Task<JArray> get_student_semester_subject(string pscs_id, string strm)
    {
      JArray jarray = new JArray();
      return JArray.Parse(await WebMethods.MakeGetRequest(Constants.StudentAPIUri + "/get_subjects/" + pscs_id + "/" + strm));
    }

    public async Task<JArray> get_student_semester_gwa(string pscs_id, string strm)
    {
      JArray jarray = new JArray();
      return JArray.Parse(await WebMethods.MakeGetRequest(Constants.StudentAPIUri + "/get_gwa/" + pscs_id + "/" + strm));
    }

    public async Task<JArray> get_all_student_subject_grade(string pscs_id)
    {
      JArray jarray = new JArray();
      return JArray.Parse(await WebMethods.MakeGetRequest(Constants.StudentAPIUri + "/get_all_subjects_grade/" + pscs_id));
    }

    public async Task<JArray> get_all_student_subject_grade(string pscs_id, string strm)
    {
      JArray jarray = new JArray();
      return JArray.Parse(await WebMethods.MakeGetRequest(Constants.StudentAPIUri + "/get_subjects_grade_new/" + pscs_id + "/" + strm));
    }

    public async Task<JArray> get_all_student_schedule(string pscs_id)
    {
      JArray jarray = new JArray();
      return JArray.Parse(await WebMethods.MakeGetRequest(Constants.StudentAPIUri + "/get_all_student_schedule/" + pscs_id));
    }

    public async Task<JArray> get_schedule_per_sem(string pscs_id, string strm)
    {
      JArray jarray = new JArray();
      return JArray.Parse(await WebMethods.MakeGetRequest(Constants.StudentAPIUri + "/get_schedule_per_sem/" + pscs_id + "/" + strm));
    }

    public async Task<JObject> get_student_settings(string pscs_id)
    {
      JObject jobject = new JObject();
      return JObject.Parse(await WebMethods.MakeGetRequest(Constants.StudentAPIUri + "/get_students_settings/" + pscs_id));
    }

    public async Task<JObject> get_latest_app_version()
    {
      JObject jobject = new JObject();
      return JObject.Parse(await WebMethods.MakeGetRequest(Constants.StudentAPIUri + "/get_current_app_version/student_portal/"));
    }

    public async Task<string> validate_security_key(string pscs_id, string hash)
    {
      JObject jobject = new JObject();
      return (await WebMethods.MakeGetRequest(Constants.StudentAPIUri + "/get_check_hash/" + pscs_id + "/" + hash)).Replace("\"", "").Replace("/", "");
    }

    public async Task<string> CheckServerStatus()
    {
      JObject jobject = new JObject();
      return (await WebMethods.MakeGetRequest(Constants.StudentAPIUri + "/serverstatus")).Replace("\"", "").Replace("/", "");
    }

    public async Task<string> CheckAppVersion(string versionCode)
    {
      JObject jobject = new JObject();
      return (await WebMethods.MakeGetRequest(Constants.StudentAPIUri + "/app_version/" + versionCode)).Replace("\"", "").Replace("/", "");
    }

    public async Task<JArray> get_student_net_assessment(string pscs_id)
    {
      JArray jarray = new JArray();
      return JArray.Parse(await WebMethods.MakeGetRequest(Constants.StudentAPIUri + "/get_net_assessment/" + pscs_id));
    }

    public async Task<JArray> get_student_charges_payment(string pscs_id)
    {
      JArray jarray = new JArray();
      return JArray.Parse(await WebMethods.MakeGetRequest(Constants.StudentAPIUri + "/get_student_charges_payment/" + pscs_id));
    }

    public async Task<JArray> get_student_charges_payment_per_semester(
      string pscs_id,
      string strm)
    {
      JArray jarray = new JArray();
      return JArray.Parse(await WebMethods.MakeGetRequest(Constants.StudentAPIUri + "/get_student_charges_payment_per_semester/" + pscs_id + "/" + strm));
    }

    public async Task<JArray> get_student_charges_due_date(string pscs_id)
    {
      JArray jarray = new JArray();
      return JArray.Parse(await WebMethods.MakeGetRequest(Constants.StudentAPIUri + "/get_student_charges_due_date/" + pscs_id));
    }

    public async Task<JArray> get_student_charges_due_date_per_semester(
      string pscs_id,
      string strm)
    {
      JArray jarray = new JArray();
      return JArray.Parse(await WebMethods.MakeGetRequest(Constants.StudentAPIUri + "/get_student_charges_due_date_per_semester/" + pscs_id + "/" + strm));
    }

    public async Task<JArray> get_osf_details(
      string pscs_id,
      string business_unit,
      string strm)
    {
      JArray jarray = new JArray();
      return JArray.Parse(await WebMethods.MakeGetRequest(Constants.StudentAPIUri + "/get_osf_details/" + pscs_id + "/" + business_unit + "/" + strm));
    }

    public async Task<JArray> get_osf_details_shs(string pscs_id, string strm)
    {
      JArray jarray = new JArray();
      return JArray.Parse(await WebMethods.MakeGetRequest(Constants.StudentAPIUri + "/get_osf_details_shs/" + pscs_id + "/" + strm));
    }

    public async Task<JArray> get_misc_details(
      string pscs_id,
      string business_unit,
      string strm)
    {
      JArray jarray = new JArray();
      return JArray.Parse(await WebMethods.MakeGetRequest(Constants.StudentAPIUri + "/get_misc_details/" + pscs_id + "/" + business_unit + "/" + strm));
    }

    public async Task<JArray> get_tuition_misc_details(string pscs_id, string strm)
    {
      JArray jarray = new JArray();
      return JArray.Parse(await WebMethods.MakeGetRequest(Constants.StudentAPIUri + "/get_tut_misc_details/" + pscs_id + "/" + strm));
    }

    public async Task<string> SendAppUsage(AppUsage appUsage) => await WebMethods.MakePostRequest(Constants.StudentAPIUri + "/send_app_usage", (object) appUsage);

    public async Task<string> SendFeedback(FeedbackModel feedback) => await WebMethods.MakePostRequest(Constants.StudentAPIUri + "/send_feedback", (object) feedback);

    public async Task<string> SendFeedbackReply(FeedbackWithReply reply) => await WebMethods.MakePostRequest(Constants.StudentAPIUri + "/reply_feedback", (object) reply);

    public async Task<string> validate_credentials(StudentCredentials studentCredentials) => await WebMethods.MakePostRequest(Constants.StudentAPIUri + "/retrieve_credentials", (object) studentCredentials);

    public async Task<JObject> get_email_credentials(string pscs_id)
    {
      JObject jobject = new JObject();
      return JObject.Parse(await WebMethods.MakeGetRequest(Constants.StudentAPIUri + "/email_credentials/" + pscs_id));
    }

    public async Task<string> SendLog(AppLogModel appLog) => await WebMethods.MakePostRequest(Constants.StudentAPIUri + "/send_logs", (object) appLog);
  }
}
