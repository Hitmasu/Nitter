using System;
using System.Reflection;

namespace Nitter
{
    public class MethodIntercept<TResult> : MethodInterceptBase
    {
        internal MethodIntercept(MethodBase methodIntercept) : base(methodIntercept)
        {
        }

        internal MethodIntercept(MethodBase methodIntercept, object instance) : base(methodIntercept, instance)
        {

        }

        public void Intercept<T>(Func<TResult> func) => PrepareMethod(func);
        public void Intercept<T>(Func<T, TResult> func) => PrepareMethod(func);
        public void Intercept<T1, T2>(Func<T1, T2, TResult> func) => PrepareMethod(func);
        public void Intercept<T1, T2, T3>(Func<T1, T2, T3, TResult> func) => PrepareMethod(func);
        public void Intercept<T1, T2, T3, T4>(Func<T1, T2, T3, T4, TResult> func) => PrepareMethod(func);
        public void Intercept<T1, T2, T3, T4, T5>(Func<T1, T2, T3, T4, T5, TResult> func) => PrepareMethod(func);
        public void Intercept<T1, T2, T3, T4, T5, T6>(Func<T1, T2, T3, T4, T5, T6, TResult> func) => PrepareMethod(func);
        public void Intercept<T1, T2, T3, T4, T5, T6, T7>(Func<T1, T2, T3, T4, T5, T6, T7, TResult> func) => PrepareMethod(func);
        public void Intercept<T1, T2, T3, T4, T5, T6, T7, T8>(Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult> func) => PrepareMethod(func);
        public void Intercept<T1, T2, T3, T4, T5, T6, T7, T8, T9>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> func) => PrepareMethod(func);
        public void Intercept<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> func) => PrepareMethod(func);
        public void Intercept<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult> func) => PrepareMethod(func);
        public void Intercept<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult> func) => PrepareMethod(func);
        public void Intercept<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult> func) => PrepareMethod(func);
        public void Intercept<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult> func) => PrepareMethod(func);
        public void Intercept<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult> func) => PrepareMethod(func);
        public void Intercept<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult> func) => PrepareMethod(func);
    }
}
 