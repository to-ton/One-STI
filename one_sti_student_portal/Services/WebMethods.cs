// Decompiled with JetBrains decompiler
// Type: one_sti_student_portal.Services.WebMethods
// Assembly: one_sti_student_portal, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 39E34984-485E-45CE-9895-F7524E3024D6
// Assembly location: \\wsl.localhost\kali-linux\root\One STI Student Portal_1.3.8_apkcombo.com (1)\unknown\assemblies\one_sti_student_portal.dll

using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace one_sti_student_portal.Services
{
  public class WebMethods
  {
    public static async Task<string> MakeGetRequest(string url)
    {
      string empty = string.Empty;
      try
      {
        HttpWebResponse responseAsync = await WebRequest.Create(url).GetResponseAsync() as HttpWebResponse;
        if (responseAsync.StatusCode != HttpStatusCode.OK)
          return "error";
        using (StreamReader streamReader = new StreamReader(responseAsync.GetResponseStream()))
        {
          string request = streamReader.ReadToEnd();
          if (string.IsNullOrWhiteSpace(request))
            request = responseAsync.StatusCode.ToString() + "Response contained an empty body ...";
          return request;
        }
      }
      catch
      {
        return "error";
      }
    }

    public static async Task<string> MakePostRequest(string url, object content)
    {
      try
      {
        HttpClient httpClient = new HttpClient();
        HttpContent httpContent1 = (HttpContent) new StringContent(JsonConvert.SerializeObject(content));
        httpContent1.Headers.ContentType = new MediaTypeHeaderValue("application/json");
        string str = url;
        HttpContent httpContent2 = httpContent1;
        return (await httpClient.PostAsync(str, httpContent2)).Content.ReadAsStringAsync().Result;
      }
      catch (Exception ex)
      {
        string message = ex.Message;
        return "error";
      }
    }
  }
}
