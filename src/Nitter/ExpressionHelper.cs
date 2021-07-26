using System.Linq.Expressions;
using System.Reflection;

namespace Nitter
{
    internal static class ExpressionHelper
    {
        public static MethodBase ToMethodBase(this LambdaExpression expression)
        {
            Expression body = expression.Body;

            if (body is MethodCallExpression methodCallExpression)
                return methodCallExpression.Method;

            return null;
        }

        public static PropertyInfo ToProperty(this LambdaExpression expression)
        {
            Expression body = expression.Body;

            if (body is MemberExpression memberExpression)
                return (PropertyInfo)memberExpression.Member;

            return null;
        }
    }
}
