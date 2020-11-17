using System;
using NewControlsDemo.Helpers;
using NewControlsDemo.Models;
using Xamarin.Auth;
using Xamarin.Forms;

namespace NewControlsDemo.Services
{
    public class OAuthAuthenticatorService
    {
        private static OAuth2Authenticator oAuth2Authenticator;
        public static OAuth2Authenticator AuthenticationState { get; private set; }
        public static string clientId = null;
        public static string redirectUri = null;

        public OAuthAuthenticatorService()
        {
            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    clientId = Constants.iOSGoogleId;
                    redirectUri = Constants.iOSRevereseGoogleId;
                    break;

                case Device.Android:
                    clientId = Constants.AndroidGoogleId;
                    redirectUri = Constants.AndroidRevereseGoogleId;
                    break;
            }
        }

        public static OAuth2Authenticator CreateOAuth2(OAuth2ProviderType authType)
        {
            switch (authType)
            {
                case OAuth2ProviderType.GOOGLE:
                    oAuth2Authenticator = new AuthenticatorExtensions(
                        clientId: clientId,
                        clientSecret: "",
                        scope: ConfigService.Environment.GoogleScope,
                        authorizeUrl: new Uri(ConfigService.Environment.GoogleAuthorizeUrl),
                        redirectUrl: new Uri(redirectUri),
                        getUsernameAsync: null,
                        isUsingNativeUI: ConfigService.Environment.GoogleIsUsingNativeUI,
                        accessTokenUrl: new Uri(ConfigService.Environment.GoogleAcessTokenUrl))
                    {
                        AllowCancel = true,
                        ShowErrors = false,
                        ClearCookiesBeforeLogin = true
                    };
                    break;
            }
            AuthenticationState = oAuth2Authenticator;
            return oAuth2Authenticator;
        }
    }

    // Xamarin.Auth "Authentication Error: Invalid state from server. Possible forgery!" workaround
    public class AuthenticatorExtensions : OAuth2Authenticator
    {
        public AuthenticatorExtensions(string clientId, string clientSecret, string scope, Uri authorizeUrl, Uri redirectUrl, Uri accessTokenUrl, GetUsernameAsyncFunc getUsernameAsync = null, bool isUsingNativeUI = false) : base(clientId, clientSecret, scope, authorizeUrl, redirectUrl, accessTokenUrl, getUsernameAsync, isUsingNativeUI)
        {
        }
        protected override void OnPageEncountered(Uri url, System.Collections.Generic.IDictionary<string, string> query, System.Collections.Generic.IDictionary<string, string> fragment)
        {
            // Remove state from dictionaries. 
            // We are ignoring request state forgery status 
            // as we're hitting an ASP.NET service which forwards 
            // to a third-party OAuth service itself
            if (query.ContainsKey("state"))
            {
                query.Remove("state");
            }

            if (fragment.ContainsKey("state"))
            {
                fragment.Remove("state");
            }

            base.OnPageEncountered(url, query, fragment);
        }
    }
}
