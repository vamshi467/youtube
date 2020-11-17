using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using NewControlsDemo.Services;
using NewControlsDemo.Views.Popups;
using Plugin.Connectivity;
using Plugin.FirebaseAuth;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Rg.Plugins.Popup.Pages;
using Xamarin.Forms;

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
        public DelegateCommand LogoutCommand { get { return new DelegateCommand(async () => await LogoutClick()); } }

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

        public async Task LogoutClick()
        {
            try
            {
                CrossFirebaseAuth.Current.Instance.SignOut();
                SettingsService.FirebaseLoggedInUser = null;
                await _navigationService.NavigateAsync($"/{nameof(NavigationPage)}/{nameof(MainPage)}");
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
        }

        public async Task<bool> CheckConnectivity()
        {
            try
            {
                var isConnected = CrossConnectivity.Current.IsConnected;
                if (!isConnected)
                {
                    await DisplayAlertAsync("Could not connect to internet. Please check your internet connection.");
                }
                return isConnected;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public static async Task DisplayAlertAsync(string message)
        {
            if (!string.IsNullOrEmpty(message) && App.Current.MainPage != null)
            {
                await App.Current.MainPage.DisplayAlert("Alert", message, "OK");
            }
        }

        public async Task ShowLoader(bool animate = false)
        {
            try
            {
                await ShowPopup(new LoadingPopup(), animate);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static async Task ShowPopup(PopupPage popup, bool animate = false)
        {
            try
            {
                await PopupNavigationService.Instance.PushAsync(popup, animate);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static async Task ClosePopup(bool animate = false)
        {
            try
            {
                if (PopupNavigationService.Instance.PopupStack != null && PopupNavigationService.Instance.PopupStack.Count > 0)
                {
                    var lastPage = PopupNavigationService.Instance.PopupStack.LastOrDefault();
                    await PopupNavigationService.Instance.PopAsync(animate);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public virtual void OnNavigatedFrom(INavigationParameters parameters) { }

        public virtual void OnNavigatedTo(INavigationParameters parameters) { }

        public void Destroy() { }
    }
}
