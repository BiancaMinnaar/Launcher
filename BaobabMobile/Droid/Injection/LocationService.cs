using System;
using Android;
using Android.Content;
using Android.Content.PM;
using Android.Gms.Common;
using Android.Gms.Location;
using Android.Support.V4.Content;
using BaobabMobile.Droid.Injection;
using BaobabMobile.Trunk.Injection;
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
            if (ContextCompat.CheckSelfPermission(context, Manifest.Permission.AccessFineLocation) == Permission.Granted)
            {
                StartLocationUpdates();
                isRequestingLocationUpdates = true;
            }
            else
            {
                isRequestingLocationUpdates = false;
            }
        }

        bool IsGooglePlayServicesInstalled()
        {
            var queryResult = GoogleApiAvailability.Instance.IsGooglePlayServicesAvailable(context);
            if (queryResult == ConnectionResult.Success)
            {
                //Log.Info("MainActivity", "Google Play Services is installed on this device.");
                return true;
            }

            if (GoogleApiAvailability.Instance.IsUserResolvableError(queryResult))
            {
                // Check if there is a way the user can resolve the issue
                var errorString = GoogleApiAvailability.Instance.GetErrorString(queryResult);
                //Log.Error("MainActivity", "There is a problem with Google Play Services on this device: {0} - {1}",
                          //queryResult, errorString);

                // Alternately, display the error to the user.
            }

            return false;
        }

        public void StartLocationUpdates()
        {
            if (IsGooglePlayServicesInstalled())
            {
                FusedLocationProviderClient fusedLocationProviderClient = LocationServices.GetFusedLocationProviderClient(context);
                Android.Locations.Location location = fusedLocationProviderClient.GetLastLocationAsync().Result;
                LocationUpdated(this, new LocationUpdatedEventArgs<ILocation>(new Location()
                {
                    Lat = location.Latitude,
                    Lon = location.Longitude
                }));
            }
        }
    }
}
