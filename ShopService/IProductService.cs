using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using ShopService.Model;
using System.IO;

namespace ShopService
{
    [ServiceContract]
    public interface IProductService
    {
        [OperationContract]
        List<Products> GetAllProducts();

        [OperationContract]
        string FileImport(Stream files);

        [OperationContract]
        bool ProductNew(Products item, string image);

        [OperationContract]
        Products Search(int? id);

        [OperationContract]
        bool ProductUpdate(Products item, string image);

        [OperationContract]
        bool ProductDelete(Products item);

        [OperationContract]
        Users Check(Users item);
    }
}
