using Jitex;
using Jitex.JIT.Context;

namespace Nitter
{
    internal class NitterModule : JitexModule
    {
        protected override void MethodResolver(MethodContext context)
        {
            bool shoudlIntercept = MethodInterceptBase.IsToIntercept(context.Method);

            if(shoudlIntercept)
                context.InterceptCall();
        }

        protected override void TokenResolver(TokenContext context)
        {
        }
    }
}
