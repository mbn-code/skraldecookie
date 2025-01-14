// Decompiled with JetBrains decompiler
// Type: NativeWifi.WlanClient
// Assembly: ExamCookie.WinClient, Version=1.4.1.4, Culture=neutral, PublicKeyToken=null
// MVID: E12BE1F8-B6E0-4BF5-B308-166F0E938C4B
// Assembly location: C:\Users\oskar\Downloads\ExamCookie1414.WinClient.exe

using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

#nullable disable
namespace NativeWifi
{
  public class WlanClient : IDisposable
  {
    private IntPtr clientHandle;
    private uint negotiatedVersion;
    private readonly Wlan.WlanNotificationCallbackDelegate wlanNotificationCallback;
    private readonly Dictionary<Guid, WlanClient.WlanInterface> ifaces = new Dictionary<Guid, WlanClient.WlanInterface>();

    public WlanClient()
    {
      Wlan.ThrowIfError(Wlan.WlanOpenHandle(1U, IntPtr.Zero, out this.negotiatedVersion, out this.clientHandle));
      try
      {
        this.wlanNotificationCallback = new Wlan.WlanNotificationCallbackDelegate(this.OnWlanNotification);
        Wlan.ThrowIfError(Wlan.WlanRegisterNotification(this.clientHandle, Wlan.WlanNotificationSource.All, false, this.wlanNotificationCallback, IntPtr.Zero, IntPtr.Zero, out Wlan.WlanNotificationSource _));
      }
      catch
      {
        this.Close();
        throw;
      }
    }

    void IDisposable.Dispose()
    {
      GC.SuppressFinalize((object) this);
      this.Close();
    }

    ~WlanClient() => this.Close();

    private void Close()
    {
      try
      {
        if (!(this.clientHandle != IntPtr.Zero))
          return;
        Wlan.WlanCloseHandle(this.clientHandle, IntPtr.Zero);
        this.clientHandle = IntPtr.Zero;
      }
      catch (Exception ex)
      {
        Console.WriteLine((object) ex);
      }
    }

    private static Wlan.WlanConnectionNotificationData? ParseWlanConnectionNotification(
      ref Wlan.WlanNotificationData notifyData)
    {
      try
      {
        int num = Marshal.SizeOf(typeof (Wlan.WlanConnectionNotificationData));
        if (notifyData.dataSize < num)
          return new Wlan.WlanConnectionNotificationData?();
        Wlan.WlanConnectionNotificationData structure = (Wlan.WlanConnectionNotificationData) Marshal.PtrToStructure(notifyData.dataPtr, typeof (Wlan.WlanConnectionNotificationData));
        if (structure.wlanReasonCode == Wlan.WlanReasonCode.Success)
        {
          IntPtr ptr = new IntPtr(notifyData.dataPtr.ToInt64() + Marshal.OffsetOf(typeof (Wlan.WlanConnectionNotificationData), "profileXml").ToInt64());
          structure.profileXml = Marshal.PtrToStringUni(ptr);
        }
        return new Wlan.WlanConnectionNotificationData?(structure);
      }
      catch (Exception ex)
      {
        Console.WriteLine((object) ex);
        return new Wlan.WlanConnectionNotificationData?();
      }
    }

