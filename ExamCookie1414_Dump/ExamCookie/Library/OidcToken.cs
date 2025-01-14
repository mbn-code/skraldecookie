// Decompiled with JetBrains decompiler
// Type: ExamCookie.Library.OidcToken
// Assembly: ExamCookie.WinClient, Version=1.4.1.4, Culture=neutral, PublicKeyToken=null
// MVID: E12BE1F8-B6E0-4BF5-B308-166F0E938C4B
// Assembly location: C:\Users\oskar\Downloads\ExamCookie1414.WinClient.exe

using System;

#nullable disable
namespace ExamCookie.Library
{
  [Serializable]
  public class OidcToken
  {
    public string UniId { get; set; }

    public string UniToken { get; set; }

    public string PostLogoutUri { get; set; }

    public string PostLogoutRedirectUri { get; set; }

    public string IdTokenHint { get; set; }

    public OidcToken(
      string uniId,
      string uniToken,
      string postLogoutUri,
      string postLogoutRedirectUri,
      string idTokenHint)
    {
      this.UniId = "";
      this.UniToken = "";
      this.PostLogoutUri = "";
      this.PostLogoutRedirectUri = "";
      this.IdTokenHint = "";
      this.UniId = uniId;
      this.PostLogoutUri = postLogoutUri;
      this.PostLogoutRedirectUri = postLogoutRedirectUri;
      this.IdTokenHint = idTokenHint;
    }
  }
}
