// Decompiled with JetBrains decompiler
// Type: ExamCookie.Library.ClientConfig
// Assembly: ExamCookie.WinClient, Version=1.4.1.4, Culture=neutral, PublicKeyToken=null
// MVID: E12BE1F8-B6E0-4BF5-B308-166F0E938C4B
// Assembly location: C:\Users\oskar\Downloads\ExamCookie1414.WinClient.exe

using System;

#nullable disable
namespace ExamCookie.Library
{
  [Serializable]
  public class ClientConfig
  {
    public string MinimumClientVersionWindows;
    public string MinimumClientVersionMac;
    public string MinimumClientVersionLinux;
    public string MinimumClientVersionChromeBook;
    public string[] OperatingSystemsWindows;
    public string[] OperatingSystemsMac;
    public string[] OperatingSystemsLinux;
    public string[] OperatingSystemsChromeBook;
    public int MinimumHarddiskSpace;
    public int NotifyBoxDisplayTime;
    public bool IncludeLogfile;
    public int ThreadsDelayedMin;
    public int ThreadsDelayedMax;
    public int HeartbeatPulseMin;
    public int HeartbeatPulseMax;
    public int ScreenPolltime;
    public int ScreenChangedPercent;
    public int ScreenChangedPercentWindows;
    public int ScreenChangedPercentMac;
    public int ScreenChangedPercentLinux;
    public int ScreenChangedPercentChromeBook;
    public int ScreenSendDelay;
    public int ScreenForceSendTime;
    public int ImageQuality;
    public int ClipboardPolltime;
    public int FrontAppPolltime;
    public int ProcessPolltime;
    public string[] ProcessIgnoreWindows;
    public string[] ProcessIgnoreMac;
    public string[] ProcessIgnoreLinux;
    public string[] ProcessIgnoreChromeBook;
    public int AdapterPolltime;

    public ClientConfig()
    {
      this.MinimumClientVersionWindows = "1.0.0.0";
      this.MinimumClientVersionMac = "1.0.0.0";
      this.MinimumClientVersionLinux = "1.0.0.0";
      this.MinimumClientVersionChromeBook = "1.0.0.0";
      this.OperatingSystemsWindows = new string[0];
      this.OperatingSystemsMac = new string[0];
      this.OperatingSystemsLinux = new string[0];
      this.OperatingSystemsChromeBook = new string[0];
      this.MinimumHarddiskSpace = 500000000;
      this.NotifyBoxDisplayTime = 10;
      this.IncludeLogfile = false;
      this.ThreadsDelayedMin = 5;
      this.ThreadsDelayedMax = 20;
      this.HeartbeatPulseMin = 30;
      this.HeartbeatPulseMax = 60;
      this.ScreenPolltime = 5000;
      this.ScreenChangedPercent = 5;
      this.ScreenChangedPercentWindows = 5;
      this.ScreenChangedPercentMac = 5;
      this.ScreenChangedPercentLinux = 5;
      this.ScreenChangedPercentChromeBook = 5;
      this.ScreenSendDelay = 1;
      this.ScreenForceSendTime = 300;
      this.ImageQuality = 20;
      this.ClipboardPolltime = 500;
      this.FrontAppPolltime = 1000;
      this.ProcessPolltime = 5000;
      this.ProcessIgnoreWindows = new string[0];
      this.ProcessIgnoreMac = new string[0];
      this.ProcessIgnoreLinux = new string[0];
      this.ProcessIgnoreChromeBook = new string[0];
      this.AdapterPolltime = 20000;
    }
  }
}
