using System;
using Android.Telephony;
using BaobabMobile.Droid.Injection.SignalStrength;
using BaobabMobile.Trunk.Injection.SignalStrength;
using Plugin.Connectivity.Abstractions;
using Xamarin.Forms;

[assembly: Dependency(typeof(SignalStrengthService))]
namespace BaobabMobile.Droid.Injection.SignalStrength
{
    public class SignalStrengthService : PhoneStateListener, ISignalStrengthService<ISignalStrength>
    {
        public event EventHandler<SignalStrengthUpdatedEventArgs<ISignalStrength>> SignalStrengthChanged;

        public int SignalStrength 
        {
            get;set;
        }

        public int WifiSignalStrength 
        { 
            get; set;
        }

        public int GetConnectionStrength(ConnectionType connectionType)
        {
            throw new NotImplementedException();
        }

        public override void OnSignalStrengthsChanged(Android.Telephony.SignalStrength signalStrength)
        {
            base.OnSignalStrengthsChanged(signalStrength);
            SignalStrengthChanged?.Invoke(
                this, new SignalStrengthUpdatedEventArgs<ISignalStrength>(
                    new SignalStrength { Strength = signalStrength.GsmSignalStrength }));
        }
    }
}
