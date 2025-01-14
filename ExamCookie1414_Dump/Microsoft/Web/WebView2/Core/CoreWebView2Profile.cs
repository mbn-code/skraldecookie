// Decompiled with JetBrains decompiler
// Type: Microsoft.Web.WebView2.Core.CoreWebView2Profile
// Assembly: ExamCookie.WinClient, Version=1.4.1.4, Culture=neutral, PublicKeyToken=null
// MVID: E12BE1F8-B6E0-4BF5-B308-166F0E938C4B
// Assembly location: C:\Users\oskar\Downloads\ExamCookie1414.WinClient.exe

using Microsoft.Web.WebView2.Core.Raw;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

#nullable disable
namespace Microsoft.Web.WebView2.Core
{
  [ComVisible(true)]
  public class CoreWebView2Profile
  {
    internal ICoreWebView2Profile _nativeICoreWebView2ProfileValue;
    internal ICoreWebView2Profile2 _nativeICoreWebView2Profile2Value;
    internal ICoreWebView2Profile3 _nativeICoreWebView2Profile3Value;
    internal ICoreWebView2Profile4 _nativeICoreWebView2Profile4Value;
    internal ICoreWebView2Profile5 _nativeICoreWebView2Profile5Value;
    internal ICoreWebView2Profile6 _nativeICoreWebView2Profile6Value;
    internal object _rawNative;

