using System;
using System.Threading.Tasks;
using CorePCL;
using BaobabMobile.Implementation.ViewModel;

namespace BaobabMobile.Interface.Repository
{
    public interface ILoginRepository<T>
        where T : BaseViewModel
    {
        Task Login(LoginViewModel model, Action<T> completeAction);
    }
}
