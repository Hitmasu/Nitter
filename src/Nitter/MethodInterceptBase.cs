using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Jitex;
using Jitex.Intercept;
using Jitex.Utils;

namespace Nitter
{
    public abstract class MethodInterceptBase
    {
        static MethodInterceptBase()
        {
            JitexManager.AddInterceptor(InterceptorCallAsync);
        }

        private static readonly Dictionary<MethodBase, IList<InterceptFilter>> MethodInterceptors = new Dictionary<MethodBase, IList<InterceptFilter>>();

        private readonly MethodBase _origin;
        private readonly object _instance;

        protected MethodInterceptBase(MethodBase origin)
        {
            _origin = MethodHelper.GetOriginalMethod(origin);
        }

        protected MethodInterceptBase(MethodBase origin, object instance)
        {
            _origin = MethodHelper.GetOriginalMethod(origin);
            _instance = instance;
        }

        protected void PrepareMethod(Delegate methodToCall)
        {
            InterceptFilter filter = new InterceptFilter(methodToCall, _instance);
            if (MethodInterceptors.TryGetValue(_origin, out IList<InterceptFilter> filters))
            {
                filters.Add(filter);
            }
            else
            {
                MethodInterceptors.Add(_origin, new List<InterceptFilter> { filter });
            }

        }

        internal static bool IsToIntercept(MethodBase methodToCompile)
        {
            MethodBase originalMethod = MethodHelper.GetOriginalMethod(methodToCompile);
            return MethodInterceptors.ContainsKey(originalMethod);
        }

        private static async ValueTask InterceptorCallAsync(CallContext context)
        {
            MethodBase originalMethod = MethodHelper.GetOriginalMethod(context.Method);

            if (!MethodInterceptors.TryGetValue(originalMethod, out IList<InterceptFilter> filters))
                return;

            Delegate delegateToCall = default;

            foreach (InterceptFilter filter in filters)
            {
                if (filter.Instance == context.Instance)
                    delegateToCall = filter.Delegate;
            }

            if (delegateToCall == null)
            {
                InterceptFilter filter = filters.FirstOrDefault(w => w.Instance == null);

                if (filter != null)
                    delegateToCall = filter.Delegate;
                else
                    return;
            }

            object[] parameters = context.HasParameters ? context.Parameters!.Select(w => w.Value).ToArray() : new object[0];
            object returnValue = delegateToCall.DynamicInvoke(parameters);

            if (context.HasReturn)
                context.ReturnValue = returnValue;
        }
    }
}
