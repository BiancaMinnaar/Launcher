using System;
namespace BaobabMobile.Trunk.Repository
{
    public interface IMobileDeviceRepository
    {
        void TrackGPS();
        void RegisterSignalStrength();
        void RegisterDeviceMovement();
        void RegisterProvider();
        void UpdateApplication();
    }
}
