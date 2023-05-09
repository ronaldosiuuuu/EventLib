using EventLib.model;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;

//namespace EventAPP.services
//{
//    public class UserRepositoryDb : IUserRepository
//    {

//        private User ReadUser(SqlDataReader reader)
//        {
//            User _user = new User();

//            _user.Email = reader.GetString(1);
//            _user.Password = reader.GetString(2);
//            _user.IsAdmin = reader.GetBoolean(3);


//            return _user;
//        }

//        public bool IsUserAdmin
//        {
//            get
//            {
//                SqlConnection conn = new SqlConnection(DbServer.GetConnectionString);
//                conn.Open();


//                String sql = "Select IsAdmin From User Where Email = @Email";

//                SqlCommand cmd = new SqlCommand(sql, conn);


//                cmd.Parameters.AddWithValue("@Email", "AdnanTest");
                
//                SqlDataReader userReader = cmd.ExecuteReader();

//                if (userReader.Read())
//                {
//                    return userReader.GetBoolean(0);
//                }
//                return userReader.GetBoolean(1);

//            }

//        }


//        public string UserName
//        {
//            get
//            {
//                SqlConnection conn = new SqlConnection(DbServer.GetConnectionString);
//                conn.Open();

//                String sql = "Select * From User Where Email = @Email";


//                SqlCommand cmd = new SqlCommand(sql, conn);

//                cmd.Parameters.AddWithValue("@Email", "Admin");


//                SqlDataReader userName = cmd.ExecuteReader();

//                if (userName.Read())
//                {
//                    return userName.GetString(0);
//                }
//                return userName.GetString(1);
//            }
//        }

//        public bool IsLoggedIn
//        {
//            get
//            {
//                SqlConnection conn = new SqlConnection(DbServer.GetConnectionString);
//                conn.Open();

//                String sql = "Select * From User";


//                SqlCommand cmd = new SqlCommand(sql, conn);

//                SqlDataReader loggedin = cmd.ExecuteReader();

//                if (loggedin.Read())
//                {
//                    return loggedin.GetBoolean(0);
//                }
//                return loggedin.GetBoolean(1);
//            }
//        }

//        public void SetUserLoggedIn(string email, bool isAdmin)
//        {
//            SqlConnection conn = new SqlConnection(DbServer.GetConnectionString);
//            conn.Open();

//            String sql = "Select "
//        }

//        public void UserLoggedOut()
//        {
//            throw new NotImplementedException();
//        }
//    }
//}
