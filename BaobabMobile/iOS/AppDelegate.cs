using BaobabMobile.iOS.Injection;
using BaobabMobile.iOS.Injection.Base;
using BaobabMobile.Trunk.Injection.Base;
using BaobabMobile.Trunk.Injection.Location;
using CoreLocation;
using Foundation;
using UIKit;

namespace BaobabMobile.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            PlatformServiceBonsai<IPlatformModelBase> service = new LocationService();

            PlatformSingleton.Instance.PlatformServiceList.Add(
                new BonsaiPlatformServiceRegistrationStruct
                {
                    ServiceKey = "LocationService",
                    Manager = new CLLocationManager
                    {
                        PausesLocationUpdatesAutomatically = false
                    },
                platformHarness = service,
            });
                //"LocationService",
                //                                               new CLLocationManager
                //{
                //    PausesLocationUpdatesAutomatically = false
                //});
            global::Xamarin.Forms.Forms.Init();
            LoadApplication(new App());
            return base.FinishedLaunching(app, options);
        }

        public override void OnActivated(UIApplication application)
        {
            if (application.BackgroundRefreshStatus == UIBackgroundRefreshStatus.Available)
            {
                PlatformBonsai.NotifyOfBackgroundChange(
                    new PlatformModelBonsai{ IsBackgroundAvailable = true });
            }
            else
            {
                PlatformBonsai.NotifyOfBackgroundChange(
                    new PlatformModelBonsai { IsBackgroundAvailable = false });
            }
        }

        public override void DidEnterBackground(UIApplication application)
        {
            PlatformBonsai.NotifyOfBackgroundChange(
                new PlatformModelBonsai { IsBackgroundAvailable = true, IsInBackground = true });
        }

        public override void WillEnterForeground(UIApplication uiApplication)
        {
            base.WillEnterForeground(uiApplication);
            PlatformBonsai.NotifyOfBackgroundChange(
                new PlatformModelBonsai { IsBackgroundAvailable = true, IsInBackground = false });
        }
    }
}

