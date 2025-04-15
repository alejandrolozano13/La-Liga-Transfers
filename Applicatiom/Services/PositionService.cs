using Applicatiom.Interfaces.IServices;
using Domain.Entities;

namespace Applicatiom.Services
{
    public class PositionService : IPositionService
    {
        public Task Add(Position position)
        {
            throw new NotImplementedException();
        }

        public Task Delete(string id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Position>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Position> GetById(string id)
        {
            throw new NotImplementedException();
        }

        public Task Update(Position position)
        {
            throw new NotImplementedException();
        }
    }
}