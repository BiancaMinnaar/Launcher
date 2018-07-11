using BaobabMobile.iOS.Injection;
using BaobabMobile.Trunk.Injection.Base;
using BaobabMobile.Trunk.Injection.Location;
using CoreLocation;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(LocationService))]
namespace BaobabMobile.iOS.Injection
{
    public class LocationService : PlatformServiceBonsai<IPlatformModelBase>, ILocationService<IPlatformModelBase>
    {
        public override string ServiceKey => "LocationService";
        CLLocationManager Manager { get; set; }

        public override void SetManagers(object[] managers)
        {
            Manager = (CLLocationManager)managers[0];
        }

        protected override void ConfigureRules()
        {
            ValidationRules.Add(GetRule(() =>
                                        UIDevice.CurrentDevice.CheckSystemVersion(8, 0),
                                        "System version lower than 8."));
            ValidationRules.Add(GetRule(() =>
                                        UIDevice.CurrentDevice.CheckSystemVersion(9, 0),
                                        "System version lower than 9."));
        }

        public override void Activate()
        {
            Manager.RequestAlwaysAuthorization();
            Manager.AllowsBackgroundLocationUpdates = true;
            if (CLLocationManager.LocationServicesEnabled)
            {
                Manager.DesiredAccuracy = 1;
                Manager.LocationsUpdated += LocationManager_LocationsUpdated;
                Manager.StartUpdatingLocation();
            }
        }

        void LocationManager_LocationsUpdated(object sender, CLLocationsUpdatedEventArgs e)
        {
            ExecuteCallBack(new Location { Lat = e.Locations[e.Locations.Length - 1].Coordinate.Latitude, Lon = e.Locations[e.Locations.Length - 1].Coordinate.Longitude });
        }
    }
}
