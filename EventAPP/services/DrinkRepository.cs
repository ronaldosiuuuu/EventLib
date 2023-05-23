using EventLib.model;
using Microsoft.Extensions.Logging;

namespace EventAPP.services
{
    public class DrinkRepository : IDrinkRepository
    {
        private List<Drinks> _drinks = new List<Drinks>()
        {
            new Drinks(1, DrinkType.SoftDrinks, "Tester", 20.00, 100),
            new Drinks(2, DrinkType.Tequila, "Testing", 30.00, 200)
        };
        public Drinks CreateDrinks(Drinks drink)
        {
            _drinks.Add(drink);
            return drink;
        }

        public Drinks DeleteDrinks(int id)
        {
            Drinks deletedrinks = GetDrinkById(id);
            _drinks.Remove(deletedrinks);
            return deletedrinks;
        }

        public List<Drinks> GetAllDrinks()
        {
            return new List<Drinks>(_drinks);
        }

        public Drinks GetDrinkById(int id)
        {
            foreach (Drinks drinks in _drinks)
            {
                if (id == drinks.Id)
                {
                    return drinks;
                }
            }
            return null;
        }

        public Drinks UpdateDrinks(int id, Drinks drink)
        {
            foreach (Drinks aDrink in _drinks)
            {
                if (aDrink.Id == id)
                {
                    aDrink.Id = drink.Id;
                    aDrink.Drinktype = drink.Drinktype;
                    aDrink.Name = drink.Name;
                    aDrink.Price = drink.Price;
                    aDrink.Quanity = drink.Quanity;

                    return aDrink;
                }

            }
            return null;
        }
    }
}
