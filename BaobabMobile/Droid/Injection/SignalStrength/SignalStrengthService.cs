using System;
using System.Threading.Tasks;
using Android.Telephony;
using BaobabMobile.Droid.Injection.Base;
using BaobabMobile.Droid.Injection.SignalStrength;
using BaobabMobile.Trunk.Injection.SignalStrength;
using Xamarin.Forms;

[assembly: Dependency(typeof(SignalStrengthService))]
namespace BaobabMobile.Droid.Injection.SignalStrength
{
    public class SignalStrengthService : ISignalStrengthService<ISignalStrength>
    {
        public string ServiceKey => "TelephonyService";
        TelephonyManager _telephonyManager;
        GsmSignalStrengthListener _signalStrengthListener;

        public SignalStrengthService()
        {
            _telephonyManager = (TelephonyManager)PlatformBonsai.Instance.PlatformServiceList[ServiceKey];
            _signalStrengthListener = new GsmSignalStrengthListener();
            _signalStrengthListener.SignalStrengthChanged += HandleSignalStrengthChanged;
            _telephonyManager.Listen(_signalStrengthListener, PhoneStateListenerFlags.SignalStrengths);
        }

        public Action<ISignalStrength> ServiceCallback { get; set; }

        public async Task GetSignalStrength()
        {
            await Task.Run(() => { HandleSignalStrengthChanged(0); });
        }

        void HandleSignalStrengthChanged(int strength)
        {
            ServiceCallback?.Invoke(new SignalStrength { Strength = strength });
        }
    }
}
