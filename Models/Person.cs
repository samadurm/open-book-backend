using System;

namespace OpenBook.Models
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public bool IsTeacher { get; set; } = false;
        
        // Todo: Add a list of courses that a Person is a part of
    }
}