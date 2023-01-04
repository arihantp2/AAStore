using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using AAStore.API.Model;

namespace AAStore.API.Repository.Product
{
    public interface IProductRepository 
    {
        public DataSet GetProducts();
        public DataSet GetProductsById(int id);
        public DataSet GetProductsByCategory(int id);
        public DataSet GetProductsByCompany(int id);
        public DataSet AddProduct(ProductModel product);
        public DataSet UpdateProduct(int id,ProductModel product);
        public DataSet DeleteProduct(int id);
    }
}