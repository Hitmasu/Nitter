using System;
using System.Reflection;
using System.Threading.Tasks;
using Jitex;
using Jitex.Intercept;
using Jitex.JIT.Context;

namespace Nitter
{
    internal class NitterModule : JitexModule
    {
        public NitterModule()
        {
            JitexManager.AddInterceptor(InterceptorCallAsync);
        }

        protected override void MethodResolver(MethodContext context)
        {
            if (MethodInterceptBase.ShouldIntercept(context))
                context.InterceptCall();
        }

        protected override void TokenResolver(TokenContext context)
        {
        }

        private async Task InterceptorCallAsync(CallContext context)
        {
            Parameters? parameters = MethodInterceptBase.GetParameters(context);

            if (parameters == null)
                return;

            object?[] args = new object?[context.ParametersCount + 1];

            for (int i = 0; i < context.ParametersCount; i++)
                args[i] = context.GetParameterValue(i);

            args[args.Length - 1] = context;

            dynamic returnValue = parameters.Interceptor.DynamicInvoke(args);

            if (context.HasReturn)
            {
                if (context.Method is MethodInfo mi)
                {
                    Type returnType = mi.ReturnType;

                    if (IsAwaitable(returnType))
                    {
                        if (returnType == typeof(Task) || returnType == typeof(ValueTask))
                        {
                            context.SetReturnValue(returnValue);
                        }
                        else
                        {
                            dynamic innerReturnValue = await returnValue;

                            if (IsTask(returnType))
                            {
                                Task task = (Task) typeof(Task)
                                    .GetMethod("FromResult")!
                                    .MakeGenericMethod(mi.ReturnType.GenericTypeArguments[0])
                                    .Invoke(null, new object[] {innerReturnValue})!;

                                context.SetReturnValue(task);
                            }
                            else if (IsValueTask(returnType))
                            {
                                ValueTask valueTask = (ValueTask) typeof(ValueTask)
                                    .GetMethod("FromResult")!
                                    .MakeGenericMethod(mi.ReturnType.GenericTypeArguments[0])
                                    .Invoke(null, new object[] {innerReturnValue})!;

                                context.SetReturnValue(valueTask);
                            }
                        }

                        return;
                    }
                    if (parameters.IsAsync)
                    {
                        dynamic innerReturnValue = await returnValue;
                        context.SetReturnValue(innerReturnValue);
                        return;
                    }
                }
                context.SetReturnValue(returnValue, false);
            }
        }

        private static bool IsAwaitable(Type type) => IsTask(type) || IsValueTask(type);

        private static bool IsTask(Type type)
        {
            if (type == typeof(Task))
                return true;

            if (!type.IsGenericType)
                return false;

            return type.GetGenericTypeDefinition() == typeof(Task<>);
        }

        private static bool IsValueTask(Type type)
        {
            if (type == typeof(ValueTask))
                return true;

            if (!type.IsGenericType)
                return false;

            return type.GetGenericTypeDefinition() == typeof(ValueTask<>);
        }
    }
}