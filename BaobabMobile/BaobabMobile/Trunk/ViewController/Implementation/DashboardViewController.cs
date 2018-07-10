using BaobabMobile.Implementation.Repository;
using BaobabMobile.Implementation.Service;
using BaobabMobile.Implementation.ViewModel;
using BaobabMobile.Interface.Repository;
using BaobabMobile.Interface.Service;
using BaobabMobile.Interface.ViewController;
using BaobabMobile.Root.ViewController;

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
        }

        public void Refresh()
        {
            _MasterRepo.OnError = (obj) => 
            {
                foreach(string error in obj)
                {
                    ShowError(error);
                }
            };
            _Reposetory.Refresh(InputObject, (DashboardViewModel obj) => 
            {
            });
        }

        public void ShowMenu()
        {
            _MasterRepo.ShowMenu();
        }
    }
}