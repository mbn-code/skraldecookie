// Decompiled with JetBrains decompiler
// Type: Microsoft.Web.WebView2.Core.CoreWebView2
// Assembly: ExamCookie.WinClient, Version=1.4.1.4, Culture=neutral, PublicKeyToken=null
// MVID: E12BE1F8-B6E0-4BF5-B308-166F0E938C4B
// Assembly location: C:\Users\oskar\Downloads\ExamCookie1414.WinClient.exe

using Microsoft.Web.WebView2.Core.Raw;
using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;

#nullable disable
namespace Microsoft.Web.WebView2.Core
{
  [ComVisible(true)]
  public class CoreWebView2
  {
    internal ICoreWebView2 _nativeICoreWebView2Value;
    internal ICoreWebView2_2 _nativeICoreWebView2_2Value;
    internal ICoreWebView2_3 _nativeICoreWebView2_3Value;
    internal ICoreWebView2_4 _nativeICoreWebView2_4Value;
    internal ICoreWebView2_5 _nativeICoreWebView2_5Value;
    internal ICoreWebView2_6 _nativeICoreWebView2_6Value;
    internal ICoreWebView2_7 _nativeICoreWebView2_7Value;
    internal ICoreWebView2_8 _nativeICoreWebView2_8Value;
    internal ICoreWebView2_9 _nativeICoreWebView2_9Value;
    internal ICoreWebView2_10 _nativeICoreWebView2_10Value;
    internal ICoreWebView2_11 _nativeICoreWebView2_11Value;
    internal ICoreWebView2_12 _nativeICoreWebView2_12Value;
    internal ICoreWebView2_13 _nativeICoreWebView2_13Value;
    internal ICoreWebView2_14 _nativeICoreWebView2_14Value;
    internal ICoreWebView2_15 _nativeICoreWebView2_15Value;
    internal ICoreWebView2_16 _nativeICoreWebView2_16Value;
    internal ICoreWebView2_17 _nativeICoreWebView2_17Value;
    internal ICoreWebView2_18 _nativeICoreWebView2_18Value;
    internal ICoreWebView2_19 _nativeICoreWebView2_19Value;
    internal ICoreWebView2PrivatePartial _nativeICoreWebView2PrivatePartialValue;
    internal object _rawNative;
    private EventRegistrationToken _navigationStartingToken;
    private EventHandler<CoreWebView2NavigationStartingEventArgs> navigationStarting;
    private EventRegistrationToken _contentLoadingToken;
    private EventHandler<CoreWebView2ContentLoadingEventArgs> contentLoading;
    private EventRegistrationToken _sourceChangedToken;
    private EventHandler<CoreWebView2SourceChangedEventArgs> sourceChanged;
    private EventRegistrationToken _historyChangedToken;
    private EventHandler<object> historyChanged;
    private EventRegistrationToken _navigationCompletedToken;
    private EventHandler<CoreWebView2NavigationCompletedEventArgs> navigationCompleted;
    private EventRegistrationToken _frameNavigationStartingToken;
    private EventHandler<CoreWebView2NavigationStartingEventArgs> frameNavigationStarting;
    private EventRegistrationToken _frameNavigationCompletedToken;
    private EventHandler<CoreWebView2NavigationCompletedEventArgs> frameNavigationCompleted;
    private EventRegistrationToken _scriptDialogOpeningToken;
    private EventHandler<CoreWebView2ScriptDialogOpeningEventArgs> scriptDialogOpening;
    private EventRegistrationToken _permissionRequestedToken;
    private EventHandler<CoreWebView2PermissionRequestedEventArgs> permissionRequested;
    private EventRegistrationToken _processFailedToken;
    private EventHandler<CoreWebView2ProcessFailedEventArgs> processFailed;
    private EventRegistrationToken _webMessageReceivedToken;
    private EventHandler<CoreWebView2WebMessageReceivedEventArgs> webMessageReceived;
    private EventRegistrationToken _newWindowRequestedToken;
    private EventHandler<CoreWebView2NewWindowRequestedEventArgs> newWindowRequested;
    private EventRegistrationToken _documentTitleChangedToken;
    private EventHandler<object> documentTitleChanged;
    private EventRegistrationToken _containsFullScreenElementChangedToken;
    private EventHandler<object> containsFullScreenElementChanged;
    private EventRegistrationToken _webResourceRequestedToken;
    private EventHandler<CoreWebView2WebResourceRequestedEventArgs> webResourceRequested;
    private EventRegistrationToken _windowCloseRequestedToken;
    private EventHandler<object> windowCloseRequested;
    private EventRegistrationToken _webResourceResponseReceivedToken;
    private EventHandler<CoreWebView2WebResourceResponseReceivedEventArgs> webResourceResponseReceived;
    private EventRegistrationToken _dOMContentLoadedToken;
    private EventHandler<CoreWebView2DOMContentLoadedEventArgs> dOMContentLoaded;
    private EventRegistrationToken _frameCreatedToken;
    private EventHandler<CoreWebView2FrameCreatedEventArgs> frameCreated;
    private EventRegistrationToken _downloadStartingToken;
    private EventHandler<CoreWebView2DownloadStartingEventArgs> downloadStarting;
    private EventRegistrationToken _clientCertificateRequestedToken;
    private EventHandler<CoreWebView2ClientCertificateRequestedEventArgs> clientCertificateRequested;
    private EventRegistrationToken _isMutedChangedToken;
    private EventHandler<object> isMutedChanged;
    private EventRegistrationToken _isDocumentPlayingAudioChangedToken;
    private EventHandler<object> isDocumentPlayingAudioChanged;
    private EventRegistrationToken _isDefaultDownloadDialogOpenChangedToken;
    private EventHandler<object> isDefaultDownloadDialogOpenChanged;
    private EventRegistrationToken _basicAuthenticationRequestedToken;
    private EventHandler<CoreWebView2BasicAuthenticationRequestedEventArgs> basicAuthenticationRequested;
    private EventRegistrationToken _contextMenuRequestedToken;
    private EventHandler<CoreWebView2ContextMenuRequestedEventArgs> contextMenuRequested;
    private EventRegistrationToken _statusBarTextChangedToken;
    private EventHandler<object> statusBarTextChanged;
    private EventRegistrationToken _serverCertificateErrorDetectedToken;
    private EventHandler<CoreWebView2ServerCertificateErrorDetectedEventArgs> serverCertificateErrorDetected;
    private EventRegistrationToken _faviconChangedToken;
    private EventHandler<object> faviconChanged;
    private EventRegistrationToken _launchingExternalUriSchemeToken;
    private EventHandler<CoreWebView2LaunchingExternalUriSchemeEventArgs> launchingExternalUriScheme;

