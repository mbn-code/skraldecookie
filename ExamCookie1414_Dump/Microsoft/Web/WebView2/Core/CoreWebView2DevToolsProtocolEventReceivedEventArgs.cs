﻿// Decompiled with JetBrains decompiler
// Type: Microsoft.Web.WebView2.Core.CoreWebView2DevToolsProtocolEventReceivedEventArgs
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
  public class CoreWebView2DevToolsProtocolEventReceivedEventArgs : EventArgs
  {
    internal ICoreWebView2DevToolsProtocolEventReceivedEventArgs _nativeICoreWebView2DevToolsProtocolEventReceivedEventArgsValue;
    internal ICoreWebView2DevToolsProtocolEventReceivedEventArgs2 _nativeICoreWebView2DevToolsProtocolEventReceivedEventArgs2Value;
    internal object _rawNative;

    internal ICoreWebView2DevToolsProtocolEventReceivedEventArgs _nativeICoreWebView2DevToolsProtocolEventReceivedEventArgs
    {
      get
      {
        if (this._nativeICoreWebView2DevToolsProtocolEventReceivedEventArgsValue == null)
        {
          try
          {
            this._nativeICoreWebView2DevToolsProtocolEventReceivedEventArgsValue = (ICoreWebView2DevToolsProtocolEventReceivedEventArgs) this._rawNative;
          }
          catch (Exception ex)
          {
            throw new NotImplementedException("Unable to cast to Microsoft.Web.WebView2.Core.Raw.ICoreWebView2DevToolsProtocolEventReceivedEventArgs.\nThis may happen if you are using an interface not supported by the version of the WebView2 Runtime you are using.\nFor instance, if you are using an experimental interface from an older SDK that has been modified or removed in a newer runtime.\nOr, if you are using a public interface from a newer SDK that wasn't implemented in an older runtime.\nFor more information about WebView2 versioning please visit the following: https://learn.microsoft.com/microsoft-edge/webview2/concepts/versioning", ex);
          }
        }
        return this._nativeICoreWebView2DevToolsProtocolEventReceivedEventArgsValue;
      }
      set => this._nativeICoreWebView2DevToolsProtocolEventReceivedEventArgsValue = value;
    }

    internal ICoreWebView2DevToolsProtocolEventReceivedEventArgs2 _nativeICoreWebView2DevToolsProtocolEventReceivedEventArgs2
    {
      get
      {
        if (this._nativeICoreWebView2DevToolsProtocolEventReceivedEventArgs2Value == null)
        {
          try
          {
            this._nativeICoreWebView2DevToolsProtocolEventReceivedEventArgs2Value = (ICoreWebView2DevToolsProtocolEventReceivedEventArgs2) this._rawNative;
          }
          catch (Exception ex)
          {
            throw new NotImplementedException("Unable to cast to Microsoft.Web.WebView2.Core.Raw.ICoreWebView2DevToolsProtocolEventReceivedEventArgs2.\nThis may happen if you are using an interface not supported by the version of the WebView2 Runtime you are using.\nFor instance, if you are using an experimental interface from an older SDK that has been modified or removed in a newer runtime.\nOr, if you are using a public interface from a newer SDK that wasn't implemented in an older runtime.\nFor more information about WebView2 versioning please visit the following: https://learn.microsoft.com/microsoft-edge/webview2/concepts/versioning", ex);
          }
        }
        return this._nativeICoreWebView2DevToolsProtocolEventReceivedEventArgs2Value;
      }
      set => this._nativeICoreWebView2DevToolsProtocolEventReceivedEventArgs2Value = value;
    }

    internal CoreWebView2DevToolsProtocolEventReceivedEventArgs(
      object rawCoreWebView2DevToolsProtocolEventReceivedEventArgs)
    {
      this._rawNative = rawCoreWebView2DevToolsProtocolEventReceivedEventArgs;
    }

    public string ParameterObjectAsJson
    {
      get
      {
        try
        {
          return this._nativeICoreWebView2DevToolsProtocolEventReceivedEventArgs.ParameterObjectAsJson;
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

    public string SessionId
    {
      get
      {
        try
        {
          return this._nativeICoreWebView2DevToolsProtocolEventReceivedEventArgs2.SessionId;
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
