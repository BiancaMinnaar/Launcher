using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Acr.UserDialogs;
using BaobabMobile.Droid.Injection.Base;
using BaobabMobile.Trunk.Injection.Base;
using BaobabMobile.Droid.Injection.Location;
using Plugin.CurrentActivity;
using Plugin.Permissions;
using Android.Runtime;

namespace BaobabMobile.Droid
{
    [Activity(Label = "BaobabMobile.Droid", Theme = "@style/MyTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            CrossCurrentActivity.Current.Init(this, bundle);
            PlatformSingleton.Instance.PlatformServiceList.Add<LocationService>(
                new BonsaiPlatformServiceRegistrationStruct
                {
                    ServiceKey = "LocationService",
                }, null);


            //PlatformSingelton.Instance.PlatformServiceList.Add("TelephonyService",
            //    GetSystemService(Context.TelephonyService));
            //PlatformSingelton.Instance.PlatformServiceList.Add("NfcManager",
                                                               //GetSystemService(Context.NfcService));
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

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            PermissionsImplementation.Current.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

    }
}