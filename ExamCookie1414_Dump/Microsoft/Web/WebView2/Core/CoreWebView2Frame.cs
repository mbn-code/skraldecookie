// Decompiled with JetBrains decompiler
// Type: Microsoft.Web.WebView2.Core.CoreWebView2Frame
// Assembly: ExamCookie.WinClient, Version=1.4.1.4, Culture=neutral, PublicKeyToken=null
// MVID: E12BE1F8-B6E0-4BF5-B308-166F0E938C4B
// Assembly location: C:\Users\oskar\Downloads\ExamCookie1414.WinClient.exe

using Microsoft.Web.WebView2.Core.Raw;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

#nullable disable
namespace Microsoft.Web.WebView2.Core
{
  [ComVisible(true)]
  public class CoreWebView2Frame
  {
    internal ICoreWebView2Frame _nativeICoreWebView2FrameValue;
    internal ICoreWebView2Frame2 _nativeICoreWebView2Frame2Value;
    internal ICoreWebView2Frame3 _nativeICoreWebView2Frame3Value;
    internal ICoreWebView2Frame4 _nativeICoreWebView2Frame4Value;
    internal object _rawNative;
    private EventRegistrationToken _nameChangedToken;
    private EventHandler<object> nameChanged;
    private EventRegistrationToken _destroyedToken;
    private EventHandler<object> destroyed;
    private EventRegistrationToken _navigationStartingToken;
    private EventHandler<CoreWebView2NavigationStartingEventArgs> navigationStarting;
    private EventRegistrationToken _contentLoadingToken;
    private EventHandler<CoreWebView2ContentLoadingEventArgs> contentLoading;
    private EventRegistrationToken _navigationCompletedToken;
    private EventHandler<CoreWebView2NavigationCompletedEventArgs> navigationCompleted;
    private EventRegistrationToken _dOMContentLoadedToken;
    private EventHandler<CoreWebView2DOMContentLoadedEventArgs> dOMContentLoaded;
    private EventRegistrationToken _webMessageReceivedToken;
    private EventHandler<CoreWebView2WebMessageReceivedEventArgs> webMessageReceived;
    private EventRegistrationToken _permissionRequestedToken;
    private EventHandler<CoreWebView2PermissionRequestedEventArgs> permissionRequested;

    public void AddHostObjectToScript(string name, object rawObject, IEnumerable<string> origins)
    {
      // ISSUE: variable of a compiler-generated type
      ICoreWebView2Frame icoreWebView2Frame = this._nativeICoreWebView2Frame;
      string name1 = name;
      object obj = rawObject;
      ref object local = ref obj;
      int originsCount = origins.Count<string>();
      string[] array = origins.Select<string, string>((Func<string, string>) (origin => origin)).ToArray<string>();
      // ISSUE: reference to a compiler-generated method
      icoreWebView2Frame.AddHostObjectToScriptWithOrigins(name1, ref local, (uint) originsCount, array);
    }

    internal ICoreWebView2Frame _nativeICoreWebView2Frame
    {
      get
      {
        if (this._nativeICoreWebView2FrameValue == null)
        {
          try
          {
            this._nativeICoreWebView2FrameValue = (ICoreWebView2Frame) this._rawNative;
          }
          catch (Exception ex)
          {
            throw new NotImplementedException("Unable to cast to Microsoft.Web.WebView2.Core.Raw.ICoreWebView2Frame.\nThis may happen if you are using an interface not supported by the version of the WebView2 Runtime you are using.\nFor instance, if you are using an experimental interface from an older SDK that has been modified or removed in a newer runtime.\nOr, if you are using a public interface from a newer SDK that wasn't implemented in an older runtime.\nFor more information about WebView2 versioning please visit the following: https://learn.microsoft.com/microsoft-edge/webview2/concepts/versioning", ex);
          }
        }
        return this._nativeICoreWebView2FrameValue;
      }
      set => this._nativeICoreWebView2FrameValue = value;
    }

