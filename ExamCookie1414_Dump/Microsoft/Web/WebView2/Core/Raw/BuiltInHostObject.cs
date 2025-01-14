// Decompiled with JetBrains decompiler
// Type: Microsoft.Web.WebView2.Core.Raw.BuiltInHostObject
// Assembly: ExamCookie.WinClient, Version=1.4.1.4, Culture=neutral, PublicKeyToken=null
// MVID: E12BE1F8-B6E0-4BF5-B308-166F0E938C4B
// Assembly location: C:\Users\oskar\Downloads\ExamCookie1414.WinClient.exe

using System.Runtime.InteropServices;

#nullable disable
namespace Microsoft.Web.WebView2.Core.Raw
{
  [ClassInterface(ClassInterfaceType.AutoDispatch)]
  [ComVisible(true)]
  public class BuiltInHostObject
  {
    private object _originalHostObject;
    private EventConnector _eventConnector;

    public BuiltInHostObject(object originalHostObject)
    {
      this._originalHostObject = originalHostObject;
    }

    public void addEventListener(string eventName, object JSHandler)
    {
      this.EventConnector.addEventListener(eventName, JSHandler);
    }

    public void removeEventListener(string eventName, object JSHandler)
    {
      this.EventConnector.removeEventListener(eventName, JSHandler);
    }

    private EventConnector EventConnector
    {
      get
      {
        if (this._eventConnector == null)
          this._eventConnector = new EventConnector(this._originalHostObject);
        return this._eventConnector;
      }
    }
  }
}
