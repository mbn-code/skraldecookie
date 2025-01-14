// Decompiled with JetBrains decompiler
// Type: Microsoft.Web.WebView2.Core.CoreWebView2Environment
// Assembly: ExamCookie.WinClient, Version=1.4.1.4, Culture=neutral, PublicKeyToken=null
// MVID: E12BE1F8-B6E0-4BF5-B308-166F0E938C4B
// Assembly location: C:\Users\oskar\Downloads\ExamCookie1414.WinClient.exe

using Microsoft.Web.WebView2.Core.Raw;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

#nullable disable
namespace Microsoft.Web.WebView2.Core
{
  [ComVisible(true)]
  public class CoreWebView2Environment
  {
    private const char DirectorySeparatorChar = '\\';
    private const char AltDirectorySeparatorChar = '/';
    private const char VolumeSeparatorChar = ':';
    private static bool webView2LoaderLoaded;
    private static string loaderDllFolderPath;
    internal ICoreWebView2Environment _nativeICoreWebView2EnvironmentValue;
    internal ICoreWebView2Environment2 _nativeICoreWebView2Environment2Value;
    internal ICoreWebView2Environment3 _nativeICoreWebView2Environment3Value;
    internal ICoreWebView2Environment4 _nativeICoreWebView2Environment4Value;
    internal ICoreWebView2Environment5 _nativeICoreWebView2Environment5Value;
    internal ICoreWebView2Environment6 _nativeICoreWebView2Environment6Value;
    internal ICoreWebView2Environment7 _nativeICoreWebView2Environment7Value;
    internal ICoreWebView2Environment8 _nativeICoreWebView2Environment8Value;
    internal ICoreWebView2Environment9 _nativeICoreWebView2Environment9Value;
    internal ICoreWebView2Environment10 _nativeICoreWebView2Environment10Value;
    internal ICoreWebView2Environment11 _nativeICoreWebView2Environment11Value;
    internal ICoreWebView2Environment12 _nativeICoreWebView2Environment12Value;
    internal object _rawNative;
    private EventRegistrationToken _newBrowserVersionAvailableToken;
    private EventHandler<object> newBrowserVersionAvailable;
    private EventRegistrationToken _browserProcessExitedToken;
    private EventHandler<CoreWebView2BrowserProcessExitedEventArgs> browserProcessExited;
    private EventRegistrationToken _processInfosChangedToken;
    private EventHandler<object> processInfosChanged;

    [DllImport("WebView2Loader.dll")]
    internal static extern int CreateCoreWebView2EnvironmentWithOptions(
      [MarshalAs(UnmanagedType.LPWStr), In] string browserExecutableFolder,
      [MarshalAs(UnmanagedType.LPWStr), In] string userDataFolder,
      ICoreWebView2EnvironmentOptions options,
      ICoreWebView2CreateCoreWebView2EnvironmentCompletedHandler environment_created_handler);

    [DllImport("WebView2Loader.dll")]
    internal static extern int GetAvailableCoreWebView2BrowserVersionString(
      [MarshalAs(UnmanagedType.LPWStr), In] string browserExecutableFolder,
      [MarshalAs(UnmanagedType.LPWStr)] ref string versionInfo);

    [DllImport("WebView2Loader.dll")]
    internal static extern int CompareBrowserVersions(
      [MarshalAs(UnmanagedType.LPWStr), In] string version1,
      [MarshalAs(UnmanagedType.LPWStr), In] string version2,
      ref int result);

    public static async Task<CoreWebView2Environment> CreateAsync(
      string browserExecutableFolder = null,
      string userDataFolder = null,
      CoreWebView2EnvironmentOptions options = null)
    {
      CoreWebView2Environment.LoadWebView2LoaderDll();
      CoreWebView2CreateCoreWebView2EnvironmentCompletedHandler handler = new CoreWebView2CreateCoreWebView2EnvironmentCompletedHandler();
      int environmentWithOptions = CoreWebView2Environment.CreateCoreWebView2EnvironmentWithOptions(browserExecutableFolder, userDataFolder, (options ?? new CoreWebView2EnvironmentOptions())._nativeICoreWebView2EnvironmentOptions, (ICoreWebView2CreateCoreWebView2EnvironmentCompletedHandler) handler);
      if (environmentWithOptions == -2147024894)
        throw new WebView2RuntimeNotFoundException(Marshal.GetExceptionForHR(environmentWithOptions));
      Marshal.ThrowExceptionForHR(environmentWithOptions);
      CoreWebView2Environment view2Environment = await handler;
      Marshal.ThrowExceptionForHR(handler.errCode);
      CoreWebView2Environment createdEnvironment = handler.createdEnvironment;
      handler = (CoreWebView2CreateCoreWebView2EnvironmentCompletedHandler) null;
      return createdEnvironment;
    }

    public static string GetAvailableBrowserVersionString(string browserExecutableFolder = null)
    {
      CoreWebView2Environment.LoadWebView2LoaderDll();
      string versionInfo = (string) null;
      int browserVersionString = CoreWebView2Environment.GetAvailableCoreWebView2BrowserVersionString(browserExecutableFolder, ref versionInfo);
      if (browserVersionString == -2147024894)
        throw new WebView2RuntimeNotFoundException(Marshal.GetExceptionForHR(browserVersionString));
      Marshal.ThrowExceptionForHR(browserVersionString);
      return versionInfo;
    }

    public static int CompareBrowserVersions(string version1, string version2)
    {
      CoreWebView2Environment.LoadWebView2LoaderDll();
      int result = 0;
      Marshal.ThrowExceptionForHR(CoreWebView2Environment.CompareBrowserVersions(version1, version2, ref result));
      return result;
    }

