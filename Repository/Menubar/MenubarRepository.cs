using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Microsoft.Extensions.Configuration;
using AAStore.API.Model;

namespace AAStore.API.Repository.Menubar
{
    public class MenubarRepository : IMenubarRepository
    {
        private readonly IConfiguration _configuration;
        public MenubarRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public DataSet GetMenu()
        {
            string connectionString = _configuration.GetConnectionString("Product");
            var ds = new DataSet();

            using(SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(Procedures.GET_MENU_DETAILS,con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;

                using (var sqlDataAdapter = new SqlDataAdapter(cmd))
                {
                    sqlDataAdapter.Fill(ds);
                }
            }
            return ds;            
        }

        public DataSet AddMenu(MenubarModel menuBar)
        {
            string connectionString = _configuration.GetConnectionString("Product");
            var ds = new DataSet();

            using(SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(Procedures.ADD_MENU_NAME,con);
                cmd.Parameters.AddWithValue(CreateParameters.MENUNAME,menuBar.MenuName);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;

                var sqlDataAdapter = new SqlDataAdapter(cmd);
                sqlDataAdapter.Fill(ds);
            }
            return ds;
        }

        public static class CreateParameters { 
             public const string MENUNAME = "@MenuName";
        }

        public static class Procedures
        {
            public const string GET_MENU_DETAILS= "usp_GetMenu";
            public const string ADD_MENU_NAME = "usp_AddMenu";
        }
    }
}