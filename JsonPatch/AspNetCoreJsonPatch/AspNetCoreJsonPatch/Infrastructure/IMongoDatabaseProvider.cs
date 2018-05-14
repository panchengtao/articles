using MongoDB.Driver;

namespace AspNetCoreJsonPatch.Infrastructure
{
    public interface IMongoDatabaseProvider
    {
        IMongoDatabase Database { get; }
    }
}