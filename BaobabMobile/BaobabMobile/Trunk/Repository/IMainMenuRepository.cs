using System;
using System.Threading.Tasks;
using CorePCL;
using BaobabMobile.Implementation.ViewModel;

namespace BaobabMobile.Interface.Repository
{
    public interface IMainMenuRepository<T>
        where T : BaseViewModel
    {
        Task Load(MainMenuViewModel model, Action<T> completeAction);
    }
}
