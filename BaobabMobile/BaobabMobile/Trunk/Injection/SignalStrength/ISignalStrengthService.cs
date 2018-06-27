using System.Threading.Tasks;
using BaobabMobile.Trunk.Injection.Base;

namespace BaobabMobile.Trunk.Injection.SignalStrength
{
    public interface ISignalStrengthService<T> : IPlatformService<T> where T : ISignalStrength
    {
        string ServiceKey { get; }
        Task GetSignalStrength();
    }
}
