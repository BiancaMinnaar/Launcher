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
        }
    }
}
