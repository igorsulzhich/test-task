using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ShopService.Model;
using System.Data.Entity;
using System.IO;

namespace ShopService.Repositories
{
    public class ProductRepository
    {
        private static WcfDataModel db = new WcfDataModel();   

        public static List<Products> GetAll()
        {
            var model = db.Products.OrderByDescending(key => key.Id).ToList();
            return model != null ? model : null;
        }

        public static Products Search(int? id)
        {
            Products item = db.Products.Find(id);
            return item;
        }

        public static void Create(Products item, string image)
        {
            item.ImageLink = image;
            db.Products.Add(item);
            db.SaveChanges();
        }

        public static void Edit(Products item, string image)
        {
            Products pr = db.Products.Single(p => p.Id == item.Id);

            if (image != null)
            {
                CloudinaryRepository.DeleteFile(pr.ImageLink);
                pr.ImageLink = image;
            }

            pr.Name = item.Name;
            pr.Price = item.Price;
            pr.Description = item.Description;

            db.SaveChanges();
        }

        public static void Delete(Products item)
        {
            Products pr = db.Products.Single(p => p.Id == item.Id);
            CloudinaryRepository.DeleteFile(pr.ImageLink);
            db.Products.Remove(pr);
            db.SaveChanges();
        }
    }
}