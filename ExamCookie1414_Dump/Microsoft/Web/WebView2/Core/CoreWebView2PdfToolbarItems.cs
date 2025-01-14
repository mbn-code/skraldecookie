// Decompiled with JetBrains decompiler
// Type: Microsoft.Web.WebView2.Core.CoreWebView2PdfToolbarItems
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
  public enum CoreWebView2PdfToolbarItems
  {
    None = 0,
    Save = 1,
    Print = 2,
    SaveAs = 4,
    ZoomIn = 8,
    ZoomOut = 16, // 0x00000010
    Rotate = 32, // 0x00000020
    FitPage = 64, // 0x00000040
    PageLayout = 128, // 0x00000080
    Bookmarks = 256, // 0x00000100
    PageSelector = 512, // 0x00000200
    Search = 1024, // 0x00000400
    FullScreen = 2048, // 0x00000800
    MoreSettings = 4096, // 0x00001000
  }
}
