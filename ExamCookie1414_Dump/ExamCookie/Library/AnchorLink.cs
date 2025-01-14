// Decompiled with JetBrains decompiler
// Type: ExamCookie.Library.AnchorLink
// Assembly: ExamCookie.WinClient, Version=1.4.1.4, Culture=neutral, PublicKeyToken=null
// MVID: E12BE1F8-B6E0-4BF5-B308-166F0E938C4B
// Assembly location: C:\Users\oskar\Downloads\ExamCookie1414.WinClient.exe

using System;
using System.Collections.Generic;
using System.Text;

#nullable disable
namespace ExamCookie.Library
{
  [Serializable]
  public class AnchorLink
  {
    public string Name;
    public List<Anchor> Anchors;

    public AnchorLink()
    {
      this.Name = "";
      this.Anchors = new List<Anchor>();
    }

    public AnchorLink(string name)
    {
      this.Name = "";
      this.Anchors = new List<Anchor>();
      this.Name = name;
    }

    public string ToHtml()
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.AppendFormat("{0}:", (object) this.Name);
      int num = checked (this.Anchors.Count - 1);
      int index = 0;
      while (index <= num)
      {
        stringBuilder.AppendFormat(" <a href='#{0}-{1}'>{2}</a>", (object) this.Anchors[index].Type.ToString(), (object) this.Anchors[index].Id, (object) checked (index + 1));
        checked { ++index; }
      }
      return stringBuilder.ToString();
    }
  }
}
