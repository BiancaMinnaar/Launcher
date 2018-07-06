using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Acr.UserDialogs;
using CorePCL;
using BaobabMobile.Interface.Repository;
using BaobabMobile.Root.Repository;
using BaobabMobile.Root.ViewModel;
using Newtonsoft.Json;
using Xamarin.Forms;
using BaobabMobile.Implementation.View;

namespace BaobabMobile.Trunk.Repository.Implementation
{
    public class MasterRepository : ProjectBaseRepository, IMasterRepository
    {
        private static MasterRepository _Reposetory = new MasterRepository();
        private static readonly object syncronisationLock = new object();
        public MasterModel DataSource { get; set; }
        private INavigation _Navigation;
        private Page _RootView;
        public Func<string, Dictionary<string, object>, BaseNetworkAccessEnum, Task> NetworkInterface { get; set; }
        public Func<string, Dictionary<string, ParameterTypedValue>, BaseNetworkAccessEnum, Task> NetworkInterfaceWithTypedParameters { get; set; }

        MasterRepository()
            : base(null)
        {
            DataSource = new MasterModel();
        }

        public static MasterRepository MasterRepo
        {
            get { return _Reposetory; }
        }

        public void SetRootView(Page rootView)
        {
            _RootView = rootView;
            _Navigation = rootView.Navigation;
            
        }

        public Page GetRootView()
        {
            return _RootView;
        }

        public void PushLogOut()
        {
            DataSource.Authenticated = false;
            _Navigation.PopToRootAsync();
        }

        public void PopView()
        {
            _Navigation.PopAsync();
        }

        public void PopModal()
        {
            _Navigation.PopModalAsync();
        }

        public void ShowLoading()
        {
            UserDialogs.Instance.ShowLoading();
        }

        public void HideLoading()
        {
            UserDialogs.Instance.HideLoading();
        }

        public void DumpJson<T>(string heading, T objectToDump)
        {
            Debug.WriteLine(heading);
            Debug.WriteLine(JsonConvert.SerializeObject(objectToDump));
        }

        public void PushDashboardView()
        {
            _Navigation.PushAsync(new DashboardView());
        }

        public void ShowMenu()
        {
            _Navigation.PushModalAsync(new MainMenuView());
        }

        public void CloseMenu()
        {
            _Navigation.PopModalAsync();
        }
    }
}

