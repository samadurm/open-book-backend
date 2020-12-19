namespace OpenBook.Models
{
    public class Lesson
    {
        public long Id { get; set; }
        public uint Number { get; set; }
        public string Title { get; set; }
        public long CourseId { get; set; }
        public string TextContent { get; set; }

        public Lesson(string title, string textContent, uint number)
        {
            Title = title;
            TextContent = textContent;
            Number = number;
        }
    }
}