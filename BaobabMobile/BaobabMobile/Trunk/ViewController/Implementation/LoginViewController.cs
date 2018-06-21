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
    public class LoginViewController : ProjectBaseViewController<LoginViewModel>, ILoginViewController
    {
        ILoginRepository<LoginViewModel> _Reposetory;
        ILoginService<LoginViewModel> _Service;

        public override void SetRepositories()
        {
            _Service = new LoginService<LoginViewModel>((U, P, C, A) => 
                                                           ExecuteQueryWithReturnTypeAndNetworkAccessAsync<LoginViewModel>(U, P, C, A));
            _Reposetory = new LoginRepository<LoginViewModel>(_MasterRepo, _Service);
        }

        public async Task Login()
        {
            await _Reposetory.Login(InputObject, (LoginViewModel obj) => { });
        }
    }
}