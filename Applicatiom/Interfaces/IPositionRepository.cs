using Domain.Entities;

namespace Applicatiom.Interfaces
{
    public interface IPositionRepository
    {
        Task<List<Position>> GetAll();
        Task<Position> GetAllById(string id);
    }
}