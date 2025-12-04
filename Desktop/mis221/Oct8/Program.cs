//main
const int MAX_BOOKS = 100;
string[] titles = new string[MAX_BOOKS];
string[] authors = new string[MAX_BOOKS];
string[] genres = new string[MAX_BOOKS];
int[] pageCounts = new int[MAX_BOOKS];

int count = GetAllBooks(titles, authors, genres, pageCounts);
PrintAllBooks(titles, authors, genres, pageCounts);


System.Console.WriteLine("\n\n");
int foundIndex = FindBook(titles, count, Console.ReadLine());
if (foundIndex != -1)
{
    System.Console.WriteLine($"the book was found at spot {foundIndex}");
}
else
{
    System.Console.WriteLine("the book was not found");
}
    //count = AddBook(titles, genres, authors, pageCounts);
    //xSaveAllBooks(titles, authors, genres, pageCounts);
    PrintAllBooks(titles, authors, genres, pageCounts);
//end main

static int GetAllBooks(string[] titles, string[] authors, string[] genres, int[] pageCounts)
{
    int count = 0;
    StreamReader inFile = new StreamReader("input.txt");  //Open file
    string line = inFile.ReadLine(); //priming read, read the first line from file

    //Process file
    while (line != null)
    {
        string[] temp = line.Split('#');
        titles[count] = temp[0];
        authors[count] = temp[1];
        genres[count] = temp[2];
        pageCounts[count] = int.Parse(temp[3]);
        line = inFile.ReadLine();// update read
    }
    inFile.Close();
    return count;//Close file
}

static int AddBook(string[] titles, string[] authors, string[] genres, int[] pageCounts, int count)
{
    System.Console.WriteLine("Enter the title of the book");
    titles[count] = Console.ReadLine();

}
//

static int GetAllBooks(string[] titles, string[] authors, string[] genres, int[] pageCounts)
{
    int count = 0;
    System.Console.WriteLine("Enter the title of the book, Stop to stop");
    string title = Console.ReadLine();
    while (title.ToLower()) != "stop")
    {
        titles[count] = title;
        System.Console.WriteLine("who was it written by");
        authors[count] = Console.ReadLine();
        System.Console.WriteLine("");// missing
        System.Console.WriteLine("How many pages");
        pageCounts[count] = int.Parse(Console.ReadLine());


        count++
        System.Console.WriteLine("Enter the title of the book, STOP to stop");
        title = Console.ReadLine();

    }
    return count;

}
static int FindBook(string[] titles, int count, string searchVal)// sequential search
{
    for (int i = 0; i < count; i++)
    {
        if (searchVal.ToUpper() == titles[i].ToUpper()) return i;
    }
    return -1; // return if not titles
}

static void Sort(string[] titles, string[] authors, string[] genres, int[] pageCounts, int count)
{
    for(int i = 0; i < count -1; i++)
    {
        int min = i;
        for (int j = i + 1; j < count; j++)
        {
            if (titles[min].CompareTo(titles[j]) > 0)
            {
                min = j;

            }
        }
        if (min !=1)
        {
            Swap(titles, min, i);
            Swap(authors, min, i);
            Swap(genres,min,i)
        }
    }
}
static void SaveAllBooks(string[] titles, string[] authors, string[] genres, int[] pageCounts, int count)
{
    StreamWriter out File = new StreamWriter("input.txt")
}

static string ToString(string titles, string author, string genre, int pageCount)
{
    return $"{title}\t{author}\t{genre}\t{pageCount}";
}
static void PrintAllBooks(string[] titles, string[] authors, string[] genres, int[] pageCounts)
{
    for (int i = 0; i < count; i++)
    System.Console.WriteLine(ToString(titles[i],authors[i],genres[i], pageCounts[i]));
}
//