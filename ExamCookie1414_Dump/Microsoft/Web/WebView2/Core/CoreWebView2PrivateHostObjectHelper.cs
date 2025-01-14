// Decompiled with JetBrains decompiler
// Type: Microsoft.Web.WebView2.Core.CoreWebView2PrivateHostObjectHelper
// Assembly: ExamCookie.WinClient, Version=1.4.1.4, Culture=neutral, PublicKeyToken=null
// MVID: E12BE1F8-B6E0-4BF5-B308-166F0E938C4B
// Assembly location: C:\Users\oskar\Downloads\ExamCookie1414.WinClient.exe

using Microsoft.Web.WebView2.Core.Raw;
using System;
using System.Reflection;
using System.Runtime.InteropServices;

#nullable disable
namespace Microsoft.Web.WebView2.Core
{
  internal class CoreWebView2PrivateHostObjectHelper
  {
    internal ICoreWebView2PrivateHostObjectHelper3 _nativeICoreWebView2PrivateHostObjectHelper3Value;
    internal ICoreWebView2PrivateHostObjectHelper2 _nativeICoreWebView2PrivateHostObjectHelper2Value;
    internal ICoreWebView2PrivateHostObjectHelper _nativeICoreWebView2PrivateHostObjectHelperValue;
    internal object _rawNative;

    internal CoreWebView2PrivateHostObjectHelper()
    {
      this._rawNative = (object) new CoreWebView2PrivateHostObjectHelper.RawHelper();
    }

    internal ICoreWebView2PrivateHostObjectHelper3 _nativeICoreWebView2PrivateHostObjectHelper3
    {
      get
      {
        if (this._nativeICoreWebView2PrivateHostObjectHelper3Value == null)
        {
          try
          {
            this._nativeICoreWebView2PrivateHostObjectHelper3Value = (ICoreWebView2PrivateHostObjectHelper3) this._rawNative;
          }
          catch (Exception ex)
          {
            throw new NotImplementedException("Unable to cast to Microsoft.Web.WebView2.Core.Raw.ICoreWebView2PrivateHostObjectHelper3.\nThis may happen if you are using an interface not supported by the version of the WebView2 Runtime you are using.\nFor instance, if you are using an experimental interface from an older SDK that has been modified or removed in a newer runtime.\nOr, if you are using a public interface from a newer SDK that wasn't implemented in an older runtime.\nFor more information about WebView2 versioning please visit the following: https://learn.microsoft.com/microsoft-edge/webview2/concepts/versioning", ex);
          }
        }
        return this._nativeICoreWebView2PrivateHostObjectHelper3Value;
      }
      set => this._nativeICoreWebView2PrivateHostObjectHelper3Value = value;
    }

    internal ICoreWebView2PrivateHostObjectHelper2 _nativeICoreWebView2PrivateHostObjectHelper2
    {
      get
      {
        if (this._nativeICoreWebView2PrivateHostObjectHelper2Value == null)
        {
          try
          {
            this._nativeICoreWebView2PrivateHostObjectHelper2Value = (ICoreWebView2PrivateHostObjectHelper2) this._rawNative;
          }
          catch (Exception ex)
          {
            throw new NotImplementedException("Unable to cast to Microsoft.Web.WebView2.Core.Raw.ICoreWebView2PrivateHostObjectHelper2.\nThis may happen if you are using an interface not supported by the version of the WebView2 Runtime you are using.\nFor instance, if you are using an experimental interface from an older SDK that has been modified or removed in a newer runtime.\nOr, if you are using a public interface from a newer SDK that wasn't implemented in an older runtime.\nFor more information about WebView2 versioning please visit the following: https://learn.microsoft.com/microsoft-edge/webview2/concepts/versioning", ex);
          }
        }
        return this._nativeICoreWebView2PrivateHostObjectHelper2Value;
      }
      set => this._nativeICoreWebView2PrivateHostObjectHelper2Value = value;
    }

