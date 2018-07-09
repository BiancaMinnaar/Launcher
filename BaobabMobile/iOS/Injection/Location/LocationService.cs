using System.Threading.Tasks;
using BaobabMobile.iOS.Injection;
using BaobabMobile.Trunk.Injection.Location;
using CoreLocation;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(LocationService))]
namespace BaobabMobile.iOS.Injection
{
    public class LocationService : PlatformServiceBonsai<ILocation>, ILocationService<ILocation>
    {
        protected CLLocationManager locationManager;

        public LocationService()
        {
            locationManager = new CLLocationManager
            {
                PausesLocationUpdatesAutomatically = false
            };

            if (UIDevice.CurrentDevice.CheckSystemVersion(8, 0))
            {
                locationManager.RequestAlwaysAuthorization(); // works in background
            }

            if (UIDevice.CurrentDevice.CheckSystemVersion(9, 0))
            {
                locationManager.AllowsBackgroundLocationUpdates = true;
            }
        }

        public async Task StartLocationUpdates()
        {
            if (CLLocationManager.LocationServicesEnabled)
            {
                locationManager.DesiredAccuracy = 1;
                locationManager.LocationsUpdated += LocationManager_LocationsUpdated;
                await Task.Run(() => locationManager.StartUpdatingLocation());
            }
        }

        void LocationManager_LocationsUpdated(object sender, CLLocationsUpdatedEventArgs e)
        {
            ExecuteCallBack(new Location { Lat = e.Locations[e.Locations.Length - 1].Coordinate.Latitude, Lon = e.Locations[e.Locations.Length - 1].Coordinate.Longitude });
        }
    }
}
