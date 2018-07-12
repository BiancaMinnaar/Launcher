using System;
using System.Threading.Tasks;
using Android;
using Android.Content;
using Android.Content.PM;
using Android.Support.V4.Content;
using BaobabMobile.Droid.Injection.Location;
using BaobabMobile.Trunk.Injection.Base;
using BaobabMobile.Trunk.Injection.Location;
using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;
using Xamarin.Forms;

[assembly: Dependency(typeof(LocationServiceCurrentActivity))]
namespace BaobabMobile.Droid.Injection.Location
{
    public class LocationServiceCurrentActivity : PlatformServiceBonsai<IPlatformModelBase>, ILocationService<IPlatformModelBase>
    {
        Context context = Android.App.Application.Context;
        bool canRequestingLocationUpdates;

        public override string ServiceKey => "LocationServiceCurrentActivity";

        protected override void ConfigureRules()
        {
            ValidationRules.Add(GetRule(() =>
                                        ContextCompat.CheckSelfPermission(
                            context, Manifest.Permission.AccessFineLocation) == Permission.Granted,
                                        ""));
            ValidationRules.Add(GetRule(() =>
            {
                if (ValidationRules[0].Check() && !canRequestingLocationUpdates)
                {
                    canRequestingLocationUpdates = true;
                }
                return canRequestingLocationUpdates;
            }, ""));

        }

        public LocationServiceCurrentActivity()
        {
            canRequestingLocationUpdates = false;
        }

        async Task<Position> GetCurrentPosition(Action<Position> raiseUpdate)
        {
            Position position = null;
            try
            {
                var locator = CrossGeolocator.Current;
                locator.DesiredAccuracy = 100;

                position = await locator.GetLastKnownLocationAsync();

                if (position != null)
                {
                    //got a cahched position, so let's use it.
                    raiseUpdate?.Invoke(position);
                }

                if (!locator.IsGeolocationAvailable || !locator.IsGeolocationEnabled)
                {
                    //not available or enabled
                    return null;
                }

                position = await locator.GetPositionAsync(TimeSpan.FromSeconds(20), null, true);

            }
            catch (Exception ex)
            {
                //Debug.WriteLine("Unable to get location: " + ex);
            }

            if (position == null)
                return null;

            var output = string.Format("Time: {0} \nLat: {1} \nLong: {2} \nAltitude: {3} \nAltitude Accuracy: {4} \nAccuracy: {5} \nHeading: {6} \nSpeed: {7}",
                    position.Timestamp, position.Latitude, position.Longitude,
                    position.Altitude, position.AltitudeAccuracy, position.Accuracy, position.Heading, position.Speed);

            //Debug.WriteLine(output);

            return position;
        }

        public override void Activate()
        {
            Task.Run(async () =>
            {
                await GetCurrentPosition((position) =>
                                         ExecuteCallBack(new Location { Lat = position.Latitude, Lon = position.Longitude }));
            });
        }
    }
}
