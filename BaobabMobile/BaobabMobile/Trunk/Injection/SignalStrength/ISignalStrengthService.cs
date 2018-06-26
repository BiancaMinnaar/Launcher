using Plugin.Connectivity.Abstractions;

namespace BaobabMobile.Trunk.Injection.SignalStrength
{
    public interface ISignalStrengthService
    {
        int GetConnectionStrength(ConnectionType connectionType);
        int SignalStrength { get; set; }
        int WifiSignalStrength { get; set; }
    }
}
