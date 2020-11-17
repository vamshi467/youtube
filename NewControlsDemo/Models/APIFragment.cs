using System;
namespace NewControlsDemo.Models
{
    public class APIFragment
    {
        #region Service Url
        public string AuthTokenURL { get; set; }
        #endregion

        public APIFragment(EnvironmentName environmentName)
        {
            switch (environmentName)
            {
                case EnvironmentName.Dev:
                    AuthTokenURL = "/oauth/token";
                    return;
                case EnvironmentName.Prod:
                    AuthTokenURL = "/oauth/token";
                    return;
                default:
                    AuthTokenURL = "/oauth/token";
                    return;
            }
        }
    }
}
