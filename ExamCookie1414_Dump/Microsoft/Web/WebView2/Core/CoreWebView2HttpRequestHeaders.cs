// Decompiled with JetBrains decompiler
// Type: Microsoft.Web.WebView2.Core.CoreWebView2HttpRequestHeaders
// Assembly: ExamCookie.WinClient, Version=1.4.1.4, Culture=neutral, PublicKeyToken=null
// MVID: E12BE1F8-B6E0-4BF5-B308-166F0E938C4B
// Assembly location: C:\Users\oskar\Downloads\ExamCookie1414.WinClient.exe

using Microsoft.Web.WebView2.Core.Raw;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

#nullable disable
namespace Microsoft.Web.WebView2.Core
{
  [ComVisible(true)]
  public class CoreWebView2HttpRequestHeaders : 
    IEnumerable<KeyValuePair<string, string>>,
    IEnumerable
  {
    internal ICoreWebView2HttpRequestHeaders _nativeICoreWebView2HttpRequestHeadersValue;
    internal object _rawNative;

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.GetEnumerator();

    IEnumerator<KeyValuePair<string, string>> IEnumerable<KeyValuePair<string, string>>.GetEnumerator()
    {
      return (IEnumerator<KeyValuePair<string, string>>) this.GetEnumerator();
    }

    public CoreWebView2HttpHeadersCollectionIterator GetEnumerator() => this.GetIterator();

    internal ICoreWebView2HttpRequestHeaders _nativeICoreWebView2HttpRequestHeaders
    {
      get
      {
        if (this._nativeICoreWebView2HttpRequestHeadersValue == null)
        {
          try
          {
            this._nativeICoreWebView2HttpRequestHeadersValue = (ICoreWebView2HttpRequestHeaders) this._rawNative;
          }
          catch (Exception ex)
          {
            throw new NotImplementedException("Unable to cast to Microsoft.Web.WebView2.Core.Raw.ICoreWebView2HttpRequestHeaders.\nThis may happen if you are using an interface not supported by the version of the WebView2 Runtime you are using.\nFor instance, if you are using an experimental interface from an older SDK that has been modified or removed in a newer runtime.\nOr, if you are using a public interface from a newer SDK that wasn't implemented in an older runtime.\nFor more information about WebView2 versioning please visit the following: https://learn.microsoft.com/microsoft-edge/webview2/concepts/versioning", ex);
          }
        }
        return this._nativeICoreWebView2HttpRequestHeadersValue;
      }
      set => this._nativeICoreWebView2HttpRequestHeadersValue = value;
    }

    internal CoreWebView2HttpRequestHeaders(object rawCoreWebView2HttpRequestHeaders)
    {
      this._rawNative = rawCoreWebView2HttpRequestHeaders;
    }

    public string GetHeader(string name)
    {
      try
      {
        // ISSUE: reference to a compiler-generated method
        return this._nativeICoreWebView2HttpRequestHeaders.GetHeader(name);
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

    public CoreWebView2HttpHeadersCollectionIterator GetHeaders(string name)
    {
      try
      {
        // ISSUE: reference to a compiler-generated method
        return new CoreWebView2HttpHeadersCollectionIterator((object) this._nativeICoreWebView2HttpRequestHeaders.GetHeaders(name));
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

    public bool Contains(string name)
    {
      try
      {
        // ISSUE: reference to a compiler-generated method
        return this._nativeICoreWebView2HttpRequestHeaders.Contains(name) != 0;
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

    public void SetHeader(string name, string value)
    {
      try
      {
        // ISSUE: reference to a compiler-generated method
        this._nativeICoreWebView2HttpRequestHeaders.SetHeader(name, value);
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

    public void RemoveHeader(string name)
    {
      try
      {
        // ISSUE: reference to a compiler-generated method
        this._nativeICoreWebView2HttpRequestHeaders.RemoveHeader(name);
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

    public CoreWebView2HttpHeadersCollectionIterator GetIterator()
    {
      try
      {
        // ISSUE: reference to a compiler-generated method
        return new CoreWebView2HttpHeadersCollectionIterator((object) this._nativeICoreWebView2HttpRequestHeaders.GetIterator());
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