    public CoreWebView2WebResourceRequest CreateWebResourceRequest(
      string uri,
      string Method,
      Stream postData,
      string Headers)
    {
      // ISSUE: reference to a compiler-generated method
      return new CoreWebView2WebResourceRequest((object) this._nativeICoreWebView2Environment2.CreateWebResourceRequest(uri, Method, postData == null ? (IStream) null : (IStream) new ManagedIStream(postData), Headers));
    }

    public CoreWebView2ControllerOptions CreateCoreWebView2ControllerOptions()
    {
      try
      {
        // ISSUE: reference to a compiler-generated method
        return new CoreWebView2ControllerOptions((object) this._nativeICoreWebView2Environment10.CreateCoreWebView2ControllerOptions());
      }
      catch (InvalidCastException ex)
      {
        if (ex.HResult == -2147467262)
          throw new InvalidOperationException("CoreWebView2Environment members can only be accessed from the UI thread.", (Exception) ex);
        throw ex;
      }
      catch (COMException ex)
      {
        if (ex.HResult == -2147019873)
          throw new InvalidOperationException("CreateCoreWebView2ControllerOptions members cannot be accessed after the WebView2 control is disposed.", (Exception) ex);
        throw ex;
      }
    }

    public async Task<CoreWebView2Controller> CreateCoreWebView2ControllerAsync(
      IntPtr ParentWindow,
      CoreWebView2ControllerOptions options)
    {
      CoreWebView2CreateCoreWebView2ControllerCompletedHandler handler;
      try
      {
        handler = new CoreWebView2CreateCoreWebView2ControllerCompletedHandler();
        // ISSUE: reference to a compiler-generated method
        this._nativeICoreWebView2Environment10.CreateCoreWebView2ControllerWithOptions(ParentWindow, options._nativeICoreWebView2ControllerOptions, (ICoreWebView2CreateCoreWebView2ControllerCompletedHandler) handler);
      }
      catch (InvalidCastException ex)
      {
        if (ex.HResult == -2147467262)
          throw new InvalidOperationException("CoreWebView2Environment members can only be accessed from the UI thread.", (Exception) ex);
        throw ex;
      }
      catch (COMException ex)
      {
        if (ex.HResult == -2147019873)
          throw new InvalidOperationException("CreateCoreWebView2ControllerAsync failed to create the controller due to incompatible options.", (Exception) ex);
        throw ex;
      }
      CoreWebView2Controller webView2Controller = await handler;
      Marshal.ThrowExceptionForHR(handler.errCode);
      CoreWebView2Controller createdController = handler.createdController;
      handler = (CoreWebView2CreateCoreWebView2ControllerCompletedHandler) null;
      return createdController;
    }

    public async Task<CoreWebView2CompositionController> CreateCoreWebView2CompositionControllerAsync(
      IntPtr ParentWindow,
      CoreWebView2ControllerOptions options)
    {
      CoreWebView2CreateCoreWebView2CompositionControllerCompletedHandler handler;
      try
      {
        handler = new CoreWebView2CreateCoreWebView2CompositionControllerCompletedHandler();
        // ISSUE: reference to a compiler-generated method
        this._nativeICoreWebView2Environment10.CreateCoreWebView2CompositionControllerWithOptions(ParentWindow, options._nativeICoreWebView2ControllerOptions, (ICoreWebView2CreateCoreWebView2CompositionControllerCompletedHandler) handler);
      }
      catch (InvalidCastException ex)
      {
        if (ex.HResult == -2147467262)
          throw new InvalidOperationException("CoreWebView2Environment members can only be accessed from the UI thread.", (Exception) ex);
        throw ex;
      }
      catch (COMException ex)
      {
        if (ex.HResult == -2147019873)
          throw new InvalidOperationException("CreateCoreWebView2CompositionControllerAsync failed to create the composition controller due to incompatible options.", (Exception) ex);
        throw ex;
      }
      CoreWebView2CompositionController compositionController = await handler;
      Marshal.ThrowExceptionForHR(handler.errCode);
      CoreWebView2CompositionController webView = handler.webView;
      handler = (CoreWebView2CreateCoreWebView2CompositionControllerCompletedHandler) null;
      return webView;
    }

    private static CoreWebView2Environment.ProcessorArchitecture GetArchitecture()
    {
      CoreWebView2Environment.SYSTEM_INFO lpSystemInfo;
      CoreWebView2Environment.GetSystemInfo(out lpSystemInfo);
      return (CoreWebView2Environment.ProcessorArchitecture) lpSystemInfo.wProcessorArchitecture;
    }

    [DllImport("kernel32.dll", SetLastError = true)]
    private static extern void GetSystemInfo(
      out CoreWebView2Environment.SYSTEM_INFO lpSystemInfo);

