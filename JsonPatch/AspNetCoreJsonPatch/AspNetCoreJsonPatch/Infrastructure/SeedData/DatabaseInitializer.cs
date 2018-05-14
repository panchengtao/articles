using AspNetCoreJsonPatch.Models;
using AspNetCoreJsonPatch.MongoDb.Repositories;

namespace AspNetCoreJsonPatch.Infrastructure.SeedData
{
    public class DatabaseInitializer
    {
        private readonly IMongoDatabaseProvider _mongoDatabaseProvider;

        public DatabaseInitializer(IMongoDatabaseProvider mongoDatabaseProvider)
        {
            _mongoDatabaseProvider = mongoDatabaseProvider;
        }

        public void Initialize()
        {
            var repository = new PersonRepository(_mongoDatabaseProvider);
            repository.Database.DropCollection(typeof(Person).Name.ToLower());
            repository.InsertAsync(new Person
            {
                FirstName = "LeBron",
                LastName = "James",
                Mail = "Example Mail",
                Address = string.Empty
            }).GetAwaiter().GetResult();
        }
    }
}