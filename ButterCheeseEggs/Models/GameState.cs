﻿using System.Text.Json;

namespace ButterCheeseEggs.Models
{
    public class GameState
    {

        public TileStates[,] Table { get; set; } = new TileStates[3, 3];

        public Players NextPlayer { get; set; }

        public Players Winner { get; set; } = Players.None;

        public string ToJson()
        {
            return JsonSerializer.Serialize(this);
        }

        public static GameState FromJson(string json)
        {
            GameState? result = JsonSerializer.Deserialize<GameState>(json);

            if(result == null)
            {
                throw new InvalidOperationException("Cannot deserialize the Json string into a valid GameState obect");
            }
            else
            {
                return result;
            }

        }
    }
}