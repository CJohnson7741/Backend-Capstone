namespace PersonalLibrary.Models
{
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Many-to-many relationship with Book
        public ICollection<BookGenre> BookGenres { get; set; }
    }
}
