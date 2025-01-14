// Decompiled with JetBrains decompiler
// Type: Microsoft.Web.WebView2.Core.CoreWebView2DevToolsProtocolEventReceiver
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
  public class CoreWebView2DevToolsProtocolEventReceiver
  {
    internal ICoreWebView2DevToolsProtocolEventReceiver _nativeICoreWebView2DevToolsProtocolEventReceiverValue;
    internal object _rawNative;
    private EventRegistrationToken _devToolsProtocolEventReceivedToken;
    private EventHandler<CoreWebView2DevToolsProtocolEventReceivedEventArgs> devToolsProtocolEventReceived;

    internal ICoreWebView2DevToolsProtocolEventReceiver _nativeICoreWebView2DevToolsProtocolEventReceiver
    {
      get
      {
        if (this._nativeICoreWebView2DevToolsProtocolEventReceiverValue == null)
        {
          try
          {
            this._nativeICoreWebView2DevToolsProtocolEventReceiverValue = (ICoreWebView2DevToolsProtocolEventReceiver) this._rawNative;
          }
          catch (Exception ex)
          {
            throw new NotImplementedException("Unable to cast to Microsoft.Web.WebView2.Core.Raw.ICoreWebView2DevToolsProtocolEventReceiver.\nThis may happen if you are using an interface not supported by the version of the WebView2 Runtime you are using.\nFor instance, if you are using an experimental interface from an older SDK that has been modified or removed in a newer runtime.\nOr, if you are using a public interface from a newer SDK that wasn't implemented in an older runtime.\nFor more information about WebView2 versioning please visit the following: https://learn.microsoft.com/microsoft-edge/webview2/concepts/versioning", ex);
          }
        }
        return this._nativeICoreWebView2DevToolsProtocolEventReceiverValue;
      }
      set => this._nativeICoreWebView2DevToolsProtocolEventReceiverValue = value;
    }

    internal CoreWebView2DevToolsProtocolEventReceiver(
      object rawCoreWebView2DevToolsProtocolEventReceiver)
    {
      this._rawNative = rawCoreWebView2DevToolsProtocolEventReceiver;
    }

    public event EventHandler<CoreWebView2DevToolsProtocolEventReceivedEventArgs> DevToolsProtocolEventReceived
    {
      add
      {
        if (this.devToolsProtocolEventReceived == null)
        {
          try
          {
            this._nativeICoreWebView2DevToolsProtocolEventReceiver.add_DevToolsProtocolEventReceived((ICoreWebView2DevToolsProtocolEventReceivedEventHandler) new CoreWebView2DevToolsProtocolEventReceivedEventHandler(new CoreWebView2DevToolsProtocolEventReceivedEventHandler.CallbackType(this.OnDevToolsProtocolEventReceived)), out this._devToolsProtocolEventReceivedToken);
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
        this.devToolsProtocolEventReceived += value;
      }
      remove
      {
        this.devToolsProtocolEventReceived -= value;
        if (this.devToolsProtocolEventReceived != null)
          return;
        try
        {
          this._nativeICoreWebView2DevToolsProtocolEventReceiver.remove_DevToolsProtocolEventReceived(this._devToolsProtocolEventReceivedToken);
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

    internal void OnDevToolsProtocolEventReceived(
      CoreWebView2DevToolsProtocolEventReceivedEventArgs args)
    {
      EventHandler<CoreWebView2DevToolsProtocolEventReceivedEventArgs> protocolEventReceived = this.devToolsProtocolEventReceived;
      if (protocolEventReceived == null)
        return;
      protocolEventReceived((object) this, args);
    }
  }
}
