using System;
using System.Threading;

public class Crash : Game
{
    public int GamesPlayed { get; set; } = 0;
    public double AvgMultiplier { get; set; } = 0;

    public Crash() : base("Crash") { }

    public override void Play(Player player)
    {
        double sumaCrash = GamesPlayed * AvgMultiplier;
        int gra = GamesPlayed + 1;

        while (true)
        {
            decimal bet;
            string input;
            do
            {
                Console.WriteLine("\nPress 0 to exit");
                Console.WriteLine($"Your current balance: {player.Balance} coins");
                Console.WriteLine("How many coins do you want to bet?");
                input = Console.ReadLine();
                if (input == null) { bet = -1; break; }
            } while (!decimal.TryParse(input, out bet) || bet < 0);

            if (bet == 0)
                break;

            if (bet > player.Balance)
            {
                Console.WriteLine("You don't have enough coins!");
                continue;
            }

            player.SubtractBalance(bet);

            // crash formula
            Random cyfra = new Random();
            double c = cyfra.Next(1, 32);

            Random elo = new Random();
            int e = elo.Next(1, (int)Math.Pow(2, (c - 1)));

            Random hash = new Random();
            int h = hash.Next(0, e - 1);

            double crash = 0.99 * e / (e - h);
            sumaCrash += crash;

            double multiplier = 1;
            bool winFlag = false;
            Console.WriteLine("Press ENTER to cash out during the game!");

            while (multiplier <= crash)
            {
                // Change color depending on multiplier value
                if (multiplier >= 1 && multiplier <= 1.29)
                    Console.ForegroundColor = ConsoleColor.Yellow;
                else if (multiplier > 1.29 && multiplier <= 1.59)
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                else if (multiplier > 1.59 && multiplier <= 2.09)
                    Console.ForegroundColor = ConsoleColor.Red;
                else if (multiplier > 2.09)
                    Console.ForegroundColor = ConsoleColor.DarkRed;

                // Cash out if ENTER is pressed
                if (Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Enter)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    decimal win = bet * (decimal)multiplier;
                    Console.WriteLine($"You cashed out at multiplier {Math.Round(multiplier, 2)}x and won {Math.Round(win, 2)} coins");
                    Console.WriteLine($"Game ended at multiplier {Math.Round(crash, 2)}x");
                    player.AddBalance(win);
                    Console.WriteLine($"Your updated balance: {Math.Round(player.Balance, 2)} coins");
                    winFlag = true;
                    break;
                }

                Console.WriteLine(Math.Round(multiplier, 2) + "x");
                Thread.Sleep(50);
                multiplier += 0.01;
            }

            Console.ForegroundColor = ConsoleColor.White;

            if (!winFlag)
            {
                Console.WriteLine($"You lost {bet} coins\nCrash at {Math.Round(crash, 2)}x\n");
                Console.WriteLine($"Your current balance: {Math.Round(player.Balance, 2)} coins");
            }

            Console.WriteLine($"Game no. {gra}");
            double avg = sumaCrash / gra;
            Console.WriteLine($"Average crash multiplier: {Math.Round(avg, 2)}");
            gra += 1;

            // Update stats
            GamesPlayed++;
            AvgMultiplier = sumaCrash / GamesPlayed;

            Console.WriteLine("Play again? (y/n)");
            string again = Console.ReadLine();
            if (again == null || again.ToLower() != "y")
                break;
        }
    }
}
