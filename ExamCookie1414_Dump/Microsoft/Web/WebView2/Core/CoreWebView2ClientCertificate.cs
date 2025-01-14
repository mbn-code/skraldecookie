// Decompiled with JetBrains decompiler
// Type: Microsoft.Web.WebView2.Core.CoreWebView2ClientCertificate
// Assembly: ExamCookie.WinClient, Version=1.4.1.4, Culture=neutral, PublicKeyToken=null
// MVID: E12BE1F8-B6E0-4BF5-B308-166F0E938C4B
// Assembly location: C:\Users\oskar\Downloads\ExamCookie1414.WinClient.exe

using Microsoft.Web.WebView2.Core.Raw;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

#nullable disable
namespace Microsoft.Web.WebView2.Core
{
  [ComVisible(true)]
  public class CoreWebView2ClientCertificate
  {
    private static DateTime _unixEpoch = DateTime.SpecifyKind(new DateTime(1970, 1, 1), DateTimeKind.Utc);
    internal ICoreWebView2ClientCertificate _nativeICoreWebView2ClientCertificateValue;
    internal object _rawNative;

    public X509Certificate2 ToX509Certificate2()
    {
      X509Certificate2 x509Certificate2 = new X509Certificate2(Convert.FromBase64String(this.ToPemEncoding().Replace("-----BEGIN CERTIFICATE-----", string.Empty).Replace("-----END CERTIFICATE-----", string.Empty)));
      if (x509Certificate2 != null)
        x509Certificate2.FriendlyName = this.DisplayName;
      return x509Certificate2;
    }

    public DateTime ValidFrom
    {
      get
      {
        return this.SecondsSinceUnixEpochToDateTime(this._nativeICoreWebView2ClientCertificate.ValidFrom);
      }
    }

    public DateTime ValidTo
    {
      get
      {
        return this.SecondsSinceUnixEpochToDateTime(this._nativeICoreWebView2ClientCertificate.ValidTo);
      }
    }

    private DateTime SecondsSinceUnixEpochToDateTime(double seconds)
    {
      if (seconds < 0.0)
        return DateTime.MinValue;
      return seconds * 10000000.0 + (double) CoreWebView2ClientCertificate._unixEpoch.Ticks > (double) DateTime.MaxValue.Ticks ? DateTime.MaxValue : CoreWebView2ClientCertificate._unixEpoch.AddSeconds(seconds);
    }

    internal ICoreWebView2ClientCertificate _nativeICoreWebView2ClientCertificate
    {
      get
      {
        if (this._nativeICoreWebView2ClientCertificateValue == null)
        {
          try
          {
            this._nativeICoreWebView2ClientCertificateValue = (ICoreWebView2ClientCertificate) this._rawNative;
          }
          catch (Exception ex)
          {
            throw new NotImplementedException("Unable to cast to Microsoft.Web.WebView2.Core.Raw.ICoreWebView2ClientCertificate.\nThis may happen if you are using an interface not supported by the version of the WebView2 Runtime you are using.\nFor instance, if you are using an experimental interface from an older SDK that has been modified or removed in a newer runtime.\nOr, if you are using a public interface from a newer SDK that wasn't implemented in an older runtime.\nFor more information about WebView2 versioning please visit the following: https://learn.microsoft.com/microsoft-edge/webview2/concepts/versioning", ex);
          }
        }
        return this._nativeICoreWebView2ClientCertificateValue;
      }
      set => this._nativeICoreWebView2ClientCertificateValue = value;
    }

    internal CoreWebView2ClientCertificate(object rawCoreWebView2ClientCertificate)
    {
      this._rawNative = rawCoreWebView2ClientCertificate;
    }

    public string Subject
    {
      get
      {
        try
        {
          return this._nativeICoreWebView2ClientCertificate.Subject;
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

    public string Issuer
    {
      get
      {
        try
        {
          return this._nativeICoreWebView2ClientCertificate.Issuer;
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

    public string DerEncodedSerialNumber
    {
      get
      {
        try
        {
          return this._nativeICoreWebView2ClientCertificate.DerEncodedSerialNumber;
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

    public string DisplayName
    {
      get
      {
        try
        {
          return this._nativeICoreWebView2ClientCertificate.DisplayName;
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

    public IReadOnlyList<string> PemEncodedIssuerCertificateChain
    {
      get
      {
        try
        {
          return COMDotNetTypeConverter.CoreWebView2StringCollectionCOMToNet(this._nativeICoreWebView2ClientCertificate.PemEncodedIssuerCertificateChain);
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

    public CoreWebView2ClientCertificateKind Kind
    {
      get
      {
        try
        {
          return (CoreWebView2ClientCertificateKind) this._nativeICoreWebView2ClientCertificate.Kind;
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

    public string ToPemEncoding()
    {
      try
      {
        // ISSUE: reference to a compiler-generated method
        return this._nativeICoreWebView2ClientCertificate.ToPemEncoding();
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
}
