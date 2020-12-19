using System.Collections.Generic;

namespace OpenBook.Models
{    
    public class Course
    {
        public long Id { get; set; }
        public long TeacherId { get; set; }
        public List<long> Students { get; }
        public string Name { get; set; }
        public string Category { get; set; }
        public int NumStudents { get; set; }

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

        public Course(string name, string category)
        {
            Name = name;
            Category = category;
            TeacherId = 0; 

            NumStudents = 0;
            Students = new List<long>();
        }

        public void addStudent(long id)
        {
            Students.Add(id);
            NumStudents++;
        }

        public void removeStudent(long id)
        {
            if (Students.Count > 0)
            {
                Students.Remove(id);    
                NumStudents--;
            }
        }
    }
}