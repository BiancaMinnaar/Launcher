using System;
using System.Threading.Tasks;
using Android;
using Android.Content;
using Android.Content.PM;
using Android.Support.V4.Content;
using BaobabMobile.Droid.Injection.Location;
using BaobabMobile.Trunk.Injection.Location;
using Plugin.Geolocation;
using Xamarin.Forms;

[assembly: Dependency(typeof(LocationService))]
namespace BaobabMobile.Droid.Injection.Location
{
    public class LocationService : ILocationService<ILocation>
    {
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

        public Action<ILocation> ServiceCallback { get; set; }

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
                        ServiceCallback?.Invoke(new Location { Lat = position.Latitude, Lon = position.Longitude });
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
