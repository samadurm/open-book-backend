using System;

namespace OpenBook.Models
{
    public class StudentCourses
    {
        public long Id { get; set; }
        public long StudentId { get; set; }
        public long CourseId { get; set; }

        public StudentCourses(long studentId, long courseId)
        {
            StudentId = studentId;
            CourseId = courseId;
        }
    }
}
