// Decompiled with JetBrains decompiler
// Type: ExamCookie.WinClient.FormMain
// Assembly: ExamCookie.WinClient, Version=1.4.1.4, Culture=neutral, PublicKeyToken=null
// MVID: E12BE1F8-B6E0-4BF5-B308-166F0E938C4B
// Assembly location: C:\Users\oskar\Downloads\ExamCookie1414.WinClient.exe

using ExamCookie.Library;
using ExamCookie.WinClient.ExamApiV3Service;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

#nullable disable
namespace ExamCookie.WinClient
{
  [DesignerGenerated]
  public class FormMain : Form
  {
    private IContainer components;
    private Random _Random;
    private const int WM_CLIPBOARDUPDATE = 797;
    private const int WM_POWERBROADCAST = 536;
    private const int PBT_APMSUSPEND = 4;
    private const int PBT_APMRESUMESUSPEND = 7;
    private const int PBT_APMRESUMEAUTOMATIC = 18;
    private const int WH_MOUSE_LL = 14;
    private const int WM_RBUTTONDOWN = 516;
    private IntPtr HookHandle;
    private FormMain.eSessionMode _SessionMode;
    private Dictionary<eEventType, int> SendDelays;
    private Stopwatch KillSwitch;
    [SpecialName]
    private bool \u0024STATIC\u0024HasExamEnded\u002420122\u0024flag;
    [SpecialName]
    private StaticLocalInitFlag \u0024STATIC\u0024HasExamEnded\u002420122\u0024flag\u0024Init;
    [SpecialName]
    private string[] \u0024STATIC\u0024Notify\u00242021E1DE\u0024last;
    [SpecialName]
    private StaticLocalInitFlag \u0024STATIC\u0024Notify\u00242021E1DE\u0024last\u0024Init;
    [SpecialName]
    private DateTime \u0024STATIC\u0024OnPowerChange\u002420118\u0024ThisTime;
    [SpecialName]
    private StaticLocalInitFlag \u0024STATIC\u0024OnPowerChange\u002420118\u0024ThisTime\u0024Init;
    [SpecialName]
    private int \u0024STATIC\u0024OnTimerTick\u002420211C1280A5\u0024ticks;
    [SpecialName]
    private StaticLocalInitFlag \u0024STATIC\u0024OnTimerTick\u002420211C1280A5\u0024ticks\u0024Init;

    public FormMain()
    {
      this.Load += new EventHandler(this.FormMain_Load);
      this.FormClosing += new FormClosingEventHandler(this.FormMain_FormClosing);
      this.Resize += new EventHandler(this.FormMain_Resize);
      this.Move += new EventHandler(this.FormMain_Move);
      this.SizeChanged += new EventHandler(this.FormMain_Move);
      this._Random = new Random();
      this.OverlayForm = new Form();
      this.ClientClock = (ClientClock) null;
      this.AdapThread = (AdapterThread) null;
      this.ApplThread = (ApplicationThread) null;
      this.ClipThread = (ClipboardThread) null;
      this.ProcThread = (ProcessThread) null;
      this.ScrnThread = (ScreenThread) null;
      this.UpldThread = (UploadThread) null;
      this.ConfThread = (ConfigurationThread) null;
      this._SessionMode = FormMain.eSessionMode.INIT;
      this.SendDelays = new Dictionary<eEventType, int>();
      this.KillSwitch = new Stopwatch();
      this.InitializeComponent();
    }

    [DebuggerNonUserCode]
    protected override void Dispose(bool disposing)
    {
      try
      {
        if (!disposing || this.components == null)
          return;
        this.components.Dispose();
      }
      finally
      {
        base.Dispose(disposing);
      }
    }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.components = (IContainer) new System.ComponentModel.Container();
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (FormMain));
      this.TmrTick = new System.Windows.Forms.Timer(this.components);
      this.Panel1 = new Panel();
      this.SuspendLayout();
      this.TmrTick.Interval = 1000;
      this.Panel1.BackColor = Color.Transparent;
      this.Panel1.BackgroundImage = (Image) ExamCookie.WinClient.My.Resources.Resources.ec_blue;
      this.Panel1.BackgroundImageLayout = ImageLayout.Zoom;
      this.Panel1.ForeColor = SystemColors.ControlText;
      this.Panel1.Location = new Point(0, 0);
      this.Panel1.Margin = new Padding(3, 2, 3, 2);
      this.Panel1.Name = "Panel1";
      this.Panel1.Size = new Size(72, 80);
      this.Panel1.TabIndex = 9;
      this.AutoScaleDimensions = new SizeF(9f, 20f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(90, 100);
      this.Controls.Add((Control) this.Panel1);
      this.FormBorderStyle = FormBorderStyle.None;
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.Margin = new Padding(3, 4, 3, 4);
      this.Name = nameof (FormMain);
      this.ShowInTaskbar = false;
      this.StartPosition = FormStartPosition.Manual;
      this.Text = "ExamCookie";
      this.TopMost = true;
      this.ResumeLayout(false);
    }