    [DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
    internal static extern IntPtr LoadLibrary(string dllToLoad);

    private static bool IsDirectorySeparator(char c) => c == '\\' || c == '/';

    internal static bool IsValidDriveChar(char value)
    {
      if (value >= 'A' && value <= 'Z')
        return true;
      return value >= 'a' && value <= 'z';
    }

    private static bool IsDotNetFramework()
    {
      return typeof (object).Assembly.GetCustomAttribute<AssemblyProductAttribute>().Product.Contains(".NET Framework");
    }

    private static string GetAssemblyLocationDirectory()
    {
      try
      {
        return Path.GetDirectoryName(typeof (CoreWebView2Environment).Assembly.Location);
      }
      catch
      {
        return "";
      }
    }

    private static string GetAssemblyCodeBaseDirectory()
    {
      try
      {
        string codeBaseDirectory = typeof (CoreWebView2Environment).Assembly.CodeBase;
        if (codeBaseDirectory.StartsWith("file:///"))
          codeBaseDirectory = Path.GetDirectoryName(codeBaseDirectory.Substring("file:///".Length));
        return codeBaseDirectory;
      }
      catch
      {
        return "";
      }
    }

    [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
    private static extern IntPtr GetModuleHandle(string lpModuleName);

    [DllImport("kernel32.dll", SetLastError = true)]
    private static extern uint GetModuleFileName(
      [In] IntPtr hModule,
      [Out] StringBuilder lpFilename,
      [MarshalAs(UnmanagedType.U4), In] int nSize);

    private static string GetCurrentDllRuningDirectory()
    {
      try
      {
        IntPtr moduleHandle = CoreWebView2Environment.GetModuleHandle("Microsoft.Web.WebView2.Core.dll");
        StringBuilder stringBuilder = new StringBuilder(256);
        StringBuilder lpFilename = stringBuilder;
        int capacity = stringBuilder.Capacity;
        return CoreWebView2Environment.GetModuleFileName(moduleHandle, lpFilename, capacity) == 0U ? "" : Path.GetDirectoryName(stringBuilder.ToString());
      }
      catch
      {
        return "";
      }
    }

    private static string GetProcessArchSubFolder()
    {
      string str = "runtimes\\win-";
      string path1;
      switch (CoreWebView2Environment.GetArchitecture())
      {
        case CoreWebView2Environment.ProcessorArchitecture.x86:
          path1 = str + "x86";
          break;
        case CoreWebView2Environment.ProcessorArchitecture.x64:
          path1 = str + "x64";
          break;
        case CoreWebView2Environment.ProcessorArchitecture.ARM64:
          path1 = str + "arm64";
          break;
        default:
          throw new NotSupportedException("Unknown Processor Architecture of WebView2Loader.dll is not supported");
      }
      return Path.Combine(path1, "native");
    }

    public static void SetLoaderDllFolderPath(string folderPath)
    {
      if (CoreWebView2Environment.webView2LoaderLoaded)
        throw new InvalidOperationException("The function should be called before before any other API is called in `CoreWebView2Environment` class.");
      CoreWebView2Environment.loaderDllFolderPath = folderPath;
    }

    private static string TrimFormat(string path)
    {
      char[] chArray = new char[2]{ '/', '\\' };
      path = path.Trim(' ');
      path = path.TrimEnd(chArray);
      return path;
    }

    private static void LoadWebView2LoaderDll()
    {
      if (CoreWebView2Environment.webView2LoaderLoaded)
        return;
      string path = "";
      if (!string.IsNullOrEmpty(CoreWebView2Environment.loaderDllFolderPath))
        path = CoreWebView2Environment.loaderDllFolderPath;
      else if (CoreWebView2Environment.IsDotNetFramework())
        path = CoreWebView2Environment.GetProcessArchSubFolder();
      if (!string.IsNullOrEmpty(path))
      {
        string str = CoreWebView2Environment.TrimFormat(path);
        ArrayList arrayList = new ArrayList();
        if (Path.IsPathRooted(str))
        {
          arrayList.Add((object) str);
        }
        else
        {
          arrayList.Add((object) Path.Combine(CoreWebView2Environment.GetAssemblyLocationDirectory(), str));
          arrayList.Add((object) Path.Combine(CoreWebView2Environment.GetAssemblyCodeBaseDirectory(), str));
          arrayList.Add((object) Path.Combine(CoreWebView2Environment.GetCurrentDllRuningDirectory(), str));
        }
        arrayList.Add((object) "");
        string dllToLoad = "";
        foreach (string path1 in arrayList)
        {
          dllToLoad = Path.Combine(path1, "WebView2Loader.dll");
          if (CoreWebView2Environment.LoadLibrary(dllToLoad) != IntPtr.Zero)
          {
            CoreWebView2Environment.webView2LoaderLoaded = true;
            break;
          }
        }
        if (!CoreWebView2Environment.webView2LoaderLoaded && !string.IsNullOrEmpty(CoreWebView2Environment.loaderDllFolderPath))
        {
          int forLastWin32Error = Marshal.GetHRForLastWin32Error();
          throw new DllNotFoundException(string.Format("Unable to load DLL '{0}' or one of its dependencies: {1} (0x{2:X})", (object) dllToLoad, (object) new Win32Exception(forLastWin32Error).Message, (object) forLastWin32Error));
        }
      }
      CoreWebView2Environment.webView2LoaderLoaded = true;
    }

    internal ICoreWebView2Environment _nativeICoreWebView2Environment
    {
      get
      {
        if (this._nativeICoreWebView2EnvironmentValue == null)
        {
          try
          {
            this._nativeICoreWebView2EnvironmentValue = (ICoreWebView2Environment) this._rawNative;
          }
          catch (Exception ex)
          {
            throw new NotImplementedException("Unable to cast to Microsoft.Web.WebView2.Core.Raw.ICoreWebView2Environment.\nThis may happen if you are using an interface not supported by the version of the WebView2 Runtime you are using.\nFor instance, if you are using an experimental interface from an older SDK that has been modified or removed in a newer runtime.\nOr, if you are using a public interface from a newer SDK that wasn't implemented in an older runtime.\nFor more information about WebView2 versioning please visit the following: https://learn.microsoft.com/microsoft-edge/webview2/concepts/versioning", ex);
          }
        }
        return this._nativeICoreWebView2EnvironmentValue;
      }
      set => this._nativeICoreWebView2EnvironmentValue = value;
    }

    internal ICoreWebView2Environment2 _nativeICoreWebView2Environment2
    {
      get
      {
        if (this._nativeICoreWebView2Environment2Value == null)
        {
          try
          {
            this._nativeICoreWebView2Environment2Value = (ICoreWebView2Environment2) this._rawNative;
          }
          catch (Exception ex)
          {
            throw new NotImplementedException("Unable to cast to Microsoft.Web.WebView2.Core.Raw.ICoreWebView2Environment2.\nThis may happen if you are using an interface not supported by the version of the WebView2 Runtime you are using.\nFor instance, if you are using an experimental interface from an older SDK that has been modified or removed in a newer runtime.\nOr, if you are using a public interface from a newer SDK that wasn't implemented in an older runtime.\nFor more information about WebView2 versioning please visit the following: https://learn.microsoft.com/microsoft-edge/webview2/concepts/versioning", ex);
          }
        }
        return this._nativeICoreWebView2Environment2Value;
      }
      set => this._nativeICoreWebView2Environment2Value = value;
    }

    internal ICoreWebView2Environment3 _nativeICoreWebView2Environment3
    {
      get
      {
        if (this._nativeICoreWebView2Environment3Value == null)
        {
          try
          {
            this._nativeICoreWebView2Environment3Value = (ICoreWebView2Environment3) this._rawNative;
          }
          catch (Exception ex)
          {
            throw new NotImplementedException("Unable to cast to Microsoft.Web.WebView2.Core.Raw.ICoreWebView2Environment3.\nThis may happen if you are using an interface not supported by the version of the WebView2 Runtime you are using.\nFor instance, if you are using an experimental interface from an older SDK that has been modified or removed in a newer runtime.\nOr, if you are using a public interface from a newer SDK that wasn't implemented in an older runtime.\nFor more information about WebView2 versioning please visit the following: https://learn.microsoft.com/microsoft-edge/webview2/concepts/versioning", ex);
          }
        }
        return this._nativeICoreWebView2Environment3Value;
      }
      set => this._nativeICoreWebView2Environment3Value = value;
    }

    internal ICoreWebView2Environment4 _nativeICoreWebView2Environment4
    {
      get
      {
        if (this._nativeICoreWebView2Environment4Value == null)
        {
          try
          {
            this._nativeICoreWebView2Environment4Value = (ICoreWebView2Environment4) this._rawNative;
          }
          catch (Exception ex)
          {
            throw new NotImplementedException("Unable to cast to Microsoft.Web.WebView2.Core.Raw.ICoreWebView2Environment4.\nThis may happen if you are using an interface not supported by the version of the WebView2 Runtime you are using.\nFor instance, if you are using an experimental interface from an older SDK that has been modified or removed in a newer runtime.\nOr, if you are using a public interface from a newer SDK that wasn't implemented in an older runtime.\nFor more information about WebView2 versioning please visit the following: https://learn.microsoft.com/microsoft-edge/webview2/concepts/versioning", ex);
          }
        }
        return this._nativeICoreWebView2Environment4Value;
      }
      set => this._nativeICoreWebView2Environment4Value = value;
    }

    internal ICoreWebView2Environment5 _nativeICoreWebView2Environment5
    {
      get
      {
        if (this._nativeICoreWebView2Environment5Value == null)
        {
          try
          {
            this._nativeICoreWebView2Environment5Value = (ICoreWebView2Environment5) this._rawNative;
          }
          catch (Exception ex)
          {
            throw new NotImplementedException("Unable to cast to Microsoft.Web.WebView2.Core.Raw.ICoreWebView2Environment5.\nThis may happen if you are using an interface not supported by the version of the WebView2 Runtime you are using.\nFor instance, if you are using an experimental interface from an older SDK that has been modified or removed in a newer runtime.\nOr, if you are using a public interface from a newer SDK that wasn't implemented in an older runtime.\nFor more information about WebView2 versioning please visit the following: https://learn.microsoft.com/microsoft-edge/webview2/concepts/versioning", ex);
          }
        }
        return this._nativeICoreWebView2Environment5Value;
      }
      set => this._nativeICoreWebView2Environment5Value = value;
    }

    internal ICoreWebView2Environment6 _nativeICoreWebView2Environment6
    {
      get
      {
        if (this._nativeICoreWebView2Environment6Value == null)
        {
          try
          {
            this._nativeICoreWebView2Environment6Value = (ICoreWebView2Environment6) this._rawNative;
          }
          catch (Exception ex)
          {
            throw new NotImplementedException("Unable to cast to Microsoft.Web.WebView2.Core.Raw.ICoreWebView2Environment6.\nThis may happen if you are using an interface not supported by the version of the WebView2 Runtime you are using.\nFor instance, if you are using an experimental interface from an older SDK that has been modified or removed in a newer runtime.\nOr, if you are using a public interface from a newer SDK that wasn't implemented in an older runtime.\nFor more information about WebView2 versioning please visit the following: https://learn.microsoft.com/microsoft-edge/webview2/concepts/versioning", ex);
          }
        }
        return this._nativeICoreWebView2Environment6Value;
      }
      set => this._nativeICoreWebView2Environment6Value = value;
    }

    internal ICoreWebView2Environment7 _nativeICoreWebView2Environment7
    {
      get
      {
        if (this._nativeICoreWebView2Environment7Value == null)
        {
          try
          {
            this._nativeICoreWebView2Environment7Value = (ICoreWebView2Environment7) this._rawNative;
          }
          catch (Exception ex)
          {
            throw new NotImplementedException("Unable to cast to Microsoft.Web.WebView2.Core.Raw.ICoreWebView2Environment7.\nThis may happen if you are using an interface not supported by the version of the WebView2 Runtime you are using.\nFor instance, if you are using an experimental interface from an older SDK that has been modified or removed in a newer runtime.\nOr, if you are using a public interface from a newer SDK that wasn't implemented in an older runtime.\nFor more information about WebView2 versioning please visit the following: https://learn.microsoft.com/microsoft-edge/webview2/concepts/versioning", ex);
          }
        }
        return this._nativeICoreWebView2Environment7Value;
      }
      set => this._nativeICoreWebView2Environment7Value = value;
    }

    internal ICoreWebView2Environment8 _nativeICoreWebView2Environment8
    {
      get
      {
        if (this._nativeICoreWebView2Environment8Value == null)
        {
          try
          {
            this._nativeICoreWebView2Environment8Value = (ICoreWebView2Environment8) this._rawNative;
          }
          catch (Exception ex)
          {
            throw new NotImplementedException("Unable to cast to Microsoft.Web.WebView2.Core.Raw.ICoreWebView2Environment8.\nThis may happen if you are using an interface not supported by the version of the WebView2 Runtime you are using.\nFor instance, if you are using an experimental interface from an older SDK that has been modified or removed in a newer runtime.\nOr, if you are using a public interface from a newer SDK that wasn't implemented in an older runtime.\nFor more information about WebView2 versioning please visit the following: https://learn.microsoft.com/microsoft-edge/webview2/concepts/versioning", ex);
          }
        }
        return this._nativeICoreWebView2Environment8Value;
      }
      set => this._nativeICoreWebView2Environment8Value = value;
    }

    internal ICoreWebView2Environment9 _nativeICoreWebView2Environment9
    {
      get
      {
        if (this._nativeICoreWebView2Environment9Value == null)
        {
          try
          {
            this._nativeICoreWebView2Environment9Value = (ICoreWebView2Environment9) this._rawNative;
          }
          catch (Exception ex)
          {
            throw new NotImplementedException("Unable to cast to Microsoft.Web.WebView2.Core.Raw.ICoreWebView2Environment9.\nThis may happen if you are using an interface not supported by the version of the WebView2 Runtime you are using.\nFor instance, if you are using an experimental interface from an older SDK that has been modified or removed in a newer runtime.\nOr, if you are using a public interface from a newer SDK that wasn't implemented in an older runtime.\nFor more information about WebView2 versioning please visit the following: https://learn.microsoft.com/microsoft-edge/webview2/concepts/versioning", ex);
          }
        }
        return this._nativeICoreWebView2Environment9Value;
      }
      set => this._nativeICoreWebView2Environment9Value = value;
    }

    internal ICoreWebView2Environment10 _nativeICoreWebView2Environment10
    {
      get
      {
        if (this._nativeICoreWebView2Environment10Value == null)
        {
          try
          {
            this._nativeICoreWebView2Environment10Value = (ICoreWebView2Environment10) this._rawNative;
          }
          catch (Exception ex)
          {
            throw new NotImplementedException("Unable to cast to Microsoft.Web.WebView2.Core.Raw.ICoreWebView2Environment10.\nThis may happen if you are using an interface not supported by the version of the WebView2 Runtime you are using.\nFor instance, if you are using an experimental interface from an older SDK that has been modified or removed in a newer runtime.\nOr, if you are using a public interface from a newer SDK that wasn't implemented in an older runtime.\nFor more information about WebView2 versioning please visit the following: https://learn.microsoft.com/microsoft-edge/webview2/concepts/versioning", ex);
          }
        }
        return this._nativeICoreWebView2Environment10Value;
      }
      set => this._nativeICoreWebView2Environment10Value = value;
    }

    internal ICoreWebView2Environment11 _nativeICoreWebView2Environment11
    {
      get
      {
        if (this._nativeICoreWebView2Environment11Value == null)
        {
          try
          {
            this._nativeICoreWebView2Environment11Value = (ICoreWebView2Environment11) this._rawNative;
          }
          catch (Exception ex)
          {
            throw new NotImplementedException("Unable to cast to Microsoft.Web.WebView2.Core.Raw.ICoreWebView2Environment11.\nThis may happen if you are using an interface not supported by the version of the WebView2 Runtime you are using.\nFor instance, if you are using an experimental interface from an older SDK that has been modified or removed in a newer runtime.\nOr, if you are using a public interface from a newer SDK that wasn't implemented in an older runtime.\nFor more information about WebView2 versioning please visit the following: https://learn.microsoft.com/microsoft-edge/webview2/concepts/versioning", ex);
          }
        }
        return this._nativeICoreWebView2Environment11Value;
      }
      set => this._nativeICoreWebView2Environment11Value = value;
    }

    internal ICoreWebView2Environment12 _nativeICoreWebView2Environment12
    {
      get
      {
        if (this._nativeICoreWebView2Environment12Value == null)
        {
          try
          {
            this._nativeICoreWebView2Environment12Value = (ICoreWebView2Environment12) this._rawNative;
          }
          catch (Exception ex)
          {
            throw new NotImplementedException("Unable to cast to Microsoft.Web.WebView2.Core.Raw.ICoreWebView2Environment12.\nThis may happen if you are using an interface not supported by the version of the WebView2 Runtime you are using.\nFor instance, if you are using an experimental interface from an older SDK that has been modified or removed in a newer runtime.\nOr, if you are using a public interface from a newer SDK that wasn't implemented in an older runtime.\nFor more information about WebView2 versioning please visit the following: https://learn.microsoft.com/microsoft-edge/webview2/concepts/versioning", ex);
          }
        }
        return this._nativeICoreWebView2Environment12Value;
      }
      set => this._nativeICoreWebView2Environment12Value = value;
    }

    internal CoreWebView2Environment(object rawCoreWebView2Environment)
    {
      this._rawNative = rawCoreWebView2Environment;
    }

    public string BrowserVersionString
    {
      get
      {
        try
        {
          return this._nativeICoreWebView2Environment.BrowserVersionString;
        }
        catch (InvalidCastException ex)
        {
          if (ex.HResult == -2147467262)
            throw new InvalidOperationException("CoreWebView2 members can only be accessed from the UI thread.", (Exception) ex);
          throw ex;
        }
        catch (COMException ex)
        {
          if (ex.HResult == -2147019873)
            throw new InvalidOperationException("CoreWebView2 members cannot be accessed after the WebView2 control is disposed.", (Exception) ex);
          throw ex;
        }
      }
    }

    public event EventHandler<object> NewBrowserVersionAvailable
    {
      add
      {
        if (this.newBrowserVersionAvailable == null)
        {
          try
          {
            this._nativeICoreWebView2Environment.add_NewBrowserVersionAvailable((ICoreWebView2NewBrowserVersionAvailableEventHandler) new CoreWebView2NewBrowserVersionAvailableEventHandler(new CoreWebView2NewBrowserVersionAvailableEventHandler.CallbackType(this.OnNewBrowserVersionAvailable)), out this._newBrowserVersionAvailableToken);
          }
          catch (InvalidCastException ex)
          {
            if (ex.HResult == -2147467262)
              throw new InvalidOperationException("CoreWebView2 members can only be accessed from the UI thread.", (Exception) ex);
            throw ex;
          }
          catch (COMException ex)
          {
            if (ex.HResult == -2147019873)
              throw new InvalidOperationException("CoreWebView2 members cannot be accessed after the WebView2 control is disposed.", (Exception) ex);
            throw ex;
          }
        }
        this.newBrowserVersionAvailable += value;
      }
      remove
      {
        this.newBrowserVersionAvailable -= value;
        if (this.newBrowserVersionAvailable != null)
          return;
        try
        {
          this._nativeICoreWebView2Environment.remove_NewBrowserVersionAvailable(this._newBrowserVersionAvailableToken);
        }
        catch (InvalidCastException ex)
        {
          if (ex.HResult == -2147467262)
            throw new InvalidOperationException("CoreWebView2 members can only be accessed from the UI thread.", (Exception) ex);
          throw ex;
        }
        catch (COMException ex)
        {
          if (ex.HResult == -2147019873)
            throw new InvalidOperationException("CoreWebView2 members cannot be accessed after the WebView2 control is disposed.", (Exception) ex);
          throw ex;
        }
      }
    }

    internal void OnNewBrowserVersionAvailable(object args)
    {
      EventHandler<object> versionAvailable = this.newBrowserVersionAvailable;
      if (versionAvailable == null)
        return;
      versionAvailable((object) this, args);
    }

    public async Task<CoreWebView2Controller> CreateCoreWebView2ControllerAsync(IntPtr ParentWindow)
    {
      CoreWebView2CreateCoreWebView2ControllerCompletedHandler handler;
      try
      {
        handler = new CoreWebView2CreateCoreWebView2ControllerCompletedHandler();
        // ISSUE: reference to a compiler-generated method
        this._nativeICoreWebView2Environment.CreateCoreWebView2Controller(ParentWindow, (ICoreWebView2CreateCoreWebView2ControllerCompletedHandler) handler);
      }
      catch (InvalidCastException ex)
      {
        if (ex.HResult == -2147467262)
          throw new InvalidOperationException("CoreWebView2 members can only be accessed from the UI thread.", (Exception) ex);
        throw ex;
      }
      catch (COMException ex)
      {
        if (ex.HResult == -2147019873)
          throw new InvalidOperationException("CoreWebView2 members cannot be accessed after the WebView2 control is disposed.", (Exception) ex);
        throw ex;
      }
      CoreWebView2Controller webView2Controller = await handler;
      Marshal.ThrowExceptionForHR(handler.errCode);
      CoreWebView2Controller createdController = handler.createdController;
      handler = (CoreWebView2CreateCoreWebView2ControllerCompletedHandler) null;
      return createdController;
    }

    public CoreWebView2WebResourceResponse CreateWebResourceResponse(
      Stream Content,
      int StatusCode,
      string ReasonPhrase,
      string Headers)
    {
      try
      {
        // ISSUE: reference to a compiler-generated method
        return new CoreWebView2WebResourceResponse((object) this._nativeICoreWebView2Environment.CreateWebResourceResponse(Content == null ? (IStream) null : (IStream) new ManagedIStream(Content), StatusCode, ReasonPhrase, Headers));
      }
      catch (InvalidCastException ex)
      {
        if (ex.HResult == -2147467262)
          throw new InvalidOperationException("CoreWebView2 members can only be accessed from the UI thread.", (Exception) ex);
        throw ex;
      }
      catch (COMException ex)
      {
        if (ex.HResult == -2147019873)
          throw new InvalidOperationException("CoreWebView2 members cannot be accessed after the WebView2 control is disposed.", (Exception) ex);
        throw ex;
      }
    }

    public async Task<CoreWebView2CompositionController> CreateCoreWebView2CompositionControllerAsync(
      IntPtr ParentWindow)
    {
      CoreWebView2CreateCoreWebView2CompositionControllerCompletedHandler handler;
      try
      {
        handler = new CoreWebView2CreateCoreWebView2CompositionControllerCompletedHandler();
        // ISSUE: reference to a compiler-generated method
        this._nativeICoreWebView2Environment3.CreateCoreWebView2CompositionController(ParentWindow, (ICoreWebView2CreateCoreWebView2CompositionControllerCompletedHandler) handler);
      }
      catch (InvalidCastException ex)
      {
        if (ex.HResult == -2147467262)
          throw new InvalidOperationException("CoreWebView2 members can only be accessed from the UI thread.", (Exception) ex);
        throw ex;
      }
      catch (COMException ex)
      {
        if (ex.HResult == -2147019873)
          throw new InvalidOperationException("CoreWebView2 members cannot be accessed after the WebView2 control is disposed.", (Exception) ex);
        throw ex;
      }
      CoreWebView2CompositionController compositionController = await handler;
      Marshal.ThrowExceptionForHR(handler.errCode);
      CoreWebView2CompositionController webView = handler.webView;
      handler = (CoreWebView2CreateCoreWebView2CompositionControllerCompletedHandler) null;
      return webView;
    }

    public CoreWebView2PointerInfo CreateCoreWebView2PointerInfo()
    {
      try
      {
        // ISSUE: reference to a compiler-generated method
        return new CoreWebView2PointerInfo((object) this._nativeICoreWebView2Environment3.CreateCoreWebView2PointerInfo());
      }
      catch (InvalidCastException ex)
      {
        if (ex.HResult == -2147467262)
          throw new InvalidOperationException("CoreWebView2 members can only be accessed from the UI thread.", (Exception) ex);
        throw ex;
      }
      catch (COMException ex)
      {
        if (ex.HResult == -2147019873)
          throw new InvalidOperationException("CoreWebView2 members cannot be accessed after the WebView2 control is disposed.", (Exception) ex);
        throw ex;
      }
    }

    public event EventHandler<CoreWebView2BrowserProcessExitedEventArgs> BrowserProcessExited
    {
      add
      {
        if (this.browserProcessExited == null)
        {
          try
          {
            this._nativeICoreWebView2Environment5.add_BrowserProcessExited((ICoreWebView2BrowserProcessExitedEventHandler) new CoreWebView2BrowserProcessExitedEventHandler(new CoreWebView2BrowserProcessExitedEventHandler.CallbackType(this.OnBrowserProcessExited)), out this._browserProcessExitedToken);
          }
          catch (InvalidCastException ex)
          {
            if (ex.HResult == -2147467262)
              throw new InvalidOperationException("CoreWebView2 members can only be accessed from the UI thread.", (Exception) ex);
            throw ex;
          }
          catch (COMException ex)
          {
            if (ex.HResult == -2147019873)
              throw new InvalidOperationException("CoreWebView2 members cannot be accessed after the WebView2 control is disposed.", (Exception) ex);
            throw ex;
          }
        }
        this.browserProcessExited += value;
      }
      remove
      {
        this.browserProcessExited -= value;
        if (this.browserProcessExited != null)
          return;
        try
        {
          this._nativeICoreWebView2Environment5.remove_BrowserProcessExited(this._browserProcessExitedToken);
        }
        catch (InvalidCastException ex)
        {
          if (ex.HResult == -2147467262)
            throw new InvalidOperationException("CoreWebView2 members can only be accessed from the UI thread.", (Exception) ex);
          throw ex;
        }
        catch (COMException ex)
        {
          if (ex.HResult == -2147019873)
            throw new InvalidOperationException("CoreWebView2 members cannot be accessed after the WebView2 control is disposed.", (Exception) ex);
          throw ex;
        }
      }
    }

    internal void OnBrowserProcessExited(CoreWebView2BrowserProcessExitedEventArgs args)
    {
      EventHandler<CoreWebView2BrowserProcessExitedEventArgs> browserProcessExited = this.browserProcessExited;
      if (browserProcessExited == null)
        return;
      browserProcessExited((object) this, args);
    }

    public CoreWebView2PrintSettings CreatePrintSettings()
    {
      try
      {
        // ISSUE: reference to a compiler-generated method
        return new CoreWebView2PrintSettings((object) this._nativeICoreWebView2Environment6.CreatePrintSettings());
      }
      catch (InvalidCastException ex)
      {
        if (ex.HResult == -2147467262)
          throw new InvalidOperationException("CoreWebView2 members can only be accessed from the UI thread.", (Exception) ex);
        throw ex;
      }
      catch (COMException ex)
      {
        if (ex.HResult == -2147019873)
          throw new InvalidOperationException("CoreWebView2 members cannot be accessed after the WebView2 control is disposed.", (Exception) ex);
        throw ex;
      }
    }

    public string UserDataFolder
    {
      get
      {
        try
        {
          return this._nativeICoreWebView2Environment7.UserDataFolder;
        }
        catch (InvalidCastException ex)
        {
          if (ex.HResult == -2147467262)
            throw new InvalidOperationException("CoreWebView2 members can only be accessed from the UI thread.", (Exception) ex);
          throw ex;
        }
        catch (COMException ex)
        {
          if (ex.HResult == -2147019873)
            throw new InvalidOperationException("CoreWebView2 members cannot be accessed after the WebView2 control is disposed.", (Exception) ex);
          throw ex;
        }
      }
    }

    public event EventHandler<object> ProcessInfosChanged
    {
      add
      {
        if (this.processInfosChanged == null)
        {
          try
          {
            this._nativeICoreWebView2Environment8.add_ProcessInfosChanged((ICoreWebView2ProcessInfosChangedEventHandler) new CoreWebView2ProcessInfosChangedEventHandler(new CoreWebView2ProcessInfosChangedEventHandler.CallbackType(this.OnProcessInfosChanged)), out this._processInfosChangedToken);
          }
          catch (InvalidCastException ex)
          {
            if (ex.HResult == -2147467262)
              throw new InvalidOperationException("CoreWebView2 members can only be accessed from the UI thread.", (Exception) ex);
            throw ex;
          }
          catch (COMException ex)
          {
            if (ex.HResult == -2147019873)
              throw new InvalidOperationException("CoreWebView2 members cannot be accessed after the WebView2 control is disposed.", (Exception) ex);
            throw ex;
          }
        }
        this.processInfosChanged += value;
      }
      remove
      {
        this.processInfosChanged -= value;
        if (this.processInfosChanged != null)
          return;
        try
        {
          this._nativeICoreWebView2Environment8.remove_ProcessInfosChanged(this._processInfosChangedToken);
        }
        catch (InvalidCastException ex)
        {
          if (ex.HResult == -2147467262)
            throw new InvalidOperationException("CoreWebView2 members can only be accessed from the UI thread.", (Exception) ex);
          throw ex;
        }
        catch (COMException ex)
        {
          if (ex.HResult == -2147019873)
            throw new InvalidOperationException("CoreWebView2 members cannot be accessed after the WebView2 control is disposed.", (Exception) ex);
          throw ex;
        }
      }
    }

    internal void OnProcessInfosChanged(object args)
    {
      EventHandler<object> processInfosChanged = this.processInfosChanged;
      if (processInfosChanged == null)
        return;
      processInfosChanged((object) this, args);
    }

    public IReadOnlyList<CoreWebView2ProcessInfo> GetProcessInfos()
    {
      try
      {
        // ISSUE: reference to a compiler-generated method
        return COMDotNetTypeConverter.ProcessInfoCollectionCOMToNet(this._nativeICoreWebView2Environment8.GetProcessInfos());
      }
      catch (InvalidCastException ex)
      {
        if (ex.HResult == -2147467262)
          throw new InvalidOperationException("CoreWebView2 members can only be accessed from the UI thread.", (Exception) ex);
        throw ex;
      }
      catch (COMException ex)
      {
        if (ex.HResult == -2147019873)
          throw new InvalidOperationException("CoreWebView2 members cannot be accessed after the WebView2 control is disposed.", (Exception) ex);
        throw ex;
      }
    }

    public CoreWebView2ContextMenuItem CreateContextMenuItem(
      string Label,
      Stream iconStream,
      CoreWebView2ContextMenuItemKind Kind)
    {
      try
      {
        // ISSUE: reference to a compiler-generated method
        return new CoreWebView2ContextMenuItem((object) this._nativeICoreWebView2Environment9.CreateContextMenuItem(Label, iconStream == null ? (IStream) null : (IStream) new ManagedIStream(iconStream), (COREWEBVIEW2_CONTEXT_MENU_ITEM_KIND) Kind));
      }
      catch (InvalidCastException ex)
      {
        if (ex.HResult == -2147467262)
          throw new InvalidOperationException("CoreWebView2 members can only be accessed from the UI thread.", (Exception) ex);
        throw ex;
      }
      catch (COMException ex)
      {
        if (ex.HResult == -2147019873)
          throw new InvalidOperationException("CoreWebView2 members cannot be accessed after the WebView2 control is disposed.", (Exception) ex);
        throw ex;
      }
    }

    public string FailureReportFolderPath
    {
      get
      {
        try
        {
          return this._nativeICoreWebView2Environment11.FailureReportFolderPath;
        }
        catch (InvalidCastException ex)
        {
          if (ex.HResult == -2147467262)
            throw new InvalidOperationException("CoreWebView2 members can only be accessed from the UI thread.", (Exception) ex);
          throw ex;
        }
        catch (COMException ex)
        {
          if (ex.HResult == -2147019873)
            throw new InvalidOperationException("CoreWebView2 members cannot be accessed after the WebView2 control is disposed.", (Exception) ex);
          throw ex;
        }
      }
    }

    public CoreWebView2SharedBuffer CreateSharedBuffer(ulong Size)
    {
      try
      {
        // ISSUE: reference to a compiler-generated method
        return new CoreWebView2SharedBuffer((object) this._nativeICoreWebView2Environment12.CreateSharedBuffer(Size));
      }
      catch (InvalidCastException ex)
      {
        if (ex.HResult == -2147467262)
          throw new InvalidOperationException("CoreWebView2 members can only be accessed from the UI thread.", (Exception) ex);
        throw ex;
      }
      catch (COMException ex)
      {
        if (ex.HResult == -2147019873)
          throw new InvalidOperationException("CoreWebView2 members cannot be accessed after the WebView2 control is disposed.", (Exception) ex);
        throw ex;
      }
    }

    private enum ProcessorArchitecture : ushort
    {
      x86 = 0,
      x64 = 9,
      ARM64 = 12, // 0x000C
      Unknown = 65535, // 0xFFFF
    }

    private struct SYSTEM_INFO
    {
      internal ushort wProcessorArchitecture;
      private ushort wReserved;
      private int dwPageSize;
      private IntPtr lpMinimumApplicationAddress;
      private IntPtr lpMaximumApplicationAddress;
      private IntPtr dwActiveProcessorMask;
      private int dwNumberOfProcessors;
      private int dwProcessorType;
      private int dwAllocationGranularity;
      private short wProcessorLevel;
      private short wProcessorRevision;
    }
  }
}
