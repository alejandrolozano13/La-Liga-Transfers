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

        public Task<List<Player>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Player> GetById(string id)
        {
            throw new NotImplementedException();
        }

        public async Task Add(Player player)
        {
            await _collection.InsertOneAsync(player);
        }

        public Task Update(Player player)
        {
            throw new NotImplementedException();
        }

        public Task Delete(string id)
        {
            throw new NotImplementedException();
        }
    }
}