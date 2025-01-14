// Decompiled with JetBrains decompiler
// Type: UIAutomationClient.TreeScope
// Assembly: ExamCookie.WinClient, Version=1.4.1.4, Culture=neutral, PublicKeyToken=null
// MVID: E12BE1F8-B6E0-4BF5-B308-166F0E938C4B
// Assembly location: C:\Users\oskar\Downloads\ExamCookie1414.WinClient.exe

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

#nullable disable
namespace UIAutomationClient
{
  [CompilerGenerated]
  [TypeIdentifier("944de083-8fb8-45cf-bcb7-c477acb2f897", "UIAutomationClient.TreeScope")]
  public enum TreeScope
  {
    TreeScope_None = 0,
    TreeScope_Element = 1,
    TreeScope_Children = 2,
    TreeScope_Descendants = 4,
    TreeScope_Subtree = 7,
    TreeScope_Parent = 8,
    TreeScope_Ancestors = 16, // 0x00000010
  }
}
