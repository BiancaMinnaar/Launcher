using BaobabMobile.Trunk.Injection.Base;

namespace BaobabMobile.Trunk.Injection.Background
{
    public interface IBackgroundModel<T> : IPlatformService<T> where T : IBackgroundModel
    {

    }
}