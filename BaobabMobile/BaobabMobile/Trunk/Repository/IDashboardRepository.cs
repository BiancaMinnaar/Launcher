using System;
using System.Threading.Tasks;
using CorePCL;
using BaobabMobile.Implementation.ViewModel;

namespace BaobabMobile.Interface.Repository
{
    public interface IDashboardRepository<T>
        where T : BaseViewModel
    {
        Task Refresh(DashboardViewModel model, Action<T> completeAction);
        void Minimize();
    }
}
