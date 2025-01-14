// Decompiled with JetBrains decompiler
// Type: ExamCookie.Library.Anchor
// Assembly: ExamCookie.WinClient, Version=1.4.1.4, Culture=neutral, PublicKeyToken=null
// MVID: E12BE1F8-B6E0-4BF5-B308-166F0E938C4B
// Assembly location: C:\Users\oskar\Downloads\ExamCookie1414.WinClient.exe

using System;

#nullable disable
namespace ExamCookie.Library
{
  [Serializable]
  public class Anchor
  {
    public int Id;
    public eReportSource Type;

    public Anchor()
    {
      this.Id = 0;
      this.Type = eReportSource.NONE;
    }

    public Anchor(int id, eReportSource type)
    {
      this.Id = 0;
      this.Type = eReportSource.NONE;
      this.Id = id;
      this.Type = type;
    }
  }
}
