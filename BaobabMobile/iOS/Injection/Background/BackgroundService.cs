using BaobabMobile.iOS.Injection.Background;
using BaobabMobile.Trunk.Injection.Background;
using Xamarin.Forms;

[assembly: Dependency(typeof(BackgroundService))]
namespace BaobabMobile.iOS.Injection.Background
{
    public class BackgroundService : PlatformServiceBonsai<IBackgroundModel>
    {
        public BackgroundService()
        {
        }
    }
}
