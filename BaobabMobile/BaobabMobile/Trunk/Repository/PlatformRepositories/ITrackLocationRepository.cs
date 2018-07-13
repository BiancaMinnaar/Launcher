using System;
using System.Threading.Tasks;
using CorePCL;
using BaobabMobile.Implementation.ViewModel;

namespace BaobabMobile.Interface.Repository
{
    public interface ITrackLocationRepository<T>
        where T : BaseViewModel
    {
        Task TrackLocation(TrackLocationViewModel model, Action<T> completeAction);
    }
}
