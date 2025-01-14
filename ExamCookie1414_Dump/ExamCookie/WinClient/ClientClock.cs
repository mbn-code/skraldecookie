// Decompiled with JetBrains decompiler
// Type: ExamCookie.WinClient.ClientClock
// Assembly: ExamCookie.WinClient, Version=1.4.1.4, Culture=neutral, PublicKeyToken=null
// MVID: E12BE1F8-B6E0-4BF5-B308-166F0E938C4B
// Assembly location: C:\Users\oskar\Downloads\ExamCookie1414.WinClient.exe

using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Diagnostics;

#nullable disable
namespace ExamCookie.WinClient
{
  public class ClientClock
  {
    private Stopwatch StopWatch;
    private DateTime InitialTime;

    public event ClientClock.OnExceptionEventHandler OnException;

    public ClientClock()
    {
      this.StopWatch = new Stopwatch();
      this.InitialTime = DateTime.MinValue;
    }

    public ClientClock(DateTime initialTime)
    {
      this.StopWatch = new Stopwatch();
      this.InitialTime = DateTime.MinValue;
      this.InitialTime = initialTime;
      this.StopWatch.Start();
    }

    public DateTime CurrentTime
    {
      get => this.InitialTime.AddMilliseconds((double) this.StopWatch.ElapsedMilliseconds);
      set
      {
        try
        {
          this.InitialTime = value;
          this.StopWatch.Restart();
        }
        catch (Exception ex1)
        {
          ProjectData.SetProjectError(ex1);
          Exception ex2 = ex1;
          ClientClock.OnExceptionEventHandler onExceptionEvent = this.OnExceptionEvent;
          if (onExceptionEvent != null)
            onExceptionEvent(ex2);
          ProjectData.ClearProjectError();
        }
      }
    }

    public delegate void OnExceptionEventHandler(Exception ex);
  }
}
