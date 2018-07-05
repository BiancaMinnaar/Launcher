using BaobabMobile.Implementation.View;
using BaobabMobile.Trunk.Repository.Implementation;
using Xamarin.Forms;

namespace BaobabMobile
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            var _MasterRepo = MasterRepository.MasterRepo;
            _MasterRepo.SetRootView(new NavigationPage(new DashboardView()));
            MainPage = _MasterRepo.GetRootView();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}

