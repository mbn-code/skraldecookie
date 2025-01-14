// Decompiled with JetBrains decompiler
// Type: ExamCookie.WinClient.FormLogin
// Assembly: ExamCookie.WinClient, Version=1.4.1.4, Culture=neutral, PublicKeyToken=null
// MVID: E12BE1F8-B6E0-4BF5-B308-166F0E938C4B
// Assembly location: C:\Users\oskar\Downloads\ExamCookie1414.WinClient.exe

using ExamCookie.Library;
using ExamCookie.WinClient.ExamApiV3Service;
using ExamCookie.WinClient.My;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.WinForms;
using Microsoft.Win32;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Web.Script.Serialization;
using System.Windows.Forms;

#nullable disable
namespace ExamCookie.WinClient
{
  [DesignerGenerated]
  public class FormLogin : Form
  {
    private IContainer components;

    public FormLogin()
    {
      this.Load += new EventHandler(this.FormLogin_Load);
      this.FormClosing += new FormClosingEventHandler(this.FormLogin_FormClosing);
      this.Resize += new EventHandler(this.FormLogin_Resize);
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
      this.PanelHeader = new Panel();
      this.PanelExamCookie = new Panel();
      this.PanelWebView = new Panel();
      this.WebView1 = new Microsoft.Web.WebView2.WinForms.WebView2();
      this.TmrAction = new System.Windows.Forms.Timer(this.components);
      this.PanelTabButton = new Panel();
      this.TabTest = new RadioButton();
      this.TabManuelLogin = new RadioButton();
      this.TabUniLogin = new RadioButton();
      this.BtnTerms = new LinkLabel();
      this.PanelHeader.SuspendLayout();
      this.PanelWebView.SuspendLayout();
      ((ISupportInitialize) this.WebView1).BeginInit();
      this.PanelTabButton.SuspendLayout();
      this.SuspendLayout();
      this.PanelHeader.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.PanelHeader.BackColor = SystemColors.ControlLight;
      this.PanelHeader.Controls.Add((Control) this.PanelExamCookie);
      this.PanelHeader.Location = new Point(0, 0);
      this.PanelHeader.Margin = new Padding(3, 4, 3, 4);
      this.PanelHeader.Name = "PanelHeader";
      this.PanelHeader.Size = new Size(615, 109);
      this.PanelHeader.TabIndex = 1;
      this.PanelExamCookie.BackgroundImage = (Image) ExamCookie.WinClient.My.Resources.Resources.ec_logo;
      this.PanelExamCookie.BackgroundImageLayout = ImageLayout.Zoom;
      this.PanelExamCookie.Location = new Point(129, 16);
      this.PanelExamCookie.Margin = new Padding(3, 4, 3, 4);
      this.PanelExamCookie.Name = "PanelExamCookie";
      this.PanelExamCookie.Size = new Size(356, 74);
      this.PanelExamCookie.TabIndex = 20;
      this.PanelWebView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.PanelWebView.BorderStyle = BorderStyle.FixedSingle;
      this.PanelWebView.Controls.Add((Control) this.WebView1);
      this.PanelWebView.Location = new Point(14, 182);
      this.PanelWebView.Margin = new Padding(3, 4, 3, 4);
      this.PanelWebView.Name = "PanelWebView";
      this.PanelWebView.Size = new Size(566, 559);
      this.PanelWebView.TabIndex = 17;
      this.WebView1.AllowExternalDrop = true;
      this.WebView1.CreationProperties = (CoreWebView2CreationProperties) null;
      this.WebView1.DefaultBackgroundColor = System.Drawing.Color.White;
      this.WebView1.Dock = DockStyle.Fill;
      this.WebView1.Location = new Point(0, 0);
      this.WebView1.Name = "WebView1";
      this.WebView1.Size = new Size(564, 557);
      this.WebView1.TabIndex = 7;
      this.WebView1.ZoomFactor = 1.0;
      this.TmrAction.Interval = 500;
      this.PanelTabButton.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.PanelTabButton.Controls.Add((Control) this.TabTest);
      this.PanelTabButton.Controls.Add((Control) this.TabManuelLogin);
      this.PanelTabButton.Controls.Add((Control) this.TabUniLogin);
      this.PanelTabButton.Location = new Point(0, 101);
      this.PanelTabButton.Margin = new Padding(3, 4, 3, 4);
      this.PanelTabButton.Name = "PanelTabButton";
      this.PanelTabButton.Size = new Size(615, 74);
      this.PanelTabButton.TabIndex = 12;
      this.TabTest.Appearance = Appearance.Button;
      this.TabTest.Font = new Font("Corbel", 10f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.TabTest.Location = new Point(389, 19);
      this.TabTest.Margin = new Padding(3, 4, 3, 4);
      this.TabTest.Name = "TabTest";
      this.TabTest.Size = new Size(172, 42);
      this.TabTest.TabIndex = 18;
      this.TabTest.Text = "Test";
      this.TabTest.TextAlign = ContentAlignment.MiddleCenter;
      this.TabTest.UseVisualStyleBackColor = true;
      this.TabManuelLogin.Appearance = Appearance.Button;
      this.TabManuelLogin.Font = new Font("Corbel", 10f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.TabManuelLogin.Location = new Point(213, 19);
      this.TabManuelLogin.Margin = new Padding(3, 4, 3, 4);
      this.TabManuelLogin.Name = "TabManuelLogin";
      this.TabManuelLogin.Size = new Size(172, 42);
      this.TabManuelLogin.TabIndex = 17;
      this.TabManuelLogin.Text = "Manuel-Login";
      this.TabManuelLogin.TextAlign = ContentAlignment.MiddleCenter;
      this.TabManuelLogin.UseVisualStyleBackColor = true;
      this.TabUniLogin.Appearance = Appearance.Button;
      this.TabUniLogin.Font = new Font("Corbel", 10f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.TabUniLogin.Location = new Point(38, 19);
      this.TabUniLogin.Margin = new Padding(3, 4, 3, 4);
      this.TabUniLogin.Name = "TabUniLogin";
      this.TabUniLogin.Size = new Size(172, 42);
      this.TabUniLogin.TabIndex = 16;
      this.TabUniLogin.Text = "UNI-Login";
      this.TabUniLogin.TextAlign = ContentAlignment.MiddleCenter;
      this.TabUniLogin.UseVisualStyleBackColor = true;
      this.BtnTerms.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.BtnTerms.AutoSize = true;
      this.BtnTerms.Font = new Font("Corbel", 10f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.BtnTerms.LinkBehavior = LinkBehavior.HoverUnderline;
      this.BtnTerms.Location = new Point(392, 745);
      this.BtnTerms.Name = "BtnTerms";
      this.BtnTerms.Size = new Size(184, 24);
      this.BtnTerms.TabIndex = 18;
      this.BtnTerms.TabStop = true;
      this.BtnTerms.Text = "Vilkår og betingelser";
      this.AutoScaleDimensions = new SizeF(9f, 20f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = SystemColors.Control;
      this.ClientSize = new Size(615, 794);
      this.Controls.Add((Control) this.BtnTerms);
      this.Controls.Add((Control) this.PanelTabButton);
      this.Controls.Add((Control) this.PanelWebView);
      this.Controls.Add((Control) this.PanelHeader);
      this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
      this.Margin = new Padding(3, 4, 3, 4);
      this.Name = nameof (FormLogin);
      this.ShowInTaskbar = false;
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = "ExamCookie Login";
      this.PanelHeader.ResumeLayout(false);
      this.PanelWebView.ResumeLayout(false);
      ((ISupportInitialize) this.WebView1).EndInit();
      this.PanelTabButton.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    [field: AccessedThroughProperty("PanelHeader")]
    internal virtual Panel PanelHeader { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [field: AccessedThroughProperty("PanelExamCookie")]
    internal virtual Panel PanelExamCookie { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [field: AccessedThroughProperty("PanelWebView")]
    internal virtual Panel PanelWebView { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual System.Windows.Forms.Timer TmrAction
    {
      get => this._TmrAction;
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.OnTmrAction);
        System.Windows.Forms.Timer tmrAction1 = this._TmrAction;
        if (tmrAction1 != null)
          tmrAction1.Tick -= eventHandler;
        this._TmrAction = value;
        System.Windows.Forms.Timer tmrAction2 = this._TmrAction;
        if (tmrAction2 == null)
          return;
        tmrAction2.Tick += eventHandler;
      }
    }

    [field: AccessedThroughProperty("PanelTabButton")]
    internal virtual Panel PanelTabButton { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual RadioButton TabTest
    {
      get => this._TabTest;
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.TabChanged);
        RadioButton tabTest1 = this._TabTest;
        if (tabTest1 != null)
          tabTest1.CheckedChanged -= eventHandler;
        this._TabTest = value;
        RadioButton tabTest2 = this._TabTest;
        if (tabTest2 == null)
          return;
        tabTest2.CheckedChanged += eventHandler;
      }
    }

    internal virtual RadioButton TabManuelLogin
    {
      get => this._TabManuelLogin;
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.TabChanged);
        RadioButton tabManuelLogin1 = this._TabManuelLogin;
        if (tabManuelLogin1 != null)
          tabManuelLogin1.CheckedChanged -= eventHandler;
        this._TabManuelLogin = value;
        RadioButton tabManuelLogin2 = this._TabManuelLogin;
        if (tabManuelLogin2 == null)
          return;
        tabManuelLogin2.CheckedChanged += eventHandler;
      }
    }

    internal virtual RadioButton TabUniLogin
    {
      get => this._TabUniLogin;
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.TabChanged);
        RadioButton tabUniLogin1 = this._TabUniLogin;
        if (tabUniLogin1 != null)
          tabUniLogin1.CheckedChanged -= eventHandler;
        this._TabUniLogin = value;
        RadioButton tabUniLogin2 = this._TabUniLogin;
        if (tabUniLogin2 == null)
          return;
        tabUniLogin2.CheckedChanged += eventHandler;
      }
    }

    internal virtual Microsoft.Web.WebView2.WinForms.WebView2 WebView1
    {
      get => this._WebView1;
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler<CoreWebView2NavigationCompletedEventArgs> eventHandler1 = new EventHandler<CoreWebView2NavigationCompletedEventArgs>(this.WebView1_NavigationCompleted);
        EventHandler<CoreWebView2InitializationCompletedEventArgs> eventHandler2 = new EventHandler<CoreWebView2InitializationCompletedEventArgs>(this.WebView1_CoreWebView2InitializationCompleted);
        Microsoft.Web.WebView2.WinForms.WebView2 webView1_1 = this._WebView1;
        if (webView1_1 != null)
        {
          webView1_1.NavigationCompleted -= eventHandler1;
          webView1_1.CoreWebView2InitializationCompleted -= eventHandler2;
        }
        this._WebView1 = value;
        Microsoft.Web.WebView2.WinForms.WebView2 webView1_2 = this._WebView1;
        if (webView1_2 == null)
          return;
        webView1_2.NavigationCompleted += eventHandler1;
        webView1_2.CoreWebView2InitializationCompleted += eventHandler2;
      }
    }

    internal virtual LinkLabel BtnTerms
    {
      get => this._BtnTerms;
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        LinkLabelLinkClickedEventHandler clickedEventHandler = new LinkLabelLinkClickedEventHandler(this.BtnTerms_LinkClicked);
        LinkLabel btnTerms1 = this._BtnTerms;
        if (btnTerms1 != null)
          btnTerms1.LinkClicked -= clickedEventHandler;
        this._BtnTerms = value;
        LinkLabel btnTerms2 = this._BtnTerms;
        if (btnTerms2 == null)
          return;
        btnTerms2.LinkClicked += clickedEventHandler;
      }
    }

