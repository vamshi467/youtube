using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using NewControlsDemo.Models;
using NewControlsDemo.Services;
using Prism.Navigation;

namespace NewControlsDemo.ViewModels
{
    public class ImgTransformPageViewModel : BaseViewModel
    {
        public ImgTransformPageViewModel(INavigationService navigationService, FacadeService facadeService)
             : base(navigationService, facadeService)
        {
        }

        private string _imageUrl;
        public string ImageUrl
        {
            get { return _imageUrl; }
            set { SetProperty(ref _imageUrl, value); }
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            try
            {
                base.OnNavigatedTo(parameters);
                if (parameters != null && parameters.ContainsKey("ImageUrl"))
                {
                    ImageUrl = parameters["ImageUrl"].ToString();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
    }
}
