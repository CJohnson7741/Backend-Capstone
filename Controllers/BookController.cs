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
using System.Net.Http;
using System.Text.Json;  // Required for System.Text.Json

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
                            Name = authorDto.Name
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
                UserProfileId = userProfile.Id,
                Description = bookDto.Description,
                Condition = bookDto.Condition,
                ImageUrl = bookDto.ImageUrl
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

            // Handle many-to-many relationship with genres
            var genres = new List<Genre>();

            // Check and add genres based on GenreIds
            foreach (var genreId in bookDto.GenreIds)
            {
                var genre = await _context.Genres
                    .FirstOrDefaultAsync(g => g.Id == genreId);

                if (genre == null)
                {
                  genres.Add(genre);  
                  //return NotFound($"Genre with Id {genreId} not found.");
                }

                
            }

            // Check if a new genre name is provided (GenreName is for a single new genre name)
            if (!string.IsNullOrEmpty(bookDto.GenreName))
            {
                var genre = await _context.Genres
                    .FirstOrDefaultAsync(g => g.Name.Equals(bookDto.GenreName, StringComparison.OrdinalIgnoreCase));

                if (genre == null)
                {
                    // Create the new genre if it doesn't exist
                    genre = new Genre
                    {
                        Name = bookDto.GenreName
                    };

                    // Add the new genre to the database
                    _context.Genres.Add(genre);
                    await _context.SaveChangesAsync(); // Save to get the genre's Id

                    genres.Add(genre);
                }
            }

            // Now create the relationships in the BookGenres table
            foreach (var genre in genres)
            {
                var bookGenre = new BookGenre
                {
                    BookId = book.Id,
                    GenreId = genre.Id
                };

                _context.BookGenres.Add(bookGenre);
            }

            await _context.SaveChangesAsync(); // Save all the relationships

            return CreatedAtAction(nameof(GetBook), new { id = book.Id }, book);
        }



        // PUT /api/books/{id}
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> UpdateBook(int id, [FromBody] BookDTO bookDto)
        {
            try
            {
                // Get the current user's Id (logged-in user)
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                if (string.IsNullOrEmpty(userId))
                {
                    return Unauthorized("User is not logged in.");
                }

                var user = await _userManager.FindByIdAsync(userId);
                if (user == null)
                {
                    return Unauthorized("User profile not found.");
                }

                var userProfile = await _context.UserProfiles
                    .FirstOrDefaultAsync(u => u.IdentityUserId == userId);

                if (userProfile == null)
                {
                    return Unauthorized("User profile not found.");
                }

                var book = await _context.Books
                    .Where(b => b.UserProfileId == userProfile.Id && b.Id == id)
                    .Include(b => b.BookGenres)  // Include BookGenres to manage the genre updates
                    .FirstOrDefaultAsync();

                if (book == null)
                {
                    return NotFound("Book not found.");
                }

                // Ensure authors are either fetched from the database or created and saved
                var authors = new List<Author>();
                foreach (var authorDto in bookDto.Authors ?? new List<AuthorDTO>())
                {
                    Author author;

                    if (authorDto.Id > 0)
                    {
                        // Fetch existing author
                        author = await _context.Authors
                            .FirstOrDefaultAsync(a => a.Id == authorDto.Id);

                        if (author == null)
                        {
                            return NotFound($"Author with Id {authorDto.Id} not found.");
                        }
                    }
                    else
                    {
                        // Check if author already exists by name
                        author = await _context.Authors
                            .FirstOrDefaultAsync(a => a.Name == authorDto.Name);

                        if (author == null)
                        {
                            // Create new author if they don't exist
                            author = new Author
                            {
                                Name = authorDto.Name
                            };
                            _context.Authors.Add(author);
                            await _context.SaveChangesAsync();  // Save to get the ID
                        }
                    }

                    authors.Add(author);
                }

                // Update the book's properties
                book.Title = bookDto.Title;
                book.Description = bookDto.Description;
                book.Condition = bookDto.Condition;
                book.ISBN = bookDto.ISBN;

                // Handle many-to-many relationship with genres
                var genres = new List<Genre>();
                foreach (var genreId in bookDto.GenreIds ?? new List<int>())
                {
                    var genre = await _context.Genres
                        .FirstOrDefaultAsync(g => g.Id == genreId);

                    if (genre == null)
                    {
                        return NotFound($"Genre with Id {genreId} not found.");
                    }

                    genres.Add(genre);
                }

                // Get the current book genres in the database
                var existingBookGenres = await _context.BookGenres
                    .Where(bg => bg.BookId == book.Id)
                    .ToListAsync();

                // Determine genres to remove and add
                var genresToRemove = existingBookGenres
                    .Where(bg => !genres.Any(g => g.Id == bg.GenreId))
                    .ToList();

                var genresToAdd = genres
                    .Where(g => !existingBookGenres.Any(bg => bg.GenreId == g.Id))
                    .ToList();

                // Remove the genres that are no longer associated with the book
                _context.BookGenres.RemoveRange(genresToRemove);

                // Add new genre relationships
                foreach (var genre in genresToAdd)
                {
                    var bookGenre = new BookGenre
                    {
                        BookId = book.Id,
                        GenreId = genre.Id
                    };

                    _context.BookGenres.Add(bookGenre);
                }

                // Handle updating authors
                var existingBookAuthors = await _context.BookAuthors
                    .Where(ba => ba.BookId == book.Id)
                    .ToListAsync();

                var authorsToRemove = existingBookAuthors
                    .Where(ba => !authors.Any(a => a.Id == ba.AuthorId))
                    .ToList();

                var authorsToAdd = authors
                    .Where(a => !existingBookAuthors.Any(ba => ba.AuthorId == a.Id))
                    .ToList();

                // Remove the authors that are no longer associated with the book
                _context.BookAuthors.RemoveRange(authorsToRemove);

                // Add new author relationships
                foreach (var author in authorsToAdd)
                {
                    var bookAuthor = new BookAuthor
                    {
                        BookId = book.Id,
                        AuthorId = author.Id
                    };

                    _context.BookAuthors.Add(bookAuthor);
                }

                // Save all changes
                await _context.SaveChangesAsync();

                return Ok(book);
            }
            catch (Exception ex)
            {
                // Log the exception and return a proper error response
                Console.WriteLine($"Error in UpdateBook API: {ex.Message}");
                return StatusCode(500, "An error occurred while updating the book.");
            }
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

        // GET /api/books/{id}
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
                .Include(b => b.BookGenres)  // Include the BookGenres relationship
                    .ThenInclude(bg => bg.Genre)  // Include the Genre for each BookGenre
                .Include(b => b.BookAuthors)  // Include BookAuthors to load related authors
                    .ThenInclude(ba => ba.Author)  // Include the Author for each BookAuthor
                .FirstOrDefaultAsync();  // Get the book with its related entities

            if (book == null)
            {
                return NotFound("Book not found.");
            }

            var authors = book.BookAuthors
                .Select(ba => new AuthorDTO { Id = ba.Author.Id, Name = ba.Author.Name })
                .ToList();

            var genreNames = string.Join(", ", book.BookGenres.Select(bg => bg.Genre.Name));  // Join genre names as a string

            var bookDto = new BookDTO
            {
                Id = book.Id,
                Title = book.Title,
                ISBN = book.ISBN,
                GenreName = genreNames,  // Set the GenreNames as a comma-separated string
                Description = book.Description,
                Condition = book.Condition,
                Authors = authors,
                ImageUrl = book.ImageUrl  // Include image URL in response
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
                .Include(b => b.BookGenres)  // Include BookGenres for the many-to-many relationship
                    .ThenInclude(bg => bg.Genre)  // Include the Genre details related to each BookGenre
                .Include(b => b.BookAuthors)  // Include BookAuthors to load related authors
                    .ThenInclude(ba => ba.Author)  // Load the authors related to the book
                .Select(b => new BookDTO
                {
                    Id = b.Id,
                    Title = b.Title,
                    ISBN = b.ISBN,
                    GenreName = string.Join(", ", b.BookGenres.Select(bg => bg.Genre.Name)),  // Get Genre names from BookGenres
                    Description = b.Description,
                    Condition = b.Condition,
                    Authors = b.BookAuthors
                        .Select(ba => new AuthorDTO
                        {
                            Id = ba.Author.Id,
                            Name = ba.Author.Name,
                        })
                        .ToList(),
                    ImageUrl = b.ImageUrl  // Include image URL in the response
                })
                .ToListAsync();

            return Ok(books);
        }


        [HttpGet("isbn/{isbn}")]
        public async Task<IActionResult> GetBookByISBN(string isbn)
        {
            string apiKey = "AIzaSyDGXvTPLdVgSFzI4_98J5BPTVZbVEtCg7o";  // Replace with your API key
            string url = $"https://www.googleapis.com/books/v1/volumes?q=isbn:{isbn}&key={apiKey}";

            try
            {
                using (var client = new HttpClient())
                {
                    // Make the request to the Google Books API
                    var response = await client.GetAsync(url);
                    if (response.IsSuccessStatusCode)
                    {
                        var jsonResponse = await response.Content.ReadAsStringAsync();

                        // Deserialize only the necessary parts of the response
                        var googleBooksResponse = JsonSerializer.Deserialize<GoogleBooksResponse>(jsonResponse);

                        if (googleBooksResponse != null && googleBooksResponse.TotalItems > 0)
                        {
                            var bookInfo = googleBooksResponse.Items.FirstOrDefault()?.VolumeInfo;

                            if (bookInfo != null)
                            {
                                var bookDto = new BookDTO
                                {
                                    Title = bookInfo.Title,
                                    ISBN = isbn,
                                    Description = bookInfo.Description ?? "No description available",
                                    GenreName = bookInfo.Categories?.FirstOrDefault() ?? "Unknown",  // Default genre if not available
                                    Condition = "Unknown",  // Default condition
                                    Authors = bookInfo.Authors?.Select(a => new AuthorDTO { Name = a }).ToList() ?? new List<AuthorDTO> { new AuthorDTO { Name = "Unknown Author" } },
                                    ImageUrl = bookInfo.ImageLinks?.Thumbnail // Extract the thumbnail image URL
                                };

                                return Ok(bookDto);
                            }
                        }

                        return NotFound("No books found with the provided ISBN.");
                    }

                    return StatusCode(500, "Error calling the Google Books API. Please try again later.");
                }
            }
            catch (HttpRequestException ex)
            {
                return StatusCode(500, $"Error while making the request: {ex.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An unexpected error occurred: {ex.Message}");
            }
        }
    }
}
