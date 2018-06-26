using System.ComponentModel;
using BaobabMobile.Root.ViewModel;
using BaobabMobile.Trunk.Injection.Location;

namespace BaobabMobile.Implementation.ViewModel
{
    public class DashboardViewModel : ProjectBaseViewModel, ILocation, INotifyPropertyChanged
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
    }
}