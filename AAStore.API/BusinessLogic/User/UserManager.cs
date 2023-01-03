using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using AAStore.API.Model;
using AAStore.API.Repository.User;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace AAStore.API.BusinessLogic.User
{
    public class UserManager : IUserManager
    {
        private readonly IConfiguration _configuration;
        private readonly IUserRepository _userRepository;

        public UserManager(IConfiguration configuration,IUserRepository userRepository)
        {
            _configuration = configuration;
            _userRepository = userRepository;
        }

        public List<UserModel> GetUsers()
        {
           List<UserModel> um = new List<UserModel>();
           var ds = new DataSet();

           ds = _userRepository.GetUsers();

           if (ds!=null)
           {
            DataTable dt = ds.Tables[0];
            if (dt!=null && dt.Rows.Count > 0 )
            {
                foreach (DataRow dr in dt.Rows)
                {
                    UserModel data = new UserModel();
                    data.UserId = Convert.ToInt32(dr["UserId"].ToString());
                    data.UserName = dr["UserName"].ToString();
                    data.UserEmail = dr["UserEmail"].ToString();
                    data.UserContactNo = dr["UserContactNo"].ToString();
                    string dt1 = Convert.ToDateTime(dr["UserDOB"]).ToString("yyyy-MM-dd");
                    data.UserDOB = dt1;
                    data.RoleId=Convert.ToInt32(dr["RoleId"].ToString());

                    um.Add(data);
                }
            }
           }
           return um;
        }

         public UserModel GetCategoryById(int id)
        {
            DataSet DS = new DataSet();
            UserModel um = new UserModel();
            
            DS = _userRepository.GetUserById(id);
            if (DS!=null)
            {
                DataTable dt = DS.Tables[0];
                if(dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        um.UserId = Convert.ToInt32(dr["UserId"].ToString());
                        um.UserName = dr["UserName"].ToString();
                        um.UserEmail = dr["UserEmail"].ToString();
                        um.UserContactNo = dr["UserContactNo"].ToString();
                        string dt1 = Convert.ToDateTime(dr["UserDOB"]).ToString("yyyy-MM-dd");
                        um.UserDOB = dt1;
                        um.RoleId=Convert.ToInt32(dr["RoleId"].ToString());
                    }
                }
            }
            return um;
        }

        public bool AddUser(UserModel user)
        {
            var ds = _userRepository.AddUser(user);
            if (ds == null)
            {
                return false;
            }
            return true;
        }

        public bool UpdateUser(int id ,UserModel user)
        {
            var ds = _userRepository.UpdateUser(id,user);
            if(ds == null)
            {
                return false;
            }
            return true;
        }

        public bool DeleteUser(int id )
        {
            var DS = _userRepository.DeleteUser(id);
            if(DS == null)
            {
                return false;
            }
            return true;
        }
    }

}