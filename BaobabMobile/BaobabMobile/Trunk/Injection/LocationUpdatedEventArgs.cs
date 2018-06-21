using System;

namespace BaobabMobile.Trunk.Injection
{
    public class LocationUpdatedEventArgs<T>
    {
        T location;

        public LocationUpdatedEventArgs(T location)
        {
            this.location = location;
        }

        public T Location
        {
            get { return location; }
        }
    }
}
