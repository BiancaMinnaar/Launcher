using System;
using System.Threading.Tasks;
using CorePCL;
using BaobabMobile.Implementation.ViewModel;
using BaobabMobile.Interface.Repository;
using BaobabMobile.Interface.Service;
using BaobabMobile.Root.Repository;

namespace BaobabMobile.Implementation.Repository
{
    public class LoginRepository<T> : ProjectBaseRepository, ILoginRepository<T>
        where T : BaseViewModel
    {
        ILoginService<T> _Service;

        public LoginRepository(IMasterRepository masterRepository, ILoginService<T> service)
            : base(masterRepository)
        {
            _Service = service;
        }

        public async Task Login(LoginViewModel model, Action<T> completeAction)
        {
            var serviceReturnModel = await _Service.Login(model);
            completeAction(serviceReturnModel);
        }
    }
}