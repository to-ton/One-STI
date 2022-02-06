// Decompiled with JetBrains decompiler
// Type: one_sti_student_portal.Helpers.MailHelper
// Assembly: one_sti_student_portal, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 39E34984-485E-45CE-9895-F7524E3024D6
// Assembly location: \\wsl.localhost\kali-linux\root\One STI Student Portal_1.3.8_apkcombo.com (1)\unknown\assemblies\one_sti_student_portal.dll

using Microsoft.Graph;
using System.IO;
using System.Threading.Tasks;

namespace one_sti_student_portal.Helpers
{
  public class MailHelper
  {
    public async Task<Stream> GetCurrentUserPhotoStreamAsync()
    {
      Stream async;
      try
      {
        async = await AuthenticationHelper.GetAuthenticatedClient().Me.Photo.Content.Request().GetAsync();
      }
      catch (ServiceException ex)
      {
        return (Stream) null;
      }
      return async;
    }
  }
}
