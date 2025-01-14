// Decompiled with JetBrains decompiler
// Type: ExamCookie.WinClient.ExamApiV3Service.IExamApiV3
// Assembly: ExamCookie.WinClient, Version=1.4.1.4, Culture=neutral, PublicKeyToken=null
// MVID: E12BE1F8-B6E0-4BF5-B308-166F0E938C4B
// Assembly location: C:\Users\oskar\Downloads\ExamCookie1414.WinClient.exe

using ExamCookie.Library;
using System;
using System.CodeDom.Compiler;
using System.ServiceModel;
using System.Threading.Tasks;

#nullable disable
namespace ExamCookie.WinClient.ExamApiV3Service
{
  [GeneratedCode("System.ServiceModel", "4.0.0.0")]
  [ServiceContract(ConfigurationName = "ExamApiV3Service.IExamApiV3")]
  public interface IExamApiV3
  {
    [OperationContract(Action = "http://tempuri.org/IExamApiV3/AddImage", ReplyAction = "http://tempuri.org/IExamApiV3/AddImageResponse")]
    int AddImage(byte[] data);

    [OperationContract(Action = "http://tempuri.org/IExamApiV3/AddImage", ReplyAction = "http://tempuri.org/IExamApiV3/AddImageResponse")]
    Task<int> AddImageAsync(byte[] data);

    [OperationContract(Action = "http://tempuri.org/IExamApiV3/GetWebLoginUrl", ReplyAction = "http://tempuri.org/IExamApiV3/GetWebLoginUrlResponse")]
    string GetWebLoginUrl(eWebLoginType type, string redirectUrl);

    [OperationContract(Action = "http://tempuri.org/IExamApiV3/GetWebLoginUrl", ReplyAction = "http://tempuri.org/IExamApiV3/GetWebLoginUrlResponse")]
    Task<string> GetWebLoginUrlAsync(eWebLoginType type, string redirectUrl);

    [OperationContract(Action = "http://tempuri.org/IExamApiV3/Echo", ReplyAction = "http://tempuri.org/IExamApiV3/EchoResponse")]
    EchoResponse Echo(EchoRequest request);

    [OperationContract(Action = "http://tempuri.org/IExamApiV3/Echo", ReplyAction = "http://tempuri.org/IExamApiV3/EchoResponse")]
    Task<EchoResponse> EchoAsync(EchoRequest request);

    [OperationContract(Action = "http://tempuri.org/IExamApiV3/GetRequirements", ReplyAction = "http://tempuri.org/IExamApiV3/GetRequirementsResponse")]
    GetRequirementsResponse GetRequirements(GetRequirementsRequest request);

    [OperationContract(Action = "http://tempuri.org/IExamApiV3/GetRequirements", ReplyAction = "http://tempuri.org/IExamApiV3/GetRequirementsResponse")]
    Task<GetRequirementsResponse> GetRequirementsAsync(GetRequirementsRequest request);

    [OperationContract(Action = "http://tempuri.org/IExamApiV3/CheckVersion", ReplyAction = "http://tempuri.org/IExamApiV3/CheckVersionResponse")]
    int CheckVersion(string version, eClientType type);

    [OperationContract(Action = "http://tempuri.org/IExamApiV3/CheckVersion", ReplyAction = "http://tempuri.org/IExamApiV3/CheckVersionResponse")]
    Task<int> CheckVersionAsync(string version, eClientType type);

    [OperationContract(Action = "http://tempuri.org/IExamApiV3/SignIn", ReplyAction = "http://tempuri.org/IExamApiV3/SignInResponse")]
    SignInResponse SignIn(SignInRequest request);

    [OperationContract(Action = "http://tempuri.org/IExamApiV3/SignIn", ReplyAction = "http://tempuri.org/IExamApiV3/SignInResponse")]
    Task<SignInResponse> SignInAsync(SignInRequest request);

    [OperationContract(Action = "http://tempuri.org/IExamApiV3/SignOut", ReplyAction = "http://tempuri.org/IExamApiV3/SignOutResponse")]
    int SignOut(string token, eSignOutMethod state, string metadata);

    [OperationContract(Action = "http://tempuri.org/IExamApiV3/SignOut", ReplyAction = "http://tempuri.org/IExamApiV3/SignOutResponse")]
    Task<int> SignOutAsync(string token, eSignOutMethod state, string metadata);