    private FormLogin.eAction TimerAction
    {
      get => (FormLogin.eAction) Conversions.ToInteger(this.TmrAction.Tag);
      set => this.TmrAction.Tag = (object) value;
    }

    private void FormLogin_Load(object sender, EventArgs e)
    {
      Control.CheckForIllegalCrossThreadCalls = false;
      this.TopMost = true;
      this.Text = string.Format("ExamCookie Login v{0}", (object) Module1.GetFileversion());
      this.SetTimerAction(FormLogin.eAction.INIT, 0);
      this.CheckWebView2RuntimeInstalled();
      this.SetWebViewLoaderPath(Module1.APP_DATA_PATH);
      Environment.SetEnvironmentVariable("WEBVIEW2_USER_DATA_FOLDER", Module1.APP_DATA_PATH);
      this.WebView1.Visible = false;
      this.WebView1.Source = new Uri(this.GetClientUIPage("message") + "?icon=" + (object) 2 + "&text=" + "Vent venligst...");
      this.ShowTabs(false, false, false);
    }

    private void FormLogin_FormClosing(object sender, FormClosingEventArgs e)
    {
      if (!Operators.ConditionalCompareObjectEqual(NewLateBinding.LateGet(sender, (Type) null, "DialogResult", new object[0], (string[]) null, (Type[]) null, (bool[]) null), (object) DialogResult.Retry, false))
        return;
      e.Cancel = true;
    }

