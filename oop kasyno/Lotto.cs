using System;
using System.Collections.Generic;
using System.Linq;

public class Lotto : Game
{
    public Lotto() : base("Lotto") { }

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

        HashSet<int> userNumbers = new HashSet<int>();
        Console.WriteLine("Pick 6 numbers from 1 to 49:");
        while (userNumbers.Count < 6)
        {
            Console.Write($"Number {userNumbers.Count + 1}: ");
            if (int.TryParse(Console.ReadLine(), out int num) && num >= 1 && num <= 49 && !userNumbers.Contains(num))
            {
                userNumbers.Add(num);
            }
            else
            {
                Console.WriteLine("Invalid or duplicate number.");
            }
        }

        Random rnd = new Random();
        HashSet<int> draw = new HashSet<int>();
        while (draw.Count < 6)
        {
            draw.Add(rnd.Next(1, 50));
        }

        Console.WriteLine("Drawn numbers: " + string.Join(", ", draw));
        int hits = userNumbers.Intersect(draw).Count();

        decimal win = 0;
        switch (hits)
        {
            case 3: win = bet * 3; break;
            case 4: win = bet * 40; break;
            case 5: win = bet * 1500; break;
            case 6: win = bet * 1_000_000; break;
        }

        Console.WriteLine($"Matched numbers: {hits}");
        if (win > 0)
        {
            Console.WriteLine($"Congratulations! You matched {hits} numbers and won {win}!");
            player.AddBalance(win);
        }
        else
        {
            Console.WriteLine($"No win. You matched {hits} numbers.");
        }
    }
}
