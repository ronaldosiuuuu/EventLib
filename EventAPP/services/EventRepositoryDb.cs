﻿using EventLib.model;
using Microsoft.Data.SqlClient;

namespace EventAPP.services
{
    public class EventRepositoryDb : IEventRepository
    {
        public Events Create(Events events)
        {
            String sql = "insert into Events values (@Id, @Name, @Description, @Date)";

            SqlConnection conn = new SqlConnection(DbServer.GetConnectionString);
            conn.Open();

            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@Name", events.Name);
            cmd.Parameters.AddWithValue("@Description", events.Description);
            cmd.Parameters.AddWithValue("Date", events.Date);

            int row = cmd.ExecuteNonQuery();

            if (row == 1)
            {
                return events;
            }
            else
            {
                return null;
            }
        }

        public Events Delete(int id)
        {
            throw new NotImplementedException();
        }

        private Events ReadEvents(SqlDataReader reader)
        {
            Events events = new Events();

            events.Id = reader.GetInt32(0);
            events.Name = reader.GetString(1);
            events.Description = reader.GetString(2);
            events.Date = reader.GetDateTime(3);


            return events;
        }

        public List<Events> GetAll()
        {
            SqlConnection conn = new SqlConnection(DbServer.GetConnectionString);
            conn.Open();

            String sql = "Select * from Events";
            
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
            throw new NotImplementedException();
        }

        public Events Update(int id, Events events)
        {
            throw new NotImplementedException();
        }
    }
}