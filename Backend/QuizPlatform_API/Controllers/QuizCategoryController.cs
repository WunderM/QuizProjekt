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
    public class QuizCategoryController : ControllerBase
    {
        private readonly PostgresContext _context;

        public QuizCategoryController(PostgresContext context)
        {
            _context = context;
        }

        // GET: api/QuizCategory
        [HttpGet]
        public async Task<ActionResult<IEnumerable<QuizCategory>>> GetQuizCategories()
        {
            return await _context.Set<QuizCategory>().ToListAsync();
        }

        // GET: api/QuizCategory/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<QuizCategory>> GetQuizCategory(long id)
        {
            var quizCategory = await _context.Set<QuizCategory>().FindAsync(id);

            if (quizCategory == null)
            {
                return NotFound();
            }

            return quizCategory;
        }

        // POST: api/QuizCategory
        [HttpPost]
        public async Task<ActionResult<QuizCategory>> CreateQuizCategory(QuizCategory quizCategory)
        {
            _context.Set<QuizCategory>().Add(quizCategory);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetQuizCategory), new { id = quizCategory.Id }, quizCategory);
        }

        // PUT: api/QuizCategory/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateQuizCategory(long id, QuizCategory quizCategory)
        {
            if (id != quizCategory.Id)
            {
                return BadRequest();
            }

            _context.Entry(quizCategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuizCategoryExists(id))
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

        // DELETE: api/QuizCategory/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuizCategory(long id)
        {
            var quizCategory = await _context.Set<QuizCategory>().FindAsync(id);
            if (quizCategory == null)
            {
                return NotFound();
            }

            _context.Set<QuizCategory>().Remove(quizCategory);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool QuizCategoryExists(long id)
        {
            return _context.Set<QuizCategory>().Any(e => e.Id == id);
        }
    }
}
