using EventLib.model;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;

namespace EventAPP.services
{
    public class TilmeldRepositoryDb : ITilmeld
    {
        public int AntalTilmeldte(int eventid)
        {
            String sql = "select count(*) from Tilmeld where EventID = @EventID ";

            SqlConnection conn = new SqlConnection(DbServer.GetConnectionString);
            conn.Open();

            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@EventID", eventid);

            var res = cmd.ExecuteReader();

            if (res.Read())
            {
                
                
                return res.GetInt32(0);
            }
            else
            {
                throw new KeyNotFoundException();
            }

        }

        public Tilmeld CreateTilmeld(Tilmeld tilmeld)
        {
            String sql = "insert into Tilmeld values (@EventID, @Email)";

            SqlConnection conn = new SqlConnection(DbServer.GetConnectionString);
            conn.Open();

            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@Email", tilmeld.Email);
            cmd.Parameters.AddWithValue("@EventID",tilmeld.EventID);

            int row = cmd.ExecuteNonQuery();

            if (row == 1)
            {
                return tilmeld;
            }
            else
            {
                throw new KeyNotFoundException();
            }
        }
    }
}
