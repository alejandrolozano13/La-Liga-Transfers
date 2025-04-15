using Domain.Entities;

namespace Applicatiom.Interfaces.IServices
{
    public interface IPositionService
    {
        Task<List<Position>> GetAll();
        Task<Position> GetById(string id);
        Task Add(Position position);
        Task Update(Position position);
        Task Delete(string id);
    }
}