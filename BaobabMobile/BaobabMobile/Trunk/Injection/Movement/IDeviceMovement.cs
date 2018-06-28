namespace BaobabMobile.Trunk.Injection.Movement
{
    public interface IDeviceMovement
    {
        double MotionVectorX { get;set; }
        double MotionVectorY { get; set; }
        double MotionVectorZ { get; set; }
        double CompassValue { get; set; }
    }
}
