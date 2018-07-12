using Android;
using Android.Content;
using Android.Content.PM;
using Android.Support.V4.Content;
using BaobabMobile.Droid.Injection.Location;
using BaobabMobile.Trunk.Injection.Base;
using BaobabMobile.Trunk.Injection.Location;
using Xamarin.Forms;

[assembly: Dependency(typeof(LocationService))]
namespace BaobabMobile.Droid.Injection.Location
{
    public class LocationService : PlatformServiceBonsai<IPlatformModelBase>, ILocationService<IPlatformModelBase>
    {
        Context context = Android.App.Application.Context;
        bool canRequestingLocationUpdates;

        protected override void ConfigureRules()
        {
            ValidationRules.Add(GetRule(() =>
                                        ContextCompat.CheckSelfPermission(
                            context, Manifest.Permission.AccessFineLocation) == Permission.Granted,
                                        ""));
            ValidationRules.Add(GetRule(() =>
            {
                if(ValidationRules[0].Check() && !canRequestingLocationUpdates)
                {
                    canRequestingLocationUpdates = true;
                }
                return canRequestingLocationUpdates;
            }, ""));
                                        
        }

        public LocationService()
        {
            canRequestingLocationUpdates = false;
        }

        //async Task setLocation(Action<LocationModel> callBack)
        //{
        //    var locator = CrossGeolocation.Current;
        //    locator.DesiredAccuracy = 100;
        //    var position = await locator.GetPositionAsync();
        //    callBack(position);
        //}

        //public override void Activate()
        //{
        //    var locator = CrossGeolocation.Current;
        //        locator.DesiredAccuracy = 100;

        //        Task.Run(async () => 
        //        {
        //            await setLocation((position) =>
        //                        ExecuteCallBack(new Location { Lat = position.Latitude, Lon = position.Longitude }));
        //        });
        //}
    }
}
