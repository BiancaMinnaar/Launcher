using System;
using BaobabMobile.Implementation.ViewController;
using BaobabMobile.Implementation.ViewModel;
using BaobabMobile.Root.View;
using Xamarin.Forms;

namespace BaobabMobile.Implementation.View
{
    public partial class DashboardView : ProjectBaseContentPage<DashboardViewController, DashboardViewModel>
    {
        public DashboardView()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);

        }

        protected override void SetSVGCollection()
        {
        }

		protected override void OnAppearing()
		{
			base.OnAppearing();
            _ViewController.Refresh();
            BindingContext = _ViewController.InputObject;
		}

		public void On_Refresh_Event(object sender, EventArgs e)
        {
            _ViewController.Refresh();
        }

        public void On_Minimize_Event(object sender, EventArgs e)
        {
            
        }
    }
}

