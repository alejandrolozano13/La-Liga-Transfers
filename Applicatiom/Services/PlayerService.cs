using Applicatiom.Interfaces.IRepositories;
using Applicatiom.Interfaces.IServices;
using Domain.Entities;

namespace Applicatiom.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly IPlayerRepository _playerRepository;

        public PlayerService(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        public async Task Add(Player player)
        {
            await _playerRepository.Add(player);
        }

        public Task Delete(string id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Player>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Player> GetById(string id)
        {
            throw new NotImplementedException();
        }

        public Task Update(Player player)
        {
            throw new NotImplementedException();
        }
    }
}