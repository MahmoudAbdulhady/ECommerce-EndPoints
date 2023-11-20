namespace EcommerceApp.Model
{
    public interface IUserRepository
    {
        void CreateUser (User user);
        void GetCurrentUser();
        User LoginUser(string username , string password);

    }
}
