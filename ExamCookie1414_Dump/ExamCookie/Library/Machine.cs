// Decompiled with JetBrains decompiler
// Type: ExamCookie.Library.Machine
// Assembly: ExamCookie.WinClient, Version=1.4.1.4, Culture=neutral, PublicKeyToken=null
// MVID: E12BE1F8-B6E0-4BF5-B308-166F0E938C4B
// Assembly location: C:\Users\oskar\Downloads\ExamCookie1414.WinClient.exe

using System;

#nullable disable
namespace ExamCookie.Library
{
  [Serializable]
  public class Machine
  {
    public int SignInId;
    public DateTime TimeStamp;
    public string Data;

    public Machine()
    {
      this.SignInId = 0;
      this.TimeStamp = DateTime.MinValue;
      this.Data = "";
    }

    public Machine(int signInId, DateTime timeStamp, string data)
    {
      this.SignInId = 0;
      this.TimeStamp = DateTime.MinValue;
      this.Data = "";
      this.SignInId = signInId;
      this.TimeStamp = timeStamp;
      this.Data = data;
    }
  }
}
