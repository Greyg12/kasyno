using System;

public class CoinFlip : Game
{
    public CoinFlip() : base("Coin Flip") { }

    public override void Play(Player player)
    {
        Console.WriteLine("Enter your bet:");
        if (!decimal.TryParse(Console.ReadLine(), out decimal bet))
        {
            Console.WriteLine("Invalid bet.");
            return;
        }
        if (!player.SubtractBalance(bet))
        {
            Console.WriteLine("Not enough balance!");
            return;
        }

        Console.WriteLine("Choose: 1. Heads  2. Tails");
        string choice = Console.ReadLine();
        if (choice != "1" && choice != "2")
        {
            Console.WriteLine("Invalid choice.");
            player.AddBalance(bet); // refund bet
            return;
        }

        Random rnd = new Random();
        int result = rnd.Next(1, 3); // 1 = Heads, 2 = Tails
        Console.WriteLine(result == 1 ? "It's Heads!" : "It's Tails!");

        if (choice == result.ToString())
        {
            Console.WriteLine($"You win! {bet * 2}");
            player.AddBalance(bet * 2);
        }
        else
        {
            Console.WriteLine("You lose!");
        }
    }
}
