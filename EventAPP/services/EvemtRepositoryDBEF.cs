using EventLib.model;

namespace EventAPP.services
{
    public class EvemtRepositoryDBEF: IEventRepository
    {
        private EventDBContext _db = new EventDBContext();


        public List<Events> GetAll()
        {
            return new List<Events>(_db.Events);
        }

        public Events GetById(int id)
        {
            Events? events = GetAll().FirstOrDefault(x => x.Id == id);
            if (events == null)
            {
                throw new KeyNotFoundException();
            }
            return events;
        }
        public Events Create(Events events)
        {
            _db.Events.Add(events);
            _db.SaveChanges();
            return events;
            
        }

        public Events Delete(int id)
        {
            Events? events = GetById(id);
            _db.Events.Remove(events);
            _db.SaveChanges();

            return events;
        }

        public Events Update(int id, Events events)
        {
            Events? updateEvents = GetById(id);

            _db.Events.Update(updateEvents);
            _db.SaveChanges();

            return events;
        }

       
    }
}
