using System;
using System.Threading.Tasks;
using CorePCL;
using BaobabMobile.Implementation.ViewModel;

namespace BaobabMobile.Interface.Repository
{
    public interface IBrowserRepository<T>
        where T : BaseViewModel
    {
        bool TestURL(string urlToTest);
    }
}
