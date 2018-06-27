using System;
using Android.Content;

namespace BaobabMobile.Droid.Injection.Base
{
    public class ServiceBonsai<T>
    {
        public readonly Action<T> _ServiceCallback;
        protected Context _Context;

        public ServiceBonsai(Action<T> serviceCallback)
        {
            _ServiceCallback = serviceCallback;
            _Context = Android.App.Application.Context;
        }
    }
}
