using System;
using System.Collections.Generic;

namespace OpenBook.Models
{
    public class Person
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime DateCreated { get; }
        public bool IsTeacher { get; set; }
        public List<int> CoursesTaught { get; }
        public List<int> SubscribedCourses { get; }

        public Person(string firstName, string lastName, string email)
        {
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