// Decompiled with JetBrains decompiler
// Type: Microsoft.Web.WebView2.Core.DelegateMap
// Assembly: ExamCookie.WinClient, Version=1.4.1.4, Culture=neutral, PublicKeyToken=null
// MVID: E12BE1F8-B6E0-4BF5-B308-166F0E938C4B
// Assembly location: C:\Users\oskar\Downloads\ExamCookie1414.WinClient.exe

using System;
using System.Collections.Generic;

#nullable disable
namespace Microsoft.Web.WebView2.Core
{
  internal class DelegateMap
  {
    private Dictionary<string, HashSet<int>> _RegisteredHandlerIdsMap = new Dictionary<string, HashSet<int>>();
    private Dictionary<int, DelegateMap.tuple> _HandlerMap = new Dictionary<int, DelegateMap.tuple>();

    public Delegate GetDelegate(int handlerId)
    {
      try
      {
        return this._HandlerMap[handlerId].handler;
      }
      catch (Exception ex)
      {
        return (Delegate) null;
      }
    }

    public bool InsertDelegate(string eventName, int handlerId, Delegate handler)
    {
      try
      {
        if (!this._RegisteredHandlerIdsMap.ContainsKey(eventName))
          this._RegisteredHandlerIdsMap[eventName] = new HashSet<int>();
        HashSet<int> registeredHandlerIds = this._RegisteredHandlerIdsMap[eventName];
        if (registeredHandlerIds.Contains(handlerId))
          return false;
        registeredHandlerIds.Add(handlerId);
        if (this._HandlerMap.ContainsKey(handlerId))
          ++this._HandlerMap[handlerId].count;
        else
          this._HandlerMap[handlerId] = new DelegateMap.tuple(1, handler);
        return true;
      }
      catch (Exception ex)
      {
        if (ex.InnerException != null)
          throw ex.InnerException;
        throw ex;
      }
    }

    public Delegate RemoveDelegate(string eventName, int handlerId)
    {
      try
      {
        if (!this._RegisteredHandlerIdsMap.ContainsKey(eventName))
          return (Delegate) null;
        HashSet<int> registeredHandlerIds = this._RegisteredHandlerIdsMap[eventName];
        if (!registeredHandlerIds.Remove(handlerId))
          return (Delegate) null;
        if (registeredHandlerIds.Count == 0)
          this._RegisteredHandlerIdsMap.Remove(eventName);
        DelegateMap.tuple handler = this._HandlerMap[handlerId];
        --handler.count;
        if (handler.count == 0)
          this._HandlerMap.Remove(handlerId);
        return handler.handler;
      }
      catch (Exception ex)
      {
        if (ex.InnerException != null)
          throw ex.InnerException;
        throw ex;
      }
    }

    public List<string> GetRegisteredEventNameById(int handlerId)
    {
      List<string> registeredEventNameById = new List<string>();
      foreach (KeyValuePair<string, HashSet<int>> registeredHandlerIds in this._RegisteredHandlerIdsMap)
      {
        if (registeredHandlerIds.Value.Contains(handlerId))
          registeredEventNameById.Add(registeredHandlerIds.Key);
      }
      return registeredEventNameById;
    }

    private class tuple
    {
      public int count;
      public Delegate handler;

      public tuple(int count, Delegate handler)
      {
        this.count = count;
        this.handler = handler;
      }
    }
  }
}
