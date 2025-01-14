// Decompiled with JetBrains decompiler
// Type: Microsoft.Web.WebView2.Core.CoreWebView2BrowsingDataKinds
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
  public enum CoreWebView2BrowsingDataKinds
  {
    FileSystems = 1,
    IndexedDb = 2,
    LocalStorage = 4,
    WebSql = 8,
    CacheStorage = 16, // 0x00000010
    AllDomStorage = 32, // 0x00000020
    Cookies = 64, // 0x00000040
    AllSite = 128, // 0x00000080
    DiskCache = 256, // 0x00000100
    DownloadHistory = 512, // 0x00000200
    GeneralAutofill = 1024, // 0x00000400
    PasswordAutosave = 2048, // 0x00000800
    BrowsingHistory = 4096, // 0x00001000
    Settings = 8192, // 0x00002000
    AllProfile = 16384, // 0x00004000
    ServiceWorkers = 32768, // 0x00008000
  }
}
