using System.Collections.Generic;
using BaobabMobile.Trunk.Injection.Base;

namespace BaobabMobile.Root.ViewModel
{
    public sealed class MasterModel
    {
        public bool Authenticated { get; set; }
        public IPlatformModelBase PlatformModel { get; set; }
        public IEnumerable<PlatformServiceBonsai<IPlatformModelBase>> PlatformServiceList { get; }
    }
}

