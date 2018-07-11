using Android.Telephony;
using BaobabMobile.Droid.Injection.SignalStrength;
using BaobabMobile.Trunk.Injection.Base;
using BaobabMobile.Trunk.Injection.SignalStrength;
using Xamarin.Forms;

[assembly: Dependency(typeof(SignalStrengthService))]
namespace BaobabMobile.Droid.Injection.SignalStrength
{
    public class SignalStrengthService : PlatformServiceBonsai<ISignalStrength>, ISignalStrengthService<ISignalStrength>
    {
        public override string ServiceKey => "TelephonyService";
        TelephonyManager _telephonyManager;

        public override void SetManagers(object[] managers)
        {
            _telephonyManager = (TelephonyManager)managers[0];
        }

        public override void Activate()
        {
            var _signalStrengthListener = new GsmSignalStrengthListener();
            _signalStrengthListener.SignalStrengthChanged += HandleSignalStrengthChanged;
            _telephonyManager.Listen(_signalStrengthListener, PhoneStateListenerFlags.SignalStrengths);
        }

        void HandleSignalStrengthChanged(int strength)
        {
            ExecuteCallBack(new SignalStrength { Strength = strength });
        }
    }
}