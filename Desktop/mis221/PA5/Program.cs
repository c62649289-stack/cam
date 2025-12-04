//main
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;


string userChoice = GetMenuChoice();

int[] gil = new int[1];
int[] userBet = new int[1];
int[] blackjackTotal = new int[1];

int[] computerRoll new int[1];
int[] computerTotals = new int[1];



gil[0] = 50; 

while (userChoice != "3")
{
    RouteEm(userChoice, gil, userBet, computerRoll);
    userChoice = GetMenuChoice();
}
SayGoodbye();
System.Console.WriteLine();

//end

    static void SayGoodbye ()

{
    System.Console.WriteLine("Thank you Goodbye");
}

static void Pause()
    {
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey(); //forces the program to "pause" enter the user selects any key
        Console.Clear();
    }

// static void PlaySpinTheWheel()
// {
//     System.Console.WriteLine("Spun the Wheel");
// }

// static void PlayBlackJack()
// {
//     System.Console.WriteLine("Played Blackjack");
// }
//     static void Pause()
//     {
//         Console.WriteLine("Press any key to continue...");
//         Console.ReadKey(); //forces the program to "pause" enter the user selects any key
//         Console.Clear();
//     }


static string GetMenuChoice()
{
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.Yellow;
    System.Console.WriteLine(@$"
+-+-+-+-+-+-+-+ +-+-+ +-+-+-+-+-+-+ +-+-+-+-+-+ +-+-+-+-+-+-+-+ +-+-+-+-+-+
|W|e|l|c|o|m|e| |t|o| |J|e|f|f|'|s| |J|o|l|l|y| |J|a|c|k|p|o|t| |L|a|n|d|!|
+-+-+-+-+-+-+-+ +-+-+ +-+-+-+-+-+-+ +-+-+-+-+-+ +-+-+-+-+-+-+-+ +-+-+-+-+-+");
    Console.ForegroundColor = ConsoleColor.Blue;
    System.Console.WriteLine("");
    System.Console.WriteLine("Please select a menu option (1-3)");
    System.Console.WriteLine("");
    System.Console.WriteLine("1. PlaySpinTheWheel");
    System.Console.WriteLine("2. PlayBlackJack");
    System.Console.WriteLine("3. Exit");
    return Console.ReadLine();
}


    static void RouteEm(string userChoice, int[] gil, int [] userBet, int[] computerRoll)
    {
   
        switch (userChoice)
        {
            case "1":
               
                PlaySpinTheWheel(gil);
                break;
            case "2":
            
                PlayBlackJack(gil, userBet, computerRoll);
                break;
            default:
                System.Console.WriteLine("Invalid menu choice...try again");
                break;
        }
        Pause();
    }




static void PlaySpinTheWheel(int[] gil)
{


    // static void Pause()
    // {
    //     Console.WriteLine("Press any key to continue...");
    //     Console.ReadKey(); //forces the program to "pause" enter the user selects any key
    //     Console.Clear();
    // }

    System.Console.Clear();

    System.Console.WriteLine("Welcome to Spin the wheel! Choose an option");
    System.Console.WriteLine("1. Spin the Wheel! (costs 10 gil)");
    System.Console.WriteLine("2. Exit Spin the Wheel");

    string userKey = Console.ReadLine();

    if (userKey == "1")
    {


        {

        }

        int cost = 10;
        if (gil[0] < cost)
        {
            System.Console.WriteLine("Not enough Gil to Play this game");
            return;
        }

        gil[0] -= cost;
        System.Console.WriteLine($"You currently have {gil[0]} gil");
        Random rnd = new Random();
        int winningNumber = rnd.Next(1, 6);

        if (winningNumber == 1)
        {
            System.Console.WriteLine("Congrats you have earned 50 gil");
            gil[0] += 50;
            System.Console.WriteLine($"You now have {gil[0]} gil!");
            GameEnder(gil);
            Pause();
            PlaySpinTheWheel(gil);
        }
        else if (winningNumber == 2)
        {
            int coinFlip = rnd.Next(1, 2);
            if (coinFlip == 1)
            {
                System.Console.WriteLine("You have earned 100 gills!");
                gil[0] += 100;
                System.Console.WriteLine($"You now have {gil[0]} gil!");
                Pause();
                GameEnder(gil);
                PlaySpinTheWheel(gil);


            }
            else
            {
                System.Console.WriteLine("You have lost 100 gills!!");
                gil[0] -= 100;
                System.Console.WriteLine($"You now have {gil[0]} gil!");
                Pause();
                GameEnder(gil);
                PlaySpinTheWheel(gil);


            }
        }
        else if (winningNumber == 3
        {
            System.Console.WriteLine("oops you lost 25 gil");
            gil[0] -= 25;
            System.Console.WriteLine($"You now have {gil[0]} gil!");
            Pause();
            GameEnder(gil);
            PlaySpinTheWheel(gil);

        }
        else if (winningNumber == 4)
        {
            System.Console.WriteLine("Lose all gils! Game Over");
            gil[0] = 0;
            System.Console.WriteLine($"You now have {gil[0]} gil!");
            GameEnder(gil);
            System.Console.WriteLine("Returning to main menu...");
            Pause();
        }
        else if (winningNumber == 5)
        {
            System.Console.WriteLine("Okay so nothing happened, Try again");
            System.Console.WriteLine($"You have {gil[0]} gil!");
            Pause();
            PlaySpinTheWheel(gil);



        [{}


        // System.Console.WriteLine("Guess a number between 1 and 5: ");
        // int guess;
        // bool valid = int.TryParse(Console.ReadLine(), out guess);

        //     if (!valid || guess < 1 || guess > 5)
        //     {
        // System.Console.WriteLine("Invalid You Lose");
        // return;

    }
    else if (userKey == "2")
    {
        GetMenuChoice();
    }
    else
    {
        System.Console.WriteLine("This input is invalid, try again");
        PlaySpinTheWheel(gil);
    }
}



static void PlayBlackJack(int[] gil, int[] userBet,int[] computerRoll)

    
{
    Console.Clear();
    Console.WriteLine("Welcome to Blackjack!");
    Console.WriteLine($"You currently have {gil[0]} gil.\n");

    userBet[0] = BetIsValid(gil);

    gil[0] -= userBet[0];

    System.Console.WriteLine($"You bet {userBet[0]} gil. You now have {gil[0]} gil left.\n");
    Pause();

    Random rnd = new Random();
    int total = 0;

    int roll1 = DieRoll(rnd)
    int roll2 = DieRoll(rnd);
    total = roll1 + roll2;
    System.Console.WriteLine($"First roll: {roll1} and {roll2}.");
    System.Console.WriteLine($"Your total is currently {total}");
    bool bust = false;
    while (true)
    {

        if (total > 21)
        {
            Console.WriteLine("Busted! You went over 21. You lose this round.");
            bust = true;
            break;
        }

        System.Console.WriteLine("");
        Console.WriteLine("Choose an option:");
        Console.WriteLine("1. Roll again");
        Console.WriteLine("2. Stop rolling");
        string choice = Console.ReadLine();

        if (choice == "1")
        {
            int newRoll = DieRoll(rnd);
            total += newRoll;
            Console.WriteLine($"You rolled a {newRoll}. Your total is now {total}.");
        }
        else if (choice == "2")
        {
            Console.WriteLine($"You stopped rolling with a total of {total}.");
            break;
        }
        else
        {
            Console.WriteLine("Invalid input. Please type 1 or 2.");
        }
    }

    if (bust)
    {
        Console.WriteLine("The computer does not roll because you busted.");
        Pause();
        AskReplay(gil, userBet, computerRoll);
        return;
    }

    int computerTotal = ComputerBlackjack(rnd);

    System.Console.WriteLine("");
    Console.WriteLine($"Computer total: {computerTotal}");

    if (computerTotal > 21)
    {
        Console.WriteLine("Computer busted! You win!");
        gil[0] += userBet[0] * 2;
        GameEnder(gil);
    
    }


    else if (total == 21 && computerTotal != 21)
    {
        System.Console.WriteLine("You win 2x your bet!");
        gil[0] += userBet[0] * 2;
        GameEnder(gil);
    }


    else if (total > computerTotal
    {
        Console.WriteLine("Congrats! You win!");

        gil[0] += userBet[0] * 2;
        GameEnder(gil);

    }


    else if (total == computerTotal)
    {
        Console.WriteLine("Computer wins the tie. You lose your bet.");
        GameEnder(gil);

    }


    else
    {
        Console.WriteLine("Computer wins this round.");
    }

    System.Console.WriteLine();
    Console.WriteLine($"You now have {gil[0]} gil.");
    Pause();

    AskReplay(gil, userBet, computerRoll);
}


static int BetIsValid(int[] gil
{
    int bet = 0;
    bool valid = false;

    while (!valid)
    {
        Console.Write("Enter your bet amount: ");
        string input = Console.ReadLine();

        if (input == "")
        {
            Console.WriteLine("Please enter a number.");
            continue;
        }

        bet = int.Parse(input);


        if (bet > 0 && bet <= gil[0])
        {
            valid = true; 
        }
        else
        {
            Console.WriteLine($"Invalid bet. Enter an amount of gil that you have");
            System.Console.WriteLine($"You currently have {gil[0]}");
        }
    }

    return bet;
}


static int DieRoll(Random rnd)
{
    int diceRoll = rnd.Next(0, 10);
    if (diceRoll == 0)
{
    return 10;
}
else
{
    return diceRoll;
}
}





static int ComputerBlackjack(Random rnd)
{
    int total = 0;

    System.Console.WriteLine("");
    Console.WriteLine("Computer's turn...");

    while (total < 17)
    {
        int roll = DieRoll(rnd);
        total += roll;
        Console.WriteLine($"Computer rolled a {roll}. Total is now {total}.");
    }



    if (total > 21)
    {
        Console.WriteLine("Computer busted!");
    }
    else
    {
        Console.WriteLine($"Computer stands at {total}.");
    }

    return total;
}




static void AskReplay(int[] gil, int[] userBet, int[] computerRoll)
{
    System.Console.WriteLine("");

    Console.WriteLine("Choose an option below:");
    Console.WriteLine("1. Play Blackjack again");
    Console.WriteLine("2. Return to main menu");

    string input = Console.ReadLine();



    if (input == "1")
    {
        PlayBlackJack(gil, userBet, computerRoll);
    }
    else
    {
        Console.WriteLine("Returning to main menu...");
    }
}  







static void GameEnder(int[] gil)
{
    if (gil[0] <= 0)
    {
        System.Console.WriteLine("");
        Console.WriteLine("You have lost all your gil!");
        Console.WriteLine("You lose! Game over.");
        Pause();
        Environment.Exit(0); // exits
    }
    else if (gil[0] >= 300)
    {
        Console.WriteLine("Congratulations! You have reached 300 gil!");
        Console.WriteLine("You win! Game over.");
        Pause();
        Environment.Exit(0); 
    }
}

//EXTRAS

// 1. environment.Exit function for winning
// 2. Custom text colors
// 3. Creative design
//end main