    private void OnWlanNotification(ref Wlan.WlanNotificationData notifyData, IntPtr context)
    {
      WlanClient.WlanInterface wlanInterface;
      this.ifaces.TryGetValue(notifyData.interfaceGuid, out wlanInterface);
      switch (notifyData.notificationSource)
      {
        case Wlan.WlanNotificationSource.ACM:
          switch ((Wlan.WlanNotificationCodeAcm) notifyData.notificationCode)
          {
            case Wlan.WlanNotificationCodeAcm.ScanFail:
              int num = Marshal.SizeOf(typeof (int));
              if (notifyData.dataSize >= num)
              {
                Wlan.WlanReasonCode reasonCode = (Wlan.WlanReasonCode) Marshal.ReadInt32(notifyData.dataPtr);
                wlanInterface?.OnWlanReason(notifyData, reasonCode);
                break;
              }
              break;
            case Wlan.WlanNotificationCodeAcm.ConnectionStart:
            case Wlan.WlanNotificationCodeAcm.ConnectionComplete:
            case Wlan.WlanNotificationCodeAcm.ConnectionAttemptFail:
            case Wlan.WlanNotificationCodeAcm.Disconnecting:
            case Wlan.WlanNotificationCodeAcm.Disconnected:
              Wlan.WlanConnectionNotificationData? connectionNotification1 = WlanClient.ParseWlanConnectionNotification(ref notifyData);
              if (connectionNotification1.HasValue && wlanInterface != null)
              {
                wlanInterface.OnWlanConnection(notifyData, connectionNotification1.Value);
                break;
              }
              break;
          }
          break;
        case Wlan.WlanNotificationSource.MSM:
          switch ((Wlan.WlanNotificationCodeMsm) notifyData.notificationCode)
          {
            case Wlan.WlanNotificationCodeMsm.Associating:
            case Wlan.WlanNotificationCodeMsm.Associated:
            case Wlan.WlanNotificationCodeMsm.Authenticating:
            case Wlan.WlanNotificationCodeMsm.Connected:
            case Wlan.WlanNotificationCodeMsm.RoamingStart:
            case Wlan.WlanNotificationCodeMsm.RoamingEnd:
            case Wlan.WlanNotificationCodeMsm.Disassociating:
            case Wlan.WlanNotificationCodeMsm.Disconnected:
            case Wlan.WlanNotificationCodeMsm.PeerJoin:
            case Wlan.WlanNotificationCodeMsm.PeerLeave:
            case Wlan.WlanNotificationCodeMsm.AdapterRemoval:
              Wlan.WlanConnectionNotificationData? connectionNotification2 = WlanClient.ParseWlanConnectionNotification(ref notifyData);
              if (connectionNotification2.HasValue && wlanInterface != null)
              {
                wlanInterface.OnWlanConnection(notifyData, connectionNotification2.Value);
                break;
              }
              break;
          }
          break;
      }
      wlanInterface?.OnWlanNotification(notifyData);
    }

    public WlanClient.WlanInterface[] Interfaces
    {
      get
      {
        IntPtr ppInterfaceList;
        Wlan.ThrowIfError(Wlan.WlanEnumInterfaces(this.clientHandle, IntPtr.Zero, out ppInterfaceList));
        try
        {
          Wlan.WlanInterfaceInfoListHeader structure1 = (Wlan.WlanInterfaceInfoListHeader) Marshal.PtrToStructure(ppInterfaceList, typeof (Wlan.WlanInterfaceInfoListHeader));
          long num = ppInterfaceList.ToInt64() + (long) Marshal.SizeOf((object) structure1);
          WlanClient.WlanInterface[] interfaces = new WlanClient.WlanInterface[(int) structure1.numberOfItems];
          List<Guid> guidList = new List<Guid>();
          for (int index = 0; (long) index < (long) structure1.numberOfItems; ++index)
          {
            Wlan.WlanInterfaceInfo structure2 = (Wlan.WlanInterfaceInfo) Marshal.PtrToStructure(new IntPtr(num), typeof (Wlan.WlanInterfaceInfo));
            num += (long) Marshal.SizeOf((object) structure2);
            guidList.Add(structure2.interfaceGuid);
            WlanClient.WlanInterface wlanInterface;
            if (!this.ifaces.TryGetValue(structure2.interfaceGuid, out wlanInterface))
            {
              wlanInterface = new WlanClient.WlanInterface(this, structure2);
              this.ifaces[structure2.interfaceGuid] = wlanInterface;
            }
            interfaces[index] = wlanInterface;
          }
          Queue<Guid> guidQueue = new Queue<Guid>();
          foreach (Guid key in this.ifaces.Keys)
          {
            if (!guidList.Contains(key))
              guidQueue.Enqueue(key);
          }
          while (guidQueue.Count != 0)
            this.ifaces.Remove(guidQueue.Dequeue());
          return interfaces;
        }
        finally
        {
          Wlan.WlanFreeMemory(ppInterfaceList);
        }
      }
    }

