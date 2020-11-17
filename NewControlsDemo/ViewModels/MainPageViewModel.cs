using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using NewControlsDemo.Models;
using NewControlsDemo.Services;
using NewControlsDemo.Views;
using Plugin.FirebaseAuth;
using Prism.Commands;
using Prism.Navigation;
using Xamarin.Auth;
using Xamarin.Auth.Presenters;
using Xamarin.Forms;

namespace NewControlsDemo.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        public MainPageViewModel(INavigationService navigationService, FacadeService facadeService)
            : base(navigationService, facadeService)
        {
        }

        #region Private Properties

        OAuth2Authenticator oAuth2Authenticator;
        OAuth2ProviderType OAuth2ProviderType { get; set; }

        #endregion

        public DelegateCommand<string> GoogleLoginCommand { get { return new DelegateCommand<string>(async (obj) => await GoogleLoginClick(obj)); } }
        private async Task GoogleLoginClick(string obj)
        {
            try
            {
                if (!await CheckConnectivity())
                {
                    return;
                }
                if (obj == "google")
                {
                    Authenticate(OAuth2ProviderType.GOOGLE);
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }

        private void Authenticate(OAuth2ProviderType providerType)
        {
            try
            {
                OAuthAuthenticatorService service = new OAuthAuthenticatorService();
                oAuth2Authenticator = OAuthAuthenticatorService.CreateOAuth2(providerType);
                oAuth2Authenticator.Completed += OAuth2Authenticator_Completed;
                oAuth2Authenticator.Error += OAuth2Authenticator_Error;

                OAuth2ProviderType = providerType;
                var presenter = new OAuthLoginPresenter();
                
                switch (Device.RuntimePlatform)
                {
                    case Device.iOS:
                        if (providerType == OAuth2ProviderType.GOOGLE)
                        {
                            presenter.Login(oAuth2Authenticator);
                        }
                        break;
                    case Device.Android:
                        presenter.Login(oAuth2Authenticator);
                        break;
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }

        private async void OAuth2Authenticator_Completed(object sender, AuthenticatorCompletedEventArgs eventArgs)
        {
            try
            {
                if (eventArgs.IsAuthenticated)
                {
                    await ShowLoader();
                    var account = eventArgs.Account;
                    var accessToken = account.Properties["access_token"];

                    if (OAuth2ProviderType == OAuth2ProviderType.GOOGLE)
                    {
                        var idToken = account.Properties["id_token"];
                        var credential = CrossFirebaseAuth.Current.GoogleAuthProvider.GetCredential(idToken, accessToken);
                        
                        try
                        {
                            var result = await CrossFirebaseAuth.Current.Instance.SignInWithCredentialAsync(credential);
                            if (result != null && result.User != null)
                            {
                                var user = new User();
                                user.Uid = result.User.Uid;
                                user.DisplayName = result.User.DisplayName;
                                user.Email = result.User.Email;
                                user.IsAnonymous = result.User.IsAnonymous;
                                user.PhoneNumber = result.User.PhoneNumber;
                                user.PhotoUrl = result.User.PhotoUrl;
                                user.ProviderId = result.User.ProviderId;
                                user.IsEmailVerified = result.User.IsEmailVerified;
                                user.CreatedDate = result.User.Metadata.CreationDate.DateTime.ToLocalTime();
                                user.LastLoginDate = result.User.Metadata.LastSignInDate.DateTime.ToLocalTime();

                                SettingsService.FirebaseLoggedInUser = user;

                                await _navigationService.NavigateAsync(InitializationService.FirebaseLoginNavigation());
                            }
                            else
                            {
                                await App.Current.MainPage.DisplayAlert("Alert", "Wrong Credentials", "OK");
                            }
                        }
                        catch (FirebaseAuthException ex)
                        {
                            await App.Current.MainPage.DisplayAlert("Alert", ex.Message, "OK");
                        }
                    }
                }
                else
                {
                    oAuth2Authenticator.OnCancelled();
                    oAuth2Authenticator = default(OAuth2Authenticator);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                await ClosePopup();
            }
        }

        private async void OAuth2Authenticator_Error(object sender, AuthenticatorErrorEventArgs e)
        {
            try
            {
                OAuth2Authenticator authenticator = (OAuth2Authenticator)sender;
                if (authenticator != null)
                {
                    authenticator.Completed -= OAuth2Authenticator_Completed;
                    authenticator.Error -= OAuth2Authenticator_Error;
                }

                string title = "Authentication Error";
                string msg = e.Message;

                Console.WriteLine($"Error authenticating with {OAuth2ProviderType}! Message: {e.Message}");
                await Application.Current.MainPage.DisplayAlert(title, msg, "OK");
            }
            catch (Exception ex)
            {
                await _facadeService.dialogService.DisplayAlertAsync("Exception", ex.Message, "OK");
            }
            finally
            {
                await ClosePopup();
            }
        }

    }
}
