using System;
using Android.Telephony;
using BaobabMobile.Droid.Injection.Base;
using BaobabMobile.Droid.Injection.SignalStrength;
using BaobabMobile.Trunk.Injection.SignalStrength;
using Xamarin.Forms;

[assembly: Dependency(typeof(SignalStrengthService))]
namespace BaobabMobile.Droid.Injection.SignalStrength
{
    public class SignalStrengthService : ServiceBonsai<ISignalStrength>, ISignalStrengthService<ISignalStrength>
    {
        public override string ServiceKey => "TelephonyService";

        public SignalStrengthService()
        {
            Java.Lang.Object val;
            var _telephonyManager = (PlatformBonsai.Instance.PlatformServiceList.TryGetValue(ServiceKey, out val))?
                (TelephonyManager)val:null;
            var _signalStrengthListener = new GsmSignalStrengthListener();
            _signalStrengthListener.SignalStrengthChanged += HandleSignalStrengthChanged;
            _telephonyManager.Listen(_signalStrengthListener, PhoneStateListenerFlags.SignalStrengths);
        }

        void HandleSignalStrengthChanged(int strength)
        {
            ServiceCallBack?.Invoke(new SignalStrength { Strength = strength });
        }
    }
}