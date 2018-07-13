using BaobabMobile.Implementation.Repository;
using BaobabMobile.Implementation.Service;
using BaobabMobile.Implementation.ViewModel;
using BaobabMobile.Interface.Repository;
using BaobabMobile.Interface.Service;
using BaobabMobile.Interface.ViewController;
using BaobabMobile.Root.ViewController;
using BaobabMobile.Trunk.Injection.Location;

namespace BaobabMobile.Implementation.ViewController
{
    public class DashboardViewController : ProjectBaseViewController<DashboardViewModel>, IDashboardViewController
    {
        IDashboardRepository<DashboardViewModel> _Reposetory;
        IDashboardService<DashboardViewModel> _Service;
        ITrackLocationService<TrackLocationViewModel> _TrackLocationService;

        public override void SetRepositories()
        {
            _Service = new DashboardService<DashboardViewModel>((U, P, C, A) => 
                                                           ExecuteQueryWithReturnTypeAndNetworkAccessAsync<DashboardViewModel>(U, P, C, A));
            _TrackLocationService = new TrackLocationService<TrackLocationViewModel>((U, P, C, A) =>
                                                                                     ExecuteQueryWithReturnTypeAndNetworkAccessAsync<TrackLocationViewModel>(U, P, C, A));
            _Reposetory = new DashboardRepository<DashboardViewModel>(
                _MasterRepo, _Service, _TrackLocationService, InputObject);
            _Reposetory.AddLocationServiceListernerToUpdateModel(InputObject);
        }

        public void ShowMenu()
        {
            _MasterRepo.ShowMenu();
        }
    }
}