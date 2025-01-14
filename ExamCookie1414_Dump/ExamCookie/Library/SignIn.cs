// Decompiled with JetBrains decompiler
// Type: ExamCookie.Library.SignIn
// Assembly: ExamCookie.WinClient, Version=1.4.1.4, Culture=neutral, PublicKeyToken=null
// MVID: E12BE1F8-B6E0-4BF5-B308-166F0E938C4B
// Assembly location: C:\Users\oskar\Downloads\ExamCookie1414.WinClient.exe

using System;

#nullable disable
namespace ExamCookie.Library
{
  [Serializable]
  public class SignIn
  {
    public int Id;
    public int ExamId;
    public int StudentId;
    public eSignInStatus Status;
    public string ErrorText;
    public DateTime CurrentTime;
    public DateTime StartTime;
    public DateTime EndTime;
    public DateTime TimeSignIn;
    public DateTime TimeSignOut;
    public DateTime TimeHeartBeat;

    public SignIn()
    {
      this.Id = 0;
      this.ExamId = 0;
      this.StudentId = 0;
      this.Status = eSignInStatus.STUDENT_NOT_FOUND;
      this.ErrorText = "";
      this.CurrentTime = DateTime.MinValue;
      this.StartTime = DateTime.MinValue;
      this.EndTime = DateTime.MinValue;
      this.TimeSignIn = DateTime.MinValue;
      this.TimeSignOut = DateTime.MinValue;
      this.TimeHeartBeat = DateTime.MinValue;
    }

    public SignIn(int id, int examId, int studentId, DateTime timeSignIn)
    {
      this.Id = 0;
      this.ExamId = 0;
      this.StudentId = 0;
      this.Status = eSignInStatus.STUDENT_NOT_FOUND;
      this.ErrorText = "";
      this.CurrentTime = DateTime.MinValue;
      this.StartTime = DateTime.MinValue;
      this.EndTime = DateTime.MinValue;
      this.TimeSignIn = DateTime.MinValue;
      this.TimeSignOut = DateTime.MinValue;
      this.TimeHeartBeat = DateTime.MinValue;
      this.Id = id;
      this.ExamId = examId;
      this.StudentId = studentId;
      this.TimeSignIn = timeSignIn;
    }
  }
}
