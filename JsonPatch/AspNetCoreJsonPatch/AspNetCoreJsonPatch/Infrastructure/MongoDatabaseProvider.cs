using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace AspNetCoreJsonPatch.Infrastructure
{
    public class MongoDatabaseProvider : IMongoDatabaseProvider
    {
        private readonly IOptions<Settings> _settings;

        public MongoDatabaseProvider(IOptions<Settings> settings)
        {
            _settings = settings;
        }

        public IMongoDatabase Database
        {
            get
            {
                var client = new MongoClient(_settings.Value.ConnectionString);
                return client.GetDatabase(_settings.Value.Database);
            }
        }
    }
}