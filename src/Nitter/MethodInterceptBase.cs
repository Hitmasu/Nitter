using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using Jitex.Intercept;
using Jitex.JIT.Context;
using Jitex.Utils;

namespace Nitter
{
    public abstract class MethodInterceptBase
    {
        private static readonly Dictionary<(Module, int), Parameters?> MethodInterceptors = new();

        public MethodBase Method { get; }

        protected MethodInterceptBase(MethodBase method)
        {
            Method = method;
            MethodInterceptors.Add((method.Module, method.MetadataToken), null);
        }

        internal static bool ShouldIntercept(MethodContext context)
        {
            if (context.Method is DynamicMethod)
                return false;

            return MethodInterceptors.ContainsKey((context.Method.Module, context.Method.MetadataToken));
        }

        internal static Parameters? GetParameters(CallContext context)
        {
            MethodBase method;

            if (context.Method.IsGenericMethod)
            {
                MethodInfo mi = (MethodInfo) context.Method;
                method = mi.GetGenericMethodDefinition();
            }
            else
            {
                method = context.Method;
            }

            MethodInterceptors.TryGetValue((method.Module, method.MetadataToken), out Parameters? parameters);
            return parameters;
        }

        protected void AddInterceptor(Delegate methodToCall, bool isAsync)
        {
            Parameters parameters = GetOrInitializeParameters();
            parameters.Interceptor = methodToCall;
            parameters.IsAsync = isAsync;

            if (!RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                MethodHelper.DisableReadyToRun(Method);
            
            MethodHelper.ForceRecompile(Method);
        }

        private Parameters GetOrInitializeParameters()
        {
            if (!MethodInterceptors.TryGetValue((Method.Module, Method.MetadataToken), out Parameters? parameters))
                throw new NullReferenceException();

            if (parameters == null)
            {
                parameters = new Parameters();
                MethodInterceptors[(Method.Module, Method.MetadataToken)] = parameters;
            }

            return parameters;
        }
    }
}