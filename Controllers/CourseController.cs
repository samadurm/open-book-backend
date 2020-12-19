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
    public class CourseController : ControllerBase
    {
        private readonly CourseContext _context;

        public CourseController(CourseContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Course>>> GetAllCourses()
        {
            return await _context.Courses.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Course>> GetCourse(long id)
        {
            var course = await _context.Courses.FindAsync(id);

            if (course == null)
            {
                return NotFound("No Course with this id exists in the database");
            }

            return Ok(course);
        }

        [HttpPost]
        public async Task<ActionResult<Person>> PostCourse(Course newCourse)
        {
            newCourse.TeacherId = 3; // SET THIS TO THE COURSE CREATOR'S ID SOMEHOW

            if (!Course.categories.Contains(newCourse.Category))
            {
                return BadRequest("Invalid category");
            }

            _context.Courses.Add(newCourse);

            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetCourse), new { id = newCourse.Id }, newCourse);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCourse(long id, Course course)
        {
            if (id != course.Id)
            {
                return BadRequest();
            }

            _context.Entry(course).State = EntityState.Modified;

            try 
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CourseExists(id))
                {
                    return NotFound("No Course with this id exists in the database");
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(long id)
        {
            var course = await _context.Courses.FindAsync(id);

            if (course == null)
            {
                return NotFound("No Course with this id exists in the database");
            }

            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet("categories")]
        public string[] GetCategories()
        {
            return Course.categories;
        }

        private bool CourseExists(long id)
        {
            return _context.Courses.Any(c => c.Id == id);
        }
    }
}