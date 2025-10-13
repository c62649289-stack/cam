//main



//end main
int userChoice;
do {
    userChoice = Menu();
    while(userChoice !=3)
    { RouteEm(userChoice);
    }
   
}

static int Menu()
{
     System.Console.WriteLine("1. Count to 10\n2. Blast Off!");
    return int.Parse(Console.ReadLine());
}
static void CountToTen()
{
    if (userChoice ==1)
    {
        CountToTen();
     }
     else if (userChoice)
    }
}
static void RouteEm(int userChoice)
    If(userChoice == 1 )

{
	for(int i = 0; i < 10; i++)
    {
        System.Console.Writeline(i);
    }
}

static void BlastOff()
{
    for(int i = 10; i >= 0; i--)
    {
        System.Console.Writeline(i);
    }
    System.Console.WriteLine("BLast OFF !!!")
}