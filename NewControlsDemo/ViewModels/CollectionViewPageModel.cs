using System;
using System.Collections.Generic;
using NewControlsDemo.Models;
using NewControlsDemo.Services;
using Prism.Navigation;

namespace NewControlsDemo.ViewModels
{
    public class CollectionViewPageModel : BaseViewModel
    {
        ProductService ProductService = new ProductService();
        public List<Product> Products { get; set; }

        public CollectionViewPageModel(INavigationService navigationService, FacadeService facadeService)
            : base(navigationService, facadeService)
        {
            Products = ProductService.GetProductsList();
        }
    }
}
