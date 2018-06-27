using System;
namespace BaobabMobile.Trunk.Injection.Base
{
    public interface IPlatformService<T>
    {
        Action<T> ServiceCallback { get; set; }
    }
}
