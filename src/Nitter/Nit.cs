using System;
using System.Linq.Expressions;
using System.Reflection;
using Jitex;
using Nitter.Interceptors;

namespace Nitter
{
    public class Nit
    {
        static Nit()
        {
            JitexManager.LoadModule<NitterModule>();
        }

        protected Nit()
        {
        }

        /// <summary>
        /// Intercept a void method delegate
        /// </summary>
        /// <param name="del">Method group to intercept.</param>
        /// <returns></returns>
        public static MethodIntercept On(Delegate del) => On(del.Method);

        /// <summary>
        /// A intercept a void method.
        /// </summary>
        /// <param name="methodIntercept">Method to intercept</param>
        /// <returns></returns>
        public static MethodIntercept On(MethodBase methodIntercept) => new(methodIntercept);
        
        /// <summary>
        /// Intercept a non-void method
        /// </summary>
        /// <param name="expression">Method to intercept.</param>
        /// <returns></returns>
        public static MethodIntercept On(Expression<Action> expression)
        {
            MethodBase method = expression.ToMethodBase();
            return On(method);
        }

        /// <summary>
        /// Intercept a non-void method.
        /// </summary>
        /// <param name="methodIntercept">Method to intercept</param>
        /// <typeparam name="TResult">Type from return.</typeparam>
        /// <returns></returns>
        public static MethodIntercept<TResult> On<TResult>(MethodBase methodIntercept) => new(methodIntercept);


        /// <summary>
        /// Intercept a non-void method delegate
        /// </summary>
        /// <param name="del">Method group to intercept.</param>
        /// <returns></returns>
        public static MethodIntercept<TResult> On<TResult>(Delegate del) => On<TResult>(del.Method);
        
        /// <summary>
        /// Intercept a non-void method
        /// </summary>
        /// <param name="expression">Method to intercept.</param>
        /// <returns></returns>
        public static MethodIntercept<TResult> On<TResult>(Expression<Func<TResult>> expression)
        {
            MethodBase method = expression.ToMethodBase();
            return On<TResult>(method);
        }
    }

    public class Nit<T> : Nit
    {
        private Nit()
        {
        }

        /// <summary>
        /// Intercept a void method
        /// </summary>
        /// <param name="expression"> Method to intercept</param>
        /// <returns></returns>
        public static MethodIntercept On(Expression<Action<T>> expression) => On(expression.ToMethodBase());

        /// <summary>
        /// Intercept a non-void method.
        /// </summary>
        /// <param name="expression">Method to intercept</param>
        /// <typeparam name="TResult">Type from return.</typeparam>
        /// <returns></returns>
        public static MethodIntercept<TResult> On<TResult>(Expression<Func<T, TResult>> expression) => On<TResult>(expression.ToMethodBase());
    }
}