// Decompiled with JetBrains decompiler
// Type: ExamCookie.WinClient.ProcessThread
// Assembly: ExamCookie.WinClient, Version=1.4.1.4, Culture=neutral, PublicKeyToken=null
// MVID: E12BE1F8-B6E0-4BF5-B308-166F0E938C4B
// Assembly location: C:\Users\oskar\Downloads\ExamCookie1414.WinClient.exe

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;

#nullable disable
namespace ExamCookie.WinClient
{
  public class ProcessThread
  {
    private const int THREAD_SLEEP = 500;
    private bool _Started;
    private List<string> _IgnoreList;

    public event ProcessThread.OnProcessChangedEventHandler OnProcessChanged;

    public event ProcessThread.OnDebugEventHandler OnDebug;

    public event ProcessThread.OnExceptionEventHandler OnException;

    public ProcessThread()
    {
      this._Started = false;
      this._IgnoreList = new List<string>();
    }

    public ProcessThread(int polltime)
    {
      ProcessThread processThread = this;
      this._Started = false;
      this._IgnoreList = new List<string>();
      if (polltime <= 0)
        return;
      if (polltime < 500)
        polltime = 500;
      Thread thread = new Thread((ThreadStart) ([SpecialName] () => processThread.Main(polltime)));
      this.Started = true;
      thread.Start();
    }

    public bool Started
    {
      get => this._Started;
      set => this._Started = value;
    }

    public List<string> IgnoreList
    {
      get => this._IgnoreList;
      set => this._IgnoreList = value;
    }

