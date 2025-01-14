// Decompiled with JetBrains decompiler
// Type: ExamCookie.Library.ParameterIn
// Assembly: ExamCookie.WinClient, Version=1.4.1.4, Culture=neutral, PublicKeyToken=null
// MVID: E12BE1F8-B6E0-4BF5-B308-166F0E938C4B
// Assembly location: C:\Users\oskar\Downloads\ExamCookie1414.WinClient.exe

using System;

#nullable disable
namespace ExamCookie.Library
{
  [Serializable]
  public class ParameterIn
  {
    public string OperatingSystem;
    public int Virtualized;
    public eClientType ClientType;
    public string ClientVersion;

    public ParameterIn()
    {
      this.OperatingSystem = "";
      this.Virtualized = 0;
      this.ClientType = eClientType.UNKNOWN;
      this.ClientVersion = "";
    }

    public ParameterIn(
      string operatingSystem,
      int virtualized,
      eClientType clientType,
      string clientVersion)
    {
      this.OperatingSystem = "";
      this.Virtualized = 0;
      this.ClientType = eClientType.UNKNOWN;
      this.ClientVersion = "";
      this.OperatingSystem = operatingSystem;
      this.Virtualized = virtualized;
      this.ClientType = clientType;
      this.ClientVersion = clientVersion;
    }
  }
}
