using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ShopService.Model;
using System.Web;
using System.IO;

namespace ShopService
{
    [ServiceContract]
    public interface IProductService
    {
        [OperationContract]
        List<Products> GetAllProducts();

        [OperationContract]
        string FileImport(Stream file);

        [OperationContract]
        void ProductNew(Products item, string image);

        [OperationContract]
        Products Search(int? id);

        [OperationContract]
        void ProductUpdate(Products item, string image);

        [OperationContract]
        void ProductDelete(Products item);

        [OperationContract]
        Users Check(Users item);
    }
}
