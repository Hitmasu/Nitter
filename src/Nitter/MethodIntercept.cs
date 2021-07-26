using System;
using System.Reflection;

namespace Nitter
{
    public class MethodIntercept : MethodInterceptBase
    {
        private MethodIntercept() : base(null)
        { }

        internal MethodIntercept(MethodBase methodIntercept) : base(methodIntercept)
        {

        }

        internal MethodIntercept(MethodBase methodIntercept, object instance) : base(methodIntercept, instance)
        {

        }

        public void Intercept<T>(Action<T> action) => PrepareMethod(action);
        public void Intercept<T1, T2>(Action<T1, T2> action) => PrepareMethod(action);
        public void Intercept<T1, T2, T3>(Action<T1, T2, T3> action) => PrepareMethod(action);
        public void Intercept<T1, T2, T3, T4>(Action<T1, T2, T3, T4> action) => PrepareMethod(action);
        public void Intercept<T1, T2, T3, T4, T5>(Action<T1, T2, T3, T4, T5> action) => PrepareMethod(action);
        public void Intercept<T1, T2, T3, T4, T5, T6>(Action<T1, T2, T3, T4, T5, T6> action) => PrepareMethod(action);
        public void Intercept<T1, T2, T3, T4, T5, T6, T7>(Action<T1, T2, T3, T4, T5, T6, T7> action) => PrepareMethod(action);
        public void Intercept<T1, T2, T3, T4, T5, T6, T7, T8>(Action<T1, T2, T3, T4, T5, T6, T7, T8> action) => PrepareMethod(action);
        public void Intercept<T1, T2, T3, T4, T5, T6, T7, T8, T9>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> action) => PrepareMethod(action);
        public void Intercept<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> action) => PrepareMethod(action);
        public void Intercept<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> action) => PrepareMethod(action);
        public void Intercept<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> action) => PrepareMethod(action);
        public void Intercept<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> action) => PrepareMethod(action);
        public void Intercept<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> action) => PrepareMethod(action);
        public void Intercept<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> action) => PrepareMethod(action);
        public void Intercept<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> action) => PrepareMethod(action);
    }
}
