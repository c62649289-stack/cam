using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.IO.Compression;


string userChoice = GetMenuChoice();

int[] gil = new int[1];
int[] userBet = new int[1];
int[] blackjackTotal = new int[1];

int[] computerRoll = new int[1];
int[] computerTotals = new int[1];


gil[0] = 50;

while (userChoice != "3")
{
    RouteEm(userChoice, gil, userBet, computerRoll);
    userChoice = GetMenuChoice();
}
SayGoodbye();
System.Console.WriteLine();

static void SayGoodbye()
{
    System.Console.WriteLine("Thank you Goodbye");
}

static void Pause()
{
    System.Console.WriteLine("Press any key to continue");
    Console.ReadKey();
    Console.Clear();
}
//static void PlaySpinTheWheel()
// {
//     System.Console.WriteLine("Spun the wheel");
// }

// static void PlayBlackJack()
// {
//     System.Console.WriteLine("Played BlackJack");
// }
// static void Pause()
// {
//     System.Console.WriteLine("Press any key to continue");
//     Console.ReadKey();
//     Console.Clear();
// }


static string GetMenuChoice()
{

    Console.Clear();
    Console.ForegroundColor = ConsoleColor.DarkRed;
    System.Console.WriteLine(@$"
. . .     |                            |                   
| | |,---.|    ,---.,---.,-.-.,---.    |--- ,---.          
| | ||---'|    |    |   || | ||---'    |    |   |          
`-'-'`---'`---'`---'`---'` ' '`---'    `---'`---'          
                                                           
                                                           
    |     ,---.,---.             |     |    |              
    |,---.|__. |__. ,---.        |,---.|    |    ,   .     
    ||---'|    |    `---.        ||   ||    |    |   |     
`---'`---'`    `    `---'    `---'`---'`---'`---'`---|     
                                                 `---'     
                                                           
    |          |              |        |                  |
    |,---.,---.|__/ ,---.,---.|---     |    ,---.,---.,---|
    |,---||    |  \ |   ||   ||        |    ,---||   ||   |
`---'`---^`---'`   `|---'`---'`---'    `---'`---^`   '`---'
                    |                                      
");
    Console.ForegroundColor = ConsoleColor.DarkYellow;
    System.Console.WriteLine("");
    System.Console.WriteLine("Please select a menu option (1-3)");
    System.Console.WriteLine("");
    System.Console.WriteLine("1. PlaySpinTheWheel");
    System.Console.WriteLine("2. PlayBlackJack");
    System.Console.WriteLine("3. Exit");
    return Console.ReadLine();
}


static void RouteEm(string userChoice, int[] gil, int[] userBet, int[] computerRoll)
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
            System.Console.WriteLine("Invalid choice try again");
            break;
    }
    Pause();
}

    
static void PlaySpinTheWheel(int[] gil)
{

    // static void Pause()
    // {
    //     System.Console.WriteLine("Press any key to continue");
    //     Console.ReadKey();
    //     Console.Clear();
    // }

    System.Console.Clear();

    System.Console.WriteLine("Welcome to Spin the Wheel! Choose a option");
    System.Console.WriteLine("1. Spin the Wheel (costs 10 gil)");
    System.Console.WriteLine("2. Exit Spin the Wheel");

    string userKey = Console.ReadLine();

if (userKey == "1")
{

    {

    }
    int cost = 10;
    if (gil[0] < cost)
    {
        System.Console.WriteLine("Not enough Gil to play");
        return;
    }
    gil[0] -= cost;
    System.Console.WriteLine($"You currently have {gil[0]} gil");
    Random rnd = new Random();
    int winningNumber = rnd.Next(1, 6);

    if (winningNumber == 1)
    {
        System.Console.WriteLine("Congrats you have earned 50 gil.");
        gil[0] += 50;
        System.Console.WriteLine($"You now have {gil[0]} gil.");
        EndGame(gil);
        Pause();
        PlaySpinTheWheel(gil);
    }
    else if (winningNumber == 2)
    {
        int coinFlip = rnd.Next(1, 2);

        if (coinFlip == 1)
        {
            System.Console.WriteLine("You have earned 100 gils");
            gil[0] += 100;
            System.Console.WriteLine($"You now have {gil[0]} gil");
            Pause();
            EndGame(gil);
            PlaySpinTheWheel(gil);



        }
        else
        {
            System.Console.WriteLine("You have now lost 100 gils!");
            gil[0] -= 100;
            System.Console.WriteLine($"You now have {gil[0]} gil!");
            Pause();
            EndGame(gil);
            PlaySpinTheWheel(gil);

        }
    }
    else if (winningNumber == 3)
    {
            System.Console.WriteLine("Ooouu sorry you lost 25 gil");
            gil[0] -= 25;
            System.Console.WriteLine($"You now have {gil[0]} gil");
            Pause();
            EndGame(gil);
            PlaySpinTheWheel(gil);

    }
        else if (winningNumber == 4)
    {
            System.Console.WriteLine("Dang you lost all your gil. Game Over");
            gil[0] = 0;
            System.Console.WriteLine($"You now have {gil[0]} gil.");
            EndGame(gil);
            System.Console.WriteLine("Returning to main menu..");
            Pause();
    }
        else if (winningNumber == 5)
    {
            System.Console.WriteLine("Okay so nothing happened, Try again I guess");
            System.Console.WriteLine($"You now have {gil[0]} gil");
            Pause();
            PlaySpinTheWheel(gil);



    }

    }
    else if (userKey == "2")
    {
        GetMenuChoice();

    }
    else
    {
        System.Console.WriteLine("This input is invalid");
        PlaySpinTheWheel(gil);
    }
}

static void PlayBlackJack(int[] gil, int[] userBet, int[] computerRoll)
{
    System.Console.Clear();
    System.Console.WriteLine("Welcome to BlackJack!");
    System.Console.WriteLine($"You currently have {gil[0]} gil");

    userBet[0] = BetIsValid(gil);

    gil[0] -= userBet[0];

    System.Console.WriteLine($"You bet{userBet[0]} gil. You have {gil[0]} gil left");
    Pause();
    Random rnd = new Random();
    int total = 0;

    int roll1 = DiceRoll(rnd);
    int roll2 = DiceRoll(rnd);
    total = roll1 + roll2;
    System.Console.WriteLine($"First roll{roll1} and {roll2}.");
    System.Console.WriteLine($"Your total is currently{total}");
    bool bust = false;
    while (true)
    {
        if (total > 21)
        {
            System.Console.WriteLine("You have busted out. You lose");
            bust = true;
            break;
        }

        System.Console.WriteLine("");
        System.Console.WriteLine("Choose an option");
        System.Console.WriteLine("1. Roll again");
        System.Console.WriteLine("2. Stop Rolling");
        string choice = Console.ReadLine();

        if (choice == "1")
        {
            int newRoll = DiceRoll(rnd);
            total += newRoll;
            System.Console.WriteLine($"You rolled an {newRoll}. Your total is now {total}");

        }
        else if (choice == "2")
        {
            System.Console.WriteLine($"You stopped rolling and the total is {total}.");
            break;
        }
        else
        {
            System.Console.WriteLine("Invalid input. Please type 1 or 2.");
        }
    }
    if (bust)
    {
        System.Console.WriteLine("The computer will not roll because you busted");
        Pause();
        AskReplay(gil, userBet, computerRoll);
        return;
    }
    int computerTotal = ComputerBlackJack(rnd);

    System.Console.WriteLine("");
    System.Console.WriteLine($"cComputer total is {computerTotal}");

    if (computerTotal > 21)
    {
        System.Console.WriteLine("Computer Busted! You Win!");
        gil[0] += userBet[0] * 2;
        EndGame(gil);
    }

    else if (total == 21 && computerTotal != 21)
    {
        System.Console.WriteLine("Lucky you 2x winnings");
        gil[0] += userBet[0] * 2;
        EndGame(gil);
    }
    else if (total > computerTotal)
    {
        System.Console.WriteLine("You have won congrats!");

        gil[0] += userBet[0] * 2;
        EndGame(gil);
    }
    else if (total == computerTotal)
    {
        System.Console.WriteLine("Its a tie computer wins");
        EndGame(gil);
    }

    else
    {
        System.Console.WriteLine("Computer wins");
    }

    System.Console.WriteLine();
    System.Console.WriteLine($"You now have {gil[0]} gil");
    Pause();

    AskReplay(gil, userBet, computerRoll);

}


static int BetIsValid(int[] gil)
{
    int bet = 0;
    bool valid = false;

    while (!valid)
    {
        System.Console.WriteLine("Enter your bet amount");
        string input = Console.ReadLine();

        if (input == "")
        {
            System.Console.WriteLine("Enter a number");
            continue;
        }

        bet = int.Parse(input);

        if (bet > 0 && bet <= gil[0])
        {
            valid = true;
        }
        else
        {
            System.Console.WriteLine("Invalid bet. Enter an sutibale bet");
            System.Console.WriteLine($"You now have {gil[0]}");

        }

    }

    return bet;

}

static int DiceRoll(Random rnd)
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


static int ComputerBlackJack(Random rnd)
{
    int total = 0;
    System.Console.WriteLine("");
    System.Console.WriteLine("Computer's turn..");

    while (total < 17)
    {
        int roll = DiceRoll(rnd);
        total += roll;
        System.Console.WriteLine($"Computer rolled a {roll}. Total is now {total}.");

    }


    if (total > 21)
    {
        System.Console.WriteLine("Computer Busted");

    }
    else
    {
        System.Console.WriteLine($"Computer stands at {total}.");
    }

    return total;
}


static void AskReplay(int[] gil, int[] userBet, int[] computerRoll)
{
    System.Console.WriteLine("");

    System.Console.WriteLine("Choose an option below:");
    System.Console.WriteLine("1. Play BlackJack again");
    System.Console.WriteLine("2. Return to main menu");

    string input = Console.ReadLine();

    if (input == "1")
    {
        PlayBlackJack(gil, userBet, computerRoll);
    }
    else
    {
        System.Console.WriteLine("Going back to menu");
    }
}




static void EndGame(int[] gil)
{
    if (gil[0] <= 0)
    {
        System.Console.WriteLine("");
        System.Console.WriteLine("You have lost all you gil.");
        System.Console.WriteLine("You lose! Better luck next time");
        Pause();
        Environment.Exit(0);
    }
    else if (gil[0] >= 300)
    {
        System.Console.WriteLine("You have reached the goal of 300 gil");
        System.Console.WriteLine("You have won");
        Pause();
        Environment.Exit(0);
    }
}


/// Extras 
/// 1. environment.Exit function for winning
/// 2. custom text colors
/// 3. Title