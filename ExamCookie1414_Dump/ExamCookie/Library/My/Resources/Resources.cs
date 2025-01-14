// Decompiled with JetBrains decompiler
// Type: ExamCookie.Library.My.Resources.Resources
// Assembly: ExamCookie.WinClient, Version=1.4.1.4, Culture=neutral, PublicKeyToken=null
// MVID: E12BE1F8-B6E0-4BF5-B308-166F0E938C4B
// Assembly location: C:\Users\oskar\Downloads\ExamCookie1414.WinClient.exe

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

#nullable disable
namespace ExamCookie.Library.My.Resources
{
  [StandardModule]
  [GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
  [DebuggerNonUserCode]
  [CompilerGenerated]
  [HideModuleName]
  internal sealed class Resources
  {
    private static ResourceManager resourceMan;
    private static CultureInfo resourceCulture;

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static ResourceManager ResourceManager
    {
      get
      {
        if (object.ReferenceEquals((object) ExamCookie.Library.My.Resources.Resources.resourceMan, (object) null))
          ExamCookie.Library.My.Resources.Resources.resourceMan = new ResourceManager("ExamCookie.Library.Resources", typeof (ExamCookie.Library.My.Resources.Resources).Assembly);
        return ExamCookie.Library.My.Resources.Resources.resourceMan;
      }
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static CultureInfo Culture
    {
      get => ExamCookie.Library.My.Resources.Resources.resourceCulture;
      set => ExamCookie.Library.My.Resources.Resources.resourceCulture = value;
    }
  }
}
