using System;
using System.Collections.Generic;
using NewControlsDemo.Models;
using Xamarin.Forms;

namespace NewControlsDemo.Views
{
    public partial class CollectionViewPage : ContentPage
    {
        public CollectionViewPage()
        {
            InitializeComponent();
            CVProducts.SelectionChanged += CVProducts_SelectionChanged;
        }

        private void CVProducts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var product = e.CurrentSelection;
            string msg = string.Empty;
            msg = "Selected product \n";
            for (int i = 0; i < product.Count; i++)
            {
                var p = product[i] as Product;
                msg += $"{p.ProductName} ({p.Price})\n";
            }
            DisplayAlert("Demo", msg, "OK");
        }
    }
}
