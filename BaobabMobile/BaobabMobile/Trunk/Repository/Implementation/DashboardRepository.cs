using System;
using System.Threading.Tasks;
using CorePCL;
using BaobabMobile.Implementation.ViewModel;
using BaobabMobile.Interface.Repository;
using BaobabMobile.Interface.Service;
using BaobabMobile.Root.Repository;
using BaobabMobile.Trunk.Injection;
using Xamarin.Forms;

namespace BaobabMobile.Implementation.Repository
{
    public class DashboardRepository<T> : ProjectBaseRepository, IDashboardRepository<T>
        where T : BaseViewModel
    {
        DashboardViewModel _Model;
        IDashboardService<T> _Service;
        ILocationService<ILocation> _LocationService;

        public DashboardRepository(IMasterRepository masterRepository, IDashboardService<T> service, DashboardViewModel model)
            : base(masterRepository)
        {
            _Service = service;
            _LocationService = DependencyService.Get<ILocationService<ILocation>>();
            _LocationService.LocationUpdated += HandleLocationChanged;
            _Model = model;
            _LocationService.StartLocationUpdates();
        }

        #region Public Methods
        public void HandleLocationChanged(object sender, LocationUpdatedEventArgs<ILocation> e)
        {
            _Model.Lat = e.Location.Lat;
        }
        #endregion

        public void Minimize()
        {
            throw new NotImplementedException();
        }

        public async Task Refresh(DashboardViewModel model, Action<T> completeAction)
        {
            
            var serviceReturnModel = await _Service.Refresh(model);
            completeAction(serviceReturnModel);
        }
    }
}