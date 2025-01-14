// Decompiled with JetBrains decompiler
// Type: Microsoft.Web.WebView2.Core.IDispatch
// Assembly: ExamCookie.WinClient, Version=1.4.1.4, Culture=neutral, PublicKeyToken=null
// MVID: E12BE1F8-B6E0-4BF5-B308-166F0E938C4B
// Assembly location: C:\Users\oskar\Downloads\ExamCookie1414.WinClient.exe

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

#nullable disable
namespace Microsoft.Web.WebView2.Core
{
  [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
  [Guid("00020400-0000-0000-C000-000000000046")]
  [ComImport]
  internal interface IDispatch
  {
    [MethodImpl(MethodImplOptions.PreserveSig)]
    int GetTypeInfoCount(out int Count);

    [MethodImpl(MethodImplOptions.PreserveSig)]
    int GetTypeInfo([MarshalAs(UnmanagedType.U4)] int iTInfo, [MarshalAs(UnmanagedType.U4)] int lcid, out ITypeInfo typeInfo);

    [MethodImpl(MethodImplOptions.PreserveSig)]
    int GetIDsOfNames(ref Guid riid, [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPWStr)] string[] rgsNames, int cNames, int lcid, [MarshalAs(UnmanagedType.LPArray)] int[] rgDispId);

    [MethodImpl(MethodImplOptions.PreserveSig)]
    int Invoke(
      int dispIdMember,
      ref Guid riid,
      uint lcid,
      ushort wFlags,
      ref System.Runtime.InteropServices.ComTypes.DISPPARAMS pDispParams,
      out object pVarResult,
      ref System.Runtime.InteropServices.ComTypes.EXCEPINFO pExcepInfo,
      out uint pArgErr);
  }
}
