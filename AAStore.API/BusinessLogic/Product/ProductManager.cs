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

        public ProductModel GetProductByProductId(int id)
        {
            DataSet DS = new DataSet();
            ProductModel data = new ProductModel();

            DS = _productRepository.GetProductsById(id);
            if(DS != null)
            {
                DataTable dt = DS.Tables[0];
                if(dt != null && dt.Rows.Count > 0)
                foreach(DataRow dr in dt.Rows)
                {
                    data.ProductId = Convert.ToInt32(dr["ProductId"].ToString());
                    data.ProductName = dr["ProductName"].ToString();
                    data.Price = Convert.ToInt32(dr["Price"].ToString());
                    data.PImage = dr["PImage"].ToString();
                    data.CategoryId = Convert.ToInt32(dr["CategoryId"].ToString());
                    data.CompanyId = Convert.ToInt32(dr["CompantId"].ToString());
                }
            }
            return data;            
        }
        public List<ProductModel> GetProductsByCategory(int id)
        {
            DataSet DS = new DataSet();
            List<ProductModel> list = new List<ProductModel>();

            DS = _productRepository.GetProductsByCategory(id);
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
        public List<ProductModel> GetProductsByCompany(int id)
        {
            DataSet DS = new DataSet();
            List<ProductModel> list = new List<ProductModel>();

            DS = _productRepository.GetProductsByCompany(id);
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

        public bool AddProduct(ProductModel product)
        {
            var ds = _productRepository.AddProduct(product);
            if (ds == null)
            {
                return false;
            }
            return true;
        }
        public bool UpdateProduct(int id,ProductModel product)
        {
            var ds = _productRepository.UpdateProduct(id,product);
            if(ds == null)
            {
                return false;
            }
            return true;
        }

        public bool DeleteProduct(int id )
        {
            var DS = _productRepository.DeleteProduct(id);
            if(DS == null)
            {
                return false;
            }
            return true;
        }
    }
}
    