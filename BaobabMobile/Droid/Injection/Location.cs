using System;
using BaobabMobile.Trunk.Injection;

namespace BaobabMobile.Droid.Injection
{
    public class Location : ILocation
    {
        public double Lat { get; set; }
        public double Lon { get; set; }
    }
}
