namespace BaobabMobile.Trunk.Injection.Base
{
    public interface IPlatformModelBonsai : IPlatformModelBase
    {
        bool IsBackgroundAvailable { get; set; }
        bool IsInBackground { get; set; }
    }
}
