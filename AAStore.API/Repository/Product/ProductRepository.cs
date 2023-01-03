using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Microsoft.Extensions.Configuration;
using AAStore.API.Model;

namespace AAStore.API.Repository.Product
{
    public class ProductRepository : IProductRepository
    {
        private readonly IConfiguration _configuration;
        public ProductRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public DataSet GetProducts()
        {
            var connectionString = _configuration.GetConnectionString("Product");
            var ds = new DataSet();
             using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(Procedures.GET_PRODUCT_DETAILS ,con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;   

                using (var sqlDataAdapter = new SqlDataAdapter(cmd))
                {
                    sqlDataAdapter.Fill (ds);
                }
            }           
            return ds;
        }

        public static class CreateParameters { 
            public const string PRODUCT_NAME = "@ProductName";
            public const string PRICE = "@Price";
            public const string PIMAGE = "@PImage";
            public const string CATEGORY_ID = "@CategoryId";
            public const string COMPANY_ID = "@CompanyId";
        }

        public static class Procedures
        {
            public const string GET_PRODUCT_DETAILS= "usp_getProductDetails";
            public const string GET_PRODUCT_DETAILS_BY_PRODUCT = "usp_getProductDetailsByProductId";
            public const string GET_PRODUCT_DETAILS_BY_COMPANY = "usp_GetProductDetailsByCompanyId";
            public const string GET_PRODUCT_DETAILS_BY_CATEGORY = "usp_GetProductDetailsByCategoryId";
            public const string ADD_PRODUCT = "usp_InsertProductDetails";
            public const string UPDATE_PRODUCT_DETAILS = "usp_UpdateProductDetails";
            public const string DELETE_PRODUCT = "usp_DeleteProductDetails";
        }
    }
}