using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using LibVLCSharp.Shared;
using NewControlsDemo.Helpers;
using NewControlsDemo.Models;
using NewControlsDemo.Services;
using NewControlsDemo.Views;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Plugin.Share;
using Prism.Commands;
using Prism.Navigation;

namespace NewControlsDemo.ViewModels
{
    public class YoutubePageViewModel : BaseViewModel
    {
        private LibVLC LibVLC { get; set; }

        public YoutubePageViewModel(INavigationService navigationService, FacadeService facadeService)
             : base(navigationService, facadeService)
        {
        }

        private ObservableCollection<YoutubeItem> _youtubeItems;

        public ObservableCollection<YoutubeItem> YoutubeItems
        {
            get { return _youtubeItems; }
            set { SetProperty(ref _youtubeItems, value); }
        }

        public DelegateCommand<YoutubeItem> PlayVideoCommand { get { return new DelegateCommand<YoutubeItem>(async (obj) => await PlayVideoClick(obj)); } }

        private async Task PlayVideoClick(YoutubeItem youtubeItem)
        {
            // We can open video in Browser using Plugin.Share
            //await CrossShare.Current.OpenBrowser($"https://www.youtube.com/watch?v={youtubeItem?.VideoId}");

            try
            {
                var parameters = new NavigationParameters();
                parameters.Add("videoId", youtubeItem.VideoId);
                await _navigationService.NavigateAsync($"{nameof(VideoStreamPage)}", parameters);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        public async override void OnNavigatedTo(INavigationParameters parameters)
        {
            await InitDataAsync();
        }

        public async Task InitDataAsync()
        {
            var videoIds = await GetVideoIdsFromChannelAsync();
        }

        private async Task<ObservableCollection<string>> GetVideoIdsFromChannelAsync()
        {
            await ShowLoader();

            var httpClient = new HttpClient();

            var json = await httpClient.GetStringAsync(Constants.apiUrlForChannel);

            var videoIds = new ObservableCollection<string>();

            try
            {
                JObject response = JsonConvert.DeserializeObject<dynamic>(json);

                var items = response.Value<JArray>("items");

                foreach (var item in items)
                {
                    videoIds.Add(item.Value<JObject>("id")?.Value<string>("videoId"));
                }

                YoutubeItems = await GetVideosDetailsAsync(videoIds);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                await ClosePopup();
            }
            return videoIds;
        }

        private async Task<ObservableCollection<YoutubeItem>> GetVideosDetailsAsync(ObservableCollection<string> videoIds)
        {
            var videoIdsString = "";
            foreach (var s in videoIds)
            {
                videoIdsString += s + ",";
            }

            var httpClient = new HttpClient();

            var json = await httpClient.GetStringAsync(string.Format(Constants.detailsUrl, videoIdsString));

            var youtubeItems = new ObservableCollection<YoutubeItem>();

            Debug.WriteLine("Json - " + json);

            try
            {
                JObject response = JsonConvert.DeserializeObject<dynamic>(json);

                var items = response.Value<JArray>("items");

                foreach (var item in items)
                {
                    var snippet = item.Value<JObject>("snippet");
                    var statistics = item.Value<JObject>("statistics");

                    var youtubeItem = new YoutubeItem
                    {
                        Title = snippet.Value<string>("title"),
                        Description = snippet.Value<string>("description"),
                        ChannelTitle = snippet.Value<string>("channelTitle"),
                        PublishedAt = snippet.Value<DateTime>("publishedAt"),
                        VideoId = item?.Value<string>("id"),
                        DefaultThumbnailUrl = snippet?.Value<JObject>("thumbnails")?.Value<JObject>("default")?.Value<string>("url"),
                        MediumThumbnailUrl = snippet?.Value<JObject>("thumbnails")?.Value<JObject>("medium")?.Value<string>("url"),
                        HighThumbnailUrl = snippet?.Value<JObject>("thumbnails")?.Value<JObject>("high")?.Value<string>("url"),
                        StandardThumbnailUrl = snippet?.Value<JObject>("thumbnails")?.Value<JObject>("standard")?.Value<string>("url"),
                        MaxResThumbnailUrl = snippet?.Value<JObject>("thumbnails")?.Value<JObject>("maxres")?.Value<string>("url"),

                        ViewCount = statistics?.Value<int>("viewCount"),
                        LikeCount = statistics?.Value<int>("likeCount"),
                        DislikeCount = statistics?.Value<int>("dislikeCount"),
                        FavoriteCount = statistics?.Value<int>("favoriteCount"),
                        CommentCount = statistics?.Value<int>("commentCount"),

                        //Tags = (from tag in snippet?.Value<JArray>("tags") select tag.ToString())?.ToList(),
                    };

                    youtubeItems.Add(youtubeItem);
                }

                return youtubeItems;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return youtubeItems;
            }
        }
    }
}
