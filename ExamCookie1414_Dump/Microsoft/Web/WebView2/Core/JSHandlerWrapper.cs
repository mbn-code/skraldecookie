// Decompiled with JetBrains decompiler
// Type: Microsoft.Web.WebView2.Core.JSHandlerWrapper
// Assembly: ExamCookie.WinClient, Version=1.4.1.4, Culture=neutral, PublicKeyToken=null
// MVID: E12BE1F8-B6E0-4BF5-B308-166F0E938C4B
// Assembly location: C:\Users\oskar\Downloads\ExamCookie1414.WinClient.exe

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.InteropServices;

#nullable disable
namespace Microsoft.Web.WebView2.Core
{
  internal class JSHandlerWrapper
  {
    private object _JSHandler;

    public JSHandlerWrapper(object JSHandler) => this._JSHandler = JSHandler;

    [DllImport("oleaut32.dll", PreserveSig = false)]
    internal static extern void VariantClear(IntPtr variant);

    public void Invoke(params object[] args)
    {
      int num1 = Marshal.SizeOf(typeof (Variant));
      System.Runtime.InteropServices.ComTypes.DISPPARAMS dispparams1 = new System.Runtime.InteropServices.ComTypes.DISPPARAMS();
      dispparams1.cArgs = args.Length;
      try
      {
        if (!(this._JSHandler is IDispatch jsHandler))
          throw new ArgumentException("The callback object is not an IDispatch's implement.");
        if (dispparams1.cArgs != 0)
        {
          dispparams1.rgvarg = Marshal.AllocHGlobal(dispparams1.cArgs * num1);
          for (int index = 0; index < dispparams1.cArgs; ++index)
            Marshal.GetNativeVariantForObject(args[dispparams1.cArgs - 1 - index], dispparams1.rgvarg + index * num1);
        }
        System.Runtime.InteropServices.ComTypes.EXCEPINFO excepinfo1 = new System.Runtime.InteropServices.ComTypes.EXCEPINFO();
        object obj = (object) null;
        uint num2 = 0;
        Guid empty = Guid.Empty;
        ref Guid local1 = ref empty;
        System.Runtime.InteropServices.ComTypes.DISPPARAMS dispparams2 = dispparams1;
        ref System.Runtime.InteropServices.ComTypes.DISPPARAMS local2 = ref dispparams2;
        ref object local3 = ref obj;
        System.Runtime.InteropServices.ComTypes.EXCEPINFO excepinfo2 = excepinfo1;
        ref System.Runtime.InteropServices.ComTypes.EXCEPINFO local4 = ref excepinfo2;
        ref uint local5 = ref num2;
        Marshal.ThrowExceptionForHR(jsHandler.Invoke(-1, ref local1, 1024U, (ushort) 1, ref local2, out local3, ref local4, out local5));
      }
      finally
      {
        try
        {
          if (dispparams1.cArgs != 0)
          {
            for (int index = 0; index < dispparams1.cArgs; ++index)
              JSHandlerWrapper.VariantClear(dispparams1.rgvarg + index * num1);
            Marshal.FreeHGlobal(dispparams1.rgvarg);
          }
        }
        catch
        {
        }
      }
    }

    public Delegate CreateDelegate(EventInfo eventInfo)
    {
      try
      {
        MethodInfo method = eventInfo.EventHandlerType.GetMethod("Invoke");
        Type returnType = method.ReturnType;
        if (returnType != typeof (void))
          throw new Exception("The" + eventInfo.Name + "'s return type should be void.");
        Type[] array = ((IEnumerable<ParameterInfo>) method.GetParameters()).Select<ParameterInfo, Type>((Func<ParameterInfo, int, Type>) ((p, i) => p.ParameterType)).ToArray<Type>();
        Type[] parameterTypes = new Type[array.Length + 1];
        parameterTypes[0] = typeof (JSHandlerWrapper);
        array.CopyTo((Array) parameterTypes, 1);
        DynamicMethod dynamicMethod = new DynamicMethod("DelegateHandler", MethodAttributes.Public | MethodAttributes.Static, CallingConventions.Standard, returnType, parameterTypes, typeof (JSHandlerWrapper).Module, true);
        ILGenerator ilGenerator = dynamicMethod.GetILGenerator();
        ilGenerator.DeclareLocal(typeof (object).MakeArrayType());
        ilGenerator.Emit(OpCodes.Ldc_I4, array.Length);
        ilGenerator.Emit(OpCodes.Newarr, typeof (object));
        ilGenerator.Emit(OpCodes.Stloc_0);
        for (int index = 0; index < array.Length; ++index)
        {
          ilGenerator.Emit(OpCodes.Ldloc_0);
          ilGenerator.Emit(OpCodes.Ldc_I4, index);
          ilGenerator.Emit(OpCodes.Ldarg_S, index + 1);
          if (array[index].IsValueType)
            ilGenerator.Emit(OpCodes.Box, array[index]);
          ilGenerator.Emit(OpCodes.Stelem_Ref);
        }
        ilGenerator.Emit(OpCodes.Ldarg_0);
        ilGenerator.Emit(OpCodes.Ldloc_0);
        ilGenerator.Emit(OpCodes.Call, typeof (JSHandlerWrapper).GetMethod("Invoke"));
        ilGenerator.Emit(OpCodes.Ret);
        return dynamicMethod.CreateDelegate(eventInfo.EventHandlerType, (object) this);
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }
  }
}
