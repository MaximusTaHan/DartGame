internal class PlayGame
{
    private string currentPlayer;
    bool won = false;

    internal void StartGame(List<Player> players)
    {
        while(won == false)
        {
            int[] darts = new int[3];
            int currentScore;
            foreach (Player player in players)
            {
                Console.Clear();
                currentPlayer = player.Name;

                currentScore = player.Calculatepoints();
                Console.WriteLine($"\n\nPlayer: {currentPlayer}, total Score: {currentScore}\n\n");
                if (player.Name == "Computer")
                   darts = GetComputerPoints(player, darts);
                else
                {
                    darts = PlayerTurn(player, darts);
                }

                currentScore = player.Calculatepoints();

                //Checks win con, or prints points gained this turn
                EndOfTurn(darts, currentScore);
            }
        }
    }

    private void EndOfTurn(int[] darts, int currentScore)
    {
        if (currentScore == 301)
        {
            won = true;
            ConcludeGame(currentPlayer);
            return;
        }
        else
        {
            Console.Clear();
            Console.WriteLine($"\n\nPlayer: {currentPlayer}, total Score: {currentScore}");


            Console.WriteLine("\nTurn recap: ");
            Console.WriteLine($"\nFirst throw: {darts[0]}");
            Console.WriteLine($"Second throw: {darts[1]}");
            Console.WriteLine($"Third throw: {darts[2]}");

            Console.WriteLine("\nPress any key to Change Player");
            Console.ReadKey(true);
        }
    }

    private void ConcludeGame(string currentPlayer)
    {
        Console.WriteLine($"\n~{currentPlayer} WINS!~\n");

        Console.WriteLine("Press any key to return to Game Menu");
        Console.ReadKey(true);
    }

    private int[] PlayerTurn(Player player, int[]darts)
    {
        for (int dart = 0; dart < 3; dart++)
        {
            Console.WriteLine($"Dart: {dart +1}");
            DartBoard dartBoard = new();
            darts[dart] = dartBoard.ThrowChoice();
        }

        player.AddTurn(darts[0], darts[1], darts[2]);
        return darts;
    }

    private int[] GetComputerPoints(Player player, int[] darts)
    {
        Random random = new Random();
        darts[0] = random.Next(0, 21);
        darts[1] = random.Next(0, 21);
        darts[2] = random.Next(0, 21);

        player.AddTurn(darts[0], darts[1], darts[2]);

        return darts;
    }
}