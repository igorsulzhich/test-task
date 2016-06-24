using System.Collections.Generic;
using System.Linq;
using ShopService.Model;

namespace ShopService.Repositories
{
    public class ProductRepository
    {
        private static WcfDataModel db = new WcfDataModel();   

        public static List<Products> GetAll()
        {
            try
            {
                var model = db.Products.OrderByDescending(key => key.Id).ToList();
                return model;
            }
            catch
            {
                return null;
            }
        }

        public static Products Search(int? id)
        {
            try
            {
                Products item = db.Products.Find(id);
                return item;
            }
            catch
            {
                return null;
            }
        }

        public static bool Create(Products item, string image)
        {
            try
            {
                item.ImageLink = image;
                db.Products.Add(item);
                db.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool Edit(Products item, string image)
        {
            try
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

                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool Delete(Products item)
        {
            try
            {
                Products pr = db.Products.Single(p => p.Id == item.Id);
                CloudinaryRepository.DeleteFile(pr.ImageLink);
                db.Products.Remove(pr);
                db.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}