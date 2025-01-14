// Decompiled with JetBrains decompiler
// Type: Microsoft.Web.WebView2.Core.CoreWebView2DevToolsProtocolEventReceivedEventHandler
// Assembly: ExamCookie.WinClient, Version=1.4.1.4, Culture=neutral, PublicKeyToken=null
// MVID: E12BE1F8-B6E0-4BF5-B308-166F0E938C4B
// Assembly location: C:\Users\oskar\Downloads\ExamCookie1414.WinClient.exe

using Microsoft.Web.WebView2.Core.Raw;

#nullable disable
namespace Microsoft.Web.WebView2.Core
{
  internal class CoreWebView2DevToolsProtocolEventReceivedEventHandler : 
    ICoreWebView2DevToolsProtocolEventReceivedEventHandler
  {
    private CoreWebView2DevToolsProtocolEventReceivedEventHandler.CallbackType _callback;

    public CoreWebView2DevToolsProtocolEventReceivedEventHandler(
      CoreWebView2DevToolsProtocolEventReceivedEventHandler.CallbackType callback)
    {
      this._callback = callback;
    }

    public void Invoke(
      ICoreWebView2 source,
      ICoreWebView2DevToolsProtocolEventReceivedEventArgs args)
    {
      this._callback(new CoreWebView2DevToolsProtocolEventReceivedEventArgs((object) args));
    }

    public delegate void CallbackType(
      CoreWebView2DevToolsProtocolEventReceivedEventArgs args);
  }
}
