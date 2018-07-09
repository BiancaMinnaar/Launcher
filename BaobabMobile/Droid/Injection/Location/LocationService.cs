using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Android;
using Android.Content;
using Android.Content.PM;
using Android.Support.V4.Content;
using BaobabMobile.Droid.Injection.Location;
using BaobabMobile.iOS.Injection;
using BaobabMobile.Trunk.Injection.Location;
using CorePCL;
using Plugin.Geolocator;
using Xamarin.Forms;

[assembly: Dependency(typeof(LocationService))]
namespace BaobabMobile.Droid.Injection.Location
{
    public class LocationService : PlatformServiceBonsai<ILocation>, ILocationService<ILocation>
    {
        Context context = Android.App.Application.Context;
        bool isRequestingLocationUpdates;

        public LocationService()
        {
            isRequestingLocationUpdates = false;
            ValidationRules = new List<ValidationRule>
                {
                new ValidationRule
                {
                    Check = () =>
                    {
                        return ContextCompat.CheckSelfPermission(
                            context, Manifest.Permission.AccessFineLocation) == Permission.Granted;
                    },
                    ErrorMessage = "AccessFineLocation not requested."
                },
                new ValidationRule
                {
                    Check = () =>
                    {
                        if (ValidationRules[0].Check() && !isRequestingLocationUpdates)
                        {
                            Task.Run(StartLocationUpdates);
                            isRequestingLocationUpdates = true;
                        }

                        return isRequestingLocationUpdates;
                    },
                    ErrorMessage = "Not currently requesting location updates"
                },
                new ValidationRule
                {
                    Check = () =>
                    {
                        return CrossGeolocator.Current.IsGeolocationEnabled;
                    },
                    ErrorMessage = "Geo location isn't enabled on this device."
                }
            };
        }

        public async Task StartLocationUpdates()
        {
            try
            {
                var locator = CrossGeolocator.Current;
                locator.DesiredAccuracy = 100;

                var position = await locator.GetPositionAsync();

                if (position != null)
                {
                    ExecuteCallBack(new Location { Lat = position.Latitude, Lon = position.Longitude });
                }
            }
            catch (Exception ex)
            {
                ValidationRules.Add(new ValidationRule
                {
                    Check = () => false,
                    ErrorMessage = ex.Message
                });
            }
        }
    }
}
