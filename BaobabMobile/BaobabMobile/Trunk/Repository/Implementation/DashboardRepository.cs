using System;
using BaobabMobile.Implementation.ViewModel;
using BaobabMobile.Interface.Repository;
using BaobabMobile.Interface.Service;
using BaobabMobile.Root.Repository;
using BaobabMobile.Trunk.Injection.Location;
using BaobabMobile.Trunk.Repository.Implementation;
using CorePCL;

namespace BaobabMobile.Implementation.Repository
{
    public class DashboardRepository<T> : ProjectBaseRepository, IDashboardRepository<T>
        where T : BaseViewModel
    {
        public DashboardViewModel _Model;
        IDashboardService<T> _Service;

        Action<string[]> IDashboardRepository<T>.OnError 
        { get; set; }

        public DashboardRepository(
            IMasterRepository masterRepository, 
            IDashboardService<T> service, 
            ITrackLocationService<TrackLocationViewModel> trackLocationService,
            DashboardViewModel model)
            : base(masterRepository)
        {
            //var tracker = new TrackLocationRepository<TrackLocationViewModel>(_MasterRepo, trackLocationService);
            _Service = service;
            _Model = model;
            var platform = new PlatformRepository<DashboardViewModel>(masterRepository);
        }

        public void AddLocationServiceListernerToUpdateModel(DashboardViewModel model)
        {
            _MasterRepo.OnPlatformServiceCallBack.Add((serviceKey, locationM) =>
            {
                if (serviceKey.Equals("LocationService"))
                {
                    model.Lat = ((ILocation)locationM).Lat;
                    model.Lon = ((ILocation)locationM).Lon;
                }
            });
        }
    }
}