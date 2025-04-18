using Domain.Entities;

namespace Applicatiom.Interfaces.IRepositories
{
    public interface IPlayerRepository
    {
        Task<List<Player>> GetAll();
        Task<Player> GetById(string id);
        Task Add(Player player);
        Task Update(Player player);
        Task Delete(string id);
    }
}