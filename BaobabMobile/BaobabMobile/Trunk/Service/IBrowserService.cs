using System.Threading.Tasks;
using CorePCL;
using BaobabMobile.Implementation.ViewModel;

namespace BaobabMobile.Interface.Service
{
    public interface IBrowserService<T>
        where T : BaseViewModel
    {
        Task<T> Navigate(BrowserViewModel model);
    }
}

