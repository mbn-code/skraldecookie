// Decompiled with JetBrains decompiler
// Type: Microsoft.Web.WebView2.Core.CoreWebView2EnvironmentOptions
// Assembly: ExamCookie.WinClient, Version=1.4.1.4, Culture=neutral, PublicKeyToken=null
// MVID: E12BE1F8-B6E0-4BF5-B308-166F0E938C4B
// Assembly location: C:\Users\oskar\Downloads\ExamCookie1414.WinClient.exe

using Microsoft.Web.WebView2.Core.Raw;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

#nullable disable
namespace Microsoft.Web.WebView2.Core
{
  [ComVisible(true)]
  public class CoreWebView2EnvironmentOptions
  {
    internal ICoreWebView2EnvironmentOptions _nativeICoreWebView2EnvironmentOptionsValue;
    internal ICoreWebView2EnvironmentOptions2 _nativeICoreWebView2EnvironmentOptions2Value;
    internal ICoreWebView2EnvironmentOptions3 _nativeICoreWebView2EnvironmentOptions3Value;
    internal ICoreWebView2EnvironmentOptions4 _nativeICoreWebView2EnvironmentOptions4Value;
    internal ICoreWebView2EnvironmentOptions5 _nativeICoreWebView2EnvironmentOptions5Value;
    internal object _rawNative;

    public CoreWebView2EnvironmentOptions(
      string additionalBrowserArguments = null,
      string language = null,
      string targetCompatibleBrowserVersion = null,
      bool allowSingleSignOnUsingOSPrimaryAccount = false,
      List<CoreWebView2CustomSchemeRegistration> customSchemeRegistrations = null)
    {
      targetCompatibleBrowserVersion = BrowserInfo.PRODUCT_VERSION;
      CoreWebView2EnvironmentOptions.RawOptions rawOptions = new CoreWebView2EnvironmentOptions.RawOptions(additionalBrowserArguments, language, targetCompatibleBrowserVersion, allowSingleSignOnUsingOSPrimaryAccount, customSchemeRegistrations);
      this._nativeICoreWebView2EnvironmentOptions = (ICoreWebView2EnvironmentOptions) rawOptions;
      this._nativeICoreWebView2EnvironmentOptions2 = (ICoreWebView2EnvironmentOptions2) rawOptions;
      this._nativeICoreWebView2EnvironmentOptions3 = (ICoreWebView2EnvironmentOptions3) rawOptions;
      this._nativeICoreWebView2EnvironmentOptions4 = (ICoreWebView2EnvironmentOptions4) rawOptions;
      this._nativeICoreWebView2EnvironmentOptions5 = (ICoreWebView2EnvironmentOptions5) rawOptions;
      this.CustomSchemeRegistrations = customSchemeRegistrations;
    }

    public List<CoreWebView2CustomSchemeRegistration> CustomSchemeRegistrations { get; }

    internal ICoreWebView2EnvironmentOptions _nativeICoreWebView2EnvironmentOptions
    {
      get
      {
        if (this._nativeICoreWebView2EnvironmentOptionsValue == null)
        {
          try
          {
            this._nativeICoreWebView2EnvironmentOptionsValue = (ICoreWebView2EnvironmentOptions) this._rawNative;
          }
          catch (Exception ex)
          {
            throw new NotImplementedException("Unable to cast to Microsoft.Web.WebView2.Core.Raw.ICoreWebView2EnvironmentOptions.\nThis may happen if you are using an interface not supported by the version of the WebView2 Runtime you are using.\nFor instance, if you are using an experimental interface from an older SDK that has been modified or removed in a newer runtime.\nOr, if you are using a public interface from a newer SDK that wasn't implemented in an older runtime.\nFor more information about WebView2 versioning please visit the following: https://learn.microsoft.com/microsoft-edge/webview2/concepts/versioning", ex);
          }
        }
        return this._nativeICoreWebView2EnvironmentOptionsValue;
      }
      set => this._nativeICoreWebView2EnvironmentOptionsValue = value;
    }

