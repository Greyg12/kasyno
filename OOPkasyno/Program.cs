using System;
using System.IO;
using System.Globalization;

class Program
{
    static void Main()
    {
        Casino casino = new Casino();
        var crashGame = new Crash();
        casino.AddGame(crashGame);
        casino.AddGame(new Lotto());
        casino.AddGame(new Roulette());
        casino.AddGame(new CoinFlip());

        // Odczyt salda, liczby gier crash i średniego mnożnika z pliku
        decimal balance = 100;
        int crashGamesPlayed = 0;
        double crashAvgMultiplier = 0;
        string balanceFile = "balance.txt";
        if (File.Exists(balanceFile))
        {
            string[] lines = File.ReadAllLines(balanceFile);
            if (lines.Length > 0)
                decimal.TryParse(lines[0].Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out balance);
            if (lines.Length > 1)
                int.TryParse(lines[1], out crashGamesPlayed);
            if (lines.Length > 2)
                double.TryParse(lines[2].Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out crashAvgMultiplier);
        }

        Player player = new Player("", balance);
        casino.AddPlayer(player);

        // Przywróć statystyki crash
        crashGame.GamesPlayed = crashGamesPlayed;
        crashGame.AvgMultiplier = crashAvgMultiplier;

        while (true)
        {
            Console.WriteLine($"Twoje saldo wynosi: {player.Balance}");
            Console.WriteLine("Wybierz opcję: 1. Crash 2. Lotto 3. Ruletka 4. Rzut Moneta 5. Wpłata 6. Wypłata 0. Zamknij");
            string choice = Console.ReadLine();
            if (choice == "1")
            {
                casino.Games[0].Play(player);
            }
            else if (choice == "2")
            {
                casino.Games[1].Play(player);
            }
            else if (choice == "3")
            {
                casino.Games[2].Play(player);
            }
            else if (choice == "4")
            {
                casino.Games[3].Play(player);
            }
            else if (choice == "5")
            {
                Console.Write("Podaj kwotę wpłaty: ");
                if (decimal.TryParse(Console.ReadLine(), out decimal deposit) && deposit > 0)
                {
                    player.AddBalance(deposit);
                    Console.WriteLine($"Wpłacono {deposit}. Nowe saldo: {player.Balance}");
                }
                else
                {
                    Console.WriteLine("Nieprawidłowa kwota.");
                }
            }
            else if (choice == "6")
            {
                Console.Write("Podaj kwotę wypłaty: ");
                if (decimal.TryParse(Console.ReadLine(), out decimal withdraw) && withdraw > 0)
                {
                    if (player.SubtractBalance(withdraw))
                    {
                        Console.WriteLine($"Wypłacono {withdraw}. Nowe saldo: {player.Balance}");
                    }
                    else
                    {
                        Console.WriteLine("Za mało środków.");
                    }
                }
                else
                {
                    Console.WriteLine("Nieprawidłowa kwota.");
                }
            }
            else if (choice == "0")
            {
                // Zapis salda, liczby gier crash i średniego mnożnika do pliku za pomocą StreamWriter
                try
                {
                    using (StreamWriter sw = new StreamWriter(balanceFile, false))
                    {
                        sw.WriteLine(player.Balance.ToString(CultureInfo.InvariantCulture));
                        sw.WriteLine(crashGame.GamesPlayed.ToString());
                        sw.WriteLine(crashGame.AvgMultiplier.ToString(CultureInfo.InvariantCulture));
                    }
                    Console.WriteLine("Dane zapisane do pliku balance.txt.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Błąd zapisu do pliku: " + ex.Message);
                }
                break;
            }
        }
    }
}
