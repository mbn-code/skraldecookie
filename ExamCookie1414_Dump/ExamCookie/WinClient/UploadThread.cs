// Decompiled with JetBrains decompiler
// Type: ExamCookie.WinClient.UploadThread
// Assembly: ExamCookie.WinClient, Version=1.4.1.4, Culture=neutral, PublicKeyToken=null
// MVID: E12BE1F8-B6E0-4BF5-B308-166F0E938C4B
// Assembly location: C:\Users\oskar\Downloads\ExamCookie1414.WinClient.exe

using ExamCookie.WinClient.ExamApiV3Service;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;

#nullable disable
namespace ExamCookie.WinClient
{
  public class UploadThread
  {
    private const int THREAD_SLEEP = 100;
    private int HeartbeatPulseMin;
    private int HeartbeatPulseMax;
    private bool _Started;
    private DateTime _CurrentTime;
    private string _Token;
    private int _IsOnline;
    private int _AcceptOnline;
    private bool _IsWsOnline;
    private List<object> _PackageBuffer;
    private int _Heartbeat;
    private Random _Random;
    [SpecialName]
    private DateTime \u0024STATIC\u0024get_UploadDataPackagesComplete\u00242002\u0024ts;
    [SpecialName]
    private StaticLocalInitFlag \u0024STATIC\u0024get_UploadDataPackagesComplete\u00242002\u0024ts\u0024Init;

    public event UploadThread.OnOnlineChangedEventHandler OnOnlineChanged;

    public event UploadThread.OnHeartbeatEventHandler OnHeartbeat;

    public event UploadThread.OnDebugEventHandler OnDebug;

    public event UploadThread.OnExceptionEventHandler OnException;

    public UploadThread()
    {
      this.HeartbeatPulseMin = 30;
      this.HeartbeatPulseMax = 60;
      this._Started = false;
      this._CurrentTime = DateTime.MinValue;
      this._Token = "";
      this._IsOnline = 2;
      this._AcceptOnline = 0;
      this._IsWsOnline = false;
      this._PackageBuffer = new List<object>();
      this._Heartbeat = 0;
      this._Random = new Random();
    }

    public UploadThread(int heartbeatPulseMin, int heartbeatPulseMax)
    {
      this.HeartbeatPulseMin = 30;
      this.HeartbeatPulseMax = 60;
      this._Started = false;
      this._CurrentTime = DateTime.MinValue;
      this._Token = "";
      this._IsOnline = 2;
      this._AcceptOnline = 0;
      this._IsWsOnline = false;
      this._PackageBuffer = new List<object>();
      this._Heartbeat = 0;
      this._Random = new Random();
      this.HeartbeatPulseMin = heartbeatPulseMin;
      this.HeartbeatPulseMax = heartbeatPulseMax;
      this.CreateOfflineDirectory();
      this.Started = true;
      new Thread((ThreadStart) ([SpecialName] () => this.UploadDataPackages())).Start();
      new Thread((ThreadStart) ([SpecialName] () => this.OnlineMonitor())).Start();
    }

    public bool Started
    {
      get => this._Started;
      set => this._Started = value;
    }

    public DateTime CurrentTime
    {
      get => this._CurrentTime;
      set => this._CurrentTime = value;
    }

    public string Token
    {
      get => this._Token;
      set => this._Token = value;
    }

    public bool IsOnline
    {
      get
      {
        return Conversions.ToBoolean(Interaction.IIf(this._IsOnline == 1, (object) true, (object) false));
      }
      set
      {
        if (this._IsOnline == 2)
        {
          UploadThread.OnOnlineChangedEventHandler onlineChangedEvent = this.OnOnlineChangedEvent;
          if (onlineChangedEvent != null)
            onlineChangedEvent(value);
        }
        else if (value & this._IsOnline == 0)
        {
          UploadThread.OnOnlineChangedEventHandler onlineChangedEvent = this.OnOnlineChangedEvent;
          if (onlineChangedEvent != null)
            onlineChangedEvent(value);
        }
        else if (!value & this._IsOnline == 1)
        {
          UploadThread.OnOnlineChangedEventHandler onlineChangedEvent = this.OnOnlineChangedEvent;
          if (onlineChangedEvent != null)
            onlineChangedEvent(value);
        }
        this._IsOnline = Conversions.ToInteger(Interaction.IIf(value, (object) 1, (object) 0));
        if (value)
          return;
        this.IsWsOnline = false;
      }
    }

