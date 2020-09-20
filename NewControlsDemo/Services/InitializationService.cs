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
            return $"/{nameof(MainPage)}"; // MailTemplatePage
        }
    }
}