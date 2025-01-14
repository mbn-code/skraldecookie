// Decompiled with JetBrains decompiler
// Type: Microsoft.Web.WebView2.Core.CoreWebView2ProcessFailedEventArgs
// Assembly: ExamCookie.WinClient, Version=1.4.1.4, Culture=neutral, PublicKeyToken=null
// MVID: E12BE1F8-B6E0-4BF5-B308-166F0E938C4B
// Assembly location: C:\Users\oskar\Downloads\ExamCookie1414.WinClient.exe

using Microsoft.Web.WebView2.Core.Raw;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

#nullable disable
namespace Microsoft.Web.WebView2.Core
{
  [ComVisible(true)]
  public class CoreWebView2ProcessFailedEventArgs : EventArgs
  {
    internal ICoreWebView2ProcessFailedEventArgs _nativeICoreWebView2ProcessFailedEventArgsValue;
    internal ICoreWebView2ProcessFailedEventArgs2 _nativeICoreWebView2ProcessFailedEventArgs2Value;
    internal object _rawNative;

    internal ICoreWebView2ProcessFailedEventArgs _nativeICoreWebView2ProcessFailedEventArgs
    {
      get
      {
        if (this._nativeICoreWebView2ProcessFailedEventArgsValue == null)
        {
          try
          {
            this._nativeICoreWebView2ProcessFailedEventArgsValue = (ICoreWebView2ProcessFailedEventArgs) this._rawNative;
          }
          catch (Exception ex)
          {
            throw new NotImplementedException("Unable to cast to Microsoft.Web.WebView2.Core.Raw.ICoreWebView2ProcessFailedEventArgs.\nThis may happen if you are using an interface not supported by the version of the WebView2 Runtime you are using.\nFor instance, if you are using an experimental interface from an older SDK that has been modified or removed in a newer runtime.\nOr, if you are using a public interface from a newer SDK that wasn't implemented in an older runtime.\nFor more information about WebView2 versioning please visit the following: https://learn.microsoft.com/microsoft-edge/webview2/concepts/versioning", ex);
          }
        }
        return this._nativeICoreWebView2ProcessFailedEventArgsValue;
      }
      set => this._nativeICoreWebView2ProcessFailedEventArgsValue = value;
    }

    internal ICoreWebView2ProcessFailedEventArgs2 _nativeICoreWebView2ProcessFailedEventArgs2
    {
      get
      {
        if (this._nativeICoreWebView2ProcessFailedEventArgs2Value == null)
        {
          try
          {
            this._nativeICoreWebView2ProcessFailedEventArgs2Value = (ICoreWebView2ProcessFailedEventArgs2) this._rawNative;
          }
          catch (Exception ex)
          {
            throw new NotImplementedException("Unable to cast to Microsoft.Web.WebView2.Core.Raw.ICoreWebView2ProcessFailedEventArgs2.\nThis may happen if you are using an interface not supported by the version of the WebView2 Runtime you are using.\nFor instance, if you are using an experimental interface from an older SDK that has been modified or removed in a newer runtime.\nOr, if you are using a public interface from a newer SDK that wasn't implemented in an older runtime.\nFor more information about WebView2 versioning please visit the following: https://learn.microsoft.com/microsoft-edge/webview2/concepts/versioning", ex);
          }
        }
        return this._nativeICoreWebView2ProcessFailedEventArgs2Value;
      }
      set => this._nativeICoreWebView2ProcessFailedEventArgs2Value = value;
    }

    internal CoreWebView2ProcessFailedEventArgs(object rawCoreWebView2ProcessFailedEventArgs)
    {
      this._rawNative = rawCoreWebView2ProcessFailedEventArgs;
    }

    public CoreWebView2ProcessFailedKind ProcessFailedKind
    {
      get
      {
        try
        {
          return (CoreWebView2ProcessFailedKind) this._nativeICoreWebView2ProcessFailedEventArgs.ProcessFailedKind;
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

    public CoreWebView2ProcessFailedReason Reason
    {
      get
      {
        try
        {
          return (CoreWebView2ProcessFailedReason) this._nativeICoreWebView2ProcessFailedEventArgs2.Reason;
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

    public int ExitCode
    {
      get
      {
        try
        {
          return this._nativeICoreWebView2ProcessFailedEventArgs2.ExitCode;
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

    public string ProcessDescription
    {
      get
      {
        try
        {
          return this._nativeICoreWebView2ProcessFailedEventArgs2.ProcessDescription;
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

    public IReadOnlyList<CoreWebView2FrameInfo> FrameInfosForFailedProcess
    {
      get
      {
        try
        {
          return COMDotNetTypeConverter.CoreWebView2FrameInfoCollectionCOMToNet(this._nativeICoreWebView2ProcessFailedEventArgs2.FrameInfosForFailedProcess);
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
