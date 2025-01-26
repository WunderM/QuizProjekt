using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuizPlatform_API.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizPlatform_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HighscoreController : ControllerBase
    {
        private readonly PostgresContext _context;

        public HighscoreController(PostgresContext context)
        {
            _context = context;
        }

        // GET: api/Highscore
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Highscore>>> GetAllHighscores()
        {
            return await _context.Highscores
                .Include(h => h.UserNavigation)
                .Include(h => h.QuizNavigation)
                .ToListAsync();
        }

        // GET: api/Highscore/Quiz/{quizId}
        [HttpGet("Quiz/{quizId}")]
        public async Task<ActionResult<IEnumerable<object>>> GetHighscoresByQuiz(long quizId)
        {
            // Überprüfen, ob das Quiz existiert
            if (!_context.Quizzes.Any(q => q.Id == quizId))
            {
                return NotFound(new { Message = "Quiz not found" });
            }

            // Highscores für das Quiz abrufen und auf vereinfachte Struktur projizieren
            var highscores = await _context.Highscores
                .Where(h => h.QuizId == quizId)
                .OrderByDescending(h => h.Score)
                .Take(25) // Nur die Top 5
                .Select(h => new
                {
                    PlayerName = h.UserNavigation.Username, // Spielername aus der User-Tabelle
                    Score = h.Score                     // Punktzahl
                })
                .ToListAsync();

            return Ok(highscores);
        }


        // GET: api/Highscore/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Highscore>> GetHighscoreById(long id)
        {
            var highscore = await _context.Highscores
                .Include(h => h.UserNavigation)
                .Include(h => h.QuizNavigation)
                .FirstOrDefaultAsync(h => h.Id == id);

            if (highscore == null)
            {
                return NotFound(new { Message = "Highscore not found" });
            }

            return highscore;
        }

        // POST: api/Highscore
        [HttpPost]
        public async Task<ActionResult<Highscore>> CreateHighscore(Highscore highscore)
        {
            // Überprüfen, ob das Quiz und der Benutzer existieren
            if (!_context.Quizzes.Any(q => q.Id == highscore.QuizId))
            {
                return NotFound(new { Message = "Quiz not found" });
            }

            if (!_context.Users.Any(u => u.Id == highscore.UserId))
            {
                return NotFound(new { Message = "User not found" });
            }

            _context.Highscores.Add(highscore);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetHighscoreById), new { id = highscore.Id }, highscore);
        }

        // DELETE: api/Highscore/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHighscore(long id)
        {
            var highscore = await _context.Highscores.FindAsync(id);

            if (highscore == null)
            {
                return NotFound(new { Message = "Highscore not found" });
            }

            _context.Highscores.Remove(highscore);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
