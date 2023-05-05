using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventLib.model
{
    public class loggedIn
    {
        public string Email { get; set; }
        public bool IsAdmin { get; set; }
        public string Password { get; set; }
        


        public loggedIn(string email, bool isAdmin, string password)
        {
            Email = email;
            IsAdmin = isAdmin;
            Password = password;
        }


        public loggedIn():this("User@zealand.dk", true, "password")
        {

        }

        public override string ToString()
        {
            return $"{{{nameof(Email)}={Email}, {nameof(IsAdmin)}={IsAdmin.ToString()}, {nameof(Password)}={Password}}}";
        }
    }
}
