namespace BaobabMobile.Trunk.Injection.Location
{
    public class LocationUpdatedEventArgs<T> where T : ILocation
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
