using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using AAStore.API.Model;
using Microsoft.Extensions.Configuration;

namespace AAStore.API.Repository.User
{
    public class UserRepository : IUserRepository
    {
        private readonly IConfiguration _configuration;

        public UserRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public DataSet GetUsers()
        {
            string connectionString = _configuration.GetConnectionString("Product");
            var DS = new DataSet();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(Procedures.GET_USERS,con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout=0;

                using (var sqlDataAdapter = new SqlDataAdapter(cmd))
                {
                    sqlDataAdapter.Fill (DS);
                }
            }
            return DS; 
        }
        
        public DataSet GetUserById(int id)
        {
            string connectionString = _configuration.GetConnectionString("Product");
            var ds = new DataSet();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(Procedures.GET_USERS_BY_ID,con);
                cmd.Parameters.AddWithValue(CreateParameters.USER_ID,id);
                cmd.CommandType = CommandType.StoredProcedure;  

                using (var sqlDataAdapter = new SqlDataAdapter(cmd))
                {
                    sqlDataAdapter.Fill (ds);
                }     
            }
            return ds;
        }

        public DataSet AddUser(UserModel user)
        {
            string connectionString = _configuration.GetConnectionString("Product");
            var ds = new DataSet();

            using ( SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(Procedures.ADD_USER,con);
                
                cmd.Parameters.AddWithValue(CreateParameters.USER_NAME,user.UserName);
                cmd.Parameters.AddWithValue(CreateParameters.USER_DOB,user.UserDOB);
                cmd.Parameters.AddWithValue(CreateParameters.USER_EMAIL,user.UserEmail);
                cmd.Parameters.AddWithValue(CreateParameters.USER_CONTACT_NO,user.UserContactNo);
                cmd.Parameters.AddWithValue(CreateParameters.USER_PASSWORD,user.UserPassword);

                cmd.CommandType=CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                
                var sqlDataAdapter = new SqlDataAdapter(cmd);
                sqlDataAdapter.Fill(ds);
            }
            return ds;
        }

        public DataSet UpdateUser(int id,UserModel user)
        {
            string connectionString = _configuration.GetConnectionString("Product");
            var ds = new DataSet();

            using ( SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(Procedures.UPDATE_USER,con);
                
                cmd.Parameters.AddWithValue(CreateParameters.USER_ID,id);
                cmd.Parameters.AddWithValue(CreateParameters.USER_NAME,user.UserName);                
                cmd.Parameters.AddWithValue(CreateParameters.USER_CONTACT_NO,user.UserContactNo);
                cmd.Parameters.AddWithValue(CreateParameters.USER_PASSWORD,user.UserPassword);

                cmd.CommandType=CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                
                var sqlDataAdapter = new SqlDataAdapter(cmd);
                sqlDataAdapter.Fill(ds);
            }
            return ds;
        }
        public DataSet DeleteUser(int id)
        {
            string connectionString = _configuration.GetConnectionString("Product");
            var ds = new DataSet();
            using(SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(Procedures.DELETE_USER,con);
                cmd.Parameters.AddWithValue(CreateParameters.USER_ID,id);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;

                var sqlDataAdapter  = new SqlDataAdapter(cmd);
                sqlDataAdapter.Fill(ds);
            }
            return ds;
        }
    }

     
        

    public static class CreateParameters 
    {
        public const string USER_ID = "@UserId";
        public const string USER_NAME = "@UserName";
        public const string USER_DOB = "@UserDOB";
        public const string USER_EMAIL = "@UserEmail";
        public const string USER_CONTACT_NO = "@UserContactNo";
        public const string USER_PASSWORD = "@UserPassword";       

    }
    public static class Procedures
    {
        public const string GET_USERS = "usp_GetAllUsers";
        public const string GET_USERS_BY_ID = "usp_GetUserById";
        public const string ADD_USER = "usp_AddUser";
        public const string UPDATE_USER = "usp_UpdateUser";
        public const string DELETE_USER = "usp_DeleteUser";
    }
}