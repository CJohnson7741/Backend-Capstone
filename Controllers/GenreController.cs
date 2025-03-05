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
    public class GenreController : ControllerBase
    {
        private readonly PersonalLibraryDbContext _context;

        public GenreController(PersonalLibraryDbContext context)
        {
            _context = context;
        }

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

    }
}