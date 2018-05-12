using MongoDB.Driver;

namespace AspNetCoreJsonPatch.MongoDb
{
    public interface IMongoDatabaseProvider
    {
        IMongoDatabase Database { get; }
    }
}