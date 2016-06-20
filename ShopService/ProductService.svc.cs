using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data.Entity;
using ShopService.Repositories;
using ShopService.Model;

namespace ShopService
{
    public class ProductService : IProductService
    {
        public List<Products> GetAllProducts() { return ProductRepository.GetAll(); }
        public void ProductNew(Products item) { ProductRepository.Create(item); }
        public Products Search(int? id) { return ProductRepository.Search(id); }
        public void ProductUpdate(Products item) { ProductRepository.Edit(item); }
        public void ProductDelete(Products item) { ProductRepository.Delete(item); }
    }
}