    internal ICoreWebView2PrivateHostObjectHelper _nativeICoreWebView2PrivateHostObjectHelper
    {
      get
      {
        if (this._nativeICoreWebView2PrivateHostObjectHelperValue == null)
        {
          try
          {
            this._nativeICoreWebView2PrivateHostObjectHelperValue = (ICoreWebView2PrivateHostObjectHelper) this._rawNative;
          }
          catch (Exception ex)
          {
            throw new NotImplementedException("Unable to cast to Microsoft.Web.WebView2.Core.Raw.ICoreWebView2PrivateHostObjectHelper.\nThis may happen if you are using an interface not supported by the version of the WebView2 Runtime you are using.\nFor instance, if you are using an experimental interface from an older SDK that has been modified or removed in a newer runtime.\nOr, if you are using a public interface from a newer SDK that wasn't implemented in an older runtime.\nFor more information about WebView2 versioning please visit the following: https://learn.microsoft.com/microsoft-edge/webview2/concepts/versioning", ex);
          }
        }
        return this._nativeICoreWebView2PrivateHostObjectHelperValue;
      }
      set => this._nativeICoreWebView2PrivateHostObjectHelperValue = value;
    }

    internal CoreWebView2PrivateHostObjectHelper(object rawCoreWebView2PrivateHostObjectHelper)
    {
      this._rawNative = rawCoreWebView2PrivateHostObjectHelper;
    }

    internal object CreateBuiltInDispatch(object originalHostObject)
    {
      try
      {
        // ISSUE: variable of a compiler-generated type
        ICoreWebView2PrivateHostObjectHelper3 hostObjectHelper3 = this._nativeICoreWebView2PrivateHostObjectHelper3;
        object obj = originalHostObject;
        ref object local = ref obj;
        // ISSUE: reference to a compiler-generated method
        return hostObjectHelper3.CreateBuiltInDispatch(ref local);
      }
      catch (InvalidCastException ex)
      {
        if (ex.HResult == -2147467262)
          throw new InvalidOperationException("CoreWebView2 members can only be accessed from the UI thread.", (Exception) ex);
        throw ex;
      }
      catch (COMException ex)
      {
        if (ex.HResult == -2147019873)
          throw new InvalidOperationException("CoreWebView2 members cannot be accessed after the WebView2 control is disposed.", (Exception) ex);
        throw ex;
      }
    }

    internal int IsAsyncMethod(object rawObject, string methodName, int parameterCount)
    {
      try
      {
        // ISSUE: variable of a compiler-generated type
        ICoreWebView2PrivateHostObjectHelper2 hostObjectHelper2 = this._nativeICoreWebView2PrivateHostObjectHelper2;
        object obj = rawObject;
        ref object local = ref obj;
        string methodName1 = methodName;
        int parameterCount1 = parameterCount;
        // ISSUE: reference to a compiler-generated method
        return hostObjectHelper2.IsAsyncMethod(ref local, methodName1, parameterCount1);
      }
      catch (InvalidCastException ex)
      {
        if (ex.HResult == -2147467262)
          throw new InvalidOperationException("CoreWebView2 members can only be accessed from the UI thread.", (Exception) ex);
        throw ex;
      }
      catch (COMException ex)
      {
        if (ex.HResult == -2147019873)
          throw new InvalidOperationException("CoreWebView2 members cannot be accessed after the WebView2 control is disposed.", (Exception) ex);
        throw ex;
      }
    }

    internal void SetAsyncMethodContinuation(
      object rawObject,
      string methodName,
      int parameterCount,
      object methodResult,
      CoreWebView2PrivateHostObjectAsyncMethodContinuation continuation)
    {
      try
      {
        // ISSUE: variable of a compiler-generated type
        ICoreWebView2PrivateHostObjectHelper2 hostObjectHelper2 = this._nativeICoreWebView2PrivateHostObjectHelper2;
        object obj1 = rawObject;
        ref object local1 = ref obj1;
        string methodName1 = methodName;
        int parameterCount1 = parameterCount;
        object obj2 = methodResult;
        ref object local2 = ref obj2;
        // ISSUE: variable of a compiler-generated type
        ICoreWebView2PrivateHostObjectAsyncMethodContinuation methodContinuation = continuation._nativeICoreWebView2PrivateHostObjectAsyncMethodContinuation;
        // ISSUE: reference to a compiler-generated method
        hostObjectHelper2.SetAsyncMethodContinuation(ref local1, methodName1, parameterCount1, ref local2, methodContinuation);
      }
      catch (InvalidCastException ex)
      {
        if (ex.HResult == -2147467262)
          throw new InvalidOperationException("CoreWebView2 members can only be accessed from the UI thread.", (Exception) ex);
        throw ex;
      }
      catch (COMException ex)
      {
        if (ex.HResult == -2147019873)
          throw new InvalidOperationException("CoreWebView2 members cannot be accessed after the WebView2 control is disposed.", (Exception) ex);
        throw ex;
      }
    }

