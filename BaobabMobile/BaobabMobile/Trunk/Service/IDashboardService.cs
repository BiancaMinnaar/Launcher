using System.Threading.Tasks;
using CorePCL;
using BaobabMobile.Implementation.ViewModel;

namespace BaobabMobile.Interface.Service
{
    public interface IDashboardService<T>
        where T : BaseViewModel
    {
        Task<T> Refresh(DashboardViewModel model);
    }
}

