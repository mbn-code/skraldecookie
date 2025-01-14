// Decompiled with JetBrains decompiler
// Type: ExamCookie.Library.ReportMatch
// Assembly: ExamCookie.WinClient, Version=1.4.1.4, Culture=neutral, PublicKeyToken=null
// MVID: E12BE1F8-B6E0-4BF5-B308-166F0E938C4B
// Assembly location: C:\Users\oskar\Downloads\ExamCookie1414.WinClient.exe

using System;
using System.Collections.Generic;

#nullable disable
namespace ExamCookie.Library
{
  [Serializable]
  public class ReportMatch
  {
    public int ExamId;
    public int StudentId;
    public List<Match> Matches;

    public ReportMatch() => this.Matches = new List<Match>();

    public ReportMatch(int examId, int studentId)
    {
      this.Matches = new List<Match>();
      this.ExamId = examId;
      this.StudentId = studentId;
    }
  }
}
