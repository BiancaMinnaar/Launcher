namespace BaobabMobile.Trunk.Injection.Base
{
    public interface IPlatformBonsai<T> : IPlatformService<T> where T : IPlatformModelBonsai
    {
        void SentToBackground();
    }
}
