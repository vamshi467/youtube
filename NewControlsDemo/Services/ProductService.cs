using System;
using System.Collections.Generic;
using NewControlsDemo.Models;

namespace NewControlsDemo.Services
{
    //public interface IProductService
    //{
    //    void GetProductsList();
    //}

    public class ProductService //: IProductService
    {
        public List<Product> GetProductsList()
        {
            return new List<Product>()
            {
                new Product(){ ProductName = "Mobile", Price=800, ImageUrl="https://t4.ftcdn.net/jpg/01/88/79/61/240_F_188796114_Pl86RbwnZz9vnJLcSz0FtBdaPU6DdJes.jpg"},
                new Product(){ ProductName = "TV", Price=800, ImageUrl="https://t4.ftcdn.net/jpg/00/73/23/79/240_F_73237971_sA6qmDPEqrQCAAnUHFYUngtnVQr8Hmn0.jpg"},
                new Product(){ ProductName = "Watches", Price=800, ImageUrl="https://t3.ftcdn.net/jpg/03/01/52/70/240_F_301527093_MsrLRU3oL6lGoF5OCBNGugZ1M4MkZzXm.jpg"},
                new Product(){ ProductName = "Laptops",Price=800, ImageUrl="https://t4.ftcdn.net/jpg/01/15/21/87/240_F_115218743_uQxtZr8HW2UUYCeB5SdupdUJZQjo7QDr.jpg"}, 
                new Product(){ ProductName = "Lights",Price=800, ImageUrl="https://t3.ftcdn.net/jpg/02/83/70/92/240_F_283709280_m9Iwup9tN9ABl2foiHucrjCuvgF7B8Qo.jpg"},
                new Product(){ ProductName = "Fans",Price=800, ImageUrl="https://t3.ftcdn.net/jpg/03/08/31/58/240_F_308315841_ywBFVnZkKSachVE3KQGlrmLuBHLew5Bk.jpg"}
            };
        }
    }
}
