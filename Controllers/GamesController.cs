using CodeFirstBasic.Data;
using CodeFirstBasic.Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CodeFirstBasic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly PatikaFirstDbContext _patikaFirstDbContext;

        public GamesController(PatikaFirstDbContext myDbContext)
        {
            _patikaFirstDbContext = myDbContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Game>>> GetAllGames()
        {
            return await _patikaFirstDbContext.Games.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Game>> GetGameId(int id)
        {
            var game = await _patikaFirstDbContext.Games.FindAsync(id);
            if (game is null)
            {
                return NotFound();
            }
            return game;
        }
    }
}
