// Decompiled with JetBrains decompiler
// Type: ExamCookie.Library.SignInLog
// Assembly: ExamCookie.WinClient, Version=1.4.1.4, Culture=neutral, PublicKeyToken=null
// MVID: E12BE1F8-B6E0-4BF5-B308-166F0E938C4B
// Assembly location: C:\Users\oskar\Downloads\ExamCookie1414.WinClient.exe

using System.Collections.Generic;

#nullable disable
namespace ExamCookie.Library
{
  public class SignInLog
  {
    public SignIn SignIn;
    public List<ExamCookie.Library.Clipboard> Clipboard;
    public List<ExamCookie.Library.FrontApp> FrontApp;
    public List<ExamCookie.Library.Machine> Machine;
    public List<ExamCookie.Library.Process> Process;
    public List<ExamCookie.Library.ScreenShot> ScreenShot;

    public SignInLog()
    {
      this.SignIn = (SignIn) null;
      this.Clipboard = new List<ExamCookie.Library.Clipboard>();
      this.FrontApp = new List<ExamCookie.Library.FrontApp>();
      this.Machine = new List<ExamCookie.Library.Machine>();
      this.Process = new List<ExamCookie.Library.Process>();
      this.ScreenShot = new List<ExamCookie.Library.ScreenShot>();
    }

    public SignInLog(SignIn signIn)
    {
      this.SignIn = (SignIn) null;
      this.Clipboard = new List<ExamCookie.Library.Clipboard>();
      this.FrontApp = new List<ExamCookie.Library.FrontApp>();
      this.Machine = new List<ExamCookie.Library.Machine>();
      this.Process = new List<ExamCookie.Library.Process>();
      this.ScreenShot = new List<ExamCookie.Library.ScreenShot>();
      this.SignIn = signIn;
    }
  }
}
