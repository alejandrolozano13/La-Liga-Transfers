using Applicatiom.DTOs;
using Domain.Entities;

namespace Applicatiom.Interfaces.IRepositories
{
    public interface IPlayerRepository
    {
        Task<List<Player>> GetAll();
        Task<Player> GetById(string id);
        Task<List<Player>> GetByClubId(string clubId);
        Task Add(Player   player);
        Task Update(Player player);
        Task Delete(string id);
    }
}