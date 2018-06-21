using System.Threading.Tasks;
using BaobabMobile.Implementation.Repository;
using BaobabMobile.Implementation.Service;
using BaobabMobile.Implementation.ViewModel;
using BaobabMobile.Interface.Repository;
using BaobabMobile.Interface.Service;
using BaobabMobile.Interface.ViewController;
using BaobabMobile.Root.ViewController;

namespace BaobabMobile.Implementation.ViewController
{
    public class TrackLocationViewController : ProjectBaseViewController<TrackLocationViewModel>, ITrackLocationViewController
    {
        ITrackLocationRepository<TrackLocationViewModel> _Reposetory;
        ITrackLocationService<TrackLocationViewModel> _Service;

        public override void SetRepositories()
        {
            _Service = new TrackLocationService<TrackLocationViewModel>((U, P, C, A) => 
                                                           ExecuteQueryWithReturnTypeAndNetworkAccessAsync<TrackLocationViewModel>(U, P, C, A));
            _Reposetory = new TrackLocationRepository<TrackLocationViewModel>(_MasterRepo, _Service);
        }

        public async Task TrackLocation()
        {
            
        }
    }
}