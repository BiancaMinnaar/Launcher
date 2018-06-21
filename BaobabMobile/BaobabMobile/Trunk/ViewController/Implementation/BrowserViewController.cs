using System.Threading.Tasks;
using BaobabMobile.Implementation.Repository;
using BaobabMobile.Implementation.Service;
using BaobabMobile.Implementation.ViewModel;
using BaobabMobile.Interface.Repository;
using BaobabMobile.Interface.Service;
using BaobabMobile.Interface.ViewController;
using BaobabMobile.Root.ViewController;

namespace BaobabMobile.Implementation.ViewController
{
    public class BrowserViewController : ProjectBaseViewController<BrowserViewModel>, IBrowserViewController
    {
        IBrowserRepository<BrowserViewModel> _Reposetory;
        IBrowserService<BrowserViewModel> _Service;

        public override void SetRepositories()
        {
            _Service = new BrowserService<BrowserViewModel>((U, P, C, A) => 
                                                           ExecuteQueryWithReturnTypeAndNetworkAccessAsync<BrowserViewModel>(U, P, C, A));
            _Reposetory = new BrowserRepository<BrowserViewModel>(_MasterRepo, _Service);
        }

        public bool TestURL(string urlToTest)
        {
            return _Reposetory.TestURL(urlToTest);
        }
    }
}