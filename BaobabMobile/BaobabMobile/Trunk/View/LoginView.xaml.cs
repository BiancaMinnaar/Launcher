using System;
using BaobabMobile.Implementation.ViewController;
using BaobabMobile.Implementation.ViewModel;
using BaobabMobile.Root.View;
using Xamarin.Forms;

namespace BaobabMobile.Implementation.View
{
    public partial class LoginView : ProjectBaseContentPage<LoginViewController, LoginViewModel>
    {
        public LoginView()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            BindingContext = _ViewController.InputObject;
        }

        protected override void SetSVGCollection()
        {
        }

        public async void On_Login_Event(object sender, EventArgs e)
        {
            await _ViewController.Login();
        }
    }
}


