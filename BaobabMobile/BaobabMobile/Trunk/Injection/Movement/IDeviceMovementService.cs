using System;
using BaobabMobile.Trunk.Injection.Base;

namespace BaobabMobile.Trunk.Injection.Movement
{
    public interface IDeviceMovementService<T> : IPlatformService<T> where T : IDeviceMovement

    {
    }
}
