using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreJsonPatch.Controllers
{
    [Route("api/[controller]")]
    public class PersonsController : Controller
    {
        [HttpPatch("{id}")]
        public dynamic UpdateThenAddThenRemove(int id, [FromBody] JsonPatchDocument<Person> personPatch)
        {
            var persons = new List<Person>
            {
                new Person
                {
                    Id = 1,
                    FirstName = "Jim",
                    LastName = "Smith",
                    Mails = new List<string>
                    {
                        "example@example.com"
                    }
                }
            };

            var person = persons.FirstOrDefault(c => c.Id == id);

            personPatch.ApplyTo(person);

            return person;
        }
    }

    public class Person
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public List<string> Mails { get; set; }

        public List<string> Addresses { get; set; }
    }
}