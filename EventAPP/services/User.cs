namespace EventAPP.services
{
    public class User : IUser
    {
        public bool IsUserAdmin => throw new NotImplementedException();

        public string UserName => throw new NotImplementedException();

        public bool IsLoggedIn => throw new NotImplementedException();

        public bool CheckLogIn(string username, string password)
        {
            throw new NotImplementedException();
        }

        public void SetUserLoggedIn(string name, bool isAdmin)
        {
            throw new NotImplementedException();
        }

        public void UserLoggedOut()
        {
            throw new NotImplementedException();
        }
    }
}
