using System;

namespace Nitter
{
    internal class Parameters
    {
        public bool IsAsync { get; set; }
        public Delegate? Interceptor { get; set; }
    }
}