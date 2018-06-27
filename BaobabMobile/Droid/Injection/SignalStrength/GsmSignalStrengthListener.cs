using Android.Telephony;

namespace BaobabMobile.Droid.Injection.SignalStrength
{
    public class GsmSignalStrengthListener : PhoneStateListener
    {
        public delegate void SignalStrengthChangedDelegate(int strength);
        public event SignalStrengthChangedDelegate SignalStrengthChanged;

        public override void OnSignalStrengthsChanged(Android.Telephony.SignalStrength signalStrength)
        {
            base.OnSignalStrengthsChanged(signalStrength);
            if (signalStrength.IsGsm)
            {
                SignalStrengthChanged?.Invoke(signalStrength.GsmSignalStrength);
            }
        }
    }
}
