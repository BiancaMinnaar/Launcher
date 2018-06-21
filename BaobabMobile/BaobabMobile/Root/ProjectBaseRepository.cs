using BaobabMobile.Interface.Repository;
using PCLBase.DataContracts;

namespace BaobabMobile.Root.Repository
{
    public class ProjectBaseRepository : BaseRepository
    {
        protected IMasterRepository _MasterRepo;

        public ProjectBaseRepository(IMasterRepository masterRepository)
        {
            _MasterRepo = masterRepository;
        }
    }
}