    private void Main(int polltime)
    {
      Stopwatch stopwatch = new Stopwatch();
      stopwatch.Start();
      List<ProcessThread.Process> processList1 = new List<ProcessThread.Process>();
      List<ProcessThread.Process> collection = new List<ProcessThread.Process>();
      List<ProcessThread.Process> processList2 = new List<ProcessThread.Process>();
      while (this.Started)
      {
        try
        {
          if (stopwatch.ElapsedMilliseconds >= (long) polltime)
          {
            stopwatch.Restart();
            if (processList1.Count == 0)
            {
              System.Diagnostics.Process[] processes = System.Diagnostics.Process.GetProcesses();
              int index = 0;
              while (index < processes.Length)
              {
                // ISSUE: object of a compiler-generated type is created
                // ISSUE: variable of a compiler-generated type
                ProcessThread._Closure\u0024__26\u002D0 closure260 = new ProcessThread._Closure\u0024__26\u002D0(closure260);
                // ISSUE: reference to a compiler-generated field
                closure260.\u0024VB\u0024Local_proc = processes[index];
                // ISSUE: reference to a compiler-generated method
                if (processList1.Find(new Predicate<ProcessThread.Process>(closure260._Lambda\u0024__0)) == null)
                {
                  // ISSUE: reference to a compiler-generated field
                  // ISSUE: reference to a compiler-generated field
                  processList1.Add(new ProcessThread.Process(closure260.\u0024VB\u0024Local_proc.Id, closure260.\u0024VB\u0024Local_proc.ProcessName, ""));
                }
                checked { ++index; }
              }
              // ISSUE: reference to a compiler-generated field
              ProcessThread.OnProcessChangedEventHandler processChangedEvent = this.OnProcessChangedEvent;
              if (processChangedEvent != null)
                processChangedEvent(new ProcessThread.ProcessChanged(processList1.ToArray()));
            }
            else
            {
              collection.Clear();
              System.Diagnostics.Process[] processes = System.Diagnostics.Process.GetProcesses();
              int index = 0;
              while (index < processes.Length)
              {
                // ISSUE: object of a compiler-generated type is created
                // ISSUE: variable of a compiler-generated type
                ProcessThread._Closure\u0024__26\u002D1 closure261 = new ProcessThread._Closure\u0024__26\u002D1(closure261);
                // ISSUE: reference to a compiler-generated field
                closure261.\u0024VB\u0024Local_proc = processes[index];
                // ISSUE: reference to a compiler-generated method
                if (collection.Find(new Predicate<ProcessThread.Process>(closure261._Lambda\u0024__1)) == null)
                {
                  // ISSUE: reference to a compiler-generated field
                  // ISSUE: reference to a compiler-generated field
                  collection.Add(new ProcessThread.Process(closure261.\u0024VB\u0024Local_proc.Id, closure261.\u0024VB\u0024Local_proc.ProcessName, ""));
                }
                checked { ++index; }
              }
              processList2.Clear();
              try
              {
                foreach (ProcessThread.Process process in collection)
                {
                  // ISSUE: object of a compiler-generated type is created
                  // ISSUE: variable of a compiler-generated type
                  ProcessThread._Closure\u0024__26\u002D2 closure262 = new ProcessThread._Closure\u0024__26\u002D2(closure262);
                  // ISSUE: reference to a compiler-generated field
                  closure262.\u0024VB\u0024Local_proc = process;
                  // ISSUE: reference to a compiler-generated method
                  // ISSUE: reference to a compiler-generated field
                  if (processList1.Find(new Predicate<ProcessThread.Process>(closure262._Lambda\u0024__2)) == null && !this.IgnoreList.Contains<string>(closure262.\u0024VB\u0024Local_proc.Name, (IEqualityComparer<string>) StringComparer.OrdinalIgnoreCase))
                  {
                    // ISSUE: reference to a compiler-generated field
                    processList2.Add(closure262.\u0024VB\u0024Local_proc);
                  }
                }
              }
              finally
              {
                List<ProcessThread.Process>.Enumerator enumerator;
                enumerator.Dispose();
              }
              processList1.Clear();
              processList1.AddRange((IEnumerable<ProcessThread.Process>) collection);
              if (processList2.Count > 0)
              {
                // ISSUE: reference to a compiler-generated field
                ProcessThread.OnProcessChangedEventHandler processChangedEvent = this.OnProcessChangedEvent;
                if (processChangedEvent != null)
                  processChangedEvent(new ProcessThread.ProcessChanged(processList2.ToArray()));
              }
            }
          }
        }
        catch (Exception ex1)
        {
          ProjectData.SetProjectError(ex1);
          Exception ex2 = ex1;
          // ISSUE: reference to a compiler-generated field
          ProcessThread.OnExceptionEventHandler onExceptionEvent = this.OnExceptionEvent;
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

    public delegate void OnProcessChangedEventHandler(ProcessThread.ProcessChanged sender);

    public delegate void OnDebugEventHandler(string message);

    public delegate void OnExceptionEventHandler(Exception ex);

    [Serializable]
    public class Process
    {
      public int Pid;
      public string Name;
      public string OriginalFilename;

      public Process()
      {
        this.Pid = 0;
        this.Name = "";
        this.OriginalFilename = "";
      }

      public Process(int pid, string name, string originalFilename)
      {
        this.Pid = 0;
        this.Name = "";
        this.OriginalFilename = "";
        this.Pid = pid;
        if (name == null)
          return;
        name = name.Replace("\0", "");
        this.Name = name;
        this.OriginalFilename = originalFilename;
      }
    }

    [Serializable]
    public class ProcessChanged
    {
      public string Reference;
      public string Token;
      public DateTime CanSend;
      public DateTime TimeStamp;
      public ProcessThread.Process[] Processes;

      public ProcessChanged()
      {
        this.Reference = Guid.NewGuid().ToString();
        this.Token = "";
        this.CanSend = DateTime.MinValue;
        this.TimeStamp = DateTime.MinValue;
        this.Processes = (ProcessThread.Process[]) null;
      }

      public ProcessChanged(ProcessThread.Process[] processes)
      {
        this.Reference = Guid.NewGuid().ToString();
        this.Token = "";
        this.CanSend = DateTime.MinValue;
        this.TimeStamp = DateTime.MinValue;
        this.Processes = (ProcessThread.Process[]) null;
        this.Processes = processes;
      }

      public string Data()
      {
        List<string> stringList = new List<string>();
        ProcessThread.Process[] processes = this.Processes;
        int index = 0;
        while (index < processes.Length)
        {
          ProcessThread.Process process = processes[index];
          if (process.Name != null && !stringList.Contains(process.Name))
            stringList.Add(process.Name);
          checked { ++index; }
        }
        return Strings.Join(stringList.ToArray(), "\r\n");
      }
    }
  }
}
