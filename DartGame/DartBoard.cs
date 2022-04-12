internal class DartBoard
{
    private int[] dartBoard = new int[20]
        {20,1,18,4,13,6,10,15,2,17,3,19,7,16,8,11,14,9,12,5};
    internal int ThrowChoice()
    {
        int points = 0;

        Console.WriteLine("\nType 0 to Skip throw");
        Console.WriteLine("Type 1 for an Aimed throw");
        Console.WriteLine("Type 2 for a Random throw");

        string input = Console.ReadLine();

        while(!(input == "1" || input == "2" || input == "0"))
        {
            Console.WriteLine("Please enter 1 or 2");
            input = Console.ReadLine();
        }
        switch (input)
        {
            case "1":
                points = AimedThrow();
                break;
            case "2":
                points = RandomThrow();
                break;
        }
        return points;
    }

    private int RandomThrow()
    {
        int points = 0;
        Random random = new Random();
        points = random.Next(0, 21);
        Console.WriteLine($"Dart points: {points}");
        return points;
    }

    private int AimedThrow()
    {
        Console.WriteLine("Enter what point you are aiming for: ");

        string input = Console.ReadLine();

        int result;
        int chance = 0;
        int points = 0;

        result = ValidateInput(input);

        Random random = new Random();
        chance = random.Next(0, 101);

        Console.WriteLine("Chance: " + chance);
        if(chance >= 0 && chance <= 59)
        {
            for (int i = 0; i < 20; i++)
            {
                if (result == dartBoard[i])
                {
                    points = dartBoard[i];
                }
            }
        }

        else if(chance >= 60 && chance <= 89)
        {
            points = OffByOne(result);
        }

        else if(chance >= 90 && chance <= 94)
        {
            points = random.Next(0,21);
        }

        else if(chance >= 95 && chance <= 100)
        {
            points = 0;
        }

        Console.WriteLine("Dart points: " + points);
        return points;
    }

    private int ValidateInput(string? input)
    {
        int result;
        while (!int.TryParse(input, out result))
        {

            Console.WriteLine("Please enter a valid number");
            input = Console.ReadLine();
        }
        if (result < 0 || result > 20)
        {
            input = "";
            result = ValidateInput(input);
        }
        return result;
    }

    private int OffByOne(int result)
    {
        int points = 0;
        Random random = new Random();
        random.Next(0, 2);
        if (random.Next(0, 2) == 0)
        {
            for (int i = 0; i < 20; i++)
            {
                if (result == dartBoard[i])
                {
                    if (i - 1 < 0)
                    {
                        points = dartBoard[dartBoard.Length - 1];
                    }
                    else
                    {
                        points = dartBoard[i - 1];
                    }
                }
            }
        }
        else
        {
            for (int i = 0; i < 20; i++)
            {
                if (result == dartBoard[i])
                {
                    if (i + 1 > 19)
                    {
                        points = dartBoard[0];
                    }
                    else
                    {
                        points = dartBoard[i + 1];
                    }
                }
            }
        }

        return points;
    }
}