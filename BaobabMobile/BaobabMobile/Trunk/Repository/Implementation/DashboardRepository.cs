using System;
using System.Threading.Tasks;
using CorePCL;
using BaobabMobile.Implementation.ViewModel;
using BaobabMobile.Interface.Repository;
using BaobabMobile.Interface.Service;
using BaobabMobile.Root.Repository;
using BaobabMobile.Trunk.Injection.Location;
using Xamarin.Forms;
using BaobabMobile.Trunk.Injection.SignalStrength;

namespace BaobabMobile.Implementation.Repository
{
    public class DashboardRepository<T> : ProjectBaseRepository, IDashboardRepository<T>
        where T : BaseViewModel
    {
        public DashboardViewModel _Model;
        IDashboardService<T> _Service;
        ILocationService<ILocation> _LocationService;
        ISignalStrengthService<ISignalStrength> _SignalStrengthService;

        public DashboardRepository(IMasterRepository masterRepository, IDashboardService<T> service, DashboardViewModel model)
            : base(masterRepository)
        {
            _Service = service;
            _LocationService = DependencyService.Get<ILocationService<ILocation>>();
            _LocationService.LocationUpdated += HandleLocationChanged;
            _Model = model;
            _LocationService.StartLocationUpdates();
            _SignalStrengthService = DependencyService.Get<ISignalStrengthService<ISignalStrength>>();
            _SignalStrengthService.SignalStrengthChanged += HandleSignlStrengthChanged;

        }

        private void translate(DashboardViewModel oldObj, ILocation newObj)
        {
            oldObj.Lat = newObj.Lat;
            oldObj.Lon = newObj.Lon;
        }

        #region Public Methods
        public async void HandleLocationChanged(object sender, LocationUpdatedEventArgs<ILocation> e)
        {
            translate(_Model, e.Location);
            await Refresh(_Model, (obj) => { });
        }
        public void HandleSignlStrengthChanged(object sender, SignalStrengthUpdatedEventArgs<ISignalStrength> e)
        {
            
        }
        #endregion

        public void Minimize()
        {
            throw new NotImplementedException();
        }

        public async Task Refresh(DashboardViewModel model, Action<T> completeAction)
        {
            translate(model, _Model);
            var serviceReturnModel = await _Service.Refresh(model);
            completeAction(serviceReturnModel);
        }
    }
}