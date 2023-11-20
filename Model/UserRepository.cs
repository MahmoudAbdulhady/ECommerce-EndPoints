namespace EcommerceApp.Model
{
    public class UserRepository : IUserRepository
    {
        private readonly UserDatabaseContext _userDatabaseContext;


        public UserRepository(UserDatabaseContext userDatabaseContext)
        {
            _userDatabaseContext = userDatabaseContext;
        }

        public void CreateUser(User user)
        {

            _userDatabaseContext.Users.Add(user);
            _userDatabaseContext.SaveChanges();
        }

        public void GetCurrentUser()
        {
            throw new NotImplementedException();
        }

        public User LoginUser(string username , string password)
        {
            return  _userDatabaseContext.Users.FirstOrDefault(u=> u.UserName == username && u.Password == password); 
        }
    }
}
