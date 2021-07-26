using System;
using System.Linq.Expressions;
using System.Reflection;
using Jitex;

namespace Nitter
{
    public class Nit
    {
        private readonly object _instance;
        static Nit()
        {
            JitexManager.LoadModule<NitterModule>();
        }

        protected Nit(object instance)
        {
            _instance = instance;
        }

        public MethodIntercept On(MethodBase methodIntercept) => new MethodIntercept(methodIntercept, _instance);
        public MethodIntercept<TResult> On<TResult>(MethodBase methodIntercept) => new MethodIntercept<TResult>(methodIntercept, _instance);
    }

    public class Nit<T> : Nit
    {
        public Nit(T instance) : base(instance){}

        public MethodIntercept On(Expression<Action<T>> expression) => On(expression.ToMethodBase());
        public MethodIntercept<TResult> On<TResult>(Expression<Func<T, TResult>> expression) => On<TResult>(expression.ToMethodBase());
    }

    public class NitEx
    {
        static NitEx()
        {
            JitexManager.LoadModule<NitterModule>();
        }

        protected NitEx() { }

        public static MethodIntercept On(MethodBase methodIntercept) => new MethodIntercept(methodIntercept);
        public static MethodIntercept<TResult> On<TResult>(MethodBase methodIntercept) => new MethodIntercept<TResult>(methodIntercept);

        public static MethodIntercept On(MethodBase methodIntercept, object instance) => new MethodIntercept(methodIntercept, instance);
        public static MethodIntercept<TResult> On<TResult>(MethodBase methodIntercept, object instance) => new MethodIntercept<TResult>(methodIntercept, instance);
    }

    public class NitEx<T> : NitEx
    {
        public static MethodIntercept On(Expression<Action<T>> expression) => On(expression.ToMethodBase());
        public static MethodIntercept<TResult> On<TResult>(Expression<Func<T, TResult>> expression) => On<TResult>(expression.ToMethodBase());
    }
}
