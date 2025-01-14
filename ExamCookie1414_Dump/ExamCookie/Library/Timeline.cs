// Decompiled with JetBrains decompiler
// Type: ExamCookie.Library.Timeline
// Assembly: ExamCookie.WinClient, Version=1.4.1.4, Culture=neutral, PublicKeyToken=null
// MVID: E12BE1F8-B6E0-4BF5-B308-166F0E938C4B
// Assembly location: C:\Users\oskar\Downloads\ExamCookie1414.WinClient.exe

using System;

#nullable disable
namespace ExamCookie.Library
{
  [Serializable]
  public class Timeline
  {
    public int StudentId;
    public int ItemId;
    public eEventType ItemType;
    public int ItemSubType;
    public string TimeList;

    public Timeline()
    {
      this.StudentId = 0;
      this.ItemId = 0;
      this.ItemType = eEventType.NONE;
      this.ItemSubType = 0;
      this.TimeList = "";
    }

    public Timeline(
      int studentId,
      int itemId,
      eEventType itemType,
      int itemSubType,
      string timeList)
    {
      this.StudentId = 0;
      this.ItemId = 0;
      this.ItemType = eEventType.NONE;
      this.ItemSubType = 0;
      this.TimeList = "";
      this.StudentId = studentId;
      this.ItemId = itemId;
      this.ItemType = itemType;
      this.ItemSubType = itemSubType;
      this.TimeList = timeList;
    }
  }
}
