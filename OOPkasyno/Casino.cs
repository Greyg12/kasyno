using System.Collections.Generic;

public class Casino
{
    public List<Player> Players { get; set; } = new List<Player>();
    public List<Game> Games { get; set; } = new List<Game>();

    public void AddPlayer(Player player)
    {
        Players.Add(player);
    }

    public void AddGame(Game game)
    {
        Games.Add(game);
    }
}
