using Applicatiom.Interfaces.IRepositories;
using Applicatiom.Interfaces.IServices;
using Domain.Entities;

namespace Applicatiom.Services
{
    public class ClubService : IClubService
    {
        private readonly IClubRepository _repository;
        private readonly IPlayerService _playerService;

        public ClubService(IClubRepository repository, IPlayerService service)
        {
            _repository = repository;
            _playerService = service;
        }

        public async Task<List<Club>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<Club> GetById(string id)
        {
            return await _repository.GetById(id);
        }

        public async Task Add(Club club)
        {
            await _repository.Add(club);   
        }

        public async Task Remove(string id)
        {
            await _repository.Delete(id);
            await _playerService.RemovePlayerClubAfterDeleteClub(id);
        }
    }
}