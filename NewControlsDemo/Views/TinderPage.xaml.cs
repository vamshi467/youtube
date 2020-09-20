using System;
using System.Collections.Generic;
using MLToolkit.Forms.SwipeCardView.Core;
using Xamarin.Forms;

namespace NewControlsDemo.Views
{
    public partial class TinderPage : ContentPage
    {
        public TinderPage()
        {
            InitializeComponent();
        }

        private async void OnDislikeClicked(object sender, EventArgs e)
        {
            await swipeCard.InvokeSwipe(SwipeCardDirection.Left);
        }

        private async void OnSuperLikeClicked(object sender, EventArgs e)
        {
            await swipeCard.InvokeSwipe(SwipeCardDirection.Up);
        }

        private async void OnLikeClicked(object sender, EventArgs e)
        {
            await swipeCard.InvokeSwipe(SwipeCardDirection.Right);
        }
    }
}


// 1 https://github.com/AndreiMisiukevich/CardView
 
// 2 https://github.com/robinmanuelthiel/swipecards
 
// 3 https://github.com/markolazic88/SwipeCardView [I have used this in my TinderPage]

