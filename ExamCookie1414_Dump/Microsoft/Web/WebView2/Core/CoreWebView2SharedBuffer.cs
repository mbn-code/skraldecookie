// Decompiled with JetBrains decompiler
// Type: Microsoft.Web.WebView2.Core.CoreWebView2SharedBuffer
// Assembly: ExamCookie.WinClient, Version=1.4.1.4, Culture=neutral, PublicKeyToken=null
// MVID: E12BE1F8-B6E0-4BF5-B308-166F0E938C4B
// Assembly location: C:\Users\oskar\Downloads\ExamCookie1414.WinClient.exe

using Microsoft.Web.WebView2.Core.Raw;
using System;
using System.IO;
using System.Runtime.InteropServices;

#nullable disable
namespace Microsoft.Web.WebView2.Core
{
  [ComVisible(true)]
  public class CoreWebView2SharedBuffer : IDisposable
  {
    private bool _disposed;
    private CoreWebView2SharedBuffer.WebView2SharedBufferSafeHandle _safeFileMappingHandle;
    internal ICoreWebView2SharedBuffer _nativeICoreWebView2SharedBufferValue;
    internal object _rawNative;

    public void Dispose()
    {
      this.Dispose(true);
      GC.SuppressFinalize((object) this);
    }

    protected virtual void Dispose(bool disposing)
    {
      if (this._disposed)
        return;
      this._disposed = true;
      this.Close();
      if (!disposing || this._safeFileMappingHandle == null)
        return;
      this._safeFileMappingHandle.SetHandleAsInvalid();
      this._safeFileMappingHandle = (CoreWebView2SharedBuffer.WebView2SharedBufferSafeHandle) null;
    }

    internal IntPtr UnsafeFileMappingHandle
    {
      get
      {
        try
        {
          return this._nativeICoreWebView2SharedBuffer.FileMappingHandle;
        }
        catch (Exception ex)
        {
          return IntPtr.Zero;
        }
      }
    }

    public SafeHandle FileMappingHandle
    {
      get
      {
        if (!this._disposed && this._safeFileMappingHandle == null)
          this._safeFileMappingHandle = new CoreWebView2SharedBuffer.WebView2SharedBufferSafeHandle(this);
        return (SafeHandle) this._safeFileMappingHandle;
      }
    }

    internal ICoreWebView2SharedBuffer _nativeICoreWebView2SharedBuffer
    {
      get
      {
        if (this._nativeICoreWebView2SharedBufferValue == null)
        {
          try
          {
            this._nativeICoreWebView2SharedBufferValue = (ICoreWebView2SharedBuffer) this._rawNative;
          }
          catch (Exception ex)
          {
            throw new NotImplementedException("Unable to cast to Microsoft.Web.WebView2.Core.Raw.ICoreWebView2SharedBuffer.\nThis may happen if you are using an interface not supported by the version of the WebView2 Runtime you are using.\nFor instance, if you are using an experimental interface from an older SDK that has been modified or removed in a newer runtime.\nOr, if you are using a public interface from a newer SDK that wasn't implemented in an older runtime.\nFor more information about WebView2 versioning please visit the following: https://learn.microsoft.com/microsoft-edge/webview2/concepts/versioning", ex);
          }
        }
        return this._nativeICoreWebView2SharedBufferValue;
      }
      set => this._nativeICoreWebView2SharedBufferValue = value;
    }

    internal CoreWebView2SharedBuffer(object rawCoreWebView2SharedBuffer)
    {
      this._rawNative = rawCoreWebView2SharedBuffer;
    }

    public ulong Size
    {
      get
      {
        try
        {
          return this._nativeICoreWebView2SharedBuffer.Size;
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

    public IntPtr Buffer
    {
      get
      {
        try
        {
          return this._nativeICoreWebView2SharedBuffer.Buffer;
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

    public Stream OpenStream()
    {
      try
      {
        // ISSUE: reference to a compiler-generated method
        return (Stream) COMDotNetTypeConverter.StreamCOMToNet(this._nativeICoreWebView2SharedBuffer.OpenStream());
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
        this._nativeICoreWebView2SharedBuffer.Close();
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

    internal class WebView2SharedBufferSafeHandle : SafeHandle
    {
      protected CoreWebView2SharedBuffer _shared_buffer;

      public WebView2SharedBufferSafeHandle(CoreWebView2SharedBuffer shared_buffer)
        : base(IntPtr.Zero, false)
      {
        IntPtr fileMappingHandle = shared_buffer.UnsafeFileMappingHandle;
        if (!(fileMappingHandle != IntPtr.Zero))
          return;
        this.SetHandle(fileMappingHandle);
        this._shared_buffer = shared_buffer;
      }

      public override bool IsInvalid
      {
        get
        {
          return this.IsClosed || this._shared_buffer == null || this._shared_buffer.UnsafeFileMappingHandle == IntPtr.Zero;
        }
      }

      protected override bool ReleaseHandle()
      {
        this._shared_buffer = (CoreWebView2SharedBuffer) null;
        return true;
      }
    }
  }
}
