using Domain.Entities;

namespace Applicatiom.Interfaces
{
    public interface IPlayerRepository
    {
        Task<List<Player>> GetAll();
        Task<Player> GetById(string id);
        Task<Player> Add (Player player);
        Task<Player> Update (Player player);
        Task<Player> Delete (string id);
    }
}