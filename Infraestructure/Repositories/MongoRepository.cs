using MongoDB.Bson;
using MongoDB.Driver;

namespace Infraestructure.Repositories
{
    public class MongoRepository<T> where T : class
    {
        private readonly IMongoDatabase _database;

        public MongoRepository(IMongoDatabase database)
        { 
            _database = database;
        }

        public IMongoCollection<T> GetCollection(string? collectionName = null)
        {
            var name = collectionName ?? $"{typeof(T).Name}s";
            return _database.GetCollection<T>(name);
        }

        public async Task CreateCollectionIfNotExists(string? collectionName = null)
        {
            var name = collectionName ?? $"{typeof(T).Name}s";

            var filter = new BsonDocument("name", name);
            var collections = await _database.ListCollectionsAsync(new ListCollectionsOptions { Filter = filter});

            if(!await collections.AnyAsync())
            {
                await _database.CreateCollectionAsync(name);
            }
        }
    }
}