    public string GetStringForReasonCode(Wlan.WlanReasonCode reasonCode)
    {
      StringBuilder stringBuffer = new StringBuilder(1024);
      Wlan.ThrowIfError(Wlan.WlanReasonCodeToString(reasonCode, stringBuffer.Capacity, stringBuffer, IntPtr.Zero));
      return stringBuffer.ToString();
    }

    public class WlanInterface
    {
      private readonly WlanClient client;
      private Wlan.WlanInterfaceInfo info;
      private bool queueEvents;
      private readonly AutoResetEvent eventQueueFilled = new AutoResetEvent(false);
      private readonly Queue<object> eventQueue = new Queue<object>();

      public event WlanClient.WlanInterface.WlanNotificationEventHandler WlanNotification;

      public event WlanClient.WlanInterface.WlanConnectionNotificationEventHandler WlanConnectionNotification;

      public event WlanClient.WlanInterface.WlanReasonNotificationEventHandler WlanReasonNotification;

      internal WlanInterface(WlanClient client, Wlan.WlanInterfaceInfo info)
      {
        this.client = client;
        this.info = info;
      }

      private void SetInterfaceInt(Wlan.WlanIntfOpcode opCode, int value)
      {
        IntPtr num = Marshal.AllocHGlobal(4);
        Marshal.WriteInt32(num, value);
        try
        {
          Wlan.ThrowIfError(Wlan.WlanSetInterface(this.client.clientHandle, this.info.interfaceGuid, opCode, 4U, num, IntPtr.Zero));
        }
        finally
        {
          Marshal.FreeHGlobal(num);
        }
      }

      private int GetInterfaceInt(Wlan.WlanIntfOpcode opCode)
      {
        IntPtr ppData;
        Wlan.ThrowIfError(Wlan.WlanQueryInterface(this.client.clientHandle, this.info.interfaceGuid, opCode, IntPtr.Zero, out int _, out ppData, out Wlan.WlanOpcodeValueType _));
        try
        {
          return Marshal.ReadInt32(ppData);
        }
        finally
        {
          Wlan.WlanFreeMemory(ppData);
        }
      }

      public bool Autoconf
      {
        get => this.GetInterfaceInt(Wlan.WlanIntfOpcode.AutoconfEnabled) != 0;
        set => this.SetInterfaceInt(Wlan.WlanIntfOpcode.AutoconfEnabled, value ? 1 : 0);
      }

      public Wlan.Dot11BssType BssType
      {
        get => (Wlan.Dot11BssType) this.GetInterfaceInt(Wlan.WlanIntfOpcode.BssType);
        set => this.SetInterfaceInt(Wlan.WlanIntfOpcode.BssType, (int) value);
      }

      public Wlan.WlanInterfaceState InterfaceState
      {
        get => (Wlan.WlanInterfaceState) this.GetInterfaceInt(Wlan.WlanIntfOpcode.InterfaceState);
      }

      public int Channel => this.GetInterfaceInt(Wlan.WlanIntfOpcode.ChannelNumber);

      public int RSSI => this.GetInterfaceInt(Wlan.WlanIntfOpcode.RSSI);

      public Wlan.WlanRadioState RadioState
      {
        get
        {
          IntPtr ppData;
          Wlan.ThrowIfError(Wlan.WlanQueryInterface(this.client.clientHandle, this.info.interfaceGuid, Wlan.WlanIntfOpcode.RadioState, IntPtr.Zero, out int _, out ppData, out Wlan.WlanOpcodeValueType _));
          try
          {
            return (Wlan.WlanRadioState) Marshal.PtrToStructure(ppData, typeof (Wlan.WlanRadioState));
          }
          finally
          {
            Wlan.WlanFreeMemory(ppData);
          }
        }
      }

      public Wlan.Dot11OperationMode CurrentOperationMode
      {
        get
        {
          return (Wlan.Dot11OperationMode) this.GetInterfaceInt(Wlan.WlanIntfOpcode.CurrentOperationMode);
        }
      }

