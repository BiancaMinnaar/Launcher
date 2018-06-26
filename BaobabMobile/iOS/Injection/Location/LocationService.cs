using System;
using System.Threading.Tasks;
using BaobabMobile.iOS.Injection;
using BaobabMobile.Trunk.Injection.Location;
using CoreLocation;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(LocationService))]
namespace BaobabMobile.iOS.Injection
{
    public class LocationService : ILocationService<ILocation>
    {
        public event EventHandler<LocationUpdatedEventArgs<ILocation>> LocationUpdated = delegate { };
        protected CLLocationManager locationManager;

        public LocationService()
        {
            locationManager = new CLLocationManager
            {
                PausesLocationUpdatesAutomatically = false
            };

            // iOS 8 has additional permissions requirements
            if (UIDevice.CurrentDevice.CheckSystemVersion(8, 0))
            {
                locationManager.RequestAlwaysAuthorization(); // works in background
                //locMgr.RequestWhenInUseAuthorization (); // only in foreground
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
                //set the desired accuracy, in meters
                locationManager.DesiredAccuracy = 1;
                locationManager.LocationsUpdated += (object sender, CLLocationsUpdatedEventArgs e) =>
                {
                    // fire our custom Location Updated event
                    LocationUpdated(this, new LocationUpdatedEventArgs<ILocation>(new Location()
                    {
                        Lat=e.Locations[e.Locations.Length - 1].Coordinate.Latitude,
                        Lon=e.Locations[e.Locations.Length - 1].Coordinate.Longitude
                    }));//e.Locations[e.Locations.Length - 1]));
                };
                await Task.Run(() => locationManager.StartUpdatingLocation());
            }
        }
    }
}
