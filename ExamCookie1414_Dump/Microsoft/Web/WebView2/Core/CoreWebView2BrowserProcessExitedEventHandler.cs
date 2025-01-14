// Decompiled with JetBrains decompiler
// Type: Microsoft.Web.WebView2.Core.CoreWebView2BrowserProcessExitedEventHandler
// Assembly: ExamCookie.WinClient, Version=1.4.1.4, Culture=neutral, PublicKeyToken=null
// MVID: E12BE1F8-B6E0-4BF5-B308-166F0E938C4B
// Assembly location: C:\Users\oskar\Downloads\ExamCookie1414.WinClient.exe

using Microsoft.Web.WebView2.Core.Raw;

#nullable disable
namespace Microsoft.Web.WebView2.Core
{
  internal class CoreWebView2BrowserProcessExitedEventHandler : 
    ICoreWebView2BrowserProcessExitedEventHandler
  {
    private CoreWebView2BrowserProcessExitedEventHandler.CallbackType _callback;

    public CoreWebView2BrowserProcessExitedEventHandler(
      CoreWebView2BrowserProcessExitedEventHandler.CallbackType callback)
    {
      this._callback = callback;
    }

    public void Invoke(
      ICoreWebView2Environment source,
      ICoreWebView2BrowserProcessExitedEventArgs args)
    {
      this._callback(new CoreWebView2BrowserProcessExitedEventArgs((object) args));
    }

    public delegate void CallbackType(CoreWebView2BrowserProcessExitedEventArgs args);
  }
}
