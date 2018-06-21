using System;
namespace BaobabMobile.Trunk.Injection
{
    public interface ILocationService<T> where T : ILocation
    {
        event EventHandler<LocationUpdatedEventArgs<T>> LocationUpdated;
        void StartLocationUpdates();
    }
}
