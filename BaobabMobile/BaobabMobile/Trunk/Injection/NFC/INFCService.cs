using BaobabMobile.Trunk.Injection.Base;

namespace BaobabMobile.Trunk.Injection.NFC
{
    public interface INFCService<T> : IPlatformService<T> where T : IPlatformModelBase
    {
    }
}
