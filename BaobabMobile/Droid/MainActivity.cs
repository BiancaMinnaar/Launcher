using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Acr.UserDialogs;
using BaobabMobile.Droid.Injection.Base;
using BaobabMobile.Trunk.Injection.Base;
using BaobabMobile.Droid.Injection.Location;
using Android.Runtime;
using Plugin.Permissions;
using Plugin.CurrentActivity;
using BaobabMobile.Droid.Injection.FingerPrintScanner;
using Android.Nfc;
using Poz1.NFCForms.Droid;
using Poz1.NFCForms.Abstract;

namespace BaobabMobile.Droid
{
    [Activity(Label = "BaobabMobile.Droid", Theme = "@style/MyTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        public NfcAdapter NFCdevice;
        public NfcForms x;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            CrossCurrentActivity.Current.Init(this, bundle);
            UserDialogs.Init(this);

            NfcManager NfcManager = (NfcManager)Android.App.Application.Context.GetSystemService(Context.NfcService);
            NFCdevice = NfcManager.DefaultAdapter;

            Xamarin.Forms.DependencyService.Register<INfcForms, NfcForms>();
            x = Xamarin.Forms.DependencyService.Get<INfcForms>() as NfcForms;

            PlatformSingleton.Instance.PlatformServiceList.Add
                             <LocationServiceCurrentActivity>(null);
            PlatformSingleton.Instance.PlatformServiceList.Add
                             <FingerPrintService>(null);


            //PlatformSingelton.Instance.PlatformServiceList.Add("TelephonyService",
            //    GetSystemService(Context.TelephonyService));
            //PlatformSingelton.Instance.PlatformServiceList.Add("NfcManager",
                                                               //GetSystemService(Context.NfcService));
            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());
        }

        protected override void OnResume()
        {
            base.OnResume();
            if (NFCdevice != null)
            {
                var intent = new Intent(this, GetType()).AddFlags(ActivityFlags.SingleTop);
                NFCdevice.EnableForegroundDispatch
                (
                    this,
                    PendingIntent.GetActivity(this, 0, intent, 0),
                    new[] { new IntentFilter(NfcAdapter.ActionTechDiscovered) },
                    new string[][] {new string[] {
                            NFCTechs.Ndef,
                        },
                        new string[] {
                            NFCTechs.MifareClassic,
                        },
                    }
                );
            }
        }

        protected override void OnPause()
        {
            base.OnPause();
            NFCdevice.DisableForegroundDispatch(this);
        }

        protected override void OnNewIntent(Intent intent)
        {
            base.OnNewIntent(intent);
            x.OnNewIntent(this, intent);
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