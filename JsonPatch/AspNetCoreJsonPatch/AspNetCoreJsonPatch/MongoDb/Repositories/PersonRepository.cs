using AspNetCoreJsonPatch.Controllers;

namespace AspNetCoreJsonPatch.MongoDb.Repositories
{
    public class PersonRepository : MongoDbRepositoryBase<Person>
    {
        public PersonRepository(IMongoDatabaseProvider databaseProvider) : base(databaseProvider)
        {
        }
    }
}