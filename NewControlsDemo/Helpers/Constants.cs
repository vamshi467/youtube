using System;
namespace NewControlsDemo.Helpers
{
    public class Constants
    {

      // keys from google developer console
        public const string ApiKey = "AIzaSyD9ZBuNBA8zBwau6BrcLXC-AACwySPteO8";//AIzaSyAsSYiKNRx86JoYt1cEvRXVed0N-T-du5o  //AIzaSyD9ZBuNBA8zBwau6BrcLXC-AACwySPteO8

        public const string AndroidGoogleId = "607076773113-n8eg56mhtagna0bsgh500mqvu5dvoatu.apps.googleusercontent.com";
        public const string iOSGoogleId = "607076773113-pnlbu737uhea3d3rvkg6qoghlboj9h6d.apps.googleusercontent.com"; //"122196288838-mc615euh1g14a908uqufugsdn9gnr9e2.apps.googleusercontent.com";

        public const string AndroidRevereseGoogleId = "com.googleusercontent.apps.607076773113-n8eg56mhtagna0bsgh500mqvu5dvoatu:/oauth2redirect";
        public const string iOSRevereseGoogleId = "com.googleusercontent.apps.607076773113-pnlbu737uhea3d3rvkg6qoghlboj9h6d:/oauth2redirect"; //"com.googleusercontent.apps.122196288838-mc615euh1g14a908uqufugsdn9gnr9e2:/oauth2redirect";


        // https://support.google.com/youtube/answer/3250431?hl=en
        // Put your youtube channel id here
        public const string ChannelId = "UCvEm37m-JpTxpUo7N8ROJNw";

        // doc : https://developers.google.com/apis-explorer/#p/youtube/v3/youtube.playlistItems.list
        public const string apiUrlForPlaylist = "https://www.googleapis.com/youtube/v3/playlistItems?part=contentDetails&maxResults=20&playlistId="
            + "PLLwGtvGqGMgOGSU9B-HdLep2WH5bCQQ1R"
            //+ "Your_PlaylistId"
            + "&key="   
            + ApiKey;

        public const string detailsUrl = "https://www.googleapis.com/youtube/v3/videos?part=snippet,statistics&key=" + ApiKey + "&id={0}";

        public const string apiUrlForChannel = "https://www.googleapis.com/youtube/v3/search?part=id&maxResults=20&channelId="
           + ChannelId
           + "&key="
           + ApiKey;

    }
}
