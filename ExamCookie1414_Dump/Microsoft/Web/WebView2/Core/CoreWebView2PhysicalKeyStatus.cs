// Decompiled with JetBrains decompiler
// Type: Microsoft.Web.WebView2.Core.CoreWebView2PhysicalKeyStatus
// Assembly: ExamCookie.WinClient, Version=1.4.1.4, Culture=neutral, PublicKeyToken=null
// MVID: E12BE1F8-B6E0-4BF5-B308-166F0E938C4B
// Assembly location: C:\Users\oskar\Downloads\ExamCookie1414.WinClient.exe

using Microsoft.Web.WebView2.Core.Raw;
using System.Runtime.InteropServices;

#nullable disable
namespace Microsoft.Web.WebView2.Core
{
  [ComVisible(true)]
  public struct CoreWebView2PhysicalKeyStatus
  {
    public uint RepeatCount;
    public uint ScanCode;
    public int IsExtendedKey;
    public int IsMenuKeyDown;
    public int WasKeyDown;
    public int IsKeyReleased;

    internal CoreWebView2PhysicalKeyStatus(COREWEBVIEW2_PHYSICAL_KEY_STATUS rawStruct)
    {
      // ISSUE: reference to a compiler-generated field
      this.RepeatCount = rawStruct.RepeatCount;
      // ISSUE: reference to a compiler-generated field
      this.ScanCode = rawStruct.ScanCode;
      // ISSUE: reference to a compiler-generated field
      this.IsExtendedKey = rawStruct.IsExtendedKey;
      // ISSUE: reference to a compiler-generated field
      this.IsMenuKeyDown = rawStruct.IsMenuKeyDown;
      // ISSUE: reference to a compiler-generated field
      this.WasKeyDown = rawStruct.WasKeyDown;
      // ISSUE: reference to a compiler-generated field
      this.IsKeyReleased = rawStruct.IsKeyReleased;
    }
  }
}