      public Wlan.WlanConnectionAttributes CurrentConnection
      {
        get
        {
          IntPtr ppData;
          Wlan.ThrowIfError(Wlan.WlanQueryInterface(this.client.clientHandle, this.info.interfaceGuid, Wlan.WlanIntfOpcode.CurrentConnection, IntPtr.Zero, out int _, out ppData, out Wlan.WlanOpcodeValueType _));
          try
          {
            return (Wlan.WlanConnectionAttributes) Marshal.PtrToStructure(ppData, typeof (Wlan.WlanConnectionAttributes));
          }
          finally
          {
            Wlan.WlanFreeMemory(ppData);
          }
        }
      }

      public void Scan()
      {
        Wlan.ThrowIfError(Wlan.WlanScan(this.client.clientHandle, this.info.interfaceGuid, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero));
      }

      private static Wlan.WlanAvailableNetwork[] ConvertAvailableNetworkListPtr(
        IntPtr availNetListPtr)
      {
        Wlan.WlanAvailableNetworkListHeader structure = (Wlan.WlanAvailableNetworkListHeader) Marshal.PtrToStructure(availNetListPtr, typeof (Wlan.WlanAvailableNetworkListHeader));
        long num = availNetListPtr.ToInt64() + (long) Marshal.SizeOf(typeof (Wlan.WlanAvailableNetworkListHeader));
        Wlan.WlanAvailableNetwork[] availableNetworkArray = new Wlan.WlanAvailableNetwork[(int) structure.numberOfItems];
        for (int index = 0; (long) index < (long) structure.numberOfItems; ++index)
        {
          availableNetworkArray[index] = (Wlan.WlanAvailableNetwork) Marshal.PtrToStructure(new IntPtr(num), typeof (Wlan.WlanAvailableNetwork));
          num += (long) Marshal.SizeOf(typeof (Wlan.WlanAvailableNetwork));
        }
        return availableNetworkArray;
      }

      public Wlan.WlanAvailableNetwork[] GetAvailableNetworkList(
        Wlan.WlanGetAvailableNetworkFlags flags)
      {
        IntPtr availableNetworkListPtr;
        Wlan.ThrowIfError(Wlan.WlanGetAvailableNetworkList(this.client.clientHandle, this.info.interfaceGuid, flags, IntPtr.Zero, out availableNetworkListPtr));
        try
        {
          return WlanClient.WlanInterface.ConvertAvailableNetworkListPtr(availableNetworkListPtr);
        }
        finally
        {
          Wlan.WlanFreeMemory(availableNetworkListPtr);
        }
      }

      private static Wlan.WlanBssEntry[] ConvertBssListPtr(IntPtr bssListPtr)
      {
        Wlan.WlanBssListHeader structure = (Wlan.WlanBssListHeader) Marshal.PtrToStructure(bssListPtr, typeof (Wlan.WlanBssListHeader));
        long num = bssListPtr.ToInt64() + (long) Marshal.SizeOf(typeof (Wlan.WlanBssListHeader));
        Wlan.WlanBssEntry[] wlanBssEntryArray = new Wlan.WlanBssEntry[(int) structure.numberOfItems];
        for (int index = 0; (long) index < (long) structure.numberOfItems; ++index)
        {
          wlanBssEntryArray[index] = (Wlan.WlanBssEntry) Marshal.PtrToStructure(new IntPtr(num), typeof (Wlan.WlanBssEntry));
          num += (long) Marshal.SizeOf(typeof (Wlan.WlanBssEntry));
        }
        return wlanBssEntryArray;
      }

      public Wlan.WlanBssEntry[] GetNetworkBssList()
      {
        IntPtr wlanBssList;
        Wlan.ThrowIfError(Wlan.WlanGetNetworkBssList(this.client.clientHandle, this.info.interfaceGuid, IntPtr.Zero, Wlan.Dot11BssType.Any, false, IntPtr.Zero, out wlanBssList));
        try
        {
          return WlanClient.WlanInterface.ConvertBssListPtr(wlanBssList);
        }
        finally
        {
          Wlan.WlanFreeMemory(wlanBssList);
        }
      }

