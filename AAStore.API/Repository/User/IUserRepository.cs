using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using AAStore.API.Model;

namespace AAStore.API.Repository.User
{
    public interface IUserRepository
    {
        DataSet GetUsers();
        DataSet GetUserById(int id);
        DataSet AddUser(UserModel user);
        DataSet UpdateUser(int id,UserModel user);
        DataSet DeleteUser(int id);
    }
}