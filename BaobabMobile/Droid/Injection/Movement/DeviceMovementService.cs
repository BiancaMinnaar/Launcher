using BaobabMobile.Droid.Injection.Movement;
using BaobabMobile.Trunk.Injection.Base;
using BaobabMobile.Trunk.Injection.Movement;
using DeviceMotion.Plugin;
using DeviceMotion.Plugin.Abstractions;
using Xamarin.Forms;

[assembly: Dependency(typeof(DeviceMovementService))]
namespace BaobabMobile.Droid.Injection.Movement
{
    public class DeviceMovementService : PlatformServiceBonsai<IDeviceMovement>, IDeviceMovementService<IDeviceMovement>
    {
        public override void Activate()
        {
            CrossDeviceMotion.Current.SensorValueChanged += (s, a) => {

                switch (a.SensorType)
                {
                    case MotionSensorType.Accelerometer:
                        HandleServiceReturn(((MotionVector)a.Value).X, ((MotionVector)a.Value).Y, ((MotionVector)a.Value).Z, 0);
                        break;
                    case MotionSensorType.Compass:
                        HandleServiceReturn(0, 0, 0, a.Value.Value);
                        break;
                }
            };
        }

        void HandleServiceReturn(double x, double y, double z, double? compassReading)
        {
            ExecuteCallBack(new DeviceMovement { MotionVectorX = x, MotionVectorY=y, MotionVectorZ=z, CompassValue=compassReading.GetValueOrDefault() });
        }
    }
}
