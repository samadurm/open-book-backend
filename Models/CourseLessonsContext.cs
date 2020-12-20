using Microsoft.EntityFrameworkCore;

namespace OpenBook.Models
{
    public class CourseLessonsContext : DbContext
    {
        public CourseLessonsContext(DbContextOptions<CourseLessonsContext> options)
            : base(options)
        {
        }

        public DbSet<CourseLessons> CourseLessons { get; set; }
    }
}