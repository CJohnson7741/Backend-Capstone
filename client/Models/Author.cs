namespace PersonalLibrary.Models;
public class Author
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Bio { get; set; }

    public ICollection<BookAuthor> BookAuthors { get; set; }
}