using Library.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.data
{
    public class Bookshelf
    {
        private List<Book> _books;
        public List<Book> Books { get { return _books; } }

        public Bookshelf() 
        {
            _books = ListAllBooks();
        }

        private List<Book> ListAllBooks()
        {
            List<Book> list = new List<Book>();
            return list;
        }
    }
}
