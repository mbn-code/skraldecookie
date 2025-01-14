// Decompiled with JetBrains decompiler
// Type: Microsoft.Web.WebView2.Core.CoreWebView2WebMessageReceivedEventArgs
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
  public class CoreWebView2WebMessageReceivedEventArgs : EventArgs
  {
    internal ICoreWebView2WebMessageReceivedEventArgs _nativeICoreWebView2WebMessageReceivedEventArgsValue;
    internal ICoreWebView2WebMessageReceivedEventArgs2 _nativeICoreWebView2WebMessageReceivedEventArgs2Value;
    internal object _rawNative;

    internal ICoreWebView2WebMessageReceivedEventArgs _nativeICoreWebView2WebMessageReceivedEventArgs
    {
      get
      {
        if (this._nativeICoreWebView2WebMessageReceivedEventArgsValue == null)
        {
          try
          {
            this._nativeICoreWebView2WebMessageReceivedEventArgsValue = (ICoreWebView2WebMessageReceivedEventArgs) this._rawNative;
          }
          catch (Exception ex)
          {
            throw new NotImplementedException("Unable to cast to Microsoft.Web.WebView2.Core.Raw.ICoreWebView2WebMessageReceivedEventArgs.\nThis may happen if you are using an interface not supported by the version of the WebView2 Runtime you are using.\nFor instance, if you are using an experimental interface from an older SDK that has been modified or removed in a newer runtime.\nOr, if you are using a public interface from a newer SDK that wasn't implemented in an older runtime.\nFor more information about WebView2 versioning please visit the following: https://learn.microsoft.com/microsoft-edge/webview2/concepts/versioning", ex);
          }
        }
        return this._nativeICoreWebView2WebMessageReceivedEventArgsValue;
      }
      set => this._nativeICoreWebView2WebMessageReceivedEventArgsValue = value;
    }

    internal ICoreWebView2WebMessageReceivedEventArgs2 _nativeICoreWebView2WebMessageReceivedEventArgs2
    {
      get
      {
        if (this._nativeICoreWebView2WebMessageReceivedEventArgs2Value == null)
        {
          try
          {
            this._nativeICoreWebView2WebMessageReceivedEventArgs2Value = (ICoreWebView2WebMessageReceivedEventArgs2) this._rawNative;
          }
          catch (Exception ex)
          {
            throw new NotImplementedException("Unable to cast to Microsoft.Web.WebView2.Core.Raw.ICoreWebView2WebMessageReceivedEventArgs2.\nThis may happen if you are using an interface not supported by the version of the WebView2 Runtime you are using.\nFor instance, if you are using an experimental interface from an older SDK that has been modified or removed in a newer runtime.\nOr, if you are using a public interface from a newer SDK that wasn't implemented in an older runtime.\nFor more information about WebView2 versioning please visit the following: https://learn.microsoft.com/microsoft-edge/webview2/concepts/versioning", ex);
          }
        }
        return this._nativeICoreWebView2WebMessageReceivedEventArgs2Value;
      }
      set => this._nativeICoreWebView2WebMessageReceivedEventArgs2Value = value;
    }

    internal CoreWebView2WebMessageReceivedEventArgs(
      object rawCoreWebView2WebMessageReceivedEventArgs)
    {
      this._rawNative = rawCoreWebView2WebMessageReceivedEventArgs;
    }

    public string Source
    {
      get
      {
        try
        {
          return this._nativeICoreWebView2WebMessageReceivedEventArgs.Source;
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

    public string WebMessageAsJson
    {
      get
      {
        try
        {
          return this._nativeICoreWebView2WebMessageReceivedEventArgs.WebMessageAsJson;
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

    public string TryGetWebMessageAsString()
    {
      try
      {
        // ISSUE: reference to a compiler-generated method
        return this._nativeICoreWebView2WebMessageReceivedEventArgs.TryGetWebMessageAsString();
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

    public IReadOnlyList<object> AdditionalObjects
    {
      get
      {
        try
        {
          return COMDotNetTypeConverter.CoreWebView2ObjectCollectionViewCOMToNet(this._nativeICoreWebView2WebMessageReceivedEventArgs2.AdditionalObjects);
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
