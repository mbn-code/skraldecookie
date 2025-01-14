// Decompiled with JetBrains decompiler
// Type: Microsoft.Web.WebView2.Core.EventConnector
// Assembly: ExamCookie.WinClient, Version=1.4.1.4, Culture=neutral, PublicKeyToken=null
// MVID: E12BE1F8-B6E0-4BF5-B308-166F0E938C4B
// Assembly location: C:\Users\oskar\Downloads\ExamCookie1414.WinClient.exe

using Microsoft.Web.WebView2.Core.Raw;
using System;
using System.Collections.Generic;
using System.Reflection;

#nullable disable
namespace Microsoft.Web.WebView2.Core
{
  internal class EventConnector
  {
    private DelegateMap _DelegatesMap = new DelegateMap();
    private object _originalHostObject;

    public EventConnector(object originalHostObject)
    {
      this._originalHostObject = originalHostObject;
    }

    public void addEventListener(string eventName, object JSHandler)
    {
      try
      {
        CoreWebView2PrivateRemoteObjectProxy remoteObjectProxy = new CoreWebView2PrivateRemoteObjectProxy(JSHandler);
        int id = remoteObjectProxy.GetId();
        EventInfo eventInfo = this.CheckAndGetEventInfo(eventName);
        Delegate handler = this._DelegatesMap.GetDelegate(id);
        if ((object) handler == null)
        {
          remoteObjectProxy.Passivated += new EventHandler<object>(this.RemoteObjectPassivated);
          handler = new JSHandlerWrapper(JSHandler).CreateDelegate(eventInfo);
        }
        if (!this._DelegatesMap.InsertDelegate(eventName, id, handler))
          return;
        eventInfo.AddEventHandler(this._originalHostObject, handler);
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    public void removeEventListener(string eventName, object JSHandler)
    {
      try
      {
        // ISSUE: reference to a compiler-generated method
        Delegate handler = this._DelegatesMap.RemoveDelegate(eventName, (JSHandler as ICoreWebView2PrivateRemoteObjectProxy).GetId());
        if ((object) handler == null)
          return;
        this.CheckAndGetEventInfo(eventName).RemoveEventHandler(this._originalHostObject, handler);
      }
      catch (Exception ex)
      {
        if (ex.InnerException != null)
          throw ex.InnerException;
        throw ex;
      }
    }

    private void RemoteObjectPassivated(object sender, object args)
    {
      try
      {
        int id = (sender as CoreWebView2PrivateRemoteObjectProxy).GetId();
        List<string> registeredEventNameById = this._DelegatesMap.GetRegisteredEventNameById(id);
        Delegate handler = this._DelegatesMap.GetDelegate(id);
        if ((object) handler == null)
          return;
        foreach (string eventName in registeredEventNameById)
        {
          this._DelegatesMap.RemoveDelegate(eventName, id);
          this.CheckAndGetEventInfo(eventName).RemoveEventHandler(this._originalHostObject, handler);
        }
      }
      catch (Exception ex)
      {
      }
    }

    private EventInfo CheckAndGetEventInfo(string eventName)
    {
      EventInfo eventInfo = this._originalHostObject.GetType().GetEvent(eventName, BindingFlags.Instance | BindingFlags.Public);
      return !(eventInfo == (EventInfo) null) ? eventInfo : throw new Exception("No such event or it is not public, event's name:" + eventName + ".");
    }
  }
}
