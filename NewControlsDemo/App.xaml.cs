using System;
using System.Diagnostics;
using NewControlsDemo.Services;
using Plugin.LocalNotification;
using Prism;
using Prism.Ioc;
using Prism.Unity;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

//[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace NewControlsDemo
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer):base (initializer) { }

        public App()
        {
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            IoCService.RegisterTypes(containerRegistry);
        }

        protected override void OnInitialized()
        {
            try
            {
                InitializeComponent();

                // Local Notification tap event listener
                NotificationCenter.Current.NotificationTapped += OnLocalNotificationTapped;

                NavigationService.NavigateAsync(InitializationService.Navigate()).Wait();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Exception: {ex.Message}");
            }
        }

        private void OnLocalNotificationTapped(NotificationTappedEventArgs e)
        {
            //
        }
    }
}