    public async Task ClearBrowsingDataAsync(
      CoreWebView2BrowsingDataKinds dataKinds,
      DateTime startTime,
      DateTime endTime)
    {
      CoreWebView2ClearBrowsingDataCompletedHandler handler;
      try
      {
        double unixTimeSeconds1 = (double) new DateTimeOffset(startTime).ToUnixTimeSeconds();
        double unixTimeSeconds2 = (double) new DateTimeOffset(endTime).ToUnixTimeSeconds();
        handler = new CoreWebView2ClearBrowsingDataCompletedHandler();
        // ISSUE: reference to a compiler-generated method
        this._nativeICoreWebView2Profile2.ClearBrowsingDataInTimeRange((COREWEBVIEW2_BROWSING_DATA_KINDS) dataKinds, unixTimeSeconds1, unixTimeSeconds2, (ICoreWebView2ClearBrowsingDataCompletedHandler) handler);
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
      await handler;
      Marshal.ThrowExceptionForHR(handler.errCode);
      handler = (CoreWebView2ClearBrowsingDataCompletedHandler) null;
    }

    public async Task ClearBrowsingDataAsync()
    {
      CoreWebView2ClearBrowsingDataCompletedHandler handler;
      try
      {
        handler = new CoreWebView2ClearBrowsingDataCompletedHandler();
        // ISSUE: reference to a compiler-generated method
        this._nativeICoreWebView2Profile2.ClearBrowsingDataAll((ICoreWebView2ClearBrowsingDataCompletedHandler) handler);
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
      await handler;
      Marshal.ThrowExceptionForHR(handler.errCode);
      handler = (CoreWebView2ClearBrowsingDataCompletedHandler) null;
    }

    internal ICoreWebView2Profile _nativeICoreWebView2Profile
    {
      get
      {
        if (this._nativeICoreWebView2ProfileValue == null)
        {
          try
          {
            this._nativeICoreWebView2ProfileValue = (ICoreWebView2Profile) this._rawNative;
          }
          catch (Exception ex)
          {
            throw new NotImplementedException("Unable to cast to Microsoft.Web.WebView2.Core.Raw.ICoreWebView2Profile.\nThis may happen if you are using an interface not supported by the version of the WebView2 Runtime you are using.\nFor instance, if you are using an experimental interface from an older SDK that has been modified or removed in a newer runtime.\nOr, if you are using a public interface from a newer SDK that wasn't implemented in an older runtime.\nFor more information about WebView2 versioning please visit the following: https://learn.microsoft.com/microsoft-edge/webview2/concepts/versioning", ex);
          }
        }
        return this._nativeICoreWebView2ProfileValue;
      }
      set => this._nativeICoreWebView2ProfileValue = value;
    }

    internal ICoreWebView2Profile2 _nativeICoreWebView2Profile2
    {
      get
      {
        if (this._nativeICoreWebView2Profile2Value == null)
        {
          try
          {
            this._nativeICoreWebView2Profile2Value = (ICoreWebView2Profile2) this._rawNative;
          }
          catch (Exception ex)
          {
            throw new NotImplementedException("Unable to cast to Microsoft.Web.WebView2.Core.Raw.ICoreWebView2Profile2.\nThis may happen if you are using an interface not supported by the version of the WebView2 Runtime you are using.\nFor instance, if you are using an experimental interface from an older SDK that has been modified or removed in a newer runtime.\nOr, if you are using a public interface from a newer SDK that wasn't implemented in an older runtime.\nFor more information about WebView2 versioning please visit the following: https://learn.microsoft.com/microsoft-edge/webview2/concepts/versioning", ex);
          }
        }
        return this._nativeICoreWebView2Profile2Value;
      }
      set => this._nativeICoreWebView2Profile2Value = value;
    }

    internal ICoreWebView2Profile3 _nativeICoreWebView2Profile3
    {
      get
      {
        if (this._nativeICoreWebView2Profile3Value == null)
        {
          try
          {
            this._nativeICoreWebView2Profile3Value = (ICoreWebView2Profile3) this._rawNative;
          }
          catch (Exception ex)
          {
            throw new NotImplementedException("Unable to cast to Microsoft.Web.WebView2.Core.Raw.ICoreWebView2Profile3.\nThis may happen if you are using an interface not supported by the version of the WebView2 Runtime you are using.\nFor instance, if you are using an experimental interface from an older SDK that has been modified or removed in a newer runtime.\nOr, if you are using a public interface from a newer SDK that wasn't implemented in an older runtime.\nFor more information about WebView2 versioning please visit the following: https://learn.microsoft.com/microsoft-edge/webview2/concepts/versioning", ex);
          }
        }
        return this._nativeICoreWebView2Profile3Value;
      }
      set => this._nativeICoreWebView2Profile3Value = value;
    }

    internal ICoreWebView2Profile4 _nativeICoreWebView2Profile4
    {
      get
      {
        if (this._nativeICoreWebView2Profile4Value == null)
        {
          try
          {
            this._nativeICoreWebView2Profile4Value = (ICoreWebView2Profile4) this._rawNative;
          }
          catch (Exception ex)
          {
            throw new NotImplementedException("Unable to cast to Microsoft.Web.WebView2.Core.Raw.ICoreWebView2Profile4.\nThis may happen if you are using an interface not supported by the version of the WebView2 Runtime you are using.\nFor instance, if you are using an experimental interface from an older SDK that has been modified or removed in a newer runtime.\nOr, if you are using a public interface from a newer SDK that wasn't implemented in an older runtime.\nFor more information about WebView2 versioning please visit the following: https://learn.microsoft.com/microsoft-edge/webview2/concepts/versioning", ex);
          }
        }
        return this._nativeICoreWebView2Profile4Value;
      }
      set => this._nativeICoreWebView2Profile4Value = value;
    }

    internal ICoreWebView2Profile5 _nativeICoreWebView2Profile5
    {
      get
      {
        if (this._nativeICoreWebView2Profile5Value == null)
        {
          try
          {
            this._nativeICoreWebView2Profile5Value = (ICoreWebView2Profile5) this._rawNative;
          }
          catch (Exception ex)
          {
            throw new NotImplementedException("Unable to cast to Microsoft.Web.WebView2.Core.Raw.ICoreWebView2Profile5.\nThis may happen if you are using an interface not supported by the version of the WebView2 Runtime you are using.\nFor instance, if you are using an experimental interface from an older SDK that has been modified or removed in a newer runtime.\nOr, if you are using a public interface from a newer SDK that wasn't implemented in an older runtime.\nFor more information about WebView2 versioning please visit the following: https://learn.microsoft.com/microsoft-edge/webview2/concepts/versioning", ex);
          }
        }
        return this._nativeICoreWebView2Profile5Value;
      }
      set => this._nativeICoreWebView2Profile5Value = value;
    }

    internal ICoreWebView2Profile6 _nativeICoreWebView2Profile6
    {
      get
      {
        if (this._nativeICoreWebView2Profile6Value == null)
        {
          try
          {
            this._nativeICoreWebView2Profile6Value = (ICoreWebView2Profile6) this._rawNative;
          }
          catch (Exception ex)
          {
            throw new NotImplementedException("Unable to cast to Microsoft.Web.WebView2.Core.Raw.ICoreWebView2Profile6.\nThis may happen if you are using an interface not supported by the version of the WebView2 Runtime you are using.\nFor instance, if you are using an experimental interface from an older SDK that has been modified or removed in a newer runtime.\nOr, if you are using a public interface from a newer SDK that wasn't implemented in an older runtime.\nFor more information about WebView2 versioning please visit the following: https://learn.microsoft.com/microsoft-edge/webview2/concepts/versioning", ex);
          }
        }
        return this._nativeICoreWebView2Profile6Value;
      }
      set => this._nativeICoreWebView2Profile6Value = value;
    }

    internal CoreWebView2Profile(object rawCoreWebView2Profile)
    {
      this._rawNative = rawCoreWebView2Profile;
    }

    public string ProfileName
    {
      get
      {
        try
        {
          return this._nativeICoreWebView2Profile.ProfileName;
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

    public bool IsInPrivateModeEnabled
    {
      get
      {
        try
        {
          return this._nativeICoreWebView2Profile.IsInPrivateModeEnabled != 0;
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

    public string ProfilePath
    {
      get
      {
        try
        {
          return this._nativeICoreWebView2Profile.ProfilePath;
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

    public string DefaultDownloadFolderPath
    {
      get
      {
        try
        {
          return this._nativeICoreWebView2Profile.DefaultDownloadFolderPath;
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
          this._nativeICoreWebView2Profile.DefaultDownloadFolderPath = value;
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

    public CoreWebView2PreferredColorScheme PreferredColorScheme
    {
      get
      {
        try
        {
          return (CoreWebView2PreferredColorScheme) this._nativeICoreWebView2Profile.PreferredColorScheme;
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
          this._nativeICoreWebView2Profile.PreferredColorScheme = (COREWEBVIEW2_PREFERRED_COLOR_SCHEME) value;
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

    public async Task ClearBrowsingDataAsync(CoreWebView2BrowsingDataKinds dataKinds)
    {
      CoreWebView2ClearBrowsingDataCompletedHandler handler;
      try
      {
        handler = new CoreWebView2ClearBrowsingDataCompletedHandler();
        // ISSUE: reference to a compiler-generated method
        this._nativeICoreWebView2Profile2.ClearBrowsingData((COREWEBVIEW2_BROWSING_DATA_KINDS) dataKinds, (ICoreWebView2ClearBrowsingDataCompletedHandler) handler);
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
      await handler;
      Marshal.ThrowExceptionForHR(handler.errCode);
      handler = (CoreWebView2ClearBrowsingDataCompletedHandler) null;
    }

    public CoreWebView2TrackingPreventionLevel PreferredTrackingPreventionLevel
    {
      get
      {
        try
        {
          return (CoreWebView2TrackingPreventionLevel) this._nativeICoreWebView2Profile3.PreferredTrackingPreventionLevel;
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
          this._nativeICoreWebView2Profile3.PreferredTrackingPreventionLevel = (COREWEBVIEW2_TRACKING_PREVENTION_LEVEL) value;
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

    public async Task SetPermissionStateAsync(
      CoreWebView2PermissionKind PermissionKind,
      string origin,
      CoreWebView2PermissionState State)
    {
      CoreWebView2SetPermissionStateCompletedHandler handler;
      try
      {
        handler = new CoreWebView2SetPermissionStateCompletedHandler();
        // ISSUE: reference to a compiler-generated method
        this._nativeICoreWebView2Profile4.SetPermissionState((COREWEBVIEW2_PERMISSION_KIND) PermissionKind, origin, (COREWEBVIEW2_PERMISSION_STATE) State, (ICoreWebView2SetPermissionStateCompletedHandler) handler);
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
      await handler;
      Marshal.ThrowExceptionForHR(handler.errCode);
      handler = (CoreWebView2SetPermissionStateCompletedHandler) null;
    }

    public async Task<IReadOnlyList<CoreWebView2PermissionSetting>> GetNonDefaultPermissionSettingsAsync()
    {
      CoreWebView2GetNonDefaultPermissionSettingsCompletedHandler handler;
      try
      {
        handler = new CoreWebView2GetNonDefaultPermissionSettingsCompletedHandler();
        // ISSUE: reference to a compiler-generated method
        this._nativeICoreWebView2Profile4.GetNonDefaultPermissionSettings((ICoreWebView2GetNonDefaultPermissionSettingsCompletedHandler) handler);
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
      IReadOnlyList<CoreWebView2PermissionSetting> permissionSettingList = await handler;
      Marshal.ThrowExceptionForHR(handler.errCode);
      IReadOnlyList<CoreWebView2PermissionSetting> collectionView = handler.collectionView;
      handler = (CoreWebView2GetNonDefaultPermissionSettingsCompletedHandler) null;
      return collectionView;
    }

    public CoreWebView2CookieManager CookieManager
    {
      get
      {
        try
        {
          return this._nativeICoreWebView2Profile5.CookieManager == null ? (CoreWebView2CookieManager) null : new CoreWebView2CookieManager((object) this._nativeICoreWebView2Profile5.CookieManager);
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

    public bool IsPasswordAutosaveEnabled
    {
      get
      {
        try
        {
          return this._nativeICoreWebView2Profile6.IsPasswordAutosaveEnabled != 0;
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
          this._nativeICoreWebView2Profile6.IsPasswordAutosaveEnabled = value ? 1 : 0;
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

    public bool IsGeneralAutofillEnabled
    {
      get
      {
        try
        {
          return this._nativeICoreWebView2Profile6.IsGeneralAutofillEnabled != 0;
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
          this._nativeICoreWebView2Profile6.IsGeneralAutofillEnabled = value ? 1 : 0;
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