    public bool AcceptOnline
    {
      get => this._AcceptOnline >= 5;
      set
      {
        if (value)
        {
          if (this._AcceptOnline >= 10)
            return;
          int& local;
          int num = checked (^(local = ref this._AcceptOnline) + 1);
          local = num;
        }
        else if (this._AcceptOnline > 0)
        {
          int& local;
          int num = checked (^(local = ref this._AcceptOnline) - 1);
          local = num;
        }
      }
    }

    public bool IsWsOnline
    {
      get => this._IsWsOnline;
      set => this._IsWsOnline = value;
    }

    public void AddDataPackage(object package)
    {
      try
      {
        if (!this.ValidateDataPackage(RuntimeHelpers.GetObjectValue(package)))
          return;
        if (this.DataPackageCount < 250)
          this._PackageBuffer.Add(RuntimeHelpers.GetObjectValue(package));
        else
          this.SaveDataPackageToDisk(RuntimeHelpers.GetObjectValue(package));
      }
      catch (Exception ex1)
      {
        ProjectData.SetProjectError(ex1);
        Exception ex2 = ex1;
        // ISSUE: reference to a compiler-generated field
        UploadThread.OnExceptionEventHandler onExceptionEvent = this.OnExceptionEvent;
        if (onExceptionEvent != null)
          onExceptionEvent(ex2);
        ProjectData.ClearProjectError();
      }
    }

    public int DataPackageCount => this._PackageBuffer.ToList<object>().Count;

    public int DataPackageOfflineCount
    {
      get
      {
        int packageOfflineCount;
        try
        {
          packageOfflineCount = !Directory.Exists(this.GetOfflineDirectoryName()) ? 0 : ((IEnumerable<string>) Directory.GetFiles(this.GetOfflineDirectoryName(), "*." + RuntimeHelpers.GetObjectValue(Module1.PACKAGE_FILE_EXTENSION))).Count<string>();
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          packageOfflineCount = 0;
          ProjectData.ClearProjectError();
        }
        return packageOfflineCount;
      }
    }

    public bool UploadDataPackagesComplete
    {
      get
      {
        if (this.\u0024STATIC\u0024get_UploadDataPackagesComplete\u00242002\u0024ts\u0024Init == null)
          Interlocked.CompareExchange<StaticLocalInitFlag>(ref this.\u0024STATIC\u0024get_UploadDataPackagesComplete\u00242002\u0024ts\u0024Init, new StaticLocalInitFlag(), (StaticLocalInitFlag) null);
        bool lockTaken = false;
        try
        {
          System.Threading.Monitor.Enter((object) this.\u0024STATIC\u0024get_UploadDataPackagesComplete\u00242002\u0024ts\u0024Init, ref lockTaken);
          if (this.\u0024STATIC\u0024get_UploadDataPackagesComplete\u00242002\u0024ts\u0024Init.State == (short) 0)
          {
            this.\u0024STATIC\u0024get_UploadDataPackagesComplete\u00242002\u0024ts\u0024Init.State = (short) 2;
            this.\u0024STATIC\u0024get_UploadDataPackagesComplete\u00242002\u0024ts = DateAndTime.Now;
          }
          else if (this.\u0024STATIC\u0024get_UploadDataPackagesComplete\u00242002\u0024ts\u0024Init.State == (short) 2)
            throw new IncompleteInitialization();
        }
        finally
        {
          this.\u0024STATIC\u0024get_UploadDataPackagesComplete\u00242002\u0024ts\u0024Init.State = (short) 1;
          if (lockTaken)
            System.Threading.Monitor.Exit((object) this.\u0024STATIC\u0024get_UploadDataPackagesComplete\u00242002\u0024ts\u0024Init);
        }
        if (this.DataPackageCount > 0 | this.DataPackageOfflineCount > 0)
        {
          this.\u0024STATIC\u0024get_UploadDataPackagesComplete\u00242002\u0024ts = DateAndTime.Now;
          return false;
        }
        return DateTime.Compare(DateAndTime.Now, this.\u0024STATIC\u0024get_UploadDataPackagesComplete\u00242002\u0024ts.AddSeconds(10.0)) >= 0;
      }
    }

