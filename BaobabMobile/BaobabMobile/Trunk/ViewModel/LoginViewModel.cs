using System;
using BaobabMobile.Root.ViewModel;

namespace BaobabMobile.Implementation.ViewModel
{
    public class LoginViewModel : ProjectBaseViewModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}