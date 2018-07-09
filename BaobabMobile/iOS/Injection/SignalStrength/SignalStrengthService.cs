using BaobabMobile.iOS.Injection.SignalStrength;
using BaobabMobile.Trunk.Injection.SignalStrength;
using Plugin.Connectivity;
using Xamarin.Forms;

[assembly: Dependency(typeof(SignalStrengthService))]
namespace BaobabMobile.iOS.Injection.SignalStrength
{
    public class SignalStrengthService : PlatformServiceBonsai<ISignalStrength>, ISignalStrengthService<ISignalStrength>
    {
        public SignalStrengthService()
        {
            var speeds = CrossConnectivity.Current.Bandwidths;
            var connectionTypes = CrossConnectivity.Current.ConnectionTypes;
            CrossConnectivity.Current.ConnectivityChanged += Current_ConnectivityChanged;
        }

        void Current_ConnectivityChanged(object sender, Plugin.Connectivity.Abstractions.ConnectivityChangedEventArgs e)
        {
            ExecuteCallBack(new SignalStrength { Strength = e.IsConnected ? 1 : 0 });
        }
    }
}
