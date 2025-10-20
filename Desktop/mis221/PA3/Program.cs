//main
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

string userChoice = GetMenuChoice();

int[] gil = new int[1];
int[] userBet = new int[1];
int[] blackjackTotal = new int[1];
int[] diceRoll1 = new int[1];
int[] diceRoll2 = new int[1];
int[] diceRoll3 = new int[1];
int[] initialTotal = new int[1];
int[] newTotal = new int[1];
int[] computerRoll = new int[1];
int[] computerTotals = new int[1];



gil[0] = 50; 

while (userChoice != "3")
{
    RouteEm(userChoice, gil, userBet, diceRoll1, diceRoll2, diceRoll3, initialTotal, newTotal);
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
    System.Console.WriteLine("Please select a menu option (1-3)");
    System.Console.WriteLine("1.PlaySpinTheWheel\n2.PlayBlackjack\n3. Exit");
    return Console.ReadLine();
}


    static void RouteEm(string userChoice, int[] gil, int [] userBet, int [] diceRoll1, int [] diceRoll2, int [] diceRoll3, int[] initialTotal, int[] newTotal)
    {
   
        switch (userChoice)
        {
            case "1":
               
                PlaySpinTheWheel(gil);
                break;
            case "2":
            
                PlayBlackJack(gil, userBet, diceRoll1, diceRoll2, diceRoll3, initialTotal, newTotal, computerRoll);
                break;
            default:
                System.Console.WriteLine("Invalid menu choice...try again");
                break;
        }
        Pause();
    }




static void PlaySpinTheWheel(int[] gil)
{


    //static void Pause()
    //{
    //    Console.WriteLine("Press any key to continue...");
    //    Console.ReadKey(); //forces the program to "pause" enter the user selects any key
    //    Console.Clear();
    //}

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
                PlaySpinTheWheel(gil);


            }
            else
            {
                System.Console.WriteLine("You have lost 100 gills!!");
                gil[0] -= 100;
                System.Console.WriteLine($"You now have {gil[0]} gil!");
                Pause();
                PlaySpinTheWheel(gil);


            }
        }
        else if (winningNumber == 3)
        {
            System.Console.WriteLine("oops you lost 25 gil");
            gil[0] -= 25;
            System.Console.WriteLine($"You now have {gil[0]} gil!");
            Pause();
            PlaySpinTheWheel(gil);

        }
        else if (winningNumber == 4)
        {
            System.Console.WriteLine("Lose all gils! Game Over");
            gil[0] = 0;
            System.Console.WriteLine($"You now have {gil[0]} gil!");
            System.Console.WriteLine("Returning to main menu...");
            Pause();
        }
        else if (winningNumber == 5)
        {
            System.Console.WriteLine("Okay so nothing happened, Try again");
            System.Console.WriteLine($"You have {gil[0]} gil!");
            Pause();
            PlaySpinTheWheel(gil);



        }


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

static void PlayBlackJack(int [] gil, int [] userBet, int [] diceRoll1, int [] diceRoll2, int [] diceRoll3, int[] initialTotal, int[] newTotal, int[] computerRoll)
{
    System.Console.WriteLine("How many gills would you like to bet");
    userBet[0] = int.Parse(Console.ReadLine());
    if (gil[0] >= userBet[0])
    {
        gil[0] -= userBet[0];
        System.Console.WriteLine($"you now have {gil[0]} gil");
        System.Console.WriteLine("");
        Pause();
    }
    else
    {
        System.Console.WriteLine("Insufficient Funds, Bet an acceptable amount");
        Pause();
        PlayBlackJack(userBet, gil, diceRoll1, diceRoll2, diceRoll3, initialTotal, newTotal, computerRoll);
    }

    System.Console.WriteLine("Type 1 to roll the die");
    string userKey = Console.ReadLine();

    if (userKey == "1")
    {
        Random rnd = new Random();
        diceRoll1[0] = rnd.Next(0, 9);
        diceRoll2[0] = rnd.Next(0, 9);
        System.Console.WriteLine($"dice 1 is a {diceRoll1[0]}");
        System.Console.WriteLine($"dice 2 is a {diceRoll2[0]}");
        initialTotal[0] = diceRoll1[0] + diceRoll2[0];
        System.Console.WriteLine($"Dice total: {initialTotal[0]} ");


        System.Console.WriteLine("Choose an option below:");
        System.Console.WriteLine("1. Keep Rolling");
        System.Console.WriteLine("2. Stop Rolliing");
        string keepRolling = Console.ReadLine();

        if (keepRolling == "1")
        {
            diceRoll3[0] = rnd.Next(0, 9);
            newTotal[0] = initialTotal[0] + diceRoll3[0];
            System.Console.WriteLine($"You rolled a {diceRoll3[0]}");
            System.Console.WriteLine($"Your total is now {newTotal[0]}");

        }
        else
        {
            System.Console.WriteLine($"Not Enough at {newTotal}");
        }

        Pause();
    }
    else
    {
        System.Console.WriteLine("invalid, click 1 to roll the dice");
    }
    if (newTotal[0] > 21)
    {
        System.Console.WriteLine("Busted! Better Luck Next Time.");
    }


    int computerTotal = computerRoll[0];
    System.Console.WriteLine($"User Total-- {newTotal}");
    System.Console.WriteLine($"Computer Total--{computerTotal}");


}
        
static void keepRolling(int [] diceRoll1, int [] diceRoll2, int [] diceRoll3, int[] initialTotal, int[] newTotal)
{
    System.Console.WriteLine("Choose an option below:");
    System.Console.WriteLine("1. Keep Rolling");
    System.Console.WriteLine("2. Stop Rolliing");
    string keepRolling = Console.ReadLine();

    if (keepRolling == "1")
    {
        Random rnd = new Random();
        diceRoll3[0] = rnd.Next(0, 9);
        initialTotal[0] += diceRoll3[0];
        System.Console.WriteLine($"You rolled a {diceRoll3[0]}");
        System.Console.WriteLine($"Your total is now {initialTotal[0]}");

    }
    else if (keepRolling == "2")
    {
        System.Console.WriteLine($"Your total is {initialTotal[0]}");
    }

    Pause();
}
    
    static void computerBlackjack(int [] computerRoll)
{
    Random rnd = new Random();
    int computerTotal = computerRoll[0]; 
    int aiRoll = rnd.Next(0, 9);
    System.Console.WriteLine("Computer is Rolling");
    while (aiRoll < 17)
    {
        int Roll1 = rnd.Next(0, 9);
        aiRoll += Roll1;
        System.Console.WriteLine($"Computer rolled a {Roll1}. Total is now {aiRoll}.");
    }
    computerRoll[0] = aiRoll;
}



    
    

//end main
