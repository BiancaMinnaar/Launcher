using System;
using BaobabMobile.iOS.Injection.Base;
using BaobabMobile.Trunk.Injection.Base;
using BaseBonsai.DataContracts;
using Xamarin.Forms;

[assembly: Dependency(typeof(PlatformBonsai))]
namespace BaobabMobile.iOS.Injection.Base
{
    public sealed class PlatformBonsai : PlatformServiceBonsai<IPlatformModelBonsai>, IPlatformService<IPlatformModelBonsai>
    {
        static readonly Lazy<PlatformBonsai> lazy = new Lazy<PlatformBonsai>(
            () => new PlatformBonsai());

        public static PlatformBonsai Instance { get { return lazy.Value; } }

        private PlatformBonsai()
        {
        }
    }
}
