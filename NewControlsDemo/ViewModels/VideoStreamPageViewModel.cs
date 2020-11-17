using System;
using NewControlsDemo.Services;
using Prism.Navigation;
using Xamarin.Forms;
using YoutubeExplode;
using YoutubeExplode.Videos.Streams;

namespace NewControlsDemo.ViewModels
{
    public class VideoStreamPageViewModel : BaseViewModel
    {
        public VideoStreamPageViewModel(INavigationService navigationService, FacadeService facadeService)
            : base(navigationService, facadeService)
        {

        }

        public async override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            try
            {
                if (parameters != null && parameters.ContainsKey("videoId"))
                {
                    await ShowLoader();
                    var videoId = (string)parameters["videoId"];
                    var videoURL = $"https://www.youtube.com/watch?v={videoId}";

                    var youtube = new YoutubeClient();

                    var streamManifest = await youtube.Videos.Streams.GetManifestAsync(videoId);

                    // Get highest quality muxed stream
                    var streamInfo = streamManifest.GetMuxed().WithHighestVideoQuality();

                    //// ...or highest quality MP4 video-only stream
                    //var streamInfo = streamManifest
                    //    .GetVideoOnly()
                    //    .Where(s => s.Container == Container.Mp4)
                    //    .WithHighestVideoQuality();

                    if (streamInfo != null)
                    {
                        // Get the actual stream
                        var stream = await youtube.Videos.Streams.GetAsync(streamInfo);
                        var source = streamInfo.Url;
                        MessagingCenter.Send<object, IVideoStreamInfo>(this, "streamUrl", streamInfo);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                await ClosePopup();
            }
        }
    }
}
