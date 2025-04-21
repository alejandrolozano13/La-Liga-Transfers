using Applicatiom.Interfaces.IRepositories;
using Domain.Entities;
using MongoDB.Driver;

namespace Infraestructure.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly IMongoCollection<Player> _collection;
        private const string CollectionName = "Players";

        public PlayerRepository(IMongoDatabase database)
        {
            _collection = database.GetCollection<Player>(CollectionName);
        }

        public async Task<List<Player>> GetAll()
        {
            return await _collection.Find(_ => true).ToListAsync();
        }

        public async Task<Player> GetById(string id)
        {
            var filter = FilterById(id);
            return await _collection.Find(filter).FirstOrDefaultAsync();
        }

        public async Task<List<Player>> GetByClubId(string clubId)
        {
            var filter = Builders<Player>.Filter.Eq(p => p.ClubId, clubId);
            return await _collection.Find(filter).ToListAsync();
        }

        public async Task Add(Player player)
        {
            await _collection.InsertOneAsync(player);
        }

        public async Task Update(Player player)
        {
            var filter = FilterById(player.Id);
            await _collection.ReplaceOneAsync(filter, player);
        }

        public async Task Delete(string id)
        {
            var filter = FilterById(id);
            await _collection.DeleteOneAsync(filter);
        }

        private FilterDefinition<Player> FilterById(string id)
        {
            return Builders<Player>.Filter.Eq(p => p.Id, id);
        }
    }
}