using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using AAStore.API.Model;
using Microsoft.Extensions.Configuration;

namespace AAStore.API.Repository.Category
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IConfiguration _configuration;

        public CategoryRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public DataSet GetCategory()
        {
            string connectionString = _configuration.GetConnectionString("Product");
            var ds = new DataSet(); 

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(Procedures.GET_CATEGORY_DETAILS ,con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;   

                using (var sqlDataAdapter = new SqlDataAdapter(cmd))
                {
                    sqlDataAdapter.Fill (ds);
                }
            }           
            return ds;
        }

        public DataSet GetCategoryById(int id)
        {
            string connectionString = _configuration.GetConnectionString("Product");
            var ds = new DataSet();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(Procedures.GET_CATEGORY_BY_ID,con);
                cmd.Parameters.AddWithValue(CreateParameters.CATEGORYID,id);
                cmd.CommandType = CommandType.StoredProcedure;
                
            }
            return ds;
        }
        
        public DataSet AddCategory(CategoryModel category)
        {
            string connectionString = _configuration.GetConnectionString("Product");
            var ds = new DataSet();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(Procedures.ADD_CATEGORY,con);
                cmd.Parameters.AddWithValue(CreateParameters.CATEGORYNAME,category.CategoryName);
                cmd.CommandType = CommandType.StoredProcedure;

                var sqlDataAdapter = new SqlDataAdapter(cmd);
                sqlDataAdapter.Fill(ds);

            }
            return ds;
        }

        public static class CreateParameters
        {
            public const string CATEGORYNAME = "@CategoryName";

            public const string CATEGORYID = "@CategoryId";
        }
         public static class Procedures
        {
            public const string GET_CATEGORY_DETAILS= "usp_getCategoryDetails";
            public const string GET_CATEGORY_BY_ID = "usp_getCategoryById";
            public const string ADD_CATEGORY = "usp_InsertCategory";

           
        }
    }
}