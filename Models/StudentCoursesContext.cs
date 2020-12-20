using Microsoft.EntityFrameworkCore;

namespace OpenBook.Models
{
    public class StudentCoursesContext : DbContext
    {
        public StudentCoursesContext(DbContextOptions<StudentCoursesContext> options)
            : base(options)
        {
        }

        public DbSet<StudentCourses> StudentCourses { get; set; }
    }
}