    [OperationContract(Action = "http://tempuri.org/IExamApiV3/HeartBeat", ReplyAction = "http://tempuri.org/IExamApiV3/HeartBeatResponse")]
    HeartBeatResponse HeartBeat(HeartBeatRequest request);

    [OperationContract(Action = "http://tempuri.org/IExamApiV3/HeartBeat", ReplyAction = "http://tempuri.org/IExamApiV3/HeartBeatResponse")]
    Task<HeartBeatResponse> HeartBeatAsync(HeartBeatRequest request);

    [OperationContract(Action = "http://tempuri.org/IExamApiV3/GetExamInformation", ReplyAction = "http://tempuri.org/IExamApiV3/GetExamInformationResponse")]
    GetExamInformationResponse GetExamInformation(GetExamInformationRequest request);

    [OperationContract(Action = "http://tempuri.org/IExamApiV3/GetExamInformation", ReplyAction = "http://tempuri.org/IExamApiV3/GetExamInformationResponse")]
    Task<GetExamInformationResponse> GetExamInformationAsync(GetExamInformationRequest request);

    [OperationContract(Action = "http://tempuri.org/IExamApiV3/AddScreenShot", ReplyAction = "http://tempuri.org/IExamApiV3/AddScreenShotResponse")]
    int AddScreenShot(string token, DateTime timeStamp, int screenNumber, byte[] data);

    [OperationContract(Action = "http://tempuri.org/IExamApiV3/AddScreenShot", ReplyAction = "http://tempuri.org/IExamApiV3/AddScreenShotResponse")]
    Task<int> AddScreenShotAsync(string token, DateTime timeStamp, int screenNumber, byte[] data);

    [OperationContract(Action = "http://tempuri.org/IExamApiV3/AddClipboard", ReplyAction = "http://tempuri.org/IExamApiV3/AddClipboardResponse")]
    int AddClipboard(string token, DateTime timeStamp, eDataFormat format, byte[] data);

    [OperationContract(Action = "http://tempuri.org/IExamApiV3/AddClipboard", ReplyAction = "http://tempuri.org/IExamApiV3/AddClipboardResponse")]
    Task<int> AddClipboardAsync(string token, DateTime timeStamp, eDataFormat format, byte[] data);

    [OperationContract(Action = "http://tempuri.org/IExamApiV3/AddFrontApp", ReplyAction = "http://tempuri.org/IExamApiV3/AddFrontAppResponse")]
    int AddFrontApp(
      string token,
      DateTime timeStamp,
      eApplicationType type,
      string name,
      string document,
      int deniedBrowserType);

    [OperationContract(Action = "http://tempuri.org/IExamApiV3/AddFrontApp", ReplyAction = "http://tempuri.org/IExamApiV3/AddFrontAppResponse")]
    Task<int> AddFrontAppAsync(
      string token,
      DateTime timeStamp,
      eApplicationType type,
      string name,
      string document,
      int deniedBrowserType);

    [OperationContract(Action = "http://tempuri.org/IExamApiV3/AddAdapter", ReplyAction = "http://tempuri.org/IExamApiV3/AddAdapterResponse")]
    int AddAdapter(string token, DateTime timeStamp, string data);

    [OperationContract(Action = "http://tempuri.org/IExamApiV3/AddAdapter", ReplyAction = "http://tempuri.org/IExamApiV3/AddAdapterResponse")]
    Task<int> AddAdapterAsync(string token, DateTime timeStamp, string data);

    [OperationContract(Action = "http://tempuri.org/IExamApiV3/AddProcess", ReplyAction = "http://tempuri.org/IExamApiV3/AddProcessResponse")]
    int AddProcess(string token, DateTime timeStamp, string data);

    [OperationContract(Action = "http://tempuri.org/IExamApiV3/AddProcess", ReplyAction = "http://tempuri.org/IExamApiV3/AddProcessResponse")]
    Task<int> AddProcessAsync(string token, DateTime timeStamp, string data);

    [OperationContract(Action = "http://tempuri.org/IExamApiV3/SaveSessionLog", ReplyAction = "http://tempuri.org/IExamApiV3/SaveSessionLogResponse")]
    int SaveSessionLog(string token, byte[] data);

    [OperationContract(Action = "http://tempuri.org/IExamApiV3/SaveSessionLog", ReplyAction = "http://tempuri.org/IExamApiV3/SaveSessionLogResponse")]
    Task<int> SaveSessionLogAsync(string token, byte[] data);
  }
}
