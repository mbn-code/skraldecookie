// Decompiled with JetBrains decompiler
// Type: ExamCookie.WinClient.Module1
// Assembly: ExamCookie.WinClient, Version=1.4.1.4, Culture=neutral, PublicKeyToken=null
// MVID: E12BE1F8-B6E0-4BF5-B308-166F0E938C4B
// Assembly location: C:\Users\oskar\Downloads\ExamCookie1414.WinClient.exe

using ExamCookie.Library;
using ExamCookie.WinClient.ExamApiV3Service;
using ExamCookie.WinClient.My;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.AccessControl;
using System.Security.Cryptography;
using System.Security.Principal;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Security;
using System.Text;
using System.Threading;
using System.Web;
using System.Windows.Forms;
using System.Xml.Serialization;

#nullable disable
namespace ExamCookie.WinClient
{
  [StandardModule]
  internal sealed class Module1
  {
    public static string APP_DATA_PATH = "C:\\Temp\\ExamCookie\\AppData";
    public static string APP_FILENAME = Path.GetFileNameWithoutExtension(Application.ExecutablePath);
    public static string APP_CURRENT_DIR = Directory.GetCurrentDirectory();
    public static string APP_CURRENT_USER = WindowsIdentity.GetCurrent().Name;
    public static string OFFLINE_PACKAGE_FOLDER = "ecoffline";
    public static object PACKAGE_FILE_EXTENSION = (object) "ecpck";
    public static int WM_DETECT = 0;
    public static string USER_SIGN_IN_TOKEN = "";
    public static bool USER_SIGNED_OUT = false;
    public static bool USER_SIGN_OUT_SUCCESS = false;
    public static int FORCE_CLOSE_DELAY = 10;
    public static bool LOG_SESSION = true;
    public static bool LOG_SESSION_LOCAL = false;
    public static string UNI_AUTH_CODE = "";
    public static string UNI_CODE_VERIFIER = "";
    public static string UNI_SIGNIN_TOKEN = "";
    public static string ID_TOKEN_HINT = "";
    public static string UNI_LOGOUT_URL = "https://sso.emu.dk/logout";
    public static string UNI_REDIRECT_SUCCESS_URL = "https://examcookieclientui.azurewebsites.net/success.html";
    public static string UNI_REDIRECT_LOGOUT_URL = "https://et-broker.unilogin.dk/auth/realms/broker/protocol/openid-connect/logout";
    public static ParameterOut Config = new ParameterOut();
    public static List<ClientError> ClientReport = new List<ClientError>();
    public static List<string> SessionLog = new List<string>();
    public static string LastError = "";
    [SpecialName]
    private static DateTime \u0024STATIC\u0024SessionLogToFile\u0024011E\u0024last;
    [SpecialName]
    private static StaticLocalInitFlag \u0024STATIC\u0024SessionLogToFile\u0024011E\u0024last\u0024Init;
    [SpecialName]
    private static int \u0024STATIC\u0024SessionLogToFile\u0024011E\u0024index;
    [SpecialName]
    private static StaticLocalInitFlag \u0024STATIC\u0024SessionLogToFile\u0024011E\u0024index\u0024Init;

    [DllImport("wininet.dll", SetLastError = true)]
    public static extern bool InternetGetConnectedState(ref int lpdwFlags, int dwReserved);

    [DllImport("wininet.dll", SetLastError = true)]
    public static extern bool InternetCheckConnection(string lpszUrl, int dwFlags, int dwReserved);

    [DllImport("kernel32.dll", CharSet = CharSet.Ansi, SetLastError = true)]
    public static extern int SetProcessWorkingSetSize(
      IntPtr process,
      int minimumWorkingSetSize,
      int maximumWorkingSetSize);

    [DllImport("kernel32.dll", SetLastError = true)]
    public static extern bool SetLocalTime(ref Module1.SYSTEMTIME time);

    [DllImport("Shcore.dll")]
    public static extern int GetDpiForMonitor(
      IntPtr hmonitor,
      int dpiType,
      ref uint dpiX,
      ref uint dpiY);

    [DllImport("user32.dll")]
    public static extern bool EnumDisplaySettings(
      string lpszDeviceName,
      int iModeNum,
      ref Module1.DEVMODE lpDevMode);

    public static void OptimizeMemoryConsumption()
    {
      GC.Collect();
      GC.WaitForPendingFinalizers();
      Module1.SetProcessWorkingSetSize(System.Diagnostics.Process.GetCurrentProcess().Handle, -1, -1);
    }

    public static void DebugPrint(string message, params object[] args)
    {
      try
      {
        Debug.Print(message, args);
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        ProjectData.ClearProjectError();
      }
    }

    public static void Log(object source, string message, params object[] args)
    {
      Module1.Log(Module1.LogType.DEBUG, RuntimeHelpers.GetObjectValue(source), message, args);
    }

    public static void Log(
      Module1.LogType type,
      object source,
      string message,
      params object[] args)
    {
      try
      {
        string str = message;
        if (args.Length > 0)
          str = string.Format(message, args);
        string message1 = DateAndTime.TimeString + ";" + type.ToString().ToUpper() + ";" + Module1.GetMethodName(RuntimeHelpers.GetObjectValue(source)) + ";" + str + "\u0003";
        Debug.Print(message1);
        if (type == Module1.LogType.ERROR)
        {
          Module1.LastError = message;
          Module1.LogToClientReport(message);
        }
        if (!Module1.LOG_SESSION)
          return;
        Module1.LogToBuffer(message1);
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Module1.LogToClientReport(ex.ToString());
        ProjectData.ClearProjectError();
      }
    }

    private static void LogToBuffer(string message)
    {
      if (message == null || Operators.CompareString(message, "", false) == 0)
        return;
      Module1.SessionLog.Add(message);
    }

