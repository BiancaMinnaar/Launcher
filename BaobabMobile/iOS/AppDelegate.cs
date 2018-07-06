using System;
using System.Collections.Generic;
using System.Linq;
using BaobabMobile.iOS.Injection.Base;
using Foundation;
using UIKit;

namespace BaobabMobile.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
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

