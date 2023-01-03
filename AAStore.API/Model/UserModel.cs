namespace AAStore.API.Model
{
    public class UserModel
    {
        public int UserId { get;  set; }
        public string UserName { get;  set; }
        public string UserDOB { get;  set; }
        public string UserEmail { get;  set; }
        public string UserContactNo { get;  set; }
        public string UserPassword { get;  set; }
        public int RoleId { get;  set; }
    }
}