    public static void LogToClientReport(string message)
    {
      try
      {
        ClientError clientError = Module1.ClientReport.Find((Predicate<ClientError>) ([SpecialName] (x) => Operators.CompareString(x.Message, message, false) == 0));
        if (clientError == null)
        {
          Module1.ClientReport.Add(new ClientError(message));
        }
        else
        {
          // ISSUE: variable of a reference type
          int& local;
          // ISSUE: explicit reference operation
          int num = checked (^(local = ref clientError.Count) + 1);
          local = num;
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        ProjectData.ClearProjectError();
      }
    }

    public static void SessionLogToFile(string path)
    {
      if (Module1.\u0024STATIC\u0024SessionLogToFile\u0024011E\u0024last\u0024Init == null)
        Interlocked.CompareExchange<StaticLocalInitFlag>(ref Module1.\u0024STATIC\u0024SessionLogToFile\u0024011E\u0024last\u0024Init, new StaticLocalInitFlag(), (StaticLocalInitFlag) null);
      bool lockTaken1 = false;
      try
      {
        System.Threading.Monitor.Enter((object) Module1.\u0024STATIC\u0024SessionLogToFile\u0024011E\u0024last\u0024Init, ref lockTaken1);
        if (Module1.\u0024STATIC\u0024SessionLogToFile\u0024011E\u0024last\u0024Init.State == (short) 0)
        {
          Module1.\u0024STATIC\u0024SessionLogToFile\u0024011E\u0024last\u0024Init.State = (short) 2;
          Module1.\u0024STATIC\u0024SessionLogToFile\u0024011E\u0024last = DateAndTime.Now;
        }
        else if (Module1.\u0024STATIC\u0024SessionLogToFile\u0024011E\u0024last\u0024Init.State == (short) 2)
          throw new IncompleteInitialization();
      }
      finally
      {
        Module1.\u0024STATIC\u0024SessionLogToFile\u0024011E\u0024last\u0024Init.State = (short) 1;
        if (lockTaken1)
          System.Threading.Monitor.Exit((object) Module1.\u0024STATIC\u0024SessionLogToFile\u0024011E\u0024last\u0024Init);
      }
      if (Module1.\u0024STATIC\u0024SessionLogToFile\u0024011E\u0024index\u0024Init == null)
        Interlocked.CompareExchange<StaticLocalInitFlag>(ref Module1.\u0024STATIC\u0024SessionLogToFile\u0024011E\u0024index\u0024Init, new StaticLocalInitFlag(), (StaticLocalInitFlag) null);
      bool lockTaken2 = false;
      try
      {
        System.Threading.Monitor.Enter((object) Module1.\u0024STATIC\u0024SessionLogToFile\u0024011E\u0024index\u0024Init, ref lockTaken2);
        if (Module1.\u0024STATIC\u0024SessionLogToFile\u0024011E\u0024index\u0024Init.State == (short) 0)
        {
          Module1.\u0024STATIC\u0024SessionLogToFile\u0024011E\u0024index\u0024Init.State = (short) 2;
          Module1.\u0024STATIC\u0024SessionLogToFile\u0024011E\u0024index = 0;
        }
        else if (Module1.\u0024STATIC\u0024SessionLogToFile\u0024011E\u0024index\u0024Init.State == (short) 2)
          throw new IncompleteInitialization();
      }
      finally
      {
        Module1.\u0024STATIC\u0024SessionLogToFile\u0024011E\u0024index\u0024Init.State = (short) 1;
        if (lockTaken2)
          System.Threading.Monitor.Exit((object) Module1.\u0024STATIC\u0024SessionLogToFile\u0024011E\u0024index\u0024Init);
      }
      try
      {
        if (DateTime.Compare(DateAndTime.Now, Module1.\u0024STATIC\u0024SessionLogToFile\u0024011E\u0024last.AddSeconds(10.0)) <= 0)
          return;
        Module1.\u0024STATIC\u0024SessionLogToFile\u0024011E\u0024last = DateAndTime.Now;
        if (Module1.SessionLog.Count > Module1.\u0024STATIC\u0024SessionLogToFile\u0024011E\u0024index)
        {
          Assembly executingAssembly = Assembly.GetExecutingAssembly();
          using (StreamWriter streamWriter = new StreamWriter(string.Format("{0}\\{1}_{2}.log", (object) path, (object) executingAssembly.GetName().Name, (object) DateAndTime.DateString), true))
          {
            int num1 = Module1.\u0024STATIC\u0024SessionLogToFile\u0024011E\u0024index;
            int num2 = checked (Module1.SessionLog.Count - 1);
            int index = num1;
            while (index <= num2)
            {
              streamWriter.WriteLine(Module1.SessionLog[index]);
              checked { ++index; }
            }
          }
          Module1.\u0024STATIC\u0024SessionLogToFile\u0024011E\u0024index = Module1.SessionLog.Count;
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        ProjectData.ClearProjectError();
      }
    }

    public static string GetClientErrorLog()
    {
      string clientErrorLog;
      try
      {
        clientErrorLog = Module1.ClientReport.Count != 0 ? Module1.SerializeToXmlString((object) Module1.ClientReport.ToArray(), false) : "";
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        clientErrorLog = "";
        ProjectData.ClearProjectError();
      }
      return clientErrorLog;
    }

    public static string CreateFolderWithFullControl(string folder, string username)
    {
      string folderWithFullControl;
      try
      {
        if (!Directory.Exists(folder))
          Directory.CreateDirectory(folder);
        DirectorySecurity directorySecurity = new DirectorySecurity();
        FileSystemRights fileSystemRights = FileSystemRights.FullControl;
        InheritanceFlags inheritanceFlags = InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit;
        PropagationFlags propagationFlags = PropagationFlags.None;
        AccessControlType type = AccessControlType.Allow;
        FileSystemAccessRule rule = new FileSystemAccessRule(username, fileSystemRights, inheritanceFlags, propagationFlags, type);
        directorySecurity.AddAccessRule(rule);
        Directory.GetAccessControl(folder);
        Directory.SetAccessControl(folder, directorySecurity);
        folderWithFullControl = "";
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        folderWithFullControl = ex.Message;
        ProjectData.ClearProjectError();
      }
      return folderWithFullControl;
    }

    public static void SetFolderHidden(string path, bool hide)
    {
      try
      {
        DirectoryInfo directoryInfo = new DirectoryInfo(path);
        FileAttributes attributes = directoryInfo.Attributes;
        FileAttributes fileAttributes = !hide ? attributes & ~FileAttributes.Hidden : attributes | FileAttributes.Hidden;
        directoryInfo.Attributes = fileAttributes;
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Debug.Print(ex.ToString());
        ProjectData.ClearProjectError();
      }
    }

    public static bool IsFolderHidden(string folderPath)
    {
      bool flag;
      try
      {
        flag = (new DirectoryInfo(folderPath).Attributes & FileAttributes.Hidden) == FileAttributes.Hidden;
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Debug.Print(ex.ToString());
        flag = false;
        ProjectData.ClearProjectError();
      }
      return flag;
    }

    public static void SaveLogBuffer()
    {
      try
      {
        if (Module1.SessionLog.Count <= 0)
          return;
        string path = string.Format("{0}\\{1}", (object) Module1.APP_DATA_PATH, (object) "Log");
        if (!Directory.Exists(path))
        {
          try
          {
            Directory.CreateDirectory(path);
          }
          catch (Exception ex)
          {
            ProjectData.SetProjectError(ex);
            Module1.SessionLog.Clear();
            ProjectData.ClearProjectError();
          }
        }
        try
        {
          using (StreamWriter streamWriter = new StreamWriter(string.Format("{0}\\session-{1}.log", (object) path, (object) Module1.USER_SIGN_IN_TOKEN), true))
          {
            while (Module1.SessionLog.Count > 0)
            {
              try
              {
                streamWriter.WriteLine(Module1.SessionLog[0]);
              }
              catch (Exception ex)
              {
                ProjectData.SetProjectError(ex);
                ProjectData.ClearProjectError();
              }
              Module1.SessionLog.RemoveAt(0);
            }
          }
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          Module1.SessionLog.Clear();
          ProjectData.ClearProjectError();
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        ProjectData.ClearProjectError();
      }
    }

    public static void LogToFile(string path, string text)
    {
      StreamWriter streamWriter = (StreamWriter) null;
      try
      {
        if (!Directory.Exists(path))
          Directory.CreateDirectory(path);
        Assembly executingAssembly = Assembly.GetExecutingAssembly();
        streamWriter = new StreamWriter(string.Format("{0}\\{1}_{2}.log", (object) path, (object) executingAssembly.GetName().Name, (object) DateAndTime.DateString), true);
        streamWriter.WriteLine(text);
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        ProjectData.ClearProjectError();
      }
      finally
      {
        streamWriter?.Close();
      }
    }

    public static string GetMethodName(object sender)
    {
      string methodName;
      try
      {
        methodName = Operators.CompareString(Versioned.TypeName(RuntimeHelpers.GetObjectValue(sender)), "RuntimeMethodInfo", false) != 0 ? (Operators.CompareString(Versioned.TypeName(RuntimeHelpers.GetObjectValue(sender)), "String", false) != 0 ? "" : Conversions.ToString(sender)) : Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(NewLateBinding.LateGet(NewLateBinding.LateGet(sender, (System.Type) null, "ReflectedType", new object[0], (string[]) null, (System.Type[]) null, (bool[]) null), (System.Type) null, "Name", new object[0], (string[]) null, (System.Type[]) null, (bool[]) null), (object) "."), NewLateBinding.LateGet(sender, (System.Type) null, "name", new object[0], (string[]) null, (System.Type[]) null, (bool[]) null)));
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        methodName = "";
        ProjectData.ClearProjectError();
      }
      return methodName;
    }

    public static bool IsInternetConnected()
    {
      bool flag;
      try
      {
        Ping ping = new Ping();
        string[] strArray = new string[3]
        {
          "www.google.com",
          "8.8.8.8",
          "8.8.4.4"
        };
        int index = 0;
        while (index < strArray.Length)
        {
          string hostNameOrAddress = strArray[index];
          if (ping.Send(hostNameOrAddress).Status == IPStatus.Success)
          {
            flag = true;
            goto label_8;
          }
          else
            checked { ++index; }
        }
        flag = false;
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        flag = false;
        ProjectData.ClearProjectError();
      }
label_8:
      return flag;
    }

    public static bool IsInternetConnected(ref Module1.NetConnectType type)
    {
      bool flag;
      try
      {
        int lpdwFlags = 0;
        bool connectedState = Module1.InternetGetConnectedState(ref lpdwFlags, 0);
        if (!connectedState)
          type = Module1.NetConnectType.INTERNET_CONNECTION_OFFLINE;
        else if ((lpdwFlags & 2) > 0 | (lpdwFlags & 1) > 0 | (lpdwFlags & 4) > 0)
        {
          type = Module1.NetConnectType.INTERNET_CONNECTION_ONLINE;
          if ((lpdwFlags & 16) <= 0)
            ;
        }
        else
          type = (lpdwFlags & 32) <= 0 ? ((lpdwFlags & 64) <= 0 ? ((lpdwFlags & 16) <= 0 ? Module1.NetConnectType.INTERNET_CONNECTION_OFFLINE : Module1.NetConnectType.INTERNET_RAS_INSTALLED) : Module1.NetConnectType.INTERNET_CONNECTION_CONFIGURED) : Module1.NetConnectType.INTERNET_CONNECTION_OFFLINE;
        flag = connectedState;
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        flag = false;
        ProjectData.ClearProjectError();
      }
      return flag;
    }

    public static void RunCommand(string command, string arguments, bool permanent)
    {
      try
      {
        new System.Diagnostics.Process()
        {
          StartInfo = new ProcessStartInfo()
          {
            Arguments = (" " + (permanent ? "/K" : "/C") + " " + command + " " + arguments),
            FileName = "cmd.exe"
          }
        }.Start();
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Exception exception = ex;
        Module1.Log(Module1.LogType.ERROR, (object) MethodBase.GetCurrentMethod(), exception.ToString());
        ProjectData.ClearProjectError();
      }
    }

    public static string RunCommand(string command, string arguments = "")
    {
      string str;
      try
      {
        System.Diagnostics.Process process = new System.Diagnostics.Process();
        process.StartInfo = new ProcessStartInfo()
        {
          Arguments = string.Format(" /C {0} {1}", (object) command, (object) arguments),
          Verb = "runas",
          CreateNoWindow = true,
          UseShellExecute = false,
          RedirectStandardOutput = true,
          FileName = "cmd.exe"
        };
        process.Start();
        try
        {
          using (StreamReader standardOutput = process.StandardOutput)
            str = standardOutput.ReadToEnd();
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          Exception exception = ex;
          Module1.Log(Module1.LogType.ERROR, (object) MethodBase.GetCurrentMethod(), exception.ToString());
          str = (string) null;
          ProjectData.ClearProjectError();
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Exception exception = ex;
        Module1.Log(Module1.LogType.ERROR, (object) MethodBase.GetCurrentMethod(), exception.ToString());
        str = (string) null;
        ProjectData.ClearProjectError();
      }
      return str;
    }

    public static void RunAsCommand(string command, string arguments = "")
    {
      try
      {
        System.Diagnostics.Process.Start(new ProcessStartInfo()
        {
          Arguments = string.Format(" /C {0} {1}", (object) command, (object) arguments),
          Verb = "runas",
          CreateNoWindow = true,
          UseShellExecute = true,
          RedirectStandardOutput = false,
          FileName = "cmd.exe"
        });
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Exception exception = ex;
        Module1.Log(Module1.LogType.ERROR, (object) MethodBase.GetCurrentMethod(), exception.ToString());
        ProjectData.ClearProjectError();
      }
    }

    public static string GetOperatingSystem()
    {
      string operatingSystem;
      try
      {
        operatingSystem = MyProject.Computer.Info.OSFullName;
      }
      catch (Exception ex1)
      {
        ProjectData.SetProjectError(ex1);
        try
        {
          operatingSystem = Environment.OSVersion.ToString();
          ProjectData.ClearProjectError();
        }
        catch (Exception ex2)
        {
          ProjectData.SetProjectError(ex2);
          operatingSystem = ex2.Message;
          ProjectData.ClearProjectError();
        }
      }
      return operatingSystem;
    }

    public static string GetWindowsReleaseId()
    {
      return Conversions.ToString(Registry.GetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion", "ReleaseId", (object) ""));
    }

    public static string GetFileversion() => Application.ProductVersion;

    public static void SetComputerClock()
    {
      try
      {
        DateTime networkDateTime = DateTime.MinValue;
        if (Module1.GetNetworkTime(ref networkDateTime) == 0)
        {
          networkDateTime = networkDateTime.ToLocalTime();
          Module1.SYSTEMTIME time;
          time.year = checked ((short) networkDateTime.Year);
          time.month = checked ((short) networkDateTime.Month);
          time.dayOfWeek = checked ((short) networkDateTime.DayOfWeek);
          time.day = checked ((short) networkDateTime.Day);
          time.hour = checked ((short) networkDateTime.Hour);
          time.minute = checked ((short) networkDateTime.Minute);
          time.second = checked ((short) networkDateTime.Second);
          time.milliseconds = checked ((short) networkDateTime.Millisecond);
          if (Module1.SetLocalTime(ref time))
            return;
          Module1.Log(Module1.LogType.ERROR, (object) MethodBase.GetCurrentMethod(), "Sæt computer ur fejlet");
        }
        else
          Module1.Log(Module1.LogType.ERROR, (object) MethodBase.GetCurrentMethod(), "Kan ikke hente internet server tid");
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Exception exception = ex;
        Module1.Log(Module1.LogType.ERROR, (object) MethodBase.GetCurrentMethod(), exception.ToString());
        ProjectData.ClearProjectError();
      }
    }

    public static string FormatExamEndTime(DateTime timeEnd, int timeExt, string timeFormat = "HH:mm:ss")
    {
      if (timeExt == 0)
        return Strings.Format((object) timeEnd, timeFormat);
      TimeSpan timeSpan = TimeSpan.FromMinutes((double) timeExt);
      return string.Format("{0} +{1}", (object) Strings.Format((object) timeEnd, timeFormat), (object) string.Format("{0:00}:{1:00}", (object) Math.Floor(timeSpan.TotalHours), (object) timeSpan.Minutes));
    }

    public static string ToAsciiCtrl(string value)
    {
      string[] strArray = new string[32]
      {
        "NUL",
        "SOH",
        "STX",
        "ETX",
        "EOT",
        "ENQ",
        "ACK",
        "BEL",
        "BS",
        "TAB",
        "LF",
        "VT",
        "FF",
        "CR",
        "SO",
        "SI",
        "DLE",
        "DC1",
        "DC2",
        "DC3",
        "DC4",
        "NAK",
        "SYN",
        "ETB",
        "CAN",
        "EM",
        "SUB",
        "ESC",
        "FS",
        "GS",
        "RS",
        "US"
      };
      int num = checked (strArray.Length - 1);
      int CharCode = 0;
      while (CharCode <= num)
      {
        value = Strings.Replace(value, Conversions.ToString(Strings.Chr(CharCode)), "<" + strArray[CharCode] + ">");
        checked { ++CharCode; }
      }
      return value;
    }

    public static string ToMACAddress(byte[] buffer)
    {
      string macAddress;
      try
      {
        List<string> stringList = new List<string>();
        byte[] numArray = buffer;
        int index = 0;
        while (index < numArray.Length)
        {
          byte num = numArray[index];
          stringList.Add(num.ToString("X2"));
          checked { ++index; }
        }
        macAddress = Strings.Join(stringList.ToArray(), "-");
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        macAddress = "";
        ProjectData.ClearProjectError();
      }
      return macAddress;
    }

    public static ExamApiV3Client ExamClient()
    {
      ExamApiV3Client examApiV3Client;
      try
      {
        CustomBinding customBinding = new CustomBinding();
        customBinding.Name = "CustomBinding_IExamApiV3";
        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
        SecurityBindingElement transportBindingElement = (SecurityBindingElement) SecurityBindingElement.CreateUserNameOverTransportBindingElement();
        transportBindingElement.DefaultAlgorithmSuite = SecurityAlgorithmSuite.Default;
        transportBindingElement.MessageSecurityVersion = MessageSecurityVersion.WSSecurity11WSTrustFebruary2005WSSecureConversationFebruary2005WSSecurityPolicy11BasicSecurityProfile10;
        transportBindingElement.IncludeTimestamp = false;
        transportBindingElement.LocalClientSettings.DetectReplays = false;
        transportBindingElement.LocalServiceSettings.DetectReplays = false;
        customBinding.Elements.Add((BindingElement) transportBindingElement);
        customBinding.Elements.Add((BindingElement) new MtomMessageEncodingBindingElement()
        {
          MessageVersion = MessageVersion.Soap11
        });
        customBinding.Elements.Add((BindingElement) new HttpsTransportBindingElement());
        examApiV3Client = new ExamApiV3Client((System.ServiceModel.Channels.Binding) customBinding, new EndpointAddress(ExamCookie.WinClient.My.Resources.Resources.WCF_ENDPOINT + "/ExamApiV3.svc"));
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Exception exception = ex;
        Module1.Log(Module1.LogType.ERROR, (object) MethodBase.GetCurrentMethod(), exception.ToString());
        examApiV3Client = (ExamApiV3Client) null;
        ProjectData.ClearProjectError();
      }
      return examApiV3Client;
    }

    public static void SetCredentials(ref ExamApiV3Client client)
    {
      client.ClientCredentials.UserName.UserName = ExamCookie.WinClient.My.Resources.Resources.WCF_USERNAME;
      client.ClientCredentials.UserName.Password = ExamCookie.WinClient.My.Resources.Resources.WCF_PASSWORD;
    }

    public static string GetMD5Hash(string value)
    {
      using (MD5 md5 = MD5.Create())
      {
        StringBuilder stringBuilder = new StringBuilder();
        byte[] hash = md5.ComputeHash(Encoding.UTF8.GetBytes(value));
        int index = 0;
        while (index < hash.Length)
        {
          byte num = hash[index];
          stringBuilder.Append(num.ToString("X2"));
          checked { ++index; }
        }
        return stringBuilder.ToString().ToLower();
      }
    }

    public static string ToBase64(string value)
    {
      return Convert.ToBase64String(Encoding.UTF8.GetBytes(value));
    }

    public static string UriEncode(string value) => HttpUtility.UrlEncode(value);

    public static StringBuilder AppendLineFormat(
      this StringBuilder value,
      string format,
      params object[] args)
    {
      return value.Append(string.Format(format, args) + "\r\n");
    }

    public static string GetQueryString(this Uri uri, string name)
    {
      string queryString;
      try
      {
        if (uri != null)
        {
          int startIndex = uri.ToString().IndexOf(name);
          if (startIndex >= 0)
          {
            int num = uri.ToString().IndexOf("&", startIndex);
            if (num == -1)
              num = uri.ToString().Length;
            queryString = uri.ToString().Substring(checked (startIndex + name.Length + 1), checked (num - startIndex - name.Length - 1)).Trim();
          }
          else
            queryString = "";
        }
        else
          queryString = "";
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        queryString = "";
        ProjectData.ClearProjectError();
      }
      return queryString;
    }

    public static Dictionary<string, string> GetUrlParameters(this string url)
    {
      string[] strArray1 = new Uri(url).Query.TrimStart('?').Split('&');
      Dictionary<string, string> urlParameters = new Dictionary<string, string>();
      string[] strArray2 = strArray1;
      int index = 0;
      while (index < strArray2.Length)
      {
        string[] strArray3 = strArray2[index].Split('=');
        if (strArray3.Length == 2)
          urlParameters[strArray3[0]] = strArray3[1];
        checked { ++index; }
      }
      return urlParameters;
    }

    public static double LabTime(this DateTime value)
    {
      return DateAndTime.Now.Subtract(value).TotalMilliseconds;
    }

    public static string ToEN(this DateTime datetime)
    {
      return Strings.Format((object) datetime, "MM-dd-yyyy HH:mm:ss");
    }

    public static string ToDK(this DateTime datetime)
    {
      return Strings.Format((object) datetime, "dd-MM-yyyy HH:mm:ss");
    }

    public static bool IsNull(this DateTime value)
    {
      return DateTime.Compare(value, DateTime.MinValue) == 0;
    }

    public static int Neg(this int value) => checked (-Math.Abs(value));

    public static object Pop(this List<object> buffer, int index = 0)
    {
      object obj;
      try
      {
        if (buffer == null)
          obj = (object) null;
        else if (buffer.Count > index)
        {
          object objectValue = RuntimeHelpers.GetObjectValue(buffer.ToList<object>()[index]);
          buffer.RemoveAt(index);
          obj = objectValue;
        }
        else
          obj = (object) null;
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        obj = (object) null;
        ProjectData.ClearProjectError();
      }
      return obj;
    }

    public static int GetParentProcessId(this System.Diagnostics.Process process)
    {
      int parentProcessId;
      try
      {
        parentProcessId = checked ((int) new PerformanceCounter("Process", "Creating Process ID", process.ProcessName).RawValue);
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        parentProcessId = -1;
        ProjectData.ClearProjectError();
      }
      return parentProcessId;
    }

    public static bool Containing(this string value, string item)
    {
      return value.ToLower().IndexOf(item.ToLower()) >= 0;
    }

    public static bool Containing(this string value, string[] items)
    {
      string[] strArray = items;
      int index = 0;
      while (index < strArray.Length)
      {
        string str = strArray[index];
        if (value.Containing(str))
          return true;
        checked { ++index; }
      }
      return false;
    }

    public static bool Has(this string value, string item)
    {
      return value.ToLower().IndexOf(item.ToLower()) != -1;
    }

    public static bool HasOnly(this string value, string item)
    {
      return Operators.CompareString(value.ToLower(), item.ToLower(), false) == 0;
    }

    public static bool HasAll(this string value, string[] items)
    {
      string[] strArray = items;
      int index = 0;
      while (index < strArray.Length)
      {
        string str = strArray[index];
        if (value.ToLower().IndexOf(str.ToLower()) == -1)
          return false;
        checked { ++index; }
      }
      return true;
    }

    public static bool HasAny(this string value, string[] items)
    {
      string[] strArray = items;
      int index = 0;
      while (index < strArray.Length)
      {
        string str = strArray[index];
        if (value.ToLower().IndexOf(str.ToLower()) >= 0)
          return true;
        checked { ++index; }
      }
      return false;
    }

    public static byte[] GetBytes(this string value)
    {
      byte[] dst = new byte[checked (value.Length - 1 + 1)];
      Buffer.BlockCopy((Array) value.ToCharArray(), 0, (Array) dst, 0, dst.Length);
      return dst;
    }

    public static string GetString(this byte[] value)
    {
      char[] dst = (char[]) null;
      Buffer.BlockCopy((Array) value, 0, (Array) dst, 0, value.Length);
      return new string(dst);
    }

    public static string ToUri(this string value)
    {
      if (value == null || Operators.CompareString(value, "", false) == 0)
        return "";
      return value.ToLower().IndexOf("http") >= 0 ? value : "http://" + value;
    }

    public static byte[,] GetDifferences(this Image img1, Image img2)
    {
      img1.Resize(16, 16);
      using (Bitmap grayScaleVersion1 = (Bitmap) img1.Resize(16, 16).GetGrayScaleVersion())
      {
        using (Bitmap grayScaleVersion2 = (Bitmap) img2.Resize(16, 16).GetGrayScaleVersion())
        {
          byte[,] differences = new byte[16, 16];
          byte[,] grayScaleValues1 = grayScaleVersion1.GetGrayScaleValues();
          byte[,] grayScaleValues2 = grayScaleVersion2.GetGrayScaleValues();
          int index1 = 0;
          do
          {
            int index2 = 0;
            do
            {
              differences[index2, index1] = checked ((byte) Math.Abs((int) grayScaleValues1[index2, index1] - (int) grayScaleValues2[index2, index1]));
              checked { ++index2; }
            }
            while (index2 <= 15);
            checked { ++index1; }
          }
          while (index1 <= 15);
          return differences;
        }
      }
    }

    public static byte[,] GetGrayScaleValues(this Image img)
    {
      using (Bitmap grayScaleVersion = (Bitmap) img.Resize(16, 16).GetGrayScaleVersion())
      {
        byte[,] grayScaleValues = new byte[16, 16];
        int y = 0;
        do
        {
          int x = 0;
          do
          {
            grayScaleValues[x, y] = checked ((byte) Math.Abs((short) grayScaleVersion.GetPixel(x, y).R));
            checked { ++x; }
          }
          while (x <= 15);
          checked { ++y; }
        }
        while (y <= 15);
        return grayScaleValues;
      }
    }

    public static Image GetGrayScaleVersion(this Image original)
    {
      ColorMatrix newColorMatrix = new ColorMatrix(new float[5][]
      {
        new float[5]{ 0.3f, 0.3f, 0.3f, 0.0f, 0.0f },
        new float[5]{ 0.59f, 0.59f, 0.59f, 0.0f, 0.0f },
        new float[5]{ 0.11f, 0.11f, 0.11f, 0.0f, 0.0f },
        new float[5]{ 0.0f, 0.0f, 0.0f, 1f, 0.0f },
        new float[5]{ 0.0f, 0.0f, 0.0f, 0.0f, 1f }
      });
      using (Bitmap bitmap = new Bitmap(original.Width, original.Height))
      {
        using (Graphics graphics = Graphics.FromImage((Image) bitmap))
        {
          using (ImageAttributes imageAttr = new ImageAttributes())
          {
            imageAttr.SetColorMatrix(newColorMatrix);
            graphics.DrawImage(original, new Rectangle(0, 0, original.Width, original.Height), 0, 0, original.Width, original.Height, GraphicsUnit.Pixel, imageAttr);
          }
        }
        return (Image) bitmap.Clone();
      }
    }

    public static Image Resize(this Image originalImage, int newWidth, int newHeight)
    {
      using (Image image = (Image) new Bitmap(newWidth, newHeight))
      {
        using (Graphics graphics = Graphics.FromImage(image))
        {
          graphics.SmoothingMode = SmoothingMode.HighQuality;
          graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
          graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
          graphics.DrawImage(originalImage, 0, 0, newWidth, newHeight);
        }
        return (Image) image.Clone();
      }
    }

    public static void GetCryptoKeyPair(ref byte[] key, ref byte[] iv)
    {
      WindowsIdentity current = WindowsIdentity.GetCurrent();
      MD5CryptoServiceProvider cryptoServiceProvider = new MD5CryptoServiceProvider();
      key = cryptoServiceProvider.ComputeHash(Encoding.UTF8.GetBytes(current.User.Value));
      iv = cryptoServiceProvider.ComputeHash(Encoding.UTF8.GetBytes(current.Name));
    }

    public static string SerializeToXmlString(object obj, bool utf8encoding)
    {
      string xmlString;
      try
      {
        if (obj == null)
          xmlString = (string) null;
        else if (utf8encoding)
        {
          XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
          namespaces.Add("", "");
          Module1.Utf8StringWriter utf8StringWriter = new Module1.Utf8StringWriter();
          new XmlSerializer(obj.GetType(), "").Serialize((TextWriter) utf8StringWriter, RuntimeHelpers.GetObjectValue(obj), namespaces);
          xmlString = utf8StringWriter.ToString();
        }
        else
        {
          StringWriter stringWriter = new StringWriter();
          new XmlSerializer(obj.GetType()).Serialize((TextWriter) stringWriter, RuntimeHelpers.GetObjectValue(obj));
          xmlString = stringWriter.ToString();
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Exception exception = ex;
        Module1.Log(Module1.LogType.ERROR, (object) MethodBase.GetCurrentMethod(), exception.ToString());
        xmlString = (string) null;
        ProjectData.ClearProjectError();
      }
      return xmlString;
    }

    public static object DeSerializeFromXmlString(string obj, System.Type type)
    {
      object obj1;
      try
      {
        if (obj == null)
          obj1 = (object) null;
        else if (Operators.CompareString(obj, "", false) == 0)
        {
          obj1 = (object) null;
        }
        else
        {
          using (StringReader stringReader = new StringReader(obj))
            obj1 = new XmlSerializer(type).Deserialize((TextReader) stringReader);
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Exception exception = ex;
        Module1.Log(Module1.LogType.ERROR, (object) MethodBase.GetCurrentMethod(), exception.ToString());
        obj1 = (object) null;
        ProjectData.ClearProjectError();
      }
      return obj1;
    }

    public static int SerializeToXmlFile(string filename, object obj, bool utf8encoding)
    {
      int xmlFile;
      try
      {
        string xmlString = Module1.SerializeToXmlString(RuntimeHelpers.GetObjectValue(obj), utf8encoding);
        if (xmlString != null)
        {
          using (StreamWriter streamWriter = new StreamWriter(filename))
          {
            streamWriter.Write(xmlString);
            xmlFile = 0;
          }
        }
        else
          xmlFile = 1;
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Exception exception = ex;
        Module1.Log(Module1.LogType.ERROR, (object) MethodBase.GetCurrentMethod(), exception.ToString());
        xmlFile = -1;
        ProjectData.ClearProjectError();
      }
      return xmlFile;
    }

    public static int DeserializeFromXmlFile(string filename, ref object obj)
    {
      return obj == null ? 1 : Module1.DeserializeFromXmlFile(filename, obj.GetType(), ref obj);
    }

    public static int DeserializeFromXmlFile(string filename, System.Type type, ref object obj)
    {
      int num;
      try
      {
        if (System.IO.File.Exists(filename))
        {
          using (StreamReader streamReader = new StreamReader(filename))
          {
            if (!streamReader.EndOfStream)
            {
              obj = RuntimeHelpers.GetObjectValue(Module1.DeSerializeFromXmlString(streamReader.ReadToEnd(), type));
              num = obj == null ? 3 : 0;
            }
            else
              num = 2;
          }
        }
        else
          num = 1;
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Exception exception = ex;
        Module1.Log(Module1.LogType.ERROR, (object) MethodBase.GetCurrentMethod(), exception.ToString());
        num = -1;
        ProjectData.ClearProjectError();
      }
      return num;
    }

    public static int SerializeToFile(string filename, object obj)
    {
      int file;
      try
      {
        if (obj == null)
        {
          file = 1;
        }
        else
        {
          using (FileStream serializationStream = new FileStream(filename, FileMode.Create))
            new BinaryFormatter().Serialize((Stream) serializationStream, RuntimeHelpers.GetObjectValue(obj));
          file = 0;
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Exception exception = ex;
        Module1.Log(Module1.LogType.ERROR, (object) MethodBase.GetCurrentMethod(), exception.ToString());
        file = -1;
        ProjectData.ClearProjectError();
      }
      return file;
    }

    public static int DeserializeFromFile(string filename, ref object obj)
    {
      int num;
      try
      {
        if (System.IO.File.Exists(filename))
        {
          using (FileStream serializationStream = new FileStream(filename, FileMode.Open))
          {
            if (serializationStream.Length == 0L)
            {
              num = 2;
            }
            else
            {
              BinaryFormatter binaryFormatter = new BinaryFormatter();
              obj = RuntimeHelpers.GetObjectValue(binaryFormatter.Deserialize((Stream) serializationStream));
              num = 0;
            }
          }
        }
        else
          num = 1;
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Exception exception = ex;
        Module1.Log(Module1.LogType.ERROR, (object) MethodBase.GetCurrentMethod(), exception.ToString());
        num = -1;
        ProjectData.ClearProjectError();
      }
      return num;
    }

    public static int SerializeToFileEncrypted(string filename, object obj)
    {
      int fileEncrypted;
      try
      {
        if (obj == null)
        {
          fileEncrypted = 1;
        }
        else
        {
          using (Rijndael rijndael = Rijndael.Create())
          {
            byte[] key = (byte[]) null;
            byte[] iv = (byte[]) null;
            Module1.GetCryptoKeyPair(ref key, ref iv);
            ICryptoTransform encryptor = rijndael.CreateEncryptor(key, iv);
            using (FileStream fileStream = new FileStream(filename, FileMode.Create))
            {
              using (CryptoStream serializationStream = new CryptoStream((Stream) fileStream, encryptor, CryptoStreamMode.Write))
                new BinaryFormatter().Serialize((Stream) serializationStream, RuntimeHelpers.GetObjectValue(obj));
            }
          }
          fileEncrypted = 0;
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Exception exception = ex;
        Module1.Log(Module1.LogType.ERROR, (object) MethodBase.GetCurrentMethod(), exception.ToString());
        fileEncrypted = -1;
        ProjectData.ClearProjectError();
      }
      return fileEncrypted;
    }

    public static int DeserializeFromFileDecrypted(string filename, ref object obj)
    {
      int num;
      try
      {
        if (System.IO.File.Exists(filename))
        {
          using (Rijndael rijndael = Rijndael.Create())
          {
            using (FileStream fileStream = new FileStream(filename, FileMode.Open))
            {
              if (fileStream.Length == 0L)
              {
                num = 2;
              }
              else
              {
                byte[] key = (byte[]) null;
                byte[] iv = (byte[]) null;
                Module1.GetCryptoKeyPair(ref key, ref iv);
                ICryptoTransform decryptor = rijndael.CreateDecryptor(key, iv);
                using (CryptoStream serializationStream = new CryptoStream((Stream) fileStream, decryptor, CryptoStreamMode.Read))
                {
                  BinaryFormatter binaryFormatter = new BinaryFormatter();
                  obj = RuntimeHelpers.GetObjectValue(binaryFormatter.Deserialize((Stream) serializationStream));
                  num = 0;
                }
              }
            }
          }
        }
        else
          num = 1;
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Exception exception = ex;
        Module1.Log(Module1.LogType.ERROR, (object) MethodBase.GetCurrentMethod(), exception.ToString());
        num = -1;
        ProjectData.ClearProjectError();
      }
      return num;
    }

    public static int PeekDeserializedEncryptedFile(
      string filename,
      ref byte[] data,
      int offset,
      int count)
    {
      int num;
      try
      {
        if (System.IO.File.Exists(filename))
        {
          using (Rijndael rijndael = Rijndael.Create())
          {
            using (FileStream fileStream = new FileStream(filename, FileMode.Open))
            {
              if (fileStream.Length == 0L)
              {
                num = 2;
              }
              else
              {
                byte[] key = (byte[]) null;
                byte[] iv = (byte[]) null;
                Module1.GetCryptoKeyPair(ref key, ref iv);
                ICryptoTransform decryptor = rijndael.CreateDecryptor(key, iv);
                using (CryptoStream cryptoStream = new CryptoStream((Stream) fileStream, decryptor, CryptoStreamMode.Read))
                {
                  using (MemoryStream destination = new MemoryStream())
                  {
                    cryptoStream.CopyTo((Stream) destination);
                    destination.Seek(0L, SeekOrigin.Begin);
                    data = new byte[checked (count - 1 + 1)];
                    destination.Read(data, offset, count);
                    num = 0;
                  }
                }
              }
            }
          }
        }
        else
          num = 1;
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Exception exception = ex;
        Module1.Log(Module1.LogType.ERROR, (object) MethodBase.GetCurrentMethod(), exception.ToString());
        num = -1;
        ProjectData.ClearProjectError();
      }
      return num;
    }

    public static int GetNetworkTime(ref DateTime networkDateTime)
    {
      int networkTime;
      try
      {
        byte[] buffer = new byte[48];
        buffer[0] = (byte) 27;
        IPEndPoint remoteEP = new IPEndPoint(Dns.GetHostEntry("pool.ntp.org").AddressList[0], 123);
        using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp))
        {
          socket.ReceiveTimeout = 3000;
          socket.Connect((EndPoint) remoteEP);
          socket.Send(buffer);
          socket.Receive(buffer);
          socket.Close();
        }
        ulong uint32_1 = (ulong) BitConverter.ToUInt32(buffer, 40);
        ulong uint32_2 = (ulong) BitConverter.ToUInt32(buffer, 44);
        ulong num1 = (ulong) Module1.SwapEndianness(uint32_1);
        ulong num2 = (ulong) Module1.SwapEndianness(uint32_2);
        Decimal num3 = Decimal.Add(Decimal.Multiply(new Decimal(num1), 1000M), Decimal.Divide(Decimal.Multiply(new Decimal(num2), 1000M), 4294967296M));
        networkDateTime = new DateTime(1900, 1, 1).AddMilliseconds((double) Convert.ToInt64(num3));
        networkTime = Conversions.ToInteger(Interaction.IIf(networkDateTime.Year < 2018, (object) 1, (object) 0));
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Exception exception = ex;
        Module1.Log(Module1.LogType.ERROR, (object) MethodBase.GetCurrentMethod(), exception.Message);
        networkTime = -1;
        ProjectData.ClearProjectError();
      }
      return networkTime;
    }

    private static uint SwapEndianness(ulong x)
    {
      return checked ((uint) ((((long) x & (long) byte.MaxValue) << 24) + (((long) x & 65280L) << 8) + (((long) x & 16711680L) >> 8) + (((long) x & -16777216L) >> 24)));
    }

    public struct SYSTEMTIME
    {
      public short year;
      public short month;
      public short dayOfWeek;
      public short day;
      public short hour;
      public short minute;
      public short second;
      public short milliseconds;
    }

    public struct DEVMODE
    {
      private const int CCHDEVICENAME = 32;
      private const int CCHFORMNAME = 32;
      [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
      public string dmDeviceName;
      public short dmSpecVersion;
      public short dmDriverVersion;
      public short dmSize;
      public short dmDriverExtra;
      public int dmFields;
      public int dmPositionX;
      public int dmPositionY;
      public ScreenOrientation dmDisplayOrientation;
      public int dmDisplayFixedOutput;
      public short dmColor;
      public short dmDuplex;
      public short dmYResolution;
      public short dmTTOption;
      public short dmCollate;
      [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
      public string dmFormName;
      public short dmLogPixels;
      public int dmBitsPerPel;
      public int dmPelsWidth;
      public int dmPelsHeight;
      public int dmDisplayFlags;
      public int dmDisplayFrequency;
      public int dmICMMethod;
      public int dmICMIntent;
      public int dmMediaType;
      public int dmDitherType;
      public int dmReserved1;
      public int dmReserved2;
      public int dmPanningWidth;
      public int dmPanningHeight;
    }

    public enum LogType
    {
      DEBUG = 1,
      INFO = 2,
      WARNING = 3,
      ERROR = 4,
    }

    public enum NetConnectType
    {
      INTERNET_CONNECTION_ONLINE = 0,
      INTERNET_CONNECTION_MODEM = 1,
      INTERNET_CONNECTION_LAN = 2,
      INTERNET_CONNECTION_PROXY = 4,
      INTERNET_CONNECTION_MODEM_BUSY = 8,
      INTERNET_RAS_INSTALLED = 16, // 0x00000010
      INTERNET_CONNECTION_OFFLINE = 32, // 0x00000020
      INTERNET_CONNECTION_CONFIGURED = 64, // 0x00000040
    }

    public class Utf8StringWriter : StringWriter
    {
      public override Encoding Encoding => Encoding.UTF8;
    }
  }
}
