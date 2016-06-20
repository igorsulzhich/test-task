using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ShopService.Model;

namespace ShopService.Repositories
{
    public class ProductRepository
    {
        private static ShopEntities db = new ShopEntities();

        public static List<Products> GetAll()
        {
            //Product item = new Product();

            //var itemFromDB = (from p in db.Products select p).First();
        
            //item.Name = itemFromDB.Name;
            //item.Price = itemFromDB.Price;
            //item.Description = itemFromDB.Description;

            return (from p in db.Products select p).ToList();
        }
    }
}