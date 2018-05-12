using MongoDB.Driver;

namespace AspNetCoreJsonPatch.MongoDb
{
    public class MongoDatabaseProvider : IMongoDatabaseProvider
    {
        public IMongoDatabase Database
        {
            get
            {
                var client = new MongoClient("mongodb://localhost:27017");
                return client.GetDatabase("example");
            }
        }
    }
}