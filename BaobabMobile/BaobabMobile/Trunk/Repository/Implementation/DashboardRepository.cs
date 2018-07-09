using System;
using System.Threading.Tasks;
using BaobabMobile.Implementation.ViewModel;
using BaobabMobile.Interface.Repository;
using BaobabMobile.Interface.Service;
using BaobabMobile.Root.Repository;
using BaobabMobile.Trunk.Injection.Base;
using BaobabMobile.Trunk.Injection.Location;
using BaobabMobile.Trunk.Injection.Movement;
using BaobabMobile.Trunk.Injection.SignalStrength;
using CorePCL;
using Xamarin.Forms;

namespace BaobabMobile.Implementation.Repository
{
    public class DashboardRepository<T> : ProjectBaseRepository, IDashboardRepository<T>
        where T : BaseViewModel
    {
        public DashboardViewModel _Model;
        IDashboardService<T> _Service;
        ILocationService<ILocation> _LocationService;
        ISignalStrengthService<ISignalStrength> _SignalStrengthService;
        IDeviceMovementService<IDeviceMovement> _MovementService;
        IPlatformBonsai<IPlatformModelBonsai> _PlatformBonsai;

        Action<string[]> IDashboardRepository<T>.OnError 
        { get; set; }

        public DashboardRepository(
            IMasterRepository masterRepository, 
            IDashboardService<T> service, 
            ITrackLocationService<TrackLocationViewModel> trackLocationService,
            DashboardViewModel model)
            : base(masterRepository)
        {
            _Service = service;
            _PlatformBonsai = DependencyService.Get<IPlatformBonsai<IPlatformModelBonsai>>();
            _PlatformBonsai.OnError = (obj) => 
            {
                OnError(obj);
            };
            _PlatformBonsai.ServiceCallBack = (platformModel) =>
            {
                _MasterRepo.DataSource.IsBackroundAvailable = platformModel.IsBackgroundAvailable;
                _MasterRepo.DataSource.IsInBackground = platformModel.IsInBackground;
                _MasterRepo.PerformBackground(trackLocationService);

            };
            //_LocationService = DependencyService.Get<ILocationService<ILocation>>();
            //_LocationService.ServiceCallBack = (location) =>
            //{
            //    model.Lat = location.Lat;
            //    model.Lon = location.Lon;
            //};
            //_Model = model;
            //_LocationService.StartLocationUpdates();
            //_SignalStrengthService = DependencyService.Get<ISignalStrengthService<ISignalStrength>>();
            //_SignalStrengthService.ServiceCallBack = (signalStrength) => { model.SignalStrength = signalStrength.Strength; };
            //_MovementService = DependencyService.Get<IDeviceMovementService<IDeviceMovement>>();
            //_MovementService.ServiceCallBack = (movment) => 
            //{
            //    model.MotionVectorX = movment.MotionVectorX;
            //    model.MotionVectorY = movment.MotionVectorY;
            //    model.MotionVectorZ = movment.MotionVectorZ;
            //    model.CompassValue = movment.CompassValue;
            //};
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
            _Model.SignalStrength = e.SignalStrength.Strength;
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