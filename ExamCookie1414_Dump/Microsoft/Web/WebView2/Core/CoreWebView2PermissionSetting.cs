﻿// Decompiled with JetBrains decompiler
// Type: Microsoft.Web.WebView2.Core.CoreWebView2PermissionSetting
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
  public class CoreWebView2PermissionSetting
  {
    internal ICoreWebView2PermissionSetting _nativeICoreWebView2PermissionSettingValue;
    internal object _rawNative;

    internal ICoreWebView2PermissionSetting _nativeICoreWebView2PermissionSetting
    {
      get
      {
        if (this._nativeICoreWebView2PermissionSettingValue == null)
        {
          try
          {
            this._nativeICoreWebView2PermissionSettingValue = (ICoreWebView2PermissionSetting) this._rawNative;
          }
          catch (Exception ex)
          {
            throw new NotImplementedException("Unable to cast to Microsoft.Web.WebView2.Core.Raw.ICoreWebView2PermissionSetting.\nThis may happen if you are using an interface not supported by the version of the WebView2 Runtime you are using.\nFor instance, if you are using an experimental interface from an older SDK that has been modified or removed in a newer runtime.\nOr, if you are using a public interface from a newer SDK that wasn't implemented in an older runtime.\nFor more information about WebView2 versioning please visit the following: https://learn.microsoft.com/microsoft-edge/webview2/concepts/versioning", ex);
          }
        }
        return this._nativeICoreWebView2PermissionSettingValue;
      }
      set => this._nativeICoreWebView2PermissionSettingValue = value;
    }

    internal CoreWebView2PermissionSetting(object rawCoreWebView2PermissionSetting)
    {
      this._rawNative = rawCoreWebView2PermissionSetting;
    }

    public CoreWebView2PermissionKind PermissionKind
    {
      get
      {
        try
        {
          return (CoreWebView2PermissionKind) this._nativeICoreWebView2PermissionSetting.PermissionKind;
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

    public string PermissionOrigin
    {
      get
      {
        try
        {
          return this._nativeICoreWebView2PermissionSetting.PermissionOrigin;
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

    public CoreWebView2PermissionState PermissionState
    {
      get
      {
        try
        {
          return (CoreWebView2PermissionState) this._nativeICoreWebView2PermissionSetting.PermissionState;
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
