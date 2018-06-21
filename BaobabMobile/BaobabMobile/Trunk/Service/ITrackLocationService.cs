using System.Threading.Tasks;
using CorePCL;
using BaobabMobile.Implementation.ViewModel;

namespace BaobabMobile.Interface.Service
{
    public interface ITrackLocationService<T>
        where T : BaseViewModel
    {
        Task<T> TrackLocation(TrackLocationViewModel model);
    }
}

