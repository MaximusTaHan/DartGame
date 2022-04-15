internal class GameMenu
{
    private List<Player> players = new List<Player>();
    
    internal void Menu()
    {
        Console.WriteLine("\n\nWelcome to your Dart Game!\n");

        while (true)
        {
            Console.WriteLine("\nPLAYER MENU");
            Console.WriteLine("\nPress 0 to Exit the application");
            Console.WriteLine("Press 1 to Add Player");
            Console.WriteLine("Press 2 to View Players");
            Console.WriteLine("Press 3 to Change a Player Name");
            Console.WriteLine("Press 4 to Remove a Player");
            Console.WriteLine("Press 5 to Start the Game!");

            string menuInput = Console.ReadLine();

            while (string.IsNullOrEmpty(menuInput))
            {
                Console.WriteLine("\nInvalid Command. Please type a number from 0 to 5.\n");
                menuInput = Console.ReadLine();
            }

            switch (menuInput)
            {
                case "0":
                    Environment.Exit(0);
                    break;
                case "1":
                    AddPlayers();
                    break;
                case "2":
                    ViewPlayers();
                    break;
                case "3":
                    UpdateName();
                    break;
                case "4":
                    RemoveName();
                    break;
                case "5":
                    InitializeGameStart();
                    players.Clear();
                    break;
            }
        }

    }

    private void InitializeGameStart()
    {
        MaxPlayerCheck();
        CheckIfZero();

        PlayGame playGame = new();
        playGame.StartGame(players);
    }

    private void UpdateName()
    {
        CheckIfZero();

        ViewPlayers();

        Console.WriteLine("Which player would you like to Edit?");
        string input = Console.ReadLine();

        int i = players.FindIndex(player => player.Name == input);

        if(i == -1)
            Console.WriteLine("\nCould not find a player with that name");
        else
        {
            Console.WriteLine($"\nChoose a new name for player: {players[i].Name}");
            players[i].Name = Console.ReadLine();

            Console.WriteLine($"You chose: {players[i].Name}");
        }
    }

    private void RemoveName()
    {
        CheckIfZero();

        ViewPlayers();

        Console.WriteLine("Which player would you like to Remove?");
        string input = Console.ReadLine();

        int i = players.FindIndex(player => player.Name == input);

        if (i == -1)
            Console.WriteLine("\nCould not find a player with that name");
        else
        {
            players.Remove(players[i]);

            Console.WriteLine("\nPlayer was removed");
        }

    }

    private void ViewPlayers()
    {
        Console.WriteLine();

        for (int i = 0; i < players.Count; i++)
            Console.WriteLine($"Player {i + 1}: {players[i].Name}");
    }

    private void AddPlayers()
    {
        MaxPlayerCheck();
        Console.Clear();
        Console.WriteLine("Enter your Name (or type 1 to add a Computer)");
        Console.WriteLine("Type 0 to Return to Menu");
        string input = Console.ReadLine();

        if(input == "0")
            return;
        if(input == "1")
            players.Add(new Player() { Name = "Computer"});
        else
        {
            players.Add(new Player() { Name = input });
            Console.WriteLine($"Player with Name: {input}. Has been added to Players");
        }

    }

    private void MaxPlayerCheck()
    {
        if (players.Count >= 4)
        {
            Console.WriteLine("Too many players, max number of player allowed is 4");
            return;
        }
    }
    private void CheckIfZero()
    {
        if (players.Count == 0)
        {
            Console.WriteLine("\nPlease add a player before continuing");
            return;
        }
    }
}