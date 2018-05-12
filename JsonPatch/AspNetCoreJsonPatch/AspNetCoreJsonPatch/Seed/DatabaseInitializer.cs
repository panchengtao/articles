using AspNetCoreJsonPatch.Controllers;
using AspNetCoreJsonPatch.MongoDb;
using AspNetCoreJsonPatch.MongoDb.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace AspNetCoreJsonPatch.Seed
{
    public class DatabaseInitializer
    {
        public static void Initialize()
        {
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IMongoDatabaseProvider, MongoDatabaseProvider>()
                .BuildServiceProvider();

            var provider = serviceProvider.GetService<IMongoDatabaseProvider>();
            var repository = new PersonRepository(provider);

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