using System;
using System.Diagnostics;
using System.Threading.Tasks;
using NewControlsDemo.Services;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;

namespace NewControlsDemo.ViewModels
{
    public class BaseViewModel: BindableBase, INavigationAware, IDestructible
    {
        protected INavigationService _navigationService { get; private set; }
        protected FacadeService _facadeService { get; private set; }

        public BaseViewModel(INavigationService navigationService, FacadeService facadeService)
        {
            _navigationService = navigationService;
            _facadeService = facadeService;
        }

        public DelegateCommand BackClickCommand { get { return new DelegateCommand(async () => await BackClick()); } }

        /// <summary>
        /// Navigate back to the previous screen. 
        /// </summary>
        /// <returns></returns>
        public async Task BackClick()
        {
            try
            {
                await _navigationService.GoBackAsync();
            }
            catch (Exception ex)
            {
                Debug.Write (ex.Message);
            }
        }

        public void Destroy()
        {
            throw new NotImplementedException();
        }

        public virtual void OnNavigatedFrom(INavigationParameters parameters) { }

        public virtual void OnNavigatedTo(INavigationParameters parameters) { }
    }
}
