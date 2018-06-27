﻿using System.Threading.Tasks;
using BaobabMobile.Trunk.Injection.Base;

namespace BaobabMobile.Trunk.Injection.Location
{
    public interface ILocationService<T> : IPlatformService<T> where T : ILocation
    {
        Task StartLocationUpdates();
    }
}
