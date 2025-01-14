// Decompiled with JetBrains decompiler
// Type: Microsoft.Web.WebView2.Core.CoreWebView2PrivateEnvironmentTesting
// Assembly: ExamCookie.WinClient, Version=1.4.1.4, Culture=neutral, PublicKeyToken=null
// MVID: E12BE1F8-B6E0-4BF5-B308-166F0E938C4B
// Assembly location: C:\Users\oskar\Downloads\ExamCookie1414.WinClient.exe

using Microsoft.Web.WebView2.Core.Raw;
using System;
using System.Runtime.InteropServices;

#nullable disable
namespace Microsoft.Web.WebView2.Core
{
  internal class CoreWebView2PrivateEnvironmentTesting
  {
    internal ICoreWebView2PrivateEnvironmentTesting _nativeICoreWebView2PrivateEnvironmentTestingValue;
    internal object _rawNative;

    internal ICoreWebView2PrivateEnvironmentTesting _nativeICoreWebView2PrivateEnvironmentTesting
    {
      get
      {
        if (this._nativeICoreWebView2PrivateEnvironmentTestingValue == null)
        {
          try
          {
            this._nativeICoreWebView2PrivateEnvironmentTestingValue = (ICoreWebView2PrivateEnvironmentTesting) this._rawNative;
          }
          catch (Exception ex)
          {
            throw new NotImplementedException("Unable to cast to Microsoft.Web.WebView2.Core.Raw.ICoreWebView2PrivateEnvironmentTesting.\nThis may happen if you are using an interface not supported by the version of the WebView2 Runtime you are using.\nFor instance, if you are using an experimental interface from an older SDK that has been modified or removed in a newer runtime.\nOr, if you are using a public interface from a newer SDK that wasn't implemented in an older runtime.\nFor more information about WebView2 versioning please visit the following: https://learn.microsoft.com/microsoft-edge/webview2/concepts/versioning", ex);
          }
        }
        return this._nativeICoreWebView2PrivateEnvironmentTestingValue;
      }
      set => this._nativeICoreWebView2PrivateEnvironmentTestingValue = value;
    }

    internal CoreWebView2PrivateEnvironmentTesting(object rawCoreWebView2PrivateEnvironmentTesting)
    {
      this._rawNative = rawCoreWebView2PrivateEnvironmentTesting;
    }

    internal void SetShouldCheckUninitializeForTesting(bool should_check)
    {
      try
      {
        // ISSUE: reference to a compiler-generated method
        this._nativeICoreWebView2PrivateEnvironmentTesting.SetShouldCheckUninitializeForTesting(should_check ? 1 : 0);
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
