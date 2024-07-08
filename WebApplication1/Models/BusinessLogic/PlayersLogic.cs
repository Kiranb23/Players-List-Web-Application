using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Data;

namespace WebApplication1.Models.BusinessLogic
{
    public class PlayersLogic
    {
        public List<Player> GetPlayersList() 
        {
            List<Player> players = new List<Player>();

            var connectionString = "data source=JAANU; database=PLQ; integrated security=true;";

            SqlConnection sqlConnection = new SqlConnection(connectionString);

            sqlConnection.Open();

            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM PlayerDetailsView;", sqlConnection);

            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            while (sqlDataReader.Read())
            {
                Player player = new Player();
                player.PlayerId = int.Parse(sqlDataReader["PlayerId"].ToString());
                player.PlayerName = (sqlDataReader["PlayerName"].ToString());
                player.Role = (sqlDataReader["playerRole"].ToString());
                player.Runs = int.Parse(sqlDataReader["runs"].ToString());
                player.Wickets = int.Parse(sqlDataReader["wickets"].ToString());
                players.Add(player);
            }
            sqlConnection.Close();
            return players;
        }

        public Player GetPlayer(int id)
        {
            var playerList = GetPlayersList();
            return playerList.Where(s => s.PlayerId == id).FirstOrDefault();
        }

        public bool AddOrUpdatePlayer(Player player)
        {
            var connectionString = "data source=JAANU; database=PLQ; integrated security=true;";

            SqlConnection sqlConnection = new SqlConnection(connectionString);

            sqlConnection.Open();

            SqlCommand sqlCommand = new SqlCommand("InsertOrUpdatePlayerStats", sqlConnection);

            sqlCommand.CommandType = CommandType.StoredProcedure;

            sqlCommand.Parameters.AddWithValue("@playername", player.PlayerName);
            sqlCommand.Parameters.AddWithValue("@playerrole", player.Role);
            sqlCommand.Parameters.AddWithValue("@runs", player.Runs);
            sqlCommand.Parameters.AddWithValue("@wickets", player.Wickets);

            sqlCommand.ExecuteNonQuery();

            sqlConnection.Close();

            return true;

        }

        public bool DeletePlayer(int id)
        {
            var connectionString = "data source=JAANU; database=PLQ; integrated security=true;";

            SqlConnection sqlConnection = new SqlConnection(connectionString);

            sqlConnection.Open();

            SqlCommand sqlCommand = new SqlCommand("DeletePlayerRecord", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@playerid", id);


            sqlCommand.ExecuteNonQuery();


            sqlConnection.Close();
            return true;
        }
    }
}