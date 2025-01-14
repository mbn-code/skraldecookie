// Decompiled with JetBrains decompiler
// Type: ExamCookie.Library.Student
// Assembly: ExamCookie.WinClient, Version=1.4.1.4, Culture=neutral, PublicKeyToken=null
// MVID: E12BE1F8-B6E0-4BF5-B308-166F0E938C4B
// Assembly location: C:\Users\oskar\Downloads\ExamCookie1414.WinClient.exe

using System;

#nullable disable
namespace ExamCookie.Library
{
  [Serializable]
  public class Student
  {
    public int Id;
    public int SiteId;
    public string Name;
    public string Classname;
    public string[] Teams;
    public string Username;
    public string Password;
    public int TimeExt;
    public DateTime Updated;
    public string Email;

    public Student()
    {
      this.Id = 0;
      this.SiteId = 0;
      this.Name = "";
      this.Classname = "";
      this.Teams = (string[]) null;
      this.Username = "";
      this.Password = "";
      this.TimeExt = 0;
      this.Updated = DateTime.MinValue;
      this.Email = "";
    }

    public Student(int id, string username, string password)
    {
      this.Id = 0;
      this.SiteId = 0;
      this.Name = "";
      this.Classname = "";
      this.Teams = (string[]) null;
      this.Username = "";
      this.Password = "";
      this.TimeExt = 0;
      this.Updated = DateTime.MinValue;
      this.Email = "";
      this.Id = id;
      this.Username = username;
      this.Password = password;
    }

    public Student(
      int id,
      string classname,
      string[] teams,
      string name,
      string username,
      string password)
    {
      this.Id = 0;
      this.SiteId = 0;
      this.Name = "";
      this.Classname = "";
      this.Teams = (string[]) null;
      this.Username = "";
      this.Password = "";
      this.TimeExt = 0;
      this.Updated = DateTime.MinValue;
      this.Email = "";
      this.Id = id;
      this.Classname = classname;
      this.Teams = teams;
      this.Name = name;
      this.Username = username;
      this.Password = password;
    }
  }
}
