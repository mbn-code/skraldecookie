// Decompiled with JetBrains decompiler
// Type: Microsoft.Web.WebView2.Core.CoreWebView2MouseEventVirtualKeys
// Assembly: ExamCookie.WinClient, Version=1.4.1.4, Culture=neutral, PublicKeyToken=null
// MVID: E12BE1F8-B6E0-4BF5-B308-166F0E938C4B
// Assembly location: C:\Users\oskar\Downloads\ExamCookie1414.WinClient.exe

using System;
using System.Runtime.InteropServices;

#nullable disable
namespace Microsoft.Web.WebView2.Core
{
  [Flags]
  [ComVisible(true)]
  public enum CoreWebView2MouseEventVirtualKeys
  {
    None = 0,
    LeftButton = 1,
    RightButton = 2,
    Shift = 4,
    Control = 8,
    MiddleButton = 16, // 0x00000010
    XButton1 = 32, // 0x00000020
    XButton2 = 64, // 0x00000040
  }
}
