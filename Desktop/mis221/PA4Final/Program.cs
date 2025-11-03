using System;
using System.IO;
using System.Text;


namespace PA4Program
{
    class PA4
    {
        static void Main()
        {
            int choice = 0;

            while (choice != 4)
            {
                System.Console.WriteLine("");
                System.Console.WriteLine("File Code Menu");
                System.Console.WriteLine("");
                System.Console.WriteLine("1. Encode a File");
                System.Console.WriteLine("");
                System.Console.WriteLine("2. Decode a File");
                System.Console.WriteLine("");
                System.Console.WriteLine("3. Word Count");
                System.Console.WriteLine("");
                System.Console.WriteLine("4. Exit");
                System.Console.WriteLine("");
                System.Console.Write("Enter your choice (1-4):");

                string input = Console.ReadLine() ?? "";
                choice = Convert.ToInt32(input);

                if (choice == 1)
                {
                    EncodeFile();
                }
                else if (choice == 2)
                {
                    DecodeFile();
                }
                else if (choice == 3)
                {
                    WordCount();
                }
                else if (choice == 4)
                {
                    System.Console.WriteLine("Exiting system. BYE!!!");
                }
                else
                {
                    System.Console.WriteLine("Invalid option. Choose options 1-4");
                }
            }
        }
        static string UseRot13(string input)
        {
            string result = "";

            for (int i = 0; i < input.Length; i++)
            {
                char c = input[i];

                if (c >= 'A' && c <= 'Z')
                {
                    c = (char)('A' + (c - 'A' + 13) % 26);
                }
                else if (c >= 'a' && c <= 'z')
                {
                    c = (char)('a' + (c - 'a' + 13) % 26);
                }
                result = result + c;
            }
            return result;
        }
        static void EncodeFile()
        {
            Console.Write("Enter the name of the file for encode: ");
            string inputFile = Console.ReadLine() ?? "";

            if (!File.Exists(inputFile))
            {
                System.Console.WriteLine(" File not found, try a different name. \n");
                return;
            }

            string[] lines = File.ReadAllLines(inputFile);
            string encodedText = "";

            for (int i = 0; i < lines.Length; i++)
            {
                encodedText += UseRot13(lines[i]) + "\n";
            }
            System.Console.WriteLine("Enter the name of the file to save: ");
            string outputFile = Console.ReadLine();

            File.WriteAllText(outputFile, encodedText);
            System.Console.WriteLine("File encoded successfully, now saved as: " + outputFile + "\n");

        }
        static void DecodeFile()
        {
            System.Console.Write("Enter the name of the file to decode: ");
            string inputFile = Console.ReadLine() ?? "";

            if (!File.Exists(inputFile))
            {
                System.Console.WriteLine(" File not found, try a differnt name. \n");
                return;
            }

            string[] lines = File.ReadAllLines(inputFile);
            string decodedText = "";

            for (int i = 0; i < lines.Length; i++)
            {
                decodedText += UseRot13(lines[i]) + "\n";
            }

            System.Console.Write("Enter the name of the file to save:");
            string outputFile = Console.ReadLine();

            File.WriteAllText(outputFile, decodedText);
            System.Console.WriteLine("File decoded successfully, now saved as: " + outputFile + "\n");
        }

        static void WordCount()
        {
            Console.Write("Enter the name of the file: ");
            string inputFile = Console.ReadLine() ?? "";

            if (!File.Exists(inputFile))
            {
                System.Console.WriteLine(" File not found, try a differnt name. \n");
                return;
            }

            string[] lines = File.ReadAllLines(inputFile);
            int wordCount = 0;

            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i];
                string[] words = line.Split(' ');

                for (int j = 0; j < words.Length; j++)
                {
                    if (words[j] != "")
                    {
                        wordCount++;
                    }
                }
            }
            System.Console.WriteLine("The file contains " + wordCount + "words.\n");
        }
    }
}    