using Applicatiom.Interfaces.IRepositories;
using Domain.Entities;

namespace Infraestructure.Repositories
{
    public class PositionRepository : IPositionRepository
    {
        public Task<List<Position>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Position> GetAllById(string id)
        {
            throw new NotImplementedException();
        }
    }
}