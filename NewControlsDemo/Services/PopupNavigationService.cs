using System;
using Rg.Plugins.Popup.Contracts;
using Rg.Plugins.Popup.Services;

namespace NewControlsDemo.Services
{
    public class PopupNavigationService
    {
        static IPopupNavigation _instance;
        public static IPopupNavigation Instance
        {
            get
            {
                return _instance ?? (_instance = PopupNavigation.Instance);
            }
            set
            {
                _instance = value;
            }
        }
    }
}
