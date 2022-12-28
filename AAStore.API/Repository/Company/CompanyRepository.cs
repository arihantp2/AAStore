using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Microsoft.Extensions.Configuration;
using AAStore.API.Model;

namespace AAStore.API.Repository.Company
{
    public class CompanyRepository : ICompanyRepository 
    {
        private readonly IConfiguration _configuration;
        public CompanyRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            
        }
        
        
        public DataSet GetCompany(int id)
        {
            string connectionString = _configuration.GetConnectionString("Product");
            var ds = new DataSet();

            using(SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(Procedures.GET_COMPANY_DETAILS,con);
                cmd.Parameters.AddWithValue(CreateParameters.CATEGORY_ID,id);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;

                using(var sqlDataAdapter = new SqlDataAdapter(cmd))
                {
                    sqlDataAdapter.Fill(ds);
                }
            }
            return ds;
        }

        public DataSet AddCompany(CompanyModel company)
        {
            string connectionString = _configuration.GetConnectionString("Product");
            var ds = new DataSet();

            using(SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(Procedures.ADD_COMPANY_NAME,con);
                cmd.Parameters.AddWithValue(CreateParameters.COMPANY_NAME,company.CompanyName);
                cmd.Parameters.AddWithValue(CreateParameters.CATEGORY_ID,CreateParameters.CATEGORY_ID);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;

                var sqlDataAdapter = new SqlDataAdapter(cmd);
                sqlDataAdapter.Fill(ds);
            }
            return ds;
        }

        public DataSet UpdateCompany(int id , CompanyModel company)
        {
            string connectionString = _configuration.GetConnectionString("Product");
            var ds = new DataSet();

            using(SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(Procedures.UPDATE_COMPANY_DETAILS,con);
                cmd.Parameters.AddWithValue(CreateParameters.COMPANY_ID,id);
                cmd.Parameters.AddWithValue(CreateParameters.COMPANY_NAME,company.CompanyName);
                cmd.Parameters.AddWithValue(CreateParameters.CATEGORY_ID,company.CategoryId);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;

                var sqlDataAdapter = new SqlDataAdapter(cmd);
                sqlDataAdapter.Fill(ds);
            }
            return ds;
        }

        public DataSet DeleteCompany(int id)
        {
            string connectionString = _configuration.GetConnectionString("Product");
            var ds = new DataSet();
            using(SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(Procedures.DELETE_COMPANY);
                cmd.Parameters.AddWithValue(CreateParameters.COMPANY_ID,id);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;

                var sqlDataAdapter  = new SqlDataAdapter(cmd);
                sqlDataAdapter.Fill(ds);
            }
            return ds;
        }

        public static class CreateParameters { 
            public const string COMPANY_NAME = "@CompanyName";
            public const string CATEGORY_ID = "@CategoryId";
            public const string COMPANY_ID = "@CompanyId";
        }

        public static class Procedures
        {
            public const string GET_COMPANY_DETAILS= "usp_GetCompanyDetailsByCategoryId";
            public const string ADD_COMPANY_NAME = "usp_InsertCompanyDetails";
            public const string UPDATE_COMPANY_DETAILS = "usp_UpdateCompanyDetails";
            public const string DELETE_COMPANY = "usp_DeleteCompanyDetails";
        }
    }
}