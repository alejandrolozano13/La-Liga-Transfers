using Applicatiom.Interfaces.IRepositories;
using Applicatiom.Interfaces.IServices;
using Domain.Entities;

namespace Applicatiom.Services
{
    public class ClubService : IClubService
    {
        private readonly IClubRepository _repository;

        public ClubService(IClubRepository repository)
        {
            _repository = repository;
        }

        public async Task Add(Club club)
        {
            await _repository.Add(club);   
        }

        public Task<List<Club>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Club> GetById(string id)
        {
            throw new NotImplementedException();
        }

        public Task Remove(string id)
        {
            throw new NotImplementedException();
        }
    }
}