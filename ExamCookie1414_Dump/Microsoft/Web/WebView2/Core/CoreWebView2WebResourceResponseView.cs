// Decompiled with JetBrains decompiler
// Type: Microsoft.Web.WebView2.Core.CoreWebView2WebResourceResponseView
// Assembly: ExamCookie.WinClient, Version=1.4.1.4, Culture=neutral, PublicKeyToken=null
// MVID: E12BE1F8-B6E0-4BF5-B308-166F0E938C4B
// Assembly location: C:\Users\oskar\Downloads\ExamCookie1414.WinClient.exe

using Microsoft.Web.WebView2.Core.Raw;
using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

#nullable disable
namespace Microsoft.Web.WebView2.Core
{
  [ComVisible(true)]
  public class CoreWebView2WebResourceResponseView
  {
    internal ICoreWebView2WebResourceResponseView _nativeICoreWebView2WebResourceResponseViewValue;
    internal object _rawNative;

    internal ICoreWebView2WebResourceResponseView _nativeICoreWebView2WebResourceResponseView
    {
      get
      {
        if (this._nativeICoreWebView2WebResourceResponseViewValue == null)
        {
          try
          {
            this._nativeICoreWebView2WebResourceResponseViewValue = (ICoreWebView2WebResourceResponseView) this._rawNative;
          }
          catch (Exception ex)
          {
            throw new NotImplementedException("Unable to cast to Microsoft.Web.WebView2.Core.Raw.ICoreWebView2WebResourceResponseView.\nThis may happen if you are using an interface not supported by the version of the WebView2 Runtime you are using.\nFor instance, if you are using an experimental interface from an older SDK that has been modified or removed in a newer runtime.\nOr, if you are using a public interface from a newer SDK that wasn't implemented in an older runtime.\nFor more information about WebView2 versioning please visit the following: https://learn.microsoft.com/microsoft-edge/webview2/concepts/versioning", ex);
          }
        }
        return this._nativeICoreWebView2WebResourceResponseViewValue;
      }
      set => this._nativeICoreWebView2WebResourceResponseViewValue = value;
    }

    internal CoreWebView2WebResourceResponseView(object rawCoreWebView2WebResourceResponseView)
    {
      this._rawNative = rawCoreWebView2WebResourceResponseView;
    }

    public CoreWebView2HttpResponseHeaders Headers
    {
      get
      {
        try
        {
          return this._nativeICoreWebView2WebResourceResponseView.Headers == null ? (CoreWebView2HttpResponseHeaders) null : new CoreWebView2HttpResponseHeaders((object) this._nativeICoreWebView2WebResourceResponseView.Headers);
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

    public int StatusCode
    {
      get
      {
        try
        {
          return this._nativeICoreWebView2WebResourceResponseView.StatusCode;
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

    public string ReasonPhrase
    {
      get
      {
        try
        {
          return this._nativeICoreWebView2WebResourceResponseView.ReasonPhrase;
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

    public async Task<Stream> GetContentAsync()
    {
      CoreWebView2WebResourceResponseViewGetContentCompletedHandler handler;
      try
      {
        handler = new CoreWebView2WebResourceResponseViewGetContentCompletedHandler();
        // ISSUE: reference to a compiler-generated method
        this._nativeICoreWebView2WebResourceResponseView.GetContent((ICoreWebView2WebResourceResponseViewGetContentCompletedHandler) handler);
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
      Stream stream = await handler;
      Marshal.ThrowExceptionForHR(handler.errCode);
      Stream content = handler.Content;
      handler = (CoreWebView2WebResourceResponseViewGetContentCompletedHandler) null;
      return content;
    }
  }
}
