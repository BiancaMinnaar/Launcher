using BaobabMobile.Trunk.Injection.SignalStrength;

namespace BaobabMobile.Droid.Injection.SignalStrength
{
    public class SignalStrength : ISignalStrength
    {
        public int Strength { get; set; }

        public string ErrorMessage { get; }
    }
}
