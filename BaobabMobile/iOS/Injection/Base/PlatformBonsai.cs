using System;
using BaobabMobile.iOS.Injection.Base;
using BaobabMobile.Trunk.Injection.Base;
using Xamarin.Forms;

[assembly: Dependency(typeof(PlatformBonsai))]
namespace BaobabMobile.iOS.Injection.Base
{
    public sealed class PlatformBonsai : PlatformServiceBonsai<IPlatformModelBonsai>, IPlatformBonsai<IPlatformModelBonsai>
    {
        public new Action<IPlatformModelBonsai> ServiceCallBack
        {
            get => PlatformSingleton.Instance.ServiceCallBack;
            set => PlatformSingleton.Instance.ServiceCallBack = value;
        }

        public static void NotifyOfBackgroundChange(IPlatformModelBonsai model)
        {
            PlatformSingleton.Instance.Model.IsBackgroundAvailable = model.IsBackgroundAvailable;
            PlatformSingleton.Instance.Model.IsInBackground = model.IsInBackground;
            PlatformSingleton.Instance.ServiceCallBack?.Invoke(PlatformSingleton.Instance.Model);
        }

        protected override void Activate()
        {
        }

        protected override void ConfigureRules()
        {
        }
    }
}
