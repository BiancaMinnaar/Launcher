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
using BaobabMobile.Trunk.Repository.Implementation;
using CorePCL;
using Xamarin.Forms;

namespace BaobabMobile.Implementation.Repository
{
    public class DashboardRepository<T> : ProjectBaseRepository, IDashboardRepository<T>
        where T : BaseViewModel
    {
        public DashboardViewModel _Model;
        IDashboardService<T> _Service;
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
            //var tracker = new TrackLocationRepository<TrackLocationViewModel>(_MasterRepo, trackLocationService);
            _Service = service;
            _Model = model;
            var platform = new PlatformRepository<DashboardViewModel>(masterRepository);
                 

            //_MasterRepo.OnPlatformServiceCallBack.Add((serviceKey, locationM) =>
            //{
            //    if (serviceKey.Equals("LocationService"))
            //    {
            //        model.Lat = ((ILocation)locationM).Lat;
            //        model.Lon = ((ILocation)locationM).Lon;
            //    }
            //});


            //_LocationService = DependencyService.Get<ILocationService<ILocation>>();
            //_LocationService.ServiceCallBack = (location) =>
            //{
            //    model.Lat = location.Lat;
            //    model.Lon = location.Lon;
            //};

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

        public void AddLocationServiceListernerToUpdateModel(DashboardViewModel model)
        {
            _MasterRepo.OnPlatformServiceCallBack.Add((serviceKey, locationM) =>
            {
                if (serviceKey.Equals("LocationService"))
                {
                    model.Lat = ((ILocation)locationM).Lat;
                    model.Lon = ((ILocation)locationM).Lon;
                }
            });
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
            var dd = model;
            //translate(model, _Model);
            //var serviceReturnModel = await _Service.Refresh(model);
            //completeAction(serviceReturnModel);
            completeAction(null);
        }
    }
}