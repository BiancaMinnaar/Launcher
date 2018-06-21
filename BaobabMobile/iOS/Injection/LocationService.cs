using System;
using BaobabMobile.Trunk.Injection;
using CoreLocation;
using UIKit;

namespace BaobabMobile.iOS.Injection
{
    public class LocationService : ILocationService<CLLocation>
    {
        public event EventHandler<LocationUpdatedEventArgs<CLLocation>> LocationUpdated = delegate { };
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

        public void StartLocationUpdates()
        {
            if (CLLocationManager.LocationServicesEnabled)
            {
                //set the desired accuracy, in meters
                locationManager.DesiredAccuracy = 1;
                locationManager.LocationsUpdated += (object sender, CLLocationsUpdatedEventArgs e) =>
                {
                    // fire our custom Location Updated event
                    LocationUpdated(this, new LocationUpdatedEventArgs<CLLocation>(e.Locations[e.Locations.Length - 1]));
                };
                locationManager.StartUpdatingLocation();
            }
        }
    }
}
