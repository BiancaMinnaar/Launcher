using System.Threading.Tasks;
using CorePCL;
using BaobabMobile.Implementation.ViewModel;

namespace BaobabMobile.Interface.Service
{
    public interface IMainMenuService<T>
        where T : BaseViewModel
    {
        Task<T> Load(MainMenuViewModel model);
    }
}

