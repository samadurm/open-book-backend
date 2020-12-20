namespace OpenBook.Models
{
    public class CourseLessons
    {
        public long Id { get; set; }
        public long CourseId { get; set; }
        public long LessonId { get; set; }

        public CourseLessons(long courseId, long lessonId)
        {
            CourseId = courseId;
            LessonId = lessonId;
        }
    }
}