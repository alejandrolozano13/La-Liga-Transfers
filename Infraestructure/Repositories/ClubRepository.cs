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

        public Task<Club> GetById(string id)
        {
            throw new NotImplementedException();
        }

        public async Task Add(Club club)
        {
            await _collection.InsertOneAsync(club);
        }

        public Task Delete(string id)
        {
            throw new NotImplementedException();
        }

        public Task Update(Club club)
        {
            throw new NotImplementedException();
        }
    }
}