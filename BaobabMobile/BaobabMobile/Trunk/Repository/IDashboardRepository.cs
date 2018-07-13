using System;
using CorePCL;
using BaobabMobile.Implementation.ViewModel;

namespace BaobabMobile.Interface.Repository
{
    public interface IDashboardRepository<T>
        where T : BaseViewModel
    {
        Action<string[]> OnError { get; set; }
        void AddLocationServiceListernerToUpdateModel(DashboardViewModel model);
    }
}