    private void UploadDataPackages()
    {
      int num = 0;
      Stopwatch stopwatch = new Stopwatch();
      object package = (object) null;
      while (this.Started)
      {
        try
        {
          if (this.DataPackageCount > 0)
          {
            if (this.GetNextPackage(ref package))
            {
              if (!this.IsWsOnline)
              {
                // ISSUE: reference to a compiler-generated field
                UploadThread.OnDebugEventHandler onDebugEvent = this.OnDebugEvent;
                if (onDebugEvent != null)
                  onDebugEvent("Maskinen er offline. Data pakke gemmes på disk.");
                this.SaveDataPackageToDisk(RuntimeHelpers.GetObjectValue(package));
              }
              else
              {
                try
                {
                  using (ExamApiV3Client examApiV3Client = Module1.ExamClient())
                  {
                    ExamApiV3Client client = examApiV3Client;
                    Module1.SetCredentials(ref client);
                    stopwatch.Restart();
                    switch (package)
                    {
                      case null:
                        num = 999;
                        break;
                      case AdapterThread.AdapterChanged _:
                        AdapterThread.AdapterChanged adapterChanged = (AdapterThread.AdapterChanged) package;
                        num = examApiV3Client.AddAdapter(adapterChanged.Token, adapterChanged.TimeStamp, adapterChanged.Data);
                        // ISSUE: reference to a compiler-generated field
                        UploadThread.OnDebugEventHandler onDebugEvent1 = this.OnDebugEvent;
                        if (onDebugEvent1 != null)
                        {
                          onDebugEvent1(string.Format("WS:AddAdapter > {0} ms", (object) stopwatch.ElapsedMilliseconds));
                          break;
                        }
                        break;
                      case ApplicationThread.ApplicationChanged _:
                        ApplicationThread.ApplicationChanged applicationChanged = (ApplicationThread.ApplicationChanged) package;
                        num = examApiV3Client.AddFrontApp(applicationChanged.Token, applicationChanged.TimeStamp, applicationChanged.Type, applicationChanged.Name, applicationChanged.Document, 0);
                        // ISSUE: reference to a compiler-generated field
                        UploadThread.OnDebugEventHandler onDebugEvent2 = this.OnDebugEvent;
                        if (onDebugEvent2 != null)
                        {
                          onDebugEvent2(string.Format("WS:AddFrontApp > {0} ms", (object) stopwatch.ElapsedMilliseconds));
                          break;
                        }
                        break;
                      case ClipboardThread.ClipboardChanged _:
                        ClipboardThread.ClipboardChanged clipboardChanged = (ClipboardThread.ClipboardChanged) package;
                        num = examApiV3Client.AddClipboard(clipboardChanged.Token, clipboardChanged.TimeStamp, clipboardChanged.Format, clipboardChanged.Data);
                        // ISSUE: reference to a compiler-generated field
                        UploadThread.OnDebugEventHandler onDebugEvent3 = this.OnDebugEvent;
                        if (onDebugEvent3 != null)
                        {
                          onDebugEvent3(string.Format("WS:AddClipboard > {0} ms", (object) stopwatch.ElapsedMilliseconds));
                          break;
                        }
                        break;
                      case ProcessThread.ProcessChanged _:
                        ProcessThread.ProcessChanged processChanged = (ProcessThread.ProcessChanged) package;
                        num = examApiV3Client.AddProcess(processChanged.Token, processChanged.TimeStamp, processChanged.Data());
                        // ISSUE: reference to a compiler-generated field
                        UploadThread.OnDebugEventHandler onDebugEvent4 = this.OnDebugEvent;
                        if (onDebugEvent4 != null)
                        {
                          onDebugEvent4(string.Format("WS:AddProcess > {0} ms", (object) stopwatch.ElapsedMilliseconds));
                          break;
                        }
                        break;
                      case ScreenThread.ScreenChanged _:
                        ScreenThread.ScreenChanged screenChanged = (ScreenThread.ScreenChanged) package;
                        num = examApiV3Client.AddScreenShot(screenChanged.Token, screenChanged.TimeStamp, screenChanged.ScreenNumber, screenChanged.Data);
                        // ISSUE: reference to a compiler-generated field
                        UploadThread.OnDebugEventHandler onDebugEvent5 = this.OnDebugEvent;
                        if (onDebugEvent5 != null)
                          onDebugEvent5(string.Format("WS:AddScreenShot > {0} ms", (object) stopwatch.ElapsedMilliseconds));
                        break;
                    }
                  }
                  switch (num)
                  {
                    case 0:
                    case 2:
                    case 2627:
                      this._Heartbeat = this.GetNextHeartbeat();
                      break;
                    case 999:
                      // ISSUE: reference to a compiler-generated field
                      UploadThread.OnDebugEventHandler onDebugEvent = this.OnDebugEvent;
                      if (onDebugEvent != null)
                      {
                        onDebugEvent("Data pakke er ugyldig");
                        break;
                      }
                      break;
                    default:
                      this.SaveDataPackageToDisk(RuntimeHelpers.GetObjectValue(package));
                      break;
                  }
                }
                catch (Exception ex1)
                {
                  ProjectData.SetProjectError(ex1);
                  Exception ex2 = ex1;
                  this.SaveDataPackageToDisk(RuntimeHelpers.GetObjectValue(package));
                  // ISSUE: reference to a compiler-generated field
                  UploadThread.OnExceptionEventHandler onExceptionEvent = this.OnExceptionEvent;
                  if (onExceptionEvent != null)
                    onExceptionEvent(ex2);
                  ProjectData.ClearProjectError();
                }
              }
            }
          }
          else if (this.IsWsOnline)
            this.LoadDataPackageFromDisk();
        }
        catch (Exception ex3)
        {
          ProjectData.SetProjectError(ex3);
          Exception ex4 = ex3;
          // ISSUE: reference to a compiler-generated field
          UploadThread.OnExceptionEventHandler onExceptionEvent = this.OnExceptionEvent;
          if (onExceptionEvent != null)
            onExceptionEvent(ex4);
          ProjectData.ClearProjectError();
        }
        finally
        {
          Thread.Sleep(100);
        }
      }
    }