    internal ICoreWebView2EnvironmentOptions2 _nativeICoreWebView2EnvironmentOptions2
    {
      get
      {
        if (this._nativeICoreWebView2EnvironmentOptions2Value == null)
        {
          try
          {
            this._nativeICoreWebView2EnvironmentOptions2Value = (ICoreWebView2EnvironmentOptions2) this._rawNative;
          }
          catch (Exception ex)
          {
            throw new NotImplementedException("Unable to cast to Microsoft.Web.WebView2.Core.Raw.ICoreWebView2EnvironmentOptions2.\nThis may happen if you are using an interface not supported by the version of the WebView2 Runtime you are using.\nFor instance, if you are using an experimental interface from an older SDK that has been modified or removed in a newer runtime.\nOr, if you are using a public interface from a newer SDK that wasn't implemented in an older runtime.\nFor more information about WebView2 versioning please visit the following: https://learn.microsoft.com/microsoft-edge/webview2/concepts/versioning", ex);
          }
        }
        return this._nativeICoreWebView2EnvironmentOptions2Value;
      }
      set => this._nativeICoreWebView2EnvironmentOptions2Value = value;
    }

    internal ICoreWebView2EnvironmentOptions3 _nativeICoreWebView2EnvironmentOptions3
    {
      get
      {
        if (this._nativeICoreWebView2EnvironmentOptions3Value == null)
        {
          try
          {
            this._nativeICoreWebView2EnvironmentOptions3Value = (ICoreWebView2EnvironmentOptions3) this._rawNative;
          }
          catch (Exception ex)
          {
            throw new NotImplementedException("Unable to cast to Microsoft.Web.WebView2.Core.Raw.ICoreWebView2EnvironmentOptions3.\nThis may happen if you are using an interface not supported by the version of the WebView2 Runtime you are using.\nFor instance, if you are using an experimental interface from an older SDK that has been modified or removed in a newer runtime.\nOr, if you are using a public interface from a newer SDK that wasn't implemented in an older runtime.\nFor more information about WebView2 versioning please visit the following: https://learn.microsoft.com/microsoft-edge/webview2/concepts/versioning", ex);
          }
        }
        return this._nativeICoreWebView2EnvironmentOptions3Value;
      }
      set => this._nativeICoreWebView2EnvironmentOptions3Value = value;
    }

    internal ICoreWebView2EnvironmentOptions4 _nativeICoreWebView2EnvironmentOptions4
    {
      get
      {
        if (this._nativeICoreWebView2EnvironmentOptions4Value == null)
        {
          try
          {
            this._nativeICoreWebView2EnvironmentOptions4Value = (ICoreWebView2EnvironmentOptions4) this._rawNative;
          }
          catch (Exception ex)
          {
            throw new NotImplementedException("Unable to cast to Microsoft.Web.WebView2.Core.Raw.ICoreWebView2EnvironmentOptions4.\nThis may happen if you are using an interface not supported by the version of the WebView2 Runtime you are using.\nFor instance, if you are using an experimental interface from an older SDK that has been modified or removed in a newer runtime.\nOr, if you are using a public interface from a newer SDK that wasn't implemented in an older runtime.\nFor more information about WebView2 versioning please visit the following: https://learn.microsoft.com/microsoft-edge/webview2/concepts/versioning", ex);
          }
        }
        return this._nativeICoreWebView2EnvironmentOptions4Value;
      }
      set => this._nativeICoreWebView2EnvironmentOptions4Value = value;
    }

    internal ICoreWebView2EnvironmentOptions5 _nativeICoreWebView2EnvironmentOptions5
    {
      get
      {
        if (this._nativeICoreWebView2EnvironmentOptions5Value == null)
        {
          try
          {
            this._nativeICoreWebView2EnvironmentOptions5Value = (ICoreWebView2EnvironmentOptions5) this._rawNative;
          }
          catch (Exception ex)
          {
            throw new NotImplementedException("Unable to cast to Microsoft.Web.WebView2.Core.Raw.ICoreWebView2EnvironmentOptions5.\nThis may happen if you are using an interface not supported by the version of the WebView2 Runtime you are using.\nFor instance, if you are using an experimental interface from an older SDK that has been modified or removed in a newer runtime.\nOr, if you are using a public interface from a newer SDK that wasn't implemented in an older runtime.\nFor more information about WebView2 versioning please visit the following: https://learn.microsoft.com/microsoft-edge/webview2/concepts/versioning", ex);
          }
        }
        return this._nativeICoreWebView2EnvironmentOptions5Value;
      }
      set => this._nativeICoreWebView2EnvironmentOptions5Value = value;
    }

    internal CoreWebView2EnvironmentOptions(object rawCoreWebView2EnvironmentOptions)
    {
      this._rawNative = rawCoreWebView2EnvironmentOptions;
    }

