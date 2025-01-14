// Decompiled with JetBrains decompiler
// Type: Microsoft.Web.WebView2.Core.CoreWebView2InitializationCompletedEventArgs
// Assembly: ExamCookie.WinClient, Version=1.4.1.4, Culture=neutral, PublicKeyToken=null
// MVID: E12BE1F8-B6E0-4BF5-B308-166F0E938C4B
// Assembly location: C:\Users\oskar\Downloads\ExamCookie1414.WinClient.exe

using System;
using System.Runtime.InteropServices;

#nullable disable
namespace Microsoft.Web.WebView2.Core
{
  [ComVisible(true)]
  public class CoreWebView2InitializationCompletedEventArgs : EventArgs
  {
    public CoreWebView2InitializationCompletedEventArgs(Exception ex = null)
    {
      this.InitializationException = ex;
    }

    public bool IsSuccess => this.InitializationException == null;

    public Exception InitializationException { get; private set; }
  }
}
