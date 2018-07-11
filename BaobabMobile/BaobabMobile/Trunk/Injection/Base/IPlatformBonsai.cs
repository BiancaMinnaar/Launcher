using System.Collections.Generic;

namespace BaobabMobile.Trunk.Injection.Base
{
    public interface IPlatformBonsai<T> : IPlatformService<T> where T : IPlatformModelBonsai
    {
        IEnumerable<BonsaiPlatformServiceRegistrationStruct> GetBonsaiServices { get;}
    }
}
