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
        int points = Random.Shared.Next(0, 21);
        Console.WriteLine($"Dart points: {points}");
        return points;
    }

    private int AimedThrow()
    {
        Console.WriteLine("Enter what point you are aiming for: ");

        string input = Console.ReadLine();

        int result;
        int points = 0;

        result = ValidateInput(input);
        var i = Array.IndexOf(dartBoard, result);

        int chance = Random.Shared.Next(0, 101);

        Console.WriteLine("Chance: " + chance);

        if(chance >= 0 && chance <= 59)
            points = dartBoard[i];

        else if(chance >= 60 && chance <= 89)
            points = OffByOne(result);

        else if(chance >= 90 && chance <= 94)
            points = Random.Shared.Next(0,21);


        else if(chance >= 95 && chance <= 100)
            points = 0;

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
        //get index that holds the inputted points
        var i = Array.IndexOf(dartBoard, result);

        if (i == -1)
            return 0;

        //Shared recommended use of Random if you dont need control over seed
        if (Random.Shared.Next(0, 2) == 0)
            // Return ternary: if 1 is smaller than 0 return Last index, else return index -1
            return i - 1 < 0 ? dartBoard[^1] : dartBoard[i - 1];

        else
            return i + 1 > 19 ? dartBoard[0] : dartBoard[i + 1];
    }
}