    internal int IsMethodMember(object rawObject, string memberName)
    {
      try
      {
        // ISSUE: variable of a compiler-generated type
        ICoreWebView2PrivateHostObjectHelper hostObjectHelper = this._nativeICoreWebView2PrivateHostObjectHelper;
        object obj = rawObject;
        ref object local = ref obj;
        string memberName1 = memberName;
        // ISSUE: reference to a compiler-generated method
        return hostObjectHelper.IsMethodMember(ref local, memberName1);
      }
      catch (InvalidCastException ex)
      {
        if (ex.HResult == -2147467262)
          throw new InvalidOperationException("CoreWebView2 members can only be accessed from the UI thread.", (Exception) ex);
        throw ex;
      }
      catch (COMException ex)
      {
        if (ex.HResult == -2147019873)
          throw new InvalidOperationException("CoreWebView2 members cannot be accessed after the WebView2 control is disposed.", (Exception) ex);
        throw ex;
      }
    }

    private class RawHelper : 
      ICoreWebView2PrivateHostObjectHelper,
      ICoreWebView2PrivateHostObjectHelper2,
      ICoreWebView2PrivateHostObjectHelper3
    {
      private const int DISP_E_MEMBERNOTFOUND = -2147352573;
      private const int DISP_E_TYPEMISMATCH = -2147352571;
      private const int WIN_BOOL_TRUE = 1;
      private const int WIN_BOOL_FALSE = 0;
      private const int S_OK = 0;

      private MethodInfo GetMethodInfo(Type type, string methodName, int? parameterCount)
      {
        if (!type.IsClass || type.IsCOMObject)
          throw new COMException((string) null, -2147352571);
        MemberInfo[] member = type.GetMember(methodName);
        if (member.Length == 0)
          throw new COMException((string) null, -2147352573);
        foreach (MemberInfo memberInfo in member)
        {
          if (memberInfo.MemberType == MemberTypes.Method)
          {
            MethodInfo methodInfo = (MethodInfo) memberInfo;
            if (!parameterCount.HasValue || methodInfo.GetParameters().Length == parameterCount.Value)
              return methodInfo;
          }
        }
        return (MethodInfo) null;
      }

      public int IsMethodMember(ref object rawObject, string memberName)
      {
        return !(this.GetMethodInfo(rawObject.GetType(), memberName, new int?()) == (MethodInfo) null) ? 1 : 0;
      }

      public object CreateBuiltInDispatch(ref object originalHostObject)
      {
        return (object) new BuiltInHostObject(originalHostObject);
      }

      public int IsAsyncMethod(ref object rawObject, string methodName, int parameterCount)
      {
        MethodInfo methodInfo = this.GetMethodInfo(rawObject.GetType(), methodName, new int?(parameterCount));
        if (methodInfo == (MethodInfo) null)
          throw new COMException((string) null, -2147352571);
        return CoreWebView2PrivateHostObjectHelper.AwaitableReflection.FromAwaitableType(methodInfo.ReturnType) != null ? 1 : 0;
      }

      public void SetAsyncMethodContinuation(
        ref object rawObject,
        string methodName,
        int parameterCount,
        ref object methodResult,
        ICoreWebView2PrivateHostObjectAsyncMethodContinuation continuation)
      {
        if (this.GetMethodInfo(rawObject.GetType(), methodName, new int?(parameterCount)) == (MethodInfo) null)
          throw new COMException((string) null, -2147352571);
        CoreWebView2PrivateHostObjectHelper.AwaitableReflection ar = CoreWebView2PrivateHostObjectHelper.AwaitableReflection.FromAwaitableType(methodResult.GetType());
        object awaiter = ar != null ? ar.InvokeGetAwaiter(methodResult) : throw new COMException((string) null, -2147352571);
        Action continuation1 = (Action) (() =>
        {
          object obj1 = (object) null;
          int num = 0;
          try
          {
            obj1 = ar.InvokeGetResult(awaiter);
          }
          catch (Exception ex)
          {
            num = Marshal.GetHRForException(ex);
          }
          if (obj1.GetType().FullName == "System.Threading.Tasks.VoidTaskResult")
            obj1 = (object) null;
          // ISSUE: variable of a compiler-generated type
          ICoreWebView2PrivateHostObjectAsyncMethodContinuation methodContinuation = continuation;
          int errorCode = num;
          object obj2 = obj1;
          ref object local = ref obj2;
          // ISSUE: reference to a compiler-generated method
          methodContinuation.Invoke(errorCode, ref local);
        });
        if (ar.InvokeIsCompleted(awaiter))
          continuation1();
        else
          ar.InvokeOnCompleted(awaiter, continuation1);
      }
    }

