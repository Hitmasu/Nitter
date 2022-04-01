using System;
using System.Reflection;
using System.Threading.Tasks;
using Jitex.Intercept;

namespace Nitter.Interceptors;

public class MethodIntercept : MethodInterceptBase
{
    internal MethodIntercept(MethodBase methodIntercept) : base(methodIntercept)
    {
    }

    private MethodIntercept DoAsync<T>(T del) where T : Delegate
    {
        AddInterceptor(del, true);
        return this;
    }

    public MethodIntercept DoAsync(Func<CallContext, Task> func) => DoAsync<Func<CallContext, Task>>(func);
    public MethodIntercept DoAsync<T1>(Func<T1, CallContext, Task> func) => DoAsync<Func<T1, CallContext, Task>>(func);
    public MethodIntercept DoAsync<T1, T2>(Func<T1, T2, Task> func) => DoAsync<Func<T1, T2, Task>>(func);
    public MethodIntercept DoAsync<T1, T2, T3>(Func<T1, T2, T3, Task> func) => DoAsync<Func<T1, T2, T3, Task>>(func);
    public MethodIntercept DoAsync<T1, T2, T3, T4>(Func<T1, T2, T3, T4, Task> func) => DoAsync<Func<T1, T2, T3, T4, Task>>(func);
    public MethodIntercept DoAsync<T1, T2, T3, T4, T5>(Func<T1, T2, T3, T4, T5, Task> func) => DoAsync<Func<T1, T2, T3, T4, T5, Task>>(func);
    public MethodIntercept DoAsync<T1, T2, T3, T4, T5, T6>(Func<T1, T2, T3, T4, T5, T6, Task> func) => DoAsync<Func<T1, T2, T3, T4, T5, T6, Task>>(func);
    public MethodIntercept DoAsync<T1, T2, T3, T4, T5, T6, T7>(Func<T1, T2, T3, T4, T5, T6, T7, Task> func) => DoAsync<Func<T1, T2, T3, T4, T5, T6, T7, Task>>(func);
    public MethodIntercept DoAsync<T1, T2, T3, T4, T5, T6, T7, T8>(Func<T1, T2, T3, T4, T5, T6, T7, T8, Task> func) => DoAsync<Func<T1, T2, T3, T4, T5, T6, T7, T8, Task>>(func);
    public MethodIntercept DoAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, Task> func) => DoAsync<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, Task>>(func);
    public MethodIntercept DoAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, Task> func) => DoAsync<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, Task>>(func);
    public MethodIntercept DoAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, Task> func) => DoAsync<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, Task>>(func);
    public MethodIntercept DoAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, Task> func) => DoAsync<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, Task>>(func);
    public MethodIntercept DoAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, Task> func) => DoAsync<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, Task>>(func);
    public MethodIntercept DoAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, Task> func) => DoAsync<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, Task>>(func);
    public MethodIntercept DoAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, Task> func) => DoAsync<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, Task>>(func);
    public MethodIntercept DoAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, Task> func) => DoAsync<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, Task>>(func);
}