using System;
using AAStore.API.Model;

namespace AAStore.API.BusinessLogic.Product
{
    public interface IProductManager
    {
        List<ProductModel> GetProducts();
        ProductModel GetProductByProductId(int id);
        List<ProductModel> GetProductsByCategory(int id);
        List<ProductModel> GetProductsByCompany(int id);
        public bool AddProduct(ProductModel product);
        public bool UpdateProduct(int id,ProductModel product);
        public bool DeleteProduct(int id );
        
        
    }
}