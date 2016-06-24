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
            try
            {
                var uploadParams = new ImageUploadParams()
                {
                    File = new FileDescription("name", item),
                    Format = "jpg",
                    Folder = "online-shop"
                };

                return cloudinary.Upload(uploadParams).PublicId;
            }
            catch
            {
                return null;
            }
        }

        public static bool DeleteFile(string publicId)
        {
            try
            {
                cloudinary.DeleteResources(publicId);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}