using System;
using BaobabMobile.iOS.Injection.SignalStrength;
using BaobabMobile.Trunk.Injection.SignalStrength;
using Plugin.Connectivity;
using Xamarin.Forms;

[assembly: Dependency(typeof(SignalStrengthService))]
namespace BaobabMobile.iOS.Injection.SignalStrength
{
    public class SignalStrengthService : ISignalStrengthService<ISignalStrength>
    {
        public Action<ISignalStrength> ServiceCallback { get; set; }
        int signalStrength;

        public SignalStrengthService()
        {
            var speeds = CrossConnectivity.Current.Bandwidths;
            var connectionTypes = CrossConnectivity.Current.ConnectionTypes;
            CrossConnectivity.Current.ConnectivityChanged += (sender, e) =>
            { HandleSignalStrengthChanged(CrossConnectivity.Current.IsConnected ? 1 : 0); };
            HandleSignalStrengthChanged(CrossConnectivity.Current.IsConnected ? 1 : 0);
        }

        void HandleSignalStrengthChanged(int strength)
        {
            signalStrength = strength;
            ServiceCallback?.Invoke(new SignalStrength { Strength = strength });
        }
    }
}
