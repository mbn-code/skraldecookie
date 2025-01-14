// Decompiled with JetBrains decompiler
// Type: ExamCookie.Library.User
// Assembly: ExamCookie.WinClient, Version=1.4.1.4, Culture=neutral, PublicKeyToken=null
// MVID: E12BE1F8-B6E0-4BF5-B308-166F0E938C4B
// Assembly location: C:\Users\oskar\Downloads\ExamCookie1414.WinClient.exe

using System;

#nullable disable
namespace ExamCookie.Library
{
  [Serializable]
  public class User
  {
    public int Id;
    public int SiteId;
    public string Name;
    public string Username;
    public string Password;
    public eUserType TypeValue;
    public string Phone;

    public User()
    {
      this.Id = 0;
      this.SiteId = 0;
      this.Name = "";
      this.Username = "";
      this.Password = "";
      this.TypeValue = eUserType.STUDENT;
      this.Phone = "";
    }

    public User(
      int id,
      int siteId,
      string name,
      string username,
      string password,
      eUserType typeValue,
      string phone)
    {
      this.Id = 0;
      this.SiteId = 0;
      this.Name = "";
      this.Username = "";
      this.Password = "";
      this.TypeValue = eUserType.STUDENT;
      this.Phone = "";
      this.Id = id;
      this.SiteId = siteId;
      this.Name = name;
      this.Username = username;
      this.Password = password;
      this.TypeValue = typeValue;
      this.Phone = phone;
    }
  }
}
