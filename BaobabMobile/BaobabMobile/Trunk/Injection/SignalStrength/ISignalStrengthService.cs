using BaobabMobile.Trunk.Injection.Base;

namespace BaobabMobile.Trunk.Injection.SignalStrength
{
    public interface ISignalStrengthService<T> : IPlatformService<T> where T : ISignalStrength
    {
    }
}
