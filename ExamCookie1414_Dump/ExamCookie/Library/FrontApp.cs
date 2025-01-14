// Decompiled with JetBrains decompiler
// Type: ExamCookie.Library.FrontApp
// Assembly: ExamCookie.WinClient, Version=1.4.1.4, Culture=neutral, PublicKeyToken=null
// MVID: E12BE1F8-B6E0-4BF5-B308-166F0E938C4B
// Assembly location: C:\Users\oskar\Downloads\ExamCookie1414.WinClient.exe

using System;

#nullable disable
namespace ExamCookie.Library
{
  [Serializable]
  public class FrontApp
  {
    public int SignInId;
    public DateTime TimeStamp;
    public eApplicationType Type;
    public string Name;
    public string Document;

    public FrontApp()
    {
      this.SignInId = 0;
      this.TimeStamp = DateTime.MinValue;
      this.Type = eApplicationType.APPLICATION;
      this.Name = "";
      this.Document = "";
    }

    public FrontApp(
      int signInId,
      DateTime timeStamp,
      eApplicationType type,
      string name,
      string document)
    {
      this.SignInId = 0;
      this.TimeStamp = DateTime.MinValue;
      this.Type = eApplicationType.APPLICATION;
      this.Name = "";
      this.Document = "";
      this.SignInId = signInId;
      this.TimeStamp = timeStamp;
      this.Type = type;
      this.Name = name;
      this.Document = document;
    }
  }
}
