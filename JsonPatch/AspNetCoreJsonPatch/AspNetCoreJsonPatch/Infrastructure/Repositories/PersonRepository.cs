using AspNetCoreJsonPatch.Infrastructure;
using AspNetCoreJsonPatch.Infrastructure.Repositories;
using AspNetCoreJsonPatch.Models;

namespace AspNetCoreJsonPatch.MongoDb.Repositories
{
    public class PersonRepository : MongoDbRepositoryBase<Person>
    {
        public PersonRepository(IMongoDatabaseProvider databaseProvider) : base(databaseProvider)
        {
        }
    }
}