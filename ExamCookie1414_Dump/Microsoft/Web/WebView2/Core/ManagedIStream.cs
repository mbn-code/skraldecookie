// Decompiled with JetBrains decompiler
// Type: Microsoft.Web.WebView2.Core.ManagedIStream
// Assembly: ExamCookie.WinClient, Version=1.4.1.4, Culture=neutral, PublicKeyToken=null
// MVID: E12BE1F8-B6E0-4BF5-B308-166F0E938C4B
// Assembly location: C:\Users\oskar\Downloads\ExamCookie1414.WinClient.exe

using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Security;

#nullable disable
namespace Microsoft.Web.WebView2.Core
{
  internal class ManagedIStream : IStream
  {
    private Stream _ioStream;
    private const int STGTY_STREAM = 2;
    private const int STGM_READ = 0;
    private const int STGM_WRITE = 1;
    private const int STGM_READWRITE = 2;
    private const int STREAM_SEEK_SET = 0;
    private const int STREAM_SEEK_CUR = 1;
    private const int STREAM_SEEK_END = 2;
    private const int STATFLAG_DEFAULT = 0;
    private const int STATFLAG_NONAME = 1;
    private const int STATFLAG_NOOPEN = 2;

    internal ManagedIStream(Stream ioStream)
    {
      this._ioStream = ioStream != null ? ioStream : throw new ArgumentNullException(nameof (ioStream));
    }

    [SecurityCritical]
    void IStream.Read(byte[] buffer, int bufferSize, IntPtr bytesReadPtr)
    {
      int val = this._ioStream.Read(buffer, 0, bufferSize);
      if (!(bytesReadPtr != IntPtr.Zero))
        return;
      Marshal.WriteInt32(bytesReadPtr, val);
    }

    [SecurityCritical]
    void IStream.Seek(long offset, int origin, IntPtr newPositionPtr)
    {
      SeekOrigin origin1;
      switch (origin)
      {
        case 0:
          origin1 = SeekOrigin.Begin;
          break;
        case 1:
          origin1 = SeekOrigin.Current;
          break;
        case 2:
          origin1 = SeekOrigin.End;
          break;
        default:
          throw new ArgumentOutOfRangeException(nameof (origin));
      }
      long val = this._ioStream.Seek(offset, origin1);
      if (!(newPositionPtr != IntPtr.Zero))
        return;
      Marshal.WriteInt64(newPositionPtr, val);
    }

    void IStream.SetSize(long libNewSize) => this._ioStream.SetLength(libNewSize);

    void IStream.Stat(out System.Runtime.InteropServices.ComTypes.STATSTG streamStats, int grfStatFlag)
    {
      streamStats = new System.Runtime.InteropServices.ComTypes.STATSTG();
      streamStats.type = 2;
      streamStats.cbSize = this._ioStream.Length;
      streamStats.grfMode = 0;
      if (this._ioStream.CanRead && this._ioStream.CanWrite)
        streamStats.grfMode |= 2;
      else if (this._ioStream.CanRead)
      {
        streamStats.grfMode |= 0;
      }
      else
      {
        if (!this._ioStream.CanWrite)
          throw new IOException();
        streamStats.grfMode |= 1;
      }
    }

    [SecurityCritical]
    void IStream.Write(byte[] buffer, int bufferSize, IntPtr bytesWrittenPtr)
    {
      this._ioStream.Write(buffer, 0, bufferSize);
      if (!(bytesWrittenPtr != IntPtr.Zero))
        return;
      Marshal.WriteInt32(bytesWrittenPtr, bufferSize);
    }

    void IStream.Clone(out IStream streamCopy)
    {
      streamCopy = (IStream) null;
      throw new NotSupportedException();
    }

    void IStream.CopyTo(
      IStream targetStream,
      long bufferSize,
      IntPtr buffer,
      IntPtr bytesWrittenPtr)
    {
      throw new NotSupportedException();
    }

    void IStream.Commit(int flags) => throw new NotSupportedException();

    void IStream.LockRegion(long offset, long byteCount, int lockType)
    {
      throw new NotSupportedException();
    }

    void IStream.Revert() => throw new NotSupportedException();

    void IStream.UnlockRegion(long offset, long byteCount, int lockType)
    {
      throw new NotSupportedException();
    }
  }
}
