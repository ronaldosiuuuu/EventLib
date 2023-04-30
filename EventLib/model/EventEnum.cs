using EventLib.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventLib.model
{
    public enum EventType { Andet, Fest, Spil, Sport}
    public class EventEnum: Events
    {
        public EventType EventSlags { get; set; }

        public EventEnum(int id, string name, string description, DateTime datetime, EventType eventslags)
            :base(id, name, description, datetime)
        {
            EventSlags = eventslags;
        }


      
    }
}