    private class AwaitableReflection
    {
      private Type _awaitable;
      private MethodInfo _getAwaiter;
      private Type _awaiter;
      private PropertyInfo _isCompleted;
      private MethodInfo _onCompleted;
      private MethodInfo _getResult;

      public static CoreWebView2PrivateHostObjectHelper.AwaitableReflection FromAwaitableType(
        Type type)
      {
        MethodInfo method1 = type.GetMethod("GetAwaiter");
        if (method1 == (MethodInfo) null || method1.GetParameters().Length != 0)
          return (CoreWebView2PrivateHostObjectHelper.AwaitableReflection) null;
        Type returnType = method1.ReturnType;
        PropertyInfo property = returnType.GetProperty("IsCompleted");
        if (property == (PropertyInfo) null || !property.CanRead || property.PropertyType != typeof (bool))
          return (CoreWebView2PrivateHostObjectHelper.AwaitableReflection) null;
        MethodInfo method2 = returnType.GetMethod("OnCompleted");
        if (method2 == (MethodInfo) null)
          return (CoreWebView2PrivateHostObjectHelper.AwaitableReflection) null;
        ParameterInfo[] parameters = method2.GetParameters();
        if (parameters.Length != 1 || parameters[0].ParameterType != typeof (Action))
          return (CoreWebView2PrivateHostObjectHelper.AwaitableReflection) null;
        MethodInfo method3 = returnType.GetMethod("GetResult");
        return method3 == (MethodInfo) null || method3.GetParameters().Length != 0 ? (CoreWebView2PrivateHostObjectHelper.AwaitableReflection) null : new CoreWebView2PrivateHostObjectHelper.AwaitableReflection(type, method1, returnType, property, method2, method3);
      }

      private AwaitableReflection(
        Type awaitable,
        MethodInfo getAwaiter,
        Type awaiter,
        PropertyInfo isCompleted,
        MethodInfo onCompleted,
        MethodInfo getResult)
      {
        this._awaitable = awaitable;
        this._getAwaiter = getAwaiter;
        this._awaiter = awaiter;
        this._isCompleted = isCompleted;
        this._onCompleted = onCompleted;
        this._getResult = getResult;
      }

      public object InvokeGetAwaiter(object awaitable)
      {
        return !(awaitable.GetType() != this._awaitable) ? this._getAwaiter.Invoke(awaitable, Array.Empty<object>()) : throw new InvalidOperationException(string.Format("Invoking {0} on an object of type {1} when an awaitable object of type {2} was expected.", (object) this._getAwaiter.Name, (object) awaitable.GetType(), (object) this._awaitable));
      }

      public bool InvokeIsCompleted(object awaiter)
      {
        return !(awaiter.GetType() != this._awaiter) ? (bool) this._isCompleted.GetValue(awaiter) : throw new InvalidOperationException(string.Format("Invoking {0} on an object of type {1} when an awaiter object of type {2} was expected.", (object) this._isCompleted.Name, (object) awaiter.GetType(), (object) this._awaiter));
      }

      public void InvokeOnCompleted(object awaiter, Action continuation)
      {
        if (awaiter.GetType() != this._awaiter)
          throw new InvalidOperationException(string.Format("Invoking {0} on an object of type {1} when an awaiter object of type {2} was expected.", (object) this._onCompleted.Name, (object) awaiter.GetType(), (object) this._awaiter));
        this._onCompleted.Invoke(awaiter, new object[1]
        {
          (object) continuation
        });
      }

      public object InvokeGetResult(object awaiter)
      {
        return !(awaiter.GetType() != this._awaiter) ? this._getResult.Invoke(awaiter, Array.Empty<object>()) : throw new InvalidOperationException(string.Format("Invoking {0} on an object of type {1} when an awaiter object of type {2} was expected.", (object) this._getResult.Name, (object) awaiter.GetType(), (object) this._awaiter));
      }
    }
  }
}
