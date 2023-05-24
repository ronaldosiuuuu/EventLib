using EventLib.model;

namespace EventAPP.services
{
    public class UserRepository : IUserRepository
    {

        private User _user;

        public static bool iAmAdmin = false;

        public static bool loggedin = false;


        private List<User> _users = new List<User>();

        public UserRepository()
        {
            _user = new User();
            _users.Add(new User("Admin123@ZealandZoo.dk", true, "zealandzoo"));
            _users.Add(new User("Khalidilmi@zealandzoo.dk", false, "khalid123"));
            
        }

        public User CreateUser(User newUser)
        {
            _users.Add(newUser);
            return newUser;
        }

        public User GetUserByEmail(string email)
        {
            foreach(User user in _users)
            {
                if(email == user.Email)
                {
                    return user;
                }
            }
            return null;
        }

        public User DeleteUser(string email)
        {
            User delete = GetUserByEmail(email);
            _users.Remove(delete);
            return delete;
        }
        public List<User> GetAllUsers()
        {
            return _users.ToList();
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
            get
            {
                return !string.IsNullOrEmpty(_user.Email);
            }
        }

        public bool TjekLogInd(String username, string password)
        {
            foreach (User b in _users)
                if (b.Email == username && b.Password == password)
                {
                    SetUserLoggedIn(b.Email, b.IsAdmin);
                    return true;
                }
            return false;
        }



        public void SetUserLoggedIn(string name, bool isAdmin)
        {
            _user.Email = name;
            _user.IsAdmin = isAdmin;
            iAmAdmin = isAdmin;
            loggedin = true;
        }

        public void UserLoggedOut()
        {
            _user.Email = "";
            _user.IsAdmin = false;
            iAmAdmin = false;
            loggedin = false;
        }
    }
}
