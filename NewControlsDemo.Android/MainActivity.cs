using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Xamarin.Forms;
using Plugin.LocalNotification;
using Plugin.LocalNotification.Platform.Droid;
using Android.Content;
using Android;
using AndroidX.Core.App;
using Java.Interop;
using Firebase;
using LibVLCSharp.Forms.Shared;

namespace NewControlsDemo.Droid
{
    [Activity(Label = "YTPlayer", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = false, LaunchMode = LaunchMode.SingleInstance, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            LibVLCSharpFormsRenderer.Init();
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);

            //Presenting the Google SignIn User Interface
            global::Xamarin.Auth.Presenters.XamarinAndroid.AuthenticationConfiguration.Init(this, savedInstanceState);
            global::Xamarin.Auth.CustomTabsConfiguration.CustomTabsClosingMessage = null;

            FirebaseApp.InitializeApp(this);
            LoadApplication(new App());
            LoadCustomTabConfiguration();
            Rg.Plugins.Popup.Popup.Init(this, savedInstanceState);
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        protected override void OnNewIntent(Intent intent)
        {
            base.OnNewIntent(intent);
        }

        public void LoadCustomTabConfiguration()
        {
            global::Xamarin.Auth.CustomTabsConfiguration.ActionLabel = null;
            global::Xamarin.Auth.CustomTabsConfiguration.MenuItemTitle = null;
            global::Xamarin.Auth.CustomTabsConfiguration.AreAnimationsUsed = true;
            global::Xamarin.Auth.CustomTabsConfiguration.IsShowTitleUsed = false;
            global::Xamarin.Auth.CustomTabsConfiguration.IsUrlBarHidingUsed = false;
            global::Xamarin.Auth.CustomTabsConfiguration.IsCloseButtonIconUsed = false;
            global::Xamarin.Auth.CustomTabsConfiguration.IsActionButtonUsed = false;
            global::Xamarin.Auth.CustomTabsConfiguration.IsActionBarToolbarIconUsed = false;
            global::Xamarin.Auth.CustomTabsConfiguration.IsDefaultShareMenuItemUsed = false;
 
            global::Xamarin.Auth.CustomTabsConfiguration.ActivityFlags =
                    global::Android.Content.ActivityFlags.NoHistory
                    |
                    global::Android.Content.ActivityFlags.SingleTop
                    |
                    global::Android.Content.ActivityFlags.NewTask;

            global::Xamarin.Auth.CustomTabsConfiguration.IsWarmUpUsed = true;
            global::Xamarin.Auth.CustomTabsConfiguration.IsPrefetchUsed = true;
        }

    }
}