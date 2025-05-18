public abstract class Game
{
    public string Name { get; set; }

    public Game(string name)
    {
        Name = name;
    }

    public abstract void Play(Player player);
}
