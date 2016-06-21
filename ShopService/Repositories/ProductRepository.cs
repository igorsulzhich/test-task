using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ShopService.Model;
using System.Data.Entity;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using System.IO;

namespace ShopService.Repositories
{
    public class ProductRepository
    {
        private static ShopEntities db = new ShopEntities();

        private static Cloudinary cloudinary = new Cloudinary(
            new Account("igorsulzhich", "232533624141977", "rj36eT3xv2EMZgPQ9hhM8c2pdXY"));

        public static List<Products> GetAll()
        {
            return db.Products.OrderByDescending(key => key.Id).ToList();
        }

        public static Products Search(int? id)
        {
            Products item = db.Products.Find(id);
            return item;
        }

        public static string ImportFile(Stream item)
        {
            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription("name", item),
                Format = "jpg",
                Folder = "online-shop"
            };

            string path = cloudinary.Upload(uploadParams).PublicId;
            return path;
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
                cloudinary.DeleteResources(pr.ImageLink);
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
            cloudinary.DeleteResources(pr.ImageLink);
            db.Products.Remove(pr);
            db.SaveChanges();
        }
    }
}