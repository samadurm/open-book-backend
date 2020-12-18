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
            new Person { FirstName = "Peter", LastName = "Jones", Email = "peter@gmail.com", IsTeacher = false},
            new Person { FirstName = "Barbara", LastName = "Miles", Email = "bmiles@gmail.com", IsTeacher = true},
        };

        [HttpGet]
        public ActionResult<IEnumerable<Person>> Get()
        {
            return people;
        }

        [HttpGet("{id}")]
        public ActionResult<Person> Get(int id)
        {
            return NotFound("Method not yet implemented!");
        }
 
        [HttpPost]
        public ActionResult<IEnumerable<Person>> Post(Person newContact)
        {
            people.Add(newContact);
            return people;
        }
    }
}