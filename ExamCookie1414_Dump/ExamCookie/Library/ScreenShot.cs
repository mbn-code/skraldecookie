// Decompiled with JetBrains decompiler
// Type: ExamCookie.Library.ScreenShot
// Assembly: ExamCookie.WinClient, Version=1.4.1.4, Culture=neutral, PublicKeyToken=null
// MVID: E12BE1F8-B6E0-4BF5-B308-166F0E938C4B
// Assembly location: C:\Users\oskar\Downloads\ExamCookie1414.WinClient.exe

using System;

#nullable disable
namespace ExamCookie.Library
{
  [Serializable]
  public class ScreenShot
  {
    public int SignInId;
    public DateTime TimeStamp;
    public byte[] Data;

    public ScreenShot()
    {
      this.SignInId = 0;
      this.TimeStamp = DateTime.MinValue;
      this.Data = (byte[]) null;
    }

    public ScreenShot(int signInId, DateTime timeStamp, byte[] data)
    {
      this.SignInId = 0;
      this.TimeStamp = DateTime.MinValue;
      this.Data = (byte[]) null;
      this.SignInId = signInId;
      this.TimeStamp = timeStamp;
      this.Data = data;
    }

    public override string ToString()
    {
      return string.Format("{0} > IMAGE", (object) this.TimeStamp.ToString());
    }
  }
}
