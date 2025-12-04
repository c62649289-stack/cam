namespace Oct20
{
    public class BookFile
    {
        private Book[] books;

        public BookFile(Book[] books)
        {
            this.books = books;
        }
        
        public void GetAllBooks()
        {
            int count = 0;
            StreamReader inFile = new StreamReader("books.txt");
            string line = inFile.ReadLine();
            while (line != null)
            {
                string[] temp = line.Split('#');
                books[count] = new Book(int.Parse(temp[0]), temp[1], temp[2], temp[3], int.Parse(temp[4]));
                count++;
                line = inFile.ReadLine();
            }
            inFile.Close();
            
        }
    }
}