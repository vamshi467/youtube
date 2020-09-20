using System;
using NewControlsDemo.Services;
using Prism.Navigation;

namespace NewControlsDemo.ViewModels
{
    public class MailTemplatePageViewModel : BaseViewModel
    {
        public MailTemplatePageViewModel(INavigationService navigationService, FacadeService facadeService)
            : base(navigationService, facadeService)
        {
        }
    }
}
