using CodeFirstBasic.Data;
using CodeFirstBasic.Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CodeFirstBasic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly PatikaFirstDbContext _patikaFirstDbContext;

        public MoviesController(PatikaFirstDbContext patikaFirstDbContext)
        {
            _patikaFirstDbContext = patikaFirstDbContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Movie>>> GetAllMovies()
        {
            return await _patikaFirstDbContext.Movies.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Movie>> GetMovieByID(int id)
        {
            var movie = await _patikaFirstDbContext.Movies.FirstOrDefaultAsync(x => x.Id == id);
            if (movie is null)
            {
                return NotFound();
            }
            return movie;
        }
    }
}
