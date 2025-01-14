// Decompiled with JetBrains decompiler
// Type: ExamCookie.WinClient.ApplicationThread
// Assembly: ExamCookie.WinClient, Version=1.4.1.4, Culture=neutral, PublicKeyToken=null
// MVID: E12BE1F8-B6E0-4BF5-B308-166F0E938C4B
// Assembly location: C:\Users\oskar\Downloads\ExamCookie1414.WinClient.exe

using ExamCookie.Library;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using UIAutomationClient;

#nullable disable
namespace ExamCookie.WinClient
{
  public class ApplicationThread
  {
    private const int THREAD_SLEEP = 1000;
    private bool _Started;

    public event ApplicationThread.OnApplicationChangedEventHandler OnApplicationChanged;

    public event ApplicationThread.OnDebugEventHandler OnDebug;

    public event ApplicationThread.OnExceptionEventHandler OnException;

    [DllImport("user32.dll")]
    private static extern IntPtr GetForegroundWindow();

    [DllImport("user32.dll")]
    private static extern IntPtr GetWindowThreadProcessId(IntPtr hwnd, ref int processId);

    [DllImport("user32.dll")]
    private static extern bool GetWindowRect(IntPtr hWnd, ref ApplicationThread.RECT lpRect);

    public ApplicationThread() => this._Started = false;

    public ApplicationThread(int polltime)
    {
      ApplicationThread applicationThread = this;
      this._Started = false;
      if (polltime <= 0)
        return;
      if (polltime < 1000)
        polltime = 1000;
      Thread thread = new Thread((ThreadStart) ([SpecialName] () => applicationThread.Main(polltime)));
      this.Started = true;
      thread.Start();
    }

    public bool Started
    {
      get => this._Started;
      set => this._Started = value;
    }

    public Rectangle GetFrontWindowRect()
    {
      Rectangle frontWindowRect;
      try
      {
        IntPtr num = (IntPtr) 0;
        int processId = 0;
        ApplicationThread.RECT lpRect = new ApplicationThread.RECT();
        IntPtr foregroundWindow = ApplicationThread.GetForegroundWindow();
        ApplicationThread.GetWindowThreadProcessId(foregroundWindow, ref processId);
        ApplicationThread.GetWindowRect(foregroundWindow, ref lpRect);
        frontWindowRect = System.Diagnostics.Process.GetProcessById(processId) == null ? new Rectangle() : this.RECTToRectangle(lpRect);
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        frontWindowRect = new Rectangle();
        ProjectData.ClearProjectError();
      }
      return frontWindowRect;
    }

    private void Main(int polltime)
    {
      Stopwatch stopwatch = new Stopwatch();
      stopwatch.Start();
      IntPtr num1 = (IntPtr) 0;
      IntPtr num2 = (IntPtr) 0;
      int processId = 0;
      ApplicationThread.RECT lpRect = new ApplicationThread.RECT();
      bool flag = false;
      string result = "";
      string Left = "¤";
      System.Diagnostics.Process process = (System.Diagnostics.Process) null;
      List<string> source = new List<string>();
      source.AddRange((IEnumerable<string>) new string[6]
      {
        "devenv",
        "ExamCookie.WinClient",
        "ExamCookie.WinIEClient",
        "ExamCookie.WinClient.vshost",
        "wermgr",
        "ShellExperienceHost"
      });
      while (this.Started)
      {
        try
        {
          if (stopwatch.ElapsedMilliseconds >= (long) polltime)
          {
            stopwatch.Restart();
            IntPtr foregroundWindow = ApplicationThread.GetForegroundWindow();
            if (num1 != foregroundWindow)
            {
              num1 = foregroundWindow;
              ApplicationThread.GetWindowThreadProcessId(num1, ref processId);
              ApplicationThread.GetWindowRect(num1, ref lpRect);
              process = System.Diagnostics.Process.GetProcessById(processId);
              if (process != null)
              {
                switch (this.GetBrowserUrl(process, process.ProcessName, ref result))
                {
                  case 0:
                    flag = true;
                    break;
                  case 1:
                    Left = "¤";
                    if (!source.Contains<string>(process.ProcessName, (IEqualityComparer<string>) StringComparer.OrdinalIgnoreCase))
                    {
                      // ISSUE: reference to a compiler-generated field
                      ApplicationThread.OnApplicationChangedEventHandler applicationChangedEvent = this.OnApplicationChangedEvent;
                      if (applicationChangedEvent != null)
                        applicationChangedEvent(new ApplicationThread.ApplicationChanged(this.RECTToRectangle(lpRect), eApplicationType.APPLICATION, process.ProcessName, process.MainWindowTitle));
                      break;
                    }
                    break;
                  default:
                    Module1.DebugPrint(string.Format("BROWSER [{0}]. (Fejl = {1})", (object) process.ProcessName, (object) result));
                    break;
                }
              }
            }
            else
              flag = this.GetBrowserUrl(process, process.ProcessName, ref result) == 0;
            if (flag)
            {
              flag = false;
              if (Operators.CompareString(Left, result, false) != 0)
              {
                Left = result;
                // ISSUE: reference to a compiler-generated field
                ApplicationThread.OnApplicationChangedEventHandler applicationChangedEvent = this.OnApplicationChangedEvent;
                if (applicationChangedEvent != null)
                  applicationChangedEvent(new ApplicationThread.ApplicationChanged(this.RECTToRectangle(lpRect), eApplicationType.BROWSER, process.ProcessName, result));
              }
            }
            Thread.Sleep(1000);
          }
        }
        catch (Exception ex1)
        {
          ProjectData.SetProjectError(ex1);
          Exception ex2 = ex1;
          // ISSUE: reference to a compiler-generated field
          ApplicationThread.OnExceptionEventHandler onExceptionEvent = this.OnExceptionEvent;
          if (onExceptionEvent != null)
            onExceptionEvent(ex2);
          ProjectData.ClearProjectError();
        }
        finally
        {
          Thread.Sleep(1000);
        }
      }
    }

