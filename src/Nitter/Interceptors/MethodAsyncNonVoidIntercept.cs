﻿using System;
using System.Reflection;
using System.Threading.Tasks;
using Jitex.Intercept;

namespace Nitter.Interceptors;

public class MethodIntercept<TResult> : MethodInterceptBase
{
    internal MethodIntercept(MethodBase methodIntercept) : base(methodIntercept)
    {
    }

    private MethodIntercept<TResult> DoAsync<T>(T del) where T : Delegate
    {
        AddInterceptor(del, true);
        return this;
    }

    public MethodIntercept<TResult> DoAsync(Func<CallContext, Task<TResult>> func) => DoAsync<Func<CallContext, Task<TResult>>>(func);
    public MethodIntercept<TResult> DoAsync<T1>(Func<T1, CallContext, Task<TResult>> func) => DoAsync<Func<T1, CallContext, Task<TResult>>>(func);
    public MethodIntercept<TResult> DoAsync<T1, T2>(Func<T1, T2, Task<TResult>> func) => DoAsync<Func<T1, T2, Task<TResult>>>(func);
    public MethodIntercept<TResult> DoAsync<T1, T2, T3>(Func<T1, T2, T3, Task<TResult>> func) => DoAsync<Func<T1, T2, T3, Task<TResult>>>(func);
    public MethodIntercept<TResult> DoAsync<T1, T2, T3, T4>(Func<T1, T2, T3, T4, Task<TResult>> func) => DoAsync<Func<T1, T2, T3, T4, Task<TResult>>>(func);
    public MethodIntercept<TResult> DoAsync<T1, T2, T3, T4, T5>(Func<T1, T2, T3, T4, T5, Task<TResult>> func) => DoAsync<Func<T1, T2, T3, T4, T5, Task<TResult>>>(func);
    public MethodIntercept<TResult> DoAsync<T1, T2, T3, T4, T5, T6>(Func<T1, T2, T3, T4, T5, T6, Task<TResult>> func) => DoAsync<Func<T1, T2, T3, T4, T5, T6, Task<TResult>>>(func);
    public MethodIntercept<TResult> DoAsync<T1, T2, T3, T4, T5, T6, T7>(Func<T1, T2, T3, T4, T5, T6, T7, Task<TResult>> func) => DoAsync<Func<T1, T2, T3, T4, T5, T6, T7, Task<TResult>>>(func);
    public MethodIntercept<TResult> DoAsync<T1, T2, T3, T4, T5, T6, T7, T8>(Func<T1, T2, T3, T4, T5, T6, T7, T8, Task<TResult>> func) => DoAsync<Func<T1, T2, T3, T4, T5, T6, T7, T8, Task<TResult>>>(func);
    public MethodIntercept<TResult> DoAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, Task<TResult>> func) => DoAsync<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, Task<TResult>>>(func);
    public MethodIntercept<TResult> DoAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, Task<TResult>> func) => DoAsync<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, Task<TResult>>>(func);
    public MethodIntercept<TResult> DoAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, Task<TResult>> func) => DoAsync<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, Task<TResult>>>(func);
    public MethodIntercept<TResult> DoAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, Task<TResult>> func) => DoAsync<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, Task<TResult>>>(func);
    public MethodIntercept<TResult> DoAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, Task<TResult>> func) => DoAsync<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, Task<TResult>>>(func);
    public MethodIntercept<TResult> DoAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, Task<TResult>> func) => DoAsync<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, Task<TResult>>>(func);
    public MethodIntercept<TResult> DoAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, Task<TResult>> func) => DoAsync<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, Task<TResult>>>(func);
    public MethodIntercept<TResult> DoAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, Task<TResult>> func) => DoAsync<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, Task<TResult>>>(func);
}