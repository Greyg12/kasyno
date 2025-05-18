using System;

public class Roulette : Game
{
    enum Colors
    {
        green,
        black,
        red,
    }

    struct Field
    {
        public Colors color;
        public int number;
    }

    private Field[] fields = new Field[37];

    public Roulette() : base("Roulette")
    {
        GenerateFields();
    }

    // Generate all roulette fields with color and number
    private void GenerateFields()
    {
        for (int i = 0; i < fields.Length; i++)
        {
            fields[i] = new Field();
            if (i == 0)
                fields[i].color = Colors.green;
            else if (i % 2 == 0)
                fields[i].color = Colors.black;
            else
                fields[i].color = Colors.red;
            fields[i].number = i;
        }
    }

    // Draw a random field
    private Field DrawField()
    {
        Random random = new Random();
        int drawn = random.Next(0, 37);
        return fields[drawn];
    }

    public override void Play(Player player)
    {
        Console.WriteLine("Choose bet type:");
        Console.WriteLine("1. Single number (0-36) (payout 35x)");
        Console.WriteLine("2. Color (red/black) (payout 2x)");
        Console.WriteLine("3. Range (1-12, 13-24, 25-36) (payout 3x)");
        Console.WriteLine("4. Range (1-18, 19-36) (payout 2x)");
        string betType = Console.ReadLine();

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

        if (betType == "1")
        {
            Console.Write("Which number (0-36) do you bet on? ");
            if (!int.TryParse(Console.ReadLine(), out int number) || number < 0 || number > 36)
            {
                Console.WriteLine("Invalid number.");
                player.AddBalance(bet);
                return;
            }
            Field field = DrawField();
            Console.WriteLine($"Drawn field: {field.number} {field.color}");
            if (number == field.number)
            {
                Console.WriteLine($"You win! {bet * 35}");
                player.AddBalance(bet * 35);
            }
            else
            {
                Console.WriteLine("You lose!");
            }
        }
        else if (betType == "2")
        {
            Console.Write("Choose color (1. red  2. black): ");
            string colorChoice = Console.ReadLine().Trim();
            string color = "";
            if (colorChoice == "1") color = "red";
            else if (colorChoice == "2") color = "black";
            else
            {
                Console.WriteLine("Invalid color choice.");
                player.AddBalance(bet);
                return;
            }
            Field field = DrawField();
            Console.WriteLine($"Drawn field: {field.number} {field.color}");
            bool win = (color == "red" && field.color == Colors.red) ||
                       (color == "black" && field.color == Colors.black);

            if (field.color == Colors.green)
            {
                Console.WriteLine("0 has no color. You lose!");
            }
            else if (win)
            {
                Console.WriteLine($"You win! {bet * 2}");
                player.AddBalance(bet * 2);
            }
            else
            {
                Console.WriteLine("You lose!");
            }
        }
        else if (betType == "3")
        {
            Console.Write("Choose range: 1. 1-12  2. 13-24  3. 25-36: ");
            string rangeChoice = Console.ReadLine().Trim();
            string range = "";
            if (rangeChoice == "1") range = "1-12";
            else if (rangeChoice == "2") range = "13-24";
            else if (rangeChoice == "3") range = "25-36";
            else
            {
                Console.WriteLine("Invalid range choice.");
                player.AddBalance(bet);
                return;
            }
            Field field = DrawField();
            Console.WriteLine($"Drawn field: {field.number} {field.color}");
            bool win = false;
            if (range == "1-12" && field.number >= 1 && field.number <= 12) win = true;
            else if (range == "13-24" && field.number >= 13 && field.number <= 24) win = true;
            else if (range == "25-36" && field.number >= 25 && field.number <= 36) win = true;

            if (field.number == 0)
            {
                Console.WriteLine("0 does not belong to any range. You lose!");
            }
            else if (win)
            {
                Console.WriteLine($"You win! {bet * 3}");
                player.AddBalance(bet * 3);
            }
            else
            {
                Console.WriteLine("You lose!");
            }
        }
        else if (betType == "4")
        {
            Console.Write("Choose range: 1. 1-18  2. 19-36: ");
            string rangeChoice = Console.ReadLine().Trim();
            string range = "";
            if (rangeChoice == "1") range = "1-18";
            else if (rangeChoice == "2") range = "19-36";
            else
            {
                Console.WriteLine("Invalid range choice.");
                player.AddBalance(bet);
                return;
            }
            Field field = DrawField();
            Console.WriteLine($"Drawn field: {field.number} {field.color}");
            bool win = false;
            if (range == "1-18" && field.number >= 1 && field.number <= 18) win = true;
            else if (range == "19-36" && field.number >= 19 && field.number <= 36) win = true;

            if (field.number == 0)
            {
                Console.WriteLine("0 does not belong to any range. You lose!");
            }
            else if (win)
            {
                Console.WriteLine($"You win! {bet * 2}");
                player.AddBalance(bet * 2);
            }
            else
            {
                Console.WriteLine("You lose!");
            }
        }
        else
        {
            Console.WriteLine("Invalid bet type.");
            player.AddBalance(bet);
        }
    }
}
