using System;
using System.Collections.Generic;

namespace BaobabMobile.Trunk.Injection.Base
{
    public class BonsaiPlatformServiceRegistrationStructCollection 
        : Dictionary<string, BonsaiPlatformServiceRegistrationStruct>
    {
        public void Add<T>(BonsaiPlatformServiceRegistrationStruct registrationStruct, params object[] managers)
            where T : PlatformServiceBonsai<IPlatformModelBase>, new()
        {
            if (!ContainsKey(registrationStruct.ServiceKey))
            {
                registrationStruct.platformHarness = new T();
                registrationStruct.platformHarness.SetManagers(managers);
                registrationStruct.platformHarness.Activate();
                Add(registrationStruct.ServiceKey, registrationStruct);
            }
        }
    }

    public struct BonsaiPlatformServiceRegistrationStruct
    {
        public string ServiceKey { get; set; }
        public PlatformServiceBonsai<IPlatformModelBase> platformHarness { get; set; }
    }
}
