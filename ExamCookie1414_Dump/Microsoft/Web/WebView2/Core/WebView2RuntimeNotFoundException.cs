﻿// Decompiled with JetBrains decompiler
// Type: Microsoft.Web.WebView2.Core.WebView2RuntimeNotFoundException
// Assembly: ExamCookie.WinClient, Version=1.4.1.4, Culture=neutral, PublicKeyToken=null
// MVID: E12BE1F8-B6E0-4BF5-B308-166F0E938C4B
// Assembly location: C:\Users\oskar\Downloads\ExamCookie1414.WinClient.exe

using System;
using System.Runtime.InteropServices;

#nullable disable
namespace Microsoft.Web.WebView2.Core
{
  [ComVisible(true)]
  [Serializable]
  public class WebView2RuntimeNotFoundException : Exception
  {
    public WebView2RuntimeNotFoundException()
      : this((Exception) null)
    {
    }

    public WebView2RuntimeNotFoundException(string message)
      : base(message)
    {
    }

    public WebView2RuntimeNotFoundException(Exception inner)
      : base("Couldn't find a compatible Webview2 Runtime installation to host WebViews.", inner)
    {
    }

    public WebView2RuntimeNotFoundException(string message, Exception inner)
      : base(message, inner)
    {
    }
  }
}
