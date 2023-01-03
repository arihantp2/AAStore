using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using AAStore.API.Model;

namespace AAStore.API.Repository.Product
{
    public interface IProductRepository 
    {
        public DataSet GetProducts();
    }
}