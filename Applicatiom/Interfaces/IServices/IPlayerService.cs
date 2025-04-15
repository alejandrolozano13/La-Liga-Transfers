using Domain.Entities;

namespace Applicatiom.Interfaces.IServices
{
    public interface IPlayerService
    {
        Task<List<Player>> GetAll();
        Task<Player> GetById(string id);
        Task Add(Player player);
        Task Update(Player player);
        Task Delete(string id);
    }
}