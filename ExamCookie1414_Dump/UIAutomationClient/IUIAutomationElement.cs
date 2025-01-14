// Decompiled with JetBrains decompiler
// Type: UIAutomationClient.IUIAutomationElement
// Assembly: ExamCookie.WinClient, Version=1.4.1.4, Culture=neutral, PublicKeyToken=null
// MVID: E12BE1F8-B6E0-4BF5-B308-166F0E938C4B
// Assembly location: C:\Users\oskar\Downloads\ExamCookie1414.WinClient.exe

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

#nullable disable
namespace UIAutomationClient
{
  [CompilerGenerated]
  [Guid("D22108AA-8AC5-49A5-837B-37BBB3D7591E")]
  [InterfaceType(1)]
  [TypeIdentifier]
  [ComImport]
  public interface IUIAutomationElement
  {
    [SpecialName]
    [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
    sealed extern void _VtblGap1_2();

    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
    [return: MarshalAs(UnmanagedType.Interface)]
    IUIAutomationElement FindFirst([In] TreeScope scope, [MarshalAs(UnmanagedType.Interface), In] IUIAutomationCondition condition);

    [SpecialName]
    [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
    sealed extern void _VtblGap2_10();

    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
    [return: MarshalAs(UnmanagedType.IUnknown)]
    object GetCurrentPattern([In] int patternId);
  }
}
