// Decompiled with JetBrains decompiler
// Type: ExamCookie.WinClient.ExamApiV3Service.GetExamInformationResponse
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
  [MessageContract(WrapperName = "GetExamInformationResponse", WrapperNamespace = "http://tempuri.org/", IsWrapped = true)]
  public class GetExamInformationResponse
  {
    [MessageBodyMember(Namespace = "http://tempuri.org/", Order = 0)]
    public int GetExamInformationResult;
    [MessageBodyMember(Namespace = "http://tempuri.org/", Order = 1)]
    public string information;

    public GetExamInformationResponse()
    {
    }

    public GetExamInformationResponse(int GetExamInformationResult, string information)
    {
      this.GetExamInformationResult = GetExamInformationResult;
      this.information = information;
    }
  }
}
