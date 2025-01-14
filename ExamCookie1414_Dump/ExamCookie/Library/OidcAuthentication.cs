// Decompiled with JetBrains decompiler
// Type: ExamCookie.Library.OidcAuthentication
// Assembly: ExamCookie.WinClient, Version=1.4.1.4, Culture=neutral, PublicKeyToken=null
// MVID: E12BE1F8-B6E0-4BF5-B308-166F0E938C4B
// Assembly location: C:\Users\oskar\Downloads\ExamCookie1414.WinClient.exe

using System;

#nullable disable
namespace ExamCookie.Library
{
  [Serializable]
  public class OidcAuthentication
  {
    public string Url { get; set; }

    public string CodeVerifier { get; set; }

    public OidcAuthentication(string url, string codeVerifier)
    {
      this.Url = "";
      this.CodeVerifier = "";
      this.Url = url;
      this.CodeVerifier = codeVerifier;
    }
  }
}
