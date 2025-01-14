// Decompiled with JetBrains decompiler
// Type: Microsoft.Web.WebView2.Core.Raw.COREWEBVIEW2_PHYSICAL_KEY_STATUS
// Assembly: ExamCookie.WinClient, Version=1.4.1.4, Culture=neutral, PublicKeyToken=null
// MVID: E12BE1F8-B6E0-4BF5-B308-166F0E938C4B
// Assembly location: C:\Users\oskar\Downloads\ExamCookie1414.WinClient.exe

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

#nullable disable
namespace Microsoft.Web.WebView2.Core.Raw
{
  [CompilerGenerated]
  [TypeIdentifier("26D34152-879F-4065-BEA2-3DAA2CFADFB8", "Microsoft.Web.WebView2.Core.Raw.COREWEBVIEW2_PHYSICAL_KEY_STATUS")]
  [ComVisible(true)]
  [StructLayout(LayoutKind.Sequential, Pack = 4)]
  public struct COREWEBVIEW2_PHYSICAL_KEY_STATUS
  {
    public uint RepeatCount;
    public uint ScanCode;
    public int IsExtendedKey;
    public int IsMenuKeyDown;
    public int WasKeyDown;
    public int IsKeyReleased;
  }
}
