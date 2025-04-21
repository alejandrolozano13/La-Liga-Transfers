using Applicatiom.DTOs;
using Domain.Entities;

namespace Applicatiom.Interfaces.IServices
{
    public interface IPlayerService
    {
        Task<List<Player>> GetAll();
        Task<Player> GetById(string id);
        Task<List<Player>> GetByClubId (string clubId);
        Task Add(PlayerDto player);
        Task Update(string id, Player player);
        Task Delete(string id);
        Task RemovePlayerClubAfterDeleteClub(string clubId);
    }
}