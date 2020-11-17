using System;
using System.Collections.Generic;
using NewControlsDemo.ViewModels;
using Xamarin.Forms;
using YoutubeExplode.Videos.Streams;

namespace NewControlsDemo.Views
{
    public partial class VideoStreamPage : ContentPage
    {
        VideoStreamPageViewModel _thisVM;

        public VideoStreamPage()
        {
            InitializeComponent();

            _thisVM = BindingContext as VideoStreamPageViewModel;

            MessagingCenter.Subscribe<object, IVideoStreamInfo>(this, "streamUrl", async (sender, arg) =>
            {
                IVideoStreamInfo streamInfo = arg;
                MyMediaElement.Source = streamInfo.Url;
            });
        }

        async void CloseButton_Clicked(System.Object sender, System.EventArgs e)
        {
            MyMediaElement.Stop();
            await _thisVM.BackClick();
        }

        protected override void OnDisappearing()
        {
            MyMediaElement.Stop();
        }
    }
}
