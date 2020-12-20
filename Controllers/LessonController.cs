using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OpenBook.Models;
using Microsoft.AspNetCore.Authorization;

namespace OpenBook.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LessonController : ControllerBase
    {
        private readonly LessonContext _context;
        public LessonController(LessonContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Lesson>>> GetAllLessons()
        {
            return await _context.Lessons.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Lesson>> GetLesson(long id)
        {
            var lesson = await _context.Lessons.FindAsync(id);

            if (lesson == null)
            {
                return NotFound("No Lesson with this id exists in the database");
            }

            return Ok(lesson);
        }

        [HttpPost]
        public async Task<ActionResult<Lesson>> PostLesson(Lesson newLesson)
        {
            newLesson.CourseId = 3; // SET THIS TO THE COURSE'S ID when its created!

            _context.Lessons.Add(newLesson);

            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetLesson), new { id = newLesson.Id }, newLesson);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutLesson(long id, Lesson lesson)
        {
            if (id != lesson.Id)
            {
                return BadRequest();
            }

            _context.Entry(lesson).State = EntityState.Modified;

            try 
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LessonExists(id))
                {
                    return NotFound("No Lesson with this id exists in the database");
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLesson(long id)
        {
            var lesson = await _context.Lessons.FindAsync(id);

            if (lesson == null)
            {
                return NotFound("No Lesson with this id exists in the database");
            }

            _context.Lessons.Remove(lesson);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LessonExists(long id)
        {
            return _context.Lessons.Any(l => l.Id == id);
        }
    }
}