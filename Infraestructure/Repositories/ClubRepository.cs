using Applicatiom.Interfaces.IRepositories;
using Domain.Entities;
using MongoDB.Driver;

namespace Infraestructure.Repositories
{
    public class ClubRepository : IClubRepository
    {
        private readonly IMongoCollection<Club> _collection;
        private const string CollectionName = "Club";

        public ClubRepository (IMongoDatabase database)
        {
            _collection = database.GetCollection<Club>(CollectionName);
        }

        public Task<List<Club>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<Club> GetById(string id)
        {
            var filter = FilterById(id);
            return await _collection.Find(filter).FirstOrDefaultAsync();
        }

        public async Task Add(Club club)
        {
            await _collection.InsertOneAsync(club);
        }

        public async Task Update(Club club)
        {
            var filter = FilterById(club.Id);
            await _collection.ReplaceOneAsync(filter, club);
        }

        public Task Delete(string id)
        {
            throw new NotImplementedException();
        }

        private FilterDefinition<Club> FilterById(string id)
        {
            return Builders<Club>.Filter.Eq(c => c.Id, id);
        }
    }
}