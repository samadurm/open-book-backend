namespace OpenBook.Models
{
    public class Lesson
    {
        public long Id { get; set; }
        public uint Number { get; set; }
        public string Title { get; set; }
        public string Filename { get; set; }
        public bool IsVideo { get; set; }

        public Lesson(string title, string filename, uint number, bool isVideo=false)
        {
            Title = title;
            Filename = filename;
            Number = number;
            IsVideo = isVideo;
        }
    }
}