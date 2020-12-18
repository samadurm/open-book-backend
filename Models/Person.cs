using System;
using System.Collections.Generic;

namespace OpenBook.Models
{
    public class Person
    {
        public static long NumPersons = 0; // remove this once the database is set up
        public long Id { get; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime DateCreated { get; }
        public bool IsTeacher { get; set; }
        public List<int> CoursesTaught { get; }
        public List<int> SubscribedCourses { get; }

        public Person(string firstName, string lastName, string email)
        {
            // get rid of this once the database is set up
            Id = NumPersons;
            NumPersons++;

            FirstName = firstName;
            LastName = lastName;
            Email = email;

            CoursesTaught = new List<int>();
            SubscribedCourses = new List<int>();

            DateCreated = DateTime.Now;
            IsTeacher = false;
        }
    }
}