    private void OnlineMonitor()
    {
      Stopwatch stopwatch = new Stopwatch();
      stopwatch.Start();
      Module1.NetConnectType type = Module1.NetConnectType.INTERNET_CONNECTION_OFFLINE;
      Module1.NetConnectType netConnectType = type;
      while (this.Started)
      {
        try
        {
          if (stopwatch.ElapsedMilliseconds >= 500L)
          {
            stopwatch.Restart();
            this.AcceptOnline = Module1.IsInternetConnected(ref type) && type == Module1.NetConnectType.INTERNET_CONNECTION_ONLINE;
            this.IsOnline = this.AcceptOnline;
          }
          if (netConnectType != type)
          {
            netConnectType = type;
            // ISSUE: reference to a compiler-generated field
            UploadThread.OnDebugEventHandler onDebugEvent = this.OnDebugEvent;
            if (onDebugEvent != null)
              onDebugEvent("NetConnectType = " + type.ToString());
          }
          if (!this.IsOnline)
          {
            this._Heartbeat = 0;
            this.IsWsOnline = false;
          }
          else if (this._Heartbeat < 0)
          {
            this._Heartbeat = this.GetNextHeartbeat();
            try
            {
              using (ExamApiV3Client examApiV3Client = Module1.ExamClient())
              {
                ExamApiV3Client client = examApiV3Client;
                Module1.SetCredentials(ref client);
                DateTime minValue = DateTime.MinValue;
                int result = examApiV3Client.HeartBeat(this.Token, ref minValue);
                if (result >= 0)
                {
                  this.IsWsOnline = true;
                  if (DateTime.Compare(minValue, DateTime.MinValue) != 0)
                  {
                    // ISSUE: reference to a compiler-generated field
                    UploadThread.OnHeartbeatEventHandler onHeartbeatEvent = this.OnHeartbeatEvent;
                    if (onHeartbeatEvent != null)
                      onHeartbeatEvent(minValue, result);
                  }
                }
                else
                  this.IsWsOnline = false;
              }
            }
            catch (Exception ex1)
            {
              ProjectData.SetProjectError(ex1);
              Exception ex2 = ex1;
              this.IsWsOnline = false;
              // ISSUE: reference to a compiler-generated field
              UploadThread.OnExceptionEventHandler onExceptionEvent = this.OnExceptionEvent;
              if (onExceptionEvent != null)
                onExceptionEvent(ex2);
              ProjectData.ClearProjectError();
            }
          }
          else
          {
            // ISSUE: variable of a reference type
            int& local;
            // ISSUE: explicit reference operation
            int num = checked (^(local = ref this._Heartbeat) - 100);
            local = num;
          }
        }
        catch (Exception ex3)
        {
          ProjectData.SetProjectError(ex3);
          Exception ex4 = ex3;
          // ISSUE: reference to a compiler-generated field
          UploadThread.OnExceptionEventHandler onExceptionEvent = this.OnExceptionEvent;
          if (onExceptionEvent != null)
            onExceptionEvent(ex4);
          ProjectData.ClearProjectError();
        }
        finally
        {
          Thread.Sleep(100);
        }
      }
    }

