// Decompiled with JetBrains decompiler
// Type: Microsoft.Web.WebView2.Core.CoreWebView2PrivateRemoteObjectProxy
// Assembly: ExamCookie.WinClient, Version=1.4.1.4, Culture=neutral, PublicKeyToken=null
// MVID: E12BE1F8-B6E0-4BF5-B308-166F0E938C4B
// Assembly location: C:\Users\oskar\Downloads\ExamCookie1414.WinClient.exe

using Microsoft.Web.WebView2.Core.Raw;
using System;
using System.Runtime.InteropServices;

#nullable disable
namespace Microsoft.Web.WebView2.Core
{
  internal class CoreWebView2PrivateRemoteObjectProxy
  {
    internal ICoreWebView2PrivateRemoteObjectProxy _nativeICoreWebView2PrivateRemoteObjectProxyValue;
    internal object _rawNative;
    private EventRegistrationToken _passivatedToken;
    private EventHandler<object> passivated;

    internal ICoreWebView2PrivateRemoteObjectProxy _nativeICoreWebView2PrivateRemoteObjectProxy
    {
      get
      {
        if (this._nativeICoreWebView2PrivateRemoteObjectProxyValue == null)
        {
          try
          {
            this._nativeICoreWebView2PrivateRemoteObjectProxyValue = (ICoreWebView2PrivateRemoteObjectProxy) this._rawNative;
          }
          catch (Exception ex)
          {
            throw new NotImplementedException("Unable to cast to Microsoft.Web.WebView2.Core.Raw.ICoreWebView2PrivateRemoteObjectProxy.\nThis may happen if you are using an interface not supported by the version of the WebView2 Runtime you are using.\nFor instance, if you are using an experimental interface from an older SDK that has been modified or removed in a newer runtime.\nOr, if you are using a public interface from a newer SDK that wasn't implemented in an older runtime.\nFor more information about WebView2 versioning please visit the following: https://learn.microsoft.com/microsoft-edge/webview2/concepts/versioning", ex);
          }
        }
        return this._nativeICoreWebView2PrivateRemoteObjectProxyValue;
      }
      set => this._nativeICoreWebView2PrivateRemoteObjectProxyValue = value;
    }

    internal CoreWebView2PrivateRemoteObjectProxy(object rawCoreWebView2PrivateRemoteObjectProxy)
    {
      this._rawNative = rawCoreWebView2PrivateRemoteObjectProxy;
    }

    internal event EventHandler<object> Passivated
    {
      add
      {
        if (this.passivated == null)
        {
          try
          {
            this._nativeICoreWebView2PrivateRemoteObjectProxy.add_Passivated((ICoreWebView2PrivateRemoteObjectProxyPassivatedEventHandler) new CoreWebView2PrivateRemoteObjectProxyPassivatedEventHandler(new CoreWebView2PrivateRemoteObjectProxyPassivatedEventHandler.CallbackType(this.OnPassivated)), out this._passivatedToken);
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
        this.passivated += value;
      }
      remove
      {
        this.passivated -= value;
        if (this.passivated != null)
          return;
        try
        {
          this._nativeICoreWebView2PrivateRemoteObjectProxy.remove_Passivated(this._passivatedToken);
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

    internal void OnPassivated(object args)
    {
      EventHandler<object> passivated = this.passivated;
      if (passivated == null)
        return;
      passivated((object) this, args);
    }

    internal int GetId()
    {
      try
      {
        // ISSUE: reference to a compiler-generated method
        return this._nativeICoreWebView2PrivateRemoteObjectProxy.GetId();
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
