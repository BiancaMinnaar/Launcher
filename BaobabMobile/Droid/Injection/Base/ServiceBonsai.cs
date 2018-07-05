using System;

namespace BaobabMobile.Droid.Injection.Base
{
    public abstract class ServiceBonsai<T>
    {
        public virtual string ServiceKey { get; }
        private Action<T> _ServiceCallback;
        public Action<T> ServiceCallBack
        {
            get => _ServiceCallback;
            set => _ServiceCallback = value;
        }
    }
}
