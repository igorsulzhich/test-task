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
    }
}
