// Decompiled with JetBrains decompiler
// Type: Microsoft.Web.WebView2.Core.CoreWebView2Color
// Assembly: ExamCookie.WinClient, Version=1.4.1.4, Culture=neutral, PublicKeyToken=null
// MVID: E12BE1F8-B6E0-4BF5-B308-166F0E938C4B
// Assembly location: C:\Users\oskar\Downloads\ExamCookie1414.WinClient.exe

using Microsoft.Web.WebView2.Core.Raw;
using System.Runtime.InteropServices;

#nullable disable
namespace Microsoft.Web.WebView2.Core
{
  [ComVisible(true)]
  public struct CoreWebView2Color
  {
    public byte A;
    public byte R;
    public byte G;
    public byte B;

    internal CoreWebView2Color(COREWEBVIEW2_COLOR rawStruct)
    {
      // ISSUE: reference to a compiler-generated field
      this.A = rawStruct.A;
      // ISSUE: reference to a compiler-generated field
      this.R = rawStruct.R;
      // ISSUE: reference to a compiler-generated field
      this.G = rawStruct.G;
      // ISSUE: reference to a compiler-generated field
      this.B = rawStruct.B;
    }
  }
}
