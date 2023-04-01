using Library.data;
using Library.model;
using System.Collections;

internal class Program
{
    private static void Main(string[] args)
    {
        Bookshelf bookshelf = new Bookshelf();
        string choice = "";
        while (!choice.Equals("q"))
        {
            DisplayMenu();
            ChooseOption(ReadLine(), bookshelf);
        }
    }

    private static void DisplayMenu()
    {
        WriteLine("------- LIBRARY -------");
        WriteLine("1. Insert a new book");
        WriteLine("2. Search for a book");
        WriteLine("3. Search for an author and their work");
        WriteLine("4. Insert a new author");
        WriteLine("q. Quit the program");
    }

    private static void ChooseOption(string? choice, Bookshelf bookshelf)
    {
        if (choice != null)
        {
            switch (choice)
            {
                case "1":
                    InsertBook(bookshelf);
                    break;
                case "2":
                    SearchBook(bookshelf);
                    break;
                case "3":
                    SearchAuthor(bookshelf);
                    break;
                case "4":
                    InsertAuthor(bookshelf);
                    break;
                case "q":
                    Environment.Exit(0);
                    break;
                default:
                    WriteLine("Invalid option");
                    break;
            }
        }
        else
        {
            WriteLine("Please choose an option or quit");
        }
    }

    private static void InsertBook(Bookshelf bookshelf)
    {
        Hashtable bookData = InsertBookData();
        Book book = new Book()
        {
            Title = bookData["title"] as string,
            AuthorId = Convert.ToInt32(bookData["authorId"]),
            Genre = (Genre) bookData["genre"],
            Description = bookData["description"] as string,
            Pages = Convert.ToInt32(bookData["pages"])
        };
        bookshelf.SaveBook(book);
    }

    private static void SearchBook(Bookshelf bookshelf)
    {
        Book? book = bookshelf.FindBook(InsertBookData());
        if (book == null)
        {
            WriteLine("Book not found");
        }
        else
        {
            WriteLine($"Book id: {book.Id}");
            WriteLine($"Title: {book.Title}");
            Author? author = bookshelf.FindAuthorById(book.AuthorId);
            WriteLine($"Author: {author?.Name} {author?.Surname}");
            WriteLine($"Pages: {book.Pages}");
            WriteLine($"Genre: {book.Genre}");
        }
    }

    private static Hashtable InsertBookData()
    {
        Hashtable bookData = new Hashtable();
        try
        {
            Write("Title: ");
            bookData["title"] = ReadLine()!;
            Write("Author id: ");
            bookData["authorId"] = int.Parse(ReadLine()!);
            Write("Pages: ");
            bookData["pages"] = int.Parse(ReadLine()!);
            Write("Description: ");
            bookData["description"] = ReadLine()!;
            DisplayGenreOptions();
            bookData["genre"] = SelectGenre();
        }
        catch (Exception)
        {
            WriteLine("Bad input");
            bookData.Clear();
        }
        return bookData;
    }

    private static void DisplayGenreOptions()
    {
        WriteLine("Select a genre");
        WriteLine("1. Fantasy");
        WriteLine("2. Science Fiction");
        WriteLine("3. Mistery");
        WriteLine("4. Romance");
        WriteLine("5. Thriller");
        WriteLine("6. Poetry");
        WriteLine("7. Theater");
        WriteLine("8. Art");
        WriteLine("9. History");
        WriteLine("10. ComputerScience");
    }

    private static Genre SelectGenre() => ReadLine() switch
    {
        "1" => Genre.Fantasy,
        "2" => Genre.ScienceFiction,
        "3" => Genre.Mistery,
        "4" => Genre.Romance,
        "5" => Genre.Thriller,
        "6" => Genre.Poetry,
        "7" => Genre.Theater,
        "8" => Genre.Art,
        "9" => Genre.History,
        "10" => Genre.ComputerScience,
        _ => Genre.Unknown
    };

    private static void SearchAuthor(Bookshelf bookshelf)
    {

    }

    private static void InsertAuthor(Bookshelf bookshelf)
    {

    }

}