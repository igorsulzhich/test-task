using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ShopService.Model;

namespace ShopService
{
    [ServiceContract]
    public interface IProductService
    {
        [OperationContract]
        List<Products> GetAllProducts();

        [OperationContract]
        void ProductNew(Products item);

        [OperationContract]
        Products Search(int? id);

        [OperationContract]
        void ProductUpdate(Products item);

        [OperationContract]
        void ProductDelete(Products item);
    }
}
