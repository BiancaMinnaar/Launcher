using System;
using BaobabMobile.Implementation.ViewController;
using BaobabMobile.Implementation.ViewModel;
using BaobabMobile.Root.View;
using Xamarin.Forms;

namespace BaobabMobile.Implementation.View
{
    public partial class MainMenuView : ProjectBaseContentPage<MainMenuViewController, MainMenuViewModel>
    {
        public MainMenuView()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            BindingContext = _ViewController.InputObject;
        }

        protected override void SetSVGCollection()
        {
        }

        public async void On_Load_Event(object sender, EventArgs e)
        {
            await _ViewController.Load();
        }

        void HandleCloseClicked(object sender, System.EventArgs e)
        {
            _ViewController.CloseMenu();
        }
    }
}


