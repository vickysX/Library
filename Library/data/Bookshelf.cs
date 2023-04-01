using Library.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using static System.Environment;
using static System.IO.Path;

namespace Library.data
{
    public class Bookshelf
    {
        private List<Book>? _books;
        public List<Book>? Books 
        { 
            get 
            {
                _books = ListAllBooks();
                return _books; 
            } 
        }

        public Bookshelf() 
        {
            _books = ListAllBooks();
        }

        public bool SaveBook(Book book)
        {
            bool isSaved = false;
            string booksPath = Combine(CurrentDirectory, "books.xml");
            using (FileStream stream = File.Open(booksPath, FileMode.OpenOrCreate))
            {
                XmlSerializer serializer = new XmlSerializer(book.GetType());
                serializer.Serialize(stream, book);
                List<Book>? savedBooks = serializer.Deserialize(stream) as List<Book>;
                if (savedBooks != null && savedBooks.Contains(book)) 
                {
                    isSaved = true;
                }
            }
            return isSaved;
        }

        private List<Book>? ListAllBooks()
        {
            List<Book>? books;
            string booksPath = Combine(CurrentDirectory, "books.xml");
            using (FileStream stream = File.Open(booksPath, FileMode.OpenOrCreate))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Book));
                books = serializer.Deserialize(stream) as List<Book>;
            }
            return books;
        }
    }
}
