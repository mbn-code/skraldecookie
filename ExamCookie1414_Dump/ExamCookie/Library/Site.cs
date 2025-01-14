// Decompiled with JetBrains decompiler
// Type: ExamCookie.Library.Site
// Assembly: ExamCookie.WinClient, Version=1.4.1.4, Culture=neutral, PublicKeyToken=null
// MVID: E12BE1F8-B6E0-4BF5-B308-166F0E938C4B
// Assembly location: C:\Users\oskar\Downloads\ExamCookie1414.WinClient.exe

using System;

#nullable disable
namespace ExamCookie.Library
{
  [Serializable]
  public class Site
  {
    public int Id;
    public string Name;
    public string Address;
    public string ZipCode;
    public string City;
    public string Phone;

    public Site()
    {
      this.Id = 0;
      this.Name = "";
      this.Address = "";
      this.ZipCode = "";
      this.City = "";
      this.Phone = "";
    }

    public Site(int id, string name, string address, string zipCode, string city, string phone)
    {
      this.Id = 0;
      this.Name = "";
      this.Address = "";
      this.ZipCode = "";
      this.City = "";
      this.Phone = "";
      this.Id = id;
      this.Name = name;
      this.Address = address;
      this.ZipCode = zipCode;
      this.City = city;
      this.Phone = phone;
    }
  }
}
