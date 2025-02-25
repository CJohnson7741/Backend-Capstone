namespace PersonalLibrary.Models;

public class Book
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string ISBN { get; set; }

    public int GenreId { get; set; }
    public Genre Genre { get; set; }

    public int UserProfileId { get; set; }
    public UserProfile UserProfile { get; set; }

    public ICollection<BookAuthor> BookAuthors { get; set; }
}