      public Wlan.WlanBssEntry[] GetNetworkBssList(
        Wlan.Dot11Ssid ssid,
        Wlan.Dot11BssType bssType,
        bool securityEnabled)
      {
        IntPtr num = Marshal.AllocHGlobal(Marshal.SizeOf((object) ssid));
        Marshal.StructureToPtr((object) ssid, num, false);
        try
        {
          IntPtr wlanBssList;
          Wlan.ThrowIfError(Wlan.WlanGetNetworkBssList(this.client.clientHandle, this.info.interfaceGuid, num, bssType, securityEnabled, IntPtr.Zero, out wlanBssList));
          try
          {
            return WlanClient.WlanInterface.ConvertBssListPtr(wlanBssList);
          }
          finally
          {
            Wlan.WlanFreeMemory(wlanBssList);
          }
        }
        finally
        {
          Marshal.FreeHGlobal(num);
        }
      }

      protected void Connect(Wlan.WlanConnectionParameters connectionParams)
      {
        Wlan.ThrowIfError(Wlan.WlanConnect(this.client.clientHandle, this.info.interfaceGuid, ref connectionParams, IntPtr.Zero));
      }

      public void Connect(
        Wlan.WlanConnectionMode connectionMode,
        Wlan.Dot11BssType bssType,
        string profile)
      {
        this.Connect(new Wlan.WlanConnectionParameters()
        {
          wlanConnectionMode = connectionMode,
          profile = profile,
          dot11BssType = bssType,
          flags = (Wlan.WlanConnectionFlags) 0
        });
      }

      public bool ConnectSynchronously(
        Wlan.WlanConnectionMode connectionMode,
        Wlan.Dot11BssType bssType,
        string profile,
        int connectTimeout)
      {
        this.queueEvents = true;
        try
        {
          this.Connect(connectionMode, bssType, profile);
          while (this.queueEvents && this.eventQueueFilled.WaitOne(connectTimeout, true))
          {
            lock (this.eventQueue)
            {
              while (this.eventQueue.Count != 0)
              {
                if (this.eventQueue.Dequeue() is WlanClient.WlanInterface.WlanConnectionNotificationEventData notificationEventData)
                {
                  if (notificationEventData.notifyData.notificationSource == Wlan.WlanNotificationSource.ACM)
                  {
                    if (notificationEventData.notifyData.notificationCode == 10 && notificationEventData.connNotifyData.profileName == profile)
                      return true;
                    break;
                  }
                  break;
                }
              }
            }
          }
        }
        finally
        {
          this.queueEvents = false;
          this.eventQueue.Clear();
        }
        return false;
      }

      public void Connect(
        Wlan.WlanConnectionMode connectionMode,
        Wlan.Dot11BssType bssType,
        Wlan.Dot11Ssid ssid,
        Wlan.WlanConnectionFlags flags)
      {
        Wlan.WlanConnectionParameters connectionParams = new Wlan.WlanConnectionParameters();
        connectionParams.wlanConnectionMode = connectionMode;
        connectionParams.dot11SsidPtr = Marshal.AllocHGlobal(Marshal.SizeOf((object) ssid));
        Marshal.StructureToPtr((object) ssid, connectionParams.dot11SsidPtr, false);
        connectionParams.dot11BssType = bssType;
        connectionParams.flags = flags;
        this.Connect(connectionParams);
        Marshal.DestroyStructure(connectionParams.dot11SsidPtr, ssid.GetType());
        Marshal.FreeHGlobal(connectionParams.dot11SsidPtr);
      }

      public void DeleteProfile(string profileName)
      {
        Wlan.ThrowIfError(Wlan.WlanDeleteProfile(this.client.clientHandle, this.info.interfaceGuid, profileName, IntPtr.Zero));
      }

      public Wlan.WlanReasonCode SetProfile(
        Wlan.WlanProfileFlags flags,
        string profileXml,
        bool overwrite)
      {
        Wlan.WlanReasonCode reasonCode;
        Wlan.ThrowIfError(Wlan.WlanSetProfile(this.client.clientHandle, this.info.interfaceGuid, flags, profileXml, (string) null, overwrite, IntPtr.Zero, out reasonCode));
        return reasonCode;
      }

      public string GetProfileXml(string profileName)
      {
        IntPtr profileXml;
        Wlan.ThrowIfError(Wlan.WlanGetProfile(this.client.clientHandle, this.info.interfaceGuid, profileName, IntPtr.Zero, out profileXml, out Wlan.WlanProfileFlags _, out Wlan.WlanAccess _));
        try
        {
          return Marshal.PtrToStringUni(profileXml);
        }
        finally
        {
          Wlan.WlanFreeMemory(profileXml);
        }
      }

