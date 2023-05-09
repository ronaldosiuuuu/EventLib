using EventLib.model;

namespace EventAPP.services
{
    public class UserRepository : IUserRepository
    {

        private readonly User _user;

        public static bool iAmAdmin = false;

        public UserRepository()
        {
            _user = new User();
        }

        public bool IsUserAdmin
        {
            get { return _user.IsAdmin; }
            set { _user.IsAdmin = value; }
        }
        public string UserName
        {
            get { return _user.Email; }
            set { _user.Email = value; }
        }

        public bool IsLoggedIn
        {
            get { return _user.IsAdmin; }
            set { _user.IsAdmin = value; }
        }

        //public bool CheckLogIn(string username, string password)
        //{
        //    throw new NotImplementedException();
        //}

        public void SetUserLoggedIn(string name, bool isAdmin)
        {
            _user.Email = name;
            _user.IsAdmin = isAdmin;
            iAmAdmin = isAdmin;
        }

        public void UserLoggedOut()
        {
            _user.Email = "";
            _user.IsAdmin = false;
            iAmAdmin = false;
        }
    }
}
