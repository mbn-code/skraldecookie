// Decompiled with JetBrains decompiler
// Type: Microsoft.Web.WebView2.Core.CoreWebView2Deferral
// Assembly: ExamCookie.WinClient, Version=1.4.1.4, Culture=neutral, PublicKeyToken=null
// MVID: E12BE1F8-B6E0-4BF5-B308-166F0E938C4B
// Assembly location: C:\Users\oskar\Downloads\ExamCookie1414.WinClient.exe

using Microsoft.Web.WebView2.Core.Raw;
using Microsoft.Win32.SafeHandles;
using System;
using System.Runtime.InteropServices;

#nullable disable
namespace Microsoft.Web.WebView2.Core
{
  [ComVisible(true)]
  public class CoreWebView2Deferral : IDisposable
  {
    private bool disposed;
    private SafeHandle handle = (SafeHandle) new SafeFileHandle(IntPtr.Zero, true);
    internal ICoreWebView2Deferral _nativeICoreWebView2DeferralValue;
    internal object _rawNative;

    public void Dispose()
    {
      this.Dispose(true);
      GC.SuppressFinalize((object) this);
    }

    protected virtual void Dispose(bool disposing)
    {
      if (this.disposed)
        return;
      if (disposing)
        this.handle.Dispose();
      this.Complete();
      this.disposed = true;
    }

    internal ICoreWebView2Deferral _nativeICoreWebView2Deferral
    {
      get
      {
        if (this._nativeICoreWebView2DeferralValue == null)
        {
          try
          {
            this._nativeICoreWebView2DeferralValue = (ICoreWebView2Deferral) this._rawNative;
          }
          catch (Exception ex)
          {
            throw new NotImplementedException("Unable to cast to Microsoft.Web.WebView2.Core.Raw.ICoreWebView2Deferral.\nThis may happen if you are using an interface not supported by the version of the WebView2 Runtime you are using.\nFor instance, if you are using an experimental interface from an older SDK that has been modified or removed in a newer runtime.\nOr, if you are using a public interface from a newer SDK that wasn't implemented in an older runtime.\nFor more information about WebView2 versioning please visit the following: https://learn.microsoft.com/microsoft-edge/webview2/concepts/versioning", ex);
          }
        }
        return this._nativeICoreWebView2DeferralValue;
      }
      set => this._nativeICoreWebView2DeferralValue = value;
    }

    internal CoreWebView2Deferral(object rawCoreWebView2Deferral)
    {
      this._rawNative = rawCoreWebView2Deferral;
    }

    public void Complete()
    {
      try
      {
        // ISSUE: reference to a compiler-generated method
        this._nativeICoreWebView2Deferral.Complete();
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
