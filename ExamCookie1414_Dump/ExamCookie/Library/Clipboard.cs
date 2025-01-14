// Decompiled with JetBrains decompiler
// Type: ExamCookie.Library.Clipboard
// Assembly: ExamCookie.WinClient, Version=1.4.1.4, Culture=neutral, PublicKeyToken=null
// MVID: E12BE1F8-B6E0-4BF5-B308-166F0E938C4B
// Assembly location: C:\Users\oskar\Downloads\ExamCookie1414.WinClient.exe

using System;

#nullable disable
namespace ExamCookie.Library
{
  [Serializable]
  public class Clipboard
  {
    public int SignInId;
    public DateTime TimeStamp;
    public eDataFormat Type;
    public byte[] Data;

    public Clipboard()
    {
      this.SignInId = 0;
      this.TimeStamp = DateTime.MinValue;
      this.Type = eDataFormat.NONE;
      this.Data = (byte[]) null;
    }

    public Clipboard(int signInId, DateTime timeStamp, eDataFormat type, byte[] data)
    {
      this.SignInId = 0;
      this.TimeStamp = DateTime.MinValue;
      this.Type = eDataFormat.NONE;
      this.Data = (byte[]) null;
      this.SignInId = signInId;
      this.TimeStamp = timeStamp;
      this.Type = type;
      this.Data = data;
    }

    public override string ToString()
    {
      return string.Format("{0} > {1}", (object) this.TimeStamp.ToString(), (object) this.Type.ToString());
    }
  }
}
