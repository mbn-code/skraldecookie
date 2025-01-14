// Decompiled with JetBrains decompiler
// Type: Microsoft.Web.WebView2.Core.CoreWebView2PrivateHostObjectAsyncMethodContinuation
// Assembly: ExamCookie.WinClient, Version=1.4.1.4, Culture=neutral, PublicKeyToken=null
// MVID: E12BE1F8-B6E0-4BF5-B308-166F0E938C4B
// Assembly location: C:\Users\oskar\Downloads\ExamCookie1414.WinClient.exe

using Microsoft.Web.WebView2.Core.Raw;
using System;
using System.Runtime.InteropServices;

#nullable disable
namespace Microsoft.Web.WebView2.Core
{
  internal class CoreWebView2PrivateHostObjectAsyncMethodContinuation
  {
    internal ICoreWebView2PrivateHostObjectAsyncMethodContinuation _nativeICoreWebView2PrivateHostObjectAsyncMethodContinuationValue;
    internal object _rawNative;

    internal ICoreWebView2PrivateHostObjectAsyncMethodContinuation _nativeICoreWebView2PrivateHostObjectAsyncMethodContinuation
    {
      get
      {
        if (this._nativeICoreWebView2PrivateHostObjectAsyncMethodContinuationValue == null)
        {
          try
          {
            this._nativeICoreWebView2PrivateHostObjectAsyncMethodContinuationValue = (ICoreWebView2PrivateHostObjectAsyncMethodContinuation) this._rawNative;
          }
          catch (Exception ex)
          {
            throw new NotImplementedException("Unable to cast to Microsoft.Web.WebView2.Core.Raw.ICoreWebView2PrivateHostObjectAsyncMethodContinuation.\nThis may happen if you are using an interface not supported by the version of the WebView2 Runtime you are using.\nFor instance, if you are using an experimental interface from an older SDK that has been modified or removed in a newer runtime.\nOr, if you are using a public interface from a newer SDK that wasn't implemented in an older runtime.\nFor more information about WebView2 versioning please visit the following: https://learn.microsoft.com/microsoft-edge/webview2/concepts/versioning", ex);
          }
        }
        return this._nativeICoreWebView2PrivateHostObjectAsyncMethodContinuationValue;
      }
      set => this._nativeICoreWebView2PrivateHostObjectAsyncMethodContinuationValue = value;
    }

    internal CoreWebView2PrivateHostObjectAsyncMethodContinuation(
      object rawCoreWebView2PrivateHostObjectAsyncMethodContinuation)
    {
      this._rawNative = rawCoreWebView2PrivateHostObjectAsyncMethodContinuation;
    }

    internal void Invoke(int errorCode, object result)
    {
      try
      {
        // ISSUE: variable of a compiler-generated type
        ICoreWebView2PrivateHostObjectAsyncMethodContinuation methodContinuation = this._nativeICoreWebView2PrivateHostObjectAsyncMethodContinuation;
        int errorCode1 = errorCode;
        object obj = result;
        ref object local = ref obj;
        // ISSUE: reference to a compiler-generated method
        methodContinuation.Invoke(errorCode1, ref local);
      }
      catch (InvalidCastException ex)
      {
        if (ex.HResult == -2147467262)
          throw new InvalidOperationException("CoreWebView2 members can only be accessed from the UI thread.", (Exception) ex);
        throw ex;
      }
      catch (COMException ex)
      {
        if (ex.HResult == -2147019873)
          throw new InvalidOperationException("CoreWebView2 members cannot be accessed after the WebView2 control is disposed.", (Exception) ex);
        throw ex;
      }
    }
  }
}
