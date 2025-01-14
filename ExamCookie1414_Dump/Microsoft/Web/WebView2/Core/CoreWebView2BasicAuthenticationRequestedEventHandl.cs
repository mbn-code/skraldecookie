// Decompiled with JetBrains decompiler
// Type: Microsoft.Web.WebView2.Core.CoreWebView2BasicAuthenticationRequestedEventHandler
// Assembly: ExamCookie.WinClient, Version=1.4.1.4, Culture=neutral, PublicKeyToken=null
// MVID: E12BE1F8-B6E0-4BF5-B308-166F0E938C4B
// Assembly location: C:\Users\oskar\Downloads\ExamCookie1414.WinClient.exe

using Microsoft.Web.WebView2.Core.Raw;

#nullable disable
namespace Microsoft.Web.WebView2.Core
{
  internal class CoreWebView2BasicAuthenticationRequestedEventHandler : 
    ICoreWebView2BasicAuthenticationRequestedEventHandler
  {
    private CoreWebView2BasicAuthenticationRequestedEventHandler.CallbackType _callback;

    public CoreWebView2BasicAuthenticationRequestedEventHandler(
      CoreWebView2BasicAuthenticationRequestedEventHandler.CallbackType callback)
    {
      this._callback = callback;
    }

    public void Invoke(
      ICoreWebView2 source,
      ICoreWebView2BasicAuthenticationRequestedEventArgs args)
    {
      this._callback(new CoreWebView2BasicAuthenticationRequestedEventArgs((object) args));
    }

    public delegate void CallbackType(
      CoreWebView2BasicAuthenticationRequestedEventArgs args);
  }
}
