using System;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace AspNetCoreJsonPatch.MongoDb
{
    public class MongoDatabaseProvider : IMongoDatabaseProvider
    {
        public IConfiguration Configuration;

        public MongoDatabaseProvider(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IMongoDatabase Database
        {
            get
            {
                var client = new MongoClient(Configuration["MongoDatabaseConfiguration:ConnectionString"]);
                return client.GetDatabase(Configuration["MongoDatabaseConfiguration:DatabaseName"]);
            }
        }
    }
}