// Decompiled with JetBrains decompiler
// Type: Microsoft.Web.WebView2.Core.CoreWebView2CustomSchemeRegistration
// Assembly: ExamCookie.WinClient, Version=1.4.1.4, Culture=neutral, PublicKeyToken=null
// MVID: E12BE1F8-B6E0-4BF5-B308-166F0E938C4B
// Assembly location: C:\Users\oskar\Downloads\ExamCookie1414.WinClient.exe

using Microsoft.Web.WebView2.Core.Raw;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

#nullable disable
namespace Microsoft.Web.WebView2.Core
{
  [ComVisible(true)]
  public class CoreWebView2CustomSchemeRegistration
  {
    public string SchemeName { get; }

    public bool TreatAsSecure { get; set; }

    public bool HasAuthorityComponent { get; set; }

    public List<string> AllowedOrigins { get; set; } = new List<string>();

    public CoreWebView2CustomSchemeRegistration(string schemeName) => this.SchemeName = schemeName;

    internal IntPtr GetNative()
    {
      return Marshal.GetComInterfaceForObject((object) new CoreWebView2CustomSchemeRegistration.RawCustomSchemeRegistration(this.SchemeName, this.TreatAsSecure, this.HasAuthorityComponent, this.AllowedOrigins), typeof (ICoreWebView2CustomSchemeRegistration));
    }

    private class RawCustomSchemeRegistration : ICoreWebView2CustomSchemeRegistration
    {
      public RawCustomSchemeRegistration(
        string schemeName,
        bool treatAsSecure,
        bool hasAuthorityComponent,
        List<string> allowedOrigins)
      {
        this.SchemeName = schemeName;
        this.TreatAsSecure = treatAsSecure ? 1 : 0;
        this.HasAuthorityComponent = hasAuthorityComponent ? 1 : 0;
        this.AllowedOrigins = allowedOrigins;
      }

      public string SchemeName { get; set; }

      public int TreatAsSecure { get; set; }

      public int HasAuthorityComponent { get; set; }

      private List<string> AllowedOrigins { get; } = new List<string>();

      public void GetAllowedOrigins(out uint allowedOriginsCount, IntPtr allowedOriginsPtr)
      {
        allowedOriginsCount = (uint) this.AllowedOrigins.Count;
        if (allowedOriginsCount == 0U)
          return;
        IntPtr val = Marshal.AllocCoTaskMem((int) allowedOriginsCount * Marshal.SizeOf<IntPtr>());
        for (int index = 0; (long) index < (long) allowedOriginsCount; ++index)
          Marshal.WriteIntPtr(val + index * Marshal.SizeOf<IntPtr>(), Marshal.StringToCoTaskMemAuto(this.AllowedOrigins[index]));
        Marshal.WriteIntPtr(allowedOriginsPtr, val);
      }

      public void SetAllowedOrigins(uint allowedOriginsCount, ref string allowedOrigins)
      {
        throw new NotImplementedException();
      }
    }
  }
}
