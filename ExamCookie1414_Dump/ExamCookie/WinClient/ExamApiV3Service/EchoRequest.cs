// Decompiled with JetBrains decompiler
// Type: ExamCookie.WinClient.ExamApiV3Service.EchoRequest
// Assembly: ExamCookie.WinClient, Version=1.4.1.4, Culture=neutral, PublicKeyToken=null
// MVID: E12BE1F8-B6E0-4BF5-B308-166F0E938C4B
// Assembly location: C:\Users\oskar\Downloads\ExamCookie1414.WinClient.exe

using System.CodeDom.Compiler;
using System.Diagnostics;
using System.ServiceModel;

#nullable disable
namespace ExamCookie.WinClient.ExamApiV3Service
{
  [DebuggerStepThrough]
  [GeneratedCode("System.ServiceModel", "4.0.0.0")]
  [MessageContract(WrapperName = "Echo", WrapperNamespace = "http://tempuri.org/", IsWrapped = true)]
  public class EchoRequest
  {
    [MessageBodyMember(Namespace = "http://tempuri.org/", Order = 0)]
    public string text;
    [MessageBodyMember(Namespace = "http://tempuri.org/", Order = 1)]
    public string result;

    public EchoRequest()
    {
    }

    public EchoRequest(string text, string result)
    {
      this.text = text;
      this.result = result;
    }
  }
}
