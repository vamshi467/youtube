using System;
using NewControlsDemo.Models;
using Environment = NewControlsDemo.Models.Environment;

namespace NewControlsDemo.Services
{
    public class ConfigService
    {
        private static Environment _environment;

        public static Environment Environment
        {
            get
            {
                if (_environment == null)
                {
                    _environment = Environment.Dev;
                }
                return _environment;
            }
        }

        public ConfigService() { }

        public static void Init(EnvironmentName environmentName = EnvironmentName.Dev)
        {
            initEnvironment(environmentName);
        }

        private static void initEnvironment(EnvironmentName environmentName)
        {
            switch (environmentName)
            {
                case EnvironmentName.Dev:
                    _environment = Environment.Dev;
                    break;
                case EnvironmentName.Prod:
                    _environment = Environment.Prod;
                    break;
            }
        }
    }
}
