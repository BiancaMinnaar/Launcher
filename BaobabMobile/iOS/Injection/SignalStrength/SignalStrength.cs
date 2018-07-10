using BaobabMobile.Trunk.Injection.SignalStrength;

namespace BaobabMobile.iOS.Injection.SignalStrength
{
    public class SignalStrength : ISignalStrength
    {
        public int Strength { get; set; }

        public string PlatformName { get; }
    }
}
