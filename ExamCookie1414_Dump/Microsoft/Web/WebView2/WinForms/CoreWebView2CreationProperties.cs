// Decompiled with JetBrains decompiler
// Type: Microsoft.Web.WebView2.WinForms.CoreWebView2CreationProperties
// Assembly: ExamCookie.WinClient, Version=1.4.1.4, Culture=neutral, PublicKeyToken=null
// MVID: E12BE1F8-B6E0-4BF5-B308-166F0E938C4B
// Assembly location: C:\Users\oskar\Downloads\ExamCookie1414.WinClient.exe

using Microsoft.Web.WebView2.Core;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

#nullable disable
namespace Microsoft.Web.WebView2.WinForms
{
  [ComVisible(true)]
  public class CoreWebView2CreationProperties
  {
    private string _browserExecutableFolder;
    private string _userDataFolder;
    private string _language;
    private string _additionalBrowserArguments;
    private Task<CoreWebView2Environment> _task;

    public string BrowserExecutableFolder
    {
      get => this._browserExecutableFolder;
      set
      {
        this._browserExecutableFolder = value;
        this._task = (Task<CoreWebView2Environment>) null;
      }
    }

    public string UserDataFolder
    {
      get => this._userDataFolder;
      set
      {
        this._userDataFolder = value;
        this._task = (Task<CoreWebView2Environment>) null;
      }
    }

    public string Language
    {
      get => this._language;
      set
      {
        this._language = value;
        this._task = (Task<CoreWebView2Environment>) null;
      }
    }

    public string ProfileName { get; set; }

    public string AdditionalBrowserArguments
    {
      get => this._additionalBrowserArguments;
      set
      {
        this._additionalBrowserArguments = value;
        this._task = (Task<CoreWebView2Environment>) null;
      }
    }

    public bool? IsInPrivateModeEnabled { get; set; }

    internal Task<CoreWebView2Environment> CreateEnvironmentAsync()
    {
      if (this._task == null && (this.BrowserExecutableFolder != null || this.UserDataFolder != null || this.Language != null || this.AdditionalBrowserArguments != null))
        this._task = CoreWebView2Environment.CreateAsync(this.BrowserExecutableFolder, this.UserDataFolder, new CoreWebView2EnvironmentOptions(this.AdditionalBrowserArguments, this.Language));
      return this._task ?? Task.FromResult<CoreWebView2Environment>((CoreWebView2Environment) null);
    }

    internal CoreWebView2ControllerOptions CreateCoreWebView2ControllerOptions(
      CoreWebView2Environment environment)
    {
      CoreWebView2ControllerOptions controllerOptions = (CoreWebView2ControllerOptions) null;
      if (this.ProfileName != null || this.IsInPrivateModeEnabled.HasValue)
      {
        controllerOptions = environment.CreateCoreWebView2ControllerOptions();
        controllerOptions.ProfileName = this.ProfileName;
        controllerOptions.IsInPrivateModeEnabled = this.IsInPrivateModeEnabled.GetValueOrDefault();
      }
      return controllerOptions;
    }
  }
}
