﻿// Decompiled with JetBrains decompiler
// Type: Microsoft.Web.WebView2.Core.CoreWebView2DownloadStartingEventArgs
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
  public class CoreWebView2DownloadStartingEventArgs : EventArgs
  {
    internal ICoreWebView2DownloadStartingEventArgs _nativeICoreWebView2DownloadStartingEventArgsValue;
    internal object _rawNative;

    internal ICoreWebView2DownloadStartingEventArgs _nativeICoreWebView2DownloadStartingEventArgs
    {
      get
      {
        if (this._nativeICoreWebView2DownloadStartingEventArgsValue == null)
        {
          try
          {
            this._nativeICoreWebView2DownloadStartingEventArgsValue = (ICoreWebView2DownloadStartingEventArgs) this._rawNative;
          }
          catch (Exception ex)
          {
            throw new NotImplementedException("Unable to cast to Microsoft.Web.WebView2.Core.Raw.ICoreWebView2DownloadStartingEventArgs.\nThis may happen if you are using an interface not supported by the version of the WebView2 Runtime you are using.\nFor instance, if you are using an experimental interface from an older SDK that has been modified or removed in a newer runtime.\nOr, if you are using a public interface from a newer SDK that wasn't implemented in an older runtime.\nFor more information about WebView2 versioning please visit the following: https://learn.microsoft.com/microsoft-edge/webview2/concepts/versioning", ex);
          }
        }
        return this._nativeICoreWebView2DownloadStartingEventArgsValue;
      }
      set => this._nativeICoreWebView2DownloadStartingEventArgsValue = value;
    }

    internal CoreWebView2DownloadStartingEventArgs(object rawCoreWebView2DownloadStartingEventArgs)
    {
      this._rawNative = rawCoreWebView2DownloadStartingEventArgs;
    }

    public CoreWebView2DownloadOperation DownloadOperation
    {
      get
      {
        try
        {
          return this._nativeICoreWebView2DownloadStartingEventArgs.DownloadOperation == null ? (CoreWebView2DownloadOperation) null : new CoreWebView2DownloadOperation((object) this._nativeICoreWebView2DownloadStartingEventArgs.DownloadOperation);
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

    public bool Cancel
    {
      get
      {
        try
        {
          return this._nativeICoreWebView2DownloadStartingEventArgs.Cancel != 0;
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
          this._nativeICoreWebView2DownloadStartingEventArgs.Cancel = value ? 1 : 0;
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

    public string ResultFilePath
    {
      get
      {
        try
        {
          return this._nativeICoreWebView2DownloadStartingEventArgs.ResultFilePath;
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
          this._nativeICoreWebView2DownloadStartingEventArgs.ResultFilePath = value;
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

    public bool Handled
    {
      get
      {
        try
        {
          return this._nativeICoreWebView2DownloadStartingEventArgs.Handled != 0;
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
          this._nativeICoreWebView2DownloadStartingEventArgs.Handled = value ? 1 : 0;
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
        return new CoreWebView2Deferral((object) this._nativeICoreWebView2DownloadStartingEventArgs.GetDeferral());
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
