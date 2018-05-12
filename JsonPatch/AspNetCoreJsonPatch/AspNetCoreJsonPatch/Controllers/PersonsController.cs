using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreJsonPatch.MongoDb;
using AspNetCoreJsonPatch.MongoDb.Repositories;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace AspNetCoreJsonPatch.Controllers
{
    [Route("api/[controller]")]
    public class PersonsController : Controller
    {
        private readonly PersonRepository _personRepository;

        public PersonsController(IMongoDatabaseProvider provider)
        {
            _personRepository = new PersonRepository(provider);
        }

        [HttpGet]
        public async Task<IEnumerable<PersonDto>> GetAllListAsync()
        {
            var persons = await _personRepository.GetAllListAsync();

            return from person in persons
                select new PersonDto
                {
                    OId = person.Id.ToString(),
                    Name = $"{person.FirstName} {person.LastName}"
                };
        }

        [HttpPatch("{id}")]
        public async Task<PersonDto> UpdateThenAddThenRemoveAsync(string id,
            [FromBody] JsonPatchDocument<Person> personPatch)
        {
            var objectId = new ObjectId(id);

            var person = await _personRepository.GetAsync(objectId);

            personPatch.ApplyTo(person);

            await _personRepository.UpdateAsync(person);

            return new PersonDto
            {
                OId = person.Id.ToString(),
                Name = $"{person.FirstName} {person.LastName}"
            };
        }
    }

    public class Person : IEntity<ObjectId>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Mail { get; set; }

        public string Address { get; set; }

        public ObjectId Id { get; set; }
    }

    public class PersonDto
    {
        public string Name { get; set; }

        public string OId { get; set; }
    }
}