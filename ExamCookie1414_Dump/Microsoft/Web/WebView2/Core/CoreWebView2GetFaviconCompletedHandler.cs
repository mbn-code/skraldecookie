// Decompiled with JetBrains decompiler
// Type: Microsoft.Web.WebView2.Core.CoreWebView2GetFaviconCompletedHandler
// Assembly: ExamCookie.WinClient, Version=1.4.1.4, Culture=neutral, PublicKeyToken=null
// MVID: E12BE1F8-B6E0-4BF5-B308-166F0E938C4B
// Assembly location: C:\Users\oskar\Downloads\ExamCookie1414.WinClient.exe

using Microsoft.Web.WebView2.Core.Raw;
using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.ComTypes;

#nullable disable
namespace Microsoft.Web.WebView2.Core
{
  internal class CoreWebView2GetFaviconCompletedHandler : 
    ICoreWebView2GetFaviconCompletedHandler,
    INotifyCompletion
  {
    private Action continuation;

    public Stream faviconStream { get; private set; }

    public int errCode { get; private set; }

    public CoreWebView2GetFaviconCompletedHandler() => this.IsCompleted = false;

    public void Invoke(int errCode, IStream faviconStream)
    {
      this.faviconStream = (Stream) COMDotNetTypeConverter.StreamCOMToNet(faviconStream);
      this.errCode = errCode;
      this.IsCompleted = true;
      if (this.continuation == null)
        return;
      this.continuation();
    }

    public CoreWebView2GetFaviconCompletedHandler GetAwaiter() => this;

    public bool IsCompleted { get; private set; }

    public void OnCompleted(Action continuation)
    {
      this.continuation = continuation;
      if (!this.IsCompleted)
        return;
      continuation();
    }

    public Stream GetResult() => this.faviconStream;
  }
}
