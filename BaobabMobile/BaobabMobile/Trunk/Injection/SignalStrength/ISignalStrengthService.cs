using System;
using Plugin.Connectivity.Abstractions;

namespace BaobabMobile.Trunk.Injection.SignalStrength
{
    public interface ISignalStrengthService<T> where T : ISignalStrength
    {
        event EventHandler<SignalStrengthUpdatedEventArgs<T>> SignalStrengthChanged;

        int GetConnectionStrength(ConnectionType connectionType);
        int SignalStrength { get; set; }
        int WifiSignalStrength { get; set; }
    }
}
