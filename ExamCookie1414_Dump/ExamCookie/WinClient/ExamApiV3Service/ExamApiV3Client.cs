// Decompiled with JetBrains decompiler
// Type: ExamCookie.WinClient.ExamApiV3Service.ExamApiV3Client
// Assembly: ExamCookie.WinClient, Version=1.4.1.4, Culture=neutral, PublicKeyToken=null
// MVID: E12BE1F8-B6E0-4BF5-B308-166F0E938C4B
// Assembly location: C:\Users\oskar\Downloads\ExamCookie1414.WinClient.exe

using ExamCookie.Library;
using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Threading.Tasks;

#nullable disable
namespace ExamCookie.WinClient.ExamApiV3Service
{
  [DebuggerStepThrough]
  [GeneratedCode("System.ServiceModel", "4.0.0.0")]
  public class ExamApiV3Client : ClientBase<IExamApiV3>, IExamApiV3
  {
    public ExamApiV3Client()
    {
    }

    public ExamApiV3Client(string endpointConfigurationName)
      : base(endpointConfigurationName)
    {
    }

    public ExamApiV3Client(string endpointConfigurationName, string remoteAddress)
      : base(endpointConfigurationName, remoteAddress)
    {
    }

    public ExamApiV3Client(string endpointConfigurationName, EndpointAddress remoteAddress)
      : base(endpointConfigurationName, remoteAddress)
    {
    }

    public ExamApiV3Client(Binding binding, EndpointAddress remoteAddress)
      : base(binding, remoteAddress)
    {
    }

    public int AddImage(byte[] data) => this.Channel.AddImage(data);

    public Task<int> AddImageAsync(byte[] data) => this.Channel.AddImageAsync(data);

    public string GetWebLoginUrl(eWebLoginType type, string redirectUrl)
    {
      return this.Channel.GetWebLoginUrl(type, redirectUrl);
    }