    private int GetBrowserUrl(System.Diagnostics.Process process, string name, ref string result)
    {
      int browserUrl;
      try
      {
        if (!((IEnumerable<string>) new string[6]
        {
          "iexplore",
          "chrome",
          "brave",
          "firefox",
          "msedge",
          "opera"
        }).Contains<string>(name.ToLower()))
        {
          result = "Ukendt browser";
          browserUrl = 1;
        }
        else
        {
          // ISSUE: variable of a compiler-generated type
          CUIAutomation instance = (CUIAutomation) Activator.CreateInstance(Marshal.GetTypeFromCLSID(new Guid("FF48DBA4-60EF-4201-AA87-54103EEF594E")));
          List<IUIAutomationCondition> automationConditionList = new List<IUIAutomationCondition>();
          // ISSUE: reference to a compiler-generated method
          automationConditionList.Add(instance.CreatePropertyCondition(30002, (object) process.Id));
          // ISSUE: reference to a compiler-generated method
          automationConditionList.Add(instance.CreatePropertyCondition(30003, (object) 50004));
          string lower = name.ToLower();
          if (Operators.CompareString(lower, "iexplore", false) != 0)
          {
            if (Operators.CompareString(lower, "chrome", false) != 0 && Operators.CompareString(lower, "brave", false) != 0)
            {
              if (Operators.CompareString(lower, "firefox", false) != 0)
              {
                if (Operators.CompareString(lower, "msedge", false) != 0)
                {
                  if (Operators.CompareString(lower, "opera", false) == 0)
                  {
                    // ISSUE: reference to a compiler-generated method
                    // ISSUE: reference to a compiler-generated method
                    // ISSUE: reference to a compiler-generated method
                    automationConditionList.Add(instance.CreateOrCondition(instance.CreatePropertyCondition(30005, (object) "Adressefelt"), instance.CreatePropertyCondition(30005, (object) "Address field")));
                  }
                }
                else
                {
                  // ISSUE: reference to a compiler-generated method
                  automationConditionList.Add(instance.CreatePropertyCondition(30012, (object) "OmniboxViewViews"));
                }
              }
              else
              {
                // ISSUE: reference to a compiler-generated method
                automationConditionList.Add(instance.CreatePropertyCondition(30024, (object) "Gecko"));
              }
            }
            else
            {
              // ISSUE: reference to a compiler-generated method
              automationConditionList.Add(instance.CreatePropertyCondition(30007, (object) "Ctrl+L"));
            }
          }
          else
          {
            // ISSUE: reference to a compiler-generated method
            automationConditionList.Add(instance.CreatePropertyCondition(30012, (object) "Edit"));
          }
          // ISSUE: reference to a compiler-generated method
          // ISSUE: variable of a compiler-generated type
          IUIAutomationElement rootElement = instance.GetRootElement();
          // ISSUE: reference to a compiler-generated method
          // ISSUE: reference to a compiler-generated method
          // ISSUE: variable of a compiler-generated type
          IUIAutomationElement first = rootElement.FindFirst(TreeScope.TreeScope_Subtree, instance.CreateAndConditionFromArray((Array) automationConditionList.ToArray()));
          if (first != null)
          {
            // ISSUE: reference to a compiler-generated method
            // ISSUE: variable of a compiler-generated type
            IUIAutomationValuePattern currentPattern = (IUIAutomationValuePattern) first.GetCurrentPattern(10002);
            if (currentPattern != null)
            {
              result = currentPattern.CurrentValue.ToUri();
              browserUrl = 0;
              goto label_20;
            }
            else
              result = "Mønster ikke fundet";
          }
          else
            result = "Adresse felt ikke fundet";
          browserUrl = 2;
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Exception exception = ex;
        result = exception.ToString();
        browserUrl = 3;
        ProjectData.ClearProjectError();
      }
label_20:
      return browserUrl;
    }

    private void ScaleWindowRect(ref ApplicationThread.RECT rect)
    {
      try
      {
        int width = 0;
        List<RectangleF> rectangleFList1 = new List<RectangleF>();
        Screen[] allScreens = Screen.AllScreens;
        int index = 0;
        while (index < allScreens.Length)
        {
          Screen screen = allScreens[index];
          Module1.DEVMODE lpDevMode = new Module1.DEVMODE();
          lpDevMode.dmSize = checked ((short) Marshal.SizeOf(typeof (Module1.DEVMODE)));
          Module1.EnumDisplaySettings(screen.DeviceName, -1, ref lpDevMode);
          Decimal d1 = new Decimal(lpDevMode.dmPelsWidth);
          Rectangle bounds = screen.Bounds;
          Decimal d2 = new Decimal(bounds.Width);
          Decimal num = Math.Round(Decimal.Divide(d1, d2), 2);
          List<RectangleF> rectangleFList2 = rectangleFList1;
          bounds = screen.Bounds;
          RectangleF rectangleF = new RectangleF((float) bounds.X, Convert.ToSingle(num), (float) width, 0.0f);
          rectangleFList2.Add(rectangleF);
          checked { width += lpDevMode.dmPelsWidth; }
          checked { ++index; }
        }
        rectangleFList1.Reverse();
        try
        {
          foreach (RectangleF rectangleF in rectangleFList1)
          {
            if ((double) rect.Left > (double) rectangleF.X - 15.0)
            {
              rect.Left = checked ((int) Math.Round(unchecked (((double) checked (rect.Left + 12) - (double) rectangleF.X) * (double) rectangleF.Y + (double) rectangleF.Width)));
              rect.Right = checked ((int) Math.Round(unchecked (((double) checked (rect.Right - 12) - (double) rectangleF.X) * (double) rectangleF.Y + (double) rectangleF.Width)));
              rect.Top = checked ((int) Math.Round(unchecked ((double) checked (rect.Top + 12) * (double) rectangleF.Y)));
              rect.Bottom = checked ((int) Math.Round(unchecked ((double) checked (rect.Bottom - 12) * (double) rectangleF.Y)));
              break;
            }
          }
        }
        finally
        {
          List<RectangleF>.Enumerator enumerator;
          enumerator.Dispose();
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        ProjectData.ClearProjectError();
      }
    }

    private Rectangle RECTToRectangle(ApplicationThread.RECT rect)
    {
      this.ScaleWindowRect(ref rect);
      return new Rectangle(rect.Left, rect.Top, checked (rect.Right - rect.Left), checked (rect.Bottom - rect.Top));
    }

    public delegate void OnApplicationChangedEventHandler(
      ApplicationThread.ApplicationChanged sender);

    public delegate void OnDebugEventHandler(string message);

    public delegate void OnExceptionEventHandler(Exception ex);

    public struct RECT
    {
      public int Left;
      public int Top;
      public int Right;
      public int Bottom;
    }

    [Serializable]
    public class ApplicationChanged
    {
      public string Reference;
      public string Token;
      public DateTime CanSend;
      public DateTime TimeStamp;
      public Rectangle Rectangle;
      public eApplicationType Type;
      public string Name;
      public string Document;
      public string FileDescription;
      public string InternalName;

      public ApplicationChanged()
      {
        this.Reference = Guid.NewGuid().ToString();
        this.Token = "";
        this.CanSend = DateTime.MinValue;
        this.TimeStamp = DateTime.MinValue;
        this.Rectangle = new Rectangle();
        this.Name = "";
        this.Document = "";
        this.FileDescription = "";
        this.InternalName = "";
      }

      public ApplicationChanged(
        Rectangle rectangle,
        eApplicationType type,
        string name,
        string document)
      {
        this.Reference = Guid.NewGuid().ToString();
        this.Token = "";
        this.CanSend = DateTime.MinValue;
        this.TimeStamp = DateTime.MinValue;
        this.Rectangle = new Rectangle();
        this.Name = "";
        this.Document = "";
        this.FileDescription = "";
        this.InternalName = "";
        this.Rectangle = rectangle;
        this.Type = type;
        this.Name = name;
        this.Document = document;
      }

      public ApplicationChanged(
        Rectangle rectangle,
        eApplicationType type,
        string name,
        string document,
        string fileDescription,
        string internalName)
      {
        this.Reference = Guid.NewGuid().ToString();
        this.Token = "";
        this.CanSend = DateTime.MinValue;
        this.TimeStamp = DateTime.MinValue;
        this.Rectangle = new Rectangle();
        this.Name = "";
        this.Document = "";
        this.FileDescription = "";
        this.InternalName = "";
        this.Rectangle = rectangle;
        this.Type = type;
        this.Name = name;
        this.Document = document;
        this.FileDescription = fileDescription;
        this.InternalName = internalName;
      }
    }
  }
}
