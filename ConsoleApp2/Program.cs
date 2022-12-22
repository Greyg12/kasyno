using System.Drawing;
using System.Reflection.Metadata.Ecma335;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp12
{
    internal class Program
    {
        static class Zmienne
        {
            public static double stan_konta;
        }
        static void bilans()
        {
            //Console.WriteLine("Twój bilans w kasynie wynosi win - bet")
        }
        static void wplaty()
        {
            //double wplata += stan_konta;
            //do{
            //Console.WriteLine($"Aktualnie masz x monet\n Ile monet chcesz wpłacić?");
            //while(!double.TryParse(Console.ReadLine(), out wplata")
        }
        static void wyplaty()
        {
            //double wyplata -= stan_konta;
            //do{
            //Console.WriteLine($"Aktualnie masz x monet\n Ile monet chcesz wypłacić?");
            //while(!double.TryParse(Console.ReadLine(), out wylata")
        }
        static void wybor()
        {
            Console.WriteLine("Witaj na naszej stronie! :D");
            Console.WriteLine($"Aktualnie posiadasz {Zmienne.stan_konta} monet");
            Console.WriteLine("1. Graj w crash");
            Console.WriteLine("2. Graj w lotto");
            Console.WriteLine("3. Doładuj monety do konta");
            Console.WriteLine("4. Wypłać monety z konta");
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int a))
                {
                    switch (a)
                    {
                        case 1:
                            crash();
                            break;
                        //case 2:
                        //wplaty();
                        //break;
                        //do{ Console.WriteLine("Ile monet chcesz dodac do swojego konta");} while(!double.TryParse(Console.ReadLine(), out dodaj = stan_konta+dodaj")
                        //case 3:
                        //wyplaty();
                        //break;
                        case 2:
                            lotto();
                            break;
                        default:
                            Console.WriteLine("Nie istnieje taki program");
                            break;
                    }
                }
            }
        }

        static void lotto()
        {
            do
            {
                Console.WriteLine("Ile chcesz mieć pieniędzy na start?");
            } while (!double.TryParse(Console.ReadLine(), out Zmienne.stan_konta) || Zmienne.stan_konta <= 2);

            Console.WriteLine("1. Graj w lotto");
            Console.WriteLine("2. Opuść");

            if (int.TryParse(Console.ReadLine(), out int graj))
                switch (graj)
                {
                    case 1:
                        Zmienne.stan_konta -= 3;
                        break;
                    default:
                        wybor();
                        break;
                }

            //podaj 6 cyfr od 1 do 49
            int[] wybrana_tabela = new int[6];
            int wybrana_cyfra;
            Console.WriteLine("Podaj 6 cyfr od 1 do 49");
            for (int i = 0; i <= 5; i++)
            {
                do
                {
                    Console.Write($"Cyfra numer {i + 1}: ");
                } while (!int.TryParse(Console.ReadLine(), out wybrana_cyfra) || wybrana_cyfra < 1 || wybrana_cyfra > 49);
            }

            //wygrywajaca tabela
            Random losowe_liczby = new Random();
            int[] wygrywajaca_tabela = new int[6];

            Console.WriteLine("Wygrywajace numery to: ");
            for (int wygrywajace_liczby = 0; wygrywajace_liczby <= 5; wygrywajace_liczby++)
            {
                wygrywajaca_tabela[wygrywajace_liczby] = losowe_liczby.Next(1, 49);
                Console.Write($"{wygrywajaca_tabela[wygrywajace_liczby]} ");
                //Thread.Sleep(1000);
            }
            // Array.Sort(wybrana_tabela);
            // Array.Sort(wygrywajaca_tabela);
            Console.WriteLine();

            foreach (var a in wygrywajaca_tabela) Console.WriteLine(wygrywajaca_tabela);

            IEnumerable<int> res = wybrana_tabela.AsQueryable().Intersect(wygrywajaca_tabela);
            int b = 0;
            foreach (int a in res)
            {
                b++;
                Console.WriteLine(b);
            }


            Console.WriteLine($"Stan konta wynosi {Zmienne.stan_konta} monet(y)");
            lotto();
        }

        //porowynanie wybranych z wygranymi i jesli 3 takie same to wygrana iles tam itd...
        static void crash()
        {
            double bet, srednia;
            double suma_crash = 0;
            int gra = 1;

            do
            {
                Console.WriteLine("Ile chcesz mieć pieniędzy na start?");
            } while (!double.TryParse(Console.ReadLine(), out Zmienne.stan_konta) || Zmienne.stan_konta <= 0);

            for (; ; )
            {

                do
                {

                    //obstawianie
                    do
                    {
                        Console.WriteLine("\nKliknij 0, aby wyjść");
                        Console.WriteLine("Ile monet chcesz obstawić?");
                    } while (!double.TryParse(Console.ReadLine(), out bet) || bet < 0);

                    if (bet > Zmienne.stan_konta)
                    {
                        Console.WriteLine("Nie masz tylu monet na koncie!");
                    }
                } while (bet > Zmienne.stan_konta);
                if (bet == 0)
                {
                    break;
                }
                Zmienne.stan_konta = Zmienne.stan_konta - bet;

                //wzor crash
                Random cyfra = new Random();
                double c = cyfra.Next(1, 32);

                Random elo = new Random();
                int e = elo.Next(1, (int)Math.Pow(2, (c - 1)));

                Random hash = new Random();
                int h = hash.Next(0, e - 1);

                double crash = 0.99 * e / (e - h);
                suma_crash += crash;

                //petla mnoznika
                double mnoznik;
                for (mnoznik = 1; mnoznik <= crash; mnoznik += 0.01)
                {

                    if (mnoznik >= 1 && mnoznik <= 1.29)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }
                    else if (mnoznik >= 1.29 && mnoznik <= 1.59)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                    }
                    else if (mnoznik >= 1.59 && mnoznik <= 2.09)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    else if (mnoznik >= 2.09)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                    }

                    //wygrana
                    if (Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Enter)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        double win = bet * mnoznik;
                        Console.WriteLine($"Opuściłeś rozgrywkę przy mnożniku {Math.Round(mnoznik, 2)}x i wygrałeś {Math.Round(win, 2)} monet(y)");
                        Console.WriteLine($"Gra zakończona mnożnikiem {Math.Round(crash, 2)}x");
                        Zmienne.stan_konta = Zmienne.stan_konta + win;
                        Console.WriteLine($"Twój zaaktualizowany stan konta wynosi {Math.Round(Zmienne.stan_konta, 2)} monet(y)");
                        break;
                    }

                    Console.WriteLine(Math.Round(mnoznik, 2) + "x");
                    Thread.Sleep(50);
                }

                //przegrana
                if (mnoznik > crash && Zmienne.stan_konta == 0)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("\nPrzegrałeś!");
                    Console.WriteLine($"Aktualnie posiadasz monet {Zmienne.stan_konta}");
                    Console.WriteLine("1. Graj w crash");
                    Console.WriteLine("2. Doładuj monety do konta");
                    Console.WriteLine("3. Wypłać monety z konta");
                    break;

                }
                else if (mnoznik > crash)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"Przegrałeś {bet} monet(y)\nCrash {Math.Round(crash, 2)}x\n");
                    Console.WriteLine($"Aktualnie masz {Math.Round(Zmienne.stan_konta, 2)} monet(y)");
                }

                //zliczanie gier i sredni mnoznik crash
                Console.WriteLine($"Gra nr {gra}");
                srednia = suma_crash / gra;
                Console.WriteLine($"Średni crash wynosi {Math.Round(srednia, 2)}");
                gra += 1;
            }
        }
        static void Main(string[] args)
        {
            wybor();
        }
        //koniec petli
    }
}//time thread petla czasowa
 //jezeli stan_konta = 0 przegrales i gra od nowa
 //laczny bilans w kasynie
 //petla w petli
 //funkcja odpowiada 1 grze i petle do gier