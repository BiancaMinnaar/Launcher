﻿using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Acr.UserDialogs;
using BaobabMobile.Droid.Injection.Base;

namespace BaobabMobile.Droid
{
    [Activity(Label = "BaobabMobile.Droid", Theme = "@style/MyTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            PlatformSingelton.Instance.PlatformServiceList.Add("TelephonyService",
                GetSystemService(Context.TelephonyService));
            PlatformSingelton.Instance.PlatformServiceList.Add("NfcManager",
                                                               GetSystemService(Context.NfcService));
            global::Xamarin.Forms.Forms.Init(this, bundle);
            UserDialogs.Init(this);
            LoadApplication(new App());
        }

        protected override void OnStart()
        {
            base.OnStart();
                PlatformBonsai.NotifyOfBackgroundChange(
                    new PlatformModelBonsai { IsBackgroundAvailable = true });
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
        }
    }
}