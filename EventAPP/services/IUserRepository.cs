using EventLib.model;

namespace EventAPP.services
{
    public interface IUserRepository
    {
        bool IsUserAdmin { get; }
        string UserName { get; }
        bool IsLoggedIn { get; }

        void SetUserLoggedIn(string email, bool isAdmin);

        public User DeleteUser(string email);
        public List<User> GetAllUsers();
        public User CreateUser(User newUser);
        public User GetUserByEmail(string email);

        void UserLoggedOut();
    }
}
