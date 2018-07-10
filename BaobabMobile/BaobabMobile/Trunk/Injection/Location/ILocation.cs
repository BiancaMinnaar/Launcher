using BaobabMobile.Trunk.Injection.Base;

namespace BaobabMobile.Trunk.Injection.Location
{
    public interface ILocation : IPlatformModelBase
    {
        double Lat { get; set; }
        double Lon { get; set; }
    }
}
