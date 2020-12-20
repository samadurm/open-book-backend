using System.Collections.Generic;
using System.Linq;

namespace OpenBook.Models
{    
    public class Course
    {
        public long Id { get; set; }
        public long TeacherId { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public int NumStudents { get; set; }
        public short Ratings { get; set; }
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

            NumStudents = 0;

            Ratings = 0;
            AverageRating = 0.0F;
        }

        //public void addStudent(long id)
        //{
        //    Students.Add(id);
        //    NumStudents++;
        //}

        //public void removeStudent(long id)
        //{
        //    if (Students.Count > 0)
        //    {
        //        Students.Remove(id);    
        //        NumStudents--;
        //    } 
        //    else
        //    {
        //        throw new System.Exception("Cannot remove student from empty students list.");
        //    }
        //}

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