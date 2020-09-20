using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using NewControlsDemo.Models;
using NewControlsDemo.Services;
using NewControlsDemo.Views;
using Prism.Commands;
using Prism.Navigation;
using Xamarin.Forms;

namespace NewControlsDemo.ViewModels
{
    public class TransformCategoryPageViewModel : BaseViewModel
    {
        ImgTransformService ImgService = new ImgTransformService();
        public ObservableCollection<ImgTransformModel> CategoryList { get; set; }

        public TransformCategoryPageViewModel(INavigationService navigationService, FacadeService facadeService)
             : base(navigationService, facadeService)
        {
            CategoryList = ImgService.GetImagesList();
        }

        public DelegateCommand<ImgTransformModel> CategoryTappedCommand { get { return new DelegateCommand<ImgTransformModel>(async (obj) => await OpenCategiryDetail(obj)); } }

        private async Task OpenCategiryDetail(ImgTransformModel obj)
        {
            NavigationParameters keyValuePairs = new NavigationParameters();
            keyValuePairs.Add("Title", obj.Title);
            keyValuePairs.Add("ImageUrl", obj.ImageUrl);
            await _navigationService.NavigateAsync(nameof(ImgTransformPage), keyValuePairs);
        }
     
    }
}
