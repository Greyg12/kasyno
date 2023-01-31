using System.Drawing;
using System.Reflection.Metadata.Ecma335;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;

namespace ConsoleApp12
{
    internal class Program
    {
        static string path = "kasyno.txt";
        public static void tworzenie_i_odczytywanie_pliku() {

            if (!File.Exists(path))
            {
                File.Create(path);
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine(Zmienne.stan_konta);
                }
            }
            else {
                using (StreamReader sr = new StreamReader(path))
                {
                    try
                    {
                        Zmienne.stan_konta = double.Parse(sr.ReadLine());
                    }
                    catch (System.ArgumentNullException)
                    {
                        Zmienne.stan_konta = 0;
                    }


                }
            }
        }


        static void zapisywanie_pliku()
        {
            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.WriteLine(Zmienne.stan_konta);
            }
        }


        static class Zmienne
        {
            public static double stan_konta;
            public static double bet;
            public static double mnoznik;
            public static double win;
        }
        static void wplaty()
        {
            double wplata;
            do
            {
                Console.WriteLine($"Ile monet chcesz wpłacić?\nAktualnie masz {Zmienne.stan_konta} monet(y)");
            } while (!double.TryParse(Console.ReadLine(), out wplata) || wplata < 0);
            Zmienne.stan_konta += wplata;
            zapisywanie_pliku();
            menu();
        }
        static void wyplaty()
        {
            double wyplata;
            do
            {
                Console.WriteLine($"Ile monet chcesz wpłacić?\nAktualnie masz {Zmienne.stan_konta} monet(y)");
            } while (!double.TryParse(Console.ReadLine(), out wyplata) || wyplata > Zmienne.stan_konta || wyplata < 0);
            Zmienne.stan_konta -= wyplata;
            zapisywanie_pliku();
            menu();
        }
        static void menu()
        {
            Console.WriteLine("Witaj na naszej stronie! :D");
            Console.WriteLine($"Aktualnie posiadasz {Zmienne.stan_konta} monet");
            Console.WriteLine("1. Graj w crash");
            Console.WriteLine("2. Graj w lotto");
            Console.WriteLine("3. Zagraj w ruletkę");
            Console.WriteLine("4. Zagraj w rzut monetą");
            Console.WriteLine("5. Doładuj monety do konta");
            Console.WriteLine("6. Wypłać monety z konta");
        }
        static void wybor()
        {
            zapisywanie_pliku();
            while (true)
            {
                Console.Write(">");
                if (int.TryParse(Console.ReadLine(), out int a))
                {
                    switch (a)
                    {
                        case 1:
                            crash();
                            break;
                        case 2:
                            lotto();
                            break;
                        case 3:
                            wlacz_ruletke();
                            break;
                        case 4:
                            MenuRzutMoneta();
                            break;
                        case 5:
                            wplaty();
                            break;
                        case 6:
                            wyplaty();
                            break;

                        default:
                            Console.WriteLine("Nie istnieje taki program");
                            break;
                    }
                }
            }
        }

        #region ruletka
        static void wlacz_ruletke()
        {
            Ruletka ruletka = new Ruletka();
            wybor_ruletka();
            menu_ruletka(ruletka);
        }
        enum kolory
        {
            zielony,
            czarny,
            czerwony,
        }

        struct Pole
        {
            public kolory kolor;
            public int cyfra;
        }

        struct Ruletka
        {
            public Pole[] pola = new Pole[37];

            public Ruletka()
            {
                GenerujPola();
            }
            void GenerujPola()
            {
                for (int i = 0; i < pola.Length; i++)
                {
                    pola[i] = new Pole();
                    if (i == 0)
                    {
                        pola[i].kolor = kolory.zielony;
                    }
                    else if (i % 2 == 0)
                    {
                        pola[i].kolor = kolory.czarny;
                    }
                    else pola[i].kolor = kolory.czerwony;
                    pola[i].cyfra = i;
                }
            }

            public Pole LosujPole()
            {
                Random random = new Random();
                int wylosowana = random.Next(0, 36);
                //Console.WriteLine($"Wylosowane pole to {pola[wylosowana].cyfra} {pola[wylosowana].kolor}");
                return pola[wylosowana];
            }

        }
        static void WybieranieCyfry(Pole pole)
        {
            obstawianie();
            int wybrana_cyfra;
            do
            {
                Console.Write($"Podaj liczbę od 0 do 36 ");
            } while (!int.TryParse(Console.ReadLine(), out wybrana_cyfra) || (wybrana_cyfra < 0) || (wybrana_cyfra > 36));
            if (wybrana_cyfra == pole.cyfra)
            {
                Zmienne.stan_konta += Zmienne.bet * 35;
                Console.WriteLine($"Wygrałeś {Zmienne.bet * 35} monet(y)\n");
            }
            else Console.WriteLine("Przegrałeś");
            Console.WriteLine($"Wylosowane pole to {pole.cyfra} {pole.kolor}\n");
            zapisywanie_pliku();
            wybor_ruletka();
        }
        static void WybierzCzerwone(Pole pole)
        {
            obstawianie();
            if (pole.kolor == kolory.czerwony)
            {
                Zmienne.stan_konta += Zmienne.bet * 2;
                Console.WriteLine($"Wygrałeś {Zmienne.bet * 2} monet(y)\n");
            }
            else Console.WriteLine("Przegrałeś");
            Console.WriteLine($"Wylosowane pole to {pole.cyfra} {pole.kolor}\n");
            zapisywanie_pliku();
            wybor_ruletka();
        }

        static void WybierzCzarne(Pole pole)
        {
            obstawianie();
            if (pole.kolor == kolory.czarny)
            {
                Zmienne.stan_konta += Zmienne.bet * 2;
                Console.WriteLine($"Wygrałeś {Zmienne.bet * 2} monet(y)\n");
            }
            else Console.WriteLine("Przegrałeś");
            Console.WriteLine($"Wylosowane pole to {pole.cyfra} {pole.kolor}\n");
            zapisywanie_pliku();
            wybor_ruletka();
        }

        static void od1do12(Pole pole)
            
        {

            obstawianie();

            if (pole.cyfra >= 1 && pole.cyfra <= 12)
                {
                Zmienne.stan_konta += Zmienne.bet * 4;
                Console.WriteLine($"Wygrałeś {Zmienne.bet*4} monet(y)\n");
                }
                else
                {

                    Console.WriteLine("Przegrałeś\n");
                }

                Console.WriteLine($"Wylosowane pole to {pole.cyfra} {pole.kolor}\n");
            zapisywanie_pliku();
            wybor_ruletka();
        }
        static void od13do24(Pole pole)
        {
            obstawianie();
            if (pole.cyfra >= 13 && pole.cyfra <= 24)
            {
                Zmienne.stan_konta += Zmienne.bet * 4;
                Console.WriteLine($"Wygrałeś {Zmienne.bet * 4} monet(y)\n");
            }
            else Console.WriteLine("Przegrałeś");
            Console.WriteLine($"Wylosowane pole to {pole.cyfra} {pole.kolor}\n");
            zapisywanie_pliku();
            wybor_ruletka();
        }
        static void od25do36(Pole pole)
        {
            obstawianie();
            if (pole.cyfra >= 25 && pole.cyfra <= 36)
            {
                Zmienne.stan_konta += Zmienne.bet * 4;
                Console.WriteLine($"Wygrałeś {Zmienne.bet * 4} monet(y)\n");
            }
            else Console.WriteLine("Przegrałeś");
            Console.WriteLine($"Wylosowane pole to {pole.cyfra} {pole.kolor}\n");
            zapisywanie_pliku();
            wybor_ruletka();
        }
        static void od1do18(Pole pole)
        {
            obstawianie();
            if (pole.cyfra >= 1 && pole.cyfra <= 18)
            {
                Zmienne.stan_konta += Zmienne.bet * 2;
                Console.WriteLine($"Wygrałeś {Zmienne.bet * 2} monet(y)\n");
            }
            else Console.WriteLine("Przegrałeś");
            Console.WriteLine($"Wylosowane pole to {pole.cyfra} {pole.kolor}\n");
            zapisywanie_pliku();
            wybor_ruletka();
        }
        static void od19do36(Pole pole)
        {
            obstawianie();
            if (pole.cyfra >= 13 && pole.cyfra <= 24)
            {
                Zmienne.stan_konta += Zmienne.bet * 2;
                Console.WriteLine($"Wygrałeś {Zmienne.bet * 2} monet(y)\n");
            }
            else Console.WriteLine("Przegrałeś");
            Console.WriteLine($"Wylosowane pole to {pole.cyfra} {pole.kolor}\n");
            zapisywanie_pliku();
            wybor_ruletka();
        }
        static void wybor_ruletka()
        {
            Console.WriteLine($"\nStan konta - {Zmienne.stan_konta}\n1. Wybór cyfry od 0 do 36\n2. Wybór czarnych pól\n3. Wybór czerwonych pól\n4. Wybór zakresu od 1 do 12\n5. Wybór zakresu od 13 do 24\n6. Wybór zakresu od 25 do 36\n7. Wybór zakresu od 1 do 18\n8 .Wybór zakresu od 19 do 36\n0. Wyjdź");
        }
        static void menu_ruletka(Ruletka ruletka)
        {
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int a))
                {
                    switch (a)
                    {
                        case 1:
                            WybieranieCyfry(ruletka.LosujPole());
                            break;
                        case 2:
                            WybierzCzarne(ruletka.LosujPole());
                            break;
                        case 3:
                            WybierzCzerwone(ruletka.LosujPole());
                            break;
                        case 4:
                            od1do12(ruletka.LosujPole());
                            break;
                        case 5:
                            od13do24(ruletka.LosujPole());
                            break;
                        case 6:
                            od25do36(ruletka.LosujPole());
                            break;
                        case 7:
                            od1do18(ruletka.LosujPole());
                            break;
                        case 8:
                            od19do36(ruletka.LosujPole());
                            break;
                        case 0:
                            menu();
                            wybor();
                            break;


                    }
                }
            }
        }
        #endregion
        #region lotto
        static void lotto()
        {

            Console.WriteLine("1. Graj w lotto");
            Console.WriteLine("2. Opuść");
            double bet = 3;

            if (int.TryParse(Console.ReadLine(), out int graj))
                switch (graj)
                {
                    case 1:
                        Zmienne.stan_konta -= bet;
                        zapisywanie_pliku();
                        break;
                    default:
                        menu();
                        wybor();
                        break;
                }

            HashSet<int> wygrywajaca_tabela = new HashSet<int>();
            Random losowe_liczby = new Random();
            int wylosowana_liczba;
            while (wygrywajaca_tabela.Count < 6)
            {
                wylosowana_liczba = losowe_liczby.Next(1, 49);
                wygrywajaca_tabela.Add(wylosowana_liczba);

            }

            //wpisane przez uzytkownika cyfry
            HashSet<int> wybrana_tabela = new HashSet<int>();
            int cyfra;
            int i = 1;

            while (wybrana_tabela.Count < 6)
            {
                do
                {
                    Console.Write($"Cyfra numer {i}: ");
                } while (!int.TryParse(Console.ReadLine(), out cyfra) || cyfra < 1 || cyfra > 49 || wybrana_tabela.Contains(cyfra));
                //cyfra = int.Parse(Console.ReadLine());
                i++;
                wybrana_tabela.Add(cyfra);
            }
            Console.WriteLine("Wygrywające liczby to: ");
            foreach (int liczba in wygrywajaca_tabela)
            {
                Console.Write($"{liczba} ");
                Thread.Sleep(500);
            }
            Console.WriteLine();

            //sprawdzenie wygranej
            int z = 0;
            foreach (int liczba in wybrana_tabela)
            {
                if (wygrywajaca_tabela.Contains(liczba))
                {
                    z++;
                }
            }
            int mnoznik=1;

            if (z == 3)
            {
                mnoznik = 3;
            }
            else if (z == 4)
            {
                mnoznik = 40;
            }
            else if (z == 5)
            {
                mnoznik = 1500;
            }
            else if (z == 6)
            {
                mnoznik = 1000000;
            }
            if (z < 3)
            {
                Console.WriteLine("Przegrałeś, spróbuj szczęścia ponownie");
            }
            else
            {
                double win = bet * mnoznik;
                Zmienne.stan_konta = Zmienne.stan_konta + win;
                Console.WriteLine($"Trafiłeś {z} cyfr(y) i wygrałeś {win} monet(y)");
            }
            zapisywanie_pliku();
            Console.WriteLine();
            menu();
        }
        #endregion

        static void crash()
        {
            double srednia;
            double suma_crash = 0;
            int gra = 1;

            for (; ; )
            {

                do
                {

                    //obstawianie
                    do
                    {
                        Console.WriteLine("\nKliknij 0, aby wyjść");
                        Console.WriteLine($"Aktualnie masz {Zmienne.stan_konta} monet");
                        Console.WriteLine("Ile monet chcesz obstawić?");
                    } while (!double.TryParse(Console.ReadLine(), out Zmienne.bet) || Zmienne.bet < 0);

                    if (Zmienne.bet > Zmienne.stan_konta)
                    {
                        Console.WriteLine("Nie masz tylu monet na koncie!");
                    }
                } while (Zmienne.bet > Zmienne.stan_konta);
                if (Zmienne.bet == 0)
                {
                    menu();
                    break;
                }
                Zmienne.stan_konta = Zmienne.stan_konta - Zmienne.bet;

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
                for (Zmienne.mnoznik = 1; Zmienne.mnoznik <= crash; Zmienne.mnoznik += 0.01)
                {

                    if (Zmienne.mnoznik >= 1 && Zmienne.mnoznik <= 1.29)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }
                    else if (Zmienne.mnoznik >= 1.29 && Zmienne.mnoznik <= 1.59)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                    }
                    else if (Zmienne.mnoznik >= 1.59 && Zmienne.mnoznik <= 2.09)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    else if (Zmienne.mnoznik >= 2.09)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                    }

                    //wygrana
                    if (Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Enter)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Zmienne.win = Zmienne.bet * Zmienne.mnoznik;
                        Console.WriteLine($"Opuściłeś rozgrywkę przy mnożniku {Math.Round(Zmienne.mnoznik, 2)}x i wygrałeś {Math.Round(Zmienne.win, 2)} monet(y)");
                        Console.WriteLine($"Gra zakończona mnożnikiem {Math.Round(crash, 2)}x");
                        Zmienne.stan_konta = Zmienne.stan_konta + Zmienne.win;
                        Console.WriteLine($"Twój zaaktualizowany stan konta wynosi {Math.Round(Zmienne.stan_konta, 2)} monet(y)");
                        break;
                    }

                    Console.WriteLine(Math.Round(Zmienne.mnoznik, 2) + "x");
                    Thread.Sleep(50);
                }

                //przegrana
                if (Zmienne.mnoznik > crash && Zmienne.stan_konta == 0)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("\nPrzegrałeś!");
                    Console.WriteLine($"Aktualnie posiadasz monet {Zmienne.stan_konta}");
                    menu();
                    break;

                }
                else if (Zmienne.mnoznik > crash)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"Przegrałeś {Zmienne.bet} monet(y)\nCrash {Math.Round(crash, 2)}x\n");
                    Console.WriteLine($"Aktualnie masz {Math.Round(Zmienne.stan_konta, 2)} monet(y)");
                }

                //zliczanie gier i sredni mnoznik crash
                Console.WriteLine($"Gra nr {gra}");
                srednia = suma_crash / gra;
                Console.WriteLine($"Średni crash wynosi {Math.Round(srednia, 2)}");
                gra += 1;
                zapisywanie_pliku();
            }
        }
        static void obstawianie()
        {
            do
            {
                Console.WriteLine($"Aktualnie masz {Zmienne.stan_konta} monet");
                Console.WriteLine("Ile monet chcesz obstawić?");
            } while (!double.TryParse(Console.ReadLine(), out Zmienne.bet) || Zmienne.bet < 0 || Zmienne.bet > Zmienne.stan_konta);
            if (Zmienne.bet > Zmienne.stan_konta)
            {
                Console.WriteLine("Nie masz tylu monet na koncie!");
            }
            Zmienne.stan_konta = Zmienne.stan_konta - Zmienne.bet;
        }

        #region OrzełiReszka
        public static void MenuRzutMoneta()
        {
            {
                
                Console.WriteLine("Orzeł czy reszka?\n1. Orzeł\n2. Reszka\n3. Wyjdź");
                if (int.TryParse(Console.ReadLine(), out int a))
                {
                    switch (a)
                    {
                        case 1:
                            orzelReszka();
                            break;
                        case 2:
                            orzelReszka();
                            break;
                        case 3:
                            menu();
                            wybor();
                            break;
                        default:
                            Console.WriteLine("Błędna wartość");
                            break;
                    }
                }
            }
        }
        static void orzelReszka()
        {
            for (; ; )
            {
                do

                {
                    do
                    {
                        Console.WriteLine($"Aktualnie masz {Zmienne.stan_konta} monet\nIle monet chcesz obstawić?\nKliknij 0, aby wyjść");
                    } while (!double.TryParse(Console.ReadLine(), out Zmienne.bet) || Zmienne.bet < 0);

                    if (Zmienne.bet > Zmienne.stan_konta)
                    {
                        Console.WriteLine("Nie masz tylu monet na koncie!");
                    }
                } while (Zmienne.bet > Zmienne.stan_konta);
                if (Zmienne.bet == 0)
                {
                    menu();
                    break;
                }
                Zmienne.stan_konta = Zmienne.stan_konta - Zmienne.bet;

                Random rand = new Random();
                int orzel = rand.Next();
                if (orzel % 2 == 0)
                {
                    Zmienne.stan_konta = Zmienne.stan_konta + (2 * Zmienne.bet);
                    Console.WriteLine($"\nWygrałeś\nAktualnie masz {Zmienne.stan_konta} monet");
                }
                else Console.WriteLine($"\nPrzegrałeś\nAktualnie masz {Zmienne.stan_konta} monet");
                zapisywanie_pliku();
                MenuRzutMoneta();
            }
        }

#endregion
    static void Main(string[] args)
        {
            tworzenie_i_odczytywanie_pliku();
            menu();
            wybor();
        }
    }
}