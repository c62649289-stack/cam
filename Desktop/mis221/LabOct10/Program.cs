// main
Cities();
// end main

static void Cities()
{
    string[] = { "Daphne", "Huntsville", "Montgomery", "Gadsten", "Mobile" };
    //string[] cities = new string[5];
    DisplayCities(Cities);// writing out every cities

    Swap(cities, 2, 3);// swaping mont and gadsten
    System.Console.WriteLine();

    DisplayCities(cities);//write agter swap
}

static void DisplayCities(string[] cities)
{
    // what goes
    for (int i = 0; i < cities.Length; i++)// not doing count because array is fully filled
    {
        System.Console.WriteLine($"City name: {cities[i]}");
    }
}

static void Swap( string[] cities, int a, int b)
{
    string temp = cities[a];
    cities[a] = cities[b];
    cities[b] = temp;

}

// main to generate rnd number for shuffled deck
RandoGuess();

static void RandoGuess()
{
    int rndNum = GetRandomNum(1, 100);

    System.Console.WriteLine("Guess a number");
    int guessNum = int.Parse(Console.ReadLine());

    if (rndNum == guessNum)
    {
        System.Console.WriteLine("Good job! You guessed it");
    }
    else
    {
        System.Console.WriteLine($"Sorry, the number was{rndNum}");
    }
}

static int GetRandomNum(int lower, int upper)
{
    Random rnd = new Random();
    return rnd.Next(lower, upper + 1);
}