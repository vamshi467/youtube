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

namespace NewControlsDemo.Droid
{
    [Activity(Label = "FeaturedDemo", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            Forms.SetFlags(new[]
            {
                "CarouselView_Experimental",
                "IndicatorView_Experimental",
                "SwipeView_Experimental",
                "CollectionView_Experimental"
            });

            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);

            FFImageLoading.Forms.Platform.CachedImageRenderer.Init(true);

            var channel = new NotificationChannelRequest();
            
            channel.LightColor = Android.Graphics.Color.Green;
            long[] vibrationPattern = { 100, 200, 300, 400, 500, 400, 300, 200, 400 };
            channel.VibrationPattern = vibrationPattern;
            channel.LockscreenVisibility = NotificationVisibility.Public;

            // Must create a Notification Channel when API >= 26
            NotificationCenter.CreateNotificationChannel(channel);
            // you can created multiple Notification Channels with different names.
            NotificationCenter.CreateNotificationChannel();

            //For apps that target Android 5.1(API level 22) or lower, there is nothing more that needs to be done.
            //Apps that will run on Android 6.0(API 23 level 23) or higher should ask Run time permission checks.
            //Handles this Exception: Xamarin: Android: System.UnauthorizedAccessException: Access to the path is denied
            if (Build.VERSION.SdkInt >= BuildVersionCodes.M)
            {
                if (!(CheckPermissionGranted(Manifest.Permission.ReadExternalStorage) && !CheckPermissionGranted(Manifest.Permission.WriteExternalStorage)))
                {
                    RequestPermission();
                }
            }

            LoadApplication(new App());

            NotificationCenter.NotifyNotificationTapped(base.Intent);
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        protected override void OnNewIntent(Intent intent)
        {
            base.OnNewIntent(intent);
            NotificationCenter.NotifyNotificationTapped(intent);
        }

        private void RequestPermission()
        {
            if (ActivityCompat.ShouldShowRequestPermissionRationale(this, Manifest.Permission.ReadExternalStorage))
            {
                // Provide an additional rationale to the user if the permission was not granted
                // and the user would benefit from additional context for the use of the permission.
                // For example if the user has previously denied the permission.
                ActivityCompat.RequestPermissions(this, new string[] { Manifest.Permission.ReadExternalStorage, Manifest.Permission.WriteExternalStorage }, 0);
            }
            else
            {
                // Permission has not been granted yet. Request it directly.
                ActivityCompat.RequestPermissions(this, new string[] { Manifest.Permission.ReadExternalStorage, Manifest.Permission.WriteExternalStorage }, 0);
            }
        }

        public bool CheckPermissionGranted(string Permissions)
        {
            // Check if the permission is already available.
            if (ActivityCompat.CheckSelfPermission(this, Permissions) != Permission.Granted)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}