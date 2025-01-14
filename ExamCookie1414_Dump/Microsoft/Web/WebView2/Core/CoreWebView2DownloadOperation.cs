// Decompiled with JetBrains decompiler
// Type: Microsoft.Web.WebView2.Core.CoreWebView2DownloadOperation
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
  public class CoreWebView2DownloadOperation
  {
    internal ICoreWebView2DownloadOperation _nativeICoreWebView2DownloadOperationValue;
    internal object _rawNative;
    private EventRegistrationToken _bytesReceivedChangedToken;
    private EventHandler<object> bytesReceivedChanged;
    private EventRegistrationToken _estimatedEndTimeChangedToken;
    private EventHandler<object> estimatedEndTimeChanged;
    private EventRegistrationToken _stateChangedToken;
    private EventHandler<object> stateChanged;

    public DateTime EstimatedEndTime
    {
      get => DateTime.Parse(this._nativeICoreWebView2DownloadOperation.EstimatedEndTime);
    }

    public ulong? TotalBytesToReceive
    {
      get
      {
        return this._nativeICoreWebView2DownloadOperation.TotalBytesToReceive < 0L ? new ulong?() : new ulong?((ulong) this._nativeICoreWebView2DownloadOperation.TotalBytesToReceive);
      }
    }

    internal ICoreWebView2DownloadOperation _nativeICoreWebView2DownloadOperation
    {
      get
      {
        if (this._nativeICoreWebView2DownloadOperationValue == null)
        {
          try
          {
            this._nativeICoreWebView2DownloadOperationValue = (ICoreWebView2DownloadOperation) this._rawNative;
          }
          catch (Exception ex)
          {
            throw new NotImplementedException("Unable to cast to Microsoft.Web.WebView2.Core.Raw.ICoreWebView2DownloadOperation.\nThis may happen if you are using an interface not supported by the version of the WebView2 Runtime you are using.\nFor instance, if you are using an experimental interface from an older SDK that has been modified or removed in a newer runtime.\nOr, if you are using a public interface from a newer SDK that wasn't implemented in an older runtime.\nFor more information about WebView2 versioning please visit the following: https://learn.microsoft.com/microsoft-edge/webview2/concepts/versioning", ex);
          }
        }
        return this._nativeICoreWebView2DownloadOperationValue;
      }
      set => this._nativeICoreWebView2DownloadOperationValue = value;
    }

    internal CoreWebView2DownloadOperation(object rawCoreWebView2DownloadOperation)
    {
      this._rawNative = rawCoreWebView2DownloadOperation;
    }

    public string Uri
    {
      get
      {
        try
        {
          return this._nativeICoreWebView2DownloadOperation.Uri;
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

    public string ContentDisposition
    {
      get
      {
        try
        {
          return this._nativeICoreWebView2DownloadOperation.ContentDisposition;
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

    public string MimeType
    {
      get
      {
        try
        {
          return this._nativeICoreWebView2DownloadOperation.MimeType;
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

    public long BytesReceived
    {
      get
      {
        try
        {
          return this._nativeICoreWebView2DownloadOperation.BytesReceived;
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

    public string ResultFilePath
    {
      get
      {
        try
        {
          return this._nativeICoreWebView2DownloadOperation.ResultFilePath;
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

    public CoreWebView2DownloadState State
    {
      get
      {
        try
        {
          return (CoreWebView2DownloadState) this._nativeICoreWebView2DownloadOperation.State;
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

    public CoreWebView2DownloadInterruptReason InterruptReason
    {
      get
      {
        try
        {
          return (CoreWebView2DownloadInterruptReason) this._nativeICoreWebView2DownloadOperation.InterruptReason;
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

    public bool CanResume
    {
      get
      {
        try
        {
          return this._nativeICoreWebView2DownloadOperation.CanResume != 0;
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

    public event EventHandler<object> BytesReceivedChanged
    {
      add
      {
        if (this.bytesReceivedChanged == null)
        {
          try
          {
            this._nativeICoreWebView2DownloadOperation.add_BytesReceivedChanged((ICoreWebView2BytesReceivedChangedEventHandler) new CoreWebView2BytesReceivedChangedEventHandler(new CoreWebView2BytesReceivedChangedEventHandler.CallbackType(this.OnBytesReceivedChanged)), out this._bytesReceivedChangedToken);
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
        this.bytesReceivedChanged += value;
      }
      remove
      {
        this.bytesReceivedChanged -= value;
        if (this.bytesReceivedChanged != null)
          return;
        try
        {
          this._nativeICoreWebView2DownloadOperation.remove_BytesReceivedChanged(this._bytesReceivedChangedToken);
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

    internal void OnBytesReceivedChanged(object args)
    {
      EventHandler<object> bytesReceivedChanged = this.bytesReceivedChanged;
      if (bytesReceivedChanged == null)
        return;
      bytesReceivedChanged((object) this, args);
    }

    public event EventHandler<object> EstimatedEndTimeChanged
    {
      add
      {
        if (this.estimatedEndTimeChanged == null)
        {
          try
          {
            this._nativeICoreWebView2DownloadOperation.add_EstimatedEndTimeChanged((ICoreWebView2EstimatedEndTimeChangedEventHandler) new CoreWebView2EstimatedEndTimeChangedEventHandler(new CoreWebView2EstimatedEndTimeChangedEventHandler.CallbackType(this.OnEstimatedEndTimeChanged)), out this._estimatedEndTimeChangedToken);
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
        this.estimatedEndTimeChanged += value;
      }
      remove
      {
        this.estimatedEndTimeChanged -= value;
        if (this.estimatedEndTimeChanged != null)
          return;
        try
        {
          this._nativeICoreWebView2DownloadOperation.remove_EstimatedEndTimeChanged(this._estimatedEndTimeChangedToken);
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

    internal void OnEstimatedEndTimeChanged(object args)
    {
      EventHandler<object> estimatedEndTimeChanged = this.estimatedEndTimeChanged;
      if (estimatedEndTimeChanged == null)
        return;
      estimatedEndTimeChanged((object) this, args);
    }

    public event EventHandler<object> StateChanged
    {
      add
      {
        if (this.stateChanged == null)
        {
          try
          {
            this._nativeICoreWebView2DownloadOperation.add_StateChanged((ICoreWebView2StateChangedEventHandler) new CoreWebView2StateChangedEventHandler(new CoreWebView2StateChangedEventHandler.CallbackType(this.OnStateChanged)), out this._stateChangedToken);
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
        this.stateChanged += value;
      }
      remove
      {
        this.stateChanged -= value;
        if (this.stateChanged != null)
          return;
        try
        {
          this._nativeICoreWebView2DownloadOperation.remove_StateChanged(this._stateChangedToken);
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

    internal void OnStateChanged(object args)
    {
      EventHandler<object> stateChanged = this.stateChanged;
      if (stateChanged == null)
        return;
      stateChanged((object) this, args);
    }

    public void Cancel()
    {
      try
      {
        // ISSUE: reference to a compiler-generated method
        this._nativeICoreWebView2DownloadOperation.Cancel();
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

    public void Pause()
    {
      try
      {
        // ISSUE: reference to a compiler-generated method
        this._nativeICoreWebView2DownloadOperation.Pause();
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

    public void Resume()
    {
      try
      {
        // ISSUE: reference to a compiler-generated method
        this._nativeICoreWebView2DownloadOperation.Resume();
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
