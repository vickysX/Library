namespace Library.model
{
    public class Author
    {
        private static int _id = 0;
        public int Id { get; set; }

        public string Name { get; set; }
        public string Surname { get; set; }
        public string Bio { get; set; }

        public Author()
        {
            _id++;
            Id = _id;
        }
    }
}
