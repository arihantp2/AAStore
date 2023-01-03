using System;
using AAStore.API.Model;

namespace AAStore.API.BusinessLogic.Product
{
    public interface IProductManager
    {
        List<ProductModel> GetProducts();
        
    }
}