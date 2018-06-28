using BaobabMobile.Trunk.Injection.Movement;

namespace BaobabMobile.Droid.Injection.Movement
{
    public class DeviceMovement : IDeviceMovement
    {
        public double MotionVectorX { get; set; }
        public double MotionVectorY { get; set; }
        public double MotionVectorZ { get; set; }
        public double CompassValue { get; set; }
    }
}
