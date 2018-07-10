using BaobabMobile.Trunk.Injection.Base;

namespace BaobabMobile.Trunk.Injection.SignalStrength
{
    public interface ISignalStrength : IPlatformModelBase
    {
        int Strength { get; set; }
    }
}
