// Decompiled with JetBrains decompiler
// Type: ExamCookie.WinClient.ConfigurationThread
// Assembly: ExamCookie.WinClient, Version=1.4.1.4, Culture=neutral, PublicKeyToken=null
// MVID: E12BE1F8-B6E0-4BF5-B308-166F0E938C4B
// Assembly location: C:\Users\oskar\Downloads\ExamCookie1414.WinClient.exe

using ExamCookie.Library;
using ExamCookie.WinClient.ExamApiV3Service;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Diagnostics;
using System.Threading;
using System.Web.Script.Serialization;

#nullable disable
namespace ExamCookie.WinClient
{
  public class ConfigurationThread
  {
    private const int THREAD_SLEEP = 500;
    private bool _Started;
    private bool _IsOnline;
    private Random _Random;

    public event ConfigurationThread.OnConfigurationChangedEventHandler OnConfigurationChanged;

    public event ConfigurationThread.OnDebugEventHandler OnDebug;

    public event ConfigurationThread.OnExceptionEventHandler OnException;

    public ConfigurationThread()
    {
      this._Started = false;
      this._IsOnline = false;
      this._Random = new Random();
      Thread thread = new Thread(new ThreadStart(this.Main));
      this.Started = true;
      thread.Start();
    }

    public bool Started
    {
      get => this._Started;
      set => this._Started = value;
    }

    public bool IsOnline
    {
      get => this._IsOnline;
      set => this._IsOnline = value;
    }

    private void Main()
    {
      int nextPolltime = this.GetNextPolltime();
      Stopwatch stopwatch = new Stopwatch();
      stopwatch.Start();
      while (this.Started)
      {
        try
        {
          if (stopwatch.ElapsedMilliseconds >= (long) nextPolltime)
          {
            stopwatch.Restart();
            nextPolltime = this.GetNextPolltime();
            using (ExamApiV3Client examApiV3Client = Module1.ExamClient())
            {
              ExamApiV3Client client = examApiV3Client;
              Module1.SetCredentials(ref client);
              string information = "";
              if (examApiV3Client.GetExamInformation(Module1.Config.Token, ref information) == 0)
              {
                ExamInformation examInformation = (ExamInformation) new JavaScriptSerializer().Deserialize(information, typeof (ExamInformation));
                if (examInformation != null)
                {
                  if (DateTime.Compare(Module1.Config.Exam.TimeBegin, examInformation.Exam.TimeBegin) != 0)
                  {
                    Module1.Config.Exam.TimeBegin = examInformation.Exam.TimeBegin;
                    // ISSUE: reference to a compiler-generated field
                    ConfigurationThread.OnConfigurationChangedEventHandler configurationChangedEvent = this.OnConfigurationChangedEvent;
                    if (configurationChangedEvent != null)
                      configurationChangedEvent(new string[2]
                      {
                        "Eksamens starttidspunkt er ændret.",
                        "Eksamen begynder: " + Strings.Format((object) Module1.Config.Exam.TimeBegin, "dd-MM-yyyy HH:mm")
                      });
                  }
                  else if (DateTime.Compare(Module1.Config.Exam.TimeEnd, examInformation.Exam.TimeEnd) != 0)
                  {
                    Module1.Config.Exam.TimeEnd = examInformation.Exam.TimeEnd;
                    // ISSUE: reference to a compiler-generated field
                    ConfigurationThread.OnConfigurationChangedEventHandler configurationChangedEvent = this.OnConfigurationChangedEvent;
                    if (configurationChangedEvent != null)
                      configurationChangedEvent(new string[2]
                      {
                        "Eksamens sluttidspunkt er ændret.",
                        "Eksamen slutter: " + Module1.FormatExamEndTime(Module1.Config.Exam.TimeEnd, Module1.Config.Exam.TimeEndExt, "dd-MM-yyyy HH:mm")
                      });
                  }
                  else if (Module1.Config.Exam.TimeEndExt != examInformation.Exam.TimeEndExt)
                  {
                    Module1.Config.Exam.TimeEndExt = examInformation.Exam.TimeEndExt;
                    // ISSUE: reference to a compiler-generated field
                    ConfigurationThread.OnConfigurationChangedEventHandler configurationChangedEvent = this.OnConfigurationChangedEvent;
                    if (configurationChangedEvent != null)
                      configurationChangedEvent(new string[2]
                      {
                        "Eksamen er tildelt ekstra tid.",
                        "Eksamen slutter: " + Module1.FormatExamEndTime(Module1.Config.Exam.TimeEnd, Module1.Config.Exam.TimeEndExt, "dd-MM-yyyy HH:mm")
                      });
                  }
                  else if (Module1.Config.Exam.StudentTimeExt != examInformation.Exam.StudentTimeExt)
                  {
                    Module1.Config.Exam.StudentTimeExt = examInformation.Exam.StudentTimeExt;
                    // ISSUE: reference to a compiler-generated field
                    ConfigurationThread.OnConfigurationChangedEventHandler configurationChangedEvent = this.OnConfigurationChangedEvent;
                    if (configurationChangedEvent != null)
                      configurationChangedEvent(new string[3]
                      {
                        "Eleven er tildelt ekstra tid.",
                        "Eksamen slutter: " + Module1.FormatExamEndTime(Module1.Config.Exam.TimeEnd, Module1.Config.Exam.TimeEndExt, "dd-MM-yyyy HH:mm"),
                        string.Format("Ekstra elev tid: {0} minutter.", (object) Module1.Config.Exam.StudentTimeExt)
                      });
                  }
                }
              }
            }
          }
        }
        catch (Exception ex1)
        {
          ProjectData.SetProjectError(ex1);
          Exception ex2 = ex1;
          // ISSUE: reference to a compiler-generated field
          ConfigurationThread.OnExceptionEventHandler onExceptionEvent = this.OnExceptionEvent;
          if (onExceptionEvent != null)
            onExceptionEvent(ex2);
          ProjectData.ClearProjectError();
        }
        finally
        {
          Thread.Sleep(500);
        }
      }
    }

    private int GetNextPolltime() => this._Random.Next(30000, 90000);

    public delegate void OnConfigurationChangedEventHandler(string[] message);

    public delegate void OnDebugEventHandler(string message);

    public delegate void OnExceptionEventHandler(Exception ex);
  }
}
