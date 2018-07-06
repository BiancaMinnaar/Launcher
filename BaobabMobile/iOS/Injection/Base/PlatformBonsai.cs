using System;
using BaobabMobile.iOS.Injection.Base;
using BaobabMobile.Trunk.Injection.Base;
using BaseBonsai.DataContracts;
using Xamarin.Forms;

[assembly: Dependency(typeof(PlatformBonsai))]
namespace BaobabMobile.iOS.Injection.Base
{
    public sealed class PlatformBonsai : PlatformServiceBonsai<IPlatformModelBonsai>, IPlatformBonsai<IPlatformModelBonsai>
    {
        static readonly Lazy<PlatformBonsai> lazy = new Lazy<PlatformBonsai>(
            () => new PlatformBonsai());
        IPlatformModelBonsai model;
        Action _PerformBackground;

        public static PlatformBonsai Instance { get { return lazy.Value; } }

        public PlatformBonsai()
        {
            model = new PlatformModelBonsai();
        }

        public static void SetPerformBackground(Action performBackground)
        {
            Instance._PerformBackground = performBackground;
        }

        public void SentToBackground()//Against Aple Guidlines
        {
            Instance._PerformBackground?.Invoke();
        }

        public static void NotifyOfBackgroundChange(IPlatformModelBonsai model)
        {
            Instance.model.IsBackgroundAvailable = model.IsBackgroundAvailable;
            Instance.model.IsInBackground = model.IsInBackground;
            Instance.ServiceCallBack?.Invoke(Instance.model);
        }
    }
}
