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
    public class MainMenuViewController : ProjectBaseViewController<MainMenuViewModel>, IMainMenuViewController
    {
        IMainMenuRepository<MainMenuViewModel> _Reposetory;
        IMainMenuService<MainMenuViewModel> _Service;

        public override void SetRepositories()
        {
            _Service = new MainMenuService<MainMenuViewModel>((U, P, C, A) => 
                                                           ExecuteQueryWithReturnTypeAndNetworkAccessAsync<MainMenuViewModel>(U, P, C, A));
            _Reposetory = new MainMenuRepository<MainMenuViewModel>(_MasterRepo, _Service);
        }

        public async Task Load()
        {
            
        }

        public void CloseMenu()
        {
            _MasterRepo.PopModal();
        }

        public void SendToBackground()
        {
            _Reposetory.SendToBackground();
        }
    }
}