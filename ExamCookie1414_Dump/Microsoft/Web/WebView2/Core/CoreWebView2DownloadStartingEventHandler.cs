// Decompiled with JetBrains decompiler
// Type: Microsoft.Web.WebView2.Core.CoreWebView2DownloadStartingEventHandler
// Assembly: ExamCookie.WinClient, Version=1.4.1.4, Culture=neutral, PublicKeyToken=null
// MVID: E12BE1F8-B6E0-4BF5-B308-166F0E938C4B
// Assembly location: C:\Users\oskar\Downloads\ExamCookie1414.WinClient.exe

using Microsoft.Web.WebView2.Core.Raw;

#nullable disable
namespace Microsoft.Web.WebView2.Core
{
  internal class CoreWebView2DownloadStartingEventHandler : ICoreWebView2DownloadStartingEventHandler
  {
    private CoreWebView2DownloadStartingEventHandler.CallbackType _callback;

    public CoreWebView2DownloadStartingEventHandler(
      CoreWebView2DownloadStartingEventHandler.CallbackType callback)
    {
      this._callback = callback;
    }

    public void Invoke(ICoreWebView2 source, ICoreWebView2DownloadStartingEventArgs args)
    {
      this._callback(new CoreWebView2DownloadStartingEventArgs((object) args));
    }

    public delegate void CallbackType(CoreWebView2DownloadStartingEventArgs args);
  }
}
