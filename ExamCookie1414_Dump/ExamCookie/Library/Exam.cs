// Decompiled with JetBrains decompiler
// Type: ExamCookie.Library.Exam
// Assembly: ExamCookie.WinClient, Version=1.4.1.4, Culture=neutral, PublicKeyToken=null
// MVID: E12BE1F8-B6E0-4BF5-B308-166F0E938C4B
// Assembly location: C:\Users\oskar\Downloads\ExamCookie1414.WinClient.exe

using System;

#nullable disable
namespace ExamCookie.Library
{
  [Serializable]
  public class Exam
  {
    [NonSerialized]
    public int Id;
    public int Status;
    public string Code;
    public string Description;
    public DateTime TimeBegin;
    public DateTime TimeEnd;

    public Exam()
    {
      this.Id = 0;
      this.Status = 0;
      this.Code = "";
      this.Description = "";
      this.TimeBegin = DateTime.MinValue;
      this.TimeEnd = DateTime.MinValue;
    }

    public Exam(
      int id,
      int status,
      string code,
      string description,
      DateTime timeBegin,
      DateTime timeEnd)
    {
      this.Id = 0;
      this.Status = 0;
      this.Code = "";
      this.Description = "";
      this.TimeBegin = DateTime.MinValue;
      this.TimeEnd = DateTime.MinValue;
      this.Id = id;
      this.Status = status;
      this.Code = code;
      this.Description = description;
      this.TimeBegin = timeBegin;
      this.TimeEnd = timeEnd;
    }
  }
}
