// Decompiled with JetBrains decompiler
// Type: UIAutomationClient.IUIAutomationValuePattern
// Assembly: ExamCookie.WinClient, Version=1.4.1.4, Culture=neutral, PublicKeyToken=null
// MVID: E12BE1F8-B6E0-4BF5-B308-166F0E938C4B
// Assembly location: C:\Users\oskar\Downloads\ExamCookie1414.WinClient.exe

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

#nullable disable
namespace UIAutomationClient
{
  [CompilerGenerated]
  [Guid("A94CD8B1-0844-4CD6-9D2D-640537AB39E9")]
  [InterfaceType(1)]
  [TypeIdentifier]
  [ComImport]
  public interface IUIAutomationValuePattern
  {
    [SpecialName]
    [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
    sealed extern void _VtblGap1_1();

    [DispId(1610678273)]
    string CurrentValue { [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)] [return: MarshalAs(UnmanagedType.BStr)] get; }
  }
}
