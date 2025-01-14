// Decompiled with JetBrains decompiler
// Type: Microsoft.Web.WebView2.Core.CoreWebView2NewWindowRequestedEventArgs
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
  public class CoreWebView2NewWindowRequestedEventArgs : EventArgs
  {
    internal ICoreWebView2NewWindowRequestedEventArgs _nativeICoreWebView2NewWindowRequestedEventArgsValue;
    internal ICoreWebView2NewWindowRequestedEventArgs2 _nativeICoreWebView2NewWindowRequestedEventArgs2Value;
    internal ICoreWebView2NewWindowRequestedEventArgs3 _nativeICoreWebView2NewWindowRequestedEventArgs3Value;
    internal object _rawNative;

    internal ICoreWebView2NewWindowRequestedEventArgs _nativeICoreWebView2NewWindowRequestedEventArgs
    {
      get
      {
        if (this._nativeICoreWebView2NewWindowRequestedEventArgsValue == null)
        {
          try
          {
            this._nativeICoreWebView2NewWindowRequestedEventArgsValue = (ICoreWebView2NewWindowRequestedEventArgs) this._rawNative;
          }
          catch (Exception ex)
          {
            throw new NotImplementedException("Unable to cast to Microsoft.Web.WebView2.Core.Raw.ICoreWebView2NewWindowRequestedEventArgs.\nThis may happen if you are using an interface not supported by the version of the WebView2 Runtime you are using.\nFor instance, if you are using an experimental interface from an older SDK that has been modified or removed in a newer runtime.\nOr, if you are using a public interface from a newer SDK that wasn't implemented in an older runtime.\nFor more information about WebView2 versioning please visit the following: https://learn.microsoft.com/microsoft-edge/webview2/concepts/versioning", ex);
          }
        }
        return this._nativeICoreWebView2NewWindowRequestedEventArgsValue;
      }
      set => this._nativeICoreWebView2NewWindowRequestedEventArgsValue = value;
    }

    internal ICoreWebView2NewWindowRequestedEventArgs2 _nativeICoreWebView2NewWindowRequestedEventArgs2
    {
      get
      {
        if (this._nativeICoreWebView2NewWindowRequestedEventArgs2Value == null)
        {
          try
          {
            this._nativeICoreWebView2NewWindowRequestedEventArgs2Value = (ICoreWebView2NewWindowRequestedEventArgs2) this._rawNative;
          }
          catch (Exception ex)
          {
            throw new NotImplementedException("Unable to cast to Microsoft.Web.WebView2.Core.Raw.ICoreWebView2NewWindowRequestedEventArgs2.\nThis may happen if you are using an interface not supported by the version of the WebView2 Runtime you are using.\nFor instance, if you are using an experimental interface from an older SDK that has been modified or removed in a newer runtime.\nOr, if you are using a public interface from a newer SDK that wasn't implemented in an older runtime.\nFor more information about WebView2 versioning please visit the following: https://learn.microsoft.com/microsoft-edge/webview2/concepts/versioning", ex);
          }
        }
        return this._nativeICoreWebView2NewWindowRequestedEventArgs2Value;
      }
      set => this._nativeICoreWebView2NewWindowRequestedEventArgs2Value = value;
    }

    internal ICoreWebView2NewWindowRequestedEventArgs3 _nativeICoreWebView2NewWindowRequestedEventArgs3
    {
      get
      {
        if (this._nativeICoreWebView2NewWindowRequestedEventArgs3Value == null)
        {
          try
          {
            this._nativeICoreWebView2NewWindowRequestedEventArgs3Value = (ICoreWebView2NewWindowRequestedEventArgs3) this._rawNative;
          }
          catch (Exception ex)
          {
            throw new NotImplementedException("Unable to cast to Microsoft.Web.WebView2.Core.Raw.ICoreWebView2NewWindowRequestedEventArgs3.\nThis may happen if you are using an interface not supported by the version of the WebView2 Runtime you are using.\nFor instance, if you are using an experimental interface from an older SDK that has been modified or removed in a newer runtime.\nOr, if you are using a public interface from a newer SDK that wasn't implemented in an older runtime.\nFor more information about WebView2 versioning please visit the following: https://learn.microsoft.com/microsoft-edge/webview2/concepts/versioning", ex);
          }
        }
        return this._nativeICoreWebView2NewWindowRequestedEventArgs3Value;
      }
      set => this._nativeICoreWebView2NewWindowRequestedEventArgs3Value = value;
    }

    internal CoreWebView2NewWindowRequestedEventArgs(
      object rawCoreWebView2NewWindowRequestedEventArgs)
    {
      this._rawNative = rawCoreWebView2NewWindowRequestedEventArgs;
    }

    public string Uri
    {
      get
      {
        try
        {
          return this._nativeICoreWebView2NewWindowRequestedEventArgs.Uri;
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

    public CoreWebView2 NewWindow
    {
      get
      {
        try
        {
          return this._nativeICoreWebView2NewWindowRequestedEventArgs.NewWindow == null ? (CoreWebView2) null : new CoreWebView2((object) this._nativeICoreWebView2NewWindowRequestedEventArgs.NewWindow);
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
          this._nativeICoreWebView2NewWindowRequestedEventArgs.NewWindow = value._nativeICoreWebView2;
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
          return this._nativeICoreWebView2NewWindowRequestedEventArgs.Handled != 0;
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
          this._nativeICoreWebView2NewWindowRequestedEventArgs.Handled = value ? 1 : 0;
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

    public bool IsUserInitiated
    {
      get
      {
        try
        {
          return this._nativeICoreWebView2NewWindowRequestedEventArgs.IsUserInitiated != 0;
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

    public CoreWebView2WindowFeatures WindowFeatures
    {
      get
      {
        try
        {
          return this._nativeICoreWebView2NewWindowRequestedEventArgs.WindowFeatures == null ? (CoreWebView2WindowFeatures) null : new CoreWebView2WindowFeatures((object) this._nativeICoreWebView2NewWindowRequestedEventArgs.WindowFeatures);
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
        return new CoreWebView2Deferral((object) this._nativeICoreWebView2NewWindowRequestedEventArgs.GetDeferral());
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

    public string Name
    {
      get
      {
        try
        {
          return this._nativeICoreWebView2NewWindowRequestedEventArgs2.Name;
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

    public CoreWebView2FrameInfo OriginalSourceFrameInfo
    {
      get
      {
        try
        {
          return this._nativeICoreWebView2NewWindowRequestedEventArgs3.OriginalSourceFrameInfo == null ? (CoreWebView2FrameInfo) null : new CoreWebView2FrameInfo((object) this._nativeICoreWebView2NewWindowRequestedEventArgs3.OriginalSourceFrameInfo);
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
