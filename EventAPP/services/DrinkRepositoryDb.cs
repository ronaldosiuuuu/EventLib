using EventLib.model;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;

namespace EventAPP.services
{
    public class DrinkRepositoryDb : IDrinkRepository
    {
        public Drinks CreateDrinks(Drinks drink)
        {
            String sql = "insert into Drinks values (@Drinktype, @Name, @Price, @Quanity)";

            SqlConnection conn = new SqlConnection(DbServer.GetConnectionString);
            conn.Open();

            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@Drinktype", drink.Drinktype.ToString());
            cmd.Parameters.AddWithValue("@Name", drink.Name);
            cmd.Parameters.AddWithValue("@Price", drink.Price);
            cmd.Parameters.AddWithValue("@Quanity", drink.Quanity);

            int row = cmd.ExecuteNonQuery();

            if (row == 1)
            {
                return drink;
            }
            else
            {
                throw new KeyNotFoundException();
            }
        }

        private Drinks ReadDrinks(SqlDataReader reader)
        {
            Drinks drinks = new Drinks();

            drinks.Id = reader.GetInt32(0);
            drinks.Drinktype = Enum.Parse<DrinkType>(reader.GetString(1));
            drinks.Name = reader.GetString(2);
            drinks.Price = reader.GetDouble(3);
            drinks.Quanity = reader.GetInt32(4);
            return drinks;
        }

        public Drinks DeleteDrinks(int id)
        {
            SqlConnection conn = new SqlConnection(DbServer.GetConnectionString);
            conn.Open();



            Drinks drinks = GetDrinkById(id);
            if (drinks is null)
            {
                return null;
            }

            String sql = "Delete from Drinks where Id = @Id";

            SqlCommand cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@Id", id);


            int row = cmd.ExecuteNonQuery();

            if (row == 1)
            {
                return drinks;
            }
            else
            {
                return null;
            }
        }

        public List<Drinks> GetAllDrinks()
        {
            SqlConnection conn = new SqlConnection(DbServer.GetConnectionString);
            conn.Open();

            String sql = "Select * from Drinks";

            SqlCommand cmd = new SqlCommand(sql, conn);

            SqlDataReader reader = cmd.ExecuteReader();

            List<Drinks> drinkslist = new List<Drinks>();
            while (reader.Read())
            {
                drinkslist.Add(ReadDrinks(reader));
            }
            return drinkslist;
        }

        public Drinks GetDrinkById(int id)
        {
            SqlConnection conn = new SqlConnection(DbServer.GetConnectionString);
            conn.Open();

            String sql = "Select * from Drinks where Id = @Id";

            SqlCommand cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@Id", id);

            SqlDataReader readergetbyid = cmd.ExecuteReader();

            if (readergetbyid.Read())
            {
                return ReadDrinks(readergetbyid);
            }
            return null;
        }

        public Drinks UpdateDrinks(int id, Drinks drink)
        {
            SqlConnection conn = new SqlConnection(DbServer.GetConnectionString);
            conn.Open();

            String sql = "update Drinks set Drinktype = @Drinktype, Name = @Name, Price = @Price, Quanity = @Quanity where Id = @Id";

            SqlCommand cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@Id", id);
            cmd.Parameters.AddWithValue("@Drinktype", drink.Drinktype.ToString());
            cmd.Parameters.AddWithValue("@Name", drink.Name);
            cmd.Parameters.AddWithValue("@Price", drink.Price);
            cmd.Parameters.AddWithValue("@Quanity", drink.Quanity);


            int row = cmd.ExecuteNonQuery();

            if (row == 1)
            {
                drink.Id = id;
                return drink;
            }
            else
            {
                return null;
            }
        }
    }
}
