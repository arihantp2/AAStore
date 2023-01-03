using System;
using System.Collections.Generic;
using System.Data;
using AAStore.API.Model;
using AAStore.API.Repository.Product;

namespace AAStore.API.BusinessLogic.Product
{
    public class ProductManager : IProductManager
    {
        private readonly IProductRepository _productRepository;
        public ProductManager(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public List<ProductModel> GetProducts()
        {
            DataSet DS = new DataSet();
            List<ProductModel> list = new List<ProductModel>();

            DS = _productRepository.GetProducts();
            if(DS != null )
            {
                DataTable dt = DS.Tables[0];
                if(dt != null && dt.Rows.Count > 0)
                {
                    foreach(DataRow dr in dt.Rows)
                    {
                        ProductModel data = new ProductModel();
                        data.ProductId = Convert.ToInt32(dr["ProductId"].ToString());
                        data.ProductName = dr["ProductName"].ToString();
                        data.Price = Convert.ToInt32(dr["Price"].ToString());
                        data.PImage = dr["PImage"].ToString();
                        data.CategoryId = Convert.ToInt32(dr["CategoryId"].ToString());
                        data.CompanyId = Convert.ToInt32(dr["CompantId"].ToString());

                        list.Add(data);
                    }
                }
            }
            return list;
        }
    }
}
    