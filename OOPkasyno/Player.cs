public class Player
{
    public string Name { get; set; }
    public decimal Balance { get; set; }

    public Player(string name, decimal balance)
    {
        Name = name;
        Balance = balance;
    }

    public void AddBalance(decimal amount)
    {
        Balance += amount;
    }

    public bool SubtractBalance(decimal amount)
    {
        if (Balance >= amount)
        {
            Balance -= amount;
            return true;
        }
        return false;
    }
}
