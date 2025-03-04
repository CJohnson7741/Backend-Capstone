using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PersonalLibrary.Data;
using PersonalLibrary.Models;
using PersonalLibrary.Models.DTOs;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PersonalLibrary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly PersonalLibraryDbContext _context;

        public BooksController(PersonalLibraryDbContext context)
        {
            _context = context;
        }

        // Get books for the logged-in user
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetUserBooks()
        {
            // Get the logged-in user's IdentityUserId from claims
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized("User is not logged in.");
            }

            // Fetch the UserProfile corresponding to the logged-in user
            var userProfile = await _context.UserProfiles
                .FirstOrDefaultAsync(u => u.IdentityUserId == userId);

            if (userProfile == null)
            {
                return NotFound("User profile not found.");
            }

            // Fetch books associated with the UserProfileId and include the authors and genre
            var books = await _context.Books
                .Where(b => b.UserProfileId == userProfile.Id) // Filter books by UserProfileId
                .Include(b => b.Genre) // Include Genre related to the book
                .Include(b => b.BookAuthors) // Include BookAuthors (join table)
                .ThenInclude(ba => ba.Author) // Include the Author data
                .ToListAsync();

            // Map the data to BookDTO format
            var booksWithAuthors = books.Select(b => new BookDTO
            {
                Id = b.Id,
                Title = b.Title,
                ISBN = b.ISBN,
                GenreId = b.GenreId,
                GenreName = b.Genre.Name, 
                UserProfileId = b.UserProfileId,
                Username = userProfile.UserName, 
                Authors = b.BookAuthors.Select(ba => new AuthorDTO
                {
                    Id = ba.Author.Id, 
                    Name = ba.Author.Name, 
                    Bio = ba.Author.Bio 
                }).ToList()
            }).ToList();

            return Ok(booksWithAuthors);
        }

        // Get book by ID
        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetBook(int id)
        {
            // Get the logged-in user's IdentityUserId from claims
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized("User is not logged in.");
            }

            // Fetch the UserProfile corresponding to the logged-in user
            var userProfile = await _context.UserProfiles
                .FirstOrDefaultAsync(u => u.IdentityUserId == userId);

            if (userProfile == null)
            {
                return NotFound("User profile not found.");
            }

            // Fetch a specific book by Id and check if it belongs to the logged-in user's profile
            var book = await _context.Books
                .Where(b => b.UserProfileId == userProfile.Id && b.Id == id)
                .Include(b => b.Genre) // Include Genre related to the book
                .Include(b => b.BookAuthors) // Include BookAuthors (join table)
                .ThenInclude(ba => ba.Author) // Include the Author data
                .FirstOrDefaultAsync();

            if (book == null)
            {
                return NotFound("Book not found.");
            }

            // Map the data to BookDTO format
            var bookWithAuthors = new BookDTO
            {
                Id = book.Id,
                Title = book.Title,
                ISBN = book.ISBN,
                GenreId = book.GenreId,
                GenreName = book.Genre.Name,
                UserProfileId = book.UserProfileId,
                Username = userProfile.UserName,
                Authors = book.BookAuthors.Select(ba => new AuthorDTO
                {
                    Id = ba.Author.Id, 
                    Name = ba.Author.Name, 
                    Bio = ba.Author.Bio 
                }).ToList()
            };

            return Ok(bookWithAuthors);
        }

        // DELETE /api/books/{id}
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteBook(int id)
        {
            // Get the logged-in user's IdentityUserId from claims
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized("User is not logged in.");
            }

            var userProfile = await _context.UserProfiles
                .FirstOrDefaultAsync(u => u.IdentityUserId == userId);

            if (userProfile == null)
            {
                return Unauthorized("User profile not found.");
            }

            var book = await _context.Books
                .Where(b => b.UserProfileId == userProfile.Id && b.Id == id)
                .FirstOrDefaultAsync();

            if (book == null)
            {
                return NotFound("Book not found.");
            }

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();

            return NoContent(); // Success, no content to return
        }
    }
}
