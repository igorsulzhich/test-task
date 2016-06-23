using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data.Entity;
using ShopService.Repositories;
using ShopService.Model;
using System.Web;
using System.IO;

namespace ShopService
{
    public class ProductService : IProductService
    {
        public List<Products> GetAllProducts() { return ProductRepository.GetAll(); }

        public string FileImport(Stream files) { return CloudinaryRepository.ImportFile(files); }

        public void ProductNew(Products item, string image) { ProductRepository.Create(item, image); }

        public Products Search(int? id) { return ProductRepository.Search(id); }

        public void ProductUpdate(Products item, string upload) { ProductRepository.Edit(item, upload); }

        public void ProductDelete(Products item) { ProductRepository.Delete(item); }

        public Users Check(Users item) { return AuthenticationRepository.Check(item); }
    }
}
