using Microsoft.EntityFrameworkCore;

namespace OpenBook.Models
{
    public class LessonContext : DbContext
    {
        public LessonContext(DbContextOptions<LessonContext> options)
            : base(options)
        {
        }

        public DbSet<Lesson> Lessons { get; set; }
    }
}