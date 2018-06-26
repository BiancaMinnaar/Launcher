using System;
using System.Threading.Tasks;

namespace BaobabMobile.Trunk.Injection.Location
{
    public interface ILocationService<T> where T : ILocation
    {
        event EventHandler<LocationUpdatedEventArgs<T>> LocationUpdated;
        Task StartLocationUpdates();
    }
}
