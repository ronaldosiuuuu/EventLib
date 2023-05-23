using EventLib.model;

namespace EventAPP.services
{
    public interface IDrinkRepository
    {
        public List<Drinks> GetAllDrinks();
        public Drinks GetDrinkById(int id);
        public Drinks CreateDrinks(Drinks drink);
        public Drinks DeleteDrinks(int id);
        public Drinks UpdateDrinks(int id, Drinks drink);
    }
}