    internal ICoreWebView2Frame2 _nativeICoreWebView2Frame2
    {
      get
      {
        if (this._nativeICoreWebView2Frame2Value == null)
        {
          try
          {
            this._nativeICoreWebView2Frame2Value = (ICoreWebView2Frame2) this._rawNative;
          }
          catch (Exception ex)
          {
            throw new NotImplementedException("Unable to cast to Microsoft.Web.WebView2.Core.Raw.ICoreWebView2Frame2.\nThis may happen if you are using an interface not supported by the version of the WebView2 Runtime you are using.\nFor instance, if you are using an experimental interface from an older SDK that has been modified or removed in a newer runtime.\nOr, if you are using a public interface from a newer SDK that wasn't implemented in an older runtime.\nFor more information about WebView2 versioning please visit the following: https://learn.microsoft.com/microsoft-edge/webview2/concepts/versioning", ex);
          }
        }
        return this._nativeICoreWebView2Frame2Value;
      }
      set => this._nativeICoreWebView2Frame2Value = value;
    }

    internal ICoreWebView2Frame3 _nativeICoreWebView2Frame3
    {
      get
      {
        if (this._nativeICoreWebView2Frame3Value == null)
        {
          try
          {
            this._nativeICoreWebView2Frame3Value = (ICoreWebView2Frame3) this._rawNative;
          }
          catch (Exception ex)
          {
            throw new NotImplementedException("Unable to cast to Microsoft.Web.WebView2.Core.Raw.ICoreWebView2Frame3.\nThis may happen if you are using an interface not supported by the version of the WebView2 Runtime you are using.\nFor instance, if you are using an experimental interface from an older SDK that has been modified or removed in a newer runtime.\nOr, if you are using a public interface from a newer SDK that wasn't implemented in an older runtime.\nFor more information about WebView2 versioning please visit the following: https://learn.microsoft.com/microsoft-edge/webview2/concepts/versioning", ex);
          }
        }
        return this._nativeICoreWebView2Frame3Value;
      }
      set => this._nativeICoreWebView2Frame3Value = value;
    }

    internal ICoreWebView2Frame4 _nativeICoreWebView2Frame4
    {
      get
      {
        if (this._nativeICoreWebView2Frame4Value == null)
        {
          try
          {
            this._nativeICoreWebView2Frame4Value = (ICoreWebView2Frame4) this._rawNative;
          }
          catch (Exception ex)
          {
            throw new NotImplementedException("Unable to cast to Microsoft.Web.WebView2.Core.Raw.ICoreWebView2Frame4.\nThis may happen if you are using an interface not supported by the version of the WebView2 Runtime you are using.\nFor instance, if you are using an experimental interface from an older SDK that has been modified or removed in a newer runtime.\nOr, if you are using a public interface from a newer SDK that wasn't implemented in an older runtime.\nFor more information about WebView2 versioning please visit the following: https://learn.microsoft.com/microsoft-edge/webview2/concepts/versioning", ex);
          }
        }
        return this._nativeICoreWebView2Frame4Value;
      }
      set => this._nativeICoreWebView2Frame4Value = value;
    }

    internal CoreWebView2Frame(object rawCoreWebView2Frame)
    {
      this._rawNative = rawCoreWebView2Frame;
    }

