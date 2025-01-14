// Decompiled with JetBrains decompiler
// Type: ExamCookie.WinClient.ExamApiV3Service.GetExamInformationRequest
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
  [MessageContract(WrapperName = "GetExamInformation", WrapperNamespace = "http://tempuri.org/", IsWrapped = true)]
  public class GetExamInformationRequest
  {
    [MessageBodyMember(Namespace = "http://tempuri.org/", Order = 0)]
    public string token;
    [MessageBodyMember(Namespace = "http://tempuri.org/", Order = 1)]
    public string information;

    public GetExamInformationRequest()
    {
    }

    public GetExamInformationRequest(string token, string information)
    {
      this.token = token;
      this.information = information;
    }
  }
}
