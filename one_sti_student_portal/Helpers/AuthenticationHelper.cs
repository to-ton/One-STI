// Decompiled with JetBrains decompiler
// Type: one_sti_student_portal.Helpers.AuthenticationHelper
// Assembly: one_sti_student_portal, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 39E34984-485E-45CE-9895-F7524E3024D6
// Assembly location: \\wsl.localhost\kali-linux\root\One STI Student Portal_1.3.8_apkcombo.com (1)\unknown\assemblies\one_sti_student_portal.dll

using Microsoft.Graph;
using Microsoft.Identity.Client;
using one_sti_student_portal.Data;
using one_sti_student_portal.Models;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace one_sti_student_portal.Helpers
{
  public class AuthenticationHelper
  {
    public static string TokenForUser;
    public static DateTimeOffset expiration;
    private static GraphServiceClient graphClient;

    public static GraphServiceClient GetAuthenticatedClient()
    {
      if (AuthenticationHelper.graphClient == null)
      {
        try
        {
          AuthenticationHelper.graphClient = new GraphServiceClient("https://graph.microsoft.com/v1.0", (IAuthenticationProvider) new DelegateAuthenticationProvider((AuthenticateRequestAsyncDelegate) (async requestMessage =>
          {
            string token = "";
            ApplicationData appData = new ApplicationData();
            token = appData.GetConstantValue("token");
            if (string.IsNullOrWhiteSpace(token))
            {
              token = await AuthenticationHelper.GetTokenForUserAsync();
              int num = await appData.SaveConstant(new AppConstants()
              {
                Constant = "token",
                Value = AuthenticationHelper.TokenForUser
              });
            }
            requestMessage.Headers.Authorization = new AuthenticationHeaderValue("bearer", token);
            token = (string) null;
            appData = (ApplicationData) null;
          })));
          return AuthenticationHelper.graphClient;
        }
        catch (Exception ex)
        {
        }
      }
      return AuthenticationHelper.graphClient;
    }

    public static async Task<string> GetTokenForUserAsync()
    {
      if (AuthenticationHelper.TokenForUser == null)
      {
        AuthenticationResult authenticationResult = await App.IdentityClientApp.AcquireTokenAsync((IEnumerable<string>) App.Scopes, App.UiParent);
        AuthenticationHelper.TokenForUser = authenticationResult.AccessToken;
        AuthenticationHelper.expiration = authenticationResult.ExpiresOn;
      }
      return AuthenticationHelper.TokenForUser;
    }

    public static void SignOut()
    {
      foreach (IUser user in App.IdentityClientApp.Users)
        App.IdentityClientApp.Remove(user);
      AuthenticationHelper.graphClient = (GraphServiceClient) null;
      AuthenticationHelper.TokenForUser = (string) null;
    }
  }
}
