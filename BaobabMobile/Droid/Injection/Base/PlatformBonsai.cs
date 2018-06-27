using System;
using System.Collections.Generic;

namespace BaobabMobile.Droid.Injection.Base
{
    public sealed class PlatformBonsai
    {
        public Dictionary<string, Java.Lang.Object> PlatformServiceList { get; set; }

        static readonly Lazy<PlatformBonsai> lazy = new Lazy<PlatformBonsai>(
            () => new PlatformBonsai());

        public static PlatformBonsai Instance { get { return lazy.Value; } }

        private PlatformBonsai()
        {
            PlatformServiceList = new Dictionary<string, Java.Lang.Object>();
        }
    }
}
