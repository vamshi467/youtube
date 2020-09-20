using System;
using Xamarin.Forms;

namespace NewControlsDemo.Controls
{
    public class ExtendedWebView : WebView
    {
        public static readonly BindableProperty FixHeightProperty = BindableProperty.Create(nameof(FixHeight), typeof(bool), typeof(ExtendedWebView), false);

        public bool FixHeight
        {
            get { return (bool)GetValue(FixHeightProperty); }
            set
            {
                SetValue(FixHeightProperty, value);
            }
        }
        public static readonly BindableProperty AllowScrollingProperty = BindableProperty.Create(nameof(AllowScrolling), typeof(bool), typeof(ExtendedWebView), true);

        public bool AllowScrolling
        {
            get { return (bool)GetValue(AllowScrollingProperty); }
            set
            {
                SetValue(AllowScrollingProperty, value);
            }
        }
    }
}
