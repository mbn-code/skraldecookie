// Decompiled with JetBrains decompiler
// Type: ExamCookie.Library.ParameterOut
// Assembly: ExamCookie.WinClient, Version=1.4.1.4, Culture=neutral, PublicKeyToken=null
// MVID: E12BE1F8-B6E0-4BF5-B308-166F0E938C4B
// Assembly location: C:\Users\oskar\Downloads\ExamCookie1414.WinClient.exe

using System;

#nullable disable
namespace ExamCookie.Library
{
  [Serializable]
  public class ParameterOut
  {
    public string Token;
    public DateTime CurrentTime;
    public ClientStudent Student;
    public ClientExam Exam;
    public ClientConfig ClientConfiguration;

    public ParameterOut()
    {
      this.Token = "";
      this.CurrentTime = DateTime.MinValue;
      this.Student = new ClientStudent();
      this.Exam = new ClientExam();
      this.ClientConfiguration = new ClientConfig();
    }
  }
}
