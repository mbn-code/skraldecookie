﻿// Decompiled with JetBrains decompiler
// Type: Microsoft.Web.WebView2.Core.CoreWebView2ContainsFullScreenElementChangedEventHandler
// Assembly: ExamCookie.WinClient, Version=1.4.1.4, Culture=neutral, PublicKeyToken=null
// MVID: E12BE1F8-B6E0-4BF5-B308-166F0E938C4B
// Assembly location: C:\Users\oskar\Downloads\ExamCookie1414.WinClient.exe

using Microsoft.Web.WebView2.Core.Raw;
using System;

#nullable disable
namespace Microsoft.Web.WebView2.Core
{
  internal class CoreWebView2ContainsFullScreenElementChangedEventHandler : 
    ICoreWebView2ContainsFullScreenElementChangedEventHandler
  {
    private CoreWebView2ContainsFullScreenElementChangedEventHandler.CallbackType _callback;

    public CoreWebView2ContainsFullScreenElementChangedEventHandler(
      CoreWebView2ContainsFullScreenElementChangedEventHandler.CallbackType callback)
    {
      this._callback = callback;
    }

    public void Invoke(ICoreWebView2 source, object args) => this._callback(EventArgs.Empty);

    public delegate void CallbackType(EventArgs args);
  }
}
