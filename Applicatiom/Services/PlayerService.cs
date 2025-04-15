using Applicatiom.Interfaces.IServices;
using Domain.Entities;

namespace Applicatiom.Services
{
    public class PlayerService : IPlayerService
    {
        public Task Add(Player player)
        {
            throw new NotImplementedException();
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