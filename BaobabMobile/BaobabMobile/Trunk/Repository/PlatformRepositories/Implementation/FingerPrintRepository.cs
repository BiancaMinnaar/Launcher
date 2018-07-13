using BaobabMobile.Interface.Repository;
using BaobabMobile.Root.Repository;
using CorePCL;

namespace BaobabMobile.Trunk.Repository.PlatformRepositories.Implementation
{
    public class FingerPrintRepository<T> : ProjectBaseRepository, IFingerPrintRepository<T>
        where T : BaseViewModel
    {
        public FingerPrintRepository(IMasterRepository masterRepository)
            : base(masterRepository)
        {
            _MasterRepo.OnPlatformServiceCallBack.Add(async (serviceKey, model) =>
            {
                if (serviceKey.Equals("FingerPrintService"))
                {
                    var me = model;
                }
            });
        }
    }
}
