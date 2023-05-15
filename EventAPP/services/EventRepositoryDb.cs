using EventLib.model;
using Microsoft.Data.SqlClient;

namespace EventAPP.services
{
    public class EventRepositoryDb : IEventRepository
    {
        public Events Create(Events events)
        {
            String sql = "insert into Event values (@Name, @EventType, @Description, @Date)";

            SqlConnection conn = new SqlConnection(DbServer.GetConnectionString);
            conn.Open();

            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@Name", events.Name);
            cmd.Parameters.AddWithValue("@EventType", events.EventSlags.ToString());
            cmd.Parameters.AddWithValue("@Description", events.Description);
            cmd.Parameters.AddWithValue("@Date", events.Date);

            int row = cmd.ExecuteNonQuery();

            if (row == 1)
            {
                return events;
            }
            else
            {
                throw new KeyNotFoundException();
            }
        }

        public Events Delete(int id)
        {
            SqlConnection conn = new SqlConnection(DbServer.GetConnectionString);
            conn.Open();



            Events ev = GetById(id);
            if (ev is null)
            {
                return null;
            }

            String sql = "Delete from Event where Id = @Id";

            SqlCommand cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@Id", id);


            int row = cmd.ExecuteNonQuery();

            if (row == 1)
            {
                return ev;
            }
            else
            {
                return null;
            }
           

        }

        private Events ReadEvents(SqlDataReader reader)
        {
            Events events = new Events();

            events.Id = reader.GetInt32(0);
            events.Name = reader.GetString(1);
            events.EventSlags = Enum.Parse<EventType>(reader.GetString(2));
            events.Description = reader.GetString(3);
            events.Date = reader.GetDateTime(4);


            return events;
        }

        public List<Events> GetAll()
        {
            SqlConnection conn = new SqlConnection(DbServer.GetConnectionString);
            conn.Open();

            String sql = "Select * from Event";
            
            SqlCommand cmd = new SqlCommand(sql, conn); 

            SqlDataReader reader = cmd.ExecuteReader();

            List<Events> eventsliste = new List<Events>();
            while (reader.Read())
            {   
                eventsliste.Add(ReadEvents(reader));
            }
            return eventsliste;
        }

        public Events GetById(int id)
        {
            SqlConnection conn = new SqlConnection(DbServer.GetConnectionString);
            conn.Open();

            String sql = "Select * from Event where Id = @Id";

            SqlCommand cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@Id", id);  

            SqlDataReader readergetbyid = cmd.ExecuteReader();

            if (readergetbyid.Read())
            {
                return ReadEvents(readergetbyid);
            }
            return null;
        }

        public Events Update(int id, Events events)
        {
            SqlConnection conn = new SqlConnection(DbServer.GetConnectionString);
            conn.Open();

            String sql = "update Event set Name = @Name, EventSlags = @EventType, Description = @Description, Date = @Date where Id = @Id";

            SqlCommand cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@Id", id);
            cmd.Parameters.AddWithValue("@Name", events.Name);
            cmd.Parameters.AddWithValue("@EventType", events.EventSlags.ToString());
            cmd.Parameters.AddWithValue("@Description", events.Description);
            cmd.Parameters.AddWithValue("@Date", events.Date);


            int row = cmd.ExecuteNonQuery();

            if(row == 1)
            {
                events.Id = id;
                return events;
            }
            else
            {
                return null;
            }   
        }
    }
}
