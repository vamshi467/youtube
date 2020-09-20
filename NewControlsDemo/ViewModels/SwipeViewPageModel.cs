using System;
using NewControlsDemo.Services;
using Prism.Navigation;

namespace NewControlsDemo.ViewModels
{
    public class SwipeViewPageModel : BaseViewModel
    {
        public SwipeViewPageModel(INavigationService navigationService, FacadeService facadeService)
            : base(navigationService, facadeService)
        {
        }

    }
}
