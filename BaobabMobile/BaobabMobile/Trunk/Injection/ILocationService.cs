using System;
namespace BaobabMobile.Trunk.Injection
{
    public interface ILocationService<T>
    {
        event EventHandler<LocationUpdatedEventArgs<T>> LocationUpdated;
        void StartLocationUpdates();
    }
}
