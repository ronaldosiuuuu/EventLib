using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventLib.model
{
    public class Tilmeld
    {
        public string Email { get; set; }
        public int EventID { get; set; }


        public Tilmeld() : this("test", 17)
        {

        }
        public Tilmeld(string email, int eventid)
        {
            Email = email;
            EventID = eventid;
        }

        public override string ToString()
        {
            return $"{{{nameof(Email)}={Email}, {nameof(EventID)}={EventID.ToString()}}}";
        }
    }
}
