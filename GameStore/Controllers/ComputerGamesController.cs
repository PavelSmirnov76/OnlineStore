using GameStore.Database;
using GameStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Controllers
{
    [Route("api/ComputerGames")]
    [ApiController]
    public class ComputerGamesController : Controller
    {
        private readonly GameStoreContext _context;

        public ComputerGamesController(GameStoreContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ComputerGame>>> GetComputerGames()
        {
            return await _context.ComputerGames.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ComputerGame>> GetComputerGame(long id)
        {
            var computerGame = await _context.ComputerGames.FirstOrDefaultAsync(m => m.Id == id);

            if (computerGame == null)
            {
                return NotFound();
            }

            return computerGame;
        }

        [HttpPost]
        public async Task<ActionResult<ComputerGame>> PostComputerGame(ComputerGame computerGame)
        {
            await _context.ComputerGames.AddAsync(computerGame);

            await _context.SaveChangesAsync();

            return base.CreatedAtAction(nameof(GetComputerGame), new { id = computerGame.Id }, computerGame);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteComputerGame(long id)
        {
            var computerGame = await _context.ComputerGames.FindAsync(id);
            if (computerGame == null)
            {
                return NotFound();
            }

            _context.ComputerGames.Remove(computerGame);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ComputerGamesExists(long id)
        {
            return (_context.ComputerGames?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
