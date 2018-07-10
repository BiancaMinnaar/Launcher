using System;
using System.Threading.Tasks;
using BaobabMobile.iOS.Injection;
using BaobabMobile.iOS.Injection.Base;
using BaobabMobile.Trunk.Injection.Location;
using CoreLocation;
using CorePCL;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(LocationService))]
namespace BaobabMobile.iOS.Injection
{
    public class LocationService : PlatformServiceBonsai<ILocation>, ILocationService<ILocation>
    {
        public override string ServiceKey => "LocationService";

        ValidationRule GetRule(Func<bool> check, string errorMessage)
        {
            return new ValidationRule
            {
                Check=check,
                ErrorMessage=errorMessage
            };
        }

        public LocationService()
        {
            ValidationRules.Add(GetRule(() => 
                                        UIDevice.CurrentDevice.CheckSystemVersion(8, 0), 
                                        "System version lower than 8."));
            ValidationRules.Add(GetRule(() =>
                                        UIDevice.CurrentDevice.CheckSystemVersion(9, 0),
                                        "System version lower than 9."));
        }

        public async Task StartLocationUpdates()
        {
            var locationManager = (PlatformSingelton.Instance.PlatformServiceList.TryGetValue(ServiceKey, out object val)) ?
                (CLLocationManager)val : null;
            locationManager.RequestAlwaysAuthorization();
            locationManager.AllowsBackgroundLocationUpdates = true;
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
