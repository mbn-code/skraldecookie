// Decompiled with JetBrains decompiler
// Type: Microsoft.Web.WebView2.Core.COMStreamWrapper
// Assembly: ExamCookie.WinClient, Version=1.4.1.4, Culture=neutral, PublicKeyToken=null
// MVID: E12BE1F8-B6E0-4BF5-B308-166F0E938C4B
// Assembly location: C:\Users\oskar\Downloads\ExamCookie1414.WinClient.exe

using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

#nullable disable
namespace Microsoft.Web.WebView2.Core
{
  internal class COMStreamWrapper : Stream
  {
    private IStream _istream;
    private IntPtr _mInt64;
    private long _size;

    public COMStreamWrapper(IStream source)
    {
      this._istream = source;
      this._mInt64 = Marshal.AllocCoTaskMem(8);
      try
      {
        this._size = this.Length;
        if (this._size <= 0L)
          return;
        GC.AddMemoryPressure(this._size);
      }
      catch (Exception ex)
      {
        string str = "Warning: The stream does not implement Stat properly, therefore it will not be possible to detect its size and report to .NET GC so it can be cleaned up. If it uses any unmanaged memory this may cause out of memory issues. Exception message: " + ex.Message;
      }
    }

    ~COMStreamWrapper()
    {
      this._istream = (IStream) null;
      Marshal.FreeCoTaskMem(this._mInt64);
      if (this._size <= 0L)
        return;
      GC.RemoveMemoryPressure(this._size);
      this._size = 0L;
    }

    public override bool CanRead => true;

    public override bool CanSeek => false;

    public override bool CanWrite => true;

    public override void Flush() => this._istream.Commit(0);

    public override long Length
    {
      get
      {
        System.Runtime.InteropServices.ComTypes.STATSTG pstatstg;
        this._istream.Stat(out pstatstg, 1);
        return pstatstg.cbSize;
      }
    }

    public override long Position
    {
      get => throw new NotSupportedException();
      set => throw new NotSupportedException();
    }

    public override int Read(byte[] buffer, int offset, int count)
    {
      if (offset != 0)
        throw new NotImplementedException();
      this._istream.Read(buffer, count, this._mInt64);
      return Marshal.ReadInt32(this._mInt64);
    }

    public override long Seek(long offset, SeekOrigin origin)
    {
      this._istream.Seek(offset, (int) origin, this._mInt64);
      return Marshal.ReadInt64(this._mInt64);
    }

    public override void SetLength(long value) => this._istream.SetSize(value);

    public override void Write(byte[] buffer, int offset, int count)
    {
      if (offset != 0)
        throw new NotImplementedException();
      this._istream.Write(buffer, count, IntPtr.Zero);
    }
  }
}
