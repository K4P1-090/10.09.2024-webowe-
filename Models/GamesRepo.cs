using System;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;

namespace _10._09._2024_webowe_.Models;

public class GamesRepo
{
    
    private string? connString="Data Source=  Games.db";
     
   
    public List<Game> GetGames(){
        List<Game> games = new List<Game>();
        using var conn = new SqliteConnection(connString);
        using var cmd = conn.CreateCommand();
        cmd.CommandText = "SELECT * FROM Games";
        conn.Open();
        using var reader = cmd.ExecuteReader();
        while (reader.Read()){
            games.Add(new Game{
               
                Title = reader.GetString(0),
                Cathegory = reader.GetString(1),
                Year = reader.GetString(2),
                Price = reader.GetDecimal(3)
            });
        }
        conn.Close();
        return games;
    }

    public Dictionary<int, int> GetGamesCountByYear()
    {
        Dictionary<int, int> gamesCountByYear = new Dictionary<int, int>();
        using var conn = new SqliteConnection(connString);
        using var cmd = conn.CreateCommand();
        cmd.CommandText = "SELECT Year, COUNT(*) FROM Games GROUP BY Year";
        conn.Open();
        using var reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            int year = reader.GetInt32(0);
            int count = reader.GetInt32(1);
            gamesCountByYear[year] = count;
        }
        conn.Close();
        return gamesCountByYear;
    }
}

