using Applicatiom.Interfaces.IRepositories;
using Domain.Entities;

namespace Infraestructure.Repositories
{
    public class TransferRepository : ITransferRepository
    {
        public Task<Transfer> Add(Transfer item)
        {
            throw new NotImplementedException();
        }

        public Task<List<Transfer>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Transfer> GetById(string id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Transfer>> GetByPlayerId(string playerId)
        {
            throw new NotImplementedException();
        }

        public Task<Transfer> Update(Transfer item)
        {
            throw new NotImplementedException();
        }
    }
}