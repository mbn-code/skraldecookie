// Decompiled with JetBrains decompiler
// Type: ExamCookie.Library.ExamInformation
// Assembly: ExamCookie.WinClient, Version=1.4.1.4, Culture=neutral, PublicKeyToken=null
// MVID: E12BE1F8-B6E0-4BF5-B308-166F0E938C4B
// Assembly location: C:\Users\oskar\Downloads\ExamCookie1414.WinClient.exe

using System;

#nullable disable
namespace ExamCookie.Library
{
  [Serializable]
  public class ExamInformation
  {
    public ClientStudent Student;
    public ClientExam Exam;

    public ExamInformation()
    {
      this.Student = new ClientStudent();
      this.Exam = new ClientExam();
    }
  }
}
