using Library.model;
using System.Collections;
using System.Xml.Serialization;
using static System.Environment;
using static System.IO.Path;

namespace Library.data
{
    public class Bookshelf
    {
        private List<Book>? _books;
        private List<Author>? _authors;

        public List<Book>? Books
        {
            get
            {
                _books = ListAllBooks();
                return _books;
            }
        }

        public List<Author>? Authors
        {
            get
            {
                _authors = ListAllAuthors();
                return _authors;
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

        private List<Author>? ListAllAuthors() 
        {
            List<Author>? authors = new List<Author>();
            return authors;
        }

        public Book? FindBook(Hashtable bookData)
        {
            var searchedBook = (from book in Books
                        where book.Title == bookData["title"] as string &&
                        book.Pages == Convert.ToInt32(bookData["pages"]) &&
                        book.AuthorId == Convert.ToInt32(bookData["authorId"])
                        select book).SingleOrDefault();
            /*var query1 = _books.AsQueryable().Where(book =>
                book.Title == bookData["title"] as string &&
                book.Pages == Convert.ToInt32(bookData["pages"])
            );*/
            return searchedBook;
        }

        public Author? FindAuthorById(int id)
        {
            var searchedAuthor = (from author in Authors
                                    where author.Id == id
                                    select author).SingleOrDefault();
            return searchedAuthor;
        }
    }
}
