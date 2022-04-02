using System.Text.Json;

namespace ButterCheeseEggs.Models
{
    public class GameState
    {

        public Table<TileStates> Table { get; set; } = new Table<TileStates>(3,3);

        public Players NextStepBy { get; set; } = Players.X;

        public Players Winner { get; set; } = Players.None;

        public bool IsGameFinished { get; set; } = false;

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
