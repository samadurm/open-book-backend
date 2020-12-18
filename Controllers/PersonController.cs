using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OpenBook.Models;

namespace OpenBook.Controllers
{
    [Route("api/[controller]")] 
    [ApiController]
    public class PersonController : ControllerBase
    {
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
            
            Console.WriteLine(Request);

            if (person == null) 
            {
                return NotFound("No Person with this id exists in the database.");
            }
            
            return Ok(person);
        }
 
        [HttpPost]
        public ActionResult<IEnumerable<Person>> Post(Person newContact)
        {
            people.Add(newContact);
            return people;
        }
    }
}