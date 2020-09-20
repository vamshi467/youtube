using System;
using Foundation;
using NewControlsDemo.Controls;
using NewControlsDemo.iOS.Renderers;
using WebKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: Xamarin.Forms.ExportRenderer(typeof(ExtendedWebView), typeof(ExtendedWebviewRenderer))]
namespace NewControlsDemo.iOS.Renderers
{
    public class ExtendedWebviewRenderer : ViewRenderer<ExtendedWebView, WKWebView>
    {
        ExtendedWebView view = null;
        WKWebView _wkWebView;

        public ExtendedWebviewRenderer()
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<ExtendedWebView> e)
        {
            try
            {
                view = (ExtendedWebView)Element;
                string url = view.Source.GetValue(UrlWebViewSource.UrlProperty).ToString();

                //The width=device-width part sets the width of the page to follow the screen-width of the device
                //(which will vary depending on the device)
                string javaScript = @"var meta = document.createElement('meta');
                                       meta.setAttribute('name', 'viewport');
                                       meta.setAttribute('content', 'width=device-width');
                                       document.getElementsByTagName('head')[0].appendChild(meta);";

                WKUserScript wkUScript = new WKUserScript((NSString)javaScript, WKUserScriptInjectionTime.AtDocumentEnd, true);
                WKUserContentController wkUController = new WKUserContentController();
                wkUController.AddUserScript(wkUScript);

                WKWebViewConfiguration wkWebConfig = new WKWebViewConfiguration();
                wkWebConfig.UserContentController = wkUController;
                _wkWebView = new WKWebView(Frame, wkWebConfig);
                _wkWebView.ScrollView.ScrollEnabled = true;
                _wkWebView.NavigationDelegate = new HybridWebviewDelegate();
                _wkWebView.LoadRequest(new NSUrlRequest(new NSUrl(url)));

                SetNativeControl(_wkWebView);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

    internal class HybridWebviewDelegate : WKNavigationDelegate
    {
    }
}
