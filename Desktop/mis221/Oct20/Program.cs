using System;
using System.Collections.Generic;

namespace iloveoopbooks
{
    public class Book
    {// instance variables
        private int id;
        private string title;
        private string author;
        private string genre;
        private int pageCount;
        public int GetId(int id)
        {
            return id;

        }
        public void SetId(int id)
        {
            this.id = id;
        }
    }
}