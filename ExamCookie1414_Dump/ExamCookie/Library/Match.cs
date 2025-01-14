// Decompiled with JetBrains decompiler
// Type: ExamCookie.Library.Match
// Assembly: ExamCookie.WinClient, Version=1.4.1.4, Culture=neutral, PublicKeyToken=null
// MVID: E12BE1F8-B6E0-4BF5-B308-166F0E938C4B
// Assembly location: C:\Users\oskar\Downloads\ExamCookie1414.WinClient.exe

using System;
using System.Collections.Generic;

#nullable disable
namespace ExamCookie.Library
{
  [Serializable]
  public class Match
  {
    public int Id;
    public eReportSource Type;
    public List<string> Search;
    public string Text;
    public bool Found;

    public Match()
    {
      this.Id = 0;
      this.Type = eReportSource.NONE;
      this.Search = new List<string>();
      this.Text = "";
      this.Found = false;
    }

    public Match(int id, eReportSource type, string[] search, string text)
    {
      this.Id = 0;
      this.Type = eReportSource.NONE;
      this.Search = new List<string>();
      this.Text = "";
      this.Found = false;
      this.Id = id;
      this.Type = type;
      this.Search.AddRange((IEnumerable<string>) search);
      this.Text = text;
    }
  }
}
