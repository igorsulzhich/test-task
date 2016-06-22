using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ShopService.Model;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using System.IO;

namespace ShopService.Repositories
{
    public class CloudinaryRepository
    {
        private static Cloudinary cloudinary = new Cloudinary(
            new Account("igorsulzhich", "232533624141977", "rj36eT3xv2EMZgPQ9hhM8c2pdXY"));

        public static string ImportFile(Stream item)
        {
            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription("name", item),
                Format = "jpg",
                Folder = "online-shop"
            };

            return cloudinary.Upload(uploadParams).PublicId;
        }

        public static void DeleteFile(string publicId)
        {
            cloudinary.DeleteResources(publicId);
        }
    }
}