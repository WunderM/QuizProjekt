using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuizPlatform_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizPlatform_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizController : ControllerBase
    {
        private readonly PostgresContext _context;

        public QuizController(PostgresContext context)
        {
            _context = context;
        }

        // GET: api/Quiz
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Quiz>>> GetQuizzes()
        {
            return await _context.Quizzes.Include(q => q.Category).ToListAsync();
        }

        // GET: api/Quiz/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Quiz>> GetQuiz(long id)
        {
            var quiz = await _context.Quizzes.Include(q => q.Category).FirstOrDefaultAsync(q => q.Id == id);

            if (quiz == null)
            {
                return NotFound();
            }

            return quiz;
        }

        // GET: api/Quiz/ByCategory/{categoryId}?count={count}
        [HttpGet("ByCategory/{categoryId}")]
        public async Task<ActionResult<IEnumerable<Quiz>>> GetQuizzesByCategory(long categoryId, [FromQuery] int count = 10)
        {
            // Überprüfen, ob die angegebene Kategorie existiert
            if (!_context.QuizCategorys.Any(c => c.Id == categoryId))
            {
                return NotFound(new { Message = "Category not found" });
            }

            // Quizfragen der Kategorie abrufen, auf die gewünschte Anzahl begrenzen und zurückgeben
            var quizzes = await _context.Quizzes
                                        .Where(q => q.CategoryId == categoryId)
                                        .Include(q => q.Category)
                                        .Take(count) // Anzahl der Fragen begrenzen
                                        .ToListAsync();

            return quizzes;
        }


        // PUT: api/Quiz/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateQuiz(long id, Quiz quiz)
        {
            if (id != quiz.Id)
            {
                return BadRequest();
            }

            _context.Entry(quiz).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuizExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/Quiz/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuiz(long id)
        {
            var quiz = await _context.Quizzes.FindAsync(id);

            if (quiz == null)
            {
                return NotFound();
            }

            _context.Quizzes.Remove(quiz);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool QuizExists(long id)
        {
            return _context.Quizzes.Any(q => q.Id == id);
        }
    }
}
