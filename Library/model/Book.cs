namespace Library.model
{
    [Serializable]
    public class Book
    {
        private static int _id = 0;
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int AuthorId { get; set; }
        public Genre Genre { get; set; }
        public int Pages { get; set; }

        public Book()
        {
            _id++;
            Id = _id;
        }

        public Book(
            string title,
            string description,
            int authorId,
            int pages,
            Genre genre = Genre.Unknown)
        {
            Title = title;
            Description = description;
            AuthorId = authorId;
            Pages = pages;
            Genre = genre;
            _id++;
            Id = _id;
        }
    }
}
