using EventLib.model;

namespace EventAPP.services
{
    public class EventRepository : IEventRepository
    {

        private readonly List<Events> _events;

        public EventRepository()
        {
            _events = new List<Events>();
        }
        public Events Create(Events events)
        {
            _events.Add(events);
            return events;
        }

        public Events Delete(int id)
        {
            Events delete = GetById(id);
            _events.Remove(delete);
            return delete;

        }

        public List<Events> GetAll()
        {
            List<Events> list = new List<Events>();
            foreach (Events events in _events)
            {
                list.Add(events);
            }
            return list;
        }

        public Events Update(int id, Events events)
        {
            foreach(Events aEvent in _events)
            {
                if(aEvent.Id == id)
                {
                   aEvent.Id = events.Id;
                   return aEvent;
                }

            }
            return null;
        }
    }
}
