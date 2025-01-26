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
        public IActionResult GetQuestions(long quizId, int limit = 20)
        {
            // Abrufen der Fragen ohne Mischen der Antworten
            var questions = _context.QuizQuestions
                .Where(q => q.QuizId == quizId)
                .Take(limit)
                .Select(q => new QuizQuestionDto
                {
                    Id = q.Id,
                    Question = q.Question,
                    Answers = new List<string> { q.AnswerTrue, q.AnswerFalseOne, q.AnswerFalseTwo, q.AnswerFalseThree }
                })
                .ToList();

            // Antworten mischen
            foreach (var question in questions)
            {
                question.Answers = ShuffleAnswers(question.Answers);
            }

            return Ok(questions);
        }

        // Mischen der Antworten (statische Methode)
        private static List<string> ShuffleAnswers(List<string> answers)
        {
            var rng = new Random();
            return answers.OrderBy(_ => rng.Next()).ToList();
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

    public class QuizQuestionDto
    {
        public long Id { get; set; }
        public string Question { get; set; } = string.Empty;
        public List<string> Answers { get; set; } = new List<string>();
    }
}
