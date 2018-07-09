using System;
using System.Collections.Generic;
using BaobabMobile.Droid.Injection.Base;
using BaobabMobile.iOS.Injection;
using BaobabMobile.Trunk.Injection.Base;
using Xamarin.Forms;

[assembly: Dependency(typeof(PlatformBonsai))]
namespace BaobabMobile.Droid.Injection.Base
{
    public sealed class PlatformSingelton
    {
        static readonly Lazy<PlatformSingelton> lazy = new Lazy<PlatformSingelton>(
            () => new PlatformSingelton());
        public IPlatformModelBonsai Model { get; set; }
        public Action<IPlatformModelBonsai> ServiceCallBack;
        public Dictionary<string, Java.Lang.Object> PlatformServiceList { get; set; }

        public static PlatformSingelton Instance { get { return lazy.Value; } }

        private PlatformSingelton()
        {
            Model = new PlatformModelBonsai();
            PlatformServiceList = new Dictionary<string, Java.Lang.Object>();
        }
    }

    public sealed class PlatformBonsai : PlatformServiceBonsai<IPlatformModelBonsai>, IPlatformBonsai<IPlatformModelBonsai>
    {
        public new Action<IPlatformModelBonsai> ServiceCallBack
        {
            get => PlatformSingelton.Instance.ServiceCallBack;
            set => PlatformSingelton.Instance.ServiceCallBack = value;
        }

        public static void NotifyOfBackgroundChange(IPlatformModelBonsai model)
        {
            PlatformSingelton.Instance.Model.IsBackgroundAvailable = model.IsBackgroundAvailable;
            PlatformSingelton.Instance.Model.IsInBackground = model.IsInBackground;
            PlatformSingelton.Instance.ServiceCallBack?.Invoke(PlatformSingelton.Instance.Model);
        }

        public void SentToBackground()
        {
            throw new NotImplementedException();
        }
    }
}
