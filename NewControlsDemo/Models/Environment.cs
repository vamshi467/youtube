using System;
using NewControlsDemo.Helpers;
using Xamarin.Forms;

namespace NewControlsDemo.Models
{
    /// <summary>
    /// Environment Identifier
    /// </summary>
    public enum EnvironmentName
    {
        /// <summary>
        /// None Environment
        /// </summary>
        None = -1,
        /// <summary>
        /// Development Environment Identifier
        /// </summary>
        Dev = 0,
        /// <summary>
        /// Production Environment Identifier
        /// </summary>
        Prod = 1
    }

    public class Environment
    {
        public EnvironmentName Name { get; set; }
        /// <summary>
        /// BaseUrl
        /// </summary>
        public String BaseUrl { get; set; }
        /// <summary>
        /// GoogleApiKey
        /// </summary>
        public string GoogleApiKey { get; set; }
        /// <summary>
        /// ClientId
        /// </summary>
        public String ClientId { get; set; }
        /// <summary>
        /// ClientSecret
        /// </summary>
        public String ClientSecret { get; set; }
        /// <summary>
        /// PassClientId
        /// </summary>
        public String PassClientId { get; set; }
        /// <summary>
        /// PassClientSecret
        /// </summary>
        public String PassClientSecret { get; set; }

        /// <summary>
        /// GoogleClientId
        /// </summary>
        public string GoogleClientId { get; set; }

        /// <summary>
        /// GoogleScope
        /// </summary>
        public string GoogleScope { get; set; }

        /// <summary>
        /// GoogleAuthorizeUrl
        /// </summary>
        public string GoogleAuthorizeUrl { get; set; }

        /// <summary>
        /// GoogleRedirectUrl
        /// </summary>
        public string GoogleRedirectUrl { get; set; }

        /// <summary>
        /// GoogleAcessTokenUrl
        /// </summary>
        public string GoogleAcessTokenUrl { get; set; }

        /// <summary>
        /// GoogleAcessTokenUrl
        /// </summary>
        public bool GoogleIsUsingNativeUI { get; set; }
        public string FirebaseClientURL { get; set; }

        /// <summary>
        /// Load Development Settings
        /// </summary>
        /// <returns></returns>
        public static Environment Dev
        {
            get
            {
                return new Environment
                {
                    Name = EnvironmentName.Dev,
                    BaseUrl = "",
                    GoogleApiKey = Constants.ApiKey,
                    GoogleClientId = Device.RuntimePlatform == Device.Android ? Constants.AndroidGoogleId :  Constants.iOSGoogleId,
                    GoogleScope = "https://www.googleapis.com/auth/userinfo.profile https://www.googleapis.com/auth/userinfo.email https://www.googleapis.com/auth/plus.login",
                    GoogleAuthorizeUrl = "https://accounts.google.com/o/oauth2/auth",
                    GoogleRedirectUrl = Device.RuntimePlatform == Device.Android ? Constants.AndroidRevereseGoogleId : Constants.iOSRevereseGoogleId,
                    GoogleAcessTokenUrl = "https://www.googleapis.com/oauth2/v4/token",
                    GoogleIsUsingNativeUI = true,
                    FirebaseClientURL = "https://ytplayer-62ebd.firebaseio.com",
                    apiFragment = new APIFragment(EnvironmentName.Dev)
                };
            }
        }

        public APIFragment apiFragment { get; set; }

        /// <summary>
        /// Load Production Settings
        /// </summary>
        /// <returns></returns>
        public static Environment Prod
        {
            get
            {
                return new Environment
                {
                    Name = EnvironmentName.Prod,
                    BaseUrl = "",
                    GoogleApiKey = Constants.ApiKey,
                    GoogleClientId = Device.RuntimePlatform == Device.Android ? Constants.AndroidGoogleId : Constants.iOSGoogleId,
                    GoogleScope = "https://www.googleapis.com/auth/userinfo.profile https://www.googleapis.com/auth/userinfo.email https://www.googleapis.com/auth/plus.login",
                    GoogleAuthorizeUrl = "https://accounts.google.com/o/oauth2/auth",
                    GoogleRedirectUrl = Device.RuntimePlatform == Device.Android ? Constants.AndroidRevereseGoogleId : Constants.iOSRevereseGoogleId,
                    GoogleAcessTokenUrl = "https://www.googleapis.com/oauth2/v4/token",
                    GoogleIsUsingNativeUI = true,
                    FirebaseClientURL = "https://ytplayer-62ebd.firebaseio.com",
                    apiFragment = new APIFragment(EnvironmentName.Dev)
                };
            }
        }

    }
}