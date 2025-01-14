// Decompiled with JetBrains decompiler
// Type: ExamCookie.WinClient.AdapterThread
// Assembly: ExamCookie.WinClient, Version=1.4.1.4, Culture=neutral, PublicKeyToken=null
// MVID: E12BE1F8-B6E0-4BF5-B308-166F0E938C4B
// Assembly location: C:\Users\oskar\Downloads\ExamCookie1414.WinClient.exe

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using NativeWifi;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;

#nullable disable
namespace ExamCookie.WinClient
{
  public class AdapterThread
  {
    private const int THREAD_SLEEP = 500;
    private bool _Started;

    public event AdapterThread.OnAdapterChangedEventHandler OnAdapterChanged;

    public event AdapterThread.OnDebugEventHandler OnDebug;

    public event AdapterThread.OnExceptionEventHandler OnException;

    public AdapterThread() => this._Started = false;

    public AdapterThread(int polltime)
    {
      AdapterThread adapterThread = this;
      this._Started = false;
      if (polltime <= 0)
        return;
      if (polltime < 500)
        polltime = 500;
      Thread thread = new Thread((ThreadStart) ([SpecialName] () => adapterThread.Main(polltime)));
      this.Started = true;
      thread.Start();
    }

    public bool Started
    {
      get => this._Started;
      set => this._Started = value;
    }

    private void Main(int polltime)
    {
      Stopwatch stopwatch = new Stopwatch();
      stopwatch.Start();
      Dictionary<string, string> dictionary1 = new Dictionary<string, string>();
      List<string> stringList = new List<string>();
      while (this.Started)
      {
        try
        {
          if (stopwatch.ElapsedMilliseconds >= (long) polltime)
          {
            stopwatch.Restart();
            stringList.Clear();
            if (dictionary1.Count == 0)
            {
              dictionary1 = this.IpConfig();
              try
              {
                foreach (KeyValuePair<string, string> keyValuePair in dictionary1)
                  stringList.Add(keyValuePair.Value);
              }
              finally
              {
                Dictionary<string, string>.Enumerator enumerator;
                enumerator.Dispose();
              }
            }
            else
            {
              Dictionary<string, string> dictionary2 = this.IpConfig();
              try
              {
                foreach (KeyValuePair<string, string> keyValuePair in dictionary2)
                {
                  if (dictionary1.ContainsKey(keyValuePair.Key))
                  {
                    if (Operators.CompareString(dictionary1[keyValuePair.Key], keyValuePair.Value, false) != 0)
                      stringList.Add(keyValuePair.Value);
                  }
                  else
                    stringList.Add(keyValuePair.Value);
                }
              }
              finally
              {
                Dictionary<string, string>.Enumerator enumerator;
                enumerator.Dispose();
              }
              dictionary1.Clear();
              try
              {
                foreach (KeyValuePair<string, string> keyValuePair in dictionary2)
                  dictionary1.Add(keyValuePair.Key, keyValuePair.Value);
              }
              finally
              {
                Dictionary<string, string>.Enumerator enumerator;
                enumerator.Dispose();
              }
            }
            if (stringList.Count > 0)
            {
              // ISSUE: reference to a compiler-generated field
              AdapterThread.OnAdapterChangedEventHandler adapterChangedEvent = this.OnAdapterChangedEvent;
              if (adapterChangedEvent != null)
                adapterChangedEvent(new AdapterThread.AdapterChanged(Strings.Join(stringList.ToArray(), "|") + "\r\n"));
            }
          }
        }
        catch (Exception ex1)
        {
          ProjectData.SetProjectError(ex1);
          Exception ex2 = ex1;
          // ISSUE: reference to a compiler-generated field
          AdapterThread.OnExceptionEventHandler onExceptionEvent = this.OnExceptionEvent;
          if (onExceptionEvent != null)
            onExceptionEvent(ex2);
          ProjectData.ClearProjectError();
        }
        finally
        {
          Thread.Sleep(500);
        }
      }
    }

