using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PersonalLibrary.Data;
using PersonalLibrary.Models;
using PersonalLibrary.Models.DTOs;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace PersonalLibrary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly PersonalLibraryDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public BooksController(PersonalLibraryDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // POST /api/books
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateBook([FromBody] BookDTO bookDto)
        {
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

            // Create or find authors based on the DTOs passed
            var authors = new List<Author>();
            foreach (var authorDto in bookDto.Authors)
            {
                Author author;
                if (authorDto.Id > 0)
                {
                    // If an AuthorId is provided, check if the author exists in the database
                    author = await _context.Authors
                        .FirstOrDefaultAsync(a => a.Id == authorDto.Id);
                    
                    if (author == null)
                    {
                        return NotFound($"Author with Id {authorDto.Id} not found.");
                    }
                }
                else
                {
                    // If no Id is provided, create a new author
                    author = await _context.Authors
                        .FirstOrDefaultAsync(a => a.Name == authorDto.Name);

                    if (author == null)
                    {
                        // Create new author if they do not exist
                        author = new Author
                        {
                            Name = authorDto.Name,
                            Bio = authorDto.Bio
                        };
                        _context.Authors.Add(author);
                        await _context.SaveChangesAsync(); // Save to get the author's ID
                    }
                }

                authors.Add(author);
            }

            // Create the book
            var book = new Book
            {
                Title = bookDto.Title,
                ISBN = bookDto.ISBN,
                GenreId = bookDto.GenreId,
                UserProfileId = userProfile.Id,
                Description = bookDto.Description,
                Condition = bookDto.Condition
            };

            _context.Books.Add(book);
            await _context.SaveChangesAsync(); // Save the book to get the book ID

            // Now create the relationships in the BookAuthors table
            foreach (var author in authors)
            {
                var bookAuthor = new BookAuthor
                {
                    BookId = book.Id,
                    AuthorId = author.Id
                };

                _context.BookAuthors.Add(bookAuthor);
            }

            await _context.SaveChangesAsync(); // Save the relationships

            return CreatedAtAction(nameof(GetBook), new { id = book.Id }, book);
        }

        // PUT /api/books/{id}
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> UpdateBook(int id, [FromBody] BookDTO bookDto)
        {
            // Get the current user's Id (logged-in user)
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized("User is not logged in.");
            }

            // Get the current user to retrieve the Username
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return Unauthorized("User profile not found.");
            }

            // Fetch user profile related to the logged-in user
            var userProfile = await _context.UserProfiles
                .FirstOrDefaultAsync(u => u.IdentityUserId == userId);

            if (userProfile == null)
            {
                return Unauthorized("User profile not found.");
            }

            // Fetch the book associated with the logged-in user
            var book = await _context.Books
                .Where(b => b.UserProfileId == userProfile.Id && b.Id == id)
                .FirstOrDefaultAsync();

            if (book == null)
            {
                return NotFound("Book not found.");
            }

            // Create or find authors based on the DTOs passed
            var authors = new List<Author>();
            foreach (var authorDto in bookDto.Authors)
            {
                Author author;
                if (authorDto.Id > 0)
                {
                    // If an AuthorId is provided, check if the author exists in the database
                    author = await _context.Authors
                        .FirstOrDefaultAsync(a => a.Id == authorDto.Id);

                    if (author == null)
                    {
                        return NotFound($"Author with Id {authorDto.Id} not found.");
                    }
                }
                else
                {
                    // If no Id is provided, create a new author
                    author = await _context.Authors
                        .FirstOrDefaultAsync(a => a.Name == authorDto.Name);

                    if (author == null)
                    {
                        // Create new author if they do not exist
                        author = new Author
                        {
                            Name = authorDto.Name,
                            Bio = authorDto.Bio
                        };
                        _context.Authors.Add(author);
                    }
                }

                authors.Add(author);
            }

            // Update book details
            book.Title = bookDto.Title;
            book.Description = bookDto.Description;
            book.Condition = bookDto.Condition;
            book.ISBN = bookDto.ISBN;
            book.GenreId = bookDto.GenreId;

            // Remove existing BookAuthors relationships
            var existingBookAuthors = await _context.BookAuthors
                .Where(ba => ba.BookId == book.Id)
                .ToListAsync();

            // Find the authors to remove (authors that are not in the new list)
            var authorsToRemove = existingBookAuthors
                .Where(ba => !authors.Any(a => a.Id == ba.AuthorId))
                .ToList();

            // Find authors to add (authors that are not already linked to the book)
            var authorsToAdd = authors
                .Where(a => !existingBookAuthors.Any(ba => ba.AuthorId == a.Id))
                .ToList();

            // Remove the BookAuthors that are no longer needed
            _context.BookAuthors.RemoveRange(authorsToRemove);

            // Add the new BookAuthors relationships
            foreach (var author in authorsToAdd)
            {
                var bookAuthor = new BookAuthor
                {
                    BookId = book.Id,
                    AuthorId = author.Id
                };

                _context.BookAuthors.Add(bookAuthor);
            }

            // Save changes in a single transaction
            await _context.SaveChangesAsync(); 

            return Ok(book); // Return the updated book
        }

        // DELETE /api/books/{id}
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteBook(int id)
        {
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

        // Get book by ID
        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetBook(int id)
        {
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

            var authors = await _context.BookAuthors
                .Where(ba => ba.BookId == book.Id)
                .Select(ba => ba.Author)
                .ToListAsync();

            var genre = await _context.Genres
                .FirstOrDefaultAsync(g => g.Id == book.GenreId);

            var bookDto = new BookDTO
            {
                Id = book.Id,
                Title = book.Title,
                ISBN = book.ISBN,
                GenreId = book.GenreId,
                GenreName = genre?.Name, // Ensure the GenreName is included
                Description = book.Description,
                Condition = book.Condition,
                Authors = authors.Select(a => new AuthorDTO { Id = a.Id, Name = a.Name, Bio = a.Bio }).ToList()
            };

            return Ok(bookDto);
        }

        // GET /api/books
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetBooks()
        {
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

            var books = await _context.Books
                .Where(b => b.UserProfileId == userProfile.Id)
                .Include(b => b.Genre) // Ensure the Genre is included in the query
                .Select(b => new BookDTO
                {
                    Id = b.Id,
                    Title = b.Title,
                    ISBN = b.ISBN,
                    GenreId = b.GenreId,
                    GenreName = b.Genre.Name,  // Map Genre Name here
                    Description = b.Description,
                    Condition = b.Condition,
                    Authors = b.BookAuthors
                        .Select(ba => ba.Author)
                        .Select(a => new AuthorDTO
                        {
                            Id = a.Id,
                            Name = a.Name,
                            Bio = a.Bio
                        }).ToList()
                })
                .ToListAsync();

            return Ok(books);
        }
    }
}
