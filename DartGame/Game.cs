internal class GameMenu
{
    private List<Player> players = new List<Player>();
    
    internal void Menu()
    {
        bool closeApp = false;
        Console.WriteLine("\n\nWelcome to your Dart Game!\n");

        while (closeApp == false)
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
                    closeApp = true;
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

        bool found = false;
        ViewPlayers();

        Console.WriteLine("Which player would you like to Edit?");
        string input= Console.ReadLine();

        foreach(Player player in players)
        {
            if (player.Name == input)
            {
                Console.WriteLine($"\nChoose a new name for player: {player.Name}");
                player.Name = Console.ReadLine();
                found = true;

                Console.WriteLine($"You chose: {player.Name}");
            }
        }
        if(!found)
        {
            Console.WriteLine("\nCould not find a player with that name");
        }

    }

    private void RemoveName()
    {
        CheckIfZero();

        bool found = false;
        ViewPlayers();

        Console.WriteLine("Which player would you like to Remove?");
        string input = Console.ReadLine();

        foreach (Player player in players)
        {
            if (player.Name == input)
            {
                players.Remove(player);
                found = true;

                Console.WriteLine($"Removed player: {player.Name}");
                return;
            }
        }
        if (!found)
        {
            Console.WriteLine("\nCould not find a player with that name");
        }

    }

    private void ViewPlayers()
    {
        Console.WriteLine();

        for (int i = 0; i < players.Count; i++)
        {
            Console.WriteLine($"Player {i + 1}: {players[i].Name}");
        }
    }

    private void AddPlayers()
    {
        MaxPlayerCheck();
        Console.Clear();
        Console.WriteLine("Enter your Name (or type 1 to add a Computer)");
        Console.WriteLine("Type 0 to Return to Menu");
        string input = Console.ReadLine();

        if(input == "0")
        {
            Menu();
        }
        if(input == "1")
        {
            players.Add(new Player() { Name = "Computer"});
        }
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
            Menu();
        }
    }
    private void CheckIfZero()
    {
        if (players.Count == 0)
        {
            Console.WriteLine("\nPlease add a player before continuing");
            Menu();
        }
    }
}