    public string AdditionalBrowserArguments
    {
      get
      {
        try
        {
          return this._nativeICoreWebView2EnvironmentOptions.AdditionalBrowserArguments;
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
          this._nativeICoreWebView2EnvironmentOptions.AdditionalBrowserArguments = value;
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

    public string Language
    {
      get
      {
        try
        {
          return this._nativeICoreWebView2EnvironmentOptions.Language;
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
          this._nativeICoreWebView2EnvironmentOptions.Language = value;
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

    public string TargetCompatibleBrowserVersion
    {
      get
      {
        try
        {
          return this._nativeICoreWebView2EnvironmentOptions.TargetCompatibleBrowserVersion;
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
          this._nativeICoreWebView2EnvironmentOptions.TargetCompatibleBrowserVersion = value;
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

    public bool AllowSingleSignOnUsingOSPrimaryAccount
    {
      get
      {
        try
        {
          return this._nativeICoreWebView2EnvironmentOptions.AllowSingleSignOnUsingOSPrimaryAccount != 0;
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
          this._nativeICoreWebView2EnvironmentOptions.AllowSingleSignOnUsingOSPrimaryAccount = value ? 1 : 0;
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

    public bool ExclusiveUserDataFolderAccess
    {
      get
      {
        try
        {
          return this._nativeICoreWebView2EnvironmentOptions2.ExclusiveUserDataFolderAccess != 0;
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
          this._nativeICoreWebView2EnvironmentOptions2.ExclusiveUserDataFolderAccess = value ? 1 : 0;
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

    public bool IsCustomCrashReportingEnabled
    {
      get
      {
        try
        {
          return this._nativeICoreWebView2EnvironmentOptions3.IsCustomCrashReportingEnabled != 0;
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
          this._nativeICoreWebView2EnvironmentOptions3.IsCustomCrashReportingEnabled = value ? 1 : 0;
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

    public bool EnableTrackingPrevention
    {
      get
      {
        try
        {
          return this._nativeICoreWebView2EnvironmentOptions5.EnableTrackingPrevention != 0;
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
          this._nativeICoreWebView2EnvironmentOptions5.EnableTrackingPrevention = value ? 1 : 0;
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

    private class RawOptions : 
      ICoreWebView2EnvironmentOptions,
      ICoreWebView2EnvironmentOptions2,
      ICoreWebView2EnvironmentOptions3,
      ICoreWebView2EnvironmentOptions4,
      ICoreWebView2EnvironmentOptions5
    {
      public string AdditionalBrowserArguments { get; set; }

      public string Language { get; set; }

      public string TargetCompatibleBrowserVersion { get; set; }

      public int AllowSingleSignOnUsingOSPrimaryAccount { get; set; }

      public int ExclusiveUserDataFolderAccess { get; set; }

      public int IsCustomCrashReportingEnabled { get; set; }

      public List<CoreWebView2CustomSchemeRegistration> CustomSchemeRegistrations { get; set; }

      public int EnableTrackingPrevention { get; set; } = 1;

      public void GetCustomSchemeRegistrations(out uint count, IntPtr registrationsPtr)
      {
        if (this.CustomSchemeRegistrations == null || this.CustomSchemeRegistrations.Count == 0)
        {
          count = 0U;
        }
        else
        {
          count = (uint) this.CustomSchemeRegistrations.Count;
          Marshal.SizeOf<IntPtr>();
          IntPtr val = Marshal.AllocCoTaskMem((int) count * Marshal.SizeOf<IntPtr>());
          for (int index = 0; (long) index < (long) count; ++index)
            Marshal.WriteIntPtr(val + index * Marshal.SizeOf<IntPtr>(), this.CustomSchemeRegistrations[index].GetNative());
          Marshal.WriteIntPtr(registrationsPtr, val);
        }
      }

      public void SetCustomSchemeRegistrations(
        uint count,
        ref ICoreWebView2CustomSchemeRegistration registration)
      {
        throw new NotImplementedException();
      }

      public RawOptions(
        string additionalBrowserArguments,
        string language,
        string targetCompatibleBrowserVersion,
        bool allowSingleSignOnUsingOSPrimaryAccount,
        List<CoreWebView2CustomSchemeRegistration> customSchemeRegistrations)
      {
        this.AdditionalBrowserArguments = additionalBrowserArguments;
        this.Language = language;
        this.TargetCompatibleBrowserVersion = targetCompatibleBrowserVersion;
        this.AllowSingleSignOnUsingOSPrimaryAccount = allowSingleSignOnUsingOSPrimaryAccount ? 1 : 0;
        this.CustomSchemeRegistrations = customSchemeRegistrations;
      }
    }
  }
}
