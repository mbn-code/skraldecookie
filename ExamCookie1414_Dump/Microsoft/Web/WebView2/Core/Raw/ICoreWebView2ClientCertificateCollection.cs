﻿// Decompiled with JetBrains decompiler
// Type: Microsoft.Web.WebView2.Core.Raw.ICoreWebView2ClientCertificateCollection
// Assembly: ExamCookie.WinClient, Version=1.4.1.4, Culture=neutral, PublicKeyToken=null
// MVID: E12BE1F8-B6E0-4BF5-B308-166F0E938C4B
// Assembly location: C:\Users\oskar\Downloads\ExamCookie1414.WinClient.exe

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

#nullable disable
namespace Microsoft.Web.WebView2.Core.Raw
{
  [CompilerGenerated]
  [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
  [Guid("EF5674D2-BCC3-11EB-8529-0242AC130003")]
  [TypeIdentifier]
  [ComVisible(true)]
  [ComImport]
  public interface ICoreWebView2ClientCertificateCollection
  {
    [DispId(1610678272)]
    uint Count { [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)] get; }

    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
    [return: MarshalAs(UnmanagedType.Interface)]
    ICoreWebView2ClientCertificate GetValueAtIndex([In] uint index);
  }
}
