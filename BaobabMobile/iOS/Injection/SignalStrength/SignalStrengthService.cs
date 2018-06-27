using System;
using System.Threading.Tasks;
using BaobabMobile.iOS.Injection.SignalStrength;
using BaobabMobile.Trunk.Injection.SignalStrength;
using Xamarin.Forms;

[assembly: Dependency(typeof(SignalStrengthService))]
namespace BaobabMobile.iOS.Injection.SignalStrength
{
    public class SignalStrengthService : ISignalStrengthService<ISignalStrength>
    {
        public string ServiceKey => throw new NotImplementedException();

        public Action<ISignalStrength> ServiceCallback { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Task GetSignalStrength()
        {
            throw new NotImplementedException();
        }
    }
}
