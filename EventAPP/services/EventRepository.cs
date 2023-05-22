using EventLib.model;
using Microsoft.AspNetCore.Mvc.Filters;

namespace EventAPP.services
{
    public class EventRepository : IEventRepository
    {

        //private readonly List<Events> _events;

        //    public EventRepository()
        //{
        //    _events = new List<Events>();
        //}

        private List<Events> _events = new List<Events>()
        {
            new Events(1, "Test", "Test", DateTime.Now, EventType.Fest),
            new Events(2, "", "", DateTime.Now, EventType.Andet)
        };
        public Events Create(Events events)
        {
            _events.Add(events);
            return events;
        }

        public Events GetById(int id)
        {
            foreach (Events events in _events)
            {
                if (id == events.Id)
                {
                    return events;
                }
            }
            return null;
        }

        public Events Delete(int id)
        {
            Events delete = GetById(id);
            _events.Remove(delete);
            return delete;

        }

        public List<Events> GetAll()
        {
            return new List<Events>(_events);
        }

        public Events Update(int id, Events events)
        {
            foreach (Events aEvent in _events)
            {
                if (aEvent.Id == id)
                {
                    aEvent.Id = events.Id;
                    aEvent.Name = events.Name;
                    aEvent.Description = events.Description;
                    aEvent.EventSlags = events.EventSlags;
                    aEvent.Date = events.Date;

                    return aEvent;
                }

            }
            return null;
        }

        public Events RegisterUser(int eventid, int userId)
        {
            throw new NotImplementedException();
        }

        public bool RegisterLimitation(int eventid, int userid)
        {
            throw new NotImplementedException();
        }

        //    public Events RegisterUser(int eventid, int userId)
        //    {
        //    }

        //    public bool RegisterLimitation(int eventid)
        //    {

        //    }
        //}
    }
}

