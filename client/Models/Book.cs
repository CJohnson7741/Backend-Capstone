namespace PersonalLibrary.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ISBN { get; set; }

        // Removed GenreId and Genre reference
        public ICollection<BookGenre> BookGenres { get; set; } // Many-to-many relationship

        public int UserProfileId { get; set; }
        public UserProfile UserProfile { get; set; }

        public ICollection<BookAuthor> BookAuthors { get; set; }

        public string Description { get; set; } 
        public string Condition { get; set; }

        public string ImageUrl { get; set; }
    }
}
