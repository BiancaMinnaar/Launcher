using System;
using System.Threading.Tasks;
using Android;
using Android.Content;
using Android.Content.PM;
using Android.Support.V4.Content;
using BaobabMobile.Droid.Injection;
using BaobabMobile.Trunk.Injection.Location;
using Plugin.Geolocation;
using Xamarin.Forms;

[assembly: Dependency(typeof(LocationService))]
namespace BaobabMobile.Droid.Injection
{
    public class LocationService : ILocationService<ILocation>
    {
		public event EventHandler<LocationUpdatedEventArgs<ILocation>> LocationUpdated;
        Context context = Android.App.Application.Context;
        bool isRequestingLocationUpdates;

        public LocationService()
        {
            isRequestingLocationUpdates = false;
            if (ContextCompat.CheckSelfPermission(context, Manifest.Permission.AccessFineLocation) == Permission.Granted)
            {
                Task.Run(StartLocationUpdates);
                isRequestingLocationUpdates = true;
            }
        }

        public async Task StartLocationUpdates()
        {
            if (isRequestingLocationUpdates)
            {
                try
                {
                    var locator = CrossGeolocation.Current;
                    locator.DesiredAccuracy = 100;

                    var position = await locator.GetPositionAsync();

                    if (position != null)
                    {
                        LocationUpdated(this, new LocationUpdatedEventArgs<ILocation>(new Location()
                        {
                            Lat = position.Latitude,
                            Lon = position.Longitude
                        }));
                    }

                    if (!locator.IsGeolocationEnabled)
                    {
                        // Raise Error
                    }
                }
                catch (Exception ex)
                {
                    // Raise Error
                }
            }
            else
            {
                //Raise error
            }
        }
    }
}
