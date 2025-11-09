internal class Program
{
    static int PlayerWins = 0;
    static int ComputerWins = 0;

    private static void Main()
    {
        bool isPlaying = true;
        while (isPlaying)
        {
            PlayRound();
            Console.WriteLine($"Score: You {PlayerWins} - Computer {ComputerWins}");
            Console.WriteLine("Do you want to play again? (y/n)");
            string playAgain = Console.ReadLine();
            if (playAgain!.ToLower() != "y")
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
            Console.WriteLine("You win!");
            PlayerWins++;
        }
        else if (userHand == computerHand)
        {
            Console.WriteLine("It's a tie!");
        }
        else
        {
            Console.WriteLine("Computer wins!");
            ComputerWins++;
        }
    }

    static string ChooseHand()
    {

        Console.WriteLine("Choose A Hand");
        Console.WriteLine("1. Rock");
        Console.WriteLine("2. Paper");
        Console.WriteLine("3. Scissors");

        string userInput = Console.ReadLine();
        // convert the user number into rock paper or scissors respectively
        switch (userInput)
        {
            case "1":
                return "Rock";
            case "2":
                return "Paper";
            case "3":
                return "Scissors";
            default:
                Console.WriteLine("Invalid choice, please try again.");
                return ChooseHand();
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