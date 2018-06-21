using System.Threading.Tasks;
using CorePCL;
using BaobabMobile.Implementation.ViewModel;

namespace BaobabMobile.Interface.Service
{
    public interface ILoginService<T>
        where T : BaseViewModel
    {
        Task<T> Login(LoginViewModel model);
    }
}

