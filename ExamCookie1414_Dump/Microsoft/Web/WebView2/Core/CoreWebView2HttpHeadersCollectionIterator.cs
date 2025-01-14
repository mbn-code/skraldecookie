// Decompiled with JetBrains decompiler
// Type: Microsoft.Web.WebView2.Core.CoreWebView2HttpHeadersCollectionIterator
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
  public class CoreWebView2HttpHeadersCollectionIterator : 
    IEnumerator<KeyValuePair<string, string>>,
    IDisposable,
    IEnumerator
  {
    private bool isInitialized;
    internal ICoreWebView2HttpHeadersCollectionIterator _nativeICoreWebView2HttpHeadersCollectionIteratorValue;
    internal object _rawNative;

    public bool MoveNext()
    {
      if (this.isInitialized)
      {
        // ISSUE: reference to a compiler-generated method
        return this._nativeICoreWebView2HttpHeadersCollectionIterator.MoveNext() != 0;
      }
      this.isInitialized = true;
      return this.HasCurrentHeader;
    }

    public void Reset() => throw new NotSupportedException();

    public void Dispose()
    {
    }

    object IEnumerator.Current => (object) this.Current;

    public KeyValuePair<string, string> Current
    {
      get
      {
        try
        {
          string name;
          string str;
          this.GetCurrentHeader(out name, out str);
          return new KeyValuePair<string, string>(name, str);
        }
        catch (IndexOutOfRangeException ex)
        {
          throw new InvalidOperationException();
        }
      }
    }

    internal ICoreWebView2HttpHeadersCollectionIterator _nativeICoreWebView2HttpHeadersCollectionIterator
    {
      get
      {
        if (this._nativeICoreWebView2HttpHeadersCollectionIteratorValue == null)
        {
          try
          {
            this._nativeICoreWebView2HttpHeadersCollectionIteratorValue = (ICoreWebView2HttpHeadersCollectionIterator) this._rawNative;
          }
          catch (Exception ex)
          {
            throw new NotImplementedException("Unable to cast to Microsoft.Web.WebView2.Core.Raw.ICoreWebView2HttpHeadersCollectionIterator.\nThis may happen if you are using an interface not supported by the version of the WebView2 Runtime you are using.\nFor instance, if you are using an experimental interface from an older SDK that has been modified or removed in a newer runtime.\nOr, if you are using a public interface from a newer SDK that wasn't implemented in an older runtime.\nFor more information about WebView2 versioning please visit the following: https://learn.microsoft.com/microsoft-edge/webview2/concepts/versioning", ex);
          }
        }
        return this._nativeICoreWebView2HttpHeadersCollectionIteratorValue;
      }
      set => this._nativeICoreWebView2HttpHeadersCollectionIteratorValue = value;
    }

    internal CoreWebView2HttpHeadersCollectionIterator(
      object rawCoreWebView2HttpHeadersCollectionIterator)
    {
      this._rawNative = rawCoreWebView2HttpHeadersCollectionIterator;
    }

    public bool HasCurrentHeader
    {
      get
      {
        try
        {
          return this._nativeICoreWebView2HttpHeadersCollectionIterator.HasCurrentHeader != 0;
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

    private void GetCurrentHeader(out string name, out string value)
    {
      try
      {
        // ISSUE: reference to a compiler-generated method
        this._nativeICoreWebView2HttpHeadersCollectionIterator.GetCurrentHeader(out name, out value);
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
