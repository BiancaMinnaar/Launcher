using BaobabMobile.Trunk.Injection.Base;

namespace BaobabMobile.Trunk.Injection.FingerPrint
{
    public interface IFingerPrint : IPlatformModelBase
    {
        bool IsValid { get; set; }
    }
}
