// Decompiled with JetBrains decompiler
// Type: Microsoft.Web.WebView2.Core.CoreWebView2DownloadInterruptReason
// Assembly: ExamCookie.WinClient, Version=1.4.1.4, Culture=neutral, PublicKeyToken=null
// MVID: E12BE1F8-B6E0-4BF5-B308-166F0E938C4B
// Assembly location: C:\Users\oskar\Downloads\ExamCookie1414.WinClient.exe

using System.Runtime.InteropServices;

#nullable disable
namespace Microsoft.Web.WebView2.Core
{
  [ComVisible(true)]
  public enum CoreWebView2DownloadInterruptReason
  {
    None,
    FileFailed,
    FileAccessDenied,
    FileNoSpace,
    FileNameTooLong,
    FileTooLarge,
    FileMalicious,
    FileTransientError,
    FileBlockedByPolicy,
    FileSecurityCheckFailed,
    FileTooShort,
    FileHashMismatch,
    NetworkFailed,
    NetworkTimeout,
    NetworkDisconnected,
    NetworkServerDown,
    NetworkInvalidRequest,
    ServerFailed,
    ServerNoRange,
    ServerBadContent,
    ServerUnauthorized,
    ServerCertificateProblem,
    ServerForbidden,
    ServerUnexpectedResponse,
    ServerContentLengthMismatch,
    ServerCrossOriginRedirect,
    UserCanceled,
    UserShutdown,
    UserPaused,
    DownloadProcessCrashed,
  }
}
