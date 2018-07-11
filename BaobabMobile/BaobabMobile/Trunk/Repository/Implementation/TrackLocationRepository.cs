using System;
using System.Threading.Tasks;
using CorePCL;
using BaobabMobile.Implementation.ViewModel;
using BaobabMobile.Interface.Repository;
using BaobabMobile.Interface.Service;
using BaobabMobile.Root.Repository;
using BaobabMobile.Trunk.Injection.Location;

namespace BaobabMobile.Implementation.Repository
{
    public class TrackLocationRepository<T> : ProjectBaseRepository, ITrackLocationRepository<T>
        where T : BaseViewModel
    {
        ITrackLocationService<T> _Service;

        public TrackLocationRepository(IMasterRepository masterRepository, ITrackLocationService<T> service)
            : base(masterRepository)
        {
            _Service = service;
            _MasterRepo.OnPlatformServiceCallBack.Add(async (platformHarness, model) =>
            {
                if (platformHarness.ServiceKey.Equals("LocationService"))
                {
                    var locationModel = new TrackLocationViewModel
                    {
                        Lat = ((ILocation)model).Lat,
                        Lon = ((ILocation)model).Lon
                    };
                    await _Service.TrackLocation(locationModel);
                }
            });
        }

        public async Task TrackLocation(TrackLocationViewModel model, Action<T> completeAction)
        {
            var serviceReturnModel = await _Service.TrackLocation(model);
            completeAction(serviceReturnModel);
        }
    }
}