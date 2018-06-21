using System;
using System.ComponentModel;
using BaobabMobile.Root.ViewModel;
using BaobabMobile.Trunk.Injection;

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
    }
}