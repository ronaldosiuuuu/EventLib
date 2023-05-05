namespace EventAPP.services
{
    public interface IUser
    {
        bool IsUserAdmin { get; }
        string UserName { get; }
        bool IsLoggedIn { get; }

        void SetUserLoggedIn(string email, bool isAdmin);

        public bool CheckLogIn(string username, string password);

        void UserLoggedOut();
    }
}
