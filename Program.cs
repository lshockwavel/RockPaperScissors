using System.Text.Json;

internal class Program
{
    static int PlayerWins = 0;
    static int ComputerWins = 0;

    private static void Main()
    {
        LoadGame();
        Console.WriteLine($"Current Score: You {PlayerWins} - Computer {ComputerWins}");
        bool isPlaying = true;
        while (isPlaying)
        {
            PlayRound();
            Console.WriteLine($"Score: You {PlayerWins} - Computer {ComputerWins}");
            Console.WriteLine("Do you want to play again? (y/n) (default[Enter] is y)");
            string playAgain = Console.ReadLine();
            SaveGame();

            if (playAgain!.ToLower() != "y" && !string.IsNullOrWhiteSpace(playAgain))
            {
                isPlaying = false;
            }

            Console.Clear();
        }
        // Console.WriteLine("Rock Paper Scissors");
        // string userHand = ChooseHand();

        // string computerHand = GetComputerHand();

        // Console.WriteLine($"You chose {userHand}");
        // Console.WriteLine($"Computer chose {computerHand}");

        // // determine the winner
        // if ((userHand == "Rock" && computerHand == "Scissors") ||
        //          (userHand == "Paper" && computerHand == "Rock") ||
        //          (userHand == "Scissors" && computerHand == "Paper"))
        // {
        //     Console.WriteLine("You win!");
        //     PlayerWins++;
        // }
        // else if (userHand == computerHand)
        // {
        //     Console.WriteLine("It's a tie!");
        // }
        // else
        // {
        //     Console.WriteLine("Computer wins!");
        //     ComputerWins++;
        // }

    }

    static void PlayRound()
    {
        Console.WriteLine("Rock Paper Scissors");
        string userHand = ChooseHand();

        string computerHand = GetComputerHand();

        Console.WriteLine($"You chose {userHand}");
        Console.WriteLine($"Computer chose {computerHand}");

        // determine the winner
        if ((userHand == "Rock" && computerHand == "Scissors") ||
                 (userHand == "Paper" && computerHand == "Rock") ||
                 (userHand == "Scissors" && computerHand == "Paper"))
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("You win!");
            PlayerWins++;
            Console.ResetColor();
        }
        else if (userHand == computerHand)
        {
            Console.WriteLine("It's a tie!");
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Computer wins!");
            ComputerWins++;
            Console.ResetColor();
        }
    }

    static string ChooseHand()
    {
        Console.WriteLine("Choose A Hand");
        Console.WriteLine("1. Rock (r)");
        Console.WriteLine("2. Paper (p)");
        Console.WriteLine("3. Scissors (s)");

        string userInput = Console.ReadLine();
        // convert the user number into rock paper or scissors respectively
        switch (userInput)
        {
            case "1":
            case "r":
                return "Rock";
            case "2":
            case "p":
                return "Paper";
            case "3":
            case "s":
                return "Scissors";
            default:
                Console.WriteLine("Invalid choice, please try again.");
                return ChooseHand();
        }
    }

    // inside Program class
    static void SaveGame()
    {

        SaveData save = new(PlayerWins, ComputerWins);
        string saveData = JsonSerializer.Serialize(save);
        File.WriteAllText("saveGame.json", saveData);
    }

    static void LoadGame()
    {

        if (!File.Exists("saveGame.json")) return;
        string jsonString = File.ReadAllText("saveGame.json");

        SaveData data = JsonSerializer.Deserialize<SaveData>(jsonString);
        if (data != null)
        {
            PlayerWins = data.PlayerWins;
            ComputerWins = data.ComputerWins;
        }

    }

    static string GetComputerHand()
    {
        // Your code here
        Random random = new();
        int computerChoice = random.Next(1, 4);

        switch (computerChoice)
        {
            case 1:
                return "Rock";
            case 2:
                return "Paper";
            case 3:
                return "Scissors";
            default:
                throw new Exception("Invalid computer choice");
        }
    }

}

internal class SaveData
{
    public int PlayerWins { get; set; }
    public int ComputerWins { get; set; }

    public SaveData(int playerWins, int computerWins)
    {

        PlayerWins = playerWins;
        ComputerWins = computerWins;

    }
}