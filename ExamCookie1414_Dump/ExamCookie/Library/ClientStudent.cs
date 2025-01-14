// Decompiled with JetBrains decompiler
// Type: ExamCookie.Library.ClientStudent
// Assembly: ExamCookie.WinClient, Version=1.4.1.4, Culture=neutral, PublicKeyToken=null
// MVID: E12BE1F8-B6E0-4BF5-B308-166F0E938C4B
// Assembly location: C:\Users\oskar\Downloads\ExamCookie1414.WinClient.exe

using System;

#nullable disable
namespace ExamCookie.Library
{
  [Serializable]
  public class ClientStudent
  {
    public string Name;
    public string Username;
    public string Classname;

    public ClientStudent()
    {
      this.Name = "";
      this.Username = "";
      this.Classname = "";
    }
  }
}