    internal virtual System.Windows.Forms.Timer TmrTick
    {
      get => this._TmrTick;
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.OnTimerTick);
        System.Windows.Forms.Timer tmrTick1 = this._TmrTick;
        if (tmrTick1 != null)
          tmrTick1.Tick -= eventHandler;
        this._TmrTick = value;
        System.Windows.Forms.Timer tmrTick2 = this._TmrTick;
        if (tmrTick2 == null)
          return;
        tmrTick2.Tick += eventHandler;
      }
    }

    internal virtual Panel Panel1
    {
      get => this._Panel1;
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        MouseEventHandler mouseEventHandler = new MouseEventHandler(this.FormMain_MouseDown);
        Panel panel1_1 = this._Panel1;
        if (panel1_1 != null)
          panel1_1.MouseDown -= mouseEventHandler;
        this._Panel1 = value;
        Panel panel1_2 = this._Panel1;
        if (panel1_2 == null)
          return;
        panel1_2.MouseDown += mouseEventHandler;
      }
    }

    private virtual Form OverlayForm
    {
      get => this._OverlayForm;
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        MouseEventHandler mouseEventHandler = new MouseEventHandler(this.FormMain_MouseDown);
        Form overlayForm1 = this._OverlayForm;
        if (overlayForm1 != null)
          overlayForm1.MouseDown -= mouseEventHandler;
        this._OverlayForm = value;
        Form overlayForm2 = this._OverlayForm;
        if (overlayForm2 == null)
          return;
        overlayForm2.MouseDown += mouseEventHandler;
      }
    }

    [field: AccessedThroughProperty("ClientClock")]
    private virtual ClientClock ClientClock { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    private virtual AdapterThread AdapThread
    {
      get => this._AdapThread;
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        AdapterThread.OnAdapterChangedEventHandler changedEventHandler = new AdapterThread.OnAdapterChangedEventHandler(this.OnAdapterChanged);
        AdapterThread.OnDebugEventHandler debugEventHandler = new AdapterThread.OnDebugEventHandler(this.OnThreadDebug);
        AdapterThread.OnExceptionEventHandler exceptionEventHandler = new AdapterThread.OnExceptionEventHandler(this.OnThreadException);
        AdapterThread adapThread1 = this._AdapThread;
        if (adapThread1 != null)
        {
          adapThread1.OnAdapterChanged -= changedEventHandler;
          adapThread1.OnDebug -= debugEventHandler;
          adapThread1.OnException -= exceptionEventHandler;
        }
        this._AdapThread = value;
        AdapterThread adapThread2 = this._AdapThread;
        if (adapThread2 == null)
          return;
        adapThread2.OnAdapterChanged += changedEventHandler;
        adapThread2.OnDebug += debugEventHandler;
        adapThread2.OnException += exceptionEventHandler;
      }
    }

    private virtual ApplicationThread ApplThread
    {
      get => this._ApplThread;
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        ApplicationThread.OnApplicationChangedEventHandler changedEventHandler = new ApplicationThread.OnApplicationChangedEventHandler(this.OnApplicationChanged);
        ApplicationThread.OnDebugEventHandler debugEventHandler = new ApplicationThread.OnDebugEventHandler(this.OnThreadDebug);
        ApplicationThread.OnExceptionEventHandler exceptionEventHandler = new ApplicationThread.OnExceptionEventHandler(this.OnThreadException);
        ApplicationThread applThread1 = this._ApplThread;
        if (applThread1 != null)
        {
          applThread1.OnApplicationChanged -= changedEventHandler;
          applThread1.OnDebug -= debugEventHandler;
          applThread1.OnException -= exceptionEventHandler;
        }
        this._ApplThread = value;
        ApplicationThread applThread2 = this._ApplThread;
        if (applThread2 == null)
          return;
        applThread2.OnApplicationChanged += changedEventHandler;
        applThread2.OnDebug += debugEventHandler;
        applThread2.OnException += exceptionEventHandler;
      }
    }

    private virtual ClipboardThread ClipThread
    {
      get => this._ClipThread;
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        ClipboardThread.OnClipboardChangedEventHandler changedEventHandler = new ClipboardThread.OnClipboardChangedEventHandler(this.OnClipboardChanged);
        ClipboardThread.OnDebugEventHandler debugEventHandler = new ClipboardThread.OnDebugEventHandler(this.OnThreadDebug);
        ClipboardThread.OnExceptionEventHandler exceptionEventHandler = new ClipboardThread.OnExceptionEventHandler(this.OnThreadException);
        ClipboardThread clipThread1 = this._ClipThread;
        if (clipThread1 != null)
        {
          clipThread1.OnClipboardChanged -= changedEventHandler;
          clipThread1.OnDebug -= debugEventHandler;
          clipThread1.OnException -= exceptionEventHandler;
        }
        this._ClipThread = value;
        ClipboardThread clipThread2 = this._ClipThread;
        if (clipThread2 == null)
          return;
        clipThread2.OnClipboardChanged += changedEventHandler;
        clipThread2.OnDebug += debugEventHandler;
        clipThread2.OnException += exceptionEventHandler;
      }
    }

    private virtual ProcessThread ProcThread
    {
      get => this._ProcThread;
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        ProcessThread.OnProcessChangedEventHandler changedEventHandler = new ProcessThread.OnProcessChangedEventHandler(this.OnProcessChanged);
        ProcessThread.OnDebugEventHandler debugEventHandler = new ProcessThread.OnDebugEventHandler(this.OnThreadDebug);
        ProcessThread.OnExceptionEventHandler exceptionEventHandler = new ProcessThread.OnExceptionEventHandler(this.OnThreadException);
        ProcessThread procThread1 = this._ProcThread;
        if (procThread1 != null)
        {
          procThread1.OnProcessChanged -= changedEventHandler;
          procThread1.OnDebug -= debugEventHandler;
          procThread1.OnException -= exceptionEventHandler;
        }
        this._ProcThread = value;
        ProcessThread procThread2 = this._ProcThread;
        if (procThread2 == null)
          return;
        procThread2.OnProcessChanged += changedEventHandler;
        procThread2.OnDebug += debugEventHandler;
        procThread2.OnException += exceptionEventHandler;
      }
    }

    private virtual ScreenThread ScrnThread
    {
      get => this._ScrnThread;
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        ScreenThread.OnScreenChangedEventHandler changedEventHandler = new ScreenThread.OnScreenChangedEventHandler(this.OnScreenChanged);
        ScreenThread.OnDebugEventHandler debugEventHandler = new ScreenThread.OnDebugEventHandler(this.OnThreadDebug);
        ScreenThread.OnExceptionEventHandler exceptionEventHandler = new ScreenThread.OnExceptionEventHandler(this.OnThreadException);
        ScreenThread scrnThread1 = this._ScrnThread;
        if (scrnThread1 != null)
        {
          scrnThread1.OnScreenChanged -= changedEventHandler;
          scrnThread1.OnDebug -= debugEventHandler;
          scrnThread1.OnException -= exceptionEventHandler;
        }
        this._ScrnThread = value;
        ScreenThread scrnThread2 = this._ScrnThread;
        if (scrnThread2 == null)
          return;
        scrnThread2.OnScreenChanged += changedEventHandler;
        scrnThread2.OnDebug += debugEventHandler;
        scrnThread2.OnException += exceptionEventHandler;
      }
    }

    private virtual UploadThread UpldThread
    {
      get => this._UpldThread;
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        UploadThread.OnOnlineChangedEventHandler changedEventHandler = new UploadThread.OnOnlineChangedEventHandler(this.OnOnlineChanged);
        UploadThread.OnHeartbeatEventHandler heartbeatEventHandler = new UploadThread.OnHeartbeatEventHandler(this.OnHeartbeat);
        UploadThread.OnDebugEventHandler debugEventHandler = new UploadThread.OnDebugEventHandler(this.OnThreadDebug);
        UploadThread.OnExceptionEventHandler exceptionEventHandler = new UploadThread.OnExceptionEventHandler(this.OnThreadException);
        UploadThread upldThread1 = this._UpldThread;
        if (upldThread1 != null)
        {
          upldThread1.OnOnlineChanged -= changedEventHandler;
          upldThread1.OnHeartbeat -= heartbeatEventHandler;
          upldThread1.OnDebug -= debugEventHandler;
          upldThread1.OnException -= exceptionEventHandler;
        }
        this._UpldThread = value;
        UploadThread upldThread2 = this._UpldThread;
        if (upldThread2 == null)
          return;
        upldThread2.OnOnlineChanged += changedEventHandler;
        upldThread2.OnHeartbeat += heartbeatEventHandler;
        upldThread2.OnDebug += debugEventHandler;
        upldThread2.OnException += exceptionEventHandler;
      }
    }

    private virtual ConfigurationThread ConfThread
    {
      get => this._ConfThread;
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        ConfigurationThread.OnConfigurationChangedEventHandler changedEventHandler = new ConfigurationThread.OnConfigurationChangedEventHandler(this.OnConfigurationChanged);
        ConfigurationThread.OnDebugEventHandler debugEventHandler = new ConfigurationThread.OnDebugEventHandler(this.OnThreadDebug);
        ConfigurationThread.OnExceptionEventHandler exceptionEventHandler = new ConfigurationThread.OnExceptionEventHandler(this.OnThreadException);
        ConfigurationThread confThread1 = this._ConfThread;
        if (confThread1 != null)
        {
          confThread1.OnConfigurationChanged -= changedEventHandler;
          confThread1.OnDebug -= debugEventHandler;
          confThread1.OnException -= exceptionEventHandler;
        }
        this._ConfThread = value;
        ConfigurationThread confThread2 = this._ConfThread;
        if (confThread2 == null)
          return;
        confThread2.OnConfigurationChanged += changedEventHandler;
        confThread2.OnDebug += debugEventHandler;
        confThread2.OnException += exceptionEventHandler;
      }
    }

    private void FormMain_Load(object sender, EventArgs e)
    {
      try
      {
        Control.CheckForIllegalCrossThreadCalls = false;
        this.RegisterMSHTML();
        Module1.Log((object) MethodBase.GetCurrentMethod(), "ExamCookie Win Client starter...");
        Module1.Log((object) MethodBase.GetCurrentMethod(), "APP_DATA_PATH={0}", (object) Module1.APP_DATA_PATH);
        Module1.Log((object) MethodBase.GetCurrentMethod(), "APP_FILENAME={0}", (object) Module1.APP_FILENAME);
        Module1.Log((object) MethodBase.GetCurrentMethod(), "APP_CURRENT_DIR={0}", (object) Module1.APP_CURRENT_DIR);
        string[] commandLineArgs = Environment.GetCommandLineArgs();
        int index = 0;
        while (index < commandLineArgs.Length)
        {
          if (Operators.CompareString(commandLineArgs[index], "-L", false) == 0)
            Module1.LOG_SESSION_LOCAL = true;
          checked { ++index; }
        }
        this.TransparencyKey = this.BackColor;
        this.Owner = this.OverlayForm;
        this.ShowInTaskbar = false;
        this.OverlayForm.FormBorderStyle = FormBorderStyle.None;
        this.OverlayForm.Opacity = 0.01;
        this.OverlayForm.Icon = this.Icon;
        this.OverlayForm.Text = this.Text;
        this.OverlayForm.ShowInTaskbar = false;
        this.OverlayForm.Show();
        this.OverlayForm.TopMost = true;
        this.Size = this.Panel1.Size;
        this.SessionMode = FormMain.eSessionMode.BEGIN_SIGN_IN;
        this.SetIconStatus((Image) ExamCookie.WinClient.My.Resources.Resources.ec_blue);
        Module1.SetComputerClock();
        this.TmrTick.Start();
        Module1.Log((object) MethodBase.GetCurrentMethod(), "ExamCookie Win Client startet");
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) Interaction.MsgBox((object) ex.Message, MsgBoxStyle.Critical);
        ProjectData.ClearProjectError();
      }
    }

    private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
    {
      int num1;
      int num2;
      try
      {
label_2:
        ProjectData.ClearProjectError();
        num1 = -2;
label_3:
        int num3 = 2;
        Module1.Log((object) MethodBase.GetCurrentMethod(), "{0}={1}", (object) "CloseReason", (object) e.CloseReason.ToString());
label_4:
        num3 = 3;
        if (this.HasExamEnded())
          goto label_7;
label_5:
        num3 = 4;
        Module1.USER_SIGNED_OUT = true;
label_6:
label_7:
label_8:
        num3 = 6;
        this.HasExamEnded(true);
label_9:
        num3 = 7;
        this.SignOut();
label_10:
        num3 = 8;
        this.TmrTick.Stop();
label_11:
        num3 = 9;
        this.StopThreads(FormMain.eThreadStopMode.STOP_ALL);
label_12:
        num3 = 10;
        this.AdapThread = (AdapterThread) null;
label_13:
        num3 = 11;
        this.ApplThread = (ApplicationThread) null;
label_14:
        num3 = 12;
        this.ClipThread = (ClipboardThread) null;
label_15:
        num3 = 13;
        this.ProcThread = (ProcessThread) null;
label_16:
        num3 = 14;
        this.ScrnThread = (ScreenThread) null;
label_17:
        num3 = 15;
        this.UpldThread = (UploadThread) null;
label_18:
        num3 = 16;
        this.ConfThread = (ConfigurationThread) null;
label_19:
        num3 = 17;
        this.ClientClock = (ClientClock) null;
label_20:
        num3 = 18;
        Module1.Log((object) MethodBase.GetCurrentMethod(), "ExamCookie Win Client stoppet");
label_21:
        num3 = 19;
        int num4 = Module1.LOG_SESSION ? 1 : 0;
        string userSignInToken = Module1.USER_SIGN_IN_TOKEN;
        Guid guid = new Guid();
        ref Guid local = ref guid;
        int num5 = Guid.TryParse(userSignInToken, out local) ? 1 : 0;
        if ((num4 & num5) == 0)
          goto label_24;
label_22:
        num3 = 20;
        this.UploadSessionLog();
label_23:
label_24:
label_25:
        num3 = 22;
        Module1.SessionLog.Clear();
label_26:
        num3 = 23;
        this.Uninstall(this.SessionMode);
        goto label_33;
label_28:
        num2 = num3;
        switch (num1 > -2 ? num1 : 1)
        {
          case 1:
            int num6 = num2 + 1;
            num2 = 0;
            switch (num6)
            {
              case 1:
                goto label_2;
              case 2:
                goto label_3;
              case 3:
                goto label_4;
              case 4:
                goto label_5;
              case 5:
                goto label_6;
              case 6:
                goto label_8;
              case 7:
                goto label_9;
              case 8:
                goto label_10;
              case 9:
                goto label_11;
              case 10:
                goto label_12;
              case 11:
                goto label_13;
              case 12:
                goto label_14;
              case 13:
                goto label_15;
              case 14:
                goto label_16;
              case 15:
                goto label_17;
              case 16:
                goto label_18;
              case 17:
                goto label_19;
              case 18:
                goto label_20;
              case 19:
                goto label_21;
              case 20:
                goto label_22;
              case 21:
                goto label_23;
              case 22:
                goto label_25;
              case 23:
                goto label_26;
              case 24:
                goto label_33;
            }
            break;
        }
      }
      catch (Exception ex) when (ex is Exception & num1 != 0 & num2 == 0)
      {
        ProjectData.SetProjectError(ex);
        goto label_28;
      }
      throw ProjectData.CreateProjectError(-2146828237);
label_33:
      if (num2 == 0)
        return;
      ProjectData.ClearProjectError();
    }

    private void FormMain_Resize(object sender, EventArgs e)
    {
      Rectangle workingArea = Screen.PrimaryScreen.WorkingArea;
      int x = checked (workingArea.Width - this.Width - 20);
      workingArea = Screen.PrimaryScreen.WorkingArea;
      int y = checked (workingArea.Height - 95);
      this.Location = new Point(x, y);
    }

    private void FormMain_Move(object sender, EventArgs e) => this.OverlayForm.Bounds = this.Bounds;

    private void FormMain_MouseDown(object sender, MouseEventArgs e)
    {
      try
      {
        if (e.Button == MouseButtons.Left)
        {
          if (!(this.SessionMode == FormMain.eSessionMode.SIGNED_IN | this.SessionMode == FormMain.eSessionMode.EXAM_STARTED))
            return;
          using (FormInfo formInfo = new FormInfo())
          {
            formInfo.Config = Module1.Config;
            if (this.ScrnThread != null)
              this.ScrnThread.TakeScreenshot(1);
            if (formInfo.ShowDialog((IWin32Window) this) == DialogResult.Yes)
            {
              formInfo.Dispose();
              this.Notify("ExamCookie", new string[2]
              {
                "Du har afsluttet eksamen",
                "og programmet lukker om et øjeblik."
              });
              Module1.USER_SIGNED_OUT = true;
              this.SessionMode = FormMain.eSessionMode.EXAM_ENDED;
              Module1.Log((object) MethodBase.GetCurrentMethod(), "Elev har valgt af afslutte før tid");
            }
          }
          this.Show();
          this.TopMost = true;
        }
        else
        {
          if (e.Button != MouseButtons.Right)
            return;
          this.Notify("ExamCookie");
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Exception exception = ex;
        Module1.Log(Module1.LogType.ERROR, (object) MethodBase.GetCurrentMethod(), exception.ToString());
        ProjectData.ClearProjectError();
      }
    }

    protected override void WndProc(ref Message m)
    {
      switch (m.Msg)
      {
        case 536:
          Module1.Log((object) MethodBase.GetCurrentMethod(), "WM_POWERBROADCAST");
          this.OnPowerChange(m.WParam.ToInt32());
          break;
        case 797:
          try
          {
            if (this.ClipThread != null)
            {
              Module1.Log((object) MethodBase.GetCurrentMethod(), "WM_CLIPBOARDUPDATE");
              this.ClipThread.GetClipboardData();
              break;
            }
            break;
          }
          catch (Exception ex)
          {
            ProjectData.SetProjectError(ex);
            Exception exception = ex;
            Module1.Log(Module1.LogType.ERROR, (object) MethodBase.GetCurrentMethod(), exception.ToString());
            ProjectData.ClearProjectError();
            break;
          }
      }
      base.WndProc(ref m);
    }

    public FormMain.eSessionMode SessionMode
    {
      get => this._SessionMode;
      set
      {
        Module1.Log((object) MethodBase.GetCurrentMethod(), value.ToString());
        this._SessionMode = value;
      }
    }

    private void SetIconStatus(Image icon) => this.Panel1.BackgroundImage = icon;

    private void RegisterMSHTML()
    {
      try
      {
        if (Operators.CompareString(Module1.GetWindowsReleaseId(), "1709", false) != 0)
          return;
        string path1 = string.Format("{0}RegAsm.exe", (object) RuntimeEnvironment.GetRuntimeDirectory());
        string path2 = string.Format("{0}Windows\\assembly\\GAC\\Microsoft.mshtml\\7.0.3300.0__b03f5f7f11d50a3a\\Microsoft.mshtml.dll", (object) Path.GetPathRoot(Environment.SystemDirectory));
        if (File.Exists(path1) && File.Exists(path2))
        {
          string str = Module1.RunCommand(string.Format("CD {0} & {1} Microsoft.mshtml.dll", (object) Path.GetDirectoryName(path2), (object) path1));
          Module1.Log((object) MethodBase.GetCurrentMethod(), "Result={0}", (object) str);
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        ProjectData.ClearProjectError();
      }
    }

    private void StartThreads()
    {
      Module1.Log((object) MethodBase.GetCurrentMethod(), nameof (StartThreads));
      try
      {
        ClientConfig clientConfiguration = Module1.Config.ClientConfiguration;
        this.InitSendDelay(eEventType.SCREENSHOT, clientConfiguration.ScreenPolltime);
        this.ScrnThread = new ScreenThread(clientConfiguration.ScreenPolltime);
        this.ScrnThread.ScreenChangedPercent = (float) clientConfiguration.ScreenChangedPercentWindows;
        this.ScrnThread.PostSendDelay = checked (clientConfiguration.ScreenSendDelay * 1000);
        this.ScrnThread.ForceScreenshotDelay = checked (clientConfiguration.ScreenForceSendTime * 1000);
        this.ScrnThread.ImageQuality = clientConfiguration.ImageQuality;
        this.InitSendDelay(eEventType.ADAPTER, clientConfiguration.AdapterPolltime);
        this.AdapThread = new AdapterThread(clientConfiguration.AdapterPolltime);
        this.InitSendDelay(eEventType.FRONT_APP, clientConfiguration.FrontAppPolltime);
        this.ApplThread = new ApplicationThread(clientConfiguration.FrontAppPolltime);
        this.InitSendDelay(eEventType.CLIPBOARD, clientConfiguration.ClipboardPolltime);
        this.ClipThread = new ClipboardThread(clientConfiguration.ClipboardPolltime, this.Handle);
        this.InitSendDelay(eEventType.PROCESS, clientConfiguration.ProcessPolltime);
        this.ProcThread = new ProcessThread(clientConfiguration.ProcessPolltime);
        this.ProcThread.IgnoreList = ((IEnumerable<string>) clientConfiguration.ProcessIgnoreWindows).ToList<string>();
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Exception exception = ex;
        Module1.Log(Module1.LogType.ERROR, (object) MethodBase.GetCurrentMethod(), exception.ToString());
        ProjectData.ClearProjectError();
      }
    }

    private void StopThreads(FormMain.eThreadStopMode mode)
    {
      Module1.Log((object) MethodBase.GetCurrentMethod(), "StopThreads (Mode={0})", (object) mode);
      try
      {
        if (mode == FormMain.eThreadStopMode.STOP_THREADS | mode == FormMain.eThreadStopMode.STOP_ALL)
        {
          if (this.AdapThread != null)
            this.AdapThread.Started = false;
          if (this.ApplThread != null)
            this.ApplThread.Started = false;
          if (this.ProcThread != null)
            this.ProcThread.Started = false;
          if (this.ScrnThread != null)
            this.ScrnThread.Started = false;
          if (this.ConfThread != null)
            this.ConfThread.Started = false;
          if (this.ClipThread != null)
            this.ClipThread.Started = false;
        }
        if (!(mode == FormMain.eThreadStopMode.STOP_UPLOAD | mode == FormMain.eThreadStopMode.STOP_ALL) || this.UpldThread == null)
          return;
        this.UpldThread.Started = false;
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Exception exception = ex;
        Module1.Log(Module1.LogType.ERROR, (object) MethodBase.GetCurrentMethod(), exception.ToString());
        ProjectData.ClearProjectError();
      }
    }

    private void InitSendDelay(eEventType eventType, int polltime)
    {
      this.SendDelays.Add(eventType, checked (this._Random.Next(Module1.Config.ClientConfiguration.ThreadsDelayedMin * 1000, Module1.Config.ClientConfiguration.ThreadsDelayedMax * 1000) + polltime));
    }

    private void Login()
    {
      try
      {
        using (FormLogin2 formLogin2 = new FormLogin2())
        {
          switch (formLogin2.ShowDialog((IWin32Window) this))
          {
            case DialogResult.OK:
              this.Show();
              this.TopMost = true;
              Module1.USER_SIGN_IN_TOKEN = Module1.Config.Token;
              Module1.LOG_SESSION = Module1.Config.ClientConfiguration.IncludeLogfile;
              this.ClientClock = new ClientClock(Module1.Config.CurrentTime.AddSeconds(2.0));
              this.UpldThread = new UploadThread(Module1.Config.ClientConfiguration.HeartbeatPulseMin, Module1.Config.ClientConfiguration.HeartbeatPulseMax);
              this.ConfThread = new ConfigurationThread();
              this.UpldThread.Token = Module1.Config.Token;
              if (DateTime.Compare(Module1.Config.CurrentTime, Module1.Config.Exam.TimeBegin) < 0)
              {
                this.SetIconStatus((Image) ExamCookie.WinClient.My.Resources.Resources.ec_yellow);
                this.Notify("ExamCookie", new string[3]
                {
                  "Du er nu logget ind. Din eksamen er ikke",
                  "startet og programmet er ikke aktivt.",
                  string.Format("Eksamen begynder: {0}", (object) Strings.Format((object) Module1.Config.Exam.TimeBegin, "dd-MM-yyyy HH:mm"))
                });
              }
              this.SessionMode = FormMain.eSessionMode.SIGNED_IN;
              Module1.Log((object) MethodBase.GetCurrentMethod(), "SIGN_IN_ID={0}", (object) Module1.USER_SIGN_IN_TOKEN);
              break;
            case DialogResult.Retry:
              break;
            default:
              this.SessionMode = FormMain.eSessionMode.CLOSE;
              break;
          }
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Exception exception = ex;
        Module1.Log(Module1.LogType.ERROR, (object) MethodBase.GetCurrentMethod(), exception.ToString());
        ProjectData.ClearProjectError();
      }
    }

    private void SignOut()
    {
      try
      {
        if (this.UpldThread == null || !this.UpldThread.IsOnline || !(this.HasExamEnded() & !Module1.USER_SIGN_OUT_SUCCESS))
          return;
        using (ExamApiV3Client examApiV3Client = Module1.ExamClient())
        {
          ExamApiV3Client client = examApiV3Client;
          Module1.SetCredentials(ref client);
          eSignOutMethod integer = (eSignOutMethod) Conversions.ToInteger(Interaction.IIf(Module1.USER_SIGNED_OUT, (object) eSignOutMethod.USER_CHOICE, (object) eSignOutMethod.EXAM_ENDED));
          int num = examApiV3Client.SignOut(Module1.Config.Token, integer, Module1.GetClientErrorLog());
          Module1.USER_SIGN_OUT_SUCCESS = num >= 0;
          Module1.Log((object) MethodBase.GetCurrentMethod(), "SignOut: {0}. Result={1}", (object) integer.ToString(), (object) num);
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Exception exception = ex;
        Module1.Log(Module1.LogType.ERROR, (object) MethodBase.GetCurrentMethod(), exception.ToString());
        ProjectData.ClearProjectError();
      }
    }

    private bool HasExamEnded(bool forceEnd = false)
    {
      if (this.\u0024STATIC\u0024HasExamEnded\u002420122\u0024flag\u0024Init == null)
        Interlocked.CompareExchange<StaticLocalInitFlag>(ref this.\u0024STATIC\u0024HasExamEnded\u002420122\u0024flag\u0024Init, new StaticLocalInitFlag(), (StaticLocalInitFlag) null);
      bool lockTaken = false;
      try
      {
        System.Threading.Monitor.Enter((object) this.\u0024STATIC\u0024HasExamEnded\u002420122\u0024flag\u0024Init, ref lockTaken);
        if (this.\u0024STATIC\u0024HasExamEnded\u002420122\u0024flag\u0024Init.State == (short) 0)
        {
          this.\u0024STATIC\u0024HasExamEnded\u002420122\u0024flag\u0024Init.State = (short) 2;
          this.\u0024STATIC\u0024HasExamEnded\u002420122\u0024flag = false;
        }
        else if (this.\u0024STATIC\u0024HasExamEnded\u002420122\u0024flag\u0024Init.State == (short) 2)
          throw new IncompleteInitialization();
      }
      finally
      {
        this.\u0024STATIC\u0024HasExamEnded\u002420122\u0024flag\u0024Init.State = (short) 1;
        if (lockTaken)
          System.Threading.Monitor.Exit((object) this.\u0024STATIC\u0024HasExamEnded\u002420122\u0024flag\u0024Init);
      }
      bool flag;
      try
      {
        if (!this.\u0024STATIC\u0024HasExamEnded\u002420122\u0024flag)
        {
          if (forceEnd)
          {
            Module1.Log((object) MethodBase.GetCurrentMethod(), "forceEnd=True");
            this.\u0024STATIC\u0024HasExamEnded\u002420122\u0024flag = true;
          }
          else if (this.ClientClock == null)
          {
            flag = false;
            goto label_25;
          }
          else if (!this.\u0024STATIC\u0024HasExamEnded\u002420122\u0024flag & DateTime.Compare(this.ClientClock.CurrentTime, Module1.Config.Exam.TimeEnd.AddMinutes((double) checked (Module1.Config.Exam.TimeEndExt + Module1.Config.Exam.StudentTimeExt))) >= 0)
          {
            Module1.Log((object) MethodBase.GetCurrentMethod(), "CurrentTime: {0} > {1}", (object) this.ClientClock.CurrentTime.ToString(), (object) Module1.Config.Exam.TimeEnd.AddMinutes((double) checked (Module1.Config.Exam.TimeEndExt + Module1.Config.Exam.StudentTimeExt)).ToString());
            this.\u0024STATIC\u0024HasExamEnded\u002420122\u0024flag = true;
          }
          else if (Module1.USER_SIGNED_OUT)
          {
            Module1.Log((object) MethodBase.GetCurrentMethod(), "USER_SIGNED_OUT");
            this.\u0024STATIC\u0024HasExamEnded\u002420122\u0024flag = true;
          }
          else if (!this.\u0024STATIC\u0024HasExamEnded\u002420122\u0024flag & DateTime.Compare(this.ClientClock.CurrentTime.Date, Module1.Config.Exam.TimeEnd.Date) != 0)
          {
            Module1.Log((object) MethodBase.GetCurrentMethod(), "CurrentDate: {0} > {1}", (object) this.ClientClock.CurrentTime.Date.ToString(), (object) Module1.Config.Exam.TimeEnd.Date.ToString());
            this.\u0024STATIC\u0024HasExamEnded\u002420122\u0024flag = true;
          }
          else
          {
            flag = false;
            goto label_25;
          }
        }
        flag = this.\u0024STATIC\u0024HasExamEnded\u002420122\u0024flag;
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        flag = false;
        ProjectData.ClearProjectError();
      }
label_25:
      return flag;
    }

    private void Notify(string header, string[] message = null)
    {
      FormMain formMain = this;
      string header1 = header;
      string[] message1 = message;
      if (this.\u0024STATIC\u0024Notify\u00242021E1DE\u0024last\u0024Init == null)
        Interlocked.CompareExchange<StaticLocalInitFlag>(ref this.\u0024STATIC\u0024Notify\u00242021E1DE\u0024last\u0024Init, new StaticLocalInitFlag(), (StaticLocalInitFlag) null);
      bool lockTaken = false;
      try
      {
        System.Threading.Monitor.Enter((object) this.\u0024STATIC\u0024Notify\u00242021E1DE\u0024last\u0024Init, ref lockTaken);
        if (this.\u0024STATIC\u0024Notify\u00242021E1DE\u0024last\u0024Init.State == (short) 0)
        {
          this.\u0024STATIC\u0024Notify\u00242021E1DE\u0024last\u0024Init.State = (short) 2;
          this.\u0024STATIC\u0024Notify\u00242021E1DE\u0024last = (string[]) null;
        }
        else if (this.\u0024STATIC\u0024Notify\u00242021E1DE\u0024last\u0024Init.State == (short) 2)
          throw new IncompleteInitialization();
      }
      finally
      {
        this.\u0024STATIC\u0024Notify\u00242021E1DE\u0024last\u0024Init.State = (short) 1;
        if (lockTaken)
          System.Threading.Monitor.Exit((object) this.\u0024STATIC\u0024Notify\u00242021E1DE\u0024last\u0024Init);
      }
      if (message1 == null)
      {
        if (this.\u0024STATIC\u0024Notify\u00242021E1DE\u0024last != null)
          message1 = this.\u0024STATIC\u0024Notify\u00242021E1DE\u0024last;
      }
      else
        this.\u0024STATIC\u0024Notify\u00242021E1DE\u0024last = message1;
      if (message1 == null)
        return;
      new Thread((ThreadStart) ([SpecialName] () => formMain.ShowNotify(header1, message1))).Start();
      if (this.ScrnThread != null)
        this.ScrnThread.TakeScreenshot(1, 1000);
    }

    private void ShowNotify(string header, string[] message)
    {
      Module1.Log((object) MethodBase.GetCurrentMethod(), Strings.Join(message, " | "));
      using (FormNotify formNotify = new FormNotify())
      {
        int timeout = checked (Module1.Config.ClientConfiguration.NotifyBoxDisplayTime * 1000);
        formNotify.Notify(header, message, timeout);
        int num = (int) formNotify.ShowDialog((IWin32Window) this);
      }
    }

    private void UploadSessionLog()
    {
      try
      {
        using (MemoryStream memoryStream = new MemoryStream())
        {
          using (StreamWriter streamWriter = new StreamWriter((Stream) memoryStream, Encoding.UTF8))
          {
            try
            {
              foreach (string str in Module1.SessionLog)
                streamWriter.WriteLine(str);
            }
            finally
            {
              List<string>.Enumerator enumerator;
              enumerator.Dispose();
            }
          }
          Module1.Log((object) MethodBase.GetCurrentMethod(), "Upload session log filen til storage");
          using (ExamApiV3Client examApiV3Client = Module1.ExamClient())
          {
            ExamApiV3Client client = examApiV3Client;
            Module1.SetCredentials(ref client);
            examApiV3Client.SaveSessionLog(Module1.Config.Token, memoryStream.ToArray());
          }
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        ProjectData.ClearProjectError();
      }
    }

    private void Uninstall(FormMain.eSessionMode mode)
    {
      try
      {
        if (mode == FormMain.eSessionMode.CLOSE_AND_DELETE)
        {
          string path1 = string.Format("{0}\\{1}", (object) Module1.APP_DATA_PATH, (object) Module1.OFFLINE_PACKAGE_FOLDER);
          if (Directory.Exists(path1))
          {
            string[] files = Directory.GetFiles(path1);
            int index = 0;
            while (index < files.Length)
            {
              string path2 = files[index];
              try
              {
                File.Delete(path2);
              }
              catch (Exception ex)
              {
                ProjectData.SetProjectError(ex);
                ProjectData.ClearProjectError();
              }
              checked { ++index; }
            }
            try
            {
              Directory.Delete(path1);
            }
            catch (Exception ex)
            {
              ProjectData.SetProjectError(ex);
              ProjectData.ClearProjectError();
            }
          }
        }
        if (!(mode == FormMain.eSessionMode.CLOSE_AND_PRESERVE | mode == FormMain.eSessionMode.CLOSE_AND_DELETE))
          return;
        using (System.Diagnostics.Process process = new System.Diagnostics.Process())
        {
          process.StartInfo = new ProcessStartInfo()
          {
            Arguments = string.Format(" /K timeout 3 & del \"{0}\\ExamCookie*.exe\"", (object) Module1.APP_CURRENT_DIR),
            FileName = "cmd.exe",
            CreateNoWindow = true,
            UseShellExecute = false
          };
          process.Start();
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        ProjectData.ClearProjectError();
      }
    }

    private void OnPowerChange(int mode)
    {
      if (this.\u0024STATIC\u0024OnPowerChange\u002420118\u0024ThisTime\u0024Init == null)
        Interlocked.CompareExchange<StaticLocalInitFlag>(ref this.\u0024STATIC\u0024OnPowerChange\u002420118\u0024ThisTime\u0024Init, new StaticLocalInitFlag(), (StaticLocalInitFlag) null);
      bool lockTaken = false;
      try
      {
        System.Threading.Monitor.Enter((object) this.\u0024STATIC\u0024OnPowerChange\u002420118\u0024ThisTime\u0024Init, ref lockTaken);
        if (this.\u0024STATIC\u0024OnPowerChange\u002420118\u0024ThisTime\u0024Init.State == (short) 0)
        {
          this.\u0024STATIC\u0024OnPowerChange\u002420118\u0024ThisTime\u0024Init.State = (short) 2;
          this.\u0024STATIC\u0024OnPowerChange\u002420118\u0024ThisTime = DateAndTime.Now;
        }
        else if (this.\u0024STATIC\u0024OnPowerChange\u002420118\u0024ThisTime\u0024Init.State == (short) 2)
          throw new IncompleteInitialization();
      }
      finally
      {
        this.\u0024STATIC\u0024OnPowerChange\u002420118\u0024ThisTime\u0024Init.State = (short) 1;
        if (lockTaken)
          System.Threading.Monitor.Exit((object) this.\u0024STATIC\u0024OnPowerChange\u002420118\u0024ThisTime\u0024Init);
      }
      try
      {
        if (mode == 4)
        {
          Module1.Log((object) MethodBase.GetCurrentMethod(), "PowerModes.Suspend: {0}", (object) DateAndTime.Now);
          this.\u0024STATIC\u0024OnPowerChange\u002420118\u0024ThisTime = DateAndTime.Now;
        }
        if (this.ClientClock == null || this.UpldThread == null)
          return;
        switch (mode)
        {
          case 4:
            this.UpldThread.IsOnline = false;
            break;
          case 7:
          case 18:
            Module1.Log((object) MethodBase.GetCurrentMethod(), "PowerModes.Resume: {0}", (object) DateAndTime.Now);
            this.TmrTick.Stop();
            this.TmrTick.Start();
            if (this.KillSwitch.IsRunning)
              this.KillSwitch.Restart();
            if (this.ClientClock != null)
            {
              long num = DateAndTime.DateDiff(DateInterval.Second, this.\u0024STATIC\u0024OnPowerChange\u002420118\u0024ThisTime, DateAndTime.Now);
              this.ClientClock.CurrentTime.AddSeconds((double) num);
              Module1.Log((object) MethodBase.GetCurrentMethod(), "ClientClock.CurrentTime adjusted by {0} seconds to {1}. ThisTime={2}, Now={3}", (object) num, (object) this.ClientClock.CurrentTime, (object) this.\u0024STATIC\u0024OnPowerChange\u002420118\u0024ThisTime, (object) DateAndTime.Now);
              this.\u0024STATIC\u0024OnPowerChange\u002420118\u0024ThisTime = DateAndTime.Now;
              break;
            }
            break;
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Exception exception = ex;
        Module1.Log(Module1.LogType.ERROR, (object) MethodBase.GetCurrentMethod(), exception.ToString());
        ProjectData.ClearProjectError();
      }
    }

    private void OnAdapterChanged(AdapterThread.AdapterChanged sender)
    {
      try
      {
        if (this.HasExamEnded())
          return;
        Module1.Log((object) MethodBase.GetCurrentMethod(), "");
        sender.Token = Module1.Config.Token;
        sender.TimeStamp = this.ClientClock.CurrentTime;
        sender.CanSend = Module1.Config.Exam.TimeBegin.AddMilliseconds((double) this.SendDelays[eEventType.ADAPTER]);
        this.UpldThread.AddDataPackage((object) sender);
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Exception exception = ex;
        Module1.Log(Module1.LogType.ERROR, (object) MethodBase.GetCurrentMethod(), exception.ToString());
        ProjectData.ClearProjectError();
      }
    }

    private void OnApplicationChanged(ApplicationThread.ApplicationChanged sender)
    {
      try
      {
        if (this.HasExamEnded())
          return;
        if (sender.Type == eApplicationType.APPLICATION)
          Module1.Log((object) MethodBase.GetCurrentMethod(), "{0}='{1}', DOC='{2}'", (object) sender.Type.ToString(), (object) sender.Name, (object) sender.Document);
        else
          Module1.Log((object) MethodBase.GetCurrentMethod(), "{0}='{1}', URL='{2}'", (object) sender.Type.ToString(), (object) sender.Name, (object) sender.Document);
        sender.Token = Module1.Config.Token;
        sender.TimeStamp = this.ClientClock.CurrentTime;
        sender.CanSend = Module1.Config.Exam.TimeBegin.AddMilliseconds((double) this.SendDelays[eEventType.FRONT_APP]);
        this.UpldThread.AddDataPackage((object) sender);
        this.ScrnThread.TakeScreenshot(sender.Rectangle);
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Exception exception = ex;
        Module1.Log(Module1.LogType.ERROR, (object) MethodBase.GetCurrentMethod(), exception.ToString());
        ProjectData.ClearProjectError();
      }
    }

    private void OnClipboardChanged(ClipboardThread.ClipboardChanged sender)
    {
      try
      {
        if (this.HasExamEnded())
          return;
        Module1.Log((object) MethodBase.GetCurrentMethod(), sender.Format.ToString());
        if (sender.Format != 0 && sender.Data != null)
        {
          sender.Token = Module1.Config.Token;
          sender.TimeStamp = this.ClientClock.CurrentTime;
          sender.CanSend = Module1.Config.Exam.TimeBegin.AddMilliseconds((double) this.SendDelays[eEventType.CLIPBOARD]);
          this.UpldThread.AddDataPackage((object) sender);
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Exception exception = ex;
        Module1.Log(Module1.LogType.ERROR, (object) MethodBase.GetCurrentMethod(), exception.ToString());
        ProjectData.ClearProjectError();
      }
    }

    private void OnProcessChanged(ProcessThread.ProcessChanged sender)
    {
      try
      {
        if (this.HasExamEnded())
          return;
        Module1.Log((object) MethodBase.GetCurrentMethod(), "");
        sender.Token = Module1.Config.Token;
        sender.TimeStamp = this.ClientClock.CurrentTime;
        sender.CanSend = Module1.Config.Exam.TimeBegin.AddMilliseconds((double) this.SendDelays[eEventType.PROCESS]);
        this.UpldThread.AddDataPackage((object) sender);
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Exception exception = ex;
        Module1.Log(Module1.LogType.ERROR, (object) MethodBase.GetCurrentMethod(), exception.ToString());
        ProjectData.ClearProjectError();
      }
    }

    private void OnScreenChanged(ScreenThread.ScreenChanged sender)
    {
      try
      {
        if (this.HasExamEnded())
          return;
        Module1.Log((object) MethodBase.GetCurrentMethod(), "Screen {0}: Bounds={1}, Filesize: {2:##,#} KB", (object) sender.ScreenNumber, (object) sender.Bounds.ToString(), (object) ((double) sender.Data.Length / 1000.0));
        if (sender.Data.Length > 0)
        {
          sender.Token = Module1.Config.Token;
          sender.TimeStamp = this.ClientClock.CurrentTime;
          sender.CanSend = Module1.Config.Exam.TimeBegin.AddMilliseconds((double) this.SendDelays[eEventType.SCREENSHOT]);
          this.UpldThread.AddDataPackage((object) sender);
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Exception exception = ex;
        Module1.Log(Module1.LogType.ERROR, (object) MethodBase.GetCurrentMethod(), exception.ToString());
        ProjectData.ClearProjectError();
      }
    }

    private void OnOnlineChanged(bool online)
    {
      try
      {
        Module1.Log((object) MethodBase.GetCurrentMethod(), "Online={0}", (object) online);
        if (online)
        {
          if (DateTime.Compare(this.ClientClock.CurrentTime, Module1.Config.Exam.TimeEnd.AddMinutes((double) checked (Module1.Config.Exam.TimeEndExt + Module1.Config.Exam.StudentTimeExt))) >= 0)
            this.SetIconStatus((Image) null);
          else if (DateTime.Compare(this.ClientClock.CurrentTime, Module1.Config.Exam.TimeBegin) >= 0)
            this.SetIconStatus((Image) ExamCookie.WinClient.My.Resources.Resources.ec_green);
          else
            this.SetIconStatus((Image) ExamCookie.WinClient.My.Resources.Resources.ec_yellow);
        }
        else
          this.SetIconStatus((Image) ExamCookie.WinClient.My.Resources.Resources.ec_red);
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Exception exception = ex;
        Module1.Log(Module1.LogType.ERROR, (object) MethodBase.GetCurrentMethod(), exception.ToString());
        ProjectData.ClearProjectError();
      }
    }

    private void OnHeartbeat(DateTime currentTime, int result)
    {
      try
      {
        Module1.Log((object) MethodBase.GetCurrentMethod(), "Servertime: {0}, ClientClock: {1}, PC time: {2}", (object) currentTime, (object) this.ClientClock.CurrentTime, (object) DateAndTime.Now);
        if (Math.Abs(DateAndTime.DateDiff(DateInterval.Second, this.ClientClock.CurrentTime, currentTime)) > 5L)
          this.ClientClock.CurrentTime = currentTime;
        if (!(this.SessionMode == FormMain.eSessionMode.EXAM_STARTED & result == 5))
          return;
        this.SessionMode = FormMain.eSessionMode.EXAM_ENDED;
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Exception exception = ex;
        Module1.Log(Module1.LogType.ERROR, (object) MethodBase.GetCurrentMethod(), exception.ToString());
        ProjectData.ClearProjectError();
      }
    }

    private void OnConfigurationChanged(string[] message) => this.Notify("ExamCookie", message);

    private void OnThreadDebug(string message)
    {
      Module1.Log((object) MethodBase.GetCurrentMethod(), message);
    }

    private void OnThreadException(Exception ex)
    {
      Module1.Log(Module1.LogType.ERROR, (object) MethodBase.GetCurrentMethod(), ex.ToString());
    }

    private void OnTimerTick(object sender, EventArgs e)
    {
      if (this.\u0024STATIC\u0024OnTimerTick\u002420211C1280A5\u0024ticks\u0024Init == null)
        Interlocked.CompareExchange<StaticLocalInitFlag>(ref this.\u0024STATIC\u0024OnTimerTick\u002420211C1280A5\u0024ticks\u0024Init, new StaticLocalInitFlag(), (StaticLocalInitFlag) null);
      bool lockTaken = false;
      try
      {
        System.Threading.Monitor.Enter((object) this.\u0024STATIC\u0024OnTimerTick\u002420211C1280A5\u0024ticks\u0024Init, ref lockTaken);
        if (this.\u0024STATIC\u0024OnTimerTick\u002420211C1280A5\u0024ticks\u0024Init.State == (short) 0)
        {
          this.\u0024STATIC\u0024OnTimerTick\u002420211C1280A5\u0024ticks\u0024Init.State = (short) 2;
          this.\u0024STATIC\u0024OnTimerTick\u002420211C1280A5\u0024ticks = 0;
        }
        else if (this.\u0024STATIC\u0024OnTimerTick\u002420211C1280A5\u0024ticks\u0024Init.State == (short) 2)
          throw new IncompleteInitialization();
      }
      finally
      {
        this.\u0024STATIC\u0024OnTimerTick\u002420211C1280A5\u0024ticks\u0024Init.State = (short) 1;
        if (lockTaken)
          System.Threading.Monitor.Exit((object) this.\u0024STATIC\u0024OnTimerTick\u002420211C1280A5\u0024ticks\u0024Init);
      }
      try
      {
        this.TmrTick.Stop();
        checked { ++this.\u0024STATIC\u0024OnTimerTick\u002420211C1280A5\u0024ticks; }
        switch (this.SessionMode)
        {
          case FormMain.eSessionMode.BEGIN_SIGN_IN:
            this.SessionMode = FormMain.eSessionMode.AWAIT_SIGN_IN;
            this.Login();
            goto case FormMain.eSessionMode.AWAIT_SIGN_IN;
          case FormMain.eSessionMode.AWAIT_SIGN_IN:
            if (this.UpldThread != null)
            {
              this.UpldThread.CurrentTime = this.ClientClock.CurrentTime;
              this.SignOut();
            }
            if (this.\u0024STATIC\u0024OnTimerTick\u002420211C1280A5\u0024ticks <= 60)
              break;
            this.\u0024STATIC\u0024OnTimerTick\u002420211C1280A5\u0024ticks = 0;
            Module1.OptimizeMemoryConsumption();
            DateTime minValue = DateTime.MinValue;
            if (Module1.GetNetworkTime(ref minValue) == 0 && Math.Abs(DateAndTime.DateDiff(DateInterval.Minute, minValue.ToLocalTime(), DateAndTime.Now)) > 3L)
              Module1.SetComputerClock();
            if (this.UpldThread != null && !this.UpldThread.IsOnline)
              this.SetIconStatus((Image) ExamCookie.WinClient.My.Resources.Resources.ec_red);
            break;
          case FormMain.eSessionMode.SIGNED_IN:
            if (DateTime.Compare(this.ClientClock.CurrentTime, Module1.Config.Exam.TimeBegin) >= 0)
            {
              this.SessionMode = FormMain.eSessionMode.EXAM_STARTED;
              this.Notify("ExamCookie", new string[2]
              {
                "Eksamen er nu begyndt",
                "og programmet er aktivt."
              });
              this.SetIconStatus((Image) ExamCookie.WinClient.My.Resources.Resources.ec_green);
              this.StartThreads();
              goto case FormMain.eSessionMode.AWAIT_SIGN_IN;
            }
            else
              goto case FormMain.eSessionMode.AWAIT_SIGN_IN;
          case FormMain.eSessionMode.EXAM_STARTED:
            if (DateTime.Compare(this.ClientClock.CurrentTime, Module1.Config.Exam.TimeEnd.AddMinutes((double) checked (Module1.Config.Exam.TimeEndExt + Module1.Config.Exam.StudentTimeExt))) >= 0)
            {
              this.SessionMode = FormMain.eSessionMode.EXAM_ENDED;
              this.Notify("ExamCookie", new string[2]
              {
                "Eksamen er slut",
                "og programmet lukker om et øjeblik."
              });
              goto case FormMain.eSessionMode.AWAIT_SIGN_IN;
            }
            else
              goto case FormMain.eSessionMode.AWAIT_SIGN_IN;
          case FormMain.eSessionMode.EXAM_ENDED:
            this.SessionMode = FormMain.eSessionMode.CLOSE_DELAY;
            this.KillSwitch.Start();
            this.SetIconStatus((Image) null);
            this.StopThreads(FormMain.eThreadStopMode.STOP_THREADS);
            Module1.Log((object) MethodBase.GetCurrentMethod(), "Offline files count = {0}", (object) this.UpldThread.DataPackageOfflineCount);
            goto case FormMain.eSessionMode.AWAIT_SIGN_IN;
          case FormMain.eSessionMode.CLOSE:
          case FormMain.eSessionMode.CLOSE_AND_PRESERVE:
          case FormMain.eSessionMode.CLOSE_AND_DELETE:
            this.TmrTick.Stop();
            this.OverlayForm.Close();
            goto case FormMain.eSessionMode.AWAIT_SIGN_IN;
          case FormMain.eSessionMode.CLOSE_DELAY:
            if (!this.UpldThread.UploadDataPackagesComplete)
            {
              if (this.KillSwitch.ElapsedMilliseconds > (long) checked (Module1.FORCE_CLOSE_DELAY * 60000))
              {
                this.SessionMode = FormMain.eSessionMode.CLOSE_AND_PRESERVE;
                goto case FormMain.eSessionMode.AWAIT_SIGN_IN;
              }
              else
                goto case FormMain.eSessionMode.AWAIT_SIGN_IN;
            }
            else if (!this.UpldThread.IsOnline)
            {
              if (this.KillSwitch.ElapsedMilliseconds > 12000L)
              {
                this.SessionMode = FormMain.eSessionMode.CLOSE_AND_PRESERVE;
                goto case FormMain.eSessionMode.AWAIT_SIGN_IN;
              }
              else
                goto case FormMain.eSessionMode.AWAIT_SIGN_IN;
            }
            else if (this.KillSwitch.ElapsedMilliseconds > 12000L)
            {
              this.SessionMode = FormMain.eSessionMode.CLOSE_AND_DELETE;
              goto case FormMain.eSessionMode.AWAIT_SIGN_IN;
            }
            else
              goto case FormMain.eSessionMode.AWAIT_SIGN_IN;
          default:
            Module1.Log((object) MethodBase.GetCurrentMethod(), this.SessionMode.ToString());
            goto case FormMain.eSessionMode.AWAIT_SIGN_IN;
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Exception exception = ex;
        Module1.Log(Module1.LogType.ERROR, (object) MethodBase.GetCurrentMethod(), exception.ToString());
        ProjectData.ClearProjectError();
      }
      finally
      {
        this.TmrTick.Start();
      }
    }

    public enum eSessionMode
    {
      INIT = 0,
      BEGIN_SIGN_IN = 1,
      AWAIT_SIGN_IN = 2,
      SIGNED_IN = 3,
      SIGN_IN_FAILED = 4,
      EXAM_STARTED = 5,
      EXAM_ENDED = 6,
      CLOSE = 10, // 0x0000000A
      CLOSE_DELAY = 11, // 0x0000000B
      CLOSE_AND_PRESERVE = 12, // 0x0000000C
      CLOSE_AND_DELETE = 13, // 0x0000000D
    }

    private enum eThreadStopMode
    {
      STOP_THREADS = 1,
      STOP_UPLOAD = 2,
      STOP_ALL = 3,
    }
  }
}
