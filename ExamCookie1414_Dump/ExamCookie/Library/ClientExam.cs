// Decompiled with JetBrains decompiler
// Type: ExamCookie.Library.ClientExam
// Assembly: ExamCookie.WinClient, Version=1.4.1.4, Culture=neutral, PublicKeyToken=null
// MVID: E12BE1F8-B6E0-4BF5-B308-166F0E938C4B
// Assembly location: C:\Users\oskar\Downloads\ExamCookie1414.WinClient.exe

using System;

#nullable disable
namespace ExamCookie.Library
{
  [Serializable]
  public class ClientExam
  {
    public int Id;
    public int Status;
    public string Code;
    public string Description;
    public DateTime TimeBegin;
    public DateTime TimeEnd;
    public int TimeEndExt;
    public int StudentTimeExt;
    public int TimeExt;

    public ClientExam()
    {
      this.Id = 0;
      this.Status = 0;
      this.Code = "";
      this.Description = "";
      this.TimeBegin = DateTime.MinValue;
      this.TimeEnd = DateTime.MinValue;
      this.TimeEndExt = 0;
      this.StudentTimeExt = 0;
      this.TimeExt = 0;
    }
  }
}
