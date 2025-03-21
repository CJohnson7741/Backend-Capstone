using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PersonalLibrary.Data;
using PersonalLibrary.Models;
using PersonalLibrary.Models.DTOs;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalLibrary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly PersonalLibraryDbContext _context;

        public GenreController(PersonalLibraryDbContext context)
        {
            _context = context;
        }

        // Existing GET endpoint to fetch genres
        [HttpGet("genres")]
        [Authorize]
        public async Task<IActionResult> GetGenres()
        {
            var genres = await _context.Genres
                .Select(g => new GenreDTO
                {
                    Id = g.Id,
                    Name = g.Name
                })
                .ToListAsync();

            return Ok(genres); // Return list of GenreDTOs
        }

        // New POST endpoint to create a genre
        [HttpPost("add")]
        [Authorize]
        public async Task<IActionResult> CreateGenre([FromBody] GenreDTO genreDTO)
        {
            if (genreDTO == null || string.IsNullOrWhiteSpace(genreDTO.Name))
            {
                return BadRequest("Invalid genre data.");
            }

            try
            {
                // Check if genre already exists
                var existingGenre = await _context.Genres
                    .FirstOrDefaultAsync(g => g.Name.Equals(genreDTO.Name, StringComparison.OrdinalIgnoreCase));

                if (existingGenre != null)
                {
                    return Conflict("Genre already exists.");
                }

                // Create new genre and add to the context
                var newGenre = new Genre
                {
                    Name = genreDTO.Name
                };

                _context.Genres.Add(newGenre);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetGenres), new { id = newGenre.Id }, genreDTO);
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while creating the genre.");
            }
        }
    }

}
