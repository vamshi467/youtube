using System;
using NewControlsDemo.Services;
using Prism.Navigation;

namespace NewControlsDemo.ViewModels
{
    public class WebUrlTestPageViewModel : BaseViewModel
    {
        public WebUrlTestPageViewModel(INavigationService navigationService, FacadeService facadeService)
             : base(navigationService, facadeService)
        {
            AccountPageURL = "http://34.216.71.66/Plaid/Plaid";
        }

        private string _accountPageURL;
        public string AccountPageURL
        {
            get { return _accountPageURL; }
            set { SetProperty(ref _accountPageURL, value); }
        }

    }
}
