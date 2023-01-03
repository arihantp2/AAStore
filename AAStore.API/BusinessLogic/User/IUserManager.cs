using AAStore.API.Model;

namespace AAStore.API.BusinessLogic.User
{
    public interface IUserManager 
    {
        List<UserModel> GetUsers();
        UserModel GetCategoryById(int id);
        public bool AddUser(UserModel user);
        public bool UpdateUser(int id ,UserModel user);
        public bool DeleteUser(int id );
    }
}