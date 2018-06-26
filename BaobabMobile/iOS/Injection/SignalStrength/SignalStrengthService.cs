using System;
using BaobabMobile.iOS.Injection.SignalStrength;
using BaobabMobile.Trunk.Injection.SignalStrength;
using Plugin.Connectivity.Abstractions;
using Xamarin.Forms;

[assembly: Dependency(typeof(SignalStrengthService))]
namespace BaobabMobile.iOS.Injection.SignalStrength
{
    public class SignalStrengthService : ISignalStrengthService<ISignalStrength>
    {
        public event EventHandler<SignalStrengthUpdatedEventArgs<ISignalStrength>> SignalStrengthChanged;

        public int SignalStrength
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        public int WifiSignalStrength
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        public int GetConnectionStrength(ConnectionType connectionType)
        {
            throw new NotImplementedException();
        }
    }
}
