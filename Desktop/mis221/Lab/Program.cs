
using System;
using System.Collections.Generic;
class Program
{
    static void Main()
    {
        List<string> deck = CreateDeck();
        bool exit = false;

        while (!exit)
        {
            System.Console.WriteLine("Card Deck Menu");
            System.Console.WriteLine("Show Full Set");
            System.Console.WriteLine("Exit");
            System.Console.WriteLine("Enter your choice (1-3):");
            
            string input = Console.ReadLine();

            Console.Clear();

            if (input == "1")
            {
                System.Console.WriteLine("Full Deck of Cards:\n");
                DisplayDeck(deck);
            }
            else if (input == "2")
            {
                List<string> shuffled = new List<string>(deck);
                ShuffleDeck(shuffled);
                System.Console.WriteLine("Shuffled Deck of Cards:\n");
                DisplayDeck(shuffled);
            }
            else if (input == "3")
            {
                System.Console.WriteLine("Exit the program");
                exit = true;
            }
            else
            {
                System.Console.WriteLine("Invalid. Choose between 1, 2, or 3.");
            }

            if (!exit)
            {
                System.Console.WriteLine("\nPress any key to return to the menu");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
    static List<string> CreateDeck()
    {
        string[] suits = { "Hearts", "Diamonds", "Clubs", "Spades" };
        string[] ranks = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King", "Ace" };

        List<string> deck = new List<string>();

        foreach (string suit in suits)
        {
            foreach (string rank in ranks)
            {
                deck.Add(ranks + " of " + suit);
            }
        }

        return deck;
    }




    static void DisplayDeck(List<string> deck)
    {
        int number = 1;

        foreach (string card in deck)
        {
            System.Console.WriteLine(number + ". " + card);
            number++;
        }
    }


    static void ShuffleDeck(List<string> deck)
    {
        Random rand = new Random();

        for (int i = deck.Count - 1; i > 0; i--)
        {
            int j = rand.Next(i + 1);

            string temp = deck[i];
            deck[i] = deck[j];
            deck[j] = temp;
        }
    }
}
