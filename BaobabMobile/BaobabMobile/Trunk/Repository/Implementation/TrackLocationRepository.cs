using System;
using System.Threading.Tasks;
using CorePCL;
using BaobabMobile.Implementation.ViewModel;
using BaobabMobile.Interface.Repository;
using BaobabMobile.Interface.Service;
using BaobabMobile.Root.Repository;

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
        }

        public async Task TrackLocation(TrackLocationViewModel model, Action<T> completeAction)
        {
            var serviceReturnModel = await _Service.TrackLocation(model);
            completeAction(serviceReturnModel);
        }
    }
}