    public Task<string> GetWebLoginUrlAsync(eWebLoginType type, string redirectUrl)
    {
      return this.Channel.GetWebLoginUrlAsync(type, redirectUrl);
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    public EchoResponse ExamApiV3Service_IExamApiV3_Echo(EchoRequest request)
    {
      return this.Channel.Echo(request);
    }

    public int Echo(string text, ref string result)
    {
      EchoResponse echoResponse = ((IExamApiV3) this).Echo(new EchoRequest()
      {
        text = text,
        result = result
      });
      result = echoResponse.result;
      return echoResponse.EchoResult;
    }

    public Task<EchoResponse> EchoAsync(EchoRequest request) => this.Channel.EchoAsync(request);

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    public GetRequirementsResponse ExamApiV3Service_IExamApiV3_GetRequirements(
      GetRequirementsRequest request)
    {
      return this.Channel.GetRequirements(request);
    }

    public int GetRequirements(eClientType type, ref string requirements)
    {
      GetRequirementsResponse requirements1 = ((IExamApiV3) this).GetRequirements(new GetRequirementsRequest()
      {
        type = type,
        requirements = requirements
      });
      requirements = requirements1.requirements;
      return requirements1.GetRequirementsResult;
    }

    public Task<GetRequirementsResponse> GetRequirementsAsync(GetRequirementsRequest request)
    {
      return this.Channel.GetRequirementsAsync(request);
    }

    public int CheckVersion(string version, eClientType type)
    {
      return this.Channel.CheckVersion(version, type);
    }

    public Task<int> CheckVersionAsync(string version, eClientType type)
    {
      return this.Channel.CheckVersionAsync(version, type);
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    public SignInResponse ExamApiV3Service_IExamApiV3_SignIn(SignInRequest request)
    {
      return this.Channel.SignIn(request);
    }

    public int SignIn(
      string code,
      string username,
      string password,
      string parameterIn,
      ref string parameterOut)
    {
      SignInResponse signInResponse = ((IExamApiV3) this).SignIn(new SignInRequest()
      {
        code = code,
        username = username,
        password = password,
        parameterIn = parameterIn,
        parameterOut = parameterOut
      });
      parameterOut = signInResponse.parameterOut;
      return signInResponse.SignInResult;
    }

    public Task<SignInResponse> SignInAsync(SignInRequest request)
    {
      return this.Channel.SignInAsync(request);
    }

    public int SignOut(string token, eSignOutMethod state, string metadata)
    {
      return this.Channel.SignOut(token, state, metadata);
    }

    public Task<int> SignOutAsync(string token, eSignOutMethod state, string metadata)
    {
      return this.Channel.SignOutAsync(token, state, metadata);
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    public HeartBeatResponse ExamApiV3Service_IExamApiV3_HeartBeat(HeartBeatRequest request)
    {
      return this.Channel.HeartBeat(request);
    }

    public int HeartBeat(string token, ref DateTime currentTime)
    {
      HeartBeatResponse heartBeatResponse = ((IExamApiV3) this).HeartBeat(new HeartBeatRequest()
      {
        token = token,
        currentTime = currentTime
      });
      currentTime = heartBeatResponse.currentTime;
      return heartBeatResponse.HeartBeatResult;
    }

    public Task<HeartBeatResponse> HeartBeatAsync(HeartBeatRequest request)
    {
      return this.Channel.HeartBeatAsync(request);
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    public GetExamInformationResponse ExamApiV3Service_IExamApiV3_GetExamInformation(
      GetExamInformationRequest request)
    {
      return this.Channel.GetExamInformation(request);
    }

    public int GetExamInformation(string token, ref string information)
    {
      GetExamInformationResponse examInformation = ((IExamApiV3) this).GetExamInformation(new GetExamInformationRequest()
      {
        token = token,
        information = information
      });
      information = examInformation.information;
      return examInformation.GetExamInformationResult;
    }

    public Task<GetExamInformationResponse> GetExamInformationAsync(
      GetExamInformationRequest request)
    {
      return this.Channel.GetExamInformationAsync(request);
    }

    public int AddScreenShot(string token, DateTime timeStamp, int screenNumber, byte[] data)
    {
      return this.Channel.AddScreenShot(token, timeStamp, screenNumber, data);
    }

    public Task<int> AddScreenShotAsync(
      string token,
      DateTime timeStamp,
      int screenNumber,
      byte[] data)
    {
      return this.Channel.AddScreenShotAsync(token, timeStamp, screenNumber, data);
    }

    public int AddClipboard(string token, DateTime timeStamp, eDataFormat format, byte[] data)
    {
      return this.Channel.AddClipboard(token, timeStamp, format, data);
    }

    public Task<int> AddClipboardAsync(
      string token,
      DateTime timeStamp,
      eDataFormat format,
      byte[] data)
    {
      return this.Channel.AddClipboardAsync(token, timeStamp, format, data);
    }

    public int AddFrontApp(
      string token,
      DateTime timeStamp,
      eApplicationType type,
      string name,
      string document,
      int deniedBrowserType)
    {
      return this.Channel.AddFrontApp(token, timeStamp, type, name, document, deniedBrowserType);
    }

    public Task<int> AddFrontAppAsync(
      string token,
      DateTime timeStamp,
      eApplicationType type,
      string name,
      string document,
      int deniedBrowserType)
    {
      return this.Channel.AddFrontAppAsync(token, timeStamp, type, name, document, deniedBrowserType);
    }

    public int AddAdapter(string token, DateTime timeStamp, string data)
    {
      return this.Channel.AddAdapter(token, timeStamp, data);
    }

    public Task<int> AddAdapterAsync(string token, DateTime timeStamp, string data)
    {
      return this.Channel.AddAdapterAsync(token, timeStamp, data);
    }

    public int AddProcess(string token, DateTime timeStamp, string data)
    {
      return this.Channel.AddProcess(token, timeStamp, data);
    }

    public Task<int> AddProcessAsync(string token, DateTime timeStamp, string data)
    {
      return this.Channel.AddProcessAsync(token, timeStamp, data);
    }

    public int SaveSessionLog(string token, byte[] data)
    {
      return this.Channel.SaveSessionLog(token, data);
    }

    public Task<int> SaveSessionLogAsync(string token, byte[] data)
    {
      return this.Channel.SaveSessionLogAsync(token, data);
    }
  }
}
