using System;
using System.Collections.Generic;
using System.Reflection;
using Jitex.Intercept;
using Jitex.JIT.Context;
using Jitex.Utils;
using Nitter.Interceptors;

namespace Nitter
{
    public abstract class MethodInterceptBase
    {
        private static readonly Dictionary<MethodBase, Parameters?> MethodInterceptors = new();

        public MethodBase Method { get; }

        protected MethodInterceptBase(MethodBase method)
        {
            //TODO: Move out of constructor
            Method = MethodHelper.GetOriginalMethod(method);
            MethodInterceptors.Add(Method, null);
        }

        internal static bool ShouldIntercept(MethodContext context) => MethodInterceptors.ContainsKey(context.Method);

        internal static Parameters? GetParameters(CallContext context)
        {
            MethodInterceptors.TryGetValue(context.Method, out Parameters? parameters);
            return parameters;
        }

        protected void AddInterceptor(Delegate methodToCall, bool isAsync)
        {
            Parameters parameters = GetOrInitializeParameters();
            parameters.Interceptor = methodToCall;
            parameters.IsAsync = isAsync;
        }

        private Parameters GetOrInitializeParameters()
        {
            if (!MethodInterceptors.TryGetValue(Method, out Parameters? parameters))
                throw new NullReferenceException();

            if (parameters == null)
            {
                parameters = new Parameters();
                MethodInterceptors[Method] = parameters;
            }

            return parameters;
        }
    }
}