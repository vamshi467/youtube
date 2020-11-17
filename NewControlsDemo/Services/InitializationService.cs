using System;
using NewControlsDemo.Views;
using Xamarin.Forms;

namespace NewControlsDemo.Services
{
    public class InitializationService
    {
        /// <summary>
        /// Navigate
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public static string Navigate()
        {
            if (SettingsService.FirebaseLoggedInUser != null && !string.IsNullOrEmpty(SettingsService.FirebaseLoggedInUser.Uid))
            {
                return $"/{nameof(NavigationPage)}/{nameof(YouTubePlaylistPage)}";
            }
            else
            {
                return $"/{nameof(MainPage)}";  
            }
        }

        public static string FirebaseLoginNavigation()
        {
            return $"/{nameof(NavigationPage)}/{nameof(YouTubePlaylistPage)}";
        }
    }
}