// Decompiled with JetBrains decompiler
// Type: Microsoft.Web.WebView2.Core.CoreWebView2WebResourceResponseReceivedEventArgs
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
  public class CoreWebView2WebResourceResponseReceivedEventArgs : EventArgs
  {
    internal ICoreWebView2WebResourceResponseReceivedEventArgs _nativeICoreWebView2WebResourceResponseReceivedEventArgsValue;
    internal object _rawNative;

    internal ICoreWebView2WebResourceResponseReceivedEventArgs _nativeICoreWebView2WebResourceResponseReceivedEventArgs
    {
      get
      {
        if (this._nativeICoreWebView2WebResourceResponseReceivedEventArgsValue == null)
        {
          try
          {
            this._nativeICoreWebView2WebResourceResponseReceivedEventArgsValue = (ICoreWebView2WebResourceResponseReceivedEventArgs) this._rawNative;
          }
          catch (Exception ex)
          {
            throw new NotImplementedException("Unable to cast to Microsoft.Web.WebView2.Core.Raw.ICoreWebView2WebResourceResponseReceivedEventArgs.\nThis may happen if you are using an interface not supported by the version of the WebView2 Runtime you are using.\nFor instance, if you are using an experimental interface from an older SDK that has been modified or removed in a newer runtime.\nOr, if you are using a public interface from a newer SDK that wasn't implemented in an older runtime.\nFor more information about WebView2 versioning please visit the following: https://learn.microsoft.com/microsoft-edge/webview2/concepts/versioning", ex);
          }
        }
        return this._nativeICoreWebView2WebResourceResponseReceivedEventArgsValue;
      }
      set => this._nativeICoreWebView2WebResourceResponseReceivedEventArgsValue = value;
    }

    internal CoreWebView2WebResourceResponseReceivedEventArgs(
      object rawCoreWebView2WebResourceResponseReceivedEventArgs)
    {
      this._rawNative = rawCoreWebView2WebResourceResponseReceivedEventArgs;
    }

    public CoreWebView2WebResourceRequest Request
    {
      get
      {
        try
        {
          return this._nativeICoreWebView2WebResourceResponseReceivedEventArgs.Request == null ? (CoreWebView2WebResourceRequest) null : new CoreWebView2WebResourceRequest((object) this._nativeICoreWebView2WebResourceResponseReceivedEventArgs.Request);
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

    public CoreWebView2WebResourceResponseView Response
    {
      get
      {
        try
        {
          return this._nativeICoreWebView2WebResourceResponseReceivedEventArgs.Response == null ? (CoreWebView2WebResourceResponseView) null : new CoreWebView2WebResourceResponseView((object) this._nativeICoreWebView2WebResourceResponseReceivedEventArgs.Response);
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
}
