// Decompiled with JetBrains decompiler
// Type: Microsoft.Web.WebView2.Core.CoreWebView2Controller
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
  public class CoreWebView2Controller
  {
    private const string HostObjectHelperName = "{60A417CA-F1AB-4307-801B-F96003F8938B} Host Object Helper";
    private CoreWebView2 _coreWebView2;
    internal ICoreWebView2Controller _nativeICoreWebView2ControllerValue;
    internal ICoreWebView2Controller2 _nativeICoreWebView2Controller2Value;
    internal ICoreWebView2Controller3 _nativeICoreWebView2Controller3Value;
    internal ICoreWebView2Controller4 _nativeICoreWebView2Controller4Value;
    internal ICoreWebView2PrivatePartialController _nativeICoreWebView2PrivatePartialControllerValue;
    internal object _rawNative;
    private EventRegistrationToken _zoomFactorChangedToken;
    private EventHandler<object> zoomFactorChanged;
    private EventRegistrationToken _moveFocusRequestedToken;
    private EventHandler<CoreWebView2MoveFocusRequestedEventArgs> moveFocusRequested;
    private EventRegistrationToken _gotFocusToken;
    private EventHandler<object> gotFocus;
    private EventRegistrationToken _lostFocusToken;
    private EventHandler<object> lostFocus;
    private EventRegistrationToken _acceleratorKeyPressedToken;
    private EventHandler<CoreWebView2AcceleratorKeyPressedEventArgs> acceleratorKeyPressed;
    private EventRegistrationToken _rasterizationScaleChangedToken;
    private EventHandler<object> rasterizationScaleChanged;
    private EventRegistrationToken _keyPressedToken;
    private EventHandler<CoreWebView2PrivateKeyPressedEventArgs> keyPressed;

    public CoreWebView2 CoreWebView2
    {
      get
      {
        if (this._nativeICoreWebView2Controller.CoreWebView2 == null)
          return (CoreWebView2) null;
        if (this._coreWebView2 == null)
          this._coreWebView2 = new CoreWebView2((object) this._nativeICoreWebView2Controller.CoreWebView2);
        return this._coreWebView2;
      }
    }

    public void MoveFocus(CoreWebView2MoveFocusReason reason)
    {
      try
      {
        // ISSUE: reference to a compiler-generated method
        this._nativeICoreWebView2Controller.MoveFocus((COREWEBVIEW2_MOVE_FOCUS_REASON) reason);
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
      catch (ArgumentException ex)
      {
        if (ex.HResult != -2147024809)
          throw ex;
      }
    }

    private void Initialize()
    {
      if (this._nativeICoreWebView2Controller == null)
        return;
      try
      {
        this.CoreWebView2.AddHostObjectHelper(new CoreWebView2PrivateHostObjectHelper());
      }
      catch (NotImplementedException ex)
      {
        // ISSUE: variable of a compiler-generated type
        ICoreWebView2 coreWebView2 = this._nativeICoreWebView2Controller.CoreWebView2;
        object obj = (object) new HostObjectHelper();
        ref object local = ref obj;
        // ISSUE: reference to a compiler-generated method
        coreWebView2.AddHostObjectToScript("{60A417CA-F1AB-4307-801B-F96003F8938B} Host Object Helper", ref local);
      }
    }

    internal ICoreWebView2Controller _nativeICoreWebView2Controller
    {
      get
      {
        if (this._nativeICoreWebView2ControllerValue == null)
        {
          try
          {
            this._nativeICoreWebView2ControllerValue = (ICoreWebView2Controller) this._rawNative;
          }
          catch (Exception ex)
          {
            throw new NotImplementedException("Unable to cast to Microsoft.Web.WebView2.Core.Raw.ICoreWebView2Controller.\nThis may happen if you are using an interface not supported by the version of the WebView2 Runtime you are using.\nFor instance, if you are using an experimental interface from an older SDK that has been modified or removed in a newer runtime.\nOr, if you are using a public interface from a newer SDK that wasn't implemented in an older runtime.\nFor more information about WebView2 versioning please visit the following: https://learn.microsoft.com/microsoft-edge/webview2/concepts/versioning", ex);
          }
        }
        return this._nativeICoreWebView2ControllerValue;
      }
      set => this._nativeICoreWebView2ControllerValue = value;
    }

    internal ICoreWebView2Controller2 _nativeICoreWebView2Controller2
    {
      get
      {
        if (this._nativeICoreWebView2Controller2Value == null)
        {
          try
          {
            this._nativeICoreWebView2Controller2Value = (ICoreWebView2Controller2) this._rawNative;
          }
          catch (Exception ex)
          {
            throw new NotImplementedException("Unable to cast to Microsoft.Web.WebView2.Core.Raw.ICoreWebView2Controller2.\nThis may happen if you are using an interface not supported by the version of the WebView2 Runtime you are using.\nFor instance, if you are using an experimental interface from an older SDK that has been modified or removed in a newer runtime.\nOr, if you are using a public interface from a newer SDK that wasn't implemented in an older runtime.\nFor more information about WebView2 versioning please visit the following: https://learn.microsoft.com/microsoft-edge/webview2/concepts/versioning", ex);
          }
        }
        return this._nativeICoreWebView2Controller2Value;
      }
      set => this._nativeICoreWebView2Controller2Value = value;
    }

    internal ICoreWebView2Controller3 _nativeICoreWebView2Controller3
    {
      get
      {
        if (this._nativeICoreWebView2Controller3Value == null)
        {
          try
          {
            this._nativeICoreWebView2Controller3Value = (ICoreWebView2Controller3) this._rawNative;
          }
          catch (Exception ex)
          {
            throw new NotImplementedException("Unable to cast to Microsoft.Web.WebView2.Core.Raw.ICoreWebView2Controller3.\nThis may happen if you are using an interface not supported by the version of the WebView2 Runtime you are using.\nFor instance, if you are using an experimental interface from an older SDK that has been modified or removed in a newer runtime.\nOr, if you are using a public interface from a newer SDK that wasn't implemented in an older runtime.\nFor more information about WebView2 versioning please visit the following: https://learn.microsoft.com/microsoft-edge/webview2/concepts/versioning", ex);
          }
        }
        return this._nativeICoreWebView2Controller3Value;
      }
      set => this._nativeICoreWebView2Controller3Value = value;
    }

    internal ICoreWebView2Controller4 _nativeICoreWebView2Controller4
    {
      get
      {
        if (this._nativeICoreWebView2Controller4Value == null)
        {
          try
          {
            this._nativeICoreWebView2Controller4Value = (ICoreWebView2Controller4) this._rawNative;
          }
          catch (Exception ex)
          {
            throw new NotImplementedException("Unable to cast to Microsoft.Web.WebView2.Core.Raw.ICoreWebView2Controller4.\nThis may happen if you are using an interface not supported by the version of the WebView2 Runtime you are using.\nFor instance, if you are using an experimental interface from an older SDK that has been modified or removed in a newer runtime.\nOr, if you are using a public interface from a newer SDK that wasn't implemented in an older runtime.\nFor more information about WebView2 versioning please visit the following: https://learn.microsoft.com/microsoft-edge/webview2/concepts/versioning", ex);
          }
        }
        return this._nativeICoreWebView2Controller4Value;
      }
      set => this._nativeICoreWebView2Controller4Value = value;
    }

    internal ICoreWebView2PrivatePartialController _nativeICoreWebView2PrivatePartialController
    {
      get
      {
        if (this._nativeICoreWebView2PrivatePartialControllerValue == null)
        {
          try
          {
            this._nativeICoreWebView2PrivatePartialControllerValue = (ICoreWebView2PrivatePartialController) this._rawNative;
          }
          catch (Exception ex)
          {
            throw new NotImplementedException("Unable to cast to Microsoft.Web.WebView2.Core.Raw.ICoreWebView2PrivatePartialController.\nThis may happen if you are using an interface not supported by the version of the WebView2 Runtime you are using.\nFor instance, if you are using an experimental interface from an older SDK that has been modified or removed in a newer runtime.\nOr, if you are using a public interface from a newer SDK that wasn't implemented in an older runtime.\nFor more information about WebView2 versioning please visit the following: https://learn.microsoft.com/microsoft-edge/webview2/concepts/versioning", ex);
          }
        }
        return this._nativeICoreWebView2PrivatePartialControllerValue;
      }
      set => this._nativeICoreWebView2PrivatePartialControllerValue = value;
    }

    internal CoreWebView2Controller(object rawCoreWebView2Controller)
    {
      this._rawNative = rawCoreWebView2Controller;
      this.Initialize();
    }

    public bool IsVisible
    {
      get
      {
        try
        {
          return this._nativeICoreWebView2Controller.IsVisible != 0;
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
          this._nativeICoreWebView2Controller.IsVisible = value ? 1 : 0;
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

    public Rectangle Bounds
    {
      get
      {
        try
        {
          return COMDotNetTypeConverter.RectangleCOMToNet(this._nativeICoreWebView2Controller.Bounds);
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
          this._nativeICoreWebView2Controller.Bounds = COMDotNetTypeConverter.RectangleNetToCOM(value);
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

    public double ZoomFactor
    {
      get
      {
        try
        {
          return this._nativeICoreWebView2Controller.ZoomFactor;
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
          this._nativeICoreWebView2Controller.ZoomFactor = value;
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

    public IntPtr ParentWindow
    {
      get
      {
        try
        {
          return this._nativeICoreWebView2Controller.ParentWindow;
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
          this._nativeICoreWebView2Controller.ParentWindow = value;
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

    public event EventHandler<object> ZoomFactorChanged
    {
      add
      {
        if (this.zoomFactorChanged == null)
        {
          try
          {
            this._nativeICoreWebView2Controller.add_ZoomFactorChanged((ICoreWebView2ZoomFactorChangedEventHandler) new CoreWebView2ZoomFactorChangedEventHandler(new CoreWebView2ZoomFactorChangedEventHandler.CallbackType(this.OnZoomFactorChanged)), out this._zoomFactorChangedToken);
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
        this.zoomFactorChanged += value;
      }
      remove
      {
        this.zoomFactorChanged -= value;
        if (this.zoomFactorChanged != null)
          return;
        try
        {
          this._nativeICoreWebView2Controller.remove_ZoomFactorChanged(this._zoomFactorChangedToken);
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

    internal void OnZoomFactorChanged(object args)
    {
      EventHandler<object> zoomFactorChanged = this.zoomFactorChanged;
      if (zoomFactorChanged == null)
        return;
      zoomFactorChanged((object) this, args);
    }

    public event EventHandler<CoreWebView2MoveFocusRequestedEventArgs> MoveFocusRequested
    {
      add
      {
        if (this.moveFocusRequested == null)
        {
          try
          {
            this._nativeICoreWebView2Controller.add_MoveFocusRequested((ICoreWebView2MoveFocusRequestedEventHandler) new CoreWebView2MoveFocusRequestedEventHandler(new CoreWebView2MoveFocusRequestedEventHandler.CallbackType(this.OnMoveFocusRequested)), out this._moveFocusRequestedToken);
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
        this.moveFocusRequested += value;
      }
      remove
      {
        this.moveFocusRequested -= value;
        if (this.moveFocusRequested != null)
          return;
        try
        {
          this._nativeICoreWebView2Controller.remove_MoveFocusRequested(this._moveFocusRequestedToken);
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

    internal void OnMoveFocusRequested(CoreWebView2MoveFocusRequestedEventArgs args)
    {
      EventHandler<CoreWebView2MoveFocusRequestedEventArgs> moveFocusRequested = this.moveFocusRequested;
      if (moveFocusRequested == null)
        return;
      moveFocusRequested((object) this, args);
    }

    public event EventHandler<object> GotFocus
    {
      add
      {
        if (this.gotFocus == null)
        {
          try
          {
            this._nativeICoreWebView2Controller.add_GotFocus((ICoreWebView2FocusChangedEventHandler) new CoreWebView2FocusChangedEventHandler(new CoreWebView2FocusChangedEventHandler.CallbackType(this.OnGotFocus)), out this._gotFocusToken);
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
        this.gotFocus += value;
      }
      remove
      {
        this.gotFocus -= value;
        if (this.gotFocus != null)
          return;
        try
        {
          this._nativeICoreWebView2Controller.remove_GotFocus(this._gotFocusToken);
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

    internal void OnGotFocus(object args)
    {
      EventHandler<object> gotFocus = this.gotFocus;
      if (gotFocus == null)
        return;
      gotFocus((object) this, args);
    }

    public event EventHandler<object> LostFocus
    {
      add
      {
        if (this.lostFocus == null)
        {
          try
          {
            this._nativeICoreWebView2Controller.add_LostFocus((ICoreWebView2FocusChangedEventHandler) new CoreWebView2FocusChangedEventHandler(new CoreWebView2FocusChangedEventHandler.CallbackType(this.OnLostFocus)), out this._lostFocusToken);
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
        this.lostFocus += value;
      }
      remove
      {
        this.lostFocus -= value;
        if (this.lostFocus != null)
          return;
        try
        {
          this._nativeICoreWebView2Controller.remove_LostFocus(this._lostFocusToken);
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

    internal void OnLostFocus(object args)
    {
      EventHandler<object> lostFocus = this.lostFocus;
      if (lostFocus == null)
        return;
      lostFocus((object) this, args);
    }

    public event EventHandler<CoreWebView2AcceleratorKeyPressedEventArgs> AcceleratorKeyPressed
    {
      add
      {
        if (this.acceleratorKeyPressed == null)
        {
          try
          {
            this._nativeICoreWebView2Controller.add_AcceleratorKeyPressed((ICoreWebView2AcceleratorKeyPressedEventHandler) new CoreWebView2AcceleratorKeyPressedEventHandler(new CoreWebView2AcceleratorKeyPressedEventHandler.CallbackType(this.OnAcceleratorKeyPressed)), out this._acceleratorKeyPressedToken);
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
        this.acceleratorKeyPressed += value;
      }
      remove
      {
        this.acceleratorKeyPressed -= value;
        if (this.acceleratorKeyPressed != null)
          return;
        try
        {
          this._nativeICoreWebView2Controller.remove_AcceleratorKeyPressed(this._acceleratorKeyPressedToken);
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

    internal void OnAcceleratorKeyPressed(CoreWebView2AcceleratorKeyPressedEventArgs args)
    {
      EventHandler<CoreWebView2AcceleratorKeyPressedEventArgs> acceleratorKeyPressed = this.acceleratorKeyPressed;
      if (acceleratorKeyPressed == null)
        return;
      acceleratorKeyPressed((object) this, args);
    }

    public void SetBoundsAndZoomFactor(Rectangle Bounds, double ZoomFactor)
    {
      try
      {
        // ISSUE: reference to a compiler-generated method
        this._nativeICoreWebView2Controller.SetBoundsAndZoomFactor(COMDotNetTypeConverter.RectangleNetToCOM(Bounds), ZoomFactor);
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

    public void NotifyParentWindowPositionChanged()
    {
      try
      {
        // ISSUE: reference to a compiler-generated method
        this._nativeICoreWebView2Controller.NotifyParentWindowPositionChanged();
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

    public void Close()
    {
      try
      {
        // ISSUE: reference to a compiler-generated method
        this._nativeICoreWebView2Controller.Close();
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

    public Color DefaultBackgroundColor
    {
      get
      {
        try
        {
          return COMDotNetTypeConverter.ColorCOMToNet(this._nativeICoreWebView2Controller2.DefaultBackgroundColor);
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
          this._nativeICoreWebView2Controller2.DefaultBackgroundColor = COMDotNetTypeConverter.ColorNetToCOM(value);
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

    public double RasterizationScale
    {
      get
      {
        try
        {
          return this._nativeICoreWebView2Controller3.RasterizationScale;
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
          this._nativeICoreWebView2Controller3.RasterizationScale = value;
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

    public bool ShouldDetectMonitorScaleChanges
    {
      get
      {
        try
        {
          return this._nativeICoreWebView2Controller3.ShouldDetectMonitorScaleChanges != 0;
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
          this._nativeICoreWebView2Controller3.ShouldDetectMonitorScaleChanges = value ? 1 : 0;
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

    public CoreWebView2BoundsMode BoundsMode
    {
      get
      {
        try
        {
          return (CoreWebView2BoundsMode) this._nativeICoreWebView2Controller3.BoundsMode;
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
          this._nativeICoreWebView2Controller3.BoundsMode = (COREWEBVIEW2_BOUNDS_MODE) value;
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

    public event EventHandler<object> RasterizationScaleChanged
    {
      add
      {
        if (this.rasterizationScaleChanged == null)
        {
          try
          {
            this._nativeICoreWebView2Controller3.add_RasterizationScaleChanged((ICoreWebView2RasterizationScaleChangedEventHandler) new CoreWebView2RasterizationScaleChangedEventHandler(new CoreWebView2RasterizationScaleChangedEventHandler.CallbackType(this.OnRasterizationScaleChanged)), out this._rasterizationScaleChangedToken);
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
        this.rasterizationScaleChanged += value;
      }
      remove
      {
        this.rasterizationScaleChanged -= value;
        if (this.rasterizationScaleChanged != null)
          return;
        try
        {
          this._nativeICoreWebView2Controller3.remove_RasterizationScaleChanged(this._rasterizationScaleChangedToken);
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

    internal void OnRasterizationScaleChanged(object args)
    {
      EventHandler<object> rasterizationScaleChanged = this.rasterizationScaleChanged;
      if (rasterizationScaleChanged == null)
        return;
      rasterizationScaleChanged((object) this, args);
    }

    public bool AllowExternalDrop
    {
      get
      {
        try
        {
          return this._nativeICoreWebView2Controller4.AllowExternalDrop != 0;
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
          this._nativeICoreWebView2Controller4.AllowExternalDrop = value ? 1 : 0;
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

    internal bool IsBrowserHitTransparent
    {
      get
      {
        try
        {
          return this._nativeICoreWebView2PrivatePartialController.IsBrowserHitTransparent != 0;
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

    internal event EventHandler<CoreWebView2PrivateKeyPressedEventArgs> KeyPressed
    {
      add
      {
        if (this.keyPressed == null)
        {
          try
          {
            this._nativeICoreWebView2PrivatePartialController.add_KeyPressed((ICoreWebView2PrivateKeyPressedEventHandler) new CoreWebView2PrivateKeyPressedEventHandler(new CoreWebView2PrivateKeyPressedEventHandler.CallbackType(this.OnKeyPressed)), out this._keyPressedToken);
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
        this.keyPressed += value;
      }
      remove
      {
        this.keyPressed -= value;
        if (this.keyPressed != null)
          return;
        try
        {
          this._nativeICoreWebView2PrivatePartialController.remove_KeyPressed(this._keyPressedToken);
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

    internal void OnKeyPressed(CoreWebView2PrivateKeyPressedEventArgs args)
    {
      EventHandler<CoreWebView2PrivateKeyPressedEventArgs> keyPressed = this.keyPressed;
      if (keyPressed == null)
        return;
      keyPressed((object) this, args);
    }
  }
}
