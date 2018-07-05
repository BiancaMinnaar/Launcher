using System;
using System.Threading.Tasks;
using CorePCL;
using BaobabMobile.Implementation.ViewModel;
using BaobabMobile.Interface.Repository;
using BaobabMobile.Interface.Service;
using BaobabMobile.Root.Repository;

namespace BaobabMobile.Implementation.Repository
{
    public class MainMenuRepository<T> : ProjectBaseRepository, IMainMenuRepository<T>
        where T : BaseViewModel
    {
        IMainMenuService<T> _Service;

        public MainMenuRepository(IMasterRepository masterRepository, IMainMenuService<T> service)
            : base(masterRepository)
        {
            _Service = service;
        }

        public async Task Load(MainMenuViewModel model, Action<T> completeAction)
        {
            var serviceReturnModel = await _Service.Load(model);
            completeAction(serviceReturnModel);
        }
    }
}