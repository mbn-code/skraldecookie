// Decompiled with JetBrains decompiler
// Type: Microsoft.Web.WebView2.Core.CoreWebView2WebResourceResponseReceivedEventHandler
// Assembly: ExamCookie.WinClient, Version=1.4.1.4, Culture=neutral, PublicKeyToken=null
// MVID: E12BE1F8-B6E0-4BF5-B308-166F0E938C4B
// Assembly location: C:\Users\oskar\Downloads\ExamCookie1414.WinClient.exe

using Microsoft.Web.WebView2.Core.Raw;

#nullable disable
namespace Microsoft.Web.WebView2.Core
{
  internal class CoreWebView2WebResourceResponseReceivedEventHandler : 
    ICoreWebView2WebResourceResponseReceivedEventHandler
  {
    private CoreWebView2WebResourceResponseReceivedEventHandler.CallbackType _callback;

    public CoreWebView2WebResourceResponseReceivedEventHandler(
      CoreWebView2WebResourceResponseReceivedEventHandler.CallbackType callback)
    {
      this._callback = callback;
    }

    public void Invoke(
      ICoreWebView2 source,
      ICoreWebView2WebResourceResponseReceivedEventArgs args)
    {
      this._callback(new CoreWebView2WebResourceResponseReceivedEventArgs((object) args));
    }

    public delegate void CallbackType(
      CoreWebView2WebResourceResponseReceivedEventArgs args);
  }
}
