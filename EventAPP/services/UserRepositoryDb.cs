using EventLib.model;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;

namespace EventAPP.services
{
    public class UserRepositoryDb : IUserRepository
    {

        private User ReadUser(SqlDataReader reader)
        {
            User _user = new User();

            _user.IsAdmin = reader.GetBoolean(0);
            _user.Email = reader.GetString(1);
            _user.Password = reader.GetString(2);


            return _user;
        }

        public bool IsUserAdmin
        {
            get
            {
                SqlConnection conn = new SqlConnection(DbServer.GetConnectionString);
                conn.Open();

                bool IsUserAdmin = false;

                String sql = "Select IsUserAdmin From User Where Email = @Email";

                SqlCommand cmd = new SqlCommand(sql, conn);


                cmd.Parameters.AddWithValue("@Email", "Admin123@zealandzoo.dk");

                SqlDataReader userReader = cmd.ExecuteReader();

                if (userReader.Read())
                {
                    return userReader.GetBoolean(0);
                }
                return IsUserAdmin;

            }

        }


        public string UserName
        {
            get
            {
                SqlConnection conn = new SqlConnection(DbServer.GetConnectionString);
                conn.Open();

                String sql = "Select * From User Where Email = @Email";


                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@Email", "Admin123@zealandzoo.dk");


                SqlDataReader userName = cmd.ExecuteReader();

                if (userName.Read())
                {
                    return userName.GetString(0);
                }
                return null;
            }
        }

        public bool IsLoggedIn
        {
            get
            {

                bool IsUserLoggedIn = false;
                SqlConnection conn = new SqlConnection(DbServer.GetConnectionString);
                conn.Open();

                String sql = "Select IsUserLoggedIn from User where Email = @Email";

                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@Email", "Admin123@zealandzoo.dk");

                SqlDataReader loggedin = cmd.ExecuteReader();

                if (loggedin.Read())
                {
                    return loggedin.GetBoolean(0);
                }
                return IsUserLoggedIn;
            }

        }

        public void SetUserLoggedIn(string email, bool isAdmin)
        {
            SqlConnection conn = new SqlConnection(DbServer.GetConnectionString);
            conn.Open();

            String sql = "Update User set IsUserLoggedIn = 1, IsUserAdmin = @IsUserAdmin where Email = @Email";

            SqlCommand cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("IsUserAdmin", isAdmin);
            cmd.Parameters.AddWithValue("email", email);

            cmd.ExecuteNonQuery();
        }

        public void UserLoggedOut()
        {
            SqlConnection conn = new SqlConnection(DbServer.GetConnectionString);
            conn.Open();

            String sql = "Update User set IsUserLoggedIn = 0";

            SqlCommand cmd = new SqlCommand(sql, conn);

            cmd.ExecuteNonQuery();
        }

        public User DeleteUser(string email)
        {
            SqlConnection conn = new SqlConnection(DbServer.GetConnectionString);
            conn.Open();



            User users = GetUserByEmail(email);
            if (users is null)
            {
                return null;
            }

            String sql = "Delete from User where Email = @Email";

            SqlCommand cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@Email", email);


            int row = cmd.ExecuteNonQuery();

            if (row == 1)
            {
                return users;
            }
            else
            {
                return null;
            }

        }

        public List<User> GetAllUsers()
        {
            SqlConnection conn = new SqlConnection(DbServer.GetConnectionString);
            conn.Open();

            String sql = "Select * from [User]";

            SqlCommand cmd = new SqlCommand(sql, conn);

            SqlDataReader readAllUsers = cmd.ExecuteReader();

            List<User> userlist = new List<User>();
            while (readAllUsers.Read())
            {
                userlist.Add(ReadUser(readAllUsers));
            }
            return userlist;
        }

        public User CreateUser(User newUser)
        {
            String sql = "insert into [User] values (@IsUserAdmin,@Email,@Password)";

            SqlConnection conn = new SqlConnection(DbServer.GetConnectionString);
            conn.Open();

            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@Email", newUser.Email);
            cmd.Parameters.AddWithValue("@IsUserAdmin", newUser.IsAdmin);
            cmd.Parameters.AddWithValue("@Password", newUser.Password);

            int row = cmd.ExecuteNonQuery();

            if (row == 1)
            {
                return newUser;
            }
            else
            {
                return null;
            }
        }

        public bool TjekLogInd(string username, string password)
        {
            SqlConnection conn = new SqlConnection(DbServer.GetConnectionString);
            conn.Open();

            String sql = "Select count (*) from [User] where Email = @username and Password = @password";

            SqlCommand cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@Email", username);
            cmd.Parameters.AddWithValue("@Password", password);

            int count = Convert.ToInt32(cmd.ExecuteScalar());

            return count > 0;
        }

        public User GetUserByEmail(string email)
        {
            SqlConnection conn = new SqlConnection(DbServer.GetConnectionString);
            conn.Open();

            String sql = "Select Email from [User] where Email = @Email";

            SqlCommand cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@Email", email);

            SqlDataReader readergetbyemail = cmd.ExecuteReader();

            if (readergetbyemail.Read())
            {
                return ReadUser(readergetbyemail);
            }
            return null;
        }
    }
}
