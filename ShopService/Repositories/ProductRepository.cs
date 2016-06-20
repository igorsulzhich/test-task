using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ShopService.Model;
using System.Data.Entity;

namespace ShopService.Repositories
{
    public class ProductRepository
    {
        private static ShopEntities db = new ShopEntities();

        public static List<Products> GetAll()
        {
            return db.Products.OrderByDescending(key => key.Id).ToList();
        }

        public static void Create(Products item)
        {
            db.Products.Add(item);
            db.SaveChanges();
        }

        public static Products Search(int? id)
        {
            Products item = db.Products.Find(id);
            return item;
        }

        public static void Edit(Products item)
        {
            Products pr = db.Products.Single(p => p.Id == item.Id);

            pr.Name = item.Name;
            pr.Price = item.Price;
            pr.Description = item.Description;
            pr.ImageLink = item.ImageLink;

            db.SaveChanges();
        }

        public static void Delete(Products item)
        {
            Products pr = db.Products.Single(p => p.Id == item.Id);
            db.Products.Remove(pr);
            db.SaveChanges();
        }
    }
}