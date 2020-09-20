using System;
using NewControlsDemo.ViewModels;
using NewControlsDemo.Views;
using Prism.Ioc;
using Xamarin.Forms;

namespace NewControlsDemo.Services
{
    public class IoCService
    {
        public static void RegisterTypes(IContainerRegistry containerRegistry)
        {
            //Infrastructure Depedencies
            RegisterInfrastructure(containerRegistry);
            // ViewModels for Navigation
            RegisterViewModelsForNavigation(containerRegistry);
            //Services
            RegisterServices(containerRegistry);
        }

        private static void RegisterInfrastructure(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
        }

        /// <summary>
        /// Register ViewModels For Navigation
        /// </summary>
        /// <param name="containerRegistry">containerRegistry</param>
        private static void RegisterViewModelsForNavigation(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<CarouselViewPage, CarouselPageViewModel>();
            containerRegistry.RegisterForNavigation<SwipeViewPage, SwipeViewPageModel>();
            containerRegistry.RegisterForNavigation<CollectionViewPage, CollectionViewPageModel>();
            containerRegistry.RegisterForNavigation<MailTemplatePage, MailTemplatePageViewModel>();
            containerRegistry.RegisterForNavigation<TransformCategoryPage, TransformCategoryPageViewModel>();
            containerRegistry.RegisterForNavigation<ImgTransformPage, ImgTransformPageViewModel>();
            containerRegistry.RegisterForNavigation<WebUrlTestPage, WebUrlTestPageViewModel>();
            containerRegistry.RegisterForNavigation<TinderPage, TinderPageViewModel>();
        }

        /// <summary>
        /// RegisterServices
        /// </summary>
        /// <param name="containerRegistry"></param>
        private static void RegisterServices(IContainerRegistry containerRegistry)
        {
            // using live services
            RegisterLiveServices(containerRegistry);
        }

        /// <summary>
        /// RegisterLiveServices
        /// </summary>
        /// <param name="containerRegistry"></param>
        private static void RegisterLiveServices(IContainerRegistry containerRegistry)
        {
        }
    }
}
