using Applicatiom.Interfaces.IRepositories;
using Domain.Entities;

namespace Infraestructure.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        public Task<Player> Add(Player player)
        {
            throw new NotImplementedException();
        }

        public Task<Player> Delete(string id)
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

        public Task<Player> Update(Player player)
        {
            throw new NotImplementedException();
        }
    }
}