    private int GetNextHeartbeat()
    {
      return this._Random.Next(checked (this.HeartbeatPulseMin * 1000), checked (this.HeartbeatPulseMax * 1000));
    }

    private bool GetNextPackage(ref object package)
    {
      bool nextPackage;
      try
      {
        if (this.DataPackageCount > 0)
        {
          package = RuntimeHelpers.GetObjectValue(this._PackageBuffer.Pop());
          if (this.CanDataPackageSend(Conversions.ToDate(NewLateBinding.LateGet(package, (Type) null, "CanSend", new object[0], (string[]) null, (Type[]) null, (bool[]) null))))
          {
            nextPackage = true;
          }
          else
          {
            this._PackageBuffer.Add(RuntimeHelpers.GetObjectValue(package));
            nextPackage = false;
          }
        }
        else
          nextPackage = false;
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        nextPackage = false;
        ProjectData.ClearProjectError();
      }
      return nextPackage;
    }

    private bool ValidateDataPackage(object package)
    {
      bool flag1;
      try
      {
        bool flag2 = false;
        switch (package)
        {
          case null:
            flag2 = false;
            break;
          case AdapterThread.AdapterChanged _:
            flag2 = true;
            break;
          case ApplicationThread.ApplicationChanged _:
            flag2 = true;
            break;
          case ClipboardThread.ClipboardChanged _:
            flag2 = true;
            break;
          case ProcessThread.ProcessChanged _:
            flag2 = true;
            break;
          case ScreenThread.ScreenChanged _:
            flag2 = true;
            break;
        }
        flag1 = !flag2 || package.GetType().GetField("Data") == null ? flag2 : !Information.IsNothing(RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(package, (Type) null, "Data", new object[0], (string[]) null, (Type[]) null, (bool[]) null)));
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        flag1 = false;
        ProjectData.ClearProjectError();
      }
      return flag1;
    }

    private bool CanDataPackageSend(DateTime value)
    {
      bool flag;
      try
      {
        flag = DateTime.Compare(this.CurrentTime, value) > 0;
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        flag = false;
        ProjectData.ClearProjectError();
      }
      return flag;
    }

