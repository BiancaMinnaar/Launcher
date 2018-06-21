using System;
using BaobabMobile.Implementation.ViewController;
using BaobabMobile.Implementation.ViewModel;
using BaobabMobile.Root.View;
using Xamarin.Forms;

namespace BaobabMobile.Implementation.View
{
    public partial class BrowserView : ProjectBaseContentPage<BrowserViewController, BrowserViewModel>
    {
        public BrowserView()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            BindingContext = _ViewController.InputObject;
        }

        protected override void SetSVGCollection()
        {
        }

        public void On_Navigate_Event(object sender, EventArgs e)
        {
            var urlAuth = _ViewController.TestURL(_ViewController.InputObject.WebUrl);
            if (urlAuth)
                BaobabBrowser.Source = "https://" + _ViewController.InputObject.WebUrl;
            else
                _ViewController.ShowError("Un Authorised URL");
        }
    }
}


