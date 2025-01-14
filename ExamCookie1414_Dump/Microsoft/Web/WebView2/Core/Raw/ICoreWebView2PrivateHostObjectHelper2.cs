// Decompiled with JetBrains decompiler
// Type: Microsoft.Web.WebView2.Core.Raw.ICoreWebView2PrivateHostObjectHelper2
// Assembly: ExamCookie.WinClient, Version=1.4.1.4, Culture=neutral, PublicKeyToken=null
// MVID: E12BE1F8-B6E0-4BF5-B308-166F0E938C4B
// Assembly location: C:\Users\oskar\Downloads\ExamCookie1414.WinClient.exe

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

#nullable disable
namespace Microsoft.Web.WebView2.Core.Raw
{
  [CompilerGenerated]
  [Guid("A791A659-3AD9-41C3-9C7E-768FCC233666")]
  [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
  [TypeIdentifier]
  [ComVisible(true)]
  [ComImport]
  public interface ICoreWebView2PrivateHostObjectHelper2
  {
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
    int IsAsyncMethod([MarshalAs(UnmanagedType.Struct), In] ref object @object, [MarshalAs(UnmanagedType.LPWStr), In] string methodName, [In] int parameterCount);

    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
    void SetAsyncMethodContinuation(
      [MarshalAs(UnmanagedType.Struct), In] ref object @object,
      [MarshalAs(UnmanagedType.LPWStr), In] string methodName,
      [In] int parameterCount,
      [MarshalAs(UnmanagedType.Struct), In] ref object methodResult,
      [MarshalAs(UnmanagedType.Interface), In] ICoreWebView2PrivateHostObjectAsyncMethodContinuation continuation);
  }
}
