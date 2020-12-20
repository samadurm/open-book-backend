namespace OpenBook.Models
{    
    public class Course
    {
        public long Id { get; set; }
        public long TeacherId { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public uint Ratings { get; set; }
        public float AverageRating { get; set; }

        public static string[] categories = {
            "Cooking",
            "Technology",
            "Programming",
            "Science",
            "Literature",
            "Education",
            "History",
            "Miscellaneous"
        };

        public Course(string name, string category, string description = "")
        {
            Name = name;

            Category = category;
            TeacherId = 0; 

            Description = description;

            Ratings = 0;
            AverageRating = 0.0F;
        }

        public void addRating(short rating)
        {
            if (rating >= 0 && rating <= 5)
            {
                Ratings++;
                AverageRating = (AverageRating + rating) / Ratings;
            } 
            else {
                throw new System.Exception("Rating out of range. Must enter in range 1-5.");
            }
        }
    }
}