    public Dictionary<string, string> IpConfig()
    {
      Dictionary<string, string> dictionary1;
      try
      {
        StringBuilder stringBuilder = new StringBuilder();
        List<string> stringList = new List<string>();
        Dictionary<string, string> dictionary2 = new Dictionary<string, string>();
        NetworkInterface[] networkInterfaces = NetworkInterface.GetAllNetworkInterfaces();
        int index1 = 0;
        while (index1 < networkInterfaces.Length)
        {
          NetworkInterface networkInterface = networkInterfaces[index1];
          try
          {
            IPInterfaceProperties ipProperties = networkInterface.GetIPProperties();
            stringBuilder.AppendLineFormat("{0}:", (object) networkInterface.Description);
            stringBuilder.AppendLine();
            stringBuilder.AppendLineFormat("   OperationalStatus ........ : {0}", (object) networkInterface.OperationalStatus.ToString());
            if (networkInterface.OperationalStatus == OperationalStatus.Up)
            {
              string ssid = "";
              if (this.GetSSID(networkInterface.Description, ref ssid) == 0)
                stringBuilder.AppendLineFormat("   SSID ..................... : {0}", (object) ssid);
              stringBuilder.AppendLineFormat("   PhysicalMACAddress ....... : {0}", (object) Module1.ToMACAddress(networkInterface.GetPhysicalAddress().GetAddressBytes()));
              try
              {
                foreach (IPAddressInformation unicastAddress in networkInterface.GetIPProperties().UnicastAddresses)
                  stringBuilder.AppendLineFormat("   {0} ............. : {1}", Interaction.IIf(unicastAddress.Address.ToString().Contains("::"), (object) "IPv6 Address", (object) "IP-Address  "), (object) unicastAddress.Address.ToString());
              }
              finally
              {
                IEnumerator<UnicastIPAddressInformation> enumerator;
                enumerator?.Dispose();
              }
              stringBuilder.AppendLineFormat("   DHCP enabled ............. : {0}", (object) ipProperties.GetIPv4Properties().IsDhcpEnabled);
              if (ipProperties.DhcpServerAddresses.Count > 0)
              {
                stringList.Clear();
                int num = checked (ipProperties.DhcpServerAddresses.Count - 1);
                int index2 = 0;
                while (index2 <= num)
                {
                  stringList.Add(ipProperties.DhcpServerAddresses[index2].ToString());
                  checked { ++index2; }
                }
                stringBuilder.AppendLineFormat("   DHCP servers ............. : {0}", (object) Strings.Join(stringList.ToArray(), ", "));
              }
              if (ipProperties.GatewayAddresses.Count > 0)
              {
                stringList.Clear();
                int num = checked (ipProperties.GatewayAddresses.Count - 1);
                int index3 = 0;
                while (index3 <= num)
                {
                  stringList.Add(ipProperties.GatewayAddresses[index3].Address.ToString());
                  checked { ++index3; }
                }
                stringBuilder.AppendLineFormat("   Default Gateway .......... : {0}", (object) Strings.Join(stringList.ToArray(), ", "));
              }
              stringBuilder.AppendLineFormat("   DNS enabled .............. : {0}", (object) ipProperties.IsDnsEnabled);
              stringBuilder.AppendLineFormat("   Dynamically configured DNS : {0}", (object) ipProperties.IsDynamicDnsEnabled);
            }
            dictionary2.Add(networkInterface.Id, stringBuilder.ToString());
            stringBuilder.Clear();
          }
          catch (Exception ex1)
          {
            ProjectData.SetProjectError(ex1);
            Exception ex2 = ex1;
            // ISSUE: reference to a compiler-generated field
            AdapterThread.OnExceptionEventHandler onExceptionEvent = this.OnExceptionEvent;
            if (onExceptionEvent != null)
              onExceptionEvent(ex2);
            ProjectData.ClearProjectError();
          }
          checked { ++index1; }
        }
        dictionary1 = dictionary2;
      }
      catch (Exception ex3)
      {
        ProjectData.SetProjectError(ex3);
        Exception ex4 = ex3;
        // ISSUE: reference to a compiler-generated field
        AdapterThread.OnExceptionEventHandler onExceptionEvent = this.OnExceptionEvent;
        if (onExceptionEvent != null)
          onExceptionEvent(ex4);
        dictionary1 = (Dictionary<string, string>) null;
        ProjectData.ClearProjectError();
      }
      return dictionary1;
    }

    private int GetSSID(string description, ref string ssid)
    {
      int ssid1;
      try
      {
        WlanClient.WlanInterface[] interfaces = new WlanClient().Interfaces;
        int index = 0;
        while (index < interfaces.Length)
        {
          WlanClient.WlanInterface wlanInterface = interfaces[index];
          if (wlanInterface != null && wlanInterface.InterfaceState == Wlan.WlanInterfaceState.Connected)
          {
            Wlan.Dot11Ssid dot11Ssid = wlanInterface.CurrentConnection.wlanAssociationAttributes.dot11Ssid;
            if (wlanInterface.NetworkInterface != null && wlanInterface.NetworkInterface.NetworkInterfaceType == NetworkInterfaceType.Wireless80211)
            {
              ssid = new string(Encoding.ASCII.GetChars(dot11Ssid.SSID, 0, checked ((int) dot11Ssid.SSIDLength)));
              ssid1 = 0;
              goto label_9;
            }
          }
          checked { ++index; }
        }
        ssid1 = 1;
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        ssid1 = -1;
        ProjectData.ClearProjectError();
      }
label_9:
      return ssid1;
    }

    public delegate void OnAdapterChangedEventHandler(AdapterThread.AdapterChanged sender);

    public delegate void OnDebugEventHandler(string message);

    public delegate void OnExceptionEventHandler(Exception ex);

    [Serializable]
    public class AdapterChanged
    {
      public string Reference;
      public string Token;
      public DateTime CanSend;
      public DateTime TimeStamp;
      public string Data;

      public AdapterChanged()
      {
        this.Reference = Guid.NewGuid().ToString();
        this.Token = "";
        this.CanSend = DateTime.MinValue;
        this.TimeStamp = DateTime.MinValue;
        this.Data = "";
      }

      public AdapterChanged(string data)
      {
        this.Reference = Guid.NewGuid().ToString();
        this.Token = "";
        this.CanSend = DateTime.MinValue;
        this.TimeStamp = DateTime.MinValue;
        this.Data = "";
        this.Data = data;
      }
    }
  }
}
