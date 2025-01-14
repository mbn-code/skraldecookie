// Decompiled with JetBrains decompiler
// Type: ExamCookie.WinClient.ExamApiV3Service.SignInRequest
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
  [MessageContract(WrapperName = "SignIn", WrapperNamespace = "http://tempuri.org/", IsWrapped = true)]
  public class SignInRequest
  {
    [MessageBodyMember(Namespace = "http://tempuri.org/", Order = 0)]
    public string code;
    [MessageBodyMember(Namespace = "http://tempuri.org/", Order = 1)]
    public string username;
    [MessageBodyMember(Namespace = "http://tempuri.org/", Order = 2)]
    public string password;
    [MessageBodyMember(Namespace = "http://tempuri.org/", Order = 3)]
    public string parameterIn;
    [MessageBodyMember(Namespace = "http://tempuri.org/", Order = 4)]
    public string parameterOut;

    public SignInRequest()
    {
    }

    public SignInRequest(
      string code,
      string username,
      string password,
      string parameterIn,
      string parameterOut)
    {
      this.code = code;
      this.username = username;
      this.password = password;
      this.parameterIn = parameterIn;
      this.parameterOut = parameterOut;
    }
  }
}
