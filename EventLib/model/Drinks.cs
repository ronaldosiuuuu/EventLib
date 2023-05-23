using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventLib.model
{
    public class Drinks
    {
        public int Id { get; set; }
        public DrinkType Drinktype { get; set; } 
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quanity { get; set; }

        public Drinks():this(5, DrinkType.Beer, "Tuborg", 20.00, 100)
        {

        }

        public Drinks(int id, DrinkType drinktype, string name, double price, int quanity)
        {
            Id = id;
            Drinktype = drinktype;
            Name = name;
            Price = price;
            Quanity = quanity;
        }

        public override string ToString()
        {
            return $"{{{nameof(Id)}={Id.ToString()}, {nameof(Drinktype)}={Drinktype.ToString()}, {nameof(Name)}={Name}, {nameof(Price)}={Price.ToString()}, {nameof(Quanity)}={Quanity.ToString()}}}";
        }
    }
}
