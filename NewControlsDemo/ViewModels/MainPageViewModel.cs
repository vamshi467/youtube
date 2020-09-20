using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using NewControlsDemo.Models;
using NewControlsDemo.Services;
using NewControlsDemo.Views;
using Prism.Commands;
using Prism.Navigation;
using Xamarin.Forms;

namespace NewControlsDemo.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        public MainPageViewModel(INavigationService navigationService, FacadeService facadeService)
            : base(navigationService, facadeService)
        {
        }

        private ObservableCollection<ControlsModel> controlsList;
        public ObservableCollection<ControlsModel> ControlsList
        {
            get { return controlsList; }
            set { SetProperty(ref controlsList, value); }
        }

        public DelegateCommand ShowCarouselCommand { get { return new DelegateCommand(async () => await ShowCarousel()); } }
        private async Task ShowCarousel()
        {
            await _navigationService.NavigateAsync(nameof(CarouselViewPage), null);
        }

        public DelegateCommand ShowSwipeViewCommand { get { return new DelegateCommand(async () => await ShowSwipeView()); } }
        private async Task ShowSwipeView()
        {
            await _navigationService.NavigateAsync(nameof(SwipeViewPage), null);
        }

        public DelegateCommand ShowCollectionVwCommand { get { return new DelegateCommand(async () => await ShowCollectionVw()); } }
        private async Task ShowCollectionVw()
        {
            await _navigationService.NavigateAsync(nameof(CollectionViewPage), null);
        }

        public DelegateCommand ShowImgTransformVwCommand { get { return new DelegateCommand(async () => await ShowImgTransformVw()); } }
        private async Task ShowImgTransformVw()
        {
            await _navigationService.NavigateAsync(nameof(TransformCategoryPage), null);
        }

        public DelegateCommand ShowWkWebViewCommand { get { return new DelegateCommand(async () => await ShowWkWebView()); } }
        private async Task ShowWkWebView()
        {
            await _navigationService.NavigateAsync(nameof(WebUrlTestPage), null);
        }

        public DelegateCommand ShowTinderPageCommand { get { return new DelegateCommand(async () => await ShowTinderPage()); } }
        private async Task ShowTinderPage()
        {
            await _navigationService.NavigateAsync(nameof(TinderPage), null);
        }

        public DelegateCommand PdfViewerCommand { get { return new DelegateCommand(() => OpenPreviewer()); } }
        private void OpenPreviewer()
        {
            var service = DependencyService.Get<IDocumentInteractionService>();
            var file = @"https://images.pexels.com/photos/220453/pexels-photo-220453.jpeg"; //"https://www.tutorialspoint.com/css/css_tutorial.pdf";
            service.DownloadFile(file, "Attachments");

            //var img = "https://images.pexels.com/photos/220453/pexels-photo-220453.jpeg";
            //DependencyService.Get<IDocumentInteractionController>().OpenFile(file);
        }
    }
}
