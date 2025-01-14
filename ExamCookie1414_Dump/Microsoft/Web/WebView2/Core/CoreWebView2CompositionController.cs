// Decompiled with JetBrains decompiler
// Type: Microsoft.Web.WebView2.Core.CoreWebView2CompositionController
// Assembly: ExamCookie.WinClient, Version=1.4.1.4, Culture=neutral, PublicKeyToken=null
// MVID: E12BE1F8-B6E0-4BF5-B308-166F0E938C4B
// Assembly location: C:\Users\oskar\Downloads\ExamCookie1414.WinClient.exe

using Microsoft.Web.WebView2.Core.Raw;
using System;
using System.Drawing;
using System.Runtime.InteropServices;

#nullable disable
namespace Microsoft.Web.WebView2.Core
{
  [ComVisible(true)]
  public class CoreWebView2CompositionController
  {
    internal ICoreWebView2CompositionController _nativeICoreWebView2CompositionControllerValue;
    internal ICoreWebView2CompositionController2 _nativeICoreWebView2CompositionController2Value;
    internal ICoreWebView2CompositionController3 _nativeICoreWebView2CompositionController3Value;
    internal object _rawNative;
    private EventRegistrationToken _cursorChangedToken;
    private EventHandler<object> cursorChanged;

    internal ICoreWebView2CompositionController _nativeICoreWebView2CompositionController
    {
      get
      {
        if (this._nativeICoreWebView2CompositionControllerValue == null)
        {
          try
          {
            this._nativeICoreWebView2CompositionControllerValue = (ICoreWebView2CompositionController) this._rawNative;
          }
          catch (Exception ex)
          {
            throw new NotImplementedException("Unable to cast to Microsoft.Web.WebView2.Core.Raw.ICoreWebView2CompositionController.\nThis may happen if you are using an interface not supported by the version of the WebView2 Runtime you are using.\nFor instance, if you are using an experimental interface from an older SDK that has been modified or removed in a newer runtime.\nOr, if you are using a public interface from a newer SDK that wasn't implemented in an older runtime.\nFor more information about WebView2 versioning please visit the following: https://learn.microsoft.com/microsoft-edge/webview2/concepts/versioning", ex);
          }
        }
        return this._nativeICoreWebView2CompositionControllerValue;
      }
      set => this._nativeICoreWebView2CompositionControllerValue = value;
    }

    internal ICoreWebView2CompositionController2 _nativeICoreWebView2CompositionController2
    {
      get
      {
        if (this._nativeICoreWebView2CompositionController2Value == null)
        {
          try
          {
            this._nativeICoreWebView2CompositionController2Value = (ICoreWebView2CompositionController2) this._rawNative;
          }
          catch (Exception ex)
          {
            throw new NotImplementedException("Unable to cast to Microsoft.Web.WebView2.Core.Raw.ICoreWebView2CompositionController2.\nThis may happen if you are using an interface not supported by the version of the WebView2 Runtime you are using.\nFor instance, if you are using an experimental interface from an older SDK that has been modified or removed in a newer runtime.\nOr, if you are using a public interface from a newer SDK that wasn't implemented in an older runtime.\nFor more information about WebView2 versioning please visit the following: https://learn.microsoft.com/microsoft-edge/webview2/concepts/versioning", ex);
          }
        }
        return this._nativeICoreWebView2CompositionController2Value;
      }
      set => this._nativeICoreWebView2CompositionController2Value = value;
    }

    internal ICoreWebView2CompositionController3 _nativeICoreWebView2CompositionController3
    {
      get
      {
        if (this._nativeICoreWebView2CompositionController3Value == null)
        {
          try
          {
            this._nativeICoreWebView2CompositionController3Value = (ICoreWebView2CompositionController3) this._rawNative;
          }
          catch (Exception ex)
          {
            throw new NotImplementedException("Unable to cast to Microsoft.Web.WebView2.Core.Raw.ICoreWebView2CompositionController3.\nThis may happen if you are using an interface not supported by the version of the WebView2 Runtime you are using.\nFor instance, if you are using an experimental interface from an older SDK that has been modified or removed in a newer runtime.\nOr, if you are using a public interface from a newer SDK that wasn't implemented in an older runtime.\nFor more information about WebView2 versioning please visit the following: https://learn.microsoft.com/microsoft-edge/webview2/concepts/versioning", ex);
          }
        }
        return this._nativeICoreWebView2CompositionController3Value;
      }
      set => this._nativeICoreWebView2CompositionController3Value = value;
    }

    internal CoreWebView2CompositionController(object rawCoreWebView2CompositionController)
    {
      this._rawNative = rawCoreWebView2CompositionController;
    }

    public object RootVisualTarget
    {
      get
      {
        try
        {
          return this._nativeICoreWebView2CompositionController.RootVisualTarget;
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
          this._nativeICoreWebView2CompositionController.RootVisualTarget = value;
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

    public IntPtr Cursor
    {
      get
      {
        try
        {
          return this._nativeICoreWebView2CompositionController.Cursor;
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

    public uint SystemCursorId
    {
      get
      {
        try
        {
          return this._nativeICoreWebView2CompositionController.SystemCursorId;
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

    public event EventHandler<object> CursorChanged
    {
      add
      {
        if (this.cursorChanged == null)
        {
          try
          {
            this._nativeICoreWebView2CompositionController.add_CursorChanged((ICoreWebView2CursorChangedEventHandler) new CoreWebView2CursorChangedEventHandler(new CoreWebView2CursorChangedEventHandler.CallbackType(this.OnCursorChanged)), out this._cursorChangedToken);
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
        this.cursorChanged += value;
      }
      remove
      {
        this.cursorChanged -= value;
        if (this.cursorChanged != null)
          return;
        try
        {
          this._nativeICoreWebView2CompositionController.remove_CursorChanged(this._cursorChangedToken);
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

    internal void OnCursorChanged(object args)
    {
      EventHandler<object> cursorChanged = this.cursorChanged;
      if (cursorChanged == null)
        return;
      cursorChanged((object) this, args);
    }

    public void SendMouseInput(
      CoreWebView2MouseEventKind eventKind,
      CoreWebView2MouseEventVirtualKeys virtualKeys,
      uint mouseData,
      Point point)
    {
      try
      {
        // ISSUE: reference to a compiler-generated method
        this._nativeICoreWebView2CompositionController.SendMouseInput((COREWEBVIEW2_MOUSE_EVENT_KIND) eventKind, (COREWEBVIEW2_MOUSE_EVENT_VIRTUAL_KEYS) virtualKeys, mouseData, COMDotNetTypeConverter.PointNetToCOM(point));
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

    public void SendPointerInput(
      CoreWebView2PointerEventKind eventKind,
      CoreWebView2PointerInfo pointerInfo)
    {
      try
      {
        // ISSUE: reference to a compiler-generated method
        this._nativeICoreWebView2CompositionController.SendPointerInput((COREWEBVIEW2_POINTER_EVENT_KIND) eventKind, pointerInfo._nativeICoreWebView2PointerInfo);
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

    public void DragLeave()
    {
      try
      {
        // ISSUE: reference to a compiler-generated method
        this._nativeICoreWebView2CompositionController3.DragLeave();
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