    private void FormLogin_Resize(object sender, EventArgs e)
    {
      this.Height = checked (this.PanelHeader.Height + this.PanelTabButton.Height + this.PanelWebView.Height + 60);
      this.Width = this.PanelHeader.Width;
    }

    private void CheckWebView2RuntimeInstalled()
    {
      try
      {
        string[] strArray = new string[2]
        {
          "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Uninstall",
          "SOFTWARE\\Wow6432Node\\Microsoft\\Windows\\CurrentVersion\\Uninstall"
        };
        int index1 = 0;
        while (index1 < strArray.Length)
        {
          string name1 = strArray[index1];
          using (RegistryKey registryKey1 = Registry.LocalMachine.OpenSubKey(name1))
          {
            if (registryKey1 != null)
            {
              string[] subKeyNames = registryKey1.GetSubKeyNames();
              int index2 = 0;
              while (index2 < subKeyNames.Length)
              {
                string name2 = subKeyNames[index2];
                using (RegistryKey registryKey2 = registryKey1.OpenSubKey(name2))
                {
                  if (registryKey2.GetValue("DisplayName") is string str)
                  {
                    if (str.Contains("Microsoft Edge WebView2 Runtime"))
                      return;
                  }
                }
                checked { ++index2; }
              }
            }
          }
          checked { ++index1; }
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Exception exception = ex;
        Module1.DebugPrint(exception.ToString());
        int num = (int) Interaction.MsgBox((object) exception.ToString());
        ProjectData.ClearProjectError();
      }
      try
      {
        string path = Module1.APP_CURRENT_DIR + "\\MicrosoftEdgeWebview2Setup.exe";
        if (!File.Exists(path))
          File.WriteAllBytes(path, ExamCookie.WinClient.My.Resources.Resources.MicrosoftEdgeWebview2Setup);
        using (System.Diagnostics.Process process = new System.Diagnostics.Process())
        {
          process.StartInfo.FileName = path;
          process.Start();
          process.WaitForExit();
        }
        File.Delete(path);
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Exception exception = ex;
        Module1.DebugPrint(exception.ToString());
        int num = (int) Interaction.MsgBox((object) exception.ToString());
        ProjectData.ClearProjectError();
      }
    }

    private void SetWebViewLoaderPath(string appdata)
    {
      string[] strArray = new string[3]
      {
        "\\runtimes\\win-x86\\native\\WebView2Loader.dll",
        "\\runtimes\\win-x64\\native\\WebView2Loader.dll",
        "\\runtimes\\win-arm64\\native\\WebView2Loader.dll"
      };
      byte[][] numArray = new byte[3][]
      {
        ExamCookie.WinClient.My.Resources.Resources.x86_WebView2Loader,
        ExamCookie.WinClient.My.Resources.Resources.x64_WebView2Loader,
        ExamCookie.WinClient.My.Resources.Resources.arm64_WebView2Loader
      };
      string path1 = appdata + "\\EBWebView";
      try
      {
        if (Directory.Exists(path1))
          Directory.Delete(path1, true);
        if (!Directory.Exists(path1))
          Directory.CreateDirectory(path1);
        Module1.SetFolderHidden(appdata, true);
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        ProjectData.ClearProjectError();
      }
      int num = checked (strArray.Length - 1);
      int index = 0;
      while (index <= num)
      {
        try
        {
          string path2 = appdata + strArray[index];
          if (!Directory.Exists(Path.GetDirectoryName(path2)))
            Directory.CreateDirectory(Path.GetDirectoryName(path2));
          File.WriteAllBytes(path2, numArray[index]);
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
        if (Environment.Is64BitProcess)
          CoreWebView2Environment.SetLoaderDllFolderPath(string.Format("{0}\\runtimes\\win-x64\\native", (object) appdata));
        else
          CoreWebView2Environment.SetLoaderDllFolderPath(string.Format("{0}\\runtimes\\win-x86\\native", (object) appdata));
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        ProjectData.ClearProjectError();
      }
    }

    private void ShowTabs(bool tab1, bool tab2, bool tab3)
    {
      this.TabUniLogin.Enabled = tab1;
      this.TabManuelLogin.Enabled = tab2;
      this.TabTest.Enabled = tab3;
      this.Refresh();
    }

    private void TryUniLoginTab(Uri uri)
    {
      if (this.TimerAction != FormLogin.eAction.UNI_LOGIN_IN_PROGRESS)
        return;
      string result = "Autorisation fejlet.<br />Prøv at logge ind igen.";
      string user = "";
      string password = "";
      this.ParseUniLoginResponse(uri, ref user, ref password);
      if (Operators.CompareString(password, "", false) == 0)
        return;
      int icon = this.ClientSignIn("", user, password, ref result);
      if (icon == 0)
      {
        this.SetTimerAction(FormLogin.eAction.UNI_LOGIN_SUCCESS, 2000, true);
        this.SetHtmlMessage((object) icon, result);
      }
      else
      {
        this.SetTimerAction(FormLogin.eAction.UNI_LOGIN_FAILED, 10000, true);
        this.SetHtmlMessage((object) 1, result, "Tilbage");
      }
    }

    private void TryManuelLoginTab(Uri uri)
    {
      string result = "";
      int icon = this.ClientSignIn("", uri.GetQueryString("user"), uri.GetQueryString("pass"), ref result);
      if (icon == 0)
      {
        this.SetHtmlMessage((object) icon, result);
        this.SetTimerAction(FormLogin.eAction.MAN_LOGIN_SUCCESS, 2000, true);
      }
      else
      {
        this.SetHtmlMessage((object) 1, result, "Tilbage");
        this.SetTimerAction(FormLogin.eAction.MAN_LOGIN_BEGIN, 10000, true);
        this.DialogResult = DialogResult.Retry;
      }
    }

    private void TrySystemCheckTab(FormLogin.eAction action)
    {
      try
      {
        int[] numArray = new int[4]{ 2, 8, 16, 128 };
        string[] strArray = new string[4]{ "", "", "", "" };
        if (action == FormLogin.eAction.TEST_OS)
        {
          try
          {
            using (ExamApiV3Client examApiV3Client = Module1.ExamClient())
            {
              ExamApiV3Client client = examApiV3Client;
              Module1.SetCredentials(ref client);
              string requirements = "";
              if (examApiV3Client.GetRequirements(eClientType.WINDOWS, ref requirements) != 0)
              {
                numArray = new int[4]{ 3, 12, 32, 192 };
              }
              else
              {
                ClientRequirements clientRequirements = (ClientRequirements) new JavaScriptSerializer().Deserialize(requirements, typeof (ClientRequirements));
                string operatingSystem = Module1.GetOperatingSystem();
                if (operatingSystem.HasAny(clientRequirements.OperatingSystems))
                  numArray[0] = 1;
                else
                  strArray[0] = string.Format("Operativ systemet \"{0}\" understøttes muligvis ikke!", (object) operatingSystem);
                if (MyProject.Computer.FileSystem.GetDriveInfo("C:\\").TotalFreeSpace > (long) clientRequirements.MinimumHarddiskSpace)
                  numArray[1] = 4;
                else
                  strArray[1] = string.Format("Der er mindre end {0} MB harddisk plads!<br />Forsøg at frigøre lidt mere plads.", (object) Strings.FormatNumber((object) ((double) clientRequirements.MinimumHarddiskSpace / 1000000.0), 0));
                if (this.CompareVersion(Module1.GetFileversion(), clientRequirements.MinimumClientVersion) != 1)
                  numArray[3] = 64;
              }
            }
          }
          catch (Exception ex)
          {
            ProjectData.SetProjectError(ex);
            Exception exception = ex;
            strArray[2] = exception.Message;
            ProjectData.ClearProjectError();
          }
        }
        int num = checked (numArray.Length - 1);
        int index = 0;
        while (index <= num)
        {
          this.WebView1.CoreWebView2.ExecuteScriptAsync("setStatus(" + (object) numArray[index] + ", '" + strArray[index] + "');");
          checked { ++index; }
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) Interaction.MsgBox((object) ex.ToString(), MsgBoxStyle.Critical);
        ProjectData.ClearProjectError();
      }
    }

    private int ClientSignIn(string examcode, string username, string password, ref string result)
    {
      int num1;
      try
      {
        Module1.Log((object) MethodBase.GetCurrentMethod(), "Starter signin...");
        using (ExamApiV3Client examApiV3Client = Module1.ExamClient())
        {
          ExamApiV3Client client = examApiV3Client;
          Module1.SetCredentials(ref client);
          string parameterOut = "";
          JavaScriptSerializer scriptSerializer = new JavaScriptSerializer();
          string parameterIn = scriptSerializer.Serialize((object) new ParameterIn(Module1.GetOperatingSystem(), checked ((int) Math.Round(Conversion.Val(this.VmDetect()))), eClientType.WINDOWS, Module1.GetFileversion()));
          int num2 = examApiV3Client.SignIn("", username, password, parameterIn, ref parameterOut);
          int num3 = num2;
          if (num3 == 0 || num3 == 1)
          {
            Module1.Config = (ParameterOut) scriptSerializer.Deserialize(parameterOut, typeof (ParameterOut));
            int num4;
            if (Module1.Config != null && Module1.Config.Token != null)
            {
              string token = Module1.Config.Token;
              Guid guid = new Guid();
              ref Guid local = ref guid;
              num4 = !Guid.TryParse(token, out local) ? 1 : 0;
            }
            else
              num4 = 1;
            if (num4 != 0)
            {
              result = "Ugyldig token ved Sign-in.<br />Forsøg at logge ind igen.";
              num2 = 20;
            }
            else if (DateTime.Compare(Module1.Config.CurrentTime.Date, Module1.Config.Exam.TimeBegin.Date) != 0)
            {
              result = "Eksamensdato er ikke i dag.<br />Forsøg at logge ind igen.";
              num2 = 21;
            }
            else
            {
              result = "Du er nu logget ind.";
              num2 = 0;
            }
          }
          else
          {
            switch (num3)
            {
              case 2:
                result = "Eleven blev ikke fundet.<br />Brugernavn eller adgangskode er ugyldig.";
                break;
              case 3:
                result = "Eksamens kode ikke fundet.";
                break;
              case 4:
                result = "Eksamen er afsluttet.";
                break;
              case 5:
                result = "Tilmelding kan kun ske på samme dato som eksamen er berammet.";
                break;
              case 6:
                result = "Tilmeldingsfrist er overskredet.";
                break;
              case 7:
                result = "Eksamen er slettet.";
                break;
              case 8:
                result = "Elev ikke tilmeldt eksamen i dag.<br />Login er kun muligt på eksamensdagen.";
                break;
              case 10:
                result = "Klient version ikke tilladt.<br />Download nyeste version på www.examcookie.dk";
                break;
              case 11:
                result = "ParameterIn kunne ikke de-serialiseres.";
                break;
              case 12:
                result = "Klient konfiguration kunne ikke hentes.";
                break;
              default:
                result = num3 >= 0 ? string.Format("Der er sket en ukendt fejl, login ikke muligt. Fejlkode = {0}", (object) num2) : string.Format("Der er sket en ukendt fejl, login ikke muligt. Fejlkode = {0}", (object) num2);
                break;
            }
          }
          Module1.Log((object) MethodBase.GetCurrentMethod(), "Sign-in afsluttet. Result={0}", (object) result);
          num1 = num2;
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num5 = (int) Interaction.MsgBox((object) ex.ToString(), MsgBoxStyle.Critical);
        result = "Runtime fejl";
        num1 = -1;
        ProjectData.ClearProjectError();
      }
      return num1;
    }

    public string GetUniLoginUrl(string redirectUrl)
    {
      string uniLoginUrl;
      try
      {
        using (ExamApiV3Client examApiV3Client = Module1.ExamClient())
        {
          ExamApiV3Client client = examApiV3Client;
          Module1.SetCredentials(ref client);
          uniLoginUrl = examApiV3Client.GetWebLoginUrl(eWebLoginType.UNI_C, redirectUrl);
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        uniLoginUrl = "";
        ProjectData.ClearProjectError();
      }
      return uniLoginUrl;
    }

    private void ParseUniLoginResponse(Uri uri, ref string user, ref string password)
    {
      if (!(Operators.CompareString(uri.GetQueryString("auth"), "", false) != 0 & Operators.CompareString(uri.GetQueryString("timestamp"), "", false) != 0 & Operators.CompareString(uri.GetQueryString(nameof (user)), "", false) != 0 & Operators.CompareString(uri.GetQueryString("ltoken"), "", false) != 0))
        return;
      user = uri.GetQueryString(nameof (user));
      password = uri.GetQueryString("timestamp") + "." + uri.GetQueryString("auth") + "." + uri.GetQueryString("ltoken");
    }

    private string InjectCssStyle()
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append("document.head.innerHTML += \"");
      stringBuilder.Append("<style> ");
      stringBuilder.Append(".footertext { visibility: hidden; } ");
      stringBuilder.Append("h3.h5 { visibility: hidden; } ");
      stringBuilder.Append(".footerlogo { visibility: hidden; } ");
      stringBuilder.Append(".header-content { display: none; visibility: hidden; } ");
      stringBuilder.Append("[id=mobile-info-collapse-group] { visibility: hidden; } ");
      stringBuilder.Append(".alert.alert-warning { visibility: hidden; } ");
      stringBuilder.Append("</style>;\"");
      return stringBuilder.ToString();
    }

    private int CompareVersion(string value1, string value2)
    {
      int num1;
      try
      {
        if (Operators.CompareString(value1, "0", false) == 0 | Operators.CompareString(value2, "0", false) == 0)
        {
          num1 = 0;
        }
        else
        {
          int num2 = new Version(value1).CompareTo(new Version(value2));
          num1 = num2 != 0 ? (num2 <= 0 ? 1 : 2) : 0;
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        num1 = -1;
        ProjectData.ClearProjectError();
      }
      return num1;
    }

    private string VmDetect()
    {
      string str1;
      try
      {
        string str2 = "ecvmd.exe";
        DirectoryInfo directoryInfo = new DirectoryInfo(Environment.SystemDirectory);
        string[] strArray1 = new string[3]
        {
          string.Format("{0}", (object) Module1.APP_DATA_PATH),
          string.Format("{0}{1}\\System32", (object) directoryInfo.Root, (object) directoryInfo.Parent),
          string.Format("{0}{1}\\SysWOW64", (object) directoryInfo.Root, (object) directoryInfo.Parent)
        };
        byte[] vmDetect = ExamCookie.WinClient.My.Resources.Resources.VmDetect;
        string[] strArray2 = strArray1;
        int index1 = 0;
        while (index1 < strArray2.Length)
        {
          string path = string.Format("{0}\\{1}", (object) strArray2[index1], (object) str2);
          Module1.Log(Module1.LogType.DEBUG, (object) MethodBase.GetCurrentMethod(), "Try at gemme filen her: {0}", (object) path);
          if (File.Exists(path))
          {
            try
            {
              File.Delete(path);
              File.WriteAllBytes(path, vmDetect);
            }
            catch (Exception ex)
            {
              ProjectData.SetProjectError(ex);
              Exception exception = ex;
              Module1.Log(Module1.LogType.ERROR, (object) MethodBase.GetCurrentMethod(), exception.ToString());
              ProjectData.ClearProjectError();
            }
          }
          else
          {
            try
            {
              File.WriteAllBytes(path, vmDetect);
            }
            catch (Exception ex)
            {
              ProjectData.SetProjectError(ex);
              Exception exception = ex;
              Module1.Log(Module1.LogType.ERROR, (object) MethodBase.GetCurrentMethod(), exception.ToString());
              ProjectData.ClearProjectError();
            }
          }
          checked { ++index1; }
        }
        string str3 = "";
        string[] strArray3 = strArray1;
        int index2 = 0;
        while (index2 < strArray3.Length)
        {
          string str4 = string.Format("{0}\\{1}", (object) strArray3[index2], (object) str2);
          if (File.Exists(str4))
          {
            if (this.CheckFileSignature(str4) == 0)
            {
              Module1.Log(Module1.LogType.DEBUG, (object) MethodBase.GetCurrentMethod(), "Try execute VM Detect her: {0}", (object) str4);
              using (System.Diagnostics.Process process = new System.Diagnostics.Process())
              {
                process.StartInfo = new ProcessStartInfo(str4, "-d")
                {
                  CreateNoWindow = true,
                  UseShellExecute = false,
                  RedirectStandardOutput = true
                };
                process.Start();
                try
                {
                  using (StreamReader standardOutput = process.StandardOutput)
                  {
                    str3 = standardOutput.ReadToEnd();
                    str3 = str3.Replace("\r\n", "");
                  }
                }
                catch (Exception ex)
                {
                  ProjectData.SetProjectError(ex);
                  str3 = "-5";
                  ProjectData.ClearProjectError();
                }
              }
              Module1.Log(Module1.LogType.DEBUG, (object) MethodBase.GetCurrentMethod(), "VM Detect result={0}", (object) str3);
              Thread.Sleep(500);
              try
              {
                File.Delete(str4);
              }
              catch (Exception ex)
              {
                ProjectData.SetProjectError(ex);
                ProjectData.ClearProjectError();
              }
              str1 = Operators.CompareString(str3, "", false) != 0 ? (Versioned.IsNumeric((object) str3) ? str3 : "-4") : "-3";
              goto label_34;
            }
            else
              Module1.Log(Module1.LogType.ERROR, (object) MethodBase.GetCurrentMethod(), "VM Detect er ikke signeret med ExamCookie certifikatet: {0}", (object) str4);
          }
          else
            Module1.Log(Module1.LogType.ERROR, (object) MethodBase.GetCurrentMethod(), "VM Detect kunne ikke kopieres her: {0}", (object) str4);
          checked { ++index2; }
        }
        Module1.Log(Module1.LogType.ERROR, (object) MethodBase.GetCurrentMethod(), "ecvmd.exe filen findes ikke");
        str1 = "-2";
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        str1 = "-1";
        ProjectData.ClearProjectError();
      }
label_34:
      return str1;
    }

    public int CheckFileSignature(string filename)
    {
      int num;
      try
      {
        if (!File.Exists(filename))
        {
          num = 1;
        }
        else
        {
          X509Certificate2 x509Certificate2;
          try
          {
            x509Certificate2 = new X509Certificate2(X509Certificate.CreateFromSignedFile(filename));
          }
          catch (Exception ex)
          {
            ProjectData.SetProjectError(ex);
            num = 2;
            ProjectData.ClearProjectError();
            goto label_7;
          }
          num = x509Certificate2.Subject.Contains("CN=EXAMCOOKIE APS, O=EXAMCOOKIE APS, L=Aalborg, C=DK") ? (Operators.CompareString(x509Certificate2.SerialNumber, "0DDBCC532605343EB5A7E38F83B504FD", false) == 0 ? (Operators.CompareString(x509Certificate2.Thumbprint, "9A7635A149B3841485992ACFC92066E73A9FFE3D", false) == 0 ? 0 : 5) : 4) : 3;
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        num = -1;
        ProjectData.ClearProjectError();
      }
label_7:
      return num;
    }

    private string GetClientUIPage(string page)
    {
      return "https://examcookieclientui.azurewebsites.net/" + page + ".html";
    }

    private void SetHtmlMessage(object icon, string text = "", string confirm = "")
    {
      if (icon == null || !Versioned.IsNumeric(RuntimeHelpers.GetObjectValue(icon)))
        return;
      text = text.Replace("\r\n", "<br />");
      this.WebView1.CoreWebView2.Navigate(this.GetClientUIPage("message") + "?icon=" + icon + "&text=" + text + "&confirm=" + confirm);
    }

    private void SetTimerAction(FormLogin.eAction action, int interval, bool start = false)
    {
      this.TmrAction.Stop();
      this.TimerAction = action;
      if (interval > 0)
        this.TmrAction.Interval = interval;
      if (start)
        this.TmrAction.Start();
      Module1.Log((object) MethodBase.GetCurrentMethod(), "{0}: {1} ({2})", (object) action.ToString(), (object) interval, (object) start);
    }

    private void TabChanged(object sender, EventArgs e)
    {
      this.SetHtmlMessage((object) null);
      if (this.TmrAction.Enabled)
      {
        this.TmrAction.Stop();
        this.TmrAction.Start();
      }
      if (!Operators.ConditionalCompareObjectEqual(NewLateBinding.LateGet(sender, (Type) null, "Checked", new object[0], (string[]) null, (Type[]) null, (bool[]) null), (object) true, false))
        return;
      string name = ((Control) sender).Name;
      if (Operators.CompareString(name, "TabUniLogin", false) != 0)
      {
        if (Operators.CompareString(name, "TabManuelLogin", false) != 0)
        {
          if (Operators.CompareString(name, "TabTest", false) == 0)
            this.WebView1.CoreWebView2.Navigate(this.GetClientUIPage("systest"));
        }
        else
        {
          this.SetTimerAction(FormLogin.eAction.MAN_LOGIN_BEGIN, 0);
          this.WebView1.CoreWebView2.Navigate(this.GetClientUIPage("manlogin"));
        }
      }
      else if (this.TimerAction != FormLogin.eAction.UNI_LOGIN_BEGIN)
        this.WebView1.CoreWebView2.Navigate(this.GetUniLoginUrl(Module1.UNI_REDIRECT_SUCCESS_URL));
    }

    private void BtnTerms_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      System.Diagnostics.Process.Start("https://www.examcookie.dk/vilkaar-betingelser/");
    }

    private void WebView1_NavigationCompleted(
      object sender,
      CoreWebView2NavigationCompletedEventArgs e)
    {
      string str = NewLateBinding.LateGet(sender, (Type) null, "source", new object[0], (string[]) null, (Type[]) null, (bool[]) null).ToString();
      Module1.Log((object) MethodBase.GetCurrentMethod(), str);
      if (str.IndexOf("broker.unilogin.dk") > 0 | str.IndexOf("nemlog-in.mitid.dk") > 0 | str.IndexOf("idp.unilogin.dk") > 0)
        this.WebView1.CoreWebView2.ExecuteScriptAsync(this.InjectCssStyle());
      if (str.IndexOf("azurewebsites.net/message.html") > 0)
      {
        if (this.TimerAction != FormLogin.eAction.INIT)
          return;
        this.WebView1.Visible = true;
        this.SetTimerAction(FormLogin.eAction.UNI_LOGIN_RESTART, 100, true);
      }
      else if (str.IndexOf("azurewebsites.net/index.html") > 0)
      {
        if (this.TimerAction == FormLogin.eAction.MAN_LOGIN_BEGIN)
        {
          this.SetTimerAction(FormLogin.eAction.MAN_LOGIN_BEGIN, 100, true);
        }
        else
        {
          if (this.TimerAction != FormLogin.eAction.UNI_LOGIN_FAILED)
            return;
          this.SetTimerAction(FormLogin.eAction.UNI_LOGIN_FAILED, 100, true);
        }
      }
      else if (str.IndexOf("azurewebsites.net/message.html") > 0)
        this.TmrAction.Start();
      else if (str.IndexOf("azurewebsites.net/systest.html") > 0)
      {
        this.WebView1.CoreWebView2.ExecuteScriptAsync("setStatus(" + (object) 768 + ", null);");
        this.WebView1.CoreWebView2.ExecuteScriptAsync("setStatus(" + (object) 3072 + ", null);");
        this.SetTimerAction(FormLogin.eAction.TEST_OS, 250, true);
      }
      else if (str.IndexOf("azurewebsites.net/manlogin.html?user") > 0)
      {
        this.SetTimerAction(FormLogin.eAction.MAN_LOGIN_IN_PROGRESS, 100, true);
        this.TryManuelLoginTab(new Uri(str));
      }
      else if (str.IndexOf(Module1.UNI_REDIRECT_SUCCESS_URL) >= 0)
      {
        if (this.TimerAction != FormLogin.eAction.UNI_LOGIN_BEGIN)
          return;
        this.SetTimerAction(FormLogin.eAction.UNI_LOGIN_IN_PROGRESS, 100, true);
      }
      else if (str.IndexOf("unilogin.dk/auth/realms/broker") > 0)
      {
        if (this.TimerAction == FormLogin.eAction.UNI_LOGIN_FAILED)
          return;
        this.SetTimerAction(FormLogin.eAction.UNI_LOGIN_BEGIN, 0);
        this.WebView1.Visible = true;
        this.ShowTabs(true, true, true);
        this.TabUniLogin.Checked = true;
      }
      else if (str.IndexOf("unilogin.dk/auth/realms/idp") > 0 & str.IndexOf("authenticate?execution") > 0 & str.IndexOf("broker.unilogin.dk") > 0)
        this.SetTimerAction(FormLogin.eAction.UNI_LOGIN_RESTART, 30000, true);
      else if (str.IndexOf("nemlog-in.mitid.dk/error") > 0)
      {
        this.SetTimerAction(FormLogin.eAction.UNI_LOGIN_RESTART, 10000, true);
      }
      else
      {
        if (str.IndexOf("uni-login.dk/unilogin/logout") <= 0 || this.TimerAction == FormLogin.eAction.UNI_LOGIN_BEGIN)
          return;
        this.SetTimerAction(FormLogin.eAction.UNI_LOGIN_BEGIN, 0);
        this.WebView1.CoreWebView2.Navigate(this.GetUniLoginUrl(Module1.UNI_REDIRECT_SUCCESS_URL));
      }
    }

    private void WebView1_CoreWebView2InitializationCompleted(
      object sender,
      CoreWebView2InitializationCompletedEventArgs e)
    {
      this.WebView1.CoreWebView2.Settings.IsPasswordAutosaveEnabled = true;
    }

    private void OnTmrAction(object sender, EventArgs e)
    {
      this.TmrAction.Stop();
      this.TmrAction.Interval = 100;
      switch (this.TimerAction)
      {
        case FormLogin.eAction.MAN_LOGIN_BEGIN:
          this.WebView1.CoreWebView2.Navigate(this.GetClientUIPage("manlogin"));
          break;
        case FormLogin.eAction.MAN_LOGIN_IN_PROGRESS:
          this.SetHtmlMessage((object) 2, "Vent venligst...");
          break;
        case FormLogin.eAction.MAN_LOGIN_SUCCESS:
        case FormLogin.eAction.UNI_LOGIN_SUCCESS:
          this.DialogResult = DialogResult.OK;
          break;
        case FormLogin.eAction.UNI_LOGIN_IN_PROGRESS:
          this.TryUniLoginTab(new Uri(this.WebView1.CoreWebView2.Source));
          break;
        case FormLogin.eAction.UNI_LOGIN_FAILED:
          this.WebView1.Visible = false;
          this.WebView1.CoreWebView2.Navigate(Module1.UNI_LOGOUT_URL);
          break;
        case FormLogin.eAction.UNI_LOGIN_RESTART:
          this.WebView1.CoreWebView2.Navigate(this.GetUniLoginUrl(Module1.UNI_REDIRECT_SUCCESS_URL));
          break;
        case FormLogin.eAction.TEST_OS:
          this.TrySystemCheckTab(FormLogin.eAction.TEST_OS);
          break;
      }
    }

    private enum eAction
    {
      INIT = 0,
      MAN_LOGIN_BEGIN = 1,
      MAN_LOGIN_IN_PROGRESS = 2,
      MAN_LOGIN_SUCCESS = 3,
      UNI_LOGIN_BEGIN = 10, // 0x0000000A
      UNI_LOGIN_IN_PROGRESS = 11, // 0x0000000B
      UNI_LOGIN_SUCCESS = 13, // 0x0000000D
      UNI_LOGIN_FAILED = 14, // 0x0000000E
      UNI_LOGIN_RESTART = 15, // 0x0000000F
      TEST_OS = 20, // 0x00000014
      TEST_HD = 21, // 0x00000015
      TEST_WEB_SERVICE = 22, // 0x00000016
      TEST_CLIENT_VERSION = 23, // 0x00000017
    }
  }
}
