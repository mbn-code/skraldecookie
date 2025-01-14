// Decompiled with JetBrains decompiler
// Type: Microsoft.Web.WebView2.Core.CoreWebView2ServerCertificateErrorDetectedEventArgs
// Assembly: ExamCookie.WinClient, Version=1.4.1.4, Culture=neutral, PublicKeyToken=null
// MVID: E12BE1F8-B6E0-4BF5-B308-166F0E938C4B
// Assembly location: C:\Users\oskar\Downloads\ExamCookie1414.WinClient.exe

using Microsoft.Web.WebView2.Core.Raw;
using System;
using System.Runtime.InteropServices;

#nullable disable
namespace Microsoft.Web.WebView2.Core
{
  [ComVisible(true)]
  public class CoreWebView2ServerCertificateErrorDetectedEventArgs : EventArgs
  {
    internal ICoreWebView2ServerCertificateErrorDetectedEventArgs _nativeICoreWebView2ServerCertificateErrorDetectedEventArgsValue;
    internal object _rawNative;

    internal ICoreWebView2ServerCertificateErrorDetectedEventArgs _nativeICoreWebView2ServerCertificateErrorDetectedEventArgs
    {
      get
      {
        if (this._nativeICoreWebView2ServerCertificateErrorDetectedEventArgsValue == null)
        {
          try
          {
            this._nativeICoreWebView2ServerCertificateErrorDetectedEventArgsValue = (ICoreWebView2ServerCertificateErrorDetectedEventArgs) this._rawNative;
          }
          catch (Exception ex)
          {
            throw new NotImplementedException("Unable to cast to Microsoft.Web.WebView2.Core.Raw.ICoreWebView2ServerCertificateErrorDetectedEventArgs.\nThis may happen if you are using an interface not supported by the version of the WebView2 Runtime you are using.\nFor instance, if you are using an experimental interface from an older SDK that has been modified or removed in a newer runtime.\nOr, if you are using a public interface from a newer SDK that wasn't implemented in an older runtime.\nFor more information about WebView2 versioning please visit the following: https://learn.microsoft.com/microsoft-edge/webview2/concepts/versioning", ex);
          }
        }
        return this._nativeICoreWebView2ServerCertificateErrorDetectedEventArgsValue;
      }
      set => this._nativeICoreWebView2ServerCertificateErrorDetectedEventArgsValue = value;
    }

    internal CoreWebView2ServerCertificateErrorDetectedEventArgs(
      object rawCoreWebView2ServerCertificateErrorDetectedEventArgs)
    {
      this._rawNative = rawCoreWebView2ServerCertificateErrorDetectedEventArgs;
    }

    public CoreWebView2WebErrorStatus ErrorStatus
    {
      get
      {
        try
        {
          return (CoreWebView2WebErrorStatus) this._nativeICoreWebView2ServerCertificateErrorDetectedEventArgs.ErrorStatus;
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

    public string RequestUri
    {
      get
      {
        try
        {
          return this._nativeICoreWebView2ServerCertificateErrorDetectedEventArgs.RequestUri;
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

    public CoreWebView2Certificate ServerCertificate
    {
      get
      {
        try
        {
          return this._nativeICoreWebView2ServerCertificateErrorDetectedEventArgs.ServerCertificate == null ? (CoreWebView2Certificate) null : new CoreWebView2Certificate((object) this._nativeICoreWebView2ServerCertificateErrorDetectedEventArgs.ServerCertificate);
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

    public CoreWebView2ServerCertificateErrorAction Action
    {
      get
      {
        try
        {
          return (CoreWebView2ServerCertificateErrorAction) this._nativeICoreWebView2ServerCertificateErrorDetectedEventArgs.Action;
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
      set
      {
        try
        {
          this._nativeICoreWebView2ServerCertificateErrorDetectedEventArgs.Action = (COREWEBVIEW2_SERVER_CERTIFICATE_ERROR_ACTION) value;
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

    public CoreWebView2Deferral GetDeferral()
    {
      try
      {
        // ISSUE: reference to a compiler-generated method
        return new CoreWebView2Deferral((object) this._nativeICoreWebView2ServerCertificateErrorDetectedEventArgs.GetDeferral());
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
