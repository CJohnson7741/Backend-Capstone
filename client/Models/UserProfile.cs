using Microsoft.AspNetCore.Identity;

namespace PersonalLibrary.Models;

public class UserProfile
{
    public int Id { get; set; }
    public string UserName { get; set; }

    public string IdentityUserId { get; set; }

    public string Email { get; set;}

    public IdentityUser IdentityUser { get; set; }

    public ICollection<Book> Books { get; set; }
}