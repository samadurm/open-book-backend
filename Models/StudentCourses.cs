namespace OpenBook.Models
{
    public class StudentCourses
    {
        public long Id { get; set; }
        public long StudentId { get; set; }
        public long CourseId { get; set; }
        public bool IsTeacher { get; set; }

        public StudentCourses(long studentId, long courseId, bool isTeacher = false)
        {
            StudentId = studentId;
            CourseId = courseId;
            IsTeacher = isTeacher;
        }
    }
}
