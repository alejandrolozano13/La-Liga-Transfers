using Domain.Entities;

namespace Applicatiom.Services
{
    public interface IPositionService
    {
        Task<List<Position>> GetAll();
        Task<Position> GetById(string id);
        Task Add (Position position);
        Task Update (Position position);
        Task Delete (string id);
    }
}