      public Wlan.WlanProfileInfo[] GetProfiles()
      {
        IntPtr profileList;
        Wlan.ThrowIfError(Wlan.WlanGetProfileList(this.client.clientHandle, this.info.interfaceGuid, IntPtr.Zero, out profileList));
        try
        {
          Wlan.WlanProfileInfoListHeader structure1 = (Wlan.WlanProfileInfoListHeader) Marshal.PtrToStructure(profileList, typeof (Wlan.WlanProfileInfoListHeader));
          Wlan.WlanProfileInfo[] profiles = new Wlan.WlanProfileInfo[(int) structure1.numberOfItems];
          long num = profileList.ToInt64() + (long) Marshal.SizeOf((object) structure1);
          for (int index = 0; (long) index < (long) structure1.numberOfItems; ++index)
          {
            Wlan.WlanProfileInfo structure2 = (Wlan.WlanProfileInfo) Marshal.PtrToStructure(new IntPtr(num), typeof (Wlan.WlanProfileInfo));
            profiles[index] = structure2;
            num += (long) Marshal.SizeOf((object) structure2);
          }
          return profiles;
        }
        finally
        {
          Wlan.WlanFreeMemory(profileList);
        }
      }

      internal void OnWlanConnection(
        Wlan.WlanNotificationData notifyData,
        Wlan.WlanConnectionNotificationData connNotifyData)
      {
        if (this.WlanConnectionNotification != null)
          this.WlanConnectionNotification(notifyData, connNotifyData);
        if (!this.queueEvents)
          return;
        this.EnqueueEvent((object) new WlanClient.WlanInterface.WlanConnectionNotificationEventData()
        {
          notifyData = notifyData,
          connNotifyData = connNotifyData
        });
      }

      internal void OnWlanReason(
        Wlan.WlanNotificationData notifyData,
        Wlan.WlanReasonCode reasonCode)
      {
        if (this.WlanReasonNotification != null)
          this.WlanReasonNotification(notifyData, reasonCode);
        if (!this.queueEvents)
          return;
        this.EnqueueEvent((object) new WlanClient.WlanInterface.WlanReasonNotificationData()
        {
          notifyData = notifyData,
          reasonCode = reasonCode
        });
      }

      internal void OnWlanNotification(Wlan.WlanNotificationData notifyData)
      {
        if (this.WlanNotification == null)
          return;
        this.WlanNotification(notifyData);
      }

      private void EnqueueEvent(object queuedEvent)
      {
        lock (this.eventQueue)
          this.eventQueue.Enqueue(queuedEvent);
        this.eventQueueFilled.Set();
      }

      public NetworkInterface NetworkInterface
      {
        get
        {
          foreach (NetworkInterface networkInterface in NetworkInterface.GetAllNetworkInterfaces())
          {
            if (new Guid(networkInterface.Id).Equals(this.info.interfaceGuid))
              return networkInterface;
          }
          return (NetworkInterface) null;
        }
      }

      public Guid InterfaceGuid => this.info.interfaceGuid;

      public string InterfaceDescription => this.info.interfaceDescription;

      public string InterfaceName => this.NetworkInterface.Name;

      public delegate void WlanNotificationEventHandler(Wlan.WlanNotificationData notifyData);

      public delegate void WlanConnectionNotificationEventHandler(
        Wlan.WlanNotificationData notifyData,
        Wlan.WlanConnectionNotificationData connNotifyData);

      public delegate void WlanReasonNotificationEventHandler(
        Wlan.WlanNotificationData notifyData,
        Wlan.WlanReasonCode reasonCode);

      private struct WlanConnectionNotificationEventData
      {
        public Wlan.WlanNotificationData notifyData;
        public Wlan.WlanConnectionNotificationData connNotifyData;
      }

      private struct WlanReasonNotificationData
      {
        public Wlan.WlanNotificationData notifyData;
        public Wlan.WlanReasonCode reasonCode;
      }
    }
  }
}
