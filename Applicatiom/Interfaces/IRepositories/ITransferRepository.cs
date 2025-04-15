using Domain.Entities;

namespace Applicatiom.Interfaces.IRepositories
{
    public interface ITransferRepository
    {
        Task<List<Transfer>> GetAll();
        Task<Transfer> GetById(string id);
        Task<List<Transfer>> GetByPlayerId(string playerId);
        Task<Transfer> Add(Transfer item);
        Task<Transfer> Update(Transfer item);
    }
}