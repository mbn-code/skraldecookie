// Decompiled with JetBrains decompiler
// Type: Microsoft.Web.WebView2.Core.CoreWebView2CreateCoreWebView2ControllerCompletedHandler
// Assembly: ExamCookie.WinClient, Version=1.4.1.4, Culture=neutral, PublicKeyToken=null
// MVID: E12BE1F8-B6E0-4BF5-B308-166F0E938C4B
// Assembly location: C:\Users\oskar\Downloads\ExamCookie1414.WinClient.exe

using Microsoft.Web.WebView2.Core.Raw;
using System;
using System.Runtime.CompilerServices;

#nullable disable
namespace Microsoft.Web.WebView2.Core
{
  internal class CoreWebView2CreateCoreWebView2ControllerCompletedHandler : 
    ICoreWebView2CreateCoreWebView2ControllerCompletedHandler,
    INotifyCompletion
  {
    private Action continuation;

    public CoreWebView2Controller createdController { get; private set; }

    public int errCode { get; private set; }

    public CoreWebView2CreateCoreWebView2ControllerCompletedHandler() => this.IsCompleted = false;

    public void Invoke(int errCode, ICoreWebView2Controller createdController)
    {
      this.createdController = new CoreWebView2Controller((object) createdController);
      this.errCode = errCode;
      this.IsCompleted = true;
      if (this.continuation == null)
        return;
      this.continuation();
    }

    public CoreWebView2CreateCoreWebView2ControllerCompletedHandler GetAwaiter() => this;

    public bool IsCompleted { get; private set; }

    public void OnCompleted(Action continuation)
    {
      this.continuation = continuation;
      if (!this.IsCompleted)
        return;
      continuation();
    }

    public CoreWebView2Controller GetResult() => this.createdController;
  }
}
