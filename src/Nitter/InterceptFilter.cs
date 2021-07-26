using System;

namespace Nitter
{
    internal class InterceptFilter
    {
        public Delegate Delegate { get; set; }
        public object Instance { get; set; }

        public InterceptFilter(Delegate @delegate, object instance)
        {
            Delegate = @delegate;
            Instance = instance;
        }
    }
}
