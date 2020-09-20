using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace NewControlsDemo.Views
{
    public partial class SwipeViewPage : ContentPage
    {
        public SwipeViewPage()
        {
            InitializeComponent();
        }

        void SwipeItem_Invoked(Object sender, EventArgs e)
        {
            DisplayAlert("Alert", "Hello...", "OK");
        }

        void SwipeItem_Reveled(System.Object sender, System.EventArgs e)
        {
            DisplayAlert("Alert", "Swipe Revel...", "OK");
        }
    }
}
