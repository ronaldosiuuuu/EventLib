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

        public Events GetById(int id)
        {
            foreach(Events events in _events)
            {
                if(id == events.Id)
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
            foreach(Events aEvent in _events)
            {
                if(aEvent.Id == id)
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
    }
}
