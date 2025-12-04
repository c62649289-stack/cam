using System.ComponentModel.DataAnnotations;

namespace Oct20
{
    public class BookUtility
    {
        private Book[] books;
        public BookUtility(Book[] books)
    }
    public void Sort()
    {
        for(int i = 0, i < Book.GetCount()-1; i++ )
            {
                int min = i;
                for(int j=i +1; j< BookUtility.GetCount(); j++)
                {
                    if(books)[min]. CompareTo(Book compareBook, string compareType = "id")
                    {
                        if (compareType == "id")
                        {
                            if (this.id == compareBook.GetId())
                            {
                                return 0;
                            }
                            else if (this.id > compareBook.GetId())
                            {
                                return 1;

                            }
                            else
                            {
                                return -1;
                            }
                        }
                        else if (compareType == "genre")
                        {
                            return this.genre.CompareTo(compareBook.GetGenre());
                        }
                        
                    }
                }
            }
    }
}