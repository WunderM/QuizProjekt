using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuizPlatform_API.Models;

namespace QuizPlatform_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizQuestionController : ControllerBase
    {
        private readonly PostgresContext _context;

        public QuizQuestionController(PostgresContext context)
        {
            _context = context;
        }

        [HttpGet("{quizId}")]
        public async Task<ActionResult<IEnumerable<QuizQuestion>>> GetQuizQuestions(long quizId, [FromQuery] int? limit = 20)
        {
            try
            {
                var questions = await _context.QuizQuestions
                    .Where(q => q.QuizId == quizId)
                    .Take(limit ?? 20)
                    .ToListAsync();

                if (questions == null || questions.Count == 0)
                {
                    return NotFound($"Keine Fragen für das Quiz mit der ID {quizId} gefunden.");
                }

                return Ok(questions);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ein Fehler ist aufgetreten: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<QuizQuestion>> PostQuizQuestion(QuizQuestion quizQuestion)
        {
            try
            {
                if (quizQuestion == null)
                {
                    return BadRequest("Ungültige Eingabe.");
                }

                _context.QuizQuestions.Add(quizQuestion);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetQuizQuestions), new { quizId = quizQuestion.QuizId }, quizQuestion);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ein Fehler ist aufgetreten: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutQuizQuestion(long id, QuizQuestion quizQuestion)
        {
            if (id != quizQuestion.Id)
            {
                return BadRequest("Die ID stimmt nicht mit der Anfrage überein.");
            }

            _context.Entry(quizQuestion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.QuizQuestions.Any(q => q.Id == id))
                {
                    return NotFound($"Keine Quizfrage mit der ID {id} gefunden.");
                }

                throw;
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuizQuestion(long id)
        {
            var quizQuestion = await _context.QuizQuestions.FindAsync(id);

            if (quizQuestion == null)
            {
                return NotFound($"Keine Quizfrage mit der ID {id} gefunden.");
            }

            _context.QuizQuestions.Remove(quizQuestion);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
