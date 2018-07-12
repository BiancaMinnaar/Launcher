using System;
using System.Collections.Generic;
using BaobabMobile.Root.ViewModel;
using BaobabMobile.Trunk.Injection.Base;
using Xamarin.Forms;

namespace BaobabMobile.Interface.Repository
{
    public interface IMasterRepository
    {
        MasterModel DataSource { get; set; }
        void SetRootView(Page rootView);
        Page GetRootView();
        void PushLogOut();
        void PopView();
        void PopModal();
        void ShowLoading();
        void HideLoading();
        void DumpJson<T>(string heading, T objectToDump);
        void ReportToAllListeners(string serviceKey, IPlatformModelBase model);
        void PushDashboardView();
        void ShowMenu();
        void CloseMenu();
        Action<string[]> OnError { get; set; }
        List<Action<string, IPlatformModelBase>> OnPlatformServiceCallBack {get;set;}
    }
}
