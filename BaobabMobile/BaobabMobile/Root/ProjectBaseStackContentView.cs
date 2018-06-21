using BaobabMobile.Root.ViewController;
using BaobabMobile.Root.ViewModel;
using BaobabMobile.Trunk.Repository.Implementation;
using Xamarin.Forms;

namespace BaobabMobile.Root.View
{
    public abstract class ProjectBaseStackContentView<T, M> : StackLayout
        where T : ProjectBaseViewController<M>, new()
        where M : ProjectBaseViewModel
    {
        protected T _ViewController;

        protected ProjectBaseStackContentView()
        {
            _ViewController = new T();
            SetSVGCollection();
            _ViewController._MasterRepo = MasterRepository.MasterRepo;
            _ViewController.SetRepositories();
        }

        protected abstract void SetSVGCollection();
    }
}

