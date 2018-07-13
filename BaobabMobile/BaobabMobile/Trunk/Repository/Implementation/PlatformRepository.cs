using BaobabMobile.Interface.Repository;
using BaobabMobile.Root.Repository;
using BaobabMobile.Trunk.Injection.Base;
using CorePCL;
using Xamarin.Forms;

namespace BaobabMobile.Trunk.Repository.Implementation
{
    public class PlatformRepository<T> : ProjectBaseRepository, IPlatformRepository<T>
        where T : BaseViewModel
    {
        IPlatformBonsai<IPlatformModelBonsai> _PlatformBonsai;

        public PlatformRepository(IMasterRepository masterRepository)
            : base(masterRepository)
        {
            _PlatformBonsai = DependencyService.Get<IPlatformBonsai<IPlatformModelBonsai>>();
            //??
            _PlatformBonsai.OnError = (obj) =>
            {
                OnError(obj);
            };
            AddCallBackToAllPlatformServices();
        }

        void AddCallBackToAllPlatformServices()
        {
            foreach (var platformService in _PlatformBonsai.GetBonsaiServices)
            {
                platformService.platformHarness.ServiceCallBack = (platformModel) =>
                {
                    SetPlatformModelAndReportToAllListeners(platformService, platformModel);

                };
                platformService.platformHarness.Activate();
            }
        }

        void SetPlatformModelAndReportToAllListeners(BonsaiPlatformServiceRegistrationStruct platformService, IPlatformModelBase platformModel)
        {
            _MasterRepo.DataSource.PlatformModel = platformModel;
            _MasterRepo.ReportToAllListeners(platformService.platformHarness.ServiceKey, platformModel);
        }
    }
}
