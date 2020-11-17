using System;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using NewControlsDemo.Services;

namespace NewControlsDemo.Droid
{
    [Activity(Label = "ActivityCustomUrlSchemeInterceptor", NoHistory = true, LaunchMode = LaunchMode.SingleTop)]
    [
      IntentFilter 
      (
          new[] { Intent.ActionView },
          Categories = new[] { Intent.CategoryDefault, Intent.CategoryBrowsable },
          DataSchemes = new[] { "com.googleusercontent.apps.607076773113-n8eg56mhtagna0bsgh500mqvu5dvoatu" },
          DataPath = "/oauth2redirect"
      )
    ]
    public class ActivityCustomUrlSchemeInterceptor : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            global::Android.Net.Uri uri_android = Intent.Data;

#if DEBUG
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.AppendLine("ActivityCustomUrlSchemeInterceptor.OnCreate()");
            sb.Append("     uri_android = ").AppendLine(uri_android.ToString());
            System.Diagnostics.Debug.WriteLine(sb.ToString());
#endif
            // Convert Android.Net.Url to Uri
            var uri_netfx = new Uri(uri_android.ToString());

            // load redirectUrl Page
            OAuthAuthenticatorService.AuthenticationState.OnPageLoading(uri_netfx);
            
            var intent = new Intent(this, typeof(MainActivity));
            intent.SetFlags(ActivityFlags.ClearTop | ActivityFlags.SingleTop);
            StartActivity(intent);

            this.Finish();

            return;
        }
    }
}
