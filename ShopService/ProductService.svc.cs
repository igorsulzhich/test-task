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

        public bool ProductNew(Products item, string image) { return ProductRepository.Create(item, image); }

        public Products Search(int? id) { return ProductRepository.Search(id); }

        public bool ProductUpdate(Products item, string upload) { return ProductRepository.Edit(item, upload); }

        public bool ProductDelete(Products item) { return ProductRepository.Delete(item); }

        public Users Check(Users item) { return AuthenticationRepository.Check(item); }
    }
}
