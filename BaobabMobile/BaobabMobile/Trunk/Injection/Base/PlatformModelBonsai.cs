using BaobabMobile.Trunk.Injection.Base;

namespace BaobabMobile.Trunk.Injection.Base
{
    public class PlatformModelBonsai : IPlatformModelBonsai
    {
        public bool IsBackgroundAvailable { get; set; }
        public bool IsInBackground { get; set; }

        public string ErrorMessage { get; }

        public PlatformModelBonsai()
        {
            IsInBackground = false;
            IsBackgroundAvailable = false;
        }
    }
}
