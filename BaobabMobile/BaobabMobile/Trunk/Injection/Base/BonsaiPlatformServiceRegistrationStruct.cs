using System;
using System.Collections.Generic;

namespace BaobabMobile.Trunk.Injection.Base
{
    public class BonsaiPlatformServiceRegistrationStructCollection 
        : Dictionary<string, BonsaiPlatformServiceRegistrationStruct>
    {
        public void Add(BonsaiPlatformServiceRegistrationStruct registrationStruct)
        {
            if (!ContainsKey(registrationStruct.ServiceKey))
            {
                Add(registrationStruct.ServiceKey, registrationStruct);
            }
        }
    }

    public struct BonsaiPlatformServiceRegistrationStruct
    {
        public string ServiceKey { get; set; }
        public object Manager { get; set; }
        public PlatformServiceBonsai<IPlatformModelBase> platformHarness { get; set; }
    }
}
