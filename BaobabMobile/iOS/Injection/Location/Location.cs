using BaobabMobile.Trunk.Injection.Location;

namespace BaobabMobile.iOS.Injection
{
    public class Location : ILocation
    {
        public double Lat { get; set; }
        public double Lon { get; set; }

        public string ErrorMessage { get; }
    }
}
