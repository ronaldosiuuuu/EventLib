using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace EventLib.model
{
    public class Events
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }

        public Events():this(1,"default", "default", DateTime.Now)
        {

        }

        public Events(int id, string name, string description, DateTime date)
        {
            Id = id;
            Name = name;
            Description = description;
            Date = date;
        }

        public override string ToString()
        {
            return $"{{{nameof(Id)}={Id.ToString()}, {nameof(Name)}={Name}, {nameof(Description)}={Description}, {nameof(Date)}={Date.ToString()}}}";
        }
    }
}
