using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using OpenBook.Models;

namespace OpenBook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        public static string Path { get; } = "api/Person/";

        private List<Person> people = new List<Person> {
            new Person(firstName: "Peter", lastName: "Jones", email: "peter@gmail.com"),
            new Person(firstName: "Barbara", lastName: "Miles", email: "bmiles@gmail.com"),
        };

        [HttpGet]
        public ActionResult<IEnumerable<Person>> Get()
        {
            return people;
        }

        [HttpGet("{id}")]
        public ActionResult<Person> Get(int id)
        {
            Person person = people.FirstOrDefault(p => p.Id == id);
            
            if (person == null) 
            {
                return NotFound("No Person with this id exists in the database.");
            }
            
            return Ok(person);
        }
 
        [HttpPost]
        public ActionResult<IEnumerable<Person>> Post(Person newPerson)
        {
            if (newPerson.FirstName == null || newPerson.LastName == null || newPerson.Email == null)
            {
                return BadRequest("One or more of the fields was missing or invalid");
            }

            people.Add(newPerson);
            return Created(Path + $"{newPerson.Id}", newPerson);
        }

        [HttpPut("{id}")]
        public void Put(int id, Person newPerson)
        {

        }

        [HttpPatch("{id}")]
        public void Patch(int id)
        {

        }

        [HttpDelete("{id}")]
        public void Delete()
        {
            
        }
    }
}