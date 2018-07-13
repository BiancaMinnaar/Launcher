using System.ComponentModel;
using BaobabMobile.Root.ViewModel;

namespace BaobabMobile.Implementation.ViewModel
{
    public class DashboardViewModel : ProjectBaseViewModel, INotifyPropertyChanged
    {
        public new event PropertyChangedEventHandler PropertyChanged;
        double lon;
        public double Lon
        {
            get => lon;
            set
            {
                lon = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Lon"));
            }
        }
        double lat;
        public double Lat
        {
            get => lat;
            set
            {
                lat = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Lat"));
            }
        }

        int signalStrength;
        public int SignalStrength
        {
            get => signalStrength;
            set
            {
                signalStrength = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SignalStrength"));
            }
        }

        double motionVectorX;
        public double MotionVectorX
        {
            get => motionVectorX;
            set
            {
                motionVectorX = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MotionVectorX"));
            }
        }

        double motionVectorY;
        public double MotionVectorY
        {
            get => motionVectorY;
            set
            {
                motionVectorY = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MotionVectorY"));
            }
        }

        double motionVectorZ;
        public double MotionVectorZ
        {
            get => motionVectorZ;
            set
            {
                motionVectorZ = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MotionVectorZ"));
            }
        }

        double compassValue;
        public double CompassValue
        {
            get => compassValue;
            set
            {
                compassValue = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CompassValue"));
            }
        }
    }
}