    public string Name
    {
      get
      {
        try
        {
          return this._nativeICoreWebView2Frame.Name;
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

    public event EventHandler<object> NameChanged
    {
      add
      {
        if (this.nameChanged == null)
        {
          try
          {
            this._nativeICoreWebView2Frame.add_NameChanged((ICoreWebView2FrameNameChangedEventHandler) new CoreWebView2FrameNameChangedEventHandler(new CoreWebView2FrameNameChangedEventHandler.CallbackType(this.OnNameChanged)), out this._nameChangedToken);
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
        this.nameChanged += value;
      }
      remove
      {
        this.nameChanged -= value;
        if (this.nameChanged != null)
          return;
        try
        {
          this._nativeICoreWebView2Frame.remove_NameChanged(this._nameChangedToken);
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

    internal void OnNameChanged(object args)
    {
      EventHandler<object> nameChanged = this.nameChanged;
      if (nameChanged == null)
        return;
      nameChanged((object) this, args);
    }

    public event EventHandler<object> Destroyed
    {
      add
      {
        if (this.destroyed == null)
        {
          try
          {
            this._nativeICoreWebView2Frame.add_Destroyed((ICoreWebView2FrameDestroyedEventHandler) new CoreWebView2FrameDestroyedEventHandler(new CoreWebView2FrameDestroyedEventHandler.CallbackType(this.OnDestroyed)), out this._destroyedToken);
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
        this.destroyed += value;
      }
      remove
      {
        this.destroyed -= value;
        if (this.destroyed != null)
          return;
        try
        {
          this._nativeICoreWebView2Frame.remove_Destroyed(this._destroyedToken);
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

    internal void OnDestroyed(object args)
    {
      EventHandler<object> destroyed = this.destroyed;
      if (destroyed == null)
        return;
      destroyed((object) this, args);
    }

    public void RemoveHostObjectFromScript(string name)
    {
      try
      {
        // ISSUE: reference to a compiler-generated method
        this._nativeICoreWebView2Frame.RemoveHostObjectFromScript(name);
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

    public int IsDestroyed()
    {
      try
      {
        // ISSUE: reference to a compiler-generated method
        return this._nativeICoreWebView2Frame.IsDestroyed();
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

    public event EventHandler<CoreWebView2NavigationStartingEventArgs> NavigationStarting
    {
      add
      {
        if (this.navigationStarting == null)
        {
          try
          {
            this._nativeICoreWebView2Frame2.add_NavigationStarting((ICoreWebView2FrameNavigationStartingEventHandler) new CoreWebView2FrameNavigationStartingEventHandler(new CoreWebView2FrameNavigationStartingEventHandler.CallbackType(this.OnNavigationStarting)), out this._navigationStartingToken);
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
        this.navigationStarting += value;
      }
      remove
      {
        this.navigationStarting -= value;
        if (this.navigationStarting != null)
          return;
        try
        {
          this._nativeICoreWebView2Frame2.remove_NavigationStarting(this._navigationStartingToken);
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

    internal void OnNavigationStarting(CoreWebView2NavigationStartingEventArgs args)
    {
      EventHandler<CoreWebView2NavigationStartingEventArgs> navigationStarting = this.navigationStarting;
      if (navigationStarting == null)
        return;
      navigationStarting((object) this, args);
    }

    public event EventHandler<CoreWebView2ContentLoadingEventArgs> ContentLoading
    {
      add
      {
        if (this.contentLoading == null)
        {
          try
          {
            this._nativeICoreWebView2Frame2.add_ContentLoading((ICoreWebView2FrameContentLoadingEventHandler) new CoreWebView2FrameContentLoadingEventHandler(new CoreWebView2FrameContentLoadingEventHandler.CallbackType(this.OnContentLoading)), out this._contentLoadingToken);
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
        this.contentLoading += value;
      }
      remove
      {
        this.contentLoading -= value;
        if (this.contentLoading != null)
          return;
        try
        {
          this._nativeICoreWebView2Frame2.remove_ContentLoading(this._contentLoadingToken);
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

    internal void OnContentLoading(CoreWebView2ContentLoadingEventArgs args)
    {
      EventHandler<CoreWebView2ContentLoadingEventArgs> contentLoading = this.contentLoading;
      if (contentLoading == null)
        return;
      contentLoading((object) this, args);
    }

    public event EventHandler<CoreWebView2NavigationCompletedEventArgs> NavigationCompleted
    {
      add
      {
        if (this.navigationCompleted == null)
        {
          try
          {
            this._nativeICoreWebView2Frame2.add_NavigationCompleted((ICoreWebView2FrameNavigationCompletedEventHandler) new CoreWebView2FrameNavigationCompletedEventHandler(new CoreWebView2FrameNavigationCompletedEventHandler.CallbackType(this.OnNavigationCompleted)), out this._navigationCompletedToken);
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
        this.navigationCompleted += value;
      }
      remove
      {
        this.navigationCompleted -= value;
        if (this.navigationCompleted != null)
          return;
        try
        {
          this._nativeICoreWebView2Frame2.remove_NavigationCompleted(this._navigationCompletedToken);
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

    internal void OnNavigationCompleted(CoreWebView2NavigationCompletedEventArgs args)
    {
      EventHandler<CoreWebView2NavigationCompletedEventArgs> navigationCompleted = this.navigationCompleted;
      if (navigationCompleted == null)
        return;
      navigationCompleted((object) this, args);
    }

    public event EventHandler<CoreWebView2DOMContentLoadedEventArgs> DOMContentLoaded
    {
      add
      {
        if (this.dOMContentLoaded == null)
        {
          try
          {
            this._nativeICoreWebView2Frame2.add_DOMContentLoaded((ICoreWebView2FrameDOMContentLoadedEventHandler) new CoreWebView2FrameDOMContentLoadedEventHandler(new CoreWebView2FrameDOMContentLoadedEventHandler.CallbackType(this.OnDOMContentLoaded)), out this._dOMContentLoadedToken);
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
        this.dOMContentLoaded += value;
      }
      remove
      {
        this.dOMContentLoaded -= value;
        if (this.dOMContentLoaded != null)
          return;
        try
        {
          this._nativeICoreWebView2Frame2.remove_DOMContentLoaded(this._dOMContentLoadedToken);
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

    internal void OnDOMContentLoaded(CoreWebView2DOMContentLoadedEventArgs args)
    {
      EventHandler<CoreWebView2DOMContentLoadedEventArgs> dOmContentLoaded = this.dOMContentLoaded;
      if (dOmContentLoaded == null)
        return;
      dOmContentLoaded((object) this, args);
    }

    public event EventHandler<CoreWebView2WebMessageReceivedEventArgs> WebMessageReceived
    {
      add
      {
        if (this.webMessageReceived == null)
        {
          try
          {
            this._nativeICoreWebView2Frame2.add_WebMessageReceived((ICoreWebView2FrameWebMessageReceivedEventHandler) new CoreWebView2FrameWebMessageReceivedEventHandler(new CoreWebView2FrameWebMessageReceivedEventHandler.CallbackType(this.OnWebMessageReceived)), out this._webMessageReceivedToken);
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
        this.webMessageReceived += value;
      }
      remove
      {
        this.webMessageReceived -= value;
        if (this.webMessageReceived != null)
          return;
        try
        {
          this._nativeICoreWebView2Frame2.remove_WebMessageReceived(this._webMessageReceivedToken);
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

    internal void OnWebMessageReceived(CoreWebView2WebMessageReceivedEventArgs args)
    {
      EventHandler<CoreWebView2WebMessageReceivedEventArgs> webMessageReceived = this.webMessageReceived;
      if (webMessageReceived == null)
        return;
      webMessageReceived((object) this, args);
    }

    public async Task<string> ExecuteScriptAsync(string javaScript)
    {
      CoreWebView2ExecuteScriptCompletedHandler handler;
      try
      {
        handler = new CoreWebView2ExecuteScriptCompletedHandler();
        // ISSUE: reference to a compiler-generated method
        this._nativeICoreWebView2Frame2.ExecuteScript(javaScript, (ICoreWebView2ExecuteScriptCompletedHandler) handler);
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
      string str = await handler;
      Marshal.ThrowExceptionForHR(handler.errCode);
      string resultObjectAsJson = handler.resultObjectAsJson;
      handler = (CoreWebView2ExecuteScriptCompletedHandler) null;
      return resultObjectAsJson;
    }

    public void PostWebMessageAsJson(string webMessageAsJson)
    {
      try
      {
        // ISSUE: reference to a compiler-generated method
        this._nativeICoreWebView2Frame2.PostWebMessageAsJson(webMessageAsJson);
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

    public void PostWebMessageAsString(string webMessageAsString)
    {
      try
      {
        // ISSUE: reference to a compiler-generated method
        this._nativeICoreWebView2Frame2.PostWebMessageAsString(webMessageAsString);
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

    public event EventHandler<CoreWebView2PermissionRequestedEventArgs> PermissionRequested
    {
      add
      {
        if (this.permissionRequested == null)
        {
          try
          {
            this._nativeICoreWebView2Frame3.add_PermissionRequested((ICoreWebView2FramePermissionRequestedEventHandler) new CoreWebView2FramePermissionRequestedEventHandler(new CoreWebView2FramePermissionRequestedEventHandler.CallbackType(this.OnPermissionRequested)), out this._permissionRequestedToken);
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
        this.permissionRequested += value;
      }
      remove
      {
        this.permissionRequested -= value;
        if (this.permissionRequested != null)
          return;
        try
        {
          this._nativeICoreWebView2Frame3.remove_PermissionRequested(this._permissionRequestedToken);
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

    internal void OnPermissionRequested(CoreWebView2PermissionRequestedEventArgs args)
    {
      EventHandler<CoreWebView2PermissionRequestedEventArgs> permissionRequested = this.permissionRequested;
      if (permissionRequested == null)
        return;
      permissionRequested((object) this, args);
    }

    public void PostSharedBufferToScript(
      CoreWebView2SharedBuffer sharedBuffer,
      CoreWebView2SharedBufferAccess access,
      string additionalDataAsJson)
    {
      try
      {
        // ISSUE: reference to a compiler-generated method
        this._nativeICoreWebView2Frame4.PostSharedBufferToScript(sharedBuffer._nativeICoreWebView2SharedBuffer, (COREWEBVIEW2_SHARED_BUFFER_ACCESS) access, additionalDataAsJson);
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
