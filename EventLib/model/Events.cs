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
        public EventType EventSlags { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public List<User> Tilmeldte { get; set; }
        public int MaxTilmeld { get; set; }


        public Events():this(1,"default", "default", DateTime.Now, EventType.Andet,10)
        {
            Tilmeldte = new List<User>();
        }

        public Events(int id, string name, string description, DateTime date, EventType eventSlags, int maxtimeld)
        {
            Id = id;
            Name = name;
            Description = description;
            Date = date;
            EventSlags = eventSlags;
            Tilmeldte = new List<User>();
            MaxTilmeld = maxtimeld;

        }

        public override string ToString()
        {
            return $"{{{nameof(Id)}={Id.ToString()}, {nameof(Name)}={Name}, {nameof(EventSlags)}={EventSlags.ToString()}, {nameof(Description)}={Description}, {nameof(Date)}={Date.ToString()}, {nameof(Tilmeldte)}={Tilmeldte}, {nameof(MaxTilmeld)}={MaxTilmeld.ToString()} }}";
        }
    }
}
