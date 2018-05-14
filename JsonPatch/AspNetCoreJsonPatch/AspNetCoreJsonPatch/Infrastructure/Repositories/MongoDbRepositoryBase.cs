using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreJsonPatch.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace AspNetCoreJsonPatch.Infrastructure.Repositories
{
    public class MongoDbRepositoryBase<TEntity> : MongoDbRepositoryBase<TEntity, ObjectId>
        where TEntity : class, IEntity<ObjectId>
    {
        public MongoDbRepositoryBase(IMongoDatabaseProvider databaseProvider)
            : base(databaseProvider)
        {
        }
    }

    public class MongoDbRepositoryBase<TEntity, TPrimaryKey>
        where TEntity : IEntity<TPrimaryKey>
    {
        private readonly IMongoDatabaseProvider _databaseProvider;

        public MongoDbRepositoryBase(IMongoDatabaseProvider databaseProvider)
        {
            _databaseProvider = databaseProvider;
        }

        public IMongoDatabase Database => _databaseProvider.Database;

        public IMongoCollection<TEntity> Collection =>
            _databaseProvider.Database.GetCollection<TEntity>(typeof(TEntity).Name.ToLower());

        public IQueryable<TEntity> GetAll()
        {
            return Collection.AsQueryable();
        }

        public async Task<List<TEntity>> GetAllListAsync()
        {
            return await Collection.AsQueryable().ToListAsync();
        }

        public async Task<TEntity> GetAsync(TPrimaryKey id)
        {
            var entity = await Collection.Find(c => c.Id.Equals(id)).FirstOrDefaultAsync();
            if (entity == null)
                throw new Exception("There is no such an entity with given primary key. Entity type: " +
                                    typeof(TEntity).FullName + ", primary key: " + id);

            return entity;
        }

        public async Task<TEntity> InsertAsync(TEntity entity)
        {
            await Collection.InsertOneAsync(entity);
            return entity;
        }

        public async Task UpdateAsync(TEntity entity)
        {
            var filter = Builders<TEntity>.Filter.Eq("_id", entity.Id);

            var properties = typeof(TEntity).GetProperties();
            foreach (var propertyInfo in properties)
            {
                var value = propertyInfo.GetValue(entity);

                var update = Builders<TEntity>.Update.Set(propertyInfo.Name, value);

                await Collection.UpdateOneAsync(filter, update);
            }
        }

        public async Task DeleteAsync(TEntity entity)
        {
            await DeleteAsync(entity.Id);
        }

        public async Task DeleteAsync(TPrimaryKey id)
        {
            await Collection.DeleteOneAsync(c => c.Id.Equals(id));
        }
    }
}