    private void LoadDataPackageFromDisk()
    {
      try
      {
        if (!Directory.Exists(this.GetOfflineDirectoryName()))
          return;
        string[] files = Directory.GetFiles(this.GetOfflineDirectoryName(), "*." + RuntimeHelpers.GetObjectValue(Module1.PACKAGE_FILE_EXTENSION));
        int index = 0;
        while (index < files.Length)
        {
          string str = files[index];
          if (this.DataPackageCount < 10)
          {
            object Instance = (object) null;
            if (Module1.DeserializeFromFileDecrypted(str, ref Instance) == 0 && DateAndTime.DateDiff(DateInterval.Day, Conversions.ToDate(NewLateBinding.LateGet(Instance, (Type) null, "TimeStamp", new object[0], (string[]) null, (Type[]) null, (bool[]) null)), DateAndTime.Now) <= 90L)
              this.AddDataPackage(RuntimeHelpers.GetObjectValue(Instance));
            try
            {
              if (File.Exists(str))
                File.Delete(str);
            }
            catch (Exception ex1)
            {
              ProjectData.SetProjectError(ex1);
              Exception ex2 = ex1;
              // ISSUE: reference to a compiler-generated field
              UploadThread.OnExceptionEventHandler onExceptionEvent = this.OnExceptionEvent;
              if (onExceptionEvent != null)
                onExceptionEvent(ex2);
              ProjectData.ClearProjectError();
            }
            checked { ++index; }
          }
          else
            break;
        }
      }
      catch (Exception ex3)
      {
        ProjectData.SetProjectError(ex3);
        Exception ex4 = ex3;
        // ISSUE: reference to a compiler-generated field
        UploadThread.OnExceptionEventHandler onExceptionEvent = this.OnExceptionEvent;
        if (onExceptionEvent != null)
          onExceptionEvent(ex4);
        ProjectData.ClearProjectError();
      }
    }

    private void SaveDataPackageToDisk(object package)
    {
      Module1.SerializeToFileEncrypted(this.GetNewFilename(), RuntimeHelpers.GetObjectValue(package));
    }

    private void CreateOfflineDirectory()
    {
      try
      {
        if (Directory.Exists(string.Format("{0}\\{1}", (object) Module1.APP_DATA_PATH, (object) Module1.OFFLINE_PACKAGE_FOLDER)))
          return;
        Directory.CreateDirectory(string.Format("{0}\\{1}", (object) Module1.APP_DATA_PATH, (object) Module1.OFFLINE_PACKAGE_FOLDER));
      }
      catch (Exception ex1)
      {
        ProjectData.SetProjectError(ex1);
        Exception ex2 = ex1;
        // ISSUE: reference to a compiler-generated field
        UploadThread.OnExceptionEventHandler onExceptionEvent = this.OnExceptionEvent;
        if (onExceptionEvent != null)
          onExceptionEvent(ex2);
        ProjectData.ClearProjectError();
      }
    }

    private string GetOfflineDirectoryName()
    {
      string offlineDirectoryName;
      try
      {
        offlineDirectoryName = string.Format("{0}\\{1}", (object) Module1.APP_DATA_PATH, (object) Module1.OFFLINE_PACKAGE_FOLDER);
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        offlineDirectoryName = "";
        ProjectData.ClearProjectError();
      }
      return offlineDirectoryName;
    }

    private string GetNewFilename()
    {
      this.CreateOfflineDirectory();
      return string.Format("{0}\\{1}.{2}", (object) this.GetOfflineDirectoryName(), (object) Guid.NewGuid().ToString(), RuntimeHelpers.GetObjectValue(Module1.PACKAGE_FILE_EXTENSION));
    }

    public delegate void OnOnlineChangedEventHandler(bool online);

    public delegate void OnHeartbeatEventHandler(DateTime currentTime, int result);

    public delegate void OnDebugEventHandler(string message);

    public delegate void OnExceptionEventHandler(Exception ex);
  }
}
