using EventLib.model;

namespace EventAPP.services
{
    public interface IEventRepository
    {
        public List<Events> GetAll();
        public Events GetById(int id);
        public Events Delete(int id);
        public Events Create(Events events);
        public Events Update(int id, Events events);
    }
}
