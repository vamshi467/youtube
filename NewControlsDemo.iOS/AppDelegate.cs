using System;
using System.Collections.Generic;
using System.Linq;
using Firebase.Auth;
using Foundation;
using LibVLCSharp.Forms.Shared;
using NewControlsDemo.Services;
using Prism;
using Prism.Ioc;
using UIKit;
using Xamarin.Forms;

namespace NewControlsDemo.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            //Presenting the Google SignIn User Interface
            Firebase.Core.App.Configure();
            Rg.Plugins.Popup.Popup.Init();
             
            global::Xamarin.Auth.Presenters.XamarinIOS.AuthenticationConfiguration.Init();
            global::Xamarin.Forms.Forms.Init();
            LibVLCSharpFormsRenderer.Init();

            LoadApplication(new App());

            return base.FinishedLaunching(app, options);
        }

        public override bool OpenUrl(UIApplication application, NSUrl url, string sourceApplication, NSObject annotation)
        {
            Uri uri = new Uri(url.AbsoluteString);
            if (OAuthAuthenticatorService.AuthenticationState != null)
            {
                OAuthAuthenticatorService.AuthenticationState.OnPageLoading(uri);
            }
            else
            {
                Auth.DefaultInstance.CanHandleUrl(uri);
            }
            return true;
        }
    }
}
