using System;
using NewControlsDemo.Models;
using Newtonsoft.Json;
using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace NewControlsDemo.Services
{
    public class SettingsService
    {
        static ISettings appSettings;
        public static ISettings AppSettings
        {
            get
            {
                return appSettings ?? (appSettings = CrossSettings.Current);
            }
            set
            {
                appSettings = value;
            }
        }

        private const string FirebaseLoggedInUserKey = "FirebaseLoggedInUser_key";
        public static User FirebaseLoggedInUser
        {
            get
            {
                var value = AppSettings.GetValueOrDefault(FirebaseLoggedInUserKey, string.Empty);
                if (string.IsNullOrEmpty(value)) { return null; }
                else { return JsonConvert.DeserializeObject<User>(value); }
            }
            set
            {
                string data = string.Empty;
                if (value != null) { data = JsonConvert.SerializeObject(value); }
                AppSettings.AddOrUpdateValue(FirebaseLoggedInUserKey, data);
            }
        }
    }
}