    public async Task<bool> PrintToPdfAsync(
      string ResultFilePath,
      CoreWebView2PrintSettings printSettings = null)
    {
      CoreWebView2PrintToPdfCompletedHandler handler;
      try
      {
        handler = new CoreWebView2PrintToPdfCompletedHandler();
        // ISSUE: variable of a compiler-generated type
        ICoreWebView2PrintSettings view2PrintSettings = printSettings != null ? printSettings._nativeICoreWebView2PrintSettings : (ICoreWebView2PrintSettings) null;
        // ISSUE: reference to a compiler-generated method
        this._nativeICoreWebView2_7.PrintToPdf(ResultFilePath, view2PrintSettings, (ICoreWebView2PrintToPdfCompletedHandler) handler);
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
      int num = await handler ? 1 : 0;
      Marshal.ThrowExceptionForHR(handler.errCode);
      bool isSuccessful = handler.isSuccessful;
      handler = (CoreWebView2PrintToPdfCompletedHandler) null;
      return isSuccessful;
    }

    public void ShowPrintUI()
    {
      try
      {
        // ISSUE: reference to a compiler-generated method
        this._nativeICoreWebView2_16.ShowPrintUI(COREWEBVIEW2_PRINT_DIALOG_KIND.COREWEBVIEW2_PRINT_DIALOG_KIND_BROWSER);
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

    internal ICoreWebView2 _nativeICoreWebView2
    {
      get
      {
        if (this._nativeICoreWebView2Value == null)
        {
          try
          {
            this._nativeICoreWebView2Value = (ICoreWebView2) this._rawNative;
          }
          catch (Exception ex)
          {
            throw new NotImplementedException("Unable to cast to Microsoft.Web.WebView2.Core.Raw.ICoreWebView2.\nThis may happen if you are using an interface not supported by the version of the WebView2 Runtime you are using.\nFor instance, if you are using an experimental interface from an older SDK that has been modified or removed in a newer runtime.\nOr, if you are using a public interface from a newer SDK that wasn't implemented in an older runtime.\nFor more information about WebView2 versioning please visit the following: https://learn.microsoft.com/microsoft-edge/webview2/concepts/versioning", ex);
          }
        }
        return this._nativeICoreWebView2Value;
      }
      set => this._nativeICoreWebView2Value = value;
    }

    internal ICoreWebView2_2 _nativeICoreWebView2_2
    {
      get
      {
        if (this._nativeICoreWebView2_2Value == null)
        {
          try
          {
            this._nativeICoreWebView2_2Value = (ICoreWebView2_2) this._rawNative;
          }
          catch (Exception ex)
          {
            throw new NotImplementedException("Unable to cast to Microsoft.Web.WebView2.Core.Raw.ICoreWebView2_2.\nThis may happen if you are using an interface not supported by the version of the WebView2 Runtime you are using.\nFor instance, if you are using an experimental interface from an older SDK that has been modified or removed in a newer runtime.\nOr, if you are using a public interface from a newer SDK that wasn't implemented in an older runtime.\nFor more information about WebView2 versioning please visit the following: https://learn.microsoft.com/microsoft-edge/webview2/concepts/versioning", ex);
          }
        }
        return this._nativeICoreWebView2_2Value;
      }
      set => this._nativeICoreWebView2_2Value = value;
    }

    internal ICoreWebView2_3 _nativeICoreWebView2_3
    {
      get
      {
        if (this._nativeICoreWebView2_3Value == null)
        {
          try
          {
            this._nativeICoreWebView2_3Value = (ICoreWebView2_3) this._rawNative;
          }
          catch (Exception ex)
          {
            throw new NotImplementedException("Unable to cast to Microsoft.Web.WebView2.Core.Raw.ICoreWebView2_3.\nThis may happen if you are using an interface not supported by the version of the WebView2 Runtime you are using.\nFor instance, if you are using an experimental interface from an older SDK that has been modified or removed in a newer runtime.\nOr, if you are using a public interface from a newer SDK that wasn't implemented in an older runtime.\nFor more information about WebView2 versioning please visit the following: https://learn.microsoft.com/microsoft-edge/webview2/concepts/versioning", ex);
          }
        }
        return this._nativeICoreWebView2_3Value;
      }
      set => this._nativeICoreWebView2_3Value = value;
    }

    internal ICoreWebView2_4 _nativeICoreWebView2_4
    {
      get
      {
        if (this._nativeICoreWebView2_4Value == null)
        {
          try
          {
            this._nativeICoreWebView2_4Value = (ICoreWebView2_4) this._rawNative;
          }
          catch (Exception ex)
          {
            throw new NotImplementedException("Unable to cast to Microsoft.Web.WebView2.Core.Raw.ICoreWebView2_4.\nThis may happen if you are using an interface not supported by the version of the WebView2 Runtime you are using.\nFor instance, if you are using an experimental interface from an older SDK that has been modified or removed in a newer runtime.\nOr, if you are using a public interface from a newer SDK that wasn't implemented in an older runtime.\nFor more information about WebView2 versioning please visit the following: https://learn.microsoft.com/microsoft-edge/webview2/concepts/versioning", ex);
          }
        }
        return this._nativeICoreWebView2_4Value;
      }
      set => this._nativeICoreWebView2_4Value = value;
    }

    internal ICoreWebView2_5 _nativeICoreWebView2_5
    {
      get
      {
        if (this._nativeICoreWebView2_5Value == null)
        {
          try
          {
            this._nativeICoreWebView2_5Value = (ICoreWebView2_5) this._rawNative;
          }
          catch (Exception ex)
          {
            throw new NotImplementedException("Unable to cast to Microsoft.Web.WebView2.Core.Raw.ICoreWebView2_5.\nThis may happen if you are using an interface not supported by the version of the WebView2 Runtime you are using.\nFor instance, if you are using an experimental interface from an older SDK that has been modified or removed in a newer runtime.\nOr, if you are using a public interface from a newer SDK that wasn't implemented in an older runtime.\nFor more information about WebView2 versioning please visit the following: https://learn.microsoft.com/microsoft-edge/webview2/concepts/versioning", ex);
          }
        }
        return this._nativeICoreWebView2_5Value;
      }
      set => this._nativeICoreWebView2_5Value = value;
    }

    internal ICoreWebView2_6 _nativeICoreWebView2_6
    {
      get
      {
        if (this._nativeICoreWebView2_6Value == null)
        {
          try
          {
            this._nativeICoreWebView2_6Value = (ICoreWebView2_6) this._rawNative;
          }
          catch (Exception ex)
          {
            throw new NotImplementedException("Unable to cast to Microsoft.Web.WebView2.Core.Raw.ICoreWebView2_6.\nThis may happen if you are using an interface not supported by the version of the WebView2 Runtime you are using.\nFor instance, if you are using an experimental interface from an older SDK that has been modified or removed in a newer runtime.\nOr, if you are using a public interface from a newer SDK that wasn't implemented in an older runtime.\nFor more information about WebView2 versioning please visit the following: https://learn.microsoft.com/microsoft-edge/webview2/concepts/versioning", ex);
          }
        }
        return this._nativeICoreWebView2_6Value;
      }
      set => this._nativeICoreWebView2_6Value = value;
    }

    internal ICoreWebView2_7 _nativeICoreWebView2_7
    {
      get
      {
        if (this._nativeICoreWebView2_7Value == null)
        {
          try
          {
            this._nativeICoreWebView2_7Value = (ICoreWebView2_7) this._rawNative;
          }
          catch (Exception ex)
          {
            throw new NotImplementedException("Unable to cast to Microsoft.Web.WebView2.Core.Raw.ICoreWebView2_7.\nThis may happen if you are using an interface not supported by the version of the WebView2 Runtime you are using.\nFor instance, if you are using an experimental interface from an older SDK that has been modified or removed in a newer runtime.\nOr, if you are using a public interface from a newer SDK that wasn't implemented in an older runtime.\nFor more information about WebView2 versioning please visit the following: https://learn.microsoft.com/microsoft-edge/webview2/concepts/versioning", ex);
          }
        }
        return this._nativeICoreWebView2_7Value;
      }
      set => this._nativeICoreWebView2_7Value = value;
    }

    internal ICoreWebView2_8 _nativeICoreWebView2_8
    {
      get
      {
        if (this._nativeICoreWebView2_8Value == null)
        {
          try
          {
            this._nativeICoreWebView2_8Value = (ICoreWebView2_8) this._rawNative;
          }
          catch (Exception ex)
          {
            throw new NotImplementedException("Unable to cast to Microsoft.Web.WebView2.Core.Raw.ICoreWebView2_8.\nThis may happen if you are using an interface not supported by the version of the WebView2 Runtime you are using.\nFor instance, if you are using an experimental interface from an older SDK that has been modified or removed in a newer runtime.\nOr, if you are using a public interface from a newer SDK that wasn't implemented in an older runtime.\nFor more information about WebView2 versioning please visit the following: https://learn.microsoft.com/microsoft-edge/webview2/concepts/versioning", ex);
          }
        }
        return this._nativeICoreWebView2_8Value;
      }
      set => this._nativeICoreWebView2_8Value = value;
    }

    internal ICoreWebView2_9 _nativeICoreWebView2_9
    {
      get
      {
        if (this._nativeICoreWebView2_9Value == null)
        {
          try
          {
            this._nativeICoreWebView2_9Value = (ICoreWebView2_9) this._rawNative;
          }
          catch (Exception ex)
          {
            throw new NotImplementedException("Unable to cast to Microsoft.Web.WebView2.Core.Raw.ICoreWebView2_9.\nThis may happen if you are using an interface not supported by the version of the WebView2 Runtime you are using.\nFor instance, if you are using an experimental interface from an older SDK that has been modified or removed in a newer runtime.\nOr, if you are using a public interface from a newer SDK that wasn't implemented in an older runtime.\nFor more information about WebView2 versioning please visit the following: https://learn.microsoft.com/microsoft-edge/webview2/concepts/versioning", ex);
          }
        }
        return this._nativeICoreWebView2_9Value;
      }
      set => this._nativeICoreWebView2_9Value = value;
    }

    internal ICoreWebView2_10 _nativeICoreWebView2_10
    {
      get
      {
        if (this._nativeICoreWebView2_10Value == null)
        {
          try
          {
            this._nativeICoreWebView2_10Value = (ICoreWebView2_10) this._rawNative;
          }
          catch (Exception ex)
          {
            throw new NotImplementedException("Unable to cast to Microsoft.Web.WebView2.Core.Raw.ICoreWebView2_10.\nThis may happen if you are using an interface not supported by the version of the WebView2 Runtime you are using.\nFor instance, if you are using an experimental interface from an older SDK that has been modified or removed in a newer runtime.\nOr, if you are using a public interface from a newer SDK that wasn't implemented in an older runtime.\nFor more information about WebView2 versioning please visit the following: https://learn.microsoft.com/microsoft-edge/webview2/concepts/versioning", ex);
          }
        }
        return this._nativeICoreWebView2_10Value;
      }
      set => this._nativeICoreWebView2_10Value = value;
    }

    internal ICoreWebView2_11 _nativeICoreWebView2_11
    {
      get
      {
        if (this._nativeICoreWebView2_11Value == null)
        {
          try
          {
            this._nativeICoreWebView2_11Value = (ICoreWebView2_11) this._rawNative;
          }
          catch (Exception ex)
          {
            throw new NotImplementedException("Unable to cast to Microsoft.Web.WebView2.Core.Raw.ICoreWebView2_11.\nThis may happen if you are using an interface not supported by the version of the WebView2 Runtime you are using.\nFor instance, if you are using an experimental interface from an older SDK that has been modified or removed in a newer runtime.\nOr, if you are using a public interface from a newer SDK that wasn't implemented in an older runtime.\nFor more information about WebView2 versioning please visit the following: https://learn.microsoft.com/microsoft-edge/webview2/concepts/versioning", ex);
          }
        }
        return this._nativeICoreWebView2_11Value;
      }
      set => this._nativeICoreWebView2_11Value = value;
    }

    internal ICoreWebView2_12 _nativeICoreWebView2_12
    {
      get
      {
        if (this._nativeICoreWebView2_12Value == null)
        {
          try
          {
            this._nativeICoreWebView2_12Value = (ICoreWebView2_12) this._rawNative;
          }
          catch (Exception ex)
          {
            throw new NotImplementedException("Unable to cast to Microsoft.Web.WebView2.Core.Raw.ICoreWebView2_12.\nThis may happen if you are using an interface not supported by the version of the WebView2 Runtime you are using.\nFor instance, if you are using an experimental interface from an older SDK that has been modified or removed in a newer runtime.\nOr, if you are using a public interface from a newer SDK that wasn't implemented in an older runtime.\nFor more information about WebView2 versioning please visit the following: https://learn.microsoft.com/microsoft-edge/webview2/concepts/versioning", ex);
          }
        }
        return this._nativeICoreWebView2_12Value;
      }
      set => this._nativeICoreWebView2_12Value = value;
    }

    internal ICoreWebView2_13 _nativeICoreWebView2_13
    {
      get
      {
        if (this._nativeICoreWebView2_13Value == null)
        {
          try
          {
            this._nativeICoreWebView2_13Value = (ICoreWebView2_13) this._rawNative;
          }
          catch (Exception ex)
          {
            throw new NotImplementedException("Unable to cast to Microsoft.Web.WebView2.Core.Raw.ICoreWebView2_13.\nThis may happen if you are using an interface not supported by the version of the WebView2 Runtime you are using.\nFor instance, if you are using an experimental interface from an older SDK that has been modified or removed in a newer runtime.\nOr, if you are using a public interface from a newer SDK that wasn't implemented in an older runtime.\nFor more information about WebView2 versioning please visit the following: https://learn.microsoft.com/microsoft-edge/webview2/concepts/versioning", ex);
          }
        }
        return this._nativeICoreWebView2_13Value;
      }
      set => this._nativeICoreWebView2_13Value = value;
    }

    internal ICoreWebView2_14 _nativeICoreWebView2_14
    {
      get
      {
        if (this._nativeICoreWebView2_14Value == null)
        {
          try
          {
            this._nativeICoreWebView2_14Value = (ICoreWebView2_14) this._rawNative;
          }
          catch (Exception ex)
          {
            throw new NotImplementedException("Unable to cast to Microsoft.Web.WebView2.Core.Raw.ICoreWebView2_14.\nThis may happen if you are using an interface not supported by the version of the WebView2 Runtime you are using.\nFor instance, if you are using an experimental interface from an older SDK that has been modified or removed in a newer runtime.\nOr, if you are using a public interface from a newer SDK that wasn't implemented in an older runtime.\nFor more information about WebView2 versioning please visit the following: https://learn.microsoft.com/microsoft-edge/webview2/concepts/versioning", ex);
          }
        }
        return this._nativeICoreWebView2_14Value;
      }
      set => this._nativeICoreWebView2_14Value = value;
    }

    internal ICoreWebView2_15 _nativeICoreWebView2_15
    {
      get
      {
        if (this._nativeICoreWebView2_15Value == null)
        {
          try
          {
            this._nativeICoreWebView2_15Value = (ICoreWebView2_15) this._rawNative;
          }
          catch (Exception ex)
          {
            throw new NotImplementedException("Unable to cast to Microsoft.Web.WebView2.Core.Raw.ICoreWebView2_15.\nThis may happen if you are using an interface not supported by the version of the WebView2 Runtime you are using.\nFor instance, if you are using an experimental interface from an older SDK that has been modified or removed in a newer runtime.\nOr, if you are using a public interface from a newer SDK that wasn't implemented in an older runtime.\nFor more information about WebView2 versioning please visit the following: https://learn.microsoft.com/microsoft-edge/webview2/concepts/versioning", ex);
          }
        }
        return this._nativeICoreWebView2_15Value;
      }
      set => this._nativeICoreWebView2_15Value = value;
    }

    internal ICoreWebView2_16 _nativeICoreWebView2_16
    {
      get
      {
        if (this._nativeICoreWebView2_16Value == null)
        {
          try
          {
            this._nativeICoreWebView2_16Value = (ICoreWebView2_16) this._rawNative;
          }
          catch (Exception ex)
          {
            throw new NotImplementedException("Unable to cast to Microsoft.Web.WebView2.Core.Raw.ICoreWebView2_16.\nThis may happen if you are using an interface not supported by the version of the WebView2 Runtime you are using.\nFor instance, if you are using an experimental interface from an older SDK that has been modified or removed in a newer runtime.\nOr, if you are using a public interface from a newer SDK that wasn't implemented in an older runtime.\nFor more information about WebView2 versioning please visit the following: https://learn.microsoft.com/microsoft-edge/webview2/concepts/versioning", ex);
          }
        }
        return this._nativeICoreWebView2_16Value;
      }
      set => this._nativeICoreWebView2_16Value = value;
    }

    internal ICoreWebView2_17 _nativeICoreWebView2_17
    {
      get
      {
        if (this._nativeICoreWebView2_17Value == null)
        {
          try
          {
            this._nativeICoreWebView2_17Value = (ICoreWebView2_17) this._rawNative;
          }
          catch (Exception ex)
          {
            throw new NotImplementedException("Unable to cast to Microsoft.Web.WebView2.Core.Raw.ICoreWebView2_17.\nThis may happen if you are using an interface not supported by the version of the WebView2 Runtime you are using.\nFor instance, if you are using an experimental interface from an older SDK that has been modified or removed in a newer runtime.\nOr, if you are using a public interface from a newer SDK that wasn't implemented in an older runtime.\nFor more information about WebView2 versioning please visit the following: https://learn.microsoft.com/microsoft-edge/webview2/concepts/versioning", ex);
          }
        }
        return this._nativeICoreWebView2_17Value;
      }
      set => this._nativeICoreWebView2_17Value = value;
    }

    internal ICoreWebView2_18 _nativeICoreWebView2_18
    {
      get
      {
        if (this._nativeICoreWebView2_18Value == null)
        {
          try
          {
            this._nativeICoreWebView2_18Value = (ICoreWebView2_18) this._rawNative;
          }
          catch (Exception ex)
          {
            throw new NotImplementedException("Unable to cast to Microsoft.Web.WebView2.Core.Raw.ICoreWebView2_18.\nThis may happen if you are using an interface not supported by the version of the WebView2 Runtime you are using.\nFor instance, if you are using an experimental interface from an older SDK that has been modified or removed in a newer runtime.\nOr, if you are using a public interface from a newer SDK that wasn't implemented in an older runtime.\nFor more information about WebView2 versioning please visit the following: https://learn.microsoft.com/microsoft-edge/webview2/concepts/versioning", ex);
          }
        }
        return this._nativeICoreWebView2_18Value;
      }
      set => this._nativeICoreWebView2_18Value = value;
    }

    internal ICoreWebView2_19 _nativeICoreWebView2_19
    {
      get
      {
        if (this._nativeICoreWebView2_19Value == null)
        {
          try
          {
            this._nativeICoreWebView2_19Value = (ICoreWebView2_19) this._rawNative;
          }
          catch (Exception ex)
          {
            throw new NotImplementedException("Unable to cast to Microsoft.Web.WebView2.Core.Raw.ICoreWebView2_19.\nThis may happen if you are using an interface not supported by the version of the WebView2 Runtime you are using.\nFor instance, if you are using an experimental interface from an older SDK that has been modified or removed in a newer runtime.\nOr, if you are using a public interface from a newer SDK that wasn't implemented in an older runtime.\nFor more information about WebView2 versioning please visit the following: https://learn.microsoft.com/microsoft-edge/webview2/concepts/versioning", ex);
          }
        }
        return this._nativeICoreWebView2_19Value;
      }
      set => this._nativeICoreWebView2_19Value = value;
    }

    internal ICoreWebView2PrivatePartial _nativeICoreWebView2PrivatePartial
    {
      get
      {
        if (this._nativeICoreWebView2PrivatePartialValue == null)
        {
          try
          {
            this._nativeICoreWebView2PrivatePartialValue = (ICoreWebView2PrivatePartial) this._rawNative;
          }
          catch (Exception ex)
          {
            throw new NotImplementedException("Unable to cast to Microsoft.Web.WebView2.Core.Raw.ICoreWebView2PrivatePartial.\nThis may happen if you are using an interface not supported by the version of the WebView2 Runtime you are using.\nFor instance, if you are using an experimental interface from an older SDK that has been modified or removed in a newer runtime.\nOr, if you are using a public interface from a newer SDK that wasn't implemented in an older runtime.\nFor more information about WebView2 versioning please visit the following: https://learn.microsoft.com/microsoft-edge/webview2/concepts/versioning", ex);
          }
        }
        return this._nativeICoreWebView2PrivatePartialValue;
      }
      set => this._nativeICoreWebView2PrivatePartialValue = value;
    }

    internal CoreWebView2(object rawCoreWebView2) => this._rawNative = rawCoreWebView2;

    public CoreWebView2Settings Settings
    {
      get
      {
        try
        {
          return this._nativeICoreWebView2.Settings == null ? (CoreWebView2Settings) null : new CoreWebView2Settings((object) this._nativeICoreWebView2.Settings);
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

    public string Source
    {
      get
      {
        try
        {
          return this._nativeICoreWebView2.Source;
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

    public uint BrowserProcessId
    {
      get
      {
        try
        {
          return this._nativeICoreWebView2.BrowserProcessId;
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

    public bool CanGoBack
    {
      get
      {
        try
        {
          return this._nativeICoreWebView2.CanGoBack != 0;
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

    public bool CanGoForward
    {
      get
      {
        try
        {
          return this._nativeICoreWebView2.CanGoForward != 0;
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

    public string DocumentTitle
    {
      get
      {
        try
        {
          return this._nativeICoreWebView2.DocumentTitle;
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

    public bool ContainsFullScreenElement
    {
      get
      {
        try
        {
          return this._nativeICoreWebView2.ContainsFullScreenElement != 0;
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

    public event EventHandler<CoreWebView2NavigationStartingEventArgs> NavigationStarting
    {
      add
      {
        if (this.navigationStarting == null)
        {
          try
          {
            this._nativeICoreWebView2.add_NavigationStarting((ICoreWebView2NavigationStartingEventHandler) new CoreWebView2NavigationStartingEventHandler(new CoreWebView2NavigationStartingEventHandler.CallbackType(this.OnNavigationStarting)), out this._navigationStartingToken);
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
          this._nativeICoreWebView2.remove_NavigationStarting(this._navigationStartingToken);
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
            this._nativeICoreWebView2.add_ContentLoading((ICoreWebView2ContentLoadingEventHandler) new CoreWebView2ContentLoadingEventHandler(new CoreWebView2ContentLoadingEventHandler.CallbackType(this.OnContentLoading)), out this._contentLoadingToken);
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
          this._nativeICoreWebView2.remove_ContentLoading(this._contentLoadingToken);
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

    public event EventHandler<CoreWebView2SourceChangedEventArgs> SourceChanged
    {
      add
      {
        if (this.sourceChanged == null)
        {
          try
          {
            this._nativeICoreWebView2.add_SourceChanged((ICoreWebView2SourceChangedEventHandler) new CoreWebView2SourceChangedEventHandler(new CoreWebView2SourceChangedEventHandler.CallbackType(this.OnSourceChanged)), out this._sourceChangedToken);
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
        this.sourceChanged += value;
      }
      remove
      {
        this.sourceChanged -= value;
        if (this.sourceChanged != null)
          return;
        try
        {
          this._nativeICoreWebView2.remove_SourceChanged(this._sourceChangedToken);
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

    internal void OnSourceChanged(CoreWebView2SourceChangedEventArgs args)
    {
      EventHandler<CoreWebView2SourceChangedEventArgs> sourceChanged = this.sourceChanged;
      if (sourceChanged == null)
        return;
      sourceChanged((object) this, args);
    }

    public event EventHandler<object> HistoryChanged
    {
      add
      {
        if (this.historyChanged == null)
        {
          try
          {
            this._nativeICoreWebView2.add_HistoryChanged((ICoreWebView2HistoryChangedEventHandler) new CoreWebView2HistoryChangedEventHandler(new CoreWebView2HistoryChangedEventHandler.CallbackType(this.OnHistoryChanged)), out this._historyChangedToken);
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
        this.historyChanged += value;
      }
      remove
      {
        this.historyChanged -= value;
        if (this.historyChanged != null)
          return;
        try
        {
          this._nativeICoreWebView2.remove_HistoryChanged(this._historyChangedToken);
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

    internal void OnHistoryChanged(object args)
    {
      EventHandler<object> historyChanged = this.historyChanged;
      if (historyChanged == null)
        return;
      historyChanged((object) this, args);
    }

    public event EventHandler<CoreWebView2NavigationCompletedEventArgs> NavigationCompleted
    {
      add
      {
        if (this.navigationCompleted == null)
        {
          try
          {
            this._nativeICoreWebView2.add_NavigationCompleted((ICoreWebView2NavigationCompletedEventHandler) new CoreWebView2NavigationCompletedEventHandler(new CoreWebView2NavigationCompletedEventHandler.CallbackType(this.OnNavigationCompleted)), out this._navigationCompletedToken);
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
          this._nativeICoreWebView2.remove_NavigationCompleted(this._navigationCompletedToken);
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

    public event EventHandler<CoreWebView2NavigationStartingEventArgs> FrameNavigationStarting
    {
      add
      {
        if (this.frameNavigationStarting == null)
        {
          try
          {
            this._nativeICoreWebView2.add_FrameNavigationStarting((ICoreWebView2NavigationStartingEventHandler) new CoreWebView2NavigationStartingEventHandler(new CoreWebView2NavigationStartingEventHandler.CallbackType(this.OnFrameNavigationStarting)), out this._frameNavigationStartingToken);
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
        this.frameNavigationStarting += value;
      }
      remove
      {
        this.frameNavigationStarting -= value;
        if (this.frameNavigationStarting != null)
          return;
        try
        {
          this._nativeICoreWebView2.remove_FrameNavigationStarting(this._frameNavigationStartingToken);
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

    internal void OnFrameNavigationStarting(CoreWebView2NavigationStartingEventArgs args)
    {
      EventHandler<CoreWebView2NavigationStartingEventArgs> navigationStarting = this.frameNavigationStarting;
      if (navigationStarting == null)
        return;
      navigationStarting((object) this, args);
    }

    public event EventHandler<CoreWebView2NavigationCompletedEventArgs> FrameNavigationCompleted
    {
      add
      {
        if (this.frameNavigationCompleted == null)
        {
          try
          {
            this._nativeICoreWebView2.add_FrameNavigationCompleted((ICoreWebView2NavigationCompletedEventHandler) new CoreWebView2NavigationCompletedEventHandler(new CoreWebView2NavigationCompletedEventHandler.CallbackType(this.OnFrameNavigationCompleted)), out this._frameNavigationCompletedToken);
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
        this.frameNavigationCompleted += value;
      }
      remove
      {
        this.frameNavigationCompleted -= value;
        if (this.frameNavigationCompleted != null)
          return;
        try
        {
          this._nativeICoreWebView2.remove_FrameNavigationCompleted(this._frameNavigationCompletedToken);
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

    internal void OnFrameNavigationCompleted(CoreWebView2NavigationCompletedEventArgs args)
    {
      EventHandler<CoreWebView2NavigationCompletedEventArgs> navigationCompleted = this.frameNavigationCompleted;
      if (navigationCompleted == null)
        return;
      navigationCompleted((object) this, args);
    }

    public event EventHandler<CoreWebView2ScriptDialogOpeningEventArgs> ScriptDialogOpening
    {
      add
      {
        if (this.scriptDialogOpening == null)
        {
          try
          {
            this._nativeICoreWebView2.add_ScriptDialogOpening((ICoreWebView2ScriptDialogOpeningEventHandler) new CoreWebView2ScriptDialogOpeningEventHandler(new CoreWebView2ScriptDialogOpeningEventHandler.CallbackType(this.OnScriptDialogOpening)), out this._scriptDialogOpeningToken);
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
        this.scriptDialogOpening += value;
      }
      remove
      {
        this.scriptDialogOpening -= value;
        if (this.scriptDialogOpening != null)
          return;
        try
        {
          this._nativeICoreWebView2.remove_ScriptDialogOpening(this._scriptDialogOpeningToken);
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

    internal void OnScriptDialogOpening(CoreWebView2ScriptDialogOpeningEventArgs args)
    {
      EventHandler<CoreWebView2ScriptDialogOpeningEventArgs> scriptDialogOpening = this.scriptDialogOpening;
      if (scriptDialogOpening == null)
        return;
      scriptDialogOpening((object) this, args);
    }

    public event EventHandler<CoreWebView2PermissionRequestedEventArgs> PermissionRequested
    {
      add
      {
        if (this.permissionRequested == null)
        {
          try
          {
            this._nativeICoreWebView2.add_PermissionRequested((ICoreWebView2PermissionRequestedEventHandler) new CoreWebView2PermissionRequestedEventHandler(new CoreWebView2PermissionRequestedEventHandler.CallbackType(this.OnPermissionRequested)), out this._permissionRequestedToken);
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
          this._nativeICoreWebView2.remove_PermissionRequested(this._permissionRequestedToken);
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

    public event EventHandler<CoreWebView2ProcessFailedEventArgs> ProcessFailed
    {
      add
      {
        if (this.processFailed == null)
        {
          try
          {
            this._nativeICoreWebView2.add_ProcessFailed((ICoreWebView2ProcessFailedEventHandler) new CoreWebView2ProcessFailedEventHandler(new CoreWebView2ProcessFailedEventHandler.CallbackType(this.OnProcessFailed)), out this._processFailedToken);
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
        this.processFailed += value;
      }
      remove
      {
        this.processFailed -= value;
        if (this.processFailed != null)
          return;
        try
        {
          this._nativeICoreWebView2.remove_ProcessFailed(this._processFailedToken);
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

    internal void OnProcessFailed(CoreWebView2ProcessFailedEventArgs args)
    {
      EventHandler<CoreWebView2ProcessFailedEventArgs> processFailed = this.processFailed;
      if (processFailed == null)
        return;
      processFailed((object) this, args);
    }

    public event EventHandler<CoreWebView2WebMessageReceivedEventArgs> WebMessageReceived
    {
      add
      {
        if (this.webMessageReceived == null)
        {
          try
          {
            this._nativeICoreWebView2.add_WebMessageReceived((ICoreWebView2WebMessageReceivedEventHandler) new CoreWebView2WebMessageReceivedEventHandler(new CoreWebView2WebMessageReceivedEventHandler.CallbackType(this.OnWebMessageReceived)), out this._webMessageReceivedToken);
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
          this._nativeICoreWebView2.remove_WebMessageReceived(this._webMessageReceivedToken);
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

    public event EventHandler<CoreWebView2NewWindowRequestedEventArgs> NewWindowRequested
    {
      add
      {
        if (this.newWindowRequested == null)
        {
          try
          {
            this._nativeICoreWebView2.add_NewWindowRequested((ICoreWebView2NewWindowRequestedEventHandler) new CoreWebView2NewWindowRequestedEventHandler(new CoreWebView2NewWindowRequestedEventHandler.CallbackType(this.OnNewWindowRequested)), out this._newWindowRequestedToken);
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
        this.newWindowRequested += value;
      }
      remove
      {
        this.newWindowRequested -= value;
        if (this.newWindowRequested != null)
          return;
        try
        {
          this._nativeICoreWebView2.remove_NewWindowRequested(this._newWindowRequestedToken);
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

    internal void OnNewWindowRequested(CoreWebView2NewWindowRequestedEventArgs args)
    {
      EventHandler<CoreWebView2NewWindowRequestedEventArgs> newWindowRequested = this.newWindowRequested;
      if (newWindowRequested == null)
        return;
      newWindowRequested((object) this, args);
    }

    public event EventHandler<object> DocumentTitleChanged
    {
      add
      {
        if (this.documentTitleChanged == null)
        {
          try
          {
            this._nativeICoreWebView2.add_DocumentTitleChanged((ICoreWebView2DocumentTitleChangedEventHandler) new CoreWebView2DocumentTitleChangedEventHandler(new CoreWebView2DocumentTitleChangedEventHandler.CallbackType(this.OnDocumentTitleChanged)), out this._documentTitleChangedToken);
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
        this.documentTitleChanged += value;
      }
      remove
      {
        this.documentTitleChanged -= value;
        if (this.documentTitleChanged != null)
          return;
        try
        {
          this._nativeICoreWebView2.remove_DocumentTitleChanged(this._documentTitleChangedToken);
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

    internal void OnDocumentTitleChanged(object args)
    {
      EventHandler<object> documentTitleChanged = this.documentTitleChanged;
      if (documentTitleChanged == null)
        return;
      documentTitleChanged((object) this, args);
    }

    public event EventHandler<object> ContainsFullScreenElementChanged
    {
      add
      {
        if (this.containsFullScreenElementChanged == null)
        {
          try
          {
            this._nativeICoreWebView2.add_ContainsFullScreenElementChanged((ICoreWebView2ContainsFullScreenElementChangedEventHandler) new CoreWebView2ContainsFullScreenElementChangedEventHandler(new CoreWebView2ContainsFullScreenElementChangedEventHandler.CallbackType(this.OnContainsFullScreenElementChanged)), out this._containsFullScreenElementChangedToken);
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
        this.containsFullScreenElementChanged += value;
      }
      remove
      {
        this.containsFullScreenElementChanged -= value;
        if (this.containsFullScreenElementChanged != null)
          return;
        try
        {
          this._nativeICoreWebView2.remove_ContainsFullScreenElementChanged(this._containsFullScreenElementChangedToken);
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

    internal void OnContainsFullScreenElementChanged(object args)
    {
      EventHandler<object> screenElementChanged = this.containsFullScreenElementChanged;
      if (screenElementChanged == null)
        return;
      screenElementChanged((object) this, args);
    }

    public event EventHandler<CoreWebView2WebResourceRequestedEventArgs> WebResourceRequested
    {
      add
      {
        if (this.webResourceRequested == null)
        {
          try
          {
            this._nativeICoreWebView2.add_WebResourceRequested((ICoreWebView2WebResourceRequestedEventHandler) new CoreWebView2WebResourceRequestedEventHandler(new CoreWebView2WebResourceRequestedEventHandler.CallbackType(this.OnWebResourceRequested)), out this._webResourceRequestedToken);
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
        this.webResourceRequested += value;
      }
      remove
      {
        this.webResourceRequested -= value;
        if (this.webResourceRequested != null)
          return;
        try
        {
          this._nativeICoreWebView2.remove_WebResourceRequested(this._webResourceRequestedToken);
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

    internal void OnWebResourceRequested(CoreWebView2WebResourceRequestedEventArgs args)
    {
      EventHandler<CoreWebView2WebResourceRequestedEventArgs> resourceRequested = this.webResourceRequested;
      if (resourceRequested == null)
        return;
      resourceRequested((object) this, args);
    }

    public event EventHandler<object> WindowCloseRequested
    {
      add
      {
        if (this.windowCloseRequested == null)
        {
          try
          {
            this._nativeICoreWebView2.add_WindowCloseRequested((ICoreWebView2WindowCloseRequestedEventHandler) new CoreWebView2WindowCloseRequestedEventHandler(new CoreWebView2WindowCloseRequestedEventHandler.CallbackType(this.OnWindowCloseRequested)), out this._windowCloseRequestedToken);
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
        this.windowCloseRequested += value;
      }
      remove
      {
        this.windowCloseRequested -= value;
        if (this.windowCloseRequested != null)
          return;
        try
        {
          this._nativeICoreWebView2.remove_WindowCloseRequested(this._windowCloseRequestedToken);
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

    internal void OnWindowCloseRequested(object args)
    {
      EventHandler<object> windowCloseRequested = this.windowCloseRequested;
      if (windowCloseRequested == null)
        return;
      windowCloseRequested((object) this, args);
    }

    public void Navigate(string uri)
    {
      try
      {
        // ISSUE: reference to a compiler-generated method
        this._nativeICoreWebView2.Navigate(uri);
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

    public void NavigateToString(string htmlContent)
    {
      try
      {
        // ISSUE: reference to a compiler-generated method
        this._nativeICoreWebView2.NavigateToString(htmlContent);
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

    public async Task<string> AddScriptToExecuteOnDocumentCreatedAsync(string javaScript)
    {
      CoreWebView2AddScriptToExecuteOnDocumentCreatedCompletedHandler handler;
      try
      {
        handler = new CoreWebView2AddScriptToExecuteOnDocumentCreatedCompletedHandler();
        // ISSUE: reference to a compiler-generated method
        this._nativeICoreWebView2.AddScriptToExecuteOnDocumentCreated(javaScript, (ICoreWebView2AddScriptToExecuteOnDocumentCreatedCompletedHandler) handler);
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
      string id = handler.id;
      handler = (CoreWebView2AddScriptToExecuteOnDocumentCreatedCompletedHandler) null;
      return id;
    }

    public void RemoveScriptToExecuteOnDocumentCreated(string id)
    {
      try
      {
        // ISSUE: reference to a compiler-generated method
        this._nativeICoreWebView2.RemoveScriptToExecuteOnDocumentCreated(id);
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

    public async Task<string> ExecuteScriptAsync(string javaScript)
    {
      CoreWebView2ExecuteScriptCompletedHandler handler;
      try
      {
        handler = new CoreWebView2ExecuteScriptCompletedHandler();
        // ISSUE: reference to a compiler-generated method
        this._nativeICoreWebView2.ExecuteScript(javaScript, (ICoreWebView2ExecuteScriptCompletedHandler) handler);
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

    public async Task CapturePreviewAsync(
      CoreWebView2CapturePreviewImageFormat imageFormat,
      Stream imageStream)
    {
      CoreWebView2CapturePreviewCompletedHandler handler;
      try
      {
        handler = new CoreWebView2CapturePreviewCompletedHandler();
        // ISSUE: reference to a compiler-generated method
        this._nativeICoreWebView2.CapturePreview((COREWEBVIEW2_CAPTURE_PREVIEW_IMAGE_FORMAT) imageFormat, imageStream == null ? (IStream) null : (IStream) new ManagedIStream(imageStream), (ICoreWebView2CapturePreviewCompletedHandler) handler);
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
      handler = (CoreWebView2CapturePreviewCompletedHandler) null;
    }

    public void Reload()
    {
      try
      {
        // ISSUE: reference to a compiler-generated method
        this._nativeICoreWebView2.Reload();
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

    public void PostWebMessageAsJson(string webMessageAsJson)
    {
      try
      {
        // ISSUE: reference to a compiler-generated method
        this._nativeICoreWebView2.PostWebMessageAsJson(webMessageAsJson);
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
        this._nativeICoreWebView2.PostWebMessageAsString(webMessageAsString);
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

    public async Task<string> CallDevToolsProtocolMethodAsync(
      string methodName,
      string parametersAsJson)
    {
      CoreWebView2CallDevToolsProtocolMethodCompletedHandler handler;
      try
      {
        handler = new CoreWebView2CallDevToolsProtocolMethodCompletedHandler();
        // ISSUE: reference to a compiler-generated method
        this._nativeICoreWebView2.CallDevToolsProtocolMethod(methodName, parametersAsJson, (ICoreWebView2CallDevToolsProtocolMethodCompletedHandler) handler);
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
      string returnObjectAsJson = handler.returnObjectAsJson;
      handler = (CoreWebView2CallDevToolsProtocolMethodCompletedHandler) null;
      return returnObjectAsJson;
    }

    public void GoBack()
    {
      try
      {
        // ISSUE: reference to a compiler-generated method
        this._nativeICoreWebView2.GoBack();
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

    public void GoForward()
    {
      try
      {
        // ISSUE: reference to a compiler-generated method
        this._nativeICoreWebView2.GoForward();
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

    public CoreWebView2DevToolsProtocolEventReceiver GetDevToolsProtocolEventReceiver(
      string eventName)
    {
      try
      {
        // ISSUE: reference to a compiler-generated method
        return new CoreWebView2DevToolsProtocolEventReceiver((object) this._nativeICoreWebView2.GetDevToolsProtocolEventReceiver(eventName));
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

    public void Stop()
    {
      try
      {
        // ISSUE: reference to a compiler-generated method
        this._nativeICoreWebView2.Stop();
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

    public void AddHostObjectToScript(string name, object rawObject)
    {
      try
      {
        // ISSUE: variable of a compiler-generated type
        ICoreWebView2 nativeIcoreWebView2 = this._nativeICoreWebView2;
        string name1 = name;
        object obj = rawObject;
        ref object local = ref obj;
        // ISSUE: reference to a compiler-generated method
        nativeIcoreWebView2.AddHostObjectToScript(name1, ref local);
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

    public void RemoveHostObjectFromScript(string name)
    {
      try
      {
        // ISSUE: reference to a compiler-generated method
        this._nativeICoreWebView2.RemoveHostObjectFromScript(name);
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

    public void OpenDevToolsWindow()
    {
      try
      {
        // ISSUE: reference to a compiler-generated method
        this._nativeICoreWebView2.OpenDevToolsWindow();
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

    public void AddWebResourceRequestedFilter(
      string uri,
      CoreWebView2WebResourceContext ResourceContext)
    {
      try
      {
        // ISSUE: reference to a compiler-generated method
        this._nativeICoreWebView2.AddWebResourceRequestedFilter(uri, (COREWEBVIEW2_WEB_RESOURCE_CONTEXT) ResourceContext);
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

    public void RemoveWebResourceRequestedFilter(
      string uri,
      CoreWebView2WebResourceContext ResourceContext)
    {
      try
      {
        // ISSUE: reference to a compiler-generated method
        this._nativeICoreWebView2.RemoveWebResourceRequestedFilter(uri, (COREWEBVIEW2_WEB_RESOURCE_CONTEXT) ResourceContext);
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

    public CoreWebView2CookieManager CookieManager
    {
      get
      {
        try
        {
          return this._nativeICoreWebView2_2.CookieManager == null ? (CoreWebView2CookieManager) null : new CoreWebView2CookieManager((object) this._nativeICoreWebView2_2.CookieManager);
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

    public CoreWebView2Environment Environment
    {
      get
      {
        try
        {
          return this._nativeICoreWebView2_2.Environment == null ? (CoreWebView2Environment) null : new CoreWebView2Environment((object) this._nativeICoreWebView2_2.Environment);
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

    public event EventHandler<CoreWebView2WebResourceResponseReceivedEventArgs> WebResourceResponseReceived
    {
      add
      {
        if (this.webResourceResponseReceived == null)
        {
          try
          {
            this._nativeICoreWebView2_2.add_WebResourceResponseReceived((ICoreWebView2WebResourceResponseReceivedEventHandler) new CoreWebView2WebResourceResponseReceivedEventHandler(new CoreWebView2WebResourceResponseReceivedEventHandler.CallbackType(this.OnWebResourceResponseReceived)), out this._webResourceResponseReceivedToken);
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
        this.webResourceResponseReceived += value;
      }
      remove
      {
        this.webResourceResponseReceived -= value;
        if (this.webResourceResponseReceived != null)
          return;
        try
        {
          this._nativeICoreWebView2_2.remove_WebResourceResponseReceived(this._webResourceResponseReceivedToken);
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

    internal void OnWebResourceResponseReceived(
      CoreWebView2WebResourceResponseReceivedEventArgs args)
    {
      EventHandler<CoreWebView2WebResourceResponseReceivedEventArgs> responseReceived = this.webResourceResponseReceived;
      if (responseReceived == null)
        return;
      responseReceived((object) this, args);
    }

    public event EventHandler<CoreWebView2DOMContentLoadedEventArgs> DOMContentLoaded
    {
      add
      {
        if (this.dOMContentLoaded == null)
        {
          try
          {
            this._nativeICoreWebView2_2.add_DOMContentLoaded((ICoreWebView2DOMContentLoadedEventHandler) new CoreWebView2DOMContentLoadedEventHandler(new CoreWebView2DOMContentLoadedEventHandler.CallbackType(this.OnDOMContentLoaded)), out this._dOMContentLoadedToken);
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
          this._nativeICoreWebView2_2.remove_DOMContentLoaded(this._dOMContentLoadedToken);
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

    public void NavigateWithWebResourceRequest(CoreWebView2WebResourceRequest Request)
    {
      try
      {
        // ISSUE: reference to a compiler-generated method
        this._nativeICoreWebView2_2.NavigateWithWebResourceRequest(Request._nativeICoreWebView2WebResourceRequest);
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

    public bool IsSuspended
    {
      get
      {
        try
        {
          return this._nativeICoreWebView2_3.IsSuspended != 0;
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

    public async Task<bool> TrySuspendAsync()
    {
      CoreWebView2TrySuspendCompletedHandler handler;
      try
      {
        handler = new CoreWebView2TrySuspendCompletedHandler();
        // ISSUE: reference to a compiler-generated method
        this._nativeICoreWebView2_3.TrySuspend((ICoreWebView2TrySuspendCompletedHandler) handler);
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
      int num = await handler ? 1 : 0;
      Marshal.ThrowExceptionForHR(handler.errCode);
      bool isSuccessful = handler.isSuccessful;
      handler = (CoreWebView2TrySuspendCompletedHandler) null;
      return isSuccessful;
    }

    public void Resume()
    {
      try
      {
        // ISSUE: reference to a compiler-generated method
        this._nativeICoreWebView2_3.Resume();
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

    public void SetVirtualHostNameToFolderMapping(
      string hostName,
      string folderPath,
      CoreWebView2HostResourceAccessKind accessKind)
    {
      try
      {
        // ISSUE: reference to a compiler-generated method
        this._nativeICoreWebView2_3.SetVirtualHostNameToFolderMapping(hostName, folderPath, (COREWEBVIEW2_HOST_RESOURCE_ACCESS_KIND) accessKind);
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

    public void ClearVirtualHostNameToFolderMapping(string hostName)
    {
      try
      {
        // ISSUE: reference to a compiler-generated method
        this._nativeICoreWebView2_3.ClearVirtualHostNameToFolderMapping(hostName);
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

    public event EventHandler<CoreWebView2FrameCreatedEventArgs> FrameCreated
    {
      add
      {
        if (this.frameCreated == null)
        {
          try
          {
            this._nativeICoreWebView2_4.add_FrameCreated((ICoreWebView2FrameCreatedEventHandler) new CoreWebView2FrameCreatedEventHandler(new CoreWebView2FrameCreatedEventHandler.CallbackType(this.OnFrameCreated)), out this._frameCreatedToken);
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
        this.frameCreated += value;
      }
      remove
      {
        this.frameCreated -= value;
        if (this.frameCreated != null)
          return;
        try
        {
          this._nativeICoreWebView2_4.remove_FrameCreated(this._frameCreatedToken);
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

    internal void OnFrameCreated(CoreWebView2FrameCreatedEventArgs args)
    {
      EventHandler<CoreWebView2FrameCreatedEventArgs> frameCreated = this.frameCreated;
      if (frameCreated == null)
        return;
      frameCreated((object) this, args);
    }

    public event EventHandler<CoreWebView2DownloadStartingEventArgs> DownloadStarting
    {
      add
      {
        if (this.downloadStarting == null)
        {
          try
          {
            this._nativeICoreWebView2_4.add_DownloadStarting((ICoreWebView2DownloadStartingEventHandler) new CoreWebView2DownloadStartingEventHandler(new CoreWebView2DownloadStartingEventHandler.CallbackType(this.OnDownloadStarting)), out this._downloadStartingToken);
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
        this.downloadStarting += value;
      }
      remove
      {
        this.downloadStarting -= value;
        if (this.downloadStarting != null)
          return;
        try
        {
          this._nativeICoreWebView2_4.remove_DownloadStarting(this._downloadStartingToken);
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

    internal void OnDownloadStarting(CoreWebView2DownloadStartingEventArgs args)
    {
      EventHandler<CoreWebView2DownloadStartingEventArgs> downloadStarting = this.downloadStarting;
      if (downloadStarting == null)
        return;
      downloadStarting((object) this, args);
    }

    public event EventHandler<CoreWebView2ClientCertificateRequestedEventArgs> ClientCertificateRequested
    {
      add
      {
        if (this.clientCertificateRequested == null)
        {
          try
          {
            this._nativeICoreWebView2_5.add_ClientCertificateRequested((ICoreWebView2ClientCertificateRequestedEventHandler) new CoreWebView2ClientCertificateRequestedEventHandler(new CoreWebView2ClientCertificateRequestedEventHandler.CallbackType(this.OnClientCertificateRequested)), out this._clientCertificateRequestedToken);
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
        this.clientCertificateRequested += value;
      }
      remove
      {
        this.clientCertificateRequested -= value;
        if (this.clientCertificateRequested != null)
          return;
        try
        {
          this._nativeICoreWebView2_5.remove_ClientCertificateRequested(this._clientCertificateRequestedToken);
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

    internal void OnClientCertificateRequested(
      CoreWebView2ClientCertificateRequestedEventArgs args)
    {
      EventHandler<CoreWebView2ClientCertificateRequestedEventArgs> certificateRequested = this.clientCertificateRequested;
      if (certificateRequested == null)
        return;
      certificateRequested((object) this, args);
    }

    public void OpenTaskManagerWindow()
    {
      try
      {
        // ISSUE: reference to a compiler-generated method
        this._nativeICoreWebView2_6.OpenTaskManagerWindow();
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

    public bool IsMuted
    {
      get
      {
        try
        {
          return this._nativeICoreWebView2_8.IsMuted != 0;
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
          this._nativeICoreWebView2_8.IsMuted = value ? 1 : 0;
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

    public bool IsDocumentPlayingAudio
    {
      get
      {
        try
        {
          return this._nativeICoreWebView2_8.IsDocumentPlayingAudio != 0;
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

    public event EventHandler<object> IsMutedChanged
    {
      add
      {
        if (this.isMutedChanged == null)
        {
          try
          {
            this._nativeICoreWebView2_8.add_IsMutedChanged((ICoreWebView2IsMutedChangedEventHandler) new CoreWebView2IsMutedChangedEventHandler(new CoreWebView2IsMutedChangedEventHandler.CallbackType(this.OnIsMutedChanged)), out this._isMutedChangedToken);
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
        this.isMutedChanged += value;
      }
      remove
      {
        this.isMutedChanged -= value;
        if (this.isMutedChanged != null)
          return;
        try
        {
          this._nativeICoreWebView2_8.remove_IsMutedChanged(this._isMutedChangedToken);
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

    internal void OnIsMutedChanged(object args)
    {
      EventHandler<object> isMutedChanged = this.isMutedChanged;
      if (isMutedChanged == null)
        return;
      isMutedChanged((object) this, args);
    }

    public event EventHandler<object> IsDocumentPlayingAudioChanged
    {
      add
      {
        if (this.isDocumentPlayingAudioChanged == null)
        {
          try
          {
            this._nativeICoreWebView2_8.add_IsDocumentPlayingAudioChanged((ICoreWebView2IsDocumentPlayingAudioChangedEventHandler) new CoreWebView2IsDocumentPlayingAudioChangedEventHandler(new CoreWebView2IsDocumentPlayingAudioChangedEventHandler.CallbackType(this.OnIsDocumentPlayingAudioChanged)), out this._isDocumentPlayingAudioChangedToken);
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
        this.isDocumentPlayingAudioChanged += value;
      }
      remove
      {
        this.isDocumentPlayingAudioChanged -= value;
        if (this.isDocumentPlayingAudioChanged != null)
          return;
        try
        {
          this._nativeICoreWebView2_8.remove_IsDocumentPlayingAudioChanged(this._isDocumentPlayingAudioChangedToken);
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

    internal void OnIsDocumentPlayingAudioChanged(object args)
    {
      EventHandler<object> playingAudioChanged = this.isDocumentPlayingAudioChanged;
      if (playingAudioChanged == null)
        return;
      playingAudioChanged((object) this, args);
    }

    public bool IsDefaultDownloadDialogOpen
    {
      get
      {
        try
        {
          return this._nativeICoreWebView2_9.IsDefaultDownloadDialogOpen != 0;
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

    public CoreWebView2DefaultDownloadDialogCornerAlignment DefaultDownloadDialogCornerAlignment
    {
      get
      {
        try
        {
          return (CoreWebView2DefaultDownloadDialogCornerAlignment) this._nativeICoreWebView2_9.DefaultDownloadDialogCornerAlignment;
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
          this._nativeICoreWebView2_9.DefaultDownloadDialogCornerAlignment = (COREWEBVIEW2_DEFAULT_DOWNLOAD_DIALOG_CORNER_ALIGNMENT) value;
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

    public Point DefaultDownloadDialogMargin
    {
      get
      {
        try
        {
          return COMDotNetTypeConverter.PointCOMToNet(this._nativeICoreWebView2_9.DefaultDownloadDialogMargin);
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
          this._nativeICoreWebView2_9.DefaultDownloadDialogMargin = COMDotNetTypeConverter.PointNetToCOM(value);
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

    public event EventHandler<object> IsDefaultDownloadDialogOpenChanged
    {
      add
      {
        if (this.isDefaultDownloadDialogOpenChanged == null)
        {
          try
          {
            this._nativeICoreWebView2_9.add_IsDefaultDownloadDialogOpenChanged((ICoreWebView2IsDefaultDownloadDialogOpenChangedEventHandler) new CoreWebView2IsDefaultDownloadDialogOpenChangedEventHandler(new CoreWebView2IsDefaultDownloadDialogOpenChangedEventHandler.CallbackType(this.OnIsDefaultDownloadDialogOpenChanged)), out this._isDefaultDownloadDialogOpenChangedToken);
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
        this.isDefaultDownloadDialogOpenChanged += value;
      }
      remove
      {
        this.isDefaultDownloadDialogOpenChanged -= value;
        if (this.isDefaultDownloadDialogOpenChanged != null)
          return;
        try
        {
          this._nativeICoreWebView2_9.remove_IsDefaultDownloadDialogOpenChanged(this._isDefaultDownloadDialogOpenChangedToken);
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

    internal void OnIsDefaultDownloadDialogOpenChanged(object args)
    {
      EventHandler<object> dialogOpenChanged = this.isDefaultDownloadDialogOpenChanged;
      if (dialogOpenChanged == null)
        return;
      dialogOpenChanged((object) this, args);
    }

    public void OpenDefaultDownloadDialog()
    {
      try
      {
        // ISSUE: reference to a compiler-generated method
        this._nativeICoreWebView2_9.OpenDefaultDownloadDialog();
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

    public void CloseDefaultDownloadDialog()
    {
      try
      {
        // ISSUE: reference to a compiler-generated method
        this._nativeICoreWebView2_9.CloseDefaultDownloadDialog();
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

    public event EventHandler<CoreWebView2BasicAuthenticationRequestedEventArgs> BasicAuthenticationRequested
    {
      add
      {
        if (this.basicAuthenticationRequested == null)
        {
          try
          {
            this._nativeICoreWebView2_10.add_BasicAuthenticationRequested((ICoreWebView2BasicAuthenticationRequestedEventHandler) new CoreWebView2BasicAuthenticationRequestedEventHandler(new CoreWebView2BasicAuthenticationRequestedEventHandler.CallbackType(this.OnBasicAuthenticationRequested)), out this._basicAuthenticationRequestedToken);
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
        this.basicAuthenticationRequested += value;
      }
      remove
      {
        this.basicAuthenticationRequested -= value;
        if (this.basicAuthenticationRequested != null)
          return;
        try
        {
          this._nativeICoreWebView2_10.remove_BasicAuthenticationRequested(this._basicAuthenticationRequestedToken);
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

    internal void OnBasicAuthenticationRequested(
      CoreWebView2BasicAuthenticationRequestedEventArgs args)
    {
      EventHandler<CoreWebView2BasicAuthenticationRequestedEventArgs> authenticationRequested = this.basicAuthenticationRequested;
      if (authenticationRequested == null)
        return;
      authenticationRequested((object) this, args);
    }

    public event EventHandler<CoreWebView2ContextMenuRequestedEventArgs> ContextMenuRequested
    {
      add
      {
        if (this.contextMenuRequested == null)
        {
          try
          {
            this._nativeICoreWebView2_11.add_ContextMenuRequested((ICoreWebView2ContextMenuRequestedEventHandler) new CoreWebView2ContextMenuRequestedEventHandler(new CoreWebView2ContextMenuRequestedEventHandler.CallbackType(this.OnContextMenuRequested)), out this._contextMenuRequestedToken);
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
        this.contextMenuRequested += value;
      }
      remove
      {
        this.contextMenuRequested -= value;
        if (this.contextMenuRequested != null)
          return;
        try
        {
          this._nativeICoreWebView2_11.remove_ContextMenuRequested(this._contextMenuRequestedToken);
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

    internal void OnContextMenuRequested(CoreWebView2ContextMenuRequestedEventArgs args)
    {
      EventHandler<CoreWebView2ContextMenuRequestedEventArgs> contextMenuRequested = this.contextMenuRequested;
      if (contextMenuRequested == null)
        return;
      contextMenuRequested((object) this, args);
    }

    public async Task<string> CallDevToolsProtocolMethodForSessionAsync(
      string sessionId,
      string methodName,
      string parametersAsJson)
    {
      CoreWebView2CallDevToolsProtocolMethodCompletedHandler handler;
      try
      {
        handler = new CoreWebView2CallDevToolsProtocolMethodCompletedHandler();
        // ISSUE: reference to a compiler-generated method
        this._nativeICoreWebView2_11.CallDevToolsProtocolMethodForSession(sessionId, methodName, parametersAsJson, (ICoreWebView2CallDevToolsProtocolMethodCompletedHandler) handler);
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
      string returnObjectAsJson = handler.returnObjectAsJson;
      handler = (CoreWebView2CallDevToolsProtocolMethodCompletedHandler) null;
      return returnObjectAsJson;
    }

    public string StatusBarText
    {
      get
      {
        try
        {
          return this._nativeICoreWebView2_12.StatusBarText;
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

    public event EventHandler<object> StatusBarTextChanged
    {
      add
      {
        if (this.statusBarTextChanged == null)
        {
          try
          {
            this._nativeICoreWebView2_12.add_StatusBarTextChanged((ICoreWebView2StatusBarTextChangedEventHandler) new CoreWebView2StatusBarTextChangedEventHandler(new CoreWebView2StatusBarTextChangedEventHandler.CallbackType(this.OnStatusBarTextChanged)), out this._statusBarTextChangedToken);
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
        this.statusBarTextChanged += value;
      }
      remove
      {
        this.statusBarTextChanged -= value;
        if (this.statusBarTextChanged != null)
          return;
        try
        {
          this._nativeICoreWebView2_12.remove_StatusBarTextChanged(this._statusBarTextChangedToken);
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

    internal void OnStatusBarTextChanged(object args)
    {
      EventHandler<object> statusBarTextChanged = this.statusBarTextChanged;
      if (statusBarTextChanged == null)
        return;
      statusBarTextChanged((object) this, args);
    }

    public CoreWebView2Profile Profile
    {
      get
      {
        try
        {
          return this._nativeICoreWebView2_13.Profile == null ? (CoreWebView2Profile) null : new CoreWebView2Profile((object) this._nativeICoreWebView2_13.Profile);
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

    public event EventHandler<CoreWebView2ServerCertificateErrorDetectedEventArgs> ServerCertificateErrorDetected
    {
      add
      {
        if (this.serverCertificateErrorDetected == null)
        {
          try
          {
            this._nativeICoreWebView2_14.add_ServerCertificateErrorDetected((ICoreWebView2ServerCertificateErrorDetectedEventHandler) new CoreWebView2ServerCertificateErrorDetectedEventHandler(new CoreWebView2ServerCertificateErrorDetectedEventHandler.CallbackType(this.OnServerCertificateErrorDetected)), out this._serverCertificateErrorDetectedToken);
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
        this.serverCertificateErrorDetected += value;
      }
      remove
      {
        this.serverCertificateErrorDetected -= value;
        if (this.serverCertificateErrorDetected != null)
          return;
        try
        {
          this._nativeICoreWebView2_14.remove_ServerCertificateErrorDetected(this._serverCertificateErrorDetectedToken);
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

    internal void OnServerCertificateErrorDetected(
      CoreWebView2ServerCertificateErrorDetectedEventArgs args)
    {
      EventHandler<CoreWebView2ServerCertificateErrorDetectedEventArgs> certificateErrorDetected = this.serverCertificateErrorDetected;
      if (certificateErrorDetected == null)
        return;
      certificateErrorDetected((object) this, args);
    }

    public async Task ClearServerCertificateErrorActionsAsync()
    {
      CoreWebView2ClearServerCertificateErrorActionsCompletedHandler handler;
      try
      {
        handler = new CoreWebView2ClearServerCertificateErrorActionsCompletedHandler();
        // ISSUE: reference to a compiler-generated method
        this._nativeICoreWebView2_14.ClearServerCertificateErrorActions((ICoreWebView2ClearServerCertificateErrorActionsCompletedHandler) handler);
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
      handler = (CoreWebView2ClearServerCertificateErrorActionsCompletedHandler) null;
    }

    public string FaviconUri
    {
      get
      {
        try
        {
          return this._nativeICoreWebView2_15.FaviconUri;
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

    public event EventHandler<object> FaviconChanged
    {
      add
      {
        if (this.faviconChanged == null)
        {
          try
          {
            this._nativeICoreWebView2_15.add_FaviconChanged((ICoreWebView2FaviconChangedEventHandler) new CoreWebView2FaviconChangedEventHandler(new CoreWebView2FaviconChangedEventHandler.CallbackType(this.OnFaviconChanged)), out this._faviconChangedToken);
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
        this.faviconChanged += value;
      }
      remove
      {
        this.faviconChanged -= value;
        if (this.faviconChanged != null)
          return;
        try
        {
          this._nativeICoreWebView2_15.remove_FaviconChanged(this._faviconChangedToken);
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

    internal void OnFaviconChanged(object args)
    {
      EventHandler<object> faviconChanged = this.faviconChanged;
      if (faviconChanged == null)
        return;
      faviconChanged((object) this, args);
    }

    public async Task<Stream> GetFaviconAsync(CoreWebView2FaviconImageFormat format)
    {
      CoreWebView2GetFaviconCompletedHandler handler;
      try
      {
        handler = new CoreWebView2GetFaviconCompletedHandler();
        // ISSUE: reference to a compiler-generated method
        this._nativeICoreWebView2_15.GetFavicon((COREWEBVIEW2_FAVICON_IMAGE_FORMAT) format, (ICoreWebView2GetFaviconCompletedHandler) handler);
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
      Stream stream = await handler;
      Marshal.ThrowExceptionForHR(handler.errCode);
      Stream faviconStream = handler.faviconStream;
      handler = (CoreWebView2GetFaviconCompletedHandler) null;
      return faviconStream;
    }

    public async Task<CoreWebView2PrintStatus> PrintAsync(CoreWebView2PrintSettings printSettings)
    {
      CoreWebView2PrintCompletedHandler handler;
      try
      {
        handler = new CoreWebView2PrintCompletedHandler();
        // ISSUE: reference to a compiler-generated method
        this._nativeICoreWebView2_16.Print(printSettings == null ? (ICoreWebView2PrintSettings) null : printSettings._nativeICoreWebView2PrintSettings, (ICoreWebView2PrintCompletedHandler) handler);
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
      int num = (int) await handler;
      Marshal.ThrowExceptionForHR(handler.errCode);
      CoreWebView2PrintStatus printStatus = handler.printStatus;
      handler = (CoreWebView2PrintCompletedHandler) null;
      return printStatus;
    }

    public void ShowPrintUI(CoreWebView2PrintDialogKind printDialogKind)
    {
      try
      {
        // ISSUE: reference to a compiler-generated method
        this._nativeICoreWebView2_16.ShowPrintUI((COREWEBVIEW2_PRINT_DIALOG_KIND) printDialogKind);
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

    public async Task<Stream> PrintToPdfStreamAsync(CoreWebView2PrintSettings printSettings)
    {
      CoreWebView2PrintToPdfStreamCompletedHandler handler;
      try
      {
        handler = new CoreWebView2PrintToPdfStreamCompletedHandler();
        // ISSUE: reference to a compiler-generated method
        this._nativeICoreWebView2_16.PrintToPdfStream(printSettings == null ? (ICoreWebView2PrintSettings) null : printSettings._nativeICoreWebView2PrintSettings, (ICoreWebView2PrintToPdfStreamCompletedHandler) handler);
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
      Stream stream = await handler;
      Marshal.ThrowExceptionForHR(handler.errCode);
      Stream pdfStream = handler.pdfStream;
      handler = (CoreWebView2PrintToPdfStreamCompletedHandler) null;
      return pdfStream;
    }

    public void PostSharedBufferToScript(
      CoreWebView2SharedBuffer sharedBuffer,
      CoreWebView2SharedBufferAccess access,
      string additionalDataAsJson)
    {
      try
      {
        // ISSUE: reference to a compiler-generated method
        this._nativeICoreWebView2_17.PostSharedBufferToScript(sharedBuffer._nativeICoreWebView2SharedBuffer, (COREWEBVIEW2_SHARED_BUFFER_ACCESS) access, additionalDataAsJson);
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

    public event EventHandler<CoreWebView2LaunchingExternalUriSchemeEventArgs> LaunchingExternalUriScheme
    {
      add
      {
        if (this.launchingExternalUriScheme == null)
        {
          try
          {
            this._nativeICoreWebView2_18.add_LaunchingExternalUriScheme((ICoreWebView2LaunchingExternalUriSchemeEventHandler) new CoreWebView2LaunchingExternalUriSchemeEventHandler(new CoreWebView2LaunchingExternalUriSchemeEventHandler.CallbackType(this.OnLaunchingExternalUriScheme)), out this._launchingExternalUriSchemeToken);
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
        this.launchingExternalUriScheme += value;
      }
      remove
      {
        this.launchingExternalUriScheme -= value;
        if (this.launchingExternalUriScheme != null)
          return;
        try
        {
          this._nativeICoreWebView2_18.remove_LaunchingExternalUriScheme(this._launchingExternalUriSchemeToken);
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

    internal void OnLaunchingExternalUriScheme(
      CoreWebView2LaunchingExternalUriSchemeEventArgs args)
    {
      EventHandler<CoreWebView2LaunchingExternalUriSchemeEventArgs> externalUriScheme = this.launchingExternalUriScheme;
      if (externalUriScheme == null)
        return;
      externalUriScheme((object) this, args);
    }

    public CoreWebView2MemoryUsageTargetLevel MemoryUsageTargetLevel
    {
      get
      {
        try
        {
          return (CoreWebView2MemoryUsageTargetLevel) this._nativeICoreWebView2_19.MemoryUsageTargetLevel;
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
          this._nativeICoreWebView2_19.MemoryUsageTargetLevel = (COREWEBVIEW2_MEMORY_USAGE_TARGET_LEVEL) value;
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

    internal void AddHostObjectHelper(CoreWebView2PrivateHostObjectHelper helper)
    {
      try
      {
        // ISSUE: reference to a compiler-generated method
        this._nativeICoreWebView2PrivatePartial.AddHostObjectHelper(helper._nativeICoreWebView2PrivateHostObjectHelper);
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
