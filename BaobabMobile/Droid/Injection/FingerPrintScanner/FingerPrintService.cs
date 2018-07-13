using System.Threading.Tasks;
using BaobabMobile.Droid.Injection.FingerPrintScanner;
using BaobabMobile.Trunk.Injection.Base;
using Plugin.Fingerprint;
using Xamarin.Forms;

[assembly: Dependency(typeof(FingerPrintService))]
namespace BaobabMobile.Droid.Injection.FingerPrintScanner
{
    public class FingerPrintService : PlatformServiceBonsai<IPlatformModelBase>
    {
        public override string ServiceKey => "FingerPrintService";

        public override void Activate()
        {
            base.Activate();
            Task.Run(async () => await method());
        }

        async Task method()
        {
            var result = await CrossFingerprint.Current.AuthenticateAsync("Prove you have fingers!");
            if (result.Authenticated)
            {
                ExecuteCallBack(new FingerPrint{IsValid=true});
            }
            else
            {
                // not allowed to do secret stuff :(
            }
        }
    }
}
